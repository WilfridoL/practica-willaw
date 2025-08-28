Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class FrmRegistrar
    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        SQL = "INSERT tb_usuarios (nombre, apellido, contraseña, correo, rol, estado)
        VALUE ('" & txtname.Text & "', '" & txtape.Text & "', '" & txtcontra.Text & "', '" & txtemail.Text & "', '" & txtRol.SelectedItem.ToString & "', 'ACTIVO')"
        ' MsgBox(SQL)
        If (txtname.Text = "" Or
            txtape.Text = "" Or
            txtcontra.Text = "" Or
            txtemail.Text = "") Then
            MsgBox("Por favor, ingresar todos los campos", MsgBoxStyle.Information)
        Else
            If (txtcontra.Text.Length > 15) Then
                MsgBox("La contraseña no comple con el rango permitido, por favor vuelva a intentarlo",
                MsgBoxStyle.Information)
            Else
                BaseDatos.ingresar_registros(SQL, "insertar")
                txtname.Text = ""
                txtape.Text = ""
                txtcontra.Text = ""
                txtemail.Text = ""
                txtname.Focus()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmRegistrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        txtRol.Items.Add("ADMIN")
        txtRol.Items.Add("USER")
        txtRol.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub txtRol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtRol.SelectedIndexChanged

    End Sub
End Class
