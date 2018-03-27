<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChildLiquidacionControl
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.cbGuia = New System.Windows.Forms.ComboBox()
        Me.cbCamabaja = New System.Windows.Forms.ComboBox()
        Me.cbTracto = New System.Windows.Forms.ComboBox()
        Me.cbTrabajador = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cbEstado = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtDinero = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNroLiquidacion = New System.Windows.Forms.TextBox()
        Me.txtCodigoLiquidacion = New System.Windows.Forms.TextBox()
        Me.dgvLiquidacion = New System.Windows.Forms.DataGridView()
        Me.btnAgregarLiquidacion = New System.Windows.Forms.Button()
        Me.txtCombustibleVirtual = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dtpLlegada = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dtpSalida = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCombustibleFisico = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtOtros = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBalanza = New System.Windows.Forms.TextBox()
        Me.txtHospedaje = New System.Windows.Forms.TextBox()
        Me.txtGuardiania = New System.Windows.Forms.TextBox()
        Me.txtViaticos = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPeajes = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalGasto = New System.Windows.Forms.TextBox()
        Me.txtDiferencia = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtDiferenciaComb = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.btnDeshacer = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblFiltro = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gbPeajes = New System.Windows.Forms.GroupBox()
        Me.btnNuevoPeaje = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtNroLineaPeaje = New System.Windows.Forms.TextBox()
        Me.txtCodigoPeaje = New System.Windows.Forms.TextBox()
        Me.btnInsertarDebajoPeaje = New System.Windows.Forms.Button()
        Me.txtCodigoLiquidacionPeaje = New System.Windows.Forms.TextBox()
        Me.btnInsertarArribaPeaje = New System.Windows.Forms.Button()
        Me.btnEliminarPeaje = New System.Windows.Forms.Button()
        Me.btnAgregarPeaje = New System.Windows.Forms.Button()
        Me.dgvPeajes = New System.Windows.Forms.DataGridView()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtTotalPeaje = New System.Windows.Forms.TextBox()
        Me.txtEjesPeaje = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtLugarPeaje = New System.Windows.Forms.TextBox()
        Me.dtpFechaHoraPeaje = New System.Windows.Forms.DateTimePicker()
        Me.gbViaticos = New System.Windows.Forms.GroupBox()
        Me.btnNuevoViatico = New System.Windows.Forms.Button()
        Me.btnInsertarAbajoViatico = New System.Windows.Forms.Button()
        Me.btnInsertarArribaViatico = New System.Windows.Forms.Button()
        Me.txtNroLineaViatico = New System.Windows.Forms.TextBox()
        Me.btnEliminarViatico = New System.Windows.Forms.Button()
        Me.txtCodigoViatico = New System.Windows.Forms.TextBox()
        Me.btnAgregarViatico = New System.Windows.Forms.Button()
        Me.txtCodigoLiquidacionViatico = New System.Windows.Forms.TextBox()
        Me.dgvViaticos = New System.Windows.Forms.DataGridView()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtTotalViatico = New System.Windows.Forms.TextBox()
        Me.txtDescripcionViatico = New System.Windows.Forms.TextBox()
        Me.dtpTurnoViaticos = New System.Windows.Forms.DateTimePicker()
        Me.txtCantidadViatico = New System.Windows.Forms.TextBox()
        Me.gbOtros = New System.Windows.Forms.GroupBox()
        Me.btnInsertarAbajoOtro = New System.Windows.Forms.Button()
        Me.txtNroLineaOtro = New System.Windows.Forms.TextBox()
        Me.btnInsertarArribaOtro = New System.Windows.Forms.Button()
        Me.btnEliminarOtros = New System.Windows.Forms.Button()
        Me.btnNuevoOtro = New System.Windows.Forms.Button()
        Me.txtCodigoOtro = New System.Windows.Forms.TextBox()
        Me.btnAgregarOtros = New System.Windows.Forms.Button()
        Me.txtCodigoLiquidacionOtro = New System.Windows.Forms.TextBox()
        Me.dgvOtros = New System.Windows.Forms.DataGridView()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtTotalOtros = New System.Windows.Forms.TextBox()
        Me.txtDescripcionOtros = New System.Windows.Forms.TextBox()
        Me.btnRptLiquidacion = New System.Windows.Forms.Button()
        Me.btnRptLiquidacionDetallado = New System.Windows.Forms.Button()
        Me.txtCarga = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cbUnidadMedida = New System.Windows.Forms.ComboBox()
        Me.btnRptLiquidacionCombustible = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnNuevoBalanza = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNroLineaBalanza = New System.Windows.Forms.TextBox()
        Me.txtCodigoBalanza = New System.Windows.Forms.TextBox()
        Me.btnInsertarAbajoBalanza = New System.Windows.Forms.Button()
        Me.txtCodigoLiquidacionBalanza = New System.Windows.Forms.TextBox()
        Me.btnInsertarArribaBalanza = New System.Windows.Forms.Button()
        Me.btnEliminarBalanza = New System.Windows.Forms.Button()
        Me.btnAgregarBalanza = New System.Windows.Forms.Button()
        Me.dgvBalanza = New System.Windows.Forms.DataGridView()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTotalBalanza = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtDescripcionBalanza = New System.Windows.Forms.TextBox()
        Me.dtpBalanza = New System.Windows.Forms.DateTimePicker()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnNuevoGuardiania = New System.Windows.Forms.Button()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtNroLineaGuardiania = New System.Windows.Forms.TextBox()
        Me.txtCodigoGuardiania = New System.Windows.Forms.TextBox()
        Me.btnInsertarAbajoGuardiania = New System.Windows.Forms.Button()
        Me.txtCodigoLiquidacionGuardiania = New System.Windows.Forms.TextBox()
        Me.btnInsertarArribaGuardiania = New System.Windows.Forms.Button()
        Me.btnEliminarGuardiania = New System.Windows.Forms.Button()
        Me.btnAgregarGuardiania = New System.Windows.Forms.Button()
        Me.dgvGuardiania = New System.Windows.Forms.DataGridView()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtTotalGuardiania = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtDescripcionGuardiania = New System.Windows.Forms.TextBox()
        Me.dtpGuardiania = New System.Windows.Forms.DateTimePicker()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnNuevoHospedaje = New System.Windows.Forms.Button()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtNroLineaHospedaje = New System.Windows.Forms.TextBox()
        Me.txtCodigoHospedaje = New System.Windows.Forms.TextBox()
        Me.btnInsertarAbajoHospedaje = New System.Windows.Forms.Button()
        Me.txtCodigoLiquidacionHospedaje = New System.Windows.Forms.TextBox()
        Me.btnInsertarArribaHospedaje = New System.Windows.Forms.Button()
        Me.btnEliminarHospedaje = New System.Windows.Forms.Button()
        Me.btnAgregarHospedaje = New System.Windows.Forms.Button()
        Me.dgvHospedaje = New System.Windows.Forms.DataGridView()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtTotalHospedaje = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtDescripcionHospedaje = New System.Windows.Forms.TextBox()
        Me.dtpHospedaje = New System.Windows.Forms.DateTimePicker()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtVuelto = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        CType(Me.dgvLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbPeajes.SuspendLayout()
        CType(Me.dgvPeajes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbViaticos.SuspendLayout()
        CType(Me.dgvViaticos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOtros.SuspendLayout()
        CType(Me.dgvOtros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvBalanza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvGuardiania, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvHospedaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(1002, 70)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(132, 34)
        Me.btnNuevo.TabIndex = 88
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'cbGuia
        '
        Me.cbGuia.FormattingEnabled = True
        Me.cbGuia.Location = New System.Drawing.Point(129, 36)
        Me.cbGuia.Name = "cbGuia"
        Me.cbGuia.Size = New System.Drawing.Size(81, 21)
        Me.cbGuia.TabIndex = 51
        '
        'cbCamabaja
        '
        Me.cbCamabaja.FormattingEnabled = True
        Me.cbCamabaja.Location = New System.Drawing.Point(340, 60)
        Me.cbCamabaja.Name = "cbCamabaja"
        Me.cbCamabaja.Size = New System.Drawing.Size(100, 21)
        Me.cbCamabaja.TabIndex = 59
        '
        'cbTracto
        '
        Me.cbTracto.FormattingEnabled = True
        Me.cbTracto.Location = New System.Drawing.Point(340, 36)
        Me.cbTracto.Name = "cbTracto"
        Me.cbTracto.Size = New System.Drawing.Size(100, 21)
        Me.cbTracto.TabIndex = 53
        '
        'cbTrabajador
        '
        Me.cbTrabajador.FormattingEnabled = True
        Me.cbTrabajador.Location = New System.Drawing.Point(564, 12)
        Me.cbTrabajador.Name = "cbTrabajador"
        Me.cbTrabajador.Size = New System.Drawing.Size(305, 21)
        Me.cbTrabajador.TabIndex = 50
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(29, 372)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 13)
        Me.Label20.TabIndex = 87
        Me.Label20.Text = "Estado"
        '
        'cbEstado
        '
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.ItemHeight = 13
        Me.cbEstado.Items.AddRange(New Object() {"1", "2"})
        Me.cbEstado.Location = New System.Drawing.Point(75, 369)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(107, 21)
        Me.cbEstado.TabIndex = 1000
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(22, 60)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 13)
        Me.Label19.TabIndex = 86
        Me.Label19.Text = "Dinero"
        '
        'txtDinero
        '
        Me.txtDinero.Location = New System.Drawing.Point(103, 60)
        Me.txtDinero.Name = "txtDinero"
        Me.txtDinero.Size = New System.Drawing.Size(107, 20)
        Me.txtDinero.TabIndex = 58
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(97, 13)
        Me.Label18.TabIndex = 85
        Me.Label18.Text = "Código Liquidación"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(244, 12)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 13)
        Me.Label17.TabIndex = 84
        Me.Label17.Text = "Nro. Liquidación"
        '
        'txtNroLiquidacion
        '
        Me.txtNroLiquidacion.Location = New System.Drawing.Point(340, 12)
        Me.txtNroLiquidacion.MaxLength = 6
        Me.txtNroLiquidacion.Name = "txtNroLiquidacion"
        Me.txtNroLiquidacion.Size = New System.Drawing.Size(100, 20)
        Me.txtNroLiquidacion.TabIndex = 49
        '
        'txtCodigoLiquidacion
        '
        Me.txtCodigoLiquidacion.Location = New System.Drawing.Point(110, 12)
        Me.txtCodigoLiquidacion.Name = "txtCodigoLiquidacion"
        Me.txtCodigoLiquidacion.ReadOnly = True
        Me.txtCodigoLiquidacion.Size = New System.Drawing.Size(99, 20)
        Me.txtCodigoLiquidacion.TabIndex = 47
        '
        'dgvLiquidacion
        '
        Me.dgvLiquidacion.AllowUserToAddRows = False
        Me.dgvLiquidacion.AllowUserToDeleteRows = False
        Me.dgvLiquidacion.AllowUserToOrderColumns = True
        Me.dgvLiquidacion.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLiquidacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLiquidacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLiquidacion.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLiquidacion.Location = New System.Drawing.Point(10, 438)
        Me.dgvLiquidacion.MultiSelect = False
        Me.dgvLiquidacion.Name = "dgvLiquidacion"
        Me.dgvLiquidacion.ReadOnly = True
        Me.dgvLiquidacion.RowHeadersVisible = False
        Me.dgvLiquidacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLiquidacion.Size = New System.Drawing.Size(1304, 204)
        Me.dgvLiquidacion.TabIndex = 1000
        '
        'btnAgregarLiquidacion
        '
        Me.btnAgregarLiquidacion.Location = New System.Drawing.Point(1002, 29)
        Me.btnAgregarLiquidacion.Name = "btnAgregarLiquidacion"
        Me.btnAgregarLiquidacion.Size = New System.Drawing.Size(132, 34)
        Me.btnAgregarLiquidacion.TabIndex = 65
        Me.btnAgregarLiquidacion.Text = "Grabar"
        Me.btnAgregarLiquidacion.UseVisualStyleBackColor = True
        '
        'txtCombustibleVirtual
        '
        Me.txtCombustibleVirtual.Location = New System.Drawing.Point(997, 369)
        Me.txtCombustibleVirtual.Name = "txtCombustibleVirtual"
        Me.txtCombustibleVirtual.ReadOnly = True
        Me.txtCombustibleVirtual.Size = New System.Drawing.Size(108, 20)
        Me.txtCombustibleVirtual.TabIndex = 1000
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(926, 372)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 13)
        Me.Label16.TabIndex = 81
        Me.Label16.Text = "Cons. Virtual"
        '
        'dtpLlegada
        '
        Me.dtpLlegada.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpLlegada.Location = New System.Drawing.Point(739, 60)
        Me.dtpLlegada.Name = "dtpLlegada"
        Me.dtpLlegada.Size = New System.Drawing.Size(150, 20)
        Me.dtpLlegada.TabIndex = 61
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(642, 60)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 13)
        Me.Label15.TabIndex = 80
        Me.Label15.Text = "Fecha Llegada"
        '
        'dtpSalida
        '
        Me.dtpSalida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSalida.Location = New System.Drawing.Point(739, 36)
        Me.dtpSalida.Name = "dtpSalida"
        Me.dtpSalida.Size = New System.Drawing.Size(150, 20)
        Me.dtpSalida.TabIndex = 56
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(641, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Fecha Salida"
        '
        'txtDestino
        '
        Me.txtDestino.Location = New System.Drawing.Point(521, 60)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(107, 20)
        Me.txtDestino.TabIndex = 60
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(465, 60)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 78
        Me.Label14.Text = "Destino"
        '
        'txtCombustibleFisico
        '
        Me.txtCombustibleFisico.Location = New System.Drawing.Point(809, 369)
        Me.txtCombustibleFisico.Name = "txtCombustibleFisico"
        Me.txtCombustibleFisico.ReadOnly = True
        Me.txtCombustibleFisico.Size = New System.Drawing.Size(107, 20)
        Me.txtCombustibleFisico.TabIndex = 1000
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(740, 372)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "Cons. Fisico"
        '
        'txtOtros
        '
        Me.txtOtros.Location = New System.Drawing.Point(241, 192)
        Me.txtOtros.Name = "txtOtros"
        Me.txtOtros.ReadOnly = True
        Me.txtOtros.Size = New System.Drawing.Size(107, 20)
        Me.txtOtros.TabIndex = 1000
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(176, 195)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 76
        Me.Label12.Text = "Total Otros"
        '
        'txtBalanza
        '
        Me.txtBalanza.Location = New System.Drawing.Point(274, 191)
        Me.txtBalanza.Name = "txtBalanza"
        Me.txtBalanza.ReadOnly = True
        Me.txtBalanza.Size = New System.Drawing.Size(107, 20)
        Me.txtBalanza.TabIndex = 84
        '
        'txtHospedaje
        '
        Me.txtHospedaje.Location = New System.Drawing.Point(273, 192)
        Me.txtHospedaje.Name = "txtHospedaje"
        Me.txtHospedaje.ReadOnly = True
        Me.txtHospedaje.Size = New System.Drawing.Size(107, 20)
        Me.txtHospedaje.TabIndex = 82
        '
        'txtGuardiania
        '
        Me.txtGuardiania.Location = New System.Drawing.Point(274, 192)
        Me.txtGuardiania.Name = "txtGuardiania"
        Me.txtGuardiania.ReadOnly = True
        Me.txtGuardiania.Size = New System.Drawing.Size(107, 20)
        Me.txtGuardiania.TabIndex = 83
        '
        'txtViaticos
        '
        Me.txtViaticos.Location = New System.Drawing.Point(241, 192)
        Me.txtViaticos.Name = "txtViaticos"
        Me.txtViaticos.ReadOnly = True
        Me.txtViaticos.Size = New System.Drawing.Size(107, 20)
        Me.txtViaticos.TabIndex = 1000
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(161, 195)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Total Viáticos"
        '
        'txtPeajes
        '
        Me.txtPeajes.Location = New System.Drawing.Point(253, 192)
        Me.txtPeajes.Name = "txtPeajes"
        Me.txtPeajes.ReadOnly = True
        Me.txtPeajes.Size = New System.Drawing.Size(107, 20)
        Me.txtPeajes.TabIndex = 1000
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(181, 195)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Total Peajes"
        '
        'txtOrigen
        '
        Me.txtOrigen.Location = New System.Drawing.Point(521, 36)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(107, 20)
        Me.txtOrigen.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(465, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Origen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(236, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Placa Camabaja"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(260, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Placa Tracto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Guias de Rem. Transp."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(465, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Nombre de Chofer"
        '
        'txtTotalGasto
        '
        Me.txtTotalGasto.Location = New System.Drawing.Point(261, 369)
        Me.txtTotalGasto.Name = "txtTotalGasto"
        Me.txtTotalGasto.ReadOnly = True
        Me.txtTotalGasto.Size = New System.Drawing.Size(107, 20)
        Me.txtTotalGasto.TabIndex = 1000
        '
        'txtDiferencia
        '
        Me.txtDiferencia.Location = New System.Drawing.Point(463, 369)
        Me.txtDiferencia.Name = "txtDiferencia"
        Me.txtDiferencia.ReadOnly = True
        Me.txtDiferencia.Size = New System.Drawing.Size(107, 20)
        Me.txtDiferencia.TabIndex = 1000
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(193, 372)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 13)
        Me.Label21.TabIndex = 91
        Me.Label21.Text = "Total Gasto"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(374, 372)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(86, 13)
        Me.Label22.TabIndex = 92
        Me.Label22.Text = "Diferencia Gasto"
        '
        'txtDiferenciaComb
        '
        Me.txtDiferenciaComb.Location = New System.Drawing.Point(1208, 369)
        Me.txtDiferenciaComb.Name = "txtDiferenciaComb"
        Me.txtDiferenciaComb.ReadOnly = True
        Me.txtDiferenciaComb.Size = New System.Drawing.Size(74, 20)
        Me.txtDiferenciaComb.TabIndex = 1000
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(1111, 372)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(85, 13)
        Me.Label23.TabIndex = 94
        Me.Label23.Text = "Diferencia Cons."
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(250, 16)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(365, 20)
        Me.txtFiltro.TabIndex = 95
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(622, 14)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.btnFiltrar.TabIndex = 96
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'btnDeshacer
        '
        Me.btnDeshacer.Location = New System.Drawing.Point(703, 14)
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.Size = New System.Drawing.Size(75, 23)
        Me.btnDeshacer.TabIndex = 97
        Me.btnDeshacer.Text = "Deshacer"
        Me.btnDeshacer.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(12, 18)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(53, 13)
        Me.Label24.TabIndex = 98
        Me.Label24.Text = "Filtrar por:"
        '
        'lblFiltro
        '
        Me.lblFiltro.AutoSize = True
        Me.lblFiltro.Location = New System.Drawing.Point(72, 18)
        Me.lblFiltro.Name = "lblFiltro"
        Me.lblFiltro.Size = New System.Drawing.Size(112, 13)
        Me.lblFiltro.TabIndex = 99
        Me.lblFiltro.Text = "(Seleccionar columna)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblFiltro)
        Me.GroupBox1.Controls.Add(Me.txtFiltro)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.btnFiltrar)
        Me.GroupBox1.Controls.Add(Me.btnDeshacer)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 390)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(789, 42)
        Me.GroupBox1.TabIndex = 100
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'gbPeajes
        '
        Me.gbPeajes.Controls.Add(Me.btnNuevoPeaje)
        Me.gbPeajes.Controls.Add(Me.Label25)
        Me.gbPeajes.Controls.Add(Me.txtNroLineaPeaje)
        Me.gbPeajes.Controls.Add(Me.txtCodigoPeaje)
        Me.gbPeajes.Controls.Add(Me.btnInsertarDebajoPeaje)
        Me.gbPeajes.Controls.Add(Me.txtCodigoLiquidacionPeaje)
        Me.gbPeajes.Controls.Add(Me.btnInsertarArribaPeaje)
        Me.gbPeajes.Controls.Add(Me.btnEliminarPeaje)
        Me.gbPeajes.Controls.Add(Me.btnAgregarPeaje)
        Me.gbPeajes.Controls.Add(Me.dgvPeajes)
        Me.gbPeajes.Controls.Add(Me.Label28)
        Me.gbPeajes.Controls.Add(Me.Label27)
        Me.gbPeajes.Controls.Add(Me.txtTotalPeaje)
        Me.gbPeajes.Controls.Add(Me.txtEjesPeaje)
        Me.gbPeajes.Controls.Add(Me.Label26)
        Me.gbPeajes.Controls.Add(Me.txtLugarPeaje)
        Me.gbPeajes.Controls.Add(Me.dtpFechaHoraPeaje)
        Me.gbPeajes.Controls.Add(Me.txtPeajes)
        Me.gbPeajes.Controls.Add(Me.Label7)
        Me.gbPeajes.Location = New System.Drawing.Point(6, 8)
        Me.gbPeajes.Name = "gbPeajes"
        Me.gbPeajes.Size = New System.Drawing.Size(420, 220)
        Me.gbPeajes.TabIndex = 66
        Me.gbPeajes.TabStop = False
        Me.gbPeajes.Text = "Control de Peajes"
        '
        'btnNuevoPeaje
        '
        Me.btnNuevoPeaje.Location = New System.Drawing.Point(387, 50)
        Me.btnNuevoPeaje.Name = "btnNuevoPeaje"
        Me.btnNuevoPeaje.Size = New System.Drawing.Size(23, 23)
        Me.btnNuevoPeaje.TabIndex = 1001
        Me.btnNuevoPeaje.Text = "N"
        Me.btnNuevoPeaje.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(9, 29)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 13)
        Me.Label25.TabIndex = 1
        Me.Label25.Text = "Fecha/Hora"
        '
        'txtNroLineaPeaje
        '
        Me.txtNroLineaPeaje.Location = New System.Drawing.Point(40, 19)
        Me.txtNroLineaPeaje.Name = "txtNroLineaPeaje"
        Me.txtNroLineaPeaje.Size = New System.Drawing.Size(10, 20)
        Me.txtNroLineaPeaje.TabIndex = 1003
        Me.txtNroLineaPeaje.Visible = False
        '
        'txtCodigoPeaje
        '
        Me.txtCodigoPeaje.Location = New System.Drawing.Point(23, 19)
        Me.txtCodigoPeaje.Name = "txtCodigoPeaje"
        Me.txtCodigoPeaje.Size = New System.Drawing.Size(10, 20)
        Me.txtCodigoPeaje.TabIndex = 1002
        Me.txtCodigoPeaje.Visible = False
        '
        'btnInsertarDebajoPeaje
        '
        Me.btnInsertarDebajoPeaje.Location = New System.Drawing.Point(387, 122)
        Me.btnInsertarDebajoPeaje.Name = "btnInsertarDebajoPeaje"
        Me.btnInsertarDebajoPeaje.Size = New System.Drawing.Size(23, 23)
        Me.btnInsertarDebajoPeaje.TabIndex = 1001
        Me.btnInsertarDebajoPeaje.Text = "i-"
        Me.btnInsertarDebajoPeaje.UseVisualStyleBackColor = True
        '
        'txtCodigoLiquidacionPeaje
        '
        Me.txtCodigoLiquidacionPeaje.Location = New System.Drawing.Point(7, 20)
        Me.txtCodigoLiquidacionPeaje.Name = "txtCodigoLiquidacionPeaje"
        Me.txtCodigoLiquidacionPeaje.Size = New System.Drawing.Size(10, 20)
        Me.txtCodigoLiquidacionPeaje.TabIndex = 1001
        Me.txtCodigoLiquidacionPeaje.Visible = False
        '
        'btnInsertarArribaPeaje
        '
        Me.btnInsertarArribaPeaje.Location = New System.Drawing.Point(387, 89)
        Me.btnInsertarArribaPeaje.Name = "btnInsertarArribaPeaje"
        Me.btnInsertarArribaPeaje.Size = New System.Drawing.Size(23, 23)
        Me.btnInsertarArribaPeaje.TabIndex = 1001
        Me.btnInsertarArribaPeaje.Tag = ""
        Me.btnInsertarArribaPeaje.Text = "i+"
        Me.btnInsertarArribaPeaje.UseVisualStyleBackColor = True
        '
        'btnEliminarPeaje
        '
        Me.btnEliminarPeaje.Location = New System.Drawing.Point(387, 156)
        Me.btnEliminarPeaje.Name = "btnEliminarPeaje"
        Me.btnEliminarPeaje.Size = New System.Drawing.Size(23, 23)
        Me.btnEliminarPeaje.TabIndex = 71
        Me.btnEliminarPeaje.Text = "-"
        Me.btnEliminarPeaje.UseVisualStyleBackColor = True
        '
        'btnAgregarPeaje
        '
        Me.btnAgregarPeaje.Location = New System.Drawing.Point(387, 24)
        Me.btnAgregarPeaje.Name = "btnAgregarPeaje"
        Me.btnAgregarPeaje.Size = New System.Drawing.Size(23, 23)
        Me.btnAgregarPeaje.TabIndex = 70
        Me.btnAgregarPeaje.Text = "+"
        Me.btnAgregarPeaje.UseVisualStyleBackColor = True
        '
        'dgvPeajes
        '
        Me.dgvPeajes.AllowUserToAddRows = False
        Me.dgvPeajes.AllowUserToResizeRows = False
        Me.dgvPeajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPeajes.Location = New System.Drawing.Point(19, 85)
        Me.dgvPeajes.MultiSelect = False
        Me.dgvPeajes.Name = "dgvPeajes"
        Me.dgvPeajes.ReadOnly = True
        Me.dgvPeajes.RowHeadersVisible = False
        Me.dgvPeajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPeajes.Size = New System.Drawing.Size(362, 101)
        Me.dgvPeajes.TabIndex = 8
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(267, 58)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(31, 13)
        Me.Label28.TabIndex = 7
        Me.Label28.Text = "Total"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(264, 29)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(27, 13)
        Me.Label27.TabIndex = 6
        Me.Label27.Text = "Ejes"
        '
        'txtTotalPeaje
        '
        Me.txtTotalPeaje.Location = New System.Drawing.Point(308, 52)
        Me.txtTotalPeaje.Name = "txtTotalPeaje"
        Me.txtTotalPeaje.Size = New System.Drawing.Size(73, 20)
        Me.txtTotalPeaje.TabIndex = 69
        '
        'txtEjesPeaje
        '
        Me.txtEjesPeaje.Location = New System.Drawing.Point(308, 25)
        Me.txtEjesPeaje.Name = "txtEjesPeaje"
        Me.txtEjesPeaje.Size = New System.Drawing.Size(73, 20)
        Me.txtEjesPeaje.TabIndex = 67
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(15, 52)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(34, 13)
        Me.Label26.TabIndex = 3
        Me.Label26.Text = "Lugar"
        '
        'txtLugarPeaje
        '
        Me.txtLugarPeaje.Location = New System.Drawing.Point(93, 52)
        Me.txtLugarPeaje.Name = "txtLugarPeaje"
        Me.txtLugarPeaje.Size = New System.Drawing.Size(150, 20)
        Me.txtLugarPeaje.TabIndex = 68
        '
        'dtpFechaHoraPeaje
        '
        Me.dtpFechaHoraPeaje.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHoraPeaje.Location = New System.Drawing.Point(93, 25)
        Me.dtpFechaHoraPeaje.Name = "dtpFechaHoraPeaje"
        Me.dtpFechaHoraPeaje.Size = New System.Drawing.Size(150, 20)
        Me.dtpFechaHoraPeaje.TabIndex = 66
        '
        'gbViaticos
        '
        Me.gbViaticos.Controls.Add(Me.btnNuevoViatico)
        Me.gbViaticos.Controls.Add(Me.btnInsertarAbajoViatico)
        Me.gbViaticos.Controls.Add(Me.btnInsertarArribaViatico)
        Me.gbViaticos.Controls.Add(Me.txtNroLineaViatico)
        Me.gbViaticos.Controls.Add(Me.btnEliminarViatico)
        Me.gbViaticos.Controls.Add(Me.txtCodigoViatico)
        Me.gbViaticos.Controls.Add(Me.btnAgregarViatico)
        Me.gbViaticos.Controls.Add(Me.txtCodigoLiquidacionViatico)
        Me.gbViaticos.Controls.Add(Me.dgvViaticos)
        Me.gbViaticos.Controls.Add(Me.Label32)
        Me.gbViaticos.Controls.Add(Me.Label31)
        Me.gbViaticos.Controls.Add(Me.Label30)
        Me.gbViaticos.Controls.Add(Me.Label29)
        Me.gbViaticos.Controls.Add(Me.txtTotalViatico)
        Me.gbViaticos.Controls.Add(Me.txtDescripcionViatico)
        Me.gbViaticos.Controls.Add(Me.dtpTurnoViaticos)
        Me.gbViaticos.Controls.Add(Me.txtCantidadViatico)
        Me.gbViaticos.Controls.Add(Me.txtViaticos)
        Me.gbViaticos.Controls.Add(Me.Label8)
        Me.gbViaticos.Location = New System.Drawing.Point(442, 8)
        Me.gbViaticos.Name = "gbViaticos"
        Me.gbViaticos.Size = New System.Drawing.Size(416, 220)
        Me.gbViaticos.TabIndex = 72
        Me.gbViaticos.TabStop = False
        Me.gbViaticos.Text = "Viáticos"
        '
        'btnNuevoViatico
        '
        Me.btnNuevoViatico.Location = New System.Drawing.Point(387, 54)
        Me.btnNuevoViatico.Name = "btnNuevoViatico"
        Me.btnNuevoViatico.Size = New System.Drawing.Size(23, 23)
        Me.btnNuevoViatico.TabIndex = 1001
        Me.btnNuevoViatico.Text = "N"
        Me.btnNuevoViatico.UseVisualStyleBackColor = True
        '
        'btnInsertarAbajoViatico
        '
        Me.btnInsertarAbajoViatico.Location = New System.Drawing.Point(387, 122)
        Me.btnInsertarAbajoViatico.Name = "btnInsertarAbajoViatico"
        Me.btnInsertarAbajoViatico.Size = New System.Drawing.Size(23, 23)
        Me.btnInsertarAbajoViatico.TabIndex = 1001
        Me.btnInsertarAbajoViatico.Text = "i-"
        Me.btnInsertarAbajoViatico.UseVisualStyleBackColor = True
        '
        'btnInsertarArribaViatico
        '
        Me.btnInsertarArribaViatico.Location = New System.Drawing.Point(387, 89)
        Me.btnInsertarArribaViatico.Name = "btnInsertarArribaViatico"
        Me.btnInsertarArribaViatico.Size = New System.Drawing.Size(23, 23)
        Me.btnInsertarArribaViatico.TabIndex = 1001
        Me.btnInsertarArribaViatico.Text = "i+"
        Me.btnInsertarArribaViatico.UseVisualStyleBackColor = True
        '
        'txtNroLineaViatico
        '
        Me.txtNroLineaViatico.Location = New System.Drawing.Point(44, 26)
        Me.txtNroLineaViatico.Name = "txtNroLineaViatico"
        Me.txtNroLineaViatico.Size = New System.Drawing.Size(10, 20)
        Me.txtNroLineaViatico.TabIndex = 1003
        Me.txtNroLineaViatico.Visible = False
        '
        'btnEliminarViatico
        '
        Me.btnEliminarViatico.Location = New System.Drawing.Point(387, 156)
        Me.btnEliminarViatico.Name = "btnEliminarViatico"
        Me.btnEliminarViatico.Size = New System.Drawing.Size(23, 23)
        Me.btnEliminarViatico.TabIndex = 77
        Me.btnEliminarViatico.Text = "-"
        Me.btnEliminarViatico.UseVisualStyleBackColor = True
        '
        'txtCodigoViatico
        '
        Me.txtCodigoViatico.Location = New System.Drawing.Point(27, 26)
        Me.txtCodigoViatico.Name = "txtCodigoViatico"
        Me.txtCodigoViatico.Size = New System.Drawing.Size(10, 20)
        Me.txtCodigoViatico.TabIndex = 1002
        Me.txtCodigoViatico.Visible = False
        '
        'btnAgregarViatico
        '
        Me.btnAgregarViatico.Location = New System.Drawing.Point(387, 29)
        Me.btnAgregarViatico.Name = "btnAgregarViatico"
        Me.btnAgregarViatico.Size = New System.Drawing.Size(23, 23)
        Me.btnAgregarViatico.TabIndex = 76
        Me.btnAgregarViatico.Text = "+"
        Me.btnAgregarViatico.UseVisualStyleBackColor = True
        '
        'txtCodigoLiquidacionViatico
        '
        Me.txtCodigoLiquidacionViatico.Location = New System.Drawing.Point(10, 26)
        Me.txtCodigoLiquidacionViatico.Name = "txtCodigoLiquidacionViatico"
        Me.txtCodigoLiquidacionViatico.Size = New System.Drawing.Size(10, 20)
        Me.txtCodigoLiquidacionViatico.TabIndex = 1001
        Me.txtCodigoLiquidacionViatico.Visible = False
        '
        'dgvViaticos
        '
        Me.dgvViaticos.AllowUserToAddRows = False
        Me.dgvViaticos.AllowUserToResizeRows = False
        Me.dgvViaticos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvViaticos.Location = New System.Drawing.Point(10, 85)
        Me.dgvViaticos.MultiSelect = False
        Me.dgvViaticos.Name = "dgvViaticos"
        Me.dgvViaticos.ReadOnly = True
        Me.dgvViaticos.RowHeadersVisible = False
        Me.dgvViaticos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvViaticos.Size = New System.Drawing.Size(371, 101)
        Me.dgvViaticos.TabIndex = 8
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(253, 59)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(31, 13)
        Me.Label32.TabIndex = 7
        Me.Label32.Text = "Total"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(7, 56)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(63, 13)
        Me.Label31.TabIndex = 6
        Me.Label31.Text = "Descripción"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(167, 32)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(58, 13)
        Me.Label30.TabIndex = 5
        Me.Label30.Text = "Día/Turno"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(6, 31)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(49, 13)
        Me.Label29.TabIndex = 4
        Me.Label29.Text = "Cantidad"
        '
        'txtTotalViatico
        '
        Me.txtTotalViatico.Location = New System.Drawing.Point(290, 55)
        Me.txtTotalViatico.Name = "txtTotalViatico"
        Me.txtTotalViatico.Size = New System.Drawing.Size(91, 20)
        Me.txtTotalViatico.TabIndex = 75
        '
        'txtDescripcionViatico
        '
        Me.txtDescripcionViatico.Location = New System.Drawing.Point(76, 56)
        Me.txtDescripcionViatico.Name = "txtDescripcionViatico"
        Me.txtDescripcionViatico.Size = New System.Drawing.Size(149, 20)
        Me.txtDescripcionViatico.TabIndex = 74
        '
        'dtpTurnoViaticos
        '
        Me.dtpTurnoViaticos.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTurnoViaticos.Location = New System.Drawing.Point(231, 29)
        Me.dtpTurnoViaticos.Name = "dtpTurnoViaticos"
        Me.dtpTurnoViaticos.Size = New System.Drawing.Size(150, 20)
        Me.dtpTurnoViaticos.TabIndex = 73
        '
        'txtCantidadViatico
        '
        Me.txtCantidadViatico.Location = New System.Drawing.Point(76, 29)
        Me.txtCantidadViatico.Name = "txtCantidadViatico"
        Me.txtCantidadViatico.Size = New System.Drawing.Size(60, 20)
        Me.txtCantidadViatico.TabIndex = 72
        '
        'gbOtros
        '
        Me.gbOtros.Controls.Add(Me.btnInsertarAbajoOtro)
        Me.gbOtros.Controls.Add(Me.txtNroLineaOtro)
        Me.gbOtros.Controls.Add(Me.btnInsertarArribaOtro)
        Me.gbOtros.Controls.Add(Me.btnEliminarOtros)
        Me.gbOtros.Controls.Add(Me.btnNuevoOtro)
        Me.gbOtros.Controls.Add(Me.txtCodigoOtro)
        Me.gbOtros.Controls.Add(Me.btnAgregarOtros)
        Me.gbOtros.Controls.Add(Me.txtCodigoLiquidacionOtro)
        Me.gbOtros.Controls.Add(Me.dgvOtros)
        Me.gbOtros.Controls.Add(Me.Label34)
        Me.gbOtros.Controls.Add(Me.Label33)
        Me.gbOtros.Controls.Add(Me.txtTotalOtros)
        Me.gbOtros.Controls.Add(Me.txtDescripcionOtros)
        Me.gbOtros.Controls.Add(Me.txtOtros)
        Me.gbOtros.Controls.Add(Me.Label12)
        Me.gbOtros.Location = New System.Drawing.Point(864, 8)
        Me.gbOtros.Name = "gbOtros"
        Me.gbOtros.Size = New System.Drawing.Size(423, 220)
        Me.gbOtros.TabIndex = 78
        Me.gbOtros.TabStop = False
        Me.gbOtros.Text = "Otros"
        '
        'btnInsertarAbajoOtro
        '
        Me.btnInsertarAbajoOtro.Location = New System.Drawing.Point(392, 118)
        Me.btnInsertarAbajoOtro.Name = "btnInsertarAbajoOtro"
        Me.btnInsertarAbajoOtro.Size = New System.Drawing.Size(23, 23)
        Me.btnInsertarAbajoOtro.TabIndex = 1003
        Me.btnInsertarAbajoOtro.Text = "i-"
        Me.btnInsertarAbajoOtro.UseVisualStyleBackColor = True
        '
        'txtNroLineaOtro
        '
        Me.txtNroLineaOtro.Location = New System.Drawing.Point(53, 45)
        Me.txtNroLineaOtro.Name = "txtNroLineaOtro"
        Me.txtNroLineaOtro.Size = New System.Drawing.Size(10, 20)
        Me.txtNroLineaOtro.TabIndex = 1003
        Me.txtNroLineaOtro.Visible = False
        '
        'btnInsertarArribaOtro
        '
        Me.btnInsertarArribaOtro.Location = New System.Drawing.Point(392, 86)
        Me.btnInsertarArribaOtro.Name = "btnInsertarArribaOtro"
        Me.btnInsertarArribaOtro.Size = New System.Drawing.Size(23, 23)
        Me.btnInsertarArribaOtro.TabIndex = 1002
        Me.btnInsertarArribaOtro.Text = "i+"
        Me.btnInsertarArribaOtro.UseVisualStyleBackColor = True
        '
        'btnEliminarOtros
        '
        Me.btnEliminarOtros.Location = New System.Drawing.Point(392, 153)
        Me.btnEliminarOtros.Name = "btnEliminarOtros"
        Me.btnEliminarOtros.Size = New System.Drawing.Size(23, 23)
        Me.btnEliminarOtros.TabIndex = 81
        Me.btnEliminarOtros.Text = "-"
        Me.btnEliminarOtros.UseVisualStyleBackColor = True
        '
        'btnNuevoOtro
        '
        Me.btnNuevoOtro.Location = New System.Drawing.Point(392, 49)
        Me.btnNuevoOtro.Name = "btnNuevoOtro"
        Me.btnNuevoOtro.Size = New System.Drawing.Size(23, 23)
        Me.btnNuevoOtro.TabIndex = 1001
        Me.btnNuevoOtro.Text = "N"
        Me.btnNuevoOtro.UseVisualStyleBackColor = True
        '
        'txtCodigoOtro
        '
        Me.txtCodigoOtro.Location = New System.Drawing.Point(37, 45)
        Me.txtCodigoOtro.Name = "txtCodigoOtro"
        Me.txtCodigoOtro.Size = New System.Drawing.Size(10, 20)
        Me.txtCodigoOtro.TabIndex = 1002
        Me.txtCodigoOtro.Visible = False
        '
        'btnAgregarOtros
        '
        Me.btnAgregarOtros.Location = New System.Drawing.Point(392, 21)
        Me.btnAgregarOtros.Name = "btnAgregarOtros"
        Me.btnAgregarOtros.Size = New System.Drawing.Size(23, 23)
        Me.btnAgregarOtros.TabIndex = 80
        Me.btnAgregarOtros.Text = "+"
        Me.btnAgregarOtros.UseVisualStyleBackColor = True
        '
        'txtCodigoLiquidacionOtro
        '
        Me.txtCodigoLiquidacionOtro.Location = New System.Drawing.Point(21, 45)
        Me.txtCodigoLiquidacionOtro.Name = "txtCodigoLiquidacionOtro"
        Me.txtCodigoLiquidacionOtro.Size = New System.Drawing.Size(10, 20)
        Me.txtCodigoLiquidacionOtro.TabIndex = 1001
        Me.txtCodigoLiquidacionOtro.Visible = False
        '
        'dgvOtros
        '
        Me.dgvOtros.AllowUserToAddRows = False
        Me.dgvOtros.AllowUserToResizeRows = False
        Me.dgvOtros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOtros.Location = New System.Drawing.Point(10, 85)
        Me.dgvOtros.MultiSelect = False
        Me.dgvOtros.Name = "dgvOtros"
        Me.dgvOtros.ReadOnly = True
        Me.dgvOtros.RowHeadersVisible = False
        Me.dgvOtros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOtros.Size = New System.Drawing.Size(376, 101)
        Me.dgvOtros.TabIndex = 4
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(273, 55)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(31, 13)
        Me.Label34.TabIndex = 3
        Me.Label34.Text = "Total"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(7, 29)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(63, 13)
        Me.Label33.TabIndex = 2
        Me.Label33.Text = "Descripción"
        '
        'txtTotalOtros
        '
        Me.txtTotalOtros.Location = New System.Drawing.Point(310, 51)
        Me.txtTotalOtros.Name = "txtTotalOtros"
        Me.txtTotalOtros.Size = New System.Drawing.Size(76, 20)
        Me.txtTotalOtros.TabIndex = 79
        '
        'txtDescripcionOtros
        '
        Me.txtDescripcionOtros.Location = New System.Drawing.Point(75, 24)
        Me.txtDescripcionOtros.Name = "txtDescripcionOtros"
        Me.txtDescripcionOtros.Size = New System.Drawing.Size(311, 20)
        Me.txtDescripcionOtros.TabIndex = 78
        '
        'btnRptLiquidacion
        '
        Me.btnRptLiquidacion.Location = New System.Drawing.Point(883, 395)
        Me.btnRptLiquidacion.Name = "btnRptLiquidacion"
        Me.btnRptLiquidacion.Size = New System.Drawing.Size(100, 37)
        Me.btnRptLiquidacion.TabIndex = 104
        Me.btnRptLiquidacion.Text = "Liquidación de viaje general"
        Me.btnRptLiquidacion.UseVisualStyleBackColor = True
        '
        'btnRptLiquidacionDetallado
        '
        Me.btnRptLiquidacionDetallado.Location = New System.Drawing.Point(1002, 395)
        Me.btnRptLiquidacionDetallado.Name = "btnRptLiquidacionDetallado"
        Me.btnRptLiquidacionDetallado.Size = New System.Drawing.Size(100, 37)
        Me.btnRptLiquidacionDetallado.TabIndex = 105
        Me.btnRptLiquidacionDetallado.Text = "Liquidación de viaje detallado"
        Me.btnRptLiquidacionDetallado.UseVisualStyleBackColor = True
        '
        'txtCarga
        '
        Me.txtCarga.Location = New System.Drawing.Point(103, 84)
        Me.txtCarga.Name = "txtCarga"
        Me.txtCarga.Size = New System.Drawing.Size(217, 20)
        Me.txtCarga.TabIndex = 62
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(10, 84)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(35, 13)
        Me.Label35.TabIndex = 107
        Me.Label35.Text = "Carga"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(340, 84)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(31, 13)
        Me.Label36.TabIndex = 108
        Me.Label36.Text = "Peso"
        '
        'txtPeso
        '
        Me.txtPeso.Location = New System.Drawing.Point(378, 84)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(85, 20)
        Me.txtPeso.TabIndex = 63
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(469, 84)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(41, 13)
        Me.Label37.TabIndex = 110
        Me.Label37.Text = "Unidad"
        '
        'cbUnidadMedida
        '
        Me.cbUnidadMedida.FormattingEnabled = True
        Me.cbUnidadMedida.Location = New System.Drawing.Point(521, 84)
        Me.cbUnidadMedida.Name = "cbUnidadMedida"
        Me.cbUnidadMedida.Size = New System.Drawing.Size(112, 21)
        Me.cbUnidadMedida.TabIndex = 64
        '
        'btnRptLiquidacionCombustible
        '
        Me.btnRptLiquidacionCombustible.Location = New System.Drawing.Point(1119, 394)
        Me.btnRptLiquidacionCombustible.Name = "btnRptLiquidacionCombustible"
        Me.btnRptLiquidacionCombustible.Size = New System.Drawing.Size(100, 38)
        Me.btnRptLiquidacionCombustible.TabIndex = 113
        Me.btnRptLiquidacionCombustible.Text = "Liquidación de Combustible"
        Me.btnRptLiquidacionCombustible.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 107)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1302, 257)
        Me.TabControl1.TabIndex = 1001
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gbPeajes)
        Me.TabPage1.Controls.Add(Me.gbViaticos)
        Me.TabPage1.Controls.Add(Me.gbOtros)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1294, 231)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Peajes, Viáticos, Otros"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1294, 231)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Hospedaje, Guardianía, Balanza"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnNuevoBalanza)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtNroLineaBalanza)
        Me.GroupBox4.Controls.Add(Me.txtCodigoBalanza)
        Me.GroupBox4.Controls.Add(Me.btnInsertarAbajoBalanza)
        Me.GroupBox4.Controls.Add(Me.txtCodigoLiquidacionBalanza)
        Me.GroupBox4.Controls.Add(Me.btnInsertarArribaBalanza)
        Me.GroupBox4.Controls.Add(Me.btnEliminarBalanza)
        Me.GroupBox4.Controls.Add(Me.btnAgregarBalanza)
        Me.GroupBox4.Controls.Add(Me.dgvBalanza)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtTotalBalanza)
        Me.GroupBox4.Controls.Add(Me.Label46)
        Me.GroupBox4.Controls.Add(Me.txtDescripcionBalanza)
        Me.GroupBox4.Controls.Add(Me.dtpBalanza)
        Me.GroupBox4.Controls.Add(Me.Label47)
        Me.GroupBox4.Controls.Add(Me.txtBalanza)
        Me.GroupBox4.Location = New System.Drawing.Point(863, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(420, 220)
        Me.GroupBox4.TabIndex = 69
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Balanza"
        '
        'btnNuevoBalanza
        '
        Me.btnNuevoBalanza.Location = New System.Drawing.Point(387, 50)
        Me.btnNuevoBalanza.Name = "btnNuevoBalanza"
        Me.btnNuevoBalanza.Size = New System.Drawing.Size(23, 23)
        Me.btnNuevoBalanza.TabIndex = 1001
        Me.btnNuevoBalanza.Text = "N"
        Me.btnNuevoBalanza.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Fecha"
        '
        'txtNroLineaBalanza
        '
        Me.txtNroLineaBalanza.Location = New System.Drawing.Point(40, 19)
        Me.txtNroLineaBalanza.Name = "txtNroLineaBalanza"
        Me.txtNroLineaBalanza.Size = New System.Drawing.Size(10, 20)
        Me.txtNroLineaBalanza.TabIndex = 1003
        Me.txtNroLineaBalanza.Visible = False
        '
        'txtCodigoBalanza
        '
        Me.txtCodigoBalanza.Location = New System.Drawing.Point(23, 19)
        Me.txtCodigoBalanza.Name = "txtCodigoBalanza"
        Me.txtCodigoBalanza.Size = New System.Drawing.Size(10, 20)
        Me.txtCodigoBalanza.TabIndex = 1002
        Me.txtCodigoBalanza.Visible = False
        '
        'btnInsertarAbajoBalanza
        '
        Me.btnInsertarAbajoBalanza.Location = New System.Drawing.Point(387, 122)
        Me.btnInsertarAbajoBalanza.Name = "btnInsertarAbajoBalanza"
        Me.btnInsertarAbajoBalanza.Size = New System.Drawing.Size(23, 23)
        Me.btnInsertarAbajoBalanza.TabIndex = 1001
        Me.btnInsertarAbajoBalanza.Text = "i-"
        Me.btnInsertarAbajoBalanza.UseVisualStyleBackColor = True
        '
        'txtCodigoLiquidacionBalanza
        '
        Me.txtCodigoLiquidacionBalanza.Location = New System.Drawing.Point(7, 19)
        Me.txtCodigoLiquidacionBalanza.Name = "txtCodigoLiquidacionBalanza"
        Me.txtCodigoLiquidacionBalanza.Size = New System.Drawing.Size(10, 20)
        Me.txtCodigoLiquidacionBalanza.TabIndex = 1001
        Me.txtCodigoLiquidacionBalanza.Visible = False
        '
        'btnInsertarArribaBalanza
        '
        Me.btnInsertarArribaBalanza.Location = New System.Drawing.Point(387, 89)
        Me.btnInsertarArribaBalanza.Name = "btnInsertarArribaBalanza"
        Me.btnInsertarArribaBalanza.Size = New System.Drawing.Size(23, 23)
        Me.btnInsertarArribaBalanza.TabIndex = 1001
        Me.btnInsertarArribaBalanza.Tag = ""
        Me.btnInsertarArribaBalanza.Text = "i+"
        Me.btnInsertarArribaBalanza.UseVisualStyleBackColor = True
        '
        'btnEliminarBalanza
        '
        Me.btnEliminarBalanza.Location = New System.Drawing.Point(387, 156)
        Me.btnEliminarBalanza.Name = "btnEliminarBalanza"
        Me.btnEliminarBalanza.Size = New System.Drawing.Size(23, 23)
        Me.btnEliminarBalanza.TabIndex = 71
        Me.btnEliminarBalanza.Text = "-"
        Me.btnEliminarBalanza.UseVisualStyleBackColor = True
        '
        'btnAgregarBalanza
        '
        Me.btnAgregarBalanza.Location = New System.Drawing.Point(387, 24)
        Me.btnAgregarBalanza.Name = "btnAgregarBalanza"
        Me.btnAgregarBalanza.Size = New System.Drawing.Size(23, 23)
        Me.btnAgregarBalanza.TabIndex = 70
        Me.btnAgregarBalanza.Text = "+"
        Me.btnAgregarBalanza.UseVisualStyleBackColor = True
        '
        'dgvBalanza
        '
        Me.dgvBalanza.AllowUserToAddRows = False
        Me.dgvBalanza.AllowUserToResizeRows = False
        Me.dgvBalanza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBalanza.Location = New System.Drawing.Point(19, 85)
        Me.dgvBalanza.MultiSelect = False
        Me.dgvBalanza.Name = "dgvBalanza"
        Me.dgvBalanza.ReadOnly = True
        Me.dgvBalanza.RowHeadersVisible = False
        Me.dgvBalanza.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBalanza.Size = New System.Drawing.Size(362, 101)
        Me.dgvBalanza.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(266, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Total"
        '
        'txtTotalBalanza
        '
        Me.txtTotalBalanza.Location = New System.Drawing.Point(307, 29)
        Me.txtTotalBalanza.Name = "txtTotalBalanza"
        Me.txtTotalBalanza.Size = New System.Drawing.Size(73, 20)
        Me.txtTotalBalanza.TabIndex = 69
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(8, 52)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(63, 13)
        Me.Label46.TabIndex = 3
        Me.Label46.Text = "Descripción"
        '
        'txtDescripcionBalanza
        '
        Me.txtDescripcionBalanza.Location = New System.Drawing.Point(77, 52)
        Me.txtDescripcionBalanza.Name = "txtDescripcionBalanza"
        Me.txtDescripcionBalanza.Size = New System.Drawing.Size(303, 20)
        Me.txtDescripcionBalanza.TabIndex = 68
        '
        'dtpBalanza
        '
        Me.dtpBalanza.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBalanza.Location = New System.Drawing.Point(77, 25)
        Me.dtpBalanza.Name = "dtpBalanza"
        Me.dtpBalanza.Size = New System.Drawing.Size(95, 20)
        Me.dtpBalanza.TabIndex = 66
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(162, 195)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(87, 13)
        Me.Label47.TabIndex = 62
        Me.Label47.Text = "Total Guardianía"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnNuevoGuardiania)
        Me.GroupBox3.Controls.Add(Me.Label40)
        Me.GroupBox3.Controls.Add(Me.txtNroLineaGuardiania)
        Me.GroupBox3.Controls.Add(Me.txtCodigoGuardiania)
        Me.GroupBox3.Controls.Add(Me.btnInsertarAbajoGuardiania)
        Me.GroupBox3.Controls.Add(Me.txtCodigoLiquidacionGuardiania)
        Me.GroupBox3.Controls.Add(Me.btnInsertarArribaGuardiania)
        Me.GroupBox3.Controls.Add(Me.btnEliminarGuardiania)
        Me.GroupBox3.Controls.Add(Me.btnAgregarGuardiania)
        Me.GroupBox3.Controls.Add(Me.dgvGuardiania)
        Me.GroupBox3.Controls.Add(Me.Label43)
        Me.GroupBox3.Controls.Add(Me.txtTotalGuardiania)
        Me.GroupBox3.Controls.Add(Me.Label44)
        Me.GroupBox3.Controls.Add(Me.txtDescripcionGuardiania)
        Me.GroupBox3.Controls.Add(Me.dtpGuardiania)
        Me.GroupBox3.Controls.Add(Me.Label45)
        Me.GroupBox3.Controls.Add(Me.txtGuardiania)
        Me.GroupBox3.Location = New System.Drawing.Point(437, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(420, 220)
        Me.GroupBox3.TabIndex = 68
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Guardianía"
        '
        'btnNuevoGuardiania
        '
        Me.btnNuevoGuardiania.Location = New System.Drawing.Point(387, 50)
        Me.btnNuevoGuardiania.Name = "btnNuevoGuardiania"
        Me.btnNuevoGuardiania.Size = New System.Drawing.Size(23, 23)
        Me.btnNuevoGuardiania.TabIndex = 1001
        Me.btnNuevoGuardiania.Text = "N"
        Me.btnNuevoGuardiania.UseVisualStyleBackColor = True
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(9, 29)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(37, 13)
        Me.Label40.TabIndex = 1
        Me.Label40.Text = "Fecha"
        '
        'txtNroLineaGuardiania
        '
        Me.txtNroLineaGuardiania.Location = New System.Drawing.Point(40, 19)
        Me.txtNroLineaGuardiania.Name = "txtNroLineaGuardiania"
        Me.txtNroLineaGuardiania.Size = New System.Drawing.Size(10, 20)
        Me.txtNroLineaGuardiania.TabIndex = 1003
        Me.txtNroLineaGuardiania.Visible = False
        '
        'txtCodigoGuardiania
        '
        Me.txtCodigoGuardiania.Location = New System.Drawing.Point(23, 19)
        Me.txtCodigoGuardiania.Name = "txtCodigoGuardiania"
        Me.txtCodigoGuardiania.Size = New System.Drawing.Size(10, 20)
        Me.txtCodigoGuardiania.TabIndex = 1002
        Me.txtCodigoGuardiania.Visible = False
        '
        'btnInsertarAbajoGuardiania
        '
        Me.btnInsertarAbajoGuardiania.Location = New System.Drawing.Point(387, 122)
        Me.btnInsertarAbajoGuardiania.Name = "btnInsertarAbajoGuardiania"
        Me.btnInsertarAbajoGuardiania.Size = New System.Drawing.Size(23, 23)
        Me.btnInsertarAbajoGuardiania.TabIndex = 1001
        Me.btnInsertarAbajoGuardiania.Text = "i-"
        Me.btnInsertarAbajoGuardiania.UseVisualStyleBackColor = True
        '
        'txtCodigoLiquidacionGuardiania
        '
        Me.txtCodigoLiquidacionGuardiania.Location = New System.Drawing.Point(7, 19)
        Me.txtCodigoLiquidacionGuardiania.Name = "txtCodigoLiquidacionGuardiania"
        Me.txtCodigoLiquidacionGuardiania.Size = New System.Drawing.Size(10, 20)
        Me.txtCodigoLiquidacionGuardiania.TabIndex = 1001
        Me.txtCodigoLiquidacionGuardiania.Visible = False
        '
        'btnInsertarArribaGuardiania
        '
        Me.btnInsertarArribaGuardiania.Location = New System.Drawing.Point(387, 89)
        Me.btnInsertarArribaGuardiania.Name = "btnInsertarArribaGuardiania"
        Me.btnInsertarArribaGuardiania.Size = New System.Drawing.Size(23, 23)
        Me.btnInsertarArribaGuardiania.TabIndex = 1001
        Me.btnInsertarArribaGuardiania.Tag = ""
        Me.btnInsertarArribaGuardiania.Text = "i+"
        Me.btnInsertarArribaGuardiania.UseVisualStyleBackColor = True
        '
        'btnEliminarGuardiania
        '
        Me.btnEliminarGuardiania.Location = New System.Drawing.Point(387, 156)
        Me.btnEliminarGuardiania.Name = "btnEliminarGuardiania"
        Me.btnEliminarGuardiania.Size = New System.Drawing.Size(23, 23)
        Me.btnEliminarGuardiania.TabIndex = 71
        Me.btnEliminarGuardiania.Text = "-"
        Me.btnEliminarGuardiania.UseVisualStyleBackColor = True
        '
        'btnAgregarGuardiania
        '
        Me.btnAgregarGuardiania.Location = New System.Drawing.Point(387, 24)
        Me.btnAgregarGuardiania.Name = "btnAgregarGuardiania"
        Me.btnAgregarGuardiania.Size = New System.Drawing.Size(23, 23)
        Me.btnAgregarGuardiania.TabIndex = 70
        Me.btnAgregarGuardiania.Text = "+"
        Me.btnAgregarGuardiania.UseVisualStyleBackColor = True
        '
        'dgvGuardiania
        '
        Me.dgvGuardiania.AllowUserToAddRows = False
        Me.dgvGuardiania.AllowUserToResizeRows = False
        Me.dgvGuardiania.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGuardiania.Location = New System.Drawing.Point(19, 85)
        Me.dgvGuardiania.MultiSelect = False
        Me.dgvGuardiania.Name = "dgvGuardiania"
        Me.dgvGuardiania.ReadOnly = True
        Me.dgvGuardiania.RowHeadersVisible = False
        Me.dgvGuardiania.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGuardiania.Size = New System.Drawing.Size(362, 101)
        Me.dgvGuardiania.TabIndex = 8
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(266, 35)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(31, 13)
        Me.Label43.TabIndex = 7
        Me.Label43.Text = "Total"
        '
        'txtTotalGuardiania
        '
        Me.txtTotalGuardiania.Location = New System.Drawing.Point(307, 29)
        Me.txtTotalGuardiania.Name = "txtTotalGuardiania"
        Me.txtTotalGuardiania.Size = New System.Drawing.Size(73, 20)
        Me.txtTotalGuardiania.TabIndex = 69
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(8, 52)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(63, 13)
        Me.Label44.TabIndex = 3
        Me.Label44.Text = "Descripción"
        '
        'txtDescripcionGuardiania
        '
        Me.txtDescripcionGuardiania.Location = New System.Drawing.Point(77, 52)
        Me.txtDescripcionGuardiania.Name = "txtDescripcionGuardiania"
        Me.txtDescripcionGuardiania.Size = New System.Drawing.Size(303, 20)
        Me.txtDescripcionGuardiania.TabIndex = 68
        '
        'dtpGuardiania
        '
        Me.dtpGuardiania.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpGuardiania.Location = New System.Drawing.Point(77, 25)
        Me.dtpGuardiania.Name = "dtpGuardiania"
        Me.dtpGuardiania.Size = New System.Drawing.Size(95, 20)
        Me.dtpGuardiania.TabIndex = 66
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(162, 195)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(87, 13)
        Me.Label45.TabIndex = 62
        Me.Label45.Text = "Total Guardianía"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnNuevoHospedaje)
        Me.GroupBox2.Controls.Add(Me.Label38)
        Me.GroupBox2.Controls.Add(Me.txtNroLineaHospedaje)
        Me.GroupBox2.Controls.Add(Me.txtCodigoHospedaje)
        Me.GroupBox2.Controls.Add(Me.btnInsertarAbajoHospedaje)
        Me.GroupBox2.Controls.Add(Me.txtCodigoLiquidacionHospedaje)
        Me.GroupBox2.Controls.Add(Me.btnInsertarArribaHospedaje)
        Me.GroupBox2.Controls.Add(Me.btnEliminarHospedaje)
        Me.GroupBox2.Controls.Add(Me.btnAgregarHospedaje)
        Me.GroupBox2.Controls.Add(Me.dgvHospedaje)
        Me.GroupBox2.Controls.Add(Me.Label39)
        Me.GroupBox2.Controls.Add(Me.txtTotalHospedaje)
        Me.GroupBox2.Controls.Add(Me.Label41)
        Me.GroupBox2.Controls.Add(Me.txtDescripcionHospedaje)
        Me.GroupBox2.Controls.Add(Me.dtpHospedaje)
        Me.GroupBox2.Controls.Add(Me.Label42)
        Me.GroupBox2.Controls.Add(Me.txtHospedaje)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(420, 220)
        Me.GroupBox2.TabIndex = 67
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Hospedaje"
        '
        'btnNuevoHospedaje
        '
        Me.btnNuevoHospedaje.Location = New System.Drawing.Point(387, 50)
        Me.btnNuevoHospedaje.Name = "btnNuevoHospedaje"
        Me.btnNuevoHospedaje.Size = New System.Drawing.Size(23, 23)
        Me.btnNuevoHospedaje.TabIndex = 1001
        Me.btnNuevoHospedaje.Text = "N"
        Me.btnNuevoHospedaje.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(9, 29)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(37, 13)
        Me.Label38.TabIndex = 1
        Me.Label38.Text = "Fecha"
        '
        'txtNroLineaHospedaje
        '
        Me.txtNroLineaHospedaje.Location = New System.Drawing.Point(40, 19)
        Me.txtNroLineaHospedaje.Name = "txtNroLineaHospedaje"
        Me.txtNroLineaHospedaje.Size = New System.Drawing.Size(10, 20)
        Me.txtNroLineaHospedaje.TabIndex = 1003
        Me.txtNroLineaHospedaje.Visible = False
        '
        'txtCodigoHospedaje
        '
        Me.txtCodigoHospedaje.Location = New System.Drawing.Point(23, 19)
        Me.txtCodigoHospedaje.Name = "txtCodigoHospedaje"
        Me.txtCodigoHospedaje.Size = New System.Drawing.Size(10, 20)
        Me.txtCodigoHospedaje.TabIndex = 1002
        Me.txtCodigoHospedaje.Visible = False
        '
        'btnInsertarAbajoHospedaje
        '
        Me.btnInsertarAbajoHospedaje.Location = New System.Drawing.Point(387, 122)
        Me.btnInsertarAbajoHospedaje.Name = "btnInsertarAbajoHospedaje"
        Me.btnInsertarAbajoHospedaje.Size = New System.Drawing.Size(23, 23)
        Me.btnInsertarAbajoHospedaje.TabIndex = 1001
        Me.btnInsertarAbajoHospedaje.Text = "i-"
        Me.btnInsertarAbajoHospedaje.UseVisualStyleBackColor = True
        '
        'txtCodigoLiquidacionHospedaje
        '
        Me.txtCodigoLiquidacionHospedaje.Location = New System.Drawing.Point(7, 19)
        Me.txtCodigoLiquidacionHospedaje.Name = "txtCodigoLiquidacionHospedaje"
        Me.txtCodigoLiquidacionHospedaje.Size = New System.Drawing.Size(10, 20)
        Me.txtCodigoLiquidacionHospedaje.TabIndex = 1001
        Me.txtCodigoLiquidacionHospedaje.Visible = False
        '
        'btnInsertarArribaHospedaje
        '
        Me.btnInsertarArribaHospedaje.Location = New System.Drawing.Point(387, 89)
        Me.btnInsertarArribaHospedaje.Name = "btnInsertarArribaHospedaje"
        Me.btnInsertarArribaHospedaje.Size = New System.Drawing.Size(23, 23)
        Me.btnInsertarArribaHospedaje.TabIndex = 1001
        Me.btnInsertarArribaHospedaje.Tag = ""
        Me.btnInsertarArribaHospedaje.Text = "i+"
        Me.btnInsertarArribaHospedaje.UseVisualStyleBackColor = True
        '
        'btnEliminarHospedaje
        '
        Me.btnEliminarHospedaje.Location = New System.Drawing.Point(387, 156)
        Me.btnEliminarHospedaje.Name = "btnEliminarHospedaje"
        Me.btnEliminarHospedaje.Size = New System.Drawing.Size(23, 23)
        Me.btnEliminarHospedaje.TabIndex = 71
        Me.btnEliminarHospedaje.Text = "-"
        Me.btnEliminarHospedaje.UseVisualStyleBackColor = True
        '
        'btnAgregarHospedaje
        '
        Me.btnAgregarHospedaje.Location = New System.Drawing.Point(387, 24)
        Me.btnAgregarHospedaje.Name = "btnAgregarHospedaje"
        Me.btnAgregarHospedaje.Size = New System.Drawing.Size(23, 23)
        Me.btnAgregarHospedaje.TabIndex = 70
        Me.btnAgregarHospedaje.Text = "+"
        Me.btnAgregarHospedaje.UseVisualStyleBackColor = True
        '
        'dgvHospedaje
        '
        Me.dgvHospedaje.AllowUserToAddRows = False
        Me.dgvHospedaje.AllowUserToResizeRows = False
        Me.dgvHospedaje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHospedaje.Location = New System.Drawing.Point(19, 85)
        Me.dgvHospedaje.MultiSelect = False
        Me.dgvHospedaje.Name = "dgvHospedaje"
        Me.dgvHospedaje.ReadOnly = True
        Me.dgvHospedaje.RowHeadersVisible = False
        Me.dgvHospedaje.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHospedaje.Size = New System.Drawing.Size(362, 101)
        Me.dgvHospedaje.TabIndex = 8
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(266, 35)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(31, 13)
        Me.Label39.TabIndex = 7
        Me.Label39.Text = "Total"
        '
        'txtTotalHospedaje
        '
        Me.txtTotalHospedaje.Location = New System.Drawing.Point(307, 29)
        Me.txtTotalHospedaje.Name = "txtTotalHospedaje"
        Me.txtTotalHospedaje.Size = New System.Drawing.Size(73, 20)
        Me.txtTotalHospedaje.TabIndex = 69
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(8, 52)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(63, 13)
        Me.Label41.TabIndex = 3
        Me.Label41.Text = "Descripción"
        '
        'txtDescripcionHospedaje
        '
        Me.txtDescripcionHospedaje.Location = New System.Drawing.Point(77, 52)
        Me.txtDescripcionHospedaje.Name = "txtDescripcionHospedaje"
        Me.txtDescripcionHospedaje.Size = New System.Drawing.Size(303, 20)
        Me.txtDescripcionHospedaje.TabIndex = 68
        '
        'dtpHospedaje
        '
        Me.dtpHospedaje.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHospedaje.Location = New System.Drawing.Point(77, 25)
        Me.dtpHospedaje.Name = "dtpHospedaje"
        Me.dtpHospedaje.Size = New System.Drawing.Size(95, 20)
        Me.dtpHospedaje.TabIndex = 66
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(163, 195)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(85, 13)
        Me.Label42.TabIndex = 62
        Me.Label42.Text = "Total Hospedaje"
        '
        'txtVuelto
        '
        Me.txtVuelto.Location = New System.Drawing.Point(627, 369)
        Me.txtVuelto.Name = "txtVuelto"
        Me.txtVuelto.Size = New System.Drawing.Size(100, 20)
        Me.txtVuelto.TabIndex = 1002
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(584, 372)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 1003
        Me.Label11.Text = "Vuelto"
        '
        'ChildLiquidacionControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1276, 807)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtVuelto)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnRptLiquidacionCombustible)
        Me.Controls.Add(Me.cbUnidadMedida)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.txtPeso)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.txtCarga)
        Me.Controls.Add(Me.btnRptLiquidacionDetallado)
        Me.Controls.Add(Me.btnRptLiquidacion)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtDiferenciaComb)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtDiferencia)
        Me.Controls.Add(Me.txtTotalGasto)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.cbGuia)
        Me.Controls.Add(Me.cbCamabaja)
        Me.Controls.Add(Me.cbTracto)
        Me.Controls.Add(Me.cbTrabajador)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cbEstado)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtDinero)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtNroLiquidacion)
        Me.Controls.Add(Me.txtCodigoLiquidacion)
        Me.Controls.Add(Me.dgvLiquidacion)
        Me.Controls.Add(Me.btnAgregarLiquidacion)
        Me.Controls.Add(Me.txtCombustibleVirtual)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.dtpLlegada)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.dtpSalida)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDestino)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtCombustibleFisico)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtOrigen)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ChildLiquidacionControl"
        Me.Text = "Liquidaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbPeajes.ResumeLayout(False)
        Me.gbPeajes.PerformLayout()
        CType(Me.dgvPeajes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbViaticos.ResumeLayout(False)
        Me.gbViaticos.PerformLayout()
        CType(Me.dgvViaticos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOtros.ResumeLayout(False)
        Me.gbOtros.PerformLayout()
        CType(Me.dgvOtros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvBalanza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvGuardiania, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvHospedaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnNuevo As Button
    Friend WithEvents cbGuia As ComboBox
    Friend WithEvents cbCamabaja As ComboBox
    Friend WithEvents cbTracto As ComboBox
    Friend WithEvents cbTrabajador As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cbEstado As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtDinero As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtNroLiquidacion As TextBox
    Friend WithEvents txtCodigoLiquidacion As TextBox
    Friend WithEvents dgvLiquidacion As DataGridView
    Friend WithEvents btnAgregarLiquidacion As Button
    Friend WithEvents txtCombustibleVirtual As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents dtpLlegada As DateTimePicker
    Friend WithEvents Label15 As Label
    Friend WithEvents dtpSalida As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDestino As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtCombustibleFisico As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtOtros As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtBalanza As TextBox
    Friend WithEvents txtHospedaje As TextBox
    Friend WithEvents txtGuardiania As TextBox
    Friend WithEvents txtViaticos As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPeajes As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtOrigen As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTotalGasto As TextBox
    Friend WithEvents txtDiferencia As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtDiferenciaComb As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents btnDeshacer As Button
    Friend WithEvents Label24 As Label
    Friend WithEvents lblFiltro As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents gbPeajes As GroupBox
    Friend WithEvents btnEliminarPeaje As Button
    Friend WithEvents btnAgregarPeaje As Button
    Friend WithEvents dgvPeajes As DataGridView
    Friend WithEvents Label28 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents txtTotalPeaje As TextBox
    Friend WithEvents txtEjesPeaje As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtLugarPeaje As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents dtpFechaHoraPeaje As DateTimePicker
    Friend WithEvents gbViaticos As GroupBox
    Friend WithEvents btnEliminarViatico As Button
    Friend WithEvents btnAgregarViatico As Button
    Friend WithEvents dgvViaticos As DataGridView
    Friend WithEvents Label32 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents txtTotalViatico As TextBox
    Friend WithEvents txtDescripcionViatico As TextBox
    Friend WithEvents dtpTurnoViaticos As DateTimePicker
    Friend WithEvents txtCantidadViatico As TextBox
    Friend WithEvents gbOtros As GroupBox
    Friend WithEvents btnEliminarOtros As Button
    Friend WithEvents btnAgregarOtros As Button
    Friend WithEvents dgvOtros As DataGridView
    Friend WithEvents Label34 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents txtTotalOtros As TextBox
    Friend WithEvents txtDescripcionOtros As TextBox
    Friend WithEvents btnRptLiquidacion As Button
    Friend WithEvents btnRptLiquidacionDetallado As Button
    Friend WithEvents txtCarga As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents txtPeso As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents cbUnidadMedida As ComboBox
    Friend WithEvents btnRptLiquidacionCombustible As Button
    Friend WithEvents btnInsertarArribaPeaje As Button
    Friend WithEvents btnInsertarDebajoPeaje As Button
    Friend WithEvents txtNroLineaPeaje As TextBox
    Friend WithEvents txtCodigoPeaje As TextBox
    Friend WithEvents txtCodigoLiquidacionPeaje As TextBox
    Friend WithEvents btnNuevoPeaje As Button
    Friend WithEvents btnNuevoViatico As Button
    Friend WithEvents btnInsertarAbajoViatico As Button
    Friend WithEvents btnInsertarArribaViatico As Button
    Friend WithEvents txtNroLineaViatico As TextBox
    Friend WithEvents txtCodigoViatico As TextBox
    Friend WithEvents txtCodigoLiquidacionViatico As TextBox
    Friend WithEvents btnInsertarAbajoOtro As Button
    Friend WithEvents txtNroLineaOtro As TextBox
    Friend WithEvents btnInsertarArribaOtro As Button
    Friend WithEvents btnNuevoOtro As Button
    Friend WithEvents txtCodigoOtro As TextBox
    Friend WithEvents txtCodigoLiquidacionOtro As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnNuevoHospedaje As Button
    Friend WithEvents Label38 As Label
    Friend WithEvents txtNroLineaHospedaje As TextBox
    Friend WithEvents txtCodigoHospedaje As TextBox
    Friend WithEvents btnInsertarAbajoHospedaje As Button
    Friend WithEvents txtCodigoLiquidacionHospedaje As TextBox
    Friend WithEvents btnInsertarArribaHospedaje As Button
    Friend WithEvents btnEliminarHospedaje As Button
    Friend WithEvents btnAgregarHospedaje As Button
    Friend WithEvents dgvHospedaje As DataGridView
    Friend WithEvents Label39 As Label
    Friend WithEvents txtTotalHospedaje As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents txtDescripcionHospedaje As TextBox
    Friend WithEvents dtpHospedaje As DateTimePicker
    Friend WithEvents Label42 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnNuevoBalanza As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNroLineaBalanza As TextBox
    Friend WithEvents txtCodigoBalanza As TextBox
    Friend WithEvents btnInsertarAbajoBalanza As Button
    Friend WithEvents txtCodigoLiquidacionBalanza As TextBox
    Friend WithEvents btnInsertarArribaBalanza As Button
    Friend WithEvents btnEliminarBalanza As Button
    Friend WithEvents btnAgregarBalanza As Button
    Friend WithEvents dgvBalanza As DataGridView
    Friend WithEvents Label10 As Label
    Friend WithEvents txtTotalBalanza As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents txtDescripcionBalanza As TextBox
    Friend WithEvents dtpBalanza As DateTimePicker
    Friend WithEvents Label47 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnNuevoGuardiania As Button
    Friend WithEvents Label40 As Label
    Friend WithEvents txtNroLineaGuardiania As TextBox
    Friend WithEvents txtCodigoGuardiania As TextBox
    Friend WithEvents btnInsertarAbajoGuardiania As Button
    Friend WithEvents txtCodigoLiquidacionGuardiania As TextBox
    Friend WithEvents btnInsertarArribaGuardiania As Button
    Friend WithEvents btnEliminarGuardiania As Button
    Friend WithEvents btnAgregarGuardiania As Button
    Friend WithEvents dgvGuardiania As DataGridView
    Friend WithEvents Label43 As Label
    Friend WithEvents txtTotalGuardiania As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents txtDescripcionGuardiania As TextBox
    Friend WithEvents dtpGuardiania As DateTimePicker
    Friend WithEvents Label45 As Label
    Friend WithEvents txtVuelto As TextBox
    Friend WithEvents Label11 As Label
End Class
