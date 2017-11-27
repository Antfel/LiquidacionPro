<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLiquidacion
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.TabControlModulo = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
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
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rptLiquidaciones = New LiquidacionPro.rptLiquidaciones()
        Me.DataTable1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataTable1TableAdapter = New LiquidacionPro.rptLiquidacionesTableAdapters.DataTable1TableAdapter()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbEstadoRpt = New System.Windows.Forms.ComboBox()
        Me.TabControlModulo.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.rptLiquidaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControlModulo
        '
        Me.TabControlModulo.Controls.Add(Me.TabPage1)
        Me.TabControlModulo.Controls.Add(Me.TabPage2)
        Me.TabControlModulo.Controls.Add(Me.TabPage3)
        Me.TabControlModulo.Location = New System.Drawing.Point(154, 12)
        Me.TabControlModulo.Name = "TabControlModulo"
        Me.TabControlModulo.SelectedIndex = 0
        Me.TabControlModulo.Size = New System.Drawing.Size(1155, 533)
        Me.TabControlModulo.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnNuevo)
        Me.TabPage1.Controls.Add(Me.cbGuia)
        Me.TabPage1.Controls.Add(Me.cbCamabaja)
        Me.TabPage1.Controls.Add(Me.cbTracto)
        Me.TabPage1.Controls.Add(Me.cbTrabajador)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.cbEstado)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.txtDinero)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.txtNroLiquidacion)
        Me.TabPage1.Controls.Add(Me.txtCodigoLiquidacion)
        Me.TabPage1.Controls.Add(Me.dgvLiquidacion)
        Me.TabPage1.Controls.Add(Me.btnAgregarLiquidacion)
        Me.TabPage1.Controls.Add(Me.txtCombustibleVirtual)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.dtpLlegada)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.dtpSalida)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtDestino)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.txtCombustibleFisico)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtOtros)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.txtBalanza)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.txtHospedaje)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtGuardiania)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtViaticos)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtPeajes)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtOrigen)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1147, 507)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Liquidación"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(875, 134)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(132, 51)
        Me.btnNuevo.TabIndex = 45
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'cbGuia
        '
        Me.cbGuia.FormattingEnabled = True
        Me.cbGuia.Location = New System.Drawing.Point(131, 58)
        Me.cbGuia.Name = "cbGuia"
        Me.cbGuia.Size = New System.Drawing.Size(81, 21)
        Me.cbGuia.TabIndex = 4
        '
        'cbCamabaja
        '
        Me.cbCamabaja.FormattingEnabled = True
        Me.cbCamabaja.Location = New System.Drawing.Point(342, 90)
        Me.cbCamabaja.Name = "cbCamabaja"
        Me.cbCamabaja.Size = New System.Drawing.Size(100, 21)
        Me.cbCamabaja.TabIndex = 9
        '
        'cbTracto
        '
        Me.cbTracto.FormattingEnabled = True
        Me.cbTracto.Location = New System.Drawing.Point(342, 55)
        Me.cbTracto.Name = "cbTracto"
        Me.cbTracto.Size = New System.Drawing.Size(100, 21)
        Me.cbTracto.TabIndex = 5
        '
        'cbTrabajador
        '
        Me.cbTrabajador.FormattingEnabled = True
        Me.cbTrabajador.Location = New System.Drawing.Point(566, 17)
        Me.cbTrabajador.Name = "cbTrabajador"
        Me.cbTrabajador.Size = New System.Drawing.Size(269, 21)
        Me.cbTrabajador.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(24, 196)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 13)
        Me.Label20.TabIndex = 44
        Me.Label20.Text = "Estado"
        '
        'cbEstado
        '
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.ItemHeight = 13
        Me.cbEstado.Items.AddRange(New Object() {"1", "2"})
        Me.cbEstado.Location = New System.Drawing.Point(105, 196)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(107, 21)
        Me.cbEstado.TabIndex = 20
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(24, 93)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 13)
        Me.Label19.TabIndex = 42
        Me.Label19.Text = "Dinero"
        '
        'txtDinero
        '
        Me.txtDinero.Location = New System.Drawing.Point(105, 93)
        Me.txtDinero.Name = "txtDinero"
        Me.txtDinero.Size = New System.Drawing.Size(107, 20)
        Me.txtDinero.TabIndex = 8
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 20)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(97, 13)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "Código Liquidación"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(246, 21)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 13)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "Nro. Liquidación"
        '
        'txtNroLiquidacion
        '
        Me.txtNroLiquidacion.Location = New System.Drawing.Point(342, 18)
        Me.txtNroLiquidacion.Name = "txtNroLiquidacion"
        Me.txtNroLiquidacion.Size = New System.Drawing.Size(100, 20)
        Me.txtNroLiquidacion.TabIndex = 2
        '
        'txtCodigoLiquidacion
        '
        Me.txtCodigoLiquidacion.Location = New System.Drawing.Point(112, 18)
        Me.txtCodigoLiquidacion.Name = "txtCodigoLiquidacion"
        Me.txtCodigoLiquidacion.ReadOnly = True
        Me.txtCodigoLiquidacion.Size = New System.Drawing.Size(99, 20)
        Me.txtCodigoLiquidacion.TabIndex = 1
        '
        'dgvLiquidacion
        '
        Me.dgvLiquidacion.AllowUserToAddRows = False
        Me.dgvLiquidacion.AllowUserToDeleteRows = False
        Me.dgvLiquidacion.AllowUserToOrderColumns = True
        Me.dgvLiquidacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLiquidacion.Location = New System.Drawing.Point(30, 231)
        Me.dgvLiquidacion.Name = "dgvLiquidacion"
        Me.dgvLiquidacion.ReadOnly = True
        Me.dgvLiquidacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLiquidacion.Size = New System.Drawing.Size(977, 251)
        Me.dgvLiquidacion.TabIndex = 36
        '
        'btnAgregarLiquidacion
        '
        Me.btnAgregarLiquidacion.Location = New System.Drawing.Point(875, 76)
        Me.btnAgregarLiquidacion.Name = "btnAgregarLiquidacion"
        Me.btnAgregarLiquidacion.Size = New System.Drawing.Size(132, 52)
        Me.btnAgregarLiquidacion.TabIndex = 34
        Me.btnAgregarLiquidacion.Text = "Grabar"
        Me.btnAgregarLiquidacion.UseVisualStyleBackColor = True
        '
        'txtCombustibleVirtual
        '
        Me.txtCombustibleVirtual.Location = New System.Drawing.Point(728, 165)
        Me.txtCombustibleVirtual.Name = "txtCombustibleVirtual"
        Me.txtCombustibleVirtual.Size = New System.Drawing.Size(107, 20)
        Me.txtCombustibleVirtual.TabIndex = 19
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(643, 168)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 13)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Comb. Virtual"
        '
        'dtpLlegada
        '
        Me.dtpLlegada.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpLlegada.Location = New System.Drawing.Point(728, 93)
        Me.dtpLlegada.Name = "dtpLlegada"
        Me.dtpLlegada.Size = New System.Drawing.Size(107, 20)
        Me.dtpLlegada.TabIndex = 11
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(644, 96)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Fecha Llegada"
        '
        'dtpSalida
        '
        Me.dtpSalida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSalida.Location = New System.Drawing.Point(728, 55)
        Me.dtpSalida.Name = "dtpSalida"
        Me.dtpSalida.Size = New System.Drawing.Size(107, 20)
        Me.dtpSalida.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(643, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Fecha Salida"
        '
        'txtDestino
        '
        Me.txtDestino.Location = New System.Drawing.Point(523, 93)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(107, 20)
        Me.txtDestino.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(467, 97)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Destino"
        '
        'txtCombustibleFisico
        '
        Me.txtCombustibleFisico.Location = New System.Drawing.Point(523, 162)
        Me.txtCombustibleFisico.Name = "txtCombustibleFisico"
        Me.txtCombustibleFisico.Size = New System.Drawing.Size(107, 20)
        Me.txtCombustibleFisico.TabIndex = 18
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(454, 168)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Comb. Fisico"
        '
        'txtOtros
        '
        Me.txtOtros.Location = New System.Drawing.Point(336, 165)
        Me.txtOtros.Name = "txtOtros"
        Me.txtOtros.Size = New System.Drawing.Size(107, 20)
        Me.txtOtros.TabIndex = 17
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(237, 165)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Otros"
        '
        'txtBalanza
        '
        Me.txtBalanza.Location = New System.Drawing.Point(105, 162)
        Me.txtBalanza.Name = "txtBalanza"
        Me.txtBalanza.Size = New System.Drawing.Size(107, 20)
        Me.txtBalanza.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(19, 165)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Balanza"
        '
        'txtHospedaje
        '
        Me.txtHospedaje.Location = New System.Drawing.Point(336, 126)
        Me.txtHospedaje.Name = "txtHospedaje"
        Me.txtHospedaje.Size = New System.Drawing.Size(107, 20)
        Me.txtHospedaje.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(237, 129)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Hospedaje"
        '
        'txtGuardiania
        '
        Me.txtGuardiania.Location = New System.Drawing.Point(105, 126)
        Me.txtGuardiania.Name = "txtGuardiania"
        Me.txtGuardiania.Size = New System.Drawing.Size(107, 20)
        Me.txtGuardiania.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 129)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Guardiania"
        '
        'txtViaticos
        '
        Me.txtViaticos.Location = New System.Drawing.Point(728, 130)
        Me.txtViaticos.Name = "txtViaticos"
        Me.txtViaticos.Size = New System.Drawing.Size(107, 20)
        Me.txtViaticos.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(643, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Viaticos"
        '
        'txtPeajes
        '
        Me.txtPeajes.Location = New System.Drawing.Point(523, 129)
        Me.txtPeajes.Name = "txtPeajes"
        Me.txtPeajes.Size = New System.Drawing.Size(107, 20)
        Me.txtPeajes.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(467, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Peajes"
        '
        'txtOrigen
        '
        Me.txtOrigen.Location = New System.Drawing.Point(523, 55)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(107, 20)
        Me.txtOrigen.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(467, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Origen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(238, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Placa Camabaja"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(262, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Placa Tracto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Guias de Rem. Transp."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(467, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre de Chofer"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1147, 507)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(875, 134)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(132, 51)
        Me.btnNuevo.TabIndex = 45
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'frmLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1321, 557)
        Me.Controls.Add(Me.TabControlModulo)
        Me.Name = "frmLiquidacion"
        Me.Text = "Liquidación de Viajes"
        Me.TabControlModulo.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.rptLiquidaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControlModulo As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtOrigen As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
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
    Friend WithEvents dgvLiquidacion As DataGridView
    Friend WithEvents btnAgregarLiquidacion As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtCodigoLiquidacion As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtNroLiquidacion As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtDinero As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cbEstado As ComboBox
    Friend WithEvents cbTrabajador As ComboBox
    Friend WithEvents cbGuia As ComboBox
    Friend WithEvents cbCamabaja As ComboBox
    Friend WithEvents cbTracto As ComboBox
    Friend WithEvents btnNuevo As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Button1 As Button
    Friend WithEvents DataTable1BindingSource As BindingSource
    Friend WithEvents rptLiquidaciones As rptLiquidaciones
    Friend WithEvents DataTable1TableAdapter As rptLiquidacionesTableAdapters.DataTable1TableAdapter
    Friend WithEvents Label21 As Label
    Friend WithEvents cbEstadoRpt As ComboBox
End Class
