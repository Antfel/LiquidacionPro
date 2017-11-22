Imports System.Data.SqlClient
Public Class SQLControl
    Private DBcon As New SqlConnection("Server=MINOS; Database=TRANSCAR;User=medinac; Pwd=Louisse98;")
    Private DBcmd As New SqlCommand
    Public DBDA As SqlDataAdapter
    Public DBT As DataTable
    Public Params As New List(Of SqlParameter)
    Public RecordCount As String
    Public Exception As String

    Public Sub New()

    End Sub

    Public Sub New(ConnectionString As String)
        DBcon = New SqlConnection(ConnectionString)
    End Sub

    Public Sub ExecQuery(Query As String)
        RecordCount = 0
        Exception = ""
        Try
            DBcon.Open()
            DBcmd = New SqlCommand(Query, DBcon)
            Params.ForEach(Sub(p) DBcmd.Parameters.Add(p))
            Params.Clear()
            DBT = New DataTable
            DBDA = New SqlDataAdapter(DBcmd)
            RecordCount = DBDA.Fill(DBT)
        Catch ex As Exception
            Exception = "ExecQuery Error: " & vbNewLine & ex.Message
        Finally
            If DBcon.State = ConnectionState.Open Then
                DBcon.Close()
            End If
        End Try
    End Sub

    Public Sub AddParam(Name As String, Value As Object)
        Dim NewParam As New SqlParameter(Name, Value)
        Params.Add(NewParam)
    End Sub

    Public Function HasException(Optional Report As Boolean = False) As Boolean
        If String.IsNullOrEmpty(Exception) Then
            Return False
        End If
        If Report = True Then
            MsgBox(Exception, MsgBoxStyle.Critical, "Exception: ")
        End If
        Return True
    End Function
End Class
