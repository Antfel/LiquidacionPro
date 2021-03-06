﻿Imports System.Data
Imports System.Data.SqlClient
Public Class BancoDAO
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

    Public Function GetAllBanco() As DataTable
        Return sqlControl.ExecQuery("select	CODIGO_BANCO,
                                            NOMBRE_BANCO,
                                            ABREVIATURA 
                                    from    BANCO order by CODIGO_BANCO asc", Nothing)

    End Function

    Public Function InsertBanco(nombre As String, abreviatura As String) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@NOMBRE_BANCO", nombre))
        params.Add(New SqlParameter("@ABREVIATURA", abreviatura))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertBanco " +
                                        "@NOMBRE_BANCO," +
                                        "@ABREVIATURA ", params)
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

    Public Function UpdateBanco(codigo As Integer, nombre As String, abreviatura As String) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_BANCO", codigo))
        params.Add(New SqlParameter("@NOMBRE_BANCO", nombre))
        params.Add(New SqlParameter("@ABREVIATURA", abreviatura))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateBanco " +
                                        "@CODIGO_BANCO, " +
                                        "@NOMBRE_BANCO," +
                                        "@ABREVIATURA ", params)
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
    Public Function DeleteBanco(codigo As Integer, nombre As String, abreviatura As String) As Integer


        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_BANCO", codigo))
        params.Add(New SqlParameter("@NOMBRE_BANCO", nombre))
        params.Add(New SqlParameter("@ABREVIATURA", abreviatura))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE deleteBanco " +
                                        "@CODIGO_BANCO ", params)
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
