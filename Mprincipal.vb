Imports System.Reflection

Module Mprincipal
    Public SQL As String
    Public rst As Odbc.OdbcDataReader
    Public codusuario As String
    Public CedCli As String
    Public sw_regreso As Integer = 0
    Public c_Varias As New Varias
    Public vec() As String
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
