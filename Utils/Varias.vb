Imports System.Runtime.InteropServices.JavaScript.JSType

Public Class Varias
    Public Sub llena_combo(ByVal cmb As ComboBox, ByVal sql As String, ByVal cod As String, ByVal nombre As String)
        Try
            cmb.DataSource = BaseDatos.Listar_datos(sql)
            With cmb
                .ValueMember = cod
                .DisplayMember = nombre
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("No se encontraron Registros Asociados a la Selección Anterior")
        End Try
    End Sub
    '
    Public Sub cargar_combo_filtro(ByVal frm As Form, ByVal cmd As ComboBox, ByVal grd As DataGridView)
        cmd.Items.Clear()
        cmd.Text = ""
        For i As Integer = 0 To grd.Columns.Count - 1
            If grd.Columns(i).Visible = True Then
                cmd.Items.Add(grd.Columns(i).HeaderText) ' rellena el combobox con los nombres de las columnas del grd
            End If
        Next
    End Sub
    Public Sub filtrar(ByVal bind As Object, txt As TextBox, ByVal combo As String, ByVal grd As DataGridView)
        If txt.Text <> "" Then ' si txt es diferente a una cadena vacia
            Try
                ' si el valor del combo es de tipo string
                If (grd.Columns(combo).ValueType Is GetType(String) Or
                    grd.Columns(combo).ValueType Is GetType(System.String)) Then
                    bind.Filter = String.Format(" {0} LIKE '%{1}%' ", combo, txt.Text)
                    grd.DataSource = bind.dataSource
                Else
                    ' si el valor del combo es de tipo date
                    If (grd.Columns(combo).ValueType Is GetType(Date)) Then
                        bind.Filter = String.Format(" {0} = '{1}' ", combo, txt.Text)
                        grd.DataSource = bind.dataSource
                    Else
                        ' si el valor del combo es de tipo numerico (int)
                        If (grd.Columns(combo).ValueType Is GetType(Integer) Or
                        grd.Columns(combo).ValueType Is GetType(System.Int16) Or
                        grd.Columns(combo).ValueType Is GetType(System.Int32) Or
                        grd.Columns(combo).ValueType Is GetType(System.Int64)) Then
                            bind.Filter = String.Format(" {0} = {1} ", combo, txt.Text)
                            grd.DataSource = bind.dataSource
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox("Parametro de busqueda incorrecto. " & ex.Message)
                txt.Clear()
            End Try
        Else
            bind.RemoveFilter()
        End If
    End Sub

    Public Sub tab()
        SendKeys.Send("{TAB}")
    End Sub
End Class
