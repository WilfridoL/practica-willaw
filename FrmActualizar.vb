Imports System.Security.Cryptography.X509Certificates

Public Class FrmActualizar
    Public Sub actualizarBtn(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        SQL = "UPDATE tb_usuarios SET " &
        "nombre = '" & txtNomAct.Text & "', " &
        "apellido = '" & txtApeAct.Text & "', " &
        "correo = '" & txtCorActu.Text & "', " &
        "contraseña = '" & txtConAct.Text & "', " &
        "rol = '" & txtRolActu.SelectedItem.ToString() & "' "
        '"WHERE usuId = " & FrmConsulta.obtenerIdUsuario()
        MsgBox(SQL)
        If (txtNomAct.Text = "" Or
            txtApeAct.Text = "" Or
            txtConAct.Text = "" Or
            txtCorActu.Text = "" Or
            txtRolActu.SelectedItem.ToString() = "") Then
            MsgBox("Por favor, ingresar todos los campos", MsgBoxStyle.Information)
        Else
            If (txtConAct.Text.Length > 15) Then
                MsgBox("La contraseña no comple con el rango permitido, por favor vuelva a intentarlo",
                MsgBoxStyle.Information)
            Else
                'FrmConsulta.SeleccionarDatos(SQL, "actualizó")
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarActualizar.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtRolActu.SelectedIndexChanged

    End Sub

    Private Sub FrmActualizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtRolActu.Items.Add("ADMIN")
        txtRolActu.Items.Add("USER")
        txtRolActu.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
End Class
