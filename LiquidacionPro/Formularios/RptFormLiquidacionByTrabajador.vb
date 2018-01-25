Imports Microsoft.Reporting.WinForms
Public Class RptFormLiquidacionByTrabajador
    Private Sub RptFormLiquidacionByTrabajador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarReporte()
    End Sub

    Sub cargarReporte()

        Dim dt As DataTable = getLiquidacionByTrabajador("")

        ReportViewer1.Reset()
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "Formularios/Reportes/RptLiquidacionVsTrabajador.rdlc"

        Dim rds As New ReportDataSource("DataSet1", dt)
        ReportViewer1.LocalReport.DataSources.Add(rds)
        'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf subReporteCombustibleDetalle

        ReportViewer1.RefreshReport()
    End Sub

    Function getLiquidacionByTrabajador(codigo As String) As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.setConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            dt = liquidacionDAO.getRptLiquidacionByTrabajador(codigo)
            sqlControl.commitTransaction()
            Return dt
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("No se pudo cargar la liquidación. " + ex.Message, "Cargar Liquidación",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error)
            Return dt
        Finally

            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("No se pudo cerrar la conexión. " + ex.Message, "Cargar Liquidación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try


        End Try

    End Function
End Class