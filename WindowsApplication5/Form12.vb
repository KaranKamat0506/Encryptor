Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Public Class Form12
    Private dgv As DataGridView
    Private strSQL As String
    Private connstr = "Data Source=XE;User Id=system; Password=karan;"
    Private dr As OracleDataReader
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv = DataGridView1
        dgv.DataSource = MD5()

    End Sub
    Private Function MD5() As DataTable
        Dim MD As New DataTable
        strSQL = "Select * from MD5"
        Using oraconn As New OracleConnection(connstr)
            Using comm As New OracleCommand()
                comm.Connection = oraconn
                comm.CommandText = strSQL
                comm.CommandType = CommandType.Text
                Try
                    oraconn.Open()
                    dr = comm.ExecuteReader
                    MD.Load(dr)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString, "Error in loading table")
                Finally
                    oraconn.Close()
                End Try
            End Using
        End Using
        Return MD

    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class