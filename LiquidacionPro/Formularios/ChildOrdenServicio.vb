Imports System.Data.SqlClient

Public Class ChildOrdenServicio
    Dim columnaFiltro As Integer = -1
    Dim source1 As New BindingSource()
    Dim nombreColumnaFiltro As String
    Private Sub btnAgregarDetalle_Click(sender As Object, e As EventArgs) Handles btnAgregarDetalle.Click
        'dgvDetalleOrdenServicio.ColumnCount = 3
        'dgvDetalleOrdenServicio.Columns(0).Name = "Product ID"
        'dgvDetalleOrdenServicio.Columns(1).Name = "Product Name"
        'dgvDetalleOrdenServicio.Columns(2).Name = "Product_Price"

        'Dim row As String() = New String() {"1", "Product 1", "1000"}
        'dgvDetalleOrdenServicio.Rows.Add(row)
        'row = New String() {"2", "Product 2", "2000"}
        'dgvDetalleOrdenServicio.Rows.Add(row)
        'row = New String() {"3", "Product 3", "3000"}
        'dgvDetalleOrdenServicio.Rows.Add(row)
        'row = New String() {"4", "Product 4", "4000"}
        'dgvDetalleOrdenServicio.Rows.Add(row)
    End Sub


    Private Sub ChildOrdenServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarGuias()
    End Sub

    Sub cargarGuias()
        Dim sqlControl As New SQLControl
        sqlControl.SetConnection()

        Dim ordenServicioDAO As New OrdenServicioDAO(sqlControl)
        Try
            sqlControl.OpenConexion()
            sqlControl.BeginTransaction()
            ordenServicioDAO.setDBcmd()

            Dim dt As DataTable

            dt = ordenServicioDAO.GetAllOrdenServicio
            sqlControl.CommitTransaction()

            'Se salva el filtro previo
            Dim filtro As String = source1.Filter

            dgvOrdenServicio.DataSource = dt

            'dgvGuias.Columns(0).Width = 55
            'dgvGuias.Columns(1).Width = 75
            'dgvGuias.Columns(5).Width = 75
            'dgvGuias.Columns(6).Width = 70
            'dgvGuias.Columns(8).Width = 60
            'dgvGuias.Columns(10).Width = 60
            'dgvGuias.Columns(12).Width = 220
            'dgvGuias.Columns(13).Width = 80
            'dgvGuias.Columns(14).Width = 80
            'dgvGuias.Columns(15).Width = 80
            'dgvGuias.Columns(17).Width = 220
            'dgvGuias.Columns(18).Width = 80
            'dgvGuias.Columns(19).Width = 80

            'dgvGuias.Columns(2).Visible = False
            'dgvGuias.Columns(3).Visible = False
            'dgvGuias.Columns(4).Visible = False
            'dgvGuias.Columns(7).Visible = False
            'dgvGuias.Columns(9).Visible = False
            'dgvGuias.Columns(11).Visible = False
            'dgvGuias.Columns(16).Visible = False

            dgvOrdenServicio.Columns(1).DefaultCellStyle.Format = "dd/MM/yyyy"

            If filtro <> Nothing Then
                source1.DataSource = dgvOrdenServicio.DataSource
                source1.Filter = filtro
                dgvOrdenServicio.Refresh()
            End If

            If txtCodigo.Text <> Nothing Then
                Dim rowIndex As Integer = -1
                For Each row As DataGridViewRow In dgvOrdenServicio.Rows
                    If row.Cells(0).Value.ToString().Equals(txtCodigo.Text) Then
                        rowIndex = row.Index
                        Exit For
                    End If
                Next

                If rowIndex <> -1 Then
                    dgvOrdenServicio.CurrentCell = dgvOrdenServicio.Item(0, rowIndex)
                End If

            End If

        Catch ex As SqlException
            sqlControl.RollbackTransaccion()
            MessageBox.Show("Error al cargar Órdenes de Servicio. SQL. " + ex.Message, "Cargar Órdenes de Servicio",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al cargar Órdenes de Servicio. " + ex.Message, "Cargar Órdenes de Servicio",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
        Finally
            Try
                sqlControl.CloseConexion()
            Catch ex As Exception

            End Try
        End Try
    End Sub
End Class