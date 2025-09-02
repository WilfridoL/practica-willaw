Imports System.Diagnostics.Eventing.Reader
Imports Google.Protobuf.WellKnownTypes

Public Class FrmUsuario
    Public Function VerEstado(ByVal est As String, ByVal name As String, ByVal ob As String)
        If est = "I" Then
            MsgBox("El usuario " & name & " Se encuentra inactivo")
        ElseIf est = "B" Then
            txtNomUsu.ReadOnly = True
            txtApeUsu.ReadOnly = True
            txtCorUsu.ReadOnly = True
            txtObsUsu.ReadOnly = True
            txtRolUsu.Enabled = False
            MsgBox("El usuario " & name & " Se encuentra bloqueado por el motivo " & ob, MsgBoxStyle.Critical)

        Else
            txtIdUsu.ReadOnly = True
        End If
        Return True
    End Function
    Public Function limpiar(ByVal e As Integer)
        txtNomUsu.Text = ""
        txtApeUsu.Text = ""
        txtCorUsu.Text = ""
        txtRolUsu.SelectedItem = ""
        txtIdUsu.ReadOnly = False
        txtNomUsu.ReadOnly = False
        txtApeUsu.ReadOnly = False
        txtCorUsu.ReadOnly = False
        txtObsUsu.ReadOnly = False
        txtRolUsu.Enabled = True
        If e = 1 Then
            txtIdUsu.Text = ""
        End If
        Return True
    End Function
    Public Function BuscarUsuario()
        SQL = "SELECT usuId AS ID, nombre, apellido, correo, contraseña, rol, observacion, estado FROM tb_usuarios  
        LEFT JOIN observaciones ON idUsuFk = usuId  
        WHERE usuId = " & txtIdUsu.Text
        ' MsgBox(SQL)
        rst = BaseDatos.leer_Registro(SQL)
        If txtIdUsu.Text = "" Then
            MsgBox("Por Favor ingresar identificacion para hacer la busqueda")
        ElseIf rst.Read() Then
            limpiar(0)
            txtNomUsu.Text = rst("nombre")
            txtApeUsu.Text = rst("apellido")
            txtCorUsu.Text = rst("correo")
            txtRolUsu.SelectedItem = rst("rol")
            txtObsUsu.Text = rst("observacion")
            VerEstado(rst("estado"), rst("nombre") & " " & rst("apellido"), rst("observacion"))
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

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        limpiar(1)
    End Sub
End Class