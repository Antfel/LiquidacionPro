<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RptGuiasVsLiquidacionFacturacion
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
        Me.btnVer = New System.Windows.Forms.Button()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.clbEstadoGuia = New System.Windows.Forms.CheckedListBox()
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
        'btnVer
        '
        Me.btnVer.Location = New System.Drawing.Point(762, 12)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(75, 23)
        Me.btnVer.TabIndex = 47
        Me.btnVer.Text = "Ver"
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 41)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1114, 394)
        Me.ReportViewer1.TabIndex = 50
        '
        'clbEstadoGuia
        '
        Me.clbEstadoGuia.FormattingEnabled = True
        Me.clbEstadoGuia.Location = New System.Drawing.Point(55, 12)
        Me.clbEstadoGuia.MultiColumn = True
        Me.clbEstadoGuia.Name = "clbEstadoGuia"
        Me.clbEstadoGuia.Size = New System.Drawing.Size(692, 19)
        Me.clbEstadoGuia.TabIndex = 51
        '
        'ChildRptLiquidacionVsLiquidacionFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1114, 355)
        Me.Controls.Add(Me.clbEstadoGuia)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.btnVer)
        Me.Name = "ChildRptLiquidacionVsLiquidacionFacturacion"
        Me.Text = "Reporte de Guía por Estado"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label21 As Label
    Friend WithEvents btnVer As Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents clbEstadoGuia As CheckedListBox
End Class
