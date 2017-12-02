Public Class ChildFacturacion
    Dim gvDetalle As New DataGridView
    Dim data As DataTable

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

        data = New DataTable()

        Dim colum As DataColumn
        data.Columns.Add("tipo_servicio")
        data.Columns.Add("descripcion")
        data.Columns.Add("cantidad")
        data.Columns.Add("conf_veh")
        data.Columns.Add("val_ref")
        data.Columns.Add("obs")
        data.Columns.Add("pre_uni")
        data.Columns.Add("origen")
        data.Columns.Add("destino")
        data.Columns.Add("lista_Transportista")
        data.Columns.Add("lista_Remision")
        data.Columns.Add("lista_Placa")


        'colum = New DataColumn()
        'colum.ColumnName = "tipo_servicio"
        'data.Columns.Add(colum)

        'colum = New DataColumn()
        'colum.ColumnName = "descripcion"
        'data.Columns.Add(colum)

        'colum = New DataColumn()
        'colum.ColumnName = "cantidad"
        'data.Columns.Add(colum)

        'colum = New DataColumn()
        'colum.ColumnName = "conf_veh"
        'data.Columns.Add(colum)

        'colum = New DataColumn()
        'colum.ColumnName = "val_ref"
        'data.Columns.Add(colum)

        'colum = New DataColumn()
        'colum.ColumnName = "obs"
        'data.Columns.Add(colum)

        'colum = New DataColumn()
        'colum.ColumnName = "pre_uni"
        'data.Columns.Add(colum)

        'colum = New DataColumn()
        'colum.ColumnName = "origen"
        'data.Columns.Add(colum)
        'colum = New DataColumn()
        'colum.ColumnName = "destino"
        'data.Columns.Add(colum)


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

        Dim row As DataRow

        row = data.NewRow()
        row("tipo_servicio") = cbTipoServicio.SelectedIndex
        row("descripcion") = txtDescripcionDetalle.Text
        row("cantidad") = txtCantidad.Text
        row("conf_veh") = txtConfVehicular.Text
        row("val_ref") = txtValorReferencial.Text
        row("obs") = txtObservaciones.Text
        row("pre_uni") = txtPrecioUnitario.Text
        row("origen") = txtOrigen.Text
        row("destino") = txtDestino.Text
        row("lista_Transportista") = tbTransportista.DataSource
        row("lista_Remision") = lbRemitente.DataSource
        row("lista_Placa") = lbPlaca.DataSource

        data.Rows.Add(row)
        gvDetalle.DataSource = data
        MsgBox(CStr(data.Rows.Count))



        txtPrecioFactura.Text = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtPrecioUnitario.Text)

        cbAccionGuia.Items.Add("ITEM " + data.Rows.Count.ToString)


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()
        Dim facturacionDao As New FacturacionDAO(sqlControl)

        Try
            sqlControl.beginTransaction()
            'facturacionDao.InsertFactura("0001", "00154", cbRazonSocial.SelectedValue,)


        Catch ex As Exception

        End Try

    End Sub

    Private Sub Panel15_Paint(sender As Object, e As PaintEventArgs) Handles Panel15.Paint

    End Sub

    Private Sub Panel16_Paint(sender As Object, e As PaintEventArgs) Handles Panel16.Paint

    End Sub

    Private Sub Panel14_Paint(sender As Object, e As PaintEventArgs) Handles Panel14.Paint

    End Sub

    Private Sub LimpiarCampos()


        cbTipoServicio.SelectedIndex = -1
        txtDescripcionDetalle.Text = ""
        txtCantidad.Text = ""
        txtConfVehicular.Text = ""
        txtValorReferencial.Text = ""
        txtObservaciones.Text = ""
        txtPrecioUnitario.Text = ""
        txtOrigen.Text = ""
        txtDestino.Text = ""

    End Sub

    Private Sub cbAccionGuia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAccionGuia.SelectedIndexChanged
        If (cbAccionGuia.SelectedIndex <> 0) Then
            Dim row As DataRow = data.Rows(cbAccionGuia.SelectedIndex - 1)
            LimpiarCampos()
            Button6.Text = "ACTUALIZAR"
            MsgBox(row.Item("tipo_servicio").ToString)
            cbTipoServicio.SelectedIndex = row.Item("tipo_servicio")
            txtDescripcionDetalle.Text = row.Item("descripcion")
            txtCantidad.Text = row.Item("cantidad")
            txtConfVehicular.Text = row.Item("conf_veh")
            txtValorReferencial.Text = row.Item("val_ref")
            txtObservaciones.Text = row.Item("obs")
            txtPrecioUnitario.Text = row.Item("pre_uni")
            txtOrigen.Text = row.Item("origen")
            txtDestino.Text = row.Item("destino")
            tbTransportista.DataSource = row.Item("lista_Transportista")
            lbRemitente.DataSource = row.Item("lista_Remision")
            lbPlaca.DataSource = row.Item("lista_Placa")

            'TextBox18.Text = IDT(P, 1)
            'If (CNTG(P, 0) <> 0) Then
            '    For I As Integer = 0 To CNTG(P, 0) - 1
            '        ListBox1.Items.Add(IGT(P, I))
            '    Next
            '    TextBox12.Text = ListBox1.Items.Count.ToString
            'End If
            'If (CNTG(P, 1) <> 0) Then
            '    For I As Integer = 0 To CNTG(P, 1) - 1
            '        ListBox2.Items.Add(IGR(P, I))
            '    Next
            '    TextBox13.Text = ListBox2.Items.Count.ToString
            'End If
            'If (CNTG(P, 2) <> 0) Then
            '    For I As Integer = 0 To CNTG(P, 2) - 1
            '        ListBox3.Items.Add(IP(P, I))
            '    Next
            'End If
            'If (IDS(P, 1) <> "NULL") Then
            '    ComboBox3.SelectedIndex = Integer.Parse(IDS(P, 0))
            'Else
            '    ComboBox3.SelectedIndex = -1
            'End If
            'If (IDS(P, 2) <> "NULL") Then
            '    TextBox11.Text = IDS(P, 2)
            'End If
            'If (IDS(P, 3) <> "NULL") Then
            '    TextBox19.Text = IDS(P, 3)
            'End If
            'If (IDS(P, 4) <> "NULL") Then
            '    TextBox20.Text = IDS(P, 4)
            'End If
            'If (IDS(P, 5) <> "NULL") Then
            '    TextBox15.Text = IDS(P, 5)
            'End If
            'If (IDS(P, 6) <> "NULL") Then
            '    TextBox16.Text = IDS(P, 6)
            'End If
            'If (IDS(P, 7) <> "NULL") Then
            '    TextBox17.Text = IDS(P, 7)
            'End If
        Else
            Button6.Text = "AGREGAR"
            LimpiarCampos()
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)
        MsgBox(data.Rows(0)(6).ToString)
    End Sub
End Class