Imports System.ComponentModel
Imports System.IO.Ports
Imports System.Threading
Imports System.Windows.Forms

Public Class frmFuentesMoviles

  
    Public Shared frmIncio As New frmFuentesMoviles
    Public Shared Sensor_MB As Sensor_MB_Class



    Public Shared Sub Main()


        Sensor_MB = New Sensor_MB_Class("COM8")
        Sensor_MB._continue = True
        frmIncio.ShowDialog()




    End Sub


    Private Sub Inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_continue = True
        'readThread.Start() 'Inicia Thread de recepcion
    End Sub

    Private Sub Inicio_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            Sensor_MB._continue = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGetVersion_Click(sender As Object, e As EventArgs) Handles btnGetVersion.Click
        Dim strResult As String
        Dim strResults() As String


        strResult = Sensor_MB.Comando_MB_GetVersionSoftware()
        strResults = strResult.Split(",")

        If strResults(0) = "1" Then
            txtConsolaMicroBench.AppendText("Version Software: " + strResults(1) + vbCrLf)
        Else
            txtConsolaMicroBench.AppendText("Version Software ERROR: " + strResults(1) + vbCrLf)
        End If


        strResult = Sensor_MB.Comando_MB_GetVersionHardware()
        strResults = strResult.Split(",")
        If strResults(0) = "1" Then
            txtConsolaMicroBench.AppendText("Version Hardware: " + strResults(1) + vbCrLf)
        Else
            txtConsolaMicroBench.AppendText("Version Hardware ERROR: " + strResults(1) + vbCrLf)
        End If

    End Sub

    Private Sub btnCalibration_Click(sender As Object, e As EventArgs) Handles btnCalibration.Click

        Dim strResult As String
        Dim strResults() As String

        If (cmbCalibrationGas.SelectedIndex <> -1) And (cmbCalibrationMode.SelectedIndex <> -1) Then
            strResult = Sensor_MB.Comando_MB_Calibration(cmbCalibrationMode.SelectedIndex,
                                                         chkHC.Checked,
                                                         chkCO.Checked,
                                                         chkCO2.Checked,
                                                         chkO2.Checked,
                                                         chkNOx.Checked,
                                                         chkHiHC.Checked)
            strResults = strResult.Split(",")

            txtConsolaMicroBench.AppendText(strResults(1) + vbCrLf)
        Else
            MsgBox("Seleccione Modo y Gas", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        Dim strResult As String
        Dim strResults() As String
        Dim CalibrationData As Sensor_MB_Class.Calibration_Data
        Dim GetDataResults As Sensor_MB_Class.GetData_Results
        Dim OverAllStatus As Sensor_MB_Class.Overall_Status
        Dim ZerStatus As Sensor_MB_Class.Zero_Status
        Dim SinglePointCalibrationSatus As Sensor_MB_Class.SinglePointCalibration_Status
        Dim TwoPointCalibrationStatus As Sensor_MB_Class.TwoPointCalibration_Status
        Dim BenchOperationWarning As Sensor_MB_Class.BenchOperational_Warnings
        Dim ADConverterChannels As Sensor_MB_Class.ADConverter_Channels
        Dim GasSelection As UInteger




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
        rdbO2ResLow.Checked,
        rdbRPM2.Checked,
        rdbIgnitionNormal.Checked,
        rdbPressResLow.Checked,
        rdbHCHexane.Checked,
        rdbOiltempC.Checked,
        rdbRPM1_min.Checked,
        GetDataResults)

        strResults = strResult.Split(",")
        txtConsolaMicroBench.AppendText("GET DATA " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            'las unidades y los puntos decimales dependen de la seleccion de realizada .
            'para efectos de ejemplo se presentan los valores tal cual son enviados por el banco de gases
            txtConsolaMicroBench.AppendText("HC=" + GetDataResults.HC.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("CO=" + GetDataResults.CO.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("CO2=" + GetDataResults.CO2.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("O2=" + GetDataResults.O2.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("NOX=" + GetDataResults.NOX.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("RPM=" + GetDataResults.RPM.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("OilTemp=" + GetDataResults.OilTemp.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("AmbientTemp=" + GetDataResults.AmbientTemp.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("Pressure=" + GetDataResults.Pressure.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("lowFlow=" + GetDataResults.lowFlow.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("FilterBowlFull=" + GetDataResults.FilterBowlFull.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("Alarm=" + GetDataResults.Alarm.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("DataMayNotBeAccurate=" + GetDataResults.DataMayNotBeAccurate.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("ZERO_recommended=" + GetDataResults.ZERO_recommended.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("HighHC_Range=" + GetDataResults.HighHC_Range.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("CondensationWarning=" + GetDataResults.CondensationWarning.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("HC_OutRange=" + GetDataResults.HC_OutRange.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("CO_OutRange=" + GetDataResults.CO_OutRange.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("CO2_OutRange=" + GetDataResults.CO2_OutRange.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("O2_OutRange=" + GetDataResults.O2_OutRange.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("NOX_OutRange=" + GetDataResults.NOX_OutRange.ToString + vbCrLf)
            txtConsolaMicroBench.AppendText("BenchInternalWarning=" + GetDataResults.BenchInternalWarning.ToString + vbCrLf)

        End If






        'CalibrationData.HC = 1500

        'strResult = Sensor_MB.Comando_MB_Write_Calibration(Sensor_MB.DataSet_SinglePont_Cal_HC_CO_CO2_HiHC, CalibrationData)

        'strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_SinglePont_Cal_HC_CO_CO2_HiHC_O2_NOX, 0)



        'strResult = Sensor_MB.Comando_MB_Calibration(0, 0, GetDataResults)


    End Sub

    Private Sub btnEscanear_Click(sender As Object, e As EventArgs) Handles btnEscanear.Click

    End Sub



    Private Sub btnReadCalibration_Click(sender As Object, e As EventArgs) Handles btnReadCalibration.Click
        Dim strResult As String
        Dim CalibrationData As Sensor_MB_Class.Calibration_Data

        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_SinglePont_Cal_HC_CO_CO2_HiHC, CalibrationData)
        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_SinglePont_Cal_O2, CalibrationData)
        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_SinglePont_Cal_NOX, CalibrationData)
        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_SinglePont_Cal_HC_CO_CO2_HiHC_O2_NOX, CalibrationData)
        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_TwolePont_Cal_HC_CO_CO2_P1, CalibrationData)
        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_TwolePont_Cal_HC_CO_CO2_P2, CalibrationData)
        CalibrationData.PEF = 2000
        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_PEF, CalibrationData)
        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_New_O2_Transducer_Installed, CalibrationData)
        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_Read_Bad_O2, CalibrationData)
        strResult = Sensor_MB.Comando_MB_Read_Calibration(Sensor_MB.DataSet_Read_High_O2, CalibrationData)


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

        strResult = Sensor_MB.Comando_MB_GetStatus(OverAllStatus, ZerStatus, SinglePointCalibrationSatus, TwoPointCalibrationStatus, BenchOperationWarning, ADConverterChannels)
        strResults = strResult.Split(",")
        txtConsolaMicroBench.AppendText("GET STATUS " + strResults(1) + vbCrLf)
        If strResults(0) = "1" Then
            txtConsolaMicroBench.AppendText("HC=" + GetDataResults.HC.ToString + vbCrLf)
        End If
    End Sub
End Class