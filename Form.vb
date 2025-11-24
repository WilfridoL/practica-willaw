Public Class seleccionar
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmUsuario.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmCliente.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FrmArticulo.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FrmFactura.Show()
        Me.Close()
    End Sub
End Class