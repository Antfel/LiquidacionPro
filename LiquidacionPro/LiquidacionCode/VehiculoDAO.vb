Public Class VehiculoDAO
    Public SQL As SQLControl

    Public Function getVehiculosTractos() As DataTable
        SQL.ExecQuery("SELECT PLACA_UNIDAD, CODIGO_TIPO_UNIDAD, EJES_UNIDAD FROM UNIDAD WHERE CODIGO_TIPO_UNIDAD=1")
        Return SQL.DBT
    End Function

    Public Function getVehiculosRemolques() As DataTable
        SQL.ExecQuery("SELECT PLACA_UNIDAD, CODIGO_TIPO_UNIDAD, EJES_UNIDAD FROM UNIDAD WHERE CODIGO_TIPO_UNIDAD=2")
        Return SQL.DBT
    End Function

End Class
