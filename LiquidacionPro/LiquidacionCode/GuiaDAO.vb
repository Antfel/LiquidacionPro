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

    Public Sub InsertLiquidacion(detalleGuia As String, estado As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@DETALLE_GUIA", detalleGuia))
        params.Add(New SqlParameter("@CODIGO_ESTADO", 7))

        sqlControl.ExecQuery("EXECUTE insertGuia 
                                        @DETALLE_GUIA,
                                        @CODIGO_ESTADO", params)
    End Sub

    Public Function getGuiaByNroGuia(nro_guia As String) As DataTable
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@NRO_GUIA", nro_guia))
        Return sqlControl.ExecQuery("SELECT CODIGO_GUIA, DETALLE_GUIA, CODIGO_ESTADO From GUIA_TRANSPORTISTA WHERE DETALLE_GUIA = @NRO_GUIA", params)

        SQL.ExecQuery("SELECT CODIGO_GUIA, DETALLE_GUIA, CODIGO_ESTADO From GUIA_TRANSPORTISTA WHERE DETALLE_GUIA = " + nro_guia)

        Return SQL.DBT

    End Function

End Class
