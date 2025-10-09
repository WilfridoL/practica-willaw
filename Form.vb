Public Class seleccionar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmUsuario.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmCliente.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FrmArticulo.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FrmFactura.Show()
    End Sub
End Class