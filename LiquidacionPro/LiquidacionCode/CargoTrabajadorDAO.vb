Imports System.Data
Imports System.Data.SqlClient
Public Class CargoTrabajadorDAO
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

    Public Function getAllCargoTrabajador() As DataTable
        'Se obtiene conductores y escoltas
        Return sqlControl.ExecQuery("select	CODIGO_CARGO_TRABAJADOR,
		                                    DESCRIPCION_CARGO_TRABAJADOR 
                                    from	CARGO_TRABAJADOR", Nothing)
    End Function

End Class
