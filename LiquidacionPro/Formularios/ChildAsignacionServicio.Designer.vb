<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChildAsignacionServicio
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtFechaAsignacion = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOrdenServicio = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbEstado = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbDetalleOrden = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbTrabajador = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbCarreta = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dgvDetalleAsignacion = New System.Windows.Forms.DataGridView()
        Me.cbUnidad = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ObservaCarga = New System.Windows.Forms.TextBox()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.txtAncho = New System.Windows.Forms.TextBox()
        Me.txtLargo = New System.Windows.Forms.TextBox()
        Me.txtAlto = New System.Windows.Forms.TextBox()
        Me.txtTipoServicio = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgvPendientes = New System.Windows.Forms.DataGridView()
        Me.lbTItuloPendientes = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvDetalleAsignacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha de Asignacion"
        '
        'dtFechaAsignacion
        '
        Me.dtFechaAsignacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaAsignacion.Location = New System.Drawing.Point(151, 23)
        Me.dtFechaAsignacion.Name = "dtFechaAsignacion"
        Me.dtFechaAsignacion.Size = New System.Drawing.Size(98, 20)
        Me.dtFechaAsignacion.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(267, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nro de Orden de Servicio"
        '
        'txtOrdenServicio
        '
        Me.txtOrdenServicio.Location = New System.Drawing.Point(400, 23)
        Me.txtOrdenServicio.Name = "txtOrdenServicio"
        Me.txtOrdenServicio.ReadOnly = True
        Me.txtOrdenServicio.Size = New System.Drawing.Size(100, 20)
        Me.txtOrdenServicio.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Observaciones"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(41, 72)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(708, 20)
        Me.txtObservacion.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1048, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Guardar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(517, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Estado"
        '
        'cbEstado
        '
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(563, 21)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(186, 21)
        Me.cbEstado.TabIndex = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbDetalleOrden)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cbTrabajador)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cbCarreta)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.dgvDetalleAsignacion)
        Me.GroupBox2.Controls.Add(Me.cbUnidad)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(41, 111)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(904, 276)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle de Asignacion"
        '
        'cbDetalleOrden
        '
        Me.cbDetalleOrden.FormattingEnabled = True
        Me.cbDetalleOrden.Location = New System.Drawing.Point(622, 42)
        Me.cbDetalleOrden.Name = "cbDetalleOrden"
        Me.cbDetalleOrden.Size = New System.Drawing.Size(165, 21)
        Me.cbDetalleOrden.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(620, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(143, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Detalle de Orden de Servicio"
        '
        'cbTrabajador
        '
        Me.cbTrabajador.FormattingEnabled = True
        Me.cbTrabajador.Location = New System.Drawing.Point(316, 42)
        Me.cbTrabajador.Name = "cbTrabajador"
        Me.cbTrabajador.Size = New System.Drawing.Size(277, 21)
        Me.cbTrabajador.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(313, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Trabajador"
        '
        'cbCarreta
        '
        Me.cbCarreta.FormattingEnabled = True
        Me.cbCarreta.Location = New System.Drawing.Point(170, 42)
        Me.cbCarreta.Name = "cbCarreta"
        Me.cbCarreta.Size = New System.Drawing.Size(119, 21)
        Me.cbCarreta.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(167, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Carreta"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(836, 168)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(35, 34)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "-"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(836, 128)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(35, 34)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "+"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dgvDetalleAsignacion
        '
        Me.dgvDetalleAsignacion.AllowUserToAddRows = False
        Me.dgvDetalleAsignacion.AllowUserToDeleteRows = False
        Me.dgvDetalleAsignacion.AllowUserToResizeColumns = False
        Me.dgvDetalleAsignacion.AllowUserToResizeRows = False
        Me.dgvDetalleAsignacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDetalleAsignacion.Location = New System.Drawing.Point(19, 84)
        Me.dgvDetalleAsignacion.MultiSelect = False
        Me.dgvDetalleAsignacion.Name = "dgvDetalleAsignacion"
        Me.dgvDetalleAsignacion.ReadOnly = True
        Me.dgvDetalleAsignacion.RowHeadersVisible = False
        Me.dgvDetalleAsignacion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDetalleAsignacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleAsignacion.Size = New System.Drawing.Size(780, 171)
        Me.dgvDetalleAsignacion.TabIndex = 2
        '
        'cbUnidad
        '
        Me.cbUnidad.FormattingEnabled = True
        Me.cbUnidad.Location = New System.Drawing.Point(37, 42)
        Me.cbUnidad.Name = "cbUnidad"
        Me.cbUnidad.Size = New System.Drawing.Size(99, 21)
        Me.cbUnidad.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Unidad"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ObservaCarga)
        Me.GroupBox3.Controls.Add(Me.txtPeso)
        Me.GroupBox3.Controls.Add(Me.txtAncho)
        Me.GroupBox3.Controls.Add(Me.txtLargo)
        Me.GroupBox3.Controls.Add(Me.txtAlto)
        Me.GroupBox3.Controls.Add(Me.txtTipoServicio)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(967, 111)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(342, 276)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos de la Carga"
        '
        'ObservaCarga
        '
        Me.ObservaCarga.Location = New System.Drawing.Point(109, 177)
        Me.ObservaCarga.Multiline = True
        Me.ObservaCarga.Name = "ObservaCarga"
        Me.ObservaCarga.ReadOnly = True
        Me.ObservaCarga.Size = New System.Drawing.Size(227, 78)
        Me.ObservaCarga.TabIndex = 11
        '
        'txtPeso
        '
        Me.txtPeso.Location = New System.Drawing.Point(109, 151)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.ReadOnly = True
        Me.txtPeso.Size = New System.Drawing.Size(227, 20)
        Me.txtPeso.TabIndex = 10
        '
        'txtAncho
        '
        Me.txtAncho.Location = New System.Drawing.Point(109, 125)
        Me.txtAncho.Name = "txtAncho"
        Me.txtAncho.ReadOnly = True
        Me.txtAncho.Size = New System.Drawing.Size(227, 20)
        Me.txtAncho.TabIndex = 9
        '
        'txtLargo
        '
        Me.txtLargo.Location = New System.Drawing.Point(109, 99)
        Me.txtLargo.Name = "txtLargo"
        Me.txtLargo.ReadOnly = True
        Me.txtLargo.Size = New System.Drawing.Size(227, 20)
        Me.txtLargo.TabIndex = 8
        '
        'txtAlto
        '
        Me.txtAlto.Location = New System.Drawing.Point(109, 73)
        Me.txtAlto.Name = "txtAlto"
        Me.txtAlto.ReadOnly = True
        Me.txtAlto.Size = New System.Drawing.Size(227, 20)
        Me.txtAlto.TabIndex = 7
        '
        'txtTipoServicio
        '
        Me.txtTipoServicio.Location = New System.Drawing.Point(109, 47)
        Me.txtTipoServicio.Name = "txtTipoServicio"
        Me.txtTipoServicio.ReadOnly = True
        Me.txtTipoServicio.Size = New System.Drawing.Size(227, 20)
        Me.txtTipoServicio.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(23, 177)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Observacion"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 50)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Tipo de Servicio"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(59, 154)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Peso"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(52, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Ancho"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(56, 102)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Largo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(65, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Alto"
        '
        'dgvPendientes
        '
        Me.dgvPendientes.AllowUserToAddRows = False
        Me.dgvPendientes.AllowUserToDeleteRows = False
        Me.dgvPendientes.AllowUserToResizeRows = False
        Me.dgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPendientes.Location = New System.Drawing.Point(976, 468)
        Me.dgvPendientes.MultiSelect = False
        Me.dgvPendientes.Name = "dgvPendientes"
        Me.dgvPendientes.ReadOnly = True
        Me.dgvPendientes.RowHeadersVisible = False
        Me.dgvPendientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPendientes.ShowEditingIcon = False
        Me.dgvPendientes.Size = New System.Drawing.Size(327, 134)
        Me.dgvPendientes.TabIndex = 13
        '
        'lbTItuloPendientes
        '
        Me.lbTItuloPendientes.AutoSize = True
        Me.lbTItuloPendientes.Location = New System.Drawing.Point(990, 441)
        Me.lbTItuloPendientes.Name = "lbTItuloPendientes"
        Me.lbTItuloPendientes.Size = New System.Drawing.Size(183, 13)
        Me.lbTItuloPendientes.TabIndex = 14
        Me.lbTItuloPendientes.Text = "Ordenes con asignaciones pendiente"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(780, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 13)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Origen"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(780, 72)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "Destino"
        '
        'txtOrigen
        '
        Me.txtOrigen.Location = New System.Drawing.Point(845, 23)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.ReadOnly = True
        Me.txtOrigen.Size = New System.Drawing.Size(128, 20)
        Me.txtOrigen.TabIndex = 17
        '
        'txtDestino
        '
        Me.txtDestino.Location = New System.Drawing.Point(845, 72)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.ReadOnly = True
        Me.txtDestino.Size = New System.Drawing.Size(128, 20)
        Me.txtDestino.TabIndex = 18
        '
        'ChildAsignacionServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1321, 628)
        Me.Controls.Add(Me.txtDestino)
        Me.Controls.Add(Me.txtOrigen)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lbTItuloPendientes)
        Me.Controls.Add(Me.dgvPendientes)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cbEstado)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtOrdenServicio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtFechaAsignacion)
        Me.Controls.Add(Me.Label2)
        Me.Name = "ChildAsignacionServicio"
        Me.Text = "ChildAsignacionServicio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvDetalleAsignacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents dtFechaAsignacion As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents txtOrdenServicio As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents cbEstado As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cbTrabajador As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cbCarreta As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents dgvDetalleAsignacion As DataGridView
    Friend WithEvents cbUnidad As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbDetalleOrden As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ObservaCarga As TextBox
    Friend WithEvents txtPeso As TextBox
    Friend WithEvents txtAncho As TextBox
    Friend WithEvents txtLargo As TextBox
    Friend WithEvents txtAlto As TextBox
    Friend WithEvents txtTipoServicio As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents dgvPendientes As DataGridView
    Friend WithEvents lbTItuloPendientes As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtOrigen As TextBox
    Friend WithEvents txtDestino As TextBox
End Class
