Imports System.Data
Imports System.Data.SqlClient
Public Class FacturacionDAO
    Dim DBcon As New SqlConnection
    Dim DBcmd As SqlCommand
    Dim sqlControl As SQLControl

    Public Sub New(sqlControl As SQLControl)
        Me.sqlControl = sqlControl
        Me.DBcon = sqlControl.getDBcon
    End Sub

    Public Sub setDBcmd()
        Me.DBcmd = sqlControl.getDBcmd
    End Sub

    Public Function openConexion() As Boolean
        Return sqlControl.openConexion()
    End Function

    Public Function closeConexion() As Boolean
        Return sqlControl.closeConexion()
    End Function

    Public Sub beginTransaction()
        sqlControl.beginTransaction()
    End Sub

    Public Sub commitTransacction()
        sqlControl.commitTransaction()
    End Sub

    Public Sub rollbackTransaccion()
        sqlControl.rollbackTransaccion()
    End Sub

    Public Function getAllFacturas() As DataTable

        Return sqlControl.ExecQuery("select		a.CODIGO_FACTURA, 
	                                            a.SERIE_FACTURA, 
	                                            a.NUMERO_FACTURA,
	                                            b.RUC_CLIENTE,
	                                            b.RAZON_CLIENTE,
	                                            CAST(a.FECHA_FACTURA as date) FECHA_FACTURA,
	                                            c.DETALLE_MONEDA,
	                                            a.TOTAL_FACTURA,
	                                            d.DETALLE_ESTADO,
                                                a.TIPO_FACTURA,
                                                e.DETALLE_ESTADO TIPO_FACTURA
                                    from FACTURA a 
                                    LEFT JOIN CLIENTE b 
                                    on a.CODIGO_CLIENTE=b.CODIGO_CLIENTE
                                    LEFT JOIN MONEDA c 
                                    on a.CODIGO_MONEDA = c.CODIGO_MONEDA
                                    LEFT JOIN ESTADO d 
                                    on a.CODIGO_ESTADO = d.CODIGO_ESTADO
                                    LEFT JOIN ESTADO e
                                    on a.TIPO_FACTURA=e.CODIGO_ESTADO and e.TIPO_ESTADO=7", Nothing)
    End Function

    Public Function getAllFacturasFiltro(Filtro As String) As DataTable

        Return sqlControl.ExecQuery("select  a.CODIGO_FACTURA, 
	                                         a.SERIE_FACTURA, 
	                                         a.NUMERO_FACTURA,
	                                         b.RUC_CLIENTE,
	                                         b.RAZON_CLIENTE,
	                                         CAST(a.FECHA_FACTURA as date) FECHA_FACTURA,
	                                         c.DETALLE_MONEDA,
	                                         a.TOTAL_FACTURA,
	                                         d.DETALLE_ESTADO,
                                             a.TIPO_FACTURA,
                                             e.DETALLE_ESTADO TIPO_FACTURA 
                                     from FACTURA a 
                                     LEFT JOIN CLIENTE b 
                                     on a.CODIGO_CLIENTE=b.CODIGO_CLIENTE
                                     LEFT JOIN MONEDA c 
                                     on a.CODIGO_MONEDA = c.CODIGO_MONEDA
                                     LEFT JOIN ESTADO d 
                                     on a.CODIGO_ESTADO = d.CODIGO_ESTADO 
                                     LEFT JOIN ESTADO e 
                                     on a.TIPO_FACTURA=e.CODIGO_ESTADO and e.TIPO_ESTADO=7 
                                     where b.RAZON_CLIENTE LIKE '%'+'" + Filtro + "'+'%'", Nothing)
    End Function

    Public Function getFacturaById(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select CODIGO_FACTURA," +
                    "SERIE_FACTURA," +
                    "NUMERO_FACTURA," +
                    "CODIGO_CLIENTE," +
                    "TOTAL_FACTURA," +
                    "CODIGO_MONEDA," +
                    "FECHA_FACTURA," +
                    "CODIGO_ESTADO " +
                    "from factura " +
                    "where CODIGO_FACTURA=" + CStr(codigo), Nothing)
    End Function
    Public Function getDetalleFacturaByIdDetalle(codigo_detalle As Integer) As DataTable

        Return sqlControl.ExecQuery("select TIPO_SERVICIO,
                                    DESCRIPCION,
                                    CANTIDAD,
                                    CONF_VEHICULAR,
                                    VALOR_REFERENCIAL,
                                    PRECIO_UNITARIO,
                                    ORIGEN,
                                    DESTINO,
                                    OBSERVACION 
                                    from DETALLE_FACTURA
                                    WHERE 
                                    CODIGO_DETALLE_FACTURA =" + CStr(codigo_detalle),
                                     Nothing)

    End Function


    Public Function getDetalleFacturaByCodigoFactura(codigo_Factura As Integer) As DataTable

        Return sqlControl.ExecQuery("select CODIGO_DETALLE_FACTURA, 
                                    'ITEM '+cast(ROW_NUMBER()  OVER(ORDER BY CODIGO_DETALLE_FACTURA ASC) as varchar(10)) AS ITEM 
                                    FROM DETALLE_FACTURA 
                                    WHERE 
                                    CODIGO_FACTURA =" + CStr(codigo_Factura),
                                     Nothing)

    End Function

    Public Function getAllDetalleFacturaByCodigoFactura(codigo_Factura As Integer) As DataTable

        Return sqlControl.ExecQuery("select CODIGO_FACTURA,
                                    CODIGO_DETALLE_FACTURA,
                                    TIPO_SERVICIO,
                                    CANTIDAD,
                                    DESCRIPCION,
                                    CONF_VEHICULAR,
                                    VALOR_REFERENCIAL,
                                    PRECIO_UNITARIO,
                                    ORIGEN,
                                    DESTINO,
                                    OBSERVACION  
                                    FROM DETALLE_FACTURA 
                                    WHERE 
                                    CODIGO_FACTURA =" + CStr(codigo_Factura),
                                     Nothing)

    End Function

    Public Function InsertFactura(serie_factura As String, numero_factura As String, codigo_cliente As Integer, total_factura As Long,
                             codigo_moneda As Integer, codigo_estado As Integer, fecha_factura As Date, tipo_factura As Integer) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@SERIE_FACTURA", serie_factura))
        params.Add(New SqlParameter("@NUMERO_FACTURA", numero_factura))
        params.Add(New SqlParameter("@CODIGO_CLIENTE", codigo_cliente))
        params.Add(New SqlParameter("@TOTAL_FACTURA", total_factura))
        params.Add(New SqlParameter("@CODIGO_MONEDA", codigo_moneda))
        params.Add(New SqlParameter("@CODIGO_ESTADO", codigo_estado))
        params.Add(New SqlParameter("@FECHA_FACTURA", fecha_factura))
        params.Add(New SqlParameter("@TIPO_FACTURA", tipo_factura))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertFacturaCabecera " +
                                        "@SERIE_FACTURA," +
                                        "@NUMERO_FACTURA," +
                                        "@CODIGO_CLIENTE," +
                                        "@TOTAL_FACTURA," +
                                        "@CODIGO_MONEDA," +
                                        "@CODIGO_ESTADO," +
                                        "@FECHA_FACTURA, " +
                                        "@TIPO_FACTURA ", params)
        If dt.Rows.Count > 0 Then
            Return CInt(dt.Rows.Item(0).Item(0))
        Else
            Return -1
        End If
    End Function

    Public Sub UpdateFactura(codigo_factura As Integer, serie_factura As String, numero_factura As String, codigo_cliente As Integer,
                             total_factura As Long, codigo_moneda As Integer, codigo_estado As Integer, fecha_factura As Date)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@SERIE_FACTURA", serie_factura))
        params.Add(New SqlParameter("@NUMERO_FACTURA", numero_factura))
        params.Add(New SqlParameter("@CODIGO_CLIENTE", codigo_cliente))
        params.Add(New SqlParameter("@TOTAL_FACTURA", total_factura))
        params.Add(New SqlParameter("@CODIGO_MONEDA", codigo_moneda))
        params.Add(New SqlParameter("@CODIGO_ESTADO", codigo_estado))
        params.Add(New SqlParameter("@FECHA_FACTURA", fecha_factura))

        sqlControl.ExecQuery("EXECUTE updateFacturaCabecera " +
                                        "@CODIGO_FACTURA," +
                                        "@SERIE_FACTURA," +
                                        "@NUMERO_FACTURA," +
                                        "@CODIGO_CLIENTE," +
                                        "@TOTAL_FACTURA," +
                                        "@CODIGO_MONEDA," +
                                        "@CODIGO_ESTADO," +
                                        "@FECHA_FACTURA ", params)
    End Sub

    Public Function InsertFacturaDetalle(codigo_factura As Integer,
                                    tipo_servicio As Integer, descripcion As String,
                                         cantidad As Integer, conf_vehi As String,
                                         valor_ref As Long, obs As String, precio_unitario As Long,
                                         origen As String, destino As String) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))

        If tipo_servicio < 0 Then
            params.Add(New SqlParameter("@TIPO_SERVICIO", DBNull.Value))
        Else
            params.Add(New SqlParameter("@TIPO_SERVICIO", tipo_servicio))
        End If

        params.Add(New SqlParameter("@DESCRIPCION", descripcion))
        params.Add(New SqlParameter("@CANTIDAD", cantidad))
        params.Add(New SqlParameter("@CONF_VEHICULAR", conf_vehi))
        params.Add(New SqlParameter("@VALOR_REFERENCIAL", valor_ref))
        params.Add(New SqlParameter("@OBSERVACION", obs))
        params.Add(New SqlParameter("@PRECIO_UNITARIO", precio_unitario))
        params.Add(New SqlParameter("@ORIGEN", origen))
        params.Add(New SqlParameter("@DESTINO", destino))

        Dim dt As DataTable

        dt = sqlControl.ExecQuery("EXECUTE insertFacturaDetalle " +
                                        "@CODIGO_FACTURA," +
                                        "@TIPO_SERVICIO," +
                                        "@DESCRIPCION," +
                                        "@CANTIDAD," +
                                        "@CONF_VEHICULAR," +
                                        "@VALOR_REFERENCIAL," +
                                        "@OBSERVACION," +
                                        "@PRECIO_UNITARIO," +
                                        "@ORIGEN," +
                                        "@DESTINO", params)

        If dt.Rows.Count > 0 Then
            Return CInt(dt.Rows.Item(0).Item(0))
        Else
            Return -1
        End If
    End Function

    Public Sub UpdateFacturaDetalle(codigo_detalle_factura As Integer, codigo_factura As Integer,
                                    tipo_servicio As Integer, descripcion As String,
                                         cantidad As Integer, conf_vehi As String,
                                         valor_ref As Long, obs As String, precio_unitario As Long,
                                         origen As String, destino As String)


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        If tipo_servicio < 0 Then
            params.Add(New SqlParameter("@TIPO_SERVICIO", DBNull.Value))
        Else
            params.Add(New SqlParameter("@TIPO_SERVICIO", tipo_servicio))
        End If


        params.Add(New SqlParameter("@DESCRIPCION", descripcion))
        params.Add(New SqlParameter("@CANTIDAD", cantidad))
        params.Add(New SqlParameter("@CONF_VEHICULAR", conf_vehi))
        params.Add(New SqlParameter("@VALOR_REFERENCIAL", valor_ref))
        params.Add(New SqlParameter("@OBSERVACION", obs))
        params.Add(New SqlParameter("@PRECIO_UNITARIO", precio_unitario))
        params.Add(New SqlParameter("@ORIGEN", origen))
        params.Add(New SqlParameter("@DESTINO", destino))

        Dim dt As DataTable

        dt = sqlControl.ExecQuery("EXECUTE updateFacturaDetalle " +
                                        "@CODIGO_DETALLE_FACTURA," +
                                        "@CODIGO_FACTURA," +
                                        "@TIPO_SERVICIO," +
                                        "@DESCRIPCION," +
                                        "@CANTIDAD," +
                                        "@CONF_VEHICULAR," +
                                        "@VALOR_REFERENCIAL," +
                                        "@OBSERVACION," +
                                        "@PRECIO_UNITARIO," +
                                        "@ORIGEN," +
                                        "@DESTINO", params)

    End Sub

    Public Function getGuiasByDetalle(codigoDetalle As Integer) As DataTable

        Return sqlControl.ExecQuery("select a.CODIGO_GUIA,
	                                b.DETALLE_GUIA from DETALLE_FACTURA_GUIA a 
                                    LEFT JOIN GUIA_TRANSPORTISTA b 
                                    ON a.CODIGO_GUIA = b.CODIGO_GUIA
                                    where 
                                    CODIGO_DETALLE_FACTURA =" + CStr(codigoDetalle),
                                    Nothing)

    End Function

    Public Sub InsertFacturaDetalleGuia(codigo_detalle_factura As Integer, codigo_factura As Integer,
                                        codigo_guia As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA1", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA1", codigo_factura))
        params.Add(New SqlParameter("@CODIGO_GUIA1", codigo_guia))

        sqlControl.ExecQuery("EXECUTE insertFacturaDetalleGuia " +
                                        "@CODIGO_DETALLE_FACTURA1," +
                                        "@CODIGO_FACTURA1," +
                                        "@CODIGO_GUIA1 ", params)
    End Sub

    Public Sub deleteFacturaDetalleGuia(codigo_detalle_factura As Integer, codigo_factura As Integer,
                                        codigo_guia As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@CODIGO_GUIA", codigo_guia))

        sqlControl.ExecQuery("EXECUTE deleteFacturaDetalleGuia " +
                                        "@CODIGO_DETALLE_FACTURA," +
                                        "@CODIGO_FACTURA," +
                                        "@CODIGO_GUIA ", params)
    End Sub

    Public Sub deleteFacturaDetalle(codigo_detalle_factura As Integer, codigo_factura As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))

        sqlControl.ExecQuery("EXECUTE deleteFacturaDetalle " +
                                        "@CODIGO_DETALLE_FACTURA," +
                                        "@CODIGO_FACTURA", params)
    End Sub

    Public Sub InsertFacturaDetalleRemitente(codigo_detalle_factura As Integer, codigo_factura As Integer,
                                            guia_remitente As String)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA2", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA2", codigo_factura))
        params.Add(New SqlParameter("@GUIA_REMITENTE2", guia_remitente))

        sqlControl.ExecQuery("EXECUTE insertFacturaDetalleRemitente " +
                                        "@CODIGO_DETALLE_FACTURA2," +
                                        "@CODIGO_FACTURA2," +
                                        "@GUIA_REMITENTE2 ", params)
    End Sub

    Public Sub deleteFacturaDetalleRemitente(codigo_detalle_factura As Integer, codigo_factura As Integer,
                                        guia_remitente As String)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@GUIA_REMITENTE", guia_remitente))

        sqlControl.ExecQuery("EXECUTE deleteFacturaDetalleRemitente " +
                                        "@CODIGO_DETALLE_FACTURA," +
                                        "@CODIGO_FACTURA," +
                                        "@GUIA_REMITENTE ", params)
    End Sub

    Public Function getRemitentesByDetalle(codigoDetalle As Integer) As DataTable

        Return sqlControl.ExecQuery("SELECT GUIA_REMITENTE 
                                     FROM DETALLE_FACTURA_REMITENTE 
                                     where 
                                     CODIGO_DETALLE_FACTURA =" + CStr(codigoDetalle),
                                     Nothing)

    End Function

    Public Function InsertFacturaDetalleUnidad(codigo_detalle_factura As Integer, codigo_factura As Integer,
                                            placa_unidad As String) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA3", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA3", codigo_factura))
        params.Add(New SqlParameter("@PLACA_UNIDAD3", placa_unidad))

        Dim dt As DataTable

        dt = sqlControl.ExecQuery("EXECUTE insertFacturaDetalleUnidad " +
                                        "@CODIGO_DETALLE_FACTURA3," +
                                        "@CODIGO_FACTURA3," +
                                        "@PLACA_UNIDAD3 ", params)

        If dt.Rows.Count > 0 Then
            Return CInt(dt.Rows.Item(0).Item(0))
        Else
            Return -1
        End If
    End Function

    Public Sub deleteFacturaDetalleUnidad(codigo_detalle_factura As Integer, codigo_factura As Integer,
                                            placa_unidad As String)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@PLACA_UNIDAD", placa_unidad))

        sqlControl.ExecQuery("EXECUTE deleteFacturaDetalleUnidad " +
                                        "@CODIGO_DETALLE_FACTURA," +
                                        "@CODIGO_FACTURA," +
                                        "@PLACA_UNIDAD ", params)
    End Sub

    Public Function getPlacaByDetalle(codigoDetalle As Integer) As DataTable

        Return sqlControl.ExecQuery("SELECT PLACA_UNIDAD 
                                     FROM DETALLE_FACTURA_UNIDAD 
                                     where 
                                     CODIGO_DETALLE_FACTURA =" + CStr(codigoDetalle),
                                     Nothing)

    End Function
End Class
