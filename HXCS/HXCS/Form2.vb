Imports MySql.Data.MySqlClient
Imports System.Data.Odbc

Public Class frmlogin
    Structure Admin
        Dim username As String
        Dim password As String
    End Structure
    Dim con As New OdbcConnection("DSN=hxcs")
    Dim cmd As OdbcCommand
    Dim oreader As OdbcDataReader
    Dim query As String
    Dim users(50) As Admin
    Dim numusers As Integer
    Dim correct As Boolean


    Private Sub frmlogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AcceptButton = btnLogin
        numusers = 0
        Dim con As New OdbcConnection("DSN=hxcs")
        con.ConnectionString =
              "Dsn=hxcs;" +
              "Uid=root;" +
              "Pwd=school;"

        Try
            con.Open()
            query = "select * from admin_user"
            cmd = New OdbcCommand(query, con)
            oreader = cmd.ExecuteReader
            While oreader.Read
                numusers = numusers + 1
                users(numusers).username = oreader.GetString(0)
                users(numusers).password = oreader.GetString(1)
            End While
            con.Close()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            con.Dispose()
        End Try
        txtUser.Clear()
        txtPass.Clear()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        correct = False
        For i = 1 To numusers
            If txtUser.Text = users(i).username And txtPass.Text = users(i).password Then
                correct = True
                Me.Hide()
                frmInfo.Show()
            End If
        Next
        If correct = False Then
            MsgBox("Username or password incorrect")
            txtUser.Clear()
            txtPass.Clear()
        End If
    End Sub
    Private Sub EnterClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode.Equals(Keys.Enter) Then
            btnLogin_Click(sender, e)
        End If
    End Sub
End Class
