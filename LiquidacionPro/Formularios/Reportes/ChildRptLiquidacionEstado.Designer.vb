<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChildRptLiquidacionEstado
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbEstadoRpt = New System.Windows.Forms.ComboBox()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.rptLiquidaciones = New LiquidacionPro.rptLiquidaciones()
        Me.dtLiquidacionEstadoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtLiquidacionEstadoTableAdapter = New LiquidacionPro.rptLiquidacionesTableAdapters.dtLiquidacionEstadoTableAdapter()
        CType(Me.rptLiquidaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtLiquidacionEstadoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 12)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 13)
        Me.Label21.TabIndex = 49
        Me.Label21.Text = "Estado"
        '
        'cbEstadoRpt
        '
        Me.cbEstadoRpt.FormattingEnabled = True
        Me.cbEstadoRpt.ItemHeight = 13
        Me.cbEstadoRpt.Location = New System.Drawing.Point(90, 12)
        Me.cbEstadoRpt.Name = "cbEstadoRpt"
        Me.cbEstadoRpt.Size = New System.Drawing.Size(107, 21)
        Me.cbEstadoRpt.TabIndex = 48
        '
        'btnVer
        '
        Me.btnVer.Location = New System.Drawing.Point(293, 12)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(75, 23)
        Me.btnVer.TabIndex = 47
        Me.btnVer.Text = "Ver"
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.dtLiquidacionEstadoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "LiquidacionPro.RptLiquidacionesEstado.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 41)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1067, 279)
        Me.ReportViewer1.TabIndex = 50
        '
        'rptLiquidaciones
        '
        Me.rptLiquidaciones.DataSetName = "rptLiquidaciones"
        Me.rptLiquidaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtLiquidacionEstadoBindingSource
        '
        Me.dtLiquidacionEstadoBindingSource.DataMember = "dtLiquidacionEstado"
        Me.dtLiquidacionEstadoBindingSource.DataSource = Me.rptLiquidaciones
        '
        'dtLiquidacionEstadoTableAdapter
        '
        Me.dtLiquidacionEstadoTableAdapter.ClearBeforeFill = True
        '
        'ChildRptLiquidacionEstado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1114, 355)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cbEstadoRpt)
        Me.Controls.Add(Me.btnVer)
        Me.Name = "ChildRptLiquidacionEstado"
        Me.Text = "Reporte de Liquidación por Estado"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.rptLiquidaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtLiquidacionEstadoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label21 As Label
    Friend WithEvents cbEstadoRpt As ComboBox
    Friend WithEvents btnVer As Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtLiquidacionEstadoBindingSource As BindingSource
    Friend WithEvents rptLiquidaciones As rptLiquidaciones
    Friend WithEvents dtLiquidacionEstadoTableAdapter As rptLiquidacionesTableAdapters.dtLiquidacionEstadoTableAdapter
End Class
