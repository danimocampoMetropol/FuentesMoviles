﻿
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
    Const MBReadWriteCalibration As UInteger = 5




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

    'Constantes Read Calibration Data
    Public DataSet_SinglePont_Cal_HC_CO_CO2_HiHC As UInteger = 1
    Public DataSet_SinglePont_Cal_O2 As UInteger = 2
    Public DataSet_SinglePont_Cal_NOX As UInteger = 3
    Public DataSet_SinglePont_Cal_HC_CO_CO2_HiHC_O2_NOX As UInteger = 4
    Public DataSet_TwolePont_Cal_HC_CO_CO2_P1 As UInteger = 11
    Public DataSet_TwolePont_Cal_HC_CO_CO2_P2 As UInteger = 21
    Public DataSet_PEF As UInteger = 42
    Public DataSet_New_O2_Transducer_Installed As UInteger = 50
    Public DataSet_Read_Bad_O2 As UInteger = 51
    Public DataSet_Read_High_O2 As UInteger = 52

    Structure Calibration_Data
        Dim HC As Integer
        Dim CO As Integer
        Dim CO2 As Integer
        Dim HC_P2 As Integer
        Dim CO_P2 As Integer
        Dim CO2_P2 As Integer
        Dim HiHc As Integer
        Dim O2 As Integer
        Dim NOX As Integer
        Dim PEF As Integer
        Dim Flag As Short
        Dim Bad_O2 As Integer
        Dim High_O2 As Integer
        Dim HC_Flag_Out_Range As Integer
        Dim CO_Flag_Out_Range As Integer
        Dim CO2_Flag_Out_Range As Integer
        Dim O2_Flag_Out_Range As Integer
        Dim NOX_Flag_Out_Range As Integer
        Dim New_O2_Transd_Installed As Integer
    End Structure






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
    Public Warm_Up_Time As UInteger





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
        Dim warmUpInProgress As Boolean
        Dim ZeroNeeded As Boolean
        Dim NewO2TransducerInstalled As Boolean
        Dim Cal_ZreoWarning As Boolean
        Dim BadO2Trasnducer As Boolean
        Dim LowFLow As Boolean
        Dim NewNOXTransducer As Boolean
        Dim BadNOXTrasnducer As Boolean
        Dim CondesationWarning As Boolean
        Dim ADChannelIsRailed As Boolean
        Dim BenchInternalWarning As Boolean
    End Structure


    Structure Zero_Status
        Dim HC_Warning As Boolean
        Dim CO_Warning As Boolean
        Dim CO2_Warning As Boolean
        Dim HiHC_Warning As Boolean
        Dim O2_Warning As Boolean
        Dim NOX_Warning As Boolean
        Dim RPM_Warning As Boolean
        Dim BadNOXTrasnducer As Boolean
        Dim CondesationWarning As Boolean
        Dim ADChannelIsRailed As Boolean
        Dim BenchInternalWarning As Boolean
    End Structure


    Structure SinglePointCalibration_Status
        Dim HC_Cal As Boolean
        Dim CO_Cal As Boolean
        Dim CO2_Cal As Boolean
        Dim HiHC_Cal As Boolean
        Dim O2_Cal As Boolean
        Dim NOX_Cal As Boolean
        Dim RPM_Cal As Boolean
        Dim PRESS_Cal As Boolean
    End Structure

    Structure TwoPointCalibration_Status
        Dim HC_Cal As Boolean
        Dim CO_Cal As Boolean
        Dim CO2_Cal As Boolean
    End Structure


    Structure BenchOperational_Warnings
        Dim BlockHeater As Boolean
        Dim O2OffsetVoltage_Warning As Boolean
        Dim NOXOffsetVoltage_OutRange As Boolean
        Dim NDIRBeamStrength_Warning As Boolean
        Dim IncompatibleEEPROM As Boolean
    End Structure


    Structure ADConverter_Channels
        Dim HC_Channel_railed As Boolean
        Dim CO_Channel_railed As Boolean
        Dim CO2_Channel_railed As Boolean
        Dim O2_Channel_railed As Boolean
        Dim NOX_Channel_railed As Boolean
        Dim RPM_Channel_railed As Boolean
        Dim OIL_Channel_railed As Boolean
        Dim TEMP_Channel_railed As Boolean
        Dim PRESS_Channel_railed As Boolean
        Dim BlOCK_Channel_railed As Boolean
    End Structure

    Structure GetData_Results
        Dim HC As Double
        Dim CO As Double
        Dim CO2 As Double
        Dim O2 As Double
        Dim NOX As Double
        Dim RPM As Double
        Dim OilTemp As Double
        Dim AmbientTemp As Double
        Dim Pressure As Double
        Dim lowFlow As Boolean
        Dim FilterBowlFull As Boolean
        Dim Alarm As Boolean
        Dim DataMayNotBeAccurate As Boolean
        Dim ZERO_recommended As Boolean
        Dim HighHC_Range As Boolean
        Dim CondensationWarning As Boolean
        Dim HC_OutRange As Boolean
        Dim CO2_OutRange As Boolean
        Dim CO_OutRange As Boolean
        Dim O2_OutRange As Boolean
        Dim NOX_OutRange As Boolean
        Dim BenchInternalWarning As Boolean
    End Structure



    Public Sub New(portName As String)

        tmrComunicacion = New Windows.Forms.Timer()
        tmrComunicacion.Enabled = False
        AddHandler tmrComunicacion.Tick, AddressOf TmrComunicacion_Tick

        _serialPortMicroBench = New SerialPort()
        _serialPortMicroBench.PortName = portName
        _serialPortMicroBench.BaudRate = 9600
        _serialPortMicroBench.DataBits = 8
        _serialPortMicroBench.StopBits = 1



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

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <param name="unitsPressure"></param>
    ''' <param name="unitsTemp"></param>
    ''' <param name="HCRange"></param>
    ''' <param name="LowHighResolition"></param>
    ''' <param name="Rpm2_4_Cycle"></param>
    ''' <param name="ignitioNormal_Dual"></param>
    ''' <param name="ResolutionPressureHigh_Low"></param>
    ''' <param name="HCasPPMHexane_Propane"></param>
    ''' <param name="OilTempAs_C_mV"></param>
    ''' <param name="RpmAs_1xmin_mv"></param>
    ''' <returns></returns>
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
                                        RpmAs_1xmin_mv As UInteger, ByRef GetDataResults As GetData_Results) As String




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


            HC = BitConverter.ToInt16(data_rcv, 6)
            CO = BitConverter.ToInt16(data_rcv, 8)
            CO2 = BitConverter.ToInt16(data_rcv, 10)
            O2 = BitConverter.ToInt16(data_rcv, 12)
            NOX = BitConverter.ToInt16(data_rcv, 14)
            RPM = BitConverter.ToInt16(data_rcv, 16)
            OilTemp = BitConverter.ToInt16(data_rcv, 18)
            AmbientTemp = BitConverter.ToInt16(data_rcv, 20)
            Pressure = BitConverter.ToInt16(data_rcv, 22)

            GetDataResults.HC = HC
            GetDataResults.CO = CO
            GetDataResults.CO2 = CO2
            GetDataResults.O2 = O2
            GetDataResults.NOX = NOX
            GetDataResults.RPM = RPM
            GetDataResults.OilTemp = OilTemp
            GetDataResults.AmbientTemp = AmbientTemp
            GetDataResults.Pressure = Pressure

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

    Public Function Comando_MB_GetStatus(ByRef OverallStatus As Overall_Status,
                                         ByRef ZeroStatus As Zero_Status,
                                         ByRef SinglePointCalibrationStatus As SinglePointCalibration_Status,
                                         ByRef TwoPointCalibrationStatus As TwoPointCalibration_Status,
                                         ByRef BenchOperationalWarnings As BenchOperational_Warnings,
                                         ByRef ADConverterChannels As ADConverter_Channels) As String
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

                TwoPointCalibrationStatus.HC_Cal = False
                If satatusWord3 And &H1 Then
                    TwoPointCalibrationStatus.HC_Cal = True
                End If
                TwoPointCalibrationStatus.CO_Cal = False
                If satatusWord3 And &H2 Then
                    TwoPointCalibrationStatus.CO_Cal = True
                End If
                TwoPointCalibrationStatus.CO2_Cal = False
                If satatusWord3 And &H4 Then
                    TwoPointCalibrationStatus.CO2_Cal = True
                End If

                BenchOperationalWarnings.BlockHeater = False
                If satatusWord6 And &H2 Then
                    BenchOperationalWarnings.BlockHeater = True
                End If
                BenchOperationalWarnings.O2OffsetVoltage_Warning = False
                If satatusWord6 And &H4 Then
                    BenchOperationalWarnings.O2OffsetVoltage_Warning = True
                End If
                BenchOperationalWarnings.NOXOffsetVoltage_OutRange = False
                If satatusWord6 And &H8 Then
                    BenchOperationalWarnings.NOXOffsetVoltage_OutRange = True
                End If
                BenchOperationalWarnings.NDIRBeamStrength_Warning = False
                If satatusWord6 And &H2000 Then
                    BenchOperationalWarnings.NDIRBeamStrength_Warning = True
                End If
                BenchOperationalWarnings.IncompatibleEEPROM = False
                If satatusWord6 And &H8000 Then
                    BenchOperationalWarnings.IncompatibleEEPROM = True
                End If

                ADConverterChannels.HC_Channel_railed = False
                If satatusWord7 And &H1 Then
                    ADConverterChannels.HC_Channel_railed = True
                End If
                ADConverterChannels.CO_Channel_railed = False
                If satatusWord7 And &H2 Then
                    ADConverterChannels.CO_Channel_railed = True
                End If
                ADConverterChannels.CO2_Channel_railed = False
                If satatusWord7 And &H4 Then
                    ADConverterChannels.CO2_Channel_railed = True
                End If
                ADConverterChannels.O2_Channel_railed = False
                If satatusWord7 And &H8 Then
                    ADConverterChannels.O2_Channel_railed = True
                End If
                ADConverterChannels.NOX_Channel_railed = False
                If satatusWord7 And &H10 Then
                    ADConverterChannels.NOX_Channel_railed = True
                End If
                ADConverterChannels.RPM_Channel_railed = False
                If satatusWord7 And &H20 Then
                    ADConverterChannels.RPM_Channel_railed = True
                End If
                ADConverterChannels.OIL_Channel_railed = False
                If satatusWord7 And &H40 Then
                    ADConverterChannels.OIL_Channel_railed = True
                End If
                ADConverterChannels.TEMP_Channel_railed = False
                If satatusWord7 And &H80 Then
                    ADConverterChannels.TEMP_Channel_railed = True
                End If
                ADConverterChannels.PRESS_Channel_railed = False
                If satatusWord7 And &H100 Then
                    ADConverterChannels.PRESS_Channel_railed = True
                End If
                ADConverterChannels.BlOCK_Channel_railed = False
                If satatusWord7 And &H800 Then
                    ADConverterChannels.BlOCK_Channel_railed = True
                End If

                Warm_Up_Time = satatusWord9

                Return "1,Datos Almacenados en las estructuras"
            Else
                Return strResult
            End If
        Catch ex As Exception
            Return "0," + ex.Message
        End Try
    End Function


    ''' <summary>
    ''' prueba Summary
    ''' </summary>
    ''' <param name="mode">indica el modo </param>
    ''' <param name="gas">indica el tipo de gas</param>
    ''' <returns>string separado por coma</returns>
    ''' 

    Public Function Comando_MB_Calibration(mode As UInteger, gas As UInteger, ByRef GetDataResults As GetData_Results) As String
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

                GetDataResults.lowFlow = False
                If mini_status And &B1 Then
                    GetDataResults.lowFlow = True
                End If

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

    Public Function Comando_MB_Read_Calibration(dataSet As Integer, PEF_Value As Short, ByRef CalibrationData As Calibration_Data) As String
        Try
            Dim data(3) As Byte
            Dim strResult As String
            Dim strResults() As String
            Dim HC, CO, CO2, O2, NOX, HiHC, Bad_O2, High_O2 As Short

            data(0) = 0 'Read
            data(1) = 0
            data(2) = dataSet
            data(3) = 0


            If dataSet = DataSet_PEF Then
                ReDim Preserve data(5)
                data(4) = PEF_Value & &HFF
                data(5) = PEF_Value / &H100
            End If

            strResult = Microbench_command(MBReadWriteCalibration, data, data.Length)
            strResults = strResult.Split(",")
            If strResults(0) = "1" Then
                Select Case dataSet
                    Case DataSet_SinglePont_Cal_HC_CO_CO2_HiHC
                        HC = BitConverter.ToInt16(data_rcv, 4)
                        CO = BitConverter.ToInt16(data_rcv, 6)
                        CO2 = BitConverter.ToInt16(data_rcv, 8)
                        HiHC = BitConverter.ToInt16(data_rcv, 10)
                        CalibrationData.HC = HC
                        CalibrationData.CO = CO
                        CalibrationData.CO2 = CO2
                        CalibrationData.HiHc = HiHC

                    Case DataSet_SinglePont_Cal_O2
                        O2 = BitConverter.ToInt16(data_rcv, 4)
                        CalibrationData.O2 = O2

                    Case DataSet_SinglePont_Cal_NOX
                        NOX = BitConverter.ToInt16(data_rcv, 4)
                        CalibrationData.NOX = NOX

                    Case DataSet_SinglePont_Cal_HC_CO_CO2_HiHC_O2_NOX
                        HC = BitConverter.ToInt16(data_rcv, 4)
                        CO = BitConverter.ToInt16(data_rcv, 6)
                        CO2 = BitConverter.ToInt16(data_rcv, 8)
                        O2 = BitConverter.ToInt16(data_rcv, 10)
                        NOX = BitConverter.ToInt16(data_rcv, 12)
                        HiHC = BitConverter.ToInt16(data_rcv, 14)

                        CalibrationData.HC = HC
                        CalibrationData.CO = CO
                        CalibrationData.CO2 = CO2
                        CalibrationData.NOX = NOX
                        CalibrationData.O2 = O2
                        CalibrationData.HiHc = HiHC

                    Case DataSet_TwolePont_Cal_HC_CO_CO2_P1
                        HC = BitConverter.ToInt16(data_rcv, 4)
                        CO = BitConverter.ToInt16(data_rcv, 6)
                        CO2 = BitConverter.ToInt16(data_rcv, 8)
                        CalibrationData.HC = HC
                        CalibrationData.CO = CO
                        CalibrationData.CO2 = CO2


                    Case DataSet_TwolePont_Cal_HC_CO_CO2_P2
                        HC = BitConverter.ToInt16(data_rcv, 4)
                        CO = BitConverter.ToInt16(data_rcv, 6)
                        CO2 = BitConverter.ToInt16(data_rcv, 8)
                        CalibrationData.HC_P2 = HC
                        CalibrationData.CO_P2 = CO
                        CalibrationData.CO2_P2 = CO2

                    Case DataSet_PEF
                        CalibrationData.PEF = BitConverter.ToInt16(data_rcv, 4)

                    Case DataSet_New_O2_Transducer_Installed
                        CalibrationData.Flag = BitConverter.ToInt16(data_rcv, 4)

                    Case DataSet_Read_Bad_O2
                        Bad_O2 = BitConverter.ToInt16(data_rcv, 4)
                        CalibrationData.Bad_O2 = Bad_O2

                    Case DataSet_Read_High_O2
                        High_O2 = BitConverter.ToInt16(data_rcv, 4)
                        CalibrationData.Bad_O2 = Bad_O2



                End Select


                Return "1,Datos Almacenados en las estructuras"
            Else
                Return strResult
            End If
        Catch ex As Exception
            Return "0," + ex.Message
        End Try
    End Function


    Public Function Comando_MB_Write_Calibration(dataSet As Integer, ByRef calibrationData As Calibration_Data) As String
        Try
            Dim data(3), DataT() As Byte
            Dim strResult As String
            Dim strResults() As String
            Dim mini_status As UInteger

            data(0) = 1 'Write
            data(1) = 0
            data(2) = dataSet
            data(3) = 0


            Select Case dataSet
                Case DataSet_SinglePont_Cal_HC_CO_CO2_HiHC
                    ReDim Preserve data(11)
                    DataT = BitConverter.GetBytes(calibrationData.HC)
                    data(4) = DataT(0)
                    data(5) = DataT(1)
                    DataT = BitConverter.GetBytes(calibrationData.CO)
                    data(6) = DataT(0)
                    data(7) = DataT(1)
                    DataT = BitConverter.GetBytes(calibrationData.CO2)
                    data(8) = DataT(0)
                    data(9) = DataT(1)
                    DataT = BitConverter.GetBytes(calibrationData.HiHc)
                    data(10) = DataT(0)
                    data(11) = DataT(1)

                Case DataSet_SinglePont_Cal_O2
                    ReDim Preserve data(5)
                    DataT = BitConverter.GetBytes(calibrationData.O2)
                    data(4) = DataT(0)
                    data(5) = DataT(1)

                Case DataSet_SinglePont_Cal_NOX
                    ReDim Preserve data(5)
                    DataT = BitConverter.GetBytes(calibrationData.NOX)
                    data(4) = DataT(0)
                    data(5) = DataT(1)

                Case DataSet_SinglePont_Cal_HC_CO_CO2_HiHC_O2_NOX
                    ReDim Preserve data(15)
                    DataT = BitConverter.GetBytes(calibrationData.HC)
                    data(4) = DataT(0)
                    data(5) = DataT(1)
                    DataT = BitConverter.GetBytes(calibrationData.CO)
                    data(6) = DataT(0)
                    data(7) = DataT(1)
                    DataT = BitConverter.GetBytes(calibrationData.CO2)
                    data(8) = DataT(0)
                    data(9) = DataT(1)
                    DataT = BitConverter.GetBytes(calibrationData.HiHc)
                    data(10) = DataT(0)
                    data(11) = DataT(1)
                    DataT = BitConverter.GetBytes(calibrationData.O2)
                    data(12) = DataT(0)
                    data(13) = DataT(1)
                    DataT = BitConverter.GetBytes(calibrationData.NOX)
                    data(14) = DataT(0)
                    data(15) = DataT(1)

                Case DataSet_TwolePont_Cal_HC_CO_CO2_P1
                    ReDim Preserve data(11)
                    DataT = BitConverter.GetBytes(calibrationData.HC)
                    data(4) = DataT(0)
                    data(5) = DataT(1)
                    DataT = BitConverter.GetBytes(calibrationData.CO)
                    data(6) = DataT(0)
                    data(7) = DataT(1)
                    DataT = BitConverter.GetBytes(calibrationData.CO2)
                    data(8) = DataT(0)
                    data(9) = DataT(1)


                Case DataSet_TwolePont_Cal_HC_CO_CO2_P2
                    ReDim Preserve data(11)
                    DataT = BitConverter.GetBytes(calibrationData.HC_P2)
                    data(4) = DataT(0)
                    data(5) = DataT(1)
                    DataT = BitConverter.GetBytes(calibrationData.CO_P2)
                    data(6) = DataT(0)
                    data(7) = DataT(1)
                    DataT = BitConverter.GetBytes(calibrationData.CO2_P2)
                    data(8) = DataT(0)
                    data(9) = DataT(1)

                Case DataSet_PEF
                    ReDim Preserve data(5)
                    DataT = BitConverter.GetBytes(calibrationData.PEF)
                    data(4) = DataT(0)
                    data(5) = DataT(1)

                Case DataSet_New_O2_Transducer_Installed
                    ReDim Preserve data(5)
                    DataT = BitConverter.GetBytes(calibrationData.Flag)
                    data(4) = DataT(0)
                    data(5) = DataT(1)

                Case DataSet_Read_Bad_O2
                    ReDim Preserve data(5)
                    DataT = BitConverter.GetBytes(calibrationData.Bad_O2)
                    data(4) = DataT(0)
                    data(5) = DataT(1)

                Case DataSet_Read_High_O2
                    ReDim Preserve data(5)
                    DataT = BitConverter.GetBytes(calibrationData.High_O2)
                    data(4) = DataT(0)
                    data(5) = DataT(1)
            End Select


            strResult = Microbench_command(MBReadWriteCalibration, data, data.Length)
            strResults = strResult.Split(",")
            If strResults(0) = "1" Then
                mini_status = data_rcv(4) + data_rcv(5) * &H100

                calibrationData.HC_Flag_Out_Range = False
                If mini_status & &H1 Then
                    calibrationData.HC_Flag_Out_Range = True
                End If
                calibrationData.CO_Flag_Out_Range = False
                If mini_status & &H2 Then
                    calibrationData.CO_Flag_Out_Range = True
                End If
                calibrationData.CO2_Flag_Out_Range = False
                If mini_status & &H4 Then
                    calibrationData.CO2_Flag_Out_Range = True
                End If
                calibrationData.O2_Flag_Out_Range = False
                If mini_status & &H8 Then
                    calibrationData.O2_Flag_Out_Range = True
                End If
                calibrationData.NOX_Flag_Out_Range = False
                If mini_status & &H10 Then
                    calibrationData.NOX_Flag_Out_Range = True
                End If
                calibrationData.New_O2_Transd_Installed = False
                If mini_status & &H20 Then
                    calibrationData.New_O2_Transd_Installed = True
                End If

            Else
                Return strResult
            End If
        Catch ex As Exception
            Return "0," + ex.Message
        End Try
    End Function

    Public Function Comando_MB_Write_I_O(Cal_Sol_1 As Integer,
                                         Cal_Sol_2 As Integer,
                                         Sol_1 As Integer,
                                         Sol_2 As Integer,
                                         Pump As Integer,
                                         Drain_Pump As Integer) As String


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
                    response = send_Microbench_command(PROCESS_STATUS, NORMAL_MODE, data_in, 0)
                End While

                If _timeOut = True Then
                    Return "0,Banco ocupado Tiempo de espera de 10 segundos agotado"
                End If
                response = send_Microbench_command(command, LENGTHY_MODE, data_in, 0)
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

            Delay(2)

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

    Private Sub TmrComunicacion_Tick(sender As Object, e As EventArgs)
        tmrComunicacion.Enabled = False
        tmrComunicacion.Stop()
        _timeOut = True
    End Sub


    Public Sub Delay(ByVal seconds As Single)
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        Do While Microsoft.VisualBasic.Timer() < start + seconds
            System.Windows.Forms.Application.DoEvents()
        Loop
    End Sub
End Class
