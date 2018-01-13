Imports Microsoft.Reporting.WinForms

Public Class RptFormLiquidacionCombustible
    Dim codigo As Integer
    Private Sub RptFormLiquidacionCombustible_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarReporteGeneral()
    End Sub
    Public Sub setCodigo(codigo As Integer)
        Me.codigo = codigo
    End Sub

    Sub cargarReporteGeneral()

        Dim dt As DataTable = getiquidacionGeneral(codigo)

        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "Formularios/Reportes/RptLiquidacionCombustibleCabecera.rdlc"

        Dim rds As New ReportDataSource("DataSet1", dt)
        ReportViewer1.LocalReport.DataSources.Add(rds)
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf subReporteCombustibleDetalle

        ReportViewer1.RefreshReport()
    End Sub

    Function getiquidacionGeneral(codigo As Integer) As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.setConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            dt = liquidacionDAO.getRptLiquidacionGeneral(codigo)
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

    Public Sub subReporteCombustibleDetalle(ByVal sender As Object,
     ByVal e As SubreportProcessingEventArgs)

        Dim codigo As Integer = CInt(e.Parameters("CodigoLiquidacion").Values(0).ToString)
        Dim dt As New DataTable
        dt = getiquidacionCombustibleDetalle(codigo)
        Dim rds As New ReportDataSource("DataSet1", dt)
        e.DataSources.Add(rds)

    End Sub

    Function getiquidacionCombustibleDetalle(codigo As Integer) As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.setConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            dt = liquidacionDAO.getRptLiquidacionCombustible(codigo)
            sqlControl.commitTransaction()
            Return dt
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("No se pudo cargar la liquidación detalle. " + ex.Message, "Cargar Liquidación",
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