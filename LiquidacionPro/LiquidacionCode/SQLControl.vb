Imports System.Data.SqlClient
Public Class SQLControl
    Private DBcon As New SqlConnection
    Private DBcmd As SqlCommand
    'Public DBDA As SqlDataAdapter
    'Public DBT As DataTable
    'Public Params As New List(Of SqlParameter)
    'Public RecordCount As String
    'Public Exception As String
    Private transaction As SqlTransaction


    Public Sub New()

    End Sub

    Public Sub setConnection()
        DBcon.ConnectionString = "Server=MINOS; Database=TRANSCAR;User=medinac; Pwd=Louisse98;"
    End Sub

    Public Function openConexion() As Boolean
        Try
            DBcon.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function closeConexion() As Boolean
        Try
            DBcon.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub beginTransaction()
        DBcmd = DBcon.CreateCommand()
        transaction = DBcon.BeginTransaction("trans")
        DBcmd.Connection = DBcon
        DBcmd.Transaction = transaction
    End Sub

    Public Sub commitTransaction()
        transaction.Commit()
    End Sub

    Public Sub rollbackTransaccion()
        transaction.Rollback()
    End Sub

    Public Function getDBcon() As SqlConnection
        Return DBcon
    End Function

    Public Function getDBcmd() As SqlCommand
        Return DBcmd
    End Function


    Public Function ExecQuery(Query As String, params As List(Of SqlParameter)) As DataTable
        Dim RecordCount As String = ""
        Dim Exception As String = ""
        Dim DBT As DataTable
        Dim DBDA As SqlDataAdapter

        Try
            'DBcon.Open()
            'DBcmd = New SqlCommand(Query, DBcon)
            DBcmd.CommandText = Query
            If Not params Is Nothing Then
                params.ForEach(Sub(p) DBcmd.Parameters.Add(p))
                'Params.Clear()
            End If

            DBT = New DataTable
            DBDA = New SqlDataAdapter(DBcmd)
            RecordCount = DBDA.Fill(DBT)
            Return DBT
        Catch ex As Exception
            Exception = "ExecQuery Error: " & vbNewLine & ex.Message
            MsgBox(Exception, MsgBoxStyle.Critical, "Exception: ")
            Return Nothing
        Finally
            If DBcon.State = ConnectionState.Open Then
                'DBcon.Close()
            End If
        End Try
    End Function

    'Public Sub AddParam(Name As String, Value As Object)
    '    Dim NewParam As New SqlParameter(Name, Value)
    '    Params.Add(NewParam)
    'End Sub

    'Public Function HasException(Optional Report As Boolean = False, Optional Exception As String = "") As Boolean
    '    If String.IsNullOrEmpty(Exception) Then
    '        Return False
    '    End If
    '    If Report = True Then
    '        MsgBox(Exception, MsgBoxStyle.Critical, "Exception: ")
    '    End If
    '    Return True
    'End Function
End Class
