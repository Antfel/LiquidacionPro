Public Class UnidadDAO
    Public SQL As New SQLControl

    Public Function getUnidadTractos() As DataTable
        SQL.ExecQuery("SELECT CODIGO_UNIDAD, PLACA_UNIDAD, CODIGO_TIPO_UNIDAD, EJES_UNIDAD FROM UNIDAD WHERE CODIGO_TIPO_UNIDAD=0")
        Return SQL.DBT
    End Function

    Public Function getUnidadSemiTrailer() As DataTable
        SQL.ExecQuery("SELECT CODIGO_UNIDAD, PLACA_UNIDAD, CODIGO_TIPO_UNIDAD, EJES_UNIDAD FROM UNIDAD WHERE CODIGO_TIPO_UNIDAD=1")
        Return SQL.DBT
    End Function

End Class
