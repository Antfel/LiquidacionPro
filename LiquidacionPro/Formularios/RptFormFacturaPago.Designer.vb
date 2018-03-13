<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptFormFacturaPago
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
        Me.btnVerificarPeriodo = New System.Windows.Forms.Button()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbCliente = New System.Windows.Forms.ComboBox()
        Me.rbtn4 = New System.Windows.Forms.RadioButton()
        Me.rbtn3 = New System.Windows.Forms.RadioButton()
        Me.rbtn2 = New System.Windows.Forms.RadioButton()
        Me.rbtn1 = New System.Windows.Forms.RadioButton()
        Me.txtPeriodo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbMes = New System.Windows.Forms.ComboBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVerificarPeriodo
        '
        Me.btnVerificarPeriodo.Location = New System.Drawing.Point(740, 12)
        Me.btnVerificarPeriodo.Name = "btnVerificarPeriodo"
        Me.btnVerificarPeriodo.Size = New System.Drawing.Size(71, 23)
        Me.btnVerificarPeriodo.TabIndex = 0
        Me.btnVerificarPeriodo.Text = "Consultar"
        Me.btnVerificarPeriodo.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Location = New System.Drawing.Point(3, 83)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(405, 249)
        Me.ReportViewer1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbCliente)
        Me.GroupBox1.Controls.Add(Me.rbtn4)
        Me.GroupBox1.Controls.Add(Me.rbtn3)
        Me.GroupBox1.Controls.Add(Me.rbtn2)
        Me.GroupBox1.Controls.Add(Me.rbtn1)
        Me.GroupBox1.Controls.Add(Me.txtPeriodo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbMes)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(708, 65)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(347, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Cliente"
        '
        'cbCliente
        '
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(392, 16)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(310, 21)
        Me.cbCliente.TabIndex = 9
        '
        'rbtn4
        '
        Me.rbtn4.AutoSize = True
        Me.rbtn4.Location = New System.Drawing.Point(255, 38)
        Me.rbtn4.Name = "rbtn4"
        Me.rbtn4.Size = New System.Drawing.Size(76, 17)
        Me.rbtn4.TabIndex = 7
        Me.rbtn4.TabStop = True
        Me.rbtn4.Text = "Cancelado"
        Me.rbtn4.UseVisualStyleBackColor = True
        '
        'rbtn3
        '
        Me.rbtn3.AutoSize = True
        Me.rbtn3.Location = New System.Drawing.Point(158, 38)
        Me.rbtn3.Name = "rbtn3"
        Me.rbtn3.Size = New System.Drawing.Size(100, 17)
        Me.rbtn3.TabIndex = 6
        Me.rbtn3.TabStop = True
        Me.rbtn3.Text = "Saldo en contra"
        Me.rbtn3.UseVisualStyleBackColor = True
        '
        'rbtn2
        '
        Me.rbtn2.AutoSize = True
        Me.rbtn2.Location = New System.Drawing.Point(255, 15)
        Me.rbtn2.Name = "rbtn2"
        Me.rbtn2.Size = New System.Drawing.Size(88, 17)
        Me.rbtn2.TabIndex = 5
        Me.rbtn2.TabStop = True
        Me.rbtn2.Text = "Saldo a favor"
        Me.rbtn2.UseVisualStyleBackColor = True
        '
        'rbtn1
        '
        Me.rbtn1.AutoSize = True
        Me.rbtn1.Checked = True
        Me.rbtn1.Location = New System.Drawing.Point(158, 15)
        Me.rbtn1.Name = "rbtn1"
        Me.rbtn1.Size = New System.Drawing.Size(84, 17)
        Me.rbtn1.TabIndex = 4
        Me.rbtn1.TabStop = True
        Me.rbtn1.Text = "Mostrar todo"
        Me.rbtn1.UseVisualStyleBackColor = True
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Location = New System.Drawing.Point(50, 38)
        Me.txtPeriodo.MaxLength = 4
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(97, 20)
        Me.txtPeriodo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(0, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Periodo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mes"
        '
        'cbMes
        '
        Me.cbMes.FormattingEnabled = True
        Me.cbMes.Location = New System.Drawing.Point(50, 15)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.Size = New System.Drawing.Size(97, 21)
        Me.cbMes.TabIndex = 0
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(817, 12)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 23)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'RptFormFacturaPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 335)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.btnVerificarPeriodo)
        Me.Name = "RptFormFacturaPago"
        Me.Text = "Facturas vs Pagos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnVerificarPeriodo As Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbMes As ComboBox
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents txtPeriodo As TextBox
    Friend WithEvents rbtn4 As RadioButton
    Friend WithEvents rbtn3 As RadioButton
    Friend WithEvents rbtn2 As RadioButton
    Friend WithEvents rbtn1 As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents cbCliente As ComboBox
End Class
