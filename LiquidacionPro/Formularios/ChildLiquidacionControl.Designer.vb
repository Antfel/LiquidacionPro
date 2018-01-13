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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtHospedaje = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtGuardiania = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
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
        Me.btnEliminarPeaje = New System.Windows.Forms.Button()
        Me.btnAgregarPeaje = New System.Windows.Forms.Button()
        Me.dgvPeajes = New System.Windows.Forms.DataGridView()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtTotalPeaje = New System.Windows.Forms.TextBox()
        Me.txtEjesPeaje = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtLugarPeaje = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dtpFechaHoraPeaje = New System.Windows.Forms.DateTimePicker()
        Me.gbViaticos = New System.Windows.Forms.GroupBox()
        Me.btnEliminarViatico = New System.Windows.Forms.Button()
        Me.btnAgregarViatico = New System.Windows.Forms.Button()
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
        Me.btnEliminarOtros = New System.Windows.Forms.Button()
        Me.btnAgregarOtros = New System.Windows.Forms.Button()
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
        CType(Me.dgvLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbPeajes.SuspendLayout()
        CType(Me.dgvPeajes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbViaticos.SuspendLayout()
        CType(Me.dgvViaticos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOtros.SuspendLayout()
        CType(Me.dgvOtros, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.cbGuia.Location = New System.Drawing.Point(129, 38)
        Me.cbGuia.Name = "cbGuia"
        Me.cbGuia.Size = New System.Drawing.Size(81, 21)
        Me.cbGuia.TabIndex = 51
        '
        'cbCamabaja
        '
        Me.cbCamabaja.FormattingEnabled = True
        Me.cbCamabaja.Location = New System.Drawing.Point(340, 64)
        Me.cbCamabaja.Name = "cbCamabaja"
        Me.cbCamabaja.Size = New System.Drawing.Size(100, 21)
        Me.cbCamabaja.TabIndex = 59
        '
        'cbTracto
        '
        Me.cbTracto.FormattingEnabled = True
        Me.cbTracto.Location = New System.Drawing.Point(340, 38)
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
        Me.Label20.Location = New System.Drawing.Point(29, 370)
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
        Me.cbEstado.Location = New System.Drawing.Point(75, 370)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(107, 21)
        Me.cbEstado.TabIndex = 74
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(22, 64)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 13)
        Me.Label19.TabIndex = 86
        Me.Label19.Text = "Dinero"
        '
        'txtDinero
        '
        Me.txtDinero.Location = New System.Drawing.Point(103, 64)
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
        Me.dgvLiquidacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLiquidacion.Location = New System.Drawing.Point(10, 462)
        Me.dgvLiquidacion.Name = "dgvLiquidacion"
        Me.dgvLiquidacion.ReadOnly = True
        Me.dgvLiquidacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLiquidacion.Size = New System.Drawing.Size(1189, 154)
        Me.dgvLiquidacion.TabIndex = 83
        '
        'btnAgregarLiquidacion
        '
        Me.btnAgregarLiquidacion.Location = New System.Drawing.Point(1002, 29)
        Me.btnAgregarLiquidacion.Name = "btnAgregarLiquidacion"
        Me.btnAgregarLiquidacion.Size = New System.Drawing.Size(132, 34)
        Me.btnAgregarLiquidacion.TabIndex = 82
        Me.btnAgregarLiquidacion.Text = "Grabar"
        Me.btnAgregarLiquidacion.UseVisualStyleBackColor = True
        '
        'txtCombustibleVirtual
        '
        Me.txtCombustibleVirtual.Location = New System.Drawing.Point(715, 370)
        Me.txtCombustibleVirtual.Name = "txtCombustibleVirtual"
        Me.txtCombustibleVirtual.Size = New System.Drawing.Size(108, 20)
        Me.txtCombustibleVirtual.TabIndex = 73
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(644, 370)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 13)
        Me.Label16.TabIndex = 81
        Me.Label16.Text = "Cons. Virtual"
        '
        'dtpLlegada
        '
        Me.dtpLlegada.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpLlegada.Location = New System.Drawing.Point(739, 64)
        Me.dtpLlegada.Name = "dtpLlegada"
        Me.dtpLlegada.Size = New System.Drawing.Size(150, 20)
        Me.dtpLlegada.TabIndex = 61
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(642, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 13)
        Me.Label15.TabIndex = 80
        Me.Label15.Text = "Fecha Llegada"
        '
        'dtpSalida
        '
        Me.dtpSalida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSalida.Location = New System.Drawing.Point(739, 38)
        Me.dtpSalida.Name = "dtpSalida"
        Me.dtpSalida.Size = New System.Drawing.Size(150, 20)
        Me.dtpSalida.TabIndex = 56
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(641, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Fecha Salida"
        '
        'txtDestino
        '
        Me.txtDestino.Location = New System.Drawing.Point(521, 64)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(107, 20)
        Me.txtDestino.TabIndex = 60
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(465, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 78
        Me.Label14.Text = "Destino"
        '
        'txtCombustibleFisico
        '
        Me.txtCombustibleFisico.Location = New System.Drawing.Point(715, 343)
        Me.txtCombustibleFisico.Name = "txtCombustibleFisico"
        Me.txtCombustibleFisico.Size = New System.Drawing.Size(107, 20)
        Me.txtCombustibleFisico.TabIndex = 71
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(646, 346)
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
        Me.txtOtros.TabIndex = 70
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
        Me.txtBalanza.Location = New System.Drawing.Point(507, 343)
        Me.txtBalanza.Name = "txtBalanza"
        Me.txtBalanza.Size = New System.Drawing.Size(107, 20)
        Me.txtBalanza.TabIndex = 69
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(456, 346)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "Balanza"
        '
        'txtHospedaje
        '
        Me.txtHospedaje.Location = New System.Drawing.Point(75, 343)
        Me.txtHospedaje.Name = "txtHospedaje"
        Me.txtHospedaje.Size = New System.Drawing.Size(107, 20)
        Me.txtHospedaje.TabIndex = 64
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 346)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 72
        Me.Label10.Text = "Hospedaje"
        '
        'txtGuardiania
        '
        Me.txtGuardiania.Location = New System.Drawing.Point(296, 343)
        Me.txtGuardiania.Name = "txtGuardiania"
        Me.txtGuardiania.Size = New System.Drawing.Size(107, 20)
        Me.txtGuardiania.TabIndex = 63
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(228, 346)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 68
        Me.Label9.Text = "Guardiania"
        '
        'txtViaticos
        '
        Me.txtViaticos.Location = New System.Drawing.Point(241, 192)
        Me.txtViaticos.Name = "txtViaticos"
        Me.txtViaticos.ReadOnly = True
        Me.txtViaticos.Size = New System.Drawing.Size(107, 20)
        Me.txtViaticos.TabIndex = 67
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
        Me.txtPeajes.TabIndex = 65
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
        Me.txtOrigen.Location = New System.Drawing.Point(521, 38)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(107, 20)
        Me.txtOrigen.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(465, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Origen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(236, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Placa Camabaja"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(260, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Placa Tracto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 38)
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
        Me.txtTotalGasto.Location = New System.Drawing.Point(295, 370)
        Me.txtTotalGasto.Name = "txtTotalGasto"
        Me.txtTotalGasto.ReadOnly = True
        Me.txtTotalGasto.Size = New System.Drawing.Size(107, 20)
        Me.txtTotalGasto.TabIndex = 89
        '
        'txtDiferencia
        '
        Me.txtDiferencia.Location = New System.Drawing.Point(507, 370)
        Me.txtDiferencia.Name = "txtDiferencia"
        Me.txtDiferencia.ReadOnly = True
        Me.txtDiferencia.Size = New System.Drawing.Size(107, 20)
        Me.txtDiferencia.TabIndex = 90
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(227, 370)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 13)
        Me.Label21.TabIndex = 91
        Me.Label21.Text = "Total Gasto"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(418, 370)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(86, 13)
        Me.Label22.TabIndex = 92
        Me.Label22.Text = "Diferencia Gasto"
        '
        'txtDiferenciaComb
        '
        Me.txtDiferenciaComb.Location = New System.Drawing.Point(929, 343)
        Me.txtDiferenciaComb.Name = "txtDiferenciaComb"
        Me.txtDiferenciaComb.ReadOnly = True
        Me.txtDiferenciaComb.Size = New System.Drawing.Size(74, 20)
        Me.txtDiferenciaComb.TabIndex = 93
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(832, 346)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(85, 13)
        Me.Label23.TabIndex = 94
        Me.Label23.Text = "Diferencia Cons."
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(250, 26)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(365, 20)
        Me.txtFiltro.TabIndex = 95
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(622, 26)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.btnFiltrar.TabIndex = 96
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'btnDeshacer
        '
        Me.btnDeshacer.Location = New System.Drawing.Point(703, 26)
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.Size = New System.Drawing.Size(75, 23)
        Me.btnDeshacer.TabIndex = 97
        Me.btnDeshacer.Text = "Deshacer"
        Me.btnDeshacer.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(12, 26)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(53, 13)
        Me.Label24.TabIndex = 98
        Me.Label24.Text = "Filtrar por:"
        '
        'lblFiltro
        '
        Me.lblFiltro.AutoSize = True
        Me.lblFiltro.Location = New System.Drawing.Point(72, 26)
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
        Me.GroupBox1.Location = New System.Drawing.Point(10, 397)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(789, 59)
        Me.GroupBox1.TabIndex = 100
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'gbPeajes
        '
        Me.gbPeajes.Controls.Add(Me.btnEliminarPeaje)
        Me.gbPeajes.Controls.Add(Me.btnAgregarPeaje)
        Me.gbPeajes.Controls.Add(Me.dgvPeajes)
        Me.gbPeajes.Controls.Add(Me.Label28)
        Me.gbPeajes.Controls.Add(Me.Label27)
        Me.gbPeajes.Controls.Add(Me.txtTotalPeaje)
        Me.gbPeajes.Controls.Add(Me.txtEjesPeaje)
        Me.gbPeajes.Controls.Add(Me.Label26)
        Me.gbPeajes.Controls.Add(Me.txtLugarPeaje)
        Me.gbPeajes.Controls.Add(Me.Label25)
        Me.gbPeajes.Controls.Add(Me.dtpFechaHoraPeaje)
        Me.gbPeajes.Controls.Add(Me.txtPeajes)
        Me.gbPeajes.Controls.Add(Me.Label7)
        Me.gbPeajes.Location = New System.Drawing.Point(10, 117)
        Me.gbPeajes.Name = "gbPeajes"
        Me.gbPeajes.Size = New System.Drawing.Size(392, 220)
        Me.gbPeajes.TabIndex = 101
        Me.gbPeajes.TabStop = False
        Me.gbPeajes.Text = "Control de Peajes"
        '
        'btnEliminarPeaje
        '
        Me.btnEliminarPeaje.Location = New System.Drawing.Point(363, 137)
        Me.btnEliminarPeaje.Name = "btnEliminarPeaje"
        Me.btnEliminarPeaje.Size = New System.Drawing.Size(23, 23)
        Me.btnEliminarPeaje.TabIndex = 10
        Me.btnEliminarPeaje.Text = "-"
        Me.btnEliminarPeaje.UseVisualStyleBackColor = True
        '
        'btnAgregarPeaje
        '
        Me.btnAgregarPeaje.Location = New System.Drawing.Point(363, 107)
        Me.btnAgregarPeaje.Name = "btnAgregarPeaje"
        Me.btnAgregarPeaje.Size = New System.Drawing.Size(23, 23)
        Me.btnAgregarPeaje.TabIndex = 9
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
        Me.dgvPeajes.Size = New System.Drawing.Size(338, 101)
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
        Me.txtTotalPeaje.TabIndex = 5
        '
        'txtEjesPeaje
        '
        Me.txtEjesPeaje.Location = New System.Drawing.Point(308, 25)
        Me.txtEjesPeaje.Name = "txtEjesPeaje"
        Me.txtEjesPeaje.Size = New System.Drawing.Size(73, 20)
        Me.txtEjesPeaje.TabIndex = 4
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
        Me.txtLugarPeaje.TabIndex = 2
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
        'dtpFechaHoraPeaje
        '
        Me.dtpFechaHoraPeaje.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHoraPeaje.Location = New System.Drawing.Point(93, 25)
        Me.dtpFechaHoraPeaje.Name = "dtpFechaHoraPeaje"
        Me.dtpFechaHoraPeaje.Size = New System.Drawing.Size(150, 20)
        Me.dtpFechaHoraPeaje.TabIndex = 0
        '
        'gbViaticos
        '
        Me.gbViaticos.Controls.Add(Me.btnEliminarViatico)
        Me.gbViaticos.Controls.Add(Me.btnAgregarViatico)
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
        Me.gbViaticos.Location = New System.Drawing.Point(408, 117)
        Me.gbViaticos.Name = "gbViaticos"
        Me.gbViaticos.Size = New System.Drawing.Size(392, 220)
        Me.gbViaticos.TabIndex = 102
        Me.gbViaticos.TabStop = False
        Me.gbViaticos.Text = "Viáticos"
        '
        'btnEliminarViatico
        '
        Me.btnEliminarViatico.Location = New System.Drawing.Point(358, 137)
        Me.btnEliminarViatico.Name = "btnEliminarViatico"
        Me.btnEliminarViatico.Size = New System.Drawing.Size(23, 23)
        Me.btnEliminarViatico.TabIndex = 10
        Me.btnEliminarViatico.Text = "-"
        Me.btnEliminarViatico.UseVisualStyleBackColor = True
        '
        'btnAgregarViatico
        '
        Me.btnAgregarViatico.Location = New System.Drawing.Point(358, 106)
        Me.btnAgregarViatico.Name = "btnAgregarViatico"
        Me.btnAgregarViatico.Size = New System.Drawing.Size(23, 23)
        Me.btnAgregarViatico.TabIndex = 9
        Me.btnAgregarViatico.Text = "+"
        Me.btnAgregarViatico.UseVisualStyleBackColor = True
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
        Me.dgvViaticos.Size = New System.Drawing.Size(338, 101)
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
        Me.txtTotalViatico.TabIndex = 3
        '
        'txtDescripcionViatico
        '
        Me.txtDescripcionViatico.Location = New System.Drawing.Point(76, 56)
        Me.txtDescripcionViatico.Name = "txtDescripcionViatico"
        Me.txtDescripcionViatico.Size = New System.Drawing.Size(149, 20)
        Me.txtDescripcionViatico.TabIndex = 2
        '
        'dtpTurnoViaticos
        '
        Me.dtpTurnoViaticos.Location = New System.Drawing.Point(231, 29)
        Me.dtpTurnoViaticos.Name = "dtpTurnoViaticos"
        Me.dtpTurnoViaticos.Size = New System.Drawing.Size(150, 20)
        Me.dtpTurnoViaticos.TabIndex = 1
        '
        'txtCantidadViatico
        '
        Me.txtCantidadViatico.Location = New System.Drawing.Point(76, 29)
        Me.txtCantidadViatico.Name = "txtCantidadViatico"
        Me.txtCantidadViatico.Size = New System.Drawing.Size(60, 20)
        Me.txtCantidadViatico.TabIndex = 0
        '
        'gbOtros
        '
        Me.gbOtros.Controls.Add(Me.btnEliminarOtros)
        Me.gbOtros.Controls.Add(Me.btnAgregarOtros)
        Me.gbOtros.Controls.Add(Me.dgvOtros)
        Me.gbOtros.Controls.Add(Me.Label34)
        Me.gbOtros.Controls.Add(Me.Label33)
        Me.gbOtros.Controls.Add(Me.txtTotalOtros)
        Me.gbOtros.Controls.Add(Me.txtDescripcionOtros)
        Me.gbOtros.Controls.Add(Me.txtOtros)
        Me.gbOtros.Controls.Add(Me.Label12)
        Me.gbOtros.Location = New System.Drawing.Point(807, 117)
        Me.gbOtros.Name = "gbOtros"
        Me.gbOtros.Size = New System.Drawing.Size(392, 220)
        Me.gbOtros.TabIndex = 103
        Me.gbOtros.TabStop = False
        Me.gbOtros.Text = "Otros"
        '
        'btnEliminarOtros
        '
        Me.btnEliminarOtros.Location = New System.Drawing.Point(355, 137)
        Me.btnEliminarOtros.Name = "btnEliminarOtros"
        Me.btnEliminarOtros.Size = New System.Drawing.Size(23, 23)
        Me.btnEliminarOtros.TabIndex = 6
        Me.btnEliminarOtros.Text = "-"
        Me.btnEliminarOtros.UseVisualStyleBackColor = True
        '
        'btnAgregarOtros
        '
        Me.btnAgregarOtros.Location = New System.Drawing.Point(355, 107)
        Me.btnAgregarOtros.Name = "btnAgregarOtros"
        Me.btnAgregarOtros.Size = New System.Drawing.Size(23, 23)
        Me.btnAgregarOtros.TabIndex = 5
        Me.btnAgregarOtros.Text = "+"
        Me.btnAgregarOtros.UseVisualStyleBackColor = True
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
        Me.dgvOtros.Size = New System.Drawing.Size(338, 101)
        Me.dgvOtros.TabIndex = 4
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(273, 28)
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
        Me.txtTotalOtros.Location = New System.Drawing.Point(310, 24)
        Me.txtTotalOtros.Name = "txtTotalOtros"
        Me.txtTotalOtros.Size = New System.Drawing.Size(76, 20)
        Me.txtTotalOtros.TabIndex = 1
        '
        'txtDescripcionOtros
        '
        Me.txtDescripcionOtros.Location = New System.Drawing.Point(88, 24)
        Me.txtDescripcionOtros.Name = "txtDescripcionOtros"
        Me.txtDescripcionOtros.Size = New System.Drawing.Size(155, 20)
        Me.txtDescripcionOtros.TabIndex = 0
        '
        'btnRptLiquidacion
        '
        Me.btnRptLiquidacion.Location = New System.Drawing.Point(835, 405)
        Me.btnRptLiquidacion.Name = "btnRptLiquidacion"
        Me.btnRptLiquidacion.Size = New System.Drawing.Size(100, 51)
        Me.btnRptLiquidacion.TabIndex = 104
        Me.btnRptLiquidacion.Text = "Liquidación de viaje general"
        Me.btnRptLiquidacion.UseVisualStyleBackColor = True
        '
        'btnRptLiquidacionDetallado
        '
        Me.btnRptLiquidacionDetallado.Location = New System.Drawing.Point(955, 405)
        Me.btnRptLiquidacionDetallado.Name = "btnRptLiquidacionDetallado"
        Me.btnRptLiquidacionDetallado.Size = New System.Drawing.Size(100, 51)
        Me.btnRptLiquidacionDetallado.TabIndex = 105
        Me.btnRptLiquidacionDetallado.Text = "Liquidación de viaje detallado"
        Me.btnRptLiquidacionDetallado.UseVisualStyleBackColor = True
        '
        'txtCarga
        '
        Me.txtCarga.Location = New System.Drawing.Point(103, 90)
        Me.txtCarga.Name = "txtCarga"
        Me.txtCarga.Size = New System.Drawing.Size(217, 20)
        Me.txtCarga.TabIndex = 106
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(10, 90)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(35, 13)
        Me.Label35.TabIndex = 107
        Me.Label35.Text = "Carga"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(340, 90)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(31, 13)
        Me.Label36.TabIndex = 108
        Me.Label36.Text = "Peso"
        '
        'txtPeso
        '
        Me.txtPeso.Location = New System.Drawing.Point(378, 90)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(85, 20)
        Me.txtPeso.TabIndex = 109
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(469, 90)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(41, 13)
        Me.Label37.TabIndex = 110
        Me.Label37.Text = "Unidad"
        '
        'cbUnidadMedida
        '
        Me.cbUnidadMedida.FormattingEnabled = True
        Me.cbUnidadMedida.Location = New System.Drawing.Point(521, 90)
        Me.cbUnidadMedida.Name = "cbUnidadMedida"
        Me.cbUnidadMedida.Size = New System.Drawing.Size(112, 21)
        Me.cbUnidadMedida.TabIndex = 111
        '
        'btnRptLiquidacionCombustible
        '
        Me.btnRptLiquidacionCombustible.Location = New System.Drawing.Point(1083, 404)
        Me.btnRptLiquidacionCombustible.Name = "btnRptLiquidacionCombustible"
        Me.btnRptLiquidacionCombustible.Size = New System.Drawing.Size(100, 51)
        Me.btnRptLiquidacionCombustible.TabIndex = 113
        Me.btnRptLiquidacionCombustible.Text = "Liquidación de Combustible"
        Me.btnRptLiquidacionCombustible.UseVisualStyleBackColor = True
        '
        'ChildLiquidacionControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1216, 644)
        Me.Controls.Add(Me.btnRptLiquidacionCombustible)
        Me.Controls.Add(Me.cbUnidadMedida)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.txtPeso)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.txtCarga)
        Me.Controls.Add(Me.btnRptLiquidacionDetallado)
        Me.Controls.Add(Me.btnRptLiquidacion)
        Me.Controls.Add(Me.gbOtros)
        Me.Controls.Add(Me.gbViaticos)
        Me.Controls.Add(Me.gbPeajes)
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
        Me.Controls.Add(Me.txtBalanza)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtHospedaje)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtGuardiania)
        Me.Controls.Add(Me.Label9)
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
    Friend WithEvents Label11 As Label
    Friend WithEvents txtHospedaje As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtGuardiania As TextBox
    Friend WithEvents Label9 As Label
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
End Class
