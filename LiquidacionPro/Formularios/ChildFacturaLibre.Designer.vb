<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChildFacturaLibre
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
        Me.btnRazonSocial = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbMoneda = New System.Windows.Forms.ComboBox()
        Me.txtRUC = New System.Windows.Forms.TextBox()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.cbRazonSocial = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnGuardarCabecera = New System.Windows.Forms.Button()
        Me.lbNroFactura = New System.Windows.Forms.Label()
        Me.txtNroSerie = New System.Windows.Forms.TextBox()
        Me.lbFactura = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRazonSocial
        '
        Me.btnRazonSocial.Location = New System.Drawing.Point(27, 83)
        Me.btnRazonSocial.Name = "btnRazonSocial"
        Me.btnRazonSocial.Size = New System.Drawing.Size(98, 21)
        Me.btnRazonSocial.TabIndex = 17
        Me.btnRazonSocial.Text = "Razon Social"
        Me.btnRazonSocial.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel2.Location = New System.Drawing.Point(31, 164)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1253, 3)
        Me.Panel2.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(401, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(334, 33)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Generación de Factura"
        '
        'cbMoneda
        '
        Me.cbMoneda.FormattingEnabled = True
        Me.cbMoneda.Location = New System.Drawing.Point(802, 121)
        Me.cbMoneda.Name = "cbMoneda"
        Me.cbMoneda.Size = New System.Drawing.Size(143, 21)
        Me.cbMoneda.TabIndex = 28
        '
        'txtRUC
        '
        Me.txtRUC.Location = New System.Drawing.Point(592, 83)
        Me.txtRUC.Name = "txtRUC"
        Me.txtRUC.Size = New System.Drawing.Size(142, 20)
        Me.txtRUC.TabIndex = 27
        '
        'dtFecha
        '
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha.Location = New System.Drawing.Point(802, 83)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(143, 20)
        Me.dtFecha.TabIndex = 19
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(131, 126)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(400, 20)
        Me.txtDireccion.TabIndex = 26
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(592, 123)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(142, 20)
        Me.txtTelefono.TabIndex = 25
        '
        'cbRazonSocial
        '
        Me.cbRazonSocial.FormattingEnabled = True
        Me.cbRazonSocial.Location = New System.Drawing.Point(131, 83)
        Me.cbRazonSocial.Name = "cbRazonSocial"
        Me.cbRazonSocial.Size = New System.Drawing.Size(400, 21)
        Me.cbRazonSocial.TabIndex = 16
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnGuardarCabecera)
        Me.Panel1.Controls.Add(Me.lbNroFactura)
        Me.Panel1.Controls.Add(Me.txtNroSerie)
        Me.Panel1.Controls.Add(Me.lbFactura)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(967, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(317, 146)
        Me.Panel1.TabIndex = 24
        '
        'btnGuardarCabecera
        '
        Me.btnGuardarCabecera.Location = New System.Drawing.Point(98, 120)
        Me.btnGuardarCabecera.Name = "btnGuardarCabecera"
        Me.btnGuardarCabecera.Size = New System.Drawing.Size(141, 23)
        Me.btnGuardarCabecera.TabIndex = 4
        Me.btnGuardarCabecera.Text = "Guardar Datos"
        Me.btnGuardarCabecera.UseVisualStyleBackColor = True
        '
        'lbNroFactura
        '
        Me.lbNroFactura.AutoSize = True
        Me.lbNroFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNroFactura.ForeColor = System.Drawing.Color.DarkRed
        Me.lbNroFactura.Location = New System.Drawing.Point(208, 94)
        Me.lbNroFactura.Name = "lbNroFactura"
        Me.lbNroFactura.Size = New System.Drawing.Size(0, 20)
        Me.lbNroFactura.TabIndex = 3
        '
        'txtNroSerie
        '
        Me.txtNroSerie.Location = New System.Drawing.Point(154, 94)
        Me.txtNroSerie.Name = "txtNroSerie"
        Me.txtNroSerie.Size = New System.Drawing.Size(48, 20)
        Me.txtNroSerie.TabIndex = 2
        '
        'lbFactura
        '
        Me.lbFactura.AutoSize = True
        Me.lbFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFactura.ForeColor = System.Drawing.Color.DarkRed
        Me.lbFactura.Location = New System.Drawing.Point(16, 94)
        Me.lbFactura.Name = "lbFactura"
        Me.lbFactura.Size = New System.Drawing.Size(132, 20)
        Me.lbFactura.TabIndex = 1
        Me.lbFactura.Text = "NRO FACTURA: "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(48, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(245, 25)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "R.U.C. : 20519804427"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(537, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Telefono"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(556, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "RUC"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(750, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Moneda"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(759, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Direccion"
        '
        'ChildFacturaLibre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1321, 524)
        Me.Controls.Add(Me.btnRazonSocial)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbMoneda)
        Me.Controls.Add(Me.txtRUC)
        Me.Controls.Add(Me.dtFecha)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.cbRazonSocial)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Name = "ChildFacturaLibre"
        Me.Text = "ChildFacturaLibre"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRazonSocial As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents cbMoneda As ComboBox
    Friend WithEvents txtRUC As TextBox
    Friend WithEvents dtFecha As DateTimePicker
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents cbRazonSocial As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnGuardarCabecera As Button
    Friend WithEvents lbNroFactura As Label
    Friend WithEvents txtNroSerie As TextBox
    Friend WithEvents lbFactura As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
End Class
