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

End Class
