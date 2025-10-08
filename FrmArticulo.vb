Public Class FrmArticulo
    Dim c_Varias As New Varias
    Public txtboxArr() As Control
    Public btnArr() As ToolStripButton

    Private Sub FrmArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        SQL = "Select * FROM categorias"
        c_Varias.llena_combo(comCat, SQL, "catId", "catNom")
        comCat.SelectedValue = 0
        txtboxArr = {txtId, txtNom, txtDesc, txtPre, txtStock, comCat}
        btnArr = {btnAdd, btnUpd, btnDel}
    End Sub

    Public Function buscar(sql As String, campos() As Control)
        rst = BaseDatos.leer_Registro(sql)
        If rst.Read() Then
            For i As Integer = 0 To campos.Length - 1
                If TypeOf campos(i) Is TextBox Or TypeOf campos(i) Is RichTextBox Then
                    campos(i).Text = rst(i)
                ElseIf TypeOf campos(i) Is ComboBox Then
                    CType(campos(i), ComboBox).SelectedValue = rst(i)
                End If
            Next
            Return True
        Else
            msjErr.Text = "No se encontro"
            Return False
        End If
    End Function

    Public Function limpiar(campos() As Control, btn() As ToolStripButton)
        For i As Integer = 0 To campos.Length - 1
            If TypeOf campos(i) Is TextBox Or TypeOf campos(i) Is RichTextBox Then
                campos(i).Text = ""
            ElseIf TypeOf campos(i) Is ComboBox Then
                CType(campos(i), ComboBox).SelectedValue = 0
            End If
        Next

        For j As Integer = 0 To btn.Length - 1
            If btn(j).Enabled = True Then
                btn(j).Enabled = False
            Else
                btn(j).Enabled = True
            End If
        Next
        Return True
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        SQL = "INSERT articulo (artnom, artdesc, precio, stock, catIdFk)
        VALUE ('" & txtNom.Text & "', '" & txtDesc.Text & "', " & txtPre.Text & ", " &
        txtStock.Text & ", " & comCat.SelectedValue & ");"
        MsgBox(SQL)
        If BaseDatos.ingresar_registros(SQL, "insertar") Then
            msjErr.Text = "Se insertaron los datos correctamente"
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        limpiar(txtboxArr, btnArr)
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
            limpiar(txtboxArr, btnArr)
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
            limpiar(txtboxArr, btnArr)
            msjErr.Text = "Articulo actualizado con exito"
        Else
            msjErr.Text = "Ocurrio un error al actualizar el articulo"
        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        SQL = "DELETE FROM articulo WHERE artId=" & txtId.Text
        If MsgBox("Quiere eliminar este articulo", MsgBoxStyle.YesNo) = vbYes Then
            If BaseDatos.ingresar_registros(SQL, "Eliminar") Then
                limpiar(txtboxArr, btnArr)
                msjErr.Text = "Articulo eliminado con exito"
            Else
                msjErr.Text = "Ocurrio un error al eliminar el articulo"
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

End Class