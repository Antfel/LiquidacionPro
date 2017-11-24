Public Class EstadoDAO
    Public SQL As New SQLControl

    Public Function getEstados() As DataTable
        SQL.ExecQuery("SELECT CODIGO_ESTADO,DETALLE_DESTADO from ESTADO where TIPO_ESTADO = 1")
        Return SQL.DBT
    End Function
End Class
