Public Class ChildClientes
    Dim columnaFiltro As Integer = -1
    Dim source1 As New BindingSource()
    Dim nombreColumnaFiltro As String

    Private Sub ChildClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarClientes()
    End Sub

    Sub cargarClientes()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim clienteDAO As New ClienteDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            clienteDAO.setDBcmd()

            Dim dt As DataTable

            dt = clienteDAO.GetAllClientes()
            dgvListaClientes.DataSource = dt

            sqlControl.CommitTransaction()

        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("No se pudo cargar la lista de clientes. " + ex.Message, "Cargar Clientes",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("No se pudo cerrar la conexión. " + ex.Message, "Cargar Clientes",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try

    End Sub

    Private Sub dgvListaClientes_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvListaClientes.ColumnHeaderMouseClick
        columnaFiltro = e.ColumnIndex
        nombreColumnaFiltro = dgvListaClientes.Columns(columnaFiltro).Name
        lblFiltro.Text = nombreColumnaFiltro
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click

        If columnaFiltro = -1 Then
            MessageBox.Show("Debe seleccionar una columna. ", "Filtrar",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If
        source1.DataSource = dgvListaClientes.DataSource

        Dim tipo As Type = dgvListaClientes.Columns(columnaFiltro).ValueType

        Select Case tipo.ToString
            Case "System.Decimal", "System.Int32"
                source1.Filter = "[" & nombreColumnaFiltro & "] " & txtFiltro.Text & ""
            Case "System.String"
                source1.Filter = "[" & nombreColumnaFiltro & "] like '%" & txtFiltro.Text & "%'"
        End Select

        dgvListaClientes.Refresh()
    End Sub

    Private Sub btnDeshacer_Click(sender As Object, e As EventArgs) Handles btnDeshacer.Click
        source1.DataSource = dgvListaClientes.DataSource
        source1.RemoveFilter()
        dgvListaClientes.Refresh()
        txtFiltro.Text = ""
    End Sub

    Private Sub dgvListaClientes_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvListaClientes.CellMouseClick
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim clienteDAO As New ClienteDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            clienteDAO.setDBcmd()

            Dim seleccion As DataGridViewRow = dgvListaClientes.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(0).Value

            Dim dt As DataTable
            dt = clienteDAO.GetClienteByCodigo(codigo)


            txtCodigo.Text = dt.Rows(0)(0)
            txtRuc.Text = dt.Rows(0)(1)
            txtRazonSocial.Text = dt.Rows(0)(2)
            txtDireccion.Text = dt.Rows(0)(3)
            txtTelefono.Text = dt.Rows(0)(4)

            sqlControl.CommitTransaction()
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar Cliente. " + ex.Message, "Seleccionar",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cargar cerrar la conexión. " + ex.Message, "Seleccionar",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            End Try
        End Try


    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()
    End Sub
    Sub limpiar()
        txtCodigo.Text = ""
        txtRazonSocial.Text = ""
        txtRuc.Text = ""
        txtDireccion.Text = ""
        txtTelefono.Text = ""
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim clienteDAO As New ClienteDAO(sqlControl)

        If txtCodigo.Text = Nothing Then
            Try
                sqlControl.OpenConexion()
                sqlControl.BeginTransaction()
                clienteDAO.setDBcmd()
                Dim correla As Integer

                correla = clienteDAO.InsertCliente(txtRuc.Text, txtTelefono.Text,
                                                   txtRazonSocial.Text, txtDireccion.Text)
                If correla >= 0 Then
                    txtCodigo.Text = CStr(correla)
                    MessageBox.Show("Cliente grabado correctamente", "Agregar Clientes",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
                End If
                sqlControl.CommitTransaction()
            Catch excep As Exception
                sqlControl.RollbackTransaccion()

                MessageBox.Show("Error al grabar cliente. " + excep.Message, "Agregar Clientes",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            Finally
                Try
                    sqlControl.CloseConexion()
                Catch ex As Exception

                End Try
            End Try
        Else
            Try
                sqlControl.OpenConexion()
                sqlControl.BeginTransaction()
                clienteDAO.setDBcmd()

                Dim correla As Integer

                correla = clienteDAO.updateCliente(CInt(txtCodigo.Text), txtRuc.Text, txtTelefono.Text,
                                                   txtRazonSocial.Text, txtDireccion.Text)


                If correla >= 0 Then
                    MessageBox.Show("Cliente actualizado correctamente.", "Agregar Clientes",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
                End If
                sqlControl.CommitTransaction()
            Catch excep As Exception
                sqlControl.RollbackTransaccion()
                MessageBox.Show("Error al actualizar cliente. " + excep.Message, "Agregar Clientes",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            Finally
                Try
                    sqlControl.CloseConexion()
                Catch ex As Exception
                    sqlControl.RollbackTransaccion()
                    MessageBox.Show("Error al cerrar Conexión. " + ex.Message, "Agregar Clientes",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error)
                End Try
            End Try


        End If

        cargarClientes()
    End Sub
End Class