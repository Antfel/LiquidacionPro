Imports System.Data
Imports System.Data.SqlClient
Public Class ClienteDAO
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

    Public Function GetClientes() As DataTable
        Return sqlControl.ExecQuery("Select CODIGO_CLIENTE, RUC_CLIENTE, RAZON_CLIENTE, DIRECCION_CLIENTE, TELEFONO_CLIENTE from CLIENTE", Nothing)
    End Function

    Public Function GetClienteByRuc(ruc_Cliente As String) As DataTable
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@RUC_CLIENTE", ruc_Cliente))
        Return sqlControl.ExecQuery("Select CODIGO_CLIENTE, RUC_CLIENTE, RAZON_CLIENTE, DIRECCION_CLIENTE, TELEFONO_CLIENTE from CLIENTE where RUC_CLIENTE=@RUC_CLIENTE", params)

    End Function

    Public Function GetClienteByCodigo(codigo As String) As DataTable
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_CLIENTE", codigo))
        Return sqlControl.ExecQuery("Select CODIGO_CLIENTE, coalesce(RUC_CLIENTE,''),coalesce( RAZON_CLIENTE,''), coalesce(DIRECCION_CLIENTE,''), coalesce(TELEFONO_CLIENTE,'') from CLIENTE where CODIGO_CLIENTE=@CODIGO_CLIENTE", params)

    End Function

    Public Function GetAllClientes() As DataTable
        Return sqlControl.ExecQuery("Select CODIGO_CLIENTE 'CODIGO CLIENTE', RUC_CLIENTE RUC, RAZON_CLIENTE 'RAZON SOCIAL', 
                                            DIRECCION_CLIENTE 'DIRECCION CLIENTE', TELEFONO_CLIENTE TELEFONO from CLIENTE ORDER BY CODIGO_CLIENTE", Nothing)
    End Function

    Public Function InsertCliente(ruc As String, telefono As String, razonSocial As String,
                                 direccion As String) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@RUC_CLIENTE", ruc))
        params.Add(New SqlParameter("@RAZON_CLIENTE", razonSocial))
        params.Add(New SqlParameter("@DIRECCION_CLIENTE", direccion))
        params.Add(New SqlParameter("@TELEFONO_CLIENTE", telefono))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertCliente 
                                        @RUC_CLIENTE,
                                        @RAZON_CLIENTE,
                                        @DIRECCION_CLIENTE,
                                        @TELEFONO_CLIENTE ", params)

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

    Public Function updateCliente(codigo As Integer, ruc As String, telefono As String, razonSocial As String,
                                 direccion As String) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_CLIENTE", codigo))
        params.Add(New SqlParameter("@RUC_CLIENTE", ruc))
        params.Add(New SqlParameter("@RAZON_CLIENTE", razonSocial))
        params.Add(New SqlParameter("@DIRECCION_CLIENTE", direccion))
        params.Add(New SqlParameter("@TELEFONO_CLIENTE", telefono))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE updateCliente 
                                        @CODIGO_CLIENTE,
                                        @RUC_CLIENTE,
                                        @RAZON_CLIENTE,
                                        @DIRECCION_CLIENTE,
                                        @TELEFONO_CLIENTE ", params)
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
