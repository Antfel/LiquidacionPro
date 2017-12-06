Public Class ChildFacturacion
    Dim gvDetalle As New DataGridView
    Dim data As DataTable
    Dim correlativo As String

    Private Sub actualizarDatosCliente()

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim clienteDao As New ClienteDAO(sqlControl)

        Try
            sqlControl.openConexion()

            sqlControl.beginTransaction()

            clienteDao.setDBcmd()

            Dim dtCliente As DataTable

            dtCliente = clienteDao.GetClientes

            sqlControl.commitTransaction()


            With cbRazonSocial
                .DataSource = dtCliente
                .DisplayMember = "RAZON_CLIENTE"
                .ValueMember = "CODIGO_CLIENTE"
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

    Private Sub actualizarDatosTracto()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim unidadDao As New UnidadDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            unidadDao.setDBcmd()

            Dim dtUnidad As DataTable

            dtUnidad = unidadDao.getUnidadTractos
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

    Private Sub actualizarDatosMoneda()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim monedaDao As New MonedaDAO(sqlControl)

        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            monedaDao.setDBcmd()

            Dim dtMoneda As DataTable

            dtMoneda = monedaDao.GetMonedas

            sqlControl.commitTransaction()

            With cbMoneda
                .DataSource = dtMoneda
                .DisplayMember = "DETALLE_MONEDA"
                .ValueMember = "CODIGO_MONEDA"
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

            dtGuia = guiaDao.getGuiaPendFacturacion
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

    Private Sub ChildFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtRUC.ReadOnly = True
        txtDireccion.ReadOnly = True
        txtTelefono.ReadOnly = True
        actualizarDatosCliente()
        actualizarDatosGuia()
        actualizarDatosTracto()
        actualizarDatosMoneda()

        data = New DataTable()


        data.Columns.Add("tipo_servicio")
        data.Columns.Add("descripcion")
        data.Columns.Add("cantidad")
        data.Columns.Add("conf_veh")
        data.Columns.Add("val_ref")
        data.Columns.Add("obs")
        data.Columns.Add("pre_uni")
        data.Columns.Add("origen")
        data.Columns.Add("destino")
        data.Columns.Add("lista_Transportista", GetType(DataTable))
        data.Columns.Add("lista_Remision", GetType(DataTable))
        data.Columns.Add("lista_Placa", GetType(DataTable))

        lbFactura.Text = "Nro. Factura "

        correlativo = ""


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
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            clienteDao.setDBcmd()

            Dim dtClente As DataTable

            dtClente = clienteDao.GetClienteByCodigo(cbRazonSocial.SelectedValue.ToString)

            sqlControl.commitTransaction()
            txtRUC.Text = dtClente.Rows.Item(0)(1).ToString.ToUpper
            txtDireccion.Text = dtClente.Rows.Item(0)(3).ToString.ToUpper
            txtTelefono.Text = dtClente.Rows.Item(0)(4).ToString
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            sqlControl.closeConexion()
        End Try

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
        Dim data As New DataTable
        Dim row As DataRow

        data.Columns.Add("Numero_de_Guia")

        If Not tbRemitente.DataSource Is Nothing Then
            data = tbRemitente.DataSource
        End If

        row = data.NewRow()
        row("Numero_de_Guia") = txtRemitente.Text

        data.Rows.Add(row)
        tbRemitente.DataSource = data
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Dim data As New DataTable
        Dim row As DataRow

        data.Columns.Add("Placa")

        If Not tbPlaca.DataSource Is Nothing Then
            data = tbPlaca.DataSource
        End If

        row = data.NewRow()
        row("Placa") = cbTracto.Text

        data.Rows.Add(row)
        tbPlaca.DataSource = data
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click

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
        Dim dataTempTransportista As DataTable = CType(tbTransportista.DataSource, DataTable)
        row("lista_Transportista") = dataTempTransportista
        Dim dataTemRemitente As DataTable = CType(tbRemitente.DataSource, DataTable)
        row("lista_Remision") = dataTemRemitente
        Dim dataTemPlaca As DataTable = CType(tbPlaca.DataSource, DataTable)
        row("lista_Placa") = dataTemPlaca

        data.Rows.Add(row)

        txtPrecioFactura.Text = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtPrecioUnitario.Text)

        cbAccionGuia.Items.Add("ITEM " + data.Rows.Count.ToString)


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        sqlControl.openConexion()

        Try
            facturacionDao.beginTransaction()

            facturacionDao.setDBcmd()
            'Inicio - Ingreso de la Cabecera de la Factura
            Dim cod_factura As Integer = facturacionDao.InsertFactura(txtNroSerie.Text,
                                         lbNroFactura.Text,
                                         cbRazonSocial.SelectedValue,
                                         txtPrecioFactura.Text,
                                         cbMoneda.SelectedValue,
                                         16,
                                         dtFecha.Value)
            'Fin - Ingreso de la Cabecera de la Factura


            'Inicio - Ingreso del Detalle de la Factura
            For x As Integer = 0 To data.Rows.Count - 1
                Dim cod_detalle As Integer = facturacionDao.InsertFacturaDetalle(cod_factura,
                                                data.Rows.Item(x)("tipo_servicio"),
                                                data.Rows.Item(x)("descripcion"),
                                                CType(data.Rows.Item(x)("cantidad"), Integer),
                                                data.Rows.Item(x)("conf_veh"),
                                                CType(data.Rows.Item(x)("val_ref"), Long),
                                                data.Rows.Item(x)("obs"),
                                                CType(data.Rows.Item(x)("pre_uni"), Long),
                                                data.Rows.Item(x)("origen"),
                                                data.Rows.Item(x)("destino"))

                'Inicio - Ingreso de las Guias Transportistas
                Dim dataTransp As DataTable = CType(data.Rows.Item(x)("lista_Transportista"), DataTable)

                For y As Integer = 0 To dataTransp.Rows.Count - 1
                    facturacionDao.InsertFacturaDetalleGuia(cod_detalle,
                                                            cod_factura,
                                                            CType(dataTransp.Rows.Item(y)("Codigo"), Integer))
                Next
                'Fin - Ingreso de las Guias Transportistas

                'Inicio - Ingreso de las Guias Remitentes

                Dim dataRemitente As DataTable = CType(data.Rows.Item(x)("lista_Remision"), DataTable)

                For y As Integer = 0 To dataTransp.Rows.Count - 1
                    facturacionDao.InsertFacturaDetalleRemitente(cod_detalle,
                                                            cod_factura,
                                                            dataRemitente.Rows.Item(y)("Numero_de_Guia"))
                Next
                'Fin - Ingreso de las Guias Remitentes

                'Inicio - Ingreso de las Unidades

                Dim dataPlaca As DataTable = CType(data.Rows.Item(x)("lista_Placa"), DataTable)

                For y As Integer = 0 To dataTransp.Rows.Count - 1
                    facturacionDao.InsertFacturaDetalleUnidad(cod_detalle,
                                                            cod_factura,
                                                            dataRemitente.Rows.Item(y)("Placa"))
                Next
                'Fin - Ingreso de las Unidades
            Next

            'Fin - Ingreso del Detalle de la Factura
            Dim correlativoDao As New Correlativo_NumeroDAO(sqlControl)

            correlativoDao.updateCorrelativoNumero(1, txtNroSerie.Text, lbNroFactura.Text)
            facturacionDao.commitTransacction()


        Catch ex As Exception
            facturacionDao.rollbackTransaccion()
            MsgBox(ex.Message)
        Finally
            sqlControl.closeConexion()
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
        cbTracto.SelectedIndex = -1
        cbGuia.SelectedIndex = -1
        txtRemitente.Text = ""
        'Try
        '    If tbTransportista.Rows.Count > 0 Then
        '        tbTransportista.Rows.Clear()
        '    End If

        'Catch ex As Exception
        '    Console.WriteLine(ex.Message)
        'End Try

        Dim dt As New DataTable
        dt.Columns.Add("Codigo")
        dt.Columns.Add("Numero_de_Guia")
        tbTransportista.DataSource = dt

        Dim dtGuia As New DataTable
        dtGuia.Columns.Add("Numero_de_Guia")
        tbRemitente.DataSource = dtGuia

        Dim dtPlaca As New DataTable
        dtPlaca.Columns.Add("Placa")
        tbPlaca.DataSource = dtPlaca

    End Sub

    Private Sub cbAccionGuia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAccionGuia.SelectedIndexChanged
        If (cbAccionGuia.SelectedIndex <> 0) Then
            Dim sqlControl As New SQLControl
            sqlControl.setConnection()

            Dim facturacionDao As New FacturacionDAO(sqlControl)

            Try
                sqlControl.openConexion()
                sqlControl.beginTransaction()
                facturacionDao.setDBcmd()

            Catch ex As Exception

            Finally

            End Try

            'Dim row As DataRow = data.Rows(cbAccionGuia.SelectedIndex - 1)
            'LimpiarCampos()
            'Button6.Text = "ACTUALIZAR"
            'cbTipoServicio.SelectedIndex = row.Item("tipo_servicio")
            'txtDescripcionDetalle.Text = row.Item("descripcion")
            'txtCantidad.Text = row.Item("cantidad")
            'txtConfVehicular.Text = row.Item("conf_veh")
            'txtValorReferencial.Text = row.Item("val_ref")
            'txtObservaciones.Text = row.Item("obs")
            'txtPrecioUnitario.Text = row.Item("pre_uni")
            'txtOrigen.Text = row.Item("origen")
            'txtDestino.Text = row.Item("destino")
            'tbTransportista.DataSource = CType(row.Item("lista_Transportista"), DataTable)
            'tbRemitente.DataSource = CType(row.Item("lista_Remision"), DataTable)
            'tbPlaca.DataSource = CType(row.Item("lista_Placa"), DataTable)


            'lbPlaca.DataSource = CType(row.Item("lista_Placa"), ListBox.ObjectCollection)
            'Dim dataTempRemision As ListBox.ObjectCollection
            'dataTempRemision = row.Item("lista_Remision")

            'For x As Integer = 0 To dataTempRemision.Count
            '    lbRemitente.Items.Add(dataTempRemision.Item(x))
            'Next

            'lbPlaca.DataSource = row.Item("lista_Placa")

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
            'Button6.Text = "AGREGAR"
            'LimpiarCampos()
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)
        MsgBox(data.Rows(0)(6).ToString)
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub txtNroSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroSerie.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim sqlControl As New SQLControl
            sqlControl.setConnection()

            Dim correlativoDao As New Correlativo_NumeroDAO(sqlControl)
            Try
                sqlControl.openConexion()
                sqlControl.beginTransaction()
                correlativoDao.setDBcmd()

                correlativo = correlativoDao.GetSiguienteCorrelativo(1, txtNroSerie.Text)

                lbNroFactura.Text = correlativo
            Catch ex As Exception
                sqlControl.rollbackTransaccion()
            Finally
                sqlControl.closeConexion()
            End Try

        End If
    End Sub
End Class