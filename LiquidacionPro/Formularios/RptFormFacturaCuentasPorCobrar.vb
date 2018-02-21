Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class RptFormFacturaCuentasPorCobrar
    Private Sub RptFormFacturaCuentasPorCobrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarClientes()
    End Sub

    Sub cargarReporteGeneral()

        Dim dt As DataTable = getFacturaCuentasPorCobrar()

        ReportViewer1.Reset()
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "Formularios/Reportes/RptFacturaCuentasPorCobrar.rdlc"
        ReportViewer1.Refresh()

        Dim paramList As New List(Of ReportParameter)

        If chbxInicio.Checked Then
            paramList.Add(New ReportParameter("f_inicio", dtpInicio.Value, True))
            paramList.Add(New ReportParameter("f_inicio_flag", False, True))
        End If

        If chbxFinal.Checked Then
            paramList.Add(New ReportParameter("f_final", dtpFinal.Value, True))
            paramList.Add(New ReportParameter("f_final_flag", False, True))
        End If

        ReportViewer1.LocalReport.SetParameters(paramList)
        Dim rds As New ReportDataSource("DataSet1", dt)
        ReportViewer1.LocalReport.DataSources.Add(rds)
        'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf subReporteLiquidacionFacturacionDetalle

        ReportViewer1.RefreshReport()
    End Sub

    Function getFacturaCuentasPorCobrar() As DataTable
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

            dt = facturacionDAO.GetRptFacturaCuentasPorCobrar(chbxInicio.Checked, dtpInicio.Value, chbxFinal.Checked, dtpFinal.Value, cliente)
            sqlControl.CommitTransaction()
            Return dt
        Catch ex As SQLException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("No se pudo cargar la Facturas. " + ex.Message, "Cargar Facturas",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error)
            Return dt
        Finally

            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("No se pudo cerrar la conexión. " + ex.Message, "Cargar Facturas",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try


        End Try

    End Function

    Private Sub RptFormFacturaCuentasPorCobrar_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim tamX, tamY As Integer
        tamX = Me.Size.Width
        tamY = Me.Size.Height

        Dim tam As New Size(tamX - 18, tamY - 125)
        ReportViewer1.Size = tam
    End Sub

    Private Sub chbxInicio_CheckedChanged(sender As Object, e As EventArgs) Handles chbxInicio.CheckedChanged
        If chbxInicio.Checked = True Then
            dtpInicio.Enabled = True
        Else
            dtpInicio.Enabled = False
        End If
    End Sub

    Private Sub chbxFinal_CheckedChanged(sender As Object, e As EventArgs) Handles chbxFinal.CheckedChanged
        If chbxFinal.Checked = True Then
            dtpFinal.Enabled = True
        Else
            dtpFinal.Enabled = False
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        cargarReporteGeneral()

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
End Class