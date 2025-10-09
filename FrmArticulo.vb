Public Class FrmArticulo
    Dim c_Varias As New Varias
    Dim idDisplay As New Integer
    Public txtboxArr() As Control
    Public btnArr() As ToolStripButton

    Private Sub FrmArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        SQL = "Select * FROM categorias"
        c_Varias.llena_combo(comCat, SQL, "catId", "catNom")
        comCat.SelectedValue = 0
        txtboxArr = {txtId, txtNom, txtDesc, txtPre, txtStock, comCat, txtIva, TxtDes}
        btnArr = {btnAdd, btnUpd, btnDel}
        rst = BaseDatos.leer_Registro("SELECT MAX(artId) FROM articulo")
        If rst.Read() Then
            idDisplay = rst(0) + 1
            txtId.Text = idDisplay
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        SQL = "INSERT articulo (artnom, artdesc, precio, stock, catIdFk, artIva, artDescuento)
        VALUE ('" & txtNom.Text & "', '" & txtDesc.Text & "', " & txtPre.Text & ", " &
        txtStock.Text & ", " & comCat.SelectedValue & ", " & txtIva.Text & ", " & TxtDes.Text & ");"
        MsgBox(SQL)
        If BaseDatos.ingresar_registros(SQL, "insertar") Then
            msjErr.Text = "Se insertaron los datos correctamente"
            limpiar(txtboxArr, btnArr, 0)
            idDisplay = idDisplay + 1
            txtId.Text = idDisplay
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        limpiar(txtboxArr, btnArr, 1)
        txtId.Text = idDisplay
        btnAdd.Enabled = True
        btnDel.Enabled = False
        btnUpd.Enabled = False
    End Sub

    ' mover este codigo a una funcion para poder reutilizarlo en otros formularios

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        'Dim btnArr() As Control = {btnAdd, btnUpd, btnDel}
        frmConsulta.Text = "Buscar Cliente"
        frmConsulta.DgvConsulta.DataSource = ""
        SQL = "
        SELECT artId AS Id, artNom AS 'Nombre del articulo', precio AS Precio, stock AS Cantidad, 
        catNom AS Categoria FROM articulo
        JOIN categorias ON catidFk = catId"
        frmConsulta.DgvConsulta.RowTemplate.Height = 17
        frmConsulta.DgvConsulta.DataSource = BaseDatos.Listar_datos(SQL)
        frmConsulta.DgvConsulta.Columns(0).Width = 70
        frmConsulta.DgvConsulta.Columns(1).Width = 150
        frmConsulta.DgvConsulta.Columns(2).Width = 150
        frmConsulta.DgvConsulta.Columns(3).Width = 150
        frmConsulta.DgvConsulta.Columns(4).Width = 120
        frmConsulta.ShowDialog()
        If sw_regreso = 1 Then
            txtId.Text = CedCli
            'MsgBox(txtboxArr)
            limpiar(txtboxArr, btnArr, 0)
            buscar("SELECT * FROM articulo WHERE artId=" & CedCli, txtboxArr)
            SendKeys.Send("{ENTER}")
            btnAdd.Enabled = False
            btnDel.Enabled = True
            btnUpd.Enabled = True
        End If
    End Sub

    Private Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        SQL = "UPDATE  articulo SET 
        artNom='" & txtNom.Text & "', " &
        "artDesc='" & txtDesc.Text & "', " &
        " precio=" & txtPre.Text.Replace(",", ".") & ", " &
        "stock=" & txtStock.Text & ", " &
        "catIdFk=" & comCat.SelectedValue &
        " WHERE artId=" & txtId.Text
        MsgBox(SQL)
        If BaseDatos.ingresar_registros(SQL, "Actualizar") Then
            limpiar(txtboxArr, btnArr, 1)
            msjErr.Text = "Articulo actualizado con exito"
        Else
            msjErr.Text = "Ocurrio un error al actualizar el articulo"
        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        SQL = "DELETE FROM articulo WHERE artId=" & txtId.Text
        If MsgBox("Quiere eliminar este articulo", MsgBoxStyle.YesNo) = vbYes Then
            If BaseDatos.ingresar_registros(SQL, "Eliminar") Then
                limpiar(txtboxArr, btnArr, 1)
                ' idDisplay = idDisplay - 1
                msjErr.Text = "Articulo eliminado con exito"
            Else
                msjErr.Text = "Ocurrio un error al eliminar el articulo"
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub addCat_Click(sender As Object, e As EventArgs) Handles addCat.Click
        FrmCategoria.Show()
        Me.Close()
    End Sub
End Class