Public Class ChildBusquedaFactura
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacturas.CellContentClick

    End Sub

    Private Sub ChildBusquedaFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatosFactura("")
    End Sub

    Private Sub cargarDatosFactura(Filtro As String)
        If Filtro.Trim <> "" Then
            Dim sqlControl As New SQLControl
            sqlControl.setConnection()

            Dim facturacionDao As New FacturacionDAO(sqlControl)
            Try
                sqlControl.openConexion()
                sqlControl.beginTransaction()
                facturacionDao.setDBcmd()

                Dim dtFactura As DataTable

                dtFactura = facturacionDao.getAllFacturasFiltro(Filtro)

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
        Else
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
        End If



    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        Dim seleccion As DataGridViewRow = dgvFacturas.SelectedRows(0)
        Dim codigo As Integer = seleccion.Cells(9).Value
        If codigo = 33 Then
            Dim facturacionLibreChild As New ChildFacturaLibre
            facturacionLibreChild.MdiParent = Me.MdiParent
            facturacionLibreChild.setCodifoFactura(CType(dgvFacturas.SelectedRows.Item(0).Cells(0).Value.ToString, Integer))
            facturacionLibreChild.Show()
        Else
            Dim facturacionChild As New ChildFacturacion
            facturacionChild.MdiParent = Me.MdiParent
            facturacionChild.setCodifoFactura(CType(dgvFacturas.SelectedRows.Item(0).Cells(0).Value.ToString, Integer))
            facturacionChild.Show()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim facturacionChild As New ChildFacturacion
        facturacionChild.MdiParent = Me.MdiParent
        facturacionChild.Show()
        Me.Dispose()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cargarDatosFactura(txtRazonSocial.Text)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtRazonSocial.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim facturaLibreChild As New ChildFacturaLibre
        facturaLibreChild.MdiParent = Me.MdiParent
        facturaLibreChild.Show()
        Me.Dispose()
    End Sub
End Class