<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class Frm_login
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
    Friend WithEvents txtusuemail As System.Windows.Forms.TextBox
    Friend WithEvents txtclave As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_login))
        LogoPictureBox = New PictureBox()
        UsernameLabel = New Label()
        PasswordLabel = New Label()
        txtusuemail = New TextBox()
        txtclave = New TextBox()
        OK = New Button()
        Cancel = New Button()
        msjErr = New Label()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LogoPictureBox
        ' 
        LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), Image)
        LogoPictureBox.Location = New Point(0, 0)
        LogoPictureBox.Name = "LogoPictureBox"
        LogoPictureBox.Size = New Size(165, 193)
        LogoPictureBox.TabIndex = 0
        LogoPictureBox.TabStop = False
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.Location = New Point(172, 24)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(220, 23)
        UsernameLabel.TabIndex = 0
        UsernameLabel.Text = "&Correo del usuario"
        UsernameLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PasswordLabel
        ' 
        PasswordLabel.Location = New Point(172, 81)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New Size(220, 23)
        PasswordLabel.TabIndex = 2
        PasswordLabel.Text = "&Contraseña"
        PasswordLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtusuemail
        ' 
        txtusuemail.Location = New Point(174, 44)
        txtusuemail.Name = "txtusuemail"
        txtusuemail.PlaceholderText = "a@example.com"
        txtusuemail.Size = New Size(220, 23)
        txtusuemail.TabIndex = 1
        ' 
        ' txtclave
        ' 
        txtclave.Location = New Point(174, 101)
        txtclave.Name = "txtclave"
        txtclave.PasswordChar = "*"c
        txtclave.PlaceholderText = "*******"
        txtclave.Size = New Size(220, 23)
        txtclave.TabIndex = 3
        ' 
        ' OK
        ' 
        OK.Location = New Point(197, 161)
        OK.Name = "OK"
        OK.Size = New Size(94, 23)
        OK.TabIndex = 4
        OK.Text = "&Aceptar"
        ' 
        ' Cancel
        ' 
        Cancel.DialogResult = DialogResult.Cancel
        Cancel.Location = New Point(300, 161)
        Cancel.Name = "Cancel"
        Cancel.Size = New Size(94, 23)
        Cancel.TabIndex = 5
        Cancel.Text = "&Cancelar"
        ' 
        ' msjErr
        ' 
        msjErr.BackColor = SystemColors.Control
        msjErr.Location = New Point(174, 127)
        msjErr.Name = "msjErr"
        msjErr.Size = New Size(220, 23)
        msjErr.TabIndex = 6
        msjErr.Text = "error"
        msjErr.TextAlign = ContentAlignment.MiddleLeft
        msjErr.Visible = False
        ' 
        ' Frm_login
        ' 
        AcceptButton = OK
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = Cancel
        ClientSize = New Size(401, 192)
        Controls.Add(msjErr)
        Controls.Add(Cancel)
        Controls.Add(OK)
        Controls.Add(txtclave)
        Controls.Add(txtusuemail)
        Controls.Add(PasswordLabel)
        Controls.Add(UsernameLabel)
        Controls.Add(LogoPictureBox)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "Frm_login"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterParent
        Text = "Login"
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents msjErr As Label

End Class
