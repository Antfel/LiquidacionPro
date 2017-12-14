Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Reporting.WinForms

Public Class RptImprimeFactura
    Private Sub RptImprimeFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'rptLiquidaciones.dtRptFacturaCabecera' Puede moverla o quitarla según sea necesario.

        'TODO: esta línea de código carga datos en la tabla 'rptLiquidaciones.dtRptFacturaCabecera' Puede moverla o quitarla según sea necesario.

        'TODO: esta línea de código carga datos en la tabla 'rptLiquidaciones.dtRptFacturaCabecera' Puede moverla o quitarla según sea necesario.

        'TODO: esta línea de código carga datos en la tabla 'rptLiquidaciones.dtRptFacturaCabecera' Puede moverla o quitarla según sea necesario.
        'Dim tam As New Size(Me.Size.Width - 5, Me.Size.Height - 5)
        'ReportViewer1.Size = tam

    End Sub

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'dtRptFacturaCabeceraTableAdapter.Fill(rptLiquidaciones.dtRptFacturaCabecera, 0)

        'ReportViewer1.RefreshReport()


        'Dim dtRptFacturaCabeceraTableAdapter As New rptLiquidacionesTableAdapters.dtRptFacturaCabeceraTableAdapter
        'Dim dt As DataTable
        'dt = dtRptFacturaCabeceraTableAdapter.GetData(0)

        'Dim dtRptFacturaDetalleTableAdapter As New rptLiquidacionesTableAdapters.dtRptFacturaDetalleTableAdapter
        'Dim dtd As DataTable
        'dtd = dtRptFacturaDetalleTableAdapter.GetData(0)

        'Dim dtRptFacturaGuiaTableAdapter As New rptLiquidacionesTableAdapters.dtRptFacturaGuiaTableAdapter
        'Dim dtg As DataTable

        'TextBox1.Text = dt.Rows.Item(0)(0)
        'ReportViewer1.Reset()
        'ReportViewer1.LocalReport.ReportEmbeddedResource = "LiquidacionPro.Reportes.rptFacturaCabecera.rdlc"
        'ReportViewer1.LocalReport.ReportPath = "LiquidacionPro.Reportes.rptFacturaCabecera.rdlc"

        'Dim rptDataSource As New ReportDataSource("DataSet1", dt)
        ''TextBox1.Text = dt.DataSet.DataSetName

        'ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
        'ReportViewer1.LocalReport.Refresh()



        'Dim objReporte As New RptFactura
        'Dim objReporteDetalle As New RptFacturaDetalle
        ''objReporte.SetParameterValue("codigo_factura", 3)
        'objReporte.SetDataSource(dt)

        ''objReporte.Subreports(1).SetDataSource(dtd)

        'If objReporte.Subreports.Count > 0 Then
        '    If dtd.Rows.Count > 0 Then
        '        objReporte.Subreports.Item("RptFacturaDetalle.rpt").SetDataSource(dtd)
        '        For i As Integer = 0 To dtd.Rows.Count - 1
        '            'objReporteDetalle = objReporte.Subreports.Item("RptFacturaDetalle.rpt")
        '            'objReporteDetalle.Subreports.Item("")
        '            dtg = dtRptFacturaGuiaTableAdapter.GetData(dtd.Rows.Item(7)(8), dtd.Rows.Item(7)(8))

        '        Next


        '    Else
        '    End If
        'End If

        'Dim dtRptFacturaCompletaTableAdapter As New rptLiquidacionesTableAdapters.dtFacturaCompletaTableAdapter
        'Dim dt As DataTable
        'dt = dtRptFacturaCompletaTableAdapter.GetData(0)

        'Dim objReporte As New RptFacturaCompleta

        'objReporte.SetDataSource(dt)

        'CrystalReportViewer1.ReportSource = objReporte

        'CrystalReportViewer1.Refresh()

        Dim dtFacturaDetalleTableAdapter As New rptLiquidacionesTableAdapters.dtFacturaDetalleTableAdapter
        Dim dt As DataTable
        dt = dtFacturaDetalleTableAdapter.GetData(0)

        Dim dtFacturaGuiaTableAdapter As New rptLiquidacionesTableAdapters.dtRptFacturaGuiaTableAdapter
        Dim dtg As DataTable
        'dtg = dtFacturaGuiaTableAdapter.GetData(0)

        Dim objReporte As New RptFacturaImpr

        objReporte.SetDataSource(dt)

        'objReporte.Subreports.Item("RptFacturaGuia.rpt").SetDataSource(dtg)

        CrystalReportViewer1.ReportSource = objReporte

        CrystalReportViewer1.Refresh()


    End Sub

End Class