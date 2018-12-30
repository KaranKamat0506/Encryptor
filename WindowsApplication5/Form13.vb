Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Public Class Form13
    Private dgv As DataGridView
    Private strSQL As String
    Private connstr = "Data Source=XE;User Id=system; Password=karan;"
    Private dr As OracleDataReader
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv = DataGridView1
        dgv.DataSource = SHA1()

    End Sub
    Private Function SHA1() As DataTable
        Dim SHA As New DataTable
        strSQL = "Select * from SHA1"
        Using oraconn As New OracleConnection(connstr)
            Using comm As New OracleCommand()
                comm.Connection = oraconn
                comm.CommandText = strSQL
                comm.CommandType = CommandType.Text
                Try
                    oraconn.Open()
                    dr = comm.ExecuteReader
                    SHA.Load(dr)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString, "Error in loading table")
                Finally
                    oraconn.Close()
                End Try
            End Using
        End Using
        Return SHA

    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class