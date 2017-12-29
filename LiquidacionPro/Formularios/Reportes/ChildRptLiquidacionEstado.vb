Public Class ChildRptLiquidacionEstado
    Private Sub ChildRptLiquidacionEstado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'rptLiquidaciones.dtLiquidacionEstado' Puede moverla o quitarla según sea necesario.
        actualizarEstados()
    End Sub

    Private Sub actualizarEstados()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim estadoDao As New EstadoDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            estadoDao.setDBcmd()

            Dim dtEstado As DataTable

            dtEstado = estadoDao.getEstados

            With cbEstadoRpt
                .DataSource = dtEstado
                .DisplayMember = "DETALLE_ESTADO"
                .ValueMember = "CODIGO_ESTADO"
            End With
            sqlControl.commitTransaction()

        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception

            End Try
        End Try



    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        Dim estado As Integer
        estado = cbEstadoRpt.SelectedValue
        Try
            'dtLiquidacionEstadoTableAdapter.Fill(rptLiquidaciones.dtLiquidacionEstado, estado)

            'ReportViewer1.
            ''ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox("" + ex.Message)
        End Try

    End Sub
End Class