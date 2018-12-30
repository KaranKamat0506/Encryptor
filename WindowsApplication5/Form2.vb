Imports WindowsApplication5.EncryptDecrypt
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Public Class Form2
    Private enc As EncryptDecrypt = New EncryptDecrypt
    Private strSQL As String
    Private connstr = "Data Source=XE;User Id=system; Password=karan;"
    Private dr As OracleDataReader
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form6.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form3.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        enc.TestEncoding(TextBox1.Text)
        Dim plaintext = TextBox1.Text
        Dim ciphertext = TextBox2.Text
        strSQL = "Insert into desu(id, u_id, p_text,c_text) values(des_seq.nextval," & Form7.id & ",'" & plaintext & "','" & ciphertext & "')"
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

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class