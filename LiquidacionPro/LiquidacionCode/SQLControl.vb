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

    Public Sub SetConnection()
        DBcon.ConnectionString = "Server=MINOS; Database=TRANSCAR;User=sa; Pwd=Louisse98;"
    End Sub

    Public Function OpenConexion() As Boolean
        Try
            DBcon.Open()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error al abrir conexión. " + ex.Message, "Open Conexión",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function CloseConexion() As Boolean
        Try
            If DBcon.State = ConnectionState.Open Then
                DBcon.Close()
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Close Conexión",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Sub BeginTransaction()
        DBcmd = DBcon.CreateCommand()
        transaction = DBcon.BeginTransaction("trans")
        DBcmd.Connection = DBcon
        DBcmd.Transaction = transaction
    End Sub

    Public Sub CommitTransaction()
        transaction.Commit()
    End Sub

    Public Sub RollbackTransaccion()
        transaction.Rollback()
    End Sub

    Public Function GetDBcon() As SqlConnection
        Return DBcon
    End Function

    Public Function GetDBcmd() As SqlCommand
        Return DBcmd
    End Function


    Public Function ExecQuery(Query As String, params As List(Of SqlParameter)) As DataTable
        Dim RecordCount As String = ""
        Dim Exception As String = ""
        Dim DBT As DataTable
        Dim DBDA As SqlDataAdapter

        Try
            DBcmd.CommandText = Query
            If Not params Is Nothing Then
                params.ForEach(Sub(p) DBcmd.Parameters.Add(p))
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
