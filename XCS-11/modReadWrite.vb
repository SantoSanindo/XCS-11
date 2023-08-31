
Option Explicit On
Module modReadWrite
    Public INISTATUSPATH As String 'PATH TO SERVER\FRIDGE
    Public INIPSNFOLDERPATH As String 'Path to the PSN.Txt
    Public INIMATERIALPATH As String
    Public INISLIDEPATH As String

    Dim FNum As Integer
    Dim LineStr As String
    Public Sub ReadINI(Filename As String)
        Dim ItemStr As String
        Dim SectionHeading As String
        Dim pos As Integer

        FNum = FreeFile()

        FileOpen(FNum, Filename, OpenMode.Input)

        Do While Not EOF(FNum)
            LineStr = LineInput(FNum)
            If Left(LineStr, 1) = "[" Then
                SectionHeading = Mid(LineStr, 2, Len(LineStr) - 2)
            Else
                If InStr(LineStr, "=") > 0 Then
                    pos = InStr(LineStr, "=")
                    ItemStr = Left$(LineStr, pos - 1)

                    Select Case UCase(SectionHeading)
                        Case "PSN FOLDER PATH" 'Share FILE
                            Select Case UCase(ItemStr)
                                Case "PATH" : INIPSNFOLDERPATH = Mid$(LineStr, pos + 1)
                            End Select

                        Case "MATERIAL PATH" 'RACK MATERIAL LIST
                            Select Case UCase(ItemStr)
                                Case "PATH" : INIMATERIALPATH = Mid$(LineStr, pos + 1)
                            End Select

                        Case "SLIDE PATH"
                            Select Case UCase(ItemStr)
                                Case "PATH" : INISLIDEPATH = Mid$(LineStr, pos + 1)
                            End Select

                        Case "STATUS PATH"
                            Select Case UCase(ItemStr)
                                Case "PATH" : INISTATUSPATH = Mid$(LineStr, pos + 1)
                            End Select
                    End Select
                End If
            End If
        Loop
        FileClose(FNum)
    End Sub
    Public Function WRITEPSNFILE(ProductPSN As String) As Boolean
        On Error GoTo ErrorHandler
        FNum = FreeFile()
        FileOpen(FNum, INIPSNFOLDERPATH & ProductPSN & ".txt", OpenMode.Output)
        PrintLine(FNum)
        PrintLine(FNum, "[MODEL] : " & PSNFileInfo.ModelName)
        PrintLine(FNum)
        PrintLine(FNum, "[DATE CREATED] : " & PSNFileInfo.DateCreated)
        PrintLine(FNum)
        PrintLine(FNum, "[DATE COMPLETED] : " & PSNFileInfo.DateCompleted)
        PrintLine(FNum)
        PrintLine(FNum, "[OPERATOR ID] : " & PSNFileInfo.OperatorID)
        PrintLine(FNum)
        PrintLine(FNum, "[WORK ORDER NO] : " & PSNFileInfo.WONos)
        PrintLine(FNum)
        PrintLine(FNum, "[MAIN PCBA S/N] : " & PSNFileInfo.MainPCBA)
        PrintLine(FNum)
        PrintLine(FNum, "[SECONDARY PCBA S/N] : " & PSNFileInfo.SecondaryPCBA)
        PrintLine(FNum)
        PrintLine(FNum, "[ELECTROMAGNET S/N] : " & PSNFileInfo.ElectroMagnet)
        PrintLine(FNum)
        PrintLine(FNum, "[PSN] : " & PSNFileInfo.PSN)
        PrintLine(FNum)
        PrintLine(FNum, "[BODY ASSY STATION CHECK IN DATE] : " & PSNFileInfo.BodyAssyCheckIn)
        PrintLine(FNum)
        PrintLine(FNum, "[BODY ASSY STATION CHECK OUT DATE] : " & PSNFileInfo.BodyAssyCheckOut)
        PrintLine(FNum)
        PrintLine(FNum, "[BODY ASSY STATION STATUS] : " & PSNFileInfo.BodyAssyStatus)
        PrintLine(FNum)
        PrintLine(FNum, "[SCREWING STATION CHECK IN DATE] : " & PSNFileInfo.ScrewStnCheckIn)
        PrintLine(FNum)
        PrintLine(FNum, "[SCREWING STATION CHECK OUT DATE] : " & PSNFileInfo.ScrewStnCheckOut)
        PrintLine(FNum)
        PrintLine(FNum, "[SCREWING STATION STATUS] : " & PSNFileInfo.ScrewStnStatus)
        PrintLine(FNum)
        PrintLine(FNum, "[FINAL TEST CHECK IN DATE] : " & PSNFileInfo.FTCheckIn)
        PrintLine(FNum)
        PrintLine(FNum, "[FINAL TEST CHECK OUT DATE] : " & PSNFileInfo.FTCheckOut)
        PrintLine(FNum)
        PrintLine(FNum, "[FINAL TEST STATUS] : " & PSNFileInfo.FTStatus)
        PrintLine(FNum)
        PrintLine(FNum, "[STATION 5 CHECK IN DATE] : " & PSNFileInfo.Stn5CheckIn)
        PrintLine(FNum)
        PrintLine(FNum, "[STATION 5 CHECK OUT DATE] : " & PSNFileInfo.Stn5CheckOut)
        PrintLine(FNum)
        PrintLine(FNum, "[STATION 5 STATUS] : " & PSNFileInfo.Stn5Status)
        PrintLine(FNum)
        PrintLine(FNum, "[VACUUM CHECK IN DATE] : " & PSNFileInfo.VacuumCheckIn)
        PrintLine(FNum)
        PrintLine(FNum, "[VACUUM CHECK OUT DATE] : " & PSNFileInfo.VacummCheckOut)
        PrintLine(FNum)
        PrintLine(FNum, "[VACUUM STATUS] : " & PSNFileInfo.VacuumStatus)
        PrintLine(FNum)
        PrintLine(FNum, "[PACKAGING CHECK IN DATE] : " & PSNFileInfo.PackagingCheckIn)
        PrintLine(FNum)
        PrintLine(FNum, "[PACKAGING CHECK OUT DATE] : " & PSNFileInfo.PackagingCheckOut)
        PrintLine(FNum)
        PrintLine(FNum, "[PACKAGING STATUS] : " & PSNFileInfo.PackagingStatus)
        PrintLine(FNum)
        PrintLine(FNum, "[DEBUG STATION #10 STATUS] : " & PSNFileInfo.DebugStatus)
        PrintLine(FNum)
        PrintLine(FNum, "[DEBUG COMMENTS] : " & PSNFileInfo.DebugComment)
        PrintLine(FNum)
        PrintLine(FNum, "[DEBUG TECHNICIANS ID] : " & PSNFileInfo.DebugTechnican)
        PrintLine(FNum)
        PrintLine(FNum, "[DEBUG DATE REPAIRED] : " & PSNFileInfo.RepairDate)
        FileClose(FNum)
        Return True
ErrorHandler:
    End Function
End Module
