Imports System.Data.SqlClient

Public Class ChildFacturaLibre
    Dim gvDetalle As New DataGridView
    Dim data As DataTable
    'Dim correlativoFactura As String
    Dim codigo_Factura As Integer = -1
    'Dim codigo_Detalle As Integer = -1
    Private cargandoDatosActualizar As Integer

    Private childBusquedaFactura As ChildBusquedaFactura

    Public Sub setChildBusquedaFactura(childBusquedaFactura As ChildBusquedaFactura)
        Me.childBusquedaFactura = childBusquedaFactura
    End Sub

    Private Sub btnRazonSocial_Click(sender As Object, e As EventArgs) Handles btnRazonSocial.Click
        obtenerDatosCliente()
    End Sub

    Public Sub setCodifoFactura(codigoFactura As Integer)
        codigo_Factura = codigoFactura
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
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MsgBox("No se pudo establecer la conexion con el servidor.")
            End Try
        End Try
    End Sub

    Private Sub ChildFacturaLibre_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtRUC.ReadOnly = True
        txtDireccion.ReadOnly = True
        txtTelefono.ReadOnly = True
        txtTotal.Text = "0.00"
        txtSubtotal.Text = "0.00"
        txtIGV.Text = "0.00"
        actualizarDatosCliente()
        actualizarDatosMoneda()
        If codigo_Factura <> -1 Then
            cargarDatosFactura()
            cargandoDatosActualizar = 0
            txtNroSerie.ReadOnly = True
        Else
            txtNroSerie.Text = "0001"
            txtNroSerie.ReadOnly = True
            ObtenerCorrelativo()
            btnGrabar.Enabled = False
            btnNuevo.Enabled = False
            btnEliminar.Enabled = False
            txtCantidad.Enabled = True
            txtDescripcion.Enabled = True
            txtPrecioUnitario.Enabled = True
        End If
        BloquearCabecera()
        'BloquearDetalle()

    End Sub

    Private Sub BloquearDetalle()
        If codigo_Factura = -1 Then
            txtDescripcion.Enabled = False
            txtCantidad.Enabled = False
            txtPrecioUnitario.Enabled = False
            btnNuevo.Enabled = False
            btnGrabar.Enabled = False
            btnEliminar.Enabled = False
        Else
            txtDescripcion.Enabled = True
            txtCantidad.Enabled = True
            txtPrecioUnitario.Enabled = True
            btnNuevo.Enabled = True
            btnGrabar.Enabled = True
            btnEliminar.Enabled = True
        End If
    End Sub

    Private Sub BloquearCabecera()
        If codigo_Factura = -1 Then
            btnGuardarCabecera.Enabled = True
            cbMoneda.Enabled = True
            cbRazonSocial.Enabled = True
            dtFecha.Enabled = True
            txtNroSerie.Enabled = True
            btnRazonSocial.Enabled = True
        Else
            'btnGuardarCabecera.Enabled = False
            'cbMoneda.Enabled = False
            'cbRazonSocial.Enabled = False
            'dtFecha.Enabled = False
            txtNroSerie.Enabled = False
            'btnRazonSocial.Enabled = False
        End If
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
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MsgBox("No se pudo establecer la conexion con el servidor.")
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
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MsgBox("No se pudo establecer la conexion con el servidor.")
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

            'correlativoFactura =
            lbNroFactura.Text = correlativoDao.GetSiguienteCorrelativo(1, txtNroSerie.Text)
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

    Private Sub btnGuardarCabecera_Click(sender As Object, e As EventArgs) Handles btnGuardarCabecera.Click
        If cbRazonSocial.SelectedIndex < 0 Then
            MessageBox.Show("Seleccionar Cliente.", "Validación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If
        If cbMoneda.SelectedIndex < 0 Then
            MessageBox.Show("Seleccionar moneda.", "Validación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If
        GuardarCabeceraFactura()
    End Sub

    Private Sub GuardarCabeceraFactura()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Dim correlativoDao As New Correlativo_NumeroDAO(sqlControl)

        If lbNroFactura.Text = Nothing Then
            MessageBox.Show("Debe existir el nro de factura. ", "Grabar datos factura",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
            Return
        End If

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            correlativoDao.setDBcmd()

            Dim porcentaje_detraccion As Double, monto_detraccion As Double, banco As Integer
            If txtPorcentajeDetraccion.Text = Nothing Then
                porcentaje_detraccion = 0
            Else
                porcentaje_detraccion = CType(txtPorcentajeDetraccion.Text, Double)
            End If

            If txtMontoDetraccion.Text = Nothing Then
                monto_detraccion = 0
            Else
                monto_detraccion = CType(txtMontoDetraccion.Text, Double)
            End If

            If cbBancoPago.SelectedIndex < 0 Then
                banco = -1
            Else
                banco = cbBancoPago.SelectedValue
            End If

            calcularDetraccion()
            If codigo_Factura = -1 Then
                'Inicio - Ingreso de la Cabecera de la Factura
                If correlativoDao.GetValidaSerieNroFactura(lbNroFactura.Text, txtNroSerie.Text) Then
                    MessageBox.Show("Existe una factura con el Nro. de Serie y Nro. de Correlativo. ", "Grabar datos factura",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                    Return
                End If

                correlativoDao.updateCorrelativoNumero(1, txtNroSerie.Text, lbNroFactura.Text)
                codigo_Factura = facturacionDao.InsertFactura(txtNroSerie.Text,
                                         lbNroFactura.Text,
                                         CType(cbRazonSocial.SelectedValue, Integer),
                                         CType(0, Double),
                                         CType(cbMoneda.SelectedValue, Integer),
                                         16,
                                         dtFecha.Value,
                                         33, chbxRecepcion.Checked, dtpRecepcion.Value,
                                         chbxVencimiento.Checked, dtpVencimiento.Value,
                                         chbxPago.Checked, dtpPago.Value,
                                         chbxCompromiso.Checked, dtpCompromiso.Value,
                                                              porcentaje_detraccion, monto_detraccion, banco)
                'Fin - Ingreso de la Cabecera de la Factura
            Else
                facturacionDao.UpdateFactura(codigo_Factura, txtNroSerie.Text,
                                         lbNroFactura.Text,
                                         CType(cbRazonSocial.SelectedValue, Integer),
                                         CType(txtTotal.Text, Double),
                                         CType(cbMoneda.SelectedValue, Integer),
                                         16,
                                         dtFecha.Value,
                                         chbxRecepcion.Checked, dtpRecepcion.Value,
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
            BloquearCabecera()
            BloquearDetalle()
            'childBusquedaFactura.cargarDatosFactura()
        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al grabar datos de factura. " + ex.Message, "Grabar datos factura",
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

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim cantidad As Integer, precio, subtotal, igv, total As Double

        If txtCantidad.Text = Nothing Then
            cantidad = 0
        Else
            cantidad = Integer.Parse(txtCantidad.Text)
        End If

        If txtDescripcion.Text = Nothing Then
            MessageBox.Show("Ingresar Descripción.", "Validación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If
        If txtPrecioUnitario.Text = Nothing Then
            precio = 0
        Else
            precio = CType(txtPrecioUnitario.Text, Double)
        End If

        subtotal = CType(txtSubtotalDetalle.Text, Double)
        igv = CType(txtIgvDetalle.Text, Double)
        total = CType(txtTotalDetalle.Text, Double)

        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        GuardarCabeceraFactura()

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDao.SetDBcmd()

            If txtCodigoDetalle.Text = Nothing Then
                facturacionDao.InsertFacturaDetalle(codigo_Factura,
                                                -1,
                                                txtDescripcion.Text,
                                                cantidad,
                                                "",
                                                0,
                                                "",
                                                precio,
                                                "",
                                                "",
                                                subtotal,
                                                igv,
                                                total)

            Else

                facturacionDao.UpdateFacturaDetalle(txtCodigoDetalle.Text, codigo_Factura,
                                                -1,
                                                txtDescripcion.Text,
                                                cantidad,
                                                "",
                                                0,
                                                "",
                                                precio,
                                                "",
                                                "",
                                                subtotal,
                                                igv,
                                                total)

            End If

            sqlControl.CommitTransaction()

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al grabar Detalle. " + ex.Message, "Grabar datos detalle factura",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al grabar Detalle. " + ex.Message, "Grabar datos detalle factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                If sqlControl.GetDBcon.State = ConnectionState.Open Then
                    sqlControl.CloseConexion()
                End If

            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Grabar datos detalle factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
            'cargarDetalleFactura()
            cargarDatosFactura()
            limpiar()
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

            Dim dataDetalle As DataTable = facturacionDao.getAllDetalleFacturaByCodigoFactura(codigo_Factura)
            sqlControl.CommitTransaction()

            dgvDetalle.DataSource = dataDetalle

            dgvDetalle.Columns(0).Visible = False
            dgvDetalle.Columns(1).Visible = False
            dgvDetalle.Columns(2).Visible = False
            dgvDetalle.Columns(5).Visible = False
            dgvDetalle.Columns(6).Visible = False
            dgvDetalle.Columns(11).Visible = False
            dgvDetalle.Columns(12).Visible = False
            dgvDetalle.Columns(13).Visible = False

            dgvDetalle.Columns(3).Width = 80
            dgvDetalle.Columns(4).Width = 625
            dgvDetalle.Columns(7).Width = 100

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

            cbRazonSocial.SelectedValue = dtCabeceraFactura.Rows(0).Item(3).ToString

            txtSubtotal.Text = dtCabeceraFactura.Rows(0).Item(16)
            txtIGV.Text = dtCabeceraFactura.Rows(0).Item(15)
            txtTotal.Text = dtCabeceraFactura.Rows(0).Item(4)

            cbMoneda.SelectedValue = dtCabeceraFactura.Rows(0).Item(5)
            dtFecha.Value = CType(dtCabeceraFactura.Rows(0).Item(6), Date)
            txtNroSerie.Text = dtCabeceraFactura.Rows(0).Item(1).ToString
            lbNroFactura.Text = dtCabeceraFactura.Rows(0).Item(2).ToString

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
            MessageBox.Show("Error al cargar." + ex.Message, "Validación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar." + ex.Message, "Validación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)

        Finally
            Try

                sqlControl.CloseConexion()
                obtenerDatosCliente()
                cargarDetalleFactura()
                BloquearBotones()
                'childBusquedaFactura.cargarDatosFactura()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión." + ex.Message, "Validación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try
    End Sub
    Private Sub BloquearBotones()
        'If cbAccionGuia.Items.Count = 0 Then
        '    btnActualizar.Enabled = False
        '    btnEliminar.Enabled = False
        '    btnNuevo.Enabled = True
        'Else
        '    btnGrabar.Enabled = True
        '    btnEliminar.Enabled = True

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDao.SetDBcmd()

            Dim seleccion As DataGridViewRow = dgvDetalle.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(1).Value

            facturacionDao.DeleteFacturaDetalle(codigo, codigo_Factura)

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

        'cargarDetalleFactura()
        'BloquearDetalle()
        BloquearBotones()
        cargarDatosFactura()
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

            Dim seleccion As DataGridViewRow = dgvDetalle.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(1).Value

            datDetalle = facturacionDao.GetDetalleFacturaByIdDetalle(codigo)
            sqlControl.CommitTransaction()


            txtDescripcion.Text = datDetalle.Rows(0).Item(1).ToString
            txtCantidad.Text = datDetalle.Rows(0).Item(2).ToString
            txtPrecioUnitario.Text = datDetalle.Rows(0).Item(5).ToString

            txtSubtotalDetalle.Text = datDetalle.Rows(0).Item(6).ToString
            txtIgvDetalle.Text = datDetalle.Rows(0).Item(7).ToString
            txtTotalDetalle.Text = datDetalle.Rows(0).Item(8).ToString

            txtCodigoDetalle.Text = datDetalle.Rows(0).Item(12).ToString

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar Detalle. " + ex.Message, "Cargar Datos Detalle",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("Error al cargar Detalle. " + ex.Message, "Cargar Datos Detalle",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        Finally
            Try
                If sqlControl.GetDBcon.State = ConnectionState.Open Then
                    sqlControl.CloseConexion()
                End If

            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar Datos Detalle",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
            End Try
        End Try
    End Sub

    Private Sub dgvDetalle_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDetalle.CellMouseClick
        cargarDatosDetalleFactura()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()
    End Sub
    Sub limpiar()
        'codigo_Detalle = -1
        txtCantidad.Text = ""
        txtDescripcion.Text = ""
        txtPrecioUnitario.Text = ""
        txtCodigoDetalle.Text = ""
        txtSubtotalDetalle.Text = ""
        txtIgvDetalle.Text = ""
        txtTotalDetalle.Text = ""
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If dgvDetalle.Rows.Count Then
            Dim rpt As New RptPrintFacturaLibre
            rpt.setNroFactura(codigo_Factura)
            rpt.Show()
        Else
            MessageBox.Show("Se requiere mínimo un detalle para la impresión.", "Imprimir",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
        End If

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
            If txtTotal.Text = Nothing Then
            Else
                porcentaje = CType(txtPorcentajeDetraccion.Text, Double)
                total = CType(txtTotal.Text, Double)
                monto = (porcentaje / 100) * total
                txtMontoDetraccion.Text = Math.Round(monto, 2)
            End If
        End If
    End Sub

    Private Sub txtCantidad_Leave(sender As Object, e As EventArgs) Handles txtCantidad.Leave
        setearMontosDetalle()
    End Sub
    Sub setearMontosDetalle()
        If txtCantidad.Text IsNot Nothing Then
            If txtPrecioUnitario.Text IsNot Nothing Then
                Dim cantidad, precio, subtotal, igv, total As Double
                cantidad = CType(txtCantidad.Text, Double)
                precio = CType(txtPrecioUnitario.Text, Double)

                subtotal = cantidad * precio
                igv = subtotal * 0.18
                total = subtotal + igv

                txtSubtotalDetalle.Text = Math.Round(subtotal, 2)
                txtIgvDetalle.Text = Math.Round(igv, 2)
                txtTotalDetalle.Text = Math.Round(total, 2)

            End If
        Else

        End If
    End Sub

    Private Sub txtPrecioUnitario_Leave(sender As Object, e As EventArgs) Handles txtPrecioUnitario.Leave
        setearMontosDetalle()
    End Sub

    Private Sub ChildFacturaLibre_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        childBusquedaFactura.cargarDatosFactura()
    End Sub
End Class