Imports System.Data.Odbc
Imports System.Diagnostics.Contracts
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
    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        conexion = New OdbcConnection("dsn=data;uid=root;pwd=;")
        conexion.Open()
        CargarUsuarios()
    End Sub
    Public Sub CargarUsuarios()
        SQL = "SELECT usuId AS ID, nombre, apellido, correo, contraseña, rol FROM tb_usuarios  "
        Dim da As New OdbcDataAdapter(SQL, conexion)
        Dim dt As New DataTable
        'MsgBox(da)
        da.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub
    Public Function SeleccionarDatos(ByVal sql As String, ByVal mensaje As String) As Boolean
        Try
            BaseDatos.ingresar_registros(sql, mensaje)
            CargarUsuarios()
            MessageBox.Show("Usuario " & mensaje & " correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Catch ex As Exception
            MessageBox.Show("Error al " & mensaje & " el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function
    Private Sub btnRegPri_Click(sender As Object, e As EventArgs) Handles btnRegPri.Click
        FrmRegistrar.Show()
    End Sub
    Public Function obtenerIdUsuario() As Integer
        If DataGridView1.SelectedRows.Count > 0 Then
            Return CInt(DataGridView1.SelectedRows(0).Cells("ID").Value)
        Else
            Return -1
        End If
    End Function
    Private Sub btnActPri_Click(sender As Object, e As EventArgs) Handles btnActPri.Click
        FrmActualizar.Show()
    End Sub

    Private Sub btnEliPri_Click(sender As Object, e As EventArgs) Handles btnEliPri.Click
        SQL = "DELETE FROM tb_usuarios WHERE usuid = " & CInt(DataGridView1.SelectedRows(0).Cells("ID").Value)
        SeleccionarDatos(SQL, "eliminó")
    End Sub

    Private Sub btnCerSes_Click(sender As Object, e As EventArgs) Handles btnCerSes.Click
        Frm_login.Show()
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'MsgBox(e.RowIndex)
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            FrmActualizar.txtNomAct.Text = row.Cells(1).Value.ToString()
            FrmActualizar.txtApeAct.Text = row.Cells(2).Value.ToString()
            FrmActualizar.txtCorActu.Text = row.Cells(3).Value.ToString()
            FrmActualizar.txtConAct.Text = row.Cells(4).Value.ToString()
            FrmActualizar.txtRolActu.SelectedItem = row.Cells(5).Value.ToString()
        End If
    End Sub
End Class
