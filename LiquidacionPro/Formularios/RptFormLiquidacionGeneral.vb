Imports Microsoft.Reporting.WinForms

Public Class RptFormLiquidacionGeneral

    Dim codigo As Integer
    Private Sub RptFormLiquidacionGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarReporteGeneral()
    End Sub

    Public Sub setCodigo(codigo As Integer)
        Me.codigo = codigo
    End Sub
    Function getiquidacionGeneral(codigo As Integer) As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.SetConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            liquidacionDAO.setDBcmd()

            dt = liquidacionDAO.getRptLiquidacionGeneral(codigo)
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

    Function getiquidacionGeneralDetalle(codigo As Integer) As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.SetConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            liquidacionDAO.setDBcmd()

            dt = liquidacionDAO.getRptLiquidacionGeneralDetalle(codigo)
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

    Sub cargarReporteGeneral()

        Dim dt As DataTable = getiquidacionGeneral(codigo)
        'ReportViewer1.Reset()
        'ReportViewer1.ProcessingMode = ProcessingMode.Local
        'ReportViewer1.LocalReport.ReportPath = "C:\Users\rasec\source\repos\LiquidacionPro\LiquidacionPro\Formularios\Reportes\RptLiquidacionGeneral.rdlc"
        'Dim rds As New ReportDataSource("DataSet1", dt)
        'ReportViewer1.LocalReport.DataSources.Clear()
        'ReportViewer1.LocalReport.DataSources.Add(rds)
        ''ReportViewer1.LocalReport.Refresh()
        'ReportViewer1.Refresh()



        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "Formularios/Reportes/RptLiquidacionGeneral.rdlc"
        'Dim rds As New ReportDataSource
        'rds.Name = "DataSet1"
        'rds.Value = dt
        Dim rds As New ReportDataSource("DataSet1", dt)
        ReportViewer1.LocalReport.DataSources.Add(rds)
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf subReporteGeneralDetalle

        ReportViewer1.RefreshReport()
    End Sub

    Public Sub subReporteGeneralDetalle(ByVal sender As Object,
     ByVal e As SubreportProcessingEventArgs)

        Dim codigo As Integer = CInt(e.Parameters("CodigoLiquidacion").Values(0).ToString)
        Dim dt As New DataTable
        dt = getiquidacionGeneralDetalle(codigo)
        Dim rds As New ReportDataSource("DataSet1", dt)
        e.DataSources.Add(rds)

    End Sub

End Class