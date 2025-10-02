<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCliente))
        ToolStrip1 = New ToolStrip()
        btnAdd = New ToolStripButton()
        btnLim = New ToolStripButton()
        ToolStripButton1 = New ToolStripButton()
        btnDel = New ToolStripButton()
        btnUpd = New ToolStripButton()
        btnSal = New ToolStripButton()
        Button1 = New Button()
        Label4 = New Label()
        txtCorCli = New TextBox()
        Label3 = New Label()
        txtApeCli = New TextBox()
        Label2 = New Label()
        txtNomCli = New TextBox()
        Label1 = New Label()
        txtIdCli = New TextBox()
        UsernameLabel = New Label()
        txtTelCli = New TextBox()
        StatusStrip1 = New StatusStrip()
        msjErr = New ToolStripStatusLabel()
        Label7 = New Label()
        txtMun = New ComboBox()
        Label6 = New Label()
        txtDepa = New ComboBox()
        ToolStrip1.SuspendLayout()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Items.AddRange(New ToolStripItem() {btnAdd, btnLim, ToolStripButton1, btnDel, btnUpd, btnSal})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(376, 25)
        ToolStrip1.TabIndex = 40
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
        ' btnLim
        ' 
        btnLim.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnLim.Image = CType(resources.GetObject("btnLim.Image"), Image)
        btnLim.ImageTransparentColor = Color.Magenta
        btnLim.Name = "btnLim"
        btnLim.Size = New Size(23, 22)
        btnLim.Text = "Limpiar"
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
        ' btnSal
        ' 
        btnSal.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnSal.Image = CType(resources.GetObject("btnSal.Image"), Image)
        btnSal.ImageTransparentColor = Color.Magenta
        btnSal.Name = "btnSal"
        btnSal.Size = New Size(23, 22)
        btnSal.Text = "Salir"
        ' 
        ' Button1
        ' 
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.Location = New Point(253, 37)
        Button1.Name = "Button1"
        Button1.Size = New Size(26, 23)
        Button1.TabIndex = 39
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label4.ForeColor = SystemColors.Desktop
        Label4.Location = New Point(10, 153)
        Label4.Name = "Label4"
        Label4.Size = New Size(63, 23)
        Label4.TabIndex = 36
        Label4.Text = "&Telefono"
        Label4.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtCorCli
        ' 
        txtCorCli.Location = New Point(112, 124)
        txtCorCli.MaxLength = 254
        txtCorCli.Name = "txtCorCli"
        txtCorCli.Size = New Size(220, 23)
        txtCorCli.TabIndex = 34
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label3.ForeColor = SystemColors.Desktop
        Label3.Location = New Point(10, 124)
        Label3.Name = "Label3"
        Label3.Size = New Size(63, 23)
        Label3.TabIndex = 33
        Label3.Text = "&Correo"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtApeCli
        ' 
        txtApeCli.Location = New Point(112, 95)
        txtApeCli.MaxLength = 150
        txtApeCli.Name = "txtApeCli"
        txtApeCli.Size = New Size(220, 23)
        txtApeCli.TabIndex = 32
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.Desktop
        Label2.Location = New Point(10, 95)
        Label2.Name = "Label2"
        Label2.Size = New Size(63, 23)
        Label2.TabIndex = 31
        Label2.Text = "&Apellidos"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtNomCli
        ' 
        txtNomCli.Location = New Point(112, 66)
        txtNomCli.MaxLength = 150
        txtNomCli.Name = "txtNomCli"
        txtNomCli.Size = New Size(220, 23)
        txtNomCli.TabIndex = 30
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label1.ForeColor = SystemColors.Desktop
        Label1.Location = New Point(10, 66)
        Label1.Name = "Label1"
        Label1.Size = New Size(63, 23)
        Label1.TabIndex = 29
        Label1.Text = "&Nombres"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtIdCli
        ' 
        txtIdCli.Location = New Point(112, 37)
        txtIdCli.MaxLength = 11
        txtIdCli.Name = "txtIdCli"
        txtIdCli.Size = New Size(135, 23)
        txtIdCli.TabIndex = 28
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        UsernameLabel.ForeColor = SystemColors.Desktop
        UsernameLabel.Location = New Point(10, 37)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(82, 23)
        UsernameLabel.TabIndex = 27
        UsernameLabel.Text = "&Identificacion:"
        UsernameLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtTelCli
        ' 
        txtTelCli.Location = New Point(112, 154)
        txtTelCli.MaxLength = 11
        txtTelCli.Name = "txtTelCli"
        txtTelCli.Size = New Size(220, 23)
        txtTelCli.TabIndex = 41
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.Items.AddRange(New ToolStripItem() {msjErr})
        StatusStrip1.Location = New Point(0, 245)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(376, 22)
        StatusStrip1.TabIndex = 42
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' msjErr
        ' 
        msjErr.Name = "msjErr"
        msjErr.Size = New Size(42, 17)
        msjErr.Text = "Estado"
        ' 
        ' Label7
        ' 
        Label7.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label7.ForeColor = SystemColors.Desktop
        Label7.Location = New Point(10, 212)
        Label7.Name = "Label7"
        Label7.Size = New Size(63, 23)
        Label7.TabIndex = 46
        Label7.Text = "&Municipio"
        Label7.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtMun
        ' 
        txtMun.FormattingEnabled = True
        txtMun.Location = New Point(112, 212)
        txtMun.Name = "txtMun"
        txtMun.Size = New Size(220, 23)
        txtMun.TabIndex = 45
        ' 
        ' Label6
        ' 
        Label6.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label6.ForeColor = SystemColors.Desktop
        Label6.Location = New Point(10, 183)
        Label6.Name = "Label6"
        Label6.Size = New Size(96, 23)
        Label6.TabIndex = 44
        Label6.Text = "&Departamentos"
        Label6.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtDepa
        ' 
        txtDepa.FormattingEnabled = True
        txtDepa.Location = New Point(112, 183)
        txtDepa.Name = "txtDepa"
        txtDepa.Size = New Size(220, 23)
        txtDepa.TabIndex = 43
        ' 
        ' FrmCliente
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(376, 267)
        Controls.Add(Label7)
        Controls.Add(txtMun)
        Controls.Add(Label6)
        Controls.Add(txtDepa)
        Controls.Add(StatusStrip1)
        Controls.Add(txtTelCli)
        Controls.Add(ToolStrip1)
        Controls.Add(Button1)
        Controls.Add(Label4)
        Controls.Add(txtCorCli)
        Controls.Add(Label3)
        Controls.Add(txtApeCli)
        Controls.Add(Label2)
        Controls.Add(txtNomCli)
        Controls.Add(Label1)
        Controls.Add(txtIdCli)
        Controls.Add(UsernameLabel)
        Name = "FrmCliente"
        Text = "Control de clientes"
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnAdd As ToolStripButton
    Friend WithEvents btnLim As ToolStripButton
    Friend WithEvents btnSal As ToolStripButton
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCorCli As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtApeCli As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNomCli As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtIdCli As TextBox
    Friend WithEvents UsernameLabel As Label
    Friend WithEvents txtTelCli As TextBox
    Friend WithEvents btnUpd As ToolStripButton
    Friend WithEvents btnDel As ToolStripButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents msjErr As ToolStripStatusLabel
    Friend WithEvents Label7 As Label
    Friend WithEvents txtMun As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDepa As ComboBox
    Friend WithEvents ToolStripButton1 As ToolStripButton
End Class
