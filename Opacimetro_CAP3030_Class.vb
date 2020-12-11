Imports System.Windows.Forms
Imports System.Threading
Imports System.IO.Ports

Public Class Opacimetro_CAP3030_Class
    Public Shared _serialPort As SerialPort
    Private tmrComunicacion As Windows.Forms.Timer
    Private tmrBenchBusy As Windows.Forms.Timer
    Public Shared _timeOut, _timeOutBusy As Boolean
    Public Shared data_rcv(100) As Byte 'Buffer para recepcion de datos
    Public Shared _readData As Boolean
    Dim readThread As New Thread(AddressOf Read)
    Public Shared _count As UInteger    'Cantidad de datos recibidos por el puerto serial
    Public Shared _errMsg As String


    'Constantes control de comunicacion
    Const CerraAplicativo As UInteger = 100
    Const TimerTimeOut As UInteger = 101
    Const RxExcepcion As Integer = 102
    Const ErrData As UInteger = 103
    Const Excepcion As UInteger = 104
    Const CantDataErr As UInteger = 105


    Const NACK As UInteger = 21
    Const ACK As UInteger = 6

    Public Shared _continueValue As Boolean
    Public Property _continue() As Boolean
        Get
            Return _continueValue
        End Get
        Set(value As Boolean)
            _continueValue = value
        End Set
    End Property


    Public Sub New(portName As String)

        tmrComunicacion = New Windows.Forms.Timer()
        tmrComunicacion.Enabled = False
        AddHandler tmrComunicacion.Tick, AddressOf TmrComunicacion_Tick

        tmrBenchBusy = New Windows.Forms.Timer()
        tmrBenchBusy.Enabled = False
        AddHandler tmrBenchBusy.Tick, AddressOf TmrBenchBusy_Tick


        _serialPort = New SerialPort()
        _serialPort.PortName = portName
        _serialPort.BaudRate = 9600
        _serialPort.DataBits = 8
        _serialPort.StopBits = 1



        _readData = False
        _continueValue = True
        readThread.Start()



    End Sub


    Public Function Comando_getVersion(ByRef version As UInt16, ByRef serialNum As UInt16) As String
        Try
            Dim response, strResult() As String
            Dim data(3) As Byte

            response = send_Opacimetro_command("v", data, 0)
            strResult = response.Split(",")
            If strResult(0) = "1" Then
                version = BitConverter.ToUInt16(data_rcv, 1)
                serialNum = BitConverter.ToUInt16(data_rcv, 3)
                Return "1,ACK"
            End If
            Return response
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function
    Private Function send_Opacimetro_command(command As Char, data_in As Byte(), DataCount As UInteger) As String
        Try

            Dim chkSumT As UInteger
            Dim chkSum As Integer
            Dim data_send(100) As Byte
            Dim i, j As UInteger
            Dim txtConsola As String
            Dim commandB As Byte

            commandB = AscW(command)
            'chkSumT = command + MODE + CantidadDatos

            'For Each d In data_in
            'chkSumT += d
            'Next

            'chkSum = chkSumT Mod &H10000

            'Encabezado trama
            data_send(0) = commandB
            i = 1
            If DataCount <> 0 Then
                'Agregar datos del comando
                For Each d In data_in
                    data_send(i) = d
                    i += 1
                Next
            End If

            'Calcular ChkSum
            chkSumT = 0
            For j = 0 To i - 1
                chkSumT += data_send(j)
            Next
            chkSum = (-1 * chkSumT)

            'Agregar ChkSum a la trama de datos
            data_send(i) = chkSum And &HFF

            txtConsola = "data_send= "
            Console.Write("data_send: ")
            For i = 0 To DataCount + 2
                txtConsola += data_send(i).ToString + ":"
                Console.Write(data_send(i).ToString)
                Console.Write(":")
            Next
            Console.WriteLine()
            _serialPort.Open()             'abrir puerto
            _serialPort.DiscardInBuffer()  'Borrar buffer de recpecion para eliminar posible ruido
            data_rcv.Initialize()                  'Inicializa buffer de recepcion                           
            _serialPort.ReceivedBytesThreshold = 1
            _continueValue = True
            _count = 0
            _serialPort.Write(data_send, 0, DataCount + 2) 'Envia trama
            'Inicializa temporizador de 2 segundos para recibir paquete

            Delay(1)

            _readData = True
            'Inicia Thread de recepcion
            'inicia timer de recepcion. Si al cabo de 2 segundo no ha recibido paquete retorna
            IniTemporizador(2)
            '_count indica si se han recibido datos
            '_continueValue indica si se ha cerrado el aplicativo
            '_timeOut indica que se agoto el tiempo de espera
            While (_count = 0) And (_continueValue = True) And (_timeOut = False)
                Application.DoEvents()
            End While
            _readData = False

            _serialPort.Close() 'Cierra puerto serial

            If _continueValue = False Then
                Return "0,CerraAplicativo"
            ElseIf _timeOut Then
                Return "0,Opacimetro no responde Tiempo de espera agotado"
            ElseIf _count = RxExcepcion Then
                Return "0," + _errMsg  'si ha ocurrido una excepcion en la recepcion
            End If
            Console.WriteLine("data_rcv: " + _count.ToString)
            For i = 0 To _count - 1
                txtConsola += data_rcv(i).ToString + ":"
                Console.Write(data_rcv(i).ToString + ":")
            Next
            Console.WriteLine()


            chkSumT = 0
            For j = 0 To i - 1
                chkSumT += data_send(j)
            Next
            chkSum = (-1 * chkSumT)
            chkSumT = 0
            For j = 0 To _count - 2
                chkSumT += data_rcv(j)
            Next
            chkSum = (-1 * chkSumT) And &HFF



            If chkSum <> data_rcv(_count - 1) Then
                Return "0,NACK"
            ElseIf data_rcv(0) <> commandB Then ' el comando enviado y le recibido deben ser iguales
                Return "0,NACK"
            End If
            Return "1,ACK" 'retorna respuesta del comando

        Catch ex As Exception
            If _serialPort.IsOpen Then
                _serialPort.Close()
            End If
            Return "0," + ex.Message
        End Try
    End Function
    Public Shared Sub Read()
        Try
            While _continueValue
                If _readData Then
                    _count = _serialPort.Read(data_rcv, 0, 100)
                    _readData = False
                End If
            End While
        Catch generatedExceptionName As TimeoutException
            _count = RxExcepcion
            _errMsg = generatedExceptionName.Message
        Catch ex As Exception
            _count = RxExcepcion
            _errMsg = ex.Message
        Finally
            If _serialPort.IsOpen Then
                _serialPort.Close()
            End If
        End Try
    End Sub
    Private Sub IniTemporizador(segundos As UInteger)
        'Inicializa temporizador de 2 segundos para recibir paquete

        tmrComunicacion.Interval = segundos * 1000
        tmrComunicacion.Enabled = True
        tmrComunicacion.Start()
        _timeOut = False
    End Sub

    Private Sub TmrComunicacion_Tick(sender As Object, e As EventArgs)
        tmrComunicacion.Enabled = False
        tmrComunicacion.Stop()
        _timeOut = True
    End Sub


    Private Sub IniTemporizadorBenchBusy(segundos As UInteger)
        'Inicializa temporizador de 2 segundos para recibir paquete

        tmrBenchBusy.Interval = segundos * 1000
        tmrBenchBusy.Enabled = True
        tmrBenchBusy.Start()
        _timeOutBusy = False
    End Sub

    Private Sub TmrBenchBusy_Tick(sender As Object, e As EventArgs)
        tmrBenchBusy.Enabled = False
        tmrBenchBusy.Stop()
        _timeOutBusy = True
    End Sub

    Private Sub Delay(ByVal seconds As Single)
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        Do While Microsoft.VisualBasic.Timer() < start + seconds
            System.Windows.Forms.Application.DoEvents()
        Loop
    End Sub
End Class
