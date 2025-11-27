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
                If CType(ctrl, TextBox).Name.Substring(CType(ctrl, TextBox).Name.Length - 3).ToLower() = "num" Then
                    Dim temp As Decimal
                    If Not Decimal.TryParse(CType(ctrl, TextBox).Text, Globalization.NumberStyles.Any,
                             Globalization.CultureInfo.CurrentCulture, temp) Then
                        msjErr.Text = "Este campo solo permite valores numéricos"
                        ctrl.Focus()
                        Return False
                    End If
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
        comCat.Focus()
    End Sub

    Function convertirDecimal(txt) As String
        Dim precioDecimal As Decimal

        If Decimal.TryParse(txt.Text,
                    Globalization.NumberStyles.Any,
                    Globalization.CultureInfo.CurrentCulture,
                    precioDecimal) = False Then
            MsgBox("El precio no es válido")
            Exit Function
        End If

        Dim precioSQL As String = precioDecimal.ToString(Globalization.CultureInfo.InvariantCulture)
        Return precioSQL
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If val() <> True Then Exit Sub
        SQL = "INSERT articulo (artnom, artdesc, precio, stock, catIdFk, artIva, artDescuento)
        VALUE ('" & txtNom.Text & "', '" & txtDesc.Text & "', " & convertirDecimal(txtPreNum) & ", " &
        txtStockNum.Text & ", " & comCat.SelectedValue & ", " & txtIvaNum.Text & ", " & TxtDesNum.Text & ");"
        'MsgBox(SQL)
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
        bloquecampos(False)
        txtIvaNum.Text = 19
        TxtDesNum.Text = 0
        txtStockNum.Text = 1
    End Sub

    ' mover este codigo a una funcion para poder reutilizarlo en otros formularios

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        'Dim btnArr() As Control = {btnAdd, btnUpd, btnDel}
        FrmConsulta2.Text = "Plantilla de Articulos"
        FrmConsulta2.grd.DataSource = Nothing
        SQL = "SELECT artId AS Id, artNom AS 'Nombre del articulo', precio AS Precio, stock AS Cantidad, 
        catNom AS Categoria FROM articulo
        JOIN categorias ON catidFk = catId"
        FrmConsulta2.bind.DataSource = BaseDatos.Listar_datos(SQL)
        FrmConsulta2.grd.DataSource = FrmConsulta2.bind.DataSource
        FrmConsulta2.grd.RowTemplate.Height = 17
        FrmConsulta2.Size = New Size(600, 300)
        FrmConsulta2.grd.Size = New Size(570, 200)
        For Each ctrl In FrmConsulta2.grd.Columns
            ctrl.readonly = True
        Next
        FrmConsulta2.ShowDialog()
        'MsgBox(frmConsulta.DgvConsulta.ColumnCount)
        If sw_regreso = 1 Then
            txtId.Text = vec(0)
            'MsgBox(txtboxArr)
            limpiar(txtboxArr, btnArr, 0)
            buscarDatos("SELECT catIdFk, artnom, precio, stock, artIva, artDescuento, artDesc FROM articulo WHERE artId=" & vec(0), txtboxArr)
            'MsgBox(vec(0))
            rst = BaseDatos.leer_Registro("SELECT artEst FROM articulo WHERE artId=" & vec(0))
            If rst.Read() Then
                If rst(0) = "E" Then
                    msjErr.Text = "Este articulo se encuentra eliminado, no se puede modificar"
                    bloquecampos(True)
                    btnAdd.Enabled = False
                    btnDel.Enabled = False
                    btnUpd.Enabled = False
                    Exit Sub
                Else
                    bloquecampos(False)
                End If
            End If
            'SendKeys.Send("{ENTER}")
            btnAdd.Enabled = False
            btnDel.Enabled = True
            btnUpd.Enabled = True
        End If
    End Sub
    Public Function buscarDatos(sql As String, campos() As Control)
        rst = BaseDatos.leer_Registro(sql)

        If rst.Read() Then
            For i As Integer = 0 To campos.Length - 1

                Dim ctrl = campos(i)
                Dim valorSQL = rst(i)

                If TypeOf ctrl Is TextBox Then

                    Dim txt As TextBox = CType(ctrl, TextBox)

                    ' ----- CAMPOS ESPECIALES -----
                    If txt.Name = "txtPreNum" Then
                        ' convertir 30000.00 → 30.000,00
                        Dim valDec As Decimal = Convert.ToDecimal(valorSQL)
                        txt.Text = valDec.ToString("N2")
                        Continue For
                    End If

                    If txt.Name = "txtStockNum" Then
                        txt.Text = Convert.ToInt32(valorSQL).ToString()
                        Continue For
                    End If
                    ' --------------------------------

                    ' Cualquier TextBox normal
                    txt.Text = valorSQL.ToString()

                ElseIf TypeOf ctrl Is ComboBox Then
                    CType(ctrl, ComboBox).SelectedValue = valorSQL

                ElseIf TypeOf ctrl Is RichTextBox Then
                    CType(ctrl, RichTextBox).Text = valorSQL.ToString()

                End If

            Next

            Return True
        Else
            msjErr.Text = "No se encontró el registro"
            Return False
        End If

    End Function

    Private Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        If val() = False Then Exit Sub
        SQL = "UPDATE  articulo SET 
        artNom='" & txtNom.Text & "', " &
        "artDesc='" & txtDesc.Text & "', " &
        " precio=" & convertirDecimal(txtPreNum) & ", " &
        "stock=" & txtStockNum.Text & ", " &
        "catIdFk=" & comCat.SelectedValue & "," &
        "artDescuento=" & TxtDesNum.Text & ", " &
        "artIva=" & txtIvaNum.Text &
        " WHERE artId=" & txtId.Text
        ' MsgBox(SQL)
        If BaseDatos.ingresar_registros(SQL, "Actualizar") Then
            limpiar(txtboxArr, btnArr, 1)
            msjErr.Text = "Articulo actualizado con exito"
        Else
            msjErr.Text = "Ocurrio un error al actualizar el articulo"
        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        SQL = "UPDATE  articulo SET artEst='E' WHERE artId=" & txtId.Text
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

    Function bloquecampos(valor As Boolean)
        For Each ctrl As Control In txtboxArr
            If valor = True Then ctrl.Enabled = False
            If valor = False Then ctrl.Enabled = True
        Next
    End Function

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub addCat_Click(sender As Object, e As EventArgs) Handles addCat.Click
        FrmCategoria.ShowDialog()
    End Sub

    Private Sub txtPreNum_LostFocus(sender As Object, e As EventArgs) Handles txtPreNum.LostFocus
        If txtPreNum.Text.Trim() = "" Then Exit Sub

        Dim valor As Decimal

        ' Convertir respetando comas y puntos según cultura
        If Decimal.TryParse(txtPreNum.Text, valor) Then
            txtPreNum.Text = valor.ToString("N2") ' formato monetario con 2 decimales
        Else
            MsgBox("Ingrese un valor válido", MsgBoxStyle.Exclamation)
            txtPreNum.Focus()
        End If
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

    Private Sub txtIvaNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIvaNum.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtDesNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDesNum.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    ' ------ TEXT CHANGED EVENT ---------

    Private Sub validarNumeros_Auto(sender As Object, e As EventArgs) _
Handles txtIvaNum.TextChanged, TxtDesNum.TextChanged, txtPreNum.TextChanged, txtStockNum.TextChanged

        Dim ctrl As TextBox = CType(sender, TextBox)

        If ctrl.Text.Trim() = "" Then Exit Sub

        Dim valor As Decimal
        If Decimal.TryParse(ctrl.Text, valor) = False Then
            ctrl.Text = ""
            Exit Sub
        End If

        Select Case ctrl.Name

            Case "txtIvaNum", "TxtDesNum"
                If valor < 0 Then
                    ctrl.Text = "0"
                ElseIf valor > 100 Then
                    MsgBox("El valor no puede ser mayor a 100", MsgBoxStyle.Exclamation)
                    ctrl.Text = "100"
                End If

            Case "txtPreNum", "txtStockNum"
                If valor < 0 Then ctrl.Text = "0"

        End Select

        ctrl.SelectionStart = ctrl.Text.Length
    End Sub


    Private Sub FrmArticulo_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ToolStripButton3.PerformClick()
    End Sub
End Class