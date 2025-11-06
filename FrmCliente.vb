Imports System.ComponentModel

Public Class FrmCliente
    Public FocusFactura As Integer = 0 ' 0 = no viene de factura, 1 = viene de factura
    Dim arrText() As Control
    Dim arrLabel() As Label
    Public Function limpiar(ByVal e As Integer)
        'txtIdCli.Text = ""
        txtNom.Text = ""
        txtApe.Text = ""
        txtEma.Text = ""
        txtTelNum.Text = ""
        txtDepa.SelectedValue = 0
        txtMun.SelectedValue = 0
        btnAdd.Enabled = True
        btnDel.Enabled = False
        btnUpd.Enabled = False
        ToolStripButton1.Enabled = True
        msjErr.Text = ""
        If e = 1 Then
            txtIdNum.Text = ""
            txtIdNum.Enabled = True
        End If
        Return True
    End Function

    Private Sub FrmCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIdNum.Focus()
        BaseDatos.conectar("root", "")
        SQL = "SELECT * FROM departamentos;"
        c_Varias.llena_combo(txtDepa, SQL, "DepId", "DepNom")
        txtMun.DropDownStyle = ComboBoxStyle.DropDownList
        txtDepa.DropDownStyle = ComboBoxStyle.DropDownList
        txtDepa.SelectedValue = 0
        txtMun.SelectedValue = 0
        arrText = {txtIdNum, txtNom, txtApe, txtEma, txtTelNum, txtDepa, txtMun}
        arrLabel = {lbId, lbNom, lbApe, lbCor, lbTel, lbDep, lbMun}
        If FocusFactura = 1 Then
            txtIdNum.Enabled = False
            ToolStripButton1.Enabled = False
        End If
    End Sub
    Public Function municipios(ByVal depa As Integer)
        SQL = "Select * FROM municipios WHERE depIdFk=" & depa
        c_Varias.llena_combo(txtMun, SQL, "munId", "munNom")
        txtMun.SelectedValue = 0
        Return True
    End Function

    Public Function BuscarCliente(ByVal id As Integer)
        SQL = "SELECT * FROM cliente WHERE cliCed=" & id
        'MsgBox(SQL)
        rst = BaseDatos.leer_Registro(SQL)
        If rst.Read() Then
            limpiar(0)
            municipios(rst("cliDep"))
            txtNom.Text = rst("cliNom")
            txtApe.Text = rst("cliApe")
            txtEma.Text = rst("cliEma")
            txtTelNum.Text = rst("cliTel")
            txtDepa.SelectedValue = rst("cliDep")
            txtMun.SelectedValue = rst("cliMun")
            btnAdd.Enabled = False
            btnDel.Enabled = True
            btnUpd.Enabled = True
            msjErr.Text = "Cliente encontrado"
        Else
            msjErr.Text = "El usuario con la identificacion " & id & " no se encuentra registrado"
        End If
        Return True
    End Function

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        SQL = "INSERT cliente (cliCed, cliNom, cliApe, cliEma, cliTel, cliDep, cliMun) 
        VALUE (" & txtIdNum.Text & ", '" & txtNom.Text.ToUpper & "', '" & txtApe.Text.ToUpper &
        "', '" & txtEma.Text & "', " & txtTelNum.Text & ", " & txtDepa.SelectedValue & ", " & txtMun.SelectedValue & ");"
        'MsgBox(SQL)
        If validacionGlobal(arrText, arrLabel, msjErr, "SELECT * FROM cliente WHERE cliCed=" & txtIdNum.Text) <> True Then Exit Sub
        If BaseDatos.ingresar_registros(SQL, "registrar") Then
            If FocusFactura = 1 Then
                FrmFactura.txtId.Text = txtIdNum.Text
                SendKeys.Send("{ENTER}")
                Me.Close()
            End If
            limpiar(1)
            msjErr.Text = "datos ingresados"
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles btnLim.Click
        limpiar(1)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        SQL = "DELETE FROM cliente WHERE cliCed=" & txtIdNum.Text
        If BaseDatos.ingresar_registros(SQL, "Eliminar") Then
            limpiar(1)
            msjErr.Text = "datos eliminados"
        Else
            msjErr.Text = "No se pudo eliminar el usuario"
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        SQL = "UPDATE cliente SET " &
       "clinom = '" & txtNom.Text.ToUpper() & "', " &
       "cliape = '" & txtApe.Text.ToUpper() & "', " &
       "cliEma = '" & txtEma.Text & "', " &
       "cliTel = " & txtTelNum.Text & ", " &
       "cliDep = " & txtDepa.SelectedValue & ", " &
       "cliMun = " & txtMun.SelectedValue &
       " WHERE cliCed = " & txtIdNum.Text
        'MsgBox(SQL)
        If BaseDatos.ingresar_registros(SQL, "actualizar") Then
            limpiar(1)
            msjErr.Text = "Datos actualizados"
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles btnSal.Click
        seleccionar.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtIdNum.Text = "" Then
            msjErr.Text = "Ingrese una identificacion"
        Else
            BuscarCliente(txtIdNum.Text)
        End If
    End Sub

    Private Sub txtIdCli_TextChanged(sender As Object, e As KeyEventArgs) Handles txtIdNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtIdNum.Text = "" Then
                msjErr.Text = "Ingrese una identificacion"
            Else
                BuscarCliente(txtIdNum.Text)
                msjErr.Text = ""
            End If
        End If
    End Sub

    Private Sub txtDepa_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles txtDepa.SelectionChangeCommitted
        municipios(txtDepa.SelectedValue)
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
            txtIdNum.Text = CedCli
            BuscarCliente(CedCli)
            SendKeys.Send("{ENTER}")
        Else
            txtIdNum.Focus()
        End If
    End Sub

    Private Sub FrmCliente_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        limpiar(1)
        FocusFactura = 0
    End Sub
End Class