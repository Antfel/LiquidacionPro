<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptFormGuiaControlViaje
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.cbCamabaja = New System.Windows.Forms.ComboBox()
        Me.cbTracto = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chbxFechaGuia = New System.Windows.Forms.CheckBox()
        Me.cbCliente = New System.Windows.Forms.ComboBox()
        Me.dtpFechaGuia = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbTrabajador = New System.Windows.Forms.ComboBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Location = New System.Drawing.Point(1, 82)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1009, 246)
        Me.ReportViewer1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtDestino)
        Me.GroupBox1.Controls.Add(Me.txtOrigen)
        Me.GroupBox1.Controls.Add(Me.cbCamabaja)
        Me.GroupBox1.Controls.Add(Me.cbTracto)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.chbxFechaGuia)
        Me.GroupBox1.Controls.Add(Me.cbCliente)
        Me.GroupBox1.Controls.Add(Me.dtpFechaGuia)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbTrabajador)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(908, 73)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(737, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 115
        Me.Label5.Text = "Destino"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(577, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "Origen"
        '
        'txtDestino
        '
        Me.txtDestino.Location = New System.Drawing.Point(786, 44)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(100, 20)
        Me.txtDestino.TabIndex = 113
        '
        'txtOrigen
        '
        Me.txtOrigen.Location = New System.Drawing.Point(621, 44)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(100, 20)
        Me.txtOrigen.TabIndex = 112
        '
        'cbCamabaja
        '
        Me.cbCamabaja.FormattingEnabled = True
        Me.cbCamabaja.Location = New System.Drawing.Point(458, 44)
        Me.cbCamabaja.Name = "cbCamabaja"
        Me.cbCamabaja.Size = New System.Drawing.Size(100, 21)
        Me.cbCamabaja.TabIndex = 109
        '
        'cbTracto
        '
        Me.cbTracto.FormattingEnabled = True
        Me.cbTracto.Location = New System.Drawing.Point(256, 44)
        Me.cbTracto.Name = "cbTracto"
        Me.cbTracto.Size = New System.Drawing.Size(100, 21)
        Me.cbTracto.TabIndex = 108
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Cliente"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(367, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "Placa Camabaja"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(378, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Trabajador"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(185, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 110
        Me.Label8.Text = "Placa Tracto"
        '
        'chbxFechaGuia
        '
        Me.chbxFechaGuia.AutoSize = True
        Me.chbxFechaGuia.Location = New System.Drawing.Point(155, 48)
        Me.chbxFechaGuia.Name = "chbxFechaGuia"
        Me.chbxFechaGuia.Size = New System.Drawing.Size(15, 14)
        Me.chbxFechaGuia.TabIndex = 2
        Me.chbxFechaGuia.UseVisualStyleBackColor = True
        '
        'cbCliente
        '
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(53, 17)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(310, 21)
        Me.cbCliente.TabIndex = 9
        '
        'dtpFechaGuia
        '
        Me.dtpFechaGuia.Enabled = False
        Me.dtpFechaGuia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaGuia.Location = New System.Drawing.Point(53, 44)
        Me.dtpFechaGuia.Name = "dtpFechaGuia"
        Me.dtpFechaGuia.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaGuia.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Fecha"
        '
        'cbTrabajador
        '
        Me.cbTrabajador.FormattingEnabled = True
        Me.cbTrabajador.Location = New System.Drawing.Point(442, 16)
        Me.cbTrabajador.Name = "cbTrabajador"
        Me.cbTrabajador.Size = New System.Drawing.Size(310, 21)
        Me.cbTrabajador.TabIndex = 7
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(811, 15)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'RptFormGuiaControlViaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1152, 348)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "RptFormGuiaControlViaje"
        Me.Text = "Guías - Control de Viajes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbTrabajador As ComboBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents chbxFechaGuia As CheckBox
    Friend WithEvents dtpFechaGuia As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents cbCliente As ComboBox
    Friend WithEvents cbCamabaja As ComboBox
    Friend WithEvents cbTracto As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDestino As TextBox
    Friend WithEvents txtOrigen As TextBox
End Class
