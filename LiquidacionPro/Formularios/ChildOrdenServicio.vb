Imports System.Data.SqlClient

Public Class ChildOrdenServicio
    Dim columnaFiltro As Integer = -1
    Dim source1 As New BindingSource()
    Dim nombreColumnaFiltro As String
    Private Sub btnAgregarDetalle_Click(sender As Object, e As EventArgs) Handles btnAgregarDetalle.Click
        'dgvDetalleOrdenServicio.ColumnCount = 3
        'dgvDetalleOrdenServicio.Columns(0).Name = "Product ID"
        'dgvDetalleOrdenServicio.Columns(1).Name = "Product Name"
        'dgvDetalleOrdenServicio.Columns(2).Name = "Product_Price"

        'Dim row As String() = New String() {"1", "Product 1", "1000"}
        'dgvDetalleOrdenServicio.Rows.Add(row)
        'row = New String() {"2", "Product 2", "2000"}
        'dgvDetalleOrdenServicio.Rows.Add(row)
        'row = New String() {"3", "Product 3", "3000"}
        'dgvDetalleOrdenServicio.Rows.Add(row)
        'row = New String() {"4", "Product 4", "4000"}
        'dgvDetalleOrdenServicio.Rows.Add(row)
    End Sub

    Private Sub ChildOrdenServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarAllOrdenServicio()
        CargarDatosMoneda()
        CargarDatosCliente()
        ObtenerCorrelativo()
        CargarTipoServicio()
        CargarDetalle(-1)
        'dgvDetalleOrdenServicio.ColumnCount = 4
        'dgvDetalleOrdenServicio.Columns(0).Name = "Product ID"
        'dgvDetalleOrdenServicio.Columns(1).Name = "Product Name"
        'dgvDetalleOrdenServicio.Columns(2).Name = "Product_Price"

        'Dim row As String() = New String() {"1", "Product 1", "1000"}
        'dgvDetalleOrdenServicio.Rows.Add(row)
        'row = New String() {"2", "Product 2", "2000"}
        'dgvDetalleOrdenServicio.Rows.Add(row)
        'row = New String() {"3", "Product 3", "3000"}
        'dgvDetalleOrdenServicio.Rows.Add(row)
        'row = New String() {"4", "Product 4", "4000"}
        'dgvDetalleOrdenServicio.Rows.Add(row)

        'Dim cmb As New DataGridViewComboBoxColumn()
        'cmb.HeaderText = "Select Data"
        'cmb.Name = "cmb"
        'cmb.MaxDropDownItems = 4
        'cmb.Items.Add("True")
        'cmb.Items.Add("False")
        'dgvDetalleOrdenServicio.Columns.Add(cmb)
    End Sub

    Sub CargarAllOrdenServicio()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim ordenServicioDAO As New OrdenServicioDAO(sqlControl)
        Try
            If sqlControl.OpenConexion() Then
                sqlControl.BeginTransaction()
                ordenServicioDAO.setDBcmd()

                Dim dt As DataTable

                dt = ordenServicioDAO.GetAllOrdenServicio
                sqlControl.CommitTransaction()

                'Se salva el filtro previo
                Dim filtro As String = source1.Filter

                dgvOrdenServicio.DataSource = dt

                'dgvGuias.Columns(0).Width = 55
                'dgvGuias.Columns(1).Width = 75
                'dgvGuias.Columns(5).Width = 75
                'dgvGuias.Columns(6).Width = 70
                'dgvGuias.Columns(8).Width = 60
                'dgvGuias.Columns(10).Width = 60
                'dgvGuias.Columns(12).Width = 220
                'dgvGuias.Columns(13).Width = 80
                'dgvGuias.Columns(14).Width = 80
                'dgvGuias.Columns(15).Width = 80
                'dgvGuias.Columns(17).Width = 220
                'dgvGuias.Columns(18).Width = 80
                'dgvGuias.Columns(19).Width = 80

                'dgvGuias.Columns(2).Visible = False
                'dgvGuias.Columns(3).Visible = False
                'dgvGuias.Columns(4).Visible = False
                'dgvGuias.Columns(7).Visible = False
                'dgvGuias.Columns(9).Visible = False
                'dgvGuias.Columns(11).Visible = False
                'dgvGuias.Columns(16).Visible = False

                dgvOrdenServicio.Columns(1).DefaultCellStyle.Format = "dd/MM/yyyy"

                If filtro <> Nothing Then
                    source1.DataSource = dgvOrdenServicio.DataSource
                    source1.Filter = filtro
                    dgvOrdenServicio.Refresh()
                End If

                If txtCodigo.Text <> Nothing Then
                    Dim rowIndex As Integer = -1
                    For Each row As DataGridViewRow In dgvOrdenServicio.Rows
                        If row.Cells(0).Value.ToString().Equals(txtCodigo.Text) Then
                            rowIndex = row.Index
                            Exit For
                        End If
                    Next

                    If rowIndex <> -1 Then
                        dgvOrdenServicio.CurrentCell = dgvOrdenServicio.Item(0, rowIndex)
                    End If

                End If
            End If


        Catch ex As SqlException
            If sqlControl.GetDBcon.State = ConnectionState.Open Then
                sqlControl.RollbackTransaccion()
                MessageBox.Show("Error al cargar Órdenes de Servicio. SQL. " + ex.Message, "Cargar Órdenes de Servicio",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar Órdenes de Servicio. " + ex.Message, "Cargar Órdenes de Servicio",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                If sqlControl.GetDBcon.State = ConnectionState.Open Then
                    sqlControl.CloseConexion()
                End If
            Catch ex As Exception

            End Try
        End Try
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        GrabarOrdenServicio()
    End Sub

    Sub GrabarOrdenServicio()
        Dim codigo As Integer, fecha As Date, numero As String, incluyeIgv As Integer,
            subtotal As Double, igv As Double, total As Double, origen As String,
            destino As String, cliente As Integer, moneda As Integer

        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim ordenServicioDAO As New OrdenServicioDAO(sqlControl)
        Dim correlativoDao As New Correlativo_NumeroDAO(sqlControl)

        Try

            If cbCliente.SelectedIndex < 0 Then
                MessageBox.Show("Seleccionar el cliente. ", "Validación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
                Return
            End If

            If cbMoneda.SelectedIndex < 0 Then
                MessageBox.Show("Seleccionar la moneda. ", "Validación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
                Return
            End If

            If txtPrecio.Text = Nothing Then
                MessageBox.Show("Ingresar el precio del servicio. ", "Validación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
                Return
            End If

            If txtCodigo.Text = Nothing Then
                codigo = 0
            Else
                codigo = txtCodigo.Text
            End If

            If txtNumero.Text = Nothing Then
                numero = 0
            Else
                numero = txtNumero.Text
            End If

            fecha = dtpFecha.Value

            cliente = cbCliente.SelectedValue

            If txtOrigen.Text = Nothing Then
                origen = ""
            Else
                origen = txtOrigen.Text
            End If

            If txtDestino.Text = Nothing Then
                destino = ""
            Else
                destino = txtDestino.Text
            End If


            If chbxIgv.Checked = True Then
                incluyeIgv = 1
            Else
                incluyeIgv = 0
            End If


            subtotal = txtPrecio.Text
            igv = txtIgv.Text
            total = txtTotal.Text

            moneda = cbMoneda.SelectedValue

            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            correlativoDao.setDBcmd()

            If txtCodigo.Text = Nothing Then
                'Insert
                ObtenerCorrelativo()
                Dim anio As String = Now.Date.Year.ToString.Substring(2, 2)
                correlativoDao.updateCorrelativoNumero(2, "OS" + anio, txtNumero.Text.Substring(2, 6))

                Dim codigo_registro As Integer = ordenServicioDAO.InsertOrdenServicio(fecha, numero, incluyeIgv,
                                                                                      subtotal, igv, total, origen,
                                                                                      destino, cliente, moneda)
                If codigo_registro > 0 Then
                    txtCodigo.Text = codigo_registro
                Else
                    MessageBox.Show("Error al insertar. ", "Registro de orden de servicio",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
                End If
            Else
                'Update

                Dim codigo_registro As Integer = ordenServicioDAO.UpdateOrdenServicio(codigo, fecha, numero, incluyeIgv,
                                                                                      subtotal, igv, total, origen,
                                                                                      destino, cliente, moneda)
                If codigo_registro > 0 Then
                    MessageBox.Show("Se actualizó con éxito. ", "Registro de orden de servicio",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
                End If
            End If
            sqlControl.CommitTransaction()

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error. SQL. " + ex.Message, "Registro de orden de servicio",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error. " + ex.Message, "Registro de orden de servicio",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
                CargarAllOrdenServicio()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Registro de orden de servicio",
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

            Dim anio As String = Now.Date.Year.ToString.Substring(2, 2)

            txtNumero.Text = "OS" + correlativoDao.GetSiguienteCorrelativo(2, "OS" + anio)
            sqlControl.CommitTransaction()

        Catch ex As SqlException
            MessageBox.Show("Error SQL. " + ex.Message, "Obtener Correlativo",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            sqlControl.RollbackTransaccion()
        Catch ex As Exception
            MessageBox.Show("Error." + ex.Message, "Obtener Correlativo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión." + ex.Message, "Obtener Correlativo",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try

    End Sub

    Sub CalcularPrecio()

        If txtPrecio.Text <> "" Then
            Try
                Dim precio, igv, total As Double

                If chbxIgv.Checked = False Then
                    precio = CType(txtPrecio.Text, Double)
                    igv = precio * 0.18
                    total = precio + igv
                Else
                    precio = CType(txtPrecio.Text, Double) / 1.18
                    igv = precio * 0.18
                    total = precio + igv
                End If


                txtPrecio.Text = Math.Round(precio, 2).ToString("0.00")
                txtIgv.Text = Math.Round(igv, 2).ToString("0.00")
                txtTotal.Text = Math.Round(total, 2).ToString("0.00")
            Catch

            End Try
        End If
    End Sub

    Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
        CalcularPrecio()
    End Sub

    Private Sub CargarDatosMoneda()
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

    Private Sub CargarDatosCliente()

        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim clienteDao As New ClienteDAO(sqlControl)

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()

            clienteDao.setDBcmd()

            Dim dtCliente As DataTable
            dtCliente = clienteDao.GetClientes

            With cbCliente
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

    Private Sub dgvOrdenServicio_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvOrdenServicio.CellMouseClick
        CargarOrdenServicio()
        If txtCodigo.Text IsNot Nothing Then
            CargarDetalle(CInt(txtCodigo.Text))
        End If
    End Sub

    Sub CargarOrdenServicio()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim ordenServicioDAO As New OrdenServicioDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            ordenServicioDAO.setDBcmd()

            Dim seleccion As DataGridViewRow = dgvOrdenServicio.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(0).Value
            Dim dt As DataTable

            dt = ordenServicioDAO.GetOrdenServicioByCodigo(codigo)
            sqlControl.CommitTransaction()

            txtCodigo.Text = dt.Rows(0)(0)
            txtNumero.Text = dt.Rows(0)(1)
            dtpFecha.Value = dt.Rows(0)(2)
            cbCliente.SelectedValue = dt.Rows(0)(3)
            txtOrigen.Text = dt.Rows(0)(4)
            txtDestino.Text = dt.Rows(0)(5)
            cbMoneda.SelectedValue = dt.Rows(0)(6)
            chbxIgv.Checked = dt.Rows(0)(7)
            txtPrecio.Text = dt.Rows(0)(8)
            txtIgv.Text = dt.Rows(0)(9)
            txtTotal.Text = dt.Rows(0)(10)


        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error SQL. " + ex.Message, "Cargar Orden Servicio",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error. " + ex.Message, "Cargar Orden Servicio",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar Orden Servicio",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Public Sub CargarTipoServicio()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()
        Dim tipoServicioDAO As New TipoServicioDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            tipoServicioDAO.setDBcmd()

            Dim dt1 As DataTable
            dt1 = tipoServicioDAO.GetTiposDeServicio
            sqlControl.CommitTransaction()

            Dim cmb As New DataGridViewComboBoxColumn()
            With cmb
                .DataSource = dt1
                .HeaderText = "Tipo Servicio"
                .ValueMember = "CODIGO_ESTADO"
                .DisplayMember = "DETALLE_ESTADO"
                .DisplayStyle = ComboBoxStyle.Simple
                .DataPropertyName = "Tipo Servicio"
            End With

            dgvDetalleOrdenServicio.Columns.Add(cmb)

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error. SQL. " + ex.Message, "Cargar detalle",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error. " + ex.Message, "Cargar detalle",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar detalle",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            End Try
        End Try
    End Sub
    Sub CargarDetalle(codigo As Integer)

        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()
        Dim ordenServicioDAO As New OrdenServicioDAO(sqlControl)
        Dim tipoServicioDAO As New TipoServicioDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            ordenServicioDAO.setDBcmd()


            Dim dt As DataTable
            dt = ordenServicioDAO.GetDetalleOrdenServicioByCodigoOrdenServicio(codigo)
            sqlControl.CommitTransaction()

            dgvDetalleOrdenServicio.DataSource = dt

            dgvDetalleOrdenServicio.Columns(0).Visible = False
            dgvDetalleOrdenServicio.Columns(1).Visible = False
            dgvDetalleOrdenServicio.Columns(2).Visible = False

            dgvDetalleOrdenServicio.Columns(3).Width = 150
            dgvDetalleOrdenServicio.Columns(4).Width = 50
            dgvDetalleOrdenServicio.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDetalleOrdenServicio.Columns(5).Width = 50
            dgvDetalleOrdenServicio.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDetalleOrdenServicio.Columns(6).Width = 50
            dgvDetalleOrdenServicio.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDetalleOrdenServicio.Columns(7).Width = 70
            dgvDetalleOrdenServicio.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDetalleOrdenServicio.Columns(8).Width = 40
            dgvDetalleOrdenServicio.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDetalleOrdenServicio.Columns(9).Width = 70
            dgvDetalleOrdenServicio.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDetalleOrdenServicio.Columns(10).Width = 70
            dgvDetalleOrdenServicio.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDetalleOrdenServicio.Columns(10).ReadOnly = True
            dgvDetalleOrdenServicio.Columns(11).Width = 70
            dgvDetalleOrdenServicio.Columns(11).ReadOnly = True
            dgvDetalleOrdenServicio.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDetalleOrdenServicio.Columns(12).Width = 70
            dgvDetalleOrdenServicio.Columns(12).ReadOnly = True
            dgvDetalleOrdenServicio.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgvDetalleOrdenServicio.ContextMenuStrip = cmsDetalle
        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error. SQL. " + ex.Message, "Cargar detalle",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error. " + ex.Message, "Cargar detalle",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar detalle",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            End Try
        End Try
    End Sub
    Sub GrabarOrdenServicioDetalle(index As Integer, opcion As Integer)
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()
        Dim ordenServicioDAO As New OrdenServicioDAO(sqlControl)

        Dim seleccion As DataGridViewRow = dgvDetalleOrdenServicio.Rows(index)

        Dim codigoOrden As Integer, codigoOrdenDetalle As Integer, nroLinea As String, alto As Double, ancho As Double,
            largo As Double, peso As Double, cantidad As Double, precioUnitario As Double, subtotal As Double, igv As Double,
            total As Double, obs As String, tipoServicio As Integer

        If txtCodigo.Text <> "" Then
            codigoOrden = CType(txtCodigo.Text, Integer)
        Else
            MessageBox.Show("Debe registrar primero la cabecera de Orden de Servicio. ", "Grabar detalle",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation)
            Return
        End If

        If seleccion.Cells(0).Value Is DBNull.Value Then
            codigoOrdenDetalle = -1
        Else

            codigoOrdenDetalle = seleccion.Cells(0).Value
        End If

        'If seleccion.Cells(1).Value Is DBNull.Value Then
        '    codigoOrden = -1
        'Else
        '    codigoOrden = seleccion.Cells(1).Value
        'End If

        If seleccion.Cells(2).Value Is DBNull.Value Then
            nroLinea = ""
        Else
            nroLinea = seleccion.Cells(2).Value
        End If

        If seleccion.Cells(3).Value Is DBNull.Value Then
            tipoServicio = -1
        Else
            tipoServicio = seleccion.Cells(3).Value
        End If

        If seleccion.Cells(4).Value Is DBNull.Value Then
            alto = -1
        Else
            alto = seleccion.Cells(4).Value
        End If

        If seleccion.Cells(5).Value Is DBNull.Value Then
            ancho = -1
        Else
            ancho = seleccion.Cells(5).Value
        End If

        If seleccion.Cells(6).Value Is DBNull.Value Then
            largo = -1
        Else
            largo = seleccion.Cells(6).Value
        End If

        If seleccion.Cells(7).Value Is DBNull.Value Then
            peso = -1
        Else
            peso = seleccion.Cells(7).Value
        End If

        If seleccion.Cells(8).Value Is DBNull.Value Then
            cantidad = -1
        Else
            cantidad = seleccion.Cells(8).Value
        End If

        If seleccion.Cells(9).Value Is DBNull.Value Then
            precioUnitario = -1
        Else
            precioUnitario = seleccion.Cells(9).Value
        End If

        If seleccion.Cells(10).Value Is DBNull.Value Then
            subtotal = -1
        Else
            subtotal = seleccion.Cells(10).Value
        End If

        If seleccion.Cells(11).Value Is DBNull.Value Then
            igv = -1
        Else
            igv = seleccion.Cells(11).Value
        End If

        If seleccion.Cells(12).Value Is DBNull.Value Then
            total = -1
        Else
            total = seleccion.Cells(12).Value
        End If

        If seleccion.Cells(13).Value Is DBNull.Value Then
            obs = ""
        Else
            obs = seleccion.Cells(13).Value
        End If

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            ordenServicioDAO.setDBcmd()

            'No hay detalle guardado
            If codigoOrdenDetalle = -1 Then
                'Dim linea As Integer

                'If dgvDetalleOrdenServicio.Rows.Count > 0 Then
                '    Dim fila As Integer
                '    fila = dgvDetalleOrdenServicio.Rows.Count - 2 + 1
                '    linea = fila * 10000
                'Else
                '    linea = 10000
                'End If

                nroLinea = GetNroLinea(opcion)
                If precioUnitario <> -1 And cantidad <> -1 Then
                    subtotal = precioUnitario * cantidad
                    igv = 0.18 * subtotal
                    total = subtotal + igv
                End If
                'ordenServicioDAO.InsertOrdenServicioDetalle(codigoOrden, nroLinea, alto, ancho, largo, cantidad, precioUnitario,
                '                                    subtotal, igv, total, obs, tipoServicio)
                seleccion.Cells(0).Value = ordenServicioDAO.InsertOrdenServicioDetalle(codigoOrden, nroLinea, alto, ancho, largo, peso, cantidad, precioUnitario,
                                                    subtotal, igv, total, obs, tipoServicio)
                seleccion.Cells(1).Value = codigoOrden
                seleccion.Cells(2).Value = nroLinea
                If precioUnitario <> -1 And cantidad <> -1 Then
                    seleccion.Cells(10).Value = subtotal
                    seleccion.Cells(11).Value = igv
                    seleccion.Cells(12).Value = total
                End If
            Else 'Hay detalle guardado
                If precioUnitario <> -1 And cantidad <> -1 Then
                    subtotal = precioUnitario * cantidad
                    igv = 0.18 * subtotal
                    total = subtotal + igv
                End If
                ordenServicioDAO.UpdateOrdenServicioDetalle(codigoOrdenDetalle, codigoOrden, nroLinea, alto, ancho, largo, peso, cantidad, precioUnitario,
                                                    subtotal, igv, total, obs, tipoServicio)
                If precioUnitario <> -1 And cantidad <> -1 Then
                    seleccion.Cells(10).Value = subtotal
                    seleccion.Cells(11).Value = igv
                    seleccion.Cells(12).Value = total
                End If
            End If
            sqlControl.CommitTransaction()
        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error. SQL. " + ex.Message, "Grabar detalle",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error. " + ex.Message, "Grabar detalle",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            If sqlControl.GetDBcon.State = ConnectionState.Open Then
                sqlControl.CloseConexion()
            End If
        End Try
    End Sub
    Private Sub dgvDetalleOrdenServicio_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleOrdenServicio.CellEndEdit
        GrabarOrdenServicioDetalle(e.RowIndex, 0)
    End Sub

    Private Sub btnEliminarDetalle_Click(sender As Object, e As EventArgs) Handles btnEliminarDetalle.Click
        If dgvDetalleOrdenServicio.Rows.Count = 1 Then
            MessageBox.Show("Debe registrar un detalle. ", "Eliminar detalle",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation)
            Return
        End If
        EliminarOrdenServicioDetalle()
    End Sub

    Sub EliminarOrdenServicioDetalle()

        Dim seleccion As DataGridViewSelectedRowCollection = dgvDetalleOrdenServicio.SelectedRows
        If seleccion.Count = 0 Then
            MessageBox.Show("Seleccionar una fila para eliminar. ", "Eliminar detalle",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
            Return
        End If

        If seleccion.Count = 1 Then
            If seleccion(0).Index = dgvDetalleOrdenServicio.Rows.Count - 1 Then
                Return
            End If
        End If

        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()
        Dim ordenServicioDAO As New OrdenServicioDAO(sqlControl)

        For Each sel As DataGridViewRow In seleccion
            Try
                sqlControl.OpenConexion()
                sqlControl.BeginTransaction()
                ordenServicioDAO.setDBcmd()

                If sel.Cells(0).Value IsNot DBNull.Value Then
                    ordenServicioDAO.DeleteOrdenServicioDetalle(CType(sel.Cells(0).Value, Integer))
                    sqlControl.CommitTransaction()
                End If

            Catch ex As SqlException
                sqlControl.RollbackTransaccion()
                MessageBox.Show("Error. SQL. " + ex.Message, "Grabar detalle",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error. " + ex.Message, "Grabar detalle",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error)
            Finally
                If sqlControl.GetDBcon.State = ConnectionState.Open Then
                    sqlControl.CloseConexion()
                End If

            End Try
        Next
        For Each sel As DataGridViewRow In seleccion
            Console.WriteLine("morrando : " + sel.Index.ToString)
            If sel.Index <> dgvDetalleOrdenServicio.RowCount - 1 Then
                dgvDetalleOrdenServicio.Rows.Remove(sel)
            End If
        Next
    End Sub

    Private Sub dgvDetalleOrdenServicio_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDetalleOrdenServicio.RowHeaderMouseClick
        If e.Button.ToString = "Right" Then
            dgvDetalleOrdenServicio.Rows(e.RowIndex).Selected = True
            cmsDetalle.Show(dgvDetalleOrdenServicio, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub cmsDetalle_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles cmsDetalle.ItemClicked
        Dim opcion As String = e.ClickedItem.ToString

        Select Case opcion
            Case "Insertar Arriba"
                If dgvDetalleOrdenServicio.Rows.Count = 1 Then
                    MessageBox.Show("Debe registrar un detalle. ", "Insertar arriba",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation)
                    Return
                End If
                Dim seleccion As DataGridViewRow = dgvDetalleOrdenServicio.SelectedRows(0)
                Console.WriteLine("Ar " + seleccion.Index.ToString)
                InsertarOrdenServicioDetalle(seleccion.Index, 1)
            Case "Insertar Abajo"
                If dgvDetalleOrdenServicio.Rows.Count = 1 Then
                    MessageBox.Show("Debe registrar un detalle. ", "Insertar abajo",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation)
                    Return
                End If
                Dim seleccion As DataGridViewRow = dgvDetalleOrdenServicio.SelectedRows(0)
                Console.WriteLine("Ab " + seleccion.Index.ToString)

                InsertarOrdenServicioDetalle(seleccion.Index, 2)
            Case "Eliminar"
                If dgvDetalleOrdenServicio.Rows.Count = 1 Then
                    MessageBox.Show("Debe registrar un detalle. ", "Eliminar detalle",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation)
                    Return
                End If
                EliminarOrdenServicioDetalle()
        End Select

    End Sub

    Function GetNroLinea(opcion As Integer) As Integer

        Dim linea As Integer = 0

        Select Case opcion
            Case 0
                If dgvDetalleOrdenServicio.Rows.Count > 0 Then
                    Dim fila As Integer
                    fila = dgvDetalleOrdenServicio.Rows.Count - 2 + 1
                    linea = fila * 10000
                Else
                    linea = 10000
                End If
            Case 1
                Dim seleccion As DataGridViewRow = dgvDetalleOrdenServicio.SelectedRows(0)
                Dim nroLinea1 As Integer = seleccion.Cells(2).Value
                Dim nroLinea2 As Integer

                If seleccion.Index = 0 Then
                    linea = nroLinea1 / 2
                Else
                    nroLinea2 = dgvDetalleOrdenServicio.Rows(seleccion.Index - 1).Cells(2).Value
                    linea = (nroLinea1 + nroLinea2) / 2
                End If

            Case 2
                Dim seleccion As DataGridViewRow = dgvDetalleOrdenServicio.SelectedRows(0)
                Dim nroLinea1 As Integer = seleccion.Cells(2).Value
                Dim nroLinea2 As Integer

                If seleccion.Index = dgvDetalleOrdenServicio.Rows.Count - 2 Then
                    Dim fila As Integer
                    fila = dgvDetalleOrdenServicio.Rows.Count + 1
                    linea = fila * 10000
                Else
                    nroLinea2 = dgvDetalleOrdenServicio.Rows(seleccion.Index + 1).Cells(2).Value
                    linea = (nroLinea1 + nroLinea2) / 2
                End If
        End Select
        Return linea
    End Function

    Sub InsertarOrdenServicioDetalle(index As Integer, opcion As Integer)
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()
        Dim ordenServicioDAO As New OrdenServicioDAO(sqlControl)

        Dim seleccion As DataGridViewRow = dgvDetalleOrdenServicio.Rows(index)

        Dim codigoOrden As Integer

        If txtCodigo.Text <> "" Then
            codigoOrden = CType(txtCodigo.Text, Integer)
        Else
            MessageBox.Show("Debe registrar primero la cabecera de Orden de Servicio. ", "Grabar detalle",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation)
            Return
        End If

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            ordenServicioDAO.setDBcmd()

            'No hay detalle guardado
            Dim nroLinea As Integer
            nroLinea = GetNroLinea(opcion)

            Dim detalle As Integer = ordenServicioDAO.InsertOrdenServicioDetalle(codigoOrden, nroLinea, -1, -1,
                                                                                 -1, -1, -1, -1,
                                                                                    -1, -1, -1, "", -1)
            sqlControl.CommitTransaction()
        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error. SQL. " + ex.Message, "Grabar detalle",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error. " + ex.Message, "Grabar detalle",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error)
        Finally
            If sqlControl.GetDBcon.State = ConnectionState.Open Then
                sqlControl.CloseConexion()
                CargarDetalle(codigoOrden)
            End If
        End Try
    End Sub
End Class