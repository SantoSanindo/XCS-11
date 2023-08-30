Public Class frmDatabase
    Private boxes(30) As TextBox
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim query = "Select * FROM Parameter WHERE ModelName = '" & ComboBox1.Text & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        TextBox101.Text = dt.Rows(0).Item("ARTICLENOS")
        TextBox102.Text = dt.Rows(0).Item("PrimaryPCBAType")
        TextBox103.Text = dt.Rows(0).Item("SecondaryPCBAType")
        TextBox104.Text = dt.Rows(0).Item("ElectroMagnetType")

        Dim Filenum1 As Integer
        Dim LineStr As String
        Filenum1 = FreeFile()
        FileOpen(Filenum1, INIMATERIALPATH & "Station3\" & ComboBox1.Text & ".Txt", OpenMode.Input)

        Dim i As Integer

        Do While Not EOF(Filenum1)
            i = i + 1
            LineStr = LineInput(Filenum1)
            boxes(i).Text = LineStr
        Loop

        FileClose(Filenum1)
    End Sub
    Private Sub LoadRefCombo()
        Dim query = "SELECT ModelName FROM Parameter"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        For i As Integer = 0 To dt.Rows.Count - 1
            ComboBox1.Items.Add(dt.Rows(i).Item(0))
        Next

        Dim newbox As TextBox

        For i As Integer = 1 To 10
            'create a new textbox and set its properties

            newbox = New TextBox
            newbox.Size = New Drawing.Size(150, 20)
            newbox.Location = New Point(320, 165 + 25 * (i - 1))
            newbox.Name = "TextBox" & i
            newbox.Font = New Font("Arial", 12)

            'connect it to a handler, save a reference to the array and add it to the form controls

            boxes(i) = newbox
            Me.Controls.Add(newbox)
        Next

        For j As Integer = 11 To 20
            'create a new textbox and set its properties

            newbox = New TextBox
            newbox.Size = New Drawing.Size(150, 20)
            newbox.Location = New Point(480, 290 + 25 * ((j - 15) - 1))
            newbox.Name = "TextBox" & j
            newbox.Font = New Font("Arial", 12)

            'connect it to a handler, save a reference to the array and add it to the form controls

            boxes(j) = newbox
            Me.Controls.Add(newbox)
        Next

        For k As Integer = 21 To 30
            'create a new textbox and set its properties

            newbox = New TextBox
            newbox.Size = New Drawing.Size(150, 20)
            newbox.Location = New Point(640, 40 + 25 * ((k - 15) - 1))
            newbox.Name = "TextBox" & k
            newbox.Font = New Font("Arial", 12)

            'connect it to a handler, save a reference to the array and add it to the form controls

            boxes(k) = newbox
            Me.Controls.Add(newbox)
        Next
    End Sub

    Private Sub frmDatabase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRefCombo()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub
End Class