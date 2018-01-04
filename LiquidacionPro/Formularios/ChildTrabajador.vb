Public Class ChildTrabajador
    Dim columnaFiltro As Integer = -1
    Dim source1 As New BindingSource()
    Dim nombreColumnaFiltro As String

    Private Sub ChildTrabajador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarTrabajadores()
        cargarEstadoTrabajador()
        cargarCargoTrabajador()
    End Sub
    Sub cargarTrabajadores()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim trabajadorDAO As New TrabajadorDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            trabajadorDAO.setDBcmd()

            Dim dt As DataTable

            dt = trabajadorDAO.getAllTrabajador
            dgvTrabajadores.DataSource = dt



            dgvTrabajadores.Columns(4).Visible = False
            dgvTrabajadores.Columns(10).Visible = False
            dgvTrabajadores.Columns(12).Visible = False
            dgvTrabajadores.Columns(14).Visible = False
            sqlControl.commitTransaction()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar trabajadores. " + ex.Message, "Cargar trabajadores",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar trabajadores",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error)
            End Try
        End Try

    End Sub
    Sub cargarEstadoTrabajador()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim estadoDAO As New EstadoDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            estadoDAO.setDBcmd()

            Dim dt As DataTable

            dt = estadoDAO.getEstadoTrabajador

            With cbEstado
                .DataSource = dt
                .DisplayMember = "DETALLE_ESTADO"
                .ValueMember = "CODIGO_ESTADO"
                .SelectedValue = 4
            End With
            sqlControl.commitTransaction()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar estado de trabajador. " + ex.Message, "Cargar estado trabajador",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar estado trabajador",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Sub cargarCargoTrabajador()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim cargoTrabajadorDAO As New CargoTrabajadorDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            cargoTrabajadorDAO.setDBcmd()

            Dim dt As DataTable

            dt = cargoTrabajadorDAO.getAllCargoTrabajador

            With cbCargo
                .DataSource = dt
                .DisplayMember = "DESCRIPCION_CARGO_TRABAJADOR"
                .ValueMember = "CODIGO_CARGO_TRABAJADOR"
                .SelectedValue = 0
            End With
            sqlControl.commitTransaction()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar cargo de trabajadores. " + ex.Message, "Cargar cargo de trabajadores",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar cargo de trabajadores",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim trabajadorDAO As New TrabajadorDAO(sqlControl)

        If txtCodigo.Text = Nothing Then
            Try
                sqlControl.openConexion()
                sqlControl.beginTransaction()
                trabajadorDAO.setDBcmd()
                Dim correla As Integer

                Dim apePaterno As String, apeMaterno As String, nombres As String, feNacimiento As Date, sexo As String, direccion As String,
                    telefono As String, dni As String, brevete As String, cargo As Integer, estado As Integer

                If txtApePaterno.Text = Nothing Then
                    apePaterno = ""
                Else
                    apePaterno = txtApePaterno.Text
                End If

                If txtApeMaterno.Text = Nothing Then
                    apeMaterno = ""
                Else
                    apeMaterno = txtApeMaterno.Text
                End If

                If txtNombres.Text = Nothing Then
                    nombres = ""
                Else
                    nombres = txtNombres.Text
                End If

                If txtDireccion.Text = Nothing Then
                    direccion = ""
                Else
                    direccion = txtDireccion.Text
                End If

                If txtTelefono.Text = Nothing Then
                    telefono = ""
                Else
                    telefono = txtTelefono.Text
                End If

                If txtDni.Text = Nothing Then
                    dni = ""
                Else
                    dni = txtDni.Text
                End If

                If txtBrevete.Text = Nothing Then
                    brevete = ""
                Else
                    brevete = txtBrevete.Text
                End If

                If cbSexo.SelectedIndex < 0 Then
                    sexo = ""
                Else
                    If cbSexo.SelectedIndex = 0 Then
                        sexo = "F"
                    Else
                        sexo = "M"
                    End If
                End If


                correla = trabajadorDAO.InsertTrajador(apePaterno, apeMaterno, nombres, dtpNacimiento.Value, direccion, telefono, dni, brevete, cbCargo.SelectedValue, cbEstado.SelectedValue, sexo)
                If correla >= 0 Then
                    txtCodigo.Text = CStr(correla)
                    MessageBox.Show("Trabajador grabado correctamente", "Agregar Trabajador",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
                End If
                sqlControl.commitTransaction()
            Catch excep As Exception
                sqlControl.rollbackTransaccion()

                MessageBox.Show("Error al grabar Trabajador. " + excep.Message, "Agregar Trabajador",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            Finally
                Try
                    sqlControl.closeConexion()
                Catch ex As Exception
                    MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Agregar Trabajador",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
                End Try
            End Try
        Else
            Try
                sqlControl.openConexion()
                sqlControl.beginTransaction()
                trabajadorDAO.setDBcmd()
                Dim correla As Integer

                Dim codigo As Integer, apePaterno As String, apeMaterno As String, nombres As String, feNacimiento As Date, sexo As String, direccion As String,
                    telefono As String, dni As String, brevete As String, cargo As Integer, estado As Integer

                codigo = CInt(txtCodigo.Text)

                If txtApePaterno.Text = Nothing Then
                    apePaterno = ""
                Else
                    apePaterno = txtApePaterno.Text
                End If

                If txtApeMaterno.Text = Nothing Then
                    apeMaterno = ""
                Else
                    apeMaterno = txtApeMaterno.Text
                End If

                If txtNombres.Text = Nothing Then
                    nombres = ""
                Else
                    nombres = txtNombres.Text
                End If

                If txtDireccion.Text = Nothing Then
                    direccion = ""
                Else
                    direccion = txtDireccion.Text
                End If

                If txtTelefono.Text = Nothing Then
                    telefono = ""
                Else
                    telefono = txtTelefono.Text
                End If

                If txtDni.Text = Nothing Then
                    dni = ""
                Else
                    dni = txtDni.Text
                End If

                If txtBrevete.Text = Nothing Then
                    brevete = ""
                Else
                    brevete = txtBrevete.Text
                End If

                If cbSexo.SelectedIndex < 0 Then
                    sexo = ""
                Else
                    If cbSexo.SelectedIndex = 0 Then
                        sexo = "F"
                    Else
                        sexo = "M"
                    End If
                End If


                correla = trabajadorDAO.updateCliente(codigo, apePaterno, apeMaterno, nombres, dtpNacimiento.Value, direccion, telefono, dni, brevete, cbCargo.SelectedValue, cbEstado.SelectedValue, sexo)
                If correla >= 0 Then
                    MessageBox.Show("Trabajador actualizado correctamente", "Agregar Trabajador",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
                End If
                sqlControl.commitTransaction()
            Catch excep As Exception
                sqlControl.rollbackTransaccion()
                MessageBox.Show("Error al actualizar Trabajador. " + excep.Message, "Agregar Trabajador",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            Finally
                Try
                    sqlControl.closeConexion()
                Catch ex As Exception
                    sqlControl.rollbackTransaccion()
                    MessageBox.Show("Error al cerrar Conexión. " + ex.Message, "Agregar Trabajador",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error)
                End Try
            End Try


        End If

        cargarTrabajadores()
    End Sub

    Private Sub dgvTrabajadores_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvTrabajadores.ColumnHeaderMouseClick
        columnaFiltro = e.ColumnIndex
        nombreColumnaFiltro = dgvTrabajadores.Columns(columnaFiltro).Name
        lblFiltro.Text = nombreColumnaFiltro
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click

        If columnaFiltro = -1 Then
            MessageBox.Show("Debe seleccionar una columna. ", "Filtrar",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If
        source1.DataSource = dgvTrabajadores.DataSource

        Dim tipo As Type = dgvTrabajadores.Columns(columnaFiltro).ValueType

        Select Case tipo.ToString
            Case "System.Decimal", "System.Int32"
                source1.Filter = "[" & nombreColumnaFiltro & "] " & txtFiltro.Text & ""
            Case "System.String"
                source1.Filter = "[" & nombreColumnaFiltro & "] like '%" & txtFiltro.Text & "%'"
        End Select

        dgvTrabajadores.Refresh()
    End Sub

    Private Sub btnDeshacer_Click(sender As Object, e As EventArgs) Handles btnDeshacer.Click
        source1.DataSource = dgvTrabajadores.DataSource
        source1.RemoveFilter()
        dgvTrabajadores.Refresh()
        txtFiltro.Text = ""
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()
    End Sub

    Sub limpiar()
        txtCodigo.Text = ""
        txtApePaterno.Text = ""
        txtApeMaterno.Text = ""
        txtNombres.Text = ""
        txtDireccion.Text = ""
        txtBrevete.Text = ""
        txtDni.Text = ""
        txtTelefono.Text = ""
        cbEstado.SelectedValue = 4
        cbCargo.SelectedValue = 0
        cbSexo.SelectedIndex = -1

    End Sub

    Private Sub dgvTrabajadores_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvTrabajadores.CellMouseClick
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim trabajadorDAO As New TrabajadorDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            trabajadorDAO.setDBcmd()

            Dim seleccion As DataGridViewRow = dgvTrabajadores.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(0).Value

            Dim dt As DataTable
            dt = trabajadorDAO.getTrabajadorByCodigo(codigo)


            txtCodigo.Text = dt.Rows(0)(0)
            txtApePaterno.Text = dt.Rows(0)(1)
            txtApeMaterno.Text = dt.Rows(0)(2)
            txtNombres.Text = dt.Rows(0)(3)
            If dt.Rows(0)(4) IsNot DBNull.Value Then
                dtpNacimiento.Value = dt.Rows(0)(4)
            Else
                dtpNacimiento.Value = Date.Now
            End If

            txtDireccion.Text = dt.Rows(0)(6)
            txtTelefono.Text = dt.Rows(0)(7)
            txtDni.Text = dt.Rows(0)(8)
            txtBrevete.Text = dt.Rows(0)(9)
            cbCargo.SelectedValue = dt.Rows(0)(10)
            cbEstado.SelectedValue = dt.Rows(0)(12)
            If dt.Rows(0)(14).ToString = "F" Then
                cbSexo.SelectedIndex = 0
            ElseIf dt.Rows(0)(14).ToString = "M" Then
                cbSexo.SelectedIndex = 1
            End If


            sqlControl.commitTransaction()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar los datos del trabajador. " + ex.Message, "Cargar Datos Trabajador",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar Datos Trabajador",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            End Try
        End Try
    End Sub
End Class