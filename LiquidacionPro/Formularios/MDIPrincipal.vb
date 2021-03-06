﻿Imports System.Deployment.Application
Imports System.Windows.Forms
Imports System.Xml

Public Class MDIPrincipal
    Private Sub LiquidacionesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        cerrarVentanas()
        Dim liquidacionChild As New ChildLiquidacion()
        liquidacionChild.MdiParent = Me
        liquidacionChild.Show()

    End Sub

    Private Sub FacturaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturaciónToolStripMenuItem.Click
        cerrarVentanas()
        Dim busquedaFacturaChild As New ChildBusquedaFactura()
        busquedaFacturaChild.MdiParent = Me
        busquedaFacturaChild.Show()
    End Sub

    Private Sub LiquidacionesPorEstadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiquidacionesPorEstadoToolStripMenuItem.Click
        cerrarVentanas()
        Dim rptFormLiquidacionByTrabajador As New RptFormLiquidacionByTrabajador()
        rptFormLiquidacionByTrabajador.Show()

    End Sub

    Private Sub GuíasDeTransportistaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuíasDeTransportistaToolStripMenuItem.Click
        cerrarVentanas()
        Dim guiaChild As New ChildGuia()
        guiaChild.MdiParent = Me
        guiaChild.Show()

    End Sub

    Private Sub CorrelativosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorrelativosToolStripMenuItem.Click
        cerrarVentanas()
        Dim correlativoChild As New ChildCorrelativo()
        correlativoChild.MdiParent = Me
        correlativoChild.Show()

    End Sub

    'se cierra ventanas
    Sub cerrarVentanas()
        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        cerrarVentanas()
        Dim childClientes As New ChildClientes()
        childClientes.MdiParent = Me
        childClientes.Show()
    End Sub

    Private Sub TrabajadorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrabajadorToolStripMenuItem.Click
        cerrarVentanas()
        Dim childTrabajador As New ChildTrabajador()
        childTrabajador.MdiParent = Me
        childTrabajador.Show()
    End Sub

    Private Sub LiquidaciónControlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiquidaciónControlToolStripMenuItem.Click
        cerrarVentanas()
        Dim childLiquidacionControl As New ChildLiquidacionControl()
        childLiquidacionControl.MdiParent = Me
        childLiquidacionControl.Show()
    End Sub

    Private Sub LiquidaciónDeCombustibleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiquidaciónDeCombustibleToolStripMenuItem.Click
        cerrarVentanas()
        Dim childLiquidacionCombustible As New ChildLiquidacionCombustible()
        childLiquidacionCombustible.MdiParent = Me
        childLiquidacionCombustible.Show()
    End Sub

    Private Sub FacturaciónVsLiquidaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturaciónVsLiquidaciónToolStripMenuItem.Click
        cerrarVentanas()
        Dim rptFormLiquidacionFacturacion As New RptFormLiquidacionFacturacionSoles()
        rptFormLiquidacionFacturacion.Show()
    End Sub

    Private Sub FacturaciónVsLiquidaciónDólaresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturaciónVsLiquidaciónDólaresToolStripMenuItem.Click
        cerrarVentanas()
        Dim rptFormLiquidacionFacturacion As New RptFormLiquidacionFacturacionDolares()
        rptFormLiquidacionFacturacion.Show()
    End Sub

    Private Sub GuíasVsLiquidaciónYFacturaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuíasVsLiquidaciónYFacturaciónToolStripMenuItem.Click
        cerrarVentanas()
        Dim rptLiquidacionChild As New RptGuiasVsLiquidacionFacturacion()
        rptLiquidacionChild.Show()
    End Sub

    Private Sub FacturacionTestToolStripMenuItem_Click(sender As Object, e As EventArgs)
        cerrarVentanas()
        Dim rptFormFacturaDetalleByMoneda As New RptFormFacturaDetalleByMoneda()
        rptFormFacturaDetalleByMoneda.Show()
    End Sub

    Private Sub FacturasPorClienteFechaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturasPorClienteFechaToolStripMenuItem.Click
        cerrarVentanas()
        Dim rptFormFacturaDetalleByClienteFecha As New RptFormFacturaDetalleByClienteFecha()
        rptFormFacturaDetalleByClienteFecha.Show()
    End Sub

    Private Sub CuentasPorCobrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuentasPorCobrarToolStripMenuItem.Click
        cerrarVentanas()
        Dim rptFormFacturaCuentasPorCobrar As New RptFormFacturaCuentasPorCobrar()
        rptFormFacturaCuentasPorCobrar.Show()
    End Sub

    Private Sub TEstToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComunicaciónBDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComunicaciónBDToolStripMenuItem.Click
        Dim configuracionForm As New ConfiguracionForm
        configuracionForm.ShowDialog()

        Dim cadena As String = configuracionForm.getValor

        If cadena = "sistemas123" Then
            Dim moduloComunicacionBD As New ModuloComunicacionBD()
            moduloComunicacionBD.MdiParent = Me
            moduloComunicacionBD.Show()
        Else
            MessageBox.Show("No tiene acceso.", "Validación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub GuíasControlDeViajesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuíasControlDeViajesToolStripMenuItem.Click
        cerrarVentanas()
        Dim rptFormGuiaControlViaje As New RptFormGuiaControlViaje()
        rptFormGuiaControlViaje.Show()
    End Sub

    Private Sub OrdenDeServicioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenDeServicioToolStripMenuItem.Click
        cerrarVentanas()
        Dim childOrdenServicio As New ChildOrdenServicio()
        childOrdenServicio.MdiParent = Me
        childOrdenServicio.Show()
    End Sub

    Private Sub AsignacionDeServicioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignacionDeServicioToolStripMenuItem.Click
        cerrarVentanas()
        Dim childBusquedaAsignaciones As New ChildBusquedaAsignaciones()
        childBusquedaAsignaciones.MdiParent = Me
        childBusquedaAsignaciones.Show()
    End Sub

    Private Sub FacturaVsPagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturaVsPagoToolStripMenuItem.Click
        cerrarVentanas()
        Dim rptFormFacturaPago As New RptFormFacturaPago()
        rptFormFacturaPago.MdiParent = Me
        rptFormFacturaPago.Show()
    End Sub

    Private Sub MDIPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim m_xmld = New XmlDocument()
            m_xmld.Load(Application.ExecutablePath & ".manifest")
            Me.Text = "Principal v" & m_xmld.ChildNodes.Item(1).ChildNodes.Item(0).Attributes.GetNamedItem("version").Value
        Catch ex As Exception
            Me.Text = "Principal"
        Finally
        End Try

    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem.Click
        cerrarVentanas()
        Dim childUsuario As New ChildUsuario()
        childUsuario.MdiParent = Me
        childUsuario.Show()
    End Sub

    Private Sub UnidadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnidadesToolStripMenuItem.Click
        cerrarVentanas()
        Dim child As New ChildUnidad()
        child.MdiParent = Me
        child.Show()
    End Sub

    'Private Sub AsignacionDeServicioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignacionDeServicioToolStripMenuItem.Click
    '    

    'End Sub


    'Private Sub FacturasVsPagosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturasVsPagosToolStripMenuItem.Click

    'End Sub
End Class
