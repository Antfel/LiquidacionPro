Imports Microsoft.Reporting.WinForms
Public Class RptGuiasVsLiquidacionFacturacion
    Private Sub ChildRptLiquidacionEstado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actualizarEstados()
    End Sub

    Private Sub actualizarEstados()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim estadoDao As New EstadoGuiaDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            estadoDao.setDBcmd()

            Dim dtEstado As DataTable

            dtEstado = estadoDao.getEstados

            clbEstadoGuia.DataSource = dtEstado
            clbEstadoGuia.DisplayMember = "DETALLE_ESTADO"
            clbEstadoGuia.ValueMember = "CODIGO_ESTADO"

            sqlControl.CommitTransaction()

        Catch ex As Exception
            sqlControl.RollbackTransaccion()
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception

            End Try
        End Try



    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        Dim codigo As String
        codigo = ""
        For Each itemChecked In clbEstadoGuia.CheckedItems
            Dim castedItem As DataRowView = CType(itemChecked, DataRowView)
            Dim codigoItem As String = castedItem("CODIGO_ESTADO")
            codigo += CStr(codigoItem) + ","
        Next
        If codigo.Length > 0 Then
            codigo = codigo.Substring(0, codigo.Length - 1)
        End If

        If codigo = "" Then
            MessageBox.Show("Debe elegir un estado. ", "Cargar Guías",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Exclamation)
            Return
        End If
        cargarReporteGuiaLiquidacionFactura(codigo)
    End Sub

    Sub cargarReporteGuiaLiquidacionFactura(codigo As String)

        Dim dt As DataTable = getiquidacionEstadoGuia(codigo)
        ReportViewer1.Reset()
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "Formularios/Reportes/RptGuiasVsLiquidacionFacturacion.rdlc"
        ReportViewer1.LocalReport.Refresh()
        Dim rds As New ReportDataSource("DataSet1", dt)
        ReportViewer1.LocalReport.DataSources.Add(rds)
        'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf subReporteCombustibleDetalle

        ReportViewer1.RefreshReport()
    End Sub

    Function getiquidacionEstadoGuia(estados As String) As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.SetConnection()

        Dim guiaDao As New GuiaDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            guiaDao.setDBcmd()

            dt = guiaDao.getRptGuiaLiquidacionFactura(estados)
            sqlControl.CommitTransaction()
            Return dt
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("No se pudo cargar la liquidación. " + ex.Message, "Cargar Liquidación",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error)
            Return dt
        Finally

            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("No se pudo cerrar la conexión. " + ex.Message, "Cargar Liquidación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try

        End Try

    End Function

    Private Sub ChildRptLiquidacionVsLiquidacionFacturacion_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim tamX, tamY As Integer
        tamX = Me.Size.Width
        tamY = Me.Size.Height

        Dim tam As New Size(tamX - 18, tamY - 82)
        ReportViewer1.Size = tam
    End Sub
End Class