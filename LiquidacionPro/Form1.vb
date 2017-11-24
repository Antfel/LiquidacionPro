Public Class frmLiquidacion
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim liquidacionDao As New LiquidacionDAO

        Dim dt As DataTable

        dt = liquidacionDao.GetAllLiquidacion()
        dgvLiquidacion.DataSource = dt

        actualizarDatosTrabajador()

    End Sub

    Private Sub actualizarDatosTrabajador()
        Dim trabajadorDao As New TrabajadorDAO

        Dim dtTrabajador As DataTable
        Dim acTrabajador As New AutoCompleteStringCollection

        dtTrabajador = trabajadorDao.GetTrabajador()

        'For x As Integer = 0 To dtTrabajador.Rows.Count - 1
        '    acTrabajador.Add(dtTrabajador.Rows(x)(3).ToString.ToUpper + " " +
        '                     dtTrabajador.Rows(x)(1).ToString.ToUpper + " " +
        '                     dtTrabajador.Rows(x)(2).ToString.ToUpper)
        '    MsgBox(dtTrabajador.Rows(x)(3).ToString.ToUpper + " " +
        '                     dtTrabajador.Rows(x)(1).ToString.ToUpper + " " +
        '                     dtTrabajador.Rows(x)(2).ToString.ToUpper)

        'Next

        'txtChofer.AutoCompleteSource = AutoCompleteSource.CustomSource
        'txtChofer.AutoCompleteCustomSource = acTrabajador
        'txtChofer.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        With cbTrabajador
            .DataSource = dtTrabajador
            .ValueMember = "CODIGO_TRABAJADOR"
            .DisplayMember = "NOMBRE_TRABAJADOR"
            .DropDownStyle = ComboBoxStyle.DropDown
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems

        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        MsgBox("Codigo Trabajador: " + cbTrabajador.SelectedValue.ToString)

    End Sub

    'Private Sub actualizarDatosTracto()
    '    Dim unidadDao As New UnidadDAO

    '    Dim dtTracto As DataTable
    '    Dim acTracto As New AutoCompleteStringCollection

    '    dtTracto = unidadDao.GetTrabajador()

    '    For x As Integer = 0 To dtTracto.Rows.Count - 1
    '        acTracto.Add(dtTracto.Rows(x)(3).ToString.ToUpper + " " +
    '                         dtTracto.Rows(x)(1).ToString.ToUpper + " " +
    '                         dtTracto.Rows(x)(2).ToString.ToUpper)
    '        MsgBox(dtTracto.Rows(x)(3).ToString.ToUpper + " " +
    '                         dtTracto.Rows(x)(1).ToString.ToUpper + " " +
    '                         dtTracto.Rows(x)(2).ToString.ToUpper)

    '    Next

    '    txtChofer.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    txtChofer.AutoCompleteCustomSource = acTracto
    '    txtChofer.AutoCompleteMode = AutoCompleteMode.Append
    'End Sub

End Class
