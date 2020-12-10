
Imports System.Windows.Forms
Imports System.Threading
Imports System.IO.Ports

Public Class Sensor_MB_Class

    'Constantes banco de gases Sensors Micrbench
    Const ACK As UInteger = 6
    Const NACK As UInteger = 21
    Const BUSY As UInteger = 5
    'Comandos Sensor Microbench
    Const MBCalibration As UInteger = 2
    Const MBGetData As UInteger = 3
    Const MBGetStatus As UInteger = 4
    Const MBReadWriteCalibration As UInteger = 5
    Const MBReadWrite_IO As UInteger = 8
    Const MBCalibrate_RPM As UInteger = 9
    Const MBGetVersion As UInteger = 12
    Const MBReadSerialNumber As UInteger = 13
    Const MBCalibrate_Pressure As UInteger = 16
    Const MBSetAccesLevel As UInteger = 18




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
    Public DataSet_TwoPont_Cal_HC_CO_CO2_P1 As UInteger = 11
    Public DataSet_TwoPont_Cal_HC_CO_CO2_P2 As UInteger = 21
    Public DataSet_PEF As UInteger = 42
    Public DataSet_New_O2_Transducer_Installed As UInteger = 50
    Public DataSet_Read_Bad_O2 As UInteger = 51
    Public DataSet_Read_High_O2 As UInteger = 52


    'Constante IO_Mode
    Public IO_Mode_Solenoid_Map As Integer = 0
    Public IO_Mode_Cal_Sol1 As Integer = 1
    Public IO_Mode_Cal_Sol2 As Integer = 2
    Public IO_Mode_Sol1 As Integer = 3
    Public IO_Mode_Sol2 As Integer = 4
    Public IO_Mode_Pump As Integer = 5
    Public IO_Mode_Drain_Pump As Integer = 6
    Public IO_Mode_Low_Flow As Integer = 7
    Public IO_Mode_Physical_IO_Map As Integer = 8

    'Constante Access Level
    Public Service_Mode As Integer = 3
    Public User_Mode As Integer = 4



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
        Dim New_O2_Transducer_Flag As Short
        Dim Bad_O2_Threshold As Integer
        Dim High_O2_Threshold As Integer
        Dim HC_Flag_Out_Range As Boolean
        Dim CO_Flag_Out_Range As Boolean
        Dim CO2_Flag_Out_Range As Boolean
        Dim O2_Flag_Out_Range As Boolean
        Dim NOX_Flag_Out_Range As Boolean
        Dim New_O2_Transd_Installed As Integer
    End Structure






    'Public Pressure_in_mbar As Integer = 1
    'Public Pressure_in_Hg As Integer = 0
    'Public Temp_in_C As Integer = 1
    'Public Temp_in_F As Integer = 0
    'Public HC_Range_0_2000_ppmHex As Integer = 1
    'Public HC_Range_0_20000_ppmHex As Integer = 0
    'Public High_Resolution_O2 As Integer = 1
    'Public Low_Resolution_O2 As Integer = 0
    'Public RPM_in_2_cycle As Integer = 1
    'Public RPM_in_4_cycle As Integer = 0
    'Public Normal_Ignition As Integer = 1
    'Public Dual_Ignition As Integer = 0
    'Public Pressure_Resolution_Low As Integer = 1
    'Public Pressure_Resolution_High As Integer = 0
    'Public HC_AS_ppm_Hexane As Integer = 1
    'Public HC_AS_ppm_Propane As Integer = 0
    'Public Oil_Temp_as_C As Integer = 1
    'Public Oil_Temp_as_mV As Integer = 0
    'Public RPM_as_1_Min As Integer = 1
    'Public RPM_as_1_mV As Integer = 0
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
    Public Shared _timeOut, _timeOutBenchBusy As Boolean   'Indica si el timer ha expirado
    Public Shared _errMsg As String


    Public Shared _serialPortMicroBench As SerialPort
    Private tmrComunicacion As Windows.Forms.Timer
    Private tmrBenchBusy As Windows.Forms.Timer



    Dim readThread As New Thread(AddressOf Read)


    Structure I_O_Port
        Dim Cal_Sol_1 As Boolean
        Dim Cal_Sol_2 As Boolean
        Dim Sol_1 As Boolean
        Dim Sol_2 As Boolean
        Dim Pump As Boolean
        Dim Drain_Pump As Boolean
        Dim Low_Flow As Boolean
        Dim Physical_IO_Map_Sample_Input As Physical_I_O_Map_Sample_Input
        Dim Physical_IO_Map_Sample_Output As Physical_I_O_Map_Sample_Output
    End Structure

    Structure Physical_I_O_Map_Sample_Output
        Dim Pin1 As Boolean
        Dim Pin2 As Boolean
        Dim Pin3 As Boolean
        Dim Pin4 As Boolean
        Dim Pin5 As Boolean
        Dim Pin6 As Boolean
        Dim Pin7 As Boolean
        Dim Pin8 As Boolean
    End Structure
    Structure Physical_I_O_Map_Sample_Input
        Dim Pin1 As Boolean
        Dim Pin2 As Boolean
        Dim Pin3 As Boolean
        Dim Pin4 As Boolean
        Dim Pin5 As Boolean
        Dim Pin6 As Boolean
        Dim Pin7 As Boolean
        Dim Pin8 As Boolean
    End Structure
    Structure Calibrate_RPM_Status
        Dim Calibration_Successfull As Boolean
        Dim RPM_Zero_Required As Boolean
        Dim No_RPM_KIT_Installed As Boolean
        Dim RPM_Calibration_Required As Boolean
    End Structure
    Structure Calibrate_Pressure_Status
        Dim No_Pressure_transducer As Boolean
        Dim AD_Railed As Boolean
        Dim Pressure_Cal1_Equal_Pressure_Cal2 As Boolean
        Dim Reading_Cal1_Equal_Reading_Cal2 As Boolean
        Dim Reading_Out_Range As Boolean
    End Structure
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

        tmrBenchBusy = New Windows.Forms.Timer()
        tmrBenchBusy.Enabled = False
        AddHandler tmrBenchBusy.Tick, AddressOf TmrBenchBusy_Tick


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
        Try

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
        Catch ex As Exception
            Return "0," + ex.Message

        End Try

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
    ''' <param name="unitsPressurembar"></param>
    ''' <param name="unitsTemp_C"></param>
    ''' <param name="HCRange_20000"></param>
    ''' <param name="O2HighResolution"></param>
    ''' <param name="Rpm2_Cycle"></param>
    ''' <param name="ignitioNormal"></param>
    ''' <param name="ResolutionPressureLow"></param>
    ''' <param name="HCasPPMHexane"></param>
    ''' <param name="OilTempAs_C"></param>
    ''' <param name="RpmAs_1xmin"></param>
    ''' <returns></returns>
    Public Function Comando_MB_GetData(mode As UInteger,
                                        unitsPressurembar As Boolean,
                                        unitsTemp_C As Boolean,
                                        HCRange_2000 As Boolean,
                                        O2HighResolution As Boolean,
                                        Rpm2_Cycle As Boolean,
                                        ignitioNormal As Boolean,
                                        ResolutionPressureLow As Boolean,
                                        HCasPPMHexane As Boolean,
                                        OilTempAs_C As Boolean,
                                        RpmAs_1xmin As Boolean,
                                       ByRef GetDataResults As GetData_Results) As String



        Try

            Dim unitsH, unitsL As Byte
            Dim status As UShort
            Dim data(3) As Byte
            Dim strResult As String
            Dim strResults() As String
            Dim HC, CO, CO2, O2, NOX, RPM, OilTemp, AmbientTemp, Pressure As Short

            unitsL = 0
            unitsH = 0
            If unitsPressurembar = False Then
                unitsL = unitsL Or &H1
            End If
            If unitsTemp_C = False Then
                unitsL = unitsL Or &H2
            End If
            If HCRange_2000 = False Then
                unitsL = unitsL Or &H4
            End If
            If O2HighResolution = False Then
                unitsL = unitsL Or &H8
            End If
            If Rpm2_Cycle = False Then
                unitsL = unitsL Or &H10
            End If
            If ignitioNormal = False Then
                unitsL = unitsL Or &H20
            End If
            If ResolutionPressureLow = False Then
                unitsL = unitsL Or &H40
            End If
            If HCasPPMHexane = False Then
                unitsL = unitsL Or &H80
            End If
            If OilTempAs_C = False Then
                unitsH = unitsH Or &H100
            End If
            If RpmAs_1xmin = False Then
                unitsH = unitsH Or &H200
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
        Catch ex As Exception
            Return "0," + ex.Message
        End Try


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

    Public Function Comando_MB_Calibration(mode As UInteger,
                                           HC As Boolean,
                                           CO As Boolean,
                                           CO2 As Boolean,
                                           O2 As Boolean,
                                           NOx As Boolean,
                                           HiHC As Boolean) As String
        Try

            Dim data(3) As Byte
            Dim gasByte As Byte
            Dim strResult As String
            Dim strResults() As String
            Dim mini_status As UInteger

            gasByte = 0
            If HC Then
                gasByte = gasByte Or &H1
            End If
            If CO Then
                gasByte = gasByte Or &H2
            End If
            If CO2 Then
                gasByte = gasByte Or &H4
            End If
            If O2 Then
                gasByte = gasByte Or &H8
            End If
            If NOx Then
                gasByte = gasByte Or &H10
            End If
            If HiHC Then
                gasByte = gasByte Or &H20
            End If

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

    Public Function Comando_MB_Read_Calibration(dataSet As Integer, ByRef CalibrationData As Calibration_Data) As String
        Try
            Dim data(3), dataT() As Byte
            Dim strResult As String
            Dim strResults() As String
            Dim HC, CO, CO2, O2, NOX, HiHC, Bad_O2, High_O2 As Short

            data(0) = 0 'Read
            data(1) = 0
            data(2) = dataSet
            data(3) = 0


            If dataSet = DataSet_PEF Then
                ReDim Preserve data(5)
                dataT = BitConverter.GetBytes(CalibrationData.PEF)
                data(4) = dataT(0)
                data(5) = dataT(1)
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

                    Case DataSet_TwoPont_Cal_HC_CO_CO2_P1
                        HC = BitConverter.ToInt16(data_rcv, 4)
                        CO = BitConverter.ToInt16(data_rcv, 6)
                        CO2 = BitConverter.ToInt16(data_rcv, 8)
                        CalibrationData.HC = HC
                        CalibrationData.CO = CO
                        CalibrationData.CO2 = CO2


                    Case DataSet_TwoPont_Cal_HC_CO_CO2_P2
                        HC = BitConverter.ToInt16(data_rcv, 4)
                        CO = BitConverter.ToInt16(data_rcv, 6)
                        CO2 = BitConverter.ToInt16(data_rcv, 8)
                        CalibrationData.HC_P2 = HC
                        CalibrationData.CO_P2 = CO
                        CalibrationData.CO2_P2 = CO2

                    Case DataSet_PEF
                        CalibrationData.PEF = BitConverter.ToInt16(data_rcv, 4)

                    Case DataSet_New_O2_Transducer_Installed
                        CalibrationData.New_O2_Transducer_Flag = BitConverter.ToInt16(data_rcv, 4)

                    Case DataSet_Read_Bad_O2
                        Bad_O2 = BitConverter.ToInt16(data_rcv, 4)
                        CalibrationData.Bad_O2_Threshold = Bad_O2

                    Case DataSet_Read_High_O2
                        High_O2 = BitConverter.ToInt16(data_rcv, 4)
                        CalibrationData.Bad_O2_Threshold = Bad_O2



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

                Case DataSet_TwoPont_Cal_HC_CO_CO2_P1
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


                Case DataSet_TwoPont_Cal_HC_CO_CO2_P2
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
                    DataT = BitConverter.GetBytes(calibrationData.New_O2_Transducer_Flag)
                    data(4) = DataT(0)
                    data(5) = DataT(1)

                Case DataSet_Read_Bad_O2
                    ReDim Preserve data(5)
                    DataT = BitConverter.GetBytes(calibrationData.Bad_O2_Threshold)
                    data(4) = DataT(0)
                    data(5) = DataT(1)

                Case DataSet_Read_High_O2
                    ReDim Preserve data(5)
                    DataT = BitConverter.GetBytes(calibrationData.High_O2_Threshold)
                    data(4) = DataT(0)
                    data(5) = DataT(1)
            End Select


            strResult = Microbench_command(MBReadWriteCalibration, data, data.Length)
            strResults = strResult.Split(",")
            If strResults(0) = "1" Then
                mini_status = data_rcv(4) + data_rcv(5) * &H100

                calibrationData.HC_Flag_Out_Range = False
                If mini_status And &H1 Then
                    calibrationData.HC_Flag_Out_Range = True
                End If
                calibrationData.CO_Flag_Out_Range = False
                If mini_status And &H2 Then
                    calibrationData.CO_Flag_Out_Range = True
                End If
                calibrationData.CO2_Flag_Out_Range = False
                If mini_status And &H4 Then
                    calibrationData.CO2_Flag_Out_Range = True
                End If
                calibrationData.O2_Flag_Out_Range = False
                If mini_status And &H8 Then
                    calibrationData.O2_Flag_Out_Range = True
                End If
                calibrationData.NOX_Flag_Out_Range = False
                If mini_status And &H10 Then
                    calibrationData.NOX_Flag_Out_Range = True
                End If
                calibrationData.New_O2_Transd_Installed = False
                If mini_status And &H20 Then
                    calibrationData.New_O2_Transd_Installed = True
                End If
                Return "1,Datos Almacenados en las estructuras"
            Else
                Return strResult
            End If
        Catch ex As Exception
            Return "0," + ex.Message
        End Try
    End Function
    Public Function Comando_MB_Read_I_O(IO_Mode As Integer, ByRef IO_Port As I_O_Port) As String
        Try

            Dim data(3) As Byte
            Dim strResult As String
            Dim strResults() As String

            IO_Port.Cal_Sol_1 = False
            IO_Port.Cal_Sol_2 = False
            IO_Port.Sol_1 = False
            IO_Port.Sol_2 = False
            IO_Port.Pump = False
            IO_Port.Drain_Pump = False
            IO_Port.Low_Flow = False
            IO_Port.Physical_IO_Map_Sample_Output.Pin1 = False
            IO_Port.Physical_IO_Map_Sample_Output.Pin2 = False
            IO_Port.Physical_IO_Map_Sample_Output.Pin3 = False
            IO_Port.Physical_IO_Map_Sample_Output.Pin4 = False
            IO_Port.Physical_IO_Map_Sample_Output.Pin5 = False
            IO_Port.Physical_IO_Map_Sample_Output.Pin6 = False
            IO_Port.Physical_IO_Map_Sample_Output.Pin7 = False
            IO_Port.Physical_IO_Map_Sample_Output.Pin8 = False

            IO_Port.Physical_IO_Map_Sample_Input.Pin1 = False
            IO_Port.Physical_IO_Map_Sample_Input.Pin2 = False
            IO_Port.Physical_IO_Map_Sample_Input.Pin3 = False
            IO_Port.Physical_IO_Map_Sample_Input.Pin4 = False
            IO_Port.Physical_IO_Map_Sample_Input.Pin5 = False
            IO_Port.Physical_IO_Map_Sample_Input.Pin6 = False
            IO_Port.Physical_IO_Map_Sample_Input.Pin7 = False
            IO_Port.Physical_IO_Map_Sample_Input.Pin8 = False

            data(0) = 0 'Read
            data(1) = 0
            data(2) = IO_Mode
            data(3) = 0
            strResult = Microbench_command(MBReadWrite_IO, data, data.Length)
            strResults = strResult.Split(",")
            If strResults(0) = "1" Then
                Select Case IO_Mode
                    Case IO_Mode_Solenoid_Map
                        If data_rcv(4) And &H1 Then
                            IO_Port.Cal_Sol_1 = True
                        End If
                        If data_rcv(4) And &H2 Then
                            IO_Port.Cal_Sol_2 = True
                        End If
                        If data_rcv(4) And &H4 Then
                            IO_Port.Sol_1 = True
                        End If
                        If data_rcv(4) And &H8 Then
                            IO_Port.Sol_2 = True
                        End If
                        If data_rcv(4) And &H10 Then
                            IO_Port.Pump = True
                        End If
                        If data_rcv(4) And &H20 Then
                            IO_Port.Drain_Pump = True
                        End If

                    Case IO_Mode_Cal_Sol1
                        If data_rcv(4) = 1 Then
                            IO_Port.Cal_Sol_1 = True
                        End If

                    Case IO_Mode_Cal_Sol2
                        If data_rcv(4) = 1 Then
                            IO_Port.Cal_Sol_2 = True
                        End If
                    Case IO_Mode_Sol1
                        If data_rcv(4) = 1 Then
                            IO_Port.Sol_1 = True
                        End If

                    Case IO_Mode_Sol2
                        If data_rcv(4) = 1 Then
                            IO_Port.Sol_2 = True
                        End If

                    Case IO_Mode_Pump
                        If data_rcv(4) = 1 Then
                            IO_Port.Pump = True
                        End If

                    Case IO_Mode_Drain_Pump
                        If data_rcv(4) = 1 Then
                            IO_Port.Drain_Pump = True
                        End If

                    Case IO_Mode_Low_Flow
                        If data_rcv(4) = 1 Then
                            IO_Port.Low_Flow = True
                        End If

                    Case IO_Mode_Physical_IO_Map
                        If data_rcv(4) And &H1 Then
                            IO_Port.Physical_IO_Map_Sample_Output.Pin1 = True
                        End If
                        If data_rcv(4) And &H2 Then
                            IO_Port.Physical_IO_Map_Sample_Output.Pin2 = True
                        End If
                        If data_rcv(4) And &H4 Then
                            IO_Port.Physical_IO_Map_Sample_Output.Pin3 = True
                        End If
                        If data_rcv(4) And &H8 Then
                            IO_Port.Physical_IO_Map_Sample_Output.Pin4 = True
                        End If
                        If data_rcv(4) And &H10 Then
                            IO_Port.Physical_IO_Map_Sample_Output.Pin5 = True
                        End If
                        If data_rcv(4) And &H20 Then
                            IO_Port.Physical_IO_Map_Sample_Output.Pin6 = True
                        End If
                        If data_rcv(4) And &H40 Then
                            IO_Port.Physical_IO_Map_Sample_Output.Pin7 = True
                        End If
                        If data_rcv(4) And &H80 Then
                            IO_Port.Physical_IO_Map_Sample_Output.Pin8 = True
                        End If

                        If data_rcv(5) And &H1 Then
                            IO_Port.Physical_IO_Map_Sample_Input.Pin1 = True
                        End If
                        If data_rcv(5) And &H2 Then
                            IO_Port.Physical_IO_Map_Sample_Input.Pin2 = True
                        End If
                        If data_rcv(5) And &H4 Then
                            IO_Port.Physical_IO_Map_Sample_Input.Pin3 = True
                        End If
                        If data_rcv(5) And &H8 Then
                            IO_Port.Physical_IO_Map_Sample_Input.Pin4 = True
                        End If
                        If data_rcv(5) And &H10 Then
                            IO_Port.Physical_IO_Map_Sample_Input.Pin5 = True
                        End If
                        If data_rcv(5) And &H20 Then
                            IO_Port.Physical_IO_Map_Sample_Input.Pin6 = True
                        End If
                        If data_rcv(5) And &H40 Then
                            IO_Port.Physical_IO_Map_Sample_Input.Pin7 = True
                        End If
                        If data_rcv(5) And &H80 Then
                            IO_Port.Physical_IO_Map_Sample_Input.Pin8 = True
                        End If

                End Select
                Return "1,Datos Almacenados en la estructura"
            Else
                Return strResult
            End If
        Catch ex As Exception
            Return "0," + ex.Message
        End Try
    End Function
    Public Function Comando_MB_Write_I_O(IO_Mode As Integer, IO_Port As I_O_Port) As String
        Try

            Dim data(5) As Byte
            Dim strResult As String
            Dim strResults() As String



            data(0) = 1 'Write
            data(1) = 0
            data(2) = IO_Mode
            data(3) = 0
            data(4) = 0
            data(5) = 0

            Select Case IO_Mode
                Case IO_Mode_Solenoid_Map
                    If IO_Port.Cal_Sol_1 Then
                        data(4) = data(4) Or &H1
                    End If
                    If IO_Port.Cal_Sol_2 Then
                        data(4) = data(4) Or &H2
                    End If
                    If IO_Port.Sol_1 Then
                        data(4) = data(4) Or &H4
                    End If
                    If IO_Port.Sol_2 Then
                        data(4) = data(4) Or &H8
                    End If
                    If IO_Port.Pump Then
                        data(4) = data(4) Or &H10
                    End If
                    If IO_Port.Drain_Pump Then
                        data(4) = data(4) Or &H20
                    End If


                Case IO_Mode_Cal_Sol1
                    If IO_Port.Cal_Sol_1 Then
                        data(4) = 1
                    End If

                Case IO_Mode_Cal_Sol2
                    If IO_Port.Cal_Sol_1 Then
                        data(4) = 1
                    End If
                Case IO_Mode_Sol1
                    If IO_Port.Sol_1 Then
                        data(4) = 1
                    End If

                Case IO_Mode_Sol2
                    If IO_Port.Sol_2 Then
                        data(4) = 1
                    End If

                Case IO_Mode_Pump
                    If IO_Port.Pump Then
                        data(4) = 1
                    End If

                Case IO_Mode_Drain_Pump
                    If IO_Port.Drain_Pump Then
                        data(4) = 1
                    End If

                Case IO_Mode_Low_Flow
                    Return "0,IO_Mode no permitido"

                Case IO_Mode_Physical_IO_Map
                    If IO_Port.Physical_IO_Map_Sample_Output.Pin1 Then
                        data(4) = data(4) Or &H1
                    End If
                    If IO_Port.Physical_IO_Map_Sample_Output.Pin2 Then
                        data(4) = data(4) Or &H2
                    End If
                    If IO_Port.Physical_IO_Map_Sample_Output.Pin3 Then
                        data(4) = data(4) Or &H4
                    End If
                    If IO_Port.Physical_IO_Map_Sample_Output.Pin4 Then
                        data(4) = data(4) Or &H8
                    End If
                    If IO_Port.Physical_IO_Map_Sample_Output.Pin5 Then
                        data(4) = data(4) Or &H10
                    End If
                    If IO_Port.Physical_IO_Map_Sample_Output.Pin6 Then
                        data(4) = data(4) Or &H20
                    End If
                    If IO_Port.Physical_IO_Map_Sample_Output.Pin7 Then
                        data(4) = data(4) Or &H40
                    End If
                    If IO_Port.Physical_IO_Map_Sample_Output.Pin8 Then
                        data(4) = data(4) Or &H80
                    End If


            End Select

            strResult = Microbench_command(MBReadWrite_IO, data, data.Length)
            strResults = strResult.Split(",")
            If strResults(0) = "1" Then
                Return "1,Exito"
            Else
                Return strResult
            End If
        Catch ex As Exception
            Return "0," + ex.Message
        End Try
    End Function


    Public Function Comando_MB_Calibrate_RPM(RPM As UShort, ByRef RPM_Status As Calibrate_RPM_Status) As String
        Try

            Dim data() As Byte
            Dim strResult As String
            Dim strResults() As String




            If (RPM < 0) Or (RPM > 9999) Then
                Return "0,Valor RPM invalido (0-9999)"
            End If
            data = BitConverter.GetBytes(RPM)

            RPM_Status.Calibration_Successfull = False
            RPM_Status.RPM_Zero_Required = False
            RPM_Status.No_RPM_KIT_Installed = False
            RPM_Status.RPM_Calibration_Required = False

            strResult = Microbench_command(MBCalibrate_RPM, data, data.Length)
            strResults = strResult.Split(",")
            If strResults(0) = "1" Then

                If data_rcv(4) = 0 Then
                    RPM_Status.Calibration_Successfull = True
                End If
                If data_rcv(4) = 1 Then
                    RPM_Status.RPM_Zero_Required = True
                End If
                If data_rcv(4) = 2 Then
                    RPM_Status.No_RPM_KIT_Installed = True
                End If
                If data_rcv(4) = 3 Then
                    RPM_Status.RPM_Calibration_Required = True
                End If

                Return "1,Datos almacenados en la estructura"
            Else
                Return strResult
            End If

        Catch ex As Exception
            Return "0," + ex.Message
        End Try
    End Function
    Public Function Comando_MB_ReadSerialNumber() As String
        Try

            Dim data(3) As Byte
            Dim strResult As String
            Dim strResults() As String
            Dim version As UInteger

            data(0) = 0
            data(1) = 0
            data(2) = 0
            data(3) = 0

            strResult = Microbench_command(MBReadSerialNumber, data, data.Length)
            strResults = strResult.Split(",")
            If strResults(0) = "1" Then
                version = BitConverter.ToInt16(data_rcv, 4)
                Return "1," + version.ToString
            Else
                Return strResult
            End If
        Catch ex As Exception
            Return "0," + ex.Message

        End Try

    End Function

    Public Function Comando_MB_Calibrate_Pressure(Cal_Mode As UShort, Pressure As UShort, Unit As UShort, ByRef Pressure_Status As Calibrate_Pressure_Status) As String
        Try

            Dim data(5), dataPress() As Byte
            Dim strResult As String
            Dim strResults() As String



            data(0) = Cal_Mode
            data(1) = 0
            dataPress = BitConverter.GetBytes(Pressure)
            data(2) = dataPress(0)
            data(3) = dataPress(1)
            data(4) = Unit
            data(5) = 0

            Pressure_Status.No_Pressure_transducer = False
            Pressure_Status.AD_Railed = False
            Pressure_Status.Pressure_Cal1_Equal_Pressure_Cal2 = False
            Pressure_Status.Reading_Cal1_Equal_Reading_Cal2 = False
            Pressure_Status.Reading_Out_Range = False


            strResult = Microbench_command(MBCalibrate_RPM, data, data.Length)
            strResults = strResult.Split(",")
            If strResults(0) = "1" Then

                If data_rcv(4) And &H1 Then
                    Pressure_Status.No_Pressure_transducer = True
                End If
                If data_rcv(4) And &H2 Then
                    Pressure_Status.AD_Railed = True
                End If
                If data_rcv(4) And &H4 Then
                    Pressure_Status.Pressure_Cal1_Equal_Pressure_Cal2 = True
                End If
                If data_rcv(4) And &H8 Then
                    Pressure_Status.Reading_Cal1_Equal_Reading_Cal2 = True
                End If
                If data_rcv(4) And &H10 Then
                    Pressure_Status.Reading_Out_Range = True
                End If

                Return "1,Datos almacenados en la estructura"
            Else
                Return strResult
            End If

        Catch ex As Exception
            Return "0," + ex.Message
        End Try
    End Function
    Public Function Comando_MB_SetAccessLevel(AccesLevel As Integer) As String
        Try

            Dim data(1) As Byte
            Dim strResult As String
            Dim strResults() As String
            Dim version As UInteger

            data(0) = AccesLevel
            data(1) = 0

            strResult = Microbench_command(MBSetAccesLevel, data, data.Length)
            strResults = strResult.Split(",")
            If strResults(0) = "1" Then
                version = BitConverter.ToInt16(data_rcv, 4)
                Return "1," + version.ToString
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
                IniTemporizadorBenchBusy(10)
                While response = BUSY And _timeOutBenchBusy = False
                    response = send_Microbench_command(PROCESS_STATUS, NORMAL_MODE, data_in, 0)
                End While

                If _timeOutBenchBusy = True Then
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
            data_send(i + 1) = (chkSum And &HFF00) >> 8
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

            Delay(1)

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


    Private Sub IniTemporizadorBenchBusy(segundos As UInteger)
        'Inicializa temporizador de 2 segundos para recibir paquete

        tmrBenchBusy.Interval = segundos * 1000
        tmrBenchBusy.Enabled = True
        tmrBenchBusy.Start()
        _timeOutBenchBusy = False
    End Sub

    Private Sub TmrBenchBusy_Tick(sender As Object, e As EventArgs)
        tmrBenchBusy.Enabled = False
        tmrBenchBusy.Stop()
        _timeOutBenchBusy = True
    End Sub

    Public Sub Delay(ByVal seconds As Single)
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        Do While Microsoft.VisualBasic.Timer() < start + seconds
            System.Windows.Forms.Application.DoEvents()
        Loop
    End Sub
End Class
