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
        Me.FacturaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuíasDeTransportistaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CorrelativosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrabajadorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiquidaciónControlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiquidaciónDeCombustibleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdenDeServicioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignacionDeServicioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiquidacionesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiquidacionesPorEstadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturaciónToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturaciónVsLiquidaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturaciónVsLiquidaciónDólaresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturasPorClienteFechaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuentasPorCobrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturaVsPagoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuíasDeTransportistaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuíasVsLiquidaciónYFacturaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuíasControlDeViajesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComunicaciónBDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 535)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1012, 22)
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ReportesToolStripMenuItem, Me.AdministraciónToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1012, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacturaciónToolStripMenuItem, Me.GuíasDeTransportistaToolStripMenuItem, Me.CorrelativosToolStripMenuItem, Me.ClientesToolStripMenuItem, Me.TrabajadorToolStripMenuItem, Me.LiquidaciónControlToolStripMenuItem, Me.LiquidaciónDeCombustibleToolStripMenuItem, Me.OrdenDeServicioToolStripMenuItem, Me.AsignacionDeServicioToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(66, 20)
        Me.ToolStripMenuItem1.Text = "Procesos"
        '
        'FacturaciónToolStripMenuItem
        '
        Me.FacturaciónToolStripMenuItem.Name = "FacturaciónToolStripMenuItem"
        Me.FacturaciónToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.FacturaciónToolStripMenuItem.Text = "Facturación"
        '
        'GuíasDeTransportistaToolStripMenuItem
        '
        Me.GuíasDeTransportistaToolStripMenuItem.Name = "GuíasDeTransportistaToolStripMenuItem"
        Me.GuíasDeTransportistaToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.GuíasDeTransportistaToolStripMenuItem.Text = "Guías de Transportista"
        '
        'CorrelativosToolStripMenuItem
        '
        Me.CorrelativosToolStripMenuItem.Name = "CorrelativosToolStripMenuItem"
        Me.CorrelativosToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.CorrelativosToolStripMenuItem.Text = "Correlativos"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'TrabajadorToolStripMenuItem
        '
        Me.TrabajadorToolStripMenuItem.Name = "TrabajadorToolStripMenuItem"
        Me.TrabajadorToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.TrabajadorToolStripMenuItem.Text = "Trabajador"
        '
        'LiquidaciónControlToolStripMenuItem
        '
        Me.LiquidaciónControlToolStripMenuItem.Name = "LiquidaciónControlToolStripMenuItem"
        Me.LiquidaciónControlToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.LiquidaciónControlToolStripMenuItem.Text = "Liquidación de Viaje"
        '
        'LiquidaciónDeCombustibleToolStripMenuItem
        '
        Me.LiquidaciónDeCombustibleToolStripMenuItem.Name = "LiquidaciónDeCombustibleToolStripMenuItem"
        Me.LiquidaciónDeCombustibleToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.LiquidaciónDeCombustibleToolStripMenuItem.Text = "Liquidación de Combustible"
        '
        'OrdenDeServicioToolStripMenuItem
        '
        Me.OrdenDeServicioToolStripMenuItem.Name = "OrdenDeServicioToolStripMenuItem"
        Me.OrdenDeServicioToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.OrdenDeServicioToolStripMenuItem.Text = "Orden de Servicio"
        '
        'AsignacionDeServicioToolStripMenuItem
        '
        Me.AsignacionDeServicioToolStripMenuItem.Name = "AsignacionDeServicioToolStripMenuItem"
        Me.AsignacionDeServicioToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.AsignacionDeServicioToolStripMenuItem.Text = "Asignacion de Servicio"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LiquidacionesToolStripMenuItem1, Me.FacturaciónToolStripMenuItem1, Me.GuíasDeTransportistaToolStripMenuItem1})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'LiquidacionesToolStripMenuItem1
        '
        Me.LiquidacionesToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LiquidacionesPorEstadoToolStripMenuItem})
        Me.LiquidacionesToolStripMenuItem1.Name = "LiquidacionesToolStripMenuItem1"
        Me.LiquidacionesToolStripMenuItem1.Size = New System.Drawing.Size(191, 22)
        Me.LiquidacionesToolStripMenuItem1.Text = "Liquidaciones"
        '
        'LiquidacionesPorEstadoToolStripMenuItem
        '
        Me.LiquidacionesPorEstadoToolStripMenuItem.Name = "LiquidacionesPorEstadoToolStripMenuItem"
        Me.LiquidacionesPorEstadoToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.LiquidacionesPorEstadoToolStripMenuItem.Text = "Liquidaciones por Trabajador"
        '
        'FacturaciónToolStripMenuItem1
        '
        Me.FacturaciónToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacturaciónVsLiquidaciónToolStripMenuItem, Me.FacturaciónVsLiquidaciónDólaresToolStripMenuItem, Me.FacturasPorClienteFechaToolStripMenuItem, Me.CuentasPorCobrarToolStripMenuItem, Me.FacturaVsPagoToolStripMenuItem})
        Me.FacturaciónToolStripMenuItem1.Name = "FacturaciónToolStripMenuItem1"
        Me.FacturaciónToolStripMenuItem1.Size = New System.Drawing.Size(191, 22)
        Me.FacturaciónToolStripMenuItem1.Text = "Facturación"
        '
        'FacturaciónVsLiquidaciónToolStripMenuItem
        '
        Me.FacturaciónVsLiquidaciónToolStripMenuItem.Name = "FacturaciónVsLiquidaciónToolStripMenuItem"
        Me.FacturaciónVsLiquidaciónToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.FacturaciónVsLiquidaciónToolStripMenuItem.Text = "Facturación vs Liquidación - Soles"
        Me.FacturaciónVsLiquidaciónToolStripMenuItem.Visible = False
        '
        'FacturaciónVsLiquidaciónDólaresToolStripMenuItem
        '
        Me.FacturaciónVsLiquidaciónDólaresToolStripMenuItem.Name = "FacturaciónVsLiquidaciónDólaresToolStripMenuItem"
        Me.FacturaciónVsLiquidaciónDólaresToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.FacturaciónVsLiquidaciónDólaresToolStripMenuItem.Text = "Facturación vs Liquidación - Dólares"
        Me.FacturaciónVsLiquidaciónDólaresToolStripMenuItem.Visible = False
        '
        'FacturasPorClienteFechaToolStripMenuItem
        '
        Me.FacturasPorClienteFechaToolStripMenuItem.Name = "FacturasPorClienteFechaToolStripMenuItem"
        Me.FacturasPorClienteFechaToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.FacturasPorClienteFechaToolStripMenuItem.Text = "Facturas por Cliente Fecha"
        Me.FacturasPorClienteFechaToolStripMenuItem.Visible = False
        '
        'CuentasPorCobrarToolStripMenuItem
        '
        Me.CuentasPorCobrarToolStripMenuItem.Name = "CuentasPorCobrarToolStripMenuItem"
        Me.CuentasPorCobrarToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.CuentasPorCobrarToolStripMenuItem.Text = "Cuentas por Cobrar"
        Me.CuentasPorCobrarToolStripMenuItem.Visible = False
        '
        'FacturaVsPagoToolStripMenuItem
        '
        Me.FacturaVsPagoToolStripMenuItem.Name = "FacturaVsPagoToolStripMenuItem"
        Me.FacturaVsPagoToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.FacturaVsPagoToolStripMenuItem.Text = "Factura vs Pago"
        '
        'GuíasDeTransportistaToolStripMenuItem1
        '
        Me.GuíasDeTransportistaToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuíasVsLiquidaciónYFacturaciónToolStripMenuItem, Me.GuíasControlDeViajesToolStripMenuItem})
        Me.GuíasDeTransportistaToolStripMenuItem1.Name = "GuíasDeTransportistaToolStripMenuItem1"
        Me.GuíasDeTransportistaToolStripMenuItem1.Size = New System.Drawing.Size(191, 22)
        Me.GuíasDeTransportistaToolStripMenuItem1.Text = "Guías de Transportista"
        '
        'GuíasVsLiquidaciónYFacturaciónToolStripMenuItem
        '
        Me.GuíasVsLiquidaciónYFacturaciónToolStripMenuItem.Name = "GuíasVsLiquidaciónYFacturaciónToolStripMenuItem"
        Me.GuíasVsLiquidaciónYFacturaciónToolStripMenuItem.Size = New System.Drawing.Size(257, 22)
        Me.GuíasVsLiquidaciónYFacturaciónToolStripMenuItem.Text = "Guías Vs Liquidación y Facturación"
        '
        'GuíasControlDeViajesToolStripMenuItem
        '
        Me.GuíasControlDeViajesToolStripMenuItem.Name = "GuíasControlDeViajesToolStripMenuItem"
        Me.GuíasControlDeViajesToolStripMenuItem.Size = New System.Drawing.Size(257, 22)
        Me.GuíasControlDeViajesToolStripMenuItem.Text = "Guías - Control de Viajes"
        '
        'AdministraciónToolStripMenuItem
        '
        Me.AdministraciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ComunicaciónBDToolStripMenuItem, Me.UsuariosToolStripMenuItem})
        Me.AdministraciónToolStripMenuItem.Name = "AdministraciónToolStripMenuItem"
        Me.AdministraciónToolStripMenuItem.Size = New System.Drawing.Size(100, 20)
        Me.AdministraciónToolStripMenuItem.Text = "Administración"
        '
        'ComunicaciónBDToolStripMenuItem
        '
        Me.ComunicaciónBDToolStripMenuItem.Name = "ComunicaciónBDToolStripMenuItem"
        Me.ComunicaciónBDToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.ComunicaciónBDToolStripMenuItem.Text = "Comunicación BD"
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.UsuariosToolStripMenuItem.Text = "Usuarios"
        '
        'MDIPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 557)
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
    Friend WithEvents FacturaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LiquidacionesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents LiquidacionesPorEstadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuíasDeTransportistaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CorrelativosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TrabajadorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LiquidaciónControlToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LiquidaciónDeCombustibleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacturaciónToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents FacturaciónVsLiquidaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacturaciónVsLiquidaciónDólaresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuíasDeTransportistaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GuíasVsLiquidaciónYFacturaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacturasPorClienteFechaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CuentasPorCobrarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AdministraciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComunicaciónBDToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuíasControlDeViajesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OrdenDeServicioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AsignacionDeServicioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacturaVsPagoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As ToolStripMenuItem
End Class
