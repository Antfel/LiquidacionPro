Imports System.Data.SqlClient
Imports Npgsql

Public Class ModuloComunicacionBD
    Private Sub btnActualizarFacturas_Click(sender As Object, e As EventArgs) Handles btnActualizarFacturas.Click

        Dim dt As DataTable = getNroFacturasByActualizado(0)

        Dim nroFacturas As String = ""

        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    nroFacturas += "'" + row.Item(0) + "',"
                Next row
            End If
        End If

        If nroFacturas <> "" Then
            nroFacturas = nroFacturas.Substring(0, nroFacturas.Length - 1)

            Dim dt2 As DataTable = getDatosVentaPgSQL(nroFacturas)
            Dim queryBatch As String = ""
            If dt2 IsNot Nothing Then
                For Each row As DataRow In dt2.Rows
                    queryBatch += "update	FACTURA 
                                    set		ID_VENTA='" + row.Item(0) + "',
		                                    SERIE_DOCUMENTO='" + row.Item(1) + "',
		                                    CORRELATIVO_DOCUMENTO='" + row.Item(2) + "',
		                                    TIPO_CAMBIO=" + row.Item(3).ToString + ",
		                                    FECHA_VENCIMIENTO=cast( '" + row.Item(9).ToString + "' as datetime),
		                                    AFECTA_DETRACCION=" + row.Item(7).ToString + ",
		                                    PORCENTAJE_DETRACCION=" + row.Item(8).ToString + ",
                                            MONTO_DETRACCION=" + CStr((Double.Parse(row.Item(8)) / 100 * Double.Parse(row.Item(10)))) + "
                                    where	CODIGO_ESTADO=16 
                                    AND		'0'+SERIE_FACTURA+'-'+substring(NUMERO_FACTURA,3,10)='" + row.Item(1) + "-" + row.Item(2) + "'
                                     "
                Next

                If queryBatch <> "" Then
                    Dim dt3 As DataTable = ejecutarQueryBatch(queryBatch)
                    If dt3 IsNot Nothing Then
                        MessageBox.Show("Trabajo culminado.", "Actualizar Facturas",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No se ejecutaron comandos.", "Actualizar Facturas",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                    End If
                End If

            End If
        End If


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
                dt = facturacionDao.EjecutarQueryBatch(queryBatch)
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

    Public Function getNroFacturasByActualizado(actualizado As Integer) As DataTable
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()
        Dim dt As DataTable = Nothing
        Dim facturacionDao As New FacturacionDAO(sqlControl)
        Try
            If sqlControl.OpenConexion() Then
                sqlControl.BeginTransaction()
                facturacionDao.SetDBcmd()
                dt = facturacionDao.GetNroFacturasByActualizado(actualizado)
                sqlControl.CommitTransaction()
            End If

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error SQL. " + ex.Message, "getNroFacturasByActualizado",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error. " + ex.Message, "getNroFacturasByActualizado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                If sqlControl.GetDBcon.State = ConnectionState.Open Then
                    sqlControl.CloseConexion()
                End If
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. ", "getNroFacturasByActualizados",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try
        Return dt
    End Function

    Public Function getDatosVentaPgSQL(nroFacturas As String) As DataTable
        Dim sqlControlPostgres As New SQLControlPostgres
        sqlControlPostgres.SetConnection()
        Dim dt As DataTable = Nothing
        Dim rutinas As New RutinasPostgreSQL(sqlControlPostgres)
        Try
            If (sqlControlPostgres.OpenConexion()) Then
                dt = rutinas.GetDatosVentasByNroFacturas(nroFacturas)
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
End Class