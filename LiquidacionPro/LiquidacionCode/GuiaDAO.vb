Imports System.Data
Imports System.Data.SqlClient
Public Class GuiaDAO
    Dim DBcon As SqlConnection
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

    Public Function getGuiaPendLiquidacion() As DataTable
        Return sqlControl.ExecQuery("SELECT CODIGO_GUIA, DETALLE_GUIA, CODIGO_ESTADO From GUIA_TRANSPORTISTA WHERE CODIGO_ESTADO = 8 OR CODIGO_ESTADO = 17", Nothing)
    End Function

    Public Function getGuiaPendFacturacion() As DataTable
        Return sqlControl.ExecQuery("SELECT CODIGO_GUIA, DETALLE_GUIA, CODIGO_ESTADO From GUIA_TRANSPORTISTA WHERE CODIGO_ESTADO = 7 OR CODIGO_ESTADO = 17", Nothing)
    End Function

    Public Function InsertGuia(detalleGuia As String, estado As Integer, fechaLiquidacion As Date, fechaFacturacion As Date) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@DETALLE_GUIA", detalleGuia))
        params.Add(New SqlParameter("@CODIGO_ESTADO", 7))
        params.Add(New SqlParameter("@FECHA_LIQUIDACION", fechaLiquidacion))
        params.Add(New SqlParameter("@FECHA_FACTURACION", fechaFacturacion))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertGuia " +
                                        "@DETALLE_GUIA," +
                                        "@CODIGO_ESTADO," +
                                        "@FECHA_LIQUIDACION," +
                                        "@FECHA_FACTURACION ", params)
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
                                estado As Integer, fechaLiquidacion As Date, fechaFacturacion As Date) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_GUIA", codigo))
        params.Add(New SqlParameter("@DETALLE_GUIA", detalleGuia))
        params.Add(New SqlParameter("@CODIGO_ESTADO", 7))
        params.Add(New SqlParameter("@FECHA_LIQUIDACION", fechaLiquidacion))
        params.Add(New SqlParameter("@FECHA_FACTURACION", fechaFacturacion))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateGuia " +
                                        "@CODIGO_GUIA," +
                                        "@DETALLE_GUIA," +
                                        "@CODIGO_ESTADO," +
                                        "@FECHA_LIQUIDACION," +
                                        "@FECHA_FACTURACION ", params)
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
        Return sqlControl.ExecQuery("select	a.CODIGO_GUIA,
		a.DETALLE_GUIA,
		a.CODIGO_ESTADO,
		a.FECHA_LIQUIDACION,
		a.FECHA_FACTURACION,
		b.DETALLE_ESTADO
from	GUIA_TRANSPORTISTA a
left	join ESTADO b on a.CODIGO_ESTADO=b.CODIGO_ESTADO and TIPO_ESTADO=3", Nothing)

    End Function

    Public Function getGuiaByCodigo(codigo As Integer) As DataTable
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@codigo", codigo))
        Return sqlControl.ExecQuery("SELECT  CODIGO_GUIA, " +
                                            "DETALLE_GUIA, " +
                                            "CODIGO_ESTADO, " +
                                            "FECHA_LIQUIDACION, " +
                                            "FECHA_FACTURACION " +
                                    "From GUIA_TRANSPORTISTA " +
                                    "WHERE CODIGO_GUIA = @codigo", params)
    End Function

End Class
