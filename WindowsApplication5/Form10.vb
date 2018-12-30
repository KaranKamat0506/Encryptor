Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Public Class Form10
    Private dgv As DataGridView
    Private strSQL As String
    Private connstr = "Data Source=XE;User Id=system; Password=karan;"
    Private dr As OracleDataReader
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv = DataGridView1
        dgv.DataSource = appusers()
        dgv = DataGridView2
        dgv.DataSource = des()
        dgv = DataGridView3
        dgv.DataSource = MD5()
        dgv = DataGridView4
        dgv.DataSource = SHA1()


    End Sub
    Private Function appusers() As DataTable
        Dim app As New DataTable
        strSQL = "Select * from rot13u"
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
    Private Function des() As DataTable
        Dim DES3 As New DataTable
        strSQL = "Select * from desu"
        Using oraconn As New OracleConnection(connstr)
            Using comm As New OracleCommand()
                comm.Connection = oraconn
                comm.CommandText = strSQL
                comm.CommandType = CommandType.Text
                Try
                    oraconn.Open()
                    dr = comm.ExecuteReader
                    DES3.Load(dr)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString, "Error in loading table")
                Finally
                    oraconn.Close()
                End Try
            End Using
        End Using
        Return DES3

    End Function
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
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim app As New DataGridView
        DataGridView1 = app

    End Sub

   
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Form7.Show()
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim des3 As New DataGridView
        DataGridView2 = des3
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim md As New DataGridView
        DataGridView3 = md
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Dim sha As New DataGridView
        DataGridView4 = sha
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form15.Show()
    End Sub
End Class