Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Public Class Form1
    Dim input As String
    Private strSQL As String
    Private connstr = "Data Source=XE;User Id=system; Password=karan;"
    Private dr As OracleDataReader
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        input = TextBox1.Text


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)




    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form2.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form6.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim result As Char() = input.ToCharArray()
        For i As Integer = 0 To result.Length - 1
            Dim temp As Integer = Asc(result(i))
            Select Case temp
                Case 65 To 77, 97 To 109 'A - M
                    result(i) = Chr(temp + 13)
                Case 78 To 90, 110 To 122 'N - Z
                    result(i) = Chr(temp - 13)
            End Select
        Next i
        TextBox2.Text = result
        'Text enters into database
        Dim plaintext = TextBox1.Text
        Dim ciphertext = TextBox2.Text
        strSQL = "Insert into ROT13u(id, u_id, p_text,c_text) values(rot13_seq.nextval," & Form7.id & ",'" & plaintext & "','" & ciphertext & "')"
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

    

   
End Class
