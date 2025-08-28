Public Class FrmNotas
    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        lbldefinitiva.Text = Val(nota1txt.Text * 0.2) + Val(nota2txt.Text * 0.3) + Val(nota3txt.Text * 0.5)
        If (lbldefinitiva.Text) < 3 Then
            lbldefinitiva.ForeColor = Color.Red
            MsgBox("LO SIENTO USTED NO APROBO", MsgBoxStyle.Information, "Informacion importante")
        Else
            lbldefinitiva.ForeColor = Color.Green
            MsgBox("FELICIDADES!!!! USTEB APROBO", MsgBoxStyle.Information, "Informacion importante")
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        nota1txt.Text = ""
        nota2txt.Text = ""
        nota3txt.Text = ""
        lbldefinitiva.Text = ""
        nota1txt.Focus()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class
