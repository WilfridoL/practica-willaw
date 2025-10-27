Public Class Frm_login
    Function validacion() As Boolean
        If txtusuid.Text = "" Then
            msjErr.Visible = True
            msjErr.Text = "Por favor ingrese el Id"
            txtusuid.Focus()
            Return False
        ElseIf txtclave.Text = "" Then
            msjErr.Visible = True
            msjErr.Text = "Por favor ingrese la clave"
            txtclave.Focus()
            Return False
        Else
            Return True

        End If
    End Function
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        msjErr.Visible = False
        SQL = "SELECT * FROM tb_usuarios WHERE usuId = " &
        txtusuid.Text & " AND contraseña = '" & txtclave.Text & "'"
        If validacion() = False Then Exit Sub
        ' MsgBox(SQL)
        rst = BaseDatos.leer_Registro(SQL)
        If rst.Read Then
            codusuario = rst(0)
            usuNombres = rst(1) & " " & rst(2)
            usuContra = txtclave.Text
            seleccionar.Show()
            Me.Close()
        Else
            MsgBox("Usuario no existe en la base de datos", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub Frm_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
    End Sub
End Class
