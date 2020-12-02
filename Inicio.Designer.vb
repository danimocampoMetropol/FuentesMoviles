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
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.cmbCalibrationGas = New System.Windows.Forms.ComboBox()
        Me.cmbCalibrationMode = New System.Windows.Forms.ComboBox()
        Me.btnCalibration = New System.Windows.Forms.Button()
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
        Me.TabPrincipal.SuspendLayout()
        Me.TabPageMicroBench.SuspendLayout()
        Me.grpComandoMB.SuspendLayout()
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
        Me.btnGetVersion.Location = New System.Drawing.Point(6, 34)
        Me.btnGetVersion.Name = "btnGetVersion"
        Me.btnGetVersion.Size = New System.Drawing.Size(188, 84)
        Me.btnGetVersion.TabIndex = 0
        Me.btnGetVersion.Text = "Get Version"
        Me.btnGetVersion.UseVisualStyleBackColor = True
        '
        'txtConsolaMicroBench
        '
        Me.txtConsolaMicroBench.Location = New System.Drawing.Point(18, 564)
        Me.txtConsolaMicroBench.Multiline = True
        Me.txtConsolaMicroBench.Name = "txtConsolaMicroBench"
        Me.txtConsolaMicroBench.Size = New System.Drawing.Size(1315, 539)
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
        Me.TabPrincipal.Size = New System.Drawing.Size(1375, 1187)
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
        Me.TabPageMicroBench.Size = New System.Drawing.Size(1355, 1130)
        Me.TabPageMicroBench.TabIndex = 0
        Me.TabPageMicroBench.Text = "Sensors Microbench"
        Me.TabPageMicroBench.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 512)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 29)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "LOG "
        '
        'grpComandoMB
        '
        Me.grpComandoMB.Controls.Add(Me.btnGetData)
        Me.grpComandoMB.Controls.Add(Me.cmbCalibrationGas)
        Me.grpComandoMB.Controls.Add(Me.cmbCalibrationMode)
        Me.grpComandoMB.Controls.Add(Me.btnCalibration)
        Me.grpComandoMB.Controls.Add(Me.btnGetVersion)
        Me.grpComandoMB.Location = New System.Drawing.Point(18, 96)
        Me.grpComandoMB.Name = "grpComandoMB"
        Me.grpComandoMB.Size = New System.Drawing.Size(1315, 404)
        Me.grpComandoMB.TabIndex = 6
        Me.grpComandoMB.TabStop = False
        Me.grpComandoMB.Text = "Comandos"
        '
        'btnGetData
        '
        Me.btnGetData.Location = New System.Drawing.Point(4, 214)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(188, 84)
        Me.btnGetData.TabIndex = 7
        Me.btnGetData.Text = "Get Data"
        Me.btnGetData.UseVisualStyleBackColor = True
        '
        'cmbCalibrationGas
        '
        Me.cmbCalibrationGas.FormattingEnabled = True
        Me.cmbCalibrationGas.Items.AddRange(New Object() {"HC", "CO", "CO2", "O2", "NOX", "HiHC"})
        Me.cmbCalibrationGas.Location = New System.Drawing.Point(206, 167)
        Me.cmbCalibrationGas.Name = "cmbCalibrationGas"
        Me.cmbCalibrationGas.Size = New System.Drawing.Size(274, 37)
        Me.cmbCalibrationGas.TabIndex = 6
        Me.cmbCalibrationGas.Text = "Gas"
        '
        'cmbCalibrationMode
        '
        Me.cmbCalibrationMode.FormattingEnabled = True
        Me.cmbCalibrationMode.Items.AddRange(New Object() {"0", "1", "2", "3"})
        Me.cmbCalibrationMode.Location = New System.Drawing.Point(206, 124)
        Me.cmbCalibrationMode.Name = "cmbCalibrationMode"
        Me.cmbCalibrationMode.Size = New System.Drawing.Size(274, 37)
        Me.cmbCalibrationMode.TabIndex = 5
        Me.cmbCalibrationMode.Text = "Mode"
        '
        'btnCalibration
        '
        Me.btnCalibration.Location = New System.Drawing.Point(6, 124)
        Me.btnCalibration.Name = "btnCalibration"
        Me.btnCalibration.Size = New System.Drawing.Size(188, 84)
        Me.btnCalibration.TabIndex = 1
        Me.btnCalibration.Text = "Calibration"
        Me.btnCalibration.UseVisualStyleBackColor = True
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
        Me.cmbPuertoMicroBench.Location = New System.Drawing.Point(22, 40)
        Me.cmbPuertoMicroBench.Name = "cmbPuertoMicroBench"
        Me.cmbPuertoMicroBench.Size = New System.Drawing.Size(274, 37)
        Me.cmbPuertoMicroBench.TabIndex = 4
        '
        'TabPageOpacimetro
        '
        Me.TabPageOpacimetro.Location = New System.Drawing.Point(10, 47)
        Me.TabPageOpacimetro.Name = "TabPageOpacimetro"
        Me.TabPageOpacimetro.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageOpacimetro.Size = New System.Drawing.Size(1355, 1130)
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
        Me.TabPageEncicla.Size = New System.Drawing.Size(1355, 1130)
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
        'frmFuentesMoviles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(14.0!, 29.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1417, 1201)
        Me.Controls.Add(Me.TabPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximumSize = New System.Drawing.Size(1445, 1280)
        Me.Name = "frmFuentesMoviles"
        Me.Text = "Fuentes Moviles"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabPrincipal.ResumeLayout(False)
        Me.TabPageMicroBench.ResumeLayout(False)
        Me.TabPageMicroBench.PerformLayout()
        Me.grpComandoMB.ResumeLayout(False)
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
End Class
