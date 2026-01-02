<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsulta2
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
        Label1 = New Label()
        cbbFiltro = New ComboBox()
        txtFiltro = New TextBox()
        grd = New DataGridView()
        bind = New BindingSource(components)
        CType(grd, ComponentModel.ISupportInitialize).BeginInit()
        CType(bind, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = Color.Red
        Label1.Location = New Point(9, 6)
        Label1.Name = "Label1"
        Label1.Size = New Size(91, 15)
        Label1.TabIndex = 0
        Label1.Text = "Control de filtro"
        ' 
        ' cbbFiltro
        ' 
        cbbFiltro.DropDownStyle = ComboBoxStyle.DropDownList
        cbbFiltro.FormattingEnabled = True
        cbbFiltro.Location = New Point(12, 24)
        cbbFiltro.Name = "cbbFiltro"
        cbbFiltro.Size = New Size(148, 23)
        cbbFiltro.TabIndex = 2
        ' 
        ' txtFiltro
        ' 
        txtFiltro.Location = New Point(166, 24)
        txtFiltro.Name = "txtFiltro"
        txtFiltro.Size = New Size(297, 23)
        txtFiltro.TabIndex = 3
        ' 
        ' grd
        ' 
        grd.AllowUserToAddRows = False
        grd.AllowUserToDeleteRows = False
        grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        grd.Location = New Point(9, 53)
        grd.Name = "grd"
        grd.ReadOnly = True
        grd.Size = New Size(454, 186)
        grd.TabIndex = 1
        ' 
        ' FrmConsulta2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(475, 251)
        Controls.Add(grd)
        Controls.Add(txtFiltro)
        Controls.Add(cbbFiltro)
        Controls.Add(Label1)
        Name = "FrmConsulta2"
        Padding = New Padding(0, 0, 10, 0)
        StartPosition = FormStartPosition.CenterScreen
        CType(grd, ComponentModel.ISupportInitialize).EndInit()
        CType(bind, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cbbFiltro As ComboBox
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents grd As DataGridView
    Friend WithEvents bind As BindingSource
End Class
