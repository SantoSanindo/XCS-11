Public Class frmMaterial
    Private Sub frmMaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadParameter()
    End Sub
    Private Sub LoadParameter()
        Dim Filenum1 As Integer
        Dim LineStr As String
        Dim textBoxes As List(Of TextBox) = New List(Of TextBox) From {TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, TextBox10, TextBox11, TextBox12, TextBox13, TextBox14, TextBox15, TextBox16, TextBox17, TextBox18, TextBox19, TextBox20, TextBox21, TextBox22, TextBox23, TextBox24, TextBox25, TextBox26, TextBox27, TextBox28, TextBox29, TextBox30}

        Filenum1 = FreeFile()
        FileOpen(Filenum1, INIMATERIALPATH & "Rack\" & "Station3", OpenMode.Input)

        For i As Integer = 0 To textBoxes.Count - 1
            If Not EOF(Filenum1) Then
                LineStr = LineInput(Filenum1)
                textBoxes(i).Text = LineStr
            Else
                textBoxes(i).Text = String.Empty
            End If
        Next

        FileClose(Filenum1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class