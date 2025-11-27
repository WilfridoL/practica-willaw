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
        lbTel = New Label()
        txtEma = New TextBox()
        lbCor = New Label()
        txtApe = New TextBox()
        lbApe = New Label()
        txtNom = New TextBox()
        lbNom = New Label()
        txtIdNum = New TextBox()
        lbId = New Label()
        txtTel = New TextBox()
        StatusStrip1 = New StatusStrip()
        msjErr = New ToolStripStatusLabel()
        lbMun = New Label()
        txtMun = New ComboBox()
        lbDep = New Label()
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
        ToolStrip1.TabStop = True
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
        ToolStripButton1.Text = "Consultar"
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
        Button1.TabIndex = 1
        Button1.UseVisualStyleBackColor = True
        ' 
        ' lbTel
        ' 
        lbTel.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbTel.ForeColor = SystemColors.Desktop
        lbTel.Location = New Point(10, 153)
        lbTel.Name = "lbTel"
        lbTel.Size = New Size(63, 23)
        lbTel.TabIndex = 36
        lbTel.Text = "&Telefono"
        lbTel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtEma
        ' 
        txtEma.Cursor = Cursors.IBeam
        txtEma.Location = New Point(112, 124)
        txtEma.MaxLength = 254
        txtEma.Name = "txtEma"
        txtEma.Size = New Size(220, 23)
        txtEma.TabIndex = 4
        ' 
        ' lbCor
        ' 
        lbCor.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbCor.ForeColor = SystemColors.Desktop
        lbCor.Location = New Point(10, 124)
        lbCor.Name = "lbCor"
        lbCor.Size = New Size(63, 23)
        lbCor.TabIndex = 33
        lbCor.Text = "&Correo"
        lbCor.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtApe
        ' 
        txtApe.Cursor = Cursors.IBeam
        txtApe.Location = New Point(112, 95)
        txtApe.MaxLength = 150
        txtApe.Name = "txtApe"
        txtApe.Size = New Size(220, 23)
        txtApe.TabIndex = 3
        ' 
        ' lbApe
        ' 
        lbApe.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbApe.ForeColor = SystemColors.Desktop
        lbApe.Location = New Point(10, 95)
        lbApe.Name = "lbApe"
        lbApe.Size = New Size(63, 23)
        lbApe.TabIndex = 31
        lbApe.Text = "&Apellidos"
        lbApe.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtNom
        ' 
        txtNom.Cursor = Cursors.IBeam
        txtNom.Location = New Point(112, 66)
        txtNom.MaxLength = 150
        txtNom.Name = "txtNom"
        txtNom.Size = New Size(220, 23)
        txtNom.TabIndex = 2
        ' 
        ' lbNom
        ' 
        lbNom.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbNom.ForeColor = SystemColors.Desktop
        lbNom.Location = New Point(10, 66)
        lbNom.Name = "lbNom"
        lbNom.Size = New Size(63, 23)
        lbNom.TabIndex = 29
        lbNom.Text = "&Nombres"
        lbNom.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtIdNum
        ' 
        txtIdNum.Cursor = Cursors.IBeam
        txtIdNum.Location = New Point(112, 37)
        txtIdNum.MaxLength = 9
        txtIdNum.Name = "txtIdNum"
        txtIdNum.Size = New Size(135, 23)
        txtIdNum.TabIndex = 0
        ' 
        ' lbId
        ' 
        lbId.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbId.ForeColor = SystemColors.Desktop
        lbId.Location = New Point(10, 37)
        lbId.Name = "lbId"
        lbId.Size = New Size(82, 23)
        lbId.TabIndex = 27
        lbId.Text = "&Identificacion"
        lbId.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtTel
        ' 
        txtTel.Cursor = Cursors.IBeam
        txtTel.Location = New Point(112, 154)
        txtTel.MaxLength = 30
        txtTel.Name = "txtTel"
        txtTel.Size = New Size(220, 23)
        txtTel.TabIndex = 5
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
        ' lbMun
        ' 
        lbMun.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbMun.ForeColor = SystemColors.Desktop
        lbMun.Location = New Point(10, 212)
        lbMun.Name = "lbMun"
        lbMun.Size = New Size(63, 23)
        lbMun.TabIndex = 46
        lbMun.Text = "&Municipio"
        lbMun.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtMun
        ' 
        txtMun.Cursor = Cursors.Hand
        txtMun.DropDownStyle = ComboBoxStyle.DropDownList
        txtMun.FormattingEnabled = True
        txtMun.Location = New Point(112, 212)
        txtMun.Name = "txtMun"
        txtMun.Size = New Size(220, 23)
        txtMun.TabIndex = 7
        ' 
        ' lbDep
        ' 
        lbDep.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbDep.ForeColor = SystemColors.Desktop
        lbDep.Location = New Point(10, 183)
        lbDep.Name = "lbDep"
        lbDep.Size = New Size(96, 23)
        lbDep.TabIndex = 44
        lbDep.Text = "&Departamentos"
        lbDep.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtDepa
        ' 
        txtDepa.Cursor = Cursors.Hand
        txtDepa.DropDownStyle = ComboBoxStyle.DropDownList
        txtDepa.FormattingEnabled = True
        txtDepa.Location = New Point(112, 183)
        txtDepa.Name = "txtDepa"
        txtDepa.Size = New Size(220, 23)
        txtDepa.TabIndex = 6
        ' 
        ' FrmCliente
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(376, 267)
        Controls.Add(lbMun)
        Controls.Add(txtMun)
        Controls.Add(lbDep)
        Controls.Add(txtDepa)
        Controls.Add(StatusStrip1)
        Controls.Add(txtTel)
        Controls.Add(ToolStrip1)
        Controls.Add(Button1)
        Controls.Add(lbTel)
        Controls.Add(txtEma)
        Controls.Add(lbCor)
        Controls.Add(txtApe)
        Controls.Add(lbApe)
        Controls.Add(txtNom)
        Controls.Add(lbNom)
        Controls.Add(txtIdNum)
        Controls.Add(lbId)
        Name = "FrmCliente"
        StartPosition = FormStartPosition.CenterScreen
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
    Friend WithEvents lbTel As Label
    Friend WithEvents txtEma As TextBox
    Friend WithEvents lbCor As Label
    Friend WithEvents txtApe As TextBox
    Friend WithEvents lbApe As Label
    Friend WithEvents txtNom As TextBox
    Friend WithEvents lbNom As Label
    Friend WithEvents txtIdNum As TextBox
    Friend WithEvents lbId As Label
    Friend WithEvents txtTel As TextBox
    Friend WithEvents btnUpd As ToolStripButton
    Friend WithEvents btnDel As ToolStripButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents msjErr As ToolStripStatusLabel
    Friend WithEvents lbMun As Label
    Friend WithEvents txtMun As ComboBox
    Friend WithEvents lbDep As Label
    Friend WithEvents txtDepa As ComboBox
    Friend WithEvents ToolStripButton1 As ToolStripButton
End Class
