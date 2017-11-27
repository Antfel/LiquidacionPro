Public Class frmLiquidacion
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'rptLiquidaciones.DataTable1' Puede moverla o quitarla según sea necesario.

        actualizarListaLiquidacion()
        actualizarDatosTrabajador()
        actualizarDatosGuia()
        actualizarDatosTracto()
        actualizarDatosSemiTrailer()
        actualizarEstados()

        Me.ReportViewer1.RefreshReport
    End Sub

    Private Sub btnAgregarLiquidacion_Click(sender As Object, e As EventArgs) Handles btnAgregarLiquidacion.Click

        Dim proceso As String
        proceso = ""

        Dim liquidacionDao As New LiquidacionDAO


        If txtCodigoLiquidacion.Text = Nothing Then
            liquidacionDao.InsertLiquidacion(txtNroLiquidacion.Text, cbTrabajador.SelectedValue, cbGuia.SelectedValue,
                                         cbTracto.SelectedValue, cbCamabaja.SelectedValue, txtOrigen.Text,
                                         txtDestino.Text, dtpSalida.Value, dtpLlegada.Value,
                                         CLng(txtDinero.Text), CLng(txtPeajes.Text), CLng(txtViaticos.Text),
                                         CLng(txtGuardiania.Text), CLng(txtHospedaje.Text), CLng(txtBalanza.Text),
                                         CLng(txtOtros.Text), CLng(txtCombustibleFisico.Text), CLng(txtCombustibleVirtual.Text),
                                         cbEstado.SelectedValue)
        Else
            liquidacionDao.UpdateLiquidacion(txtCodigoLiquidacion.Text, txtNroLiquidacion.Text, cbTrabajador.SelectedValue, cbGuia.SelectedValue,
                                         cbTracto.SelectedValue, cbCamabaja.SelectedValue, txtOrigen.Text,
                                         txtDestino.Text, dtpSalida.Value, dtpLlegada.Value,
                                         CLng(txtDinero.Text), CLng(txtPeajes.Text), CLng(txtViaticos.Text),
                                         CLng(txtGuardiania.Text), CLng(txtHospedaje.Text), CLng(txtBalanza.Text),
                                         CLng(txtOtros.Text), CLng(txtCombustibleFisico.Text), CLng(txtCombustibleVirtual.Text),
                                         cbEstado.SelectedValue)
        End If



        If liquidacionDao.SQL.HasException(True) Then Exit Sub

        actualizarListaLiquidacion()

        MsgBox("Liquidación " + proceso + " correctamente")

    End Sub

    Private Sub dgvLiquidacion_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvLiquidacion.CellMouseClick
        Dim liquidacionDao As New LiquidacionDAO

        Dim seleccion As DataGridViewRow = dgvLiquidacion.SelectedRows(0)
        Dim codigo As Integer = seleccion.Cells(0).Value

        Dim dt As DataTable

        dt = liquidacionDao.GetLiquidacionById(codigo)

        txtCodigoLiquidacion.Text = dt.Rows(0)(0)
        txtNroLiquidacion.Text = dt.Rows(0)(1)
        cbTrabajador.SelectedValue = dt.Rows(0)(2)
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

    End Sub

    Private Sub txtCodigoLiquidacion_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoLiquidacion.TextChanged

    End Sub

    Private Sub actualizarListaLiquidacion()
        Dim liquidacionDao As New LiquidacionDAO

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
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
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
            .SelectedIndex = -1
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
            .SelectedIndex = -1
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
            .SelectedIndex = -1
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
            .SelectedIndex = -1
        End With

        With cbEstadoRpt
            .DataSource = dtEstado
            .DisplayMember = "DETALLE_DESTADO"
            .ValueMember = "CODIGO_ESTADO"
        End With
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
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
        txtDinero.Text = ""
        txtGuardiania.Text = ""
        txtHospedaje.Text = ""
        txtPeajes.Text = ""
        txtViaticos.Text = ""
        txtBalanza.Text = ""
        txtOtros.Text = ""
        txtCombustibleFisico.Text = ""
        txtCombustibleVirtual.Text = ""
        cbEstado.SelectedIndex = -1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim estado As Integer
        estado = cbEstadoRpt.SelectedValue
        MsgBox(estado)

        Me.DataTable1TableAdapter.Fill(Me.rptLiquidaciones.DataTable1, estado)

        Me.ReportViewer1.RefreshReport()



    End Sub
End Class