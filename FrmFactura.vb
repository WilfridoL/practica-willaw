Public Class FrmFactura
    Dim arrTxt() As Control
    Dim idFactura As Integer = 1
    Dim sbtCant As Double = 0
    Dim dscto As Double = 0
    Private Sub DgvFac_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvFac.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Select Case DgvFac.CurrentCell.ColumnIndex ' posicion de la columna donde esta el foco en el datagrid
                    Case 0
                        e.Handled = True
                        SendKeys.Send("{TAB}")
                    Case 1
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
                                DgvFac.Item(4, DgvFac.CurrentRow.Index).Value = vec(4) ' rellena la columna seleccionada (4 = Descuento) con los datos de vec
                                DgvFac.Item(5, DgvFac.CurrentRow.Index).Value = vec(3) ' rellena la columna seleccionada (3 = IVA) con los datos de vec
                                DgvFac.CurrentCell = DgvFac.Rows(DgvFac.CurrentRow.Index).Cells(1) ' mover el focus a la siguiente fila en la misma columna
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
                DgvFac.CurrentCell = DgvFac.Rows(DgvFac.CurrentRow.Index + 1).Cells(1) ' desplaza la fila actual debajo de la fila recien agregada 
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

    Protected Overrides Function processCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If Not DgvFac.IsCurrentCellInEditMode Then Return MyBase.ProcessCmdKey(msg, keyData)
        If (keyData <> Keys.Return) Then Return MyBase.ProcessCmdKey(msg, keyData)
        Dim cell As DataGridViewCell = DgvFac.CurrentCell
        Dim columnIndex As Int32 = cell.ColumnIndex
        Dim rowIndex As Int32 = cell.RowIndex
        If columnIndex = 2 Then
            sbtCant = DgvFac.Rows(rowIndex).Cells(3).Value * DgvFac.Rows(rowIndex).Cells(2).Value
            dscto = DgvFac.Rows(rowIndex).Cells(4).Value
            DgvFac.Rows(rowIndex).Cells(6).Value = sbtCant - (sbtCant * (dscto / 100))
            If rowIndex = DgvFac.Rows.Count - 1 Then
                DgvFac.Rows.Add()
                cell = DgvFac.Rows(DgvFac.CurrentRow.Index + 1).Cells(0)
            Else
                cell = DgvFac.Rows(rowIndex + 1).Cells(0)
            End If
            cell = DgvFac.Rows(rowIndex).Cells(columnIndex + 1)
        End If
        DgvFac.CurrentCell = cell
        Return True

    End Function

End Class