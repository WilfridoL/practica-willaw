<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class FrmRegistrar
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents txtape As System.Windows.Forms.TextBox
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistrar))
        LogoPictureBox = New PictureBox()
        UsernameLabel = New Label()
        PasswordLabel = New Label()
        txtname = New TextBox()
        txtape = New TextBox()
        btnEnviar = New Button()
        btnCancel = New Button()
        txtcontra = New TextBox()
        Label1 = New Label()
        txtemail = New TextBox()
        Label2 = New Label()
        btnLog = New Label()
        Label3 = New Label()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LogoPictureBox
        ' 
        LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), Image)
        LogoPictureBox.Location = New Point(2, -2)
        LogoPictureBox.Name = "LogoPictureBox"
        LogoPictureBox.Size = New Size(166, 352)
        LogoPictureBox.TabIndex = 0
        LogoPictureBox.TabStop = False
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.Location = New Point(172, 24)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(220, 23)
        UsernameLabel.TabIndex = 0
        UsernameLabel.Text = "&Nombre"
        UsernameLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PasswordLabel
        ' 
        PasswordLabel.Location = New Point(417, 24)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New Size(220, 23)
        PasswordLabel.TabIndex = 2
        PasswordLabel.Text = "&Apellido"
        PasswordLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtname
        ' 
        txtname.Location = New Point(174, 44)
        txtname.Name = "txtname"
        txtname.PlaceholderText = "Ingresar Nombre"
        txtname.Size = New Size(220, 23)
        txtname.TabIndex = 1
        ' 
        ' txtape
        ' 
        txtape.Location = New Point(419, 44)
        txtape.Name = "txtape"
        txtape.PlaceholderText = "&Ingresar Apellidos"
        txtape.Size = New Size(220, 23)
        txtape.TabIndex = 3
        ' 
        ' btnEnviar
        ' 
        btnEnviar.Location = New Point(179, 156)
        btnEnviar.Name = "btnEnviar"
        btnEnviar.Size = New Size(94, 23)
        btnEnviar.TabIndex = 4
        btnEnviar.Text = "&Registrar"
        ' 
        ' btnCancel
        ' 
        btnCancel.DialogResult = DialogResult.Cancel
        btnCancel.Location = New Point(282, 156)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(94, 23)
        btnCancel.TabIndex = 5
        btnCancel.Text = "&Cancelar"
        ' 
        ' txtcontra
        ' 
        txtcontra.Location = New Point(421, 98)
        txtcontra.Name = "txtcontra"
        txtcontra.PasswordChar = "*"c
        txtcontra.PlaceholderText = "************"
        txtcontra.Size = New Size(220, 23)
        txtcontra.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.Location = New Point(419, 78)
        Label1.Name = "Label1"
        Label1.Size = New Size(220, 23)
        Label1.TabIndex = 6
        Label1.Text = "&Contraseña"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtemail
        ' 
        txtemail.Location = New Point(174, 98)
        txtemail.Name = "txtemail"
        txtemail.PlaceholderText = "Ingresar Correo Electronico"
        txtemail.Size = New Size(220, 23)
        txtemail.TabIndex = 11
        ' 
        ' Label2
        ' 
        Label2.Location = New Point(172, 78)
        Label2.Name = "Label2"
        Label2.Size = New Size(220, 23)
        Label2.TabIndex = 10
        Label2.Text = "&Correo Electronico"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' btnLog
        ' 
        btnLog.ForeColor = SystemColors.Highlight
        btnLog.Location = New Point(174, 124)
        btnLog.Name = "btnLog"
        btnLog.Size = New Size(220, 23)
        btnLog.TabIndex = 12
        btnLog.Text = "&Iniciar sesion"
        btnLog.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI", 9F)
        Label3.Location = New Point(421, 124)
        Label3.Name = "Label3"
        Label3.Size = New Size(107, 20)
        Label3.TabIndex = 13
        Label3.Text = "Max 15 caracteres"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' FrmRegistrar
        ' 
        AcceptButton = btnEnviar
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCancel
        ClientSize = New Size(688, 191)
        Controls.Add(Label3)
        Controls.Add(btnLog)
        Controls.Add(txtemail)
        Controls.Add(Label2)
        Controls.Add(txtcontra)
        Controls.Add(Label1)
        Controls.Add(btnCancel)
        Controls.Add(btnEnviar)
        Controls.Add(txtape)
        Controls.Add(txtname)
        Controls.Add(PasswordLabel)
        Controls.Add(UsernameLabel)
        Controls.Add(LogoPictureBox)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "FrmRegistrar"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterParent
        Text = "FrmRegistrar"
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents txtcontra As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtemail As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnLog As Label
    Friend WithEvents Label3 As Label

End Class
