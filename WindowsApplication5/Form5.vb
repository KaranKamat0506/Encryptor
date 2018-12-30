Imports System.Text
Imports System.Security.Cryptography
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Public Class Form5

    Dim input As String

    Private strSQL As String
    Private connstr = "Data Source=XE;User Id=system; Password=karan;"
    Private dr As OracleDataReader
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Function SHA1(ByVal content As String) As String
        Dim input As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytestring() As Byte = System.Text.Encoding.ASCII.GetBytes(content)
        bytestring = input.ComputeHash(bytestring)

        Dim Finalstring As String = Nothing
        For Each bt As Byte In bytestring
            Finalstring &= bt.ToString("x2")
        Next
        Return Finalstring

    End Function


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form3.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form6.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox2.Text = SHA1(TextBox1.Text)
        Dim plaintext = TextBox1.Text
        Dim ciphertext = TextBox2.Text
        strSQL = "Insert into SHA1(id, u_id, p_text,c_text) values(SHA_seq.nextval," & Form7.id & ",'" & plaintext & "','" & ciphertext & "')"
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