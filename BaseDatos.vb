Imports System.Data.Odbc
Imports Mysqlx.Crud
Public Class BaseDatos
    Public Shared conexion As Odbc.OdbcConnection
    Public Shared orden As OdbcCommand
    Public Shared insertar As OdbcCommand
    Public Shared Function conectar(ByVal user As String, ByVal pass As String) As Boolean
        Try
            conexion = New OdbcConnection("dsn=data;uid=" & user & ";pwd=" & pass & ";")
            conexion.Open()
            ' MsgBox("CONECTADO A LA BASE DE DATOS")
            Return True
        Catch ex As OdbcException
            MsgBox(ex.ErrorCode)
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Shared Function leer_Registro(ByVal sql As String) As OdbcDataReader
        Try
            orden = New OdbcCommand(sql, conexion)
            Return orden.ExecuteReader()
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error al Leer Registros en la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function ingresar_registros(ByVal sql As String) As OdbcDataReader
        Try
            insertar = New OdbcCommand(sql, conexion)
            'MsgBox(insertar)
            insertar.ExecuteNonQuery()
            MsgBox("Datos insertados correctamente")
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("No se insertaron los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class