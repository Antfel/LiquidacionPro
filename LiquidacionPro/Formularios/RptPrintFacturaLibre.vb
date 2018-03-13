Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Globalization

Public Class RptPrintFacturaLibre

    Dim cordy As Integer
    Dim PUNTEROITEM As Integer = 0
    Dim PUNTERO As Integer = 0
    Dim PUNTEROIMPR As Integer = 0
    Dim nroFactura As Integer

    Public Sub setNroFactura(nroFactura As Integer)
        Me.nroFactura = nroFactura
    End Sub

    Private Sub RptPrintFacturaLibre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()
        Try

            Dim facturacionDao As New FacturacionDAO(SQLControl)

            SQLControl.OpenConexion()
            SQLControl.BeginTransaction()
            facturacionDao.SetDBcmd()

            Dim dtc As DataTable
            dtc = facturacionDao.GetPrintRptFacturaCabecera(nroFactura)

            Dim dtd As DataTable
            dtd = facturacionDao.GetPrintRptFacturaDetalle(nroFactura)

            Dim FONT As New Font("Abadi MT", 10, FontStyle.Regular)
            Dim moneda, simbolo As String
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
                simbolo = "S/ "
                moneda = "SOLES"
            Else
                simbolo = "$ "
                moneda = "DOLARES AMERICANOS"
            End If

            For i As Integer = 0 To dtd.Rows.Count - 1
                If Double.Parse(dtd.Rows.Item(i)(0)) <> 0 Then
                    e.Graphics.DrawString(dtd.Rows.Item(i)(0), FONT, Brushes.Black, 45, cordy)
                End If
                e.Graphics.DrawString(dtd.Rows.Item(i)(17), FONT, Brushes.Black, 90, cordy)
                If dtd.Rows.Item(i)(3) <> 0 Then
                    e.Graphics.DrawString(simbolo + Double.Parse(dtd.Rows.Item(i)(3)).ToString("0.00", CultureInfo.InvariantCulture), FONT, Brushes.Black, 565, cordy)
                    e.Graphics.DrawString(simbolo + (Double.Parse(dtd.Rows.Item(i)(21))).ToString("0.00", CultureInfo.InvariantCulture), FONT, Brushes.Black, 670, cordy)
                End If
                cordy = cordy + (salto * 2)
            Next

            TOTAL = CType(dtc.Rows.Item(0)(5), Double)
            SUBTOTAL = CType(dtc.Rows.Item(0)(7), Double)
            IGV = CType(dtc.Rows.Item(0)(8), Double)

            e.Graphics.DrawString(simbolo + SUBTOTAL.ToString("0.00", CultureInfo.InvariantCulture), FONT, Brushes.Black, 670, 1050)
            e.Graphics.DrawString("18", FONT, Brushes.Black, 635, 1080)
            e.Graphics.DrawString(simbolo + IGV.ToString("0.00", CultureInfo.InvariantCulture), FONT, Brushes.Black, 670, 1080)
            e.Graphics.DrawString(simbolo + TOTAL.ToString("0.00", CultureInfo.InvariantCulture), FONT, Brushes.Black, 670, 1110)
            e.Graphics.DrawString(NUMBERF.DecimalLetras(TOTAL.ToString("0.00", CultureInfo.InvariantCulture)) + " " + moneda, FONT, Brushes.Black, 60, 1045)


        Catch excp As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error en la transacción. " + excp.Message, "Cargar datos factura",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch excp As Exception
            MessageBox.Show("Error en la escritura de datos. " + excp.Message, "Cargar datos factura",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            If sqlControl.GetDBcon.State = ConnectionState.Open Then
                sqlControl.CloseConexion()
            End If
        End Try

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            PrintDocument1.Print()
        End If
    End Sub
End Class