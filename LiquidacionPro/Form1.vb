Public Class frmLiquidacion
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim liquidacionDao As New LiquidacionDAO
        Dim dt As DataTable

        dt = liquidacionDao.GetAllLiquidacion()
        dgvLiquidacion.DataSource = dt
    End Sub

End Class
