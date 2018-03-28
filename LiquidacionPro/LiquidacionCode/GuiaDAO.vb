Imports System.Data
Imports System.Data.SqlClient
Public Class GuiaDAO
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

    Public Function getGuiaPendLiquidacion() As DataTable
        Return sqlControl.ExecQuery("SELECT CODIGO_GUIA, DETALLE_GUIA, CODIGO_ESTADO From GUIA_TRANSPORTISTA WHERE CODIGO_ESTADO = 8 OR CODIGO_ESTADO = 17", Nothing)
    End Function

    Public Function getGuiaPendFacturacion() As DataTable
        Return sqlControl.ExecQuery("SELECT CODIGO_GUIA, DETALLE_GUIA, CODIGO_ESTADO From GUIA_TRANSPORTISTA WHERE CODIGO_ESTADO = 7 OR CODIGO_ESTADO = 17", Nothing)
    End Function

    Public Function InsertGuia(detalleGuia As String,
                                estado As Integer, fechaLiquidacion As Date, fechaFacturacion As Date,
                                fechaGuia As Date, tracto As Integer, semitrailer As Integer,
                                trabajador As Integer, carga As String, na As String, cantidad As String,
                                cliente As Integer, origen As String, destino As String, comentario As String) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@DETALLE_GUIA", detalleGuia))
        params.Add(New SqlParameter("@CODIGO_ESTADO", 17))

        If fechaLiquidacion = Nothing Then
            params.Add(New SqlParameter("@FECHA_LIQUIDACION", DBNull.Value))
        Else
            params.Add(New SqlParameter("@FECHA_LIQUIDACION", fechaLiquidacion))
        End If

        If fechaFacturacion = Nothing Then
            params.Add(New SqlParameter("@FECHA_FACTURACION", DBNull.Value))
        Else
            params.Add(New SqlParameter("@FECHA_FACTURACION", fechaFacturacion))
        End If

        params.Add(New SqlParameter("@FECHA_GUIA", fechaGuia))

        If tracto = -1 Then
            params.Add(New SqlParameter("@CODIGO_UNIDAD_TRACTO", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CODIGO_UNIDAD_TRACTO", tracto))
        End If

        If semitrailer = -1 Then
            params.Add(New SqlParameter("@CODIGO_UNIDAD_SEMITRAILER", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CODIGO_UNIDAD_SEMITRAILER", semitrailer))
        End If

        If trabajador = -1 Then
            params.Add(New SqlParameter("@CODIGO_TRABAJADOR", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CODIGO_TRABAJADOR", trabajador))
        End If

        params.Add(New SqlParameter("@CARGA", carga))
        params.Add(New SqlParameter("@NA", na))
        params.Add(New SqlParameter("@CANTIDAD", cantidad))

        If cliente = -1 Then
            params.Add(New SqlParameter("@CODIGO_CLIENTE", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CODIGO_CLIENTE", cliente))
        End If

        params.Add(New SqlParameter("@ORIGEN", origen))
        params.Add(New SqlParameter("@DESTINO", destino))
        params.Add(New SqlParameter("@COMENTARIO", comentario))


        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertGuia " +
                                        "@DETALLE_GUIA," +
                                        "@CODIGO_ESTADO," +
                                        "@FECHA_LIQUIDACION," +
                                        "@FECHA_FACTURACION, " +
                                        "@FECHA_GUIA," +
                                        "@CODIGO_UNIDAD_TRACTO, " +
                                        "@CODIGO_UNIDAD_SEMITRAILER, " +
                                        "@CODIGO_TRABAJADOR, " +
                                        "@CARGA, " +
                                        "@NA, " +
                                        "@CANTIDAD, " +
                                        "@CODIGO_CLIENTE, " +
                                        "@ORIGEN, " +
                                        "@DESTINO, " +
                                        "@COMENTARIO ", params)
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

    Public Function UpdatetGuia(codigo As Integer, detalleGuia As String,
                                estado As Integer, fechaLiquidacion As Date, fechaFacturacion As Date,
                                fechaGuia As Date, tracto As Integer, semitrailer As Integer,
                                trabajador As Integer, carga As String, na As String, cantidad As String,
                                cliente As Integer, origen As String, destino As String, comentario As String) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_GUIA", codigo))
        params.Add(New SqlParameter("@DETALLE_GUIA", detalleGuia))
        params.Add(New SqlParameter("@CODIGO_ESTADO", estado))

        If fechaLiquidacion = Nothing Then
            params.Add(New SqlParameter("@FECHA_LIQUIDACION", DBNull.Value))
        Else
            params.Add(New SqlParameter("@FECHA_LIQUIDACION", fechaLiquidacion))
        End If

        If fechaFacturacion = Nothing Then
            params.Add(New SqlParameter("@FECHA_FACTURACION", DBNull.Value))
        Else
            params.Add(New SqlParameter("@FECHA_FACTURACION", fechaFacturacion))
        End If

        params.Add(New SqlParameter("@FECHA_GUIA", fechaGuia))

        If tracto = -1 Then
            params.Add(New SqlParameter("@CODIGO_UNIDAD_TRACTO", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CODIGO_UNIDAD_TRACTO", tracto))
        End If

        If semitrailer = -1 Then
            params.Add(New SqlParameter("@CODIGO_UNIDAD_SEMITRAILER", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CODIGO_UNIDAD_SEMITRAILER", semitrailer))
        End If

        If trabajador = -1 Then
            params.Add(New SqlParameter("@CODIGO_TRABAJADOR", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CODIGO_TRABAJADOR", trabajador))
        End If

        params.Add(New SqlParameter("@CARGA", carga))
        params.Add(New SqlParameter("@NA", na))
        params.Add(New SqlParameter("@CANTIDAD", cantidad))

        If cliente = -1 Then
            params.Add(New SqlParameter("@CODIGO_CLIENTE", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CODIGO_CLIENTE", cliente))
        End If

        params.Add(New SqlParameter("@ORIGEN", origen))
        params.Add(New SqlParameter("@DESTINO", destino))
        params.Add(New SqlParameter("@COMENTARIO", comentario))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateGuia " +
                                        "@CODIGO_GUIA," +
                                        "@DETALLE_GUIA," +
                                        "@CODIGO_ESTADO," +
                                        "@FECHA_LIQUIDACION," +
                                        "@FECHA_FACTURACION, " +
                                        "@FECHA_GUIA, " +
                                        "@CODIGO_UNIDAD_TRACTO, " +
                                        "@CODIGO_UNIDAD_SEMITRAILER, " +
                                        "@CODIGO_TRABAJADOR, " +
                                        "@CARGA, " +
                                        "@NA, " +
                                        "@CANTIDAD, " +
                                        "@CODIGO_CLIENTE, " +
                                        "@ORIGEN, " +
                                        "@DESTINO, " +
                                        "@COMENTARIO ", params)
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

    Public Function getGuiaByNroGuia(nro_guia As String) As DataTable
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@NRO_GUIA", nro_guia))
        Return sqlControl.ExecQuery("SELECT CODIGO_GUIA, DETALLE_GUIA, CODIGO_ESTADO From GUIA_TRANSPORTISTA WHERE DETALLE_GUIA = @NRO_GUIA", params)
    End Function

    Public Function GetAllGuia() As DataTable
        Return sqlControl.ExecQuery("select	a.CODIGO_GUIA CODIGO,
		                                    a.DETALLE_GUIA 'DETALLE',
		                                    a.CODIGO_ESTADO,
		                                    a.FECHA_LIQUIDACION 'FECHA LIQUIDACION',
		                                    a.FECHA_FACTURACION 'FECHA FACTURACION',
		                                    b.DETALLE_ESTADO 'ESTADO',
		                                    convert(varchar(10),a.FECHA_GUIA,103) 'FECHA GUIA',
		                                    a.CODIGO_UNIDAD_TRACTO,
		                                    c.PLACA_UNIDAD 'TRACTO',
		                                    a.CODIGO_UNIDAD_SEMITRAILER,
		                                    d.PLACA_UNIDAD 'SEMI TRAILER',
		                                    a.CODIGO_TRABAJADOR,
		                                    coalesce(e.APELLIDO_PATERNO_TRABAJADOR,'')+' '+coalesce(e.APELLIDO_MATERNO_TRABAJADOR,'')+' '+coalesce(e.NOMBRES_TRABAJADOR,'') 'TRABAJADOR',
		                                    a.CARGA,
		                                    a.NA,
		                                    a.CANTIDAD,
		                                    a.CODIGO_CLIENTE,
		                                    f.RAZON_CLIENTE 'RAZON SOCIAL',
		                                    a.ORIGEN,
		                                    a.DESTINO,
                                            a.COMENTARIO 
                                    from	GUIA_TRANSPORTISTA a
                                    left	join ESTADO b on a.CODIGO_ESTADO=b.CODIGO_ESTADO and TIPO_ESTADO=3
                                    left	join UNIDAD c on a.CODIGO_UNIDAD_TRACTO=c.CODIGO_UNIDAD
                                    left	join unidad d on a.CODIGO_UNIDAD_SEMITRAILER=d.CODIGO_UNIDAD
                                    left	join TRABAJADOR e on e.CODIGO_TRABAJADOR=a.CODIGO_TRABAJADOR
                                    left	join CLIENTE f on a.CODIGO_CLIENTE=f.CODIGO_CLIENTE", Nothing)

    End Function

    Public Function getGuiaByCodigo(codigo As Integer) As DataTable
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@codigo", codigo))
        Return sqlControl.ExecQuery("select	a.CODIGO_GUIA CODIGO,
		                                    a.DETALLE_GUIA 'DETALLE',
		                                    a.CODIGO_ESTADO,
		                                    a.FECHA_LIQUIDACION 'FECHA LIQUIDACION',
		                                    a.FECHA_FACTURACION 'FECHA FACTURACION',
		                                    b.DETALLE_ESTADO 'ESTADO',
		                                    a.FECHA_GUIA 'FECHA GUIA',
		                                    a.CODIGO_UNIDAD_TRACTO,
		                                    c.PLACA_UNIDAD 'TRACTO',
		                                    a.CODIGO_UNIDAD_SEMITRAILER,
		                                    d.PLACA_UNIDAD 'SEMITRAILER',
		                                    a.CODIGO_TRABAJADOR,
		                                    coalesce(e.APELLIDO_PATERNO_TRABAJADOR,'')+' '+coalesce(e.APELLIDO_MATERNO_TRABAJADOR,'')+' '+coalesce(e.NOMBRES_TRABAJADOR,'') 'TRABAJADOR',
		                                    coalesce(a.CARGA,'') CARGA,
		                                    coalesce(a.NA,'') NA,
		                                    coalesce(a.CANTIDAD,'') CANTIDAD,
		                                    a.CODIGO_CLIENTE,
		                                    f.RAZON_CLIENTE 'RAZON SOCIAL',
		                                    coalesce(a.ORIGEN,'')ORIGEN,  
		                                    coalesce(a.DESTINO,'')  DESTINO, 
                                            coalesce(a.COMENTARIO,'')  COMENTARIO  
                                    from	GUIA_TRANSPORTISTA a 
                                    left	join ESTADO b on a.CODIGO_ESTADO=b.CODIGO_ESTADO and TIPO_ESTADO=3 
                                    left	join UNIDAD c on a.CODIGO_UNIDAD_TRACTO=c.CODIGO_UNIDAD 
                                    left	join unidad d on a.CODIGO_UNIDAD_SEMITRAILER=d.CODIGO_UNIDAD 
                                    left	join TRABAJADOR e on e.CODIGO_TRABAJADOR=a.CODIGO_TRABAJADOR 
                                    left	join CLIENTE f on a.CODIGO_CLIENTE=f.CODIGO_CLIENTE 
                                    WHERE   CODIGO_GUIA = @codigo", params)
    End Function

    Public Function getGuiaByCodigoCb(codigo As Integer) As DataTable
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@codigo", codigo))
        Return sqlControl.ExecQuery("select	a.CODIGO_GUIA,
		                                    a.DETALLE_GUIA   
                                    from	GUIA_TRANSPORTISTA a  
                                    WHERE   a.CODIGO_GUIA = @codigo", params)
    End Function

    Public Function getRptGuiaLiquidacionFactura(estados As String) As DataTable
        Dim params As New List(Of SqlParameter)
        Return sqlControl.ExecQuery("SELECT	a.CODIGO_GUIA,
		                                    a.DETALLE_GUIA,
		                                    b.DETALLE_ESTADO,
		                                    c.CODIGO_LIQUIDACION,
		                                    c.NUMERO_LIQUIDACION,
		                                    f.CODIGO_FACTURA,
		                                    f.NUMERO_FACTURA
                                    FROM	GUIA_TRANSPORTISTA a
                                    LEFT	JOIN ESTADO b ON a.CODIGO_ESTADO=b.CODIGO_ESTADO
                                    LEFT	JOIN LIQUIDACION c ON c.CODIGO_GUIA=a.CODIGO_GUIA
                                    LEFT	JOIN DETALLE_FACTURA_GUIA d ON d.CODIGO_GUIA=A.CODIGO_GUIA 
                                    LEFT	JOIN DETALLE_FACTURA e ON e.CODIGO_DETALLE_FACTURA=d.CODIGO_DETALLE_FACTURA AND d.CODIGO_FACTURA=e.CODIGO_FACTURA
                                    LEFT	JOIN FACTURA f ON f.CODIGO_FACTURA=e.CODIGO_FACTURA
                                    WHERE	a.CODIGO_ESTADO IN (" + estados + ")
                                    ORDER	BY a.DETALLE_GUIA", params)
    End Function

    Public Function GetRptAllGuia() As DataTable
        Return sqlControl.ExecQuery("select	a.CODIGO_GUIA CODIGO,
		                                    a.DETALLE_GUIA 'DETALLE',
		                                    a.CODIGO_ESTADO,
		                                    a.FECHA_LIQUIDACION 'FECHA LIQUIDACION',
		                                    a.FECHA_FACTURACION 'FECHA FACTURACION',
		                                    b.DETALLE_ESTADO 'ESTADO',
		                                    convert(varchar(10),a.FECHA_GUIA,103) 'FECHA GUIA',
		                                    a.CODIGO_UNIDAD_TRACTO,
		                                    c.PLACA_UNIDAD 'TRACTO',
		                                    a.CODIGO_UNIDAD_SEMITRAILER,
		                                    d.PLACA_UNIDAD 'SEMI TRAILER',
		                                    a.CODIGO_TRABAJADOR,
		                                    coalesce(e.APELLIDO_PATERNO_TRABAJADOR,'')+' '+coalesce(e.APELLIDO_MATERNO_TRABAJADOR,'')+' '+coalesce(e.NOMBRES_TRABAJADOR,'') 'TRABAJADOR',
		                                    a.CARGA,
		                                    a.NA,
		                                    a.CANTIDAD,
		                                    a.CODIGO_CLIENTE,
		                                    f.RAZON_CLIENTE 'RAZON SOCIAL',
		                                    a.ORIGEN,
		                                    a.DESTINO 
                                    from	GUIA_TRANSPORTISTA a
                                    left	join ESTADO b on a.CODIGO_ESTADO=b.CODIGO_ESTADO and TIPO_ESTADO=3
                                    left	join UNIDAD c on a.CODIGO_UNIDAD_TRACTO=c.CODIGO_UNIDAD
                                    left	join unidad d on a.CODIGO_UNIDAD_SEMITRAILER=d.CODIGO_UNIDAD
                                    left	join TRABAJADOR e on e.CODIGO_TRABAJADOR=a.CODIGO_TRABAJADOR
                                    left	join CLIENTE f on a.CODIGO_CLIENTE=f.CODIGO_CLIENTE", Nothing)

    End Function

    Public Function GetRptGuiaControlViaje(cliente As Integer, trabajador As Integer, origen As String, destino As String,
                                           fecha As Date, bfecha As Boolean, tracto As Integer, semitrailer As Integer) As DataTable

        Dim whereClienteString, whereTrabajadorString, whereOrigenString, whereDestinoString,
            whereTractoString, whereSemitrailerString, whereFechaString, whereString As String

        whereClienteString = ""
        whereTrabajadorString = ""
        whereOrigenString = ""
        whereDestinoString = ""
        whereTractoString = ""
        whereSemitrailerString = ""
        whereFechaString = ""
        whereString = ""

        Dim params As New List(Of SqlParameter)

        If cliente <> -1 Then
            params.Add(New SqlParameter("@cliente", cliente))
            whereClienteString = " and a.CODIGO_CLIENTE=@cliente "
        Else
            whereClienteString = ""
        End If

        If trabajador <> -1 Then
            params.Add(New SqlParameter("@trabajador", trabajador))
            whereTrabajadorString = " and a.CODIGO_TRABAJADOR=@trabajador "
        Else
            whereTrabajadorString = ""
        End If

        If origen <> "" Then
            params.Add(New SqlParameter("@origen", origen))
            whereOrigenString = " and a.ORIGEN like '%@origen%' "
        Else
            whereOrigenString = ""
        End If

        If destino <> "" Then
            params.Add(New SqlParameter("@destino", destino))
            whereDestinoString = " and a.DESTINO like '%@destino%' "
        Else
            whereDestinoString = ""
        End If

        If tracto <> -1 Then
            params.Add(New SqlParameter("@tracto", tracto))
            whereTractoString = " and a.CODIGO_UNIDAD_TRACTO=@tracto "
        Else
            whereTractoString = ""
        End If

        If semitrailer <> -1 Then
            params.Add(New SqlParameter("@semitrailer", semitrailer))
            whereSemitrailerString = " and a.CODIGO_UNIDAD_SEMITRAILER=@semitrailer "
        Else
            whereSemitrailerString = ""
        End If

        If bfecha Then
            params.Add(New SqlParameter("@fecha", fecha))
            whereFechaString = " and cast(cast(a.FECHA_GUIA as date) as datetime)=cast(cast(@fecha as date) as datetime) "
        Else
            whereFechaString = ""
        End If

        whereString = whereClienteString + whereTrabajadorString + whereOrigenString + whereDestinoString + whereTractoString + whereSemitrailerString + whereFechaString

        If whereString <> "" Then
            whereString = "where " + whereString.Substring(4, whereString.Length - 4)
        End If

        Return sqlControl.ExecQuery("select	a.CODIGO_GUIA CODIGO,
		                                    a.DETALLE_GUIA 'DETALLE',
		                                    a.CODIGO_ESTADO,
		                                    a.FECHA_LIQUIDACION,
		                                    a.FECHA_FACTURACION,
		                                    b.DETALLE_ESTADO 'ESTADO',
		                                    a.FECHA_GUIA,
		                                    a.CODIGO_UNIDAD_TRACTO,
		                                    c.PLACA_UNIDAD 'TRACTO',
		                                    a.CODIGO_UNIDAD_SEMITRAILER,
		                                    d.PLACA_UNIDAD 'SEMI_TRAILER',
		                                    a.CODIGO_TRABAJADOR,
		                                    coalesce(e.APELLIDO_PATERNO_TRABAJADOR,'')+' '+coalesce(e.NOMBRES_TRABAJADOR,'') 'TRABAJADOR',
		                                    a.CARGA,
		                                    a.NA, 
		                                    a.CANTIDAD, 
		                                    a.CODIGO_CLIENTE, 
		                                    f.RAZON_CLIENTE, 
		                                    a.ORIGEN, 
		                                    a.DESTINO,
                                            a.COMENTARIO 
                                    from	GUIA_TRANSPORTISTA a 
                                    left	join ESTADO b on a.CODIGO_ESTADO=b.CODIGO_ESTADO and TIPO_ESTADO=3 
                                    left	join UNIDAD c on a.CODIGO_UNIDAD_TRACTO=c.CODIGO_UNIDAD 
                                    left	join unidad d on a.CODIGO_UNIDAD_SEMITRAILER=d.CODIGO_UNIDAD 
                                    left	join TRABAJADOR e on e.CODIGO_TRABAJADOR=a.CODIGO_TRABAJADOR 
                                    left	join CLIENTE f on a.CODIGO_CLIENTE=f.CODIGO_CLIENTE 
                                     " + whereString + "", params)

    End Function
End Class
