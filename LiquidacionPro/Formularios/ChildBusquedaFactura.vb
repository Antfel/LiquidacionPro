Imports System.Data.SqlClient

Public Class ChildBusquedaFactura
    Dim columnaFiltro As Integer = -1
    Dim source1 As New BindingSource()
    Dim nombreColumnaFiltro As String
    Dim facturaSeleccion As Integer

    Private Sub ChildBusquedaFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatosFactura()
        'CargarFacturas()
    End Sub

    Public Sub CargarFacturas()
        Dim dao As New FacturaDao()
        Dim lista As New List(Of FacturaClass)

        Dim t As Task = New Task(Sub()
                                     lista = dao.GetFacturas().Result
                                 End Sub)
        t.Start()

        t.Wait()

        Me.LlenarTabla(lista)

    End Sub

    Delegate Sub llenarTablaCallBack(lista As List(Of FacturaClass))

    Public Sub LlenarTabla(lista As List(Of FacturaClass))
        If Me.dgvFacturas.InvokeRequired Then
            Dim d As New llenarTablaCallBack(AddressOf LlenarTabla)
            Me.Invoke(d, New Object() {lista})
        Else
            dgvFacturas.DataSource = lista
        End If

    End Sub

    Public Sub cargarDatosFactura()


        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDao.SetDBcmd()

            Dim dtFactura As DataTable

            dtFactura = facturacionDao.GetAllFacturas()
            sqlControl.CommitTransaction()

            Dim filtro As String = source1.Filter

            dgvFacturas.DataSource = dtFactura

            dgvFacturas.Columns(11).Visible = False
            dgvFacturas.Columns(16).Visible = False

            dgvFacturas.Columns(0).Width = 55
            dgvFacturas.Columns(1).Width = 50
            dgvFacturas.Columns(2).Width = 70
            dgvFacturas.Columns(3).Width = 75
            dgvFacturas.Columns(4).Width = 250
            dgvFacturas.Columns(5).Width = 85
            dgvFacturas.Columns(6).Width = 70
            dgvFacturas.Columns(13).Width = 85
            dgvFacturas.Columns(14).Width = 85
            dgvFacturas.Columns(15).Width = 85
            dgvFacturas.Columns(17).Width = 85

            dgvFacturas.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvFacturas.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvFacturas.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            If filtro <> Nothing Then
                source1.DataSource = dgvFacturas.DataSource
                source1.Filter = filtro
                dgvFacturas.Refresh()
            End If

            If facturaSeleccion > 0 Then
                Dim rowIndex As Integer = -1
                For Each row As DataGridViewRow In dgvFacturas.Rows
                    If row.Cells(0).Value.ToString().Equals(facturaSeleccion.ToString) Then
                        rowIndex = row.Index
                        Exit For
                    End If
                Next

                If rowIndex <> -1 Then
                    dgvFacturas.CurrentCell = dgvFacturas.Item(0, rowIndex)
                Else
                End If
            Else
            End If

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar lista de facturas. ", "Cargar lista de facturas",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar lista de facturas. ", "Cargar lista de facturas",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. ", "Cargar lista de facturas",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try

    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        Dim seleccion As DataGridViewRow = dgvFacturas.SelectedRows(0)
        Dim codigo As Integer = seleccion.Cells(11).Value
        If codigo = 33 Then
            Dim facturacionLibreChild As New ChildFacturaLibre
            facturacionLibreChild.MdiParent = Me.MdiParent
            facturacionLibreChild.setCodifoFactura(CType(dgvFacturas.SelectedRows.Item(0).Cells(0).Value.ToString, Integer))
            facturacionLibreChild.setChildBusquedaFactura(Me)
            facturacionLibreChild.Show()
            'Me.Dispose()
        Else
            Dim facturacionChild As New ChildFacturacion
            facturacionChild.MdiParent = Me.MdiParent
            facturacionChild.setCodifoFactura(CType(dgvFacturas.SelectedRows.Item(0).Cells(0).Value.ToString, Integer))
            facturacionChild.setChildBusquedaFactura(Me)
            facturacionChild.Show()
            'Me.Dispose()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim facturacionChild As New ChildFacturacion
        facturacionChild.MdiParent = Me.MdiParent
        facturacionChild.setChildBusquedaFactura(Me)
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
        facturaLibreChild.setChildBusquedaFactura(Me)
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
        Dim estado As Integer = seleccion.Cells(16).Value

        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim facturacionDAO As New FacturacionDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDAO.SetDBcmd()

            If estado = 16 Then
                facturacionDAO.UpdateFacturaEstado(codigo, 15)
                btnAnular.Text = "Activar"
            ElseIf estado = 15 Then
                facturacionDAO.UpdateFacturaEstado(codigo, 16)
                btnAnular.Text = "Anular"
            End If

            sqlControl.CommitTransaction()
        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
        Catch ex As Exception

        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception

            End Try
        End Try
        cargarDatosFactura()
    End Sub

    Private Sub btnCopiar_Click(sender As Object, e As EventArgs) Handles btnCopiar.Click
        Dim seleccion As DataGridViewRow = dgvFacturas.SelectedRows(0)
        Dim codigo As Integer = seleccion.Cells(0).Value
        Dim serie As String = seleccion.Cells(1).Value
        Dim estado As Int16 = seleccion.Cells(16).Value


        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

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
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDAO.SetDBcmd()

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

            sqlControl.CommitTransaction()

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al copiar factura. " + ex.Message, "Copiar Factura",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al copiar factura. " + ex.Message, "Copiar Factura",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
        Finally
            Try
                If sqlControl.GetDBcon.State = ConnectionState.Open Then
                    sqlControl.CloseConexion()
                End If

            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión", "Copiar Factura",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
            cargarDatosFactura()
        End Try
    End Sub

    Private Sub dgvFacturas_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvFacturas.CellMouseClick
        Dim seleccion As DataGridViewRow = dgvFacturas.SelectedRows(0)

        If seleccion.Index < 0 Then
            Return
        End If

        Dim estado As Int16 = seleccion.Cells(16).Value
        facturaSeleccion = seleccion.Cells(0).Value

        If estado = 15 Then
            'anulado
            btnAnular.Text = "Activar"
        ElseIf estado = 16 Then
            'facturado
            btnAnular.Text = "Anular"
        End If
    End Sub
End Class