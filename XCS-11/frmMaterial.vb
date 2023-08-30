Public Class frmMaterial
    Private boxes(30) As TextBox
    Private labels(30) As Label
    Private Sub frmMaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadParameter()
    End Sub
    Private Sub LoadParameter()
        Dim Filenum1 As Integer
        Dim LineStr As String
        Filenum1 = FreeFile()
        FileOpen(Filenum1, INIMATERIALPATH & "Rack\" & "Station3", OpenMode.Input)
        Dim newbox As TextBox
        Dim label As Label

        For i As Integer = 1 To 15

            'create a new textbox and set its properties

            newbox = New TextBox
            newbox.Size = New Drawing.Size(150, 20)
            newbox.Location = New Point(110, 100 + 25 * (i - 1))
            newbox.Name = "TextBox" & i
            If Not EOF(Filenum1) Then
                LineStr = LineInput(Filenum1)
                newbox.Text = LineStr
            Else
                newbox.Text = ""
            End If
            newbox.Font = New Font("Arial", 12)

            label = New Label
            label.Size = New Drawing.Size(150, 20)
            label.Location = New Point(70, 100 + 25 * (i - 1))
            label.Name = "Label" & i
            label.Text = "#" & i
            label.Font = New Font("Arial", 12)

            'connect it to a handler, save a reference to the array and add it to the form controls

            boxes(i) = newbox
            Me.Controls.Add(newbox)
            labels(i) = label
            Me.Controls.Add(label)

        Next

        For j As Integer = 16 To 30

            'create a new textbox and set its properties

            newbox = New TextBox
            newbox.Size = New Drawing.Size(150, 20)
            newbox.Location = New Point(330, 100 + 25 * ((j - 15) - 1))
            newbox.Name = "TextBox" & j
            If Not EOF(Filenum1) Then
                LineStr = LineInput(Filenum1)
                newbox.Text = LineStr
            Else
                newbox.Text = ""
            End If
            newbox.Font = New Font("Arial", 12)

            label = New Label
            label.Size = New Drawing.Size(150, 20)
            label.Location = New Point(290, 100 + 25 * ((j - 15) - 1))
            label.Name = "Label" & j
            label.Text = "#" & j
            label.Font = New Font("Arial", 12)

            'connect it to a handler, save a reference to the array and add it to the form controls

            boxes(j) = newbox
            Me.Controls.Add(newbox)
            labels(j) = label
            Me.Controls.Add(label)

        Next
        FileClose(Filenum1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class