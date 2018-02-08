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

    Private Sub ChildFacturaLibre_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtRUC.ReadOnly = True
        txtDireccion.ReadOnly = True
        txtTelefono.ReadOnly = True
        txtTotal.Text = "0.00"
        actualizarDatosCliente()
        actualizarDatosMoneda()
        If codigo_Factura <> -1 Then
            cargarDatosFactura()
            cargandoDatosActualizar = 0
            'btnGrabar.Enabled = False
            'btnNuevo.Enabled = False
            'btnEliminar.Enabled = False
            txtNroSerie.ReadOnly = True
            'txtCantidad.Enabled = False
            'txtDescripcion.Enabled = False
            'txtPrecioUnitario.Enabled = False
        Else
            txtNroSerie.Text = "001"
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

    Private Sub ObtenerCorrelativo()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim correlativoDao As New Correlativo_NumeroDAO(sqlControl)

        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            correlativoDao.setDBcmd()

            'correlativoFactura =
            lbNroFactura.Text = correlativoDao.GetSiguienteCorrelativo(1, txtNroSerie.Text)
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
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Dim correlativoDao As New Correlativo_NumeroDAO(sqlControl)

        If lbNroFactura.Text = Nothing Then
            MessageBox.Show("Debe existir el nro de factura. ", "Grabar datos factura",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
            Return
        End If

        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            correlativoDao.setDBcmd()

            Dim porcentaje_detraccion As Double, monto_detraccion As Double
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
                                         CType(0, Long),
                                         CType(cbMoneda.SelectedValue, Integer),
                                         16,
                                         dtFecha.Value,
                                         33, chbxRecepcion.Checked, dtpRecepcion.Value,
                                         chbxVencimiento.Checked, dtpVencimiento.Value,
                                         chbxPago.Checked, dtpPago.Value,
                                         chbxCompromiso.Checked, dtpCompromiso.Value,
                                                              porcentaje_detraccion, monto_detraccion)
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
                                             porcentaje_detraccion, monto_detraccion)
            End If


            sqlControl.commitTransaction()

            txtNroSerie.Enabled = False
            cbRazonSocial.Enabled = False
            cbMoneda.Enabled = False
            dtFecha.Enabled = False
            btnRazonSocial.Enabled = False
            BloquearCabecera()
            BloquearDetalle()
            childBusquedaFactura.cargarDatosFactura()
        Catch ex As SqlException
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al grabar datos de factura. " + ex.Message, "Grabar datos factura",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al grabar datos de factura. " + ex.Message, "Grabar datos factura",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Grabar datos factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim cantidad As Integer, precio As Double

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
            precio = txtPrecioUnitario.Text
        End If

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        GuardarCabeceraFactura()

        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            facturacionDao.setDBcmd()

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
                                                ""
                                                )

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
                                                ""
                                                )

            End If

            sqlControl.commitTransaction()

        Catch ex As SqlException
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al grabar Detalle. " + ex.Message, "Grabar datos detalle factura",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al grabar Detalle. " + ex.Message, "Grabar datos detalle factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                If sqlControl.getDBcon.State = ConnectionState.Open Then
                    sqlControl.closeConexion()
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
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)

        Try

            sqlControl.openConexion()
            sqlControl.beginTransaction()
            facturacionDao.setDBcmd()

            Dim dataDetalle As DataTable = facturacionDao.getAllDetalleFacturaByCodigoFactura(codigo_Factura)
            dgvDetalle.DataSource = dataDetalle

            dgvDetalle.Columns(0).Visible = False
            dgvDetalle.Columns(1).Visible = False
            dgvDetalle.Columns(2).Visible = False
            dgvDetalle.Columns(5).Visible = False
            dgvDetalle.Columns(6).Visible = False
            dgvDetalle.Columns(8).Visible = False
            dgvDetalle.Columns(9).Visible = False
            dgvDetalle.Columns(10).Visible = False

            dgvDetalle.Columns(3).Width = 80
            dgvDetalle.Columns(4).Width = 625
            dgvDetalle.Columns(7).Width = 100

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
            txtIGV.Text = Double.Parse(dtCabeceraFactura.Rows(0).Item(4)) * 0.18
            txtSubtotal.Text = dtCabeceraFactura.Rows(0).Item(4)
            txtTotal.Text = Double.Parse(txtIGV.Text) + Double.Parse(txtSubtotal.Text)
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
            If dtCabeceraFactura.Rows(0).Item(11) IsNot DBNull.Value Then
                dtpCompromiso.Enabled = True
                dtpCompromiso.Value = CType(dtCabeceraFactura.Rows(0).Item(11), Date)
                chbxCompromiso.Checked = True
            End If

            txtPorcentajeDetraccion.Text = dtCabeceraFactura.Rows(0).Item(12)
            txtMontoDetraccion.Text = dtCabeceraFactura.Rows(0).Item(13)
        Catch ex As SqlException
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar." + ex.Message, "Validación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar." + ex.Message, "Validación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)

        Finally
            Try

                sqlControl.closeConexion()
                obtenerDatosCliente()
                cargarDetalleFactura()
                BloquearBotones()
                childBusquedaFactura.cargarDatosFactura()
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
        sqlControl.setConnection()

        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            facturacionDao.setDBcmd()

            Dim seleccion As DataGridViewRow = dgvDetalle.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(1).Value

            facturacionDao.deleteFacturaDetalle(codigo, codigo_Factura)

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

        'cargarDetalleFactura()
        'BloquearDetalle()
        BloquearBotones()
        cargarDatosFactura()
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

            Dim seleccion As DataGridViewRow = dgvDetalle.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(1).Value

            datDetalle = facturacionDao.getDetalleFacturaByIdDetalle(codigo)
            sqlControl.commitTransaction()


            txtDescripcion.Text = datDetalle.Rows(0).Item(1).ToString
            txtCantidad.Text = datDetalle.Rows(0).Item(2).ToString
            txtPrecioUnitario.Text = datDetalle.Rows(0).Item(5).ToString
            txtCodigoDetalle.Text = datDetalle.Rows(0).Item(9).ToString

        Catch ex As SqlException
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar Detalle. " + ex.Message, "Cargar Datos Detalle",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("Error al cargar Detalle. " + ex.Message, "Cargar Datos Detalle",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
        Finally
            Try
                If sqlControl.getDBcon.State = ConnectionState.Open Then
                    sqlControl.closeConexion()
                End If

            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar Datos Detalle",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
            End Try
        End Try
    End Sub

    Private Sub dgvDetalle_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDetalle.CellMouseClick
        'Dim seleccion As DataGridViewRow = dgvDetalle.SelectedRows(0)
        'Dim codigo As Integer = seleccion.Cells(1).Value

        'codigo_Detalle = codigo
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
        Else
            dtpPago.Enabled = False
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
            If txtSubtotal.Text = Nothing Then
            Else
                porcentaje = Double.Parse(txtPorcentajeDetraccion.Text)
                total = Double.Parse(txtSubtotal.Text)
                monto = (porcentaje / 100) * total
                txtMontoDetraccion.Text = Math.Round(monto, 2)
            End If
        End If
    End Sub
End Class