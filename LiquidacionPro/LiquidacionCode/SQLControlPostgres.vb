Imports Npgsql


Public Class SQLControlPostgres
    'Private DBcon As New SqlConnection
    'Private DBcmd As SqlCommand
    'Public DBDA As SqlDataAdapter
    'Public DBT As DataTable
    'Public Params As New List(Of SqlParameter)
    'Public RecordCount As String
    'Public Exception As String
    'Private transaction As SqlTransaction
    Dim myConnection As NpgsqlConnection

    Public Sub New()

    End Sub

    Public Sub setConnection()
        'DBcon.ConnectionString = "Server=localhost;Port=5432;Database=20518904429;User Id=readuser;Password=12345678;"

        myConnection = New NpgsqlConnection()
        myConnection.ConnectionString = "Server=localhost;Port=5432;Database=20518904427;User Id=readuser;Password=12345678;"

        ' execute queries, etc

    End Sub

    Public Function openConexion() As Boolean
        Try
            'DBcon.Open()
            myConnection.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function closeConexion() As Boolean
        Try
            'DBcon.Close()
            myConnection.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Public Sub beginTransaction()
    '    DBcmd = DBcon.CreateCommand()
    '    transaction = DBcon.BeginTransaction("trans")
    '    DBcmd.Connection = DBcon
    '    DBcmd.Transaction = transaction
    'End Sub

    'Public Sub commitTransaction()
    '    transaction.Commit()
    'End Sub

    'Public Sub rollbackTransaccion()
    '    transaction.Rollback()
    'End Sub

    'Public Function getDBcon() As SqlConnection
    '    Return DBcon
    'End Function

    'Public Function getDBcmd() As SqlCommand
    '    Return DBcmd
    'End Function


    'Public Function ExecQuery(Query As String, params As List(Of SqlParameter)) As DataTable
    '    Dim RecordCount As String = ""
    '    Dim Exception As String = ""
    '    Dim DBT As DataTable
    '    Dim DBDA As SqlDataAdapter

    '    Try
    '        'DBcon.Open()
    '        'DBcmd = New SqlCommand(Query, DBcon)
    '        DBcmd.CommandText = Query
    '        If Not params Is Nothing Then
    '            params.ForEach(Sub(p) DBcmd.Parameters.Add(p))
    '            'Params.Clear()
    '        End If

    '        DBT = New DataTable
    '        DBDA = New SqlDataAdapter(DBcmd)
    '        RecordCount = DBDA.Fill(DBT)
    '        Return DBT
    '    Catch ex As Exception
    '        Exception = "ExecQuery Error: " & vbNewLine & ex.Message
    '        MsgBox(Exception, MsgBoxStyle.Critical, "Exception: ")
    '        Return Nothing
    '    Finally
    '        If DBcon.State = ConnectionState.Open Then
    '            'DBcon.Close()
    '        End If
    '    End Try
    'End Function

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

    Public Function ExecQuery(query As String) As DataTable
        Dim RecordCount As String = ""
        Dim Exception As String = ""
        Dim dt As DataTable
        'Dim DBDA As SqlDataAdapter

        Try

            'Dim cmd As New NpgsqlCommand(query, myConnection)
            'Dim da As New NpgsqlDataAdapter(cmd)

            ''Dim dr As NpgsqlDataReader = cmd.ExecuteReader()
            'da.Fill(dt)

            Dim pgCommand As NpgsqlCommand = New NpgsqlCommand
            pgCommand.Connection = myConnection
            pgCommand.CommandType = CommandType.Text
            pgCommand.CommandText = query

            Dim sda As NpgsqlDataAdapter

            sda = New NpgsqlDataAdapter(pgCommand)

            Dim ds As DataSet
            ds = New DataSet
            sda.Fill(ds)
            dt = ds.Tables(0)
            Return dt
        Catch ex As Exception
            Exception = "ExecQuery Error: " + ex.Message
            MsgBox(Exception, MsgBoxStyle.Critical, "Exception: ")
            Return Nothing
        Finally
            'If DBcon.State = ConnectionState.Open Then
            '    'DBcon.Close()
            'End If
        End Try
    End Function
End Class
