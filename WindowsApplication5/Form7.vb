Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

Public Class Form7
    Dim strsql As String
    Dim strsqli As String
    Dim connStr As String = "Data Source=XE; User Id=system; password=karan"
    Dim dr As OracleDataReader
    Public id As Integer
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form8.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim uname = TextBox1.Text
        Dim pass = TextBox2.Text
        strsql = "select * from appuser where username = '" & uname & "' and password = '" & pass & "'"
        Using oraConn As New OracleConnection(connStr)
            Using comm As New OracleCommand()
                comm.CommandText = strsql
                comm.CommandType = CommandType.Text
                comm.Connection = oraConn
                Try
                    oraConn.Open()
                    dr = comm.ExecuteReader
                    If dr.HasRows Then
                        id = dr("id")
                        MessageBox.Show("Logged in")
                        Me.Hide()
                        Form6.Show()
                    Else
                        MessageBox.Show("Invalid")
                    End If
                    oraConn.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                End Try
            End Using
        End Using
       
       
    End Sub
   


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form9.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        Form9.TextBox1.Text = ""
        Form9.TextBox2.Text = ""
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

   

End Class