Public Class ChildFacturacion
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
        Dim clienteDao As New ClienteDAO
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

    Private Sub ChildFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtRUC.ReadOnly = True
        txtDireccion.ReadOnly = True
        txtTelefono.ReadOnly = True
        actualizarDatosCliente()
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
        Dim clienteDao As New ClienteDAO
        Dim dtClente As DataTable

        dtClente = clienteDao.GetClienteByCodigo(cbRazonSocial.SelectedValue.ToString)

        txtRUC.Text = dtClente.Rows.Item(0)(1).ToString.ToUpper
        txtDireccion.Text = dtClente.Rows.Item(0)(3).ToString.ToUpper
        txtTelefono.Text = dtClente.Rows.Item(0)(4).ToString
    End Sub
End Class