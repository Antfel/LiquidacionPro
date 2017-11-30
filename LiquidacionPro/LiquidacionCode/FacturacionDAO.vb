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
                    "SERIE_FACTURA," +
                    "NUMERO_FACTURA," +
                    "CODIGO_CLIENTE," +
                    "TOTAL_FACTURA," +
                    "CODIGO_MONEDA," +
                    "CODIGO_ESTADO " +
                    "from Factura ", Nothing)
    End Function

    Public Function getFacturaById(codigo As Integer) As DataTable

        Return sqlControl.ExecQuery("select CODIGO_FACTURA," +
                    "SERIE_FACTURA," +
                    "NUMERO_FACTURA," +
                    "CODIGO_CLIENTE," +
                    "TOTAL_FACTURA," +
                    "CODIGO_MONEDA," +
                    "CODIGO_ESTADO " +
                    "from factura " +
                    "where CODIGO_FACTURA=" + CStr(codigo), Nothing)
    End Function

    Public Function InsertFactura(serie_factura As String, numero_factura As String, codigo_cliente As Integer, total_factura As Long,
                             codigo_moneda As Integer, codigo_estado As Integer) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@SERIE_FACTURA", serie_factura))
        params.Add(New SqlParameter("@NUMERO_FACTURA", numero_factura))
        params.Add(New SqlParameter("@CODIGO_CLIENTE", codigo_cliente))
        params.Add(New SqlParameter("@TOTAL_FACTURA", total_factura))
        params.Add(New SqlParameter("@CODIGO_MONEDA", codigo_moneda))
        params.Add(New SqlParameter("@CODIGO_ESTADO", codigo_estado))

        Dim dt As DataTable
        dt = sqlControl.ExecQuery("EXECUTE insertFacturaCabecera " +
                                        "@SERIE_FACTURA," +
                                        "@NUMERO_FACTURA," +
                                        "@CODIGO_CLIENTE," +
                                        "@TOTAL_FACTURA," +
                                        "@CODIGO_MONEDA," +
                                        "@CODIGO_ESTADO", params)
        If dt.Rows.Count > 0 Then
            Return CInt(dt.Rows.Item(0).Item(0))
        Else
            Return -1
        End If
    End Function

    Public Sub UpdateFactura(codigo_factura As Integer, serie_factura As String, numero_factura As String, codigo_cliente As Integer,
                             total_factura As Long, codigo_moneda As Integer, codigo_estado As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@SERIE_FACTURA", serie_factura))
        params.Add(New SqlParameter("@NUMERO_FACTURA", numero_factura))
        params.Add(New SqlParameter("@CODIGO_CLIENTE", codigo_cliente))
        params.Add(New SqlParameter("@TOTAL_FACTURA", total_factura))
        params.Add(New SqlParameter("@CODIGO_MONEDA", codigo_moneda))
        params.Add(New SqlParameter("@CODIGO_ESTADO", codigo_estado))

        sqlControl.ExecQuery("EXECUTE updateFacturaCabecera " +
                                        "@CODIGO_FACTURA," +
                                        "@SERIE_FACTURA," +
                                        "@NUMERO_FACTURA," +
                                        "@CODIGO_CLIENTE," +
                                        "@TOTAL_FACTURA," +
                                        "@CODIGO_MONEDA," +
                                        "@CODIGO_ESTADO", params)
    End Sub

    Public Function InsertFacturaDetalle(codigo_factura As Integer, precio_factura_detalle As Long,
                                    codigo_moneda As Integer, codigo_estado As Integer) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@PRECIO_DETALLE_FACTURA", precio_factura_detalle))
        params.Add(New SqlParameter("@CODIGO_MONEDA", codigo_moneda))
        params.Add(New SqlParameter("@CODIGO_ESTADO", codigo_estado))

        Dim dt As DataTable

        dt = sqlControl.ExecQuery("EXECUTE insertFacturaDetalle " +
                                        "@CODIGO_FACTURA," +
                                        "@PRECIO_DETALLE_FACTURA," +
                                        "@CODIGO_MONEDA," +
                                        "@CODIGO_ESTADO", params)

        If dt.Rows.Count > 0 Then
            Return CInt(dt.Rows.Item(0).Item(0))
        Else
            Return -1
        End If
    End Function

    Public Sub UpdateFacturaDetalle(codigo_detalle_factura As Integer, codigo_factura As Integer, precio_factura_detalle As Long,
                                    codigo_moneda As Integer, codigo_estado As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@PRECIO_DETALLE_FACTURA", precio_factura_detalle))
        params.Add(New SqlParameter("@CODIGO_MONEDA", codigo_moneda))
        params.Add(New SqlParameter("@CODIGO_ESTADO", codigo_estado))

        sqlControl.ExecQuery("EXECUTE updateFacturaDetalle " +
                                        "@CODIGO_DETALLE_FACTURA," +
                                        "@CODIGO_FACTURA," +
                                        "@PRECIO_DETALLE_FACTURA," +
                                        "@CODIGO_MONEDA," +
                                        "@CODIGO_ESTADO", params)
    End Sub

    Public Sub InsertFacturaDetalleGuia(codigo_detalle_factura As Integer, codigo_factura As Integer,
                                        codigo_guia As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@CODIGO_GUIA", codigo_guia))

        sqlControl.ExecQuery("EXECUTE insertFacturaDetalle " +
                                        "@CODIGO_DETALLE_FACTURA," +
                                        "@CODIGO_FACTURA," +
                                        "@CODIGO_GUIA ", params)
    End Sub

    Public Sub deleteFacturaDetalleGuia(codigo_detalle_factura As Integer, codigo_factura As Integer,
                                        codigo_guia As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@CODIGO_GUIA", codigo_guia))

        sqlControl.ExecQuery("EXECUTE deleteFacturaDetalleGuia " +
                                        "@CODIGO_DETALLE_FACTURA," +
                                        "@CODIGO_FACTURA," +
                                        "@CODIGO_GUIA ", params)
    End Sub

    Public Sub InsertFacturaDetalleRemitente(codigo_detalle_factura As Integer, codigo_factura As Integer,
                                            guia_remitente As String)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@GUIA_REMITENTE", guia_remitente))

        sqlControl.ExecQuery("EXECUTE insertFacturaDetalleRemitente " +
                                        "@CODIGO_DETALLE_FACTURA," +
                                        "@CODIGO_FACTURA," +
                                        "@GUIA_REMITENTE ", params)
    End Sub

    Public Sub deleteFacturaDetalleRemitente(codigo_detalle_factura As Integer, codigo_factura As Integer,
                                        guia_remitente As String)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@GUIA_REMITENTE", guia_remitente))

        sqlControl.ExecQuery("EXECUTE deleteFacturaDetalleRemitente " +
                                        "@CODIGO_DETALLE_FACTURA," +
                                        "@CODIGO_FACTURA," +
                                        "@GUIA_REMITENTE ", params)
    End Sub

    Public Function InsertFacturaDetalleUnidad(codigo_detalle_factura As Integer, codigo_factura As Integer,
                                            codigo_unidad As Integer, placa_unidad As String) As Integer

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@CODIGO_UNIDAD", codigo_unidad))
        params.Add(New SqlParameter("@PLACA_UNIDAD", placa_unidad))

        Dim dt As DataTable

        dt = sqlControl.ExecQuery("EXECUTE insertFacturaDetalleUnidad " +
                                        "@CODIGO_DETALLE_FACTURA," +
                                        "@CODIGO_FACTURA," +
                                        "@CODIGO_UNIDAD," +
                                        "@PLACA_UNIDAD ", params)

        If dt.Rows.Count > 0 Then
            Return CInt(dt.Rows.Item(0).Item(0))
        Else
            Return -1
        End If
    End Function

    Public Sub deleteFacturaDetalleRemitente(codigo_detalle_factura As Integer, codigo_factura As Integer,
                                            codigo_item As Integer)

        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter("@CODIGO_DETALLE_FACTURA", codigo_detalle_factura))
        params.Add(New SqlParameter("@CODIGO_FACTURA", codigo_factura))
        params.Add(New SqlParameter("@CODIGO_ITEM", codigo_item))

        sqlControl.ExecQuery("EXECUTE deleteFacturaDetalleUnidad " +
                                        "@CODIGO_DETALLE_FACTURA," +
                                        "@CODIGO_FACTURA," +
                                        "@CODIGO_ITEM ", params)
    End Sub
End Class
