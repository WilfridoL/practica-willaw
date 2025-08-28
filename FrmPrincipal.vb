Imports System.Data.Odbc
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ApplicationServices

Public Class FrmPrincipal
    Public Shared conexion As Odbc.OdbcConnection

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub


    Private m_ChildFormNumber As Integer

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        FrmNotas.Show()
        Me.Visible = False
    End Sub

    Private Sub btnRegistro_Click(sender As Object, e As EventArgs) Handles btnRegistro.Click
        FrmRegistrar.Show()
    End Sub

    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        BaseDatos.obtenerDatos("root", "")
        MsgBox(BaseDatos.obtenerDatos("root", ""))
        CargarUsuarios()
    End Sub
    Private Sub CargarUsuarios()
        Dim da As New OdbcDataAdapter("SELECT nombre FROM tb_usuarios", conexion)
        Dim dt As New DataTable
        'MsgBox(da)
        da.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub
End Class
