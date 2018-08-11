Public Class FrmLogin
    Private Sub btnLogear_Click(sender As Object, e As EventArgs) Handles btnLogear.Click
        'Dim sqlControl As New SQLControl
        'sqlControl.SetConnection()

        'Dim correlativo As New UsuarioDAO(sqlControl)
        'Try
        '    sqlControl.OpenConexion()
        '    sqlControl.BeginTransaction()
        '    correlativo.setDBcmd()

        '    Dim dt As DataTable = correlativo.Login(txtUsuario.Text, txtPass.Text)
        '    sqlControl.CommitTransaction()

        '    If dt.Rows.Count > 0 Then
        '        Dim ObjMDIPrincipal As New MDIPrincipal
        '        ObjMDIPrincipal.Show()
        '        Me.Close()
        '    Else
        '        MessageBox.Show("Error al validar. ", "Validar",
        '                         MessageBoxButtons.OK,
        '                         MessageBoxIcon.Error)
        '    End If

        'Catch excep As Exception
        '    sqlControl.RollbackTransaccion()
        'Finally
        '    Try
        '        correlativo.closeConexion()
        '    Catch ex As Exception

        '    End Try
        'End Try


        Logeo()
    End Sub


    Delegate Sub callMDIFrmCallBack()

    Public Sub CallMDIFrm()
        'If Me.dgvFacturas.InvokeRequired Then
        '    Dim d As New llenarTablaCallBack(AddressOf LlenarTabla)
        '    Me.Invoke(d, New Object() {lista})
        'Else
        '    dgvFacturas.DataSource = lista
        'End If

        Dim ObjMDIPrincipal As New MDIPrincipal
        ObjMDIPrincipal.Show()
        Me.Close()

    End Sub
    Sub Logeo()
        Dim dao As New FacturaDao()
        Dim loginClass As New LoginClass

        loginClass.usernameOrEmail = txtUsuario.Text
        loginClass.password = txtPass.Text

        Dim lista As New TokenClass

        Dim t As Task = New Task(Sub()
                                     lista = dao.Logeo(loginClass).Result
                                 End Sub)
        t.Start()

        t.Wait()
        Console.WriteLine("Token: " + lista.accessToken)

        Me.CallMDIFrm()
    End Sub
End Class