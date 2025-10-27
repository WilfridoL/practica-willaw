<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFactura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFactura))
        ToolStrip1 = New ToolStrip()
        btnAdd = New ToolStripButton()
        ToolStripButton3 = New ToolStripButton()
        btnDel = New ToolStripButton()
        btnBuscar = New ToolStripButton()
        btnSalir = New ToolStripButton()
        dateMenu = New DateTimePicker()
        Label1 = New Label()
        txtId = New TextBox()
        txtNom = New TextBox()
        Label2 = New Label()
        txtRezSoc = New TextBox()
        Label3 = New Label()
        txtTel = New TextBox()
        Label4 = New Label()
        Label5 = New Label()
        facId = New Label()
        DgvFac = New DataGridView()
        txtSub = New TextBox()
        Label7 = New Label()
        txtIva = New TextBox()
        Label8 = New Label()
        txtDesc = New TextBox()
        Label9 = New Label()
        txtTotal = New TextBox()
        Label10 = New Label()
        StatusStrip1 = New StatusStrip()
        ToolStripStatusLabel2 = New ToolStripStatusLabel()
        ToolStripStatusLabel3 = New ToolStripStatusLabel()
        usuNom = New ToolStripStatusLabel()
        barProgress = New ToolStripProgressBar()
        est = New ToolStripStatusLabel()
        artid = New DataGridViewTextBoxColumn()
        artNom = New DataGridViewTextBoxColumn()
        artCant = New DataGridViewTextBoxColumn()
        artPre = New DataGridViewTextBoxColumn()
        ToolStrip1.SuspendLayout()
        CType(DgvFac, ComponentModel.ISupportInitialize).BeginInit()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Items.AddRange(New ToolStripItem() {btnAdd, ToolStripButton3, btnDel, btnBuscar, btnSalir})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(505, 25)
        ToolStrip1.TabIndex = 62
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
        ToolStripButton3.Text = "Editar"
        ' 
        ' btnDel
        ' 
        btnDel.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnDel.Image = CType(resources.GetObject("btnDel.Image"), Image)
        btnDel.ImageTransparentColor = Color.Magenta
        btnDel.Name = "btnDel"
        btnDel.Size = New Size(23, 22)
        btnDel.Text = "Eliminar"
        ' 
        ' btnBuscar
        ' 
        btnBuscar.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), Image)
        btnBuscar.ImageTransparentColor = Color.Magenta
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(23, 22)
        btnBuscar.Text = "Buscar"
        ' 
        ' btnSalir
        ' 
        btnSalir.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), Image)
        btnSalir.ImageTransparentColor = Color.Magenta
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(23, 22)
        btnSalir.Text = "ToolStripButton1"
        ' 
        ' dateMenu
        ' 
        dateMenu.Location = New Point(12, 28)
        dateMenu.Name = "dateMenu"
        dateMenu.Size = New Size(229, 23)
        dateMenu.TabIndex = 63
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 69)
        Label1.Name = "Label1"
        Label1.Size = New Size(79, 15)
        Label1.TabIndex = 64
        Label1.Text = "Identificación"
        ' 
        ' txtId
        ' 
        txtId.Location = New Point(97, 66)
        txtId.Name = "txtId"
        txtId.Size = New Size(68, 23)
        txtId.TabIndex = 65
        ' 
        ' txtNom
        ' 
        txtNom.Location = New Point(232, 69)
        txtNom.Name = "txtNom"
        txtNom.Size = New Size(261, 23)
        txtNom.TabIndex = 67
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(170, 72)
        Label2.Name = "Label2"
        Label2.Size = New Size(56, 15)
        Label2.TabIndex = 66
        Label2.Text = "Nombres"
        ' 
        ' txtRezSoc
        ' 
        txtRezSoc.Location = New Point(90, 95)
        txtRezSoc.Name = "txtRezSoc"
        txtRezSoc.Size = New Size(231, 23)
        txtRezSoc.TabIndex = 69
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 98)
        Label3.Name = "Label3"
        Label3.Size = New Size(72, 15)
        Label3.TabIndex = 68
        Label3.Text = "Razon social"
        ' 
        ' txtTel
        ' 
        txtTel.Location = New Point(385, 98)
        txtTel.Name = "txtTel"
        txtTel.Size = New Size(108, 23)
        txtTel.TabIndex = 71
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(327, 101)
        Label4.Name = "Label4"
        Label4.Size = New Size(52, 15)
        Label4.TabIndex = 70
        Label4.Text = "Teléfono"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(385, 20)
        Label5.Name = "Label5"
        Label5.Size = New Size(42, 32)
        Label5.TabIndex = 72
        Label5.Text = "N°"
        ' 
        ' facId
        ' 
        facId.AutoSize = True
        facId.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        facId.Location = New Point(433, 20)
        facId.Name = "facId"
        facId.Size = New Size(28, 32)
        facId.TabIndex = 73
        facId.Text = "1"
        ' 
        ' DgvFac
        ' 
        DgvFac.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvFac.Columns.AddRange(New DataGridViewColumn() {artid, artNom, artCant, artPre})
        DgvFac.Location = New Point(12, 137)
        DgvFac.Name = "DgvFac"
        DgvFac.Size = New Size(481, 174)
        DgvFac.TabIndex = 74
        ' 
        ' txtSub
        ' 
        txtSub.Location = New Point(385, 317)
        txtSub.Name = "txtSub"
        txtSub.Size = New Size(108, 23)
        txtSub.TabIndex = 76
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(327, 320)
        Label7.Name = "Label7"
        Label7.Size = New Size(51, 15)
        Label7.TabIndex = 75
        Label7.Text = "Subtotal"
        ' 
        ' txtIva
        ' 
        txtIva.Location = New Point(385, 346)
        txtIva.Name = "txtIva"
        txtIva.Size = New Size(108, 23)
        txtIva.TabIndex = 78
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(327, 349)
        Label8.Name = "Label8"
        Label8.Size = New Size(52, 15)
        Label8.TabIndex = 77
        Label8.Text = "Total IVA"
        ' 
        ' txtDesc
        ' 
        txtDesc.Location = New Point(385, 375)
        txtDesc.Name = "txtDesc"
        txtDesc.Size = New Size(108, 23)
        txtDesc.TabIndex = 80
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(289, 378)
        Label9.Name = "Label9"
        Label9.Size = New Size(90, 15)
        Label9.TabIndex = 79
        Label9.Text = "Total descuento"
        ' 
        ' txtTotal
        ' 
        txtTotal.Location = New Point(385, 404)
        txtTotal.Name = "txtTotal"
        txtTotal.Size = New Size(108, 23)
        txtTotal.TabIndex = 82
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(347, 407)
        Label10.Name = "Label10"
        Label10.Size = New Size(32, 15)
        Label10.TabIndex = 81
        Label10.Text = "Total"
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.Items.AddRange(New ToolStripItem() {ToolStripStatusLabel2, ToolStripStatusLabel3, usuNom, barProgress, est})
        StatusStrip1.Location = New Point(0, 444)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(505, 23)
        StatusStrip1.TabIndex = 83
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' ToolStripStatusLabel2
        ' 
        ToolStripStatusLabel2.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        ToolStripStatusLabel2.Size = New Size(0, 18)
        ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        ' 
        ' ToolStripStatusLabel3
        ' 
        ToolStripStatusLabel3.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        ToolStripStatusLabel3.Size = New Size(0, 18)
        ToolStripStatusLabel3.Text = "ToolStripStatusLabel3"
        ' 
        ' usuNom
        ' 
        usuNom.Name = "usuNom"
        usuNom.Size = New Size(71, 18)
        usuNom.Text = "NombreUsu"
        ' 
        ' barProgress
        ' 
        barProgress.Name = "barProgress"
        barProgress.Size = New Size(119, 17)
        ' 
        ' est
        ' 
        est.Name = "est"
        est.Size = New Size(115, 18)
        est.Text = "&Estado: En Ejecucion"
        est.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' artid
        ' 
        artid.HeaderText = "Cod Art"
        artid.Name = "artid"
        ' 
        ' artNom
        ' 
        artNom.HeaderText = "Nombre"
        artNom.Name = "artNom"
        artNom.Width = 250
        ' 
        ' artCant
        ' 
        artCant.HeaderText = "Cantidad"
        artCant.Name = "artCant"
        ' 
        ' artPre
        ' 
        artPre.HeaderText = "Precio"
        artPre.Name = "artPre"
        ' 
        ' FrmFactura
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(505, 467)
        Controls.Add(StatusStrip1)
        Controls.Add(txtTotal)
        Controls.Add(Label10)
        Controls.Add(txtDesc)
        Controls.Add(Label9)
        Controls.Add(txtIva)
        Controls.Add(Label8)
        Controls.Add(txtSub)
        Controls.Add(Label7)
        Controls.Add(DgvFac)
        Controls.Add(facId)
        Controls.Add(Label5)
        Controls.Add(txtTel)
        Controls.Add(Label4)
        Controls.Add(txtRezSoc)
        Controls.Add(Label3)
        Controls.Add(txtNom)
        Controls.Add(Label2)
        Controls.Add(txtId)
        Controls.Add(Label1)
        Controls.Add(dateMenu)
        Controls.Add(ToolStrip1)
        Name = "FrmFactura"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Crear Factura"
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        CType(DgvFac, ComponentModel.ISupportInitialize).EndInit()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnAdd As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents btnBuscar As ToolStripButton
    Friend WithEvents btnDel As ToolStripButton
    Friend WithEvents dateMenu As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents txtNom As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRezSoc As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTel As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents facId As Label
    Friend WithEvents DgvFac As DataGridView
    Friend WithEvents txtSub As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtIva As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtDesc As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents barProgress As ToolStripProgressBar
    Friend WithEvents artid As DataGridViewTextBoxColumn
    Friend WithEvents artNom As DataGridViewTextBoxColumn
    Friend WithEvents artCant As DataGridViewTextBoxColumn
    Friend WithEvents btnSalir As ToolStripButton
    Friend WithEvents usuNom As ToolStripStatusLabel
    Friend WithEvents est As ToolStripStatusLabel
    Friend WithEvents artPre As DataGridViewTextBoxColumn
End Class
