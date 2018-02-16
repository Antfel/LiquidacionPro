Imports Npgsql
Imports NpgsqlTypes

Public Class SQLControlPostgres
    'Private DBcon As New SqlConnection
    'Private DBcmd As SqlCommand
    'Public DBDA As SqlDataAdapter
    'Public DBT As DataTable
    'Public Params As New List(Of SqlParameter)
    'Public RecordCount As String
    'Public Exception As String
    'Private transaction As SqlTransaction
    Dim con As NpgsqlConnection

    Public Sub New()

    End Sub

    Public Sub setConnection()
        con = New NpgsqlConnection()
        'con.ConnectionString = "Server=rad-laptop;Port=5432;Database=20518904427;User Id=postgres;Password=sistemas;"
        con.ConnectionString = "Server=localhost;Port=5432;Database=20518904427;User Id=readuser;Password=12345678;"
    End Sub

    Public Function openConexion() As Boolean
        Try
            con.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function closeConexion() As Boolean
        Try
            con.Close()
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

    Public Function ExecQuery(query As String, params As List(Of NpgsqlParameter)) As DataTable
        Dim RecordCount As String = ""
        Dim Exception As String = ""
        Dim dt As DataTable

        Try

            Dim cmd As NpgsqlCommand = New NpgsqlCommand
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            If Not params Is Nothing Then
                params.ForEach(Sub(p) cmd.Parameters.Add(p))
            End If

            Dim da As NpgsqlDataAdapter
            da = New NpgsqlDataAdapter(cmd)

            Dim ds As DataSet
            ds = New DataSet
            da.Fill(ds)
            dt = ds.Tables(0)

            Return dt
        Catch ex As NpgsqlException
            Exception = "ExecQuery Error: "
            MsgBox(Exception, MsgBoxStyle.Critical, "Exception: " + ex.Message)
            Return Nothing
        Finally

        End Try
    End Function
End Class
