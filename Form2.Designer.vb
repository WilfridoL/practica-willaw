<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCategoria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCategoria))
        ToolStrip1 = New ToolStrip()
        btnAdd = New ToolStripButton()
        ToolStripButton3 = New ToolStripButton()
        btnBuscar = New ToolStripButton()
        btnUpd = New ToolStripButton()
        btnDel = New ToolStripButton()
        ToolStripButton2 = New ToolStripButton()
        txtNom = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        txtId = New TextBox()
        Label3 = New Label()
        ToolStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Items.AddRange(New ToolStripItem() {btnAdd, ToolStripButton3, btnBuscar, btnUpd, btnDel, ToolStripButton2})
        resources.ApplyResources(ToolStrip1, "ToolStrip1")
        ToolStrip1.Name = "ToolStrip1"
        ' 
        ' btnAdd
        ' 
        btnAdd.DisplayStyle = ToolStripItemDisplayStyle.Image
        resources.ApplyResources(btnAdd, "btnAdd")
        btnAdd.Name = "btnAdd"
        ' 
        ' ToolStripButton3
        ' 
        ToolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image
        resources.ApplyResources(ToolStripButton3, "ToolStripButton3")
        ToolStripButton3.Name = "ToolStripButton3"
        ' 
        ' btnBuscar
        ' 
        btnBuscar.DisplayStyle = ToolStripItemDisplayStyle.Image
        resources.ApplyResources(btnBuscar, "btnBuscar")
        btnBuscar.Name = "btnBuscar"
        ' 
        ' btnUpd
        ' 
        btnUpd.DisplayStyle = ToolStripItemDisplayStyle.Image
        resources.ApplyResources(btnUpd, "btnUpd")
        btnUpd.Name = "btnUpd"
        ' 
        ' btnDel
        ' 
        btnDel.DisplayStyle = ToolStripItemDisplayStyle.Image
        resources.ApplyResources(btnDel, "btnDel")
        btnDel.Name = "btnDel"
        ' 
        ' ToolStripButton2
        ' 
        ToolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image
        resources.ApplyResources(ToolStripButton2, "ToolStripButton2")
        ToolStripButton2.Name = "ToolStripButton2"
        ' 
        ' txtNom
        ' 
        resources.ApplyResources(txtNom, "txtNom")
        txtNom.Name = "txtNom"
        ' 
        ' Label2
        ' 
        resources.ApplyResources(Label2, "Label2")
        Label2.ForeColor = SystemColors.Desktop
        Label2.Name = "Label2"
        ' 
        ' Label1
        ' 
        resources.ApplyResources(Label1, "Label1")
        Label1.ForeColor = SystemColors.Desktop
        Label1.Name = "Label1"
        ' 
        ' txtId
        ' 
        resources.ApplyResources(txtId, "txtId")
        txtId.Name = "txtId"
        txtId.ReadOnly = True
        ' 
        ' Label3
        ' 
        resources.ApplyResources(Label3, "Label3")
        Label3.Name = "Label3"
        ' 
        ' FrmCategoria
        ' 
        resources.ApplyResources(Me, "$this")
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(txtId)
        Controls.Add(txtNom)
        Controls.Add(Label1)
        Controls.Add(ToolStrip1)
        Name = "FrmCategoria"
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnAdd As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents btnBuscar As ToolStripButton
    Friend WithEvents btnUpd As ToolStripButton
    Friend WithEvents btnDel As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents txtNom As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents Label3 As Label
End Class
