Imports System.Data.SqlClient
Public Class ChildBusquedaAsignaciones
    Dim columnaFiltro As Integer = -1
    Dim source1 As New BindingSource()
    Dim nombreColumnaFiltro As String
    Dim codigoOrden As Integer
    Dim codigoAsignacion As Integer
    Private Sub ChildBusquedaAsignaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargandoAsignaciones()
    End Sub
    Public Sub CargandoAsignaciones()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim asignacionDao As New AsignacionServicioDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            asignacionDao.setDBcmd()

            Dim dtAsignaciones As DataTable

            dtAsignaciones = asignacionDao.GetAllAsignaciones()
            sqlControl.CommitTransaction()

            dgvAsignaciones.DataSource = dtAsignaciones

            dgvAsignaciones.Columns(0).Visible = False
            dgvAsignaciones.Columns(1).Visible = False

            dgvAsignaciones.Columns(2).Width = 120
            dgvAsignaciones.Columns(3).Width = 250
            dgvAsignaciones.Columns(4).Width = 70
            dgvAsignaciones.Columns(5).Width = 70
            dgvAsignaciones.Columns(6).Width = 80
            dgvAsignaciones.Columns(7).Width = 80
            dgvAsignaciones.Columns(8).Width = 250
            dgvAsignaciones.Columns(9).Width = 80

            ''dgvFacturas.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar lista de asignaciones. ", "Cargar lista de asignaciones",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar lista de asignaciones. ", "Cargar lista de asignaciones",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. ", "Cargar lista de asigaciones",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try

    End Sub

    Private Sub BtnVer_Click(sender As Object, e As EventArgs) Handles BtnVer.Click
        Dim seleccion As DataGridViewRow = dgvAsignaciones.SelectedRows(0)
        Dim codigo As Integer = seleccion.Cells(1).Value

        Dim childAsignacionServicio As New ChildAsignacionServicio
        childAsignacionServicio.MdiParent = Me.MdiParent
        childAsignacionServicio.cargarCodigoAsignacion(codigo)
        childAsignacionServicio.cargarTipo(0)
        childAsignacionServicio.cargarChildBusquedaAsignaciones(Me)
        childAsignacionServicio.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim childAsignacionServicio As New ChildAsignacionServicio
        childAsignacionServicio.MdiParent = Me.MdiParent
        childAsignacionServicio.cargarTipo(1)
        childAsignacionServicio.cargarChildBusquedaAsignaciones(Me)
        childAsignacionServicio.Show()
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        If columnaFiltro = -1 Then
            MessageBox.Show("Debe seleccionar una columna. ", "Filtrar",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation)
            Return
        End If
        source1.DataSource = dgvAsignaciones.DataSource

        Dim tipo As Type = dgvAsignaciones.Columns(columnaFiltro).ValueType

        Select Case tipo.ToString
            Case "System.Decimal", "System.Int32"
                source1.Filter = "[" & nombreColumnaFiltro & "] " & txtFiltro.Text & ""
            Case "System.String"
                source1.Filter = "[" & nombreColumnaFiltro & "] like '%" & txtFiltro.Text & "%'"
        End Select

        dgvAsignaciones.Refresh()
    End Sub

    Private Sub btnDeshacer_Click(sender As Object, e As EventArgs) Handles btnDeshacer.Click
        source1.DataSource = dgvAsignaciones.DataSource
        source1.RemoveFilter()
        dgvAsignaciones.Refresh()
        txtFiltro.Text = ""
    End Sub

    Private Sub dgvAsignaciones_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAsignaciones.ColumnHeaderMouseClick
        columnaFiltro = e.ColumnIndex
        nombreColumnaFiltro = dgvAsignaciones.Columns(columnaFiltro).Name
        lblFiltro.Text = nombreColumnaFiltro
    End Sub
End Class