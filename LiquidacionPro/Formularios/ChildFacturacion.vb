Public Class ChildFacturacion
    Dim gvDetalle As New DataGridView

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub actualizarDatosCliente()

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim clienteDao As New ClienteDAO(sqlControl)
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
        '    cbRazonSocial.SelectedValue = -1
    End Sub

    Private Sub actualizarDatosTracto()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim unidadDao As New UnidadDAO(sqlControl)
        sqlControl.openConexion()

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
        sqlControl.closeConexion()
    End Sub

    Private Sub actualizarDatosGuia()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim guiaDao As New GuiaDAO(sqlControl)
        sqlControl.openConexion()

        Dim dtGuia As DataTable

        dtGuia = guiaDao.getGuiaPendFacturacion

        With cbGuia
            .DataSource = dtGuia
            .DisplayMember = "DETALLE_GUIA"
            .ValueMember = "CODIGO_GUIA"
            .DropDownStyle = ComboBoxStyle.Simple
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedIndex = -1
        End With

        sqlControl.closeConexion()

    End Sub

    Private Sub ChildFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtRUC.ReadOnly = True
        txtDireccion.ReadOnly = True
        txtTelefono.ReadOnly = True
        actualizarDatosCliente()
        actualizarDatosGuia()
        actualizarDatosTracto()

    End Sub

    Private Sub cbRazonSocial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRazonSocial.SelectedIndexChanged


        'MsgBox(cbRazonSocial.SelectedValue.ToString)

        If cbRazonSocial.SelectedIndex <> -1 Then

            'MsgBox(cbRazonSocial.SelectedIndex.ToString)

        End If
        'MsgBox(cbRazonSocial.SelectedIndex.ToString)

        'If cbRazonSocial.Text.Equals("") Then

        'Else
        '    'Dim clienteDao As New ClienteDAO
        '    'Dim dtClente As DataTable

        '    'dtClente = clienteDao.GetClienteByCodigo(cbRazonSocial.SelectedValue.ToString)

        '    'txtRUC.Text = dtClente.Rows.Item(0)(1).ToString.ToUpper
        '    'txtDireccion.Text = dtClente.Rows.Item(0)(3).ToString.ToUpper
        '    'txtTelefono.Text = dtClente.Rows.Item(0)(4).ToString
        'End If


    End Sub

    Private Sub cbRazonSocial_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbRazonSocial.SelectionChangeCommitted
    End Sub

    Private Sub cbRazonSocial_Leave(sender As Object, e As EventArgs) Handles cbRazonSocial.Leave
        'cbRazonSocial.
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim clienteDao As New ClienteDAO(sqlControl)
        Dim dtClente As DataTable

        dtClente = clienteDao.GetClienteByCodigo(cbRazonSocial.SelectedValue.ToString)

        txtRUC.Text = dtClente.Rows.Item(0)(1).ToString.ToUpper
        txtDireccion.Text = dtClente.Rows.Item(0)(3).ToString.ToUpper
        txtTelefono.Text = dtClente.Rows.Item(0)(4).ToString
    End Sub

    Private Sub cbGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles cbGuia.KeyDown
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim data As New DataTable
        Dim row As DataRow
        data.Columns.Add("Codigo")
        data.Columns.Add("Numero_de_Guia")

        If Not tbTransportista.DataSource Is Nothing Then
            data = tbTransportista.DataSource
        End If

        row = data.NewRow()
        row("Codigo") = cbGuia.SelectedValue
        row("Numero_de_Guia") = cbGuia.Text

        data.Rows.Add(row)
        tbTransportista.DataSource = data

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        lbRemitente.Items.Add(txtRemitente.Text)
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        lbRemitente.Items.RemoveAt(lbRemitente.SelectedIndex)
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        lbPlaca.Items.Add(cbTracto.Text)
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        lbPlaca.Items.RemoveAt(lbPlaca.SelectedIndex)
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Dim data As DataTable
        Dim row As DataRow
        data.Columns.Add("tipo_servicio")
        data.Columns.Add("descripcion")
        data.Columns.Add("cantidad")
        data.Columns.Add("conf_veh")
        data.Columns.Add("val_ref")
        data.Columns.Add("obs")
        data.Columns.Add("pre_uni")
        data.Columns.Add("origen")
        data.Columns.Add("destino")

        If Not tbTransportista.DataSource Is Nothing Then
            data = tbTransportista.DataSource
        End If

        row = data.NewRow()
        row("tipo_servicio") = cbTipoServicio.SelectedValue
        row("Numero_de_Guia") = cbGuia.Text

        data.Rows.Add(row)
        gvDetalle.DataSource = data



    End Sub
End Class