Imports System.Diagnostics.Eventing.Reader

Public Class FrmUsuario
    Public Function BuscarUsuario()
        If txtIdUsu.Text = "" Then
            SQL = "SELECT usuId AS ID, nombre, apellido, correo, contraseña, rol, observacion FROM tb_usuarios  
        LEFT JOIN observaciones ON idUsuFk = usuId  
        WHERE usuId = " & txtIdUsu.Text
            ' MsgBox(SQL)
            rst = BaseDatos.leer_Registro(SQL)
            MsgBox("Por Favor ingresar identificacion para hacer la busqueda")
        ElseIf rst.Read() Then
            txtNomUsu.Text = rst("nombre")
            txtApeUsu.Text = rst("apellido")
            txtCorUsu.Text = rst("correo")
            txtRolUsu.SelectedItem = rst("rol")
        Else
            MsgBox("Usuario no existe en la base de datos", MsgBoxStyle.Critical)
        End If
        Return True
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BuscarUsuario()
    End Sub

    Private Sub FrmUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIdUsu.Focus()
        BaseDatos.conectar("root", "")
        txtRolUsu.Items.Add("ADMIN")
        txtRolUsu.Items.Add("USER")
        txtRolUsu.Items.Add("INVITADO")
        txtRolUsu.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub txtIdUsu_TextChanged(sender As Object, e As KeyEventArgs) Handles txtIdUsu.KeyDown
        If e.KeyCode = Keys.Enter Then
            BuscarUsuario()
        End If
    End Sub
End Class