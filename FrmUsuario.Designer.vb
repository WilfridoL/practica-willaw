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
        txtIdNum = New TextBox()
        lbId = New Label()
        txtNomUsu = New TextBox()
        lbNom = New Label()
        txtApeUsu = New TextBox()
        lbApe = New Label()
        txtEma = New TextBox()
        lbCorr = New Label()
        lbRol = New Label()
        txtRolUsu = New ComboBox()
        txtObsUsu = New RichTextBox()
        lbObs = New Label()
        Button1 = New Button()
        ToolStrip1 = New ToolStrip()
        btnAdd = New ToolStripButton()
        ToolStripButton3 = New ToolStripButton()
        btnBuscar = New ToolStripButton()
        btnUpd = New ToolStripButton()
        btnDel = New ToolStripButton()
        ToolStripButton2 = New ToolStripButton()
        menDes = New ToolStripSplitButton()
        btnCanContra = New ToolStripMenuItem()
        btnDesBlo = New ToolStripMenuItem()
        lbDep = New Label()
        txtDepa = New ComboBox()
        lbMun = New Label()
        txtMun = New ComboBox()
        BaseDatosBindingSource = New BindingSource(components)
        StatusStrip1 = New StatusStrip()
        msjErr = New ToolStripStatusLabel()
        txtConUsu = New TextBox()
        lbCon = New Label()
        lbEst = New Label()
        txtEstUsu = New ComboBox()
        txtConContra = New TextBox()
        lbConCont = New Label()
        tipId = New ComboBox()
        txtApe2Usu = New TextBox()
        lbApe2 = New Label()
        txtNom2Usu = New TextBox()
        lbNom2 = New Label()
        txtDir = New TextBox()
        lbDir = New Label()
        ToolStrip1.SuspendLayout()
        CType(BaseDatosBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtIdNum
        ' 
        txtIdNum.Cursor = Cursors.IBeam
        txtIdNum.Location = New Point(190, 50)
        txtIdNum.MaxLength = 9
        txtIdNum.Name = "txtIdNum"
        txtIdNum.Size = New Size(139, 23)
        txtIdNum.TabIndex = 0
        ' 
        ' lbId
        ' 
        lbId.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbId.ForeColor = SystemColors.Desktop
        lbId.Location = New Point(12, 50)
        lbId.Name = "lbId"
        lbId.Size = New Size(96, 23)
        lbId.TabIndex = 12
        lbId.Text = "&Identificacion*"
        lbId.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtNomUsu
        ' 
        txtNomUsu.Cursor = Cursors.IBeam
        txtNomUsu.Location = New Point(137, 79)
        txtNomUsu.MaxLength = 150
        txtNomUsu.Name = "txtNomUsu"
        txtNomUsu.Size = New Size(220, 23)
        txtNomUsu.TabIndex = 2
        ' 
        ' lbNom
        ' 
        lbNom.AutoSize = True
        lbNom.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbNom.ForeColor = SystemColors.Desktop
        lbNom.Location = New Point(12, 82)
        lbNom.Name = "lbNom"
        lbNom.Size = New Size(94, 15)
        lbNom.TabIndex = 14
        lbNom.Text = "&Primer Nombre*"
        lbNom.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtApeUsu
        ' 
        txtApeUsu.Cursor = Cursors.IBeam
        txtApeUsu.Location = New Point(137, 142)
        txtApeUsu.MaxLength = 150
        txtApeUsu.Name = "txtApeUsu"
        txtApeUsu.Size = New Size(220, 23)
        txtApeUsu.TabIndex = 4
        ' 
        ' lbApe
        ' 
        lbApe.AutoSize = True
        lbApe.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbApe.ForeColor = SystemColors.Desktop
        lbApe.Location = New Point(12, 145)
        lbApe.Name = "lbApe"
        lbApe.Size = New Size(92, 15)
        lbApe.TabIndex = 16
        lbApe.Text = "&Primer apellido*"
        lbApe.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtEma
        ' 
        txtEma.Cursor = Cursors.IBeam
        txtEma.ImeMode = ImeMode.NoControl
        txtEma.Location = New Point(137, 262)
        txtEma.MaxLength = 254
        txtEma.Name = "txtEma"
        txtEma.Size = New Size(220, 23)
        txtEma.TabIndex = 8
        ' 
        ' lbCorr
        ' 
        lbCorr.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbCorr.ForeColor = SystemColors.Desktop
        lbCorr.Location = New Point(12, 264)
        lbCorr.Name = "lbCorr"
        lbCorr.Size = New Size(63, 23)
        lbCorr.TabIndex = 18
        lbCorr.Text = "&Correo*"
        lbCorr.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lbRol
        ' 
        lbRol.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbRol.ForeColor = SystemColors.Desktop
        lbRol.Location = New Point(12, 383)
        lbRol.Name = "lbRol"
        lbRol.Size = New Size(42, 23)
        lbRol.TabIndex = 21
        lbRol.Text = "&Rol*"
        lbRol.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtRolUsu
        ' 
        txtRolUsu.Cursor = Cursors.Hand
        txtRolUsu.DropDownStyle = ComboBoxStyle.DropDownList
        txtRolUsu.FormattingEnabled = True
        txtRolUsu.Location = New Point(137, 381)
        txtRolUsu.Name = "txtRolUsu"
        txtRolUsu.Size = New Size(220, 23)
        txtRolUsu.TabIndex = 12
        ' 
        ' txtObsUsu
        ' 
        txtObsUsu.BackColor = SystemColors.ControlLightLight
        txtObsUsu.Location = New Point(137, 439)
        txtObsUsu.Name = "txtObsUsu"
        txtObsUsu.Size = New Size(220, 96)
        txtObsUsu.TabIndex = 14
        txtObsUsu.Text = ""
        ' 
        ' lbObs
        ' 
        lbObs.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbObs.ForeColor = SystemColors.Desktop
        lbObs.Location = New Point(12, 441)
        lbObs.Name = "lbObs"
        lbObs.Size = New Size(96, 23)
        lbObs.TabIndex = 23
        lbObs.Text = "&Observaciones:"
        lbObs.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Button1
        ' 
        Button1.Cursor = Cursors.Hand
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.Location = New Point(331, 50)
        Button1.Name = "Button1"
        Button1.Size = New Size(26, 23)
        Button1.TabIndex = 1
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Items.AddRange(New ToolStripItem() {btnAdd, ToolStripButton3, btnBuscar, btnUpd, btnDel, ToolStripButton2, menDes})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(369, 25)
        ToolStrip1.TabIndex = 26
        ToolStrip1.TabStop = True
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' btnAdd
        ' 
        btnAdd.BackgroundImageLayout = ImageLayout.None
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
        ' btnBuscar
        ' 
        btnBuscar.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), Image)
        btnBuscar.ImageTransparentColor = Color.Magenta
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(23, 22)
        btnBuscar.Text = "consultar"
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
        btnDel.Text = "Bloquear usuario"
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
        ' menDes
        ' 
        menDes.DisplayStyle = ToolStripItemDisplayStyle.Text
        menDes.DropDownItems.AddRange(New ToolStripItem() {btnCanContra, btnDesBlo})
        menDes.ImageTransparentColor = Color.Magenta
        menDes.Name = "menDes"
        menDes.Size = New Size(16, 22)
        ' 
        ' btnCanContra
        ' 
        btnCanContra.Name = "btnCanContra"
        btnCanContra.Size = New Size(183, 22)
        btnCanContra.Text = "Cambiar Contraseña"
        ' 
        ' btnDesBlo
        ' 
        btnDesBlo.Name = "btnDesBlo"
        btnDesBlo.Size = New Size(183, 22)
        btnDesBlo.Text = "Desbloquear Usuario"
        ' 
        ' lbDep
        ' 
        lbDep.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbDep.ForeColor = SystemColors.Desktop
        lbDep.Location = New Point(12, 293)
        lbDep.Name = "lbDep"
        lbDep.Size = New Size(96, 23)
        lbDep.TabIndex = 28
        lbDep.Text = "&Departamentos*"
        lbDep.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtDepa
        ' 
        txtDepa.Cursor = Cursors.Hand
        txtDepa.DropDownStyle = ComboBoxStyle.DropDownList
        txtDepa.FormattingEnabled = True
        txtDepa.Location = New Point(137, 291)
        txtDepa.Name = "txtDepa"
        txtDepa.Size = New Size(220, 23)
        txtDepa.TabIndex = 9
        ' 
        ' lbMun
        ' 
        lbMun.AutoSize = True
        lbMun.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbMun.ForeColor = SystemColors.Desktop
        lbMun.Location = New Point(12, 322)
        lbMun.Name = "lbMun"
        lbMun.Size = New Size(66, 15)
        lbMun.TabIndex = 30
        lbMun.Text = "&Municipio*"
        lbMun.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtMun
        ' 
        txtMun.Cursor = Cursors.Hand
        txtMun.DropDownStyle = ComboBoxStyle.DropDownList
        txtMun.FormattingEnabled = True
        txtMun.Location = New Point(137, 320)
        txtMun.Name = "txtMun"
        txtMun.Size = New Size(220, 23)
        txtMun.TabIndex = 10
        ' 
        ' BaseDatosBindingSource
        ' 
        BaseDatosBindingSource.DataSource = GetType(BaseDatos)
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.Items.AddRange(New ToolStripItem() {msjErr})
        StatusStrip1.Location = New Point(0, 550)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(369, 22)
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
        txtConUsu.Cursor = Cursors.IBeam
        txtConUsu.Location = New Point(137, 204)
        txtConUsu.MaxLength = 15
        txtConUsu.Name = "txtConUsu"
        txtConUsu.PasswordChar = "*"c
        txtConUsu.Size = New Size(220, 23)
        txtConUsu.TabIndex = 6
        ' 
        ' lbCon
        ' 
        lbCon.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbCon.ForeColor = SystemColors.Desktop
        lbCon.Location = New Point(12, 204)
        lbCon.Name = "lbCon"
        lbCon.Size = New Size(82, 23)
        lbCon.TabIndex = 44
        lbCon.Text = "&Contraseña*"
        lbCon.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lbEst
        ' 
        lbEst.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbEst.ForeColor = SystemColors.Desktop
        lbEst.Location = New Point(12, 412)
        lbEst.Name = "lbEst"
        lbEst.Size = New Size(51, 23)
        lbEst.TabIndex = 47
        lbEst.Text = "&Estado"
        lbEst.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtEstUsu
        ' 
        txtEstUsu.Cursor = Cursors.Hand
        txtEstUsu.DropDownStyle = ComboBoxStyle.DropDownList
        txtEstUsu.Enabled = False
        txtEstUsu.FormattingEnabled = True
        txtEstUsu.Location = New Point(137, 410)
        txtEstUsu.Name = "txtEstUsu"
        txtEstUsu.Size = New Size(220, 23)
        txtEstUsu.TabIndex = 13
        ' 
        ' txtConContra
        ' 
        txtConContra.Cursor = Cursors.IBeam
        txtConContra.Location = New Point(137, 233)
        txtConContra.MaxLength = 15
        txtConContra.Name = "txtConContra"
        txtConContra.PasswordChar = "*"c
        txtConContra.Size = New Size(220, 23)
        txtConContra.TabIndex = 7
        ' 
        ' lbConCont
        ' 
        lbConCont.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbConCont.ForeColor = SystemColors.Desktop
        lbConCont.Location = New Point(12, 233)
        lbConCont.Name = "lbConCont"
        lbConCont.Size = New Size(128, 23)
        lbConCont.TabIndex = 48
        lbConCont.Text = "&Confrimar Contraseña*"
        lbConCont.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' tipId
        ' 
        tipId.DropDownStyle = ComboBoxStyle.DropDownList
        tipId.FormattingEnabled = True
        tipId.Location = New Point(137, 50)
        tipId.Name = "tipId"
        tipId.Size = New Size(47, 23)
        tipId.TabIndex = 49
        ' 
        ' txtApe2Usu
        ' 
        txtApe2Usu.Cursor = Cursors.IBeam
        txtApe2Usu.Location = New Point(137, 171)
        txtApe2Usu.MaxLength = 150
        txtApe2Usu.Name = "txtApe2Usu"
        txtApe2Usu.Size = New Size(220, 23)
        txtApe2Usu.TabIndex = 5
        ' 
        ' lbApe2
        ' 
        lbApe2.AutoSize = True
        lbApe2.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbApe2.ForeColor = SystemColors.Desktop
        lbApe2.Location = New Point(12, 177)
        lbApe2.Name = "lbApe2"
        lbApe2.Size = New Size(102, 15)
        lbApe2.TabIndex = 53
        lbApe2.Text = "&Segundo Apellido"
        lbApe2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtNom2Usu
        ' 
        txtNom2Usu.Cursor = Cursors.IBeam
        txtNom2Usu.Location = New Point(137, 111)
        txtNom2Usu.MaxLength = 150
        txtNom2Usu.Name = "txtNom2Usu"
        txtNom2Usu.Size = New Size(220, 23)
        txtNom2Usu.TabIndex = 3
        ' 
        ' lbNom2
        ' 
        lbNom2.AutoSize = True
        lbNom2.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbNom2.ForeColor = SystemColors.Desktop
        lbNom2.Location = New Point(12, 114)
        lbNom2.Name = "lbNom2"
        lbNom2.Size = New Size(102, 15)
        lbNom2.TabIndex = 52
        lbNom2.Text = "&Segundo Nombre"
        lbNom2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtDir
        ' 
        txtDir.Cursor = Cursors.IBeam
        txtDir.ImeMode = ImeMode.NoControl
        txtDir.Location = New Point(137, 349)
        txtDir.MaxLength = 254
        txtDir.Name = "txtDir"
        txtDir.Size = New Size(220, 23)
        txtDir.TabIndex = 11
        ' 
        ' lbDir
        ' 
        lbDir.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbDir.ForeColor = SystemColors.Desktop
        lbDir.Location = New Point(12, 351)
        lbDir.Name = "lbDir"
        lbDir.Size = New Size(63, 23)
        lbDir.TabIndex = 55
        lbDir.Text = "&Direccion*"
        lbDir.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' FrmUsuario
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(369, 572)
        Controls.Add(txtDir)
        Controls.Add(lbDir)
        Controls.Add(txtApe2Usu)
        Controls.Add(lbApe2)
        Controls.Add(txtNom2Usu)
        Controls.Add(lbNom2)
        Controls.Add(tipId)
        Controls.Add(txtConContra)
        Controls.Add(lbConCont)
        Controls.Add(lbEst)
        Controls.Add(txtEstUsu)
        Controls.Add(txtConUsu)
        Controls.Add(lbCon)
        Controls.Add(StatusStrip1)
        Controls.Add(lbMun)
        Controls.Add(txtMun)
        Controls.Add(lbDep)
        Controls.Add(txtDepa)
        Controls.Add(ToolStrip1)
        Controls.Add(Button1)
        Controls.Add(lbObs)
        Controls.Add(txtObsUsu)
        Controls.Add(lbRol)
        Controls.Add(txtRolUsu)
        Controls.Add(txtEma)
        Controls.Add(lbCorr)
        Controls.Add(txtApeUsu)
        Controls.Add(lbApe)
        Controls.Add(txtNomUsu)
        Controls.Add(lbNom)
        Controls.Add(txtIdNum)
        Controls.Add(lbId)
        Name = "FrmUsuario"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Control de usuario"
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        CType(BaseDatosBindingSource, ComponentModel.ISupportInitialize).EndInit()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtIdNum As TextBox
    Friend WithEvents lbId As Label
    Friend WithEvents txtNomUsu As TextBox
    Friend WithEvents lbNom As Label
    Friend WithEvents txtApeUsu As TextBox
    Friend WithEvents lbApe As Label
    Friend WithEvents txtEma As TextBox
    Friend WithEvents lbCorr As Label
    Friend WithEvents lbRol As Label
    Friend WithEvents txtRolUsu As ComboBox
    Friend WithEvents txtObsUsu As RichTextBox
    Friend WithEvents lbObs As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnAdd As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents lbDep As Label
    Friend WithEvents txtDepa As ComboBox
    Friend WithEvents lbMun As Label
    Friend WithEvents txtMun As ComboBox
    Friend WithEvents BaseDatosBindingSource As BindingSource
    Friend WithEvents btnUpd As ToolStripButton
    Friend WithEvents btnDel As ToolStripButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents msjErr As ToolStripStatusLabel
    Friend WithEvents txtConUsu As TextBox
    Friend WithEvents lbCon As Label
    Friend WithEvents lbEst As Label
    Friend WithEvents txtEstUsu As ComboBox
    Friend WithEvents btnBuscar As ToolStripButton
    Friend WithEvents txtConContra As TextBox
    Friend WithEvents lbConCont As Label
    Friend WithEvents tipId As ComboBox
    Friend WithEvents txtApe2Usu As TextBox
    Friend WithEvents lbApe2 As Label
    Friend WithEvents txtNom2Usu As TextBox
    Friend WithEvents lbNom2 As Label
    Friend WithEvents txtDir As TextBox
    Friend WithEvents lbDir As Label
    Friend WithEvents menDes As ToolStripSplitButton
    Friend WithEvents btnCanContra As ToolStripMenuItem
    Friend WithEvents btnDesBlo As ToolStripMenuItem
End Class
