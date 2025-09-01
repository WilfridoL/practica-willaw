<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUsuario))
        txtIdUsu = New TextBox()
        UsernameLabel = New Label()
        txtNomUsu = New TextBox()
        Label1 = New Label()
        txtApeUsu = New TextBox()
        Label2 = New Label()
        txtCorUsu = New TextBox()
        Label3 = New Label()
        Label4 = New Label()
        txtRolUsu = New ComboBox()
        txtObsUsu = New RichTextBox()
        Label5 = New Label()
        Button1 = New Button()
        ToolStrip1 = New ToolStrip()
        ToolStripButton1 = New ToolStripButton()
        ToolStripButton2 = New ToolStripButton()
        ToolStripButton3 = New ToolStripButton()
        ToolStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtIdUsu
        ' 
        txtIdUsu.Location = New Point(114, 50)
        txtIdUsu.Name = "txtIdUsu"
        txtIdUsu.Size = New Size(135, 23)
        txtIdUsu.TabIndex = 13
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        UsernameLabel.ForeColor = SystemColors.Desktop
        UsernameLabel.Location = New Point(12, 50)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(82, 23)
        UsernameLabel.TabIndex = 12
        UsernameLabel.Text = "&Identificacion:"
        UsernameLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtNomUsu
        ' 
        txtNomUsu.Location = New Point(114, 79)
        txtNomUsu.Name = "txtNomUsu"
        txtNomUsu.Size = New Size(220, 23)
        txtNomUsu.TabIndex = 15
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label1.ForeColor = SystemColors.Desktop
        Label1.Location = New Point(12, 79)
        Label1.Name = "Label1"
        Label1.Size = New Size(63, 23)
        Label1.TabIndex = 14
        Label1.Text = "&Nombres"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtApeUsu
        ' 
        txtApeUsu.Location = New Point(114, 108)
        txtApeUsu.Name = "txtApeUsu"
        txtApeUsu.Size = New Size(220, 23)
        txtApeUsu.TabIndex = 17
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.Desktop
        Label2.Location = New Point(12, 108)
        Label2.Name = "Label2"
        Label2.Size = New Size(63, 23)
        Label2.TabIndex = 16
        Label2.Text = "&Apellidos"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtCorUsu
        ' 
        txtCorUsu.Location = New Point(114, 137)
        txtCorUsu.Name = "txtCorUsu"
        txtCorUsu.Size = New Size(220, 23)
        txtCorUsu.TabIndex = 19
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label3.ForeColor = SystemColors.Desktop
        Label3.Location = New Point(12, 137)
        Label3.Name = "Label3"
        Label3.Size = New Size(63, 23)
        Label3.TabIndex = 18
        Label3.Text = "&Correo"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label4
        ' 
        Label4.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label4.ForeColor = SystemColors.Desktop
        Label4.Location = New Point(12, 166)
        Label4.Name = "Label4"
        Label4.Size = New Size(42, 23)
        Label4.TabIndex = 21
        Label4.Text = "&Rol"
        Label4.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtRolUsu
        ' 
        txtRolUsu.FormattingEnabled = True
        txtRolUsu.Location = New Point(114, 166)
        txtRolUsu.Name = "txtRolUsu"
        txtRolUsu.Size = New Size(220, 23)
        txtRolUsu.TabIndex = 20
        ' 
        ' txtObsUsu
        ' 
        txtObsUsu.Location = New Point(114, 195)
        txtObsUsu.Name = "txtObsUsu"
        txtObsUsu.Size = New Size(220, 96)
        txtObsUsu.TabIndex = 22
        txtObsUsu.Text = ""
        ' 
        ' Label5
        ' 
        Label5.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label5.ForeColor = SystemColors.Desktop
        Label5.Location = New Point(12, 195)
        Label5.Name = "Label5"
        Label5.Size = New Size(96, 23)
        Label5.TabIndex = 23
        Label5.Text = "&Observaciones:"
        Label5.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Button1
        ' 
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.Location = New Point(255, 50)
        Button1.Name = "Button1"
        Button1.Size = New Size(26, 23)
        Button1.TabIndex = 25
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Items.AddRange(New ToolStripItem() {ToolStripButton1, ToolStripButton2, ToolStripButton3})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(396, 25)
        ToolStrip1.TabIndex = 26
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), Image)
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Size = New Size(23, 22)
        ToolStripButton1.Text = "ToolStripButton1"
        ' 
        ' ToolStripButton2
        ' 
        ToolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), Image)
        ToolStripButton2.ImageTransparentColor = Color.Magenta
        ToolStripButton2.Name = "ToolStripButton2"
        ToolStripButton2.Size = New Size(23, 22)
        ToolStripButton2.Text = "ToolStripButton2"
        ' 
        ' ToolStripButton3
        ' 
        ToolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), Image)
        ToolStripButton3.ImageTransparentColor = Color.Magenta
        ToolStripButton3.Name = "ToolStripButton3"
        ToolStripButton3.Size = New Size(23, 22)
        ToolStripButton3.Text = "ToolStripButton3"
        ' 
        ' FrmUsuario
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(396, 315)
        Controls.Add(ToolStrip1)
        Controls.Add(Button1)
        Controls.Add(Label5)
        Controls.Add(txtObsUsu)
        Controls.Add(Label4)
        Controls.Add(txtRolUsu)
        Controls.Add(txtCorUsu)
        Controls.Add(Label3)
        Controls.Add(txtApeUsu)
        Controls.Add(Label2)
        Controls.Add(txtNomUsu)
        Controls.Add(Label1)
        Controls.Add(txtIdUsu)
        Controls.Add(UsernameLabel)
        Name = "FrmUsuario"
        Text = "Control de usuario"
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtIdUsu As TextBox
    Friend WithEvents UsernameLabel As Label
    Friend WithEvents txtNomUsu As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtApeUsu As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCorUsu As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRolUsu As ComboBox
    Friend WithEvents txtObsUsu As RichTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
End Class
