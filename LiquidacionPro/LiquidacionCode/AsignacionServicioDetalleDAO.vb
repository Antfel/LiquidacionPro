Imports System.Data
Imports System.Data.SqlClient
Public Class AsignacionServicioDetalleDAO
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
    Public Function InsertAsignacionServicioDetalle(codigoAsignacionServicio As Integer, codigoUnidad As Integer, codigoCarreta As Integer, codigoTrabajador As Integer, codigoOrdenServicioDetalle As Integer) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_ASIGNACION_SERVICIO", codigoAsignacionServicio))
        params.Add(New SqlParameter("@CODIGO_UNIDAD", codigoUnidad))
        params.Add(New SqlParameter("@CODIGO_CARRETA", codigoCarreta))
        params.Add(New SqlParameter("@CODIGO_TRABAJADOR", codigoTrabajador))
        params.Add(New SqlParameter("@CODIGO_ORDEN_SERVICIO_DETALLE", codigoOrdenServicioDetalle))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertASIGNACIONDETALLE " +
                                        "@CODIGO_ASIGNACION_SERVICIO," +
                                        "@CODIGO_UNIDAD," +
                                        "@CODIGO_CARRETA," +
                                        "@CODIGO_TRABAJADOR," +
                                        "@CODIGO_ORDEN_SERVICIO_DETALLE", params)
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
    Public Function updateAsignacionServicioDetalle(codigoAsignacionServicioDetalle As Integer, codigoAsignacionServicio As Integer, codigoUnidad As Integer, codigoCarreta As Integer, codigoTrabajador As Integer, codigoOrdenServicioDetalle As Integer) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_ASIGNACION_DETALLE", codigoAsignacionServicioDetalle))
        params.Add(New SqlParameter("@CODIGO_ASIGNACION_SERVICIO", codigoAsignacionServicio))
        params.Add(New SqlParameter("@CODIGO_UNIDAD", codigoUnidad))
        params.Add(New SqlParameter("@CODIGO_CARRETA", codigoCarreta))
        params.Add(New SqlParameter("@CODIGO_TRABAJADOR", codigoTrabajador))
        params.Add(New SqlParameter("@CODIGO_ORDEN_SERVICIO_DETALLE", codigoOrdenServicioDetalle))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateASIGNACIONDETALLE " +
                                        "@CODIGO_ASIGNACION_DETALLE," +
                                        "@CODIGO_ASIGNACION_SERVICIO," +
                                        "@CODIGO_UNIDAD," +
                                        "@CODIGO_CARRETA," +
                                        "@CODIGO_TRABAJADOR," +
                                        "@CODIGO_ORDEN_SERVICIO_DETALLE", params)
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
    Public Function deteleAsignacionServicioDetalle(codigoAsignacionServicioDetalle As Integer) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_ASIGNACION_DETALLE", codigoAsignacionServicioDetalle))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE deleteASIGANCIONDETALLE " +
                                        "@CODIGO_ASIGNACION_DETALLE", params)
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

    Public Function getDetalleAsignacion(codigoAsignacion As Integer) As DataTable
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_ASIGNACION", codigoAsignacion))

        Return sqlControl.ExecQuery("SELECT	a.CODIGO_ASIGNACION_DETALLE 'Codigo Detalle',
		                                    f.DETALLE_ESTADO 'Tipo de Servicio',
		                                    b.PLACA_UNIDAD as 'Unidad',
		                                    c.PLACA_UNIDAD as 'Remolque',
		                                    d.APELLIDO_PATERNO_TRABAJADOR+' '+d.APELLIDO_MATERNO_TRABAJADOR+', '+d.NOMBRES_TRABAJADOR as 'Trabajador'
                                    FROM ASIGNACION_SERVICIO_DETALLE a
                                    LEFT JOIN UNIDAD b ON a.CODIGO_UNIDAD = b.CODIGO_UNIDAD
                                    LEFT JOIN UNIDAD c ON a.CODIGO_CARRETA = c.CODIGO_UNIDAD
                                    LEFT JOIN TRABAJADOR d ON a.CODIGO_TRABAJADOR = d.CODIGO_TRABAJADOR
                                    LEFT JOIN ORDEN_SERVICIO_DETALLE e ON a.CODIGO_ORDEN_SERVICIO_DETALLE = e.CODIGO_ORDEN_SERVICIO_DETALLE
                                    LEFT JOIN ESTADO f ON e.CODIGO_TIPO_SERVICIO = f.CODIGO_ESTADO
                                    WHERE a.CODIGO_ASIGNACION_SERVICIO = @CODIGO_ASIGNACION",
                                    params)
    End Function

End Class
