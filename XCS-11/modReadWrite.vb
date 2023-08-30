
Option Explicit On
Module modReadWrite
    Public INICSINFOPATH As String 'Path to WOEntry.Mdb
    Public INIDATABASEPATH As String 'Path to local Model.mdb
    Public INIUSERPATH As String 'Path to local User.mdb
    Public INISERVERPATH As String 'PATH TO SERVER DIR - to access Serial.mdb & Signal.Txt
    Public INISTATUSPATH As String 'PATH TO SERVER\FRIDGE
    Public INIPSNFOLDERPATH As String 'Path to the PSN.Txt
    Public INITEMPPATH As String
    Public INIMATERIALPATH As String
    Public INIPHOTOPATH As String
    Public INISLIDEPATH As String
    Public INIHISPATH As String
    Public INIMPCode As String
    Public INIHISDBNAME As String

    Public INIPRINTPATH As String 'PATH TO PRINT.TXT
    Public INITMPSERIALPATH As String 'PATH TO LOCAL TEMP SERIAL.TXT
    Public INIREPRINTPATH As String

    Dim FNum As Integer
    Dim LineStr As String
    Public Sub ReadINI(Filename As String)
        Dim ItemStr As String
        Dim SectionHeading As String
        Dim pos As Integer

        FNum = FreeFile()

        FileOpen(FNum, My.Application.Info.DirectoryPath & "\Config.ini", OpenMode.Input)

        Do While Not EOF(FNum)
            LineStr = LineInput(FNum)
            If Left(LineStr, 1) = "[" Then
                SectionHeading = Mid(LineStr, 2, Len(LineStr) - 2)
            Else
                If InStr(LineStr, "=") > 0 Then
                    pos = InStr(LineStr, "=")
                    ItemStr = Left$(LineStr, pos - 1)

                    Select Case UCase(SectionHeading)
                        Case "DATABASE PATH"
                            Select Case UCase(ItemStr)
                                Case "PATH" : INIDATABASEPATH = Mid$(LineStr, pos + 1)
                            End Select

                        Case "PSN FOLDER PATH" 'Share FILE
                            Select Case UCase(ItemStr)
                                Case "PATH" : INIPSNFOLDERPATH = Mid$(LineStr, pos + 1)
                            End Select

                        Case "MATERIAL PATH" 'RACK MATERIAL LIST
                            Select Case UCase(ItemStr)
                                Case "PATH" : INIMATERIALPATH = Mid$(LineStr, pos + 1)
                            End Select

                        Case "TEMP PATH" 'LOCAL DIR
                            Select Case UCase(ItemStr)
                                Case "PATH" : INITEMPPATH = Mid$(LineStr, pos + 1)
                            End Select

                        Case "PHOTO PATH" 'LOCAL DIR
                            Select Case UCase(ItemStr)
                                Case "PATH" : INIPHOTOPATH = Mid$(LineStr, pos + 1)
                            End Select

                        Case "SERVER PATH"
                            Select Case UCase(ItemStr)
                                Case "PATH" : INISERVERPATH = Mid$(LineStr, pos + 1)
                            End Select

                        Case "SLIDE PATH"
                            Select Case UCase(ItemStr)
                                Case "PATH" : INISLIDEPATH = Mid$(LineStr, pos + 1)
                            End Select

                        Case "CSUNIT PATH"
                            Select Case UCase(ItemStr)
                                Case "PATH" : INICSINFOPATH = Mid$(LineStr, pos + 1)
                            End Select

                        Case "STATUS PATH"
                            Select Case UCase(ItemStr)
                                Case "PATH" : INISTATUSPATH = Mid$(LineStr, pos + 1)
                            End Select

                        Case "PRINT PATH" 'LOCAL FILE
                            Select Case UCase(ItemStr)
                                Case "PATH" : INIPRINTPATH = Mid$(LineStr, pos + 1)
                            End Select

                        Case "TEMPSERIAL PATH" 'LOCAL DIR
                            Select Case UCase(ItemStr)
                                Case "PATH" : INITMPSERIALPATH = Mid$(LineStr, pos + 1)
                            End Select

                        Case "USER PATH" 'LOCAL FILE
                            Select Case UCase(ItemStr)
                                Case "PATH" : INIUSERPATH = Mid$(LineStr, pos + 1)
                            End Select

                        Case "HISTORY DATABASE"
                            Select Case UCase(ItemStr)
                                Case "PATH" : INIHISPATH = Mid$(LineStr, pos + 1)
                                Case "NAME" : INIHISDBNAME = Mid$(LineStr, pos + 1)
                            End Select

                        Case "MANUFACTURING PLANT CODE"
                            Select Case UCase(ItemStr)
                                Case "CODE" : INIMPCode = Mid$(LineStr, pos + 1)
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
