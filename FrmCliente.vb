Public Class FrmCliente
    Dim c_Varias As New Varias

    Public Function limpiar()
        'txtIdCli.Text = ""
        txtNomCli.Text = ""
        txtApeCli.Text = ""
        txtCorCli.Text = ""
        txtTelCli.Text = ""
        btnAdd.Enabled = True
        btnDel.Enabled = False
        btnUpd.Enabled = False
    End Function
    Private Sub FrmCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIdCli.Focus()
        BaseDatos.conectar("root", "")
        SQL = "SELECT * FROM departamentos;"
        c_Varias.llena_combo(txtDepa, SQL, "DepId", "DepNom")
    End Sub

    Public Function BuscarCliario()
        SQL = "SELECT * FROM cliente WHERE cliCed=" & txtIdCli.Text
        MsgBox(SQL)
        rst = BaseDatos.leer_Registro(SQL)
        If txtIdCli.Text = "" Then
            msjErr.Text = "Por Favor ingresar identificacion para hacer la busqueda"
        ElseIf BaseDatos.leer_Registro(SQL).Read() Then
            limpiar()
            txtNomCli.Text = rst("cliNom")
            txtApeCli.Text = rst("cliApe")
            txtCorCli.Text = rst("cliEma")
            txtTelCli.Text = rst("cliTel")
            btnAdd.Enabled = False
            btnDel.Enabled = True
            btnUpd.Enabled = True
        Else
            msjErr.Text = "Cliente no existe en la base de datos"
        End If
        Return True
    End Function

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        SQL = "INSERT cliente (cliCed, cliNom, cliApe, cliEma, cliTel) 
        VALUE (" & txtIdCli.Text & ", '" & txtNomCli.Text.ToUpper & "', '" & txtApeCli.Text.ToUpper & "', '" & txtCorCli.Text & "', " & txtTelCli.Text & ");"
        MsgBox(SQL)
        If BaseDatos.ingresar_registros(SQL, "registrar") Then
            limpiar()
            msjErr.Text = "datos ingresados"
        Else
            MsgBox("error")
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles btnLim.Click
        limpiar()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        SQL = "DELETE FROM cliente WHERE cliCed=" & txtIdCli.Text
        If BaseDatos.ingresar_registros(SQL, "Eliminar") Then
            limpiar()
            msjErr.Text = "datos eliminados"
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        SQL = "UPDATE cliente SET " &
       "clinom = '" & txtNomCli.Text & "', " &
       "cliape = '" & txtApeCli.Text & "', " &
       "cliEma = '" & txtCorCli.Text & "', " &
       "cliTel = " & txtTelCli.Text & " " &
       "WHERE cliCed = " & txtIdCli.Text
        ' MsgBox(SQL)
        If BaseDatos.ingresar_registros(SQL, "actualizar") Then
            limpiar()
            msjErr.Text = "Datos actualizados"
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles btnSal.Click
        seleccionar.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BuscarCliario()
    End Sub

    Private Sub txtIdCli_TextChanged(sender As Object, e As KeyEventArgs) Handles txtIdCli.KeyDown
        If e.KeyCode = Keys.Enter Then
            BuscarCliario()
        End If
    End Sub

    Private Sub txtDepa_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles txtDepa.SelectionChangeCommitted
        SQL = "Select * FROM municipios WHERE depIdFk=" & txtDepa.SelectedValue
        c_Varias.llena_combo(txtMun, SQL, "munId", "munNom")
    End Sub
End Class