Imports System.Text.RegularExpressions

Public Class FrmArticulo
    Dim c_Varias As New Varias
    Dim idDisplay As New Integer
    Public txtboxArr() As Control
    Private arrLabel() As Label
    Public btnArr() As ToolStripButton

    Function val()
        For Each ctrl As Control In txtboxArr
            If TypeOf ctrl Is TextBox Then
                If CType(ctrl, TextBox).Text = "" Then
                    msjErr.Text = "por favor, rellene todos los campos"
                    ctrl.Focus()
                    Return False
                End If
                If CType(ctrl, TextBox).Name.Substring(CType(ctrl, TextBox).Name.Length - 3).ToLower() = "num" And
                    Regex.IsMatch(CType(ctrl, TextBox).Text, "^([0-9]+(\/{1}[0-9]+)*)+(?!([\/]{2}))$") = False Then
                    msjErr.Text = "Este campo no permite datos no numericos"
                    ctrl.Focus()
                    Return False
                End If
            ElseIf TypeOf ctrl Is ComboBox Then
                If CType(ctrl, ComboBox).SelectedValue = 0 Then
                    msjErr.Text = "Por favor, seleccione una categoria para continuar"
                    ctrl.Focus()
                    Return False
                End If
            Else
                Return True
            End If
        Next
    End Function

    Function cargar_id()
        rst = BaseDatos.leer_Registro("SELECT MAX(artId) FROM articulo")
        If rst.Read() Then
            idDisplay = rst(0) + 1
            txtId.Text = idDisplay
        End If
    End Function

    Private Sub FrmArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        SQL = "Select * FROM categorias"
        c_Varias.llena_combo(comCat, SQL, "catId", "catNom")
        comCat.SelectedValue = 0
        txtboxArr = {comCat, txtNom, txtPreNum, txtStockNum, txtIvaNum, TxtDesNum, txtDesc}
        arrLabel = {lbCat, lbNom, lbPre, lbSto, lbIva, lbDes, lbDesc}
        btnArr = {btnAdd, btnUpd, btnDel}
        cargar_id()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If val() <> True Then Exit Sub
        SQL = "INSERT articulo (artnom, artdesc, precio, stock, catIdFk, artIva, artDescuento)
        VALUE ('" & txtNom.Text & "', '" & txtDesc.Text & "', " & txtPreNum.Text & ", " &
        txtStockNum.Text & ", " & comCat.SelectedValue & ", " & txtIvaNum.Text & ", " & TxtDesNum.Text & ");"
        ' MsgBox(SQL)
        If BaseDatos.ingresar_registros(SQL, "insertar") Then
            msjErr.Text = "Se insertaron los datos correctamente"
            limpiar(txtboxArr, btnArr, 0)
            cargar_id()
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
        For Each ctrl In frmConsulta.DgvConsulta.Columns
            ctrl.readOnly = True
        Next
        'MsgBox(frmConsulta.DgvConsulta.ColumnCount)
        frmConsulta.ShowDialog()
        If sw_regreso = 1 Then
            txtId.Text = CedCli
            'MsgBox(txtboxArr)
            limpiar(txtboxArr, btnArr, 0)
            buscar("SELECT catIdFk, artnom, precio, stock, artIva, artDescuento, artDesc FROM articulo WHERE artId=" & CedCli, txtboxArr)
            SendKeys.Send("{ENTER}")
            btnAdd.Enabled = False
            btnDel.Enabled = True
            btnUpd.Enabled = True
        End If
    End Sub

    Private Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        If val() = False Then Exit Sub
        SQL = "UPDATE  articulo SET 
        artNom='" & txtNom.Text & "', " &
        "artDesc='" & txtDesc.Text & "', " &
        " precio=" & txtPreNum.Text.Replace(",", ".") & ", " &
        "stock=" & txtStockNum.Text & ", " &
        "catIdFk=" & comCat.SelectedValue & "," &
        "artDescuento=" & TxtDesNum.Text & ", " &
        "artIva=" & txtIvaNum.Text &
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
        FrmCategoria.ShowDialog()
    End Sub

    Private Sub FrmArticulo_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        seleccionar.Show()
    End Sub

    Private Sub txtPreNum_LostFocus(sender As Object, e As EventArgs) Handles txtPreNum.LostFocus
        'If txtPreNum.Text 
        Dim converPrecio = CInt(txtPreNum.Text).ToString("N0")
        txtPreNum.Text = converPrecio
        's MsgBox("a")
    End Sub

    'Private Sub txtNom_Enter(sender As Object, e As EventArgs) Handles txtNom.Enter
    'End Sub

    ' ------ ENTER EVENT ---------
    Private Sub txtNom_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNom.KeyDown
        If e.KeyCode = Keys.Enter Then
            If btnAdd.Enabled = True Then btnAdd.PerformClick()
            If btnUpd.Enabled = True Then btnUpd.PerformClick()
        End If
    End Sub

    Private Sub txtPreNum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPreNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            If btnAdd.Enabled = True Then btnAdd.PerformClick()
            If btnUpd.Enabled = True Then btnUpd.PerformClick()
        End If
    End Sub

    Private Sub txtStockNum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStockNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            If btnAdd.Enabled = True Then btnAdd.PerformClick()
            If btnUpd.Enabled = True Then btnUpd.PerformClick()
        End If
    End Sub

    Private Sub txtIvaNum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIvaNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            If btnAdd.Enabled = True Then btnAdd.PerformClick()
            If btnUpd.Enabled = True Then btnUpd.PerformClick()
        End If
    End Sub

    Private Sub TxtDesNum_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDesNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            If btnAdd.Enabled = True Then btnAdd.PerformClick()
            If btnUpd.Enabled = True Then btnUpd.PerformClick()
        End If
    End Sub

    Private Sub txtDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            If btnAdd.Enabled = True Then btnAdd.PerformClick()
            If btnUpd.Enabled = True Then btnUpd.PerformClick()
        End If
    End Sub

    Private Sub comCat_KeyDown(sender As Object, e As KeyEventArgs) Handles comCat.KeyDown
        If e.KeyCode = Keys.Enter Then
            If btnAdd.Enabled = True Then btnAdd.PerformClick()
            If btnUpd.Enabled = True Then btnUpd.PerformClick()
        End If
    End Sub
End Class