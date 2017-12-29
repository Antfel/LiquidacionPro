<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChildRptLiquidacionEstado
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
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbEstadoRpt = New System.Windows.Forms.ComboBox()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 12)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 13)
        Me.Label21.TabIndex = 49
        Me.Label21.Text = "Estado"
        '
        'cbEstadoRpt
        '
        Me.cbEstadoRpt.FormattingEnabled = True
        Me.cbEstadoRpt.ItemHeight = 13
        Me.cbEstadoRpt.Location = New System.Drawing.Point(90, 12)
        Me.cbEstadoRpt.Name = "cbEstadoRpt"
        Me.cbEstadoRpt.Size = New System.Drawing.Size(107, 21)
        Me.cbEstadoRpt.TabIndex = 48
        '
        'btnVer
        '
        Me.btnVer.Location = New System.Drawing.Point(293, 12)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(75, 23)
        Me.btnVer.TabIndex = 47
        Me.btnVer.Text = "Ver"
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'ChildRptLiquidacionEstado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1114, 355)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cbEstadoRpt)
        Me.Controls.Add(Me.btnVer)
        Me.Name = "ChildRptLiquidacionEstado"
        Me.Text = "Reporte de Liquidación por Estado"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label21 As Label
    Friend WithEvents cbEstadoRpt As ComboBox
    Friend WithEvents btnVer As Button
End Class
