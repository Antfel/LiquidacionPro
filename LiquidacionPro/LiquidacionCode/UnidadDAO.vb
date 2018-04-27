Imports System.Data
Imports System.Data.SqlClient
Public Class UnidadDAO
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

    Public Function getUnidadTractos() As DataTable
        Return sqlControl.ExecQuery("SELECT CODIGO_UNIDAD, PLACA_UNIDAD, CODIGO_TIPO_UNIDAD, EJES_UNIDAD FROM UNIDAD WHERE CODIGO_TIPO_UNIDAD=0 or CODIGO_TIPO_UNIDAD=2", Nothing)
    End Function

    Public Function getUnidadSemiTrailer() As DataTable
        Return sqlControl.ExecQuery("SELECT CODIGO_UNIDAD, PLACA_UNIDAD, CODIGO_TIPO_UNIDAD, EJES_UNIDAD FROM UNIDAD WHERE CODIGO_TIPO_UNIDAD=1", Nothing)
    End Function

    Public Function GetTipoUnidad() As DataTable
        Return sqlControl.ExecQuery("select	CODIGO_TIPO_UNIDAD,
		                                    DETALLE_TIPO_UNIDAD
                                    from	TIPO_UNIDAD
                                    order	by DETALLE_TIPO_UNIDAD asc ", Nothing)
    End Function

    Public Function GetAllUnidad() As DataTable
        Return sqlControl.ExecQuery("select	a.CODIGO_UNIDAD CODIGO, 
                                            a.PLACA_UNIDAD PLACA, 
                                            b.DETALLE_TIPO_UNIDAD 'TIPO UNIDAD', 
                                            a.EJES_UNIDAD 'EJES' 
                                    from	UNIDAD a
                                    left join TIPO_UNIDAD b on a.CODIGO_TIPO_UNIDAD=b.CODIGO_TIPO_UNIDAD
                                    order	by CODIGO_UNIDAD asc ", Nothing)
    End Function

    Public Function GetUnidadById(codigo As Integer) As DataTable
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO", codigo))

        Return sqlControl.ExecQuery("SELECT CODIGO_UNIDAD, 
                                            PLACA_UNIDAD, 
                                            CODIGO_TIPO_UNIDAD, 
                                            EJES_UNIDAD 
                                    FROM    UNIDAD 
                                    WHERE   CODIGO_UNIDAD=@CODIGO", params)
    End Function

    Public Function InsertUnidad(placa As String, tipo As Integer, ejes As Integer) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@PLACA_UNIDAD", placa))
        params.Add(New SqlParameter("@CODIGO_TIPO_UNIDAD", tipo))
        params.Add(New SqlParameter("@EJES_UNIDAD", ejes))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertUnidad " +
                                        "@PLACA_UNIDAD," +
                                        "@CODIGO_TIPO_UNIDAD," +
                                        "@EJES_UNIDAD ", params)
        If dt.Rows.Count > 0 Then
            Return CInt(dt.Rows.Item(0).Item(0))
        Else
            Return -1
        End If
    End Function

    Public Function UpdateUsuario(codigo As Integer, placa As String, tipo As Integer, ejes As Integer) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_UNIDAD", codigo))
        params.Add(New SqlParameter("@PLACA_UNIDAD", placa))
        params.Add(New SqlParameter("@CODIGO_TIPO_UNIDAD", tipo))
        params.Add(New SqlParameter("@EJES_UNIDAD", ejes))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateUnidad " +
                                        "@CODIGO_UNIDAD," +
                                        "@PLACA_UNIDAD," +
                                        "@CODIGO_TIPO_UNIDAD," +
                                        "@EJES_UNIDAD ", params)
        If dt.Rows.Count > 0 Then
            Return CInt(dt.Rows.Item(0).Item(0))
        Else
            Return -1
        End If
    End Function
End Class
