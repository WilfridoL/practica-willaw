Imports System.ComponentModel

Public Class FrmConsulta2
    Dim n_col As String
    'c_varias esta declardo en el modulo Mprincipal

    Private Sub grd_DoubleClick(sender As Object, e As EventArgs) Handles grd.DoubleClick
        ReDim vec(grd.Columns.Count) ' cantidad de columnas del datagrid
        For i As Integer = 0 To grd.Columns.Count - 1
            ' si el valor es null el resultado sera una cadena vacia
            vec(i) = IIf(IsDBNull(grd.Item(i, grd.CurrentCell.RowIndex).Value), "", grd.Item(i, grd.CurrentCell.RowIndex).Value) ' guardar el valor de las celdas en vec
        Next
        bind.DataSource = ""
        sw_regreso = 1
        Me.Close()
    End Sub

    ' cuando se cierre el programa elimine los filtro
    Private Sub FrmConsulta2_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        bind.RemoveFilter()
    End Sub

    Private Sub FrmConsulta2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                sw_regreso = 1
                Close()
            Case Keys.Enter
                e.Handled = True
        End Select
    End Sub
    Private Sub temp_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        c_Varias.cargar_combo_filtro(Me, cbbFiltro, grd)
        sw_regreso = 0
    End Sub

    Private Sub cbbFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbFiltro.SelectedIndexChanged
        n_col = cbbFiltro.Text
        c_Varias.tab()
    End Sub

    ' Cuando se cambie el contenido del texbox
    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        c_Varias.filtrar(bind, txtFiltro, n_col, grd)
    End Sub

    Private Sub grd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grd.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Try
                ReDim vec(grd.Columns.Count)
                For i As Integer = 0 To grd.Columns.Count - 1
                    ' si el valor es null guardara una cadena vacia si no
                    ' copiara los valores de la fila anterior a la actual
                    vec(i) = IIf(IsDBNull(grd.Item(i, grd.CurrentCell.RowIndex - 1).Value), "", grd.Item(i, grd.CurrentCell.RowIndex - 1).Value)
                Next
                bind.DataSource = ""
                sw_regreso = 1
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub grd_KeyDown(sender As Object, e As KeyEventArgs) Handles grd.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                sw_regreso = 0
                Me.Close()
        End Select
    End Sub

End Class