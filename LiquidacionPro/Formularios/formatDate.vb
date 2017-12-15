Public Class formatDate
    Public Function formatMonth(ByVal num As String)
        Dim month As String = "null"
        Select Case num
            Case "1"
                month = "ENERO"
            Case "2"
                month = "FEBRERO"
            Case "3"
                month = "MARZO"
            Case "4"
                month = "ABRIL"
            Case "5"
                month = "MAYO"
            Case "6"
                month = "JUNIO"
            Case "7"
                month = "JULIO"
            Case "8"
                month = "AGOSTO"
            Case "9"
                month = "SEPTIEMBRE"
            Case "10"
                month = "OCTUBRE"
            Case "11"
                month = "NOVIEMBRE"
            Case "12"
                month = "DICIEMBRE"
        End Select
        Return month
    End Function
End Class