<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChildOrdenServicio
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
        Me.components = New System.ComponentModel.Container()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtIgv = New System.Windows.Forms.TextBox()
        Me.chbxIgv = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.dgvDetalleOrdenServicio = New System.Windows.Forms.DataGridView()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAgregarDetalle = New System.Windows.Forms.Button()
        Me.btnEliminarDetalle = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.cbMoneda = New System.Windows.Forms.ComboBox()
        Me.cbCliente = New System.Windows.Forms.ComboBox()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblFiltro = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.btnDeshacer = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgvOrdenServicio = New System.Windows.Forms.DataGridView()
        Me.cmsDetalle = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvDetalleOrdenServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvOrdenServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(56, 19)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigo.TabIndex = 1000
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtTotal)
        Me.GroupBox1.Controls.Add(Me.txtIgv)
        Me.GroupBox1.Controls.Add(Me.chbxIgv)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnGrabar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.cbMoneda)
        Me.GroupBox1.Controls.Add(Me.cbCliente)
        Me.GroupBox1.Controls.Add(Me.txtDestino)
        Me.GroupBox1.Controls.Add(Me.txtOrigen)
        Me.GroupBox1.Controls.Add(Me.txtPrecio)
        Me.GroupBox1.Controls.Add(Me.txtNumero)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(882, 255)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Generales"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(370, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 1005
        Me.Label10.Text = "Total"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(198, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 13)
        Me.Label9.TabIndex = 1004
        Me.Label9.Text = "Igv"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(412, 72)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 1003
        '
        'txtIgv
        '
        Me.txtIgv.Location = New System.Drawing.Point(239, 72)
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.ReadOnly = True
        Me.txtIgv.Size = New System.Drawing.Size(100, 20)
        Me.txtIgv.TabIndex = 1002
        '
        'chbxIgv
        '
        Me.chbxIgv.AutoSize = True
        Me.chbxIgv.Checked = True
        Me.chbxIgv.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbxIgv.Location = New System.Drawing.Point(381, 45)
        Me.chbxIgv.Name = "chbxIgv"
        Me.chbxIgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbxIgv.Size = New System.Drawing.Size(113, 17)
        Me.chbxIgv.TabIndex = 6
        Me.chbxIgv.Text = "Precio incluye IGV"
        Me.chbxIgv.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAbajo)
        Me.GroupBox2.Controls.Add(Me.dgvDetalleOrdenServicio)
        Me.GroupBox2.Controls.Add(Me.btnArriba)
        Me.GroupBox2.Controls.Add(Me.btnAgregarDetalle)
        Me.GroupBox2.Controls.Add(Me.btnEliminarDetalle)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(864, 148)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle de la Carga"
        '
        'btnAbajo
        '
        Me.btnAbajo.Location = New System.Drawing.Point(834, 110)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(24, 23)
        Me.btnAbajo.TabIndex = 22
        Me.btnAbajo.Text = "b"
        Me.btnAbajo.UseVisualStyleBackColor = True
        Me.btnAbajo.Visible = False
        '
        'dgvDetalleOrdenServicio
        '
        Me.dgvDetalleOrdenServicio.AllowUserToResizeRows = False
        Me.dgvDetalleOrdenServicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleOrdenServicio.Location = New System.Drawing.Point(6, 19)
        Me.dgvDetalleOrdenServicio.Name = "dgvDetalleOrdenServicio"
        Me.dgvDetalleOrdenServicio.Size = New System.Drawing.Size(821, 123)
        Me.dgvDetalleOrdenServicio.TabIndex = 0
        '
        'btnArriba
        '
        Me.btnArriba.Location = New System.Drawing.Point(834, 19)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(24, 23)
        Me.btnArriba.TabIndex = 21
        Me.btnArriba.Text = "a"
        Me.btnArriba.UseVisualStyleBackColor = True
        Me.btnArriba.Visible = False
        '
        'btnAgregarDetalle
        '
        Me.btnAgregarDetalle.Location = New System.Drawing.Point(833, 50)
        Me.btnAgregarDetalle.Name = "btnAgregarDetalle"
        Me.btnAgregarDetalle.Size = New System.Drawing.Size(25, 23)
        Me.btnAgregarDetalle.TabIndex = 19
        Me.btnAgregarDetalle.Text = "+"
        Me.btnAgregarDetalle.UseVisualStyleBackColor = True
        Me.btnAgregarDetalle.Visible = False
        '
        'btnEliminarDetalle
        '
        Me.btnEliminarDetalle.Location = New System.Drawing.Point(834, 80)
        Me.btnEliminarDetalle.Name = "btnEliminarDetalle"
        Me.btnEliminarDetalle.Size = New System.Drawing.Size(24, 23)
        Me.btnEliminarDetalle.TabIndex = 20
        Me.btnEliminarDetalle.Text = "-"
        Me.btnEliminarDetalle.UseVisualStyleBackColor = True
        Me.btnEliminarDetalle.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(798, 45)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 17
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(525, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Moneda"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Precio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(177, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Destino"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Origen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(522, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Cliente"
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(717, 45)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 9
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(370, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(174, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Nro. Orden"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Código"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(412, 18)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(97, 20)
        Me.dtpFecha.TabIndex = 2
        '
        'cbMoneda
        '
        Me.cbMoneda.FormattingEnabled = True
        Me.cbMoneda.Location = New System.Drawing.Point(575, 45)
        Me.cbMoneda.Name = "cbMoneda"
        Me.cbMoneda.Size = New System.Drawing.Size(108, 21)
        Me.cbMoneda.TabIndex = 7
        '
        'cbCliente
        '
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(575, 18)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(298, 21)
        Me.cbCliente.TabIndex = 3
        '
        'txtDestino
        '
        Me.txtDestino.Location = New System.Drawing.Point(239, 45)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(100, 20)
        Me.txtDestino.TabIndex = 5
        '
        'txtOrigen
        '
        Me.txtOrigen.Location = New System.Drawing.Point(56, 45)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(100, 20)
        Me.txtOrigen.TabIndex = 4
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(55, 72)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecio.TabIndex = 8
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(239, 19)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(100, 20)
        Me.txtNumero.TabIndex = 10000
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblFiltro)
        Me.GroupBox3.Controls.Add(Me.txtFiltro)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.btnFiltrar)
        Me.GroupBox3.Controls.Add(Me.btnDeshacer)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 272)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(789, 59)
        Me.GroupBox3.TabIndex = 103
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filtros"
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
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(250, 26)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(365, 20)
        Me.txtFiltro.TabIndex = 95
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvOrdenServicio)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 337)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(949, 253)
        Me.GroupBox4.TabIndex = 104
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Lista de Servicios"
        '
        'dgvOrdenServicio
        '
        Me.dgvOrdenServicio.AllowUserToAddRows = False
        Me.dgvOrdenServicio.AllowUserToDeleteRows = False
        Me.dgvOrdenServicio.AllowUserToResizeColumns = False
        Me.dgvOrdenServicio.AllowUserToResizeRows = False
        Me.dgvOrdenServicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrdenServicio.Location = New System.Drawing.Point(9, 20)
        Me.dgvOrdenServicio.MultiSelect = False
        Me.dgvOrdenServicio.Name = "dgvOrdenServicio"
        Me.dgvOrdenServicio.ReadOnly = True
        Me.dgvOrdenServicio.RowHeadersVisible = False
        Me.dgvOrdenServicio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOrdenServicio.ShowEditingIcon = False
        Me.dgvOrdenServicio.Size = New System.Drawing.Size(934, 219)
        Me.dgvOrdenServicio.TabIndex = 0
        '
        'cmsDetalle
        '
        Me.cmsDetalle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.cmsDetalle.Name = "cmsDetalle"
        Me.cmsDetalle.Size = New System.Drawing.Size(149, 70)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(148, 22)
        Me.ToolStripMenuItem1.Text = "Insertar Arriba"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(148, 22)
        Me.ToolStripMenuItem2.Text = "Insertar Abajo"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(148, 22)
        Me.ToolStripMenuItem3.Text = "Eliminar"
        '
        'ChildOrdenServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 617)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ChildOrdenServicio"
        Me.Text = "Orden de Servicio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvDetalleOrdenServicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvOrdenServicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents btnEliminarDetalle As Button
    Friend WithEvents btnAgregarDetalle As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvDetalleOrdenServicio As DataGridView
    Friend WithEvents btnNuevo As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnGrabar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents cbMoneda As ComboBox
    Friend WithEvents cbCliente As ComboBox
    Friend WithEvents txtDestino As TextBox
    Friend WithEvents txtOrigen As TextBox
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents txtNumero As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblFiltro As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents btnDeshacer As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dgvOrdenServicio As DataGridView
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents txtIgv As TextBox
    Friend WithEvents chbxIgv As CheckBox
    Friend WithEvents cmsDetalle As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
End Class
