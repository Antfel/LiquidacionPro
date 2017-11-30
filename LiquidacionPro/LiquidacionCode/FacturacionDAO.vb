Imports System.Data
Imports System.Data.SqlClient
Public Class FacturacionDAO
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

    Public Function getAllFacturas() As DataTable

        Return sqlControl.ExecQuery("select CODIGO_FACTURA," +
                    "NUMERO_FACTURA," +
                    "CODIGO_CLIENTE," +
                    "TOTAL_FACTURA," +
                    "CODIGO_MONEDA," +
                    "CODIGO_ESTADO " +
                    "from Factura ", Nothing)
    End Function

    Public Function getFacturaById(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select CODIGO_FACTURA," +
                    "NUMERO_FACTURA," +
                    "CODIGO_CLIENTE," +
                    "TOTAL_FACTURA," +
                    "CODIGO_MONEDA," +
                    "CODIGO_ESTADO " +
                    "from factura " +
                    "where CODIGO_FACTURA=" + CStr(codigo), Nothing)
    End Function

    Public Sub InsertFactura(numero_factura As String, codigo_cliente As Integer, total_factura As Long,
                             codigo_moneda As Integer, codigo_estado As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@NUMERO_FACTURA", numero_factura))
        params.Add(New SqlParameter("@CODIGO_CLIENTE", codigo_cliente))
        params.Add(New SqlParameter("@TOTAL_FACTURA", total_factura))
        params.Add(New SqlParameter("@CODIGO_MONEDA", codigo_moneda))
        params.Add(New SqlParameter("@CODIGO_ESTADO", codigo_estado))

        sqlControl.ExecQuery("EXECUTE insertFacturaCabecera " +
                                        "@NUMERO_FACTURA," +
                                        "@CODIGO_CLIENTE," +
                                        "@TOTAL_FACTURA," +
                                        "@CODIGO_MONEDA," +
                                        "@CODIGO_ESTADO", params)
    End Sub

    Public Sub UpdateFactura(codigo_factura As Integer, numero_factura As String, codigo_cliente As Integer,
                             total_factura As Long, codigo_moneda As Integer, codigo_estado As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@NUMERO_FACTURA", numero_factura))
        params.Add(New SqlParameter("@CODIGO_CLIENTE", codigo_cliente))
        params.Add(New SqlParameter("@TOTAL_FACTURA", total_factura))
        params.Add(New SqlParameter("@CODIGO_MONEDA", codigo_moneda))
        params.Add(New SqlParameter("@CODIGO_ESTADO", codigo_estado))

        sqlControl.ExecQuery("EXECUTE updateFacturaCabecera " +
                                        "@CODIGO_FACTURA," +
                                        "@NUMERO_FACTURA," +
                                        "@CODIGO_CLIENTE," +
                                        "@TOTAL_FACTURA," +
                                        "@CODIGO_MONEDA," +
                                        "@CODIGO_ESTADO", params)
    End Sub
End Class
