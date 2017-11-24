Public Class GuiaDAO
    Public SQL As New SQLControl

    Public Function getGuia() As DataTable
        SQL.ExecQuery("SELECT CODIGO_GUIA, DETALLE_GUIA, CODIGO_ESTADO From GUIA_TRANSPORTISTA WHERE CODIGO_ESTADO = 8")

        Return SQL.DBT
    End Function
End Class
