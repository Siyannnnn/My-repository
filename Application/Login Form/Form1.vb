Imports System.Data.SqlClient




Public Class Form1
    Dim Username As String = ""
    Dim Password As String = ""
    Dim Con As SqlConnection
    Dim ConStr As String = "Data Source=(LocalDB)\MSSQLLocalDB;" _
                           & "Initial Catalog=master;" _
                           & "Integrated Security=True;"


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()

    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Con = New SqlConnection(ConStr)
        Con.Open()

        Dim query As String = "Select * from ssr_user;"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, Con)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader

        If dr.Read Then
            Me.Username = dr("name").ToString
            Me.Password = dr("password").ToString
            If Me.Username = Me.txtUser.Text And Me.Password = Me.txtPass.Text Then
                Form2.Show()
                MsgBox("Your are successfully Loggedin..!!", MsgBoxStyle.Information)
            Else
                MsgBox("Failed to Login", MsgBoxStyle.Critical)
            End If

        End If
        dr.Close()
        Con.Close()


    End Sub
End Class
