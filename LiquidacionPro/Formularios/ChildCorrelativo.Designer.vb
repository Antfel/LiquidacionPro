<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChildCorrelativo
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
        Me.dgvCorrelativoNumero = New System.Windows.Forms.DataGridView()
        Me.txtCorrealtivo = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvCorrelativo = New System.Windows.Forms.DataGridView()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.txtUltimoUsado = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDetalleCorrelativo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        CType(Me.dgvCorrelativoNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCorrelativo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCorrelativoNumero
        '
        Me.dgvCorrelativoNumero.AllowUserToAddRows = False
        Me.dgvCorrelativoNumero.AllowUserToDeleteRows = False
        Me.dgvCorrelativoNumero.AllowUserToResizeRows = False
        Me.dgvCorrelativoNumero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCorrelativoNumero.Location = New System.Drawing.Point(274, 161)
        Me.dgvCorrelativoNumero.MultiSelect = False
        Me.dgvCorrelativoNumero.Name = "dgvCorrelativoNumero"
        Me.dgvCorrelativoNumero.ReadOnly = True
        Me.dgvCorrelativoNumero.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCorrelativoNumero.Size = New System.Drawing.Size(565, 148)
        Me.dgvCorrelativoNumero.TabIndex = 0
        '
        'txtCorrealtivo
        '
        Me.txtCorrealtivo.Location = New System.Drawing.Point(110, 32)
        Me.txtCorrealtivo.Name = "txtCorrealtivo"
        Me.txtCorrealtivo.ReadOnly = True
        Me.txtCorrealtivo.Size = New System.Drawing.Size(100, 20)
        Me.txtCorrealtivo.TabIndex = 1
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(341, 32)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(163, 20)
        Me.txtDescripcion.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(250, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Descripción"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Correlativo"
        '
        'dgvCorrelativo
        '
        Me.dgvCorrelativo.AllowUserToAddRows = False
        Me.dgvCorrelativo.AllowUserToDeleteRows = False
        Me.dgvCorrelativo.AllowUserToResizeRows = False
        Me.dgvCorrelativo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCorrelativo.Location = New System.Drawing.Point(27, 161)
        Me.dgvCorrelativo.MultiSelect = False
        Me.dgvCorrelativo.Name = "dgvCorrelativo"
        Me.dgvCorrelativo.ReadOnly = True
        Me.dgvCorrelativo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCorrelativo.Size = New System.Drawing.Size(241, 148)
        Me.dgvCorrelativo.TabIndex = 5
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(342, 69)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(100, 20)
        Me.txtSerie.TabIndex = 6
        '
        'txtUltimoUsado
        '
        Me.txtUltimoUsado.Location = New System.Drawing.Point(573, 70)
        Me.txtUltimoUsado.Name = "txtUltimoUsado"
        Me.txtUltimoUsado.Size = New System.Drawing.Size(163, 20)
        Me.txtUltimoUsado.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(477, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Último usado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(271, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Serie"
        '
        'txtDetalleCorrelativo
        '
        Me.txtDetalleCorrelativo.Location = New System.Drawing.Point(110, 69)
        Me.txtDetalleCorrelativo.Name = "txtDetalleCorrelativo"
        Me.txtDetalleCorrelativo.ReadOnly = True
        Me.txtDetalleCorrelativo.Size = New System.Drawing.Size(100, 20)
        Me.txtDetalleCorrelativo.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Detalle"
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(764, 69)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 12
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'ChildCorrelativo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 376)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDetalleCorrelativo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtUltimoUsado)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.dgvCorrelativo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtCorrealtivo)
        Me.Controls.Add(Me.dgvCorrelativoNumero)
        Me.Name = "ChildCorrelativo"
        Me.Text = "Correlativos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvCorrelativoNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCorrelativo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvCorrelativoNumero As DataGridView
    Friend WithEvents txtCorrealtivo As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvCorrelativo As DataGridView
    Friend WithEvents txtSerie As TextBox
    Friend WithEvents txtUltimoUsado As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDetalleCorrelativo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnGrabar As Button
End Class
