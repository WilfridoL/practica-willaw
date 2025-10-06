<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class seleccionar
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
        Button1 = New Button()
        Button2 = New Button()
        Label1 = New Label()
        Button3 = New Button()
        Button4 = New Button()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
        Button1.Location = New Point(12, 76)
        Button1.Name = "Button1"
        Button1.Size = New Size(200, 50)
        Button1.TabIndex = 0
        Button1.Text = "Usuario"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
        Button2.Location = New Point(218, 76)
        Button2.Name = "Button2"
        Button2.Size = New Size(200, 50)
        Button2.TabIndex = 1
        Button2.Text = "Cliente"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18F)
        Label1.Location = New Point(60, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(317, 32)
        Label1.TabIndex = 2
        Label1.Text = "Seleccionar panel de control"
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
        Button3.Location = New Point(218, 150)
        Button3.Name = "Button3"
        Button3.Size = New Size(200, 50)
        Button3.TabIndex = 4
        Button3.Text = "Factura"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
        Button4.Location = New Point(12, 150)
        Button4.Name = "Button4"
        Button4.Size = New Size(200, 50)
        Button4.TabIndex = 3
        Button4.Text = "Articulos"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' seleccionar
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(444, 218)
        Controls.Add(Button3)
        Controls.Add(Button4)
        Controls.Add(Label1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Name = "seleccionar"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Seleccionar panel"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
End Class
