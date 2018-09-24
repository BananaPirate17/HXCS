Imports MySql.Data.MySqlClient
Imports System.Data.Odbc
Public Class FormLog
    Dim con As New OdbcConnection("DSN=hxcs")
    Dim cmd As OdbcCommand
    Dim oreader As OdbcDataReader
    Dim query As String
    Private Sub FormLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim log As String
        Dim num As Integer
        log = ""
        num = 0
        Dim con As New OdbcConnection("DSN=hxcs")
        con.ConnectionString =
              "Dsn=hxcs;" +
              "Uid=root;" +
              "Pwd=school;"
        Try
            con.Open()
            query = "SELECT * from log order by ad desc limit 100"
            cmd = New OdbcCommand(query, con)
            oreader = cmd.ExecuteReader
            While oreader.Read
                log = oreader.GetString(0)
                log = log + vbTab + oreader.GetString(1)
                log = log + vbTab + oreader.GetString(2)
                log = log + vbTab + oreader.GetString(3)
                lstLog.Items.Add(log)
                log = ""
                num = num + 1
            End While
            con.Close()
        Catch ex As Exception
        End Try
    End Sub
End Class