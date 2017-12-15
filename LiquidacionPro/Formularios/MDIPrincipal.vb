Imports System.Windows.Forms

Public Class MDIPrincipal
    Private Sub LiquidacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiquidacionesToolStripMenuItem.Click
        Dim liquidacionChild As New ChildLiquidacion()
        liquidacionChild.MdiParent = Me
        liquidacionChild.Show()
    End Sub

    Private Sub FacturaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturaciónToolStripMenuItem.Click
        Dim busquedaFacturaChild As New ChildBusquedaFactura()
        busquedaFacturaChild.MdiParent = Me
        busquedaFacturaChild.Show()
    End Sub

    Private Sub LiquidacionesPorEstadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiquidacionesPorEstadoToolStripMenuItem.Click
        Dim rptLiquidacionChild As New ChildRptLiquidacionEstado()
        rptLiquidacionChild.MdiParent = Me
        rptLiquidacionChild.Show()
    End Sub

    Private Sub GuíasDeTransportistaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuíasDeTransportistaToolStripMenuItem.Click
        Dim guiaChild As New ChildGuia()
        guiaChild.MdiParent = Me
        guiaChild.Show()
    End Sub

    Private Sub CorrelativosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorrelativosToolStripMenuItem.Click
        Dim correlativoChild As New ChildCorrelativo()
        correlativoChild.MdiParent = Me
        correlativoChild.Show()
    End Sub
End Class
