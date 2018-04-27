Imports System.Data.SqlClient

Public Class ChildUnidad

    Dim columnaFiltro As Integer = -1
    Dim source1 As New BindingSource()
    Dim nombreColumnaFiltro As String
    Private Sub ChildUnidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarUnidades()
        CargarTipoUnidad()
    End Sub

    Sub CargarUnidades()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim dao As New UnidadDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            dao.setDBcmd()

            Dim dt As DataTable

            dt = dao.GetAllUnidad
            sqlControl.CommitTransaction()
            dgvUnidad.DataSource = dt

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar Unidad. SQL. " + ex.Message, "Cargar Unidad",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar Unidad. " + ex.Message, "Cargar Unidad",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar  Unidad",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try
    End Sub
    Sub CargarTipoUnidad()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim dao As New UnidadDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            dao.setDBcmd()

            Dim dt As DataTable

            dt = dao.GetTipoUnidad
            sqlControl.CommitTransaction()

            With cbTipoUnidad
                .DataSource = dt
                .DisplayMember = "DETALLE_TIPO_UNIDAD"
                .ValueMember = "CODIGO_TIPO_UNIDAD"
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With
        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar Tipo Unidad. SQL. " + ex.Message, "Cargar Tipo Unidad",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar Tipo Unidad. " + ex.Message, "Cargar Tipo Unidad",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar Tipo Unidad",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try
    End Sub
    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click

        If columnaFiltro = -1 Then
            MessageBox.Show("Debe seleccionar una columna. ", "Filtrar",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If
        source1.DataSource = dgvUnidad.DataSource

        Dim tipo As Type = dgvUnidad.Columns(columnaFiltro).ValueType

        Select Case tipo.ToString
            Case "System.Decimal", "System.Int32"
                source1.Filter = "[" & nombreColumnaFiltro & "] " & txtFiltro.Text & ""
            Case "System.String"
                source1.Filter = "[" & nombreColumnaFiltro & "] like '%" & txtFiltro.Text & "%'"
        End Select

        dgvUnidad.Refresh()
    End Sub

    Private Sub dgvUnidad_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvUnidad.ColumnHeaderMouseClick
        columnaFiltro = e.ColumnIndex
        nombreColumnaFiltro = dgvUnidad.Columns(columnaFiltro).Name
        lblFiltro.Text = nombreColumnaFiltro
    End Sub

    Private Sub btnDeshacer_Click(sender As Object, e As EventArgs) Handles btnDeshacer.Click
        source1.DataSource = dgvUnidad.DataSource
        source1.RemoveFilter()
        dgvUnidad.Refresh()
        txtFiltro.Text = ""
    End Sub

    Private Sub dgvUnidad_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvUnidad.CellMouseClick
        CargarUnidad()
    End Sub
    Sub CargarUnidad()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim dao As New UnidadDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            dao.setDBcmd()

            Dim seleccion As DataGridViewRow = dgvUnidad.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(0).Value
            'filaSeleccionada = seleccion.Index
            Dim dt As DataTable
            dt = dao.GetUnidadById(codigo)
            sqlControl.CommitTransaction()

            txtCodigo.Text = dt.Rows(0)(0)
            txtPlaca.Text = dt.Rows(0)(1)
            cbTipoUnidad.SelectedValue = dt.Rows(0)(2)
            txtEjes.Text = dt.Rows(0)(3)

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar. SQL." + ex.Message, "Cargar",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar. " + ex.Message, "Cargar",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

        Dim codigo As Integer, placa As String, tipo As Integer, ejes As Integer

        If txtPlaca.Text = Nothing Then
            MessageBox.Show("Ingresar una placa. ", "Validación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If

        If cbTipoUnidad.SelectedIndex < 0 Then
            MessageBox.Show("Seleccionar un Tipo de Unidad. ", "Validación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If

        Try
            If txtCodigo.Text = Nothing Then
                codigo = 0
            Else
                codigo = CType(txtCodigo.Text, Integer)
            End If

            If txtPlaca.Text = Nothing Then
                placa = ""
            Else
                placa = txtPlaca.Text
            End If

            tipo = cbTipoUnidad.SelectedValue

            If txtEjes.Text = Nothing Then
                ejes = 0
            Else
                ejes = txtEjes.Text
            End If

            Dim sqlControl As New SQLControl
            sqlControl.SetConnection()

            Dim dao As New UnidadDAO(sqlControl)

            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            dao.setDBcmd()


            Try
                If codigo = 0 Then
                    Dim correla As Integer

                    correla = dao.InsertUnidad(placa, tipo, ejes)
                    If correla > -1 Then
                        txtCodigo.Text = correla
                        MessageBox.Show("Registrado.", "Agregar Unidad",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Algo salió mal.", "Agregar Unidad",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    End If
                Else
                    Dim correla As Integer

                    correla = dao.UpdateUsuario(codigo, placa, tipo, ejes)
                    If correla > -1 Then
                        MessageBox.Show("Actualizado.", "Actualizar Unidad",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Algo salió mal.", "Actualizar Unidad",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    End If
                End If
                dao.commitTransacction()
            Catch ex2 As SqlException
                sqlControl.RollbackTransaccion()
                MessageBox.Show("Error al cerrar Conexión. SQL. " + ex2.Message, "Agregar Usuario",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
            Catch ex1 As Exception
                MessageBox.Show("Error al cerrar Conexión. " + ex1.Message, "Agregar Usuario",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
            Finally
                If sqlControl.GetDBcon.State = ConnectionState.Open Then
                    sqlControl.CloseConexion()
                End If
                CargarUnidades()
            End Try

        Catch ex As Exception


        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtCodigo.Text = ""
        txtPlaca.Text = ""
        cbTipoUnidad.SelectedIndex = -1
        txtEjes.Text = ""
    End Sub
End Class