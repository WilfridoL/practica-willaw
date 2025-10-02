Imports System.Data.Odbc
Imports System.Diagnostics.Contracts
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ApplicationServices

Public Class frmConsulta
    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DgvConsulta.DoubleClick
        CedCli = (DgvConsulta.Item(0, DgvConsulta.CurrentCell.RowIndex).Value)
        sw_regreso = 1
        Me.Close()
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvConsulta.KeyDown
        Select Case (e.KeyCode)
            Case 13
                CedCli = (DgvConsulta.Item(0, DgvConsulta.CurrentCell.RowIndex).Value)
                sw_regreso = 1
                Me.Close()
            Case 27
                sw_regreso = 0
                Me.Close()
        End Select
    End Sub
End Class
