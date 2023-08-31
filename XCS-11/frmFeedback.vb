Public Class frmFeedback
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim MyMsg, ID$, TestTime
        Dim Atfile$, Fileloc$
        Dim Filenos As Integer
        Dim currentDate As DateTime = DateTime.Now
        'On Error Resume Next

        Atfile$ = "Cancel.Txt" '"WO" & Year(Date) & Format(Date, "ww", vbSunday, vbFirstFullWeek) & ".CSV"
        Fileloc$ = My.Application.Info.DirectoryPath & "\" & Atfile$

        MyMsg = currentDate.Date
        Filenos = FreeFile()
        FileOpen(Filenos, Fileloc$, OpenMode.Append) 'MyMsg; ","; Time; ","; Label1.Caption
        PrintLine(Filenos, MyMsg & "," & Now.ToLongTimeString & "," & Label1.Text)
        FileClose(Filenos)
        frmMain.ScanMode = 0
        PCBAFLAG(1) = False
        PCBAFLAG(2) = False

        frmMain.BoardCount = LoadWOfrRFID.JobItemCount
        frmMain.Label11.Text = frmMain.BoardCount
        frmMain.ScanMode = 0 'Waiting for the next product
        frmMain.Action = 0
        frmMain.ItemsScanCompleteFlag = False
        frmMain.BodyTest = False
        frmMain.TextBox2.BackColor = Color.White
        frmMain.TextBox3.BackColor = Color.White
        Me.Hide()
    End Sub
End Class