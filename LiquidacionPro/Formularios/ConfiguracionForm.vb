Public Class ConfiguracionForm
    Dim valor As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        setValor(txtPass.Text)
        Me.Dispose()
    End Sub
    Public Sub setValor(valor As String)
        Me.valor = valor
    End Sub

    Public Function getValor() As String
        Return Me.valor
    End Function

    Private Sub ConfiguracionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class