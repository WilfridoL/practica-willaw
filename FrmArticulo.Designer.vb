<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmArticulo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArticulo))
        ToolStrip1 = New ToolStrip()
        btnAdd = New ToolStripButton()
        ToolStripButton3 = New ToolStripButton()
        btnBuscar = New ToolStripButton()
        btnUpd = New ToolStripButton()
        btnDel = New ToolStripButton()
        ToolStripButton2 = New ToolStripButton()
        lbDesc = New Label()
        txtDesc = New RichTextBox()
        txtPre = New TextBox()
        lbPre = New Label()
        txtNom = New TextBox()
        lbNom = New Label()
        txtStock = New TextBox()
        lbSto = New Label()
        StatusStrip1 = New StatusStrip()
        msjErr = New ToolStripStatusLabel()
        comCat = New ComboBox()
        lbCat = New Label()
        addCat = New PictureBox()
        txtIva = New TextBox()
        lbIva = New Label()
        TxtDes = New TextBox()
        lbDes = New Label()
        txtId = New Label()
        Label7 = New Label()
        ToolStrip1.SuspendLayout()
        StatusStrip1.SuspendLayout()
        CType(addCat, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Items.AddRange(New ToolStripItem() {btnAdd, ToolStripButton3, btnBuscar, btnUpd, btnDel, ToolStripButton2})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(491, 25)
        ToolStrip1.TabIndex = 61
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
        ' lbDesc
        ' 
        lbDesc.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbDesc.ForeColor = SystemColors.Desktop
        lbDesc.Location = New Point(245, 187)
        lbDesc.Name = "lbDesc"
        lbDesc.Size = New Size(199, 23)
        lbDesc.TabIndex = 59
        lbDesc.Text = "&Descripcion del producto"
        lbDesc.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtDesc
        ' 
        txtDesc.BackColor = SystemColors.ControlLightLight
        txtDesc.Location = New Point(245, 213)
        txtDesc.Name = "txtDesc"
        txtDesc.Size = New Size(220, 40)
        txtDesc.TabIndex = 7
        txtDesc.Text = ""
        ' 
        ' txtPre
        ' 
        txtPre.Location = New Point(245, 115)
        txtPre.MaxLength = 150
        txtPre.Name = "txtPre"
        txtPre.Size = New Size(220, 23)
        txtPre.TabIndex = 3
        ' 
        ' lbPre
        ' 
        lbPre.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbPre.ForeColor = SystemColors.Desktop
        lbPre.Location = New Point(245, 89)
        lbPre.Name = "lbPre"
        lbPre.Size = New Size(63, 23)
        lbPre.TabIndex = 52
        lbPre.Text = "&Precio"
        lbPre.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtNom
        ' 
        txtNom.Location = New Point(19, 115)
        txtNom.MaxLength = 150
        txtNom.Name = "txtNom"
        txtNom.Size = New Size(220, 23)
        txtNom.TabIndex = 2
        ' 
        ' lbNom
        ' 
        lbNom.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbNom.ForeColor = SystemColors.Desktop
        lbNom.Location = New Point(19, 89)
        lbNom.Name = "lbNom"
        lbNom.Size = New Size(63, 23)
        lbNom.TabIndex = 50
        lbNom.Text = "&Nombre"
        lbNom.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtStock
        ' 
        txtStock.Location = New Point(19, 166)
        txtStock.MaxLength = 15
        txtStock.Name = "txtStock"
        txtStock.Size = New Size(220, 23)
        txtStock.TabIndex = 4
        ' 
        ' lbSto
        ' 
        lbSto.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbSto.ForeColor = SystemColors.Desktop
        lbSto.Location = New Point(19, 140)
        lbSto.Name = "lbSto"
        lbSto.Size = New Size(82, 23)
        lbSto.TabIndex = 67
        lbSto.Text = "&Stock"
        lbSto.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.Items.AddRange(New ToolStripItem() {msjErr})
        StatusStrip1.Location = New Point(0, 256)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(491, 22)
        StatusStrip1.TabIndex = 66
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' msjErr
        ' 
        msjErr.Name = "msjErr"
        msjErr.Size = New Size(42, 17)
        msjErr.Text = "Estado"
        ' 
        ' comCat
        ' 
        comCat.DropDownStyle = ComboBoxStyle.DropDownList
        comCat.FormattingEnabled = True
        comCat.Location = New Point(19, 61)
        comCat.Name = "comCat"
        comCat.Size = New Size(196, 23)
        comCat.TabIndex = 1
        ' 
        ' lbCat
        ' 
        lbCat.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbCat.ForeColor = SystemColors.Desktop
        lbCat.Location = New Point(19, 35)
        lbCat.Name = "lbCat"
        lbCat.Size = New Size(63, 23)
        lbCat.TabIndex = 71
        lbCat.Text = "&Categoria"
        lbCat.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' addCat
        ' 
        addCat.BackColor = Color.Transparent
        addCat.BackgroundImageLayout = ImageLayout.None
        addCat.Image = CType(resources.GetObject("addCat.Image"), Image)
        addCat.Location = New Point(218, 63)
        addCat.Name = "addCat"
        addCat.Size = New Size(16, 16)
        addCat.SizeMode = PictureBoxSizeMode.AutoSize
        addCat.TabIndex = 72
        addCat.TabStop = False
        ' 
        ' txtIva
        ' 
        txtIva.Location = New Point(245, 166)
        txtIva.MaxLength = 15
        txtIva.Name = "txtIva"
        txtIva.Size = New Size(220, 23)
        txtIva.TabIndex = 5
        ' 
        ' lbIva
        ' 
        lbIva.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbIva.ForeColor = SystemColors.Desktop
        lbIva.Location = New Point(245, 140)
        lbIva.Name = "lbIva"
        lbIva.Size = New Size(82, 23)
        lbIva.TabIndex = 73
        lbIva.Text = "&IVA"
        lbIva.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TxtDes
        ' 
        TxtDes.Location = New Point(19, 216)
        TxtDes.MaxLength = 15
        TxtDes.Name = "TxtDes"
        TxtDes.Size = New Size(220, 23)
        TxtDes.TabIndex = 6
        ' 
        ' lbDes
        ' 
        lbDes.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lbDes.ForeColor = SystemColors.Desktop
        lbDes.Location = New Point(19, 190)
        lbDes.Name = "lbDes"
        lbDes.Size = New Size(82, 23)
        lbDes.TabIndex = 75
        lbDes.Text = "&Descuento"
        lbDes.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtId
        ' 
        txtId.AutoSize = True
        txtId.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtId.Location = New Point(277, 54)
        txtId.Name = "txtId"
        txtId.Size = New Size(23, 25)
        txtId.TabIndex = 78
        txtId.Text = "0"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(245, 52)
        Label7.Name = "Label7"
        Label7.Size = New Size(38, 30)
        Label7.TabIndex = 79
        Label7.Text = "N°"
        ' 
        ' FrmArticulo
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(491, 278)
        Controls.Add(txtId)
        Controls.Add(Label7)
        Controls.Add(TxtDes)
        Controls.Add(lbDes)
        Controls.Add(txtIva)
        Controls.Add(lbIva)
        Controls.Add(addCat)
        Controls.Add(lbCat)
        Controls.Add(comCat)
        Controls.Add(ToolStrip1)
        Controls.Add(lbDesc)
        Controls.Add(txtDesc)
        Controls.Add(txtPre)
        Controls.Add(lbPre)
        Controls.Add(txtNom)
        Controls.Add(lbNom)
        Controls.Add(txtStock)
        Controls.Add(lbSto)
        Controls.Add(StatusStrip1)
        Name = "FrmArticulo"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Control de articulos"
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        CType(addCat, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lbDesc As Label
    Friend WithEvents txtDesc As RichTextBox
    Friend WithEvents txtPre As TextBox
    Friend WithEvents lbPre As Label
    Friend WithEvents txtNom As TextBox
    Friend WithEvents lbNom As Label
    Friend WithEvents txtStock As TextBox
    Friend WithEvents lbSto As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents msjErr As ToolStripStatusLabel
    Friend WithEvents comCat As ComboBox
    Friend WithEvents lbCat As Label
    Friend WithEvents addCat As PictureBox
    Friend WithEvents txtIva As TextBox
    Friend WithEvents lbIva As Label
    Friend WithEvents TxtDes As TextBox
    Friend WithEvents lbDes As Label
    Friend WithEvents txtId As Label
    Friend WithEvents Label7 As Label
End Class
