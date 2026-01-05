Imports System.Diagnostics.Eventing.Reader
Imports System.Text.RegularExpressions

'Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms
Imports Google.Protobuf.WellKnownTypes

Public Class FrmUsuario
    Dim arrTextBox() As Control
    Dim arrLabel() As Label
    Dim arrBtn() As ToolStripButton
    Dim limitModFrm As Integer = 1
    Dim idAnterior As Integer = 0
    Public Function VerEstado(ByVal est As String, ByVal name As String, ByVal ob As String)
        If est > 1 Then
            'txtObsUsu.ReadOnly = False
            If est = 2 Then
                MsgBox("El usuario " & name & " Se encuentra inactivo")
            Else
                For Each ctrl As Control In arrTextBox
                    If TypeOf ctrl Is TextBox Or TypeOf ctrl Is RichTextBox Then ctrl.Enabled = False
                    If TypeOf ctrl Is ComboBox Then ctrl.Enabled = False
                    If TypeOf ctrl Is TextBox = True Then ctrl.Cursor = Cursors.No ' cambia el cursor a no disponible
                Next
                btnDel.Enabled = False
                btnUpd.Enabled = False
                btnCanContra.Enabled = False
                btnDesBlo.Enabled = True
                MsgBox("El usuario " & name & " Se encuentra bloqueado por el motivo " & ob, MsgBoxStyle.Critical)
            End If
        Else
            txtIdNum.ReadOnly = True
            txtIdNum.Cursor = Cursors.No
            'txtObsUsu.ReadOnly = True
            btnCanContra.Enabled = True
            btnDesBlo.Enabled = False
        End If
        Return True
    End Function
    Function validacion()
        If validacionGlobal(arrTextBox.Skip(2).ToArray, arrLabel.Skip(1).ToArray, msjErr, "") = False Then Return False ' validacion de campos de texto, correo y numericos
        Return True
    End Function
    Public Function resetCampo()
        limpiar(arrTextBox, arrBtn, 0)
        For Each ctrl As Control In arrTextBox
            txtConContra.Text = ""
            If TypeOf ctrl Is TextBox Then CType(ctrl, TextBox).ReadOnly = False
            If TypeOf ctrl Is ComboBox Then ctrl.Enabled = True
            If TypeOf ctrl Is TextBox Then ctrl.Cursor = Cursors.IBeam
        Next
        For Each lb As Label In arrLabel
            cambiarColor(True, lb)
        Next
        txtConUsu.ReadOnly = False
        txtConUsu.Text = ""
        txtEstUsu.SelectedValue = 1
        tipId.SelectedValue = 1
        btnAdd.Enabled = True
        btnDel.Enabled = False
        btnUpd.Enabled = False
        txtEstUsu.Enabled = False
        msjErr.Text = ""
        menDes.Visible = False
        limitModFrm = 2
        modInterfaz()
        limitModFrm = 1
        bloquearCampos(arrTextBox, 0)
        cambiarColor(True, lbCon)
        cambiarColor(True, lbConCont)
        frmConsulta.DgvConsulta.DataSource = ""
        txtIdNum.Focus()
        Return True
    End Function
    Public Function BuscarUsuario(ByVal id As Integer)
        SQL = "SELECT usuId, usutipId, nombre, nombre2, apellido, apellido2, correo, 
        departamento, municipio, direccion, rol, estado, observacion 
        FROM tb_usuarios  
        LEFT JOIN observaciones ON idUsuFk = usuId  
        WHERE usuId =  " & id
        Dim arrRecortado() As Control = arrTextBox.Skip(2).ToArray()
        rst = BaseDatos.leer_Registro(SQL)
        If rst.Read() Then
            resetCampo()
            bloquearCampos(arrTextBox, 1)
            limitModFrm = 0
            modInterfaz()
            municipios(rst("departamento"))
            buscar(SQL, arrTextBox.Where(Function(ctrl, index) index <> 6 AndAlso index <> 7).ToArray())
            txtEstUsu.Enabled = True
            'txtObsUsu.ReadOnly = False
            btnDel.Enabled = True
            btnUpd.Enabled = True
            VerEstado(rst("estado"), rst("nombre") & " " & rst("apellido"), rst("observacion"))
            btnAdd.Enabled = False
            msjErr.Text = "Usuario encontrado"
            limitModFrm = 1
            menDes.Visible = True
        Else
            'If MsgBox("El usuario con la identificacion " & id & " no se encuentra registrado" & vbCrLf & "¿Desea crearlo?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) <> vbYes Then Exit Function
            bloquearCampos(arrTextBox, 1)
            txtEstUsu.Enabled = False

        End If
        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtIdNum.Text = "" Then
            msjErr.Text = "Ingrese una identificacion"
        Else
            BuscarUsuario(txtIdNum.Text)
        End If
    End Sub
    Private Sub txtIdCli_TextChanged(sender As Object, e As KeyEventArgs) Handles txtIdNum.KeyDown ' bucar usuario al presionar enter
        If e.KeyCode = Keys.Enter Then
            If txtIdNum.Text = "" Then
                msjErr.Text = "Ingrese una identificacion"
            Else
                BuscarUsuario(txtIdNum.Text)
            End If
        End If
    End Sub

    Private Sub FrmUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BaseDatos.conectar("root", "")
        txtIdNum.Focus()
        ' rellenar arreglos
        arrTextBox = {txtIdNum, tipId, txtNomUsu, txtNom2Usu, txtApeUsu, txtApe2Usu, txtConUsu, txtConContra, txtEma, txtDepa, txtMun, txtDir, txtRolUsu, txtEstUsu, txtObsUsu}
        arrLabel = {lbId, lbNom, lbNom2, lbApe, lbApe2, lbCon, lbConCont, lbCorr, lbDep, lbMun, lbDir, lbRol, lbEst, lbObs}
        arrBtn = {btnAdd, btnUpd, btnDel}
        'MsgBox(arrTextBox.Skip(6).ToArray().Length)

        cargar_combobox("Select * FROM departamentos", txtDepa, "depId", "DepNom")
        cargar_combobox("SELECT * FROM tipo_identificacion", tipId, "tipId", "tipNom")
        cargar_combobox("Select * FROM rol", txtRolUsu, "idRol", "nomRol")
        cargar_combobox("Select * FROM estados", txtEstUsu, "idEst", "estNom")
        txtDepa.SelectedValue = 0
        txtRolUsu.SelectedValue = 0

        bloquearCampos(arrTextBox, 0)
    End Sub
    Private Function mostrarContra(e As Boolean, c As Boolean)
        txtConUsu.Visible = e
        txtConContra.Visible = e
        lbCon.Visible = e
        lbConCont.Visible = e
    End Function
    Private Sub modInterfaz()
        Dim newArrText() As Control = arrTextBox.Skip(6).ToArray()
        Dim newArrLabel() As Control = arrLabel.Skip(5).ToArray()
        If txtConUsu.Visible = True And limitModFrm = 0 Then
            mostrarContra(False, True)
            For Each ctrl As Control In newArrText
                ctrl.Location = New Point(ctrl.Location.X, ctrl.Location.Y - (29 * 2))
            Next
            For Each ctrl As Control In newArrLabel
                ctrl.Location = New Point(ctrl.Location.X, ctrl.Location.Y - (29 * 2))
            Next
        End If
        If txtConUsu.Visible = False And limitModFrm = 2 Then
            mostrarContra(True, False)
            For Each ctrl As Control In newArrText
                ctrl.Location = New Point(ctrl.Location.X, ctrl.Location.Y + (29 * 2))
            Next
            For Each ctrl As Control In newArrLabel
                ctrl.Location = New Point(ctrl.Location.X, ctrl.Location.Y + (29 * 2))
            Next
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click ' boton de limpiar
        resetCampo()
    End Sub

    Public Function municipios(ByVal depa As Integer) ' cargar municipios segun el departamento seleccionado
        cargar_combobox("Select * FROM municipios WHERE depIdFk=" & depa, txtMun, "munId", "munNom")
        'txtMun.SelectedValue = 0
        Return True
    End Function

    Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles txtDepa.SelectionChangeCommitted
        municipios(txtDepa.SelectedValue)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If txtIdNum.Text = codusuario Then
            MsgBox("No puedes bloquear el usuario de esta sesión", MsgBoxStyle.Critical)
            Exit Sub
        End If
        SQL = "UPDATE tb_usuarios Set estado=3  WHERE usuId=" & txtIdNum.Text
        'MsgBox(SQL)
        If MsgBox("Desea bloquear este usuario", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) <> vbYes Then Exit Sub
        Dim obs As String = InputBox("Ingrese el motivo por el cual se bloquea el usuario", "Motivo de bloqueo", "")
        If obs = "" Then
            msjErr.Text = "Debe ingresar un motivo para bloquear el usuario"
            Exit Sub
        End If
        If BaseDatos.ingresar_registros(SQL, "Eliminar") Then
            SQL = "UPDATE observaciones SET " &
                        "observacion= '" & obs & "' " &
                        "WHERE idUsuFK=" & txtIdNum.Text
            controlObservaciones(SQL)
            msjErr.Text = "Usuario bloqueado"
            resetCampo()
        Else
            msjErr.Text = "No se pudo eliminar el usuario"
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        SQL = "UPDATE tb_usuarios Set " &
        "nombre = '" & txtNomUsu.Text.ToUpper() & "', " &
        "nombre2 = '" & txtNom2Usu.Text.ToUpper() & "', " &
        "apellido = '" & txtApeUsu.Text.ToUpper() & "', " &
        "apellido2 = '" & txtApe2Usu.Text.ToUpper() & "', " &
        "correo = '" & txtEma.Text.ToLower() & "', " &
        "rol = '" & txtRolUsu.SelectedValue & "', " &
        "estado = '" & txtEstUsu.SelectedValue & "', " &
        "departamento = " & txtDepa.SelectedValue & ", " &
        "municipio = " & txtMun.SelectedValue & ", " &
        "direccion = '" & txtDir.Text & "' " &
        " WHERE usuId = " & txtIdNum.Text
        If validacion() <> True Then Exit Sub ' validar campos
        If BaseDatos.ingresar_registros(SQL, "actualizar") Then
            SQL = "UPDATE observaciones SET " &
                        "observacion= " & IIf(txtObsUsu.Text = "", "'No tiene observaciones...'", $"'{txtObsUsu.Text}'") &
                        " WHERE idUsuFK=" & txtIdNum.Text
            controlObservaciones(SQL)
            If txtConUsu.Visible = True Then ' actualizar contraseña si el campo es visible
                SQL = "UPDATE tb_usuarios Set " &
                        "contraseña = '" & txtConUsu.Text & "' " &
                        " WHERE usuId = " & txtIdNum.Text
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
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        SQL = $"INSERT tb_usuarios (usuId, usuTipId, nombre, nombre2, apellido, apellido2, 
        contraseña, correo, departamento, municipio, direccion, rol, estado)
        VALUE ({txtIdNum.Text}, {tipId.SelectedValue}, '{txtNomUsu.Text.ToString.ToUpper}', '{txtNom2Usu.Text.ToString.ToUpper}', 
        '{txtApeUsu.Text.ToString.ToUpper}', '{txtApe2Usu.Text.ToString.ToUpper}', '{txtConUsu.Text}', '{txtEma.Text.ToString.ToLower}',
        {txtDepa.SelectedValue}, {txtMun.SelectedValue}, '{txtDir.Text}', {txtRolUsu.SelectedValue}, {txtEstUsu.SelectedValue});"
        If validacion() <> True Then Exit Sub
        'MsgBox(SQL)
        ' validacion id existente
        rst = BaseDatos.leer_Registro("SELECT * FROM tb_usuarios WHERE usuId=" & txtIdNum.Text)
        If rst.Read() Then
            If rst(0) = arrTextBox(0).Text Then
                msjErr.Text = "La identificacion ya existe, por favor ingrese uno diferentes"
                arrTextBox(0).Focus()
                cambiarColor(False, lbId)
                Exit Sub
            End If
        End If
        cambiarColor(True, lbId)
        ' validacion correo existente
        rst = BaseDatos.leer_Registro($"SELECT * FROM cliente WHERE cliEma='{txtEma.Text}'")
        If rst.Read() Then
            msjErr.Text = "Este correo ya existe, por favor ingrese uno diferente"
            txtEma.Focus()
            cambiarColor(False, lbCorr)
            Exit Sub
        End If
        cambiarColor(True, lbCorr)
        If BaseDatos.ingresar_registros(SQL, "guardar") Then
            SQL = $"INSERT observaciones (idUsuFk, observacion)
            VALUE ({txtIdNum.Text}, {IIf(txtObsUsu.Text = "", "'No tiene observaciones...'", $"'{txtObsUsu.Text}'")});"
            MsgBox(SQL)
            BaseDatos.ingresar_registros(SQL, "guardar Observacion")
            resetCampo()
            msjErr.Text = "Datos guardados"
        End If
    End Sub
    ' habilitar o deshabilitar el campo de observaciones segun el estado seleccionado
    Private Sub txtEstUsu_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles txtEstUsu.SelectionChangeCommitted
        If txtEstUsu.SelectedValue = 3 Then
            txtEstUsu.SelectedValue = 2
            MsgBox("No se puede seleccionar el estado bloqueado desde este campo, para bloquear el usuario utilice el boton 'Bloquear Usuario'", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        SQL = "SELECT usuId AS Identificación, tipNom AS Tipo, 
        CONCAT_WS(' ', nombre, nombre2) AS Nombres, CONCAT_WS(' ', apellido, apellido2) AS Apellidos, 
        correo AS Correo_Electronico, DepNom AS Departamento, 
        munNom AS Municipio, direccion AS Dirección, nomRol AS Rol, observacion AS Observacion
        FROM tb_usuarios  
        LEFT JOIN observaciones ON idUsuFk = usuId  
        JOIN departamentos ON depID = departamento
        JOIN municipios ON munId = municipio
        JOIN tipo_identificacion ON tipId = usuTipId
        JOIN rol ON rol = idRol 
        WHERE estado != 3"
        mostrarDataGridView(SQL, "Buscar Usuario", txtIdNum) ' mostar y calcular tamaño automatico del datagrid
        If sw_regreso = 1 Then BuscarUsuario(valDataGrid) ' si la respuesta es la deseada ejecuta la funcion de busqueda

    End Sub
    ' Cambiar contraseña
    Private Sub camCont_Click(sender As Object, e As EventArgs)
        If InputBox("Ingrese su contraseña de acceso, para habilitar el cambio de contraseña",
                    "Cambiar Contraseña", "").ToString = usuContra Then
            limitModFrm = 2
            modInterfaz()
            limitModFrm = 1
        Else
            MsgBox("Contraseña incorrecta", MsgBoxStyle.Critical)
        End If
    End Sub

    Function bloquearCampos(arr() As Control, tip As Integer)
        For Each ctrl As Control In arr
            If tip = 0 Then ctrl.Enabled = False
            If tip = 1 Then ctrl.Enabled = True
        Next
        If tip = 1 Then
            txtIdNum.Enabled = False
            tipId.Enabled = False
            Button1.Enabled = False
            btnAdd.Enabled = True
            txtConUsu.Enabled = True
            txtConContra.Enabled = True
        End If
        If tip = 0 Then
            btnAdd.Enabled = False
            txtIdNum.Enabled = True
            tipId.Enabled = True
            txtConUsu.Enabled = False
            txtConContra.Enabled = False
            Button1.Enabled = True
        End If
    End Function


    Private Sub txtNom_KeyDown(sender As Object, e As KeyEventArgs) Handles _
        txtNomUsu.KeyDown, txtNom2Usu.KeyDown, txtApeUsu.KeyDown, txtApe2Usu.KeyDown, txtEma.KeyDown, txtDepa.KeyDown, txtMun.KeyDown,
        txtConUsu.KeyDown, txtConContra.KeyDown, txtObsUsu.KeyDown, txtRolUsu.KeyDown, txtDir.KeyDown
        'MsgBox(e.KeyCode)
        If e.KeyCode = Keys.Enter Then
            If txtRolUsu.Focused Or txtObsUsu.Focused Then
                If btnAdd.Enabled = True Then
                    btnAdd.PerformClick()
                Else btnUpd.PerformClick()
                End If
            Else SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub txtApe_KeyDown(sender As Object, e As KeyEventArgs) Handles txtApeUsu.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtApeUsu.Text <> "" Then
                cambiarColor(True, lbApe)
            Else Exit Sub
            End If
        End If
    End Sub



    Private Sub txtConUsu_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConUsu.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtConUsu.Text <> "" Then
                cambiarColor(True, lbCon)
            Else
                cambiarColor(False, lbCon)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtConContra_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConContra.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtConContra.Text <> "" Then
                cambiarColor(True, lbConCont)
            Else
                cambiarColor(False, lbConCont)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtIdNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdNum.KeyPress
        SoloNumeros(sender, e)
    End Sub

    Private Sub FrmUsuario_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ToolStripButton3.PerformClick()
    End Sub

    Private Sub camposSoloLetras(sender As Object, e As KeyPressEventArgs) Handles _
        txtNomUsu.KeyPress, txtNom2Usu.KeyPress, txtApeUsu.KeyPress, txtApe2Usu.KeyPress
        SoloLetras(sender, e)
    End Sub

    Private Sub direccionRectricion(sender As Object, e As KeyPressEventArgs) Handles txtDir.KeyPress
        If Char.IsControl(e.KeyChar) Then Exit Sub
        If Not Regex.IsMatch(e.KeyChar.ToString(), "[A-Za-zÁÉÍÓÚáéíóúÑñ0-9\s#\-,./°()]") Then
            e.Handled = True
        End If
    End Sub



    Private Sub btnCanContra_Click(sender As Object, e As EventArgs) Handles btnCanContra.Click, btnDesBlo.Click
        If sender.name = "btnCanContra" And sender.enabled = True Then
            If InputBox("Ingrese su contraseña de acceso, para habilitar el cambio de contraseña",
                    "Cambiar Contraseña", "").ToString() = usuContra Then
                limitModFrm = 2
                modInterfaz()
                limitModFrm = 1
            Else
                MsgBox("Contraseña incorrecta", MsgBoxStyle.Critical)
            End If
        End If
        If sender.name = "btnDesBlo" And sender.enabled = True Then
            If InputBox("Ingrese su contraseña de acceso, para continuar con el proceso",
                    "Desbloquear usuario", "").ToString() = usuContra Then
                If BaseDatos.ingresar_registros($"UPDATE tb_usuarios SET estado = 1 WHERE usuId={txtIdNum.Text} AND 
                usuTipId={tipId.SelectedValue}", "actualizar") Then
                    MsgBox($"El usuario {txtNomUsu.Text} {txtApeUsu.Text} ha sido desbloqueado", MsgBoxStyle.Information, "Usuario desbloqueado")
                    BuscarUsuario(txtIdNum.Text)
                End If
            Else
                MsgBox("Contraseña incorrecta", MsgBoxStyle.Critical)
            End If
        End If

    End Sub

    Private Sub txtEma_LostFocus(sender As Object, e As EventArgs) Handles txtEma.LostFocus
        autoCompletarCorreo(sender, e)
    End Sub
End Class