Imports System.Data
Imports System.Data.SqlClient
Public Class AsignacionServicioDAO
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
    Public Function InsertAsignacionServicio(fecha_asignacion As Date, observaciones As String, estadoAsignacion As Integer, codigoOrdenServicio As Integer) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@FECHA_ASIGNACION", fecha_asignacion))
        params.Add(New SqlParameter("@OBSERVACIONES_ASIGNACION", observaciones))
        params.Add(New SqlParameter("@ESTADO_ASIGNACION", estadoAsignacion))
        params.Add(New SqlParameter("@CODIGO_ORDEN_SERVICIO", codigoOrdenServicio))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertASIGNACION " +
                                        "@FECHA_ASIGNACION," +
                                        "@OBSERVACIONES_ASIGNACION," +
                                        "@ESTADO_ASIGNACION," +
                                        "@CODIGO_ORDEN_SERVICIO", params)
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
    Public Function updateAsignacionServicio(codigoAsignacion As Integer, fecha_asignacion As Date, observaciones As String, estadoAsignacion As Integer, codigoOrdenServicio As Integer) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_ASIGNACION", codigoAsignacion))
        params.Add(New SqlParameter("@FECHA_ASIGNACION", fecha_asignacion))
        params.Add(New SqlParameter("@OBSERVACIONES_ASIGNACION", observaciones))
        params.Add(New SqlParameter("@ESTADO_ASIGNACION", estadoAsignacion))
        params.Add(New SqlParameter("@CODIGO_ORDEN_SERVICIO", codigoOrdenServicio))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateASIGNACION " +
                                        "@CODIGO_ASIGNACION," +
                                        "@FECHA_ASIGNACION," +
                                        "@OBSERVACIONES_ASIGNACION," +
                                        "@ESTADO_ASIGNACION," +
                                        "@CODIGO_ORDEN_SERVICIO", params)
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
    Public Function deleteAsignacionServicio(codigoAsignacion As Integer) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_ASIGNACION", codigoAsignacion))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateASIGNACION " +
                                        "@CODIGO_ASIGNACION ", params)
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

    Public Function GetAllAsignaciones() As DataTable

        Return sqlControl.ExecQuery("SELECT	a.CODIGO_ASIGNACION_DETALLE as 'Codigo Asig Detalle',
		                                    b.CODIGO_ASIGNACION as 'Codigo Asignacion',
                                            convert(varchar(10),b.FECHA_ASIGNACION ,103)as 'Fecha Asignacion',
		                                    g.APELLIDO_PATERNO_TRABAJADOR+' '+g.APELLIDO_MATERNO_TRABAJADOR+', '+g.NOMBRES_TRABAJADOR as 'Trabajador',
		                                    e.PLACA_UNIDAD as 'Unidad',
		                                    f.PLACA_UNIDAD as 'Remolque',
		                                    c.ORIGEN as 'Origen',
		                                    c.DESTINO as 'Destino',
		                                    d.RAZON_CLIENTE as 'Razon Social',
                                            h.DETALLE_ESTADO as 'Estado'
                                    FROM ASIGNACION_SERVICIO_DETALLE a
                                        left join ASIGNACION_SERVICIO b on b.CODIGO_ASIGNACION = a.CODIGO_ASIGNACION_SERVICIO
                                        left join ORDEN_SERVICIO c on b.CODIGO_ORDEN_SERVICIO = c.CODIGO_ORDEN_SERVICIO
                                        left join CLIENTE d on c.CODIGO_CLIENTE = d.CODIGO_CLIENTE
                                        left join UNIDAD e on a.CODIGO_UNIDAD = e.CODIGO_UNIDAD
                                        left join UNIDAD f on a.CODIGO_CARRETA = f.CODIGO_UNIDAD
                                        left join TRABAJADOR g on g.CODIGO_TRABAJADOR = a.CODIGO_TRABAJADOR
                                        left join ESTADO h on h.CODIGO_ESTADO = b.ESTADO_ASIGNACION",
                                    Nothing)
    End Function

    Public Function GetAsignacionesCodigo(codigoAsignacion As Integer) As DataTable

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_ASIGNACION", codigoAsignacion))

        Return sqlControl.ExecQuery("SELECT	a.CODIGO_ASIGNACION 'codigo asignacion',
		                                    a.FECHA_ASIGNACION 'fecha asignacion',
		                                    COALESCE(a.OBSERVACION_ASIGNACION,'') 'observacion',
		                                    a.ESTADO_ASIGNACION 'estado',
		                                    b.NUMERO 'numero orden',
											b.ORIGEN 'Origen',
											b.DESTINO 'Destino'
                                    FROM ASIGNACION_SERVICIO a
                                        LEFT JOIN ORDEN_SERVICIO b ON a.CODIGO_ORDEN_SERVICIO = b.CODIGO_ORDEN_SERVICIO 
                                    WHERE CODIGO_ASIGNACION = @CODIGO_ASIGNACION",
                                    params)
    End Function

    Public Function getAsignacionesPedientes() As DataTable

        Return sqlControl.ExecQuery("SELECT	a.CODIGO_ASIGNACION 'Codigo Asignacion',
                                            b.FECHA 'Fecha',
		                                    b.NUMERO 'Nro Oden de Servicio',
		                                    c.DETALLE_ESTADO 'Estado'
                                     FROM ASIGNACION_SERVICIO a 
                                     LEFT JOIN ORDEN_SERVICIO b ON a.CODIGO_ORDEN_SERVICIO = b.CODIGO_ORDEN_SERVICIO
                                     LEFT JOIN ESTADO c ON c.CODIGO_ESTADO = a.ESTADO_ASIGNACION
                                     WHERE a.ESTADO_ASIGNACION = 39", Nothing)

    End Function

End Class
