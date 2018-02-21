Imports System.Data.SqlClient

Public Class ChildFacturacion
    Dim gvDetalle As New DataGridView
    Dim data As DataTable
    Dim correlativoFactura As String
    Dim codigo_Factura As Integer = -1
    Dim codigo_Detalle As Integer = -1
    Dim cargandoDatosActualizar As Integer = -1
    Private childBusquedaFactura As ChildBusquedaFactura

    Public Sub setChildBusquedaFactura(childBusquedaFactura As ChildBusquedaFactura)
        Me.childBusquedaFactura = childBusquedaFactura
    End Sub
    Public Sub setCodifoFactura(codigoFactura As Integer)
        codigo_Factura = codigoFactura
    End Sub

    Private Sub leerCodigoFactura()
        If codigo_Factura <> -1 Then

        End If
    End Sub

    Private Sub cargarDatosFactura()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Dim dtCabeceraFactura As DataTable
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDao.SetDBcmd()

            dtCabeceraFactura = facturacionDao.GetFacturaById(codigo_Factura)
            sqlControl.CommitTransaction()

            txtNroSerie.Text = dtCabeceraFactura.Rows(0).Item(1).ToString
            lbNroFactura.Text = dtCabeceraFactura.Rows(0).Item(2).ToString
            cbRazonSocial.SelectedValue = dtCabeceraFactura.Rows(0).Item(3).ToString
            txtPrecioFactura.Text = dtCabeceraFactura.Rows(0).Item(4)

            txtIgv.Text = Math.Round(Double.Parse(dtCabeceraFactura.Rows(0).Item(4)) * 0.18, 2)
            txtTotalFactura.Text = Math.Round(Double.Parse(txtIgv.Text) + Double.Parse(txtPrecioFactura.Text), 2)

            cbMoneda.SelectedValue = dtCabeceraFactura.Rows(0).Item(5)
            dtFecha.Value = CType(dtCabeceraFactura.Rows(0).Item(6), Date)
            If dtCabeceraFactura.Rows(0).Item(8) IsNot DBNull.Value Then
                dtpRecepcion.Enabled = True
                dtpRecepcion.Value = CType(dtCabeceraFactura.Rows(0).Item(8), Date)
                chbxRecepcion.Checked = True
            End If
            If dtCabeceraFactura.Rows(0).Item(9) IsNot DBNull.Value Then
                dtpVencimiento.Enabled = True
                dtpVencimiento.Value = CType(dtCabeceraFactura.Rows(0).Item(9), Date)
                chbxVencimiento.Checked = True
            End If
            If dtCabeceraFactura.Rows(0).Item(10) IsNot DBNull.Value Then
                dtpPago.Enabled = True
                dtpPago.Value = CType(dtCabeceraFactura.Rows(0).Item(10), Date)
                chbxPago.Checked = True
            End If
            If dtCabeceraFactura.Rows(0).Item(14) IsNot DBNull.Value Then
                cbBancoPago.Enabled = True
                cbBancoPago.SelectedValue = CInt(dtCabeceraFactura.Rows(0).Item(14))
            End If
            If dtCabeceraFactura.Rows(0).Item(11) IsNot DBNull.Value Then
                dtpCompromiso.Enabled = True
                dtpCompromiso.Value = CType(dtCabeceraFactura.Rows(0).Item(11), Date)
                chbxCompromiso.Checked = True
            End If

            txtPorcentajeDetraccion.Text = dtCabeceraFactura.Rows(0).Item(12)
            txtMontoDetraccion.Text = dtCabeceraFactura.Rows(0).Item(13)



        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar datos de factura. " + ex.Message, "Cargar datos factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar datos de factura. " + ex.Message, "Cargar datos factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
                obtenerDatosCliente()
                cargarDetalleFactura()
                BloquearBotones()
                childBusquedaFactura.cargarDatosFactura()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar datos factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub actualizarDatosCliente()

        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim clienteDao As New ClienteDAO(sqlControl)

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()

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

            sqlControl.CommitTransaction()

        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar cliente. " + ex.Message, "Cargar datos de cliente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar datos de cliente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try

        End Try
    End Sub

    Private Sub actualizarDatosTracto()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim unidadDao As New UnidadDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
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
            sqlControl.CommitTransaction()
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar datos del tracto. " + ex.Message, "Cargar datos de tracto",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar datos de tracto",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try

        End Try

    End Sub

    Private Sub actualizarDatosMoneda()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim monedaDao As New MonedaDAO(sqlControl)

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            monedaDao.setDBcmd()

            Dim dtMoneda As DataTable

            dtMoneda = monedaDao.GetMonedas

            With cbMoneda
                .DataSource = dtMoneda
                .DisplayMember = "DETALLE_MONEDA"
                .ValueMember = "CODIGO_MONEDA"
                .SelectedIndex = -1
            End With
            sqlControl.CommitTransaction()
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar datos moneda. " + ex.Message, "Cargar datos moneda",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar datos moneda",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try

        End Try

    End Sub

    Private Sub actualizarDatosGuia()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim guiaDao As New GuiaDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
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
            sqlControl.CommitTransaction()
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar datos de guía. " + ex.Message, "Cargar datos guías",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar datos guías",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
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
        cargarBancos()
        If codigo_Factura <> -1 Then
            cargarDatosFactura()
            cargandoDatosActualizar = 0

        Else
            txtNroSerie.Text = "001"
            ObtenerCorrelativo()
            txtMontoDetraccion.Text = "0.00"
            txtPorcentajeDetraccion.Text = "0.00"

        End If
        cargarDireccionesPrevias()
        actualizarDatosGuia()
        actualizarDatosTracto()
        BloquearDetalle()



    End Sub

    Sub cargarBancos()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()


        Dim bancoDao As New BancoDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            bancoDao.setDBcmd()

            Dim dt As DataTable

            dt = bancoDao.GetAllBanco()
            sqlControl.CommitTransaction()

            With cbBancoPago
                .DataSource = dt
                .DisplayMember = "ABREVIATURA"
                .ValueMember = "CODIGO_BANCO"
                .SelectedIndex = -1
            End With

        Catch ex As SQLException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar datos de Banco. " + ex.Message, "Cargar datos de Banco",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar datos de Banco. " + ex.Message, "Cargar datos de Banco",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar datos de Banco",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRazonSocial.Click
        obtenerDatosCliente()
    End Sub

    Private Sub obtenerDatosCliente()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()


        Dim clienteDao As New ClienteDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            clienteDao.setDBcmd()

            Dim dtClente As DataTable

            dtClente = clienteDao.GetClienteByCodigo(cbRazonSocial.SelectedValue.ToString)

            txtRUC.Text = dtClente.Rows.Item(0)(1).ToString.ToUpper
            txtDireccion.Text = dtClente.Rows.Item(0)(3).ToString.ToUpper
            txtTelefono.Text = dtClente.Rows.Item(0)(4).ToString

            sqlControl.CommitTransaction()
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar datos de cliente. " + ex.Message, "Cargar datos de cliente",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar datos de cliente",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles btnActualizar.Click
        GuardarCabeceraFactura()
        BloquearBotones()

        If cbAccionGuia.SelectedIndex = -1 Then
            MessageBox.Show("Seleccionar un Item.", "Agregar Detalle",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
            Return
        End If

        If txtCantidad.Text = Nothing Then
            MessageBox.Show("Ingresar cantidad.", "Agregar Detalle",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
            Return
        End If

        If txtPrecioUnitario.Text = Nothing Then
            MessageBox.Show("Ingresar precio.", "Agregar Detalle",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
            Return
        End If

        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDao.SetDBcmd()

            Dim descripcionDetalle As String, confVehi As String, valorRef As Double, obs As String, origen As String, destino As String

            If txtDescripcionDetalle.Text = Nothing Then
                descripcionDetalle = ""
            Else
                descripcionDetalle = txtDescripcionDetalle.Text
            End If

            If txtConfVehicular.Text = Nothing Then
                confVehi = ""
            Else
                confVehi = txtConfVehicular.Text
            End If

            If txtValorReferencial.Text = Nothing Then
                valorRef = 0.00
            Else
                valorRef = CType(txtValorReferencial.Text, Double)
            End If

            If txtObservaciones.Text = Nothing Then
                obs = ""
            Else
                obs = txtObservaciones.Text
            End If

            If cbOrigen.Text = Nothing Then
                origen = ""
            Else
                origen = cbOrigen.Text
            End If

            If cbDestino.Text = Nothing Then
                destino = ""
            Else
                destino = cbDestino.Text
            End If

            facturacionDao.UpdateFacturaDetalle(codigo_Detalle,
                                                codigo_Factura,
                                                CType(cbTipoServicio.SelectedValue, Integer),
                                                descripcionDetalle,
                                                CType(txtCantidad.Text, Integer),
                                                confVehi,
                                                valorRef,
                                                obs,
                                                CType(txtPrecioUnitario.Text, Double),
                                                origen,
                                                destino)

            sqlControl.CommitTransaction()
            cargandoDatosActualizar = 0
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al grabar datos del detalle. " + ex.Message, "Actualizar detalle item",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Actualizar detalle item",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try

        'cargarDetalleFactura()
        BloquearDetalle()
        BloquearBotones()
        cargarDatosFactura()
        LimpiarCampos()
        cargarDireccionesPrevias()
    End Sub

    Private Sub LimpiarCampos()


        cbTipoServicio.SelectedIndex = -1
        txtDescripcionDetalle.Text = ""
        txtCantidad.Text = ""
        txtConfVehicular.Text = ""
        txtValorReferencial.Text = ""
        txtObservaciones.Text = ""
        txtPrecioUnitario.Text = ""
        'txtOrigen.Text = ""
        'txtDestino.Text = ""
        cbOrigen.SelectedIndex = -1
        cbDestino.SelectedIndex = -1
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
            cbTracto.SelectedIndex = -1
            cbGuia.SelectedIndex = -1
            txtRemitente.Text = ""
        End If

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)
        MsgBox(data.Rows(0)(6).ToString)
    End Sub

    Private Sub txtNroSerie_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter And Not txtNroSerie.Text.Equals("") Then
            ObtenerCorrelativo()
        End If
    End Sub

    Private Sub txtNroSerie_Leave(sender As Object, e As EventArgs)
        If Not txtNroSerie.Text.Equals("") Then
            ObtenerCorrelativo()
        End If
    End Sub

    Private Sub GuardarCabeceraFactura()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Dim correlativoDao As New Correlativo_NumeroDAO(sqlControl)

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            correlativoDao.setDBcmd()

            Dim porcentaje_detraccion As Double, monto_detraccion As Double, banco As Integer
            If txtPorcentajeDetraccion.Text = Nothing Then
                porcentaje_detraccion = 0
            Else
                porcentaje_detraccion = Double.Parse(txtPorcentajeDetraccion.Text)
            End If

            If txtMontoDetraccion.Text = Nothing Then
                monto_detraccion = 0
            Else
                monto_detraccion = Double.Parse(txtMontoDetraccion.Text)
            End If

            If cbBancoPago.SelectedIndex < 0 Then
                banco = -1
            Else
                banco = cbBancoPago.SelectedValue
            End If

            calcularDetraccion()
            If codigo_Factura < 0 Then
                correlativoDao.updateCorrelativoNumero(1, txtNroSerie.Text, correlativoFactura)


                'Inicio - Ingreso de la Cabecera de la Factura
                codigo_Factura = facturacionDao.InsertFactura(txtNroSerie.Text,
                                         lbNroFactura.Text,
                                         CType(cbRazonSocial.SelectedValue, Integer),
                                         CType(txtPrecioFactura.Text, Long),
                                         CType(cbMoneda.SelectedValue, Integer),
                                         16,
                                         dtFecha.Value,
                                         34, chbxRecepcion.Checked, dtpRecepcion.Value,
                                             chbxVencimiento.Checked, dtpVencimiento.Value,
                                             chbxPago.Checked, dtpPago.Value,
                                             chbxCompromiso.Checked, dtpCompromiso.Value,
                                             porcentaje_detraccion,
                                                              monto_detraccion, banco)
                'Fin - Ingreso de la Cabecera de la Factura
            Else
                facturacionDao.UpdateFactura(codigo_Factura, txtNroSerie.Text,
                                         lbNroFactura.Text,
                                         CType(cbRazonSocial.SelectedValue, Integer),
                                         CType(txtPrecioFactura.Text, Long),
                                         CType(cbMoneda.SelectedValue, Integer),
                                         16,
                                         dtFecha.Value, chbxRecepcion.Checked, dtpRecepcion.Value,
                                             chbxVencimiento.Checked, dtpVencimiento.Value,
                                             chbxPago.Checked, dtpPago.Value,
                                             chbxCompromiso.Checked, dtpCompromiso.Value,
                                             porcentaje_detraccion, monto_detraccion, banco)
            End If

            sqlControl.CommitTransaction()

            txtNroSerie.Enabled = False
            cbRazonSocial.Enabled = False
            cbMoneda.Enabled = False
            dtFecha.Enabled = False
            btnRazonSocial.Enabled = False
            'btnGuardarCabecera.Enabled = False
            childBusquedaFactura.cargarDatosFactura()
        Catch ex As SQLException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al grabar datos de factura. SQL. " + ex.Message, "Grabar datos factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al grabar datos de factura. " + ex.Message, "Grabar datos factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Grabar datos factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub cargarDetalleFactura()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)

        Try

            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDao.SetDBcmd()

            Dim dataDetalle As DataTable = facturacionDao.getDetalleFacturaByCodigoFactura(codigo_Factura)

            With cbAccionGuia
                .DataSource = dataDetalle
                .DisplayMember = "ITEM"
                .ValueMember = "CODIGO_DETALLE_FACTURA"
                .SelectedIndex = -1
            End With
            sqlControl.CommitTransaction()
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar datos de detalle factura. " + ex.Message, "Cargar datos detalle factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cargar datos de detalle factura. " + ex.Message, "Cargar datos detalle factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub guardarDetalleFactura()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDao.SetDBcmd()

            codigo_Detalle = facturacionDao.InsertFacturaDetalle(codigo_Factura,
                                                                 0,
                                                                 "",
                                                                 0,
                                                                 "",
                                                                 CType(0.00, Double),
                                                                 "",
                                                                 CType(0.00, Double),
                                                                 "",
                                                                 "")

            sqlControl.CommitTransaction()
            btnImprimir.Enabled = True
        Catch ex As SQLException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al guardar datos de detalle factura. " + ex.Message, "Guardar datos de detalle factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al guardar datos de detalle factura. " + ex.Message, "Guardar datos de detalle factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cargar datos de detalle factura. " + ex.Message, "Guardar datos detalle factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try

    End Sub

    Private Sub ObtenerCorrelativo()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim correlativoDao As New Correlativo_NumeroDAO(sqlControl)

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            correlativoDao.setDBcmd()

            correlativoFactura = correlativoDao.GetSiguienteCorrelativo(1, txtNroSerie.Text)
            lbNroFactura.Text = correlativoFactura
            sqlControl.CommitTransaction()

        Catch ex As Exception
            sqlControl.RollbackTransaccion()
        Finally
            Try
                sqlControl.CloseConexion()
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
        cbAccionGuia.SelectedIndex = cbAccionGuia.Items.Count - 1
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDao.SetDBcmd()

            facturacionDao.DeleteFacturaDetalle(codigo_Detalle, codigo_Factura)

            facturacionDao.CommitTransacction()

        Catch ex As Exception
            sqlControl.RollbackTransaccion()
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MsgBox("No se pudo establecer la conexion con el servidor.")
            End Try
        End Try

        'cargarDetalleFactura()
        BloquearDetalle()
        BloquearBotones()
        cargarDatosFactura()
        LimpiarCampos()

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
            'txtOrigen.Enabled = False
            cbOrigen.Enabled = False
            txtConfVehicular.Enabled = False
            'txtDestino.Enabled = False
            cbDestino.Enabled = False
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
            'txtOrigen.Enabled = True
            cbOrigen.Enabled = True
            txtConfVehicular.Enabled = True
            'txtDestino.Enabled = True
            cbDestino.Enabled = True
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
            sqlControl.SetConnection()


            Dim facturacionDao As New FacturacionDAO(sqlControl)
            Try
                sqlControl.OpenConexion()
                sqlControl.BeginTransaction()
                facturacionDao.SetDBcmd()

                Dim dataGuias As New DataTable

                dataGuias = facturacionDao.GetGuiasByDetalle(codigo_Detalle)
                sqlControl.CommitTransaction()

                tbTransportista.DataSource = dataGuias
            Catch ex As SqlException
                sqlControl.RollbackTransaccion()
            Catch ex As Exception

            Finally
                Try
                    sqlControl.CloseConexion()
                Catch ex As Exception
                    MsgBox("No se pudo establecer la conexion con el servidor.")
                End Try
            End Try
        End If

    End Sub

    Private Sub cargarGuiasRemitente()
        If codigo_Detalle <> -1 Then
            Dim sqlControl As New SQLControl
            sqlControl.SetConnection()

            Dim facturacionDao As New FacturacionDAO(sqlControl)
            Try
                sqlControl.OpenConexion()
                sqlControl.BeginTransaction()
                facturacionDao.SetDBcmd()

                Dim dataGuias As New DataTable

                dataGuias = facturacionDao.GetRemitentesByDetalle(codigo_Detalle)

                tbRemitente.DataSource = dataGuias

                sqlControl.CommitTransaction()

            Catch ex As Exception
                sqlControl.RollbackTransaccion()
            Finally
                Try
                    sqlControl.CloseConexion()
                Catch ex As Exception
                    MsgBox("No se pudo establecer la conexion con el servidor.")
                End Try
            End Try
        End If


    End Sub

    Private Sub cargarTiposDeServicio()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim tipoServicioDao As New TipoServicioDAO(sqlControl)
        Dim dataTipoServicio As DataTable
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            tipoServicioDao.setDBcmd()

            dataTipoServicio = tipoServicioDao.getTiposDeServicio()

            With cbTipoServicio
                .DataSource = dataTipoServicio
                .ValueMember = "CODIGO_ESTADO"
                .DisplayMember = "DETALLE_ESTADO"
                .SelectedIndex = -1
            End With
            sqlControl.CommitTransaction()
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MsgBox("Cargar Tipo Servicio. " + ex.Message)
            End Try
        End Try

    End Sub

    Private Sub cargarPlacasDetalle()
        If codigo_Detalle <> -1 Then
            Dim sqlControl As New SQLControl
            sqlControl.SetConnection()

            Dim facturacionDao As New FacturacionDAO(sqlControl)
            Try
                sqlControl.OpenConexion()
                sqlControl.BeginTransaction()
                facturacionDao.SetDBcmd()

                Dim dataPlacas As New DataTable

                dataPlacas = facturacionDao.GetPlacaByDetalle(codigo_Detalle)

                tbPlaca.DataSource = dataPlacas

                sqlControl.CommitTransaction()

            Catch ex As Exception
                sqlControl.RollbackTransaccion()
            Finally
                Try
                    sqlControl.CloseConexion()
                Catch ex As Exception
                    MsgBox("No se pudo establecer la conexion con el servidor.")
                End Try
            End Try
        End If

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If cbAccionGuia.Items.Count > 0 Then
            Dim rpt As New RptPrintFactura
            rpt.setNroFactura(codigo_Factura)
            rpt.Show()
        Else
            MessageBox.Show("Se requiere mínimo un detalle para la impresión.", "Imprimir",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub cargarDatosDetalleFactura()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Dim datDetalle As DataTable
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDao.SetDBcmd()

            datDetalle = facturacionDao.GetDetalleFacturaByIdDetalle(codigo_Detalle)

            If datDetalle.Rows.Count > 0 Then
                cbTipoServicio.SelectedValue = datDetalle.Rows(0).Item(0)
                txtDescripcionDetalle.Text = datDetalle.Rows(0).Item(1).ToString
                txtCantidad.Text = datDetalle.Rows(0).Item(2).ToString
                txtConfVehicular.Text = datDetalle.Rows(0).Item(3).ToString
                txtValorReferencial.Text = datDetalle.Rows(0).Item(4).ToString
                txtPrecioUnitario.Text = datDetalle.Rows(0).Item(5).ToString
                'txtOrigen.Text = datDetalle.Rows(0).Item(6).ToString
                'txtDestino.Text = datDetalle.Rows(0).Item(7).ToString
                cbOrigen.Text = datDetalle.Rows(0).Item(6).ToString
                cbDestino.Text = datDetalle.Rows(0).Item(7).ToString
                txtObservaciones.Text = datDetalle.Rows(0).Item(8).ToString
                sqlControl.CommitTransaction()
            End If

        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar datos detalle. " + ex.Message, "Cargar datos detalleee",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar datos detalleeeeee",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub btnGuardarCabecera_Click_1(sender As Object, e As EventArgs) Handles btnGuardarCabecera.Click
        GuardarCabeceraFactura()
        'cargarDetalleFactura()
        BloquearBotones()
    End Sub

    Private Sub btnAgregarTransportista_Click(sender As Object, e As EventArgs) Handles btnAgregarTransportista.Click

        If cbAccionGuia.SelectedIndex = -1 Then
            MessageBox.Show("Seleccionar un Item", "Agregar Transportista",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
            Return
        End If

        If cbGuia.SelectedIndex = -1 Then
            MessageBox.Show("Seleccionar una Guía de Transportista", "Agregar Transportista",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
            Return
        End If

        If CType(cbGuia.SelectedValue, Integer) <> -1 And cbGuia.Text <> "" Then
            Dim sqlControl As New SQLControl
            sqlControl.SetConnection()

            Dim facturacionDao As New FacturacionDAO(sqlControl)
            Try
                sqlControl.OpenConexion()
                sqlControl.BeginTransaction()
                facturacionDao.SetDBcmd()

                facturacionDao.InsertFacturaDetalleGuia(codigo_Detalle, codigo_Factura, CType(cbGuia.SelectedValue, Integer))

                sqlControl.CommitTransaction()
                cbGuia.SelectedIndex = -1
            Catch ex As SQLException
                sqlControl.RollbackTransaccion()
                MessageBox.Show("Error al agregar transportista. " + ex.Message, "Agregar transportista",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error al agregar transportista. " + ex.Message, "Agregar transportista",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            Finally
                Try
                    sqlControl.CloseConexion()
                Catch ex As Exception
                    MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Agregar transportista",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
                End Try
            End Try

            cargarGuiasTransportistas()
            actualizarDatosGuia()
        End If
    End Sub

    Private Sub btnEliminarTransportista_Click(sender As Object, e As EventArgs) Handles btnEliminarTransportista.Click

        If tbTransportista.RowCount <= 0 Then
            MessageBox.Show("Ingresar una guía de transportista.", "Eliminar Transportista",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If

        Dim seleccion As DataGridViewRow = tbTransportista.SelectedRows(0)
        Dim codigo As Integer = seleccion.Cells(0).Value

        If seleccion.Index > -1 Then
            Dim sqlControl As New SQLControl
            sqlControl.SetConnection()

            Dim facturacionDao As New FacturacionDAO(sqlControl)
            Try
                sqlControl.OpenConexion()
                sqlControl.BeginTransaction()
                facturacionDao.SetDBcmd()

                facturacionDao.DeleteFacturaDetalleGuia(codigo_Detalle, codigo_Factura, codigo)

                sqlControl.CommitTransaction()
            Catch ex As Exception
                sqlControl.RollbackTransaccion()
                MessageBox.Show("Error al eliminar transportista. " + ex.Message, "Eliminar transportista",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error)
            Finally
                Try
                    sqlControl.CloseConexion()
                Catch ex As Exception
                    MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Eliminar transportista",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error)
                End Try
            End Try

            cargarGuiasTransportistas()
            actualizarDatosGuia()
        End If
    End Sub

    Private Sub btnAgregarRemitente_Click(sender As Object, e As EventArgs) Handles btnAgregarRemitente.Click

        If cbAccionGuia.SelectedIndex = -1 Then
            MessageBox.Show("Seleccionar un Item.", "Agregar Remitente",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
            Return
        End If

        If txtRemitente.Text = Nothing Then
            MessageBox.Show("Ingresar una Guía de Remitente.", "Agregar Remitente",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
            Return
        End If
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDao.SetDBcmd()

            facturacionDao.InsertFacturaDetalleRemitente(codigo_Detalle, codigo_Factura, txtRemitente.Text)

            sqlControl.CommitTransaction()
            txtRemitente.Text = ""
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al agregar remitente. " + ex.Message, "Agregar remitente",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Agregar remitente",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            End Try
        End Try

        cargarGuiasRemitente()
    End Sub

    Private Sub btnAgregarPlaca_Click(sender As Object, e As EventArgs) Handles btnAgregarPlaca.Click

        If cbAccionGuia.SelectedIndex = -1 Then
            MessageBox.Show("Seleccionar un Item", "Agregar Unidad",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
            Return
        End If

        If cbTracto.Text = Nothing Then
            MessageBox.Show("Ingresar una Unidad", "Agregar Unidad",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
            Return
        End If

        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDao.SetDBcmd()

            facturacionDao.InsertFacturaDetalleUnidad(codigo_Detalle, codigo_Factura, cbTracto.Text)
            cbTracto.SelectedIndex = -1
            cbTracto.Text = Nothing
            sqlControl.CommitTransaction()
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al grabar unidad. " + ex.Message, "Agregar unidad",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar unidad. " + ex.Message, "Agregar unidad",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error)
            End Try
        End Try

        cargarPlacasDetalle()
    End Sub

    Private Sub btnEliminarPlaca_Click(sender As Object, e As EventArgs) Handles btnEliminarPlaca.Click

        If tbPlaca.RowCount <= 0 Then
            MessageBox.Show("Ingresar una Unidad.", "Agregar Unidad",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If

        Dim seleccion As DataGridViewRow = tbPlaca.SelectedRows(0)
        Dim codigo As String = seleccion.Cells(0).Value

        If seleccion.Index > -1 Then
            Dim sqlControl As New SQLControl
            sqlControl.SetConnection()

            Dim facturacionDao As New FacturacionDAO(sqlControl)
            Try
                sqlControl.OpenConexion()
                sqlControl.BeginTransaction()
                facturacionDao.SetDBcmd()

                facturacionDao.DeleteFacturaDetalleUnidad(codigo_Detalle, codigo_Factura, codigo)

                sqlControl.CommitTransaction()
            Catch ex As Exception
                sqlControl.RollbackTransaccion()
                MessageBox.Show("Error al eliminar unidad. " + ex.Message, "Eliminar unidad",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            Finally
                Try
                    sqlControl.CloseConexion()
                Catch ex As Exception
                    MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Eliminar unidad",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
                End Try
            End Try

            cargarPlacasDetalle()

        End If
    End Sub

    Private Sub btnEliminarRemitente_Click(sender As Object, e As EventArgs) Handles btnEliminarRemitente.Click

        If tbRemitente.RowCount <= 0 Then
            MessageBox.Show("Ingresar una guía de remitente.", "Agregar Remitente",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If

        Dim seleccion As DataGridViewRow = tbRemitente.SelectedRows(0)
        Dim codigo As String = seleccion.Cells(0).Value

        If seleccion.Index > -1 Then
            Dim sqlControl As New SQLControl
            sqlControl.SetConnection()

            Dim facturacionDao As New FacturacionDAO(sqlControl)
            Try
                sqlControl.OpenConexion()
                sqlControl.BeginTransaction()
                facturacionDao.SetDBcmd()

                facturacionDao.DeleteFacturaDetalleRemitente(codigo_Detalle, codigo_Factura, codigo)

                sqlControl.CommitTransaction()
            Catch ex As Exception
                sqlControl.RollbackTransaccion()
                MessageBox.Show("Error al eliminar remitente. " + ex.Message, "Eliminar remitente",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            Finally
                Try
                    sqlControl.CloseConexion()
                Catch ex As Exception
                    MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Eliminar remitente",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
                End Try
            End Try

            cargarGuiasRemitente()

        End If
    End Sub

    Private Sub cargarDireccionesPrevias()

        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim facturacionDAO As New FacturacionDAO(sqlControl)

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()

            facturacionDAO.SetDBcmd()

            Dim dtOrigen, dtDestino As DataTable
            dtOrigen = facturacionDAO.GetOrigenDestino
            dtDestino = facturacionDAO.GetOrigenDestino
            With cbOrigen
                .DataSource = dtOrigen
                .DisplayMember = "DIRECCION"
                .ValueMember = "ITEM"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1

            End With

            With cbDestino
                .DataSource = dtDestino
                .DisplayMember = "DIRECCION"
                .ValueMember = "ITEM"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1

            End With

            sqlControl.CommitTransaction()

        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar direcciones. " + ex.Message, "Cargar direcciones",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar direcciones",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try

        End Try
    End Sub

    Private Sub chbxRecepcion_CheckedChanged(sender As Object, e As EventArgs) Handles chbxRecepcion.CheckedChanged
        If chbxRecepcion.Checked Then
            dtpRecepcion.Enabled = True
        Else
            dtpRecepcion.Enabled = False
        End If
    End Sub

    Private Sub chbxVencimiento_CheckedChanged(sender As Object, e As EventArgs) Handles chbxVencimiento.CheckedChanged
        If chbxVencimiento.Checked Then
            dtpVencimiento.Enabled = True
        Else
            dtpVencimiento.Enabled = False
        End If
    End Sub

    Private Sub chbxPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbxPago.CheckedChanged
        If chbxPago.Checked Then
            dtpPago.Enabled = True
            cbBancoPago.Enabled = True
        Else
            dtpPago.Enabled = False
            cbBancoPago.Enabled = False
        End If
    End Sub

    Private Sub chbxCompromiso_CheckedChanged(sender As Object, e As EventArgs) Handles chbxCompromiso.CheckedChanged
        If chbxCompromiso.Checked Then
            dtpCompromiso.Enabled = True
        Else
            dtpCompromiso.Enabled = False
        End If
    End Sub

    Private Sub txtPorcentajeDetraccion_Leave(sender As Object, e As EventArgs) Handles txtPorcentajeDetraccion.Leave
        calcularDetraccion()
    End Sub

    Sub calcularDetraccion()
        Dim porcentaje As Double, monto As Double, total As Double
        If txtPorcentajeDetraccion.Text = Nothing Then

        Else
            If txtPrecioFactura.Text = Nothing Then
            Else
                porcentaje = Double.Parse(txtPorcentajeDetraccion.Text)
                total = Double.Parse(txtPrecioFactura.Text)
                monto = (porcentaje / 100) * total
                txtMontoDetraccion.Text = Math.Round(monto, 2)
            End If
        End If
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click

    End Sub

    Private Sub txtTotalFactura_TextChanged(sender As Object, e As EventArgs) Handles txtTotalFactura.TextChanged

    End Sub

    Private Sub txtIgv_TextChanged(sender As Object, e As EventArgs) Handles txtIgv.TextChanged

    End Sub

    Private Sub cbDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDestino.SelectedIndexChanged

    End Sub

    Private Sub cbOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOrigen.SelectedIndexChanged

    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged

    End Sub

    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click

    End Sub

    Private Sub txtConfVehicular_TextChanged(sender As Object, e As EventArgs) Handles txtConfVehicular.TextChanged

    End Sub

    Private Sub Label29_Click(sender As Object, e As EventArgs) Handles Label29.Click

    End Sub

    Private Sub txtValorReferencial_TextChanged(sender As Object, e As EventArgs) Handles txtValorReferencial.TextChanged

    End Sub

    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click

    End Sub

    Private Sub txtPrecioUnitario_TextChanged(sender As Object, e As EventArgs) Handles txtPrecioUnitario.TextChanged

    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click

    End Sub

    Private Sub txtOrigen_TextChanged(sender As Object, e As EventArgs) Handles txtOrigen.TextChanged

    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click

    End Sub

    Private Sub txtObservaciones_TextChanged(sender As Object, e As EventArgs) Handles txtObservaciones.TextChanged

    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click

    End Sub

    Private Sub txtDestino_TextChanged(sender As Object, e As EventArgs) Handles txtDestino.TextChanged

    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click

    End Sub

    Private Sub tbPlaca_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tbPlaca.CellContentClick

    End Sub

    Private Sub cbTracto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTracto.SelectedIndexChanged

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub tbRemitente_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tbRemitente.CellContentClick

    End Sub

    Private Sub txtRemitente_TextChanged(sender As Object, e As EventArgs) Handles txtRemitente.TextChanged

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub cbGuia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGuia.SelectedIndexChanged

    End Sub

    Private Sub tbTransportista_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tbTransportista.CellContentClick

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub txtPrecioFactura_TextChanged(sender As Object, e As EventArgs) Handles txtPrecioFactura.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub txtDescripcionDetalle_TextChanged(sender As Object, e As EventArgs) Handles txtDescripcionDetalle.TextChanged

    End Sub

    Private Sub cbTipoServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoServicio.SelectedIndexChanged

    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click

    End Sub
End Class