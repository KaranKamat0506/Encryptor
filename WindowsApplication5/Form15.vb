Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Public Class Form15
    Private dgv As DataGridView
    Private strSQL As String
    Private connstr = "Data Source=XE;User Id=system; Password=karan;"
    Private dr As OracleDataReader
    
    Private Function appusers() As DataTable
        Dim app As New DataTable
        strSQL = "Select id,username from appuser"
        Using oraconn As New OracleConnection(connstr)
            Using comm As New OracleCommand()
                comm.Connection = oraconn
                comm.CommandText = strSQL
                comm.CommandType = CommandType.Text
                Try
                    oraconn.Open()
                    dr = comm.ExecuteReader
                    app.Load(dr)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString, "Error in loading table")
                Finally
                    oraconn.Close()
                End Try
            End Using
        End Using
        Return app

    End Function

    Private Sub Form15_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv = DataGridView1
        dgv.DataSource = appusers()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form9.Show()
        Form9.TextBox1.Text = ""
        Form9.TextBox2.Text = ""

    End Sub
End Class