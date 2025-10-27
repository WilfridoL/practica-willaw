﻿Imports System.Diagnostics.Eventing.Reader
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms
Imports Google.Protobuf.WellKnownTypes

Public Class FrmUsuario
    Dim arrTextBox() As Control
    Dim arrLabel() As Label
    Dim arrBtn() As ToolStripButton
    Dim limitModFrm As Integer = 1
    Public Function VerEstado(ByVal est As String, ByVal name As String, ByVal ob As String)
        If est > 1 Then
            txtObsUsu.ReadOnly = False
            If est = 2 Then
                MsgBox("El usuario " & name & " Se encuentra inactivo")
            Else
                For Each ctrl As Control In arrTextBox
                    If TypeOf ctrl Is TextBox Then CType(ctrl, TextBox).ReadOnly = True
                    If TypeOf ctrl Is ComboBox Then ctrl.Enabled = False
                Next
                txtEstUsu.Enabled = True
                MsgBox("El usuario " & name & " Se encuentra bloqueado por el motivo " & ob, MsgBoxStyle.Critical)
            End If
        Else
            txtIdUsu.ReadOnly = True
        End If
        Return True
    End Function
    Function validacion()
        For i As Integer = 0 To arrTextBox.Length - 1
            If TypeOf arrTextBox(i) Is TextBox Then
                If arrTextBox(i).Text = "" Then
                    msjErr.Text = "El campo " & arrLabel(i).Text & " es obligatorio"
                    arrTextBox(i).Focus()
                    Return False
                End If
            ElseIf TypeOf arrTextBox(i) Is ComboBox Then
                If CType(arrTextBox(i), ComboBox).SelectedValue = 0 Then
                    msjErr.Text = "Seleccione una opcion en el campo " & arrLabel(i).Text
                    arrTextBox(i).Focus()
                    Return False
                End If
            End If
        Next
        If txtConUsu.Text = "" And txtConUsu.Visible = True Then
            msjErr.Text = "El campo " & lbCon.Text & " es obligatorio"
            txtConUsu.Focus()
            Return False
        ElseIf txtConUsu.Text <> txtConContra.Text And txtConUsu.Visible = True Then
            msjErr.Text = "La contraseña no coiciden"
            txtConUsu.Focus()
            Return False
        Else
            Return True
        End If
    End Function
    Public Function resetCampo()
        limpiar(arrTextBox, arrBtn, 0)
        For Each ctrl As Control In arrTextBox
            txtConContra.Text = ""
            If TypeOf ctrl Is TextBox Then CType(ctrl, TextBox).ReadOnly = False
            If TypeOf ctrl Is ComboBox Then ctrl.Enabled = True
        Next
        txtConUsu.ReadOnly = False
        txtConUsu.Text = ""
        txtEstUsu.SelectedValue = 1
        btnAdd.Enabled = True
        btnDel.Enabled = False
        btnUpd.Enabled = False
        txtEstUsu.Enabled = False
        msjErr.Text = ""
        limitModFrm = 2
        modInterfaz()
        limitModFrm = 1
        Return True
    End Function
    Public Function BuscarUsuario(ByVal id As Integer)
        SQL = "SELECT usuId, nombre, apellido, correo, departamento, municipio, rol, estado, observacion FROM tb_usuarios  
        LEFT JOIN observaciones ON idUsuFk = usuId  
        WHERE usuId = " & id
        rst = BaseDatos.leer_Registro(SQL)
        If rst.Read() Then
            resetCampo()
            limitModFrm = 0
            municipios(rst("departamento"))
            buscar(SQL, arrTextBox)
            txtEstUsu.Enabled = True
            txtObsUsu.ReadOnly = False
            btnAdd.Enabled = False
            btnDel.Enabled = True
            btnUpd.Enabled = True
            modInterfaz()
            VerEstado(rst("estado"), rst("nombre") & " " & rst("apellido"), rst("observacion"))
            msjErr.Text = "Usuario encontrado"
            limitModFrm = 1
        Else
            msjErr.Text = "El usuario con la identificacion " & id & " no se encuentra registrado"
        End If
        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtIdUsu.Text = "" Then
            msjErr.Text = "Ingrese una identificacion"
        Else
            BuscarUsuario(txtIdUsu.Text)
        End If
    End Sub
    Private Sub txtIdCli_TextChanged(sender As Object, e As KeyEventArgs) Handles txtIdUsu.KeyDown ' bucar usuario al presionar enter
        If e.KeyCode = Keys.Enter Then
            If txtIdUsu.Text = "" Then
                msjErr.Text = "Ingrese una identificacion"
            Else
                BuscarUsuario(txtIdUsu.Text)
            End If
        End If
    End Sub

    Private Sub FrmUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        txtIdUsu.Focus()
        ' rellenar arreglos
        arrTextBox = {txtIdUsu, txtNomUsu, txtApeUsu, txtCorUsu, txtDepa, txtMun, txtRolUsu, txtEstUsu, txtObsUsu}
        arrLabel = {lbId, lbNom, lbApe, lbCorr, lbDep, lbMun, lbRol, lbEst, lbObs}
        arrBtn = {btnAdd, btnUpd, btnDel}
        cargar_combobox("Select * FROM departamentos", txtDepa, "depId", "DepNom")
        cargar_combobox("Select * FROM rol", txtRolUsu, "idRol", "nomRol")
        cargar_combobox("Select * FROM estados", txtEstUsu, "idEst", "estNom")
        txtDepa.SelectedValue = 0
        txtRolUsu.SelectedValue = 0
    End Sub

    Private Sub modInterfaz()
        ' interfaz para busqueda de usuario
        If txtConUsu.Visible = True And limitModFrm = 0 Then
            txtConUsu.Visible = False
            txtConContra.Visible = False
            lbCon.Visible = False
            lbConCont.Visible = False
            camCont.Visible = True
            For i As Integer = 3 To arrTextBox.Length - 1 ' ajusta la posicion de los campos y labels
                arrTextBox(i).Location = New Point(arrTextBox(i).Location.X, arrTextBox(i).Location.Y - (29 * 2))
                arrLabel(i).Location = New Point(arrLabel(i).Location.X, arrLabel(i).Location.Y - (29 * 2))
            Next
        Else
            ' interfaz de para crea un nuevo usuario o cambiar la contraseña
            If txtConUsu.Visible = False And limitModFrm = 2 Then
                txtConUsu.Visible = True
                txtConContra.Visible = True
                lbCon.Visible = True
                lbConCont.Visible = True
                camCont.Visible = False
                For i As Integer = 3 To arrTextBox.Length - 1 ' ajusta la posicion de los campos y labels
                    arrTextBox(i).Location = New Point(arrTextBox(i).Location.X, arrTextBox(i).Location.Y + (29 * 2))
                    arrLabel(i).Location = New Point(arrLabel(i).Location.X, arrLabel(i).Location.Y + (29 * 2))
                Next
            End If
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click ' boton de limpiar
        resetCampo()
    End Sub

    Public Function municipios(ByVal depa As Integer) ' cargar municipios segun el departamento seleccionado
        cargar_combobox("Select * FROM municipios WHERE depIdFk=" & depa, txtMun, "munId", "munNom")
        txtMun.SelectedValue = 0
        Return True
    End Function

    Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles txtDepa.SelectionChangeCommitted
        municipios(txtDepa.SelectedValue)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        SQL = "DELETE FROM observaciones WHERE idUsuFk=" & txtIdUsu.Text
        'MsgBox(SQL)
        If BaseDatos.ingresar_registros(SQL, "Eliminar") Then
            SQL = "DELETE FROM tb_usuarios WHERE usuId=" & txtIdUsu.Text
            BaseDatos.ingresar_registros(SQL, "Eliminar")
            msjErr.Text = "datos eliminados"
            resetCampo()
        Else
            msjErr.Text = "No se pudo eliminar el usuario"
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        SQL = "UPDATE tb_usuarios Set " &
        "nombre = '" & txtNomUsu.Text & "', " &
        "apellido = '" & txtApeUsu.Text & "', " &
        "correo = '" & txtCorUsu.Text & "', " &
        "rol = '" & txtRolUsu.SelectedValue & "', " &
        "estado = '" & txtEstUsu.SelectedValue & "', " &
        "departamento = " & txtDepa.SelectedValue & ", " &
        "municipio = " & txtMun.SelectedValue & " " &
        " WHERE usuId = " & txtIdUsu.Text
        If validacion() <> True Then Exit Sub ' validar campos
        If BaseDatos.ingresar_registros(SQL, "actualizar") Then
                SQL = "UPDATE observaciones SET " &
                        "observacion= '" & txtObsUsu.Text & "' " &
                        "WHERE idUsuFK=" & txtIdUsu.Text
            controlObservaciones(SQL)
            If txtConUsu.Visible = True Then ' actualizar contraseña si el campo es visible
                SQL = "UPDATE tb_usuarios Set " &
                        "contraseña = '" & txtConUsu.Text & "' " &
                        " WHERE usuId = " & txtIdUsu.Text
                'MsgBox(SQL)
                If BaseDatos.ingresar_registros(SQL, "actualizar contraseña") Then
                    MsgBox("Contraseña actualizada", MsgBoxStyle.Information)
                End If
            End If
            resetCampo()
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
        If validacion() <> True Then Exit Sub
        MsgBox(SQL)
        If BaseDatos.ingresar_registros(SQL, "guardar") Then
            SQL = "INSERT observaciones (idUsuFk, observacion)
            VALUE (" & txtIdUsu.Text & ", 'No tiene observaciones...');"
            BaseDatos.ingresar_registros(SQL, "guardar")
            resetCampo()
            msjErr.Text = "Datos guardados"
        End If
    End Sub
    ' habilitar o deshabilitar el campo de observaciones segun el estado seleccionado
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
            'SendKeys.Send("{ENTER}")
        Else
            txtIdUsu.Focus()
        End If
    End Sub

    Private Sub camCont_Click(sender As Object, e As EventArgs) Handles camCont.Click
        If InputBox("Ingrese su contraseña de acceso, para habilitar el cambio de contraseña",
                    "Cambiar Contraseña", "").ToString() = usuContra Then
            limitModFrm = 2
            modInterfaz()
            limitModFrm = 1
        Else
            MsgBox("Contraseña incorrecta", MsgBoxStyle.Critical)
        End If
    End Sub
End Class