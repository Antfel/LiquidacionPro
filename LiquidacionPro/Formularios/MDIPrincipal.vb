Imports System.Windows.Forms

Public Class MDIPrincipal
    Private Sub LiquidacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiquidacionesToolStripMenuItem.Click
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
        Dim rptLiquidacionChild As New ChildRptLiquidacionEstado()
        rptLiquidacionChild.MdiParent = Me
        rptLiquidacionChild.Show()

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
End Class
