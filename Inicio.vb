Imports System.ComponentModel
Imports System.IO.Ports
Imports System.Threading
Imports System.Windows.Forms

Public Class frmFuentesMoviles

  
    Public Shared frmIncio As New frmFuentesMoviles
    Public Shared Sensor_MB As Sensor_MB_Class



    Public Shared Sub Main()


        Sensor_MB = New Sensor_MB_Class("COM10")
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
            strResult = Sensor_MB.Comando_MB_Calibration(cmbCalibrationMode.SelectedIndex, cmbCalibrationGas.SelectedIndex)
            strResults = strResult.Split(",")
            txtConsolaMicroBench.AppendText(strResults(1) + vbCrLf)
        Else
            MsgBox("Seleccione Modo y Gas", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        Dim strResult As String
        Dim strResults() As String

        strResult = Sensor_MB.Comando_MB_GetData(Sensor_MB.Report_Gas_Data_in_Concentration,
                                                 Sensor_MB.Pressure_in_mbar,
                                                 Sensor_MB.Temp_in_C,
                                                 Sensor_MB.HC_Range_0_20000_ppmHex,
                                                 Sensor_MB.High_Resolution_O2,
                                                 Sensor_MB.RPM_in_2_cycle,
                                                 Sensor_MB.Normal_Ignition,
                                                 Sensor_MB.Pressure_Resolution_High,
                                                 Sensor_MB.HC_AS_ppm_Hexane,
                                                 Sensor_MB.Oil_Temp_as_C, Sensor_MB.RPM_as_1_Min)
        strResult = Sensor_MB.Comando_MB_GetStatus()


        strResult = Sensor_MB.Comando_MB_Calibration(0, 0)
        strResults = strResult.Split(",")
        txtConsolaMicroBench.AppendText(strResults(1) + vbCrLf)

    End Sub

    Private Sub btnEscanear_Click(sender As Object, e As EventArgs) Handles btnEscanear.Click

    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

    End Sub
End Class