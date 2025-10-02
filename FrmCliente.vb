Public Class FrmCliente
    Dim c_Varias As New Varias

    Public Function limpiar()
        'txtIdCli.Text = ""
        txtNomCli.Text = ""
        txtApeCli.Text = ""
        txtCorCli.Text = ""
        txtTelCli.Text = ""
        txtDepa.SelectedValue = 0
        txtMun.SelectedValue = 0
        btnAdd.Enabled = True
        btnDel.Enabled = False
        btnUpd.Enabled = False
        Return True
    End Function
    Private Sub FrmCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIdCli.Focus()
        BaseDatos.conectar("root", "")
        SQL = "SELECT * FROM departamentos;"
        c_Varias.llena_combo(txtDepa, SQL, "DepId", "DepNom")
        txtMun.DropDownStyle = ComboBoxStyle.DropDownList
        txtDepa.DropDownStyle = ComboBoxStyle.DropDownList
        txtDepa.SelectedValue = 0
        txtMun.SelectedValue = 0
    End Sub

    Public Function BuscarCliente(ByVal id As Integer)
        SQL = "SELECT * FROM cliente WHERE cliCed=" & id
        'MsgBox(SQL)
        rst = BaseDatos.leer_Registro(SQL)
        If rst.Read() Then
            limpiar()
            txtNomCli.Text = rst("cliNom")
            txtApeCli.Text = rst("cliApe")
            txtCorCli.Text = rst("cliEma")
            txtTelCli.Text = rst("cliTel")
            txtDepa.SelectedValue = rst("cliDep")
            txtMun.SelectedValue = rst("cliMun")
            btnAdd.Enabled = False
            btnDel.Enabled = True
            btnUpd.Enabled = True
        End If
        Return True
    End Function

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        SQL = "INSERT cliente (cliCed, cliNom, cliApe, cliEma, cliTel, cliDep, cliMun) 
        VALUE (" & txtIdCli.Text & ", '" & txtNomCli.Text.ToUpper & "', '" & txtApeCli.Text.ToUpper &
        "', '" & txtCorCli.Text & "', " & txtTelCli.Text & ", " & txtDepa.SelectedValue & ", " & txtMun.SelectedValue & ");"
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
       "clinom = '" & txtNomCli.Text.ToUpper() & "', " &
       "cliape = '" & txtApeCli.Text.ToUpper() & "', " &
       "cliEma = '" & txtCorCli.Text & "', " &
       "cliTel = " & txtTelCli.Text & ", " &
       "cliDep = " & txtDepa.SelectedValue & ", " &
       "cliMun = " & txtMun.SelectedValue & " " &
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
        BuscarCliente(txtIdCli.Text)
    End Sub

    Private Sub txtIdCli_TextChanged(sender As Object, e As KeyEventArgs) Handles txtIdCli.KeyDown
        If e.KeyCode = Keys.Enter Then
            BuscarCliente(txtIdCli.Text)
        End If
    End Sub

    Private Sub txtDepa_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles txtDepa.SelectionChangeCommitted
        SQL = "Select * FROM municipios WHERE depIdFk=" & txtDepa.SelectedValue
        c_Varias.llena_combo(txtMun, SQL, "munId", "munNom")
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        frmConsulta.Text = "Buscar Cliente"
        frmConsulta.DgvConsulta.DataSource = ""
        SQL = "SELECT cliCed as Cedula, cliNom AS Nombres, cliApe as Apellidos, cliEma as Correo, cliTel as Telefono FROM cliente"
        frmConsulta.DgvConsulta.RowTemplate.Height = 17
        frmConsulta.DgvConsulta.DataSource = BaseDatos.Listar_datos(SQL)
        frmConsulta.DgvConsulta.Columns(0).Width = 70
        frmConsulta.DgvConsulta.Columns(1).Width = 150
        frmConsulta.DgvConsulta.Columns(2).Width = 150
        frmConsulta.DgvConsulta.Columns(3).Width = 150
        frmConsulta.DgvConsulta.Columns(4).Width = 120
        frmConsulta.ShowDialog()
        If sw_regreso = 1 Then
            txtIdCli.Text = CedCli
            BuscarCliente(CedCli)
            SendKeys.Send("{ENTER}")
        Else
            txtIdCli.Focus()
        End If
    End Sub
End Class