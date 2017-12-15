Public Class ChildGuia
    Private Sub ChildGuia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarGuias()
        cargarEstadoGuia()
    End Sub

    Sub cargarGuias()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim guiaDao As New GuiaDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            guiaDao.setDBcmd()

            Dim dt As DataTable

            dt = guiaDao.GetAllGuia
            dgvGuias.DataSource = dt

            sqlControl.commitTransaction()

            dgvGuias.Columns(2).Visible = False
            dgvGuias.Columns(3).DefaultCellStyle.Format = "dd/MM/yyyy"
            dgvGuias.Columns(4).DefaultCellStyle.Format = "dd/MM/yyyy"
            'dgvLiquidacion.Columns(4).Visible = False
            'dgvLiquidacion.Columns(6).Visible = False
            'dgvLiquidacion.Columns(8).Visible = False
            'dgvLiquidacion.Columns(23).Visible = False

            dgvGuias.MultiSelect = False
            dgvGuias.RowHeadersVisible = False

        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception

            End Try
        End Try
    End Sub

    Private Sub cargarEstadoGuia()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim estadoDao As New EstadoGuiaDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            estadoDao.setDBcmd()

            Dim dtEstado As DataTable

            dtEstado = estadoDao.getEstados
            sqlControl.commitTransaction()

            With cbEstado
                .DataSource = dtEstado
                .DisplayMember = "DETALLE_ESTADO"
                .ValueMember = "CODIGO_ESTADO"
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception

            End Try
        End Try

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtCodigo.Text = ""
        txtDetalle.Text = ""
        cbEstado.SelectedIndex = -1
        dtpLiquidacion.Value = Date.Now
        dtpFacturacion.Value = Date.Now

    End Sub

    Private Sub dgvGuias_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvGuias.CellMouseClick
        cargaGuiaByCodigo
    End Sub

    Sub cargaGuiaByCodigo()
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim guiaDao As New GuiaDAO(sqlControl)
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            guiaDao.setDBcmd()

            Dim seleccion As DataGridViewRow = dgvGuias.SelectedRows(0)
            Dim codigo As Integer = seleccion.Cells(0).Value

            Dim dt As DataTable

            dt = guiaDao.getGuiaByCodigo(codigo)

            sqlControl.commitTransaction()

            txtCodigo.Text = dt.Rows(0)(0)
            txtDetalle.Text = dt.Rows(0)(1)
            cbEstado.SelectedValue = dt.Rows(0)(2)

            If dt.Rows.Item(0)(3) IsNot DBNull.Value Then
                dtpLiquidacion.Value = dt.Rows.Item(0)(3)
                dtpLiquidacion.Enabled = True
                chkbLiquidacion.Checked = True
            Else
                dtpLiquidacion.Value = Date.Now
                dtpLiquidacion.Enabled = False
                chkbLiquidacion.Checked = False
            End If

            If dt.Rows.Item(0)(4) IsNot DBNull.Value Then
                dtpFacturacion.Value = dt.Rows.Item(0)(4)
                dtpFacturacion.Enabled = True
                chkbFacturacion.Checked = True
            Else
                dtpFacturacion.Value = Date.Now
                dtpFacturacion.Enabled = False
                chkbFacturacion.Checked = False
            End If


        Catch ex As Exception
            sqlControl.rollbackTransaccion()
        Finally
            Try
                sqlControl.closeConexion()
            Catch ex As Exception

            End Try
        End Try
    End Sub
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim proceso As String
        proceso = ""

        Dim guiaDao As New GuiaDAO(sqlControl)

        If txtCodigo.Text = Nothing Then
            Try
                sqlControl.openConexion()
                sqlControl.beginTransaction()
                guiaDao.setDBcmd()

                Dim correla As Integer
                proceso = "grabada"

                Dim fliqui As Date
                If chkbLiquidacion.Checked = True Then
                    fliqui = dtpLiquidacion.Value
                Else
                    fliqui = Nothing
                End If

                Dim ffactura As Date
                If chkbFacturacion.Checked = True Then
                    ffactura = dtpLiquidacion.Value
                Else
                    ffactura = Nothing
                End If

                correla = guiaDao.InsertGuia(txtDetalle.Text, cbEstado.SelectedValue,
                                             fliqui, ffactura)
                If correla >= 0 Then
                    txtCodigo.Text = CStr(correla)
                    MsgBox("Guía " + proceso + " correctamente.")
                End If
                sqlControl.commitTransaction()
            Catch excep As Exception
                sqlControl.rollbackTransaccion()
                MsgBox("Error. Verifique")
            Finally
                Try
                    sqlControl.closeConexion()
                Catch ex As Exception

                End Try
            End Try
        Else
            Try
                sqlControl.openConexion()
                sqlControl.beginTransaction()
                guiaDao.setDBcmd()

                Dim correla As Integer
                proceso = "actualizada"

                Dim fliqui As Date
                If chkbLiquidacion.Checked = True Then
                    fliqui = dtpLiquidacion.Value
                Else
                    fliqui = Nothing
                End If

                Dim ffactura As Date
                If chkbFacturacion.Checked = True Then
                    ffactura = dtpLiquidacion.Value
                Else
                    ffactura = Nothing
                End If

                correla = guiaDao.UpdatetGuia(CInt(txtCodigo.Text), txtDetalle.Text, cbEstado.SelectedValue,
                                              fliqui, ffactura)
                If correla >= 0 Then
                    txtCodigo.Text = CStr(correla)
                    MsgBox("Guía " + proceso + " correctamente.")
                End If
                sqlControl.commitTransaction()
            Catch excep As Exception
                sqlControl.rollbackTransaccion()
                MsgBox("Error. Verifique")
            Finally
                Try
                    sqlControl.closeConexion()
                Catch ex As Exception

                End Try
            End Try
        End If


        cargarGuias()
    End Sub

    Private Sub chkbLiquidacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkbLiquidacion.CheckedChanged
        If chkbLiquidacion.Checked = True Then
            dtpLiquidacion.Enabled = True
        Else
            dtpLiquidacion.Enabled = False
        End If
    End Sub

    Private Sub chkbFacturacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkbFacturacion.CheckedChanged
        If chkbFacturacion.Checked = True Then
            dtpFacturacion.Enabled = True
        Else
            dtpFacturacion.Enabled = False
        End If
    End Sub
End Class