Imports Microsoft.Reporting.WinForms
Public Class RptFormLiquidacionFacturacionSoles
    Private Sub RptFormLiquidacionFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarReporteGeneral()
    End Sub

    Sub cargarReporteGeneral()

        Dim dt As DataTable = getLiquidacionFacturacionCabecera()

        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "Formularios/Reportes/RptLiquidacionFacturacionCabecera.rdlc"

        Dim rds As New ReportDataSource("DataSet1", dt)
        ReportViewer1.LocalReport.DataSources.Add(rds)
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf subReporteLiquidacionFacturacionDetalle

        ReportViewer1.RefreshReport()
    End Sub

    Function getLiquidacionFacturacionCabecera() As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.SetConnection()

        Dim facturacionDAO As New FacturacionDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDAO.SetDBcmd()

            dt = facturacionDAO.GetRptLiquidacionFacturacionCabeceraAll(0)
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

    Public Sub subReporteLiquidacionFacturacionDetalle(ByVal sender As Object,
     ByVal e As SubreportProcessingEventArgs)

        Dim codigo As Integer = CInt(e.Parameters("CodigoFactura").Values(0).ToString)
        Dim dt As New DataTable
        dt = getLiquidacionFacturacionDetalle(codigo)
        Dim rds As New ReportDataSource("DataSet1", dt)
        e.DataSources.Add(rds)

    End Sub

    Function getLiquidacionFacturacionDetalle(codigo As Integer) As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.SetConnection()

        Dim facturacionDAO As New FacturacionDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDAO.SetDBcmd()

            dt = facturacionDAO.GetRptLiquidacionFacturacionDetalle(codigo)
            sqlControl.CommitTransaction()
            Return dt
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("No se pudo cargar la liquidación detalle. " + ex.Message, "Cargar Liquidación",
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
End Class