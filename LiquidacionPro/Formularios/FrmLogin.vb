Public Class FrmLogin
    Private Sub btnLogear_Click(sender As Object, e As EventArgs) Handles btnLogear.Click
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim correlativo As New UsuarioDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            correlativo.setDBcmd()

            Dim dt As DataTable = correlativo.Login(txtUsuario.Text, txtPass.Text)
            sqlControl.CommitTransaction()

            If dt.Rows.Count > 0 Then
                Dim ObjMDIPrincipal As New MDIPrincipal
                ObjMDIPrincipal.Show()
                Me.Close()
            Else
                MessageBox.Show("Error al validar. ", "Validar",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End If

        Catch excep As Exception
            sqlControl.RollbackTransaccion()
        Finally
            Try
                correlativo.closeConexion()
            Catch ex As Exception

            End Try
        End Try
    End Sub
End Class