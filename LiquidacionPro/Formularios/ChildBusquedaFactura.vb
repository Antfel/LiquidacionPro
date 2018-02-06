Imports System.Data.SqlClient

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
            sqlControl.commitTransaction()

            dgvFacturas.DataSource = dtFactura

            dgvFacturas.Columns(9).Visible = False
            dgvFacturas.Columns(14).Visible = False

            dgvFacturas.MultiSelect = False
            dgvFacturas.RowHeadersVisible = False

        Catch ex As SqlException
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar lista de facturas. ", "Cargar lista de facturas",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar lista de facturas. ", "Cargar lista de facturas",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. ", "Cargar lista de facturas",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
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
            Me.Dispose()
        Else
            Dim facturacionChild As New ChildFacturacion
            facturacionChild.MdiParent = Me.MdiParent
            facturacionChild.setCodifoFactura(CType(dgvFacturas.SelectedRows.Item(0).Cells(0).Value.ToString, Integer))
            facturacionChild.Show()
            Me.Dispose()
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

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        Dim seleccion As DataGridViewRow = dgvFacturas.SelectedRows(0)
        Dim codigo As Integer = seleccion.Cells(0).Value

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim facturacionDAO As New FacturacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            facturacionDAO.setDBcmd()

            facturacionDAO.UpdateFacturaEstado(codigo, 15)

            sqlControl.commitTransaction()

        Catch ex As SqlException
            sqlControl.rollbackTransaccion()
        Catch ex As Exception

        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception

            End Try
        End Try
        cargarDatosFactura()
    End Sub

    Private Sub btnCopiar_Click(sender As Object, e As EventArgs) Handles btnCopiar.Click
        Dim seleccion As DataGridViewRow = dgvFacturas.SelectedRows(0)
        Dim codigo As Integer = seleccion.Cells(0).Value
        Dim serie As String = seleccion.Cells(1).Value
        Dim estado As Int16 = seleccion.Cells(14).Value


        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim facturacionDAO As New FacturacionDAO(sqlControl)
        Dim correlativoDao As New Correlativo_NumeroDAO(sqlControl)


        If estado = 15 Then
            Dim confirm As Integer = MessageBox.Show("La factura está anulada, se realizará una copia activa de la misma. ¿Desea proceder?", "Copiar Factura",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Information)
            If confirm = 6 Then
            Else
                Return
            End If
        End If


        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            facturacionDAO.setDBcmd()

            Dim correlativo As String = correlativoDao.GetSiguienteCorrelativo(1, serie)

            If correlativoDao.GetValidaSerieNroFactura(correlativo, serie) Then
                MessageBox.Show("Existe una factura con el nro: " + serie + "-" + correlativo + ". Verifique el siguiente correlativo a usar en la vista de correlativos.", "Copiar Factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
                Return
            End If

            Dim resp As Integer = MessageBox.Show("Se realizará una copia con el siguiente nro. de Factura: " + serie + "-" + correlativo + ". ¿Desea proceder?", "Copiar Factura",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Information)

            If resp = 6 Then
                correlativoDao.updateCorrelativoNumero(1, serie, correlativo)
                facturacionDAO.CopiarFactura(codigo, serie, correlativo)
            Else

            End If

            sqlControl.commitTransaction()

        Catch ex As SqlException
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al copiar factura. " + ex.Message, "Copiar Factura",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al copiar factura. " + ex.Message, "Copiar Factura",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
        Finally
            Try
                If sqlControl.getDBcon.State = ConnectionState.Open Then
                    sqlControl.closeConexion()
                End If

            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión", "Copiar Factura",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
            cargarDatosFactura()
        End Try
    End Sub
End Class