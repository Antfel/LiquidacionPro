Imports System.Data
Imports System.Data.SqlClient
Public Class TrabajadorDAO
    Dim DBcon As SqlConnection
    Dim DBcmd As SqlCommand
    Dim sqlControl As SQLControl

    Public Sub New(sqlControl As SQLControl)
        Me.sqlControl = sqlControl
        Me.DBcon = sqlControl.getDBcon
    End Sub

    Public Sub setDBcmd()
        Me.DBcmd = sqlControl.getDBcmd
    End Sub

    Public Function openConexion() As Boolean
        Return sqlControl.openConexion()
    End Function

    Public Function closeConexion() As Boolean
        Return sqlControl.closeConexion()
    End Function

    Public Sub beginTransaction()
        sqlControl.beginTransaction()
    End Sub

    Public Sub commitTransacction()
        sqlControl.commitTransaction()
    End Sub

    Public Sub rollbackTransaccion()
        sqlControl.rollbackTransaccion()
    End Sub

    Public Function GetTrabajador() As DataTable
        Return sqlControl.ExecQuery("SELECT CODIGO_TRABAJADOR,
                              coalesce(APELLIDO_PATERNO_TRABAJADOR,'') + ' '+
                              coalesce(APELLIDO_MATERNO_TRABAJADOR,'') + ', ' +
                              coalesce(NOMBRES_TRABAJADOR,'') as NOMBRE_TRABAJADOR
                        FROM TRABAJADOR where CODIGO_CARGO_TRABAJADOR = 1 AND CODIGO_ESTADO_TRABAJADOR = 4", Nothing)
    End Function

    Public Function GetConductor() As DataTable
        'Se obtiene conductores y escoltas
        Return sqlControl.ExecQuery("SELECT CODIGO_TRABAJADOR,
                              coalesce(APELLIDO_PATERNO_TRABAJADOR,'') + ' '+
                              coalesce(APELLIDO_MATERNO_TRABAJADOR,'') + ', ' +
                              coalesce(NOMBRES_TRABAJADOR,'') as NOMBRE_TRABAJADOR
                        FROM TRABAJADOR where CODIGO_CARGO_TRABAJADOR = 1 or CODIGO_CARGO_TRABAJADOR = 8 or CODIGO_CARGO_TRABAJADOR = 6", Nothing)
    End Function

    Public Function getAllTrabajador() As DataTable
        'Se obtiene conductores y escoltas
        Return sqlControl.ExecQuery("select	a.CODIGO_TRABAJADOR CODIGO,
		                                    a.APELLIDO_PATERNO_TRABAJADOR 'APELLIDO PATERNO',
		                                    a.APELLIDO_MATERNO_TRABAJADOR 'APELLIDO MATERNO',
		                                    a.NOMBRES_TRABAJADOR NOMBRES,
		                                    a.NACIMIENTO_TRABAJADOR ,
		                                    convert(varchar(10),a.NACIMIENTO_TRABAJADOR,103) 'FECHA NACIMIENTO',
		                                    a.DIRECCION_TRABAJADOR DIRECCION, 
		                                    a.TELEFONO_TRABAJADOR TELEFONO,
		                                    a.DNI_TRABAJADOR DNI,
		                                    a.BREVETE_TRABAJADOR BREVETE,
		                                    a.CODIGO_CARGO_TRABAJADOR,
		                                    b.DESCRIPCION_CARGO_TRABAJADOR CARGO,
		                                    a.CODIGO_ESTADO_TRABAJADOR,
		                                    c.DETALLE_ESTADO ESTADO,
		                                    a.SEXO SEXO_COD,
		                                    case when SEXO='M' then 'Masculino' else 'Femenino' end SEXO,
                                            coalesce(a.APELLIDO_PATERNO_TRABAJADOR,'')+' '+coalesce(a.APELLIDO_MATERNO_TRABAJADOR,'')+' '+a.NOMBRES_TRABAJADOR NOMBRE_COMPLETO 
                                    from	TRABAJADOR a
                                    left	join CARGO_TRABAJADOR b on a.CODIGO_CARGO_TRABAJADOR=b.CODIGO_CARGO_TRABAJADOR
                                    left	join ESTADO c on c.CODIGO_ESTADO=a.CODIGO_ESTADO_TRABAJADOR and TIPO_ESTADO=2", Nothing)
    End Function

    Public Function getTrabajadorByCodigo(codigo As Integer) As DataTable
        'Se obtiene conductores y escoltas
        Return sqlControl.ExecQuery("select	a.CODIGO_TRABAJADOR CODIGO,
		                                    coalesce(a.APELLIDO_PATERNO_TRABAJADOR,'') 'APELLIDO PATERNO',
		                                    coalesce(a.APELLIDO_MATERNO_TRABAJADOR,'') 'APELLIDO MATERNO',
		                                    coalesce(a.NOMBRES_TRABAJADOR,'') NOMBRES,
		                                    a.NACIMIENTO_TRABAJADOR ,
		                                    convert(varchar(10),a.NACIMIENTO_TRABAJADOR,103) 'FECHA NACIMIENTO',
		                                    coalesce(a.DIRECCION_TRABAJADOR,'') DIRECCION, 
		                                    coalesce(a.TELEFONO_TRABAJADOR,'') TELEFONO,
		                                    coalesce(a.DNI_TRABAJADOR,'') DNI,
		                                    coalesce(a.BREVETE_TRABAJADOR,'') BREVETE,
		                                    coalesce(a.CODIGO_CARGO_TRABAJADOR,0),
		                                    b.DESCRIPCION_CARGO_TRABAJADOR CARGO,
		                                    coalesce(a.CODIGO_ESTADO_TRABAJADOR,0),
		                                    c.DETALLE_ESTADO ESTADO,
		                                    coalesce(a.SEXO,'') SEXO_COD,
		                                    (case when SEXO='M' then 'Masculino' else 'Femenino' end) SEXO
                                    from	TRABAJADOR a
                                    left	join CARGO_TRABAJADOR b on a.CODIGO_CARGO_TRABAJADOR=b.CODIGO_CARGO_TRABAJADOR
                                    left	join ESTADO c on c.CODIGO_ESTADO=a.CODIGO_ESTADO_TRABAJADOR and TIPO_ESTADO=2 
                                    where   codigo_trabajador=" + CStr(codigo), Nothing)
    End Function

    Public Function InsertTrajador(apePaterno As String, apeMaterno As String, nombres As String,
                                   nacimiento As Date, direccion As String, telefono As String, dni As String,
                                   brevete As String, cargo As Integer, estado As Integer, sexo As String) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@APELLIDO_PATERNO_TRABAJADOR", apePaterno))
        params.Add(New SqlParameter("@APELLIDO_MATERNO_TRABAJADOR", apeMaterno))
        params.Add(New SqlParameter("@NOMBRES_TRABAJADOR", nombres))
        params.Add(New SqlParameter("@NACIMIENTO_TRABAJADOR", nacimiento))
        params.Add(New SqlParameter("@DIRECCION_TRABAJADOR", direccion))
        params.Add(New SqlParameter("@TELEFONO_TRABAJADOR", telefono))
        params.Add(New SqlParameter("@DNI_TRABAJADOR", dni))
        params.Add(New SqlParameter("@BREVETE_TRABAJADOR", brevete))
        params.Add(New SqlParameter("@CODIGO_CARGO_TRABAJADOR", cargo))
        params.Add(New SqlParameter("@CODIGO_ESTADO_TRABAJADOR", estado))
        params.Add(New SqlParameter("@SEXO", sexo))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertTrabajador 
                                        @APELLIDO_PATERNO_TRABAJADOR,
	                                    @APELLIDO_MATERNO_TRABAJADOR,
	                                    @NOMBRES_TRABAJADOR,
	                                    @NACIMIENTO_TRABAJADOR,
	                                    @DIRECCION_TRABAJADOR,
	                                    @TELEFONO_TRABAJADOR,
	                                    @DNI_TRABAJADOR,
	                                    @BREVETE_TRABAJADOR,
	                                    @CODIGO_CARGO_TRABAJADOR,
	                                    @CODIGO_ESTADO_TRABAJADOR,
	                                    @SEXO ", params)

        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                Return CInt(dt.Rows.Item(0).Item(0))
            Else
                Return -1
            End If
        Else
            Return -1
        End If


    End Function

    Public Function updateCliente(codigo As Integer, apePaterno As String, apeMaterno As String, nombres As String,
                                   nacimiento As Date, direccion As String, telefono As String, dni As String,
                                   brevete As String, cargo As Integer, estado As Integer, sexo As String) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_TRABAJADOR", codigo))
        params.Add(New SqlParameter("@APELLIDO_PATERNO_TRABAJADOR", apePaterno))
        params.Add(New SqlParameter("@APELLIDO_MATERNO_TRABAJADOR", apeMaterno))
        params.Add(New SqlParameter("@NOMBRES_TRABAJADOR", nombres))
        params.Add(New SqlParameter("@NACIMIENTO_TRABAJADOR", nacimiento))
        params.Add(New SqlParameter("@DIRECCION_TRABAJADOR", direccion))
        params.Add(New SqlParameter("@TELEFONO_TRABAJADOR", telefono))
        params.Add(New SqlParameter("@DNI_TRABAJADOR", dni))
        params.Add(New SqlParameter("@BREVETE_TRABAJADOR", brevete))
        params.Add(New SqlParameter("@CODIGO_CARGO_TRABAJADOR", cargo))
        params.Add(New SqlParameter("@CODIGO_ESTADO_TRABAJADOR", estado))
        params.Add(New SqlParameter("@SEXO", sexo))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateTrabajador 
                                        @CODIGO_TRABAJADOR,    
                                        @APELLIDO_PATERNO_TRABAJADOR,
	                                    @APELLIDO_MATERNO_TRABAJADOR,
	                                    @NOMBRES_TRABAJADOR,
	                                    @NACIMIENTO_TRABAJADOR,
	                                    @DIRECCION_TRABAJADOR,
	                                    @TELEFONO_TRABAJADOR,
	                                    @DNI_TRABAJADOR,
	                                    @BREVETE_TRABAJADOR,
	                                    @CODIGO_CARGO_TRABAJADOR,
	                                    @CODIGO_ESTADO_TRABAJADOR,
	                                    @SEXO ", params)
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                Return CInt(dt.Rows.Item(0).Item(0))
            Else
                Return -1
            End If
        Else
            Return -1
        End If

    End Function
End Class
