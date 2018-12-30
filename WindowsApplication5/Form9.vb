Public Class Form9
    Private uname As String = "ADMIN"
    Private upass As String = "connect"
    Private adname, adpass As String


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form7.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        Form7.TextBox1.Text = ""
        Form7.TextBox2.Text = ""


    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        adname = TextBox1.Text
        adpass = TextBox2.Text
        If (adname <> uname Or adpass <> upass) Then
            MessageBox.Show("INVALID USERNAME OR PASSWORD", "Access Denied")
        Else
            MessageBox.Show(adname & " Logged In Successfully", "welcome")
            Me.Hide()
            Form10.Show()


        End If

    End Sub
End Class