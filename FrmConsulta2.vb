Imports System.ComponentModel

Public Class FrmConsulta2

    Dim n_col As String
    ' vec, bind y sw_regreso están declarados en el módulo principal
    ' Igual que c_Varias y BaseDatos

    ' ──────────────────────────────────────────────────────────────
    '  DOBLE CLICK EN LA GRILLA
    ' ──────────────────────────────────────────────────────────────
    Private Sub grd_DoubleClick(sender As Object, e As EventArgs) Handles grd.DoubleClick
        ReDim vec(grd.Columns.Count)

        For i As Integer = 0 To grd.Columns.Count - 1
            Dim valor = grd.Item(i, grd.CurrentCell.RowIndex).Value
            vec(i) = If(IsDBNull(valor), "", valor)
        Next

        bind.DataSource = Nothing
        sw_regreso = 1
        Me.Close()
    End Sub

    ' ──────────────────────────────────────────────────────────────
    '  AL CERRAR EL FORMULARIO
    ' ──────────────────────────────────────────────────────────────
    Private Sub FrmConsulta2_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        bind.RemoveFilter()
    End Sub

    ' ──────────────────────────────────────────────────────────────
    '  EVENTO LOAD
    ' ──────────────────────────────────────────────────────────────
    Private Sub FrmConsulta2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        c_Varias.cargar_combo_filtro(Me, cbbFiltro, grd)
        sw_regreso = 0
    End Sub

    ' ──────────────────────────────────────────────────────────────
    '  CAMBIO DE FILTRO (ComboBox)
    ' ──────────────────────────────────────────────────────────────
    Private Sub cbbFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbFiltro.SelectedIndexChanged
        n_col = cbbFiltro.Text
        c_Varias.tab()
    End Sub

    ' ──────────────────────────────────────────────────────────────
    '  FILTRAR MIENTRAS SE ESCRIBE
    ' ──────────────────────────────────────────────────────────────
    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        c_Varias.filtrar(bind, txtFiltro, n_col, grd)
    End Sub

    ' ──────────────────────────────────────────────────────────────
    '  KEYDOWN GENERAL DEL FORMULARIO
    ' ──────────────────────────────────────────────────────────────
    Private Sub FrmConsulta2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                sw_regreso = 1
                Close()

            Case Keys.Enter
                e.Handled = True  ' evita pitar
        End Select
    End Sub

    ' ──────────────────────────────────────────────────────────────
    '  ENTER EN LA GRILLA (copiar fila anterior)
    ' ──────────────────────────────────────────────────────────────
    Private Sub grd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grd.KeyPress
        If Asc(e.KeyChar) = 13 Then ' ENTER
            Try
                ReDim vec(grd.Columns.Count)

                For i As Integer = 0 To grd.Columns.Count - 1
                    Dim valor = grd.Item(i, grd.CurrentCell.RowIndex - 1).Value
                    vec(i) = If(IsDBNull(valor), "", valor)
                Next

                bind.DataSource = Nothing
                sw_regreso = 1
                Me.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    ' ──────────────────────────────────────────────────────────────
    '  ESCAPE EN LA GRILLA
    ' ──────────────────────────────────────────────────────────────
    Private Sub grd_KeyDown(sender As Object, e As KeyEventArgs) Handles grd.KeyDown
        If e.KeyCode = Keys.Escape Then
            sw_regreso = 0
            Me.Close()
        End If
    End Sub

End Class
