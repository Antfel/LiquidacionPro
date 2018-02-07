Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class RptFormLiquidacionByTrabajador
    Private Sub RptFormLiquidacionByTrabajador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarTrabajador
    End Sub

    Sub cargarTrabajador()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim trabajadorDAO As New TrabajadorDAO(sqlControl)

        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()

            trabajadorDAO.setDBcmd()

            Dim dt As DataTable
            dt = trabajadorDAO.getAllTrabajador
            sqlControl.commitTransaction()

            With cbTrabajador
                .DataSource = dt
                .DisplayMember = "NOMBRE_COMPLETO"
                .ValueMember = "CODIGO"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1

            End With


        Catch ex As SqlException
            sqlControl.rollbackTransaccion()
            MessageBox.Show("Error al cargar trabajadores. " + ex.Message, "Cargar datos de trabajadores",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar trabajadores. " + ex.Message, "Cargar datos de trabajadores",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar datos de trabajadores",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try

        End Try
    End Sub
    Sub cargarReporte()

        Dim dt As DataTable = getLiquidacionByTrabajador()

        ReportViewer1.Reset()
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "Formularios/Reportes/RptLiquidacionVsTrabajador.rdlc"
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
        'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf subReporteCombustibleDetalle

        ReportViewer1.RefreshReport()
    End Sub

    Function getLiquidacionByTrabajador() As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.setConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            Dim codigo As Integer
            If cbTrabajador.SelectedIndex >= 0 Then
                codigo = cbTrabajador.SelectedValue
            Else
                codigo = -1
            End If

            dt = liquidacionDAO.getRptLiquidacionByTrabajador(codigo, chbxInicio.Checked, dtpInicio.Value,
                                                              chbxFinal.Checked, dtpFinal.Value)
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

    Private Sub RptFormLiquidacionByTrabajador_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim tamX, tamY As Integer
        tamX = Me.Size.Width
        tamY = Me.Size.Height

        Dim tam As New Size(tamX - 18, tamY - 125)
        ReportViewer1.Size = tam
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        cargarReporte()
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
End Class