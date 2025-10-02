<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsulta
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        ToolTip = New ToolTip(components)
        BaseDatosBindingSource = New BindingSource(components)
        DgvConsulta = New DataGridView()
        CType(BaseDatosBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(DgvConsulta, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BaseDatosBindingSource
        ' 
        BaseDatosBindingSource.DataSource = GetType(BaseDatos)
        ' 
        ' DgvConsulta
        ' 
        DgvConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvConsulta.Location = New Point(1, 2)
        DgvConsulta.Name = "DgvConsulta"
        DgvConsulta.Size = New Size(741, 295)
        DgvConsulta.TabIndex = 11
        ' 
        ' frmConsulta
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(742, 297)
        Controls.Add(DgvConsulta)
        IsMdiContainer = True
        Margin = New Padding(4, 3, 4, 3)
        Name = "frmConsulta"
        Text = "Inicio"
        CType(BaseDatosBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(DgvConsulta, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents BaseDatosBindingSource As BindingSource
    Friend WithEvents DgvConsulta As DataGridView

End Class
