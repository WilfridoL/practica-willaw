Module consultaComponent
    Public Function mostrarDataGridView(SQL As String, titulo As String, foco As Control) As Integer
        Dim frmConsulta2 As New FrmConsulta2
        Dim autoWithCells As Integer = 0
        frmConsulta2.Text = titulo
        frmConsulta2.grd.DataSource = Nothing

        frmConsulta2.bind.DataSource = BaseDatos.Listar_datos(SQL)
        frmConsulta2.grd.DataSource = frmConsulta2.bind.DataSource

        frmConsulta2.grd.RowTemplate.Height = 17
        maxWidthColumn(frmConsulta2.grd)
        frmConsulta2.Size = New Size(frmConsulta2.grd.Size.Width + 45, 320)
        'frmConsulta2.grd.Size = New Size(660, 200)
        frmConsulta2.txtFiltro.Size = New Size(frmConsulta2.grd.Size.Width - frmConsulta2.cbbFiltro.Size.Width - 6, 24)
        frmConsulta2.grd.Columns(0).Width.ToString()
        frmConsulta2.ShowDialog()

        'MsgBox(SQL)
        'MsgBox(titulo)
        'MsgBox(foco.Name)
        If sw_regreso = 1 Then
            valDataGrid = vec(0)
        Else Exit Function
        End If
    End Function

    Private Function maxWidthColumn(element As DataGridView)
        Dim maxWidthDgv As Integer = 0
        Dim config As New List(Of contrutorColumnAutoSize)
        config = rellenarLista(element)
        For Each e As DataGridViewRow In element.Rows
            For i As Integer = 0 To element.ColumnCount - 1
                If config(i).columnNum = i Then
                    If e.Cells(i).Value.ToString().Length > config(i).columnSize Then
                        config(i).columnSize = e.Cells(i).Value.ToString().Length
                    End If
                End If
            Next
        Next
        For Each c In config
            If c.columnSize < 4 Then c.columnSize = c.columnSize * 2
            If c.columnSize > 18 Then c.columnSize = 15
            element.Columns(c.columnNum).Width = c.columnSize * 10
            maxWidthDgv += (c.columnSize * 10)
        Next
        element.Size = New Size(maxWidthDgv + 60, 220)
    End Function

    Function rellenarLista(dgv As DataGridView) As List(Of contrutorColumnAutoSize)
        Dim columnas As New List(Of contrutorColumnAutoSize)
        For Each col As DataGridViewColumn In dgv.Columns

            columnas.Add(New contrutorColumnAutoSize With {
                .columnNum = col.Index,
                .columnSize = 0
        })
        Next

        Return columnas


    End Function

End Module
Class contrutorColumnAutoSize
    Public columnNum As Integer
    Public columnSize As Integer
End Class

