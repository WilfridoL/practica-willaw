<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmNotas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtnota1 = New Label()
        nota1txt = New TextBox()
        nota2txt = New TextBox()
        txtnota2 = New Label()
        nota3txt = New TextBox()
        txtnota3 = New Label()
        lbldefinitiva = New TextBox()
        definitivalabel = New Label()
        btnCalcular = New Button()
        btnNuevo = New Button()
        btnSalir = New Button()
        SuspendLayout()
        ' 
        ' txtnota1
        ' 
        txtnota1.AutoSize = True
        txtnota1.Font = New Font("Arial Rounded MT Bold", 12F)
        txtnota1.Location = New Point(26, 28)
        txtnota1.Name = "txtnota1"
        txtnota1.Size = New Size(60, 18)
        txtnota1.TabIndex = 0
        txtnota1.Text = "Nota 1"
        ' 
        ' nota1txt
        ' 
        nota1txt.Location = New Point(88, 25)
        nota1txt.Name = "nota1txt"
        nota1txt.Size = New Size(39, 23)
        nota1txt.TabIndex = 1
        ' 
        ' nota2txt
        ' 
        nota2txt.Location = New Point(88, 65)
        nota2txt.Name = "nota2txt"
        nota2txt.Size = New Size(39, 23)
        nota2txt.TabIndex = 3
        ' 
        ' txtnota2
        ' 
        txtnota2.AutoSize = True
        txtnota2.Font = New Font("Arial Rounded MT Bold", 12F)
        txtnota2.Location = New Point(26, 68)
        txtnota2.Name = "txtnota2"
        txtnota2.Size = New Size(60, 18)
        txtnota2.TabIndex = 2
        txtnota2.Text = "Nota 2"
        ' 
        ' nota3txt
        ' 
        nota3txt.Location = New Point(88, 104)
        nota3txt.Name = "nota3txt"
        nota3txt.Size = New Size(39, 23)
        nota3txt.TabIndex = 5
        ' 
        ' txtnota3
        ' 
        txtnota3.AutoSize = True
        txtnota3.Font = New Font("Arial Rounded MT Bold", 12F)
        txtnota3.Location = New Point(26, 107)
        txtnota3.Name = "txtnota3"
        txtnota3.Size = New Size(60, 18)
        txtnota3.TabIndex = 4
        txtnota3.Text = "Nota 3"
        ' 
        ' lbldefinitiva
        ' 
        lbldefinitiva.BackColor = SystemColors.InactiveCaption
        lbldefinitiva.Location = New Point(108, 189)
        lbldefinitiva.Name = "lbldefinitiva"
        lbldefinitiva.Size = New Size(36, 23)
        lbldefinitiva.TabIndex = 7
        ' 
        ' definitivalabel
        ' 
        definitivalabel.AutoSize = True
        definitivalabel.Font = New Font("Arial Rounded MT Bold", 12F)
        definitivalabel.Location = New Point(26, 189)
        definitivalabel.Name = "definitivalabel"
        definitivalabel.Size = New Size(76, 18)
        definitivalabel.TabIndex = 6
        definitivalabel.Text = "Difinitiva"
        ' 
        ' btnCalcular
        ' 
        btnCalcular.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCalcular.Location = New Point(207, 25)
        btnCalcular.Name = "btnCalcular"
        btnCalcular.Size = New Size(102, 48)
        btnCalcular.TabIndex = 8
        btnCalcular.Text = "Calcular"
        btnCalcular.UseVisualStyleBackColor = True
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNuevo.Location = New Point(207, 91)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(102, 48)
        btnNuevo.TabIndex = 9
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnSalir
        ' 
        btnSalir.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSalir.Location = New Point(207, 159)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(102, 48)
        btnSalir.TabIndex = 10
        btnSalir.Text = "Salir"
        btnSalir.UseVisualStyleBackColor = True
        ' 
        ' FrmNotas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(347, 252)
        Controls.Add(btnSalir)
        Controls.Add(btnNuevo)
        Controls.Add(btnCalcular)
        Controls.Add(lbldefinitiva)
        Controls.Add(definitivalabel)
        Controls.Add(nota3txt)
        Controls.Add(txtnota3)
        Controls.Add(nota2txt)
        Controls.Add(txtnota2)
        Controls.Add(nota1txt)
        Controls.Add(txtnota1)
        Name = "FrmNotas"
        Text = "Calculo de Notas"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtnota1 As Label
    Friend WithEvents nota1txt As TextBox
    Friend WithEvents nota2txt As TextBox
    Friend WithEvents txtnota2 As Label
    Friend WithEvents nota3txt As TextBox
    Friend WithEvents txtnota3 As Label
    Friend WithEvents lbldefinitiva As TextBox
    Friend WithEvents definitivalabel As Label
    Friend WithEvents btnCalcular As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnSalir As Button

End Class
