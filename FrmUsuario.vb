Imports System.Diagnostics.Eventing.Reader
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Google.Protobuf.WellKnownTypes

Public Class FrmUsuario
    Dim c_Varias As New Varias
    Public Function VerEstado(ByVal est As String, ByVal name As String, ByVal ob As String)
        If est > 1 Then
            txtObsUsu.ReadOnly = False
            If est = 2 Then
                MsgBox("El usuario " & name & " Se encuentra inactivo")
            Else
                txtNomUsu.ReadOnly = True
                txtApeUsu.ReadOnly = True
                txtCorUsu.ReadOnly = True
                txtConUsu.ReadOnly = True
                txtObsUsu.ReadOnly = True
                txtRolUsu.Enabled = False
                MsgBox("El usuario " & name & " Se encuentra bloqueado por el motivo " & ob, MsgBoxStyle.Critical)
            End If
        Else
            txtIdUsu.ReadOnly = True
        End If
        Return True
    End Function
    Function validacion() As Boolean
        If txtIdUsu.Text = "" Then
            msjErr.Text = "Por favor ingrese la identificacion del usuario"
            txtIdUsu.Focus()
            Return False
        ElseIf txtNomUsu.Text = "" Then
            msjErr.Text = "Por favor ingrese el nombre del usuario"
            txtNomUsu.Focus()
            Return False
        ElseIf txtApeUsu.Text = "" Then
            msjErr.Text = "Por favor ingrese el apellido del usuario"
            txtApeUsu.Focus()
            Return False
        ElseIf txtCorUsu.Text = "" Then
            msjErr.Text = "Por favor ingrese el correo del usuario"
            txtCorUsu.Focus()
            Return False
        ElseIf txtConUsu.Text = "" And SQL.Contains("INSERT") Then
            msjErr.Text = "Por favor ingrese la contraseña del usuario"
            txtConUsu.Focus()
            Return False
        ElseIf txtDepa.SelectedValue = 0 Then
            msjErr.Text = "Por favor seleccione el departamento del usuario"
            txtDepa.Focus()
            Return False
        ElseIf txtMun.SelectedValue = 0 Then
            msjErr.Text = "Por favor seleccione el municipio del usuario"
            txtMun.Focus()
            Return False
        ElseIf txtRolUsu.SelectedValue = 0 Then
            msjErr.Text = "Por favor seleccione el rol del usuario"
            txtRolUsu.Focus()
            Return False
        End If
        Return True
    End Function
    Public Function limpiar(ByVal e As Integer)
        txtNomUsu.Text = ""
        txtApeUsu.Text = ""
        txtCorUsu.Text = ""
        txtConUsu.Text = ""
        txtObsUsu.Text = ""
        txtRolUsu.SelectedValue = 0
        txtDepa.SelectedValue = 0
        txtMun.SelectedValue = 0
        txtEstUsu.SelectedValue = 1
        txtIdUsu.ReadOnly = False
        txtNomUsu.ReadOnly = False
        txtApeUsu.ReadOnly = False
        txtCorUsu.ReadOnly = False
        txtObsUsu.ReadOnly = True
        txtRolUsu.Enabled = True
        txtEstUsu.Enabled = False
        btnAdd.Enabled = True
        btnDel.Enabled = False
        btnUpd.Enabled = False
        If e = 1 Then
            txtIdUsu.Text = ""
        End If
        Return True
    End Function
    Public Function BuscarUsuario(ByVal id As Integer)
        SQL = "SELECT nombre, apellido, correo, contraseña, rol, observacion, estado, departamento, municipio FROM tb_usuarios  
        LEFT JOIN observaciones ON idUsuFk = usuId  
        WHERE usuId = " & id
        rst = BaseDatos.leer_Registro(SQL)
        If rst.Read() Then
            limpiar(0)
            txtNomUsu.Text = rst("nombre")
            txtApeUsu.Text = rst("apellido")
            txtCorUsu.Text = rst("correo")
            txtConUsu.Text = rst("contraseña")
            txtRolUsu.SelectedValue = rst("rol")
            txtDepa.SelectedValue = rst("departamento")
            txtMun.SelectedValue = rst("municipio")
            txtEstUsu.SelectedValue = rst("estado")
            txtObsUsu.Text = rst("observacion")
            txtEstUsu.Enabled = True
            txtObsUsu.ReadOnly = False
            btnAdd.Enabled = False
            btnDel.Enabled = True
            btnUpd.Enabled = True
            VerEstado(rst("estado"), rst("nombre") & " " & rst("apellido"), rst("observacion"))
        End If
        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BuscarUsuario(txtIdUsu.Text)
    End Sub
    Private Sub txtIdCli_TextChanged(sender As Object, e As KeyEventArgs) Handles txtIdUsu.KeyDown
        If e.KeyCode = Keys.Enter Then
            BuscarUsuario(txtIdUsu.Text)
        End If
    End Sub

    Private Sub FrmUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        txtIdUsu.Focus()
        SQL = "SELECT * FROM departamentos;"
        c_Varias.llena_combo(txtDepa, SQL, "DepId", "DepNom")
        SQL = "SELECT * FROM rol;"
        c_Varias.llena_combo(txtRolUsu, SQL, "idRol", "nomRol")
        SQL = "SELECT * FROM estados;"
        c_Varias.llena_combo(txtEstUsu, SQL, "idEst", "estNom")
        txtRolUsu.DropDownStyle = ComboBoxStyle.DropDownList
        txtDepa.DropDownStyle = ComboBoxStyle.DropDownList
        txtMun.DropDownStyle = ComboBoxStyle.DropDownList
        txtEstUsu.DropDownStyle = ComboBoxStyle.DropDownList
        txtDepa.SelectedValue = 0
        txtRolUsu.SelectedValue = 0
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        limpiar(1)
    End Sub

    Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles txtDepa.SelectionChangeCommitted
        SQL = "Select * FROM municipios WHERE depIdFk=" & txtDepa.SelectedValue
        c_Varias.llena_combo(txtMun, SQL, "munId", "munNom")
        txtMun.SelectedValue = 0
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        SQL = "DELETE FROM observaciones WHERE idUsuFk=" & txtIdUsu.Text
        'MsgBox(SQL)
        If BaseDatos.ingresar_registros(SQL, "Eliminar") Then
            limpiar(0)
            SQL = "DELETE FROM tb_usuarios WHERE usuId=" & txtIdUsu.Text
            BaseDatos.ingresar_registros(SQL, "Eliminar")
            msjErr.Text = "datos eliminados"
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        SQL = "UPDATE tb_usuarios SET " &
        "nombre = '" & txtNomUsu.Text & "', " &
        "apellido = '" & txtApeUsu.Text & "', " &
        "correo = '" & txtCorUsu.Text & "', " &
        "rol = '" & txtRolUsu.SelectedValue & "', " &
        "estado = '" & txtEstUsu.SelectedValue & "' " &
        "WHERE usuId = " & txtIdUsu.Text
        ' MsgBox(SQL)
        If BaseDatos.ingresar_registros(SQL, "actualizar") Then
            SQL = "UPDATE observaciones SET " &
                "observacion= '" & txtObsUsu.Text & "' " &
                "WHERE idUsuFK=" & txtIdUsu.Text
            controlObservaciones(SQL)
            limpiar(0)
            msjErr.Text = "Datos actualizados"
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        seleccionar.Show()
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        SQL = "INSERT tb_usuarios (usuId, nombre, apellido, contraseña, correo, departamento, municipio, rol, estado) " & "
        VALUE (" & txtIdUsu.Text & ", '" & txtNomUsu.Text.ToUpper() & "', '" & txtApeUsu.Text.ToUpper() & "', '" & txtConUsu.Text & "', '" & txtCorUsu.Text &
        "', " & txtDepa.SelectedValue & ", " & txtMun.SelectedValue & ", " & txtRolUsu.SelectedValue & ", " & txtEstUsu.SelectedValue & ");"
        'MsgBox(SQL)
        If validacion() And BaseDatos.ingresar_registros(SQL, "guardar") Then
            SQL = "INSERT observaciones (idUsuFk, observacion)
            VALUE (" & txtIdUsu.Text & ", 'No tiene observaciones...');"
            BaseDatos.ingresar_registros(SQL, "guardar")
            limpiar(1)
            msjErr.Text = "Datos guardados"
        End If
    End Sub

    Private Sub txtEstUsu_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles txtEstUsu.SelectionChangeCommitted
        If txtEstUsu.SelectedValue <> 1 Then
            txtObsUsu.ReadOnly = False
        Else
            txtObsUsu.ReadOnly = True
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frmConsulta.Text = "Buscar usuario"
        frmConsulta.DgvConsulta.DataSource = ""
        SQL = "SELECT usuId as cedula ,nombre, apellido, correo, nomrol AS rol, estNom AS estado FROM tb_usuarios  
        JOIN rol ON rol = idRol
        JOIN estados ON estado = idEst"
        frmConsulta.DgvConsulta.RowTemplate.Height = 17
        frmConsulta.DgvConsulta.DataSource = BaseDatos.Listar_datos(SQL)
        frmConsulta.DgvConsulta.Columns(0).Width = 70
        frmConsulta.DgvConsulta.Columns(1).Width = 150
        frmConsulta.DgvConsulta.Columns(2).Width = 150
        frmConsulta.DgvConsulta.Columns(3).Width = 150
        frmConsulta.DgvConsulta.Columns(4).Width = 120
        frmConsulta.ShowDialog()
        If sw_regreso = 1 Then
            txtIdUsu.Text = CedCli
            BuscarUsuario(CedCli)
            SendKeys.Send("{ENTER}")
        Else
            txtIdUsu.Focus()
        End If
    End Sub
End Class