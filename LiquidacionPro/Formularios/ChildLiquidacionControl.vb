Public Class ChildLiquidacionControl

    Dim columnaFiltro As Integer = -1
    Dim source1 As New BindingSource()
    Dim nombreColumnaFiltro As String
    Dim filaSeleccionada As Integer = -1
    Private Sub ChildLiquidacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actualizarListaLiquidacion()
        actualizarDatosTrabajador()
        actualizarDatosGuia()
        actualizarDatosTracto()
        actualizarDatosSemiTrailer()
        actualizarEstados()
        cargarUnidadMedida()
        dtpSalida.Format = DateTimePickerFormat.Custom
        dtpSalida.CustomFormat = "dd/MM/yyyy hh:mm tt"
        dtpLlegada.Format = DateTimePickerFormat.Custom
        dtpLlegada.CustomFormat = "dd/MM/yyyy hh:mm tt"
        dtpFechaHoraPeaje.Format = DateTimePickerFormat.Custom
        dtpFechaHoraPeaje.CustomFormat = "dd/MM/yyyy hh:mm tt"
        limpiar()
    End Sub

    Sub cargarUnidadMedida()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim unidadMedidaDAO As New UnidadMedidaDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            unidadMedidaDAO.setDBcmd()

            Dim dt As DataTable

            dt = unidadMedidaDAO.getAllUnidadMedida

            With cbUnidadMedida
                .DataSource = dt
                .DisplayMember = "DETALLE_ESTADO"
                .ValueMember = "CODIGO_ESTADO"
                .SelectedIndex = 0
            End With

            sqlControl.commitTransaction()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar Unidad Medida. " + ex.Message, "Cargar Unidad Medida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar Unidad Medida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub btnAgregarLiquidacion_Click(sender As Object, e As EventArgs) Handles btnAgregarLiquidacion.Click

        If cbTrabajador.SelectedIndex < 0 Then
            MessageBox.Show("Seleccionar un Trabajador.", "Agregar liquidación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
            Return
        End If

        If txtNroLiquidacion.Text = Nothing Then
            MessageBox.Show("Ingresar nro. de liquidación.", "Agregar liquidación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
            Return
        End If

        If cbTracto.SelectedIndex < 0 Then
            MessageBox.Show("Seleccionar un tracto.", "Agregar liquidación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
            Return
        End If

        'If cbCamabaja.SelectedIndex < 0 Then
        '    MessageBox.Show("Seleccionar un semitrailer.", "Agregar liquidación",
        '                        MessageBoxButtons.OK,
        '                        MessageBoxIcon.Exclamation)
        '    Return
        'End If


        'If cbGuia.SelectedIndex < 0 Then
        '    MessageBox.Show("Seleccionar una guía de transportista.", "Agregar liquidación",
        '                        MessageBoxButtons.OK,
        '                        MessageBoxIcon.Exclamation)
        '    Return
        'End If

        Dim respuesta As Integer, guia, camabaja As Integer

        guia = -1
        camabaja = -1


        If cbCamabaja.SelectedIndex < 0 Then
            respuesta = MessageBox.Show("Está registrando una liquidación sin camabaja asignada. ¿Está seguro de proceder?", "Valiidación",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Exclamation)

            If respuesta = 7 Then
                Return
            End If
        End If

        If cbGuia.SelectedIndex < 0 Then
            respuesta = MessageBox.Show("Está registrando una liquidación sin guía de transportista. ¿Está seguro de proceder?", "Valiidación",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Exclamation)

            If respuesta = 7 Then
                Return
            End If
        End If
        Dim origen As String, destino As String, dinero As Double, peaje As Double, viatico As Double, guardiania As Double, hospedaje As Double, balanza As Double,
            otros As Double, fisico As Double, virtual As Double, carga As String, peso As Double

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

        If txtDinero.Text = Nothing Then
            dinero = 0
        Else
            dinero = Double.Parse(txtDinero.Text)
        End If

        If txtPeajes.Text = Nothing Then
            peaje = 0
        Else
            peaje = Double.Parse(txtPeajes.Text)
        End If

        If txtViaticos.Text = Nothing Then
            viatico = 0
        Else
            viatico = Double.Parse(txtViaticos.Text)
        End If

        If txtGuardiania.Text = Nothing Then
            guardiania = 0
        Else
            guardiania = Double.Parse(txtGuardiania.Text)
        End If

        If txtHospedaje.Text = Nothing Then
            hospedaje = 0
        Else
            hospedaje = Double.Parse(txtHospedaje.Text)
        End If

        If txtBalanza.Text = Nothing Then
            balanza = 0
        Else
            balanza = Double.Parse(txtBalanza.Text)
        End If

        If txtOtros.Text = Nothing Then
            otros = 0
        Else
            otros = Double.Parse(txtOtros.Text)
        End If

        If txtCombustibleFisico.Text = Nothing Then
            fisico = 0
        Else
            fisico = Double.Parse(txtCombustibleFisico.Text)
        End If

        If txtCombustibleVirtual.Text = Nothing Then
            virtual = 0
        Else
            virtual = Double.Parse(txtCombustibleVirtual.Text)
        End If

        If txtCarga.Text = Nothing Then
            carga = ""
        Else
            carga = txtCarga.Text
        End If

        If txtPeso.Text = Nothing Then
            peso = 0
        Else
            peso = Double.Parse(txtPeso.Text)
        End If

        If cbGuia.SelectedIndex < 0 Then
            guia = -1
        Else
            guia = cbGuia.SelectedValue
        End If

        If cbCamabaja.SelectedIndex < 0 Then
            camabaja = -1
        Else
            camabaja = cbCamabaja.SelectedValue
        End If

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim liquidacionDao As New LiquidacionDAO(sqlControl)

        If txtCodigoLiquidacion.Text = Nothing Then
            Try
                sqlControl.openConexion()
                sqlControl.beginTransaction()
                liquidacionDao.setDBcmd()
                Dim correla As Integer

                cbEstado.SelectedValue = 1



                correla = liquidacionDao.InsertLiquidacion(txtNroLiquidacion.Text, cbTrabajador.SelectedValue,
                                                           guia,
                                             cbTracto.SelectedValue, camabaja, origen,
                                             destino, dtpSalida.Value, dtpLlegada.Value,
                                             dinero, peaje, viatico,
                                             guardiania, hospedaje, balanza,
                                             otros, fisico,
                                             virtual, cbEstado.SelectedValue, carga, peso, cbUnidadMedida.SelectedValue)
                If correla >= 0 Then
                    txtCodigoLiquidacion.Text = CStr(correla)
                    MessageBox.Show("Liquidación grabada correctamente", "Agregar Liquidaciones",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
                End If
                sqlControl.commitTransaction()
            Catch excep As Exception
                sqlControl.rollbackTransaccion()

                MessageBox.Show("Error al grabar Liquidación. " + excep.Message, "Agregar Liquidaciones",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            Finally
                Try
                    sqlControl.closeConexion()
                Catch ex As Exception

                End Try
            End Try
        Else
            Try
                sqlControl.openConexion()
                sqlControl.beginTransaction()
                liquidacionDao.setDBcmd()

                Dim correla As Integer
                correla = liquidacionDao.UpdateLiquidacion(txtCodigoLiquidacion.Text, txtNroLiquidacion.Text, cbTrabajador.SelectedValue, guia,
                                         cbTracto.SelectedValue, camabaja, origen,
                                         destino, dtpSalida.Value, dtpLlegada.Value,
                                         dinero, peaje, viatico,
                                         guardiania, hospedaje, balanza,
                                         otros, fisico, virtual,
                                         cbEstado.SelectedValue, carga, peso, cbUnidadMedida.SelectedValue)


                If correla >= 0 Then
                    MessageBox.Show("Liquidación actualizada correctamente", "Agregar Liquidaciones",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
                End If
                sqlControl.commitTransaction()
            Catch excep As Exception
                sqlControl.rollbackTransaccion()
                MessageBox.Show("Error al actualizar Liquidación. " + excep.Message, "Agregar Liquidaciones",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            Finally
                Try
                    sqlControl.closeConexion()
                Catch ex As Exception
                    sqlControl.rollbackTransaccion()
                    MessageBox.Show("Error al cerrar Conexión. " + ex.Message, "Agregar Liquidaciones",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error)
                End Try
            End Try


        End If

        actualizarListaLiquidacion()

    End Sub

    Private Sub dgvLiquidacion_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvLiquidacion.CellMouseClick
        cargarLiquidacion()
        If txtCodigoLiquidacion.Text IsNot Nothing Then
            cargarPeajes(CInt(txtCodigoLiquidacion.Text))
            cargarViaticos(CInt(txtCodigoLiquidacion.Text))
            cargarOtros(CInt(txtCodigoLiquidacion.Text))
        End If

    End Sub

    Sub cargarLiquidacion()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim liquidacionDao As New LiquidacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDao.setDBcmd()

            Dim seleccion As DataGridViewRow = dgvLiquidacion.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(0).Value
            filaSeleccionada = seleccion.Index
            Dim dt As DataTable
            dt = liquidacionDao.GetLiquidacionById(codigo)


            txtCodigoLiquidacion.Text = dt.Rows(0)(0)
            txtNroLiquidacion.Text = dt.Rows(0)(1)
            cbTrabajador.SelectedValue = dt.Rows(0)(2)
            If dt.Rows(0)(4) IsNot DBNull.Value Then
                actualizarDatosGuiaRegistrada(CInt(dt.Rows(0)(4)))
                cbGuia.SelectedValue = dt.Rows(0)(4)
            End If


            cbTracto.SelectedValue = dt.Rows(0)(6)
            txtOrigen.Text = dt.Rows(0)(10)
            dtpLlegada.Value = dt.Rows(0)(13)

            If dt.Rows(0)(8) IsNot DBNull.Value Then
                cbCamabaja.SelectedValue = dt.Rows(0)(8)
            End If

            txtDestino.Text = dt.Rows(0)(11)
            dtpSalida.Value = dt.Rows(0)(12)
            txtDinero.Text = dt.Rows(0)(14)
            txtGuardiania.Text = dt.Rows(0)(17)
            txtHospedaje.Text = dt.Rows(0)(18)
            txtPeajes.Text = dt.Rows(0)(15)
            txtViaticos.Text = dt.Rows(0)(16)
            txtBalanza.Text = dt.Rows(0)(19)
            txtOtros.Text = dt.Rows(0)(20)
            txtCombustibleFisico.Text = dt.Rows(0)(21)
            txtCombustibleVirtual.Text = dt.Rows(0)(22)
            cbEstado.SelectedValue = dt.Rows(0)(23)
            txtTotalGasto.Text = dt.Rows(0)(25)
            txtDiferencia.Text = dt.Rows(0)(26)
            txtDiferenciaComb.Text = dt.Rows(0)(27)

            txtCarga.Text = dt.Rows(0)(34)
            txtPeso.Text = dt.Rows(0)(35)

            If dt.Rows(0)(36) <> -1 Then
                cbUnidadMedida.SelectedValue = dt.Rows(0)(36)
            Else
                cbUnidadMedida.SelectedIndex = 0
            End If


            sqlControl.commitTransaction()

        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar liquidación. " + ex.Message, "Cargar Liquidación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar Liquidación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try
    End Sub
    Private Sub txtCodigoLiquidacion_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoLiquidacion.TextChanged

    End Sub

    Private Sub actualizarListaLiquidacion()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim liquidacionDao As New LiquidacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDao.setDBcmd()

            Dim dt As DataTable

            dt = liquidacionDao.GetAllLiquidacion()
            dgvLiquidacion.DataSource = dt

            dgvLiquidacion.Columns(2).Visible = False
            dgvLiquidacion.Columns(4).Visible = False
            dgvLiquidacion.Columns(6).Visible = False
            dgvLiquidacion.Columns(8).Visible = False
            dgvLiquidacion.Columns(23).Visible = False

            dgvLiquidacion.MultiSelect = False
            dgvLiquidacion.RowHeadersVisible = False

            sqlControl.commitTransaction()

            If filaSeleccionada <> -1 Then
                dgvLiquidacion.CurrentCell = dgvLiquidacion.Item(0, filaSeleccionada)
            End If
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar liquidaciones. " + ex.Message, "Cargar Liquidaciones",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar Liquidaciones",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try


    End Sub
    Private Sub actualizarDatosTrabajador()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim trabajadorDao As New TrabajadorDAO(sqlControl)
        Try

            sqlControl.openConexion()
            sqlControl.beginTransaction()
            trabajadorDao.setDBcmd()

            Dim dtTrabajador As DataTable

            dtTrabajador = trabajadorDao.GetConductor

            With cbTrabajador
                .DataSource = dtTrabajador
                .DisplayMember = "NOMBRE_TRABAJADOR"
                .ValueMember = "CODIGO_TRABAJADOR"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With

            sqlControl.commitTransaction()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar trabajador. " + ex.Message, "Cargar Datos Trabajador",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar Datos Trabajador",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub actualizarDatosGuia()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim guiaDao As New GuiaDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            guiaDao.setDBcmd()
            Dim dtGuia As DataTable

            dtGuia = guiaDao.getGuiaPendLiquidacion

            With cbGuia
                .DataSource = dtGuia
                .DisplayMember = "DETALLE_GUIA"
                .ValueMember = "CODIGO_GUIA"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With
            sqlControl.commitTransaction()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar guías. " + ex.Message, "Cargar Guías",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar Guías",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try

    End Sub

    Private Sub actualizarDatosGuiaRegistrada(cod_guia As Integer)
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim guiaDao As New GuiaDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            guiaDao.setDBcmd()
            Dim dtGuia As DataTable

            dtGuia = guiaDao.getGuiaByCodigo(cod_guia)
            sqlControl.commitTransaction()

            With cbGuia
                .DataSource = dtGuia
                .DisplayMember = "DETALLE_GUIA"
                .ValueMember = "CODIGO_GUIA"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar Guía Registrada. " + ex.Message, "Cargar Guía Registrada",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar Guía Registrada",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try

    End Sub

    Private Sub actualizarDatosTracto()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim unidadDao As New UnidadDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            unidadDao.setDBcmd()

            Dim dtUnidad As DataTable

            dtUnidad = unidadDao.getUnidadTractos()

            With cbTracto
                .DataSource = dtUnidad
                .DisplayMember = "PLACA_UNIDAD"
                .ValueMember = "CODIGO_UNIDAD"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With

            sqlControl.commitTransaction()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()

            MessageBox.Show("Error al cargar tractos. " + ex.Message, "Cargar Tractos",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar Tractos",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try


    End Sub

    Private Sub actualizarDatosSemiTrailer()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim unidadDao As New UnidadDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            unidadDao.setDBcmd()

            Dim dtUnidad As DataTable

            dtUnidad = unidadDao.getUnidadSemiTrailer

            With cbCamabaja
                .DataSource = dtUnidad
                .DisplayMember = "PLACA_UNIDAD"
                .ValueMember = "CODIGO_UNIDAD"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With

            sqlControl.commitTransaction()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar semitrailer. " + ex.Message, "Cargar Semitrailer",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar Semitrailer",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try

    End Sub

    Private Sub actualizarEstados()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim estadoDao As New EstadoDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            estadoDao.setDBcmd()

            Dim dtEstado As DataTable

            dtEstado = estadoDao.getEstados

            With cbEstado
                .DataSource = dtEstado
                .DisplayMember = "DETALLE_ESTADO"
                .ValueMember = "CODIGO_ESTADO"
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedValue = 1
            End With

            sqlControl.commitTransaction()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar estados. " + ex.Message, "Cargar Estados",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar Estados",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()
    End Sub

    Sub limpiar()
        txtCodigoLiquidacion.Text = ""
        txtNroLiquidacion.Text = ""
        cbTrabajador.SelectedIndex = -1
        cbGuia.SelectedIndex = -1
        cbTracto.SelectedIndex = -1
        txtOrigen.Text = ""
        dtpLlegada.Value = DateTime.Now
        cbCamabaja.SelectedIndex = -1
        txtDestino.Text = ""
        dtpSalida.Value = DateTime.Now
        txtDinero.Text = "0.00"
        txtGuardiania.Text = "0.00"
        txtHospedaje.Text = "0.00"
        txtPeajes.Text = "0.00"
        txtViaticos.Text = "0.00"
        txtBalanza.Text = "0.00"
        txtOtros.Text = "0.00"
        txtTotalGasto.Text = "0.00"
        txtDiferencia.Text = "0.00"
        txtCombustibleFisico.Text = "0.00"
        txtCombustibleVirtual.Text = "0.00"
        txtDiferenciaComb.Text = "0.00"
        cbEstado.SelectedValue = 1
        cbUnidadMedida.SelectedIndex = 0
        actualizarDatosGuia()

        dtpFechaHoraPeaje.Value = DateTime.Now
        dtpTurnoViaticos.Value = DateTime.Now

        cargarOtros(-1)
        cargarPeajes(-1)
        cargarViaticos(-1)

    End Sub

    Private Sub dgvLiquidacion_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvLiquidacion.ColumnHeaderMouseClick
        columnaFiltro = e.ColumnIndex
        nombreColumnaFiltro = dgvLiquidacion.Columns(columnaFiltro).Name
        lblFiltro.Text = nombreColumnaFiltro
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click

        If columnaFiltro = -1 Then
            MessageBox.Show("Debe seleccionar una columna. ", "Filtrar",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If
        source1.DataSource = dgvLiquidacion.DataSource

        Dim tipo As Type = dgvLiquidacion.Columns(columnaFiltro).ValueType

        Select Case tipo.ToString
            Case "System.Decimal", "System.Int32"
                source1.Filter = "[" & nombreColumnaFiltro & "] " & txtFiltro.Text & ""
            Case "System.String"
                source1.Filter = "[" & nombreColumnaFiltro & "] like '%" & txtFiltro.Text & "%'"
        End Select

        dgvLiquidacion.Refresh()
    End Sub

    Private Sub btnDeshacer_Click(sender As Object, e As EventArgs) Handles btnDeshacer.Click
        source1.DataSource = dgvLiquidacion.DataSource
        source1.RemoveFilter()
        dgvLiquidacion.Refresh()
        txtFiltro.Text = ""
    End Sub

    Private Sub btnAgregarPeaje_Click(sender As Object, e As EventArgs) Handles btnAgregarPeaje.Click
        If txtCodigoLiquidacion.Text = Nothing Then
            MessageBox.Show("Debe grabar la Liquidación primero. ", "Agregar peaje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
            Return
        End If

        If txtEjesPeaje.Text = Nothing Then
            MessageBox.Show("Debe ingresar el nro. de ejes. ", "Agregar peaje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation)
            Return
        End If

        If txtLugarPeaje.Text = Nothing Then
            MessageBox.Show("Debe ingresar el lugar. ", "Agregar peaje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation)
            Return
        End If

        If txtTotalPeaje.Text = Nothing Then
            MessageBox.Show("Debe ingresar el total del peaje. ", "Agregar peaje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation)
            Return
        End If

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            liquidacionDAO.InsertLiquidacionPeaje(CInt(txtCodigoLiquidacion.Text), dtpFechaHoraPeaje.Value, txtLugarPeaje.Text, CInt(txtEjesPeaje.Text), Double.Parse(txtTotalPeaje.Text.ToString))

            sqlControl.commitTransaction()
            cargarLiquidacion()
            cargarPeajes(CInt(txtCodigoLiquidacion.Text))
            txtEjesPeaje.Text = ""
            txtTotalPeaje.Text = ""
            txtLugarPeaje.Text = ""
            dtpFechaHoraPeaje.Value = Date.Now
            dtpFechaHoraPeaje.Focus()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al agregar peaje. " + ex.Message, "Agregar peaje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Agregar peaje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            End Try
        End Try

    End Sub

    Sub cargarPeajes(codigo As Integer)

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()
        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            Dim dt As DataTable
            dt = liquidacionDAO.GetLiquidacionPeajeByIdLiquidacion(codigo)

            dgvPeajes.DataSource = dt

            dgvPeajes.Columns(0).Visible = False
            dgvPeajes.Columns(1).Visible = False

            sqlControl.commitTransaction()

        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar peaje. " + ex.Message, "Cargar peaje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Agregar peaje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Sub cargarViaticos(codigo As Integer)

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()
        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            Dim dt As DataTable
            dt = liquidacionDAO.GetLiquidacionViaticoByIdLiquidacion(codigo)

            dgvViaticos.DataSource = dt

            dgvViaticos.Columns(0).Visible = False
            dgvViaticos.Columns(1).Visible = False

            sqlControl.commitTransaction()

        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar peaje. " + ex.Message, "Cargar peaje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Agregar peaje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub btnEliminarPeaje_Click(sender As Object, e As EventArgs) Handles btnEliminarPeaje.Click
        If dgvPeajes.Rows.Count <= 0 Then
            Return
        End If

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()
        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)
        Try
            Dim seleccion As DataGridViewRow = dgvPeajes.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(1).Value

            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            liquidacionDAO.deleteLiquidacionPeajeById(CInt(txtCodigoLiquidacion.Text), codigo)

            sqlControl.commitTransaction()
            cargarLiquidacion()
            cargarPeajes(CInt(txtCodigoLiquidacion.Text))
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar peaje. " + ex.Message, "Cargar peaje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Agregar peaje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub btnAgregarViatico_Click(sender As Object, e As EventArgs) Handles btnAgregarViatico.Click
        If txtCodigoLiquidacion.Text = Nothing Then
            MessageBox.Show("Debe grabar la Liquidación primero. ", "Agregar viático",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
            Return
        End If

        If txtCantidadViatico.Text = Nothing Then
            MessageBox.Show("Debe ingresar cantidad. ", "Agregar viático",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation)
            Return
        End If

        If txtDescripcionViatico.Text = Nothing Then
            MessageBox.Show("Debe ingresar descripción. ", "Agregar viático",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation)
            Return
        End If

        If txtTotalViatico.Text = Nothing Then
            MessageBox.Show("Debe ingresar total de viático. ", "Agregar viático",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation)
            Return
        End If

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            liquidacionDAO.InsertLiquidacionViatico(CInt(txtCodigoLiquidacion.Text), CInt(txtCantidadViatico.Text), dtpTurnoViaticos.Value, txtDescripcionViatico.Text, Double.Parse(txtTotalViatico.Text))

            sqlControl.commitTransaction()
            cargarLiquidacion()
            cargarViaticos(CInt(txtCodigoLiquidacion.Text))
            txtCantidadViatico.Text = ""
            txtDescripcionViatico.Text = ""
            txtTotalGasto.Text = ""
            dtpTurnoViaticos.Value = Date.Now
            txtCantidadViatico.Focus()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al agregar peaje. " + ex.Message, "Agregar peaje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Agregar peaje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub btnEliminarViatico_Click(sender As Object, e As EventArgs) Handles btnEliminarViatico.Click
        If dgvViaticos.Rows.Count <= 0 Then
            Return
        End If

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()
        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)
        Try
            Dim seleccion As DataGridViewRow = dgvViaticos.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(1).Value

            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            liquidacionDAO.deleteLiquidacionViaticoById(CInt(txtCodigoLiquidacion.Text), codigo)

            sqlControl.commitTransaction()
            cargarLiquidacion()
            cargarViaticos(CInt(txtCodigoLiquidacion.Text))
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar peaje. " + ex.Message, "Cargar peaje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Agregar peaje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub btnAgregarOtros_Click(sender As Object, e As EventArgs) Handles btnAgregarOtros.Click
        If txtCodigoLiquidacion.Text = Nothing Then
            MessageBox.Show("Debe grabar la Liquidación primero. ", "Agregar otros",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
            Return
        End If

        If txtDescripcionOtros.Text = Nothing Then
            MessageBox.Show("Debe ingresar descripción. ", "Agregar otros",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation)
            Return
        End If

        If txtTotalOtros.Text = Nothing Then
            MessageBox.Show("Debe ingresar total. ", "Agregar otros",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation)
            Return
        End If

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            liquidacionDAO.InsertLiquidacionOtro(CInt(txtCodigoLiquidacion.Text), txtDescripcionOtros.Text, Double.Parse(txtTotalOtros.Text))

            sqlControl.commitTransaction()
            cargarLiquidacion()
            cargarOtros(CInt(txtCodigoLiquidacion.Text))
            txtDescripcionOtros.Text = ""
            txtTotalOtros.Text = ""
            txtDescripcionOtros.Focus()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al agregar peaje. " + ex.Message, "Agregar peaje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Agregar peaje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Sub cargarOtros(codigo As Integer)
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()
        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            Dim dt As DataTable
            dt = liquidacionDAO.GetLiquidacionOtroByIdLiquidacion(codigo)

            dgvOtros.DataSource = dt

            dgvOtros.Columns(0).Visible = False
            dgvOtros.Columns(1).Visible = False

            sqlControl.commitTransaction()

        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar otros. " + ex.Message, "Cargar Otros",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar Otros",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub btnEliminarOtros_Click(sender As Object, e As EventArgs) Handles btnEliminarOtros.Click
        If dgvOtros.Rows.Count <= 0 Then
            Return
        End If

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)
        Try

            Dim seleccion As DataGridViewRow = dgvOtros.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(1).Value

            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            liquidacionDAO.deleteLiquidacionOtroById(CInt(txtCodigoLiquidacion.Text), codigo)

            sqlControl.commitTransaction()
            cargarLiquidacion()
            cargarOtros(CInt(txtCodigoLiquidacion.Text))
            txtDescripcionOtros.Text = ""
            txtTotalOtros.Text = ""

        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al eliminar otro. " + ex.Message, "Eliminar otro",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Eliminar otro",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub btnRptLiquidacionDetallado_Click(sender As Object, e As EventArgs) Handles btnRptLiquidacionDetallado.Click
        If txtCodigoLiquidacion.Text = Nothing Then
            MessageBox.Show("La liquidación debe estar registrada.", "Imprimir Detalle de Liquidación",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation)
            Return
        End If
        Dim rptFormLiquidacionViaje As New RptFormLiquidacionViaje()
        rptFormLiquidacionViaje.setCodigo(CInt(txtCodigoLiquidacion.Text))
        rptFormLiquidacionViaje.Show()
    End Sub

    Private Sub btnRptLiquidacion_Click(sender As Object, e As EventArgs) Handles btnRptLiquidacion.Click
        If txtCodigoLiquidacion.Text = Nothing Then
            MessageBox.Show("La liquidación debe estar registrada.", "Imprimir Vista General de Liquidación",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation)
            Return
        End If

        Dim rptFormLiquidacionGeneral As New RptFormLiquidacionGeneral()
        rptFormLiquidacionGeneral.setCodigo(CInt(txtCodigoLiquidacion.Text))
        rptFormLiquidacionGeneral.Show()
    End Sub

    Private Sub btnRptLiquidacionCombustible_Click(sender As Object, e As EventArgs) Handles btnRptLiquidacionCombustible.Click
        If txtCodigoLiquidacion.Text = Nothing Then
            MessageBox.Show("La liquidación debe estar registrada.", "Imprimir Vista General de Liquidación",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation)
            Return
        End If

        Dim rptFormLiquidacionCombustible As New RptFormLiquidacionCombustible()
        rptFormLiquidacionCombustible.setCodigo(CInt(txtCodigoLiquidacion.Text))
        rptFormLiquidacionCombustible.Show()
    End Sub
End Class