Public Class ChildFacturacion
    Dim gvDetalle As New DataGridView
    Dim data As DataTable
    Dim correlativoFactura As String
    Dim codigo_Factura As Integer = -1
    Dim codigo_Detalle As Integer = -1
    Dim cargandoDatosActualizar As Integer = -1

    Public Sub setCodifoFactura(codigoFactura As Integer)
        codigo_Factura = codigoFactura
    End Sub

    Private Sub leerCodigoFactura()
        If codigo_Factura <> -1 Then

        End If
    End Sub

    Private Sub cargarDatosFactura()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Dim dtCabeceraFactura As DataTable
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            facturacionDao.setDBcmd()

            dtCabeceraFactura = facturacionDao.getFacturaById(codigo_Factura)
            sqlControl.commitTransaction()
            cbRazonSocial.SelectedValue = dtCabeceraFactura.Rows(0).Item(3).ToString
            txtPrecioFactura.Text = dtCabeceraFactura.Rows(0).Item(4).ToString
            cbMoneda.SelectedValue = dtCabeceraFactura.Rows(0).Item(5)
            dtFecha.Value = CType(dtCabeceraFactura.Rows(0).Item(6), Date)
            txtNroSerie.Text = dtCabeceraFactura.Rows(0).Item(1).ToString
            lbNroFactura.Text = dtCabeceraFactura.Rows(0).Item(2).ToString

            sqlControl.commitTransaction()
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
                obtenerDatosCliente()
                cargarDetalleFactura()
                BloquearBotones()
            Catch ex As Exception

            End Try
        End Try
    End Sub

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

            With cbRazonSocial
                .DataSource = dtCliente
                .DisplayMember = "RAZON_CLIENTE"
                .ValueMember = "CODIGO_CLIENTE"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1

            End With
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

            With cbMoneda
                .DataSource = dtMoneda
                .DisplayMember = "DETALLE_MONEDA"
                .ValueMember = "CODIGO_MONEDA"
                .SelectedIndex = -1
            End With
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
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MsgBox("No se pudo establecer la conexion con el servidor.")
            End Try
        End Try

    End Sub

    Private Sub ChildFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        leerCodigoFactura()
        txtRUC.ReadOnly = True
        txtDireccion.ReadOnly = True
        txtTelefono.ReadOnly = True
        txtPrecioFactura.Text = "0.00"
        actualizarDatosCliente()
        cargarTiposDeServicio()
        actualizarDatosMoneda()
        If codigo_Factura <> -1 Then
            cargarDatosFactura()
            cargandoDatosActualizar = 0

        Else
            txtNroSerie.Text = "001"
            ObtenerCorrelativo()

        End If

        actualizarDatosGuia()
        actualizarDatosTracto()
        BloquearDetalle()



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRazonSocial.Click

        obtenerDatosCliente()


    End Sub

    Private Sub obtenerDatosCliente()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()


        Dim clienteDao As New ClienteDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            clienteDao.setDBcmd()

            Dim dtClente As DataTable

            dtClente = clienteDao.GetClienteByCodigo(cbRazonSocial.SelectedValue.ToString)

            txtRUC.Text = dtClente.Rows.Item(0)(1).ToString.ToUpper
            txtDireccion.Text = dtClente.Rows.Item(0)(3).ToString.ToUpper
            txtTelefono.Text = dtClente.Rows.Item(0)(4).ToString

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


    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles btnAgregarTransportista.Click
        If CType(cbGuia.SelectedValue, Integer) <> -1 And cbGuia.Text <> "" Then
            Dim sqlControl As New SQLControl
            sqlControl.setConnection()

            Dim facturacionDao As New FacturacionDAO(sqlControl)
            Try
                sqlControl.openConexion()
                sqlControl.beginTransaction()
                facturacionDao.setDBcmd()

                facturacionDao.InsertFacturaDetalleGuia(codigo_Detalle, codigo_Factura, CType(cbGuia.SelectedValue, Integer))

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

        End If

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
                                                CType(cbTipoServicio.SelectedValue, Integer),
                                                txtDescripcionDetalle.Text,
                                                CType(txtCantidad.Text, Integer),
                                                txtConfVehicular.Text,
                                                CType(txtValorReferencial.Text, Long),
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
        cargarDatosFactura()


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

    End Sub

    Private Sub cbAccionGuia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAccionGuia.SelectedIndexChanged
        If cargandoDatosActualizar <> -1 Then
            codigo_Detalle = CType(cbAccionGuia.SelectedValue, Integer)
            cargarDatosDetalleFactura()
            cargarGuiasRemitente()
            cargarGuiasTransportistas()
            cargarPlacasDetalle()
        End If

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)
        MsgBox(data.Rows(0)(6).ToString)
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
                                         CType(cbRazonSocial.SelectedValue, Integer),
                                         CType(txtPrecioFactura.Text, Long),
                                         CType(cbMoneda.SelectedValue, Integer),
                                         16,
                                         dtFecha.Value,
                                         34)
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

            With cbAccionGuia
                .DataSource = dataDetalle
                .DisplayMember = "ITEM"
                .ValueMember = "CODIGO_DETALLE_FACTURA"
                .SelectedIndex = -1
            End With
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
                                                                 CType(0.00, Long),
                                                                 "",
                                                                 CType(0.00, Long),
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
        cargarDatosFactura()
        LimpiarCampos()
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
        cargarDatosFactura()


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

    Private Sub cargarTiposDeServicio()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim tipoServicioDao As New TipoServicioDAO(sqlControl)
        Dim dataTipoServicio As DataTable
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            tipoServicioDao.setDBcmd()

            dataTipoServicio = tipoServicioDao.getTiposDeServicio()

            With cbTipoServicio
                .DataSource = dataTipoServicio
                .ValueMember = "CODIGO_ESTADO"
                .DisplayMember = "DETALLE_ESTADO"
                .SelectedIndex = -1
            End With
        Catch ex As Exception

        Finally

        End Try

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

                tbPlaca.DataSource = dataPlacas

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

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim rpt As New RptPrintFactura
        rpt.setNroFactura(codigo_Factura)
        rpt.Show()
    End Sub

    Private Sub cargarDatosDetalleFactura()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Dim datDetalle As DataTable
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            facturacionDao.setDBcmd()

            datDetalle = facturacionDao.getDetalleFacturaByIdDetalle(codigo_Detalle)

            cbTipoServicio.SelectedValue = datDetalle.Rows(0).Item(0)
            txtDescripcionDetalle.Text = datDetalle.Rows(0).Item(1).ToString
            txtCantidad.Text = datDetalle.Rows(0).Item(2).ToString
            txtConfVehicular.Text = datDetalle.Rows(0).Item(3).ToString
            txtValorReferencial.Text = datDetalle.Rows(0).Item(4).ToString
            txtPrecioUnitario.Text = datDetalle.Rows(0).Item(5).ToString
            txtOrigen.Text = datDetalle.Rows(0).Item(6).ToString
            txtDestino.Text = datDetalle.Rows(0).Item(7).ToString
            txtObservaciones.Text = datDetalle.Rows(0).Item(8).ToString

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardarCabecera_Click(sender As Object, e As EventArgs) Handles btnGuardarCabecera.Click
        GuardarCabeceraFactura()
        cargarDetalleFactura()
        BloquearBotones()
    End Sub
End Class