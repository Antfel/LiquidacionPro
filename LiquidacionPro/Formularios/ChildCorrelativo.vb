Imports System.Data.SqlClient

Public Class ChildCorrelativo
    Private Sub ChildCorrelativo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarCorrelativo()
    End Sub

    Sub cargarCorrelativo()

        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim correlativo As New Correlativo_NumeroDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            correlativo.setDBcmd()

            Dim dt As DataTable = correlativo.GetAllCorrelativo
            dgvCorrelativo.DataSource = dt
            sqlControl.CommitTransaction()
        Catch excep As Exception
            sqlControl.RollbackTransaccion()
        Finally
            Try
                correlativo.closeConexion()
            Catch ex As Exception

            End Try
        End Try

    End Sub

    Private Sub dgvCorrelativo_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvCorrelativo.CellMouseClick
        cargarCorrelativoNumero()
    End Sub

    Sub cargarCorrelativoNumero()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim correlativoNumero As New Correlativo_NumeroDAO(sqlControl)

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            correlativoNumero.setDBcmd()

            If dgvCorrelativo.CurrentRow.Index > -1 Then
                Dim dt As DataTable

                Dim seleccion As DataGridViewRow = dgvCorrelativo.SelectedRows(0)
                Dim codigo As Integer = seleccion.Cells(0).Value
                Dim descripcion As String = seleccion.Cells(1).Value

                dt = correlativoNumero.GetAllCorrelativoNumeroByCorrelativo(codigo)

                sqlControl.CommitTransaction()

                txtCorrealtivo.Text = CStr(codigo)
                txtDescripcion.Text = descripcion
                txtDetalleCorrelativo.Text = ""
                txtSerie.Text = ""
                txtUltimoUsado.Text = ""

                dgvCorrelativoNumero.DataSource = dt



            End If
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
        Finally
            Try
                sqlControl.CloseConexion()
            Catch exp As Exception
            End Try

        End Try
    End Sub
    Private Sub dgvCorrelativoNumero_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvCorrelativoNumero.CellMouseClick
        'Dim sqlControl As New SQLControl
        'sqlControl.setConnection()

        'Dim correlativoNumero As New Correlativo_NumeroDAO(sqlControl)

        Try
            'sqlControl.openConexion()
            'sqlControl.beginTransaction()
            'correlativoNumero.setDBcmd()

            If e.RowIndex > -1 Then
                ' Dim dt As DataTable

                Dim seleccion As DataGridViewRow = dgvCorrelativoNumero.SelectedRows(0)
                Dim codigo As Integer = seleccion.Cells(0).Value
                Dim detalle As Integer = seleccion.Cells(1).Value
                Dim serie As String = seleccion.Cells(2).Value
                Dim ultimo As String = seleccion.Cells(3).Value
                ' dt = correlativoNumero.GetCorrelativoNumeroByCodigoSerie(codigo, serie)

                txtDetalleCorrelativo.Text = CStr(detalle)
                txtSerie.Text = serie
                txtUltimoUsado.Text = ultimo

                ' Console.WriteLine("roreo: " + CStr(dt.Rows.Count))

                ' dgvCorrelativoNumero.DataSource = dt

            End If
        Catch ex As Exception
            'Console.WriteLine("dasdasdasd: " + ex.Message)
        Finally
            Try
                'sqlControl.closeConexion()
            Catch exp As Exception

            End Try

        End Try
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim correlativo_numero As New Correlativo_NumeroDAO(sqlControl)

        If txtSerie.Text = "" Then
            MsgBox("Seleccionar un correlativo.")
            Return
        End If

        Try

            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            correlativo_numero.setDBcmd()

            Dim flag As Integer

            Dim codigo As Integer
            Dim serie As String
            Dim ultimo As String

            codigo = CStr(txtCorrealtivo.Text)
            serie = txtSerie.Text
            ultimo = txtUltimoUsado.Text

            flag = correlativo_numero.updateCorrelativoNumero(codigo, serie, ultimo)
            sqlControl.CommitTransaction()
            If flag > 0 Then
                MessageBox.Show("Grabación exitosa", "Grabar correlativo",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information)
            Else
                MessageBox.Show("Verifique la numeración", "Grabar correlativo",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End If
        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al grabar. " + ex.Message, "Grabar correlativo",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al grabar. " + ex.Message, "Grabar correlativo",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
                cargarCorrelativoNumero()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. " + ex.Message, "Grabar correlativo",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try

        End Try
    End Sub
End Class