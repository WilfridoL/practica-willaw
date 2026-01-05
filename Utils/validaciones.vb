Imports System.Reflection.Metadata.Ecma335
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
        For Each ctrl As Control In arrTxt
            If TypeOf ctrl Is TextBox Then
                If ctrl.Text = "" Then
                    ctrl.Focus()
                    Return False
                    'ElseIf Regex.IsMatch(ctrl.Text, "^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$") = False And
                    '    ctrl.Name.Substring(ctrl.Name.Length - 3).ToLower() = "ema" Then ' valida formato de correo
                    '    msjErr.Text = "Digite un correo valido"
                    '    ctrl.Focus()
                    '    Return False
                Else Return True
                End If
            End If
            If TypeOf ctrl Is ComboBox Then
                'MsgBox("a")
                If CType(ctrl, ComboBox).SelectedValue = 0 Then
                    ctrl.Focus()
                    Return False
                Else
                    Return True
                End If
            End If
        Next
        'For i As Integer = 0 To arrTxt.Length - 1
        '    If TypeOf ctrl Is TextBox Then
        '        If ctrl.Text = "" Then ' campo obligatorio
        '        ElseIf ctrl.Name.Substring(ctrl.Name.Length - 3).ToLower() = "num" And
        '            Regex.IsMatch(ctrl.Text, "^([0-9]+(\/{1}[0-9]+)*)+(?!([\/]{2}))$") = False Then ' no permite letras y simbolos solo numeros
        '            msjErr.Text = $"El campo {arrLabel(i).Text} no tiene que tener letras ni simbolos"
        '            ctrl.Focus()
        '            cambiarColor(False, arrLabel(i))
        '            Return False
        '        ElseIf Regex.IsMatch(ctrl.Text, "^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$") = False And
        '            ctrl.Name.Substring(ctrl.Name.Length - 3).ToLower() = "ema" Then ' valida formato de correo
        '            msjErr.Text = "Digite un correo valido"
        '            ctrl.Focus()
        '            cambiarColor(False, arrLabel(i))
        '            Return False
        '            'ElseIf Regex.IsMatch(ctrl.Text, "[^0-9\-\+\(\)\s]") = False And
        '            'ctrl.Name.Substring(ctrl.Name.Length - 3).ToLower() = "tel" Then ' valida formato de correo
        '            '    msjErr.Text = "Digite un numero de teléfono valido"
        '            '    ctrl.Focus()
        '            '    cambiarColor(False, arrLabel(i))
        '            '    Return False
        '        Else
        '            cambiarColor(True, arrLabel(i))
        '        End If
        '    ElseIf TypeOf ctrl Is ComboBox Then
        '        If CType(ctrl, ComboBox).SelectedValue = 0 Then
        '            msjErr.Text = "Seleccione una opcion en el campo " & arrLabel(i).Text
        '            ctrl.Focus()
        '            cambiarColor(False, arrLabel(i))

        '            Return False
        '        Else
        '            cambiarColor(True, arrLabel(i))
        '            Return True
        '        End If
        '    End If
        '    MsgBox(ctrl.Name)

        'Next
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
