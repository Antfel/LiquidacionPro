﻿Imports Microsoft.Reporting.WinForms

Public Class RptFormLiquidacionViaje
    Dim codigo As Integer
    Private Sub RptFormLiquidacionViaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cargarReporteGeneral()
    End Sub

    Public Sub setCodigo(codigo As Integer)
        Me.codigo = codigo
    End Sub
    Function getiquidacionGeneral(codigo As Integer) As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.setConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            dt = liquidacionDAO.getRptLiquidacionGeneral(codigo)
            sqlControl.commitTransaction()
            Return dt
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("No se pudo cargar la liquidación. " + ex.Message, "Cargar Liquidación",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error)
            Return dt
        Finally

            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("No se pudo cerrar la conexión. " + ex.Message, "Cargar Liquidación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try


        End Try

    End Function

    Function getiquidacionPeaje(codigo As Integer) As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.setConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            dt = liquidacionDAO.getRptLiquidacionViajePeaje(codigo)
            sqlControl.commitTransaction()
            Return dt
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("No se pudo cargar la liquidación detalle. " + ex.Message, "Cargar Liquidación",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error)
            Return dt
        Finally

            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("No se pudo cerrar la conexión. " + ex.Message, "Cargar Liquidación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try


        End Try

    End Function

    Function getiquidacionViatico(codigo As Integer) As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.setConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            dt = liquidacionDAO.getRptLiquidacionViajeViatico(codigo)
            sqlControl.commitTransaction()
            Return dt
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("No se pudo cargar la liquidación detalle. " + ex.Message, "Cargar Liquidación",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error)
            Return dt
        Finally

            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("No se pudo cerrar la conexión. " + ex.Message, "Cargar Liquidación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try


        End Try

    End Function

    Function getiquidacionOtro(codigo As Integer) As DataTable
        Dim sqlControl As New SQLControl
        Dim dt As DataTable
        sqlControl.setConnection()

        Dim liquidacionDAO As New LiquidacionDAO(sqlControl)

        dt = Nothing
        Try
            sqlControl.openConexion()
            sqlControl.beginTransaction()
            liquidacionDAO.setDBcmd()

            dt = liquidacionDAO.getRptLiquidacionViajeOtro(codigo)
            sqlControl.commitTransaction()
            Return dt
        Catch ex As Exception
            sqlControl.rollbackTransaccion()
            MessageBox.Show("No se pudo cargar la liquidación detalle. " + ex.Message, "Cargar Liquidación",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error)
            Return dt
        Finally

            Try
                sqlControl.closeConexion()
            Catch ex As Exception
                MessageBox.Show("No se pudo cerrar la conexión. " + ex.Message, "Cargar Liquidación",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error)
            End Try


        End Try

    End Function

    Sub cargarReporteGeneral()

        Dim dt As DataTable = getiquidacionGeneral(codigo)
        'ReportViewer1.Reset()
        'ReportViewer1.ProcessingMode = ProcessingMode.Local
        'ReportViewer1.LocalReport.ReportPath = "C:\Users\rasec\source\repos\LiquidacionPro\LiquidacionPro\Formularios\Reportes\RptLiquidacionGeneral.rdlc"
        'Dim rds As New ReportDataSource("DataSet1", dt)
        'ReportViewer1.LocalReport.DataSources.Clear()
        'ReportViewer1.LocalReport.DataSources.Add(rds)
        ''ReportViewer1.LocalReport.Refresh()
        'ReportViewer1.Refresh()



        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "Formularios/Reportes/RptLiquidacionViajeCabecera.rdlc"
        'Dim rds As New ReportDataSource
        'rds.Name = "DataSet1"
        'rds.Value = dt
        Dim rds As New ReportDataSource("DataSet1", dt)
        ReportViewer1.LocalReport.DataSources.Add(rds)
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf subReporteViajeViatico
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf subReporteViajePeaje
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf subReporteViajeOtro
        ReportViewer1.RefreshReport()
    End Sub

    Public Sub subReporteViajePeaje(ByVal sender As Object,
     ByVal e As SubreportProcessingEventArgs)

        Dim codigo As Integer = CInt(e.Parameters("CodigoLiquidacion").Values(0).ToString)
        Dim dt As New DataTable
        dt = getiquidacionPeaje(codigo)
        Dim rds As New ReportDataSource("DataSet1", dt)
        e.DataSources.Add(rds)

    End Sub

    Public Sub subReporteViajeViatico(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)

        Dim codigo As Integer = CInt(e.Parameters("CodigoLiquidacion").Values(0).ToString)
        Dim dt As New DataTable
        dt = getiquidacionViatico(codigo)
        Dim rds As New ReportDataSource("DataSet1_Viatico", dt)
        e.DataSources.Add(rds)

    End Sub

    Public Sub subReporteViajeOtro(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)

        Dim codigo As Integer = CInt(e.Parameters("CodigoLiquidacion").Values(0).ToString)
        Dim dt As New DataTable
        dt = getiquidacionOtro(codigo)
        Dim rds As New ReportDataSource("DataSet1_Otro", dt)
        e.DataSources.Add(rds)

    End Sub
End Class