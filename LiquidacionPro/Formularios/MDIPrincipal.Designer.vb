<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MDIPrincipal
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
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiquidacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuíasDeTransportistaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CorrelativosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiquidacionesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiquidacionesPorEstadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 535)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1321, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel.Text = "Estado"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ReportesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1321, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LiquidacionesToolStripMenuItem, Me.FacturaciónToolStripMenuItem, Me.GuíasDeTransportistaToolStripMenuItem, Me.CorrelativosToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(66, 20)
        Me.ToolStripMenuItem1.Text = "Procesos"
        '
        'LiquidacionesToolStripMenuItem
        '
        Me.LiquidacionesToolStripMenuItem.Name = "LiquidacionesToolStripMenuItem"
        Me.LiquidacionesToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.LiquidacionesToolStripMenuItem.Text = "Liquidaciones"
        '
        'FacturaciónToolStripMenuItem
        '
        Me.FacturaciónToolStripMenuItem.Name = "FacturaciónToolStripMenuItem"
        Me.FacturaciónToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.FacturaciónToolStripMenuItem.Text = "Facturación"
        '
        'GuíasDeTransportistaToolStripMenuItem
        '
        Me.GuíasDeTransportistaToolStripMenuItem.Name = "GuíasDeTransportistaToolStripMenuItem"
        Me.GuíasDeTransportistaToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.GuíasDeTransportistaToolStripMenuItem.Text = "Guías de Transportista"
        '
        'CorrelativosToolStripMenuItem
        '
        Me.CorrelativosToolStripMenuItem.Name = "CorrelativosToolStripMenuItem"
        Me.CorrelativosToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.CorrelativosToolStripMenuItem.Text = "Correlativos"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LiquidacionesToolStripMenuItem1})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'LiquidacionesToolStripMenuItem1
        '
        Me.LiquidacionesToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LiquidacionesPorEstadoToolStripMenuItem})
        Me.LiquidacionesToolStripMenuItem1.Name = "LiquidacionesToolStripMenuItem1"
        Me.LiquidacionesToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.LiquidacionesToolStripMenuItem1.Text = "Liquidaciones"
        '
        'LiquidacionesPorEstadoToolStripMenuItem
        '
        Me.LiquidacionesPorEstadoToolStripMenuItem.Name = "LiquidacionesPorEstadoToolStripMenuItem"
        Me.LiquidacionesPorEstadoToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.LiquidacionesPorEstadoToolStripMenuItem.Text = "Liquidaciones por Estado"
        '
        'MDIPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1321, 557)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.Name = "MDIPrincipal"
        Me.Text = "Principal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents LiquidacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacturaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LiquidacionesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents LiquidacionesPorEstadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuíasDeTransportistaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CorrelativosToolStripMenuItem As ToolStripMenuItem
End Class
