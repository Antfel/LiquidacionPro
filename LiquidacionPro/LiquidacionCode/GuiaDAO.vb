Public Class GuiaDAO
    Public SQL As New SQLControl

    Public Function getGuia() As DataTable
        SQL.ExecQuery("SELECT CODIGO_GUIA, DETALLE_GUIA, CODIGO_ESTADO From GUIA_TRANSPORTISTA WHERE CODIGO_ESTADO = 8")

        Return SQL.DBT
    End Function

    Public Sub InsertLiquidacion(detalleGuia As String, estado As Integer)

        SQL.AddParam("@DETALLE_GUIA", detalleGuia)
        SQL.AddParam("@CODIGO_ESTADO", 7)

        SQL.ExecQuery("EXECUTE insertGuia 
                                        @DETALLE_GUIA,
                                        @CODIGO_ESTADO")




    End Sub

End Class
