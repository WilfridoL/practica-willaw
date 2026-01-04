Imports System.Text.RegularExpressions

Module eventosCampos
    Public Sub SoloNumeros(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Public Sub SoloLetras(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) AndAlso e.KeyChar <> " "c Then
            e.Handled = True
        End If
    End Sub

    Dim diccionarioDominiosCorreo As New List(Of dominios) From {
        New dominios("gmail", "com"),
        New dominios("hotmail", "com"),
        New dominios("soy.sena", "edu.co"),
        New dominios("yandex", "com")
    }
    Public Sub autoCompletarCorreo(sender As Object, e As EventArgs)
        If sender.text = "" Or sender.text = "@gmail.com" Then Exit Sub
        If Regex.IsMatch(sender.Text, "^[\w-\.]+@") = False Then
            sender.text = $"{sender.text}@gmail.com"
        End If
    End Sub
    Class dominios
        Public nombre As String
        Public dominio As String

        Public Sub New(nombreEmail, dominioWeb)
            nombre = nombreEmail
            dominio = dominioWeb
        End Sub
    End Class
End Module
