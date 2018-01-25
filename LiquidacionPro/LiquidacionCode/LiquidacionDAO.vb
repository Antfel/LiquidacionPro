﻿Imports System.Data
Imports System.Data.SqlClient
Public Class LiquidacionDAO

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

    Public Function GetAllLiquidacion() As DataTable
        Return sqlControl.ExecQuery("select		a.CODIGO_LIQUIDACION CODIGO,
			                        a.NUMERO_LIQUIDACION 'NUMERO LIQUIDACION',
			                        a.CODIGO_TRABAJADOR,
			                        f.APELLIDO_PATERNO_TRABAJADOR+' '+f.APELLIDO_MATERNO_TRABAJADOR+', '+f.NOMBRES_TRABAJADOR TRABAJADOR,
			                        a.CODIGO_GUIA,
			                        d.DETALLE_GUIA GUIA,
			                        a.CODIGO_UNIDAD_TRACTO,
			                        b.PLACA_UNIDAD TRACTO,
			                        a.CODIGO_UNIDAD_SEMITRAILER,
			                        c.PLACA_UNIDAD SEMITRAILER,
			                        a.ORIGEN_LIQUIDACION ORIGEN,
			                        a.DESTINO_LIQUIDACION DESTINO,
			                        convert(varchar(10),a.FECHA_SALIDA,103)+''+right(convert(varchar(32),a.FECHA_SALIDA,100),8) 'FECHA SALIDA',
			                        convert(varchar(10),a.FECHA_LLEGADA,103)+''+right(convert(varchar(32),a.FECHA_LLEGADA,100),8) 'FECHA LLEGADA',
			                        a.DINERO_LIQUIDACION 'DINERO ENTREGADO',
			                        a.PEAJES_LIQUIDACION PEAJES,
			                        a.VIATICOS_LIQUIDACION VIATICOS,
			                        a.GUARDIANIA_LIQUIDACION GUARDIANIA,
                                    a.HOSPEDAJE_LIQUIDACION HOSPEDAJE,
			                        a.BALANZA_LIQUIDACION BALANZA,
			                        a.OTROS_LIQUIDACION OTROS,
			                        a.CONSUMO_FISICO_LIQUIDACION 'CONSUMO FISICO',
			                        a.CONSUMO_VIRTUAL_LIQUIDACION 'CONSUMO VIRTUAL',
			                        a.CODIGO_ESTADO,
			                        e.DETALLE_ESTADO ESTADO,
                                    a.DINERO_LIQUIDACION DINERO,
			                        (coalesce(a.PEAJES_LIQUIDACION,0)+coalesce(a.VIATICOS_LIQUIDACION,0)+coalesce(a.GUARDIANIA_LIQUIDACION,0)+
			                        coalesce(a.HOSPEDAJE_LIQUIDACION,0)+coalesce(a.BALANZA_LIQUIDACION,0)+coalesce(a.OTROS_LIQUIDACION,0)) 'TOTAL GASTO',
			                        (coalesce(a.DINERO_LIQUIDACION,0)-(coalesce(a.PEAJES_LIQUIDACION,0)+coalesce(a.VIATICOS_LIQUIDACION,0)+coalesce(a.GUARDIANIA_LIQUIDACION,0)+
			                        coalesce(a.HOSPEDAJE_LIQUIDACION,0)+coalesce(a.BALANZA_LIQUIDACION,0)+coalesce(a.OTROS_LIQUIDACION,0))) 'DIFERENCIA GASTO',
                                    a.CONSUMO_FISICO_LIQUIDACION-a.CONSUMO_VIRTUAL_LIQUIDACION 'DIFERENCIA CONSUMO'      
                        from		LIQUIDACION a
                        LEFT JOIN	UNIDAD b on a.CODIGO_UNIDAD_TRACTO=b.CODIGO_UNIDAD
                        LEFT JOIN	UNIDAD c on a.CODIGO_UNIDAD_SEMITRAILER=c.CODIGO_UNIDAD
                        LEFT JOIN	GUIA_TRANSPORTISTA d on d.CODIGO_GUIA=a.CODIGO_GUIA
                        LEFT JOIN	ESTADO e on e.CODIGO_ESTADO=a.CODIGO_ESTADO
                        LEFT JOIN	TRABAJADOR f on f.CODIGO_TRABAJADOR=a.CODIGO_TRABAJADOR
                        ORDER BY	CODIGO_LIQUIDACION ASC", Nothing)

    End Function

    Public Function GetLiquidacionById(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select		a.CODIGO_LIQUIDACION,
			                        a.NUMERO_LIQUIDACION,
			                        a.CODIGO_TRABAJADOR,
			                        f.APELLIDO_PATERNO_TRABAJADOR+' '+f.APELLIDO_MATERNO_TRABAJADOR+', '+f.NOMBRES_TRABAJADOR,
			                        a.CODIGO_GUIA,
			                        d.DETALLE_GUIA,
			                        a.CODIGO_UNIDAD_TRACTO,
			                        b.PLACA_UNIDAD,
			                        a.CODIGO_UNIDAD_SEMITRAILER,
			                        c.PLACA_UNIDAD,
			                        a.ORIGEN_LIQUIDACION,
			                        a.DESTINO_LIQUIDACION,
			                        a.FECHA_SALIDA,
			                        a.FECHA_LLEGADA,
			                        a.DINERO_LIQUIDACION,
			                        a.PEAJES_LIQUIDACION,
			                        a.VIATICOS_LIQUIDACION,
			                        a.GUARDIANIA_LIQUIDACION,
                                    a.HOSPEDAJE_LIQUIDACION,
			                        a.BALANZA_LIQUIDACION,
			                        a.OTROS_LIQUIDACION,
			                        coalesce(a.CONSUMO_FISICO_LIQUIDACION,0),
			                        coalesce(a.CONSUMO_VIRTUAL_LIQUIDACION,0),
			                        a.CODIGO_ESTADO,
			                        e.DETALLE_ESTADO,
                                    (coalesce(a.PEAJES_LIQUIDACION,0)+coalesce(a.VIATICOS_LIQUIDACION,0)+coalesce(a.GUARDIANIA_LIQUIDACION,0)+
			                        coalesce(a.HOSPEDAJE_LIQUIDACION,0)+coalesce(a.BALANZA_LIQUIDACION,0)+coalesce(a.OTROS_LIQUIDACION,0)) TOTAL_GASTO,
			                        (coalesce(a.DINERO_LIQUIDACION,0)-(coalesce(a.PEAJES_LIQUIDACION,0)+coalesce(a.VIATICOS_LIQUIDACION,0)+coalesce(a.GUARDIANIA_LIQUIDACION,0)+
			                        coalesce(a.HOSPEDAJE_LIQUIDACION,0)+coalesce(a.BALANZA_LIQUIDACION,0)+coalesce(a.OTROS_LIQUIDACION,0)))DIFERENCIA,
                                    coalesce(a.CONSUMO_FISICO_LIQUIDACION,0)-coalesce(a.CONSUMO_VIRTUAL_LIQUIDACION,0) DIFERENCIA_CONSUMO,
                                    coalesce(a.TOTAL_GASTO_COMBUSTIBLE,0),
                                    coalesce(a.TANQUE,0),
                                    coalesce(a.KM_SALIDA,0),
                                    coalesce(a.KM_LLEGADA,0),
                                    coalesce(a.KM_RECORRIDO,0),
                                    coalesce(a.GALONES_LLEGA,0),
                                    coalesce(a.CARGA,''),
                                    coalesce(a.PESO,0),
                                    coalesce(a.UNIDAD_MEDIDA,-1),
                                    coalesce(a.RUTA_DETALLE,''),
                                    coalesce(a.CARGA_DETALLE,''),
                                    coalesce(a.AJUSTE_GALONES,0),
                                    coalesce(a.TOTAL_GALONES,0),
                                    coalesce(a.PESO_DESCRIPCION,'') 
                        from		LIQUIDACION a
                        LEFT JOIN	UNIDAD b on a.CODIGO_UNIDAD_TRACTO=b.CODIGO_UNIDAD
                        LEFT JOIN	UNIDAD c on a.CODIGO_UNIDAD_SEMITRAILER=c.CODIGO_UNIDAD
                        LEFT JOIN	GUIA_TRANSPORTISTA d on d.CODIGO_GUIA=a.CODIGO_GUIA
                        LEFT JOIN	ESTADO e on e.CODIGO_ESTADO=a.CODIGO_ESTADO
                        LEFT JOIN	TRABAJADOR f on f.CODIGO_TRABAJADOR=a.CODIGO_TRABAJADOR 
                        where       CODIGO_LIQUIDACION=" + CStr(codigo) + " 
                        ORDER BY	CODIGO_LIQUIDACION ASC", Nothing)
    End Function

    Public Function InsertLiquidacion(nroLiquidacion As String, trabajador As Object, guia As Object,
                                 tracto As Object, camabaja As Object, origen As String,
                                 destino As String, salida As Date, llegada As Date,
                                 dinero As Double, peajes As Double, viaticos As Double,
                                 guardiania As Double, hospedaje As Double, balanaza As Double,
                                 otros As Double, fisico As Double, virtual As Double,
                                 estado As Object, carga As String, peso As Double, unidadMedida As Object) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@NUMERO_LIQUIDACION", nroLiquidacion))
        params.Add(New SqlParameter("@CODIGO_TRABAJADOR", trabajador))
        If guia = -1 Then
            params.Add(New SqlParameter("@CODIGO_GUIA", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CODIGO_GUIA", guia))
        End If

        params.Add(New SqlParameter("@CODIGO_UNIDAD_TRACTO", tracto))

        If camabaja = -1 Then
            params.Add(New SqlParameter("@CODIGO_UNIDAD_SEMITRAILER", DBNull.Value))
        Else
            params.Add(New SqlParameter("@CODIGO_UNIDAD_SEMITRAILER", camabaja))
        End If

        params.Add(New SqlParameter("@ORIGEN_LIQUIDACION", origen))
        params.Add(New SqlParameter("@DESTINO_LIQUIDACION", destino))
        params.Add(New SqlParameter("@FECHA_SALIDA", salida))
        params.Add(New SqlParameter("@FECHA_LLEGADA", llegada))
        params.Add(New SqlParameter("@DINERO_LIQUIDACION", dinero))
        params.Add(New SqlParameter("@PEAJES_LIQUIDACION", peajes))
        params.Add(New SqlParameter("@VIATICOS_LIQUIDACION", viaticos))
        params.Add(New SqlParameter("@GUARDIANIA_LIQUIDACION", guardiania))
        params.Add(New SqlParameter("@HOSPEDAJE_LIQUIDACION", hospedaje))
        params.Add(New SqlParameter("@BALANZA_LIQUIDACION", balanaza))
        params.Add(New SqlParameter("@OTROS_LIQUIDACION", otros))
        params.Add(New SqlParameter("@CONSUMO_FISICO_LIQUIDACION", fisico))
        params.Add(New SqlParameter("@CONSUMO_VIRTUAL_LIQUIDACION", virtual))
        params.Add(New SqlParameter("@CODIGO_ESTADO", estado))
        params.Add(New SqlParameter("@CARGA", carga))
        params.Add(New SqlParameter("@PESO", peso))
        params.Add(New SqlParameter("@UNIDAD_MEDIDA", unidadMedida))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertLiquidacion 
                                        @NUMERO_LIQUIDACION,
                                        @CODIGO_TRABAJADOR,
                                        @CODIGO_GUIA,
                                        @CODIGO_UNIDAD_TRACTO,
                                        @CODIGO_UNIDAD_SEMITRAILER,
                                        @ORIGEN_LIQUIDACION,
                                        @DESTINO_LIQUIDACION,
                                        @FECHA_SALIDA,
                                        @FECHA_LLEGADA,
                                        @DINERO_LIQUIDACION,
                                        @PEAJES_LIQUIDACION,
                                        @VIATICOS_LIQUIDACION,
                                        @GUARDIANIA_LIQUIDACION,
                                        @HOSPEDAJE_LIQUIDACION,
                                        @BALANZA_LIQUIDACION,
                                        @OTROS_LIQUIDACION,
                                        @CONSUMO_FISICO_LIQUIDACION,
                                        @CONSUMO_VIRTUAL_LIQUIDACION,
                                        @CODIGO_ESTADO,
                                        @CARGA,
                                        @PESO,
                                        @UNIDAD_MEDIDA ", params)

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

    Public Function UpdateLiquidacion(codigo As String, nroLiquidacion As String, trabajador As Object, guia As Object,
                                 tracto As Object, camabaja As Object, origen As String,
                                 destino As String, salida As Date, llegada As Date,
                                 dinero As Double, peajes As Double, viaticos As Double,
                                 guardiania As Double, hospedaje As Double, balanaza As Double,
                                 otros As Double, fisico As Double, virtual As Double,
                                 estado As Object, carga As String, peso As Double, unidadMedida As Object) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_LIQUIDACION", codigo))
        params.Add(New SqlParameter("@NUMERO_LIQUIDACION", nroLiquidacion))
        params.Add(New SqlParameter("@CODIGO_TRABAJADOR", trabajador))
        params.Add(New SqlParameter("@CODIGO_GUIA", guia))
        params.Add(New SqlParameter("@CODIGO_UNIDAD_TRACTO", tracto))
        params.Add(New SqlParameter("@CODIGO_UNIDAD_SEMITRAILER", camabaja))
        params.Add(New SqlParameter("@ORIGEN_LIQUIDACION", origen))
        params.Add(New SqlParameter("@DESTINO_LIQUIDACION", destino))
        params.Add(New SqlParameter("@FECHA_SALIDA", salida))
        params.Add(New SqlParameter("@FECHA_LLEGADA", llegada))
        params.Add(New SqlParameter("@DINERO_LIQUIDACION", dinero))
        params.Add(New SqlParameter("@PEAJES_LIQUIDACION", peajes))
        params.Add(New SqlParameter("@VIATICOS_LIQUIDACION", viaticos))
        params.Add(New SqlParameter("@GUARDIANIA_LIQUIDACION", guardiania))
        params.Add(New SqlParameter("@HOSPEDAJE_LIQUIDACION", hospedaje))
        params.Add(New SqlParameter("@BALANZA_LIQUIDACION", balanaza))
        params.Add(New SqlParameter("@OTROS_LIQUIDACION", otros))
        params.Add(New SqlParameter("@CONSUMO_FISICO_LIQUIDACION", fisico))
        params.Add(New SqlParameter("@CONSUMO_VIRTUAL_LIQUIDACION", virtual))
        params.Add(New SqlParameter("@CODIGO_ESTADO", estado))
        params.Add(New SqlParameter("@CARGA", carga))
        params.Add(New SqlParameter("@PESO", peso))
        params.Add(New SqlParameter("@UNIDAD_MEDIDA", unidadMedida))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateLiquidacion 
                                        @CODIGO_LIQUIDACION,
                                        @NUMERO_LIQUIDACION,
                                        @CODIGO_TRABAJADOR,
                                        @CODIGO_GUIA,
                                        @CODIGO_UNIDAD_TRACTO,
                                        @CODIGO_UNIDAD_SEMITRAILER,
                                        @ORIGEN_LIQUIDACION,
                                        @DESTINO_LIQUIDACION,
                                        @FECHA_SALIDA,
                                        @FECHA_LLEGADA,
                                        @DINERO_LIQUIDACION,
                                        @PEAJES_LIQUIDACION,
                                        @VIATICOS_LIQUIDACION,
                                        @GUARDIANIA_LIQUIDACION,
                                        @HOSPEDAJE_LIQUIDACION,
                                        @BALANZA_LIQUIDACION,
                                        @OTROS_LIQUIDACION,
                                        @CONSUMO_FISICO_LIQUIDACION,
                                        @CONSUMO_VIRTUAL_LIQUIDACION,
                                        @CODIGO_ESTADO,
                                        @CARGA,
                                        @PESO,
                                        @UNIDAD_MEDIDA ", params)
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

    Public Function UpdateLiquidacionCabeceraCombustible(codigo As String, tanque As Double, salida As Double, llegada As Double,
                                                 recorrido As Double, galonesLlega As Double, virtual As Double,
                                                 rutaDetalle As String, cargaDetalle As String, ajuste As Double, pesoDescripcion As String) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_LIQUIDACION", codigo))
        params.Add(New SqlParameter("@TANQUE", tanque))
        params.Add(New SqlParameter("@KM_SALIDA", salida))
        params.Add(New SqlParameter("@KM_LLEGADA", llegada))
        params.Add(New SqlParameter("@KM_RECORRIDO", recorrido))
        params.Add(New SqlParameter("@GALONES_LLEGA", galonesLlega))
        params.Add(New SqlParameter("@CONSUMO_VIRTUAL_LIQUIDACION", virtual))
        params.Add(New SqlParameter("@RUTA_DETALLE", rutaDetalle))
        params.Add(New SqlParameter("@CARGA_DETALLE", cargaDetalle))
        params.Add(New SqlParameter("@AJUSTE_GALONES", ajuste))
        params.Add(New SqlParameter("@PESO_DESCRIPCION", pesoDescripcion))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateLiquidacionCabeceraCombustible  
                                        @CODIGO_LIQUIDACION,
                                        @TANQUE,
                                        @KM_SALIDA,
                                        @KM_LLEGADA,
                                        @KM_RECORRIDO,
                                        @GALONES_LLEGA,
                                        @CONSUMO_VIRTUAL_LIQUIDACION,
                                        @RUTA_DETALLE,
                                        @CARGA_DETALLE,
                                        @AJUSTE_GALONES,
                                        @PESO_DESCRIPCION 
                                        ", params)
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

    Public Function InsertLiquidacionPeaje(codigo As Integer, fecha As Date, lugar As String, ejes As Integer, total As Double, nroLinea As Integer) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_LIQUIDACION", codigo))
        params.Add(New SqlParameter("@FECHA_PEAJE", fecha))
        params.Add(New SqlParameter("@LUGAR", lugar))
        params.Add(New SqlParameter("@EJES", ejes))
        params.Add(New SqlParameter("@TOTAL", total))
        params.Add(New SqlParameter("@NRO_LINEA", nroLinea))


        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertLiquidacionPeaje 
                                        @CODIGO_LIQUIDACION,
                                        @FECHA_PEAJE,
                                        @LUGAR,
                                        @EJES,
                                        @TOTAL,
                                        @NRO_LINEA ", params)

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

    Public Function GetLiquidacionPeajeByIdLiquidacion(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select	CODIGO_LIQUIDACION,
		                                    CODIGO_PEAJE,
                                            NRO_LINEA,
		                                    FECHA_PEAJE FECHA,
		                                    LUGAR,
		                                    EJES,
		                                    TOTAL
                                    from	LIQUIDACION_PEAJE
                                    where	CODIGO_LIQUIDACION=" + CStr(codigo) + " order by NRO_LINEA asc", Nothing)
    End Function

    Public Sub deleteLiquidacionPeajeById(codigo As Integer, peaje As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_LIQUIDACION", codigo))
        params.Add(New SqlParameter("@CODIGO_PEAJE", peaje))

        sqlControl.ExecQuery("EXECUTE deleteLiquidacionPeaje " +
                                        "@CODIGO_LIQUIDACION," +
                                        "@CODIGO_PEAJE ", params)
    End Sub

    Public Function InsertLiquidacionViatico(codigo As Integer, cantidad As Integer, turno As Date, descripcion As String, total As Double) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_LIQUIDACION", codigo))
        params.Add(New SqlParameter("@CANTIDAD", cantidad))
        params.Add(New SqlParameter("@TURNO", turno))
        params.Add(New SqlParameter("@DESCRIPCION", descripcion))
        params.Add(New SqlParameter("@TOTAL", total))


        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertLiquidacionViatico 
                                        @CODIGO_LIQUIDACION,
                                        @CANTIDAD,
                                        @TURNO,
                                        @DESCRIPCION,
                                        @TOTAL ", params)

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

    Public Sub deleteLiquidacionViaticoById(codigo As Integer, peaje As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_LIQUIDACION", codigo))
        params.Add(New SqlParameter("@CODIGO_PEAJE", peaje))

        sqlControl.ExecQuery("EXECUTE deleteLiquidacionPeaje " +
                                        "@CODIGO_LIQUIDACION," +
                                        "@CODIGO_PEAJE ", params)
    End Sub

    Public Function GetLiquidacionViaticoByIdLiquidacion(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select	CODIGO_LIQUIDACION,
		                                    CODIGO_Viatico,
		                                    CANTIDAD,
		                                    TURNO,
		                                    DESCRIPCION,
		                                    TOTAL 
                                    from	LIQUIDACION_VIATICO
                                    where	CODIGO_LIQUIDACION=" + CStr(codigo) + " 
                        ", Nothing)
    End Function

    Public Function InsertLiquidacionOtro(codigo As Integer, descripcion As String, total As Double) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_LIQUIDACION", codigo))
        params.Add(New SqlParameter("@DESCRIPCION", descripcion))
        params.Add(New SqlParameter("@TOTAL", total))


        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertLiquidacionOtro  
                                        @CODIGO_LIQUIDACION,
                                        @DESCRIPCION,
                                        @TOTAL ", params)

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

    Public Function InsertLiquidacionCombustible(codigo As Integer, fecha As Date, lugar As String,
                                                 galones As Double, precioGalon As Double, total As Double,
                                                 km As Double, linea As Integer) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_LIQUIDACION", codigo))
        params.Add(New SqlParameter("@FECHA", fecha))
        params.Add(New SqlParameter("@LUGAR", lugar))
        params.Add(New SqlParameter("@GALONES", galones))
        params.Add(New SqlParameter("@PRECIO_GALON", precioGalon))
        params.Add(New SqlParameter("@TOTAL", total))
        params.Add(New SqlParameter("@KM", km))
        params.Add(New SqlParameter("@NRO_LINEA", linea))


        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertLiquidacionCombustible   
                                        @CODIGO_LIQUIDACION,
                                        @FECHA,
                                        @LUGAR,
                                        @GALONES,
                                        @PRECIO_GALON,
                                        @TOTAL,
                                        @KM,
                                        @NRO_LINEA ", params)

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

    Public Function UpdateLiquidacionCombustible(codigo As Integer, combustible As Integer, fecha As Date, lugar As String,
                                                 galones As Double, precioGalon As Double, total As Double,
                                                 km As Double, nroLinea As Integer) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_LIQUIDACION", codigo))
        params.Add(New SqlParameter("@CODIGO_COMBUSTIBLE", combustible))
        params.Add(New SqlParameter("@FECHA", fecha))
        params.Add(New SqlParameter("@LUGAR", lugar))
        params.Add(New SqlParameter("@GALONES", galones))
        params.Add(New SqlParameter("@PRECIO_GALON", precioGalon))
        params.Add(New SqlParameter("@TOTAL", total))
        params.Add(New SqlParameter("@KM", km))
        params.Add(New SqlParameter("@NRO_LINEA", nroLinea))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateLiquidacionCombustible    
                                        @CODIGO_LIQUIDACION,
                                        @CODIGO_COMBUSTIBLE,
                                        @FECHA,
                                        @LUGAR,
                                        @GALONES,
                                        @PRECIO_GALON,
                                        @TOTAL,
                                        @KM,
                                        @NRO_LINEA ", params)

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

    Public Sub deleteLiquidacionOtroById(codigo As Integer, otro As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_LIQUIDACION", codigo))
        params.Add(New SqlParameter("@CODIGO_OTRO", otro))

        sqlControl.ExecQuery("EXECUTE deleteLiquidacionOtro " +
                                        "@CODIGO_LIQUIDACION," +
                                        "@CODIGO_OTRO ", params)
    End Sub

    Public Sub deleteLiquidacionCombustibleById(codigo As Integer, combustible As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_LIQUIDACION", codigo))
        params.Add(New SqlParameter("@CODIGO_COMBUSTIBLE", combustible))

        sqlControl.ExecQuery("EXECUTE deleteLiquidacionCombustible " +
                                        "@CODIGO_LIQUIDACION," +
                                        "@CODIGO_COMBUSTIBLE ", params)
    End Sub

    Public Function GetLiquidacionOtroByIdLiquidacion(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select	CODIGO_LIQUIDACION,
		                                    CODIGO_OTRO,
		                                    DESCRIPCION,
		                                    TOTAL 
                                    from	LIQUIDACION_OTRO 
                                    where	CODIGO_LIQUIDACION=" + CStr(codigo) + " 
                        ", Nothing)
    End Function

    Public Function GetLiquidacionCombustibleByIdLiquidacion(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select	CODIGO_LIQUIDACION,
		                                    CODIGO_COMBUSTIBLE,
                                            NRO_LINEA,
		                                    FECHA,
		                                    LUGAR,
		                                    GALONES,
		                                    PRECIO_GALON,
		                                    TOTAL,
                                            coalesce(KM,0) KM 
                                    from	LIQUIDACION_COMBUSTIBLE
                                    where	CODIGO_LIQUIDACION=" + CStr(codigo) + " 
                                    order   by  NRO_LINEA asc", Nothing)
    End Function

    Public Function getRptLiquidacionGeneral(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select	a.CODIGO_LIQUIDACION,
		                                    a.NUMERO_LIQUIDACION,
		                                    a.CODIGO_TRABAJADOR,
		                                    coalesce(b.NOMBRES_TRABAJADOR,'')+' '+coalesce(b.APELLIDO_PATERNO_TRABAJADOR,'')+' '+coalesce(b.APELLIDO_MATERNO_TRABAJADOR,'') TRABAJADOR,
		                                    a.CODIGO_GUIA,
		                                    c.DETALLE_GUIA,
		                                    a.CODIGO_UNIDAD_TRACTO,
		                                    d.PLACA_UNIDAD TRACTO,
		                                    a.CODIGO_UNIDAD_SEMITRAILER,
		                                    e.PLACA_UNIDAD SEMITRAILER,
		                                    a.ORIGEN_LIQUIDACION,
		                                    a.DESTINO_LIQUIDACION,
		                                    a.FECHA_SALIDA,
		                                    a.FECHA_LLEGADA,
		                                    a.DINERO_LIQUIDACION,
		                                    a.PEAJES_LIQUIDACION,
		                                    a.VIATICOS_LIQUIDACION,
		                                    a.GUARDIANIA_LIQUIDACION,
		                                    a.HOSPEDAJE_LIQUIDACION,
		                                    a.BALANZA_LIQUIDACION,
		                                    a.OTROS_LIQUIDACION,
		                                    a.CODIGO_ESTADO,
                                            a.CARGA, a.PESO, 
                                            a.UNIDAD_MEDIDA,
                                            coalesce(a.TANQUE,0)TANQUE,
                                            coalesce(a.KM_SALIDA,0)KM_SALIDA,
                                            coalesce(a.KM_LLEGADA,0)KM_LLEGADA,
                                            coalesce(a.KM_RECORRIDO,0)KM_RECORRIDO,
                                            coalesce(a.TOTAL_GASTO_COMBUSTIBLE,0)TOTAL_GASTO_COMBUSTIBLE,
                                            coalesce(a.GALONES_LLEGA,0)GALONES_LLEGA,
                                            coalesce(f.DETALLE_ESTADO,'') NOMBRE_UNIDAD_MEDIDA,
                                            coalesce(a.CONSUMO_FISICO_LIQUIDACION,0) CONSUMO_FISICO_LIQUIDACION,
                                            coalesce(a.CONSUMO_VIRTUAL_LIQUIDACION,0)  CONSUMO_VIRTUAL_LIQUIDACION 
                                    from	LIQUIDACION a 
                                    left	join TRABAJADOR b on a.CODIGO_TRABAJADOR=b.CODIGO_TRABAJADOR 
                                    left	join GUIA_TRANSPORTISTA c on c.CODIGO_GUIA=a.CODIGO_GUIA 
                                    left	join UNIDAD d on a.CODIGO_UNIDAD_TRACTO=d.CODIGO_UNIDAD 
                                    left	join UNIDAD e on a.CODIGO_UNIDAD_SEMITRAILER=e.CODIGO_UNIDAD 
                                    left	join ESTADO f on a.UNIDAD_MEDIDA=f.CODIGO_ESTADO and f.TIPO_ESTADO=8  
                                    where	CODIGO_LIQUIDACION=" + CStr(codigo) + " 
                        ", Nothing)
    End Function

    Public Function getRptLiquidacionGeneralDetalle(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select	CODIGO_LIQUIDACION,
		                                    CODIGO_OTRO,
		                                    DESCRIPCION,
		                                    TOTAL 
                                    from	LIQUIDACION_OTRO
                                    where	CODIGO_LIQUIDACION=" + CStr(codigo) + " 
                        ", Nothing)
    End Function

    Public Function getRptLiquidacionViajePeaje(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select	CODIGO_LIQUIDACION,
		                                    CODIGO_PEAJE,
		                                    FECHA_PEAJE,
		                                    LUGAR,
		                                    EJES,
		                                    TOTAL
                                    from	LIQUIDACION_PEAJE
                                    where	CODIGO_LIQUIDACION=" + CStr(codigo) + " 
                                    order by NRO_LINEA asc", Nothing)
    End Function

    Public Function getRptLiquidacionViajeViatico(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select	CODIGO_LIQUIDACION,
		                                    CODIGO_VIATICO,
		                                    CANTIDAD,
		                                    TURNO,
		                                    DESCRIPCION,
		                                    TOTAL
                                    from	LIQUIDACION_VIATICO
                                    where	CODIGO_LIQUIDACION=" + CStr(codigo) + " 
                        ", Nothing)
    End Function

    Public Function getRptLiquidacionCombustible(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select	CODIGO_LIQUIDACION,
		                                    CODIGO_COMBUSTIBLE,
		                                    FECHA,
		                                    LUGAR,
		                                    GALONES,
		                                    PRECIO_GALON,
		                                    TOTAL 
                                    from	LIQUIDACION_COMBUSTIBLE
                                    where	CODIGO_LIQUIDACION=" + CStr(codigo) + " 
                        ", Nothing)
    End Function

    'Public Function getRptLiquidacionViajeOtro(codigo As Integer) As DataTable

    '    Return sqlControl.ExecQuery("select	CODIGO_LIQUIDACION,
    '                                  CODIGO_OTRO,
    '                                  DESCRIPCION,
    '                                  TOTAL
    '                                from	LIQUIDACION_OTRO
    '                                where	CODIGO_LIQUIDACION=" + CStr(codigo) + " 
    '                    ", Nothing)
    'End Function

    Public Function getRptLiquidacionViajeOtro(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select	CODIGO_LIQUIDACION,
		                                    CODIGO_OTRO,
		                                    DESCRIPCION,
		                                    TOTAL
                                    from	LIQUIDACION_OTRO
                                    where	CODIGO_LIQUIDACION=" + CStr(codigo) + "
                                    UNION ALL
                                    SELECT	CODIGO_LIQUIDACION,
		                                    0 CODIGO_OTRO,
		                                    'HOSPEDAJE' DESCRIPCION,
		                                    HOSPEDAJE_LIQUIDACION TOTAL
                                    FROM	LIQUIDACION
                                    WHERE	CODIGO_LIQUIDACION=" + CStr(codigo) + " AND HOSPEDAJE_LIQUIDACION<>0
                                    UNION ALL
                                    SELECT	CODIGO_LIQUIDACION,
		                                    0 CODIGO_OTRO,
		                                    'GUARDIANÍA' DESCRIPCION,
		                                    GUARDIANIA_LIQUIDACION TOTAL
                                    FROM	LIQUIDACION
                                    WHERE	CODIGO_LIQUIDACION=" + CStr(codigo) + " AND GUARDIANIA_LIQUIDACION<>0
                                    UNION ALL
                                    SELECT	CODIGO_LIQUIDACION,
		                                    0 CODIGO_OTRO,
		                                    'BALANZA' DESCRIPCION,
		                                    BALANZA_LIQUIDACION TOTAL
                                    FROM	LIQUIDACION
                                    WHERE	CODIGO_LIQUIDACION=" + CStr(codigo) + " AND BALANZA_LIQUIDACION<>0", Nothing)
    End Function

    Public Function getRptLiquidacionCombustiblePrincipal(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("SELECT	a.CODIGO_LIQUIDACION,
		                                    a.FECHA_SALIDA,
		                                    a.FECHA_LLEGADA,
		                                    a.CODIGO_UNIDAD_TRACTO,
		                                    b.PLACA_UNIDAD TRACTO,
		                                    a.CODIGO_UNIDAD_SEMITRAILER,
		                                    c.PLACA_UNIDAD SEMITRAILER,
		                                    a.CODIGO_TRABAJADOR,
		                                    d.APELLIDO_PATERNO_TRABAJADOR+' '+d.APELLIDO_MATERNO_TRABAJADOR+' '+d.NOMBRES_TRABAJADOR TRABAJADOR,
		                                    a.RUTA_DETALLE,
		                                    a.CARGA_DETALLE,
		                                    a.PESO_DESCRIPCION,
		                                    a.KM_SALIDA,
		                                    a.KM_LLEGADA,
                                            a.KM_RECORRIDO,
		                                    a.CONSUMO_VIRTUAL_LIQUIDACION,
		                                    a.CONSUMO_FISICO_LIQUIDACION,
                                            (CASE WHEN a.AJUSTE_GALONES<0 THEN (a.AJUSTE_GALONES*-1) ELSE COALESCE(a.AJUSTE_GALONES,0) END) AJUSTE_GALONES,
                                            a.TOTAL_GALONES 
                                    FROM	LIQUIDACION a 
                                    LEFT	JOIN UNIDAD b on a.CODIGO_UNIDAD_TRACTO=b.CODIGO_UNIDAD
                                    LEFT	JOIN UNIDAD c on a.CODIGO_UNIDAD_SEMITRAILER=c.CODIGO_UNIDAD
                                    LEFT	join TRABAJADOR d on a.CODIGO_TRABAJADOR=d.CODIGO_TRABAJADOR
                                    where	CODIGO_LIQUIDACION=" + CStr(codigo) + "", Nothing)
    End Function

    Public Function getRptLiquidacionCombustiblePrincipalDetalle(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("SELECT	CODIGO_LIQUIDACION,
		                                    CODIGO_COMBUSTIBLE,
		                                    FECHA,
		                                    LUGAR,
		                                    GALONES,
		                                    KM 
                                    FROM	LIQUIDACION_COMBUSTIBLE
                                    WHERE	CODIGO_LIQUIDACION=" + CStr(codigo) + "", Nothing)
    End Function

    Public Function getRptLiquidacionByTrabajador(codigo As String) As DataTable

        Return sqlControl.ExecQuery("SELECT	A.CODIGO_LIQUIDACION,
		                                    A.NUMERO_LIQUIDACION,
		                                    A.CODIGO_TRABAJADOR,
		                                    COALESCE(B.NOMBRES_TRABAJADOR,'')+COALESCE(B.APELLIDO_PATERNO_TRABAJADOR,'')+COALESCE(B.APELLIDO_MATERNO_TRABAJADOR,'') TRABAJADOR,
		                                    A.CODIGO_GUIA,
		                                    C.DETALLE_GUIA,
		                                    A.CODIGO_UNIDAD_TRACTO,
		                                    D.PLACA_UNIDAD TRACTO,
		                                    A.CODIGO_UNIDAD_SEMITRAILER,
		                                    E.PLACA_UNIDAD SEMITRAILER,
		                                    A.ORIGEN_LIQUIDACION,
		                                    A.DESTINO_LIQUIDACION,
		                                    A.FECHA_SALIDA,
		                                    A.FECHA_LLEGADA,
		                                    A.DINERO_LIQUIDACION,
		                                    A.PEAJES_LIQUIDACION,
		                                    A.VIATICOS_LIQUIDACION,
		                                    A.GUARDIANIA_LIQUIDACION,
		                                    A.HOSPEDAJE_LIQUIDACION,
		                                    A.BALANZA_LIQUIDACION,
		                                    A.OTROS_LIQUIDACION,
		                                    A.CONSUMO_FISICO_LIQUIDACION,
		                                    A.CONSUMO_VIRTUAL_LIQUIDACION,
		                                    A.CODIGO_ESTADO,
		                                    F.DETALLE_ESTADO ESTADO_LIQUIDACION,
		                                    A.CARGA,
		                                    A.PESO,
		                                    A.UNIDAD_MEDIDA,
		                                    G.DETALLE_ESTADO DETALLE_UNIDAD
                                    FROM	LIQUIDACION A
                                    LEFT	JOIN TRABAJADOR B ON A.CODIGO_TRABAJADOR=B.CODIGO_TRABAJADOR
                                    LEFT	JOIN GUIA_TRANSPORTISTA C ON A.CODIGO_GUIA=C.CODIGO_GUIA
                                    LEFT	JOIN UNIDAD D ON D.CODIGO_UNIDAD=A.CODIGO_UNIDAD_TRACTO
                                    LEFT	JOIN UNIDAD E ON E.CODIGO_UNIDAD=A.CODIGO_UNIDAD_SEMITRAILER
                                    LEFT	JOIN ESTADO F ON F.CODIGO_ESTADO=A.CODIGO_ESTADO AND F.TIPO_ESTADO=1
                                    LEFT	JOIN ESTADO G ON G.CODIGO_ESTADO=A.UNIDAD_MEDIDA AND G.TIPO_ESTADO=8
                                    WHERE	A.CODIGO_TRABAJADOR LIKE '%" + codigo + "%' order	by TRABAJADOR", Nothing)
    End Function

    Public Function GetLiquidacionPeajeById(liquidacion As Integer, codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select	A.CODIGO_LIQUIDACION,
		                            A.CODIGO_PEAJE,
		                            A.NRO_LINEA,
		                            A.FECHA_PEAJE,
		                            A.LUGAR,
		                            A.EJES,
		                            A.TOTAL 
                            from	LIQUIDACION_PEAJE A 
                            WHERE	A.CODIGO_LIQUIDACION=" + CStr(liquidacion) + " AND CODIGO_PEAJE=" + CStr(codigo) + "", Nothing)
    End Function

    Public Function GetLiquidacionCombustibleById(liquidacion As Integer, codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("SELECT	CODIGO_LIQUIDACION,
		                                    CODIGO_COMBUSTIBLE,
		                                    NRO_LINEA,
		                                    FECHA,
		                                    LUGAR,
		                                    GALONES,
		                                    PRECIO_GALON,
		                                    TOTAL,
		                                    KM 
                                    FROM	LIQUIDACION_COMBUSTIBLE A 
                                    WHERE	A.CODIGO_LIQUIDACION=" + CStr(liquidacion) + " AND A.CODIGO_COMBUSTIBLE=" + CStr(codigo) + "", Nothing)
    End Function
    Public Function UpdateLiquidacionPeaje(liquidacion As Integer, peaje As Integer, fechaPeaje As Date,
                                           lugar As String, ejes As Integer, total As Double,
                                           nroLinea As Integer) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_LIQUIDACION", liquidacion))
        params.Add(New SqlParameter("@CODIGO_PEAJE", peaje))
        params.Add(New SqlParameter("@FECHA_PEAJE", fechaPeaje))
        params.Add(New SqlParameter("@LUGAR", lugar))
        params.Add(New SqlParameter("@EJES", ejes))
        params.Add(New SqlParameter("@TOTAL", total))
        params.Add(New SqlParameter("@NRO_LINEA", nroLinea))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateLiquidacionPeaje  
                                        @CODIGO_LIQUIDACION,
                                        @CODIGO_PEAJE,
                                        @FECHA_PEAJE,
                                        @LUGAR,
                                        @EJES,
                                        @TOTAL,
                                        @NRO_LINEA 
                                        ", params)
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
