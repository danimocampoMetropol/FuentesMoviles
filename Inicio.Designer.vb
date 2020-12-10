<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.txtConsolaMicroBench = New System.Windows.Forms.TextBox()
        Me.TabPrincipal = New System.Windows.Forms.TabControl()
        Me.TabPageMicroBench = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpComandoMB = New System.Windows.Forms.GroupBox()
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
        Me.rdbPressResLow = New System.Windows.Forms.RadioButton()
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
        Me.cmbCalibrationGas = New System.Windows.Forms.ComboBox()
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
        Me.btnWriteCalibration = New System.Windows.Forms.Button()
        Me.btnRead_IO = New System.Windows.Forms.Button()
        Me.btnWrite_IO = New System.Windows.Forms.Button()
        Me.TabPrincipal.SuspendLayout()
        Me.TabPageMicroBench.SuspendLayout()
        Me.grpComandoMB.SuspendLayout()
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
        Me.TabPageEncicla.SuspendLayout()
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
        'txtConsolaMicroBench
        '
        Me.txtConsolaMicroBench.Location = New System.Drawing.Point(2061, 74)
        Me.txtConsolaMicroBench.Multiline = True
        Me.txtConsolaMicroBench.Name = "txtConsolaMicroBench"
        Me.txtConsolaMicroBench.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConsolaMicroBench.Size = New System.Drawing.Size(865, 1100)
        Me.txtConsolaMicroBench.TabIndex = 3
        '
        'TabPrincipal
        '
        Me.TabPrincipal.Controls.Add(Me.TabPageMicroBench)
        Me.TabPrincipal.Controls.Add(Me.TabPageOpacimetro)
        Me.TabPrincipal.Controls.Add(Me.TabPageEncicla)
        Me.TabPrincipal.Location = New System.Drawing.Point(12, 12)
        Me.TabPrincipal.Name = "TabPrincipal"
        Me.TabPrincipal.SelectedIndex = 0
        Me.TabPrincipal.Size = New System.Drawing.Size(2961, 1271)
        Me.TabPrincipal.TabIndex = 6
        '
        'TabPageMicroBench
        '
        Me.TabPageMicroBench.Controls.Add(Me.Label1)
        Me.TabPageMicroBench.Controls.Add(Me.grpComandoMB)
        Me.TabPageMicroBench.Controls.Add(Me.lblSerialMB)
        Me.TabPageMicroBench.Controls.Add(Me.cmbPuertoMicroBench)
        Me.TabPageMicroBench.Controls.Add(Me.txtConsolaMicroBench)
        Me.TabPageMicroBench.Location = New System.Drawing.Point(10, 47)
        Me.TabPageMicroBench.Name = "TabPageMicroBench"
        Me.TabPageMicroBench.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageMicroBench.Size = New System.Drawing.Size(2941, 1214)
        Me.TabPageMicroBench.TabIndex = 0
        Me.TabPageMicroBench.Text = "Sensors Microbench"
        Me.TabPageMicroBench.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2056, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 29)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "LOG "
        '
        'grpComandoMB
        '
        Me.grpComandoMB.Controls.Add(Me.btnWrite_IO)
        Me.grpComandoMB.Controls.Add(Me.btnRead_IO)
        Me.grpComandoMB.Controls.Add(Me.btnWriteCalibration)
        Me.grpComandoMB.Controls.Add(Me.btnGetStatus)
        Me.grpComandoMB.Controls.Add(Me.GroupBox12)
        Me.grpComandoMB.Controls.Add(Me.GroupBox3)
        Me.grpComandoMB.Controls.Add(Me.btnReadCalibration)
        Me.grpComandoMB.Controls.Add(Me.cmbCalibrationGas)
        Me.grpComandoMB.Controls.Add(Me.btnGetVersion)
        Me.grpComandoMB.Location = New System.Drawing.Point(22, 63)
        Me.grpComandoMB.Name = "grpComandoMB"
        Me.grpComandoMB.Size = New System.Drawing.Size(2019, 1111)
        Me.grpComandoMB.TabIndex = 6
        Me.grpComandoMB.TabStop = False
        Me.grpComandoMB.Text = "Comandos"
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
        Me.GroupBox12.Controls.Add(Me.btnCalibration)
        Me.GroupBox12.Controls.Add(Me.cmbCalibrationMode)
        Me.GroupBox12.Controls.Add(Me.chkHiHC)
        Me.GroupBox12.Controls.Add(Me.chkHC)
        Me.GroupBox12.Controls.Add(Me.chkNOx)
        Me.GroupBox12.Controls.Add(Me.chkCO)
        Me.GroupBox12.Controls.Add(Me.chkO2)
        Me.GroupBox12.Controls.Add(Me.chkCO2)
        Me.GroupBox12.Location = New System.Drawing.Point(257, 402)
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
        Me.GroupBox3.Size = New System.Drawing.Size(1547, 346)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Get Data"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.rdbRPMmv)
        Me.GroupBox11.Controls.Add(Me.rdbRPM1_min)
        Me.GroupBox11.Location = New System.Drawing.Point(832, 243)
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
        Me.GroupBox9.Location = New System.Drawing.Point(297, 243)
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
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.rdbIgnitionDual)
        Me.GroupBox7.Controls.Add(Me.rdbIgnitionNormal)
        Me.GroupBox7.Location = New System.Drawing.Point(1172, 149)
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
        Me.GroupBox6.Location = New System.Drawing.Point(993, 149)
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
        Me.GroupBox5.Size = New System.Drawing.Size(214, 81)
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
        Me.GroupBox4.Size = New System.Drawing.Size(288, 81)
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
        Me.GroupBox2.Size = New System.Drawing.Size(193, 79)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Temperature"
        '
        'rdbTempF
        '
        Me.rdbTempF.AutoSize = True
        Me.rdbTempF.Location = New System.Drawing.Point(111, 34)
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
        'cmbCalibrationGas
        '
        Me.cmbCalibrationGas.FormattingEnabled = True
        Me.cmbCalibrationGas.Items.AddRange(New Object() {"HC", "CO", "CO2", "O2", "NOX", "HiHC"})
        Me.cmbCalibrationGas.Location = New System.Drawing.Point(1331, 607)
        Me.cmbCalibrationGas.Name = "cmbCalibrationGas"
        Me.cmbCalibrationGas.Size = New System.Drawing.Size(274, 37)
        Me.cmbCalibrationGas.TabIndex = 6
        Me.cmbCalibrationGas.Text = "Gas"
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
        Me.cmbPuertoMicroBench.Size = New System.Drawing.Size(274, 37)
        Me.cmbPuertoMicroBench.TabIndex = 4
        '
        'TabPageOpacimetro
        '
        Me.TabPageOpacimetro.Location = New System.Drawing.Point(10, 47)
        Me.TabPageOpacimetro.Name = "TabPageOpacimetro"
        Me.TabPageOpacimetro.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageOpacimetro.Size = New System.Drawing.Size(2728, 1181)
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
        Me.TabPageEncicla.Size = New System.Drawing.Size(2728, 1181)
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
        'btnWriteCalibration
        '
        Me.btnWriteCalibration.Location = New System.Drawing.Point(41, 340)
        Me.btnWriteCalibration.Name = "btnWriteCalibration"
        Me.btnWriteCalibration.Size = New System.Drawing.Size(193, 84)
        Me.btnWriteCalibration.TabIndex = 28
        Me.btnWriteCalibration.Text = "Write Calibration"
        Me.btnWriteCalibration.UseVisualStyleBackColor = True
        '
        'btnRead_IO
        '
        Me.btnRead_IO.Location = New System.Drawing.Point(41, 449)
        Me.btnRead_IO.Name = "btnRead_IO"
        Me.btnRead_IO.Size = New System.Drawing.Size(193, 84)
        Me.btnRead_IO.TabIndex = 29
        Me.btnRead_IO.Text = "Read I/O"
        Me.btnRead_IO.UseVisualStyleBackColor = True
        '
        'btnWrite_IO
        '
        Me.btnWrite_IO.Location = New System.Drawing.Point(41, 560)
        Me.btnWrite_IO.Name = "btnWrite_IO"
        Me.btnWrite_IO.Size = New System.Drawing.Size(193, 84)
        Me.btnWrite_IO.TabIndex = 30
        Me.btnWrite_IO.Text = "Write I/O"
        Me.btnWrite_IO.UseVisualStyleBackColor = True
        '
        'frmFuentesMoviles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(14.0!, 29.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2985, 1295)
        Me.Controls.Add(Me.TabPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmFuentesMoviles"
        Me.Text = "Fuentes Moviles"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabPrincipal.ResumeLayout(False)
        Me.TabPageMicroBench.ResumeLayout(False)
        Me.TabPageMicroBench.PerformLayout()
        Me.grpComandoMB.ResumeLayout(False)
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
        Me.TabPageEncicla.ResumeLayout(False)
        Me.TabPageEncicla.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents btnGetVersion As Windows.Forms.Button
    Friend WithEvents txtConsolaMicroBench As Windows.Forms.TextBox
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
    Friend WithEvents cmbCalibrationGas As Windows.Forms.ComboBox
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
    Friend WithEvents rdbPressResLow As Windows.Forms.RadioButton
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
End Class
