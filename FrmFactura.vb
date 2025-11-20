Public Class FrmFactura
    Dim arrTxt() As Control
    Dim idFactura As Integer = 1
    Dim sbtCant As Double = 0
    Dim dscto As Double = 0
    Dim prIva As Double = 0

    ' valores totales
    Dim subTotal As Double = 0
    Dim dscoTotal As Double = 0
    Dim ivaTotal As Double = 0
    Dim total As Double = 0

    Sub buscarArticulo(sql As String)
        rst = BaseDatos.leer_Registro(sql)
    End Sub

    Private Sub DgvFac_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvFac.KeyDown

        ' MsgBox(e.KeyCode)
        Select Case e.KeyCode
            Case Keys.Enter
                Select Case DgvFac.CurrentCell.ColumnIndex ' posicion de la columna donde esta el foco en el datagrid
                    Case 0
                        Try

                            FrmConsulta2.Text = "Plantilla de Articulos"
                            FrmConsulta2.grd.DataSource = ""
                            SQL = "SELECT artId AS ID, artNom AS NOMBRE, precio AS VALOR, artIva AS IVA, artDescuento AS 'DT(%)' FROM articulo
                            WHERE  artEst = 'A'
                            ORDER BY artNom"
                            FrmConsulta2.grd.RowTemplate.Height = 17
                            FrmConsulta2.Size = New Size(500, 300)
                            FrmConsulta2.bind.DataSource = BaseDatos.Listar_datos(SQL)
                            FrmConsulta2.grd.DataSource = FrmConsulta2.bind.DataSource
                            FrmConsulta2.grd.Columns(0).Width = 45
                            FrmConsulta2.grd.Columns(1).Width = 100
                            FrmConsulta2.grd.Columns(2).Width = 80
                            FrmConsulta2.grd.Columns(3).Width = 45
                            FrmConsulta2.grd.Columns(4).Width = 45
                            FrmConsulta2.ShowDialog()
                            If sw_regreso = 1 Then
                                DgvFac.Item(0, DgvFac.CurrentRow.Index).Value = vec(0) ' rellena la columna seleccionada (0 = Codigo) con los datos de vec
                                DgvFac.Item(1, DgvFac.CurrentRow.Index).Value = vec(1) ' rellena la columna seleccionada (1 = Nombre) con los datos de vec
                                DgvFac.Item(3, DgvFac.CurrentRow.Index).Value = vec(2) ' rellena la columna seleccionada (2 = Valor) con los datos de vec
                                DgvFac.Item(5, DgvFac.CurrentRow.Index).Value = vec(3) ' rellena la columna seleccionada (3 = IVA) con los datos de vec
                                DgvFac.Item(4, DgvFac.CurrentRow.Index).Value = vec(4) ' rellena la columna seleccionada (4 = Descuento) con los datos de vec
                                DgvFac.CurrentCell = DgvFac.Rows(DgvFac.CurrentRow.Index - 1).Cells(2) ' mover el focus a la siguiente fila en la misma columna
                                'If DgvFac.CurrentCell.Selected = 0 Then
                                'MsgBox("a")

                                'End If
                            Else
                                DgvFac.CurrentCell = DgvFac.Rows(DgvFac.CurrentRow.Index).Cells(1)
                            End If
                        Catch ex As Exception
                        End Try
                    Case 2, 3
                        e.Handled = True
                        SendKeys.Send("{TAB}")
                End Select
            Case Keys.Insert
                DgvFac.Rows.Add() ' agrega una nueva fila
                DgvFac.CurrentCell = DgvFac.Rows(DgvFac.CurrentRow.Index + 1).Cells(0) ' desplaza la fila actual debajo de la fila recien agregada 
        End Select
    End Sub

    Private Sub FrmFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        ' cargar nombre del usuario
        usuNom.Text = "Usuario: " & usuNombres
        ' cargar id de factura
        rst = BaseDatos.leer_Registro("SELECT MAX(facId) FROM factura")
        idFactura = If(rst.Read(), If(IsDBNull(rst(0)), 1, CInt(rst(0)) + 1), 1) ' si es null o false el resultado sera 1, si no se sumara el id_factura + 1 
        facId.Text = idFactura
        arrTxt = {txtId, txtNom, txtTel} ' rellenar array de control
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtId.KeyDown
        SQL = "SELECT cliCed, CONCAT_WS(' ', cliNom, cliApe), cliTel FROM cliente WHERE cliCed =" & txtId.Text
        If e.KeyCode = Keys.Enter Then
            If txtId.Text = "" Then Exit Sub
            If BaseDatos.leer_Registro(SQL).Read() = False Then
                If MsgBox("El cliente no existe." & vbCrLf & "¿Desea agregarlo?", MsgBoxStyle.YesNo, "Error") = vbYes Then
                    FrmCliente.txtIdNum.Text = txtId.Text
                    FrmCliente.FocusFactura = 1
                    FrmCliente.ShowDialog()
                    Exit Sub
                End If
            End If
            limpiar(arrTxt, {btnAdd}, 0) ' limpiar los controles del array (el boton de agregar esta de adorno en el parametro)
            buscar(SQL, arrTxt) ' llena los controles del array con los datos de la consulta
        End If
    End Sub

    Sub recorrerDataGrid()
        subTotal = 0
        dscoTotal = 0
        ivaTotal = 0
        total = 0
        For i As Integer = 0 To DgvFac.RowCount - 1
            subTotal += DgvFac.Rows(i).Cells(3).Value * DgvFac.Rows(i).Cells(2).Value
            dscoTotal += (DgvFac.Rows(i).Cells(3).Value * DgvFac.Rows(i).Cells(2).Value) * (DgvFac.Rows(i).Cells(4).Value / 100)
            ivaTotal += ((DgvFac.Rows(i).Cells(3).Value * DgvFac.Rows(i).Cells(2).Value) -
                          ((DgvFac.Rows(i).Cells(3).Value * DgvFac.Rows(i).Cells(2).Value) * (DgvFac.Rows(i).Cells(4).Value / 100))) *
                          (DgvFac.Rows(i).Cells(5).Value / 100) ' se saca el subtotal menos el descuento y se multiplica por el iva
            total += DgvFac.Rows(i).Cells(6).Value
        Next
        txtSub.Text = "$ " & subTotal.ToString("N2")
        txtIva.Text = "$ " & ivaTotal.ToString("N2")
        txtDesc.Text = "$ " & dscoTotal.ToString("N2")
        txtTotal.Text = "$ " & total.ToString("N2")
    End Sub

    Protected Overrides Function processCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If (Not DgvFac.IsCurrentCellInEditMode) Then Return MyBase.ProcessCmdKey(msg, keyData) ' Si el control DataGridView no tiene el foco, y si la celda actual no está siendo editada, abandonamos el procedimiento.

        If (keyData <> Keys.Return) Then Return MyBase.ProcessCmdKey(msg, keyData)
        Dim cell As DataGridViewCell = DgvFac.CurrentCell
        Dim columnIndex As Int32 = cell.ColumnIndex
        Dim rowIndex As Int32 = cell.RowIndex
        DgvFac.CommitEdit(DataGridViewDataErrorContexts.Commit)
        DgvFac.EndEdit()
        If columnIndex = 0 Then
            If DgvFac.Rows(rowIndex).Cells(0).Value = "" Then
                MsgBox("Debe ingresar un codigo de articulo")
                Exit Function
            End If
            SQL = $"SELECT artId AS ID, artNom AS NOMBRE, precio AS VALOR, artIva AS IVA, artDescuento AS 'DT(%)' FROM articulo
                            WHERE  artEst = 'A' AND artId = {DgvFac.Rows(rowIndex).Cells(0).Value}"
            'MsgBox(SQL)
            rst = BaseDatos.leer_Registro(SQL)
            If rst.Read() Then
                DgvFac.Rows(rowIndex).Cells(1).Value = rst(1)
                DgvFac.Rows(rowIndex).Cells(3).Value = rst(2)
                DgvFac.Rows(rowIndex).Cells(4).Value = rst(3)
                DgvFac.Rows(rowIndex).Cells(5).Value = rst(4)
                DgvFac.CurrentCell = DgvFac.Rows(rowIndex).Cells(2)
                Return True
            Else
                If (MsgBox("El articulo no exite. ¿Desea buscarlo?", MsgBoxStyle.YesNo) = vbYes) Then
                    SendKeys.Send("{ENTER}")
                Else
                    DgvFac.Rows(rowIndex).Cells(0).Value = ""
                End If
            End If
        End If
        If columnIndex = 2 Then
            DgvFac.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DgvFac.EndEdit()
            sbtCant = DgvFac.Rows(rowIndex).Cells(3).Value * DgvFac.Rows(rowIndex).Cells(2).Value
            dscto = sbtCant * (DgvFac.Rows(rowIndex).Cells(4).Value / 100)
            'MsgBox(dscto)
            prIva = DgvFac.Rows(rowIndex).Cells(5).Value / 100
            DgvFac.Rows(rowIndex).Cells(6).Value = (sbtCant - dscto) + ((sbtCant - dscto) * prIva)
            recorrerDataGrid()
            DgvFac.CurrentCell = DgvFac.Rows(rowIndex + 1).Cells(0)
            'cell = DgvFac.Rows(rowIndex).Cells(columnIndex + 1)
            Return True
        End If
        DgvFac.CurrentCell = cell
        Return True
    End Function

End Class