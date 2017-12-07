Public Class ChildFacturacion
    Dim gvDetalle As New DataGridView
    Dim data As DataTable
    Dim correlativoFactura As String
    Dim codigo_Factura As Integer = -1
    Dim codigo_Detalle As Integer = -1

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
                MsgBox("No se pudo establecer la conexion con el servidor.")
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
                MsgBox("No se pudo establecer la conexion con el servidor.")
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
                MsgBox("No se pudo establecer la conexion con el servidor.")
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
                MsgBox("No se pudo establecer la conexion con el servidor.")
            End Try
        End Try

    End Sub

    Private Sub ChildFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtRUC.ReadOnly = True
        txtDireccion.ReadOnly = True
        txtTelefono.ReadOnly = True
        txtPrecioFactura.Text = "0.00"
        actualizarDatosCliente()
        actualizarDatosGuia()
        actualizarDatosTracto()
        actualizarDatosMoneda()
        BloquearDetalle()



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRazonSocial.Click

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
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MsgBox("No se pudo establecer la conexion con el servidor.")
            End Try
        End Try

    End Sub

    Private Sub cbGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles cbGuia.KeyDown
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles btnAgregarTransportista.Click
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            facturacionDao.setDBcmd()

            facturacionDao.InsertFacturaDetalleGuia(codigo_Detalle, codigo_Factura, cbGuia.SelectedValue)

            sqlControl.commitTransaction()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MsgBox("No se pudo establecer la conexion con el servidor.")
            End Try
        End Try

        cargarGuiasTransportistas()


    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles btnAgregarRemitente.Click
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            facturacionDao.setDBcmd()

            facturacionDao.InsertFacturaDetalleRemitente(codigo_Detalle, codigo_Factura, txtRemitente.Text)

            sqlControl.commitTransaction()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MsgBox("No se pudo establecer la conexion con el servidor.")
            End Try
        End Try

        cargarGuiasRemitente()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles btnEliminarRemitente.Click

    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles btnAgregarPlaca.Click
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            facturacionDao.setDBcmd()

            facturacionDao.InsertFacturaDetalleUnidad(codigo_Detalle, codigo_Factura, cbTracto.Text)

            sqlControl.commitTransaction()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MsgBox("No se pudo establecer la conexion con el servidor.")
            End Try
        End Try

        cargarPlacasDetalle()
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles btnEliminarPlaca.Click

    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            facturacionDao.setDBcmd()

            facturacionDao.UpdateFacturaDetalle(codigo_Detalle,
                                                codigo_Factura,
                                                cbTipoServicio.SelectedValue,
                                                txtDescripcionDetalle.Text,
                                                CType(txtCantidad.Text, Integer),
                                                txtConfVehicular.Text,
                                                txtValorReferencial.Text,
                                                txtObservaciones.Text,
                                                CType(txtPrecioUnitario.Text, Long),
                                                txtOrigen.Text,
                                                txtDestino.Text
                                                )

            sqlControl.commitTransaction()

        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MsgBox("No se pudo establecer la conexion con el servidor.")
            End Try
        End Try

        cargarDetalleFactura()
        BloquearDetalle()
        BloquearBotones()


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)
        'Dim sqlControl As New SQLControl
        'sqlControl.setConnection()

        'Dim facturacionDao As New FacturacionDAO(sqlControl)
        'sqlControl.openConexion()

        'Try
        '    facturacionDao.beginTransaction()

        '    facturacionDao.setDBcmd()
        '    'Inicio - Ingreso de la Cabecera de la Factura
        '    Dim od_factura As Integer = facturacionDao.InsertFactura(txtNroSerie.Text,
        '                                 lbNroFactura.Text,
        '                                 cbRazonSocial.SelectedValue,
        '                                 txtPrecioFactura.Text,
        '                                 cbMoneda.SelectedValue,
        '                                 16,
        '                                 dtFecha.Value)
        '    'Fin - Ingreso de la Cabecera de la Factura


        '    'Inicio - Ingreso del Detalle de la Factura
        '    For x As Integer = 0 To data.Rows.Count - 1
        '        Dim cod_detalle As Integer = facturacionDao.InsertFacturaDetalle(cod_factura,
        '                                        data.Rows.Item(x)("tipo_servicio"),
        '                                        data.Rows.Item(x)("descripcion"),
        '                                        CType(data.Rows.Item(x)("cantidad"), Integer),
        '                                        data.Rows.Item(x)("conf_veh"),
        '                                        CType(data.Rows.Item(x)("val_ref"), Long),
        '                                        data.Rows.Item(x)("obs"),
        '                                        CType(data.Rows.Item(x)("pre_uni"), Long),
        '                                        data.Rows.Item(x)("origen"),
        '                                        data.Rows.Item(x)("destino"))

        '        'Inicio - Ingreso de las Guias Transportistas
        '        Dim dataTransp As DataTable = CType(data.Rows.Item(x)("lista_Transportista"), DataTable)

        '        For y As Integer = 0 To dataTransp.Rows.Count - 1
        '            facturacionDao.InsertFacturaDetalleGuia(cod_detalle,
        '                                                    cod_factura,
        '                                                    CType(dataTransp.Rows.Item(y)("Codigo"), Integer))
        '        Next
        '        'Fin - Ingreso de las Guias Transportistas

        '        'Inicio - Ingreso de las Guias Remitentes

        '        Dim dataRemitente As DataTable = CType(data.Rows.Item(x)("lista_Remision"), DataTable)

        '        For y As Integer = 0 To dataTransp.Rows.Count - 1
        '            facturacionDao.InsertFacturaDetalleRemitente(cod_detalle,
        '                                                    cod_factura,
        '                                                    dataRemitente.Rows.Item(y)("Numero_de_Guia"))
        '        Next
        '        'Fin - Ingreso de las Guias Remitentes

        '        'Inicio - Ingreso de las Unidades

        '        Dim dataPlaca As DataTable = CType(data.Rows.Item(x)("lista_Placa"), DataTable)

        '        For y As Integer = 0 To dataTransp.Rows.Count - 1
        '            facturacionDao.InsertFacturaDetalleUnidad(cod_detalle,
        '                                                    cod_factura,
        '                                                    dataRemitente.Rows.Item(y)("Placa"))
        '        Next
        '        'Fin - Ingreso de las Unidades
        '    Next

        '    'Fin - Ingreso del Detalle de la Factura
        '    Dim correlativoDao As New Correlativo_NumeroDAO(sqlControl)

        '    correlativoDao.updateCorrelativoNumero(1, txtNroSerie.Text, lbNroFactura.Text)
        '    facturacionDao.commitTransacction()


        'Catch ex As Exception
        '    facturacionDao.rollbackTransaccion()
        '    MsgBox(ex.Message)
        'Finally
        '    Try
        '        sqlControl.closeConexion()
        '    Catch ex As Exception
        '        MsgBox("No se pudo establecer la conexion con el servidor.")
        '    End Try
        'End Try


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
        codigo_Detalle = cbAccionGuia.SelectedValue
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)
        MsgBox(data.Rows(0)(6).ToString)
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles btnEliminarTransportista.Click

        MsgBox(tbTransportista.SelectedRows(0).Cells(0).ToString)
        'Dim sqlControl As New SQLControl
        'sqlControl.setConnection()

        'Dim facturacionDao As New FacturacionDAO(sqlControl)
        'Try
        '    sqlControl.openConexion()
        '    sqlControl.beginTransaction()
        '    facturacionDao.setDBcmd()

        '    facturacionDao.deleteFacturaDetalleGuia(codigo_Detalle, codigo_Factura, tbTransportista.SelectedRows(0).Cells(0))

        '    sqlControl.commitTransaction()
        'Catch ex As Exception
        '    sqlControl.rollbackTransaccion()
        'Finally
        '    Try
        '        sqlControl.closeConexion()
        '    Catch ex As Exception
        '        MsgBox("No se pudo establecer la conexion con el servidor.")
        '    End Try
        'End Try

        'cargarGuiasTransportistas()
    End Sub

    Private Sub txtNroSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroSerie.KeyDown
        If e.KeyCode = Keys.Enter And Not txtNroSerie.Text.Equals("") Then
            ObtenerCorrelativo()
            GuardarCabeceraFactura()
            cargarDetalleFactura()
            BloquearBotones()

        End If
    End Sub

    Private Sub txtNroSerie_Leave(sender As Object, e As EventArgs) Handles txtNroSerie.Leave
        If Not txtNroSerie.Text.Equals("") Then
            ObtenerCorrelativo()
            GuardarCabeceraFactura()
            cargarDetalleFactura()
            BloquearBotones()
        End If

    End Sub

    Private Sub GuardarCabeceraFactura()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Dim correlativoDao As New Correlativo_NumeroDAO(sqlControl)

        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            correlativoDao.setDBcmd()

            correlativoDao.updateCorrelativoNumero(1, txtNroSerie.Text, correlativoFactura)


            'Inicio - Ingreso de la Cabecera de la Factura
            codigo_Factura = facturacionDao.InsertFactura(txtNroSerie.Text,
                                         lbNroFactura.Text,
                                         cbRazonSocial.SelectedValue,
                                         CType(txtPrecioFactura.Text, Long),
                                         cbMoneda.SelectedValue,
                                         16,
                                         dtFecha.Value)
            'Fin - Ingreso de la Cabecera de la Factura

            sqlControl.commitTransaction()

            txtNroSerie.Enabled = False
            cbRazonSocial.Enabled = False
            cbMoneda.Enabled = False
            dtFecha.Enabled = False
            btnRazonSocial.Enabled = False
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MsgBox(ex.Message)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MsgBox("No se pudo establecer la conexion con el servidor.")
            End Try
        End Try
    End Sub

    Private Sub cargarDetalleFactura()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)

        Try

            sqlControl.openConexion()
            sqlControl.beginTransaction()
            facturacionDao.setDBcmd()

            Dim dataDetalle As DataTable = facturacionDao.getDetalleFacturaByCodigoFactura(codigo_Factura)
            sqlControl.commitTransaction()

            With cbAccionGuia
                .DataSource = dataDetalle
                .DisplayMember = "ITEM"
                .ValueMember = "CODIGO_DETALLE_FACTURA"
            End With

        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MsgBox("No se pudo establecer la conexion con el servidor.")
            End Try
        End Try
    End Sub

    Private Sub guardarDetalleFactura()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)

        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            facturacionDao.setDBcmd()

            codigo_Detalle = facturacionDao.InsertFacturaDetalle(codigo_Factura,
                                                                 0,
                                                                 "",
                                                                 0,
                                                                 "",
                                                                 0.00,
                                                                 "",
                                                                 0.00,
                                                                 "",
                                                                 "")

            sqlControl.commitTransaction()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MsgBox("No se pudo establecer la conexion con el servidor.")
            End Try
        End Try

    End Sub

    Private Sub ObtenerCorrelativo()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim correlativoDao As New Correlativo_NumeroDAO(sqlControl)

        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            correlativoDao.setDBcmd()

            correlativoFactura = correlativoDao.GetSiguienteCorrelativo(1, txtNroSerie.Text)
            lbNroFactura.Text = correlativoFactura
            sqlControl.commitTransaction()


        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MsgBox("No se pudo establecer la conexion con el servidor.")
            End Try
        End Try

    End Sub

    Private Sub Button11_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click
        guardarDetalleFactura()
        cargarDetalleFactura()
        BloquearDetalle()
        BloquearBotones()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            facturacionDao.setDBcmd()

            facturacionDao.deleteFacturaDetalle(codigo_Detalle, codigo_Factura)

            facturacionDao.commitTransacction()

        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MsgBox("No se pudo establecer la conexion con el servidor.")
            End Try
        End Try

        cargarDetalleFactura()
        BloquearDetalle()
        BloquearBotones()

    End Sub

    Private Sub BloquearBotones()
        If cbAccionGuia.Items.Count = 0 Then
            btnActualizar.Enabled = False
            btnEliminar.Enabled = False
            btnNuevo.Enabled = True
        Else
            btnActualizar.Enabled = True
            btnEliminar.Enabled = True
        End If
    End Sub

    Private Sub BloquearDetalle()
        If codigo_Factura = -1 Then
            cbTipoServicio.Enabled = False
            txtDescripcionDetalle.Enabled = False
            cbGuia.Enabled = False
            txtRemitente.Enabled = False
            cbTracto.Enabled = False
            txtCantidad.Enabled = False
            txtPrecioUnitario.Enabled = False
            txtValorReferencial.Enabled = False
            txtObservaciones.Enabled = False
            txtOrigen.Enabled = False
            txtConfVehicular.Enabled = False
            txtDestino.Enabled = False
            tbTransportista.Enabled = False
            tbRemitente.Enabled = False
            tbPlaca.Enabled = False
            btnAgregarTransportista.Enabled = False
            btnEliminarTransportista.Enabled = False
            btnAgregarRemitente.Enabled = False
            btnEliminarRemitente.Enabled = False
            btnAgregarPlaca.Enabled = False
            btnEliminarPlaca.Enabled = False
            btnNuevo.Enabled = False
            btnImprimir.Enabled = False
            btnActualizar.Enabled = False
            btnEliminar.Enabled = False

        Else
            cbTipoServicio.Enabled = True
            txtDescripcionDetalle.Enabled = True
            cbGuia.Enabled = True
            txtRemitente.Enabled = True
            cbTracto.Enabled = True
            txtCantidad.Enabled = True
            txtPrecioUnitario.Enabled = True
            txtValorReferencial.Enabled = True
            txtObservaciones.Enabled = True
            txtOrigen.Enabled = True
            txtConfVehicular.Enabled = True
            txtDestino.Enabled = True
            tbTransportista.Enabled = True
            tbRemitente.Enabled = True
            tbPlaca.Enabled = True
            btnAgregarTransportista.Enabled = True
            btnEliminarTransportista.Enabled = True
            btnAgregarRemitente.Enabled = True
            btnEliminarRemitente.Enabled = True
            btnAgregarPlaca.Enabled = True
            btnEliminarPlaca.Enabled = True
            btnNuevo.Enabled = True

        End If
    End Sub

    Private Sub cargarGuiasTransportistas()
        If codigo_Detalle <> -1 Then
            Dim sqlControl As New SQLControl
            sqlControl.setConnection()


            Dim facturacionDao As New FacturacionDAO(sqlControl)
            Try
                sqlControl.openConexion()
                sqlControl.beginTransaction()
                facturacionDao.setDBcmd()

                Dim dataGuias As New DataTable

                dataGuias = facturacionDao.getGuiasByDetalle(codigo_Detalle)

                tbTransportista.DataSource = dataGuias

                sqlControl.commitTransaction()

            Catch ex As Exception
                sqlControl.rollbackTransaccion()
            Finally
                Try
                    sqlControl.closeConexion()
                Catch ex As Exception
                    MsgBox("No se pudo establecer la conexion con el servidor.")
                End Try
            End Try
        End If

    End Sub

    Private Sub cargarGuiasRemitente()
        If codigo_Detalle <> -1 Then
            Dim sqlControl As New SQLControl
            sqlControl.setConnection()

            Dim facturacionDao As New FacturacionDAO(sqlControl)
            Try
                sqlControl.openConexion()
                sqlControl.beginTransaction()
                facturacionDao.setDBcmd()

                Dim dataGuias As New DataTable

                dataGuias = facturacionDao.getRemitentesByDetalle(codigo_Detalle)

                tbRemitente.DataSource = dataGuias

                sqlControl.commitTransaction()

            Catch ex As Exception
                sqlControl.rollbackTransaccion()
            Finally
                Try
                    sqlControl.closeConexion()
                Catch ex As Exception
                    MsgBox("No se pudo establecer la conexion con el servidor.")
                End Try
            End Try
        End If


    End Sub

    Private Sub cargarPlacasDetalle()
        If codigo_Detalle <> -1 Then
            Dim sqlControl As New SQLControl
            sqlControl.setConnection()

            Dim facturacionDao As New FacturacionDAO(sqlControl)
            Try
                sqlControl.openConexion()
                sqlControl.beginTransaction()
                facturacionDao.setDBcmd()

                Dim dataPlacas As New DataTable

                dataPlacas = facturacionDao.getPlacaByDetalle(codigo_Detalle)

                tbRemitente.DataSource = dataPlacas

                sqlControl.commitTransaction()

            Catch ex As Exception
                sqlControl.rollbackTransaccion()
            Finally
                Try
                    sqlControl.closeConexion()
                Catch ex As Exception
                    MsgBox("No se pudo establecer la conexion con el servidor.")
                End Try
            End Try
        End If

    End Sub

End Class