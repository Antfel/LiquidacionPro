Public Class ClienteDAO
    Public SQL As New SQLControl

    Public Function GetClientes() As DataTable
        SQL.ExecQuery("Select CODIGO_CLIENTE, RUC_CLIENTE, RAZON_CLIENTE, DIRECCION_CLIENTE, TELEFONO_CLIENTE from CLIENTE")
        Return SQL.DBT
        'Return Nothing

    End Function

    Public Function GetClienteByRuc(ruc_Cliente As String) As DataTable
        SQL.AddParam("@RUC_CLIENTE", ruc_Cliente)
        SQL.ExecQuery("Select CODIGO_CLIENTE, RUC_CLIENTE, RAZON_CLIENTE, DIRECCION_CLIENTE, TELEFONO_CLIENTE from CLIENTE where RUC_CLIENTE=@RUC_CLIENTE")
        Return SQL.DBT

    End Function

    Public Function GetClienteByCodigo(codigo As String) As DataTable
        SQL.AddParam("@CODIGO_CLIENTE", codigo)
        SQL.ExecQuery("Select CODIGO_CLIENTE, RUC_CLIENTE, RAZON_CLIENTE, DIRECCION_CLIENTE, TELEFONO_CLIENTE from CLIENTE where CODIGO_CLIENTE=@CODIGO_CLIENTE")
        Return SQL.DBT

    End Function

End Class
