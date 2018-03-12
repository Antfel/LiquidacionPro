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
                                            and			""v_SerieDocumento""||'-'||""v_CorrelativoDocumento"" in (" + nroFacturas + ") ", Nothing)


    End Function

    Public Function GetFacturasPagoByMesPeriodo(mes As String, periodo As String) As DataTable

        Dim params As New List(Of NpgsqlParameter)
        params.Add(New NpgsqlParameter("@MES", mes))
        params.Add(New NpgsqlParameter("@PERIODO", periodo))

        Return sqlControlPostgres.ExecQuery("select 	a.""v_IdTesoreriaDetalle"",
		                                                a.""v_IdTesoreria"",
		                                                a.""v_Naturaleza"",
		                                                a.""d_Importe"",
		                                                a.""d_Cambio"",
		                                                b.""i_IdMoneda"",
		                                                b.""d_TipoCambio"",
		                                                a.""v_NroDocumento"",
		                                                b.""v_Periodo"",
		                                                b.""v_Mes"",
                                                        to_char(b.""t_FechaRegistro"", 'MM/DD/YYYY') ""v_Fecha_Pago"",
		                                                b.""i_IdTipoDocumento"",
		                                                c.""v_Nombre"",
		                                                d.""d_TipoCambio"" ""d_TipoCambio_Venta"",
		                                                d.""i_IdMoneda"" ""i_IdMoneda_Venta"",
		                                                d.""v_Periodo"" ""v_Periodo_Venta"",
		                                                d.""v_Mes"" ""v_Mes_Venta"",
		                                                to_char(d.""t_FechaRegistro"", 'MM/DD/YYYY') ""v_Fecha_Venta"" 
                                                from	tesoreriadetalle a 
                                                inner	join tesoreria b on a.""v_IdTesoreria""=b.""v_IdTesoreria""  
                                                left	join documento c on b.""i_IdTipoDocumento""=c.""i_CodigoDocumento"" 
                                                inner	join venta d on d.""v_SerieDocumento""||'-'||d.""v_CorrelativoDocumento""=a.""v_NroDocumento"" and d.""i_Eliminado""=0 
                                                where 	a.""i_Eliminado""=0 
		                                                and a.""v_Naturaleza""='H'  
		                                                and a.""i_EsDestino""='0'  
		                                                and d.""v_Mes"" like '%'||@MES||'%'  
		                                                and d.""v_Periodo""=@PERIODO  
                                                order 	by a.""v_NroDocumento""  ", params)


    End Function

End Class
