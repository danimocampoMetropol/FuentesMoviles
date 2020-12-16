Imports System.Windows.Forms
Imports System.Threading
Imports System.IO.Ports

Public Class Opacimetro_CAP3030_Class
    Public Shared _serialPort As SerialPort
    Private tmrComunicacion As Windows.Forms.Timer
    Private tmrBenchBusy As Windows.Forms.Timer
    Public Shared _timeOut, _timeOutBusy As Boolean
    Public Shared data_rcv(1100) As Byte 'Buffer para recepcion de datos
    Public Shared _readData As Boolean
    Dim readThread As New Thread(AddressOf Read)
    Public Shared _count As UInteger    'Cantidad de datos recibidos por el puerto serial
    Public Shared _errMsg As String

    'Comandos Sensor Microbench
    Const OPAGetVersion As UInteger = 119 ' ascii "v"
    Const OPAGetNonFilteredOpacity As UInteger = &H8B
    Const OPAGetFilteredOpacity As UInteger = 117 ' ascii "u"
    Const OPAZero As UInteger = 108 ' ascii "l"
    Const OPAMesuramentTable As UInteger = 111 ' ascii "o"
    Const OPADemandAcquisition As UInteger = 97 ' ascii "a"
    Const OPATrigSampling As UInteger = 116 ' ascii "t"
    Const OPAStopSampling As UInteger = 113 ' ascii "q"
    Const OPAReadEEPROM As UInteger = 109 ' ascii "m"
    Const OPAWriteEEPROM As UInteger = 110 ' ascii "n"
    Const OPAREadWriteIntensity As UInteger = 99 ' ascii "c"
    Const OPAStartStopFan As UInteger = 115 ' ascii "s"
    Const OPAReadWriteSelectionMesuramentFilter As UInteger = 101 ' ascii "e"
    Const OPAReadWriteMinimunValue_GasTemp As UInteger = 104 ' ascii "h"
    Const OPAReadWriteCleanWindow As UInteger = 107 ' ascii "k"
    Const OPAReadOpacityCurve As UInteger = &H8A
    Const OPAReadCurrFactorAcquisition As UInteger = 119 ' ascii "w
    Const OPAReadValueSmokePeak As UInteger = 98 ' ascii "b"
    Const OPAReadVariousInternalData As UInteger = 85 ' ascii "U"
    Const OPAAdjustGainDetector As UInteger = 100 ' ascii "d"



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



    Structure filteredOpacityStatus
        Dim ambienTempUnvalid As Boolean
        Dim detectorTempUnvalid As Boolean
        Dim tubeTempUnvalid As Boolean
        Dim PowerSupplyOutTolarance As Boolean
        Dim fanState As Boolean
        Dim opacityNonAvailable As Boolean
        Dim trasnducerStandBy As Boolean
        Dim zeroRunning As Boolean
        Dim sootingLenses As Boolean
        Dim acquisitionTriggered As Boolean
        Dim triggerActivated As Boolean
        Dim faultFans As Boolean
        Dim gasTempCold As Boolean
        Dim faultTempSensor As Boolean
    End Structure

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


    Public Function Comando_getVersion(ByRef version As Double, ByRef serialNum As UInt16) As String
        Try
            Dim response, strResult() As String
            Dim data(3) As Byte

            response = send_Opacimetro_command(OPAGetVersion, data, 0)
            strResult = response.Split(",")
            If strResult(0) = "1" Then
                version = CDbl(convertMSByte_toUInt16(data_rcv, 1)) / 100.0
                serialNum = convertMSByte_toUInt16(data_rcv, 3)
                Return "1,ACK"
            End If
            Return response
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_NonFilteredOpacity(ByRef opacity As Double) As String
        Try
            Dim response, strResult() As String
            Dim data(3) As Byte

            response = send_Opacimetro_command(OPAGetNonFilteredOpacity, data, 0)
            strResult = response.Split(",")
            If strResult(0) = "1" Then
                opacity = CDbl(convertMSByte_toUInt16(data_rcv, 1)) / 10.0
                Return "1,ACK"
            End If
            Return response
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_FilteredOpacity(ByRef opacity As Double,
                                            ByRef gasTemp As UInt16,
                                            ByRef tubeTemp As UInt16,
                                            ByRef status As filteredOpacityStatus) As String
        Try
            Dim response, strResult() As String
            Dim data(3) As Byte


            response = send_Opacimetro_command(OPAGetFilteredOpacity, data, 0)
            strResult = response.Split(",")
            If strResult(0) = "1" Then
                opacity = CDbl(convertMSByte_toUInt16(data_rcv, 1)) / 10.0
                gasTemp = data_rcv(3)
                tubeTemp = data_rcv(4)


                status.ambienTempUnvalid = False
                If data_rcv(6) And &H1 Then
                    status.ambienTempUnvalid = True
                End If
                status.detectorTempUnvalid = False
                If data_rcv(6) And &H2 Then
                    status.detectorTempUnvalid = True
                End If
                status.tubeTempUnvalid = False
                If data_rcv(6) And &H4 Then
                    status.tubeTempUnvalid = True
                End If
                status.PowerSupplyOutTolarance = False
                If data_rcv(6) And &H8 Then
                    status.PowerSupplyOutTolarance = True
                End If
                status.fanState = False
                If data_rcv(6) And &H10 Then
                    status.fanState = True
                End If
                status.opacityNonAvailable = False
                If data_rcv(6) And &H40 Then
                    status.opacityNonAvailable = True
                End If
                status.trasnducerStandBy = False
                If data_rcv(6) And &H80 Then
                    status.trasnducerStandBy = True
                End If

                status.zeroRunning = False
                If data_rcv(5) And &H1 Then
                    status.zeroRunning = True
                End If
                status.sootingLenses = False
                If data_rcv(5) And &H2 Then
                    status.sootingLenses = True
                End If
                status.acquisitionTriggered = False
                If data_rcv(5) And &H4 Then
                    status.acquisitionTriggered = True
                End If
                status.triggerActivated = False
                If data_rcv(5) And &H8 Then
                    status.triggerActivated = True
                End If
                status.faultFans = False
                If data_rcv(5) And &H10 Then
                    status.faultFans = True
                End If
                status.gasTempCold = False
                If data_rcv(5) And &H20 Then
                    status.gasTempCold = True
                End If
                status.faultTempSensor = False
                If data_rcv(5) And &H80 Then
                    status.faultTempSensor = True
                End If

                Return "1,ACK"
            End If
            Return response
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_Zero() As String
        Try

            Dim data(3) As Byte

            Return send_Opacimetro_command(OPAZero, data, 0)

        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_GetMesTable(ByRef opacityArray() As Double) As String
        Try
            Dim response, strResult() As String
            Dim data(3) As Byte
            Dim i As UInteger

            response = send_Opacimetro_command(OPAMesuramentTable, data, 0)
            strResult = response.Split(",")
            If strResult(0) = "1" Then

                For i = 0 To 499
                    opacityArray(i) = CDbl(convertMSByte_toUInt16(data_rcv, i * 2 + 1)) / 10.0
                Next


                Return "1,ACK"
            End If
            Return response
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_DemandAcquisition() As String
        Try

            Dim data(3) As Byte

            Return send_Opacimetro_command(OPADemandAcquisition, data, 0)

        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_TrigSampling() As String
        Try

            Dim data(3) As Byte

            Return send_Opacimetro_command(OPATrigSampling, data, 0)

        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function
    Public Function Comando_StopSampling() As String
        Try

            Dim data(3) As Byte

            Return send_Opacimetro_command(OPAStopSampling, data, 0)

        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_ReadEEPROM(startAddress As UInt16, cantData As UInt16, ByRef dataArray() As Byte) As String
        Try
            Dim response, strResult() As String
            Dim data(1) As Byte
            Dim i As UInteger

            data(0) = startAddress
            data(1) = cantData

            response = send_Opacimetro_command(OPAReadEEPROM, data, data.Length)
            strResult = response.Split(",")
            If strResult(0) = "1" Then

                For i = 0 To cantData - 1
                    dataArray(i) = data_rcv(i + 1)
                Next


                Return "1,ACK"
            End If
            Return response
        Catch ex As Exception
            Return "0," + ex.Message
        End Try

    End Function

    Public Function Comando_WriteEEPROM(startAddress As UInt16, cantData As UInt16, dataArray() As Byte) As String
        Try

            Dim data(1) As Byte
            Dim i As UInteger

            data(0) = startAddress
            data(1) = cantData

            For i = 0 To cantData - 1
                ReDim Preserve data(i + 2)
                data(i + 2) = dataArray(i)
            Next

            Return send_Opacimetro_command(OPAWriteEEPROM, data, data.Length)
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_WriteIntensity(l As UInt16) As String
        Try

            Dim data(1) As Byte

            data(0) = 0 'Write
            data(1) = l

            Return send_Opacimetro_command(OPAREadWriteIntensity, data, data.Length)
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_ReadIntensity(ByRef l As UInt16) As String
        Try
            Dim response, strResult() As String
            Dim data(0) As Byte

            data(0) = &H80 'Read

            response = send_Opacimetro_command(OPAREadWriteIntensity, data, data.Length)
            strResult = response.Split(",")
            If strResult(0) = "1" Then
                l = data_rcv(2)
                Return "1,ACK"
            End If
            Return response
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function
    Public Function Comando_StartFan() As String
        Try

            Dim data(0) As Byte
            data(0) = 1 'Start Fan

            Return send_Opacimetro_command(OPAStartStopFan, data, data.Length)
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function
    Public Function Comando_StopFan() As String
        Try

            Dim data(0) As Byte
            data(0) = 0 'Stop Fan

            Return send_Opacimetro_command(OPAStartStopFan, data, data.Length)
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_WriteSelectionMesuramentFilter(numberOfPoles As UInt16,
                                                           filterOn_k_N As Boolean,
                                                           besselFilter As Boolean,
                                                           Ca As Double,
                                                           Cb As Double) As String
        Try

            Dim data(4), dataT() As Byte
            Dim strNum() As String
            Dim strN As String

            data(0) = 0 'Write

            data(0) = numberOfPoles 's.0 s.1 s.2
            If numberOfPoles > 2 Then
                Return "0,Error Number of poles"
            End If

            If filterOn_k_N And besselFilter Then
                Return "0,Seleccione una de las dos opciones"
            End If



            If filterOn_k_N Then
                data(0) = data(0) Or &H10 's.4 = 1

                strN = Ca.ToString
                If strN.Contains(".") Then
                    strNum = Split(strN, ".")
                    data(1) = CByte(strNum(0))
                    data(2) = CByte(strNum(1))
                ElseIf strN.Contains(",") Then
                    strNum = Split(strN, ",")
                    data(1) = CByte(strNum(0))
                    data(2) = CByte(strNum(1))
                Else
                    data(1) = CByte(Decimal.Truncate(Ca))
                    data(2) = 0
                End If

                strN = Cb.ToString
                If strN.Contains(".") Then
                    strNum = Split(strN, ".")
                    data(3) = CByte(strNum(0))
                    data(4) = CByte(strNum(1))
                ElseIf strN.Contains(",") Then
                    strNum = Split(strN, ",")
                    data(3) = CByte(strNum(0))
                    data(4) = CByte(strNum(1))
                Else
                    data(3) = CByte(Decimal.Truncate(Cb))
                    data(4) = 0
                End If


            End If

            If besselFilter Then
                Dim CxInteger As UInt16
                CxInteger = Decimal.Truncate(Ca)
                dataT = BitConverter.GetBytes(CxInteger)
                data(1) = dataT(1)
                data(2) = dataT(0)


                CxInteger = Decimal.Truncate(Cb)
                dataT = BitConverter.GetBytes(CxInteger)
                data(3) = dataT(1)
                data(4) = dataT(0)

            End If

            Return send_Opacimetro_command(OPAReadWriteSelectionMesuramentFilter, data, data.Length)
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_ReadSelectionMesuramentFilter(ByRef numberOfPoles As UInt16,
                                                          ByRef filterOn_k_N As Boolean,
                                                          ByRef besselFilter As Boolean,
                                                          ByRef Ca As Double,
                                                          ByRef Cb As Double) As String
        Try

            Dim data(0), dataT() As Byte
            Dim strNum() As String
            Dim strN As String
            Dim response As String
            Dim strResult() As String


            data(0) = &H80 's.7=1 Read


            response = send_Opacimetro_command(OPAReadWriteSelectionMesuramentFilter, data, data.Length)
            strResult = response.Split(",")
            If strResult(0) = "1" Then

                numberOfPoles = data_rcv(1) And &H3 'enmascara los bits  s.0 y s.1
                filterOn_k_N = False
                If data_rcv(1) And &H10 Then
                    filterOn_k_N = True
                End If
                besselFilter = False
                If data_rcv(1) And &H20 Then
                    besselFilter = True
                End If

                If filterOn_k_N Then
                    Dim CxDecimal As Double
                    strN = data_rcv(3).ToString
                    CxDecimal = data_rcv(3)
                    For i = 0 To strN.Length - 1
                        CxDecimal /= 10.0
                    Next

                    Ca = CxDecimal + data_rcv(2)

                    strN = data_rcv(5).ToString
                    CxDecimal = data_rcv(5)
                    For i = 0 To strN.Length - 1
                        CxDecimal /= 10.0
                    Next

                    Cb = CxDecimal + data_rcv(4)

                ElseIf besselFilter Then
                    Ca = convertMSByte_toUInt16(data_rcv, 2)
                    Cb = convertMSByte_toUInt16(data_rcv, 4)
                Else
                    Return "0,No Filter Selected"
                End If

                Return "1,ACK"
            End If
            Return response


        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_Write_MinimunValue_GasTemp(tgasLimit As Byte) As String
        Try

            Dim data(1) As Byte

            data(0) = 0 'Write
            data(1) = tgasLimit

            Return send_Opacimetro_command(OPAReadWriteMinimunValue_GasTemp, data, data.Length)

        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function
    Public Function Comando_ReadMinimunValue_GasTemp(ByRef tgasLimit As Byte) As String
        Try
            Dim response As String
            Dim strResult() As String
            Dim data(0) As Byte

            data(0) = &H80 's.7=1 Read

            tgasLimit = 0
            response = send_Opacimetro_command(OPAReadWriteMinimunValue_GasTemp, data, data.Length)

            strResult = response.Split(",")
            If strResult(0) = "1" Then
                tgasLimit = data_rcv(2)
                Return "1,ACK"
            End If

            Return response
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_WritecleanWindow(cleanWindow As Byte) As String
        Try

            Dim data(1) As Byte

            data(0) = 0 'Write
            data(1) = cleanWindow

            Return send_Opacimetro_command(OPAReadWriteCleanWindow, data, data.Length)

        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function
    Public Function Comando_ReadcleanWindow(ByRef cleanWindow As Byte) As String
        Try
            Dim response As String
            Dim strResult() As String
            Dim data(0) As Byte

            data(0) = &H80 's.7=1 Read

            cleanWindow = 0
            response = send_Opacimetro_command(OPAReadWriteCleanWindow, data, data.Length)

            strResult = response.Split(",")
            If strResult(0) = "1" Then
                cleanWindow = data_rcv(2)
                Return "1,ACK"
            End If
            Return response
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function


    Public Function Comando_ReadOpacityCurve(n As UInt16, m As UInt16, ByRef dataArray() As UInt16) As String
        Try
            Dim response As String
            Dim strResult() As String
            Dim data(3) As Byte
            Dim dataT() As Byte


            dataT = convertUint16toMSByte(n)
            data(0) = dataT(0)
            data(1) = dataT(1)

            dataT = convertUint16toMSByte(m)
            data(2) = dataT(0)
            data(3) = dataT(1)


            dataT = convertUint16toMSByte(n)


            response = send_Opacimetro_command(OPAReadOpacityCurve, data, data.Length)

            strResult = response.Split(",")
            If strResult(0) = "1" Then
                Dim i As Integer

                For i = 0 To _count - 3 Step 2
                    dataArray(i / 2) = convertMSByte_toUInt16(data_rcv, i + 1)

                Next

                Return "1,ACK"

            End If
            Return response
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_ReadCurrFactorAcquisition(ByRef Indice As UInt16) As String
        Try
            Dim response As String
            Dim strResult() As String
            Dim data(0) As Byte




            response = send_Opacimetro_command(OPAReadCurrFactorAcquisition, data, 0)

            strResult = response.Split(",")
            If strResult(0) = "1" Then
                Indice = convertMSByte_toUInt16(data_rcv, 1)
                Return "1,ACK"
            End If
            Return response
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_ReadValueSmokePeak(ByRef peak As Double,
                                              ByRef gasStatus As UInt16,
                                              ByRef durationAcceleration As UInt16) As String
        Try
            Dim response As String
            Dim strResult() As String
            Dim data(0) As Byte




            response = send_Opacimetro_command(OPAReadValueSmokePeak, data, 0)

            strResult = response.Split(",")
            If strResult(0) = "1" Then
                peak = convertMSByte_toUInt16(data_rcv, 1) / 1000.0
                gasStatus = data_rcv(3)
                durationAcceleration = convertMSByte_toUInt16(data_rcv, 4)
                Return "1,ACK"
            End If
            Return response
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_ReadVariousInternalData(ByRef tempGas As UInt16,
                                                    ByRef tempTube As UInt16,
                                                    ByRef tempDetector As UInt16,
                                                    ByRef tempAMbient As UInt16,
                                                    ByRef powerSupply As Double,
                                                    ByRef fanSpeed As UInt16,
                                                    ByRef lenseDirtyness As UInt16,
                                                    ByRef ledOFFIntensity As UInt16,
                                                    ByRef ledONIntensity As UInt16) As String
        Try
            Dim response As String
            Dim strResult() As String
            Dim data(0) As Byte




            response = send_Opacimetro_command(OPAReadVariousInternalData, data, 0)

            strResult = response.Split(",")
            If strResult(0) = "1" Then
                tempGas = data_rcv(1)
                tempTube = data_rcv(2)
                tempDetector = data_rcv(3)
                tempAMbient = data_rcv(4)
                powerSupply = convertMSByte_toUInt16(data_rcv, 5) / 100.0
                fanSpeed = convertMSByte_toUInt16(data_rcv, 7)
                lenseDirtyness = data_rcv(9)
                ledOFFIntensity = convertMSByte_toUInt16(data_rcv, 10)
                ledONIntensity = convertMSByte_toUInt16(data_rcv, 12)

                Return "1,ACK"
            End If
            Return response
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function

    Public Function Comando_AdjustGainDetector() As String
        Try

            Dim data(3) As Byte

            Return send_Opacimetro_command(OPAAdjustGainDetector, data, 0)

        Catch ex As Exception
            Return "0," + ex.Message
        End Try


    End Function
    Private Function convertMSByte_toUInt16(data() As Byte, posicion As Integer) As UInt16
        Dim dataT(1) As Byte

        dataT(0) = data(posicion + 1)
        dataT(1) = data(posicion)
        Return BitConverter.ToUInt16(dataT, 0)

    End Function

    Private Function convertUint16toMSByte(num As UInt16) As Byte()
        Dim dataT(1) As Byte
        Dim data(1) As Byte

        dataT = BitConverter.GetBytes(num)
        data(0) = dataT(1)
        data(1) = dataT(0)

        Return data

    End Function

    Private Function send_Opacimetro_command(commandB As Byte, data_in As Byte(), DataCount As UInteger) As String
        Try

            Dim chkSumT As UInteger
            Dim chkSum As Integer
            Dim data_send(100) As Byte
            Dim i, j As UInteger
            Dim txtConsola As String

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
            chkSum = -1 * chkSumT

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

            Delay(2)

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
