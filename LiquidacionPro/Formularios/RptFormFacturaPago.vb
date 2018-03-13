Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports Npgsql
Public Class RptFormFacturaPago
    Private Sub btnVerificarPeriodo_Click(sender As Object, e As EventArgs) Handles btnVerificarPeriodo.Click

        Dim mes, periodo As String
        Dim opcion, cliente As Integer

        If cbMes.SelectedIndex < 0 Then
            mes = ""
        Else
            mes = cbMes.SelectedValue
        End If

        If txtPeriodo.Text = Nothing Then
            MessageBox.Show("Seleccionar Periodo", "Cargar Reporte",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If

        periodo = txtPeriodo.Text

        If rbtn1.Checked = True Then
            opcion = 0
        ElseIf rbtn2.Checked = True Then
            opcion = 1
        ElseIf rbtn3.Checked = True Then
            opcion = 2
        ElseIf rbtn4.Checked = True Then
            opcion = 3
        End If

        If cbCliente.SelectedIndex < 0 Then
            cliente = -1
        Else
            cliente = cbCliente.SelectedValue
        End If

        Dim limpiaFacturas As Integer
        'Limpiando los pagos anteriores del Mes y Periodo
        limpiaFacturas = SetLimpiarFacturasByMesPeriodo(mes, periodo)

        'Resultado exitoso
        If limpiaFacturas = 1 Then
            Dim dt As DataTable = Nothing
            Dim queryBatch As String = ""

            'Se obtiene del sistema contable, todos los pagos realizados de las facturas en el periodo indicado
            dt = GetFacturasPagoByMesPeriodo(mes, periodo)
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    For Each row As DataRow In dt.Rows

                        'Se arma un query para insertar todos los pagos por factura en el periodo indicado
                        queryBatch += "insert into FACTURA_PAGO
                                        (IMPORTE,
                                        CAMBIO,
                                        MONEDA,
                                        TIPO_CAMBIO,
                                        NRO_DOCUMENTO,
                                        PERIODO,
                                        MES,
                                        FECHA_PAGO,
                                        NOMBRE,
                                        TIPO_CAMBIO_VENTA,
                                        MONEDA_VENTA,
                                        PERIODO_VENTA,
                                        MES_VENTA,
                                        FECHA_VENTA)
                                        values
                                        (" + row.Item(3).ToString + ",
                                         " + row.Item(4).ToString + ",
                                         " + row.Item(5).ToString + ",
                                         " + row.Item(6).ToString + ",
                                         '" + row.Item(7).ToString + "',
                                         '" + row.Item(8).ToString + "',
                                         '" + row.Item(9).ToString + "',
                                         cast('" + row.Item(10).ToString + "' as datetime),
                                         '" + row.Item(12).ToString + "',
                                         " + row.Item(13).ToString + ",
                                         " + row.Item(14).ToString + ",
                                         '" + row.Item(15).ToString + "',
                                         '" + row.Item(16).ToString + "',
                                         cast('" + row.Item(17).ToString + "' as datetime) )"
                    Next

                    If queryBatch <> "" Then
                        Dim dt2 As DataTable = ejecutarQueryBatch(queryBatch)
                        If dt2 IsNot Nothing Then
                            queryBatch = "  UPDATE
                                                Table_A 
                                            SET 
                                                Table_A.TIPO_CAMBIO = Table_B.TIPO_CAMBIO_VENTA, 
	                                            Table_A.ID_MONEDA = Table_B.MONEDA_VENTA 
                                            FROM 
                                                FACTURA AS Table_A 
                                                INNER JOIN (select	distinct 
						                                            NRO_DOCUMENTO,
						                                            TIPO_CAMBIO_VENTA,
						                                            MONEDA_VENTA  
				                                            from	FACTURA_PAGO) AS Table_B 
                                                    ON Table_A.NRO_DOCUMENTO = Table_B.NRO_DOCUMENTO 
                                            where Table_A.CODIGO_ESTADO=16 "
                            dt2 = ejecutarQueryBatch(queryBatch)

                            If dt2 IsNot Nothing Then
                                cargarReporte(mes, periodo, opcion, cliente)
                            End If
                        Else
                            MessageBox.Show("No se ejecutaron comandos.", "Actualizar Facturas",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                        End If
                    End If

                End If
            End If
        Else
            MessageBox.Show("Error al verificar datos en los pagos. ", "Verificar Periodo",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error)
        End If
    End Sub

    Sub cargarReporte(mes As String, periodo As String, opcion As Integer, cliente As Integer)

        Dim paramList As New List(Of ReportParameter)

        If rbtn1.Checked = True Then
            paramList.Add(New ReportParameter("opcion", "Mostrar todo", True))
        ElseIf rbtn2.Checked = True Then
            paramList.Add(New ReportParameter("opcion", "Saldo a favor", True))
        ElseIf rbtn3.Checked = True Then
            paramList.Add(New ReportParameter("opcion", "Saldo en contra", True))
        ElseIf rbtn4.Checked = True Then
            paramList.Add(New ReportParameter("opcion", "Cancelado", True))
        End If

        If cbMes.SelectedIndex < 0 Then
            paramList.Add(New ReportParameter("mes", "Todos", True))
        Else
            paramList.Add(New ReportParameter("mes", cbMes.SelectedItem.ToString, True))
        End If

        paramList.Add(New ReportParameter("periodo", txtPeriodo.Text, True))

        If cliente = -1 Then
            paramList.Add(New ReportParameter("cliente", " ", True))
        Else
            paramList.Add(New ReportParameter("cliente", cbCliente.SelectedItem.ToString, True))
        End If

        Dim dt As DataTable = GetReporte(mes, periodo, opcion, cliente)

        ReportViewer1.Reset()
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "Formularios/Reportes/RptFacturaVsPago.rdlc"
        ReportViewer1.Refresh()



        ReportViewer1.LocalReport.SetParameters(paramList)
        Dim rds As New ReportDataSource("DataSet1", dt)
        ReportViewer1.LocalReport.DataSources.Add(rds)
        'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf subReporteLiquidacionFacturacionDetalle

        ReportViewer1.RefreshReport()

        'MessageBox.Show("Trabajo culminado.", "Actualizar Facturas",
        '                             MessageBoxButtons.OK,
        '                             MessageBoxIcon.Information)
    End Sub
    Public Function ejecutarQueryBatch(queryBatch As String) As DataTable
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()
        Dim dt As DataTable = Nothing
        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Try
            If sqlControl.OpenConexion() Then
                sqlControl.BeginTransaction()
                facturacionDao.SetDBcmd()
                dt = sqlControl.ExecQuery(queryBatch, Nothing)
                sqlControl.CommitTransaction()
            End If


        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error SQL. " + ex.Message, "ejecutarQueryBatch",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error. " + ex.Message, "ejecutarQueryBatch",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()

            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. ", "ejecutarQueryBatch",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try
        Return dt
    End Function

    Public Function GetFacturasPagoByMesPeriodo(mes As String, periodo As String) As DataTable
        Dim sqlControlPostgres As New SQLControlPostgres
        sqlControlPostgres.SetConnection()
        Dim dt As DataTable = Nothing
        Dim rutinas As New RutinasPostgreSQL(sqlControlPostgres)
        Try
            If (sqlControlPostgres.OpenConexion()) Then
                dt = rutinas.GetFacturasPagoByMesPeriodo(mes, periodo)
            End If

        Catch ex As NpgsqlException
            MessageBox.Show("Error SQL. " + ex.Message, "GetFacturasPagoByMesPeriodo",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error. " + ex.Message, "GetFacturasPagoByMesPeriodo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                If sqlControlPostgres.GetDBcon.State = ConnectionState.Open Then
                    sqlControlPostgres.CloseConexion()
                End If

            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. ", "GetFacturasPagoByMesPeriodo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try
        Return dt
    End Function

    Public Function SetLimpiarFacturasByMesPeriodo(mes As String, periodo As String) As Integer
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()
        Dim flag As Integer = -1
        Dim facturacionDao As New FacturacionDAO(sqlControl)

        Try
            If sqlControl.OpenConexion() Then
                sqlControl.BeginTransaction()
                facturacionDao.SetDBcmd()
                facturacionDao.SetLimpiarFacturasByMesPeriodo(mes, periodo)
                sqlControl.CommitTransaction()
                flag = 1
            End If

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error SQL. " + ex.Message, "SetLimpiarFacturasByMesPeriodo",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error. " + ex.Message, "SetLimpiarFacturasByMesPeriodo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                If sqlControl.GetDBcon.State = ConnectionState.Open Then
                    sqlControl.CloseConexion()
                End If
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. ", "SetLimpiarFacturasByMesPeriodo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try
        Return flag
    End Function

    Public Function GetFacturasPagoByMesPeriodoPgSQL(mes As String, periodo As String) As DataTable
        Dim sqlControlPostgres As New SQLControlPostgres
        sqlControlPostgres.SetConnection()
        Dim dt As DataTable = Nothing
        Dim rutinas As New RutinasPostgreSQL(sqlControlPostgres)
        Try
            If (sqlControlPostgres.OpenConexion()) Then
                dt = rutinas.GetFacturasPagoByMesPeriodo(mes, periodo)
            End If

        Catch ex As NpgsqlException
            MessageBox.Show("Error SQL. " + ex.Message, "getDatosVentaPgSQL",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error. " + ex.Message, "getDatosVentaPgSQL",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                If sqlControlPostgres.GetDBcon.State = ConnectionState.Open Then
                    sqlControlPostgres.CloseConexion()
                End If

            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. ", "getDatosVentaPgSQL",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try
        Return dt
    End Function

    Private Sub RptFormFacturaPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarMes()
        cargarClientes()
        txtPeriodo.Text = Date.Now.Year.ToString
    End Sub

    Sub cargarClientes()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim clienteDao As New ClienteDAO(sqlControl)

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()

            clienteDao.setDBcmd()

            Dim dtCliente As DataTable
            dtCliente = clienteDao.GetClientes
            sqlControl.CommitTransaction()

            With cbCliente
                .DataSource = dtCliente
                .DisplayMember = "RAZON_CLIENTE"
                .ValueMember = "CODIGO_CLIENTE"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1

            End With


        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar cliente. " + ex.Message, "Cargar datos de cliente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Catch ex As Exception
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
    Sub cargarMes()
        With cbMes
            .DataSource = GetMeses("2018")
            .ValueMember = "MES"
            .DisplayMember = "NOMBRE"
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub RptFormFacturaPago_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim tamX, tamY As Integer
        tamX = Me.Size.Width
        tamY = Me.Size.Height

        Dim tam As New Size(tamX - 18, tamY - 125)
        ReportViewer1.Size = tam
    End Sub

    Public Function GetMeses(periodo As String) As DataTable
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()
        Dim dt As DataTable = Nothing
        Dim facturacionDao As New FacturacionDAO(sqlControl)

        Try
            If sqlControl.OpenConexion() Then
                sqlControl.BeginTransaction()
                facturacionDao.SetDBcmd()
                dt = facturacionDao.GetMesPeriodoDescripcion(periodo)
                sqlControl.CommitTransaction()
            End If

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error SQL. " + ex.Message, "GetMeses",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error. " + ex.Message, "GetMeses",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                If sqlControl.GetDBcon.State = ConnectionState.Open Then
                    sqlControl.CloseConexion()
                End If
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. ", "GetMeses",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try
        Return dt
    End Function

    Public Function GetReporte(mes As String, periodo As String, opcion As Integer, cliente As Integer) As DataTable
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()
        Dim dt As DataTable = Nothing
        Dim facturacionDao As New FacturacionDAO(sqlControl)

        Try
            If sqlControl.OpenConexion() Then
                sqlControl.BeginTransaction()
                facturacionDao.SetDBcmd()
                dt = facturacionDao.GetRptFacturaVsPago(mes, periodo, opcion, cliente)
                sqlControl.CommitTransaction()
            End If

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error SQL. " + ex.Message, "GetReporte",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error. " + ex.Message, "GetReporte",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                If sqlControl.GetDBcon.State = ConnectionState.Open Then
                    sqlControl.CloseConexion()
                End If
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. ", "GetReporte",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try
        Return dt
    End Function

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cbCliente.SelectedIndex = -1
        cbMes.SelectedIndex = -1
        txtPeriodo.Text = Date.Now.Year.ToString
        rbtn1.Checked = True

    End Sub
End Class