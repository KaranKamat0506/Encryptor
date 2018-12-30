Imports System.Text
Imports System.Security.Cryptography
Public Class Form4
    Dim input As String
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Function SHA1(ByVal content As String) As String
        Dim input As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytestring() As Byte = System.Text.Encoding.ASCII.GetBytes(content)
        bytestring = input.computehash(bytestring)

        Dim Finalstring As String = Nothing
        For Each bt As Byte In bytestring
            Finalstring &= bt.ToString("x2")
        Next
        Return Finalstring
    End Function


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        input = TextBox1.Text
        TextBox2.Text = SHA1(TextBox1.Text)


    End Sub
End Class