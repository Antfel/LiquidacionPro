Imports System.Data.SqlClient

Public Class ChildGuia
    Dim columnaFiltro As Integer = -1
    Dim source1 As New BindingSource()
    Dim nombreColumnaFiltro As String
    Private Sub ChildGuia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarGuias()
        cargarEstadoGuia()
        cargarDatosCliente()
        cargarDatosTrabajador()
        cargarDatosTracto()
        cargarDatosSemiTrailer()
    End Sub

    Private Sub cargarDatosTracto()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim unidadDao As New UnidadDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            unidadDao.setDBcmd()

            Dim dtUnidad As DataTable

            dtUnidad = unidadDao.getUnidadTractos()
            sqlControl.CommitTransaction()

            With cbTracto
                .DataSource = dtUnidad
                .DisplayMember = "PLACA_UNIDAD"
                .ValueMember = "CODIGO_UNIDAD"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()

            MessageBox.Show("Error al cargar tractos. " + ex.Message, "Cargar Tractos",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar tractos. " + ex.Message, "Cargar Tractos",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar Tractos",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try


    End Sub

    Private Sub cargarDatosSemiTrailer()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim unidadDao As New UnidadDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            unidadDao.setDBcmd()

            Dim dtUnidad As DataTable

            dtUnidad = unidadDao.getUnidadSemiTrailer
            sqlControl.CommitTransaction()

            With cbCamabaja
                .DataSource = dtUnidad
                .DisplayMember = "PLACA_UNIDAD"
                .ValueMember = "CODIGO_UNIDAD"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar semitrailer. " + ex.Message, "Cargar Semitrailer",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar semitrailer. " + ex.Message, "Cargar Semitrailer",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar Semitrailer",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try

    End Sub

    Private Sub cargarDatosTrabajador()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim trabajadorDao As New TrabajadorDAO(sqlControl)
        Try

            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            trabajadorDao.setDBcmd()

            Dim dtTrabajador As DataTable

            dtTrabajador = trabajadorDao.GetConductor
            sqlControl.CommitTransaction()

            With cbTrabajador
                .DataSource = dtTrabajador
                .DisplayMember = "NOMBRE_TRABAJADOR"
                .ValueMember = "CODIGO_TRABAJADOR"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar trabajador. " + ex.Message, "Cargar Datos Trabajador",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar trabajador. " + ex.Message, "Cargar Datos Trabajador",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar Datos Trabajador",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try
    End Sub
    Private Sub cargarDatosCliente()

        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim clienteDao As New ClienteDAO(sqlControl)

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()

            clienteDao.setDBcmd()

            Dim dtCliente As DataTable
            dtCliente = clienteDao.GetClientes

            With cbRazonSocial
                .DataSource = dtCliente
                .DisplayMember = "RAZON_CLIENTE"
                .ValueMember = "CODIGO_CLIENTE"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1

            End With

            sqlControl.CommitTransaction()
        Catch ex As SQLException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar cliente. " + ex.Message, "Cargar datos de cliente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar cliente. " + ex.Message, "Cargar datos de cliente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar datos de cliente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try

        End Try
    End Sub

    Sub cargarGuias()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim guiaDao As New GuiaDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            guiaDao.setDBcmd()

            Dim dt As DataTable

            dt = guiaDao.GetAllGuia
            sqlControl.CommitTransaction()

            'Se salva el filtro previo
            Dim filtro As String = source1.Filter

            dgvGuias.DataSource = dt

            dgvGuias.Columns(0).Width = 55
            dgvGuias.Columns(1).Width = 75
            dgvGuias.Columns(5).Width = 75
            dgvGuias.Columns(6).Width = 70
            dgvGuias.Columns(8).Width = 60
            dgvGuias.Columns(10).Width = 60
            dgvGuias.Columns(12).Width = 220
            dgvGuias.Columns(13).Width = 80
            dgvGuias.Columns(14).Width = 80
            dgvGuias.Columns(15).Width = 80
            dgvGuias.Columns(17).Width = 220
            dgvGuias.Columns(18).Width = 80
            dgvGuias.Columns(19).Width = 80

            dgvGuias.Columns(2).Visible = False
            dgvGuias.Columns(3).Visible = False
            dgvGuias.Columns(4).Visible = False
            dgvGuias.Columns(7).Visible = False
            dgvGuias.Columns(9).Visible = False
            dgvGuias.Columns(11).Visible = False
            dgvGuias.Columns(16).Visible = False

            dgvGuias.Columns(3).DefaultCellStyle.Format = "dd/MM/yyyy"
            dgvGuias.Columns(4).DefaultCellStyle.Format = "dd/MM/yyyy"

            If filtro <> Nothing Then
                source1.DataSource = dgvGuias.DataSource
                source1.Filter = filtro
                dgvGuias.Refresh()
            End If

            If txtCodigo.Text <> Nothing Then
                Dim rowIndex As Integer = -1
                For Each row As DataGridViewRow In dgvGuias.Rows
                    If row.Cells(0).Value.ToString().Equals(txtCodigo.Text) Then
                        rowIndex = row.Index
                        Exit For
                    End If
                Next

                If rowIndex <> -1 Then
                    dgvGuias.CurrentCell = dgvGuias.Item(0, rowIndex)
                End If

            End If

        Catch ex As SQLException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar Guías. " + ex.Message, "Cargar Guías",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar Guías. " + ex.Message, "Cargar Guías",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception

            End Try
        End Try
    End Sub

    Private Sub cargarEstadoGuia()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim estadoDao As New EstadoGuiaDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            estadoDao.setDBcmd()

            Dim dtEstado As DataTable

            dtEstado = estadoDao.getEstados
            sqlControl.CommitTransaction()

            With cbEstado
                .DataSource = dtEstado
                .DisplayMember = "DETALLE_ESTADO"
                .ValueMember = "CODIGO_ESTADO"
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With
        Catch ex As SQLException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar Estado Guías. " + ex.Message, "Cargar Estado Guías",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar Estado Guías. " + ex.Message, "Cargar Estado Guías",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
                cbEstado.SelectedValue = 17
            Catch ex As Exception

            End Try
        End Try

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtCodigo.Text = ""
        txtDetalle.Text = ""
        cbEstado.SelectedValue = 17
        dtpLiquidacion.Value = Date.Now
        dtpFacturacion.Value = Date.Now
        dtpFechaGuia.Value = Date.Now
        cbTracto.SelectedIndex = -1
        cbCamabaja.SelectedIndex = -1
        cbRazonSocial.SelectedIndex = -1
        cbTrabajador.SelectedIndex = -1
        txtCarga.Text = ""
        txtNa.Text = ""
        txtCantidad.Text = ""
        txtOrigen.Text = ""
        txtDestino.Text = ""
        txtComentario.Text = ""
    End Sub

    Private Sub dgvGuias_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvGuias.CellMouseClick
        cargaGuiaByCodigo()
    End Sub

    Sub cargaGuiaByCodigo()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim guiaDao As New GuiaDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            guiaDao.setDBcmd()

            Dim seleccion As DataGridViewRow = dgvGuias.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(0).Value

            Dim dt As DataTable

            dt = guiaDao.getGuiaByCodigo(codigo)

            sqlControl.CommitTransaction()

            txtCodigo.Text = dt.Rows(0)(0)
            txtDetalle.Text = dt.Rows(0)(1)
            cbEstado.SelectedValue = dt.Rows(0)(2)

            If dt.Rows.Item(0)(3) IsNot DBNull.Value Then
                dtpLiquidacion.Value = dt.Rows.Item(0)(3)
                dtpLiquidacion.Enabled = True
                chkbLiquidacion.Checked = True
            Else
                dtpLiquidacion.Value = Date.Now
                dtpLiquidacion.Enabled = False
                chkbLiquidacion.Checked = False
            End If

            If dt.Rows.Item(0)(4) IsNot DBNull.Value Then
                dtpFacturacion.Value = dt.Rows.Item(0)(4)
                dtpFacturacion.Enabled = True
                chkbFacturacion.Checked = True
            Else
                dtpFacturacion.Value = Date.Now
                dtpFacturacion.Enabled = False
                chkbFacturacion.Checked = False
            End If

            If dt.Rows.Item(0)(6) IsNot DBNull.Value Then
                dtpFechaGuia.Value = dt.Rows.Item(0)(6)
            Else
                dtpFechaGuia.Value = Date.Now
            End If

            If dt.Rows.Item(0)(7) IsNot DBNull.Value Then
                cbTracto.SelectedValue = dt.Rows.Item(0)(7)
            Else
                cbTracto.SelectedIndex = -1
            End If

            If dt.Rows.Item(0)(9) IsNot DBNull.Value Then
                cbCamabaja.SelectedValue = dt.Rows.Item(0)(9)
            Else
                cbCamabaja.SelectedIndex = -1
            End If

            If dt.Rows.Item(0)(11) IsNot DBNull.Value Then
                cbTrabajador.SelectedValue = dt.Rows.Item(0)(11)
            Else
                cbTrabajador.SelectedIndex = -1
            End If

            If dt.Rows.Item(0)(16) IsNot DBNull.Value Then
                cbRazonSocial.SelectedValue = dt.Rows.Item(0)(16)
            Else
                cbRazonSocial.SelectedIndex = -1
            End If

            txtCarga.Text = dt.Rows.Item(0)(13)
            txtNa.Text = dt.Rows.Item(0)(14)
            txtCantidad.Text = dt.Rows.Item(0)(15)
            txtOrigen.Text = dt.Rows.Item(0)(18)
            txtDestino.Text = dt.Rows.Item(0)(19)

        Catch ex As SQLException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar Guía. SQL. " + ex.Message, "Cargar Guía",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar Guía. " + ex.Message, "Cargar Guía",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                If sqlControl.GetDBcon.State = ConnectionState.Open Then
                    sqlControl.CloseConexion()
                End If

            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar Guía",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            Finally
            End Try
        End Try
    End Sub
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim guiaDao As New GuiaDAO(sqlControl)

        Try
            If sqlControl.OpenConexion() Then
                sqlControl.BeginTransaction()
                guiaDao.setDBcmd()

                Dim correla As Integer

                Dim fliqui As Date, ffactura As Date, tracto As Integer, semitrailer As Integer, trabajador As Integer, carga As String, na As String, cantidad As String, cliente As Integer,
                        origen As String, destino As String, comentario As String

                If txtDetalle.Text = Nothing Then
                    MessageBox.Show("Debe ingresar un Nro. de Guía.", "Grabar Guía",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information)
                    Return
                End If

                If chkbLiquidacion.Checked = True Then
                    fliqui = dtpLiquidacion.Value
                Else
                    fliqui = Nothing
                End If

                If chkbFacturacion.Checked = True Then
                    ffactura = dtpLiquidacion.Value
                Else
                    ffactura = Nothing
                End If

                If cbTracto.SelectedIndex < 0 Then
                    tracto = -1
                Else
                    tracto = cbTracto.SelectedValue
                End If

                If cbCamabaja.SelectedIndex < 0 Then
                    semitrailer = -1
                Else
                    semitrailer = cbCamabaja.SelectedValue
                End If

                If cbTrabajador.SelectedIndex < 0 Then
                    trabajador = -1
                Else
                    trabajador = cbTrabajador.SelectedValue
                End If

                If txtCarga.Text = Nothing Then
                    carga = ""
                Else
                    carga = txtCarga.Text
                End If

                If txtNa.Text = Nothing Then
                    na = ""
                Else
                    na = txtNa.Text
                End If

                If txtCantidad.Text = Nothing Then
                    cantidad = ""
                Else
                    cantidad = txtCantidad.Text
                End If

                If cbRazonSocial.SelectedIndex < 0 Then
                    cliente = -1
                Else
                    cliente = cbRazonSocial.SelectedValue
                End If

                If txtOrigen.Text = Nothing Then
                    origen = ""
                Else
                    origen = txtOrigen.Text
                End If

                If txtDestino.Text = Nothing Then
                    destino = ""
                Else
                    destino = txtDestino.Text
                End If

                If txtComentario.Text = Nothing Then
                    comentario = ""
                Else
                    comentario = txtComentario.Text
                End If

                If txtCodigo.Text = Nothing Then
                    correla = guiaDao.InsertGuia(txtDetalle.Text, cbEstado.SelectedValue,
                                                 fliqui, ffactura, dtpFechaGuia.Value, tracto, semitrailer, trabajador,
                                                 carga, na, cantidad, cliente, origen, destino, comentario)

                    If correla >= 0 Then
                        txtCodigo.Text = CStr(correla)
                        MessageBox.Show("Guía grabada correctamente.", "Grabar Guía",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Verificar los datos de la Guía a ingresar.", "Grabar Guía",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation)
                    End If
                Else
                    correla = guiaDao.UpdatetGuia(CInt(txtCodigo.Text), txtDetalle.Text, cbEstado.SelectedValue,
                                                 fliqui, ffactura, dtpFechaGuia.Value, tracto, semitrailer, trabajador,
                                                 carga, na, cantidad, cliente, origen, destino, comentario)

                    If correla >= 0 Then
                        MessageBox.Show("Guía actualizada correctamente.", "Actualizar Guía",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Verificar los datos de la Guía a actualizar.", "Actualizar Guía",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                    End If

                End If

                sqlControl.CommitTransaction()
                cargarGuias()
            End If
        Catch excep As SQLException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al grabar Guía. SQL. " + excep.Message, "Grabar Guía",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch excep As Exception
            MessageBox.Show("Error al grabar Guía. " + excep.Message, "Grabar Guía",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Grabar Guía",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try

    End Sub

    Private Sub chkbLiquidacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkbLiquidacion.CheckedChanged
        If chkbLiquidacion.Checked = True Then
            dtpLiquidacion.Enabled = True
        Else
            dtpLiquidacion.Enabled = False
        End If
    End Sub

    Private Sub chkbFacturacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkbFacturacion.CheckedChanged
        If chkbFacturacion.Checked = True Then
            dtpFacturacion.Enabled = True
        Else
            dtpFacturacion.Enabled = False
        End If
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        If columnaFiltro = -1 Then
            MessageBox.Show("Debe seleccionar una columna. ", "Filtrar",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If
        source1.DataSource = dgvGuias.DataSource

        Dim tipo As Type = dgvGuias.Columns(columnaFiltro).ValueType

        Select Case tipo.ToString
            Case "System.Decimal", "System.Int32"
                source1.Filter = "[" & nombreColumnaFiltro & "] " & txtFiltro.Text & ""
            Case "System.String"
                source1.Filter = "[" & nombreColumnaFiltro & "] like '%" & txtFiltro.Text & "%'"
        End Select

        dgvGuias.Refresh()
    End Sub

    Private Sub btnDeshacer_Click(sender As Object, e As EventArgs) Handles btnDeshacer.Click
        source1.DataSource = dgvGuias.DataSource
        source1.RemoveFilter()
        dgvGuias.Refresh()
        txtFiltro.Text = ""
    End Sub

    Private Sub dgvGuias_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvGuias.ColumnHeaderMouseClick
        columnaFiltro = e.ColumnIndex
        nombreColumnaFiltro = dgvGuias.Columns(columnaFiltro).Name
        lblFiltro.Text = nombreColumnaFiltro
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub dtpFechaGuia_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaGuia.ValueChanged

    End Sub
End Class