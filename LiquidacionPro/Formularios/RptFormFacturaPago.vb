﻿Imports System.Data.SqlClient
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

        Try
            periodo = txtPeriodo.Text
        Catch ex As Exception
            MessageBox.Show("Ingresar Periodo válido.", "Cargar Reporte",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End Try



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

        Try
            cargarReporte(mes, periodo, opcion, cliente)
        Catch ex As SqlException
            MessageBox.Show("Error al verificar datos en los pagos. SQL. " + ex.Message, "Validación",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al verificar datos en los pagos. " + ex.Message, "Validación",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error)
        End Try


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
            paramList.Add(New ReportParameter("mes", mes, True))
        End If

        paramList.Add(New ReportParameter("periodo", txtPeriodo.Text, True))

        If cliente = -1 Then
            paramList.Add(New ReportParameter("cliente", " ", True))
        Else
            Dim drv As DataRowView = cbCliente.SelectedItem
            paramList.Add(New ReportParameter("cliente", drv.Item(2).ToString, True))
        End If

        Dim dt As DataTable = GetReporte(mes, periodo, opcion, cliente)

        ReportViewer1.Reset()
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "Formularios/Reportes/RptFacturaVsAbono.rdlc"
        ReportViewer1.Refresh()

        ReportViewer1.LocalReport.SetParameters(paramList)
        Dim rds As New ReportDataSource("DataSet1", dt)
        ReportViewer1.LocalReport.DataSources.Add(rds)
        'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf subReporteLiquidacionFacturacionDetalle

        ReportViewer1.RefreshReport()
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

    Public Function GetFacturasPagosAll() As DataTable
        Dim sqlControlPostgres As New SQLControlPostgres
        sqlControlPostgres.SetConnection()
        Dim dt As DataTable = Nothing
        Dim rutinas As New RutinasPostgreSQL(sqlControlPostgres)
        Try
            If (sqlControlPostgres.OpenConexion()) Then
                dt = rutinas.GetFacturasPagosAll
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

    Public Function LimpiarFacturaAbonoAll() As Integer
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()
        Dim flag As Integer = -1
        Dim facturacionDao As New FacturacionDAO(sqlControl)

        Try
            If sqlControl.OpenConexion() Then
                sqlControl.BeginTransaction()
                facturacionDao.SetDBcmd()
                'facturacionDao.SetLimpiarFacturasByMesPeriodo(mes, periodo)
                'facturacionDao.SetLimpiarNotasCreditoAll()
                facturacionDao.LimpiarFacturaAbonoAll()
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
        CargarFechaACtualizacion()
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
                dt = facturacionDao.GetRptFacturaVsAbono(mes, periodo, opcion, cliente)
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

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        'Pase de información
        Dim limpiaFacturas As Integer
        'Limpiando los pagos anteriores del Mes y Periodo, y todas las notas de crédito
        limpiaFacturas = LimpiarFacturaAbonoAll()

        'Resultado exitoso
        If limpiaFacturas = 1 Then
            Dim dt As DataTable = Nothing
            Dim queryBatch As String = ""

            'Se obtiene del sistema contable, todos los pagos realizados de las facturas en el periodo indicado
            dt = GetFacturasPagosAll()

            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    For Each row As DataRow In dt.Rows

                        'Se arma un query para insertar todos los pagos por factura en el periodo indicado
                        queryBatch += "insert into FACTURA_ABONO 
                                        (RUC,
                                        RAZON_SOCIAL,
                                        NRO_DOCUMENTO,
                                        DEBE_SOLES,
                                        HABER_SOLES,
                                        DEBE_DOLARES,
                                        HABER_DOLARES)
                                        values
                                        ('" + row.Item(0).ToString + "',
                                         '" + row.Item(1).ToString.Replace("'", "''") + "',
                                         '" + row.Item(2).ToString + "',
                                         " + row.Item(3).ToString + ",
                                         " + row.Item(4).ToString + ",
                                         " + row.Item(5).ToString + ",
                                         " + row.Item(6).ToString + ") "
                    Next

                    If queryBatch <> "" Then
                        Dim dt2 As DataTable = ejecutarQueryBatch(queryBatch)
                        If dt2 IsNot Nothing Then
                            ActualizarFecha()
                            MessageBox.Show("Actualizado con éxito. ", "Actualización",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information)
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

    Sub CargarFechaActualizacion()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()
        Dim dt As DataTable = Nothing
        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Dim fecha As Date
        fecha = Date.Now
        Dim usuario As String
        usuario = ""
        Try
            If sqlControl.OpenConexion() Then
                sqlControl.BeginTransaction()
                facturacionDao.SetDBcmd()
                dt = facturacionDao.GetUltimaFechaActualizacion()
                sqlControl.CommitTransaction()
                If dt IsNot Nothing Then
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0)(0) IsNot DBNull.Value Then
                            lblActualizado.Text = CType(dt.Rows(0)(0), Date).ToString("dd/MM/yyyy hh:mm:ss")
                        Else
                            lblActualizado.Text = "No actualizado"
                        End If

                    End If
                Else
                    lblActualizado.Text = "No actualizado"
                End If
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
    End Sub
    Sub ActualizarFecha()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()
        Dim flag As Integer = -1
        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Dim fecha As Date
        fecha = Date.Now
        Dim usuario As String
        usuario = ""
        Try
            If sqlControl.OpenConexion() Then
                sqlControl.BeginTransaction()
                facturacionDao.SetDBcmd()
                flag = facturacionDao.InsertFacturaAbonoActualizacion(usuario, fecha)
                sqlControl.CommitTransaction()
                If flag > 0 Then
                    lblActualizado.Text = fecha.ToString("dd/MM/yyyy hh:mm:ss")
                Else

                End If
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
    End Sub
End Class