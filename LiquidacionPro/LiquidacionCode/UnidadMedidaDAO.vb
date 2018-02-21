Imports System.Data
Imports System.Data.SqlClient
Public Class UnidadMedidaDAO
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

    Public Function getAllUnidadMedida() As DataTable
        Return sqlControl.ExecQuery("select	CODIGO_ESTADO,
		                                    TIPO_ESTADO,
		                                    DESCRIPCION,
		                                    DETALLE_ESTADO,
		                                    DETALLE_ESTADO_COMPLETO 
                                    from	ESTADO where TIPO_ESTADO=8", Nothing)
    End Function
End Class
