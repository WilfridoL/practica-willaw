Public Class FrmCategoria
    Private txtboxArr() As Control
    Private btnArr() As ToolStripButton
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        txtboxArr = {txtId, txtNom}
        btnArr = {btnAdd, btnUpd, btnDel}
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        SQL = "INSERT categorias (catnom)
        VALUE ('" & txtNom.Text & "');"
        'sgBox(SQL)
        If BaseDatos.ingresar_registros(SQL, "insertar") Then
            limpiar(txtboxArr, btnArr, 0)
            MsgBox("Se insertaron los datos correctamente")
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        limpiar(txtboxArr, btnArr, 1)
        btnAdd.Enabled = True
        btnDel.Enabled = False
        btnUpd.Enabled = False
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        'Dim btnArr() As Control = {btnAdd, btnUpd, btnDel}
        frmConsulta.Text = "Buscar Categoria"
        frmConsulta.DgvConsulta.DataSource = ""
        SQL = "SELECT catId as Id, catNom as Nombres from categorias"
        frmConsulta.Width = 250
        frmConsulta.Height = 200
        frmConsulta.DgvConsulta.RowTemplate.Height = 17
        frmConsulta.DgvConsulta.DataSource = BaseDatos.Listar_datos(SQL)
        For Each ctrl In frmConsulta.DgvConsulta.Columns
            ctrl.readOnly = True
        Next
        frmConsulta.ShowDialog()
        If sw_regreso = 1 Then
            txtId.Text = CedCli
            'MsgBox(txtboxArr)
            limpiar(txtboxArr, btnArr, 1)
            buscar("SELECT * FROM categorias WHERE catid=" & CedCli, txtboxArr)
            SendKeys.Send("{ENTER}")
            btnAdd.Enabled = False
            btnDel.Enabled = True
            btnUpd.Enabled = True
        End If
    End Sub

    Private Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        SQL = "UPDATE categorias SET catNom='" & txtNom.Text & "' WHERE catId=" & txtId.Text
        If BaseDatos.ingresar_registros(SQL, "actualizar") Then
            limpiar(txtboxArr, btnArr, 1)
            MsgBox("Se actualizo correctamente")
        Else
            MsgBox("Ocurrio un error")
        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        SQL = "DELETE FROM categorias WHERE catId=" & txtId.Text
        If MsgBox("Quiere eliminar este articulo", MsgBoxStyle.YesNo) = vbYes Then
            If BaseDatos.ingresar_registros(SQL, "Eliminar") Then
                limpiar(txtboxArr, btnArr, 1)
                MsgBox("Articulo eliminado con exito")
            Else
                MsgBox("Ocurrio un error al eliminar el articulo", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        FrmArticulo.Show()
        Me.Close()
    End Sub

    Private Sub FrmCategoria_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        c_Varias.llena_combo(FrmArticulo.comCat, "Select * FROM categorias", "catId", "catNom")
        ToolStripButton3.PerformClick()
    End Sub
End Class