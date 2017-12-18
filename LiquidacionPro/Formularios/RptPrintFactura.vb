Imports System.Drawing.Printing
Imports System.Globalization

Public Class RptPrintFactura

    'Dim IDT(5, 1) As String
    'Dim CNTG(5, 2) As String
    'Dim IGT(5, 30) As String
    'Dim IGR(5, 30) As String
    'Dim IP(5, 30) As String
    'Dim IDS(5, 9) As String
    Dim cordy As Integer
    Dim PUNTEROITEM As Integer = 0
    Dim PUNTERO As Integer = 0
    Dim PUNTEROIMPR As Integer = 0
    Dim nroFactura As Integer

    Public Sub setNroFactura(nroFactura As Integer)
        Me.nroFactura = nroFactura
    End Sub

    Private Sub RptPrintFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PrintPreviewControl1.Location = New Point(88, 150)

        PrintDocument1.DefaultPageSettings.PaperSize = New PaperSize("Custom", 827, 1210)
        PrintPreviewControl1.Name = "PrintPreviewControl1"
        PrintPreviewControl1.Dock = DockStyle.Fill

        ' Set the Document property to the PrintDocument 
        ' for which the PrintPage event has been handled.
        PrintPreviewControl1.Document = PrintDocument1

        ' Set the zoom to 25 percent.
        PrintPreviewControl1.Zoom = 1

        ' Set the document name. This will show be displayed when 
        ' the document is loading into the control.
        'Me.PrintPreviewControl1.Document.DocumentName = "c:\athmsg.log"

        ' Set the UseAntiAlias property to true so fonts are smoothed
        ' by the operating system.
        PrintPreviewControl1.UseAntiAlias = True

        ' Add the control to the form.
        Controls.Add(PrintPreviewControl1)
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        'MessageBox.Show(e.PageSettings.PrintableArea.ToString)

        Dim dtFacturaCabeceraTableAdapter As New rptLiquidacionesTableAdapters.dtRptFacturaCabeceraTableAdapter
        Dim dtc As DataTable
        dtc = dtFacturaCabeceraTableAdapter.GetData(nroFactura)

        Dim dtFacturaDetalleTableAdapter As New rptLiquidacionesTableAdapters.dtRptFacturaDetalleTableAdapter
        Dim dtd As DataTable
        dtd = dtFacturaDetalleTableAdapter.GetData(nroFactura)

        Dim dtFacturaGuiaTableAdapter As New rptLiquidacionesTableAdapters.dtRptFacturaGuiaTableAdapter
        Dim dtg As DataTable

        Dim dtFacturaRemitenteTableAdapter As New rptLiquidacionesTableAdapters.dtRptFacturaRemitenteTableAdapter
        Dim dtr As DataTable

        Dim dtFacturaUnidadTableAdapter As New rptLiquidacionesTableAdapters.dtRptFacturaUnidadTableAdapter
        Dim dtu As DataTable

        Dim FONT As New Font("Abadi MT", 10, FontStyle.Regular)
        Dim moneda, simbolo As String
        Dim pgdt, pgdr, pgdp As Integer
        Dim salto As Integer = 15
        Dim mayor As Integer = 0
        Dim SUBTOTAL As Double = 0
        Dim IGV As Double = 0
        Dim TOTAL As Double = 0
        Dim MONTHF As formatDate = New formatDate()
        Dim NUMBERF As formatNUMBER = New formatNUMBER()
        Dim text As String = "SERVICIO DE TRANSPORTE "
        cordy = 275

        e.Graphics.DrawString(dtc.Rows.Item(0)(0), FONT, Brushes.Black, 85, 195)
        e.Graphics.DrawString(dtc.Rows.Item(0)(2), FONT, Brushes.Black, 610, 190)
        e.Graphics.DrawString(dtc.Rows.Item(0)(1), FONT, Brushes.Black, 85, 225)
        e.Graphics.DrawString(CDate(dtc.Rows.Item(0)(3)).Day, FONT, Brushes.Black, 65, 175)
        e.Graphics.DrawString(MONTHF.formatMonth(CDate(dtc.Rows.Item(0)(3)).Month), FONT, Brushes.Black, 130, 175)
        e.Graphics.DrawString(CDate(dtc.Rows.Item(0)(3)).Year.ToString.Substring(2, 2), FONT, Brushes.Black, 320, 175)

        If (dtc.Rows.Item(0)(10) = 0) Then
            simbolo = "S/. "
            moneda = "SOLES"
        Else
            simbolo = "$ "
            moneda = "DOLARES AMERICANOS"
        End If


        If (PUNTEROIMPR = 0) Then
            For i As Integer = 0 To dtd.Rows.Count - 1
                Dim PRNGX As Integer = 0
                e.Graphics.DrawString(dtd.Rows.Item(i)(0), FONT, Brushes.Black, 45, cordy)
                e.Graphics.DrawString(simbolo + Double.Parse(dtd.Rows.Item(i)(3)).ToString("0.00", CultureInfo.InvariantCulture), FONT, Brushes.Black, 565, cordy)
                e.Graphics.DrawString(simbolo + (Double.Parse(dtd.Rows.Item(i)(0)) * Double.Parse(dtd.Rows.Item(i)(3))).ToString("0.00", CultureInfo.InvariantCulture), FONT, Brushes.Black, 670, cordy)

                'text = "SERVICIO DE TRANSPORTE"
                'If (dtd.Rows.Item(i)(8) <> "") Then
                '    If (dtd.Rows.Item(i)(8) <> "INTEGRAL ESPECIAL" And dtd.Rows.Item(i)(8) <> "INTEGRAL") Then
                '        text = text + " EN " + dtd.Rows.Item(i)(8)
                '    Else
                '        text = text + dtd.Rows.Item(i)(8)
                '    End If
                'End If
                'If (dtd.Rows.Item(i)(17) <> "NULL") Then
                '    text = text + " DE " + dtd.Rows.Item(i)(17)
                'End If
                Console.WriteLine("tipo de servicio: " + CStr(dtd.Rows.Item(i)(19)))
                text = "SERVICIO DE TRANSPORTE "
                Select Case CInt(dtd.Rows.Item(i)(19))
                    Case 18
                        text = "SERVICIO DE TRANSPORTE "
                    Case 19
                        text = text + "EN " + dtd.Rows.Item(i)(8)
                    Case 20
                        text = text + "EN " + dtd.Rows.Item(i)(8)
                    Case 21
                        text = text + "EN " + dtd.Rows.Item(i)(8)
                    Case 22
                        text = text + "EN " + dtd.Rows.Item(i)(8)
                    Case 23
                        text = text + "EN " + dtd.Rows.Item(i)(8)
                    Case 24
                        text = text + "EN " + dtd.Rows.Item(i)(8)
                    Case 25
                        text = text + "EN " + dtd.Rows.Item(i)(8)
                    Case 26
                        text = text + "EN " + dtd.Rows.Item(i)(8)
                    Case 27
                        text = text + dtd.Rows.Item(i)(8)
                    Case 28
                        text = text + dtd.Rows.Item(i)(8)
                    Case 29
                        text = dtd.Rows.Item(i)(8)
                    Case 30
                        text = dtd.Rows.Item(i)(8)
                    Case 31
                        text = dtd.Rows.Item(i)(8)
                End Select
                If (dtd.Rows.Item(i)(17) <> "") Then
                    text = text + " DE " + dtd.Rows.Item(i)(17)
                End If

                dtg = dtFacturaGuiaTableAdapter.GetData(dtd.Rows.Item(i)(6), dtd.Rows.Item(i)(7))
                dtr = dtFacturaRemitenteTableAdapter.GetData(dtd.Rows.Item(i)(6), dtd.Rows.Item(i)(7))
                dtu = dtFacturaUnidadTableAdapter.GetData(dtd.Rows.Item(i)(6), dtd.Rows.Item(i)(7))

                If (dtg.Rows.Count <> 0 Or dtr.Rows.Count <> 0 Or dtu.Rows.Count <> 0) Then
                    text = text + " SEGUN GUIA DE REMISION:"
                End If

                printMULTILINES(text, FONT, e, salto)
                pgdt = cordy
                pgdr = cordy
                pgdp = cordy
                mayor = dtg.Rows.Count
                If (mayor <= dtr.Rows.Count) Then
                    mayor = dtr.Rows.Count
                ElseIf (mayor <= dtu.Rows.Count) Then
                    mayor = dtu.Rows.Count
                End If

                cordy = cordy + (salto * (mayor + 1))

                If (dtg.Rows.Count <> 0) Then
                    PRNGX = PRNGX + 90
                    e.Graphics.DrawString("TRANSPORTISTA", FONT, Brushes.Black, PRNGX, pgdt)
                    pgdt = pgdt + salto
                    For j As Integer = 0 To dtg.Rows.Count - 1
                        e.Graphics.DrawString(dtg.Rows.Item(j)(3), FONT, Brushes.Black, PRNGX, pgdt)
                        pgdt = pgdt + salto
                    Next
                End If
                If (dtr.Rows.Count <> 0) Then
                    If (PRNGX = 0) Then
                        PRNGX = PRNGX + 90
                    Else
                        PRNGX = PRNGX + 180
                    End If
                    e.Graphics.DrawString("REMITENTE", FONT, Brushes.Black, PRNGX, pgdr)
                    pgdr = pgdr + salto
                    For j As Integer = 0 To dtr.Rows.Count - 1
                        e.Graphics.DrawString(dtr.Rows.Item(j)(2), FONT, Brushes.Black, PRNGX, pgdr)
                        pgdr = pgdr + salto
                    Next
                End If
                If (dtu.Rows.Count <> 0) Then
                    If (PRNGX = 0) Then
                        PRNGX = PRNGX + 90
                    Else
                        PRNGX = PRNGX + 180
                    End If
                    e.Graphics.DrawString("PLACA", FONT, Brushes.Black, PRNGX, pgdp)
                    pgdp = pgdp + salto
                    For j As Integer = 0 To dtu.Rows.Count - 1
                        e.Graphics.DrawString(dtu.Rows.Item(j)(2), FONT, Brushes.Black, PRNGX, pgdp)
                        pgdp = pgdp + salto
                    Next
                End If
                If (dtd.Rows.Item(i)(4) <> "") Then
                    text = "ORIGEN: " + dtd.Rows.Item(i)(4)
                    printMULTILINES(text, FONT, e, salto)
                End If
                If (dtd.Rows.Item(i)(5) <> "") Then
                    text = "DESTINO: " + dtd.Rows.Item(i)(5)
                    printMULTILINES(text, FONT, e, salto)
                End If
                If (dtd.Rows.Item(i)(1) <> "") Then
                    text = "CONFIGURACION VEHICULAR: " + dtd.Rows.Item(i)(1)
                    printMULTILINES(text, FONT, e, salto)
                End If
                If (dtd.Rows.Item(i)(18) <> 0) Then
                    text = "VALOR REFERENCIAL: S/. " + CStr(dtd.Rows.Item(i)(18)) + vbLf
                    printMULTILINES(text, FONT, e, salto)
                End If
                If (dtd.Rows.Item(i)(2) <> "") Then
                    text = "OBSERVACION: " + dtd.Rows.Item(i)(2)
                    printMULTILINES(text, FONT, e, salto)
                End If
                cordy = cordy + (salto * 2)
                SUBTOTAL = SUBTOTAL + Double.Parse(dtd.Rows.Item(i)(0)) * Double.Parse(dtd.Rows.Item(i)(3))
            Next
        ElseIf (PUNTEROIMPR = 1) Then
            'For I As Integer = 0 To DataGridView1.Rows.Count - 1
            '    e.Graphics.DrawString(DataGridView1.Rows(I).Cells(0).Value, FONT, Brushes.Black, 45, cordy)
            '    e.Graphics.DrawString(DataGridView1.Rows(I).Cells(1).Value, FONT, Brushes.Black, 90, cordy)
            '    If DataGridView1.Rows(I).Cells(2).Value <> "" Then
            '        e.Graphics.DrawString(simbolo + Double.Parse(DataGridView1.Rows(I).Cells(2).Value).ToString("0.00", CultureInfo.InvariantCulture), FONT, Brushes.Black, 565, cordy)
            '        e.Graphics.DrawString(simbolo + (Double.Parse(DataGridView1.Rows(I).Cells(0).Value) * Double.Parse(DataGridView1.Rows(I).Cells(2).Value)).ToString("0.00", CultureInfo.InvariantCulture), FONT, Brushes.Black, 670, cordy)
            '        SUBTOTAL = SUBTOTAL + Double.Parse(DataGridView1.Rows(I).Cells(0).Value) * Double.Parse(DataGridView1.Rows(I).Cells(2).Value)
            '    End If
            '    cordy = cordy + (salto * 2)
            'Next
        End If
        IGV = SUBTOTAL * 0.18
        TOTAL = SUBTOTAL + IGV
        e.Graphics.DrawString(simbolo + SUBTOTAL.ToString("0.00", CultureInfo.InvariantCulture), FONT, Brushes.Black, 670, 1050)
        e.Graphics.DrawString("18", FONT, Brushes.Black, 635, 1080)
        e.Graphics.DrawString(simbolo + IGV.ToString("0.00", CultureInfo.InvariantCulture), FONT, Brushes.Black, 670, 1080)
        e.Graphics.DrawString(simbolo + TOTAL.ToString("0.00", CultureInfo.InvariantCulture), FONT, Brushes.Black, 670, 1110)
        e.Graphics.DrawString(NUMBERF.DecimalLetras(TOTAL.ToString("0.00", CultureInfo.InvariantCulture)) + " " + moneda, FONT, Brushes.Black, 60, 1045)

    End Sub

    Private Sub printMULTILINES(ByVal imprTEXT As String, ByVal FONT As Font, e As Printing.PrintPageEventArgs, salto As Integer)
        If (imprTEXT <> "") Then
            Dim contc As Integer = 50
            Dim pala As String = ""
            Dim contp As Integer = 0
            Dim pal(150) As String
            Dim lineas As Integer = 1
            For i = 1 To imprTEXT.Length
                If Mid(imprTEXT, i, 1) <> " " Then
                    pal(contp) = pal(contp) + Mid(imprTEXT, i, 1)
                Else
                    contp = contp + 1
                End If
            Next
            For i = 0 To contp
                If Len(pala + pal(i)) <= contc Then
                    If pala <> "" Then
                        pala = pala + " " + pal(i)
                    Else
                        pala = pala + pal(i)
                    End If
                Else
                    lineas = lineas + 1
                    pala = pala + vbLf + pal(i)
                    contc = (lineas * 50)
                End If
            Next
            e.Graphics.DrawString(pala, FONT, Brushes.Black, 90, cordy)
            cordy = cordy + (salto * lineas) + 2
        End If
    End Sub
    Private WithEvents docToPrint As New Printing.PrintDocument
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'PUNTEROIMPR = 0
        'PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
        'If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        '    PrintDocument1.Print()
        'End If


        'Me.PrintPreviewControl1 = New PrintPreviewControl

        ' Set location, name, and dock style for PrintPreviewControl1.
        'Me.PrintPreviewControl1.Location = New Point(88, 150)

        'PrintDocument1.DefaultPageSettings.PaperSize = New PaperSize("Custom", 827, 1210)
        'Me.PrintPreviewControl1.Name = "PrintPreviewControl1"
        'Me.PrintPreviewControl1.Dock = DockStyle.Fill

        ' Set the Document property to the PrintDocument 
        ' For which the PrintPage event has been handled.
        'Me.PrintPreviewControl1.Document = PrintDocument1

        ' Set the zoom to 25 percent.
        'Me.PrintPreviewControl1.Zoom = 1

        ' Set the document name. This will show be displayed when 
        ' the document Is loading into the control.
        'Me.PrintPreviewControl1.Document.DocumentName = "c:\athmsg.log"

        ' Set the UseAntiAlias property to true so fonts are smoothed
        ' by the operating system.
        'Me.PrintPreviewControl1.UseAntiAlias = True

        '    Add the control to the form.
        'Me.Controls.Add(Me.PrintPreviewControl1)
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            PrintDocument1.Print()
        End If
    End Sub
End Class