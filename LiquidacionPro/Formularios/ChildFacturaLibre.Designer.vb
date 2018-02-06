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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtPrecioUnitario = New System.Windows.Forms.TextBox()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.txtIGV = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbFactura = New System.Windows.Forms.Label()
        Me.txtNroSerie = New System.Windows.Forms.TextBox()
        Me.lbNroFactura = New System.Windows.Forms.Label()
        Me.btnGuardarCabecera = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chbxCompromiso = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtpCompromiso = New System.Windows.Forms.DateTimePicker()
        Me.chbxPago = New System.Windows.Forms.CheckBox()
        Me.chbxVencimiento = New System.Windows.Forms.CheckBox()
        Me.chbxRecepcion = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dtpPago = New System.Windows.Forms.DateTimePicker()
        Me.dtpVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.dtpRecepcion = New System.Windows.Forms.DateTimePicker()
        Me.txtCodigoDetalle = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtMontoDetraccion = New System.Windows.Forms.TextBox()
        Me.txtPorcentajeDetraccion = New System.Windows.Forms.TextBox()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRazonSocial
        '
        Me.btnRazonSocial.Location = New System.Drawing.Point(27, 83)
        Me.btnRazonSocial.Name = "btnRazonSocial"
        Me.btnRazonSocial.Size = New System.Drawing.Size(98, 21)
        Me.btnRazonSocial.TabIndex = 2
        Me.btnRazonSocial.Text = "Razon Social"
        Me.btnRazonSocial.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel2.Location = New System.Drawing.Point(31, 219)
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
        Me.cbMoneda.TabIndex = 4
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
        Me.dtFecha.TabIndex = 3
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
        Me.cbRazonSocial.TabIndex = 1
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
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToResizeRows = False
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Location = New System.Drawing.Point(214, 302)
        Me.dgvDetalle.MultiSelect = False
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalle.Size = New System.Drawing.Size(825, 154)
        Me.dgvDetalle.TabIndex = 31
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(214, 264)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(100, 20)
        Me.txtCantidad.TabIndex = 7
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(337, 264)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(587, 20)
        Me.txtDescripcion.TabIndex = 8
        '
        'txtPrecioUnitario
        '
        Me.txtPrecioUnitario.Location = New System.Drawing.Point(939, 264)
        Me.txtPrecioUnitario.Name = "txtPrecioUnitario"
        Me.txtPrecioUnitario.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecioUnitario.TabIndex = 9
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Location = New System.Drawing.Point(939, 477)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.ReadOnly = True
        Me.txtSubtotal.Size = New System.Drawing.Size(100, 20)
        Me.txtSubtotal.TabIndex = 35
        '
        'txtIGV
        '
        Me.txtIGV.Location = New System.Drawing.Point(939, 503)
        Me.txtIGV.Name = "txtIGV"
        Me.txtIGV.ReadOnly = True
        Me.txtIGV.Size = New System.Drawing.Size(100, 20)
        Me.txtIGV.TabIndex = 36
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(939, 529)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 37
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(214, 245)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Cantidad"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(337, 244)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Descripción"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(939, 243)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 13)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Precio Unitario"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(863, 480)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "Subtotal"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(884, 506)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 13)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "IGV"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(878, 532)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "Total"
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(1074, 264)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 10
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(1074, 323)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 12
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(1074, 294)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 11
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(456, 482)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(203, 61)
        Me.btnImprimir.TabIndex = 44
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1039, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(245, 25)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "R.U.C. : 20519804427"
        '
        'lbFactura
        '
        Me.lbFactura.AutoSize = True
        Me.lbFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFactura.ForeColor = System.Drawing.Color.DarkRed
        Me.lbFactura.Location = New System.Drawing.Point(1007, 93)
        Me.lbFactura.Name = "lbFactura"
        Me.lbFactura.Size = New System.Drawing.Size(132, 20)
        Me.lbFactura.TabIndex = 1
        Me.lbFactura.Text = "NRO FACTURA: "
        '
        'txtNroSerie
        '
        Me.txtNroSerie.Location = New System.Drawing.Point(1145, 93)
        Me.txtNroSerie.Name = "txtNroSerie"
        Me.txtNroSerie.Size = New System.Drawing.Size(48, 20)
        Me.txtNroSerie.TabIndex = 5
        '
        'lbNroFactura
        '
        Me.lbNroFactura.AutoSize = True
        Me.lbNroFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNroFactura.ForeColor = System.Drawing.Color.DarkRed
        Me.lbNroFactura.Location = New System.Drawing.Point(1199, 93)
        Me.lbNroFactura.Name = "lbNroFactura"
        Me.lbNroFactura.Size = New System.Drawing.Size(0, 20)
        Me.lbNroFactura.TabIndex = 3
        '
        'btnGuardarCabecera
        '
        Me.btnGuardarCabecera.Location = New System.Drawing.Point(1089, 119)
        Me.btnGuardarCabecera.Name = "btnGuardarCabecera"
        Me.btnGuardarCabecera.Size = New System.Drawing.Size(141, 23)
        Me.btnGuardarCabecera.TabIndex = 6
        Me.btnGuardarCabecera.Text = "Guardar Datos"
        Me.btnGuardarCabecera.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chbxCompromiso)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.dtpCompromiso)
        Me.GroupBox1.Controls.Add(Me.chbxPago)
        Me.GroupBox1.Controls.Add(Me.chbxVencimiento)
        Me.GroupBox1.Controls.Add(Me.chbxRecepcion)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.dtpPago)
        Me.GroupBox1.Controls.Add(Me.dtpVencimiento)
        Me.GroupBox1.Controls.Add(Me.dtpRecepcion)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 152)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(780, 53)
        Me.GroupBox1.TabIndex = 1039
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fechas"
        '
        'chbxCompromiso
        '
        Me.chbxCompromiso.AutoSize = True
        Me.chbxCompromiso.Location = New System.Drawing.Point(754, 26)
        Me.chbxCompromiso.Name = "chbxCompromiso"
        Me.chbxCompromiso.Size = New System.Drawing.Size(15, 14)
        Me.chbxCompromiso.TabIndex = 1046
        Me.chbxCompromiso.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(575, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 13)
        Me.Label17.TabIndex = 1045
        Me.Label17.Text = "Compromiso"
        '
        'dtpCompromiso
        '
        Me.dtpCompromiso.Enabled = False
        Me.dtpCompromiso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCompromiso.Location = New System.Drawing.Point(651, 23)
        Me.dtpCompromiso.Name = "dtpCompromiso"
        Me.dtpCompromiso.Size = New System.Drawing.Size(97, 20)
        Me.dtpCompromiso.TabIndex = 1044
        '
        'chbxPago
        '
        Me.chbxPago.AutoSize = True
        Me.chbxPago.Location = New System.Drawing.Point(543, 26)
        Me.chbxPago.Name = "chbxPago"
        Me.chbxPago.Size = New System.Drawing.Size(15, 14)
        Me.chbxPago.TabIndex = 1040
        Me.chbxPago.UseVisualStyleBackColor = True
        '
        'chbxVencimiento
        '
        Me.chbxVencimiento.AutoSize = True
        Me.chbxVencimiento.Location = New System.Drawing.Point(372, 26)
        Me.chbxVencimiento.Name = "chbxVencimiento"
        Me.chbxVencimiento.Size = New System.Drawing.Size(15, 14)
        Me.chbxVencimiento.TabIndex = 1040
        Me.chbxVencimiento.UseVisualStyleBackColor = True
        '
        'chbxRecepcion
        '
        Me.chbxRecepcion.AutoSize = True
        Me.chbxRecepcion.Location = New System.Drawing.Point(173, 26)
        Me.chbxRecepcion.Name = "chbxRecepcion"
        Me.chbxRecepcion.Size = New System.Drawing.Size(15, 14)
        Me.chbxRecepcion.TabIndex = 1039
        Me.chbxRecepcion.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(402, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Pago"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(198, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Vencimiento"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Recepción"
        '
        'dtpPago
        '
        Me.dtpPago.Enabled = False
        Me.dtpPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPago.Location = New System.Drawing.Point(440, 23)
        Me.dtpPago.Name = "dtpPago"
        Me.dtpPago.Size = New System.Drawing.Size(97, 20)
        Me.dtpPago.TabIndex = 2
        '
        'dtpVencimiento
        '
        Me.dtpVencimiento.Enabled = False
        Me.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVencimiento.Location = New System.Drawing.Point(269, 23)
        Me.dtpVencimiento.Name = "dtpVencimiento"
        Me.dtpVencimiento.Size = New System.Drawing.Size(97, 20)
        Me.dtpVencimiento.TabIndex = 1
        '
        'dtpRecepcion
        '
        Me.dtpRecepcion.Enabled = False
        Me.dtpRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRecepcion.Location = New System.Drawing.Point(72, 23)
        Me.dtpRecepcion.Name = "dtpRecepcion"
        Me.dtpRecepcion.Size = New System.Drawing.Size(97, 20)
        Me.dtpRecepcion.TabIndex = 0
        '
        'txtCodigoDetalle
        '
        Me.txtCodigoDetalle.Location = New System.Drawing.Point(131, 264)
        Me.txtCodigoDetalle.Name = "txtCodigoDetalle"
        Me.txtCodigoDetalle.Size = New System.Drawing.Size(46, 20)
        Me.txtCodigoDetalle.TabIndex = 1040
        Me.txtCodigoDetalle.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtMontoDetraccion)
        Me.GroupBox2.Controls.Add(Me.txtPorcentajeDetraccion)
        Me.GroupBox2.Location = New System.Drawing.Point(819, 152)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(330, 53)
        Me.GroupBox2.TabIndex = 1041
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detracción"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(186, 26)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(37, 13)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "Monto"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(14, 25)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Porcentaje"
        '
        'txtMontoDetraccion
        '
        Me.txtMontoDetraccion.Location = New System.Drawing.Point(230, 22)
        Me.txtMontoDetraccion.Name = "txtMontoDetraccion"
        Me.txtMontoDetraccion.ReadOnly = True
        Me.txtMontoDetraccion.Size = New System.Drawing.Size(77, 20)
        Me.txtMontoDetraccion.TabIndex = 1
        '
        'txtPorcentajeDetraccion
        '
        Me.txtPorcentajeDetraccion.Location = New System.Drawing.Point(85, 23)
        Me.txtPorcentajeDetraccion.Name = "txtPorcentajeDetraccion"
        Me.txtPorcentajeDetraccion.Size = New System.Drawing.Size(77, 20)
        Me.txtPorcentajeDetraccion.TabIndex = 0
        '
        'ChildFacturaLibre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1321, 581)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtCodigoDetalle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnGuardarCabecera)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.lbNroFactura)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.txtNroSerie)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.lbFactura)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtIGV)
        Me.Controls.Add(Me.txtSubtotal)
        Me.Controls.Add(Me.txtPrecioUnitario)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.btnRazonSocial)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbMoneda)
        Me.Controls.Add(Me.txtRUC)
        Me.Controls.Add(Me.dtFecha)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.cbRazonSocial)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Name = "ChildFacturaLibre"
        Me.Text = "ChildFacturaLibre"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvDetalle As DataGridView
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtPrecioUnitario As TextBox
    Friend WithEvents txtSubtotal As TextBox
    Friend WithEvents txtIGV As TextBox
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents btnGrabar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents btnGuardarCabecera As Button
    Friend WithEvents lbNroFactura As Label
    Friend WithEvents txtNroSerie As TextBox
    Friend WithEvents lbFactura As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chbxPago As CheckBox
    Friend WithEvents chbxVencimiento As CheckBox
    Friend WithEvents chbxRecepcion As CheckBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents dtpPago As DateTimePicker
    Friend WithEvents dtpVencimiento As DateTimePicker
    Friend WithEvents dtpRecepcion As DateTimePicker
    Friend WithEvents txtCodigoDetalle As TextBox
    Friend WithEvents chbxCompromiso As CheckBox
    Friend WithEvents Label17 As Label
    Friend WithEvents dtpCompromiso As DateTimePicker
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtMontoDetraccion As TextBox
    Friend WithEvents txtPorcentajeDetraccion As TextBox
End Class
