Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class FrmFactura
    Dim arrTxt() As Control
    Dim canCod As Integer
    Dim clienteValido As Integer = 0

    Dim idFactura As Integer = 1
    Dim sbtCant As Double = 0
    Dim dscto As Double = 0
    Dim prIva As Double = 0

    ' valores totales
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
                                If validarDataGrid(DgvFac.Item(0, DgvFac.CurrentRow.Index).Value) = False Then DgvFac.CurrentCell = DgvFac.Rows(DgvFac.CurrentRow.Index - 1).Cells(0) : Exit Sub
                                DgvFac.Item(1, DgvFac.CurrentRow.Index).Value = vec(1) ' rellena la columna seleccionada (1 = Nombre) con los datos de vec
                                DgvFac.Item(3, DgvFac.CurrentRow.Index).Value = vec(2) ' rellena la columna seleccionada (2 = Valor) con los datos de vec
                                DgvFac.Item(5, DgvFac.CurrentRow.Index).Value = vec(3) ' rellena la columna seleccionada (3 = IVA) con los datos de vec
                                DgvFac.Item(4, DgvFac.CurrentRow.Index).Value = vec(4) ' rellena la columna seleccionada (4 = Descuento) con los datos de vec
                                DgvFac.CurrentCell = DgvFac.Rows(DgvFac.CurrentRow.Index - 1).Cells(2) ' mover el focus a la siguiente fila en la misma columna
                                MsgBox(DgvFac.CurrentCell.RowIndex) ' el indece 0 aparece pero en realidad es la fila 2
                                'If DgvFac.CurrentCell.RowIndex = 0 Then
                                '    MsgBox("a")

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
                'DgvFac.CurrentCell = DgvFac.Rows(DgvFac.CurrentRow.Index + 1).Cells(0) ' desplaza la fila actual debajo de la fila recien agregada 
        End Select
    End Sub

    Private Sub FrmFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        ' cargar nombre del usuario
        usuNom.Text = "Usuario: " & usuNombres
        arrTxt = {txtId, txtNom, txtTel, txtCor} ' rellenar array de control
        txtId.Focus()
        ' DgvFac.Rows.Add() ' agrega una nueva fila
        cambiarEstado(2)
        ' MsgBox(DgvFac.RowCount)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtId.KeyDown
        If e.KeyCode = Keys.Enter Then
            If validarIdCliente(False) <> True Then Exit Sub
            SQL = "SELECT cliCed, CONCAT_WS(' ', cliNom, cliApe), cliTel, cliEma FROM cliente WHERE cliCed =" & Convert.ToInt32(txtId.Text)
            If BaseDatos.leer_Registro(SQL).Read() = False Then
                If MsgBox("El cliente no existe." & vbCrLf & "¿Desea agregarlo?", MsgBoxStyle.YesNo, "Error") = vbYes Then
                    FrmCliente.txtIdNum.Text = txtId.Text
                    FrmCliente.FocusFactura = 1
                    FrmCliente.ShowDialog()
                    Exit Sub
                End If
                Exit Sub
            End If
            limpiar(arrTxt, {btnAdd}, 0) ' limpiar los controles del array (el boton de agregar esta de adorno en el parametro)
            buscar(SQL, arrTxt) ' llena los controles del array con los datos de la consulta
            clienteValido = txtId.Text
            'bloquearCampos(arrTxt, 0)
        End If
    End Sub

    ' Sub bloquearCampos(arr() As Control, tip As Integer)
    '  For i As Integer = 0 To arr.Length
    '        arr(0).Enabled = True
    '       If tip = 0 Then arr(i).Enabled = False
    ' If tip = 1 Then arr(i).Enabled = True
    '    Next
    'End Sub

    Sub recorrerDataGrid()
        dscoTotal = 0
        ivaTotal = 0
        total = 0
        For i As Integer = 0 To DgvFac.RowCount - 1
            dscoTotal += (DgvFac.Rows(i).Cells(3).Value * DgvFac.Rows(i).Cells(2).Value) * (DgvFac.Rows(i).Cells(4).Value / 100)
            ivaTotal += ((DgvFac.Rows(i).Cells(3).Value * DgvFac.Rows(i).Cells(2).Value) -
                          ((DgvFac.Rows(i).Cells(3).Value * DgvFac.Rows(i).Cells(2).Value) * (DgvFac.Rows(i).Cells(4).Value / 100))) *
                          (DgvFac.Rows(i).Cells(5).Value / 100) ' se saca el subtotal menos el descuento y se multiplica por el iva
            total += DgvFac.Rows(i).Cells(6).Value
        Next
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
            If validarDataGrid(DgvFac.Rows(rowIndex).Cells(0).Value) = False Then Exit Function

            SQL = $"SELECT artId AS ID, artNom AS NOMBRE, precio AS VALOR, artIva AS IVA, artDescuento AS 'DT(%)', stock FROM articulo
                            WHERE  artEst = 'A' AND artId = {DgvFac.Rows(rowIndex).Cells(0).Value}"
            MsgBox(rowIndex)
            rst = BaseDatos.leer_Registro(SQL)
            If rst.Read() Then
                DgvFac.Rows(rowIndex).Cells(1).Value = rst(1)
                DgvFac.Rows(rowIndex).Cells(2).Value = 1
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
            If validarDataGrid(DgvFac.Rows(rowIndex).Cells(0).Value) = False Then Exit Function
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

    Function validarIdCliente(tipoVal As Boolean) As Boolean ' solo valida los datos de identificacion 
        If txtId.Text = "" Then
            MsgBox("Debe ingresar un cliente para registrar la factura", MsgBoxStyle.Exclamation)
            Return False
        ElseIf Regex.IsMatch(txtId.Text, "^([0-9]+(\/{1}[0-9]+)*)+(?!([\/]{2}))$") = False Then
            MsgBox("Solo ingresar datos numericos", MsgBoxStyle.Critical)
            txtId.Text = ""
            Return False
        ElseIf clienteValido <> CInt(txtId.Text) And tipoVal = True Then
            txtId.Focus()
            SendKeys.Send("{ENTER}")
            Return False
        End If
        Return True
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If validarIdCliente(True) <> True Then Exit Sub ' si no pasa a la primera al segundo click si pasa, si la funcion retorna true 
            If DgvFac.RowCount < 2 Then MsgBox("Para registrar tiene que al menos tener un articulo en la cuadricula", MsgBoxStyle.Critical) : Exit Sub
            If MsgBox("¿Desea registrar la factura?" & vbCrLf &
                      "Se eliminaran todas las filas que no esten diligenciadas de la cuadricula",
                      MsgBoxStyle.YesNo Or MsgBoxStyle.Information, "Confirmar") = vbNo Then Exit Sub
            SQL = $"INSERT INTO factura (facFec,facTolIva, facTolDsc, facTol, cliCedFk, usuIdFk, facEst, facObs) VALUES
            (NOW() ,
            {Convert.ToDouble(ivaTotal).ToString(CultureInfo.InvariantCulture)}, 
            {Convert.ToDouble(dscoTotal).ToString(CultureInfo.InvariantCulture)}, 
            {Convert.ToDouble(total).ToString(CultureInfo.InvariantCulture)}, 
            {txtId.Text}, 
            {codusuario}, 
            'REGISTRADO', 
            '{txtObs.Text}');"
            'MsgBox(SQL)
            eliminarFilasVacias() ' si la fila del datagrid no tiene codigo de articulo se eliminara
            If BaseDatos.ingresar_registros(SQL, "registrar") Then
                rst = BaseDatos.leer_Registro("SELECT MAX(facId) FROM factura")
                If rst.Read() Then idFactura = rst(0)
                For i As Integer = 0 To DgvFac.RowCount - 2
                    Try
                        SQL = $"INSERT INTO detFac (facIdFk, artIdFk, artPre, detCant, detDesc, detIva,detSub) VALUES
                        ({idFactura}, 
                        {CInt(DgvFac.Rows(i).Cells(0).Value)}, 
                        {Convert.ToDouble(DgvFac.Rows(i).Cells(3).Value).ToString(CultureInfo.InvariantCulture)}, 
                        {CInt(DgvFac.Rows(i).Cells(2).Value)}, 
                        {CInt(DgvFac.Rows(i).Cells(4).Value)}, 
                        {CInt(DgvFac.Rows(i).Cells(5).Value)}, 
                        {Convert.ToDouble(DgvFac.Rows(i).Cells(6).Value).ToString(CultureInfo.InvariantCulture)});"
                        ' MsgBox(SQL)
                        BaseDatos.ingresar_registros(SQL, "registrar")
                    Catch ex As Exception
                        MsgBox(i.ToString & " - " & ex.Message)
                        cambiarEstado(1)
                    End Try
                Next
                MsgBox($"La factura con el codigo {idFactura} se registro con exito", MsgBoxStyle.Information)
                cambiarEstado(0)
            Else
                Exit Sub
            End If
            limpiarFactura()
        Catch ex As Exception
            MsgBox(ex.Message)
            cambiarEstado(1)
        End Try
    End Sub

    Function cambiarEstado(evento As Integer)
        If evento = 0 Then msjErr.Text = "Registrado"
        If evento = 1 Then msjErr.Text = "Anulado"
        If evento > 1 Then msjErr.Text = "En ejecución"
    End Function

    Function eliminarFilasVacias()

        'Recorrer desde la última fila hacia arriba
        For i As Integer = DgvFac.Rows.Count - 1 To 0 Step -1

            Dim fila = DgvFac.Rows(i)

            'Evitar la fila nueva vacía del DataGridView
            If fila.IsNewRow Then Continue For

            'Evitar celdas no inicializadas
            If fila.Cells(0).Value Is Nothing Then
                DgvFac.Rows.RemoveAt(i)
                Continue For
            End If

            'Si hay texto vacío o espacios → eliminar
            If fila.Cells(0).Value.ToString().Trim() = "" Then
                DgvFac.Rows.RemoveAt(i)
            End If

        Next

        Return True
    End Function

    Function validarDataGrid(codArt As Integer) As Boolean
        For i As Integer = 0 To DgvFac.RowCount - 1
            ' verificar si el articulo ya fue ingresado en la factura
            If DgvFac.Rows(i).Cells(0).Value = codArt And DgvFac.CurrentRow.Index <> i Then
                MsgBox("El articulo ya fue ingresado en la factura")
                DgvFac.Rows(DgvFac.CurrentRow.Index).Cells(0).Value = ""
                DgvFac.CurrentCell = DgvFac.Rows(DgvFac.CurrentRow.Index).Cells(0)
                Return False
            End If
            ' verificar si la cantidad solicitada no supera el stock disponible
            rst = BaseDatos.leer_Registro($"SELECT stock FROM articulo WHERE artId = {codArt}")
            If rst.Read() Then
                canCod = rst(0)
                If DgvFac.Rows(DgvFac.CurrentRow.Index).Cells(2).Value > canCod Then
                    MsgBox("La cantidad solicitada supera el stock disponible: " & canCod)
                    DgvFac.Rows(DgvFac.CurrentRow.Index).Cells(2).Value = 0
                    DgvFac.CurrentCell = DgvFac.Rows(DgvFac.CurrentRow.Index).Cells(2)
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Function limpiarFactura()
        txtId.Clear()
        txtNom.Clear()
        txtTel.Clear()
        txtCor.Clear()
        txtIva.Clear()
        txtDesc.Clear()
        txtTotal.Clear()
        txtObs.Clear()
        DgvFac.Rows.Clear()
        txtId.Focus()
        cambiarEstado(2)
        Return True
    End Function

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        'limpiarFilas()
    End Sub

    Private Sub FrmFactura_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        seleccionar.Show()
    End Sub
End Class