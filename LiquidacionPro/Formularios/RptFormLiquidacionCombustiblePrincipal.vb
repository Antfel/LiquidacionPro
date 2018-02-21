Imports Microsoft.Reporting.WinForms
Public Class RptFormLiquidacionCombustiblePrincipal

    Dim codigo As Integer
    Private Sub RptFormLiquidacionCombustiblePrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarReporteGeneral()

    End Sub

    Public Sub setCodigo(codigo As Integer)
        Me.codigo = codigo
    End Sub

    Sub cargarReporteGeneral()

        Dim dt As DataTable = getiquidacionPrincipal(codigo)

        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "Formularios/Reportes/RptLiquidacionCombustiblePrincipal.rdlc"

        Dim rds As New ReportDataSource("DataSet1", dt)
        ReportViewer1.LocalReport.DataSources.Add(rds)
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf subReporteCombustiblePrincipalDetalle

        ReportViewer1.RefreshReport()
    End Sub

    Function getiquidacionPrincipal(codigo As Integer) As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.SetConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            liquidacionDAO.setDBcmd()

            dt = liquidacionDAO.getRptLiquidacionCombustiblePrincipal(codigo)
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

    Public Sub subReporteCombustiblePrincipalDetalle(ByVal sender As Object,
     ByVal e As SubreportProcessingEventArgs)

        Dim codigo As Integer = CInt(e.Parameters("CodigoLiquidacion").Values(0).ToString)
        Dim dt As New DataTable
        dt = getiquidacionCombustiblePrincipalDetalle(codigo)
        Dim rds As New ReportDataSource("DataSet1", dt)
        e.DataSources.Add(rds)

    End Sub

    Function getiquidacionCombustiblePrincipalDetalle(codigo As Integer) As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.SetConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            liquidacionDAO.setDBcmd()

            dt = liquidacionDAO.getRptLiquidacionCombustiblePrincipalDetalle(codigo)
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