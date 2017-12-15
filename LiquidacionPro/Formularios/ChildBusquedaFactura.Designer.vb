<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChildBusquedaFactura
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
        Me.dgvFacturas = New System.Windows.Forms.DataGridView()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFacturas
        '
        Me.dgvFacturas.AllowUserToAddRows = False
        Me.dgvFacturas.AllowUserToDeleteRows = False
        Me.dgvFacturas.AllowUserToResizeColumns = False
        Me.dgvFacturas.AllowUserToResizeRows = False
        Me.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFacturas.Location = New System.Drawing.Point(12, 135)
        Me.dgvFacturas.MultiSelect = False
        Me.dgvFacturas.Name = "dgvFacturas"
        Me.dgvFacturas.ReadOnly = True
        Me.dgvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFacturas.Size = New System.Drawing.Size(1282, 304)
        Me.dgvFacturas.TabIndex = 0
        '
        'btnVer
        '
        Me.btnVer.Location = New System.Drawing.Point(520, 455)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(163, 45)
        Me.btnVer.TabIndex = 1
        Me.btnVer.Text = "Ver"
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(378, 455)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 45)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Nuevo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(128, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Razon Social"
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.Location = New System.Drawing.Point(204, 86)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(527, 20)
        Me.txtRazonSocial.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(751, 83)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(178, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "FIltrar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ChildBusquedaFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1321, 524)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtRazonSocial)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnVer)
        Me.Controls.Add(Me.dgvFacturas)
        Me.Name = "ChildBusquedaFactura"
        Me.Text = "Busqueda de Factura"
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvFacturas As DataGridView
    Friend WithEvents btnVer As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtRazonSocial As TextBox
    Friend WithEvents Button2 As Button
End Class
