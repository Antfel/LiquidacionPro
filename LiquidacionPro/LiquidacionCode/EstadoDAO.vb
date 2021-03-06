﻿Imports System.Data
Imports System.Data.SqlClient
Public Class EstadoDAO
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

    Public Function getEstados() As DataTable
        Return sqlControl.ExecQuery("SELECT CODIGO_ESTADO,DETALLE_ESTADO from ESTADO where TIPO_ESTADO = 1", Nothing)
    End Function
    Public Function getEstadoTrabajador() As DataTable
        Return sqlControl.ExecQuery("SELECT CODIGO_ESTADO,DETALLE_ESTADO from ESTADO where TIPO_ESTADO = 2", Nothing)
    End Function

    Public Function getEstadoAsignacion() As DataTable
        Return sqlControl.ExecQuery("SELECT CODIGO_ESTADO,DETALLE_ESTADO from ESTADO where TIPO_ESTADO = 9", Nothing)
    End Function

End Class
