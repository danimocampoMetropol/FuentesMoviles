Imports System.ComponentModel
Imports System.IO.Ports
Imports System.Threading
Imports System.Windows.Forms

Public Class frmFuentesMoviles

  
    Public Shared frmIncio As New frmFuentesMoviles
    Public Shared Sensor_MB As Sensor_MB_Class
    Public Shared Opacimetro As Opacimetro_CAP3030_Class



    Public Shared Sub Main()






        frmIncio.ShowDialog()




    End Sub


    Private Sub Inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_continue = True
        'readThread.Start() 'Inicia Thread de recepcion

        For Each sp As String In SerialPort.GetPortNames

            cmbPuertoMicroBench.Items.Add(sp)
            cmbPuertoOpacimetro.Items.Add(sp)
        Next
    End Sub

    Private Sub Inicio_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            If cmbPuertoMicroBench.SelectedIndex <> -1 Then
                Sensor_MB._continue = False
            End If
            If cmbPuertoOpacimetro.SelectedIndex <> -1 Then
                Opacimetro._continue = False
            End If

        Catch ex As Exception
            Return
        End Try
    End Sub

    Private Sub btnGetVersion_Click(sender As Object, e As EventArgs) Handles btnGetVersion.Click
        Dim strResult As String
        Dim strResults() As String

        If cmbPuertoMicroBench.SelectedIndex < 0 Then
            MsgBox("Seleccione Pueto")
            Return
        End If

        strResult = Sensor_MB.Comando_MB_GetVersionSoftware()
        strResults = strResult.Split(",")

        If strResults(0) = "1" Then
            txtConsola.AppendText("Version Software:  " + strResults(1) + vbCrLf)
        Else
            txtConsola.AppendText("Version Software ERROR:  " + strResults(1) + vbCrLf)
        End If


        strResult = Sensor_MB.Comando_MB_GetVersionHardware()
        strResults = strResult.Split(",")
        If strResults(0) = "1" Then
            txtConsola.AppendText("Version Hardware:  " + strResults(1) + vbCrLf)
        Else
            txtConsola.AppendText("Version Hardware ERROR:  " + strResults(1) + vbCrLf)
        End If

    End Sub

    Private Sub btnCalibration_Click(sender As Object, e As EventArgs) Handles btnCalibration.Click


        Dim strResult As String
        Dim strResults() As String

        If cmbPuertoMicroBench.SelectedIndex < 0 Then
            MsgBox("Seleccione Pueto")
            Return
        End If



        If cmbCalibrationMode.SelectedIndex <> -1 Then
            strResult = Sensor_MB.Comando_MB_Calibration(cmbCalibrationMode.SelectedIndex,
                                                         chkHC.Checked,
                                                         chkCO.Checked,
                                                         chkCO2.Checked,
                                                         chkO2.Checked,
                                                         chkNOx.Checked,
                                                         chkHiHC.Checked)
            strResults = strResult.Split(",")
            txtConsola.AppendText(vbCrLf + "CALIBRATION  " + strResults(1) + vbCrLf)

        Else
            MsgBox("Seleccione Modo y Gas", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        Dim strResult As String
        Dim strResults() As String
        Dim GetDataResults As Sensor_MB_Class.GetData_Results

        Dim GasSelection As UInteger


        If cmbPuertoMicroBench.SelectedIndex < 0 Then
            MsgBox("Seleccione Pueto")
            Return
        End If

        Select Case cmbGasDatain.SelectedItem
            Case "Concentracion"
                GasSelection = Sensor_MB.Report_Gas_Data_in_Concentration
            Case "Voltage"
                GasSelection = Sensor_MB.Report_Gas_Data_in_Voltage
            Case "A/D Counts"
                GasSelection = Sensor_MB.Report_Gas_Data_in_AD_Counts
            Case "Modulations"
                GasSelection = Sensor_MB.Report_Gas_Data_in_Modulation
            Case Else
                MsgBox("Seleccione Tipo de dato")
                Return
        End Select



        strResult = Sensor_MB.Comando_MB_GetData(GasSelection,
        rdbPressmbar.Checked,
         rdbTempC.Checked,
        rdbHC2000.Checked,
        rdbO2ResHigh.Checked,
        rdbRPM2.Checked,
        rdbIgnitionNormal.Checked,
        rdbPressResLow.Checked,
        rdbHCHexane.Checked,
        rdbOiltempC.Checked,
        rdbRPM1_min.Checked,
        GetDataResults)

        strResults = strResult.Split(",")
        txtConsola.AppendText(vbCrLf + "GET DATA  " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            'las unidades y los puntos decimales dependen de la seleccion de realizada .
            'para efectos de ejemplo se presentan los valores tal cual son enviados por el banco de gases
            txtConsola.AppendText("HC=" + GetDataResults.HC.ToString + vbCrLf)
            txtConsola.AppendText("CO=" + GetDataResults.CO.ToString + vbCrLf)
            txtConsola.AppendText("CO2=" + GetDataResults.CO2.ToString + vbCrLf)
            txtConsola.AppendText("O2=" + GetDataResults.O2.ToString + vbCrLf)
            txtConsola.AppendText("NOX=" + GetDataResults.NOX.ToString + vbCrLf)
            txtConsola.AppendText("RPM=" + GetDataResults.RPM.ToString + vbCrLf)
            txtConsola.AppendText("Oil Temp=" + GetDataResults.OilTemp.ToString + vbCrLf)
            txtConsola.AppendText("Ambient Temp=" + GetDataResults.AmbientTemp.ToString + vbCrLf)
            txtConsola.AppendText("Pressure=" + GetDataResults.Pressure.ToString + vbCrLf)
            txtConsola.AppendText("low Flow=" + GetDataResults.lowFlow.ToString + vbCrLf)
            txtConsola.AppendText("Filter Bowl Full=" + GetDataResults.FilterBowlFull.ToString + vbCrLf)
            txtConsola.AppendText("Alarm=" + GetDataResults.Alarm.ToString + vbCrLf)
            txtConsola.AppendText("Data May Not Be Accurate=" + GetDataResults.DataMayNotBeAccurate.ToString + vbCrLf)
            txtConsola.AppendText("ZERO_recommended=" + GetDataResults.ZERO_recommended.ToString + vbCrLf)
            txtConsola.AppendText("HighHC_Range=" + GetDataResults.HighHC_Range.ToString + vbCrLf)
            txtConsola.AppendText("Condensation Warning=" + GetDataResults.CondensationWarning.ToString + vbCrLf)
            txtConsola.AppendText("HC_OutRange=" + GetDataResults.HC_OutRange.ToString + vbCrLf)
            txtConsola.AppendText("CO_OutRange=" + GetDataResults.CO_OutRange.ToString + vbCrLf)
            txtConsola.AppendText("CO2_OutRange=" + GetDataResults.CO2_OutRange.ToString + vbCrLf)
            txtConsola.AppendText("O2_OutRange=" + GetDataResults.O2_OutRange.ToString + vbCrLf)
            txtConsola.AppendText("NOX_OutRange=" + GetDataResults.NOX_OutRange.ToString + vbCrLf)
            txtConsola.AppendText("Bench Internal Warning=" + GetDataResults.BenchInternalWarning.ToString + vbCrLf)

        End If








        'strResult = Sensor_MB.Comando_MB_Calibration(0, 0, GetDataResults)


    End Sub

    Private Sub btnEscanear_Click(sender As Object, e As EventArgs) Handles btnEscanear.Click

    End Sub



    Private Sub btnReadCalibration_Click(sender As Object, e As EventArgs) Handles btnReadCalibration.Click
        Dim strResult As String
        Dim strResults() As String
        Dim CalibrationData As New Sensor_MB_Class.Calibration_Data
        If cmbPuertoMicroBench.SelectedIndex < 0 Then
            MsgBox("Seleccione Pueto")
            Return
        End If
        'A continuacion se envia el comando Read Calibration para cada tipo de DataSet
        'Las constantes para identificar cada uno de los DataSet se llaman utilizando las constantes publicas 
        'de la clase  Sensor_MB_Class.DataSet_... 
        'Seleccione el Dataset adecuado segun la operacion que este realizando

        txtConsola.AppendText(vbCrLf + "READ CALIBRATION DATA " + vbCrLf)
        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_SinglePont_Cal_HC_CO_CO2_HiHC, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText("DataSet SinglePont Cal HC,CO,CO2,HiHC:  " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("HC=" + CalibrationData.HC.ToString + vbCrLf)
            txtConsola.AppendText("CO=" + CalibrationData.CO.ToString + vbCrLf)
            txtConsola.AppendText("CO2=" + CalibrationData.CO2.ToString + vbCrLf)
            txtConsola.AppendText("HiHC=" + CalibrationData.HiHc.ToString + vbCrLf)
        End If

        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_SinglePont_Cal_O2, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText("DataSet SinglePont Cal O2:  " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("O2=" + CalibrationData.O2.ToString + vbCrLf)
        End If

        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_SinglePont_Cal_NOX, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText("DataSet SinglePont Cal NOX:  " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("NOX=" + CalibrationData.NOX.ToString + vbCrLf)
        End If

        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_SinglePont_Cal_HC_CO_CO2_HiHC_O2_NOX, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText("DataSet SinglePont Cal HC,CO,CO2,HiHC,O2,NOX:  " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("HC=" + CalibrationData.HC.ToString + vbCrLf)
            txtConsola.AppendText("CO=" + CalibrationData.CO.ToString + vbCrLf)
            txtConsola.AppendText("CO2=" + CalibrationData.CO2.ToString + vbCrLf)
            txtConsola.AppendText("HiHC=" + CalibrationData.HiHc.ToString + vbCrLf)
            txtConsola.AppendText("O2=" + CalibrationData.O2.ToString + vbCrLf)
            txtConsola.AppendText("NOX=" + CalibrationData.NOX.ToString + vbCrLf)
        End If

        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_TwoPont_Cal_HC_CO_CO2_P1, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText("DataSet Two Point Cal HC,CO,CO2 Point 1:  " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("HC=" + CalibrationData.HC.ToString + vbCrLf)
            txtConsola.AppendText("CO=" + CalibrationData.CO.ToString + vbCrLf)
            txtConsola.AppendText("CO2=" + CalibrationData.CO2.ToString + vbCrLf)
        End If

        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_TwoPont_Cal_HC_CO_CO2_P2, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText("DataSet Two Point Cal HC,CO,CO2 Point 2:  " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("HC=" + CalibrationData.HC_P2.ToString + vbCrLf)
            txtConsola.AppendText("CO=" + CalibrationData.CO_P2.ToString + vbCrLf)
            txtConsola.AppendText("CO2=" + CalibrationData.CO2_P2.ToString + vbCrLf)
        End If

        CalibrationData.PEF = 2000 'asignar valor PEF en la estructura para ser enviado en el comando
        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_PEF, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText("DataSet PEF Constant:  " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("PEF=" + CalibrationData.PEF.ToString + vbCrLf)
        End If

        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_New_O2_Transducer_Installed, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText("DataSet New O2 Transducer Installed:  " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("New O2 Transd Installed=" + CalibrationData.New_O2_Transd_Installed.ToString + vbCrLf)
        End If

        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_Read_Bad_O2, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText("DataSet DataSet Read Bad O2:  " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("Bad O2=" + CalibrationData.Bad_O2_Threshold.ToString + vbCrLf)
        End If

        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_Read_High_O2, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText("DataSet DataSet Read High O2:  " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("High O2=" + CalibrationData.High_O2_Threshold.ToString + vbCrLf)
        End If



    End Sub

    Private Sub btnGetStatus_Click(sender As Object, e As EventArgs) Handles btnGetStatus.Click
        Dim OverAllStatus As Sensor_MB_Class.Overall_Status
        Dim ZerStatus As Sensor_MB_Class.Zero_Status
        Dim SinglePointCalibrationSatus As Sensor_MB_Class.SinglePointCalibration_Status
        Dim TwoPointCalibrationStatus As Sensor_MB_Class.TwoPointCalibration_Status
        Dim BenchOperationWarning As Sensor_MB_Class.BenchOperational_Warnings
        Dim ADConverterChannels As Sensor_MB_Class.ADConverter_Channels
        Dim strResult As String
        Dim strResults() As String
        If cmbPuertoMicroBench.SelectedIndex < 0 Then
            MsgBox("Seleccione Pueto")
            Return
        End If
        strResult = Sensor_MB.Comando_MB_GetStatus(OverAllStatus, ZerStatus, SinglePointCalibrationSatus, TwoPointCalibrationStatus, BenchOperationWarning, ADConverterChannels)
        strResults = strResult.Split(",")
        txtConsola.AppendText("GET STATUS  " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then

            txtConsola.AppendText("OverAll Status->" + vbCrLf)
            txtConsola.AppendText("warm Up In Progress=" + OverAllStatus.warmUpInProgress.ToString + vbCrLf)
            txtConsola.AppendText("Zero Needed=" + OverAllStatus.ZeroNeeded.ToString + vbCrLf)
            txtConsola.AppendText("New O2 Transducer Installed=" + OverAllStatus.NewO2TransducerInstalled.ToString + vbCrLf)
            txtConsola.AppendText("Cal/Zero Warning=" + OverAllStatus.Cal_ZreoWarning.ToString + vbCrLf)
            txtConsola.AppendText("Bad O2 Trasnducer=" + OverAllStatus.BadO2Trasnducer.ToString + vbCrLf)
            txtConsola.AppendText("Condesation Warning=" + OverAllStatus.CondesationWarning.ToString + vbCrLf)
            txtConsola.AppendText("A/D Channel Is Railed=" + OverAllStatus.ADChannelIsRailed.ToString + vbCrLf)
            txtConsola.AppendText("Bench Internal Warning=" + OverAllStatus.BenchInternalWarning.ToString + vbCrLf)


            txtConsola.AppendText(vbCrLf + "Zero Status->" + vbCrLf)
            txtConsola.AppendText("HC_Warning=" + ZerStatus.HC_Warning.ToString + vbCrLf)
            txtConsola.AppendText("CO_Warning=" + ZerStatus.CO_Warning.ToString + vbCrLf)
            txtConsola.AppendText("CO2_Warning=" + ZerStatus.CO2_Warning.ToString + vbCrLf)
            txtConsola.AppendText("HiHC_Warning=" + ZerStatus.HiHC_Warning.ToString + vbCrLf)
            txtConsola.AppendText("O2_Warning=" + ZerStatus.O2_Warning.ToString + vbCrLf)
            txtConsola.AppendText("NOX_Warning=" + ZerStatus.NOX_Warning.ToString + vbCrLf)
            txtConsola.AppendText("RPM_Warning=" + ZerStatus.RPM_Warning.ToString + vbCrLf)


            txtConsola.AppendText(vbCrLf + "Single Point Calibration Satus->" + vbCrLf)
            txtConsola.AppendText("HC_Calibration Warning =" + SinglePointCalibrationSatus.HC_Cal.ToString + vbCrLf)
            txtConsola.AppendText("CO_Calibration Warning =" + SinglePointCalibrationSatus.CO_Cal.ToString + vbCrLf)
            txtConsola.AppendText("CO2_Calibration Warning =" + SinglePointCalibrationSatus.CO2_Cal.ToString + vbCrLf)
            txtConsola.AppendText("HiHC_Calibration Warning =" + SinglePointCalibrationSatus.HiHC_Cal.ToString + vbCrLf)
            txtConsola.AppendText("O2_Calibration Warning =" + SinglePointCalibrationSatus.O2_Cal.ToString + vbCrLf)
            txtConsola.AppendText("NOx_Calibration Warning =" + SinglePointCalibrationSatus.NOX_Cal.ToString + vbCrLf)
            txtConsola.AppendText("RPM_Calibration Warning =" + SinglePointCalibrationSatus.RPM_Cal.ToString + vbCrLf)
            txtConsola.AppendText("PRESS_Calibration Warning =" + SinglePointCalibrationSatus.PRESS_Cal.ToString + vbCrLf)

            txtConsola.AppendText(vbCrLf + "Two Point Calibration Satus->" + vbCrLf)
            txtConsola.AppendText("HC_Calibration Warning =" + TwoPointCalibrationStatus.HC_Cal.ToString + vbCrLf)
            txtConsola.AppendText("CO_Calibration Warning =" + TwoPointCalibrationStatus.CO_Cal.ToString + vbCrLf)
            txtConsola.AppendText("CO2_Calibration Warning =" + TwoPointCalibrationStatus.CO2_Cal.ToString + vbCrLf)

            txtConsola.AppendText(vbCrLf + "Bench Operation Warning->" + vbCrLf)
            txtConsola.AppendText("BlockHeater Warning =" + BenchOperationWarning.BlockHeater.ToString + vbCrLf)
            txtConsola.AppendText("O2 Offset Voltage Warning=" + BenchOperationWarning.O2OffsetVoltage_Warning.ToString + vbCrLf)
            txtConsola.AppendText("NOX Offset Voltage Out of Range=" + BenchOperationWarning.NOXOffsetVoltage_OutRange.ToString + vbCrLf)
            txtConsola.AppendText("NDIR Beam Strength Warning=" + BenchOperationWarning.NDIRBeamStrength_Warning.ToString + vbCrLf)
            txtConsola.AppendText("Incompatible EEPROM=" + BenchOperationWarning.IncompatibleEEPROM.ToString + vbCrLf)

            txtConsola.AppendText(vbCrLf + "A/D Converter Channels->" + vbCrLf)
            txtConsola.AppendText("HC_Channel_railed=" + ADConverterChannels.HC_Channel_railed.ToString + vbCrLf)
            txtConsola.AppendText("CO_Channel_railed=" + ADConverterChannels.CO_Channel_railed.ToString + vbCrLf)
            txtConsola.AppendText("CO2_Channel_railed=" + ADConverterChannels.CO2_Channel_railed.ToString + vbCrLf)
            txtConsola.AppendText("O2_Channel_railed=" + ADConverterChannels.O2_Channel_railed.ToString + vbCrLf)
            txtConsola.AppendText("NOX_Channel_railed=" + ADConverterChannels.NOX_Channel_railed.ToString + vbCrLf)
            txtConsola.AppendText("RPM_Channel_railed=" + ADConverterChannels.RPM_Channel_railed.ToString + vbCrLf)
            txtConsola.AppendText("OIL_Channel_railed=" + ADConverterChannels.OIL_Channel_railed.ToString + vbCrLf)
            txtConsola.AppendText("TEMP_Channel_railed=" + ADConverterChannels.TEMP_Channel_railed.ToString + vbCrLf)
            txtConsola.AppendText("PRESS_Channel_railed=" + ADConverterChannels.PRESS_Channel_railed.ToString + vbCrLf)
            txtConsola.AppendText("BLOCK_Channel_railed=" + ADConverterChannels.BlOCK_Channel_railed.ToString + vbCrLf)

        End If
    End Sub

    Private Sub btnWriteCalibration_Click(sender As Object, e As EventArgs) Handles btnWriteCalibration.Click
        Dim strResult As String
        Dim strResults() As String
        Dim CalibrationData As Sensor_MB_Class.Calibration_Data
        If cmbPuertoMicroBench.SelectedIndex < 0 Then
            MsgBox("Seleccione Pueto")
            Return
        End If
        'A continuacion se envia el comando Write Calibration para cada tipo de DataSet
        'Las constantes para identificar cada uno de los DataSet se llaman utilizando las constantes publicas 
        'de la clase  Sensor_MB_Class.DataSet_... 
        'Seleccione el Dataset adecuado segun la operacion que este realizando
        'escriba el valor a enviar para cada una de las variables en la estructura Sensor_MB_Class.Calibration_Data
        'las variables se deben convertir a un numero entero segun sea la resoucion de cada una (ver documentación del banco de gases)
        'Se recomienda leer primero las variables usando el comando Sensor_MB.Comando_MB_Read_Calibration 
        'el estado de la operacion se almacena en la estructura Sensor_MB_Class.Calibration_Datan en cada una de las banderas (flags)



        txtConsola.AppendText(vbCrLf + "WRITE CALIBRARION DATA" + vbCrLf)

        'ejemplo escribir calibration usando el  dataset 1
        CalibrationData.HC = 1500 'modificar el valor segun sea el caso para este gas
        CalibrationData.CO = 2120 'modificar el valor segun sea el caso para este gas
        CalibrationData.CO2 = 2020 'modificar el valor segun sea el caso para este gas
        CalibrationData.HiHc = 2020 'modificar el valor segun sea el caso para este gas

        strResult = Sensor_MB.Comando_MB_Write_Calibration(Sensor_MB.DataSet_SinglePont_Cal_HC_CO_CO2_HiHC, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText(vbCrLf + "DATA SET 1 " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("Mini Satus->" + vbCrLf)
            txtConsola.AppendText("HC Flag Out Range =" + CalibrationData.HC_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("CO Flag Out Range =" + CalibrationData.CO_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("CO2 Flag Out Range =" + CalibrationData.CO2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("O2 Flag Out Range =" + CalibrationData.O2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("NOX Flag Out Range =" + CalibrationData.NOX_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("New O2 Transd Installed =" + CalibrationData.New_O2_Transd_Installed.ToString + vbCrLf)
        End If


        'ejemplo escribir calibration usando el  dataset 2
        CalibrationData.O2 = 2100 'modificar el valor segun sea el caso para este gas
        strResult = Sensor_MB.Comando_MB_Write_Calibration(Sensor_MB.DataSet_SinglePont_Cal_O2, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText(vbCrLf + "DATA SET 2 " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("Mini Satus->" + vbCrLf)
            txtConsola.AppendText("HC Flag Out Range =" + CalibrationData.HC_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("COFlag Out Range =" + CalibrationData.CO_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("CO2 Flag Out Range =" + CalibrationData.CO2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("O2 Flag Out Range =" + CalibrationData.O2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("NOX Flag Out Range =" + CalibrationData.NOX_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("New O2 Transd Installed =" + CalibrationData.New_O2_Transd_Installed.ToString + vbCrLf)
        End If

        'ejemplo escribir calibration usando el  dataset 3
        CalibrationData.NOX = 2100 'modificar el valor segun sea el caso para este gas
        strResult = Sensor_MB.Comando_MB_Write_Calibration(Sensor_MB.DataSet_SinglePont_Cal_NOX, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText(vbCrLf + "DATA SET 3 " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("Mini Satus->" + vbCrLf)
            txtConsola.AppendText("HC Flag Out Range =" + CalibrationData.HC_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("COFlag Out Range =" + CalibrationData.CO_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("CO2 Flag Out Range =" + CalibrationData.CO2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("O2 Flag Out Range =" + CalibrationData.O2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("NOX Flag Out Range =" + CalibrationData.NOX_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("New O2 Transd Installed =" + CalibrationData.New_O2_Transd_Installed.ToString + vbCrLf)
        End If

        'ejemplo escribir calibration usando el  dataset 4
        CalibrationData.HC = 1500 'modificar el valor segun sea el caso para este gas
        CalibrationData.CO = 2120 'modificar el valor segun sea el caso para este gas
        CalibrationData.CO2 = 2020 'modificar el valor segun sea el caso para este gas
        CalibrationData.HiHc = 2020 'modificar el valor segun sea el caso para este gas
        CalibrationData.O2 = 2020 'modificar el valor segun sea el caso para este gas
        CalibrationData.NOX = 2020 'modificar el valor segun sea el caso para este gas
        strResult = Sensor_MB.Comando_MB_Write_Calibration(Sensor_MB.DataSet_SinglePont_Cal_HC_CO_CO2_HiHC_O2_NOX, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText(vbCrLf + "DATA SET 4 " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("Mini Satus->" + vbCrLf)
            txtConsola.AppendText("HC Flag Out Range =" + CalibrationData.HC_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("COFlag Out Range =" + CalibrationData.CO_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("CO2 Flag Out Range =" + CalibrationData.CO2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("O2 Flag Out Range =" + CalibrationData.O2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("NOX Flag Out Range =" + CalibrationData.NOX_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("New O2 Transd Installed =" + CalibrationData.New_O2_Transd_Installed.ToString + vbCrLf)
        End If


        'ejemplo escribir calibration usando el  dataset 11
        CalibrationData.HC = 1500 'modificar el valor segun sea el caso para este gas
        CalibrationData.CO = 2120 'modificar el valor segun sea el caso para este gas
        CalibrationData.CO2 = 2020 'modificar el valor segun sea el caso para este gas
        strResult = Sensor_MB.Comando_MB_Write_Calibration(Sensor_MB.DataSet_TwoPont_Cal_HC_CO_CO2_P1, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText(vbCrLf + "DATA SET 11 " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("Mini Satus->" + vbCrLf)
            txtConsola.AppendText("HC Flag Out Range =" + CalibrationData.HC_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("COFlag Out Range =" + CalibrationData.CO_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("CO2 Flag Out Range =" + CalibrationData.CO2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("O2 Flag Out Range =" + CalibrationData.O2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("NOX Flag Out Range =" + CalibrationData.NOX_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("New O2 Transd Installed =" + CalibrationData.New_O2_Transd_Installed.ToString + vbCrLf)
        End If

        'ejemplo escribir calibration usando el  dataset 21
        CalibrationData.HC_P2 = 1500 'modificar el valor segun sea el caso para este gas
        CalibrationData.CO_P2 = 2120 'modificar el valor segun sea el caso para este gas
        CalibrationData.CO2_P2 = 2020 'modificar el valor segun sea el caso para este gas
        strResult = Sensor_MB.Comando_MB_Write_Calibration(Sensor_MB.DataSet_TwoPont_Cal_HC_CO_CO2_P2, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText(vbCrLf + "DATA SET 21 " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("Mini Satus->" + vbCrLf)
            txtConsola.AppendText("HC Flag Out Range =" + CalibrationData.HC_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("COFlag Out Range =" + CalibrationData.CO_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("CO2 Flag Out Range =" + CalibrationData.CO2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("O2 Flag Out Range =" + CalibrationData.O2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("NOX Flag Out Range =" + CalibrationData.NOX_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("New O2 Transd Installed =" + CalibrationData.New_O2_Transd_Installed.ToString + vbCrLf)
        End If



        'ejemplo escribir calibration usando el  dataset 42
        CalibrationData.PEF = 2000 'modificar el valor segun sea el caso para el PEF seleccionado
        strResult = Sensor_MB.Comando_MB_Write_Calibration(Sensor_MB.DataSet_PEF, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText(vbCrLf + "DATA SET 42 " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("Mini Satus->" + vbCrLf)
            txtConsola.AppendText("HC Flag Out Range =" + CalibrationData.HC_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("COFlag Out Range =" + CalibrationData.CO_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("CO2 Flag Out Range =" + CalibrationData.CO2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("O2 Flag Out Range =" + CalibrationData.O2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("NOX Flag Out Range =" + CalibrationData.NOX_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("New O2 Transd Installed =" + CalibrationData.New_O2_Transd_Installed.ToString + vbCrLf)
        End If


        'ejemplo escribir calibration usando el  dataset 50
        CalibrationData.New_O2_Transducer_Flag = &H20 'indica que se instalo un nuevo tranducer
        strResult = Sensor_MB.Comando_MB_Write_Calibration(Sensor_MB.DataSet_PEF, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText(vbCrLf + "DATA SET 50 " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("Mini Satus->" + vbCrLf)
            txtConsola.AppendText("HC Flag Out Range =" + CalibrationData.HC_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("COFlag Out Range =" + CalibrationData.CO_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("CO2 Flag Out Range =" + CalibrationData.CO2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("O2 Flag Out Range =" + CalibrationData.O2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("NOX Flag Out Range =" + CalibrationData.NOX_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("New O2 Transd Installed =" + CalibrationData.New_O2_Transd_Installed.ToString + vbCrLf)
        End If

        'ejemplo escribir calibration usando el  dataset 51
        CalibrationData.Bad_O2_Threshold = 2700 'modificar el valor segun sea el caso para este gas
        strResult = Sensor_MB.Comando_MB_Write_Calibration(Sensor_MB.DataSet_PEF, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText(vbCrLf + "DATA SET 51 " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("Mini Satus->" + vbCrLf)
            txtConsola.AppendText("HC Flag Out Range =" + CalibrationData.HC_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("COFlag Out Range =" + CalibrationData.CO_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("CO2 Flag Out Range =" + CalibrationData.CO2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("O2 Flag Out Range =" + CalibrationData.O2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("NOX Flag Out Range =" + CalibrationData.NOX_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("New O2 Transd Installed =" + CalibrationData.New_O2_Transd_Installed.ToString + vbCrLf)
        End If

        'ejemplo escribir calibration usando el  dataset 52
        CalibrationData.High_O2_Threshold = 2300 'modificar el valor segun sea el caso para este gas
        strResult = Sensor_MB.Comando_MB_Write_Calibration(Sensor_MB.DataSet_PEF, CalibrationData)
        strResults = strResult.Split(",")
        txtConsola.AppendText(vbCrLf + "DATA SET 52 " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsola.AppendText("Mini Satus->" + vbCrLf)
            txtConsola.AppendText("HC Flag Out Range =" + CalibrationData.HC_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("COFlag Out Range =" + CalibrationData.CO_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("CO2 Flag Out Range =" + CalibrationData.CO2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("O2 Flag Out Range =" + CalibrationData.O2_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("NOX Flag Out Range =" + CalibrationData.NOX_Flag_Out_Range.ToString + vbCrLf)
            txtConsola.AppendText("New O2 Transd Installed =" + CalibrationData.New_O2_Transd_Installed.ToString + vbCrLf)
        End If
    End Sub

    Private Sub btnRead_IO_Click(sender As Object, e As EventArgs) Handles btnRead_IO.Click
        Dim strResult As String
        Dim strResults() As String
        Dim IO_Port As Sensor_MB_Class.I_O_Port

        If cmbPuertoMicroBench.SelectedIndex < 0 Then
            MsgBox("Seleccione Pueto")
            Return
        End If
        'A continuacion se envia el comando Read IO Port para cada uno de los modos (ver documentación del banco de gases)
        'Las constantes para identificar cada uno de los modo se llaman utilizando las constantes publicas de la clase  Sensor_MB_Class.IO_Mode_... 
        'Seleccione el Mode adecuado segun la operacion que este realizando
        'el estado de la operacion se almacena en la estructura Sensor_MB_Class.I_O_Port en cada una de las banderas (flags)
        chkCalSol1.Checked = False
        chkCalSol2.Checked = False
        chkSol1.Checked = False
        chkSol2.Checked = False
        chkPump.Checked = False
        chkDrainPmp.Checked = False
        chkOUT1.Checked = False
        chkOUT2.Checked = False
        chkOUT3.Checked = False
        chkOUT4.Checked = False
        chkOUT5.Checked = False
        chkOUT6.Checked = False
        chkOUT7.Checked = False
        chkOUT8.Checked = False

        chkIN1.Checked = False
        chkIN2.Checked = False
        chkIN3.Checked = False
        chkIN4.Checked = False
        chkIN5.Checked = False
        chkIN6.Checked = False
        chkIN7.Checked = False
        chkIN8.Checked = False

        txtConsola.AppendText(vbCrLf + "READ IO PORT" + vbCrLf)

        'leer solenoid Map
        strResult = Sensor_MB.Comando_MB_Read_I_O(Sensor_MB.IO_Mode_Solenoid_Map, IO_Port)
        strResults = strResult.Split(",")
        txtConsola.AppendText(vbCrLf + "Solenoid Map " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then

            chkCalSol1.Checked = IO_Port.Cal_Sol_1
            chkCalSol2.Checked = IO_Port.Cal_Sol_2
            chkSol1.Checked = IO_Port.Sol_1
            chkSol2.Checked = IO_Port.Sol_2
            chkPump.Checked = IO_Port.Pump
            chkDrainPmp.Checked = IO_Port.Drain_Pump

            txtConsola.AppendText("Cal Sol 1 =" + IO_Port.Cal_Sol_1.ToString + vbCrLf)
            txtConsola.AppendText("Cal Sol 2 =" + IO_Port.Cal_Sol_2.ToString + vbCrLf)
            txtConsola.AppendText("Sol 1 =" + IO_Port.Sol_1.ToString + vbCrLf)
            txtConsola.AppendText("Sol 2 =" + IO_Port.Sol_2.ToString + vbCrLf)
            txtConsola.AppendText("Pump =" + IO_Port.Pump.ToString + vbCrLf)
            txtConsola.AppendText("Drain Pump =" + IO_Port.Drain_Pump.ToString + vbCrLf)
        End If

        'A contonuacion se enivian los demas modos (Codigo Comentado), sin embargo con el comando anterior se obtiene el mapa completo.


        ''leer Cal Sol 1
        'strResult = Sensor_MB.Comando_MB_Read_I_O(Sensor_MB.IO_Mode_Cal_Sol1, IO_Port)
        'strResults = strResult.Split(",")
        'txtConsolaMicroBench.AppendText(vbCrLf + "Cal Sol1  " + strResults(1) + vbCrLf)
        'If strResults(0) = "1" Then
        '    txtConsolaMicroBench.AppendText("Cal Sol 1 =" + IO_Port.Cal_Sol_1.ToString + vbCrLf)
        'End If

        ''leer Cal Sol 2
        'strResult = Sensor_MB.Comando_MB_Read_I_O(Sensor_MB.IO_Mode_Cal_Sol2, IO_Port)
        'strResults = strResult.Split(",")
        'txtConsolaMicroBench.AppendText(vbCrLf + "Cal Sol2  " + strResults(1) + vbCrLf)
        'If strResults(0) = "1" Then
        '    txtConsolaMicroBench.AppendText("Cal Sol 2 =" + IO_Port.Cal_Sol_2.ToString + vbCrLf)
        'End If

        ''leer Sol 1
        'strResult = Sensor_MB.Comando_MB_Read_I_O(Sensor_MB.IO_Mode_Sol1, IO_Port)
        'strResults = strResult.Split(",")
        'txtConsolaMicroBench.AppendText(vbCrLf + "Sol1  " + strResults(1) + vbCrLf)
        'If strResults(0) = "1" Then
        '    txtConsolaMicroBench.AppendText("Sol 1 =" + IO_Port.Sol_1.ToString + vbCrLf)
        'End If

        ''leer Sol 2
        'strResult = Sensor_MB.Comando_MB_Read_I_O(Sensor_MB.IO_Mode_Sol2, IO_Port)
        'strResults = strResult.Split(",")
        'txtConsolaMicroBench.AppendText(vbCrLf + "Sol2  " + strResults(1) + vbCrLf)
        'If strResults(0) = "1" Then
        '    txtConsolaMicroBench.AppendText("Sol 2 =" + IO_Port.Sol_2.ToString + vbCrLf)
        'End If

        ''leer Pump
        'strResult = Sensor_MB.Comando_MB_Read_I_O(Sensor_MB.IO_Mode_Pump, IO_Port)
        'strResults = strResult.Split(",")
        'txtConsolaMicroBench.AppendText(vbCrLf + "Pump  " + strResults(1) + vbCrLf)
        'If strResults(0) = "1" Then
        '    txtConsolaMicroBench.AppendText("Pump =" + IO_Port.Pump.ToString + vbCrLf)
        'End If

        ''leer Drain Pump
        'strResult = Sensor_MB.Comando_MB_Read_I_O(Sensor_MB.IO_Mode_Drain_Pump, IO_Port)
        'strResults = strResult.Split(",")
        'txtConsolaMicroBench.AppendText(vbCrLf + "Drain Pump " + strResults(1) + vbCrLf)
        'If strResults(0) = "1" Then
        '    txtConsolaMicroBench.AppendText("Drain Pump =" + IO_Port.Drain_Pump.ToString + vbCrLf)
        'End If

        ''leer low flow sensor
        'strResult = Sensor_MB.Comando_MB_Read_I_O(Sensor_MB.IO_Mode_Low_Flow, IO_Port)
        'strResults = strResult.Split(",")
        'txtConsolaMicroBench.AppendText(vbCrLf + "Low Flow " + strResults(1) + vbCrLf)
        'If strResults(0) = "1" Then
        '    txtConsolaMicroBench.AppendText("Low Flow =" + IO_Port.Low_Flow.ToString + vbCrLf)
        'End If

        'leer puerto fisico 
        strResult = Sensor_MB.Comando_MB_Read_I_O(Sensor_MB.IO_Mode_Physical_IO_Map, IO_Port)
        strResults = strResult.Split(",")
        txtConsola.AppendText(vbCrLf + "Physical IO Map " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            'Output port
            chkOUT1.Checked = IO_Port.Physical_IO_Map_Sample_Output.Pin1
            chkOUT2.Checked = IO_Port.Physical_IO_Map_Sample_Output.Pin2
            chkOUT3.Checked = IO_Port.Physical_IO_Map_Sample_Output.Pin3
            chkOUT4.Checked = IO_Port.Physical_IO_Map_Sample_Output.Pin4
            chkOUT5.Checked = IO_Port.Physical_IO_Map_Sample_Output.Pin5
            chkOUT6.Checked = IO_Port.Physical_IO_Map_Sample_Output.Pin6
            chkOUT7.Checked = IO_Port.Physical_IO_Map_Sample_Output.Pin7
            chkOUT8.Checked = IO_Port.Physical_IO_Map_Sample_Output.Pin8

            txtConsola.AppendText("Output port" + vbCrLf)
            txtConsola.AppendText("Pin1 =" + IO_Port.Physical_IO_Map_Sample_Output.Pin1.ToString + vbCrLf)
            txtConsola.AppendText("Pin2 =" + IO_Port.Physical_IO_Map_Sample_Output.Pin2.ToString + vbCrLf)
            txtConsola.AppendText("Pin3 =" + IO_Port.Physical_IO_Map_Sample_Output.Pin3.ToString + vbCrLf)
            txtConsola.AppendText("Pin4 =" + IO_Port.Physical_IO_Map_Sample_Output.Pin4.ToString + vbCrLf)
            txtConsola.AppendText("Pin5 =" + IO_Port.Physical_IO_Map_Sample_Output.Pin5.ToString + vbCrLf)
            txtConsola.AppendText("Pin6 =" + IO_Port.Physical_IO_Map_Sample_Output.Pin6.ToString + vbCrLf)
            txtConsola.AppendText("Pin7 =" + IO_Port.Physical_IO_Map_Sample_Output.Pin7.ToString + vbCrLf)
            txtConsola.AppendText("Pin8 =" + IO_Port.Physical_IO_Map_Sample_Output.Pin8.ToString + vbCrLf)

            'Input port
            chkIN1.Checked = IO_Port.Physical_IO_Map_Sample_Input.Pin1
            chkIN2.Checked = IO_Port.Physical_IO_Map_Sample_Input.Pin2
            chkIN3.Checked = IO_Port.Physical_IO_Map_Sample_Input.Pin3
            chkIN4.Checked = IO_Port.Physical_IO_Map_Sample_Input.Pin4
            chkIN5.Checked = IO_Port.Physical_IO_Map_Sample_Input.Pin5
            chkIN6.Checked = IO_Port.Physical_IO_Map_Sample_Input.Pin6
            chkIN7.Checked = IO_Port.Physical_IO_Map_Sample_Input.Pin7
            chkIN8.Checked = IO_Port.Physical_IO_Map_Sample_Input.Pin8

            txtConsola.AppendText("Input port" + vbCrLf)
            txtConsola.AppendText("Pin1 =" + IO_Port.Physical_IO_Map_Sample_Input.Pin1.ToString + vbCrLf)
            txtConsola.AppendText("Pin2 =" + IO_Port.Physical_IO_Map_Sample_Input.Pin2.ToString + vbCrLf)
            txtConsola.AppendText("Pin3 =" + IO_Port.Physical_IO_Map_Sample_Input.Pin3.ToString + vbCrLf)
            txtConsola.AppendText("Pin4 =" + IO_Port.Physical_IO_Map_Sample_Input.Pin4.ToString + vbCrLf)
            txtConsola.AppendText("Pin5 =" + IO_Port.Physical_IO_Map_Sample_Input.Pin5.ToString + vbCrLf)
            txtConsola.AppendText("Pin6 =" + IO_Port.Physical_IO_Map_Sample_Input.Pin6.ToString + vbCrLf)
            txtConsola.AppendText("Pin7 =" + IO_Port.Physical_IO_Map_Sample_Input.Pin7.ToString + vbCrLf)
            txtConsola.AppendText("Pin8 =" + IO_Port.Physical_IO_Map_Sample_Input.Pin8.ToString + vbCrLf)

        End If


    End Sub

    Private Sub btnWrite_IO_Click(sender As Object, e As EventArgs) Handles btnWrite_IO.Click
        Dim strResult As String
        Dim strResults() As String
        Dim IO_Port As Sensor_MB_Class.I_O_Port

        If cmbPuertoMicroBench.SelectedIndex < 0 Then
            MsgBox("Seleccione Pueto")
            Return
        End If
        'A continuacion se envia el comando Write IO Port para cada uno de los modos (ver documentación del banco de gases)
        'Las constantes para identificar cada uno de los modo se llaman utilizando las constantes publicas de la clase  Sensor_MB_Class.IO_Mode_... 
        'Seleccione el Mode adecuado segun la operacion que este realizando
        'Escriba la estrucutra IO_Port segun el estado deseado de cada uno de los pines y el modo que se vaya a utilizar



        txtConsola.AppendText(vbCrLf + "WRITE IO PORT" + vbCrLf)

        'escribir solenoid Map si desea encender alguno de los perifericos ponga el valor en true
        IO_Port.Cal_Sol_1 = chkCalSol1.Checked 'true inidca que el pin se pone en 1, enciende cal sol 1 
        IO_Port.Cal_Sol_2 = chkCalSol2.Checked 'False inidca que el pin se pone en 0, apa
        IO_Port.Sol_1 = chkSol1.Checked
        IO_Port.Sol_2 = chkSol2.Checked
        IO_Port.Pump = chkPump.Checked
        IO_Port.Drain_Pump = chkDrainPmp.Checked

        strResult = Sensor_MB.Comando_MB_Write_I_O(Sensor_MB.IO_Mode_Solenoid_Map, IO_Port)
        strResults = strResult.Split(",")
        txtConsola.AppendText(vbCrLf + "Solenoid Map ->  " + strResults(1) + vbCrLf)


        ''escribir cal sol 1 desea encender alguno de los perifericos ponga el valor en true
        'IO_Port.Cal_Sol_1 = True 'true inidca que el pin se pone en 1, enciende cal sol 1 
        'strResult = Sensor_MB.Comando_MB_Write_I_O(Sensor_MB.IO_Mode_Cal_Sol1, IO_Port)
        'strResults = strResult.Split(",")
        'txtConsolaMicroBench.AppendText(vbCrLf + "cal_sol1 ->  " + strResults(1) + vbCrLf)

        ''escribir cal sol 2 desea encender alguno de los perifericos ponga el valor en true
        'IO_Port.Cal_Sol_2 = True 'true inidca que el pin se pone en 1, enciende cal sol 2
        'strResult = Sensor_MB.Comando_MB_Write_I_O(Sensor_MB.IO_Mode_Cal_Sol2, IO_Port)
        'strResults = strResult.Split(",")
        'txtConsolaMicroBench.AppendText(vbCrLf + "cal_sol2 ->  " + strResults(1) + vbCrLf)

        ''Realice la misma operacion anterior para escribir los demas perofericos PUMP y Drain Pump


        'escribir Physical port, si desea encender alguno de los pines ponga el valor en true
        If chkHabilitarSOUT.Checked Then
            IO_Port.Physical_IO_Map_Sample_Output.Pin1 = chkOUT1.Checked 'true inidca que el pin se pone en 1, enciende el Pin 1 del puerto
            IO_Port.Physical_IO_Map_Sample_Output.Pin2 = chkOUT2.Checked 'false inidca que el pin se pone en 0, apaga el Pin 2 del puerto
            IO_Port.Physical_IO_Map_Sample_Output.Pin3 = chkOUT3.Checked 'false inidca que el pin se pone en 0, apaga el Pin 3 del puerto
            IO_Port.Physical_IO_Map_Sample_Output.Pin4 = chkOUT4.Checked 'false inidca que el pin se pone en 0, apaga el Pin 4 del puerto
            IO_Port.Physical_IO_Map_Sample_Output.Pin5 = chkOUT5.Checked 'false inidca que el pin se pone en 0, apaga el Pin 5 del puerto
            IO_Port.Physical_IO_Map_Sample_Output.Pin6 = chkOUT6.Checked 'false inidca que el pin se pone en 0, apaga el Pin 6 del puerto
            IO_Port.Physical_IO_Map_Sample_Output.Pin7 = chkOUT7.Checked 'false inidca que el pin se pone en 0, apaga el Pin 7 del puerto
            IO_Port.Physical_IO_Map_Sample_Output.Pin8 = chkOUT8.Checked 'false inidca que el pin se pone en 0, apaga el Pin 8 del puerto

            strResult = Sensor_MB.Comando_MB_Write_I_O(Sensor_MB.IO_Mode_Physical_IO_Map, IO_Port)
            strResults = strResult.Split(",")
            txtConsola.AppendText(vbCrLf + "Solenoid Map ->  " + strResults(1) + vbCrLf)

        End If


    End Sub

    Private Sub cmbPuertoMicroBench_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPuertoMicroBench.SelectedIndexChanged
        Sensor_MB = New Sensor_MB_Class(cmbPuertoMicroBench.SelectedItem)
        Sensor_MB._continue = True

    End Sub

    Private Sub btnCalibrateRPM_Click(sender As Object, e As EventArgs) Handles btnCalibrateRPM.Click
        Dim strResult As String
        Dim strResults() As String
        Dim RPM_Status As Sensor_MB_Class.Calibrate_RPM_Status
        Dim RPM As UShort

        If cmbPuertoMicroBench.SelectedIndex < 0 Then
            MsgBox("Seleccione Pueto")
            Return
        End If
        If IsNumeric(txtRPM.Text) Then

            RPM = CUShort(txtRPM.Text)
            strResult = Sensor_MB.Comando_MB_Calibrate_RPM(RPM, RPM_Status)
            strResults = strResult.Split(",")
            txtConsola.AppendText(vbCrLf + "CALIBRATE RPM " + strResults(1) + vbCrLf)
            If strResults(0) = "1" Then
                txtConsola.AppendText("Calibration_Successfull  " + RPM_Status.Calibration_Successfull.ToString + vbCrLf)
                txtConsola.AppendText("RPM_Zero_Required  " + RPM_Status.RPM_Zero_Required.ToString + vbCrLf)
                txtConsola.AppendText("No_RPM_KIT_Installed  " + RPM_Status.No_RPM_KIT_Installed.ToString + vbCrLf)
                txtConsola.AppendText("RPM_Calibration_Required  " + RPM_Status.RPM_Calibration_Required.ToString + vbCrLf)

            End If

        Else
            MsgBox("Ingrese un valor de RPM")
        End If
    End Sub

    Private Sub btnCalibratePress_Click(sender As Object, e As EventArgs) Handles btnCalibratePress.Click
        Try
            Dim strResult As String
            Dim strResults() As String
            Dim Press_Status As Sensor_MB_Class.Calibrate_Pressure_Status
            Dim Press As UShort

            If cmbPuertoMicroBench.SelectedIndex < 0 Then
                MsgBox("Seleccione Pueto")
                Return
            End If

            If IsNumeric(txtCalPress.Text) And cmbCalibrationMode.SelectedIndex <> -1 Then

                Press = CUShort(txtRPM.Text)
                strResult = Sensor_MB.Comando_MB_Calibrate_Pressure(cmbCalibrationMode.SelectedIndex, Press, rdbCalPressmbar.Checked, Press_Status)
                strResults = strResult.Split(",")
                txtConsola.AppendText(vbCrLf + "CALIBRATE PRESSURE " + strResults(1) + vbCrLf)
                If strResults(0) = "1" Then
                    txtConsola.AppendText("No_Pressure_transducer= " + Press_Status.No_Pressure_transducer.ToString + vbCrLf)
                    txtConsola.AppendText("AD_Railed= " + Press_Status.AD_Railed.ToString + vbCrLf)
                    txtConsola.AppendText("Pressure_Cal1_Equal_Pressure_Cal2= " + Press_Status.Pressure_Cal1_Equal_Pressure_Cal2.ToString + vbCrLf)
                    txtConsola.AppendText("Reading_Cal1_Equal_Reading_Cal2= " + Press_Status.Reading_Cal1_Equal_Reading_Cal2.ToString + vbCrLf)
                    txtConsola.AppendText("Reading_Out_Range= " + Press_Status.Reading_Out_Range.ToString + vbCrLf)

                End If

            Else
                MsgBox("Ingrese un valor de presion y seleccione el modo")
            End If
        Catch ex As Exception
            txtConsola.AppendText(vbCrLf + "CALIBRATE PRESSURE " + ex.Message + vbCrLf)
        End Try

    End Sub

    Private Sub btnLimpiarConsola_Click(sender As Object, e As EventArgs) Handles btnLimpiarConsola.Click
        txtConsola.Text = ""
    End Sub

    Private Sub cmbPuetoOpacimetro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPuertoOpacimetro.SelectedIndexChanged
        Opacimetro = New Opacimetro_CAP3030_Class(cmbPuertoOpacimetro.SelectedItem)
        Opacimetro._continue = True
    End Sub

    Private Sub btnOpacGetVersion_Click(sender As Object, e As EventArgs) Handles btnOpacGetVersion.Click
        Dim version As UShort
        Dim serialnum As UShort

        If cmbPuertoOpacimetro.SelectedIndex < 0 Then
            MsgBox("Seleccione Pueto")
            Return
        End If

        Opacimetro.Comando_getVersion(version, serialnum)
    End Sub
End Class