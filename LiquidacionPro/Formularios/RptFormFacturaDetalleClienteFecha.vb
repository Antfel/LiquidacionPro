Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class RptFormFacturaDetalleByClienteFecha
    Private Sub RptFormFacturaDetalleByMoneda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarClientes()
        cargarMoneda()
    End Sub

    Sub cargarMoneda()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim monedaDao As New MonedaDAO(sqlControl)

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            monedaDao.setDBcmd()

            Dim dtMoneda As DataTable

            dtMoneda = monedaDao.GetMonedas

            With cbMoneda
                .DataSource = dtMoneda
                .DisplayMember = "DETALLE_MONEDA"
                .ValueMember = "CODIGO_MONEDA"
                .SelectedIndex = -1
            End With
            sqlControl.CommitTransaction()
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar datos moneda. " + ex.Message, "Cargar datos moneda",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar datos moneda",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try

        End Try
    End Sub
    Sub cargarClientes()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim clienteDao As New ClienteDAO(sqlControl)

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()

            clienteDao.setDBcmd()

            Dim dtCliente As DataTable
            dtCliente = clienteDao.GetClientes
            sqlControl.CommitTransaction()

            With cbCliente
                .DataSource = dtCliente
                .DisplayMember = "RAZON_CLIENTE"
                .ValueMember = "CODIGO_CLIENTE"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1

            End With


        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar cliente. " + ex.Message, "Cargar datos de cliente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar cliente. " + ex.Message, "Cargar datos de cliente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar datos de cliente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try

        End Try
    End Sub
    Sub cargarReporteGeneral()

        Dim dt As DataTable = getLiquidacionFacturacionCabecera()
        ReportViewer1.Reset()
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "Formularios/Reportes/RptFacturaDetalleByMoneda.rdlc"

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

            Dim cliente As Integer
            If cbCliente.SelectedIndex < 0 Then
                cliente = -1
            Else
                cliente = cbCliente.SelectedValue
            End If

            dt = facturacionDAO.GetRptFacturaDetalleByClienteFecha(cbMoneda.SelectedValue, cliente, chbkFechas.Checked, dtpInicio.Value, dtpFin.Value)
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

    Public Sub subReporteLiquidacionFacturacionDetalle(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)

        Dim codigo As Integer = CInt(e.Parameters("CodigoFactura").Values(0).ToString)
        Dim detalle As Integer = CInt(e.Parameters("CodigoDetalle").Values(0).ToString)
        Dim dt As New DataTable
        dt = getLiquidacionFacturacionDetalle(codigo, detalle)
        Dim rds As New ReportDataSource("DataSet1Id", dt)
        e.DataSources.Add(rds)

    End Sub

    Function getLiquidacionFacturacionDetalle(codigo As Integer, detalle As Integer) As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.SetConnection()

        Dim facturacionDAO As New FacturacionDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            facturacionDAO.SetDBcmd()

            dt = facturacionDAO.GetRptFacturaDetalleByMonedaAndId(codigo, detalle)
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

    Private Sub RptFormFacturaDetalleByClienteFecha_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim s As Size

        s.Width = Me.Size.Width - 17
        '137 a 175
        s.Height = Me.Size.Height - 175

        ReportViewer1.Size = s

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If cbMoneda.SelectedIndex = -1 Then
            MessageBox.Show("Seleccionar la moneda. ", "Ver reporte",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If
        cargarReporteGeneral()
    End Sub

    Private Sub chbkFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chbkFechas.CheckedChanged
        If chbkFechas.Checked Then
            dtpInicio.Enabled = True
            dtpFin.Enabled = True
        Else
            dtpInicio.Enabled = False
            dtpFin.Enabled = False
        End If
    End Sub
End Class