Public Class ChildFacturaLibre
    Dim gvDetalle As New DataGridView
    Dim data As DataTable
    Dim correlativoFactura As String


    Dim codigo_Factura As Integer = -1
    Private Sub btnRazonSocial_Click(sender As Object, e As EventArgs) Handles btnRazonSocial.Click
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
        actualizarDatosCliente()
        actualizarDatosMoneda()
        txtNroSerie.Text = "001"
        txtNroSerie.ReadOnly = True
        ObtenerCorrelativo()

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

    Private Sub btnGuardarCabecera_Click(sender As Object, e As EventArgs) Handles btnGuardarCabecera.Click
        GuardarCabeceraFactura()

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
                                         CType(0, Long),
                                         CType(cbMoneda.SelectedValue, Integer),
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

End Class