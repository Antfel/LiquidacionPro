Imports System.Data
Imports System.Data.SqlClient
Public Class CargoTrabajadorDAO
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

    Public Function getAllCargoTrabajador() As DataTable
        'Se obtiene conductores y escoltas
        Return sqlControl.ExecQuery("select	CODIGO_CARGO_TRABAJADOR,
		                                    DESCRIPCION_CARGO_TRABAJADOR 
                                    from	CARGO_TRABAJADOR", Nothing)
    End Function

End Class
