Imports System.Data
Imports System.Data.SqlClient
Public Class Correlativo_NumeroDAO
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

    Public Function GetAllCorrelativo() As DataTable
        Dim dt As DataTable
        dt = sqlControl.ExecQuery("select		CODIGO_CORRELATIVO CODIGO,
			                                    DESCRIPCION
                                    from		CORRELATIVO
                                    order by	codigo_correlativo asc", Nothing)

        Return dt
    End Function

    Public Function GetAllCorrelativoNumeroByCorrelativo(codigo As Integer) As DataTable

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("select		CODIGO_CORRELATIVO CODIGO,
                                                DETALLE_CORRELATIVO DETALLE,
			                                    SERIE,
			                                    ULTIMO_USADO 'ULTIMO USADO' 
                                    from		CORRELATIVO_NUMERO
                                    where		CODIGO_CORRELATIVO=" + CStr(codigo) + "
                                    order by	codigo_correlativo asc", Nothing)

        Return dt
    End Function

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

    Public Function GetValidaSerieNroFactura(nroFactura As String, serie As String) As Integer

        Dim dt As DataTable

        dt = sqlControl.ExecQuery("select count(*) from FACTURA
                                    where	NUMERO_FACTURA='" + nroFactura + "' and SERIE_FACTURA='" + serie + "' and CODIGO_ESTADO=16", Nothing)

        If dt.Rows.Count > 0 Then
            Return CInt(dt.Rows.Item(0).Item(0))
        Else
            Return 0
        End If
    End Function

    Public Function updateCorrelativoNumero(codigo_correlativo As Integer, serie As String,
                                                      ultimo As String) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_CORRELATIVO1", codigo_correlativo))
        params.Add(New SqlParameter("@SERIE1", serie))
        params.Add(New SqlParameter("@ULTIMO_USADO1", ultimo))

        Dim dt As DataTable

        dt = sqlControl.ExecQuery("EXECUTE updateCorrelativoNumero 
                                        @CODIGO_CORRELATIVO1,
                                        @SERIE1,
                                        @ULTIMO_USADO1", params)

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
