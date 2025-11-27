Public Class seleccionar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmUsuario.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmCliente.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FrmArticulo.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FrmFactura.ShowDialog()
    End Sub
End Class