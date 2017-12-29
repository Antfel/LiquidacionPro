Public Class ChildBusquedaFactura
    Dim columnaFiltro As Integer = -1
    Dim source1 As New BindingSource()
    Dim nombreColumnaFiltro As String

    Private Sub ChildBusquedaFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatosFactura()
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

            dgvFacturas.Columns(9).Visible = False

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

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim facturaLibreChild As New ChildFacturaLibre
        facturaLibreChild.MdiParent = Me.MdiParent
        facturaLibreChild.Show()
        Me.Dispose()
    End Sub

    Private Sub dgvFacturas_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvFacturas.ColumnHeaderMouseClick
        columnaFiltro = e.ColumnIndex
        nombreColumnaFiltro = dgvFacturas.Columns(columnaFiltro).Name
        lblFiltro.Text = nombreColumnaFiltro
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        If columnaFiltro = -1 Then
            MessageBox.Show("Debe seleccionar una columna. ", "Filtrar",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If
        source1.DataSource = dgvFacturas.DataSource

        Dim tipo As Type = dgvFacturas.Columns(columnaFiltro).ValueType

        Select Case tipo.ToString
            Case "System.Decimal", "System.Int32"
                source1.Filter = "[" & nombreColumnaFiltro & "] " & txtFiltro.Text & ""
            Case "System.String"
                source1.Filter = "[" & nombreColumnaFiltro & "] like '%" & txtFiltro.Text & "%'"
        End Select

        dgvFacturas.Refresh()
    End Sub

    Private Sub btnDeshacer_Click(sender As Object, e As EventArgs) Handles btnDeshacer.Click
        source1.DataSource = dgvFacturas.DataSource
        source1.RemoveFilter()
        dgvFacturas.Refresh()
        txtFiltro.Text = ""
    End Sub
End Class