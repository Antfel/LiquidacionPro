Public Class ChildCorrelativo
    Private Sub ChildCorrelativo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarCorrelativo()
    End Sub

    Sub cargarCorrelativo()

        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim correlativo As New Correlativo_NumeroDAO(sqlControl)
        Try
            correlativo.openConexion()

            Dim dt As DataTable = correlativo.GetAllCorrelativo
            dgvCorrelativo.DataSource = dt

        Catch excep As Exception
        Finally
            Try
                correlativo.closeConexion()
            Catch ex As Exception

            End Try
        End Try

    End Sub

    Private Sub dgvCorrelativo_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvCorrelativo.CellMouseClick
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim correlativoNumero As New Correlativo_NumeroDAO(sqlControl)

        Try
            sqlControl.openConexion()

            If e.RowIndex > -1 Then
                Dim dt As DataTable

                Dim seleccion As DataGridViewRow = dgvCorrelativo.SelectedRows(0)
                Dim codigo As Integer = seleccion.Cells(0).Value
                Dim descripcion As String = seleccion.Cells(1).Value

                dt = correlativoNumero.GetAllCorrelativoNumeroByCorrelativo(codigo)


                txtCorrealtivo.Text = CStr(codigo)
                txtDescripcion.Text = descripcion
                txtDetalleCorrelativo.Text = ""
                txtSerie.Text = ""
                txtUltimoUsado.Text = ""

                dgvCorrelativoNumero.DataSource = dt



            End If
        Catch ex As Exception
        Finally
            Try
                sqlControl.closeConexion()
            Catch exp As Exception
            End Try

        End Try
    End Sub

    Private Sub dgvCorrelativoNumero_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvCorrelativoNumero.CellMouseClick
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()

        Dim correlativoNumero As New Correlativo_NumeroDAO(sqlControl)

        Try
            sqlControl.openConexion()

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
            Console.WriteLine("dasdasdasd: " + ex.Message)
        Finally
            Try
                sqlControl.closeConexion()
            Catch exp As Exception

            End Try

        End Try
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim sqlControl As New SQLControl
        sqlControl.setConnection()
        Dim correlativo_numero As Correlativo_NumeroDAO
        correlativo_numero = New Correlativo_NumeroDAO(sqlControl)

        If txtSerie.Text = "" Then
            MsgBox("Seleccionar un correlativo.")
            Return
        End If

        Try

            correlativo_numero.openConexion()
            Dim flag As Integer

            Dim codigo As Integer
            Dim serie As String
            Dim ultimo As String

            codigo = CStr(txtCorrealtivo.Text)
            serie = txtSerie.Text
            ultimo = txtUltimoUsado.Text

            flag = correlativo_numero.GetCorrelativoNumeroByCodigoSerie(codigo, serie, ultimo)

            If flag > 0 Then
                MsgBox("Grabación exitosa.")
            Else
                MsgBox("Verifique la numeración.")
            End If

        Catch ex As Exception
        Finally
            Try
                correlativo_numero.closeConexion()
            Catch ex As Exception

            End Try

        End Try
    End Sub
End Class