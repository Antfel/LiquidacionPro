Imports System.Data
Imports System.Data.SqlClient
Public Class TrabajadorDAO
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

    Public Function GetTrabajador() As DataTable
        Return sqlControl.ExecQuery("SELECT CODIGO_TRABAJADOR,
                              coalesce(APELLIDO_PATERNO_TRABAJADOR,'') + ' '+
                              coalesce(APELLIDO_MATERNO_TRABAJADOR,'') + ', ' +
                              coalesce(NOMBRES_TRABAJADOR,'') as NOMBRE_TRABAJADOR
                        FROM TRABAJADOR where CODIGO_CARGO_TRABAJADOR = 1 AND CODIGO_ESTADO_TRABAJADOR = 4", Nothing)
    End Function
End Class
