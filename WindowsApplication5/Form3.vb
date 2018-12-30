Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Public Class Form3
    Dim input As String
    Dim result As String
    Dim s As String

    Private strSQL As String
    Private connstr = "Data Source=XE;User Id=system; Password=karan;"
    Private dr As OracleDataReader



    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged


    End Sub






    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form2.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form5.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form6.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim input = TextBox1.Text
        Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim bytes() As Byte = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input))

        For Each i As Byte In bytes
            s &= i.ToString("x2")

        Next
        TextBox2.Text = s
        'Text enters into database
        Dim plaintext = TextBox1.Text
        Dim ciphertext = TextBox2.Text
        strSQL = "Insert into md5(id, u_id, p_text,c_text) values(md_seq.nextval," & Form7.id & ",'" & plaintext & "','" & ciphertext & "')"
        Using oraConn As New OracleConnection(connstr)
            Using comm As New OracleCommand()
                comm.CommandText = strSQL
                comm.CommandType = CommandType.Text
                comm.Connection = oraConn
                Try
                    oraConn.Open()
                    comm.ExecuteNonQuery()
                    oraConn.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                End Try
            End Using
        End Using
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class