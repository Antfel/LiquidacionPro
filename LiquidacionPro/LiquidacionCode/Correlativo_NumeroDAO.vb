Imports System.Data
Imports System.Data.SqlClient
Public Class Correlativo_NumeroDAO
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

    Public Function GetSiguienteCorrelativo(codigo_correlativo As Integer, serie As String) As String

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@codigo_correlativo", codigo_correlativo))
        params.Add(New SqlParameter("@serie", serie))

        Dim dt As DataTable

        dt = sqlControl.ExecQuery("EXECUTE selectSiguienteCorrelativo " +
                                        "@codigo_correlativo," +
                                        "@serie ", params)

        If dt.Rows.Count > 0 Then
            Return CStr(dt.Rows.Item(0).Item(0))
        Else
            Return "-"
        End If
    End Function

End Class
