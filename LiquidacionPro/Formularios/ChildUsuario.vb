Imports System.Data.SqlClient

Public Class ChildUsuario

    Dim columnaFiltro As Integer = -1
    Dim source1 As New BindingSource()
    Dim nombreColumnaFiltro As String

    Private Sub ChildUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarAllUsuario()
        CargarRol()
        CargarEstado()
    End Sub

    Sub CargarEstado()
        Dim data As New DataTable
        data.Columns.Add("CODIGO")
        data.Columns.Add("DESCRIPCION")

        data.Rows.Add({1, "Activo"})
        data.Rows.Add({0, "Inactivo"})


        With cbEstado
            .DataSource = data
            .ValueMember = "CODIGO"
            .DisplayMember = "DESCRIPCION"
        End With

        cbEstado.SelectedIndex = 0
    End Sub
    Sub CargarRol()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim rolDAO As New RolDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            rolDAO.setDBcmd()

            Dim dt As DataTable = rolDAO.GetAllRol
            rolDAO.commitTransacction()

            With cbRol
                .DataSource = dt
                .ValueMember = "ID_ROL"
                .DisplayMember = "DESCRIPCION"
            End With

        Catch excep As Exception
            sqlControl.RollbackTransaccion()
        Finally
            Try
                rolDAO.closeConexion()
            Catch ex As Exception

            End Try
        End Try
    End Sub


    Sub CargarAllUsuario()

        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim correlativo As New UsuarioDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            correlativo.setDBcmd()

            Dim dt As DataTable = correlativo.GetAllUsuario

            dgvUsuario.DataSource = dt
            sqlControl.CommitTransaction()

            'Se salva el filtro previo
            Dim filtro As String = source1.Filter

            dgvUsuario.Columns(7).Visible = False

            If filtro <> Nothing Then
                source1.DataSource = dgvUsuario.DataSource
                source1.Filter = filtro
                dgvUsuario.Refresh()
            End If

            If txtId_Usuario.Text <> Nothing Then
                Dim rowIndex As Integer = -1
                For Each row As DataGridViewRow In dgvUsuario.Rows
                    If row.Cells(0).Value.ToString().Equals(txtId_Usuario.Text) Then
                        rowIndex = row.Index
                        Exit For
                    End If
                Next

                If rowIndex <> -1 Then
                    dgvUsuario.CurrentCell = dgvUsuario.Item(0, rowIndex)
                End If

            End If

        Catch excep As Exception
            sqlControl.RollbackTransaccion()
        Finally
            Try
                correlativo.closeConexion()
            Catch ex As Exception

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
        source1.DataSource = dgvUsuario.DataSource

        Dim tipo As Type = dgvUsuario.Columns(columnaFiltro).ValueType

        Select Case tipo.ToString
            Case "System.Decimal", "System.Int32"
                source1.Filter = "[" & nombreColumnaFiltro & "] " & txtFiltro.Text & ""
            Case "System.String"
                source1.Filter = "[" & nombreColumnaFiltro & "] like '%" & txtFiltro.Text & "%'"
        End Select

        dgvUsuario.Refresh()
    End Sub

    Private Sub btnDeshacer_Click(sender As Object, e As EventArgs) Handles btnDeshacer.Click
        source1.DataSource = dgvUsuario.DataSource
        source1.RemoveFilter()
        dgvUsuario.Refresh()
        txtFiltro.Text = ""
    End Sub

    Private Sub dgvUsuario_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvUsuario.ColumnHeaderMouseClick
        columnaFiltro = e.ColumnIndex
        nombreColumnaFiltro = dgvUsuario.Columns(columnaFiltro).Name
        lblFiltro.Text = nombreColumnaFiltro
    End Sub

    Private Sub dgvUsuario_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvUsuario.CellMouseClick
        CargarUsuario()
    End Sub

    Sub CargarUsuario()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim usuarioDAO As New UsuarioDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            usuarioDAO.setDBcmd()

            Dim seleccion As DataGridViewRow = dgvUsuario.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(0).Value
            'filaSeleccionada = seleccion.Index
            Dim dt As DataTable
            dt = usuarioDAO.GetUsuarioById(codigo)
            sqlControl.CommitTransaction()

            txtId_Usuario.Text = dt.Rows(0)(0)
            txtApe_Paterno.Text = dt.Rows(0)(1)
            txtApe_Materno.Text = dt.Rows(0)(2)
            txtNombres.Text = dt.Rows(0)(3)
            txtNombre_Usuario.Text = dt.Rows(0)(4)
            txtPass.Text = dt.Rows(0)(5)
            dtpInicio.Value = dt.Rows(0)(6)
            dtpFin.Value = dt.Rows(0)(7)
            cbRol.SelectedValue = dt.Rows(0)(8)
            Console.WriteLine("datos: " + dt.Rows(0)(9).ToString)
            cbEstado.SelectedValue = dt.Rows(0)(9)


        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar liquidación. " + ex.Message, "Cargar Liquidación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar liquidación. " + ex.Message, "Cargar Liquidación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar Liquidación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

        Dim idUsuario As Integer, ape_pat As String, ape_mat As String, nombres As String, usuario As String,
            pass As String, inicio As Date, fin As Date, estado As Integer, rol As Integer

        Try
            If txtId_Usuario.Text = Nothing Then
                idUsuario = 0
            Else
                idUsuario = CType(txtId_Usuario.Text, Integer)
            End If

            If txtApe_Paterno.Text = Nothing Then
                ape_pat = ""
            Else
                ape_pat = txtApe_Paterno.Text
            End If

            If txtApe_Materno.Text = Nothing Then
                ape_mat = ""
            Else
                ape_mat = txtApe_Materno.Text
            End If

            If txtNombres.Text = Nothing Then
                nombres = ""
            Else
                nombres = txtNombres.Text
            End If

            If txtNombre_Usuario.Text = Nothing Then
                usuario = ""
            Else
                usuario = txtNombre_Usuario.Text
            End If

            If txtPass.Text = Nothing Then
                pass = ""
            Else
                pass = txtPass.Text
            End If

            inicio = dtpInicio.Value
            fin = dtpFin.Value

            rol = cbRol.SelectedValue

            estado = cbEstado.SelectedValue

            Dim sqlControl As New SQLControl
            sqlControl.SetConnection()

            Dim usuarioDAO As New UsuarioDAO(sqlControl)

            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            usuarioDAO.setDBcmd()


            Try
                If idUsuario = 0 Then
                    Dim correla As Integer

                    correla = usuarioDAO.InsertUsuario(ape_pat, ape_mat, nombres, usuario, pass, inicio, fin, rol, estado)
                    If correla > -1 Then
                        txtId_Usuario.Text = correla
                        MessageBox.Show("Registrado.", "Agregar Usuario",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Algo salió mal.", "Agregar Usuario",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    End If
                Else
                    Dim correla As Integer

                    correla = usuarioDAO.UpdateUsuario(idUsuario, ape_pat, ape_mat, nombres, usuario, pass, inicio, fin, rol, estado)
                    If correla > -1 Then
                        MessageBox.Show("Actualizado.", "Actualizar Usuario",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Algo salió mal.", "Actualizar Usuario",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    End If
                End If
                usuarioDAO.commitTransacction()
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
                CargarAllUsuario()
            End Try

        Catch ex As Exception


        End Try



    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
    End Sub

    Sub Limpiar()
        txtId_Usuario.Text = ""
        txtApe_Paterno.Text = ""
        txtApe_Materno.Text = ""
        txtNombres.Text = ""
        txtNombre_Usuario.Text = ""
        txtPass.Text = ""
        dtpInicio.Value = Date.Now
        dtpFin.Value = Date.Now
        cbRol.SelectedIndex = 0
        cbEstado.SelectedIndex = 0
    End Sub
End Class