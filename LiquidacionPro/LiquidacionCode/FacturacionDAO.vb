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

        Return sqlControl.ExecQuery("select		a.CODIGO_FACTURA CODIGO, 
	                                            a.SERIE_FACTURA SERIE,  
	                                            a.NUMERO_FACTURA 'NRO. FACTURA',
	                                            b.RUC_CLIENTE RUC,
	                                            b.RAZON_CLIENTE 'RAZON SOCIAL',
	                                            CAST(a.FECHA_FACTURA as date) 'FECHA FACTURA',
	                                            c.DETALLE_MONEDA 'MONEDA',
	                                            a.TOTAL_FACTURA 'TOTAL FACTURA',
	                                            d.DETALLE_ESTADO 'ESTADO FACTURA',
                                                a.TIPO_FACTURA 'CODIGO TIPO',
                                                e.DETALLE_ESTADO 'TIPO FACTURA'
                                    from FACTURA a 
                                    LEFT JOIN CLIENTE b 
                                    on a.CODIGO_CLIENTE=b.CODIGO_CLIENTE
                                    LEFT JOIN MONEDA c 
                                    on a.CODIGO_MONEDA = c.CODIGO_MONEDA
                                    LEFT JOIN ESTADO d 
                                    on a.CODIGO_ESTADO = d.CODIGO_ESTADO
                                    LEFT JOIN ESTADO e
                                    on a.TIPO_FACTURA=e.CODIGO_ESTADO and e.TIPO_ESTADO=7 
                                    order by a.NUMERO_FACTURA", Nothing)
    End Function

    Public Function getAllFacturasFiltro(Filtro As String) As DataTable

        Return sqlControl.ExecQuery("select     a.CODIGO_FACTURA CODIGO, 
	                                            a.SERIE_FACTURA SERIE,  
	                                            a.NUMERO_FACTURA 'NRO. FACTURA',
	                                            b.RUC_CLIENTE RUC,
	                                            b.RAZON_CLIENTE 'RAZON SOCIAL',
	                                            CAST(a.FECHA_FACTURA as date) 'FECHA FACTURA',
	                                            c.DETALLE_MONEDA 'MONEDA',
	                                            a.TOTAL_FACTURA 'TOTAL FACTURA',
	                                            d.DETALLE_ESTADO 'ESTADO FACTURA',
                                                a.TIPO_FACTURA 'CODIGO TIPO',
                                                e.DETALLE_ESTADO 'TIPO FACTURA' 
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
                                    PRECIO_UNITARIO 'PRECIO UNITARIO',
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

    Public Sub UpdateFacturaEstado(codigo_factura As Integer, codigo_estado As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@CODIGO_ESTADO", codigo_estado))

        sqlControl.ExecQuery("EXECUTE updateFacturaCabeceraEstado " +
                                        "@CODIGO_FACTURA," +
                                        "@CODIGO_ESTADO ", params)
    End Sub

    Public Function InsertFacturaDetalle(codigo_factura As Integer,
                                    tipo_servicio As Integer, descripcion As String,
                                         cantidad As Integer, conf_vehi As String,
                                         valor_ref As Double, obs As String, precio_unitario As Double,
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
                                         valor_ref As Double, obs As String, precio_unitario As Double,
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
                                        codigo_factura_remitente As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA_REMITENTE", codigo_factura_remitente))

        sqlControl.ExecQuery("EXECUTE deleteFacturaDetalleRemitente " +
                                        "@CODIGO_DETALLE_FACTURA," +
                                        "@CODIGO_FACTURA," +
                                        "@CODIGO_FACTURA_REMITENTE ", params)
    End Sub

    Public Function getRemitentesByDetalle(codigoDetalle As Integer) As DataTable

        Return sqlControl.ExecQuery("SELECT     CODIGO_FACTURA_REMITENTE,
                                                GUIA_REMITENTE 
                                     FROM       DETALLE_FACTURA_REMITENTE 
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
                                            codigo_factura_guia As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA_GUIA", codigo_factura_guia))

        sqlControl.ExecQuery("EXECUTE deleteFacturaDetalleUnidad " +
                                        "@CODIGO_DETALLE_FACTURA," +
                                        "@CODIGO_FACTURA," +
                                        "@CODIGO_FACTURA_GUIA ", params)
    End Sub

    Public Function getPlacaByDetalle(codigoDetalle As Integer) As DataTable

        Return sqlControl.ExecQuery("SELECT CODIGO_FACTURA_GUIA, 
                                            PLACA_UNIDAD  
                                     FROM   DETALLE_FACTURA_UNIDAD 
                                     where 
                                     CODIGO_DETALLE_FACTURA =" + CStr(codigoDetalle),
                                     Nothing)

    End Function

    Public Function getOrigenDestino() As DataTable

        Return sqlControl.ExecQuery("select	distinct cast(ROW_NUMBER()  OVER(ORDER BY direccion ASC) as varchar(10)) AS ITEM,
		                                    DIRECCION from (
						                                    select distinct * from (
											                                    SELECT	distinct
													                                    ORIGEn direccion
											                                    FROM	DETALLE_FACTURA
											                                    union all 
											                                    SELECT	distinct
													                                    DESTINO direccion
											                                    FROM	DETALLE_FACTURA) a)b",
                                     Nothing)

    End Function


    Public Function getRptLiquidacionFacturacionCabeceraAll(codigoMoneda As Integer) As DataTable

        Return sqlControl.ExecQuery("SELECT	a.CODIGO_FACTURA,
		                                    a.NUMERO_FACTURA,
		                                    a.FECHA_FACTURA,
		                                    a.TOTAL_FACTURA,
		                                    b.SIMBOLO
                                    FROM	FACTURA a
                                    inner	join MONEDA b on a.CODIGO_MONEDA=b.CODIGO_MONEDA 
                                    where   a.CODIGO_MONEDA=" + CStr(codigoMoneda) + " and a.CODIGO_ESTADO<>15",
                                     Nothing)

    End Function

    Public Function getRptLiquidacionFacturacionDetalle(codigo_factura As Integer) As DataTable

        Return sqlControl.ExecQuery("SELECT	a.CODIGO_FACTURA,
		                                    f.PLACA_UNIDAD,
		                                    d.DETALLE_GUIA,
		                                    e.PEAJES_LIQUIDACION,
		                                    e.VIATICOS_LIQUIDACION,
		                                    e.GUARDIANIA_LIQUIDACION,
		                                    e.HOSPEDAJE_LIQUIDACION,
		                                    e.BALANZA_LIQUIDACION,
		                                    e.OTROS_LIQUIDACION,
		                                    e.CONSUMO_FISICO_LIQUIDACION,
		                                    round(coalesce(e.TOTAL_GASTO_COMBUSTIBLE,0)+coalesce(e.PEAJES_LIQUIDACION,0)+
		                                    coalesce(e.VIATICOS_LIQUIDACION,0)+coalesce(e.GUARDIANIA_LIQUIDACION,0)+coalesce(e.HOSPEDAJE_LIQUIDACION,0)+
		                                    coalesce(e.BALANZA_LIQUIDACION,0)+coalesce(e.OTROS_LIQUIDACION,0),3) TOTAL_GASTO,
		                                    b.PRECIO_UNITARIO,
		                                    case when e.CONSUMO_FISICO_LIQUIDACION<>0 then coalesce(e.TOTAL_GASTO_COMBUSTIBLE,0)/e.CONSUMO_FISICO_LIQUIDACION else 0 end 'PRECIO_COMBUSTIBLE',
		                                    PRECIO_UNITARIO-round(coalesce(e.TOTAL_GASTO_COMBUSTIBLE,0)+coalesce(e.PEAJES_LIQUIDACION,0)+
		                                    coalesce(e.VIATICOS_LIQUIDACION,0)+coalesce(e.GUARDIANIA_LIQUIDACION,0)+coalesce(e.HOSPEDAJE_LIQUIDACION,0)+
		                                    coalesce(e.BALANZA_LIQUIDACION,0)+coalesce(e.OTROS_LIQUIDACION,0),3) 'GANANCIA_BRUTA',
		                                    0 'PORCENTAJE',
		                                    b.PRECIO_UNITARIO*0 'PAGA',
		                                    (PRECIO_UNITARIO-round(coalesce(e.TOTAL_GASTO_COMBUSTIBLE,0)+coalesce(e.PEAJES_LIQUIDACION,0)+
		                                    coalesce(e.VIATICOS_LIQUIDACION,0)+coalesce(e.GUARDIANIA_LIQUIDACION,0)+coalesce(e.HOSPEDAJE_LIQUIDACION,0)+
		                                    coalesce(e.BALANZA_LIQUIDACION,0)+coalesce(e.OTROS_LIQUIDACION,0),3))-b.PRECIO_UNITARIO*0 'INGRESO',
                                            e.ORIGEN_LIQUIDACION,
                                            e.DESTINO_LIQUIDACION 
                                    FROM	FACTURA a
                                    inner	JOIN DETALLE_FACTURA b ON a.CODIGO_FACTURA=b.CODIGO_FACTURA
                                    inner	JOIN DETALLE_FACTURA_GUIA c on a.CODIGO_FACTURA=b.CODIGO_FACTURA and b.CODIGO_DETALLE_FACTURA=c.CODIGO_DETALLE_FACTURA 
                                    inner	join GUIA_TRANSPORTISTA d on c.CODIGO_GUIA=d.CODIGO_GUIA
                                    inner	join LIQUIDACION e on d.CODIGO_GUIA=e.CODIGO_GUIA
                                    inner	join UNIDAD f on f.CODIGO_UNIDAD=e.CODIGO_UNIDAD_TRACTO
                                    where	a.CODIGO_FACTURA=" + CStr(codigo_factura),
                                     Nothing)

    End Function


    'Original cabecera
    'Public Function getRptFacturaDetalleByMoneda(codigoMoneda As Integer) As DataTable

    '    Return sqlControl.ExecQuery("SELECT	a.CODIGO_FACTURA,
    '                                  b.CODIGO_DETALLE_FACTURA,
    '                                  a.NUMERO_FACTURA,
    '                                  a.FECHA_FACTURA,
    '                                  a.TOTAL_FACTURA,
    '                                  c.SIMBOLO,
    '                                  b.PRECIO_UNITARIO
    '                                FROM	FACTURA a
    '                                inner	join DETALLE_FACTURA b on a.CODIGO_FACTURA=b.CODIGO_FACTURA
    '                                inner	join MONEDA c on a.CODIGO_MONEDA=c.CODIGO_MONEDA 
    '                                where   a.CODIGO_MONEDA=" + CStr(codigoMoneda) + " and a.CODIGO_ESTADO<>15
    '                                order	by a.CODIGO_FACTURA, b.CODIGO_DETALLE_FACTURA asc",
    '                                 Nothing)

    'End Function

    Public Function getRptFacturaDetalleByMoneda(codigoMoneda As Integer) As DataTable

        Return sqlControl.ExecQuery("SELECT	a.CODIGO_FACTURA,
    		b.CODIGO_DETALLE_FACTURA,
    		a.NUMERO_FACTURA,
    		a.FECHA_FACTURA,
    		a.TOTAL_FACTURA,
    		g.SIMBOLO,
    		b.PRECIO_UNITARIO,
    		sum(round(coalesce(e.TOTAL_GASTO_COMBUSTIBLE,0)+coalesce(e.PEAJES_LIQUIDACION,0)+
    		coalesce(e.VIATICOS_LIQUIDACION,0)+coalesce(e.GUARDIANIA_LIQUIDACION,0)+coalesce(e.HOSPEDAJE_LIQUIDACION,0)+
    		coalesce(e.BALANZA_LIQUIDACION,0)+coalesce(e.OTROS_LIQUIDACION,0),3)) TOTAL_GASTO
    FROM	FACTURA a
    left	JOIN DETALLE_FACTURA b ON a.CODIGO_FACTURA=b.CODIGO_FACTURA
    left	JOIN DETALLE_FACTURA_GUIA c on a.CODIGO_FACTURA=b.CODIGO_FACTURA and b.CODIGO_DETALLE_FACTURA=c.CODIGO_DETALLE_FACTURA 
    left	join GUIA_TRANSPORTISTA d on c.CODIGO_GUIA=d.CODIGO_GUIA
    left	join LIQUIDACION e on d.CODIGO_GUIA=e.CODIGO_GUIA
    left	join UNIDAD f on f.CODIGO_UNIDAD=e.CODIGO_UNIDAD_TRACTO
    inner	join MONEDA g on g.CODIGO_MONEDA=a.CODIGO_MONEDA
    where	a.CODIGO_ESTADO<>15 and a.CODIGO_MONEDA=0
    group	by a.CODIGO_FACTURA,b.CODIGO_DETALLE_FACTURA,a.NUMERO_FACTURA,a.FECHA_FACTURA,a.TOTAL_FACTURA,g.SIMBOLO,b.PRECIO_UNITARIO 
    order	by a.CODIGO_FACTURA,b.CODIGO_DETALLE_FACTURA",
                                     Nothing)

    End Function

    Public Function getRptFacturaDetalleByClienteFecha(codigoMoneda As Integer, codigoCliente As Integer,
                                                       flagFecha As Boolean, inicio As Date, fin As Date) As DataTable

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_MONEDA", codigoMoneda))

        Dim cadenaCliente As String

        If codigoCliente = -1 Then
            cadenaCliente = ""
        Else
            cadenaCliente = " and a.CODIGO_CLIENTE=" + CStr(codigoCliente)
        End If

        Dim cadenaFecha As String
        If flagFecha Then
            params.Add(New SqlParameter("@FECHA_INICIO", inicio))
            params.Add(New SqlParameter("@FECHA_FIN", fin))
            cadenaFecha = "and cast(cast(a.FECHA_FACTURA as date) as datetime) between cast(cast(@FECHA_INICIO as date) as datetime) and cast(cast(@FECHA_FIN as date) as datetime) "
        Else
            cadenaFecha = ""
        End If
        'params.Add(New SqlParameter("@PLACA_UNIDAD3", placa_unidad))

        Return sqlControl.ExecQuery("SELECT	a.CODIGO_FACTURA,
    		                        b.CODIGO_DETALLE_FACTURA,
    		                        a.NUMERO_FACTURA,
    		                        a.FECHA_FACTURA,
    		                        a.TOTAL_FACTURA,
    		                        g.SIMBOLO,
    		                        b.PRECIO_UNITARIO,
    		                        sum(round(coalesce(e.TOTAL_GASTO_COMBUSTIBLE,0)+coalesce(e.PEAJES_LIQUIDACION,0)+
    		                        coalesce(e.VIATICOS_LIQUIDACION,0)+coalesce(e.GUARDIANIA_LIQUIDACION,0)+coalesce(e.HOSPEDAJE_LIQUIDACION,0)+
    		                        coalesce(e.BALANZA_LIQUIDACION,0)+coalesce(e.OTROS_LIQUIDACION,0),3)) TOTAL_GASTO
                            FROM	FACTURA a
                            left	JOIN DETALLE_FACTURA b ON a.CODIGO_FACTURA=b.CODIGO_FACTURA
                            left	JOIN DETALLE_FACTURA_GUIA c on a.CODIGO_FACTURA=b.CODIGO_FACTURA and b.CODIGO_DETALLE_FACTURA=c.CODIGO_DETALLE_FACTURA 
                            left	join GUIA_TRANSPORTISTA d on c.CODIGO_GUIA=d.CODIGO_GUIA
                            left	join LIQUIDACION e on d.CODIGO_GUIA=e.CODIGO_GUIA
                            left	join UNIDAD f on f.CODIGO_UNIDAD=e.CODIGO_UNIDAD_TRACTO
                            inner	join MONEDA g on g.CODIGO_MONEDA=a.CODIGO_MONEDA
                            where	a.CODIGO_ESTADO<>15 and a.CODIGO_MONEDA=@CODIGO_MONEDA
                                    " + cadenaCliente + "
                                    " + cadenaFecha + "
                            group	by a.CODIGO_FACTURA,b.CODIGO_DETALLE_FACTURA,a.NUMERO_FACTURA,a.FECHA_FACTURA,a.TOTAL_FACTURA,g.SIMBOLO,b.PRECIO_UNITARIO 
                            order	by a.CODIGO_FACTURA,b.CODIGO_DETALLE_FACTURA",
                                                             params)

    End Function

    Public Function getRptFacturaDetalleByMonedaAndId(codigo_factura As Integer, factura_detalle As Integer) As DataTable

        Return sqlControl.ExecQuery("SELECT	a.CODIGO_FACTURA,
		                                    f.PLACA_UNIDAD,
		                                    d.DETALLE_GUIA,
		                                    e.PEAJES_LIQUIDACION,
		                                    e.VIATICOS_LIQUIDACION,
		                                    e.GUARDIANIA_LIQUIDACION,
		                                    e.HOSPEDAJE_LIQUIDACION,
		                                    e.BALANZA_LIQUIDACION,
		                                    e.OTROS_LIQUIDACION,
		                                    e.CONSUMO_FISICO_LIQUIDACION,
		                                    round(coalesce(e.TOTAL_GASTO_COMBUSTIBLE,0)+coalesce(e.PEAJES_LIQUIDACION,0)+
		                                    coalesce(e.VIATICOS_LIQUIDACION,0)+coalesce(e.GUARDIANIA_LIQUIDACION,0)+coalesce(e.HOSPEDAJE_LIQUIDACION,0)+
		                                    coalesce(e.BALANZA_LIQUIDACION,0)+coalesce(e.OTROS_LIQUIDACION,0),3) TOTAL_GASTO,
		                                    case when e.CONSUMO_FISICO_LIQUIDACION<>0 then coalesce(e.TOTAL_GASTO_COMBUSTIBLE,0)/e.CONSUMO_FISICO_LIQUIDACION else 0 end 'PRECIO_COMBUSTIBLE',
                                            e.ORIGEN_LIQUIDACION,
                                            e.DESTINO_LIQUIDACION 
                                    FROM	FACTURA a
                                    inner	JOIN DETALLE_FACTURA b ON a.CODIGO_FACTURA=b.CODIGO_FACTURA
                                    inner	JOIN DETALLE_FACTURA_GUIA c on a.CODIGO_FACTURA=b.CODIGO_FACTURA and b.CODIGO_DETALLE_FACTURA=c.CODIGO_DETALLE_FACTURA 
                                    inner	join GUIA_TRANSPORTISTA d on c.CODIGO_GUIA=d.CODIGO_GUIA
                                    inner	join LIQUIDACION e on d.CODIGO_GUIA=e.CODIGO_GUIA
                                    inner	join UNIDAD f on f.CODIGO_UNIDAD=e.CODIGO_UNIDAD_TRACTO
                                    where	a.CODIGO_FACTURA=" + CStr(codigo_factura) + " and b.CODIGO_DETALLE_FACTURA=" + CStr(factura_detalle),
                                     Nothing)

    End Function

    Public Function getRptFacturaDetalleByMonedaGastoTotal(codigoFactura As Integer) As DataTable

        Return sqlControl.ExecQuery("SELECT	a.CODIGO_FACTURA,
                                            a.TOTAL_FACTURA,
		                                    sum(round(coalesce(e.TOTAL_GASTO_COMBUSTIBLE,0)+coalesce(e.PEAJES_LIQUIDACION,0)+
		                                    coalesce(e.VIATICOS_LIQUIDACION,0)+coalesce(e.GUARDIANIA_LIQUIDACION,0)+coalesce(e.HOSPEDAJE_LIQUIDACION,0)+
		                                    coalesce(e.BALANZA_LIQUIDACION,0)+coalesce(e.OTROS_LIQUIDACION,0),3)) TOTAL_GASTO
                                    FROM	FACTURA a
                                    inner	JOIN DETALLE_FACTURA b ON a.CODIGO_FACTURA=b.CODIGO_FACTURA
                                    inner	JOIN DETALLE_FACTURA_GUIA c on a.CODIGO_FACTURA=b.CODIGO_FACTURA and b.CODIGO_DETALLE_FACTURA=c.CODIGO_DETALLE_FACTURA 
                                    inner	join GUIA_TRANSPORTISTA d on c.CODIGO_GUIA=d.CODIGO_GUIA
                                    inner	join LIQUIDACION e on d.CODIGO_GUIA=e.CODIGO_GUIA
                                    inner	join UNIDAD f on f.CODIGO_UNIDAD=e.CODIGO_UNIDAD_TRACTO
                                    where	a.CODIGO_FACTURA=" + CStr(codigoFactura) + "
                                    group by a.CODIGO_FACTURA, a.TOTAL_FACTURA",
                                     Nothing)

    End Function
End Class
