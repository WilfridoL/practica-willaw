Imports System.Text.RegularExpressions

Module validaciones
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
                    'ElseIf Regex.IsMatch(arrTxt(i).Text, "[^0-9\-\+\(\)\s]") = False And
                    'arrTxt(i).Name.Substring(arrTxt(i).Name.Length - 3).ToLower() = "tel" Then ' valida formato de correo
                    '    msjErr.Text = "Digite un numero de teléfono valido"
                    '    arrTxt(i).Focus()
                    '    cambiarColor(False, arrLabel(i))
                    '    Return False
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


    Function validarPorcentaje(ctrl As TextBox, msjerr As ToolStripStatusLabel) As Boolean
        Dim valor As Integer

        ' Campo vacío
        If ctrl.Text.Trim() = "" Then
            msjerr.Text = $"El campo {ctrl.Name} no puede estar vacío"
            ctrl.Focus()
            Return False
        End If

        ' No es número
        If Integer.TryParse(ctrl.Text, valor) = False Then
            msjerr.Text = $"El campo {ctrl.Name} solo permite números enteros"
            ctrl.Focus()
            Return False
        End If

        ' Rango válido
        If valor < 0 Or valor > 100 Then
            msjerr.Text = $"El valor  debe estar entre 0 y 100"
            ctrl.Focus()
            Return False
        End If

        Return True
    End Function

End Module
