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
        Return sqlControl.ExecQuery("select	a.CODIGO_ORDEN_SERVICIO 'Código',
		                             a.FECHA 'Fecha',
		                             a.NUMERO 'Nro. Orden',
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
                                order	by a.FECHA desc", Nothing)

    End Function

    Public Function GetOrdenServicioByCodigo(codigo As Integer) As DataTable

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_ORDEN_SERVICIO", codigo))

        Return sqlControl.ExecQuery("select	a.CODIGO_ORDEN_SERVICIO 'Código',
		                                    a.NUMERO 'Nro. Orden',
		                                    a.FECHA 'Fecha',
		                                    a.CODIGO_CLIENTE 'Cliente',
		                                    a.ORIGEN 'Origen',
		                                    a.DESTINO 'Destino',
		                                    a.CODIGO_MONEDA 'Moneda',
		                                    a.IGV_INCLUYE,
		                                    a.SUBTOTAL 'Sub Total',
		                                    a.IGV 'Monto IGV',
		                                    a.TOTAL 'Total' 
                                    from    ORDEN_SERVICIO a
                                    where a.CODIGO_ORDEN_SERVICIO=@CODIGO_ORDEN_SERVICIO", params)

    End Function

    Public Function InsertOrdenServicio(fecha As Date, numero As String, igvIncluye As Integer,
                                        subtotal As Double, igv As Double, total As Double,
                                        origen As String, destino As String, cliente As Integer,
                                        moneda As Integer) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@FECHA", fecha))
        params.Add(New SqlParameter("@NUMERO", numero))
        params.Add(New SqlParameter("@IGV_INCLUYE", igvIncluye))
        params.Add(New SqlParameter("@SUBTOTAL", subtotal))
        params.Add(New SqlParameter("@IGV", igv))
        params.Add(New SqlParameter("@TOTAL", total))
        params.Add(New SqlParameter("@ORIGEN", origen))
        params.Add(New SqlParameter("@DESTINO", destino))
        params.Add(New SqlParameter("@CODIGO_CLIENTE", cliente))
        params.Add(New SqlParameter("@CODIGO_MONEDA", moneda))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertOrdenServicio " +
                                        "@FECHA," +
                                        "@NUMERO, " +
                                        "@IGV_INCLUYE, " +
                                        "@SUBTOTAL, " +
                                        "@IGV, " +
                                        "@TOTAL, " +
                                        "@ORIGEN, " +
                                        "@DESTINO, " +
                                        "@CODIGO_CLIENTE, " +
                                        "@CODIGO_MONEDA ", params)
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

    Public Function UpdateOrdenServicio(codigo As Integer, fecha As Date, numero As String, igvIncluye As Integer,
                                        subtotal As Double, igv As Double, total As Double,
                                        origen As String, destino As String, cliente As Integer,
                                        moneda As Integer) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_ORDEN_SERVICIO", codigo))
        params.Add(New SqlParameter("@FECHA", fecha))
        params.Add(New SqlParameter("@NUMERO", numero))
        params.Add(New SqlParameter("@IGV_INCLUYE", igvIncluye))
        params.Add(New SqlParameter("@SUBTOTAL", subtotal))
        params.Add(New SqlParameter("@IGV", igv))
        params.Add(New SqlParameter("@TOTAL", total))
        params.Add(New SqlParameter("@ORIGEN", origen))
        params.Add(New SqlParameter("@DESTINO", destino))
        params.Add(New SqlParameter("@CODIGO_CLIENTE", cliente))
        params.Add(New SqlParameter("@CODIGO_MONEDA", moneda))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateOrdenServicio " +
                                        "@CODIGO_ORDEN_SERVICIO," +
                                        "@FECHA," +
                                        "@NUMERO, " +
                                        "@IGV_INCLUYE, " +
                                        "@SUBTOTAL, " +
                                        "@IGV, " +
                                        "@TOTAL, " +
                                        "@ORIGEN, " +
                                        "@DESTINO, " +
                                        "@CODIGO_CLIENTE, " +
                                        "@CODIGO_MONEDA ", params)
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

    Public Function GetDetalleOrdenServicioByCodigoOrdenServicio(codigoOrden As Integer) As DataTable

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_ORDEN", codigoOrden))

        Return sqlControl.ExecQuery("SELECT	CODIGO_ORDEN_SERVICIO_DETALLE,
		                                    CODIGO_ORDEN_SERVICIO,
		                                    NRO_LINEA,
                                            CODIGO_TIPO_SERVICIO 'Tipo Servicio',
		                                    ALTO_CARGA 'Alto',
		                                    ANCHO_CARGA 'Ancho',
		                                    LARGO_CARGA 'Largo',
		                                    PESO_CARGA 'Peso',
		                                    CANTIDAD 'Cant.',
		                                    PRECIO_UNITARIO 'P. Unitario',
		                                    SUBTOTAL Subtotal,
		                                    IGV 'Igv',
		                                    TOTAL 'Total',
		                                    OBSERVACION_DETALLE_SERVICIO 'Observación' 
                                    FROM	ORDEN_SERVICIO_DETALLE a
                                    WHERE	a.CODIGO_ORDEN_SERVICIO = @CODIGO_ORDEN 
                                    ORDER   BY NRO_LINEA ASC", params)

    End Function

    Public Function InsertOrdenServicioDetalle(codigoOrden As Integer, nroLinea As Integer, alto As Double,
                                               ancho As Double, largo As Double, peso As Double, cantidad As Double, precioUnitario As Double,
                                               subtotal As Double, igv As Double, total As Double, obs As String,
                                               tipoServicio As Integer) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_ORDEN_SERVICIO", codigoOrden))
        params.Add(New SqlParameter("@NRO_LINEA", nroLinea))
        If alto = -1 Then
            params.Add(New SqlParameter("@ALTO_CARGA", DBNull.Value))
        Else

            params.Add(New SqlParameter("@ALTO_CARGA", alto))
        End If

        If ancho = -1 Then
            params.Add(New SqlParameter("@ANCHO_CARGA", DBNull.Value))
        Else
            params.Add(New SqlParameter("@ANCHO_CARGA", ancho))
        End If

        If largo = -1 Then
            params.Add(New SqlParameter("@LARGO_CARGA", DBNull.Value))
        Else
            params.Add(New SqlParameter("@LARGO_CARGA", largo))
        End If

        If peso = -1 Then
            params.Add(New SqlParameter("@PESO_CARGA", DBNull.Value))
        Else
            params.Add(New SqlParameter("@PESO_CARGA", peso))
        End If

        If cantidad = -1 Then
            params.Add(New SqlParameter("@CANTIDAD", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CANTIDAD", cantidad))
        End If

        If precioUnitario = -1 Then
            params.Add(New SqlParameter("@PRECIO_UNITARIO", DBNull.Value))
        Else
            params.Add(New SqlParameter("@PRECIO_UNITARIO", precioUnitario))
        End If

        If subtotal = -1 Then
            params.Add(New SqlParameter("@SUBTOTAL", DBNull.Value))
        Else
            params.Add(New SqlParameter("@SUBTOTAL", subtotal))
        End If

        If igv = -1 Then
            params.Add(New SqlParameter("@IGV", DBNull.Value))
        Else
            params.Add(New SqlParameter("@IGV", igv))
        End If

        If total = -1 Then
            params.Add(New SqlParameter("@TOTAL", DBNull.Value))
        Else
            params.Add(New SqlParameter("@TOTAL", total))
        End If

        If obs = "" Then
            params.Add(New SqlParameter("@OBSERVACION_DETALLE_SERVICIO", DBNull.Value))
        Else
            params.Add(New SqlParameter("@OBSERVACION_DETALLE_SERVICIO", obs))
        End If

        If tipoServicio = -1 Then
            params.Add(New SqlParameter("@CODIGO_TIPO_SERVICIO", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CODIGO_TIPO_SERVICIO", tipoServicio))
        End If

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertOrdenServicioDetalle " +
                                        "@CODIGO_ORDEN_SERVICIO," +
                                        "@NRO_LINEA, " +
                                        "@ALTO_CARGA, " +
                                        "@ANCHO_CARGA, " +
                                        "@LARGO_CARGA, " +
                                        "@PESO_CARGA, " +
                                        "@CANTIDAD, " +
                                        "@PRECIO_UNITARIO, " +
                                        "@SUBTOTAL, " +
                                        "@IGV, " +
                                        "@TOTAL, " +
                                        "@OBSERVACION_DETALLE_SERVICIO, " +
                                        "@CODIGO_TIPO_SERVICIO ", params)
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

    Public Function UpdateOrdenServicioDetalle(codigoDetalle As Integer, codigoOrden As Integer, nroLinea As Integer, alto As Double,
                                               ancho As Double, largo As Double, peso As Double, cantidad As Double, precioUnitario As Double,
                                               subtotal As Double, igv As Double, total As Double, obs As String,
                                               tipoServicio As Integer) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_ORDEN_SERVICIO_DETALLE", codigoDetalle))
        params.Add(New SqlParameter("@CODIGO_ORDEN_SERVICIO", codigoOrden))
        params.Add(New SqlParameter("@NRO_LINEA", nroLinea))

        If alto = -1 Then
            params.Add(New SqlParameter("@ALTO_CARGA", DBNull.Value))
        Else

            params.Add(New SqlParameter("@ALTO_CARGA", alto))
        End If

        If ancho = -1 Then
            params.Add(New SqlParameter("@ANCHO_CARGA", DBNull.Value))
        Else
            params.Add(New SqlParameter("@ANCHO_CARGA", ancho))
        End If

        If largo = -1 Then
            params.Add(New SqlParameter("@LARGO_CARGA", DBNull.Value))
        Else
            params.Add(New SqlParameter("@LARGO_CARGA", largo))
        End If

        If peso = -1 Then
            params.Add(New SqlParameter("@PESO_CARGA", DBNull.Value))
        Else
            params.Add(New SqlParameter("@PESO_CARGA", peso))
        End If

        If cantidad = -1 Then
            params.Add(New SqlParameter("@CANTIDAD", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CANTIDAD", cantidad))
        End If

        If precioUnitario = -1 Then
            params.Add(New SqlParameter("@PRECIO_UNITARIO", DBNull.Value))
        Else
            params.Add(New SqlParameter("@PRECIO_UNITARIO", precioUnitario))
        End If

        If subtotal = -1 Then
            params.Add(New SqlParameter("@SUBTOTAL", DBNull.Value))
        Else
            params.Add(New SqlParameter("@SUBTOTAL", subtotal))
        End If

        If igv = -1 Then
            params.Add(New SqlParameter("@IGV", DBNull.Value))
        Else
            params.Add(New SqlParameter("@IGV", igv))
        End If

        If total = -1 Then
            params.Add(New SqlParameter("@TOTAL", DBNull.Value))
        Else
            params.Add(New SqlParameter("@TOTAL", total))
        End If

        If obs = "" Then
            params.Add(New SqlParameter("@OBSERVACION_DETALLE_SERVICIO", DBNull.Value))
        Else
            params.Add(New SqlParameter("@OBSERVACION_DETALLE_SERVICIO", obs))
        End If

        If tipoServicio = -1 Then
            params.Add(New SqlParameter("@CODIGO_TIPO_SERVICIO", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CODIGO_TIPO_SERVICIO", tipoServicio))
        End If

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateOrdenServicioDetalle " +
                                        "@CODIGO_ORDEN_SERVICIO_DETALLE," +
                                        "@CODIGO_ORDEN_SERVICIO," +
                                        "@NRO_LINEA, " +
                                        "@ALTO_CARGA, " +
                                        "@ANCHO_CARGA, " +
                                        "@LARGO_CARGA, " +
                                        "@PESO_CARGA, " +
                                        "@CANTIDAD, " +
                                        "@PRECIO_UNITARIO, " +
                                        "@SUBTOTAL, " +
                                        "@IGV, " +
                                        "@TOTAL, " +
                                        "@OBSERVACION_DETALLE_SERVICIO, " +
                                        "@CODIGO_TIPO_SERVICIO ", params)
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

    Public Function DeleteOrdenServicioDetalle(codigoDetalle As Integer) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_ORDEN_SERVICIO_DETALLE", codigoDetalle))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE deleteOrdenServicioDetalle 
                                            @CODIGO_ORDEN_SERVICIO_DETALLE ", params)
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
End Class
