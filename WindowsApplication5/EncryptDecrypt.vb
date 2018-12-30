Imports WindowsApplication5.Simple3DES
Imports WindowsApplication5.Form2
Public Class EncryptDecrypt
    Public Sub TestEncoding(ByRef str As String)
        Dim plainText As String = str
        Dim key As String = "karankamat"

        Dim wrapper As New Simple3DES(key)
        Dim cipherText As String = wrapper.EncryptData(plainText)
        Form2.TextBox2.Text = cipherText
        My.Computer.FileSystem.WriteAllText(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments &
            "\cipherText.txt", cipherText, False)
    End Sub
    Sub TestDecoding()
        Dim cipherText As String = My.Computer.FileSystem.ReadAllText(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments &
                "\cipherText.txt")
        Dim password As String = InputBox("Enter the password:")
        Dim wrapper As New Simple3DES(password)

        ' DecryptData throws if the wrong password is used.
        Try
            Dim plainText As String = wrapper.DecryptData(cipherText)
            MsgBox("The plain text is: " & plainText)
        Catch ex As System.Security.Cryptography.CryptographicException
            MsgBox("The data could not be decrypted with the password.")
        End Try
    End Sub
End Class
