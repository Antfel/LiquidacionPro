Public Class ChildRptLiquidacionEstado
    Private Sub ChildRptLiquidacionEstado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actualizarEstados()
    End Sub

    Private Sub actualizarEstados()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim estadoDao As New EstadoDAO(sqlControl)
        sqlControl.openConexion()

        Dim dtEstado As DataTable

        dtEstado = estadoDao.getEstados

        With cbEstadoRpt
            .DataSource = dtEstado
            .DisplayMember = "DETALLE_DESTADO"
            .ValueMember = "CODIGO_ESTADO"
        End With
        sqlControl.closeConexion()

    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        Dim estado As Integer
        estado = cbEstadoRpt.SelectedValue
        dtLiquidacionEstadoTableAdapter.Fill(rptLiquidaciones.dtLiquidacionEstado, estado)
        ReportViewer1.RefreshReport()
    End Sub
End Class