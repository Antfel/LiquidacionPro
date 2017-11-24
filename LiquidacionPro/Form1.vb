Public Class frmLiquidacion
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim liquidacionDao As New LiquidacionDAO

        Dim dt As DataTable

        dt = liquidacionDao.GetAllLiquidacion()
        dgvLiquidacion.DataSource = dt

        actualizarDatosTrabajador()
        actualizarDatosGuia()
        actualizarDatosTracto()
        actualizarDatosSemiTrailer()
        actualizarEstados()

    End Sub

    Private Sub btnAgregarLiquidacion_Click(sender As Object, e As EventArgs) Handles btnAgregarLiquidacion.Click
        Dim liquidacionDao As New LiquidacionDAO
        liquidacionDao.SQL.AddParam("@NUMERO_LIQUIDACION", txtNroLiquidacion.Text)
        liquidacionDao.SQL.AddParam("@CODIGO_TRABAJADOR", cbTrabajador.ValueMember)
        liquidacionDao.SQL.AddParam("@CODIGO_GUIA", cbGuia.ValueMember)
        liquidacionDao.SQL.AddParam("@CODIGO_UNIDAD_TRACTO", cbTracto.ValueMember)
        liquidacionDao.SQL.AddParam("@CODIGO_UNIDAD_SEMITRAILER", cbCamabaja.ValueMember)
        liquidacionDao.SQL.AddParam("@ORIGEN_LIQUIDACION", txtOrigen.Text)
        liquidacionDao.SQL.AddParam("@DESTINO_LIQUIDACION", txtDestino.Text)
        liquidacionDao.SQL.AddParam("@FECHA_SALIDA", dtpSalida.Value)
        liquidacionDao.SQL.AddParam("@FECHA_LLEGADA", dtpLlegada.Value)
        liquidacionDao.SQL.AddParam("@DINERO_LIQUIDACION", txtDinero.Text)
        liquidacionDao.SQL.AddParam("@PEAJES_LIQUIDACION", txtPeajes.Text)
        liquidacionDao.SQL.AddParam("@VIATICOS_LIQUIDACION", txtViaticos.Text)
        liquidacionDao.SQL.AddParam("@GUARDIANIA_LIQUIDACION", txtGuardiania.Text)
        liquidacionDao.SQL.AddParam("@HOSPEDAJE_LIQUIDACION", txtHospedaje.Text)
        liquidacionDao.SQL.AddParam("@BALANZA_LIQUIDACION", txtBalanza.Text)
        liquidacionDao.SQL.AddParam("@OTROS_LIQUIDACION", txtOtros.Text)
        liquidacionDao.SQL.AddParam("@CONSUMO_FISICO_LIQUIDACION", txtCombustibleFisico.Text)
        liquidacionDao.SQL.AddParam("@CONSUMO_VIRTUAL_LIQUIDACION", txtCombustibleVirtual.Text)
        liquidacionDao.SQL.AddParam("@CODIGO_ESTADO", cbEstado.SelectedItem)

        liquidacionDao.SQL.ExecQuery("EXECUTE insertLiquidacion 
                                        @NUMERO_LIQUIDACION,
                                        @CODIGO_TRABAJADOR,
                                        @CODIGO_GUIA,
                                        @CODIGO_UNIDAD_TRACTO,
                                        @CODIGO_UNIDAD_SEMITRAILER,
                                        @ORIGEN_LIQUIDACION,
                                        @DESTINO_LIQUIDACION,
                                        @FECHA_SALIDA,
                                        @FECHA_LLEGADA,
                                        @DINERO_LIQUIDACION,
                                        @PEAJES_LIQUIDACION,
                                        @VIATICOS_LIQUIDACION,
                                        @GUARDIANIA_LIQUIDACION,
                                        @HOSPEDAJE_LIQUIDACION,
                                        @BALANZA_LIQUIDACION,
                                        @OTROS_LIQUIDACION,
                                        @CONSUMO_FISICO_LIQUIDACION,
                                        @CONSUMO_VIRTUAL_LIQUIDACION,
                                        @CODIGO_ESTADO")
        If liquidacionDao.SQL.HasException(True) Then Exit Sub
        MsgBox("Liquidación ingresada correctamente")
    End Sub

    Private Sub dgvLiquidacion_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvLiquidacion.CellMouseClick
        Dim liquidacionDao As New LiquidacionDAO

        Dim seleccion As DataGridViewRow = dgvLiquidacion.SelectedRows(0)
        Dim codigo As Integer = seleccion.Cells(0).Value

        Dim dt As DataTable

        dt = liquidacionDao.GetLiquidacionById(codigo)

        txtCodigoLiquidacion.Text = dt.Rows(0)(0)
        txtCodigoLiquidacion.Text = dt.Rows(0)(0)
        txtCodigoLiquidacion.Text = dt.Rows(0)(0)
        txtCodigoLiquidacion.Text = dt.Rows(0)(0)
        txtCodigoLiquidacion.Text = dt.Rows(0)(0)
        txtCodigoLiquidacion.Text = dt.Rows(0)(0)
        txtCodigoLiquidacion.Text = dt.Rows(0)(0)
        txtCodigoLiquidacion.Text = dt.Rows(0)(0)
        txtCodigoLiquidacion.Text = dt.Rows(0)(0)
        txtCodigoLiquidacion.Text = dt.Rows(0)(0)
        txtCodigoLiquidacion.Text = dt.Rows(0)(0)
        txtCodigoLiquidacion.Text = dt.Rows(0)(0)


    End Sub

    Private Sub txtCodigoLiquidacion_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoLiquidacion.TextChanged

    End Sub

    Private Sub actualizarDatosTrabajador()
        Dim trabajadorDao As New TrabajadorDAO
        Dim dtTrabajador As DataTable

        dtTrabajador = trabajadorDao.GetTrabajador

        With cbTrabajador
            .DataSource = dtTrabajador
            .DisplayMember = "NOMBRE_TRABAJADOR"
            .ValueMember = "CODIGO_TRABAJADOR"
            .DropDownStyle = ComboBoxStyle.Simple
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

    End Sub

    Private Sub actualizarDatosGuia()
        Dim guiaDao As New GuiaDAO
        Dim dtGuia As DataTable

        dtGuia = guiaDao.getGuia

        With cbGuia
            .DataSource = dtGuia
            .DisplayMember = "DETALLE_GUIA"
            .ValueMember = "CODIGO_GUIA"
            .DropDownStyle = ComboBoxStyle.Simple
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

    End Sub

    Private Sub actualizarDatosTracto()
        Dim unidadDao As New UnidadDAO
        Dim dtUnidad As DataTable

        dtUnidad = unidadDao.getUnidadTractos

        With cbTracto
            .DataSource = dtUnidad
            .DisplayMember = "PLACA_UNIDAD"
            .ValueMember = "CODIGO_UNIDAD"
            .DropDownStyle = ComboBoxStyle.Simple
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

    End Sub

    Private Sub actualizarDatosSemiTrailer()
        Dim unidadDao As New UnidadDAO
        Dim dtUnidad As DataTable

        dtUnidad = unidadDao.getUnidadSemiTrailer

        With cbCamabaja
            .DataSource = dtUnidad
            .DisplayMember = "PLACA_UNIDAD"
            .ValueMember = "CODIGO_UNIDAD"
            .DropDownStyle = ComboBoxStyle.Simple
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

    End Sub

    Private Sub actualizarEstados()
        Dim estadoDao As New EstadoDAO
        Dim dtEstado As DataTable

        dtEstado = estadoDao.getEstados

        With cbEstado
            .DataSource = dtEstado
            .DisplayMember = "DETALLE_DESTADO"
            .ValueMember = "CODIGO_ESTADO"
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

    End Sub

End Class
