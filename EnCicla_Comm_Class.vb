Imports System.IO.Ports
Imports System.Threading
Imports System.Windows.Forms

Public Class EnCicla_Comm_Class



    'Public Shared _serialPort As SerialPort
    'Private tmrComunicacion As Windows.Forms.Timer

    'Dim readThread As New Thread(AddressOf Read)


    ''Constantes control de comunicacion

    'Const CerraAplicativo As UInteger = 100
    'Const TimerTimeOut As UInteger = 101
    'Const RxExcepcion As Integer = 102
    'Const respuestaOK As UInteger = 103

    'Public Shared _readData As Boolean 'Si se cierra la App _continue = False para terminar los loops de recepcion 
    'Public Shared _count As UInteger    'Cantidad de datos recibidos por el puerto serial
    'Public Shared data_rcv(100) As Char 'Buffer para recepcion de datos
    'Public Shared _timeOut As Boolean   'Indica si el timer ha expirado
    'Public Shared _errMsg As String

    'Public Shared _continueValue As Boolean
    'Public Property _continue() As Boolean
    '    Get
    '        Return _continueValue
    '    End Get
    '    Set(value As Boolean)
    '        _continueValue = value
    '    End Set
    'End Property

    'Public Shared _tramaValue As String
    'Public Property _trama() As String
    '    Get
    '        Return _tramaValue
    '    End Get
    '    Set(value As String)
    '        _tramaValue = value
    '    End Set
    'End Property


    'Public Shared _tramaStatusValue As Bo
    'Public Property _tramaStatus() As Integer
    '    Get
    '        Return _tramaStatusValue
    '    End Get
    '    Set(value As Integer)
    '        _tramaStatusValue = value
    '    End Set
    'End Property

    'Public Sub New(portName As String)

    '    tmrComunicacion = New Windows.Forms.Timer()
    '    tmrComunicacion.Enabled = False
    '    AddHandler tmrComunicacion.Tick, AddressOf tmrComunicacion_Tick

    '    _serialPort = New SerialPort()
    '    _serialPort.PortName = portName
    '    _serialPort.BaudRate = 9600
    '    _serialPort.DataBits = 8
    '    _serialPort.StopBits = 1

    '    _readData = False
    '    _continueValue = True
    '    readThread.Start()

    '    AddHandler _serialPort.DataReceived, New SerialDataReceivedEventHandler(AddressOf SerialPort_DataReceived)


    'End Sub


    'Public Function comando_Escanear(numModulo As Integer)
    '    Dim comando As String = "#"
    '    Dim respuesta As String = ""
    '    Dim status As Integer


    '    comando += numModulo.ToString("D2")
    '    comando += "0301"

    '    status = enviar_comando(comando, respuesta)
    '    Select Case status

    '        Case respuestaOK
    '            Return respuesta
    '        Case CerraAplicativo
    '            Return "0,CerraAplicativo"
    '        Case TimerTimeOut
    '            Return "1,"
    '        Case RxExcepcion
    '            Return "0," + _errMsg
    '        Case Else
    '            Return "0,Err Respuesta"
    '    End Select

    'End Function



    'Private Function enviar_comando(comando As String, ByRef respuesta As String) As Integer




    '    _serialPort.Open()             'abrir puerto
    '    _serialPort.DiscardInBuffer()  'Borrar buffer de recpecion para eliminar posible ruido
    '    data_rcv.Initialize()                  'Inicializa buffer de recepcion                           
    '    '_serialPort.ReceivedBytesThreshold = 1
    '    _continueValue = True
    '    _count = 0
    '    _serialPort.Write(comando + vbCrLf) 'Envia trama
    '    'Inicializa temporizador de 0.5 segundos para recibir paquete
    '    IniTemporizador(1)
    '    'espera que el temprozador de la señal de timeOut
    '    While _timeOut = False
    '        Application.DoEvents()
    '    End While
    '    _readData = True
    '    'Inicia Thread de recepcion
    '    'inicia timer de recepcion. Si al cabo de 2 segundo no ha recibido paquete retorna
    '    IniTemporizador(2)
    '    '_count indica si se han recibido datos
    '    '_continueValue indica si se ha cerrado el aplicativo
    '    '_timeOut indica que se agoto el tiempo de espera
    '    While (_count = 0) And (_continueValue = True) And (_timeOut = False)
    '        Application.DoEvents()
    '    End While
    '    _readData = False

    '    _serialPort.Close() 'Cierra puerto serial

    '    If _continueValue = False Then
    '        Return CerraAplicativo
    '    ElseIf _timeOut Then
    '        Return TimerTimeOut
    '    ElseIf _count = RxExcepcion Then
    '        Return RxExcepcion  'si ha ocurrido una excepcion en la recepcion
    '    End If
    '    Console.WriteLine("data_rcv: " + _count.ToString)
    '    For i = 0 To _count - 1
    '        respuesta += data_rcv(i)
    '        Console.Write(data_rcv(i))
    '    Next
    '    Console.WriteLine()

    '    Return respuestaOK
    'End Function

    'Public Shared Sub Read()
    '    Try
    '        While _continueValue
    '            If _readData Then
    '                _count = _serialPort.Read(data_rcv, 0, 100)
    '                _readData = False
    '            End If

    '        End While
    '    Catch generatedExceptionName As TimeoutException
    '        _count = RxExcepcion
    '        _errMsg = generatedExceptionName.Message
    '    Catch ex As Exception
    '        _count = RxExcepcion
    '        _errMsg = ex.Message
    '    Finally
    '        If _serialPort.IsOpen Then
    '            _serialPort.Close()
    '        End If
    '    End Try
    'End Sub

    'Private Sub IniTemporizador(segundos As Double)
    '    'Inicializa temporizador de 2 segundos para recibir paquete

    '    tmrComunicacion.Interval = segundos * 1000
    '    tmrComunicacion.Enabled = True
    '    tmrComunicacion.Start()
    '    _timeOut = False
    'End Sub

    'Private Sub tmrComunicacion_Tick(sender As Object, e As EventArgs)
    '    tmrComunicacion.Enabled = False
    '    tmrComunicacion.Stop()
    '    _timeOut = True
    'End Sub


    'Private Sub SerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs)
    '    Try
    '        _tramaValue = _serialPort.ReadTo(vbCr)
    '        _tramaStatusValue = respuestaOK
    '    Catch exT As TimeoutException
    '        _tramaValue = exT.Message
    '        _tramaStatusValue = TimerTimeOut
    '    Catch ex As Exception
    '        _tramaValue = ex.Message
    '        _tramaStatusValue = RxExcepcion
    '    End Try

    'End Sub

End Class
