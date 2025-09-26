Module Mprincipal
    Public SQL As String
    Public rst As Odbc.OdbcDataReader
    Public codusuario As String
    Function controlObservaciones(ByVal SQL As String) As Boolean
        If FrmUsuario.txtEstUsu.SelectedValue <> 1 Then
            'MsgBox(SQL)
            BaseDatos.ingresar_registros(SQL, "manipulacion obs")
            Return True
        Else
            Return False
        End If
    End Function
End Module
