Imports System.Data
Imports System.Data.SqlClient
Public Class ClienteDAO
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

    Public Function GetClientes() As DataTable
        Return sqlControl.ExecQuery("Select CODIGO_CLIENTE, RUC_CLIENTE, RAZON_CLIENTE, DIRECCION_CLIENTE, TELEFONO_CLIENTE from CLIENTE", Nothing)
    End Function

    Public Function GetClienteByRuc(ruc_Cliente As String) As DataTable
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@RUC_CLIENTE", ruc_Cliente))
        Return sqlControl.ExecQuery("Select CODIGO_CLIENTE, RUC_CLIENTE, RAZON_CLIENTE, DIRECCION_CLIENTE, TELEFONO_CLIENTE from CLIENTE where RUC_CLIENTE=@RUC_CLIENTE", params)

    End Function

    Public Function GetClienteByCodigo(codigo As String) As DataTable
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_CLIENTE", codigo))
        Return sqlControl.ExecQuery("Select CODIGO_CLIENTE, RUC_CLIENTE, RAZON_CLIENTE, DIRECCION_CLIENTE, TELEFONO_CLIENTE from CLIENTE where CODIGO_CLIENTE=@CODIGO_CLIENTE", params)

    End Function
End Class
