<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class FrmActualizar
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
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents txtNomAct As System.Windows.Forms.TextBox
    Friend WithEvents txtConAct As System.Windows.Forms.TextBox
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnCancelarActualizar As System.Windows.Forms.Button

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        UsernameLabel = New Label()
        PasswordLabel = New Label()
        txtNomAct = New TextBox()
        txtConAct = New TextBox()
        btnActualizar = New Button()
        btnCancelarActualizar = New Button()
        txtApeAct = New TextBox()
        Label2 = New Label()
        txtCorActu = New TextBox()
        Label1 = New Label()
        txtRolActu = New ComboBox()
        Label3 = New Label()
        Label4 = New Label()
        SuspendLayout()
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.Location = New Point(10, 32)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(220, 23)
        UsernameLabel.TabIndex = 0
        UsernameLabel.Text = "&Nombres"
        UsernameLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PasswordLabel
        ' 
        PasswordLabel.Location = New Point(10, 89)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New Size(220, 23)
        PasswordLabel.TabIndex = 2
        PasswordLabel.Text = "&Contraseña"
        PasswordLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtNomAct
        ' 
        txtNomAct.Location = New Point(12, 52)
        txtNomAct.Name = "txtNomAct"
        txtNomAct.Size = New Size(220, 23)
        txtNomAct.TabIndex = 1
        ' 
        ' txtConAct
        ' 
        txtConAct.Location = New Point(12, 109)
        txtConAct.Name = "txtConAct"
        txtConAct.PasswordChar = "*"c
        txtConAct.Size = New Size(220, 23)
        txtConAct.TabIndex = 3
        ' 
        ' btnActualizar
        ' 
        btnActualizar.Location = New Point(504, 109)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(94, 23)
        btnActualizar.TabIndex = 4
        btnActualizar.Text = "&Actualizar"
        ' 
        ' btnCancelarActualizar
        ' 
        btnCancelarActualizar.DialogResult = DialogResult.Cancel
        btnCancelarActualizar.Location = New Point(607, 109)
        btnCancelarActualizar.Name = "btnCancelarActualizar"
        btnCancelarActualizar.Size = New Size(94, 23)
        btnCancelarActualizar.TabIndex = 5
        btnCancelarActualizar.Text = "&Cancelar"
        ' 
        ' txtApeAct
        ' 
        txtApeAct.Location = New Point(256, 52)
        txtApeAct.Name = "txtApeAct"
        txtApeAct.Size = New Size(220, 23)
        txtApeAct.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.Location = New Point(254, 32)
        Label2.Name = "Label2"
        Label2.Size = New Size(220, 23)
        Label2.TabIndex = 6
        Label2.Text = "&Apellidos"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtCorActu
        ' 
        txtCorActu.Location = New Point(497, 52)
        txtCorActu.Name = "txtCorActu"
        txtCorActu.Size = New Size(220, 23)
        txtCorActu.TabIndex = 9
        ' 
        ' Label1
        ' 
        Label1.Location = New Point(495, 32)
        Label1.Name = "Label1"
        Label1.Size = New Size(220, 23)
        Label1.TabIndex = 8
        Label1.Text = "&Correo Electronico"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtRolActu
        ' 
        txtRolActu.FormattingEnabled = True
        txtRolActu.Location = New Point(256, 109)
        txtRolActu.Name = "txtRolActu"
        txtRolActu.Size = New Size(220, 23)
        txtRolActu.TabIndex = 10
        ' 
        ' Label3
        ' 
        Label3.Location = New Point(256, 86)
        Label3.Name = "Label3"
        Label3.Size = New Size(220, 23)
        Label3.TabIndex = 11
        Label3.Text = "&Rol"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(10, 4)
        Label4.Name = "Label4"
        Label4.Size = New Size(153, 25)
        Label4.TabIndex = 12
        Label4.Text = "Actualizar Datos"
        ' 
        ' FrmActualizar
        ' 
        AcceptButton = btnActualizar
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCancelarActualizar
        ClientSize = New Size(733, 145)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(txtRolActu)
        Controls.Add(txtCorActu)
        Controls.Add(Label1)
        Controls.Add(txtApeAct)
        Controls.Add(Label2)
        Controls.Add(btnCancelarActualizar)
        Controls.Add(btnActualizar)
        Controls.Add(txtConAct)
        Controls.Add(txtNomAct)
        Controls.Add(PasswordLabel)
        Controls.Add(UsernameLabel)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "FrmActualizar"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterParent
        Text = "FrmActualizar"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents txtApeAct As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCorActu As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtRolActu As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label

End Class
