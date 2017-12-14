Public Class ChildBusquedaFactura
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacturas.CellContentClick

    End Sub

    Private Sub ChildBusquedaFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cargarDatosFactura()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            facturacionDao.setDBcmd()

            Dim dtFactura As DataTable

            dtFactura = facturacionDao.getAllFacturas()

            dgvFacturas.DataSource = dtFactura

            sqlControl.commitTransaction()

            dgvFacturas.MultiSelect = False
            dgvFacturas.RowHeadersVisible = False

        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception

            End Try
        End Try

    End Sub

End Class