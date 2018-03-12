Imports System.Data.SqlClient
Public Class ChildAsignacionServicio
    Dim columnaFiltro As Integer = -1
    Dim source1 As New BindingSource()
    Dim nombreColumnaFiltro As String
    Dim codigoOrden As Integer
    Dim codigoAsignacion As Integer = -1
    Dim childBusquedaAsignaciones As ChildBusquedaAsignaciones

    ''si es 0 es modificacion, 1 asignacion nueva
    Dim tipoCarga As Integer

    Private Sub ChildAsignacionServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        actualizarDatosSemiTrailer()
        actualizarDatosTrabajador()
        actualizarDatosTracto()
        actualizarEstados()
        cargarAsignacionesPendientes()
        cargarDatosAsignacion()
        ocultarPendientes()



    End Sub
    Public Sub cargarAsignacionesPendientes()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim asignacionDao As New AsignacionServicioDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            asignacionDao.setDBcmd()

            Dim dtAsignacionesPendientes As DataTable

            dtAsignacionesPendientes = asignacionDao.getAsignacionesPedientes()
            sqlControl.CommitTransaction()

            dgvPendientes.DataSource = dtAsignacionesPendientes

            dgvPendientes.Columns(0).Visible = False

            dgvPendientes.Columns(1).Width = 80
            dgvPendientes.Columns(2).Width = 135
            dgvPendientes.Columns(3).Width = 71

            ''dgvFacturas.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar lista de asignaciones pendientes. ", "Cargar lista de asignaciones pendientes",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar lista de asignaciones pendientes. ", "Cargar lista de asignaciones pendientes",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. ", "Cargar lista de asigaciones pendientes",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Public Sub cargarDatosAsignacion()

        If codigoAsignacion <> -1 Then

            Dim sqlControl As New SQLControl
            sqlControl.SetConnection()

            Dim asignacionServicioDao As New AsignacionServicioDAO(sqlControl)
            Try
                sqlControl.OpenConexion()
                sqlControl.BeginTransaction()
                asignacionServicioDao.setDBcmd()

                Dim dt As DataTable
                dt = asignacionServicioDao.GetAsignacionesCodigo(codigoAsignacion)
                sqlControl.CommitTransaction()

                txtOrdenServicio.Text = dt.Rows(0)(4)
                txtObservacion.Text = dt.Rows(0)(2)
                cbEstado.SelectedValue = dt.Rows(0)(3)
                dtFechaAsignacion.Value = dt.Rows(0)(1)
                txtOrigen.Text = dt.Rows(0)(5)
                txtDestino.Text = dt.Rows(0)(6)
                codigoOrden = dt.Rows(0)(0)


            Catch ex As Exception
                sqlControl.RollbackTransaccion()
            Finally
                Try
                    sqlControl.CloseConexion()
                    actualizaDetalleOrden()
                    cargarDetalleAsignacion(codigoAsignacion)
                Catch ex As Exception

                End Try
            End Try
        End If

    End Sub
    Private Sub actualizarDatosTrabajador()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim trabajadorDao As New TrabajadorDAO(sqlControl)
        Try

            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            trabajadorDao.setDBcmd()

            Dim dtTrabajador As DataTable

            dtTrabajador = trabajadorDao.GetConductor

            sqlControl.CommitTransaction()

            With cbTrabajador
                .DataSource = dtTrabajador
                .DisplayMember = "NOMBRE_TRABAJADOR"
                .ValueMember = "CODIGO_TRABAJADOR"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception

            End Try
        End Try
    End Sub

    Private Sub actualizarDatosSemiTrailer()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim unidadDao As New UnidadDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            unidadDao.setDBcmd()

            Dim dtUnidad As DataTable

            dtUnidad = unidadDao.getUnidadSemiTrailer

            sqlControl.CommitTransaction()

            With cbCarreta
                .DataSource = dtUnidad
                .DisplayMember = "PLACA_UNIDAD"
                .ValueMember = "CODIGO_UNIDAD"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception

            End Try
        End Try

    End Sub
    Private Sub actualizarEstados()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim estadoDao As New EstadoDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            estadoDao.setDBcmd()

            Dim dtEstado As DataTable

            dtEstado = estadoDao.getEstadoAsignacion

            sqlControl.CommitTransaction()

            With cbEstado
                .DataSource = dtEstado
                .DisplayMember = "DETALLE_ESTADO"
                .ValueMember = "CODIGO_ESTADO"
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedValue = 1
            End With
        Catch ex As Exception
            sqlControl.RollbackTransaccion()
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception

            End Try
        End Try

    End Sub
    Public Sub actualizaDetalleOrden()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim ordenServicioDao As New OrdenServicioDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            ordenServicioDao.setDBcmd()

            Dim dtDetalleOrden As DataTable
            dtDetalleOrden = ordenServicioDao.getDetalleOrdenServicios(codigoOrden)

            sqlControl.CommitTransaction()

            With cbDetalleOrden
                .DataSource = dtDetalleOrden
                .DisplayMember = "DETALLE_ESTADO"
                .ValueMember = "CODIGO_ORDEN_SERVICIO_DETALLE"
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With
            'cbDetalleOrden.SelectedIndex = -1
        Catch ex As SQLException
            sqlControl.RollbackTransaccion()
        Catch ex As Exception

        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception

            End Try
        End Try


    End Sub
    Private Sub actualizarDatosTracto()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim unidadDao As New UnidadDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            unidadDao.setDBcmd()

            Dim dtUnidad As DataTable

            dtUnidad = unidadDao.getUnidadTractos()
            sqlControl.CommitTransaction()

            With cbUnidad
                .DataSource = dtUnidad
                .DisplayMember = "PLACA_UNIDAD"
                .ValueMember = "CODIGO_UNIDAD"
                .DropDownStyle = ComboBoxStyle.Simple
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedIndex = -1
            End With

        Catch ex As Exception
            sqlControl.RollbackTransaccion()
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception

            End Try
        End Try


    End Sub

    Private Sub dgvAsignaciones_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim asignacionServicioDao As New AsignacionServicioDAO(sqlControl)

        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            asignacionServicioDao.setDBcmd()



            Dim dt As DataTable
            dt = asignacionServicioDao.GetAsignacionesCodigo(codigoAsignacion)
            sqlControl.CommitTransaction()

            txtOrdenServicio.Text = dt.Rows(0)(4)
            txtObservacion.Text = dt.Rows(0)(2)
            cbEstado.SelectedValue = dt.Rows(0)(3)
            dtFechaAsignacion.Value = dt.Rows(0)(1)
            txtOrigen.Text = dt.Rows(0)(5)
            txtDestino.Text = dt.Rows(0)(6)
            codigoOrden = dt.Rows(0)(0)


        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
        Catch ex As Exception

        Finally
            Try
                sqlControl.CloseConexion()
                actualizaDetalleOrden()
                cargarDetalleAsignacion(codigoAsignacion)
            Catch ex As Exception

            End Try
        End Try

    End Sub

    Private Sub cbDetalleOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDetalleOrden.SelectedIndexChanged
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim ordenServicioDao As New OrdenServicioDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            ordenServicioDao.setDBcmd()

            Dim dtDetalleOrden As DataTable
            dtDetalleOrden = ordenServicioDao.getDatosDetalleOrden(cbDetalleOrden.SelectedValue)

            sqlControl.CommitTransaction()

            txtTipoServicio.Text = dtDetalleOrden.Rows(0)(0)
            txtAlto.Text = dtDetalleOrden.Rows(0)(1)
            txtAncho.Text = dtDetalleOrden.Rows(0)(2)
            txtLargo.Text = dtDetalleOrden.Rows(0)(3)
            txtPeso.Text = dtDetalleOrden.Rows(0)(4)
            ObservaCarga.Text = dtDetalleOrden.Rows(0)(5)

        Catch ex As Exception
            sqlControl.RollbackTransaccion()

        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception

            End Try
        End Try
    End Sub

    Private Sub dgvPendientes_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvPendientes.CellMouseClick
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim asignacionServicioDao As New AsignacionServicioDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            asignacionServicioDao.setDBcmd()

            Dim seleccion As DataGridViewRow = dgvPendientes.SelectedRows(0)
            codigoAsignacion = seleccion.Cells(0).Value

            Dim dt As DataTable
            dt = asignacionServicioDao.GetAsignacionesCodigo(codigoAsignacion)
            sqlControl.CommitTransaction()

            txtOrdenServicio.Text = dt.Rows(0)(4)
            txtObservacion.Text = dt.Rows(0)(2)
            cbEstado.SelectedValue = dt.Rows(0)(3)
            dtFechaAsignacion.Value = dt.Rows(0)(1)
            txtOrigen.Text = dt.Rows(0)(5)
            txtDestino.Text = dt.Rows(0)(6)
            codigoOrden = dt.Rows(0)(0)



        Catch ex As Exception
            sqlControl.RollbackTransaccion()
        Finally
            Try
                sqlControl.CloseConexion()
                actualizaDetalleOrden()
                cargarDetalleAsignacion(codigoAsignacion)
            Catch ex As Exception

            End Try
        End Try



    End Sub

    Private Sub cargarDetalleAsignacion(codigoAsignacion As Integer)
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim asignacionDetalleDao As New AsignacionServicioDetalleDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            asignacionDetalleDao.setDBcmd()

            Dim dtAsignacionesDetalle As DataTable

            dtAsignacionesDetalle = asignacionDetalleDao.getDetalleAsignacion(codigoAsignacion)
            sqlControl.CommitTransaction()

            dgvDetalleAsignacion.DataSource = dtAsignacionesDetalle

            dgvDetalleAsignacion.Columns(0).Visible = False

            dgvDetalleAsignacion.Columns(2).Width = 120
            dgvDetalleAsignacion.Columns(2).Width = 120
            dgvDetalleAsignacion.Columns(3).Width = 120
            dgvDetalleAsignacion.Columns(4).Width = 250

            ''dgvFacturas.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar lista de asignaciones. ", "Cargar lista de detalle de asignacion",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar lista de asignaciones. ", "Cargar lista de detalle de asignacion",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception
                MessageBox.Show("Error al cerrar conexión. ", "Cargar lista de detalle de asigacion",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            End Try
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If codigoAsignacion = -1 Then
            MsgBox("Debe serleccionar una orden de servicio.")
        Else

            Dim sqlControl As New SQLControl
            sqlControl.SetConnection()

            Dim asignacionServicioDao As New AsignacionServicioDAO(sqlControl)

            Try
                sqlControl.OpenConexion()
                sqlControl.BeginTransaction()
                asignacionServicioDao.setDBcmd()

                asignacionServicioDao.updateAsignacionServicio(codigoAsignacion, dtFechaAsignacion.Value, txtObservacion.Text, cbEstado.SelectedValue, codigoOrden)

                sqlControl.CommitTransaction()

            Catch ex As SqlException
                sqlControl.RollbackTransaccion()
            Catch ex As Exception

            Finally
                Try
                    sqlControl.CloseConexion()
                Catch ex As Exception

                End Try
            End Try

            cargarAsignacionesPendientes()
            childBusquedaAsignaciones.CargandoAsignaciones()
            cargarDetalleAsignacion(codigoAsignacion)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If codigoAsignacion = -1 Then
            MsgBox("Debe serleccionar una orden de servicio.")
        Else
            If cbUnidad.SelectedIndex = -1 Or cbCarreta.SelectedIndex = -1 Or cbTrabajador.SelectedIndex = -1 Then
                MsgBox("Ingrese todos los datos para poder agregar una asignación.")
            Else
                Dim sqlControl As New SQLControl
                sqlControl.SetConnection()

                Dim asignacionServicioDetalleDao As New AsignacionServicioDetalleDAO(sqlControl)

                Try
                    sqlControl.OpenConexion()
                    sqlControl.BeginTransaction()
                    asignacionServicioDetalleDao.setDBcmd()

                    asignacionServicioDetalleDao.InsertAsignacionServicioDetalle(codigoAsignacion, cbUnidad.SelectedValue, cbCarreta.SelectedValue, cbTrabajador.SelectedValue, cbDetalleOrden.SelectedValue)

                    sqlControl.CommitTransaction()

                    cbUnidad.SelectedIndex = -1
                    cbCarreta.SelectedIndex = -1
                    cbTrabajador.SelectedIndex = -1
                    cbDetalleOrden.SelectedIndex = -1

                Catch ex As SqlException
                    sqlControl.RollbackTransaccion()
                Catch ex As Exception

                Finally
                    Try
                        sqlControl.CloseConexion()
                    Catch ex As Exception

                    End Try
                End Try

                cargarAsignacionesPendientes()
                childBusquedaAsignaciones.CargandoAsignaciones()
                cargarDetalleAsignacion(codigoAsignacion)

            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If codigoAsignacion = -1 Then
            MsgBox("Debe serleccionar una orden de servicio.")
        Else
            If dgvDetalleAsignacion.Rows.Count = 0 Then
                MsgBox("No hay registros para borrar.")
            Else
                If MessageBox.Show("¿Estas Seguro que deseas eliminar a " + dgvDetalleAsignacion.SelectedRows(0).Cells(4).Value + "?", "Eliminando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                    Dim sqlControl As New SQLControl
                    sqlControl.SetConnection()

                    Dim asignacionServicioDetalleDao As New AsignacionServicioDetalleDAO(sqlControl)

                    Try
                        sqlControl.OpenConexion()
                        sqlControl.BeginTransaction()
                        asignacionServicioDetalleDao.setDBcmd()

                        asignacionServicioDetalleDao.deteleAsignacionServicioDetalle(CType(dgvDetalleAsignacion.SelectedRows(0).Cells(0).Value, Integer))

                        sqlControl.CommitTransaction()

                    Catch ex As SqlException
                        sqlControl.RollbackTransaccion()
                    Catch ex As Exception

                    Finally
                        Try
                            sqlControl.CloseConexion()
                        Catch ex As Exception

                        End Try
                    End Try

                    cargarAsignacionesPendientes()
                    childBusquedaAsignaciones.CargandoAsignaciones()
                    cargarDetalleAsignacion(codigoAsignacion)
                End If
            End If
        End If
    End Sub

    Public Sub cargarCodigoAsignacion(codigo_Asignacion As Integer)
        codigoAsignacion = codigo_Asignacion
    End Sub

    Public Sub cargarChildBusquedaAsignaciones(childBusquedaAsig As ChildBusquedaAsignaciones)
        childBusquedaAsignaciones = childBusquedaAsig
    End Sub

    Public Sub cargarTipo(tipo As Integer)
        tipoCarga = tipo
    End Sub

    Public Sub ocultarPendientes()
        If tipoCarga = 0 Then

            lbTItuloPendientes.Visible = False
            dgvPendientes.Visible = False

        Else

            lbTItuloPendientes.Visible = True
            dgvPendientes.Visible = True

        End If

    End Sub

End Class