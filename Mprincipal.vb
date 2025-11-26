Imports System.Reflection
Imports System.Text.RegularExpressions

Module Mprincipal
    Public SQL As String
    Public rst As Odbc.OdbcDataReader
    Public codusuario As String
    Public usuContra As String
    Public usuNombres As String
    Public CedCli As String
    Public sw_regreso As Integer = 0
    Public c_Varias As New Varias
    Public vec() As String
    'And Regex.IsMatch(arrTxt(i).Text, "[^\w]") = True
    Function controlObservaciones(ByVal SQL As String) As Boolean
        If FrmUsuario.txtEstUsu.SelectedValue <> 1 Then
            'MsgBox(SQL)
            BaseDatos.ingresar_registros(SQL, "manipulacion obs")
            Return True
        Else
            Return False
        End If
    End Function

    Function cargar_combobox(sql, combo, id, name)
        c_Varias.llena_combo(combo, sql, id, name)
        Return True
    End Function

    Public Function limpiar(campos() As Control, btn() As ToolStripButton, tip As Integer)
        For i As Integer = 0 To campos.Length - 1
            If TypeOf campos(i) Is TextBox Or TypeOf campos(i) Is RichTextBox Then
                campos(i).Text = ""
            ElseIf TypeOf campos(i) Is ComboBox Then
                CType(campos(i), ComboBox).SelectedValue = 0
            End If
        Next

        If tip = 1 Then
            For j As Integer = 0 To btn.Length - 1
                If btn(j).Enabled = True Then
                    btn(j).Enabled = False
                Else
                    btn(j).Enabled = True
                End If
            Next
        End If
        Return True
    End Function

    Public Function buscar(sql As String, campos() As Control)
        rst = BaseDatos.leer_Registro(sql)
        If rst.Read() Then
            For i As Integer = 0 To campos.Length - 1
                If TypeOf campos(i) Is TextBox Or TypeOf campos(i) Is RichTextBox Or TypeOf campos(i) Is Label Then
                    campos(i).Text = rst(i)
                ElseIf TypeOf campos(i) Is ComboBox Then
                    CType(campos(i), ComboBox).SelectedValue = rst(i)
                End If
            Next
            Return True
        Else
            ' msjErr.Text = "No se encontro"
            Return False
        End If
    End Function

    Public Function cambiarColor(resultado As Boolean, label As Label)
        If resultado = False Then
            label.ForeColor = Color.Red
        Else
            label.ForeColor = Color.Black
        End If
    End Function

    Public Function validacionGlobal(arrTxt() As Control, arrLabel() As Label, msjErr As ToolStripStatusLabel, sql As String) As Boolean
        For i As Integer = 0 To arrTxt.Length - 1
            If TypeOf arrTxt(i) Is TextBox Then
                If arrTxt(i).Text = "" Then ' campo obligatorio
                    msjErr.Text = "El campo " & arrLabel(i).Text & " es obligatorio"
                    arrTxt(i).Focus()
                    cambiarColor(False, arrLabel(i))
                    Return False
                ElseIf arrTxt(i).Name.Substring(arrTxt(i).Name.Length - 3).ToLower() = "num" And
                    Regex.IsMatch(arrTxt(i).Text, "^([0-9]+(\/{1}[0-9]+)*)+(?!([\/]{2}))$") = False Then ' no permite letras y simbolos solo numeros
                    msjErr.Text = $"El campo {arrLabel(i).Text} no tiene que tener letras ni simbolos"
                    arrTxt(i).Focus()
                    cambiarColor(False, arrLabel(i))
                    Return False
                    'ElseIf arrTxt(i).Name.Substring(3, 2).ToLower = "id" Then ' problemas con este bloque de codigo
                    '    rst = BaseDatos.leer_Registro(sql)
                    '    If rst.Read() Then
                    '        If rst(0) = arrTxt(i).Text Then
                    '            msjErr.Text = "La identificacion ya existe, por favor ingrese uno diferentes"
                    '            arrTxt(i).Focus()
                    'cambiarColor(False, arrTxt(i), arrLabel(i)) 
                    '        Return False
                    '    End If
                    'End If
                ElseIf Regex.IsMatch(arrTxt(i).Text, "^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$") = False And
                    arrTxt(i).Name.Substring(arrTxt(i).Name.Length - 3).ToLower() = "ema" Then ' valida formato de correo
                    msjErr.Text = "Digite un correo valido"
                    arrTxt(i).Focus()
                    cambiarColor(False, arrLabel(i))
                    Return False
                ElseIf Regex.IsMatch(arrTxt(i).Text, "^[A-Za-z0-9\-\+\(\)\s]+$") = False And
                arrTxt(i).Name.Substring(arrTxt(i).Name.Length - 3).ToLower() = "tel" Then ' valida formato de correo
                    msjErr.Text = "Digite un numero de teléfono valido"
                    arrTxt(i).Focus()
                    cambiarColor(False, arrLabel(i))
                    Return False
                Else
                    cambiarColor(True, arrLabel(i))
                End If
            ElseIf TypeOf arrTxt(i) Is ComboBox Then
                If CType(arrTxt(i), ComboBox).SelectedValue = 0 Then
                    msjErr.Text = "Seleccione una opcion en el campo " & arrLabel(i).Text
                    arrTxt(i).Focus()
                    cambiarColor(False, arrLabel(i))

                    Return False
                Else
                    cambiarColor(True, arrLabel(i))
                    Return True
                End If
            End If
        Next
    End Function

    ' Public Function mostrarDataGridView(SQL1 As String, SQL2 As String, txtTitle As String, )
    'Dim btnArr() As Control = {btnAdd, btnUpd, btnDel}
    '    frmConsulta.Text = txtTitle
    '   frmConsulta.DgvConsulta.DataSource = ""
    '  frmConsulta.DgvConsulta.RowTemplate.Height = 17
    ' frmConsulta.DgvConsulta.DataSource = BaseDatos.Listar_datos(SQL1)
    'frmConsulta.ShowDialog()
    'If sw_regreso = 1 Then
    '       txtId.Text = CedCli
    'MsgBox(txtboxArr)
    '      limpiar(txtboxArr, btnArr)
    '     buscar(SQL2 & CedCli, txtboxArr)
    '    SendKeys.Send("{ENTER}")
    'End If
    'End Function
End Module
