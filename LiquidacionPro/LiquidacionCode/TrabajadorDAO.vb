Public Class TrabajadorDAO
    Public SQL As New SQLControl

    Public Function GetTrabajador() As DataTable
        SQL.ExecQuery("SELECT CODIGO_TRABAJADOR,
                              coalesce(APELLIDO_PATERNO_TRABAJADOR,'') + ' '+
                              coalesce(APELLIDO_MATERNO_TRABAJADOR,'') + ', ' +
                              coalesce(NOMBRES_TRABAJADOR,'') as NOMBRE_TRABAJADOR
                        FROM TRABAJADOR where CODIGO_CARGO_TRABAJADOR = 1 AND CODIGO_ESTADO_TRABAJADOR = 4")
        Return SQL.DBT
    End Function


End Class
