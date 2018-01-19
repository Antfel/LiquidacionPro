Public Class ChildLiquidacionCombustible

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
            sqlControl.commitTransaction()

            With cbUnidadMedida
                .DataSource = dt
                .DisplayMember = "DETALLE_ESTADO"
                .ValueMember = "CODIGO_ESTADO"
                .SelectedIndex = 0
            End With
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception

            End Try
        End Try
    End Sub

    Private Sub btnAgregarLiquidacion_Click(sender As Object, e As EventArgs) Handles btnAgregarLiquidacion.Click

        'If cbTrabajador.SelectedIndex < 0 Then
        '    MessageBox.Show("Seleccionar un Trabajador.", "Agregar liquidación",
        '                        MessageBoxButtons.OK,
        '                        MessageBoxIcon.Exclamation)
        '    Return
        'End If

        'If txtNroLiquidacion.Text = Nothing Then
        '    MessageBox.Show("Ingresar nro. de liquidación.", "Agregar liquidación",
        '                        MessageBoxButtons.OK,
        '                        MessageBoxIcon.Exclamation)
        '    Return
        'End If

        'If cbTracto.SelectedIndex < 0 Then
        '    MessageBox.Show("Seleccionar un tracto.", "Agregar liquidación",
        '                        MessageBoxButtons.OK,
        '                        MessageBoxIcon.Exclamation)
        '    Return
        'End If

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

        Dim tanque As Double, salida As Double, llegada As Double, recorrido As Double, llegaLima As Double, virtual As Double,
            ajuste As Double, cargaDetalle As String, rutaDetalle As String, pesoDetalle As String

        If txtTanque.Text = Nothing Then
            tanque = 0
        Else
            tanque = Double.Parse(txtTanque.Text)
        End If

        If txtKmSalida.Text = Nothing Then
            salida = 0
        Else
            salida = Double.Parse(txtKmSalida.Text)
        End If

        If txtKmLlegada.Text = Nothing Then
            llegada = 0
        Else
            llegada = Double.Parse(txtKmLlegada.Text)
        End If

        If txtKmRecorrido.Text = Nothing Then
            recorrido = 0
        Else
            recorrido = Double.Parse(txtKmRecorrido.Text)
        End If

        If txtLlegadaLima.Text = Nothing Then
            llegaLima = 0
        Else
            llegaLima = Double.Parse(txtLlegadaLima.Text)
        End If

        If txtCombustibleVirtual.Text = Nothing Then
            virtual = 0
        Else
            virtual = Double.Parse(txtCombustibleVirtual.Text)
        End If

        If txtAjusteGalon.Text = Nothing Then
            ajuste = 0
        Else
            ajuste = Double.Parse(txtAjusteGalon.Text)
        End If

        If txtRutaDetalle.Text = Nothing Then
            rutaDetalle = ""
        Else
            rutaDetalle = txtRutaDetalle.Text
        End If

        If txtCargaDetalle.Text = Nothing Then
            cargaDetalle = ""
        Else
            cargaDetalle = txtCargaDetalle.Text
        End If

        If txtPesoDetalle.Text = Nothing Then
            pesoDetalle = ""
        Else
            pesoDetalle = txtPesoDetalle.Text
        End If

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim liquidacionDao As New LiquidacionDAO(sqlControl)

        If txtCodigoLiquidacion.Text = Nothing Then
            MessageBox.Show("Seleccione una liquidación para agregar gastos de combustible. ", "Agregar Liquidaciones",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
            'Try
            '    sqlControl.openConexion()
            '    sqlControl.beginTransaction()
            '    liquidacionDao.setDBcmd()
            '    Dim correla As Integer

            '    cbEstado.SelectedValue = 1



            '    correla = liquidacionDao.InsertLiquidacion(txtNroLiquidacion.Text, cbTrabajador.SelectedValue,
            '                                               cbGuia.SelectedValue,
            '                                 cbTracto.SelectedValue, cbCamabaja.SelectedValue, origen,
            '                                 destino, dtpSalida.Value, dtpLlegada.Value,
            '                                 dinero, peaje, viatico,
            '                                 guardiania, hospedaje, balanza,
            '                                 otros, fisico,
            '                                 virtual, cbEstado.SelectedValue, carga, peso, cbUnidadMedida.SelectedValue)
            '    If correla >= 0 Then
            '        txtCodigoLiquidacion.Text = CStr(correla)
            '        MessageBox.Show("Liquidación grabada correctamente", "Agregar Liquidaciones",
            '                     MessageBoxButtons.OK,
            '                     MessageBoxIcon.Information)
            '    End If
            '    sqlControl.commitTransaction()
            'Catch excep As Exception
            '    sqlControl.rollbackTransaccion()

            '    MessageBox.Show("Error al grabar Liquidación. " + excep.Message, "Agregar Liquidaciones",
            '                     MessageBoxButtons.OK,
            '                     MessageBoxIcon.Error)
            'Finally
            '    Try
            '        sqlControl.closeConexion()
            '    Catch ex As Exception

            '    End Try
            'End Try
        Else
            Try
                sqlControl.openConexion()
                sqlControl.beginTransaction()
                liquidacionDao.setDBcmd()

                Dim correla As Integer

                correla = liquidacionDao.UpdateLiquidacionCombustible(CInt(txtCodigoLiquidacion.Text), tanque, salida, llegada,
                                                                      recorrido, llegaLima, virtual,
                                                                      rutaDetalle, cargaDetalle, ajuste, pesoDetalle)


                If correla >= 0 Then
                    MessageBox.Show("Liquidación de Combustible actualizada correctamente", "Agregar Liquidaciones",
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

        cargarLiquidacion()
        If txtCodigoLiquidacion.Text IsNot Nothing Then
            cargarCombustible(CInt(txtCodigoLiquidacion.Text))
        End If

        actualizarListaLiquidacion()

    End Sub

    Private Sub dgvLiquidacion_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvLiquidacion.CellMouseClick
        cargarLiquidacion()
        If txtCodigoLiquidacion.Text IsNot Nothing Then
            cargarCombustible(CInt(txtCodigoLiquidacion.Text))
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
            actualizarDatosGuiaRegistrada(CInt(dt.Rows(0)(4)))
            cbGuia.SelectedValue = dt.Rows(0)(4)
            cbTracto.SelectedValue = dt.Rows(0)(6)
            txtOrigen.Text = dt.Rows(0)(10)
            dtpLlegada.Value = dt.Rows(0)(13)
            cbCamabaja.SelectedValue = dt.Rows(0)(8)
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
            txtTotalGastoGalones.Text = dt.Rows(0)(28)

            txtTanque.Text = dt.Rows(0)(29)
            txtKmSalida.Text = dt.Rows(0)(30)
            txtKmLlegada.Text = dt.Rows(0)(31)
            txtKmRecorrido.Text = dt.Rows(0)(32)
            txtLlegadaLima.Text = dt.Rows(0)(33)

            txtCarga.Text = dt.Rows(0)(34)
            txtPeso.Text = dt.Rows(0)(35)
            If dt.Rows(0)(36) <> -1 Then
                cbUnidadMedida.SelectedValue = dt.Rows(0)(36)
            Else
                cbUnidadMedida.SelectedIndex = 0
            End If


            txtRutaDetalle.Text = dt.Rows(0)(37)
            txtCargaDetalle.Text = dt.Rows(0)(38)
            txtAjusteGalon.Text = dt.Rows(0)(39)
            txtTotalGalones.Text = dt.Rows(0)(40)

            txtPesoDetalle.Text = dt.Rows(0)(41)

            sqlControl.commitTransaction()

        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception

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
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception

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

            sqlControl.commitTransaction()

            With cbTrabajador
                .DataSource = dtTrabajador
                .DisplayMember = "NOMBRE_TRABAJADOR"
                .ValueMember = "CODIGO_TRABAJADOR"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception

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
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception

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
            sqlControl.commitTransaction()

            With cbTracto
                .DataSource = dtUnidad
                .DisplayMember = "PLACA_UNIDAD"
                .ValueMember = "CODIGO_UNIDAD"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception

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

            sqlControl.commitTransaction()

            With cbCamabaja
                .DataSource = dtUnidad
                .DisplayMember = "PLACA_UNIDAD"
                .ValueMember = "CODIGO_UNIDAD"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception

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
            sqlControl.commitTransaction()

            With cbEstado
                .DataSource = dtEstado
                .DisplayMember = "DETALLE_ESTADO"
                .ValueMember = "CODIGO_ESTADO"
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedValue = 1
            End With
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception

            End Try
        End Try

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs)
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

        cargarCombustible(-1)

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

    Sub cargarCombustible(codigo As Integer)
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()
        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            Dim dt As DataTable
            dt = liquidacionDAO.GetLiquidacionCombustibleByIdLiquidacion(codigo)

            dgvCombustible.DataSource = dt

            dgvCombustible.Columns(0).Visible = False
            dgvCombustible.Columns(1).Visible = False

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

    Private Sub btnAgregarCombustible_Click(sender As Object, e As EventArgs) Handles btnAgregarCombustible.Click
        If txtCodigoLiquidacion.Text = Nothing Then
            MessageBox.Show("Debe grabar la Liquidación primero. ", "Agregar combustible",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
            Return
        End If

        If txtLugarCombustible.Text = Nothing Then
            MessageBox.Show("Debe ingresar el lugar. ", "Agregar combustible",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation)
            Return
        End If

        If txtGalonesCombustible.Text = Nothing Then
            MessageBox.Show("Debe ingresar galones. ", "Agregar combustible",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation)
            Return
        End If

        If txtPrecioGalon.Text = Nothing Then
            MessageBox.Show("Debe ingresar el precio de galón. ", "Agregar combustible",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation)
            Return
        End If

        If txtGastoCombustible.Text = Nothing Then
            MessageBox.Show("Debe ingresar los galones y precio. ", "Agregar combustible",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation)
            Return
        End If

        Dim gastoCombustible As Double, km As Double

        If txtGastoCombustible.Text = Nothing Then
            gastoCombustible = 0
        Else
            gastoCombustible = Double.Parse(txtGastoCombustible.Text)
        End If

        If txtKm.Text = Nothing Then
            km = 0
        Else
            km = Double.Parse(txtKm.Text)
        End If

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            liquidacionDAO.InsertLiquidacionCombustible(CInt(txtCodigoLiquidacion.Text), dtpFechaCombustible.Value,
                                                        txtLugarCombustible.Text, Double.Parse(txtGalonesCombustible.Text),
                                                        Double.Parse(txtPrecioGalon.Text), gastoCombustible, km)

            sqlControl.commitTransaction()
            cargarLiquidacion()
            cargarCombustible(CInt(txtCodigoLiquidacion.Text))
            txtLugarCombustible.Text = ""
            txtGalonesCombustible.Text = ""
            txtPrecioGalon.Text = ""
            txtGastoCombustible.Text = ""
            dtpFechaCombustible.Value = Date.Now
            txtKm.Text = ""
            txtLugarCombustible.Focus()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al agregar combustible. " + ex.Message, "Agregar combustible",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Agregar combustible",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub btnEliminarCombustible_Click(sender As Object, e As EventArgs) Handles btnEliminarCombustible.Click
        If dgvCombustible.Rows.Count <= 0 Then
            Return
        End If

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)
        Try

            Dim seleccion As DataGridViewRow = dgvCombustible.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(1).Value

            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            liquidacionDAO.deleteLiquidacionCombustibleById(CInt(txtCodigoLiquidacion.Text), codigo)

            sqlControl.commitTransaction()
            cargarLiquidacion()
            cargarCombustible(CInt(txtCodigoLiquidacion.Text))
            txtLugarCombustible.Text = ""
            txtGalonesCombustible.Text = ""
            txtPrecioGalon.Text = ""
            txtGastoCombustible.Text = ""
            dtpFechaCombustible.Value = Date.Now

        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al eliminar combustible. " + ex.Message, "Eliminar combustible",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Eliminar combustible",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub txtGalonesCombustible_Leave(sender As Object, e As EventArgs) Handles txtGalonesCombustible.Leave
        If txtPrecioGalon.Text <> Nothing Then
            If txtGalonesCombustible.Text <> Nothing Then
                Dim galones As Double, precioGalon As Double, gastoCombustible As Double
                precioGalon = Double.Parse(txtPrecioGalon.Text)
                galones = Double.Parse(txtGalonesCombustible.Text)
                gastoCombustible = precioGalon * galones
                txtGastoCombustible.Text = CStr(gastoCombustible.ToString)
            End If
        End If

    End Sub

    Private Sub txtPrecioGalon_Leave(sender As Object, e As EventArgs) Handles txtPrecioGalon.Leave
        If txtPrecioGalon.Text <> Nothing Then
            If txtGalonesCombustible.Text <> Nothing Then
                Dim galones As Double, precioGalon As Double, gastoCombustible As Double
                precioGalon = Double.Parse(txtPrecioGalon.Text)
                galones = Double.Parse(txtGalonesCombustible.Text)
                gastoCombustible = precioGalon * galones
                txtGastoCombustible.Text = CStr(gastoCombustible.ToString)
            End If
        End If
    End Sub

    Private Sub txtKmSalida_Leave(sender As Object, e As EventArgs) Handles txtKmSalida.Leave
        If txtKmSalida.Text <> Nothing Then
            If txtKmLlegada.Text <> Nothing Then
                Dim salida As Double, llegada As Double, recorrido As Double
                salida = Double.Parse(txtKmSalida.Text)
                llegada = Double.Parse(txtKmLlegada.Text)
                recorrido = llegada - salida
                txtKmRecorrido.Text = CStr(recorrido.ToString)
            End If
        End If
    End Sub

    Private Sub txtKmLlegada_Leave(sender As Object, e As EventArgs) Handles txtKmLlegada.Leave
        If txtKmSalida.Text <> Nothing Then
            If txtKmLlegada.Text <> Nothing Then
                Dim salida As Double, llegada As Double, recorrido As Double
                salida = Double.Parse(txtKmSalida.Text)
                llegada = Double.Parse(txtKmLlegada.Text)
                recorrido = llegada - salida
                txtKmRecorrido.Text = CStr(recorrido.ToString)
            End If
        End If
    End Sub

    Private Sub btnRptLiquidacionCombustible_Click(sender As Object, e As EventArgs) Handles btnRptLiquidacionCombustible.Click
        If txtCodigoLiquidacion.Text = Nothing Then
            MessageBox.Show("La liquidación debe estar registrada.", "Imprimir Vista General de Liquidación",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation)
            Return
        End If

        Dim rptFormLiquidacionCombustiblePrincipal As New RptFormLiquidacionCombustiblePrincipal()
        rptFormLiquidacionCombustiblePrincipal.setCodigo(CInt(txtCodigoLiquidacion.Text))
        rptFormLiquidacionCombustiblePrincipal.Show()
    End Sub
End Class