﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFuentesMoviles
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.btnGetVersion = New System.Windows.Forms.Button()
        Me.txtConsola = New System.Windows.Forms.TextBox()
        Me.TabPrincipal = New System.Windows.Forms.TabControl()
        Me.TabPageMicroBench = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpComandoMB = New System.Windows.Forms.GroupBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.chkHabilitarSOUT = New System.Windows.Forms.CheckBox()
        Me.chkIN8 = New System.Windows.Forms.CheckBox()
        Me.btnRead_IO = New System.Windows.Forms.Button()
        Me.chkIN7 = New System.Windows.Forms.CheckBox()
        Me.chkIN6 = New System.Windows.Forms.CheckBox()
        Me.chkIN5 = New System.Windows.Forms.CheckBox()
        Me.chkIN4 = New System.Windows.Forms.CheckBox()
        Me.chkIN3 = New System.Windows.Forms.CheckBox()
        Me.chkIN2 = New System.Windows.Forms.CheckBox()
        Me.chkIN1 = New System.Windows.Forms.CheckBox()
        Me.chkOUT8 = New System.Windows.Forms.CheckBox()
        Me.chkOUT7 = New System.Windows.Forms.CheckBox()
        Me.chkOUT6 = New System.Windows.Forms.CheckBox()
        Me.chkOUT5 = New System.Windows.Forms.CheckBox()
        Me.chkOUT4 = New System.Windows.Forms.CheckBox()
        Me.chkOUT3 = New System.Windows.Forms.CheckBox()
        Me.chkOUT2 = New System.Windows.Forms.CheckBox()
        Me.chkOUT1 = New System.Windows.Forms.CheckBox()
        Me.chkDrainPmp = New System.Windows.Forms.CheckBox()
        Me.chkPump = New System.Windows.Forms.CheckBox()
        Me.chkSol2 = New System.Windows.Forms.CheckBox()
        Me.chkSol1 = New System.Windows.Forms.CheckBox()
        Me.chkCalSol2 = New System.Windows.Forms.CheckBox()
        Me.chkCalSol1 = New System.Windows.Forms.CheckBox()
        Me.btnWrite_IO = New System.Windows.Forms.Button()
        Me.btnWriteCalibration = New System.Windows.Forms.Button()
        Me.btnGetStatus = New System.Windows.Forms.Button()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.btnCalibration = New System.Windows.Forms.Button()
        Me.cmbCalibrationMode = New System.Windows.Forms.ComboBox()
        Me.chkHiHC = New System.Windows.Forms.CheckBox()
        Me.chkHC = New System.Windows.Forms.CheckBox()
        Me.chkNOx = New System.Windows.Forms.CheckBox()
        Me.chkCO = New System.Windows.Forms.CheckBox()
        Me.chkO2 = New System.Windows.Forms.CheckBox()
        Me.chkCO2 = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.rdbRPMmv = New System.Windows.Forms.RadioButton()
        Me.rdbRPM1_min = New System.Windows.Forms.RadioButton()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.rdbOiltempmV = New System.Windows.Forms.RadioButton()
        Me.rdbOiltempC = New System.Windows.Forms.RadioButton()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.rdbHCHPropane = New System.Windows.Forms.RadioButton()
        Me.rdbHCHexane = New System.Windows.Forms.RadioButton()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.rdbPressResHigh = New System.Windows.Forms.RadioButton()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.rdbIgnitionDual = New System.Windows.Forms.RadioButton()
        Me.rdbIgnitionNormal = New System.Windows.Forms.RadioButton()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.rdbRPM4 = New System.Windows.Forms.RadioButton()
        Me.rdbRPM2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rdbO2ResLow = New System.Windows.Forms.RadioButton()
        Me.rdbO2ResHigh = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rdbHC20000 = New System.Windows.Forms.RadioButton()
        Me.rdbHC2000 = New System.Windows.Forms.RadioButton()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdbTempF = New System.Windows.Forms.RadioButton()
        Me.rdbTempC = New System.Windows.Forms.RadioButton()
        Me.cmbGasDatain = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdbPressHg = New System.Windows.Forms.RadioButton()
        Me.rdbPressmbar = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnReadCalibration = New System.Windows.Forms.Button()
        Me.lblSerialMB = New System.Windows.Forms.Label()
        Me.cmbPuertoMicroBench = New System.Windows.Forms.ComboBox()
        Me.TabPageOpacimetro = New System.Windows.Forms.TabPage()
        Me.TabPageEncicla = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLogEncicla = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnEscanear = New System.Windows.Forms.Button()
        Me.tmrComunicacion = New System.Windows.Forms.Timer(Me.components)
        Me.btnCalibrateRPM = New System.Windows.Forms.Button()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.txtRPM = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.btnCalibratePress = New System.Windows.Forms.Button()
        Me.rdbCalPressHg = New System.Windows.Forms.RadioButton()
        Me.rdbCalPressmbar = New System.Windows.Forms.RadioButton()
        Me.cmbCalPressMode = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCalPress = New System.Windows.Forms.TextBox()
        Me.btnLimpiarConsola = New System.Windows.Forms.Button()
        Me.rdbPressResLow = New System.Windows.Forms.RadioButton()
        Me.btnOpacGetVersion = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbPuertoOpacimetro = New System.Windows.Forms.ComboBox()
        Me.TabPrincipal.SuspendLayout()
        Me.TabPageMicroBench.SuspendLayout()
        Me.grpComandoMB.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPageOpacimetro.SuspendLayout()
        Me.TabPageEncicla.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 115200
        Me.SerialPort1.PortName = "COM4"
        '
        'btnGetVersion
        '
        Me.btnGetVersion.Location = New System.Drawing.Point(41, 34)
        Me.btnGetVersion.Name = "btnGetVersion"
        Me.btnGetVersion.Size = New System.Drawing.Size(188, 84)
        Me.btnGetVersion.TabIndex = 0
        Me.btnGetVersion.Text = "Get Version"
        Me.btnGetVersion.UseVisualStyleBackColor = True
        '
        'txtConsola
        '
        Me.txtConsola.Location = New System.Drawing.Point(1793, 95)
        Me.txtConsola.Multiline = True
        Me.txtConsola.Name = "txtConsola"
        Me.txtConsola.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConsola.Size = New System.Drawing.Size(1180, 1316)
        Me.txtConsola.TabIndex = 3
        '
        'TabPrincipal
        '
        Me.TabPrincipal.Controls.Add(Me.TabPageMicroBench)
        Me.TabPrincipal.Controls.Add(Me.TabPageOpacimetro)
        Me.TabPrincipal.Controls.Add(Me.TabPageEncicla)
        Me.TabPrincipal.Location = New System.Drawing.Point(0, 48)
        Me.TabPrincipal.Name = "TabPrincipal"
        Me.TabPrincipal.SelectedIndex = 0
        Me.TabPrincipal.Size = New System.Drawing.Size(1787, 1373)
        Me.TabPrincipal.TabIndex = 6
        '
        'TabPageMicroBench
        '
        Me.TabPageMicroBench.Controls.Add(Me.grpComandoMB)
        Me.TabPageMicroBench.Controls.Add(Me.lblSerialMB)
        Me.TabPageMicroBench.Controls.Add(Me.cmbPuertoMicroBench)
        Me.TabPageMicroBench.Location = New System.Drawing.Point(10, 47)
        Me.TabPageMicroBench.Name = "TabPageMicroBench"
        Me.TabPageMicroBench.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageMicroBench.Size = New System.Drawing.Size(1767, 1316)
        Me.TabPageMicroBench.TabIndex = 0
        Me.TabPageMicroBench.Text = "Sensors Microbench"
        Me.TabPageMicroBench.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1793, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 29)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "LOG "
        '
        'grpComandoMB
        '
        Me.grpComandoMB.Controls.Add(Me.GroupBox15)
        Me.grpComandoMB.Controls.Add(Me.GroupBox14)
        Me.grpComandoMB.Controls.Add(Me.GroupBox13)
        Me.grpComandoMB.Controls.Add(Me.btnWriteCalibration)
        Me.grpComandoMB.Controls.Add(Me.btnGetStatus)
        Me.grpComandoMB.Controls.Add(Me.GroupBox12)
        Me.grpComandoMB.Controls.Add(Me.GroupBox3)
        Me.grpComandoMB.Controls.Add(Me.btnReadCalibration)
        Me.grpComandoMB.Controls.Add(Me.btnGetVersion)
        Me.grpComandoMB.Location = New System.Drawing.Point(22, 63)
        Me.grpComandoMB.Name = "grpComandoMB"
        Me.grpComandoMB.Size = New System.Drawing.Size(1718, 1168)
        Me.grpComandoMB.TabIndex = 6
        Me.grpComandoMB.TabStop = False
        Me.grpComandoMB.Text = "Comandos"
        '
        'GroupBox13
        '
        Me.GroupBox13.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox13.Controls.Add(Me.chkHabilitarSOUT)
        Me.GroupBox13.Controls.Add(Me.chkIN8)
        Me.GroupBox13.Controls.Add(Me.btnRead_IO)
        Me.GroupBox13.Controls.Add(Me.chkIN7)
        Me.GroupBox13.Controls.Add(Me.chkIN6)
        Me.GroupBox13.Controls.Add(Me.chkIN5)
        Me.GroupBox13.Controls.Add(Me.chkIN4)
        Me.GroupBox13.Controls.Add(Me.chkIN3)
        Me.GroupBox13.Controls.Add(Me.chkIN2)
        Me.GroupBox13.Controls.Add(Me.chkIN1)
        Me.GroupBox13.Controls.Add(Me.chkOUT8)
        Me.GroupBox13.Controls.Add(Me.chkOUT7)
        Me.GroupBox13.Controls.Add(Me.chkOUT6)
        Me.GroupBox13.Controls.Add(Me.chkOUT5)
        Me.GroupBox13.Controls.Add(Me.chkOUT4)
        Me.GroupBox13.Controls.Add(Me.chkOUT3)
        Me.GroupBox13.Controls.Add(Me.chkOUT2)
        Me.GroupBox13.Controls.Add(Me.chkOUT1)
        Me.GroupBox13.Controls.Add(Me.chkDrainPmp)
        Me.GroupBox13.Controls.Add(Me.chkPump)
        Me.GroupBox13.Controls.Add(Me.chkSol2)
        Me.GroupBox13.Controls.Add(Me.chkSol1)
        Me.GroupBox13.Controls.Add(Me.chkCalSol2)
        Me.GroupBox13.Controls.Add(Me.chkCalSol1)
        Me.GroupBox13.Controls.Add(Me.btnWrite_IO)
        Me.GroupBox13.Location = New System.Drawing.Point(966, 402)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(729, 474)
        Me.GroupBox13.TabIndex = 31
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "I/O"
        '
        'chkHabilitarSOUT
        '
        Me.chkHabilitarSOUT.AutoSize = True
        Me.chkHabilitarSOUT.Location = New System.Drawing.Point(27, 227)
        Me.chkHabilitarSOUT.Name = "chkHabilitarSOUT"
        Me.chkHabilitarSOUT.Size = New System.Drawing.Size(274, 33)
        Me.chkHabilitarSOUT.TabIndex = 53
        Me.chkHabilitarSOUT.Text = "Escribir Sample OUT"
        Me.chkHabilitarSOUT.UseVisualStyleBackColor = True
        '
        'chkIN8
        '
        Me.chkIN8.AutoSize = True
        Me.chkIN8.Location = New System.Drawing.Point(564, 410)
        Me.chkIN8.Name = "chkIN8"
        Me.chkIN8.Size = New System.Drawing.Size(88, 33)
        Me.chkIN8.TabIndex = 52
        Me.chkIN8.Text = "IN 8"
        Me.chkIN8.UseVisualStyleBackColor = True
        '
        'btnRead_IO
        '
        Me.btnRead_IO.Location = New System.Drawing.Point(27, 43)
        Me.btnRead_IO.Name = "btnRead_IO"
        Me.btnRead_IO.Size = New System.Drawing.Size(193, 84)
        Me.btnRead_IO.TabIndex = 29
        Me.btnRead_IO.Text = "Read I/O"
        Me.btnRead_IO.UseVisualStyleBackColor = True
        '
        'chkIN7
        '
        Me.chkIN7.AutoSize = True
        Me.chkIN7.Location = New System.Drawing.Point(564, 371)
        Me.chkIN7.Name = "chkIN7"
        Me.chkIN7.Size = New System.Drawing.Size(94, 33)
        Me.chkIN7.TabIndex = 51
        Me.chkIN7.Text = "IN  7"
        Me.chkIN7.UseVisualStyleBackColor = True
        '
        'chkIN6
        '
        Me.chkIN6.AutoSize = True
        Me.chkIN6.Location = New System.Drawing.Point(564, 330)
        Me.chkIN6.Name = "chkIN6"
        Me.chkIN6.Size = New System.Drawing.Size(88, 33)
        Me.chkIN6.TabIndex = 50
        Me.chkIN6.Text = "IN 6"
        Me.chkIN6.UseVisualStyleBackColor = True
        '
        'chkIN5
        '
        Me.chkIN5.AutoSize = True
        Me.chkIN5.Location = New System.Drawing.Point(564, 293)
        Me.chkIN5.Name = "chkIN5"
        Me.chkIN5.Size = New System.Drawing.Size(88, 33)
        Me.chkIN5.TabIndex = 49
        Me.chkIN5.Text = "IN 5"
        Me.chkIN5.UseVisualStyleBackColor = True
        '
        'chkIN4
        '
        Me.chkIN4.AutoSize = True
        Me.chkIN4.Location = New System.Drawing.Point(564, 254)
        Me.chkIN4.Name = "chkIN4"
        Me.chkIN4.Size = New System.Drawing.Size(88, 33)
        Me.chkIN4.TabIndex = 48
        Me.chkIN4.Text = "IN 4"
        Me.chkIN4.UseVisualStyleBackColor = True
        '
        'chkIN3
        '
        Me.chkIN3.AutoSize = True
        Me.chkIN3.Location = New System.Drawing.Point(564, 215)
        Me.chkIN3.Name = "chkIN3"
        Me.chkIN3.Size = New System.Drawing.Size(88, 33)
        Me.chkIN3.TabIndex = 47
        Me.chkIN3.Text = "IN 3"
        Me.chkIN3.UseVisualStyleBackColor = True
        '
        'chkIN2
        '
        Me.chkIN2.AutoSize = True
        Me.chkIN2.Location = New System.Drawing.Point(564, 176)
        Me.chkIN2.Name = "chkIN2"
        Me.chkIN2.Size = New System.Drawing.Size(88, 33)
        Me.chkIN2.TabIndex = 46
        Me.chkIN2.Text = "IN 2"
        Me.chkIN2.UseVisualStyleBackColor = True
        '
        'chkIN1
        '
        Me.chkIN1.AutoSize = True
        Me.chkIN1.Location = New System.Drawing.Point(564, 137)
        Me.chkIN1.Name = "chkIN1"
        Me.chkIN1.Size = New System.Drawing.Size(88, 33)
        Me.chkIN1.TabIndex = 45
        Me.chkIN1.Text = "IN 1"
        Me.chkIN1.UseVisualStyleBackColor = True
        '
        'chkOUT8
        '
        Me.chkOUT8.AutoSize = True
        Me.chkOUT8.Location = New System.Drawing.Point(405, 410)
        Me.chkOUT8.Name = "chkOUT8"
        Me.chkOUT8.Size = New System.Drawing.Size(116, 33)
        Me.chkOUT8.TabIndex = 44
        Me.chkOUT8.Text = "OUT 8"
        Me.chkOUT8.UseVisualStyleBackColor = True
        '
        'chkOUT7
        '
        Me.chkOUT7.AutoSize = True
        Me.chkOUT7.Location = New System.Drawing.Point(405, 371)
        Me.chkOUT7.Name = "chkOUT7"
        Me.chkOUT7.Size = New System.Drawing.Size(116, 33)
        Me.chkOUT7.TabIndex = 43
        Me.chkOUT7.Text = "OUT 7"
        Me.chkOUT7.UseVisualStyleBackColor = True
        '
        'chkOUT6
        '
        Me.chkOUT6.AutoSize = True
        Me.chkOUT6.Location = New System.Drawing.Point(405, 330)
        Me.chkOUT6.Name = "chkOUT6"
        Me.chkOUT6.Size = New System.Drawing.Size(116, 33)
        Me.chkOUT6.TabIndex = 42
        Me.chkOUT6.Text = "OUT 6"
        Me.chkOUT6.UseVisualStyleBackColor = True
        '
        'chkOUT5
        '
        Me.chkOUT5.AutoSize = True
        Me.chkOUT5.Location = New System.Drawing.Point(405, 293)
        Me.chkOUT5.Name = "chkOUT5"
        Me.chkOUT5.Size = New System.Drawing.Size(116, 33)
        Me.chkOUT5.TabIndex = 41
        Me.chkOUT5.Text = "OUT 5"
        Me.chkOUT5.UseVisualStyleBackColor = True
        '
        'chkOUT4
        '
        Me.chkOUT4.AutoSize = True
        Me.chkOUT4.Location = New System.Drawing.Point(405, 254)
        Me.chkOUT4.Name = "chkOUT4"
        Me.chkOUT4.Size = New System.Drawing.Size(116, 33)
        Me.chkOUT4.TabIndex = 40
        Me.chkOUT4.Text = "OUT 4"
        Me.chkOUT4.UseVisualStyleBackColor = True
        '
        'chkOUT3
        '
        Me.chkOUT3.AutoSize = True
        Me.chkOUT3.Location = New System.Drawing.Point(405, 215)
        Me.chkOUT3.Name = "chkOUT3"
        Me.chkOUT3.Size = New System.Drawing.Size(116, 33)
        Me.chkOUT3.TabIndex = 39
        Me.chkOUT3.Text = "OUT 3"
        Me.chkOUT3.UseVisualStyleBackColor = True
        '
        'chkOUT2
        '
        Me.chkOUT2.AutoSize = True
        Me.chkOUT2.Location = New System.Drawing.Point(405, 175)
        Me.chkOUT2.Name = "chkOUT2"
        Me.chkOUT2.Size = New System.Drawing.Size(116, 33)
        Me.chkOUT2.TabIndex = 38
        Me.chkOUT2.Text = "OUT 2"
        Me.chkOUT2.UseVisualStyleBackColor = True
        '
        'chkOUT1
        '
        Me.chkOUT1.AutoSize = True
        Me.chkOUT1.Location = New System.Drawing.Point(405, 137)
        Me.chkOUT1.Name = "chkOUT1"
        Me.chkOUT1.Size = New System.Drawing.Size(116, 33)
        Me.chkOUT1.TabIndex = 37
        Me.chkOUT1.Text = "OUT 1"
        Me.chkOUT1.UseVisualStyleBackColor = True
        '
        'chkDrainPmp
        '
        Me.chkDrainPmp.AutoSize = True
        Me.chkDrainPmp.Location = New System.Drawing.Point(511, 82)
        Me.chkDrainPmp.Name = "chkDrainPmp"
        Me.chkDrainPmp.Size = New System.Drawing.Size(171, 33)
        Me.chkDrainPmp.TabIndex = 36
        Me.chkDrainPmp.Text = "Drain Pump"
        Me.chkDrainPmp.UseVisualStyleBackColor = True
        '
        'chkPump
        '
        Me.chkPump.AutoSize = True
        Me.chkPump.Location = New System.Drawing.Point(511, 43)
        Me.chkPump.Name = "chkPump"
        Me.chkPump.Size = New System.Drawing.Size(108, 33)
        Me.chkPump.TabIndex = 35
        Me.chkPump.Text = "Pump"
        Me.chkPump.UseVisualStyleBackColor = True
        '
        'chkSol2
        '
        Me.chkSol2.AutoSize = True
        Me.chkSol2.Location = New System.Drawing.Point(405, 82)
        Me.chkSol2.Name = "chkSol2"
        Me.chkSol2.Size = New System.Drawing.Size(100, 33)
        Me.chkSol2.TabIndex = 34
        Me.chkSol2.Text = "Sol 2"
        Me.chkSol2.UseVisualStyleBackColor = True
        '
        'chkSol1
        '
        Me.chkSol1.AutoSize = True
        Me.chkSol1.Location = New System.Drawing.Point(405, 43)
        Me.chkSol1.Name = "chkSol1"
        Me.chkSol1.Size = New System.Drawing.Size(100, 33)
        Me.chkSol1.TabIndex = 33
        Me.chkSol1.Text = "Sol 1"
        Me.chkSol1.UseVisualStyleBackColor = True
        '
        'chkCalSol2
        '
        Me.chkCalSol2.AutoSize = True
        Me.chkCalSol2.Location = New System.Drawing.Point(242, 82)
        Me.chkCalSol2.Name = "chkCalSol2"
        Me.chkCalSol2.Size = New System.Drawing.Size(142, 33)
        Me.chkCalSol2.TabIndex = 32
        Me.chkCalSol2.Text = "Cal Sol 2"
        Me.chkCalSol2.UseVisualStyleBackColor = True
        '
        'chkCalSol1
        '
        Me.chkCalSol1.AutoSize = True
        Me.chkCalSol1.Location = New System.Drawing.Point(242, 43)
        Me.chkCalSol1.Name = "chkCalSol1"
        Me.chkCalSol1.Size = New System.Drawing.Size(142, 33)
        Me.chkCalSol1.TabIndex = 31
        Me.chkCalSol1.Text = "Cal Sol 1"
        Me.chkCalSol1.UseVisualStyleBackColor = True
        '
        'btnWrite_IO
        '
        Me.btnWrite_IO.Location = New System.Drawing.Point(27, 137)
        Me.btnWrite_IO.Name = "btnWrite_IO"
        Me.btnWrite_IO.Size = New System.Drawing.Size(193, 84)
        Me.btnWrite_IO.TabIndex = 30
        Me.btnWrite_IO.Text = "Write I/O"
        Me.btnWrite_IO.UseVisualStyleBackColor = True
        '
        'btnWriteCalibration
        '
        Me.btnWriteCalibration.Location = New System.Drawing.Point(41, 340)
        Me.btnWriteCalibration.Name = "btnWriteCalibration"
        Me.btnWriteCalibration.Size = New System.Drawing.Size(193, 84)
        Me.btnWriteCalibration.TabIndex = 28
        Me.btnWriteCalibration.Text = "Write Calibration"
        Me.btnWriteCalibration.UseVisualStyleBackColor = True
        '
        'btnGetStatus
        '
        Me.btnGetStatus.CausesValidation = False
        Me.btnGetStatus.Location = New System.Drawing.Point(41, 133)
        Me.btnGetStatus.Name = "btnGetStatus"
        Me.btnGetStatus.Size = New System.Drawing.Size(188, 76)
        Me.btnGetStatus.TabIndex = 27
        Me.btnGetStatus.Text = "Get Status"
        Me.btnGetStatus.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.BackColor = System.Drawing.Color.LightGray
        Me.GroupBox12.Controls.Add(Me.btnCalibration)
        Me.GroupBox12.Controls.Add(Me.cmbCalibrationMode)
        Me.GroupBox12.Controls.Add(Me.chkHiHC)
        Me.GroupBox12.Controls.Add(Me.chkHC)
        Me.GroupBox12.Controls.Add(Me.chkNOx)
        Me.GroupBox12.Controls.Add(Me.chkCO)
        Me.GroupBox12.Controls.Add(Me.chkO2)
        Me.GroupBox12.Controls.Add(Me.chkCO2)
        Me.GroupBox12.Location = New System.Drawing.Point(966, 901)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(543, 251)
        Me.GroupBox12.TabIndex = 20
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Calibration"
        '
        'btnCalibration
        '
        Me.btnCalibration.Location = New System.Drawing.Point(24, 47)
        Me.btnCalibration.Name = "btnCalibration"
        Me.btnCalibration.Size = New System.Drawing.Size(188, 84)
        Me.btnCalibration.TabIndex = 1
        Me.btnCalibration.Text = "Calibration"
        Me.btnCalibration.UseVisualStyleBackColor = True
        '
        'cmbCalibrationMode
        '
        Me.cmbCalibrationMode.FormattingEnabled = True
        Me.cmbCalibrationMode.Items.AddRange(New Object() {"0", "1", "2", "3"})
        Me.cmbCalibrationMode.Location = New System.Drawing.Point(228, 47)
        Me.cmbCalibrationMode.Name = "cmbCalibrationMode"
        Me.cmbCalibrationMode.Size = New System.Drawing.Size(274, 37)
        Me.cmbCalibrationMode.TabIndex = 5
        Me.cmbCalibrationMode.Text = "Mode"
        '
        'chkHiHC
        '
        Me.chkHiHC.AutoSize = True
        Me.chkHiHC.Location = New System.Drawing.Point(400, 137)
        Me.chkHiHC.Name = "chkHiHC"
        Me.chkHiHC.Size = New System.Drawing.Size(102, 33)
        Me.chkHiHC.TabIndex = 14
        Me.chkHiHC.Text = "HiHC"
        Me.chkHiHC.UseVisualStyleBackColor = True
        '
        'chkHC
        '
        Me.chkHC.AutoSize = True
        Me.chkHC.Location = New System.Drawing.Point(228, 98)
        Me.chkHC.Name = "chkHC"
        Me.chkHC.Size = New System.Drawing.Size(79, 33)
        Me.chkHC.TabIndex = 9
        Me.chkHC.Text = "HC"
        Me.chkHC.UseVisualStyleBackColor = True
        '
        'chkNOx
        '
        Me.chkNOx.AutoSize = True
        Me.chkNOx.Location = New System.Drawing.Point(311, 137)
        Me.chkNOx.Name = "chkNOx"
        Me.chkNOx.Size = New System.Drawing.Size(93, 33)
        Me.chkNOx.TabIndex = 13
        Me.chkNOx.Text = "NOx"
        Me.chkNOx.UseVisualStyleBackColor = True
        '
        'chkCO
        '
        Me.chkCO.AutoSize = True
        Me.chkCO.Location = New System.Drawing.Point(313, 98)
        Me.chkCO.Name = "chkCO"
        Me.chkCO.Size = New System.Drawing.Size(81, 33)
        Me.chkCO.TabIndex = 10
        Me.chkCO.Text = "CO"
        Me.chkCO.UseVisualStyleBackColor = True
        '
        'chkO2
        '
        Me.chkO2.AutoSize = True
        Me.chkO2.Location = New System.Drawing.Point(228, 137)
        Me.chkO2.Name = "chkO2"
        Me.chkO2.Size = New System.Drawing.Size(77, 33)
        Me.chkO2.TabIndex = 12
        Me.chkO2.Text = "O2"
        Me.chkO2.UseVisualStyleBackColor = True
        '
        'chkCO2
        '
        Me.chkCO2.AutoSize = True
        Me.chkCO2.Location = New System.Drawing.Point(400, 98)
        Me.chkCO2.Name = "chkCO2"
        Me.chkCO2.Size = New System.Drawing.Size(94, 33)
        Me.chkCO2.TabIndex = 11
        Me.chkCO2.Text = "CO2"
        Me.chkCO2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.SeaGreen
        Me.GroupBox3.Controls.Add(Me.GroupBox11)
        Me.GroupBox3.Controls.Add(Me.GroupBox10)
        Me.GroupBox3.Controls.Add(Me.GroupBox9)
        Me.GroupBox3.Controls.Add(Me.GroupBox8)
        Me.GroupBox3.Controls.Add(Me.GroupBox7)
        Me.GroupBox3.Controls.Add(Me.GroupBox6)
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.btnGetData)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.cmbGasDatain)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(251, 34)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1454, 347)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Get Data"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.rdbRPMmv)
        Me.GroupBox11.Controls.Add(Me.rdbRPM1_min)
        Me.GroupBox11.Location = New System.Drawing.Point(840, 243)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(228, 79)
        Me.GroupBox11.TabIndex = 26
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "RPM"
        '
        'rdbRPMmv
        '
        Me.rdbRPMmv.AutoSize = True
        Me.rdbRPMmv.Location = New System.Drawing.Point(120, 34)
        Me.rdbRPMmv.Name = "rdbRPMmv"
        Me.rdbRPMmv.Size = New System.Drawing.Size(79, 33)
        Me.rdbRPMmv.TabIndex = 1
        Me.rdbRPMmv.Text = "mV"
        Me.rdbRPMmv.UseVisualStyleBackColor = True
        '
        'rdbRPM1_min
        '
        Me.rdbRPM1_min.AutoSize = True
        Me.rdbRPM1_min.Checked = True
        Me.rdbRPM1_min.Location = New System.Drawing.Point(6, 34)
        Me.rdbRPM1_min.Name = "rdbRPM1_min"
        Me.rdbRPM1_min.Size = New System.Drawing.Size(103, 33)
        Me.rdbRPM1_min.TabIndex = 0
        Me.rdbRPM1_min.TabStop = True
        Me.rdbRPM1_min.Text = "1/min"
        Me.rdbRPM1_min.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.rdbOiltempmV)
        Me.GroupBox10.Controls.Add(Me.rdbOiltempC)
        Me.GroupBox10.Location = New System.Drawing.Point(623, 243)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(203, 79)
        Me.GroupBox10.TabIndex = 25
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Oil Temp"
        '
        'rdbOiltempmV
        '
        Me.rdbOiltempmV.AutoSize = True
        Me.rdbOiltempmV.Location = New System.Drawing.Point(108, 34)
        Me.rdbOiltempmV.Name = "rdbOiltempmV"
        Me.rdbOiltempmV.Size = New System.Drawing.Size(79, 33)
        Me.rdbOiltempmV.TabIndex = 1
        Me.rdbOiltempmV.Text = "mV"
        Me.rdbOiltempmV.UseVisualStyleBackColor = True
        '
        'rdbOiltempC
        '
        Me.rdbOiltempC.AutoSize = True
        Me.rdbOiltempC.Checked = True
        Me.rdbOiltempC.Location = New System.Drawing.Point(6, 34)
        Me.rdbOiltempC.Name = "rdbOiltempC"
        Me.rdbOiltempC.Size = New System.Drawing.Size(61, 33)
        Me.rdbOiltempC.TabIndex = 0
        Me.rdbOiltempC.TabStop = True
        Me.rdbOiltempC.Text = "C"
        Me.rdbOiltempC.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.rdbHCHPropane)
        Me.GroupBox9.Controls.Add(Me.rdbHCHexane)
        Me.GroupBox9.Location = New System.Drawing.Point(306, 243)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(302, 79)
        Me.GroupBox9.TabIndex = 24
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "HC as PPM"
        '
        'rdbHCHPropane
        '
        Me.rdbHCHPropane.AutoSize = True
        Me.rdbHCHPropane.Location = New System.Drawing.Point(138, 34)
        Me.rdbHCHPropane.Name = "rdbHCHPropane"
        Me.rdbHCHPropane.Size = New System.Drawing.Size(136, 33)
        Me.rdbHCHPropane.TabIndex = 1
        Me.rdbHCHPropane.Text = "Propane"
        Me.rdbHCHPropane.UseVisualStyleBackColor = True
        '
        'rdbHCHexane
        '
        Me.rdbHCHexane.AutoSize = True
        Me.rdbHCHexane.Checked = True
        Me.rdbHCHexane.Location = New System.Drawing.Point(6, 34)
        Me.rdbHCHexane.Name = "rdbHCHexane"
        Me.rdbHCHexane.Size = New System.Drawing.Size(126, 33)
        Me.rdbHCHexane.TabIndex = 0
        Me.rdbHCHexane.TabStop = True
        Me.rdbHCHexane.Text = "Hexane"
        Me.rdbHCHexane.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.rdbPressResHigh)
        Me.GroupBox8.Controls.Add(Me.rdbPressResLow)
        Me.GroupBox8.Location = New System.Drawing.Point(32, 243)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(259, 79)
        Me.GroupBox8.TabIndex = 23
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Pressure Resolution"
        '
        'rdbPressResHigh
        '
        Me.rdbPressResHigh.AutoSize = True
        Me.rdbPressResHigh.Location = New System.Drawing.Point(107, 34)
        Me.rdbPressResHigh.Name = "rdbPressResHigh"
        Me.rdbPressResHigh.Size = New System.Drawing.Size(94, 33)
        Me.rdbPressResHigh.TabIndex = 1
        Me.rdbPressResHigh.Text = "High"
        Me.rdbPressResHigh.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.rdbIgnitionDual)
        Me.GroupBox7.Controls.Add(Me.rdbIgnitionNormal)
        Me.GroupBox7.Location = New System.Drawing.Point(1189, 149)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(255, 81)
        Me.GroupBox7.TabIndex = 22
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Ignition"
        '
        'rdbIgnitionDual
        '
        Me.rdbIgnitionDual.AutoSize = True
        Me.rdbIgnitionDual.Location = New System.Drawing.Point(135, 33)
        Me.rdbIgnitionDual.Name = "rdbIgnitionDual"
        Me.rdbIgnitionDual.Size = New System.Drawing.Size(93, 33)
        Me.rdbIgnitionDual.TabIndex = 1
        Me.rdbIgnitionDual.Text = "Dual"
        Me.rdbIgnitionDual.UseVisualStyleBackColor = True
        '
        'rdbIgnitionNormal
        '
        Me.rdbIgnitionNormal.AutoSize = True
        Me.rdbIgnitionNormal.Checked = True
        Me.rdbIgnitionNormal.Location = New System.Drawing.Point(6, 34)
        Me.rdbIgnitionNormal.Name = "rdbIgnitionNormal"
        Me.rdbIgnitionNormal.Size = New System.Drawing.Size(123, 33)
        Me.rdbIgnitionNormal.TabIndex = 0
        Me.rdbIgnitionNormal.TabStop = True
        Me.rdbIgnitionNormal.Text = "Normal"
        Me.rdbIgnitionNormal.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.rdbRPM4)
        Me.GroupBox6.Controls.Add(Me.rdbRPM2)
        Me.GroupBox6.Location = New System.Drawing.Point(1005, 149)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(161, 81)
        Me.GroupBox6.TabIndex = 21
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "RPM Cycle"
        '
        'rdbRPM4
        '
        Me.rdbRPM4.AutoSize = True
        Me.rdbRPM4.Location = New System.Drawing.Point(69, 34)
        Me.rdbRPM4.Name = "rdbRPM4"
        Me.rdbRPM4.Size = New System.Drawing.Size(57, 33)
        Me.rdbRPM4.TabIndex = 1
        Me.rdbRPM4.Text = "4"
        Me.rdbRPM4.UseVisualStyleBackColor = True
        '
        'rdbRPM2
        '
        Me.rdbRPM2.AutoSize = True
        Me.rdbRPM2.Checked = True
        Me.rdbRPM2.Location = New System.Drawing.Point(6, 34)
        Me.rdbRPM2.Name = "rdbRPM2"
        Me.rdbRPM2.Size = New System.Drawing.Size(57, 33)
        Me.rdbRPM2.TabIndex = 0
        Me.rdbRPM2.TabStop = True
        Me.rdbRPM2.Text = "2"
        Me.rdbRPM2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rdbO2ResLow)
        Me.GroupBox5.Controls.Add(Me.rdbO2ResHigh)
        Me.GroupBox5.Location = New System.Drawing.Point(752, 149)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(235, 81)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "O2 Resolution"
        '
        'rdbO2ResLow
        '
        Me.rdbO2ResLow.AutoSize = True
        Me.rdbO2ResLow.Location = New System.Drawing.Point(125, 34)
        Me.rdbO2ResLow.Name = "rdbO2ResLow"
        Me.rdbO2ResLow.Size = New System.Drawing.Size(89, 33)
        Me.rdbO2ResLow.TabIndex = 1
        Me.rdbO2ResLow.Text = "Low"
        Me.rdbO2ResLow.UseVisualStyleBackColor = True
        '
        'rdbO2ResHigh
        '
        Me.rdbO2ResHigh.AutoSize = True
        Me.rdbO2ResHigh.Checked = True
        Me.rdbO2ResHigh.Location = New System.Drawing.Point(6, 34)
        Me.rdbO2ResHigh.Name = "rdbO2ResHigh"
        Me.rdbO2ResHigh.Size = New System.Drawing.Size(94, 33)
        Me.rdbO2ResHigh.TabIndex = 0
        Me.rdbO2ResHigh.TabStop = True
        Me.rdbO2ResHigh.Text = "High"
        Me.rdbO2ResHigh.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdbHC20000)
        Me.GroupBox4.Controls.Add(Me.rdbHC2000)
        Me.GroupBox4.Location = New System.Drawing.Point(458, 149)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(274, 81)
        Me.GroupBox4.TabIndex = 19
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "HC Range ppmHex"
        '
        'rdbHC20000
        '
        Me.rdbHC20000.AutoSize = True
        Me.rdbHC20000.Location = New System.Drawing.Point(141, 34)
        Me.rdbHC20000.Name = "rdbHC20000"
        Me.rdbHC20000.Size = New System.Drawing.Size(130, 33)
        Me.rdbHC20000.TabIndex = 1
        Me.rdbHC20000.Text = "0-20000"
        Me.rdbHC20000.UseVisualStyleBackColor = True
        '
        'rdbHC2000
        '
        Me.rdbHC2000.AutoSize = True
        Me.rdbHC2000.Checked = True
        Me.rdbHC2000.Location = New System.Drawing.Point(6, 34)
        Me.rdbHC2000.Name = "rdbHC2000"
        Me.rdbHC2000.Size = New System.Drawing.Size(117, 33)
        Me.rdbHC2000.TabIndex = 0
        Me.rdbHC2000.TabStop = True
        Me.rdbHC2000.Text = "0-2000"
        Me.rdbHC2000.UseVisualStyleBackColor = True
        '
        'btnGetData
        '
        Me.btnGetData.Location = New System.Drawing.Point(6, 34)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(188, 84)
        Me.btnGetData.TabIndex = 7
        Me.btnGetData.Text = "Get Data"
        Me.btnGetData.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdbTempF)
        Me.GroupBox2.Controls.Add(Me.rdbTempC)
        Me.GroupBox2.Location = New System.Drawing.Point(259, 149)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(179, 79)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Temperature"
        '
        'rdbTempF
        '
        Me.rdbTempF.AutoSize = True
        Me.rdbTempF.Location = New System.Drawing.Point(95, 33)
        Me.rdbTempF.Name = "rdbTempF"
        Me.rdbTempF.Size = New System.Drawing.Size(59, 33)
        Me.rdbTempF.TabIndex = 1
        Me.rdbTempF.Text = "F"
        Me.rdbTempF.UseVisualStyleBackColor = True
        '
        'rdbTempC
        '
        Me.rdbTempC.AutoSize = True
        Me.rdbTempC.Checked = True
        Me.rdbTempC.Location = New System.Drawing.Point(6, 34)
        Me.rdbTempC.Name = "rdbTempC"
        Me.rdbTempC.Size = New System.Drawing.Size(61, 33)
        Me.rdbTempC.TabIndex = 0
        Me.rdbTempC.TabStop = True
        Me.rdbTempC.Text = "C"
        Me.rdbTempC.UseVisualStyleBackColor = True
        '
        'cmbGasDatain
        '
        Me.cmbGasDatain.FormattingEnabled = True
        Me.cmbGasDatain.Items.AddRange(New Object() {"Concentracion", "Voltage", "A/D Counts", "Modulations"})
        Me.cmbGasDatain.Location = New System.Drawing.Point(433, 31)
        Me.cmbGasDatain.Name = "cmbGasDatain"
        Me.cmbGasDatain.Size = New System.Drawing.Size(286, 37)
        Me.cmbGasDatain.TabIndex = 15
        Me.cmbGasDatain.Text = "--"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbPressHg)
        Me.GroupBox1.Controls.Add(Me.rdbPressmbar)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 149)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 79)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pressure"
        '
        'rdbPressHg
        '
        Me.rdbPressHg.AutoSize = True
        Me.rdbPressHg.Location = New System.Drawing.Point(126, 34)
        Me.rdbPressHg.Name = "rdbPressHg"
        Me.rdbPressHg.Size = New System.Drawing.Size(75, 33)
        Me.rdbPressHg.TabIndex = 1
        Me.rdbPressHg.Text = "Hg"
        Me.rdbPressHg.UseVisualStyleBackColor = True
        '
        'rdbPressmbar
        '
        Me.rdbPressmbar.AutoSize = True
        Me.rdbPressmbar.Checked = True
        Me.rdbPressmbar.Location = New System.Drawing.Point(6, 34)
        Me.rdbPressmbar.Name = "rdbPressmbar"
        Me.rdbPressmbar.Size = New System.Drawing.Size(99, 33)
        Me.rdbPressmbar.TabIndex = 0
        Me.rdbPressmbar.TabStop = True
        Me.rdbPressmbar.Text = "mbar"
        Me.rdbPressmbar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(200, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(214, 29)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Report gas data in:"
        '
        'btnReadCalibration
        '
        Me.btnReadCalibration.Location = New System.Drawing.Point(41, 232)
        Me.btnReadCalibration.Name = "btnReadCalibration"
        Me.btnReadCalibration.Size = New System.Drawing.Size(193, 84)
        Me.btnReadCalibration.TabIndex = 8
        Me.btnReadCalibration.Text = "Read Calibration"
        Me.btnReadCalibration.UseVisualStyleBackColor = True
        '
        'lblSerialMB
        '
        Me.lblSerialMB.AutoSize = True
        Me.lblSerialMB.Location = New System.Drawing.Point(17, 9)
        Me.lblSerialMB.Name = "lblSerialMB"
        Me.lblSerialMB.Size = New System.Drawing.Size(153, 29)
        Me.lblSerialMB.TabIndex = 5
        Me.lblSerialMB.Text = "Puerto Serial"
        '
        'cmbPuertoMicroBench
        '
        Me.cmbPuertoMicroBench.FormattingEnabled = True
        Me.cmbPuertoMicroBench.Location = New System.Drawing.Point(181, 9)
        Me.cmbPuertoMicroBench.Name = "cmbPuertoMicroBench"
        Me.cmbPuertoMicroBench.Size = New System.Drawing.Size(325, 37)
        Me.cmbPuertoMicroBench.TabIndex = 4
        Me.cmbPuertoMicroBench.Text = "Seleccione Puerto COM"
        '
        'TabPageOpacimetro
        '
        Me.TabPageOpacimetro.Controls.Add(Me.Label7)
        Me.TabPageOpacimetro.Controls.Add(Me.cmbPuertoOpacimetro)
        Me.TabPageOpacimetro.Controls.Add(Me.btnOpacGetVersion)
        Me.TabPageOpacimetro.Location = New System.Drawing.Point(10, 47)
        Me.TabPageOpacimetro.Name = "TabPageOpacimetro"
        Me.TabPageOpacimetro.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageOpacimetro.Size = New System.Drawing.Size(1767, 1316)
        Me.TabPageOpacimetro.TabIndex = 1
        Me.TabPageOpacimetro.Text = "Opacimetro CAP3030"
        Me.TabPageOpacimetro.UseVisualStyleBackColor = True
        '
        'TabPageEncicla
        '
        Me.TabPageEncicla.Controls.Add(Me.Label3)
        Me.TabPageEncicla.Controls.Add(Me.txtLogEncicla)
        Me.TabPageEncicla.Controls.Add(Me.Label2)
        Me.TabPageEncicla.Controls.Add(Me.TextBox1)
        Me.TabPageEncicla.Controls.Add(Me.btnEscanear)
        Me.TabPageEncicla.Location = New System.Drawing.Point(10, 47)
        Me.TabPageEncicla.Name = "TabPageEncicla"
        Me.TabPageEncicla.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabPageEncicla.Size = New System.Drawing.Size(2941, 1214)
        Me.TabPageEncicla.TabIndex = 2
        Me.TabPageEncicla.Text = "EnCicla"
        Me.TabPageEncicla.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 533)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 29)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "LOG "
        '
        'txtLogEncicla
        '
        Me.txtLogEncicla.Location = New System.Drawing.Point(3, 576)
        Me.txtLogEncicla.Multiline = True
        Me.txtLogEncicla.Name = "txtLogEncicla"
        Me.txtLogEncicla.Size = New System.Drawing.Size(1315, 539)
        Me.txtLogEncicla.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(207, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 29)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Número Módulo"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(207, 130)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(208, 35)
        Me.TextBox1.TabIndex = 1
        '
        'btnEscanear
        '
        Me.btnEscanear.Location = New System.Drawing.Point(19, 85)
        Me.btnEscanear.Name = "btnEscanear"
        Me.btnEscanear.Size = New System.Drawing.Size(182, 94)
        Me.btnEscanear.TabIndex = 0
        Me.btnEscanear.Text = "Escanear Modulo"
        Me.btnEscanear.UseVisualStyleBackColor = True
        '
        'btnCalibrateRPM
        '
        Me.btnCalibrateRPM.Location = New System.Drawing.Point(19, 52)
        Me.btnCalibrateRPM.Name = "btnCalibrateRPM"
        Me.btnCalibrateRPM.Size = New System.Drawing.Size(193, 84)
        Me.btnCalibrateRPM.TabIndex = 32
        Me.btnCalibrateRPM.Text = "Calibrate RPM"
        Me.btnCalibrateRPM.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.Label5)
        Me.GroupBox14.Controls.Add(Me.txtRPM)
        Me.GroupBox14.Controls.Add(Me.btnCalibrateRPM)
        Me.GroupBox14.Location = New System.Drawing.Point(257, 402)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(494, 201)
        Me.GroupBox14.TabIndex = 33
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Calibrate RPM"
        '
        'txtRPM
        '
        Me.txtRPM.Location = New System.Drawing.Point(228, 92)
        Me.txtRPM.Name = "txtRPM"
        Me.txtRPM.Size = New System.Drawing.Size(239, 35)
        Me.txtRPM.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(223, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 29)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "RPM"
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.cmbCalPressMode)
        Me.GroupBox15.Controls.Add(Me.rdbCalPressHg)
        Me.GroupBox15.Controls.Add(Me.rdbCalPressmbar)
        Me.GroupBox15.Controls.Add(Me.Label6)
        Me.GroupBox15.Controls.Add(Me.txtCalPress)
        Me.GroupBox15.Controls.Add(Me.btnCalibratePress)
        Me.GroupBox15.Location = New System.Drawing.Point(251, 617)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(581, 277)
        Me.GroupBox15.TabIndex = 34
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Calibrate Pressure"
        '
        'btnCalibratePress
        '
        Me.btnCalibratePress.Location = New System.Drawing.Point(19, 52)
        Me.btnCalibratePress.Name = "btnCalibratePress"
        Me.btnCalibratePress.Size = New System.Drawing.Size(193, 84)
        Me.btnCalibratePress.TabIndex = 32
        Me.btnCalibratePress.Text = "Calibrate Pressure"
        Me.btnCalibratePress.UseVisualStyleBackColor = True
        '
        'rdbCalPressHg
        '
        Me.rdbCalPressHg.AutoSize = True
        Me.rdbCalPressHg.Location = New System.Drawing.Point(354, 203)
        Me.rdbCalPressHg.Name = "rdbCalPressHg"
        Me.rdbCalPressHg.Size = New System.Drawing.Size(75, 33)
        Me.rdbCalPressHg.TabIndex = 1
        Me.rdbCalPressHg.Text = "Hg"
        Me.rdbCalPressHg.UseVisualStyleBackColor = True
        '
        'rdbCalPressmbar
        '
        Me.rdbCalPressmbar.AutoSize = True
        Me.rdbCalPressmbar.Checked = True
        Me.rdbCalPressmbar.Location = New System.Drawing.Point(234, 203)
        Me.rdbCalPressmbar.Name = "rdbCalPressmbar"
        Me.rdbCalPressmbar.Size = New System.Drawing.Size(99, 33)
        Me.rdbCalPressmbar.TabIndex = 0
        Me.rdbCalPressmbar.TabStop = True
        Me.rdbCalPressmbar.Text = "mbar"
        Me.rdbCalPressmbar.UseVisualStyleBackColor = True
        '
        'cmbCalPressMode
        '
        Me.cmbCalPressMode.FormattingEnabled = True
        Me.cmbCalPressMode.Items.AddRange(New Object() {"Calibrate Trans 0", "Calibrate Trans 1", "Read Cal. Pressure", ""})
        Me.cmbCalPressMode.Location = New System.Drawing.Point(234, 52)
        Me.cmbCalPressMode.Name = "cmbCalPressMode"
        Me.cmbCalPressMode.Size = New System.Drawing.Size(246, 37)
        Me.cmbCalPressMode.TabIndex = 35
        Me.cmbCalPressMode.Text = "Calibration Mode"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(229, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 29)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Pressure"
        '
        'txtCalPress
        '
        Me.txtCalPress.Location = New System.Drawing.Point(234, 150)
        Me.txtCalPress.Name = "txtCalPress"
        Me.txtCalPress.Size = New System.Drawing.Size(239, 35)
        Me.txtCalPress.TabIndex = 33
        '
        'btnLimpiarConsola
        '
        Me.btnLimpiarConsola.Location = New System.Drawing.Point(2785, 40)
        Me.btnLimpiarConsola.Name = "btnLimpiarConsola"
        Me.btnLimpiarConsola.Size = New System.Drawing.Size(188, 37)
        Me.btnLimpiarConsola.TabIndex = 35
        Me.btnLimpiarConsola.Text = "Limpiar"
        Me.btnLimpiarConsola.UseVisualStyleBackColor = True
        '
        'rdbPressResLow
        '
        Me.rdbPressResLow.AutoSize = True
        Me.rdbPressResLow.Checked = True
        Me.rdbPressResLow.Location = New System.Drawing.Point(6, 34)
        Me.rdbPressResLow.Name = "rdbPressResLow"
        Me.rdbPressResLow.Size = New System.Drawing.Size(89, 33)
        Me.rdbPressResLow.TabIndex = 0
        Me.rdbPressResLow.TabStop = True
        Me.rdbPressResLow.Text = "Low"
        Me.rdbPressResLow.UseVisualStyleBackColor = True
        '
        'btnOpacGetVersion
        '
        Me.btnOpacGetVersion.Location = New System.Drawing.Point(23, 109)
        Me.btnOpacGetVersion.Name = "btnOpacGetVersion"
        Me.btnOpacGetVersion.Size = New System.Drawing.Size(188, 84)
        Me.btnOpacGetVersion.TabIndex = 1
        Me.btnOpacGetVersion.Text = "Get Version"
        Me.btnOpacGetVersion.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(153, 29)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Puerto Serial"
        '
        'cmbPuertoOpacimetro
        '
        Me.cmbPuertoOpacimetro.FormattingEnabled = True
        Me.cmbPuertoOpacimetro.Location = New System.Drawing.Point(182, 25)
        Me.cmbPuertoOpacimetro.Name = "cmbPuertoOpacimetro"
        Me.cmbPuertoOpacimetro.Size = New System.Drawing.Size(325, 37)
        Me.cmbPuertoOpacimetro.TabIndex = 6
        Me.cmbPuertoOpacimetro.Text = "Seleccione Puerto COM"
        '
        'frmFuentesMoviles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(14.0!, 29.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2985, 1467)
        Me.Controls.Add(Me.btnLimpiarConsola)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabPrincipal)
        Me.Controls.Add(Me.txtConsola)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmFuentesMoviles"
        Me.Text = "Fuentes Moviles"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabPrincipal.ResumeLayout(False)
        Me.TabPageMicroBench.ResumeLayout(False)
        Me.TabPageMicroBench.PerformLayout()
        Me.grpComandoMB.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPageOpacimetro.ResumeLayout(False)
        Me.TabPageOpacimetro.PerformLayout()
        Me.TabPageEncicla.ResumeLayout(False)
        Me.TabPageEncicla.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents btnGetVersion As Windows.Forms.Button
    Friend WithEvents txtConsola As Windows.Forms.TextBox
    Friend WithEvents TabPrincipal As Windows.Forms.TabControl
    Friend WithEvents TabPageMicroBench As Windows.Forms.TabPage
    Friend WithEvents TabPageOpacimetro As Windows.Forms.TabPage
    Friend WithEvents tmrComunicacion As Windows.Forms.Timer
    Friend WithEvents cmbPuertoMicroBench As Windows.Forms.ComboBox
    Friend WithEvents lblSerialMB As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents grpComandoMB As Windows.Forms.GroupBox
    Friend WithEvents btnCalibration As Windows.Forms.Button
    Friend WithEvents cmbCalibrationMode As Windows.Forms.ComboBox
    Friend WithEvents btnGetData As Windows.Forms.Button
    Friend WithEvents TabPageEncicla As Windows.Forms.TabPage
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents txtLogEncicla As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents btnEscanear As Windows.Forms.Button
    Friend WithEvents btnReadCalibration As Windows.Forms.Button
    Friend WithEvents chkHC As Windows.Forms.CheckBox
    Friend WithEvents chkHiHC As Windows.Forms.CheckBox
    Friend WithEvents chkNOx As Windows.Forms.CheckBox
    Friend WithEvents chkO2 As Windows.Forms.CheckBox
    Friend WithEvents chkCO2 As Windows.Forms.CheckBox
    Friend WithEvents chkCO As Windows.Forms.CheckBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents cmbGasDatain As Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents rdbTempF As Windows.Forms.RadioButton
    Friend WithEvents rdbTempC As Windows.Forms.RadioButton
    Friend WithEvents rdbPressHg As Windows.Forms.RadioButton
    Friend WithEvents rdbPressmbar As Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As Windows.Forms.GroupBox
    Friend WithEvents rdbHC20000 As Windows.Forms.RadioButton
    Friend WithEvents rdbHC2000 As Windows.Forms.RadioButton
    Friend WithEvents GroupBox11 As Windows.Forms.GroupBox
    Friend WithEvents rdbRPMmv As Windows.Forms.RadioButton
    Friend WithEvents rdbRPM1_min As Windows.Forms.RadioButton
    Friend WithEvents GroupBox10 As Windows.Forms.GroupBox
    Friend WithEvents rdbOiltempmV As Windows.Forms.RadioButton
    Friend WithEvents rdbOiltempC As Windows.Forms.RadioButton
    Friend WithEvents GroupBox9 As Windows.Forms.GroupBox
    Friend WithEvents rdbHCHPropane As Windows.Forms.RadioButton
    Friend WithEvents rdbHCHexane As Windows.Forms.RadioButton
    Friend WithEvents GroupBox8 As Windows.Forms.GroupBox
    Friend WithEvents rdbPressResHigh As Windows.Forms.RadioButton
    Friend WithEvents GroupBox7 As Windows.Forms.GroupBox
    Friend WithEvents rdbIgnitionDual As Windows.Forms.RadioButton
    Friend WithEvents rdbIgnitionNormal As Windows.Forms.RadioButton
    Friend WithEvents GroupBox6 As Windows.Forms.GroupBox
    Friend WithEvents rdbRPM4 As Windows.Forms.RadioButton
    Friend WithEvents rdbRPM2 As Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As Windows.Forms.GroupBox
    Friend WithEvents rdbO2ResLow As Windows.Forms.RadioButton
    Friend WithEvents rdbO2ResHigh As Windows.Forms.RadioButton
    Friend WithEvents GroupBox12 As Windows.Forms.GroupBox
    Friend WithEvents btnGetStatus As Windows.Forms.Button
    Friend WithEvents btnWriteCalibration As Windows.Forms.Button
    Friend WithEvents btnRead_IO As Windows.Forms.Button
    Friend WithEvents btnWrite_IO As Windows.Forms.Button
    Friend WithEvents GroupBox13 As Windows.Forms.GroupBox
    Friend WithEvents chkCalSol1 As Windows.Forms.CheckBox
    Friend WithEvents chkDrainPmp As Windows.Forms.CheckBox
    Friend WithEvents chkPump As Windows.Forms.CheckBox
    Friend WithEvents chkSol2 As Windows.Forms.CheckBox
    Friend WithEvents chkSol1 As Windows.Forms.CheckBox
    Friend WithEvents chkCalSol2 As Windows.Forms.CheckBox
    Friend WithEvents chkOUT7 As Windows.Forms.CheckBox
    Friend WithEvents chkOUT6 As Windows.Forms.CheckBox
    Friend WithEvents chkOUT5 As Windows.Forms.CheckBox
    Friend WithEvents chkOUT4 As Windows.Forms.CheckBox
    Friend WithEvents chkOUT3 As Windows.Forms.CheckBox
    Friend WithEvents chkOUT2 As Windows.Forms.CheckBox
    Friend WithEvents chkOUT1 As Windows.Forms.CheckBox
    Friend WithEvents chkIN8 As Windows.Forms.CheckBox
    Friend WithEvents chkIN7 As Windows.Forms.CheckBox
    Friend WithEvents chkIN6 As Windows.Forms.CheckBox
    Friend WithEvents chkIN5 As Windows.Forms.CheckBox
    Friend WithEvents chkIN4 As Windows.Forms.CheckBox
    Friend WithEvents chkIN3 As Windows.Forms.CheckBox
    Friend WithEvents chkIN2 As Windows.Forms.CheckBox
    Friend WithEvents chkIN1 As Windows.Forms.CheckBox
    Friend WithEvents chkOUT8 As Windows.Forms.CheckBox
    Friend WithEvents chkHabilitarSOUT As Windows.Forms.CheckBox
    Friend WithEvents GroupBox14 As Windows.Forms.GroupBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents txtRPM As Windows.Forms.TextBox
    Friend WithEvents btnCalibrateRPM As Windows.Forms.Button
    Friend WithEvents GroupBox15 As Windows.Forms.GroupBox
    Friend WithEvents cmbCalPressMode As Windows.Forms.ComboBox
    Friend WithEvents rdbCalPressHg As Windows.Forms.RadioButton
    Friend WithEvents rdbCalPressmbar As Windows.Forms.RadioButton
    Friend WithEvents btnCalibratePress As Windows.Forms.Button
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents txtCalPress As Windows.Forms.TextBox
    Friend WithEvents btnLimpiarConsola As Windows.Forms.Button
    Friend WithEvents rdbPressResLow As Windows.Forms.RadioButton
    Friend WithEvents btnOpacGetVersion As Windows.Forms.Button
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents cmbPuertoOpacimetro As Windows.Forms.ComboBox
End Class
