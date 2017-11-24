Public Class LiquidacionDAO
    Public SQL As New SQLControl

    Public Function GetAllLiquidacion() As DataTable
        SQL.ExecQuery("select		a.CODIGO_LIQUIDACION,
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
			                        a.CONSUMO_FISICO_LIQUIDACION,
			                        a.CONSUMO_VIRTUAL_LIQUIDACION,
			                        a.CODIGO_ESTADO,
			                        e.DETALLE_DESTADO
                        from		LIQUIDACION a
                        LEFT JOIN	UNIDAD b on a.CODIGO_UNIDAD_TRACTO=b.CODIGO_UNIDAD
                        LEFT JOIN	UNIDAD c on a.CODIGO_UNIDAD_SEMITRAILER=c.CODIGO_UNIDAD
                        LEFT JOIN	GUIA_TRANSPORTISTA d on d.CODIGO_GUIA=a.CODIGO_GUIA
                        LEFT JOIN	ESTADO e on e.CODIGO_ESTADO=a.CODIGO_ESTADO
                        LEFT JOIN	TRABAJADOR f on f.CODIGO_TRABAJADOR=a.CODIGO_TRABAJADOR
                        ORDER BY	CODIGO_LIQUIDACION ASC")
        Return SQL.DBT
    End Function

    Public Function GetLiquidacionById(codigo As Integer) As DataTable
        SQL.ExecQuery("select		a.CODIGO_LIQUIDACION,
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
			                        a.CONSUMO_FISICO_LIQUIDACION,
			                        a.CONSUMO_VIRTUAL_LIQUIDACION,
			                        a.CODIGO_ESTADO,
			                        e.DETALLE_DESTADO
                        from		LIQUIDACION a
                        LEFT JOIN	UNIDAD b on a.CODIGO_UNIDAD_TRACTO=b.CODIGO_UNIDAD
                        LEFT JOIN	UNIDAD c on a.CODIGO_UNIDAD_SEMITRAILER=c.CODIGO_UNIDAD
                        LEFT JOIN	GUIA_TRANSPORTISTA d on d.CODIGO_GUIA=a.CODIGO_GUIA
                        LEFT JOIN	ESTADO e on e.CODIGO_ESTADO=a.CODIGO_ESTADO
                        LEFT JOIN	TRABAJADOR f on f.CODIGO_TRABAJADOR=a.CODIGO_TRABAJADOR 
                        where       CODIGO_LIQUIDACION=" + CStr(codigo) + " 
                        ORDER BY	CODIGO_LIQUIDACION ASC")
        Return SQL.DBT
    End Function

    Public Sub InsertLiquidacion(nroLiquidacion As String, trabajador As Object, guia As Object,
                                 tracto As Object, camabaja As Object, origen As String,
                                 destino As String, salida As Date, llegada As Date,
                                 dinero As Long, peajes As Long, viaticos As Long,
                                 guardiania As Long, hospedaje As Long, balanaza As Long,
                                 otros As Long, fisico As Long, virtual As Long,
                                 estado As Object)

        SQL.AddParam("@NUMERO_LIQUIDACION", nroLiquidacion)
        SQL.AddParam("@CODIGO_TRABAJADOR", trabajador)
        SQL.AddParam("@CODIGO_GUIA", guia)
        SQL.AddParam("@CODIGO_UNIDAD_TRACTO", tracto)
        SQL.AddParam("@CODIGO_UNIDAD_SEMITRAILER", camabaja)
        SQL.AddParam("@ORIGEN_LIQUIDACION", origen)
        SQL.AddParam("@DESTINO_LIQUIDACION", destino)
        SQL.AddParam("@FECHA_SALIDA", salida)
        SQL.AddParam("@FECHA_LLEGADA", llegada)
        SQL.AddParam("@DINERO_LIQUIDACION", dinero)
        SQL.AddParam("@PEAJES_LIQUIDACION", peajes)
        SQL.AddParam("@VIATICOS_LIQUIDACION", viaticos)
        SQL.AddParam("@GUARDIANIA_LIQUIDACION", guardiania)
        SQL.AddParam("@HOSPEDAJE_LIQUIDACION", hospedaje)
        SQL.AddParam("@BALANZA_LIQUIDACION", balanaza)
        SQL.AddParam("@OTROS_LIQUIDACION", otros)
        SQL.AddParam("@CONSUMO_FISICO_LIQUIDACION", fisico)
        SQL.AddParam("@CONSUMO_VIRTUAL_LIQUIDACION", virtual)
        SQL.AddParam("@CODIGO_ESTADO", estado)

        SQL.ExecQuery("EXECUTE insertLiquidacion 
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
                                        @CODIGO_ESTADO")




    End Sub

    Public Sub UpdateLiquidacion(codigo As String, nroLiquidacion As String, trabajador As Object, guia As Object,
                                 tracto As Object, camabaja As Object, origen As String,
                                 destino As String, salida As Date, llegada As Date,
                                 dinero As Long, peajes As Long, viaticos As Long,
                                 guardiania As Long, hospedaje As Long, balanaza As Long,
                                 otros As Long, fisico As Long, virtual As Long,
                                 estado As Object)

        SQL.AddParam("@CODIGO_LIQUIDACION", codigo)
        SQL.AddParam("@NUMERO_LIQUIDACION", nroLiquidacion)
        SQL.AddParam("@CODIGO_TRABAJADOR", trabajador)
        SQL.AddParam("@CODIGO_GUIA", guia)
        SQL.AddParam("@CODIGO_UNIDAD_TRACTO", tracto)
        SQL.AddParam("@CODIGO_UNIDAD_SEMITRAILER", camabaja)
        SQL.AddParam("@ORIGEN_LIQUIDACION", origen)
        SQL.AddParam("@DESTINO_LIQUIDACION", destino)
        SQL.AddParam("@FECHA_SALIDA", salida)
        SQL.AddParam("@FECHA_LLEGADA", llegada)
        SQL.AddParam("@DINERO_LIQUIDACION", dinero)
        SQL.AddParam("@PEAJES_LIQUIDACION", peajes)
        SQL.AddParam("@VIATICOS_LIQUIDACION", viaticos)
        SQL.AddParam("@GUARDIANIA_LIQUIDACION", guardiania)
        SQL.AddParam("@HOSPEDAJE_LIQUIDACION", hospedaje)
        SQL.AddParam("@BALANZA_LIQUIDACION", balanaza)
        SQL.AddParam("@OTROS_LIQUIDACION", otros)
        SQL.AddParam("@CONSUMO_FISICO_LIQUIDACION", fisico)
        SQL.AddParam("@CONSUMO_VIRTUAL_LIQUIDACION", virtual)
        SQL.AddParam("@CODIGO_ESTADO", estado)

        SQL.ExecQuery("EXECUTE updateLiquidacion 
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
                                        @CODIGO_ESTADO")




    End Sub
End Class
