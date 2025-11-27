Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class FrmFactura
    Dim arrTxt() As Control
    Dim canCod As Integer
    Dim clienteValido As Long = 0

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
        If e.KeyCode <> Keys.Enter Then
            If e.KeyCode = Keys.Insert Then
                DgvFac.Rows.Add()
            End If
            Return
        End If

        e.Handled = True
        Dim col As Integer = DgvFac.CurrentCell.ColumnIndex
        Dim row As Integer = DgvFac.CurrentCell.RowIndex

        Select Case col
            Case 0
                ' Abrir buscador
                FrmConsulta2.Text = "Plantilla de Articulos"
                FrmConsulta2.grd.DataSource = Nothing
                SQL = "SELECT artId AS ID, artNom AS NOMBRE, precio AS VALOR, artIva AS IVA, artDescuento AS 'DT(%)' FROM articulo WHERE artEst = 'A' ORDER BY artNom"
                FrmConsulta2.bind.DataSource = BaseDatos.Listar_datos(SQL)
                FrmConsulta2.grd.DataSource = FrmConsulta2.bind.DataSource
                FrmConsulta2.grd.RowTemplate.Height = 17
                FrmConsulta2.Size = New Size(500, 300)
                FrmConsulta2.grd.Size = New Size(454, 186)
                For Each ctrl In FrmConsulta2.grd.Columns
                    ctrl.readonly = True
                Next
                FrmConsulta2.ShowDialog()

                If sw_regreso <> 1 Then
                    ' No seleccionó -> ir a columna nombre
                    SafeSetCurrentCell(row, 1)
                    Exit Sub
                End If

                ' Puso un artículo (vec viene desde el form de consulta)
                Dim codigoSel As Integer = 0
                If Not Integer.TryParse(Convert.ToString(vec(0)), codigoSel) Then
                    MsgBox("Código de artículo inválido.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                ' validar repetido y stock (se pasa la fila actual)
                If Not validarDataGrid(codigoSel, row) Then Exit Sub

                ' rellenar
                SafeEnsureRowExists(row)
                DgvFac.Item(0, row).Value = codigoSel
                DgvFac.Item(0, row).ReadOnly = True
                DgvFac.Item(1, row).Value = vec(1)
                DgvFac.Item(2, row).Value = 1
                DgvFac.Item(3, row).Value = vec(2)
                DgvFac.Item(4, row).Value = vec(4)
                DgvFac.Item(5, row).Value = vec(3)
                recorrerDataGrid()
                MoverAFilaReal(row, 2) ' mover seguro a cantidad (col 2)

            Case 2, 3
                e.Handled = True
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    ' LOAD
    Private Sub FrmFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        usuNom.Text = "Usuario: " & usuNombres
        arrTxt = {txtId, txtNom, txtTel, txtCor}
        txtId.Focus()
        cambiarEstado(2)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    ' Buscar cliente por id
    Private Sub txtId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtId.KeyDown
        If e.KeyCode <> Keys.Enter Then Return
        If validarIdCliente(False) <> True Then Exit Sub

        Dim idnum As Long

        If Not Long.TryParse(txtId.Text, idnum) Then
            MsgBox("Identificación inválida", MsgBoxStyle.Exclamation)
            Exit Sub
        End If



        SQL = "SELECT cliCed, CONCAT_WS(' ', cliNom, cliApe), cliTel, cliEma, cliEst FROM cliente WHERE cliCed =" & CLng(idnum)
        rst = BaseDatos.leer_Registro(SQL)
        If rst.Read() = False Then
            If MsgBox("El cliente no existe." & vbCrLf & "¿Desea agregarlo?", MsgBoxStyle.YesNo, "Error") = vbYes Then
                FrmCliente.txtIdNum.Text = txtId.Text
                FrmCliente.FocusFactura = 1
                FrmCliente.ShowDialog()
                Exit Sub
            Else
                Exit Sub
            End If
        Else
            If rst("cliEst") = "BLOQUEADO" Then
                MsgBox("El cliente se encuentra bloqueado, no se puede registrar la factura", MsgBoxStyle.Critical)
                txtId.Text = ""
                Exit Sub
            End If
        End If

        limpiar(arrTxt, {btnAdd}, 0)
        buscar(SQL, arrTxt)
        clienteValido = CLng(txtId.Text)
    End Sub

    ' Recorrer datagrid para totales
    Sub recorrerDataGrid()
        dscoTotal = 0
        ivaTotal = 0
        total = 0

        For Each fila As DataGridViewRow In DgvFac.Rows
            If fila.IsNewRow Then Continue For

            ' Validar valores por fila
            Dim cantidad As Double = 0
            Dim precio As Double = 0
            Dim porcDesc As Double = 0
            Dim porcIva As Double = 0
            Dim subFila As Double = 0

            Double.TryParse(Convert.ToString(fila.Cells(2).Value), NumberStyles.Any, CultureInfo.CurrentCulture, cantidad)
            Double.TryParse(Convert.ToString(fila.Cells(3).Value), NumberStyles.Any, CultureInfo.CurrentCulture, precio)
            Double.TryParse(Convert.ToString(fila.Cells(4).Value), NumberStyles.Any, CultureInfo.CurrentCulture, porcDesc)
            Double.TryParse(Convert.ToString(fila.Cells(5).Value), NumberStyles.Any, CultureInfo.CurrentCulture, porcIva)

            subFila = Math.Round(precio * cantidad, 2)
            Dim valorDesc As Double = Math.Round(subFila * (porcDesc / 100), 2)
            Dim subConDesc As Double = subFila - valorDesc
            Dim valorIva As Double = Math.Round(subConDesc * (porcIva / 100), 2)
            Dim totalFila As Double = Math.Round(subConDesc + valorIva, 2)

            ' actualizar columna subtotal si está vacía o distinta
            fila.Cells(6).Value = totalFila

            dscoTotal += valorDesc
            ivaTotal += valorIva
            total += totalFila
        Next

        txtIva.Text = "$ " & ivaTotal.ToString("N2")
        txtDesc.Text = "$ " & dscoTotal.ToString("N2")
        txtTotal.Text = "$ " & total.ToString("N2")
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If (Not DgvFac.IsCurrentCellInEditMode) Then Return MyBase.ProcessCmdKey(msg, keyData)
        If (keyData <> Keys.Return) Then Return MyBase.ProcessCmdKey(msg, keyData)

        Dim cell As DataGridViewCell = DgvFac.CurrentCell
        Dim columnIndex As Int32 = cell.ColumnIndex
        Dim rowIndex As Int32 = cell.RowIndex

        DgvFac.CommitEdit(DataGridViewDataErrorContexts.Commit)
        DgvFac.EndEdit()

        If columnIndex = 0 Then
            ' validar codigo no vacío
            If Convert.ToString(DgvFac.Rows(rowIndex).Cells(0).Value).Trim() = "" Then
                MsgBox("Debe ingresar un codigo de articulo", MsgBoxStyle.Exclamation)
                Return True
            End If

            Dim codArt As Integer = 0
            If Not Integer.TryParse(Convert.ToString(DgvFac.Rows(rowIndex).Cells(0).Value), codArt) Then
                MsgBox("Código de artículo inválido", MsgBoxStyle.Exclamation)
                DgvFac.Rows(rowIndex).Cells(0).Value = ""
                Return True
            End If

            If Not validarDataGrid(codArt, rowIndex) Then Return True

            SQL = $"Select artId As ID, artNom As NOMBRE, precio As VALOR, artIva As IVA, artDescuento As 'DT(%)', stock FROM articulo WHERE artEst = 'A' AND artId = {codArt}"
            rst = BaseDatos.leer_Registro(SQL)
            If rst.Read() Then
                SafeEnsureRowExists(rowIndex)
                DgvFac.Rows(rowIndex).Cells(1).Value = rst("NOMBRE")
                DgvFac.Rows(rowIndex).Cells(2).Value = 1
                DgvFac.Rows(rowIndex).Cells(3).Value = rst("VALOR")
                DgvFac.Rows(rowIndex).Cells(4).Value = rst("DT(%)")
                DgvFac.Rows(rowIndex).Cells(5).Value = rst("IVA")
                DgvFac.CurrentCell = DgvFac.Rows(rowIndex).Cells(2)
                DgvFac.Rows(rowIndex).Cells(0).ReadOnly = True
                recorrerDataGrid()
                Return True
            Else
                If (MsgBox("El articulo no existe. ¿Desea buscarlo?", MsgBoxStyle.YesNo) = vbYes) Then
                    SendKeys.Send("{ENTER}")
                Else
                    DgvFac.Rows(rowIndex).Cells(0).Value = ""
                End If
            End If
        End If

        If columnIndex = 2 Then
            ' al ingresar cantidad recalcular fila y totales
            DgvFac.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DgvFac.EndEdit()

            ' validar codigo
            Dim codVal As Integer
            If Not Integer.TryParse(Convert.ToString(DgvFac.Rows(rowIndex).Cells(0).Value), codVal) Then
                MsgBox("Primero debe ingresar un artículo válido", MsgBoxStyle.Exclamation)
                Return True
            End If
            If Not validarDataGrid(codVal, rowIndex) Then Return True

            Dim cantidad As Double = 0
            Dim precio As Double = 0
            Dim porcDesc As Double = 0
            Dim porcIva As Double = 0

            Double.TryParse(Convert.ToString(DgvFac.Rows(rowIndex).Cells(2).Value), NumberStyles.Any, CultureInfo.CurrentCulture, cantidad)
            Double.TryParse(Convert.ToString(DgvFac.Rows(rowIndex).Cells(3).Value), NumberStyles.Any, CultureInfo.CurrentCulture, precio)
            Double.TryParse(Convert.ToString(DgvFac.Rows(rowIndex).Cells(4).Value), NumberStyles.Any, CultureInfo.CurrentCulture, porcDesc)
            Double.TryParse(Convert.ToString(DgvFac.Rows(rowIndex).Cells(5).Value), NumberStyles.Any, CultureInfo.CurrentCulture, porcIva)

            sbtCant = precio * cantidad
            dscto = sbtCant * (porcDesc / 100)
            prIva = (sbtCant - dscto) * (porcIva / 100)
            DgvFac.Rows(rowIndex).Cells(6).Value = Math.Round((sbtCant - dscto) + prIva, 2)

            recorrerDataGrid()

            ' mover a la siguiente fila real, columna 0 (si no existe, crearla)
            Dim siguiente As Integer = rowIndex + 1
            If siguiente > DgvFac.RowCount - 2 Then
                ' crear nueva fila real
                DgvFac.Rows.Add()
            End If
            SafeSetCurrentCell(siguiente, 0)

            Return True
        End If

        DgvFac.CurrentCell = cell
        Return True
    End Function

    ' validar id cliente
    Function validarIdCliente(tipoVal As Boolean) As Boolean
        If txtId.Text = "" Then
            MsgBox("Debe ingresar un cliente para registrar la factura", MsgBoxStyle.Exclamation)
            Return False
            'ElseIf Regex.IsMatch(txtId.Text, "^([0-9]+(\/{1}[0-9]+)*)+(?!([\/]{2}))$") = False Then
            '    MsgBox("Solo ingresar datos numericos", MsgBoxStyle.Critical)
            '    txtId.Text = ""
            '    Return False
        ElseIf clienteValido <> CLng(txtId.Text) And tipoVal = True Then
            txtId.Focus()
            SendKeys.Send("{ENTER}")
            Return False
        End If
        Return True
    End Function

    ' Registrar factura
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If validarIdCliente(True) <> True Then Exit Sub
            If DgvFac.RowCount < 2 Then MsgBox("Para registrar tiene que al menos tener un articulo en la cuadricula", MsgBoxStyle.Critical) : Exit Sub
            If MsgBox("¿Desea registrar la factura?" & vbCrLf & "Se eliminaran todas las filas que no esten diligenciadas de la cuadricula", MsgBoxStyle.YesNo Or MsgBoxStyle.Information, "Confirmar") = vbNo Then Exit Sub

            ' recalcular totales antes
            recorrerDataGrid()

            SQL = $"INSERT INTO factura (facFec,facTolIva, facTolDsc, facTol, cliCedFk, usuIdFk, facEst, facObs) VALUES
            (NOW(),
            {Convert.ToDouble(ivaTotal).ToString(CultureInfo.InvariantCulture)},
            {Convert.ToDouble(dscoTotal).ToString(CultureInfo.InvariantCulture)},
            {Convert.ToDouble(total).ToString(CultureInfo.InvariantCulture)},
            {txtId.Text},
            {codusuario},
            'REGISTRADO',
            '{txtObs.Text}');"

            eliminarFilasVacias()
            If BaseDatos.ingresar_registros(SQL, "registrar") Then
                rst = BaseDatos.leer_Registro("SELECT MAX(facId) FROM factura")
                If rst.Read() Then idFactura = rst(0)

                For Each fila As DataGridViewRow In DgvFac.Rows
                    If fila.IsNewRow Then Continue For
                    Try
                        Dim artId As Integer = CInt(fila.Cells(0).Value)
                        Dim artPre As String = Convert.ToDouble(fila.Cells(3).Value).ToString(CultureInfo.InvariantCulture)
                        Dim detCant As Integer = CInt(fila.Cells(2).Value)
                        Dim detDesc As String = Convert.ToDouble(fila.Cells(4).Value).ToString(CultureInfo.InvariantCulture)
                        Dim detIva As String = Convert.ToDouble(fila.Cells(5).Value).ToString(CultureInfo.InvariantCulture)
                        Dim detSub As String = Convert.ToDouble(fila.Cells(6).Value).ToString(CultureInfo.InvariantCulture)

                        SQL = $"INSERT INTO detFac (facIdFk, artIdFk, artPre, detCant, detDesc, detIva,detSub) VALUES
                        ({idFactura}, {artId}, {artPre}, {detCant}, {detDesc}, {detIva}, {detSub});"
                        BaseDatos.ingresar_registros(SQL, "registrar")
                    Catch ex As Exception
                        MsgBox("Error guardando línea: " & ex.Message)
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
        For i As Integer = DgvFac.Rows.Count - 1 To 0 Step -1
            Dim fila = DgvFac.Rows(i)
            If fila.IsNewRow Then Continue For
            If fila.Cells(0).Value Is Nothing Then
                DgvFac.Rows.RemoveAt(i) : Continue For
            End If
            If fila.Cells(0).Value.ToString().Trim() = "" Then
                DgvFac.Rows.RemoveAt(i)
            End If
        Next
        Return True
    End Function

    ' validar DataGrid 
    Function validarDataGrid(codArt As Integer, filaActual As Integer) As Boolean
        For i As Integer = 0 To DgvFac.RowCount - 1
            If DgvFac.Rows(i).IsNewRow Then Continue For
            If i = filaActual Then Continue For

            Dim cellVal = DgvFac.Rows(i).Cells(0).Value
            If cellVal IsNot Nothing AndAlso Convert.ToString(cellVal).Trim() <> "" Then
                Dim v As Integer
                If Integer.TryParse(Convert.ToString(cellVal), v) AndAlso v = codArt Then
                    MsgBox("El articulo ya fue ingresado en la factura")
                    DgvFac.Rows(filaActual).Cells(0).Value = ""
                    SafeSetCurrentCell(filaActual, 0)
                    Return False
                End If
            End If
        Next

        ' verificar stock para la fila actual (si hay cantidad)
        rst = BaseDatos.leer_Registro($"SELECT stock FROM articulo WHERE artId = {codArt}")
        If rst.Read() Then
            canCod = rst(0)
            Dim cantAct As Double = 0
            Double.TryParse(Convert.ToString(DgvFac.Rows(filaActual).Cells(2).Value), NumberStyles.Any, CultureInfo.CurrentCulture, cantAct)
            If cantAct > canCod Then
                MsgBox("La cantidad solicitada supera el stock disponible: " & canCod)
                DgvFac.Rows(filaActual).Cells(2).Value = 0
                SafeSetCurrentCell(filaActual, 2)
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub DgvFac_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvFac.EditingControlShowing

        If TypeOf e.Control Is TextBox Then

            Dim txt As TextBox = CType(e.Control, TextBox)

            'Eliminar cualquier controlador anterior para evita duplicación
            RemoveHandler txt.KeyPress, AddressOf validarSoloNumeros

            'Activar solo si está editando las columnas 0 = Cod o 2 = Cant
            If DgvFac.CurrentCell.ColumnIndex = 0 Or
           DgvFac.CurrentCell.ColumnIndex = 2 Then

                AddHandler txt.KeyPress, AddressOf validarSoloNumeros

            End If

        End If

    End Sub

    Private Sub validarSoloNumeros(sender As Object, e As KeyPressEventArgs)
        ' Permitir solo números y tecla Backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub


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

    'Private Sub FrmFactura_Closed(sender As Object, e As EventArgs) Handles Me.Closed
    '    seleccionar.Show()
    'End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        limpiarFactura()
    End Sub

    Private Sub MoverAFilaReal(filaActual As Integer, columnaDestino As Integer)
        Dim fila As Integer = filaActual
        If fila < 0 Then fila = 0
        If DgvFac.Rows.Count = 0 Then Return
        If fila >= DgvFac.RowCount Then fila = DgvFac.RowCount - 1

        If DgvFac.Rows(fila).IsNewRow Then
            fila -= 1
        End If
        If fila < 0 Then fila = 0
        If fila > DgvFac.RowCount - 2 Then fila = Math.Max(0, DgvFac.RowCount - 2)

        SafeSetCurrentCell(fila, columnaDestino)
    End Sub

    Private Sub SafeSetCurrentCell(fila As Integer, col As Integer)
        Try
            If fila < 0 OrElse col < 0 Then Return
            If fila > DgvFac.RowCount - 1 Then Return
            If col > DgvFac.ColumnCount - 1 Then Return
            If DgvFac.Rows(fila).IsNewRow Then
                ' si es la fila nueva y pedimos ir ahi, crea una fila real antes
                If fila = DgvFac.RowCount - 1 Then
                    DgvFac.Rows.Add()
                End If
            End If
            DgvFac.CurrentCell = DgvFac.Rows(fila).Cells(col)
        Catch ex As Exception
            MsgBox("Error navegando: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub SafeEnsureRowExists(fila As Integer)
        If fila < 0 Then Return
        If fila > DgvFac.RowCount - 2 Then
            ' agregar filas hasta tener la fila requerida
            Do While DgvFac.RowCount - 2 < fila
                DgvFac.Rows.Add()
            Loop
        End If
    End Sub

    Private Function ConvertToDisplayDecimal(obj As Object) As String
        Try
            Dim d As Double
            If Double.TryParse(Convert.ToString(obj), NumberStyles.Any, CultureInfo.InvariantCulture, d) Then
                ' mostrar según cultura local con 2 decimales
                Return d.ToString("N0", CultureInfo.CurrentCulture)
            ElseIf Double.TryParse(Convert.ToString(obj), NumberStyles.Any, CultureInfo.CurrentCulture, d) Then
                Return d.ToString("N0", CultureInfo.CurrentCulture)
            End If
        Catch ex As Exception
        End Try
        Return "0,00"
    End Function

    Private Sub FrmFactura_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        limpiarFactura()
    End Sub

    Private Sub txtIdNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtId.KeyPress
        ' Solo permitir números, espacios y Enter
        If Not Char.IsDigit(e.KeyChar) AndAlso
       e.KeyChar <> ControlChars.Back AndAlso
       e.KeyChar <> ControlChars.Cr Then

            e.Handled = True
            MsgBox("Solo se permiten números")
            Exit Sub
        End If

        ' Limitar a 15 caracteres
        If txtId.Text.Length > 10 AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
            Exit Sub
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        FrmConsulta2.Text = "Buscar de cliente"
        FrmConsulta2.grd.DataSource = Nothing

        SQL = "
SELECT 
    cliCed AS Cedula,
    cliNom AS Nombres,
    cliApe AS Apellidos,
    cliEma AS Correo,
    cliTel AS Telefono
FROM cliente
WHERE cliEst = 'ACTIVO'
"

        FrmConsulta2.bind.DataSource = BaseDatos.Listar_datos(SQL)
        FrmConsulta2.grd.DataSource = FrmConsulta2.bind.DataSource

        FrmConsulta2.grd.RowTemplate.Height = 17
        FrmConsulta2.Size = New Size(600, 320)
        FrmConsulta2.grd.Size = New Size(565, 200)

        For Each ctrl In FrmConsulta2.grd.Columns
            ctrl.ReadOnly = True
        Next

        FrmConsulta2.ShowDialog()

        If sw_regreso = 1 Then
            txtId.Text = vec(0)
            txtId.Focus()
            SendKeys.Send("{ENTER}")
        End If

    End Sub
End Class
