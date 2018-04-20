Imports System.Data
Imports System.Data.SqlClient
Public Class UsuarioDAO
    Dim DBcon As SqlConnection
    Dim DBcmd As SqlCommand
    Dim sqlControl As SQLControl

    Public Sub New(sqlControl As SQLControl)
        Me.sqlControl = sqlControl
        Me.DBcon = sqlControl.GetDBcon
    End Sub

    Public Sub setDBcmd()
        Me.DBcmd = sqlControl.GetDBcmd
    End Sub

    Public Function openConexion() As Boolean
        Return sqlControl.OpenConexion()
    End Function

    Public Function closeConexion() As Boolean
        Return sqlControl.CloseConexion()
    End Function

    Public Sub beginTransaction()
        sqlControl.BeginTransaction()
    End Sub

    Public Sub commitTransacction()
        sqlControl.CommitTransaction()
    End Sub

    Public Sub rollbackTransaccion()
        sqlControl.RollbackTransaccion()
    End Sub

    Public Function Login(user As String, pass As String) As DataTable
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@NOMBRE_USUARIO", user))
        params.Add(New SqlParameter("@PASS", pass))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("select	a.ID_USUARIO 'ID USUARIO'
                                    from	USUARIO a
                                    where   a.nombre_usuario=@NOMBRE_USUARIO 
                                            and a.pass=@PASS 
                                            and a.estado=1", params)

        Return dt
    End Function

    Public Function GetAllUsuario() As DataTable
        Dim dt As DataTable
        dt = sqlControl.ExecQuery("select	a.ID_USUARIO 'ID USUARIO',
		                                    a.APE_PATERNO 'APE PATERNO',
		                                    a.APE_MATERNO 'APE MATERNO',
		                                    a.NOMBRES,
		                                    a.NOMBRE_USUARIO 'USUARIO',
		                                    a.FECHA_INICIO 'FECHA INICIO',
		                                    a.FECHA_FIN 'FECHA FIN',
		                                    a.ID_ROL,
		                                    b.DESCRIPCION 'ROL',
                                            a.ESTADO 
                                    from	USUARIO a
                                    inner	join ROL b on a.ID_ROL=b.ID_ROL
                                    order	by a.ID_USUARIO asc", Nothing)

        Return dt
    End Function

    Public Function GetUsuarioById(id As Integer) As DataTable

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@ID_USUARIO", id))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("select	a.ID_USUARIO 'ID USUARIO',
		                                    a.APE_PATERNO 'APE PATERNO',
		                                    a.APE_MATERNO 'APE MATERNO',
		                                    a.NOMBRES,
		                                    a.NOMBRE_USUARIO 'USUARIO',
                                            a.PASS,
		                                    a.FECHA_INICIO 'FECHA INICIO',
		                                    a.FECHA_FIN 'FECHA FIN',
		                                    a.ID_ROL,
                                            a.ESTADO
                                    from	USUARIO a 
                                    where   ID_USUARIO=@ID_USUARIO
                                    order	by a.ID_USUARIO asc", params)

        Return dt
    End Function

    Public Function InsertUsuario(ape_pat As String, ape_mat As String, nombres As String, usuario As String,
            pass As String, inicio As Date, fin As Date, rol As Integer, estado As Integer) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@APE_PATERNO", ape_pat))
        params.Add(New SqlParameter("@APE_MATERNO", ape_mat))
        params.Add(New SqlParameter("@NOMBRES", nombres))
        params.Add(New SqlParameter("@NOMBRE_USUARIO", usuario))
        params.Add(New SqlParameter("@PASS", pass))
        params.Add(New SqlParameter("@FECHA_INICIO", inicio))
        params.Add(New SqlParameter("@FECHA_FIN", fin))
        params.Add(New SqlParameter("@ID_ROL", rol))
        params.Add(New SqlParameter("@ESTADO", estado))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertUsuario " +
                                        "@APE_PATERNO," +
                                        "@APE_MATERNO," +
                                        "@NOMBRES," +
                                        "@NOMBRE_USUARIO," +
                                        "@PASS," +
                                        "@FECHA_INICIO," +
                                        "@FECHA_FIN, " +
                                        "@ID_ROL, " +
                                        "@ESTADO ", params)
        If dt.Rows.Count > 0 Then
            Return CInt(dt.Rows.Item(0).Item(0))
        Else
            Return -1
        End If
    End Function

    Public Function UpdateUsuario(idUsuario As Integer, ape_pat As String, ape_mat As String, nombres As String, usuario As String,
            pass As String, inicio As Date, fin As Date, rol As Integer, estado As Integer) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@ID_USUARIO", idUsuario))
        params.Add(New SqlParameter("@APE_PATERNO", ape_pat))
        params.Add(New SqlParameter("@APE_MATERNO", ape_mat))
        params.Add(New SqlParameter("@NOMBRES", nombres))
        params.Add(New SqlParameter("@NOMBRE_USUARIO", usuario))
        params.Add(New SqlParameter("@PASS", pass))
        params.Add(New SqlParameter("@FECHA_INICIO", inicio))
        params.Add(New SqlParameter("@FECHA_FIN", fin))
        params.Add(New SqlParameter("@ID_ROL", rol))
        params.Add(New SqlParameter("@ESTADO", estado))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateUsuario " +
                                        "@ID_USUARIO," +
                                        "@APE_PATERNO," +
                                        "@APE_MATERNO," +
                                        "@NOMBRES," +
                                        "@NOMBRE_USUARIO," +
                                        "@PASS," +
                                        "@FECHA_INICIO," +
                                        "@FECHA_FIN, " +
                                        "@ID_ROL, " +
                                        "@ESTADO ", params)
        If dt.Rows.Count > 0 Then
            Return CInt(dt.Rows.Item(0).Item(0))
        Else
            Return -1
        End If
    End Function
End Class
