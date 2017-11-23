Public Class PersonalDAO
    Public SQL As New SQLControl

    Public Function getPersonal() As DataTable
        SQL.ExecQuery("SELECT CODIGO_TRABAJADOR,
                              APELLIDO_PATERNO_TRABAJADOR,
                              APELLIDO_MATERNO_TRABAJADOR,
                              NOMBRES_TRABAJADOR,
                              NACIMIENTO_TRABAJADOR,
                              DIRECCION_TRABAJADOR,
                              TELEFONO_TRABAJADOR,
                              DNI_TRABAJADOR,
                              BREVETE_TRABAJADOR,
                              CODIGO_CARGO_TRABAJADOR,
                              CODIGO_ESTADO_TRABAJADOR
                        FROM TRABAJADOR")
        Return SQL.DBT
    End Function


End Class
