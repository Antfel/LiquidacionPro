Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim clienteDao As New ClienteDAO
        Dim num As Integer

        num = clienteDao.GetClientes().Rows.Count


        MsgBox("DEBE INGRESAR R.U.C., RAZON SOCIAL Y DIRECCION" + CStr(num))

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim personalDAO As New PersonalDAO
        Dim TotalEmpleados = personalDAO.getPersonal().Rows.Count

        MsgBox("Total de Empleados: " + TotalEmpleados.ToString)

    End Sub
End Class
