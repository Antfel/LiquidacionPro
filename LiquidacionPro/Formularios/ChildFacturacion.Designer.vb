<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChildFacturacion
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbNroFactura = New System.Windows.Forms.Label()
        Me.txtNroSerie = New System.Windows.Forms.TextBox()
        Me.lbFactura = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbRazonSocial = New System.Windows.Forms.ComboBox()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtRUC = New System.Windows.Forms.TextBox()
        Me.cbMoneda = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtDescripcionDetalle = New System.Windows.Forms.TextBox()
        Me.cbTipoServicio = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbAccionGuia = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnAgregarTransportista = New System.Windows.Forms.Button()
        Me.btnEliminarTransportista = New System.Windows.Forms.Button()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.cbGuia = New System.Windows.Forms.ComboBox()
        Me.tbTransportista = New System.Windows.Forms.DataGridView()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.tbRemitente = New System.Windows.Forms.DataGridView()
        Me.txtRemitente = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnAgregarRemitente = New System.Windows.Forms.Button()
        Me.btnEliminarRemitente = New System.Windows.Forms.Button()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.tbPlaca = New System.Windows.Forms.DataGridView()
        Me.cbTracto = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnAgregarPlaca = New System.Windows.Forms.Button()
        Me.btnEliminarPlaca = New System.Windows.Forms.Button()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.txtPrecioUnitario = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Panel27 = New System.Windows.Forms.Panel()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel28 = New System.Windows.Forms.Panel()
        Me.txtValorReferencial = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Panel29 = New System.Windows.Forms.Panel()
        Me.txtConfVehicular = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Panel30 = New System.Windows.Forms.Panel()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnRazonSocial = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPrecioFactura = New System.Windows.Forms.TextBox()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGuardarCabecera = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel14.SuspendLayout()
        CType(Me.tbTransportista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel15.SuspendLayout()
        CType(Me.tbRemitente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel16.SuspendLayout()
        CType(Me.tbPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel25.SuspendLayout()
        Me.Panel26.SuspendLayout()
        Me.Panel27.SuspendLayout()
        Me.Panel28.SuspendLayout()
        Me.Panel29.SuspendLayout()
        Me.Panel24.SuspendLayout()
        Me.Panel30.SuspendLayout()
        Me.Panel23.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(44, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Direccion"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(757, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(748, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Moneda"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(554, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "RUC"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(535, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Telefono"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnGuardarCabecera)
        Me.Panel1.Controls.Add(Me.lbNroFactura)
        Me.Panel1.Controls.Add(Me.txtNroSerie)
        Me.Panel1.Controls.Add(Me.lbFactura)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(965, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(317, 146)
        Me.Panel1.TabIndex = 7
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
        'cbRazonSocial
        '
        Me.cbRazonSocial.FormattingEnabled = True
        Me.cbRazonSocial.Location = New System.Drawing.Point(129, 83)
        Me.cbRazonSocial.Name = "cbRazonSocial"
        Me.cbRazonSocial.Size = New System.Drawing.Size(400, 21)
        Me.cbRazonSocial.TabIndex = 1
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(590, 123)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(142, 20)
        Me.txtTelefono.TabIndex = 9
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(129, 126)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(400, 20)
        Me.txtDireccion.TabIndex = 10
        '
        'dtFecha
        '
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha.Location = New System.Drawing.Point(800, 83)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(143, 20)
        Me.dtFecha.TabIndex = 3
        '
        'txtRUC
        '
        Me.txtRUC.Location = New System.Drawing.Point(590, 83)
        Me.txtRUC.Name = "txtRUC"
        Me.txtRUC.Size = New System.Drawing.Size(142, 20)
        Me.txtRUC.TabIndex = 12
        '
        'cbMoneda
        '
        Me.cbMoneda.FormattingEnabled = True
        Me.cbMoneda.Location = New System.Drawing.Point(800, 121)
        Me.cbMoneda.Name = "cbMoneda"
        Me.cbMoneda.Size = New System.Drawing.Size(143, 21)
        Me.cbMoneda.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(399, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(334, 33)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Generación de Factura"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel2.Location = New System.Drawing.Point(29, 164)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1253, 3)
        Me.Panel2.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(643, 179)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(151, 13)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "SEGUN GUIA DE REMISION:"
        '
        'txtDescripcionDetalle
        '
        Me.txtDescripcionDetalle.Location = New System.Drawing.Point(494, 176)
        Me.txtDescripcionDetalle.Name = "txtDescripcionDetalle"
        Me.txtDescripcionDetalle.Size = New System.Drawing.Size(143, 20)
        Me.txtDescripcionDetalle.TabIndex = 19
        '
        'cbTipoServicio
        '
        Me.cbTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoServicio.FormattingEnabled = True
        Me.cbTipoServicio.Location = New System.Drawing.Point(295, 176)
        Me.cbTipoServicio.Name = "cbTipoServicio"
        Me.cbTipoServicio.Size = New System.Drawing.Size(170, 21)
        Me.cbTipoServicio.TabIndex = 18
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(183, 179)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(106, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "TIPO DE SERVICIO:"
        '
        'cbAccionGuia
        '
        Me.cbAccionGuia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAccionGuia.FormattingEnabled = True
        Me.cbAccionGuia.Location = New System.Drawing.Point(60, 176)
        Me.cbAccionGuia.Name = "cbAccionGuia"
        Me.cbAccionGuia.Size = New System.Drawing.Size(102, 21)
        Me.cbAccionGuia.TabIndex = 16
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 10)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "TRANSPORTISTA"
        '
        'btnAgregarTransportista
        '
        Me.btnAgregarTransportista.Location = New System.Drawing.Point(196, 64)
        Me.btnAgregarTransportista.Name = "btnAgregarTransportista"
        Me.btnAgregarTransportista.Size = New System.Drawing.Size(23, 23)
        Me.btnAgregarTransportista.TabIndex = 12
        Me.btnAgregarTransportista.Text = "+"
        Me.btnAgregarTransportista.UseVisualStyleBackColor = True
        '
        'btnEliminarTransportista
        '
        Me.btnEliminarTransportista.Location = New System.Drawing.Point(196, 93)
        Me.btnEliminarTransportista.Name = "btnEliminarTransportista"
        Me.btnEliminarTransportista.Size = New System.Drawing.Size(23, 23)
        Me.btnEliminarTransportista.TabIndex = 8
        Me.btnEliminarTransportista.Text = "-"
        Me.btnEliminarTransportista.UseVisualStyleBackColor = True
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.cbGuia)
        Me.Panel14.Controls.Add(Me.tbTransportista)
        Me.Panel14.Controls.Add(Me.Label16)
        Me.Panel14.Controls.Add(Me.btnAgregarTransportista)
        Me.Panel14.Controls.Add(Me.btnEliminarTransportista)
        Me.Panel14.Location = New System.Drawing.Point(64, 205)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(235, 161)
        Me.Panel14.TabIndex = 21
        '
        'cbGuia
        '
        Me.cbGuia.FormattingEnabled = True
        Me.cbGuia.Location = New System.Drawing.Point(119, 7)
        Me.cbGuia.Name = "cbGuia"
        Me.cbGuia.Size = New System.Drawing.Size(100, 21)
        Me.cbGuia.TabIndex = 11
        '
        'tbTransportista
        '
        Me.tbTransportista.AllowUserToAddRows = False
        Me.tbTransportista.AllowUserToDeleteRows = False
        Me.tbTransportista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.tbTransportista.ColumnHeadersVisible = False
        Me.tbTransportista.Location = New System.Drawing.Point(17, 37)
        Me.tbTransportista.MultiSelect = False
        Me.tbTransportista.Name = "tbTransportista"
        Me.tbTransportista.ReadOnly = True
        Me.tbTransportista.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbTransportista.RowHeadersVisible = False
        Me.tbTransportista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tbTransportista.Size = New System.Drawing.Size(173, 108)
        Me.tbTransportista.TabIndex = 10
        '
        'Panel15
        '
        Me.Panel15.Controls.Add(Me.tbRemitente)
        Me.Panel15.Controls.Add(Me.txtRemitente)
        Me.Panel15.Controls.Add(Me.Label17)
        Me.Panel15.Controls.Add(Me.btnAgregarRemitente)
        Me.Panel15.Controls.Add(Me.btnEliminarRemitente)
        Me.Panel15.Location = New System.Drawing.Point(324, 205)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(238, 161)
        Me.Panel15.TabIndex = 22
        '
        'tbRemitente
        '
        Me.tbRemitente.AllowUserToAddRows = False
        Me.tbRemitente.AllowUserToDeleteRows = False
        Me.tbRemitente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tbRemitente.ColumnHeadersVisible = False
        Me.tbRemitente.Location = New System.Drawing.Point(17, 37)
        Me.tbRemitente.MultiSelect = False
        Me.tbRemitente.Name = "tbRemitente"
        Me.tbRemitente.RowHeadersVisible = False
        Me.tbRemitente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tbRemitente.Size = New System.Drawing.Size(176, 108)
        Me.tbRemitente.TabIndex = 10
        '
        'txtRemitente
        '
        Me.txtRemitente.Location = New System.Drawing.Point(138, 7)
        Me.txtRemitente.Name = "txtRemitente"
        Me.txtRemitente.Size = New System.Drawing.Size(84, 20)
        Me.txtRemitente.TabIndex = 9
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(14, 10)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "REMITENTE"
        '
        'btnAgregarRemitente
        '
        Me.btnAgregarRemitente.Location = New System.Drawing.Point(199, 64)
        Me.btnAgregarRemitente.Name = "btnAgregarRemitente"
        Me.btnAgregarRemitente.Size = New System.Drawing.Size(23, 23)
        Me.btnAgregarRemitente.TabIndex = 7
        Me.btnAgregarRemitente.Text = "+"
        Me.btnAgregarRemitente.UseVisualStyleBackColor = True
        '
        'btnEliminarRemitente
        '
        Me.btnEliminarRemitente.Location = New System.Drawing.Point(199, 93)
        Me.btnEliminarRemitente.Name = "btnEliminarRemitente"
        Me.btnEliminarRemitente.Size = New System.Drawing.Size(23, 23)
        Me.btnEliminarRemitente.TabIndex = 8
        Me.btnEliminarRemitente.Text = "-"
        Me.btnEliminarRemitente.UseVisualStyleBackColor = True
        '
        'Panel16
        '
        Me.Panel16.Controls.Add(Me.tbPlaca)
        Me.Panel16.Controls.Add(Me.cbTracto)
        Me.Panel16.Controls.Add(Me.Label18)
        Me.Panel16.Controls.Add(Me.btnAgregarPlaca)
        Me.Panel16.Controls.Add(Me.btnEliminarPlaca)
        Me.Panel16.Location = New System.Drawing.Point(589, 205)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(222, 161)
        Me.Panel16.TabIndex = 23
        '
        'tbPlaca
        '
        Me.tbPlaca.AllowUserToAddRows = False
        Me.tbPlaca.AllowUserToDeleteRows = False
        Me.tbPlaca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tbPlaca.ColumnHeadersVisible = False
        Me.tbPlaca.Location = New System.Drawing.Point(17, 37)
        Me.tbPlaca.MultiSelect = False
        Me.tbPlaca.Name = "tbPlaca"
        Me.tbPlaca.RowHeadersVisible = False
        Me.tbPlaca.Size = New System.Drawing.Size(156, 108)
        Me.tbPlaca.TabIndex = 10
        '
        'cbTracto
        '
        Me.cbTracto.FormattingEnabled = True
        Me.cbTracto.Location = New System.Drawing.Point(84, 7)
        Me.cbTracto.Name = "cbTracto"
        Me.cbTracto.Size = New System.Drawing.Size(121, 21)
        Me.cbTracto.TabIndex = 9
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(14, 10)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 13)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "PLACA"
        '
        'btnAgregarPlaca
        '
        Me.btnAgregarPlaca.Location = New System.Drawing.Point(179, 64)
        Me.btnAgregarPlaca.Name = "btnAgregarPlaca"
        Me.btnAgregarPlaca.Size = New System.Drawing.Size(23, 23)
        Me.btnAgregarPlaca.TabIndex = 7
        Me.btnAgregarPlaca.Text = "+"
        Me.btnAgregarPlaca.UseVisualStyleBackColor = True
        '
        'btnEliminarPlaca
        '
        Me.btnEliminarPlaca.Location = New System.Drawing.Point(179, 93)
        Me.btnEliminarPlaca.Name = "btnEliminarPlaca"
        Me.btnEliminarPlaca.Size = New System.Drawing.Size(23, 23)
        Me.btnEliminarPlaca.TabIndex = 8
        Me.btnEliminarPlaca.Text = "-"
        Me.btnEliminarPlaca.UseVisualStyleBackColor = True
        '
        'Panel25
        '
        Me.Panel25.Controls.Add(Me.Panel26)
        Me.Panel25.Controls.Add(Me.Panel27)
        Me.Panel25.Controls.Add(Me.Panel28)
        Me.Panel25.Controls.Add(Me.Panel29)
        Me.Panel25.Controls.Add(Me.Panel24)
        Me.Panel25.Controls.Add(Me.Panel30)
        Me.Panel25.Controls.Add(Me.Panel23)
        Me.Panel25.Location = New System.Drawing.Point(817, 205)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(465, 133)
        Me.Panel25.TabIndex = 26
        '
        'Panel26
        '
        Me.Panel26.Controls.Add(Me.txtPrecioUnitario)
        Me.Panel26.Controls.Add(Me.Label26)
        Me.Panel26.Location = New System.Drawing.Point(280, 13)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Size = New System.Drawing.Size(88, 48)
        Me.Panel26.TabIndex = 29
        '
        'txtPrecioUnitario
        '
        Me.txtPrecioUnitario.Location = New System.Drawing.Point(6, 23)
        Me.txtPrecioUnitario.Name = "txtPrecioUnitario"
        Me.txtPrecioUnitario.Size = New System.Drawing.Size(77, 20)
        Me.txtPrecioUnitario.TabIndex = 41
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(6, 5)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(64, 13)
        Me.Label26.TabIndex = 40
        Me.Label26.Text = "PRE. UNIT."
        '
        'Panel27
        '
        Me.Panel27.Controls.Add(Me.txtObservaciones)
        Me.Panel27.Controls.Add(Me.Label27)
        Me.Panel27.Location = New System.Drawing.Point(16, 71)
        Me.Panel27.Name = "Panel27"
        Me.Panel27.Size = New System.Drawing.Size(352, 48)
        Me.Panel27.TabIndex = 28
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(6, 23)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(341, 20)
        Me.txtObservaciones.TabIndex = 39
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(3, 5)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(84, 13)
        Me.Label27.TabIndex = 38
        Me.Label27.Text = "OBSERVACION"
        '
        'Panel28
        '
        Me.Panel28.Controls.Add(Me.txtValorReferencial)
        Me.Panel28.Controls.Add(Me.Label28)
        Me.Panel28.Location = New System.Drawing.Point(186, 13)
        Me.Panel28.Name = "Panel28"
        Me.Panel28.Size = New System.Drawing.Size(88, 48)
        Me.Panel28.TabIndex = 27
        '
        'txtValorReferencial
        '
        Me.txtValorReferencial.Location = New System.Drawing.Point(6, 23)
        Me.txtValorReferencial.Name = "txtValorReferencial"
        Me.txtValorReferencial.Size = New System.Drawing.Size(77, 20)
        Me.txtValorReferencial.TabIndex = 37
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 5)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(57, 13)
        Me.Label28.TabIndex = 36
        Me.Label28.Text = "VAL. REF."
        '
        'Panel29
        '
        Me.Panel29.Controls.Add(Me.txtConfVehicular)
        Me.Panel29.Controls.Add(Me.Label29)
        Me.Panel29.Location = New System.Drawing.Point(89, 13)
        Me.Panel29.Name = "Panel29"
        Me.Panel29.Size = New System.Drawing.Size(91, 48)
        Me.Panel29.TabIndex = 26
        '
        'txtConfVehicular
        '
        Me.txtConfVehicular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConfVehicular.Location = New System.Drawing.Point(8, 23)
        Me.txtConfVehicular.Name = "txtConfVehicular"
        Me.txtConfVehicular.Size = New System.Drawing.Size(77, 20)
        Me.txtConfVehicular.TabIndex = 35
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(5, 5)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(67, 13)
        Me.Label29.TabIndex = 34
        Me.Label29.Text = "CONF. VEH."
        '
        'Panel24
        '
        Me.Panel24.Controls.Add(Me.txtDestino)
        Me.Panel24.Controls.Add(Me.Label25)
        Me.Panel24.Location = New System.Drawing.Point(374, 71)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(88, 48)
        Me.Panel24.TabIndex = 46
        '
        'txtDestino
        '
        Me.txtDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDestino.Location = New System.Drawing.Point(6, 23)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(77, 20)
        Me.txtDestino.TabIndex = 43
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(3, 7)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(55, 13)
        Me.Label25.TabIndex = 42
        Me.Label25.Text = "DESTINO"
        '
        'Panel30
        '
        Me.Panel30.Controls.Add(Me.txtCantidad)
        Me.Panel30.Controls.Add(Me.Label30)
        Me.Panel30.Location = New System.Drawing.Point(16, 13)
        Me.Panel30.Name = "Panel30"
        Me.Panel30.Size = New System.Drawing.Size(67, 48)
        Me.Panel30.TabIndex = 25
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(6, 23)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(54, 20)
        Me.txtCantidad.TabIndex = 33
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(3, 5)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(62, 13)
        Me.Label30.TabIndex = 32
        Me.Label30.Text = "CANTIDAD"
        '
        'Panel23
        '
        Me.Panel23.Controls.Add(Me.txtOrigen)
        Me.Panel23.Controls.Add(Me.Label24)
        Me.Panel23.Location = New System.Drawing.Point(374, 13)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(88, 48)
        Me.Panel23.TabIndex = 45
        '
        'txtOrigen
        '
        Me.txtOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrigen.Location = New System.Drawing.Point(3, 23)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(80, 20)
        Me.txtOrigen.TabIndex = 43
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(3, 5)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(49, 13)
        Me.Label24.TabIndex = 42
        Me.Label24.Text = "ORIGEN"
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(849, 344)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(119, 35)
        Me.btnActualizar.TabIndex = 47
        Me.btnActualizar.Text = "ACTUALIZAR"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(523, 405)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(143, 37)
        Me.btnImprimir.TabIndex = 48
        Me.btnImprimir.Text = "IMPRIMIR"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnRazonSocial
        '
        Me.btnRazonSocial.Location = New System.Drawing.Point(25, 83)
        Me.btnRazonSocial.Name = "btnRazonSocial"
        Me.btnRazonSocial.Size = New System.Drawing.Size(98, 21)
        Me.btnRazonSocial.TabIndex = 2
        Me.btnRazonSocial.Text = "Razon Social"
        Me.btnRazonSocial.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 417)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Total de Factura"
        '
        'txtPrecioFactura
        '
        Me.txtPrecioFactura.Location = New System.Drawing.Point(135, 414)
        Me.txtPrecioFactura.Name = "txtPrecioFactura"
        Me.txtPrecioFactura.ReadOnly = True
        Me.txtPrecioFactura.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecioFactura.TabIndex = 51
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(981, 344)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(126, 35)
        Me.btnNuevo.TabIndex = 52
        Me.btnNuevo.Text = "NUEVO"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(1122, 344)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(126, 35)
        Me.btnEliminar.TabIndex = 53
        Me.btnEliminar.Text = "ELIMINAR"
        Me.btnEliminar.UseVisualStyleBackColor = True
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
        'ChildFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1321, 524)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.txtPrecioFactura)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnRazonSocial)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.Panel25)
        Me.Controls.Add(Me.Panel16)
        Me.Controls.Add(Me.Panel15)
        Me.Controls.Add(Me.Panel14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtDescripcionDetalle)
        Me.Controls.Add(Me.cbTipoServicio)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cbAccionGuia)
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
        Me.Name = "ChildFacturacion"
        Me.Text = "Facturación"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        CType(Me.tbTransportista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        CType(Me.tbRemitente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        CType(Me.tbPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel25.ResumeLayout(False)
        Me.Panel26.ResumeLayout(False)
        Me.Panel26.PerformLayout()
        Me.Panel27.ResumeLayout(False)
        Me.Panel27.PerformLayout()
        Me.Panel28.ResumeLayout(False)
        Me.Panel28.PerformLayout()
        Me.Panel29.ResumeLayout(False)
        Me.Panel29.PerformLayout()
        Me.Panel24.ResumeLayout(False)
        Me.Panel24.PerformLayout()
        Me.Panel30.ResumeLayout(False)
        Me.Panel30.PerformLayout()
        Me.Panel23.ResumeLayout(False)
        Me.Panel23.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lbFactura As Label
    Friend WithEvents cbRazonSocial As ComboBox
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents dtFecha As DateTimePicker
    Friend WithEvents txtRUC As TextBox
    Friend WithEvents cbMoneda As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents txtDescripcionDetalle As TextBox
    Friend WithEvents cbTipoServicio As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cbAccionGuia As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents btnAgregarTransportista As Button
    Friend WithEvents btnEliminarTransportista As Button
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents lbRemitente As ListBox
    Friend WithEvents btnAgregarRemitente As Button
    Friend WithEvents btnEliminarRemitente As Button
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents btnAgregarPlaca As Button
    Friend WithEvents btnEliminarPlaca As Button
    Friend WithEvents Panel25 As Panel
    Friend WithEvents Panel26 As Panel
    Friend WithEvents txtPrecioUnitario As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Panel27 As Panel
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Panel28 As Panel
    Friend WithEvents txtValorReferencial As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Panel29 As Panel
    Friend WithEvents txtConfVehicular As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Panel30 As Panel
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Panel24 As Panel
    Friend WithEvents txtDestino As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Panel23 As Panel
    Friend WithEvents txtOrigen As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents tbTransportista As DataGridView
    Friend WithEvents btnRazonSocial As Button
    Friend WithEvents cbTracto As ComboBox
    Friend WithEvents cbGuia As ComboBox
    Friend WithEvents txtRemitente As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPrecioFactura As TextBox
    Friend WithEvents tbRemitente As DataGridView
    Friend WithEvents tbPlaca As DataGridView
    Friend WithEvents lbNroFactura As Label
    Friend WithEvents txtNroSerie As TextBox
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnGuardarCabecera As Button
End Class
