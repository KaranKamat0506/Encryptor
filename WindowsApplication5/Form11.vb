﻿Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Public Class Form11
    Private dgv As DataGridView
    Private strSQL As String
    Private connstr = "Data Source=XE;User Id=system; Password=karan;"
    Private dr As OracleDataReader
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv = DataGridView1
        dgv.DataSource = DES()

    End Sub
    Private Function DES() As DataTable
        Dim DES3 As New DataTable
        strSQL = "Select * from DESu"
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
End Class