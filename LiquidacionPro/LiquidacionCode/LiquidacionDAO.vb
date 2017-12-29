Imports System.Data
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
			                        a.CONSUMO_FISICO_LIQUIDACION,
			                        a.CONSUMO_VIRTUAL_LIQUIDACION,
			                        a.CODIGO_ESTADO,
			                        e.DETALLE_ESTADO,
                                    (coalesce(a.PEAJES_LIQUIDACION,0)+coalesce(a.VIATICOS_LIQUIDACION,0)+coalesce(a.GUARDIANIA_LIQUIDACION,0)+
			                        coalesce(a.HOSPEDAJE_LIQUIDACION,0)+coalesce(a.BALANZA_LIQUIDACION,0)+coalesce(a.OTROS_LIQUIDACION,0)) TOTAL_GASTO,
			                        (coalesce(a.DINERO_LIQUIDACION,0)-(coalesce(a.PEAJES_LIQUIDACION,0)+coalesce(a.VIATICOS_LIQUIDACION,0)+coalesce(a.GUARDIANIA_LIQUIDACION,0)+
			                        coalesce(a.HOSPEDAJE_LIQUIDACION,0)+coalesce(a.BALANZA_LIQUIDACION,0)+coalesce(a.OTROS_LIQUIDACION,0)))DIFERENCIA,
                                    a.CONSUMO_FISICO_LIQUIDACION-a.CONSUMO_VIRTUAL_LIQUIDACION DIFERENCIA_CONSUMO
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
                                 estado As Object) As Integer

        Dim params As New List(Of SqlParameter)
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
        params.Add(New SqlParameter("@CONSUMO_FISICO_LIQUIDACION", virtual))
        params.Add(New SqlParameter("@CONSUMO_VIRTUAL_LIQUIDACION", nroLiquidacion))
        params.Add(New SqlParameter("@CODIGO_ESTADO", estado))

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
                                        @CODIGO_ESTADO", params)

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
                                 estado As Object) As Integer

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
                                        @CODIGO_ESTADO", params)
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
