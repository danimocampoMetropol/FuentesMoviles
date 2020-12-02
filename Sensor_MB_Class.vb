
Imports System.Windows.Forms
Imports System.Threading
Imports System.IO.Ports

Public Class Sensor_MB_Class

    'Constantes banco de gases Sensors Micrbench
    Const ACK As UInteger = 6
    Const NACK As UInteger = 21
    Const BUSY As UInteger = 5
    'Comandos Sensor Microbench
    Const MBGetVersion As UInteger = 12
    Const MBCalibration As UInteger = 2
    Const MBGetData As UInteger = 3
    Const MBGetStatus As UInteger = 4




    'Constantes control de comunicacion
    Const CerraAplicativo As UInteger = 100
    Const TimerTimeOut As UInteger = 101
    Const RxExcepcion As Integer = 102
    Const ErrData As UInteger = 103
    Const Excepcion As UInteger = 104
    Const CantDataErr As UInteger = 105

    'constantes enviar comando GETDATA
    Public Report_Gas_Data_in_Concentration As Integer = 0
    Public Report_Gas_Data_in_Voltage As Integer = 10
    Public Report_Gas_Data_in_AD_Counts As Integer = 11
    Public Report_Gas_Data_in_Modulation As Integer = 12

    Public Pressure_in_mbar As Integer = 1
    Public Pressure_in_Hg As Integer = 0
    Public Temp_in_C As Integer = 1
    Public Temp_in_F As Integer = 0
    Public HC_Range_0_2000_ppmHex As Integer = 1
    Public HC_Range_0_20000_ppmHex As Integer = 0
    Public High_Resolution_O2 As Integer = 1
    Public Low_Resolution_O2 As Integer = 0
    Public RPM_in_2_cycle As Integer = 1
    Public RPM_in_4_cycle As Integer = 0
    Public Normal_Ignition As Integer = 1
    Public Dual_Ignition As Integer = 0
    Public Pressure_Resolution_Low As Integer = 1
    Public Pressure_Resolution_High As Integer = 0
    Public HC_AS_ppm_Hexane As Integer = 1
    Public HC_AS_ppm_Propane As Integer = 0
    Public Oil_Temp_as_C As Integer = 1
    Public Oil_Temp_as_mV As Integer = 0
    Public RPM_as_1_Min As Integer = 1
    Public RPM_as_1_mV As Integer = 0



    'Varaibles de 
    Public Shared _continueValue As Boolean
    Public Property _continue() As Boolean
        Get
            Return _continueValue
        End Get
        Set(value As Boolean)
            _continueValue = value
        End Set
    End Property



    Public Shared _readDataMB As Boolean 'Si se cierra la App _continue = False para terminar los loops de recepcion 
    Public Shared _count As UInteger    'Cantidad de datos recibidos por el puerto serial
    Public Shared data_rcv(100) As Byte 'Buffer para recepcion de datos
    Public Shared _timeOut As Boolean   'Indica si el timer ha expirado
    Public Shared _errMsg As String


    Public Shared _serialPortMicroBench As SerialPort
    Private tmrComunicacion As Windows.Forms.Timer


    Dim readThread As New Thread(AddressOf Read)

    Structure Overall_Status
        Public warmUpInProgress As Boolean
        Public ZeroNeeded As Boolean
        Public NewO2TransducerInstalled As Boolean
        Public Cal_ZreoWarning As Boolean
        Public BadO2Trasnducer As Boolean
        Public LowFLow As Boolean
        Public NewNOXTransducer As Boolean
        Public BadNOXTrasnducer As Boolean
        Public CondesationWarning As Boolean
        Public ADChannelIsRailed As Boolean
        Public BenchInternalWarning As Boolean
    End Structure


    Structure Zero_Status
        Public HC_Warning As Boolean
        Public CO_Warning As Boolean
        Public CO2_Warning As Boolean
        Public HiHC_Warning As Boolean
        Public O2_Warning As Boolean
        Public NOX_Warning As Boolean
        Public RPM_Warning As Boolean
        Public BadNOXTrasnducer As Boolean
        Public CondesationWarning As Boolean
        Public ADChannelIsRailed As Boolean
        Public BenchInternalWarning As Boolean
    End Structure


    Structure SinglePointCalibration_Status
        Public HC_Cal As Boolean
        Public CO_Cal As Boolean
        Public CO2_Cal As Boolean
        Public HiHC_Cal As Boolean
        Public O2_Cal As Boolean
        Public NOX_Cal As Boolean
        Public RPM_Cal As Boolean
        Public PRESS_Cal As Boolean
    End Structure

    Structure TwoPointCalibration_Status
        Public HC_Cal As Boolean
        Public CO_Cal As Boolean
        Public CO2_Cal As Boolean
    End Structure


    Structure BenchOperational_Warnings
        Public BlockHeater As Boolean
        Public O2OffsetVoltage_Warning As Boolean
        Public NOXOffsetVoltage_OutRange As Boolean
        Public NDIRBeamStrength_Warning As Boolean
        Public IncompatibleEEPROM As Boolean
    End Structure


    Structure ADConverter_Channels
        Public HC_Channel_railed As Boolean
        Public CO_Channel_railed As Boolean
        Public CO2_Channel_railed As Boolean
        Public O2_Channel_railed As Boolean
        Public NOX_Channel_railed As Boolean
        Public RPM_Channel_railed As Boolean
        Public OIL_Channel_railed As Boolean
        Public TEMP_Channel_railed As Boolean
        Public PRESS_Channel_railed As Boolean
        Public BlOCK_Channel_railed As Boolean
    End Structure

    Structure GetData_Results
        Public HC As Double
        Public CO As Double
        Public CO2 As Double
        Public O2 As Double
        Public NOX As Double
        Public RPM As Double
        Public OilTemp As Double
        Public AmbientTemp As Double
        Public Pressure As Double
        Public lowFlow As Boolean
        Public FilterBowlFull As Boolean
        Public Alarm As Boolean
        Public DataMayNotBeAccurate As Boolean
        Public ZERO_recommended As Boolean
        Public HighHC_Range As Boolean
        Public CondensationWarning As Boolean
        Public HC_OutRange As Boolean
        Public CO2_OutRange As Boolean
        Public CO_OutRange As Boolean
        Public O2_OutRange As Boolean
        Public NOX_OutRange As Boolean
        Public BenchInternalWarning As Boolean
    End Structure

    Public OverallStatus As Overall_Status
    Public ZeroStatus As Zero_Status
    Public SinglePointCalibrationStatus As SinglePointCalibration_Status
    Public TwoPointCalibrationStatus As TwoPointCalibration_Status
    Public BenchOperationalWarnings As BenchOperational_Warnings
    Public ADConverterChannels As ADConverter_Channels
    Public GetDataResults As GetData_Results


    Public Sub New(portName As String)

        tmrComunicacion = New Windows.Forms.Timer()
        tmrComunicacion.Enabled = False
        AddHandler tmrComunicacion.Tick, AddressOf tmrComunicacion_Tick

        _serialPortMicroBench = New SerialPort()
        _serialPortMicroBench.PortName = portName
        _serialPortMicroBench.BaudRate = 9600
        _serialPortMicroBench.DataBits = 8
        _serialPortMicroBench.StopBits = 1

        OverallStatus = New Overall_Status
        ZeroStatus = New Zero_Status
        SinglePointCalibrationStatus = New SinglePointCalibration_Status
        TwoPointCalibrationStatus = New TwoPointCalibration_Status
        BenchOperationalWarnings = New BenchOperational_Warnings
        ADConverterChannels = New ADConverter_Channels
        GetDataResults = New GetData_Results

        _readDataMB = False
        _continueValue = True
        readThread.Start()



    End Sub


    Public Function Comando_MB_GetVersionSoftware() As String
        Dim data(3) As Byte
        Dim strResult As String
        Dim strResults() As String
        Dim version As UInteger

        data(0) = 0
        data(1) = 0
        data(2) = 0
        data(3) = 0

        strResult = Microbench_command(MBGetVersion, data, data.Length)
        strResults = strResult.Split(",")
        If strResults(0) = "1" Then
            version = data_rcv(4) + data_rcv(5) * &H100
            Return "1," + version.ToString
        Else
            Return strResult
        End If

    End Function
    Public Function Comando_MB_GetVersionHardware() As String
        Dim data(3) As Byte
        Dim strResult As String
        Dim strResults() As String
        Dim version As UInteger

        data(0) = 0
        data(1) = 0
        data(2) = 1
        data(3) = 0


        strResult = Microbench_command(MBGetVersion, data, data.Length)
        strResults = strResult.Split(",")
        If strResults(0) = "1" Then
            version = data_rcv(4) + data_rcv(5) * &H100
            Return "1," + version.ToString
        Else
            Return strResult
        End If

    End Function

    Public Function Comando_MB_GetData(mode As UInteger,
                                        unitsPressure As UInteger,
                                        unitsTemp As UInteger,
                                        HCRange As UInteger,
                                        LowHighResolition As UInteger,
                                        Rpm2_4_Cycle As UInteger,
                                        ignitioNormal_Dual As UInteger,
                                        ResolutionPressureHigh_Low As UInteger,
                                        HCasPPMHexane_Propane As UInteger,
                                        OilTempAs_C_mV As UInteger,
                                        RpmAs_1xmin_mv As UInteger) As String




        Dim unitsH, unitsL As Byte
        Dim status As UShort
        Dim data(3) As Byte
        Dim strResult As String
        Dim strResults() As String
        Dim HC, CO, CO2, O2, NOX, RPM, OilTemp, AmbientTemp, Pressure As Short


        unitsL = 0
        unitsH = 0
        If unitsPressure = 1 Then
            unitsL = unitsL Or &B1
        End If
        If unitsTemp = 1 Then
            unitsL = unitsL Or &B10
        End If
        If HCRange = 1 Then
            unitsL = unitsL Or &B100
        End If
        If LowHighResolition = 1 Then
            unitsL = unitsL Or &B1000
        End If
        If Rpm2_4_Cycle = 1 Then
            unitsL = unitsL Or &B10000
        End If
        If ignitioNormal_Dual = 1 Then
            unitsL = unitsL Or &B100000
        End If
        If ResolutionPressureHigh_Low = 1 Then
            unitsL = unitsL Or &B1000000
        End If
        If HCasPPMHexane_Propane = 1 Then
            unitsL = unitsL Or &B10000000
        End If
        If OilTempAs_C_mV = 1 Then
            unitsH = unitsH Or &B1
        End If
        If RpmAs_1xmin_mv = 1 Then
            unitsH = unitsH Or &B10
        End If

        data(0) = mode
        data(1) = 0
        data(2) = unitsL
        data(3) = unitsH

        strResult = Microbench_command(MBGetData, data, data.Length)
        strResults = strResult.Split(",")
        If strResults(0) = "1" Then
            status = data_rcv(4) + data_rcv(5) * &H100


            HC = data_rcv(6) + data_rcv(7) * &H100
            CO = data_rcv(8) + data_rcv(9) * &H100
            CO2 = data_rcv(10) + data_rcv(11) * &H100
            O2 = data_rcv(12) + data_rcv(13) * &H100
            NOX = data_rcv(14) + data_rcv(15) * &H100
            RPM = data_rcv(16) + data_rcv(17) * &H100
            OilTemp = data_rcv(18) + data_rcv(19) * &H100
            AmbientTemp = data_rcv(20) + data_rcv(21) * &H100
            Pressure = data_rcv(22) + data_rcv(23) * &H100

            GetDataResults.HC = HC / 100
            GetDataResults.CO = CO / 100
            GetDataResults.CO2 = CO2 / 100
            GetDataResults.O2 = O2 / 100
            GetDataResults.NOX = NOX / 100
            GetDataResults.RPM = RPM / 100
            GetDataResults.OilTemp = OilTemp / 100
            GetDataResults.AmbientTemp = AmbientTemp / 100
            GetDataResults.Pressure = Pressure / 100

            GetDataResults.lowFlow = False
            If status And &B1 Then
                GetDataResults.lowFlow = True
            End If
            GetDataResults.FilterBowlFull = False
            If status And &B10 Then
                GetDataResults.FilterBowlFull = True
            End If
            GetDataResults.Alarm = False
            If status And &B100 Then
                GetDataResults.Alarm = True
            End If
            GetDataResults.DataMayNotBeAccurate = False
            If status And &B1000 Then
                GetDataResults.DataMayNotBeAccurate = True
            End If
            GetDataResults.ZERO_recommended = False
            If status And &B10000 Then
                GetDataResults.ZERO_recommended = True
            End If
            GetDataResults.HighHC_Range = False
            If status And &B100000 Then
                GetDataResults.HighHC_Range = True
            End If
            GetDataResults.CondensationWarning = False
            If status And &B1000000 Then
                GetDataResults.CondensationWarning = True
            End If
            GetDataResults.HC_OutRange = False
            If status And &B100000000 Then
                GetDataResults.HC_OutRange = True
            End If
            GetDataResults.CO_OutRange = False
            If status And &B1000000000 Then
                GetDataResults.CO_OutRange = True
            End If
            GetDataResults.CO2_OutRange = False
            If status And &B10000000000 Then
                GetDataResults.CO2_OutRange = True
            End If
            GetDataResults.O2_OutRange = False
            If status And &B100000000000 Then
                GetDataResults.O2_OutRange = True
            End If
            GetDataResults.NOX_OutRange = False
            If status And &B1000000000000 Then
                GetDataResults.NOX_OutRange = True
            End If
            GetDataResults.BenchInternalWarning = False
            If status And &B1000000000000000 Then
                GetDataResults.BenchInternalWarning = True
            End If
            Return "1,Datos Leidos Correctamente"
        Else
            Return strResult
        End If


    End Function

    Public Function Comando_MB_GetStatus() As String
        Try

            Dim data(0) As Byte
            Dim strResult As String
            Dim strResults() As String
            Dim satatusWord0 As UInteger
            Dim satatusWord1 As UInteger
            Dim satatusWord2 As UInteger
            Dim satatusWord3 As UInteger
            Dim satatusWord4 As UInteger
            Dim satatusWord5 As UInteger
            Dim satatusWord6 As UInteger
            Dim satatusWord7 As UInteger
            Dim satatusWord8 As UInteger
            Dim satatusWord9 As UInteger

            strResult = Microbench_command(MBGetStatus, data, 0)
            strResults = strResult.Split(",")
            If strResults(0) = "1" Then
                satatusWord0 = data_rcv(4) + data_rcv(5) * &H100
                satatusWord1 = data_rcv(6) + data_rcv(7) * &H100
                satatusWord2 = data_rcv(8) + data_rcv(9) * &H100
                satatusWord3 = data_rcv(10) + data_rcv(11) * &H100
                satatusWord4 = data_rcv(12) + data_rcv(13) * &H100
                satatusWord5 = data_rcv(14) + data_rcv(15) * &H100
                satatusWord6 = data_rcv(16) + data_rcv(17) * &H100
                satatusWord7 = data_rcv(18) + data_rcv(19) * &H100
                satatusWord8 = data_rcv(20) + data_rcv(21) * &H100
                satatusWord9 = data_rcv(22) + data_rcv(23) * &H100


                OverallStatus.warmUpInProgress = False
                If satatusWord0 And &H1 Then
                    OverallStatus.warmUpInProgress = True
                End If
                OverallStatus.ZeroNeeded = False
                If satatusWord0 And &H2 Then
                    OverallStatus.ZeroNeeded = True
                End If
                OverallStatus.NewO2TransducerInstalled = False
                If satatusWord0 And &H4 Then
                    OverallStatus.NewO2TransducerInstalled = True
                End If
                OverallStatus.Cal_ZreoWarning = False
                If satatusWord0 And &H8 Then
                    OverallStatus.Cal_ZreoWarning = True
                End If
                OverallStatus.BadO2Trasnducer = False
                If satatusWord0 And &H10 Then
                    OverallStatus.BadO2Trasnducer = True
                End If
                OverallStatus.LowFLow = False
                If satatusWord0 And &H20 Then
                    OverallStatus.LowFLow = True
                End If
                OverallStatus.NewNOXTransducer = False
                If satatusWord0 And &H40 Then
                    OverallStatus.NewNOXTransducer = True
                End If
                OverallStatus.BadNOXTrasnducer = False
                If satatusWord0 And &H80 Then
                    OverallStatus.BadNOXTrasnducer = True
                End If
                OverallStatus.CondesationWarning = False
                If satatusWord0 And &H100 Then
                    OverallStatus.CondesationWarning = True
                End If
                OverallStatus.ADChannelIsRailed = False
                If satatusWord0 And &H400 Then
                    OverallStatus.ADChannelIsRailed = True
                End If
                OverallStatus.BenchInternalWarning = False
                If satatusWord0 And &H800 Then
                    OverallStatus.BenchInternalWarning = True
                End If

                ZeroStatus.HC_Warning = False
                If satatusWord1 And &H1 Then
                    ZeroStatus.HC_Warning = True
                End If
                ZeroStatus.CO_Warning = False
                If satatusWord1 And &H2 Then
                    ZeroStatus.CO_Warning = True
                End If
                ZeroStatus.CO2_Warning = False
                If satatusWord1 And &H4 Then
                    ZeroStatus.CO2_Warning = True
                End If
                ZeroStatus.HiHC_Warning = False
                If satatusWord1 And &H8 Then
                    ZeroStatus.HiHC_Warning = True
                End If
                ZeroStatus.O2_Warning = False
                If satatusWord1 And &H20 Then
                    ZeroStatus.O2_Warning = True
                End If
                ZeroStatus.NOX_Warning = False
                If satatusWord1 And &H40 Then
                    ZeroStatus.NOX_Warning = True
                End If
                ZeroStatus.RPM_Warning = False
                If satatusWord1 And &H80 Then
                    ZeroStatus.RPM_Warning = True
                End If

                SinglePointCalibrationStatus.HC_Cal = False
                If satatusWord2 And &H1 Then
                    SinglePointCalibrationStatus.HC_Cal = True
                End If
                SinglePointCalibrationStatus.CO_Cal = False
                If satatusWord2 And &H2 Then
                    SinglePointCalibrationStatus.CO_Cal = True
                End If
                SinglePointCalibrationStatus.CO2_Cal = False
                If satatusWord2 And &H4 Then
                    SinglePointCalibrationStatus.CO2_Cal = True
                End If
                SinglePointCalibrationStatus.HiHC_Cal = False
                If satatusWord2 And &H8 Then
                    SinglePointCalibrationStatus.HiHC_Cal = True
                End If
                SinglePointCalibrationStatus.O2_Cal = False
                If satatusWord2 And &H20 Then
                    SinglePointCalibrationStatus.O2_Cal = True
                End If
                SinglePointCalibrationStatus.NOX_Cal = False
                If satatusWord2 And &H40 Then
                    SinglePointCalibrationStatus.NOX_Cal = True
                End If
                SinglePointCalibrationStatus.RPM_Cal = False
                If satatusWord2 And &H80 Then
                    SinglePointCalibrationStatus.RPM_Cal = True
                End If
                SinglePointCalibrationStatus.PRESS_Cal = False
                If satatusWord2 And &H100 Then
                    SinglePointCalibrationStatus.PRESS_Cal = True
                End If







                Return "1,Datos Almacenados en las estructuras"
            Else
                Return strResult
            End If
        Catch ex As Exception
            Return "0," + ex.Message
        End Try
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <param name="gas"></param>
    ''' <returns></returns>
    ''' 

    Public Function Comando_MB_Calibration(mode As UInteger, gas As UInteger) As String
        Try

            Dim data(3) As Byte
            Dim gasByte As Byte
            Dim strResult As String
            Dim strResults() As String
            Dim mini_status As UInteger

            Select Case gas
                Case 0
                    gasByte = &B1
                Case 1
                    gasByte = &B10
                Case 2
                    gasByte = &B100
                Case 3
                    gasByte = &B1000
                Case 4
                    gasByte = &B10000
                Case 5
                    gasByte = &B100000
                Case Else
                    gasByte = 0
            End Select
            data(0) = mode
            data(1) = 0
            data(2) = gasByte
            data(3) = 0


            strResult = Microbench_command(MBCalibration, data, data.Length)
            strResults = strResult.Split(",")
            If strResults(0) = "1" Then
                mini_status = data_rcv(4) + data_rcv(5) * &H100
                Select Case mini_status
                    Case &H0
                        Return "1,No Warning"
                    Case &H1
                        Return "1,Zero Warning"
                    Case &H2
                        Return "1,Single Point Calibration Warning"
                    Case &H10
                        Return "1,Single Point Calibration Warning"
                    Case Else
                        Return "0,Error devuelve mini_status desconocido"
                End Select
            Else
                Return strResult
            End If
        Catch ex As Exception
            Return "0," + ex.Message
        End Try
    End Function
    Private Function Microbench_command(command As UInteger, data_in As Byte(), DataCount As UInteger) As String
        Try

            Dim NORMAL_MODE As UInteger = 0
            Dim LENGTHY_MODE As UInteger = 1

            Dim PROCESS_STATUS As UInteger = 11
            Dim response As Integer

            response = send_Microbench_command(command, NORMAL_MODE, data_in, DataCount)
            If response = BUSY Then
                'Inicializar temporizador 10 segundos
                IniTemporizador(10)
                While response = BUSY And _timeOut = False
                    response = send_Microbench_command(PROCESS_STATUS, LENGTHY_MODE, data_in, 0)
                End While
                If _timeOut = True Then
                    Return "0,Banco ocupado Tiempo de espera de 10 segundos agotado"
                End If
            End If

            Select Case response
                Case ACK
                    Return "1,ACK"
                Case NACK
                    Return "0,Error Comando o comando no reconocido"
                Case CerraAplicativo
                    Return "0,CerraAplicativo"
                Case TimerTimeOut
                    Return "0,Banco no responde Tiempo de espera agotado"
                Case RxExcepcion
                    Return "0," + _errMsg
                Case Excepcion
                    Return "0," + _errMsg
                Case CantDataErr
                    Return "0,Error cantidad de datos no corresponde"
                Case Else
                    Return "0,Err Respuesta"
            End Select
        Catch ex As Exception
            Return "0," + ex.Message
        End Try

    End Function

    Private Function send_Microbench_command(command As UInteger, MODE As UInteger, data_in As Byte(), DataCount As UInteger) As UInteger
        Try

            Dim chkSumT As UInteger
            Dim chkSum, chkSumRcv, cantData As UInteger
            Dim data_send(100) As Byte
            Dim i, j As UInteger
            Dim WordCount As UInteger = DataCount / 2
            Dim txtConsola As String


            'chkSumT = command + MODE + CantidadDatos

            'For Each d In data_in
            'chkSumT += d
            'Next

            'chkSum = chkSumT Mod &H10000

            'Encabezado trama
            data_send(0) = command
            data_send(1) = MODE
            data_send(2) = WordCount And &HFF
            data_send(3) = WordCount And &HFF00
            i = 4
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
            chkSum = chkSumT Mod &H10000
            'Agregar ChkSum a la trama de datos
            data_send(i) = chkSum And &HFF
            data_send(i + 1) = chkSum And &HFF00
            txtConsola = "data_send= "
            Console.Write("data_send: ")
            For i = 0 To DataCount + 5
                txtConsola += data_send(i).ToString + ":"
                Console.Write(data_send(i).ToString)
                Console.Write(":")
            Next
            Console.WriteLine()
            _serialPortMicroBench.Open()             'abrir puerto
            _serialPortMicroBench.DiscardInBuffer()  'Borrar buffer de recpecion para eliminar posible ruido
            data_rcv.Initialize()                  'Inicializa buffer de recepcion                           
            _serialPortMicroBench.ReceivedBytesThreshold = 1
            _continueValue = True
            _count = 0
            _serialPortMicroBench.Write(data_send, 0, DataCount + 6) 'Envia trama
            'Inicializa temporizador de 2 segundos para recibir paquete
            IniTemporizador(2)
            'espera que el temprozador de la señal de timeOut
            While _timeOut = False
                Application.DoEvents()
            End While
            _readDataMB = True
            'Inicia Thread de recepcion
            'inicia timer de recepcion. Si al cabo de 2 segundo no ha recibido paquete retorna
            IniTemporizador(2)
            '_count indica si se han recibido datos
            '_continueValue indica si se ha cerrado el aplicativo
            '_timeOut indica que se agoto el tiempo de espera
            While (_count = 0) And (_continueValue = True) And (_timeOut = False)
                Application.DoEvents()
            End While
            _readDataMB = False

            _serialPortMicroBench.Close() 'Cierra puerto serial

            If _continueValue = False Then
                Return CerraAplicativo
            ElseIf _timeOut Then
                Return TimerTimeOut
            ElseIf _count = RxExcepcion Then
                Return RxExcepcion  'si ha ocurrido una excepcion en la recepcion
            End If
            Console.WriteLine("data_rcv: " + _count.ToString)
            For i = 0 To _count - 1
                txtConsola += data_rcv(i).ToString + ":"
                Console.Write(data_rcv(i).ToString + ":")
            Next
            Console.WriteLine()

            'revisar Checksum de paquete recibido
            cantData = (data_rcv(2) + data_rcv(3) * &H100) * 2
            If cantData <> (_count - 6) Then
                Return CantDataErr
            End If
            chkSumT = 0
            For j = 0 To _count - 3
                chkSumT += data_rcv(j)
            Next
            chkSum = chkSumT Mod &H10000
            chkSumRcv = data_rcv(_count - 2) + data_rcv(_count - 1) * &H100
            If chkSum <> chkSumRcv Then
                Return NACK
            ElseIf data_rcv(0) <> command Then ' el comando enviado y le recibido deben ser iguales
                Return NACK
            End If
            Return data_rcv(1) 'retorna respuesta del comando

        Catch ex As Exception
            If _serialPortMicroBench.IsOpen Then
                _serialPortMicroBench.Close()
            End If
            _errMsg = ex.Message
            Return Excepcion
        End Try
    End Function


    Public Shared Sub Read()
        Try
            While _continueValue
                If _readDataMB Then
                    _count = _serialPortMicroBench.Read(data_rcv, 0, 100)
                    _readDataMB = False
                End If
            End While
        Catch generatedExceptionName As TimeoutException
            _count = RxExcepcion
            _errMsg = generatedExceptionName.Message
        Catch ex As Exception
            _count = RxExcepcion
            _errMsg = ex.Message
        Finally
            If _serialPortMicroBench.IsOpen Then
                _serialPortMicroBench.Close()
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

    Private Sub tmrComunicacion_Tick(sender As Object, e As EventArgs)
        tmrComunicacion.Enabled = False
        tmrComunicacion.Stop()
        _timeOut = True
    End Sub

End Class
