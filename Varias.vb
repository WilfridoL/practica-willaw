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

End Class
