Public Class ClienteDAO
    Public SQL As New SQLControl

    Public Function GetCliente() As DataTable
        SQL.ExecQuery("Select RUC_CLIENTE, RAZON_CLIENTE, DIRECCION_CLIENTE, TELEFONO_CLIENTE from CLIENTE")
        Return SQL.DBT
        'Return Nothing

    End Function



End Class
