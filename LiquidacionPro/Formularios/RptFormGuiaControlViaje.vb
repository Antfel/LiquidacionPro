Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class RptFormGuiaControlViaje
    Private Sub RptFormGuiaControlViaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarTrabajador()
        cargarClientes()
        cargarDatosTracto()
        cargarDatosSemiTrailer()
    End Sub

    Private Sub cargarDatosTracto()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim unidadDao As New UnidadDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            unidadDao.setDBcmd()

            Dim dtUnidad As DataTable

            dtUnidad = unidadDao.getUnidadTractos()
            sqlControl.CommitTransaction()

            With cbTracto
                .DataSource = dtUnidad
                .DisplayMember = "PLACA_UNIDAD"
                .ValueMember = "CODIGO_UNIDAD"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()

            MessageBox.Show("Error al cargar tractos. " + ex.Message, "Cargar Tractos",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar tractos. " + ex.Message, "Cargar Tractos",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar Tractos",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try


    End Sub

    Private Sub cargarDatosSemiTrailer()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim unidadDao As New UnidadDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            unidadDao.setDBcmd()

            Dim dtUnidad As DataTable

            dtUnidad = unidadDao.getUnidadSemiTrailer
            sqlControl.CommitTransaction()

            With cbCamabaja
                .DataSource = dtUnidad
                .DisplayMember = "PLACA_UNIDAD"
                .ValueMember = "CODIGO_UNIDAD"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar semitrailer. " + ex.Message, "Cargar Semitrailer",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar semitrailer. " + ex.Message, "Cargar Semitrailer",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Cargar Semitrailer",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try
        End Try

    End Sub
    Sub cargarTrabajador()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim trabajadorDAO As New TrabajadorDAO(sqlControl)

        Try
            If sqlControl.OpenConexion() Then
                sqlControl.BeginTransaction()

                trabajadorDAO.setDBcmd()

                Dim dt As DataTable
                dt = trabajadorDAO.getAllTrabajador
                sqlControl.CommitTransaction()

                With cbTrabajador
                    .DataSource = dt
                    .DisplayMember = "NOMBRE_COMPLETO"
                    .ValueMember = "CODIGO"
                    .DropDownStyle = ComboBoxStyle.Simple
                    .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                    .AutoCompleteSource = AutoCompleteSource.ListItems
                    .SelectedIndex = -1

                End With
            End If

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar trabajadores. " + ex.Message, "Cargar datos de trabajadores",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar trabajadores. " + ex.Message, "Cargar datos de trabajadores",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar la conexión. " + ex.Message, "Cargar datos de trabajadores",
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
            If sqlControl.OpenConexion() Then
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
            End If

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
            sqlControl.CloseConexion()
        End Try
    End Sub
    Private Sub chbxInicio_CheckedChanged(sender As Object, e As EventArgs) Handles chbxFechaGuia.CheckedChanged
        If chbxFechaGuia.Checked = True Then
            dtpFechaGuia.Enabled = True
        Else
            dtpFechaGuia.Enabled = False
        End If
    End Sub

    Private Sub RptFormGuiaControlViaje_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim tamX, tamY As Integer
        tamX = Me.Size.Width
        tamY = Me.Size.Height

        Dim tam As New Size(tamX - 18, tamY - 125)
        ReportViewer1.Size = tam
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        cargarReporteGeneral()
    End Sub

    Sub cargarReporteGeneral()

        Dim dt As DataTable = GetReporteGuiaControlViaje()

        ReportViewer1.Reset()
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "Formularios/Reportes/RptGuiasControl.rdlc"
        ReportViewer1.Refresh()

        'Dim paramList As New List(Of ReportParameter)

        'If chbxInicio.Checked Then
        '    paramList.Add(New ReportParameter("f_inicio", dtpInicio.Value, True))
        '    paramList.Add(New ReportParameter("f_inicio_flag", False, True))
        'End If

        'If chbxFinal.Checked Then
        '    paramList.Add(New ReportParameter("f_final", dtpFinal.Value, True))
        '    paramList.Add(New ReportParameter("f_final_flag", False, True))
        'End If

        'ReportViewer1.LocalReport.SetParameters(paramList)
        Dim rds As New ReportDataSource("DataSet1", dt)
        ReportViewer1.LocalReport.DataSources.Add(rds)
        'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf subReporteLiquidacionFacturacionDetalle

        ReportViewer1.RefreshReport()
    End Sub

    Function GetReporteGuiaControlViaje() As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.SetConnection()

        Dim guiaDAO As New GuiaDAO(sqlControl)

        dt = Nothing
        Try
            If sqlControl.OpenConexion() Then
                sqlControl.BeginTransaction()
                guiaDAO.setDBcmd()

                Dim cliente As Integer
                If cbCliente.SelectedIndex < 0 Then
                    cliente = -1
                Else
                    cliente = cbCliente.SelectedValue
                End If

                Dim trabajador As Integer
                If cbTrabajador.SelectedIndex < 0 Then
                    trabajador = -1
                Else
                    trabajador = cbTrabajador.SelectedValue
                End If

                Dim origen, destino As String
                If txtOrigen.Text = Nothing Then
                    origen = ""
                Else
                    origen = txtOrigen.Text
                End If

                If txtDestino.Text = Nothing Then
                    destino = ""
                Else
                    destino = txtDestino.Text
                End If

                Dim tracto As Integer
                If cbTracto.SelectedIndex < 0 Then
                    tracto = -1
                Else
                    tracto = cbTracto.SelectedValue
                End If

                Dim semitrailer As Integer
                If cbCamabaja.SelectedIndex < 0 Then
                    semitrailer = -1
                Else
                    semitrailer = cbCamabaja.SelectedValue
                End If
                dt = guiaDAO.GetRptGuiaControlViaje(cliente, trabajador, origen, destino, dtpFechaGuia.Value, chbxFechaGuia.Checked, tracto, semitrailer)
                sqlControl.CommitTransaction()
            End If

            Return dt
        Catch ex As SqlException
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
End Class