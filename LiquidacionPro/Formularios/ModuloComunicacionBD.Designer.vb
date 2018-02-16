<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModuloComunicacionBD
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
        Me.btnActualizarFacturas = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnActualizarFacturas
        '
        Me.btnActualizarFacturas.Location = New System.Drawing.Point(219, 23)
        Me.btnActualizarFacturas.Name = "btnActualizarFacturas"
        Me.btnActualizarFacturas.Size = New System.Drawing.Size(135, 23)
        Me.btnActualizarFacturas.TabIndex = 0
        Me.btnActualizarFacturas.Text = "Actualizar Facturas"
        Me.btnActualizarFacturas.UseVisualStyleBackColor = True
        '
        'ModuloComunicacionBD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 290)
        Me.Controls.Add(Me.btnActualizarFacturas)
        Me.Name = "ModuloComunicacionBD"
        Me.Text = "ModuloComunicacionBD"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnActualizarFacturas As Button
End Class
