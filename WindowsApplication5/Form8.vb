Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Public Class Form8
    Private strSQL As String
    Private connstr = "Data Source=XE;User Id=system;Password=karan"
    Private dr As OracleDataReader
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        strSQL = "Insert into appuser (id,username,password)values(user2.nextval, '" & TextBox1.Text & "','" & TextBox2.Text & "')"
        Using oraconn As New OracleConnection(connstr)
            Using comm As New OracleCommand()
                comm.Connection = oraconn
                comm.CommandText = strSQL
                comm.CommandType = CommandType.Text
                Try
                    oraconn.Open()
                    comm.ExecuteNonQuery()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString, "Error in Signup")

                Finally

                    oraconn.Close()
                End Try
            End Using
        End Using

        MessageBox.Show("Registered successfully")
        Me.Hide()
        Form7.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        TextBox1.Text = ""
        TextBox2.Text = ""


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Form7.Show()

    End Sub
End Class