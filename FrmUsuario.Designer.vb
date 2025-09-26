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
        components = New ComponentModel.Container()
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
        btnAdd = New ToolStripButton()
        ToolStripButton3 = New ToolStripButton()
        btnUpd = New ToolStripButton()
        btnDel = New ToolStripButton()
        ToolStripButton2 = New ToolStripButton()
        Label6 = New Label()
        txtDepa = New ComboBox()
        Label7 = New Label()
        txtMun = New ComboBox()
        BaseDatosBindingSource = New BindingSource(components)
        StatusStrip1 = New StatusStrip()
        msjErr = New ToolStripStatusLabel()
        txtConUsu = New TextBox()
        Label8 = New Label()
        Label9 = New Label()
        txtEstUsu = New ComboBox()
        ToolStrip1.SuspendLayout()
        CType(BaseDatosBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        StatusStrip1.SuspendLayout()
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
        txtCorUsu.Location = New Point(114, 162)
        txtCorUsu.Name = "txtCorUsu"
        txtCorUsu.Size = New Size(220, 23)
        txtCorUsu.TabIndex = 19
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label3.ForeColor = SystemColors.Desktop
        Label3.Location = New Point(12, 162)
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
        Label4.Location = New Point(12, 249)
        Label4.Name = "Label4"
        Label4.Size = New Size(42, 23)
        Label4.TabIndex = 21
        Label4.Text = "&Rol"
        Label4.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtRolUsu
        ' 
        txtRolUsu.FormattingEnabled = True
        txtRolUsu.Location = New Point(114, 249)
        txtRolUsu.Name = "txtRolUsu"
        txtRolUsu.Size = New Size(220, 23)
        txtRolUsu.TabIndex = 20
        ' 
        ' txtObsUsu
        ' 
        txtObsUsu.BackColor = SystemColors.ControlLightLight
        txtObsUsu.Location = New Point(114, 307)
        txtObsUsu.Name = "txtObsUsu"
        txtObsUsu.ReadOnly = True
        txtObsUsu.Size = New Size(220, 96)
        txtObsUsu.TabIndex = 22
        txtObsUsu.Text = ""
        ' 
        ' Label5
        ' 
        Label5.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label5.ForeColor = SystemColors.Desktop
        Label5.Location = New Point(12, 307)
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
        ToolStrip1.Items.AddRange(New ToolStripItem() {btnAdd, ToolStripButton3, btnUpd, btnDel, ToolStripButton2})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(396, 25)
        ToolStrip1.TabIndex = 26
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' btnAdd
        ' 
        btnAdd.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), Image)
        btnAdd.ImageTransparentColor = Color.Magenta
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(23, 22)
        btnAdd.Text = "Agregar"
        ' 
        ' ToolStripButton3
        ' 
        ToolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), Image)
        ToolStripButton3.ImageTransparentColor = Color.Magenta
        ToolStripButton3.Name = "ToolStripButton3"
        ToolStripButton3.Size = New Size(23, 22)
        ToolStripButton3.Text = "Limpiar"
        ' 
        ' btnUpd
        ' 
        btnUpd.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnUpd.Enabled = False
        btnUpd.Image = CType(resources.GetObject("btnUpd.Image"), Image)
        btnUpd.ImageTransparentColor = Color.Magenta
        btnUpd.Name = "btnUpd"
        btnUpd.Size = New Size(23, 22)
        btnUpd.Text = "Actualizar"
        ' 
        ' btnDel
        ' 
        btnDel.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnDel.Enabled = False
        btnDel.Image = CType(resources.GetObject("btnDel.Image"), Image)
        btnDel.ImageTransparentColor = Color.Magenta
        btnDel.Name = "btnDel"
        btnDel.Size = New Size(23, 22)
        btnDel.Text = "Eliminar"
        ' 
        ' ToolStripButton2
        ' 
        ToolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), Image)
        ToolStripButton2.ImageTransparentColor = Color.Magenta
        ToolStripButton2.Name = "ToolStripButton2"
        ToolStripButton2.Size = New Size(23, 22)
        ToolStripButton2.Text = "Salir"
        ' 
        ' Label6
        ' 
        Label6.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label6.ForeColor = SystemColors.Desktop
        Label6.Location = New Point(12, 191)
        Label6.Name = "Label6"
        Label6.Size = New Size(96, 23)
        Label6.TabIndex = 28
        Label6.Text = "&Departamentos"
        Label6.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtDepa
        ' 
        txtDepa.FormattingEnabled = True
        txtDepa.Location = New Point(114, 191)
        txtDepa.Name = "txtDepa"
        txtDepa.Size = New Size(220, 23)
        txtDepa.TabIndex = 27
        ' 
        ' Label7
        ' 
        Label7.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label7.ForeColor = SystemColors.Desktop
        Label7.Location = New Point(12, 220)
        Label7.Name = "Label7"
        Label7.Size = New Size(63, 23)
        Label7.TabIndex = 30
        Label7.Text = "&Municipio"
        Label7.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtMun
        ' 
        txtMun.FormattingEnabled = True
        txtMun.Location = New Point(114, 220)
        txtMun.Name = "txtMun"
        txtMun.Size = New Size(220, 23)
        txtMun.TabIndex = 29
        ' 
        ' BaseDatosBindingSource
        ' 
        BaseDatosBindingSource.DataSource = GetType(BaseDatos)
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.Items.AddRange(New ToolStripItem() {msjErr})
        StatusStrip1.Location = New Point(0, 433)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(396, 22)
        StatusStrip1.TabIndex = 43
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' msjErr
        ' 
        msjErr.Name = "msjErr"
        msjErr.Size = New Size(42, 17)
        msjErr.Text = "Estado"
        ' 
        ' txtConUsu
        ' 
        txtConUsu.Location = New Point(114, 137)
        txtConUsu.Name = "txtConUsu"
        txtConUsu.PasswordChar = "*"c
        txtConUsu.Size = New Size(220, 23)
        txtConUsu.TabIndex = 45
        ' 
        ' Label8
        ' 
        Label8.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label8.ForeColor = SystemColors.Desktop
        Label8.Location = New Point(12, 137)
        Label8.Name = "Label8"
        Label8.Size = New Size(82, 23)
        Label8.TabIndex = 44
        Label8.Text = "&Contraseña"
        Label8.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label9
        ' 
        Label9.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label9.ForeColor = SystemColors.Desktop
        Label9.Location = New Point(12, 278)
        Label9.Name = "Label9"
        Label9.Size = New Size(51, 23)
        Label9.TabIndex = 47
        Label9.Text = "&Estado"
        Label9.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtEstUsu
        ' 
        txtEstUsu.Enabled = False
        txtEstUsu.FormattingEnabled = True
        txtEstUsu.Location = New Point(114, 278)
        txtEstUsu.Name = "txtEstUsu"
        txtEstUsu.Size = New Size(220, 23)
        txtEstUsu.TabIndex = 46
        ' 
        ' FrmUsuario
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(396, 455)
        Controls.Add(Label9)
        Controls.Add(txtEstUsu)
        Controls.Add(txtConUsu)
        Controls.Add(Label8)
        Controls.Add(StatusStrip1)
        Controls.Add(Label7)
        Controls.Add(txtMun)
        Controls.Add(Label6)
        Controls.Add(txtDepa)
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
        CType(BaseDatosBindingSource, ComponentModel.ISupportInitialize).EndInit()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
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
    Friend WithEvents btnAdd As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDepa As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtMun As ComboBox
    Friend WithEvents BaseDatosBindingSource As BindingSource
    Friend WithEvents btnUpd As ToolStripButton
    Friend WithEvents btnDel As ToolStripButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents msjErr As ToolStripStatusLabel
    Friend WithEvents txtConUsu As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtEstUsu As ComboBox
End Class
