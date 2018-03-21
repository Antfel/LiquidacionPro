Imports System.Data
Imports System.Data.SqlClient
Public Class FacturacionDAO
    Dim DBcon As New SqlConnection
    Dim DBcmd As SqlCommand
    Dim sqlControl As SQLControl

    Public Sub New(sqlControl As SQLControl)
        Me.sqlControl = sqlControl
        Me.DBcon = sqlControl.GetDBcon
    End Sub

    Public Sub SetDBcmd()
        Me.DBcmd = sqlControl.GetDBcmd
    End Sub

    Public Function OpenConexion() As Boolean
        Return sqlControl.OpenConexion()
    End Function

    Public Function CloseConexion() As Boolean
        Return sqlControl.CloseConexion()
    End Function

    Public Sub BeginTransaction()
        sqlControl.BeginTransaction()
    End Sub

    Public Sub CommitTransacction()
        sqlControl.CommitTransaction()
    End Sub

    Public Sub RollbackTransaccion()
        sqlControl.RollbackTransaccion()
    End Sub

    Public Function GetAllFacturas() As DataTable

        Return sqlControl.ExecQuery("select		a.CODIGO_FACTURA CODIGO, 
	                                            a.SERIE_FACTURA SERIE,  
	                                            a.NUMERO_FACTURA 'NRO. FACTURA',
	                                            b.RUC_CLIENTE RUC,
	                                            b.RAZON_CLIENTE 'RAZON SOCIAL',
	                                            convert(varchar(10),a.FECHA_FACTURA,103) 'FECHA FACTURA',
	                                            c.DETALLE_MONEDA 'MONEDA',
                                                cast(round(a.SUBTOTAL,2) as numeric(9,2)) 'SUB TOTAL',
                                                cast(round(a.IGV,2) as numeric(9,2)) 'IGV',
	                                            cast(round(a.TOTAL_FACTURA,2) as numeric(9,2)) 'TOTAL FACTURA',
	                                            d.DETALLE_ESTADO 'ESTADO FACTURA',
                                                a.TIPO_FACTURA 'CODIGO TIPO',
                                                e.DETALLE_ESTADO 'TIPO FACTURA',
                                                convert(varchar(10),a.FECHA_RECEPCION,103) 'FECHA RECEPCION',
                                                convert(varchar(10),a.FECHA_VENCIMIENTO,103) 'FECHA VENCIMIENTO',
                                                convert(varchar(10),a.FECHA_PAGO,103)  'FECHA PAGO',
                                                a.CODIGO_ESTADO,
                                                convert(varchar(10),a.FECHA_COMPROMISO,103)  'FECHA COMPROMISO',
                                                f.NOMBRE_BANCO  'NOMBRE BANCO' 
                                    from FACTURA a 
                                    LEFT JOIN CLIENTE b 
                                    on a.CODIGO_CLIENTE=b.CODIGO_CLIENTE
                                    LEFT JOIN MONEDA c 
                                    on a.CODIGO_MONEDA = c.CODIGO_MONEDA
                                    LEFT JOIN ESTADO d 
                                    on a.CODIGO_ESTADO = d.CODIGO_ESTADO
                                    LEFT JOIN ESTADO e
                                    on a.TIPO_FACTURA=e.CODIGO_ESTADO and e.TIPO_ESTADO=7 
                                    LEFT JOIN BANCO f on f.CODIGO_BANCO=a.CODIGO_BANCO  
                                    order by a.NUMERO_FACTURA", Nothing)
    End Function

    Public Function GetFacturaById(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select CODIGO_FACTURA," +
                                            "SERIE_FACTURA," +
                                            "NUMERO_FACTURA," +
                                            "CODIGO_CLIENTE," +
                                            "coalesce(TOTAL_FACTURA,0) TOTAL_FACTURA," +
                                            "CODIGO_MONEDA," +
                                            "FECHA_FACTURA," +
                                            "CODIGO_ESTADO, " +
                                            "FECHA_RECEPCION, " +
                                            "FECHA_VENCIMIENTO, " +
                                            "FECHA_PAGO, " +
                                            "FECHA_COMPROMISO, " +
                                            "coalesce(PORCENTAJE_DETRACCION,0), " +
                                            "coalesce(MONTO_DETRACCION,0),  " +
                                            "CODIGO_BANCO,  " +
                                            "coalesce(IGV,0)IGV," +
                                            "coalesce(SUBTOTAL,0) SUBTOTAL " +
                                            "from factura " +
                                            "where CODIGO_FACTURA=" + CStr(codigo), Nothing)
    End Function
    Public Function GetDetalleFacturaByIdDetalle(codigo_detalle As Integer) As DataTable

        Return sqlControl.ExecQuery("select TIPO_SERVICIO,
                                    DESCRIPCION,
                                    CANTIDAD,
                                    CONF_VEHICULAR,
                                    VALOR_REFERENCIAL,
                                    PRECIO_UNITARIO,
                                    PRECIO_SUBTOTAL,
                                    IGV,
                                    TOTAL,
                                    ORIGEN,
                                    DESTINO,
                                    OBSERVACION,
                                    CODIGO_DETALLE_FACTURA 
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
                                    PRECIO_SUBTOTAL 'SUBTOTAL',
                                    IGV 'IGV',
                                    TOTAL 'TOTAL',
                                    ORIGEN,
                                    DESTINO,
                                    OBSERVACION  
                                    FROM DETALLE_FACTURA 
                                    WHERE 
                                    CODIGO_FACTURA =" + CStr(codigo_Factura),
                                     Nothing)

    End Function

    Public Function InsertFactura(serie_factura As String, numero_factura As String, codigo_cliente As Integer, total_factura As Double,
                             codigo_moneda As Integer, codigo_estado As Integer, fecha_factura As Date, tipo_factura As Integer,
                                  chbxRecep As Boolean, fecha_recepcion As Date, chbxVencimiento As Boolean, fecha_vencimiento As Date,
                             chbxPago As Boolean, fecha_pago As Date, chbxCompromiso As Boolean, fecha_compromiso As Date, porcentaje_detraccion As Double,
                                  monto_detraccion As Double, banco As Integer) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@SERIE_FACTURA", serie_factura))
        params.Add(New SqlParameter("@NUMERO_FACTURA", numero_factura))
        params.Add(New SqlParameter("@CODIGO_CLIENTE", codigo_cliente))
        params.Add(New SqlParameter("@TOTAL_FACTURA", total_factura))
        params.Add(New SqlParameter("@CODIGO_MONEDA", codigo_moneda))
        params.Add(New SqlParameter("@CODIGO_ESTADO", codigo_estado))
        params.Add(New SqlParameter("@FECHA_FACTURA", fecha_factura))
        params.Add(New SqlParameter("@TIPO_FACTURA", tipo_factura))

        If chbxRecep Then
            params.Add(New SqlParameter("@FECHA_RECEPCION", fecha_recepcion))
        Else
            params.Add(New SqlParameter("@FECHA_RECEPCION", DBNull.Value))
        End If

        If chbxVencimiento Then
            params.Add(New SqlParameter("@FECHA_VENCIMIENTO", fecha_vencimiento))
        Else
            params.Add(New SqlParameter("@FECHA_VENCIMIENTO", DBNull.Value))
        End If

        If chbxPago Then
            params.Add(New SqlParameter("@FECHA_PAGO", fecha_pago))
        Else
            params.Add(New SqlParameter("@FECHA_PAGO", DBNull.Value))
        End If

        If chbxCompromiso Then
            params.Add(New SqlParameter("@FECHA_COMPROMISO", fecha_compromiso))
        Else
            params.Add(New SqlParameter("@FECHA_COMPROMISO", DBNull.Value))
        End If

        params.Add(New SqlParameter("@PORCENTAJE_DETRACCION", porcentaje_detraccion))

        params.Add(New SqlParameter("@MONTO_DETRACCION", monto_detraccion))

        If banco = -1 Then
            params.Add(New SqlParameter("@CODIGO_BANCO", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CODIGO_BANCO", banco))
        End If

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertFacturaCabecera " +
                                        "@SERIE_FACTURA," +
                                        "@NUMERO_FACTURA," +
                                        "@CODIGO_CLIENTE," +
                                        "@TOTAL_FACTURA," +
                                        "@CODIGO_MONEDA," +
                                        "@CODIGO_ESTADO," +
                                        "@FECHA_FACTURA, " +
                                        "@TIPO_FACTURA, " +
                                        "@FECHA_RECEPCION, " +
                                        "@FECHA_VENCIMIENTO, " +
                                        "@FECHA_PAGO, " +
                                        "@FECHA_COMPROMISO, " +
                                        "@PORCENTAJE_DETRACCION, " +
                                        "@MONTO_DETRACCION, " +
                                        "@CODIGO_BANCO ", params)
        If dt.Rows.Count > 0 Then
            Return CInt(dt.Rows.Item(0).Item(0))
        Else
            Return -1
        End If
    End Function

    Public Sub UpdateFactura(codigo_factura As Integer, serie_factura As String, numero_factura As String, codigo_cliente As Integer,
                             total_factura As Double, codigo_moneda As Integer, codigo_estado As Integer, fecha_factura As Date,
                             chbxRecep As Boolean, fecha_recepcion As Date, chbxVencimiento As Boolean, fecha_vencimiento As Date,
                             chbxPago As Boolean, fecha_pago As Date, chbxCompromiso As Boolean, fecha_compromiso As Date, porcentaje_detraccion As Double,
                             monto_detraccion As Double, banco As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@SERIE_FACTURA", serie_factura))
        params.Add(New SqlParameter("@NUMERO_FACTURA", numero_factura))
        params.Add(New SqlParameter("@CODIGO_CLIENTE", codigo_cliente))
        params.Add(New SqlParameter("@TOTAL_FACTURA", total_factura))
        params.Add(New SqlParameter("@CODIGO_MONEDA", codigo_moneda))
        params.Add(New SqlParameter("@CODIGO_ESTADO", codigo_estado))
        params.Add(New SqlParameter("@FECHA_FACTURA", fecha_factura))


        If chbxRecep Then
            params.Add(New SqlParameter("@FECHA_RECEPCION", fecha_recepcion))
        Else
            params.Add(New SqlParameter("@FECHA_RECEPCION", DBNull.Value))
        End If

        If chbxVencimiento Then
            params.Add(New SqlParameter("@FECHA_VENCIMIENTO", fecha_vencimiento))
        Else
            params.Add(New SqlParameter("@FECHA_VENCIMIENTO", DBNull.Value))
        End If

        If chbxPago Then
            params.Add(New SqlParameter("@FECHA_PAGO", fecha_pago))
        Else
            params.Add(New SqlParameter("@FECHA_PAGO", DBNull.Value))
        End If

        If chbxCompromiso Then
            params.Add(New SqlParameter("@FECHA_COMPROMISO", fecha_compromiso))
        Else
            params.Add(New SqlParameter("@FECHA_COMPROMISO", DBNull.Value))
        End If

        params.Add(New SqlParameter("@PORCENTAJE_DETRACCION", porcentaje_detraccion))

        params.Add(New SqlParameter("@MONTO_DETRACCION", monto_detraccion))

        If banco = -1 Then
            params.Add(New SqlParameter("@CODIGO_BANCO", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CODIGO_BANCO", banco))
        End If

        sqlControl.ExecQuery("EXECUTE updateFacturaCabecera " +
                                        "@CODIGO_FACTURA," +
                                        "@SERIE_FACTURA," +
                                        "@NUMERO_FACTURA," +
                                        "@CODIGO_CLIENTE," +
                                        "@TOTAL_FACTURA," +
                                        "@CODIGO_MONEDA," +
                                        "@CODIGO_ESTADO," +
                                        "@FECHA_FACTURA, " +
                                        "@FECHA_RECEPCION, " +
                                        "@FECHA_VENCIMIENTO, " +
                                        "@FECHA_PAGO, " +
                                        "@FECHA_COMPROMISO, " +
                                        "@PORCENTAJE_DETRACCION," +
                                        "@MONTO_DETRACCION, " +
                                        "@CODIGO_BANCO ", params)
    End Sub

    Public Sub UpdateFacturaEstado(codigo_factura As Integer, codigo_estado As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@CODIGO_ESTADO", codigo_estado))

        sqlControl.ExecQuery("EXECUTE updateFacturaCabeceraEstado " +
                                        "@CODIGO_FACTURA," +
                                        "@CODIGO_ESTADO ", params)
    End Sub

    Public Sub CopiarFactura(codigo_factura As Integer, serie As String, nro As String)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@NRO_SERIE", serie))
        params.Add(New SqlParameter("@NRO_FACTURA", nro))

        sqlControl.ExecQuery("EXECUTE uspCopiarFactura " +
                                        "@CODIGO_FACTURA," +
                                        "@NRO_SERIE," +
                                        "@NRO_FACTURA ", params)
    End Sub

    Public Function InsertFacturaDetalle(codigo_factura As Integer,
                                    tipo_servicio As Integer, descripcion As String,
                                         cantidad As Integer, conf_vehi As String,
                                         valor_ref As Double, obs As String, precio_unitario As Double,
                                         origen As String, destino As String, subtotal As Double, igv As Double, total As Double) As Integer

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
        params.Add(New SqlParameter("@SUBTOTAL", subtotal))
        params.Add(New SqlParameter("@IGV", igv))
        params.Add(New SqlParameter("@TOTAL", total))

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
                                        "@DESTINO," +
                                        "@SUBTOTAL," +
                                        "@IGV," +
                                        "@TOTAL ", params)

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
                                         origen As String, destino As String, subtotal As Double, igv As Double, total As Double)

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
        params.Add(New SqlParameter("@SUBTOTAL", subtotal))
        params.Add(New SqlParameter("@IGV", igv))
        params.Add(New SqlParameter("@TOTAL", total))

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
                                        "@DESTINO," +
                                        "@SUBTOTAL," +
                                        "@IGV," +
                                        "@TOTAL ", params)

    End Sub

    Public Function GetGuiasByDetalle(codigoDetalle As Integer) As DataTable

        Return sqlControl.ExecQuery("select a.CODIGO_GUIA,
	                                        b.DETALLE_GUIA 
                                    from    DETALLE_FACTURA_GUIA a 
                                    LEFT    JOIN GUIA_TRANSPORTISTA b ON a.CODIGO_GUIA = b.CODIGO_GUIA
                                    where   CODIGO_DETALLE_FACTURA =" + CStr(codigoDetalle) + "   
                                    order   by a.CODIGO_DETALLE_GUIA asc ",
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

    Public Sub DeleteFacturaDetalleGuia(codigo_detalle_factura As Integer, codigo_factura As Integer,
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

    Public Sub DeleteFacturaDetalle(codigo_detalle_factura As Integer, codigo_factura As Integer)

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

    Public Sub DeleteFacturaDetalleRemitente(codigo_detalle_factura As Integer, codigo_factura As Integer,
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

    Public Function GetRemitentesByDetalle(codigoDetalle As Integer) As DataTable

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

    Public Sub DeleteFacturaDetalleUnidad(codigo_detalle_factura As Integer, codigo_factura As Integer,
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

    Public Function GetPlacaByDetalle(codigoDetalle As Integer) As DataTable

        Return sqlControl.ExecQuery("SELECT CODIGO_FACTURA_GUIA, 
                                            PLACA_UNIDAD  
                                     FROM   DETALLE_FACTURA_UNIDAD 
                                     where 
                                     CODIGO_DETALLE_FACTURA =" + CStr(codigoDetalle),
                                     Nothing)

    End Function

    Public Function GetOrigenDestino() As DataTable

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


    Public Function GetRptLiquidacionFacturacionCabeceraAll(codigoMoneda As Integer) As DataTable

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

    Public Function GetRptLiquidacionFacturacionDetalle(codigo_factura As Integer) As DataTable

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

    Public Function GetRptFacturaDetalleByMoneda(codigoMoneda As Integer) As DataTable

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

    Public Function GetRptFacturaDetalleByClienteFecha(codigoMoneda As Integer, codigoCliente As Integer,
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

    Public Function GetRptFacturaDetalleByMonedaAndId(codigo_factura As Integer, factura_detalle As Integer) As DataTable

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

    Public Function GetRptFacturaDetalleByMonedaGastoTotal(codigoFactura As Integer) As DataTable

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

    Public Function GetPrintRptFacturaCabecera(codigo_factura As Integer) As DataTable
        Return sqlControl.ExecQuery("select	    b.RAZON_CLIENTE,
			                                    b.DIRECCION_CLIENTE,
			                                    b.RUC_CLIENTE,
			                                    a.FECHA_FACTURA,
			                                    c.DETALLE_MONEDA,
			                                    a.TOTAL_FACTURA,
			                                    0 TOTAL_FACTURA_LETRA,
			                                    a.SUBTOTAL,
			                                    a.IGV,
			                                    a.CODIGO_FACTURA,				    
                                                a.CODIGO_MONEDA 
                                    from	FACTURA a
                                    left	join CLIENTE b on a.CODIGO_CLIENTE=b.CODIGO_CLIENTE
                                    left	join MONEDA c on a.CODIGO_MONEDA=c.CODIGO_MONEDA
                                    where	a.CODIGO_FACTURA=" + CStr(codigo_factura) + "",
                                     Nothing)
    End Function

    Public Function GetPrintRptFacturaDetalle(codigo_factura As Integer) As DataTable
        Return sqlControl.ExecQuery("select	coalesce(b.CANTIDAD,0) CANTIDAD,
		                                    coalesce(b.CONF_VEHICULAR,'') CONF_VEHICULAR,
		                                    coalesce(b.OBSERVACION,'') OBSERVACION,
		                                    coalesce(b.PRECIO_UNITARIO,0)PRECIO_UNITARIO,
		                                    coalesce(b.ORIGEN,'') ORIGEN,
		                                    coalesce(b.DESTINO,'')DESTINO ,
		                                    a.CODIGO_FACTURA,
		                                    b.CODIGO_DETALLE_FACTURA,
		                                    coalesce(e.DETALLE_ESTADO,'')DETALLE_ESTADO ,
		                                    '',
		                                    '',
		                                    '',
		                                    '',
		                                    0,
		                                    d.DETALLE_MONEDA,
		                                    0,
		                                    a.FECHA_FACTURA,
		                                    coalesce(b.DESCRIPCION,'')DESCRIPCION,
		                                    coalesce(b.VALOR_REFERENCIAL,0) VALOR_REFERENCIAL,
		                                    coalesce(b.TIPO_SERVICIO,0) TIPO_SERVICIO,
		                                    coalesce(e.DETALLE_ESTADO_COMPLETO,'') DETALLE_ESTADO_COMPLETO,
                                            coalesce(b.PRECIO_SUBTOTAL ,0)  PRECIO_SUBTOTAL 
                                    from	FACTURA a 
                                    left	join DETALLE_FACTURA b on a.CODIGO_FACTURA=b.CODIGO_FACTURA 
                                    left	join CLIENTE c on c.CODIGO_CLIENTE=a.CODIGO_CLIENTE 
                                    left	join MONEDA d on d.CODIGO_MONEDA=a.CODIGO_MONEDA 
                                    left	join ESTADO e on e.CODIGO_ESTADO=b.TIPO_SERVICIO and e.TIPO_ESTADO=6 
                                    where	a.CODIGO_FACTURA=" + CStr(codigo_factura) + "",
                                     Nothing)
    End Function

    Public Function GetPrintRptFacturaGuia(codigo_factura As Integer, codigo_detalle As Integer) As DataTable
        Return sqlControl.ExecQuery("select	a.CODIGO_FACTURA,
		                                    a.CODIGO_DETALLE_FACTURA,
		                                    b.CODIGO_GUIA,
		                                    b.DETALLE_GUIA 
                                    from	DETALLE_FACTURA_GUIA a
                                    left	join GUIA_TRANSPORTISTA b on a.CODIGO_GUIA=b.CODIGO_GUIA
                                    where	CODIGO_FACTURA=" + CStr(codigo_factura) + "
		                                    and CODIGO_DETALLE_FACTURA=" + CStr(codigo_detalle) + "  
                                    order   by a.CODIGO_DETALLE_GUIA asc ",
                                     Nothing)
    End Function

    Public Function GetPrintRptFacturaRemitente(codigo_factura As Integer, codigo_detalle As Integer) As DataTable
        Return sqlControl.ExecQuery("select	CODIGO_FACTURA,
		                                    CODIGO_DETALLE_FACTURA,
		                                    GUIA_REMITENTE,
                                            CODIGO_FACTURA_REMITENTE 
                                    from	DETALLE_FACTURA_REMITENTE
                                    where	CODIGO_FACTURA=" + CStr(codigo_factura) + " 
		                                    and CODIGO_DETALLE_FACTURA=" + CStr(codigo_detalle) + " 
                                    order   by CODIGO_FACTURA_REMITENTE asc",
                                     Nothing)
    End Function

    Public Function GetPrintRptFacturaUnidad(codigo_factura As Integer, codigo_detalle As Integer) As DataTable
        Return sqlControl.ExecQuery("select	CODIGO_FACTURA,
		                                    CODIGO_DETALLE_FACTURA,
		                                    PLACA_UNIDAD,
                                            CODIGO_FACTURA_GUIA 
                                    from	DETALLE_FACTURA_UNIDAD
                                    where	CODIGO_FACTURA=" + CStr(codigo_factura) + "
		                                    and CODIGO_DETALLE_FACTURA=" + CStr(codigo_detalle) + " 
                                    order   by CODIGO_FACTURA_GUIA asc",
                                     Nothing)
    End Function

    Public Function GetRptFacturaCuentasPorCobrar(chbxInicio As Boolean, fecha_inicio As Date,
                                                  chbxFinal As Boolean, fecha_fin As Date, cliente As Integer) As DataTable

        Dim whereFecha As String, whereCliente As String
        whereFecha = ""
        whereCliente = ""

        Dim params As New List(Of SqlParameter)
        If chbxInicio And Not chbxFinal Then
            params.Add(New SqlParameter("@FECHA_INICIO", fecha_inicio))
            whereFecha = " AND (cast(cast(A.FECHA_FACTURA as date) as datetime) >= cast(cast( @FECHA_INICIO as date) as datetime)) "
        End If

        If chbxFinal And Not chbxInicio Then
            params.Add(New SqlParameter("@FECHA_FIN", fecha_fin))
            whereFecha = " AND (cast(cast(A.FECHA_FACTURA as date) as datetime) <= cast(cast( @FECHA_FIN as date) as datetime)) "
        End If

        If chbxInicio And chbxFinal Then
            params.Add(New SqlParameter("@FECHA_INICIO", fecha_inicio))
            params.Add(New SqlParameter("@FECHA_FIN", fecha_fin))
            whereFecha = " AND (cast(cast(A.FECHA_FACTURA as date) as datetime) between cast(cast( @FECHA_INICIO as date) as datetime) and cast(cast( @FECHA_FIN as date) as datetime)) "
        End If

        If cliente = -1 Then
            whereCliente = ""
        Else
            whereCliente = " and a.CODIGO_CLIENTE=" + CStr(cliente)
        End If

        Return sqlControl.ExecQuery("SELECT	A.CODIGO_FACTURA,
		                                    A.SERIE_FACTURA,
		                                    A.NUMERO_FACTURA,
		                                    A.FECHA_FACTURA,
		                                    A.CODIGO_CLIENTE,
		                                    B.RAZON_CLIENTE,
		                                    COALESCE(MAX(D.ORIGEN),'')+' - '+COALESCE(MAX(D.DESTINO),'') RUTA,
		                                    A.TOTAL_FACTURA,
		                                    A.CODIGO_MONEDA,
		                                    C.DETALLE_MONEDA,
		                                    C.SIMBOLO,
		                                    A.FECHA_COMPROMISO,
                                            coalesce(A.MONTO_DETRACCION,0) MONTO_DETRACCION,
                                            TOTAL_FACTURA-coalesce(MONTO_DETRACCION,0) TOTAL_DETRACCION
                                    FROM	FACTURA A
                                    LEFT	JOIN CLIENTE B ON A.CODIGO_CLIENTE=B.CODIGO_CLIENTE
                                    LEFT	JOIN MONEDA C ON A.CODIGO_MONEDA=C.CODIGO_MONEDA  
                                    LEFT	JOIN DETALLE_FACTURA D on A.CODIGO_FACTURA=D.CODIGO_FACTURA
                                    where   FECHA_PAGO IS NULL AND A.CODIGO_ESTADO<>15  
                                    " + whereFecha + "
                                    " + whereCliente + "
                                    GROUP	BY A.CODIGO_FACTURA,A.SERIE_FACTURA,A.NUMERO_FACTURA,A.FECHA_FACTURA,A.CODIGO_CLIENTE,
		                                    B.RAZON_CLIENTE,A.TOTAL_FACTURA,A.CODIGO_MONEDA,C.DETALLE_MONEDA,C.SIMBOLO,A.FECHA_COMPROMISO,MONTO_DETRACCION,
		                                    TOTAL_FACTURA -coalesce(MONTO_DETRACCION,0)  
                                    ORDER	BY CODIGO_CLIENTE,SERIE_FACTURA,NUMERO_FACTURA",
                                     params)
    End Function

    Public Function GetNroFacturasByActualizado(actualizado As Integer) As DataTable

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@ACTUALIZADO", actualizado))

        Return sqlControl.ExecQuery("select '0'+SERIE_FACTURA+'-'+substring(NUMERO_FACTURA,3,10) NRO_FACTURA 
                                    from    FACTURA 
                                    where   coalesce(ACTUALIZADO,0)=@ACTUALIZADO
                                    and     CODIGO_ESTADO=16",
                                     params)
    End Function

    Public Function SetLimpiarFacturasByMesPeriodo(mes As String, periodo As String) As DataTable

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@MES", mes))
        params.Add(New SqlParameter("@PERIODO", periodo))

        Return sqlControl.ExecQuery("delete	FACTURA_PAGO 
		                            where	MES_VENTA like '%'+@MES+'%' 
				                            and PERIODO_VENTA=@PERIODO ",
                                     params)
    End Function

    Public Function SetLimpiarNotasCreditoAll() As DataTable

        Return sqlControl.ExecQuery("delete	FACTURA_PAGO 
		                            where	ID_TIPO_DOCUMENTO=337 ",
                                     Nothing)
    End Function

    Public Function GetRptFacturaVsPago(mes As String, periodo As String, opcion As Integer, cliente As Integer) As DataTable

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@mes", mes))
        params.Add(New SqlParameter("@periodo", periodo))
        params.Add(New SqlParameter("@opcion", opcion))
        params.Add(New SqlParameter("@cliente", cliente))
        Console.WriteLine("sql param " + cliente.ToString)
        Return sqlControl.ExecQuery("exec uspRptFacturaVsPagos @mes,@periodo,@opcion,@cliente ",
                                     params)
    End Function

    Public Function GetMesPeriodoDescripcion(periodo As String) As DataTable

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@periodo", periodo))

        Return sqlControl.ExecQuery("select MES, NOMBRE from PERIODO where PERIODO=@periodo order by MES asc",
                                     params)
    End Function
End Class
