Imports System.Data
Imports System.Data.SqlClient
Public Class OrdenServicioDAO
    Dim DBcon As SqlConnection
    Dim DBcmd As SqlCommand
    Dim sqlControl As SQLControl

    Public Sub New(sqlControl As SQLControl)
        Me.sqlControl = sqlControl
        Me.DBcon = sqlControl.GetDBcon
    End Sub

    Public Sub setDBcmd()
        Me.DBcmd = sqlControl.GetDBcmd
    End Sub

    Public Function openConexion() As Boolean
        Return sqlControl.OpenConexion()
    End Function

    Public Function closeConexion() As Boolean
        Return sqlControl.CloseConexion()
    End Function

    Public Sub beginTransaction()
        sqlControl.BeginTransaction()
    End Sub

    Public Sub commitTransacction()
        sqlControl.CommitTransaction()
    End Sub

    Public Sub rollbackTransaccion()
        sqlControl.RollbackTransaccion()
    End Sub

    Public Function GetAllOrdenServicio() As DataTable
        Return sqlControl.ExecQuery("select	a.CODIGO_ORDEN_SERVICIO 'Codigo Orden',
		                             convert(varchar(10),a.FECHA ,103) 'Fecha Orden',
		                             a.NUMERO 'Nro Orden',
		                             b.RAZON_CLIENTE 'Cliente',
		                             a.ORIGEN 'Origen',
		                             a.DESTINO 'Destino',
		                             c.DETALLE_MONEDA 'Moneda',
		                             'Incluye IGV' = CASE WHEN a.IGV_INCLUYE=0 THEN 'No' ELSE 'Si'END,
		                             a.SUBTOTAL 'Sub Total',
		                             a.IGV 'Monto IGV',
		                             a.TOTAL 'Total'
                                from    ORDEN_SERVICIO a
                                LEFT JOIN CLIENTE b ON a.CODIGO_CLIENTE = b.CODIGO_CLIENTE
                                LEFT JOIN MONEDA c ON a.CODIGO_MONEDA = c.CODIGO_MONEDA
                                order	by CODIGO_ORDEN_SERVICIO asc", Nothing)

    End Function

    Public Function InsertBanco(nombre As String, abreviatura As String) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@NOMBRE_BANCO", nombre))
        params.Add(New SqlParameter("@ABREVIATURA", abreviatura))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertBanco " +
                                        "@NOMBRE_BANCO," +
                                        "@ABREVIATURA ", params)
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                Return CInt(dt.Rows.Item(0).Item(0))
            Else
                Return -1
            End If
        Else
            Return -1
        End If

    End Function
    Public Function getOrdenServicioCombo() As DataTable
        Return sqlControl.ExecQuery("select	CODIGO_ORDEN_SERVICIO,
		                                    NUMERO
                                    from    ORDEN_SERVICIO 
                                    order	by CODIGO_ORDEN_SERVICIO asc", Nothing)
    End Function
    Public Function getDetalleOrdenServicios(codigoOrden As Integer) As DataTable

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_ORDEN", codigoOrden))

        Return sqlControl.ExecQuery("SELECT	a.CODIGO_ORDEN_SERVICIO_DETALLE,
		                                    b.DETALLE_ESTADO
                                     FROM ORDEN_SERVICIO_DETALLE a
                                     LEFT JOIN ESTADO b ON a.CODIGO_TIPO_SERVICIO = b.CODIGO_ESTADO
                                     WHERE a.CODIGO_ORDEN_SERVICIO = @CODIGO_ORDEN", params)

    End Function

    Public Function getDatosDetalleOrden(codigoDetalleOrden As Integer) As DataTable

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_ORDEN", codigoDetalleOrden))

        Return sqlControl.ExecQuery("SELECT  b.DETALLE_ESTADO 'TIPO_SERVICIO',
		                                     a.ALTO_CARGA 'ALTO',
		                                     a.ANCHO_CARGA 'ANCHO',
		                                     a.LARGO_CARGA 'LARGO',
		                                     a.PESO_CARGA 'PESO',
		                                     a.OBSERVACION_DETALLE_SERVICIO 'OBSERVACION'
                                    FROM ORDEN_SERVICIO_DETALLE a
                                    LEFT JOIN ESTADO b ON a.CODIGO_TIPO_SERVICIO = b.CODIGO_ESTADO
                                    WHERE a.CODIGO_ORDEN_SERVICIO_DETALLE = @CODIGO_DETALLE_ORDEN", params)

    End Function

End Class
