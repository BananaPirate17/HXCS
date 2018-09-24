Imports System.Data.Odbc
Imports System.Data
Public Class Form1
    Dim Sname As String
    Dim con As New OdbcConnection("DSN=hxcs")
    Dim cmd As OdbcCommand
    Dim reader As OdbcDataReader


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()
        cmd = New OdbcCommand("SELECT * from family_info", con)
        reader = cmd.ExecuteReader()
        Try
            While reader.Read()
                TextBox1.Text = reader.GetString("address")
            End While

        Finally
            reader.Close()
            con.Close()



        End Try
        MsgBox("Connection Successful")
    End Sub
End Class
