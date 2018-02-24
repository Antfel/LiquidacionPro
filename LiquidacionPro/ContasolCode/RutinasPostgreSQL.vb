Imports Npgsql
Imports NpgsqlTypes
Public Class RutinasPostgreSQL

    Dim sqlControlPostgres As SQLControlPostgres

    Public Sub New(sqlControlPostgres As SQLControlPostgres)
        Me.sqlControlPostgres = sqlControlPostgres
    End Sub
    Public Function GetDatosVentasByNroFacturas(nroFacturas As String) As DataTable


        Return sqlControlPostgres.ExecQuery("select	   ""v_IdVenta"",
			                                            ""v_SerieDocumento"",
                                                        ""v_CorrelativoDocumento"",
                                                        ""d_TipoCambio"",
                                                        ""t_FechaVencimiento"",
                                                        ""i_IdMoneda"",
                                                        ""i_IdEstado"",
                                                        ""i_AfectaDetraccion"",
                                                        ""d_TasaDetraccion"",
                                                        to_char(""t_FechaVencimiento"", 'MM/DD/YYYY'),
                                                        ""d_ValorVenta"" 
                                            from		venta 
                                            where		""i_Eliminado""=0
                                            and			""v_SerieDocumento""||'-'||""v_CorrelativoDocumento"" in (" + nroFacturas + ")", Nothing)

    End Function

End Class
