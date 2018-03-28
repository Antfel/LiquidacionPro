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
                                                        to_char(b.""t_FechaRegistro"", 'DD/MM/YYYY') ""v_Fecha_Pago"",
		                                                b.""i_IdTipoDocumento"",
		                                                c.""v_Nombre"",
		                                                d.""d_TipoCambio"" ""d_TipoCambio_Venta"",
		                                                d.""i_IdMoneda"" ""i_IdMoneda_Venta"",
		                                                d.""v_Periodo"" ""v_Periodo_Venta"",
		                                                d.""v_Mes"" ""v_Mes_Venta"",
		                                                to_char(d.""t_FechaRegistro"", 'DD/MM/YYYY') ""v_Fecha_Venta"" 
                                                from	tesoreriadetalle a 
                                                inner	join tesoreria b on a.""v_IdTesoreria""=b.""v_IdTesoreria""  
                                                left	join documento c on b.""i_IdTipoDocumento""=c.""i_CodigoDocumento"" 
                                                inner	join venta d on d.""v_SerieDocumento""||'-'||d.""v_CorrelativoDocumento""=a.""v_NroDocumento"" and d.""i_Eliminado""=0 
                                                where 	a.""i_Eliminado""=0 
		                                                and a.""v_Naturaleza""='H'  
		                                                and a.""i_EsDestino""='0'  
		                                                and d.""v_Mes"" like '%'||@MES||'%'  
		                                                and d.""v_Periodo""=@PERIODO  
                                                union   all 
                                                select 	a.""v_IdDiarioDetalle"",
		                                                a.""v_IdDiario"",
		                                                a.""v_Naturaleza"",
		                                                a.""d_Importe"",
		                                                a.""d_Cambio"",
		                                                b.""i_IdMoneda"",
		                                                b.""d_TipoCambio"",
		                                                rtrim(ltrim(a.""v_NroDocumentoRef"")),
		                                                b.""v_Periodo"",
		                                                b.""v_Mes"",
		                                                to_char(b.""t_Fecha"", 'DD/MM/YYYY') ""v_Fecha_Pago"",
		                                                b.""i_IdTipoDocumento"",
		                                                c.""v_Nombre"",
		                                                d.""d_TipoCambio"" ""d_TipoCambio_Venta"",
		                                                d.""i_IdMoneda"" ""i_IdMoneda_Venta"",
		                                                d.""v_Periodo"" ""v_Periodo_Venta"",
		                                                d.""v_Mes"" ""v_Mes_Venta"",
		                                                to_char(d.""t_FechaRegistro"", 'DD/MM/YYYY') ""v_Fecha_Venta""
                                                from	diariodetalle a 
                                                inner	join diario b on a.""v_IdDiario""=b.""v_IdDiario""  
                                                left	join documento c on b.""i_IdTipoDocumento""=c.""i_CodigoDocumento"" 
                                                inner	join venta d on d.""v_SerieDocumento""||'-'||d.""v_CorrelativoDocumento""=ltrim(rtrim(a.""v_NroDocumentoRef"")) and d.""i_Eliminado""=0 
                                                where 	a.""i_Eliminado""=0 
		                                                and a.""v_Naturaleza""='H'  
		                                                and b.""i_IdTipoDocumento""=337 
                                                order 	by 8 asc  ", params)


    End Function

    Public Function GetFacturasPagosAll() As DataTable

        Return sqlControlPostgres.ExecQuery("select	aa.""v_NroDocIdentificacion"",
	                                                aa.""v_RazonSocial"",
	                                                aa.""i_IdTipoDocumento"",
	                                                sum(""DEBE_SOLES""),
	                                                sum(""HABER_SOLES""),
	                                                sum(""DEBE_DOLARES""), 
	                                                sum(""HABER_DOLARES"")
                                                from (
                                                select	e.""v_NroDocIdentificacion"",
	                                                case 	when e.""i_IdTipoPersona""=2 then e.""v_RazonSocial""
		                                                when e.""i_IdTipoPersona""=1 then (case when e.""v_ApeMaterno""<>'' then e.""v_ApePaterno""||' '||e.""v_ApeMaterno""||' '||e.""v_PrimerNombre""
						                                                else e.""v_RazonSocial"" end)
		                                                 end ""v_RazonSocial"",
	                                                case 	when b.""i_IdTipoDocumento""=1 then b.""v_NroDocumento""
		                                                when b.""i_IdTipoDocumento""=3 then b.""v_NroDocumento""
		                                                when b.""i_IdTipoDocumento""=7 then b.""v_NroDocumentoRef"" end ""i_IdTipoDocumento"",
	                                                case	when b.""v_Naturaleza""='D' then
						                                                case	when a.""i_IdMoneda""=1 then b.""d_Importe""
							                                                when a.""i_IdMoneda""=2 then b.""d_Cambio"" end 
		                                                when b.""v_Naturaleza""='H' then 0 end ""DEBE_SOLES"",

	                                                case	when b.""v_Naturaleza""='H' then
						                                                case	when a.""i_IdMoneda""=1 then b.""d_Importe""
							                                                when a.""i_IdMoneda""=2 then b.""d_Cambio"" end 
		                                                when b.""v_Naturaleza""='D' then 0 end ""HABER_SOLES"",
		
	                                                case	when b.""v_Naturaleza""='D' then
						                                                case	when a.""i_IdMoneda""=1 then b.""d_Cambio""
							                                                when a.""i_IdMoneda""=2 then b.""d_Importe"" end 
		                                                when b.""v_Naturaleza""='H' then 0 end ""DEBE_DOLARES"",
		
	                                                case	when b.""v_Naturaleza""='H' then
						                                                case	when a.""i_IdMoneda""=1 then b.""d_Cambio""
							                                                when a.""i_IdMoneda""=2 then b.""d_Importe"" end 
		                                                when b.""v_Naturaleza""='D' then 0 end ""HABER_DOLARES""
                                                from	diario a
                                                inner 	join diariodetalle b on a.""v_IdDiario""=b.""v_IdDiario""
                                                inner	join documento c on c.""i_CodigoDocumento""=a.""i_IdTipoDocumento""
                                                inner	join documento d on d.""i_CodigoDocumento""=b.""i_IdTipoDocumento""
                                                left	join cliente e on e.""v_IdCliente""=b.""v_IdCliente""
                                                where	b.""v_NroCuenta""='1212101'
                                                and	a.""i_Eliminado""=0
                                                and	b.""i_Eliminado""=0
                                                union 	all
                                                select 	e.""v_NroDocIdentificacion"",
	                                                case 	when e.""i_IdTipoPersona""=2 then e.""v_RazonSocial""
		                                                when e.""i_IdTipoPersona""=1 then case when e.""v_ApeMaterno""<>'' then e.""v_ApePaterno""||' '||e.""v_ApeMaterno""||' '||e.""v_PrimerNombre""
						                                                else e.""v_RazonSocial"" end 
	                                                end,
	                                                case 	when b.""i_IdTipoDocumento""=1 then b.""v_NroDocumento""
		                                                when b.""i_IdTipoDocumento""=3 then b.""v_NroDocumento""
		                                                when b.""i_IdTipoDocumento""=7 then b.""v_NroDocumentoRef"" end ""i_IdTipoDocumento"",
	                                                case	when b.""v_Naturaleza""='D' then
						                                                case	when a.""i_IdMoneda""=1 then b.""d_Importe""
							                                                when a.""i_IdMoneda""=2 then b.""d_Cambio"" end 
		                                                when b.""v_Naturaleza""='H' then 0 end ""DEBE_SOLES"",

	                                                case	when b.""v_Naturaleza""='H' then
						                                                case	when a.""i_IdMoneda""=1 then b.""d_Importe""
							                                                when a.""i_IdMoneda""=2 then b.""d_Cambio"" end 
		                                                when b.""v_Naturaleza""='D' then 0 end ""HABER_SOLES"",
		
	                                                case	when b.""v_Naturaleza""='D' then
						                                                case	when a.""i_IdMoneda""=1 then b.""d_Cambio""
							                                                when a.""i_IdMoneda""=2 then b.""d_Importe"" end 
		                                                when b.""v_Naturaleza""='H' then 0 end ""DEBE_DOLARES"",
		
	                                                case	when b.""v_Naturaleza""='H' then
						                                                case	when a.""i_IdMoneda""=1 then b.""d_Cambio""
							                                                when a.""i_IdMoneda""=2 then b.""d_Importe"" end 
		                                                when b.""v_Naturaleza""='D' then 0 end ""HABER_DOLARES""
                                                from 	tesoreria a
                                                inner	join tesoreriadetalle b on a.""v_IdTesoreria""=b.""v_IdTesoreria""
                                                inner	join documento c on c.""i_CodigoDocumento""=a.""i_IdTipoDocumento""
                                                inner	join documento d on d.""i_CodigoDocumento""=b.""i_IdTipoDocumento""
                                                left	join cliente e on e.""v_IdCliente""=b.""v_IdCliente""
                                                where	b.""v_NroCuenta""='1212101'
                                                and	a.""i_Eliminado""=0
                                                and	b.""i_Eliminado""=0
                                                ) aa
                                                group	by aa.""v_NroDocIdentificacion"",aa.""v_RazonSocial"",""i_IdTipoDocumento""
                                                order 	by 2,3 asc ", Nothing)


    End Function

End Class
