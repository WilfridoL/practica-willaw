Public Class FrmArticulo
    Dim c_Varias As New Varias

    Public Function buscar(sql As String, campos() As Control)
        rst = BaseDatos.leer_Registro(sql)
        If rst.Read() Then
            For i As Integer = 0 To campos.Length - 1
                If TypeOf campos(i) Is TextBox Then
                    campos(i).Text = rst(i)
                ElseIf TypeOf campos(i) Is ComboBox Then
                    CType(campos(i), ComboBox).SelectedValue = rst(i)
                ElseIf TypeOf campos(i) Is RichTextBox Then
                    campos(i).Text = rst(i)
                End If
            Next
            Return True
        Else
            msjErr.Text = "No se encontrol el usuario"
            Return False
        End If
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        SQL = "INSERT articulo (artnom, artdesc, precio, stock, catIdFk)
        VALUE ('" & txtNom.Text & "', '" & txtDesc.Text & "', " & txtPre.Text & ", " &
        txtStock.Text & ", " & comCat.SelectedValue & ");"
        MsgBox(SQL)
        If BaseDatos.ingresar_registros(SQL, "insertar") Then
            msjErr.Text = "yeap bary"
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim txtboxArr() As Control = {txtId, txtNom, txtDesc, txtPre, txtStock, comCat}
        frmConsulta.Text = "Buscar Cliente"
        frmConsulta.DgvConsulta.DataSource = ""
        SQL = "SELECT * FROM articulo"
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
            buscar("SELECT * FROM articulo WHERE artId=" & CedCli, txtboxArr)
            SendKeys.Send("{ENTER}")
            btnAdd.Enabled = False
            btnDel.Enabled = True
            btnUpd.Enabled = True
        End If
    End Sub

    Private Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click

    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub FrmArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        SQL = "Select * FROM categorias"
        c_Varias.llena_combo(comCat, SQL, "catId", "catNom")
        comCat.SelectedValue = 0
    End Sub
End Class