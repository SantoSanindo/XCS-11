Public Class frmDatabase
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim query = "Select * FROM Parameter WHERE ModelName = '" & ComboBox1.Text & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        TextBox101.Text = dt.Rows(0).Item("ARTICLENOS")
        TextBox102.Text = dt.Rows(0).Item("PrimaryPCBAType")
        TextBox103.Text = dt.Rows(0).Item("SecondaryPCBAType")
        TextBox104.Text = dt.Rows(0).Item("ElectroMagnetType")
        Dim Filenum1 As Integer
        Dim LineStr As String
        Dim textBoxes As List(Of TextBox) = New List(Of TextBox) From {TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, TextBox10, TextBox11, TextBox12, TextBox13, TextBox14, TextBox15, TextBox16, TextBox17, TextBox18, TextBox19, TextBox20, TextBox21, TextBox22, TextBox23, TextBox24, TextBox25, TextBox26, TextBox27, TextBox28, TextBox29, TextBox30}

        Filenum1 = FreeFile()
        FileOpen(Filenum1, INIMATERIALPATH & "Station3\" & ComboBox1.Text & ".Txt", OpenMode.Input)

        Dim i As Integer

        For i = 0 To textBoxes.Count - 1
            If Not EOF(Filenum1) Then
                LineStr = LineInput(Filenum1)
                textBoxes(i).Text = LineStr
            Else
                textBoxes(i).Text = String.Empty
            End If
        Next

        FileClose(Filenum1)
    End Sub
    Private Sub LoadRefCombo()
        Dim query = "SELECT ModelName FROM Parameter"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        For i As Integer = 0 To dt.Rows.Count - 1
            ComboBox1.Items.Add(dt.Rows(i).Item(0))
        Next
    End Sub

    Private Sub frmDatabase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRefCombo()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub
End Class