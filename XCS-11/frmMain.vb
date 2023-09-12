Option Explicit On
Imports System.Threading
Imports System.Net
Public Class frmMain
    Public BoardCount As Integer
    Public BodyTest As Boolean
    Public Action As Integer
    Public ItemsScanCompleteFlag As Boolean 'True when all items are scanned
    Public ScanMode As Integer
    Dim AssyBuf As String
    Dim currentDate As DateTime = DateTime.Now
    Dim SlideCount As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SlideCount = 22
        Dim fullPath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim projectFolder As String = fullPath.Replace("\XCS-11\bin\Debug\", "").Replace("\XCS-11\bin\Release\", "")
        If Dir(projectFolder & "\Config\Config.INI") = "" Then 'This is to initalize the program during start up
            MsgBox("Config.INI is missing")
            End
        End If
        ReadINI(projectFolder & "\Config\Config.INI")
        GetLastConfig()
        frmMsg.Show()
        frmMsg.Label1.Text = "Establishing connection with PLC..."
        frmModbus.Show()

        Ethernet.BackColor = Color.Lime

        Dim strHostName As String = Dns.GetHostName()
        Dim hostname As IPHostEntry = Dns.GetHostByName(strHostName)
        Dim ip As IPAddress() = hostname.AddressList
        Label18.Text = "PC Name : " & strHostName
        Label19.Text = "PC IP Address : " & ip(0).ToString

        frmModbus.Hide()
        Thread.Sleep(10)
        Reset_PLC()
        frmMsg.Label1.Text = "Loading parameters..."
        'Load parameters
        If Not LoadParameter(LoadWOfrRFID.JobModelName) Then
            MsgBox("Unable to load parameters...")
            End
        End If
        If Not LoadLabelParameter(LoadWOfrRFID.JobModelName) Then
            MsgBox("Unable to load Label parameters...")
            End
        End If
        lbl_WOnos.Text = LoadWOfrRFID.JobNos
        PSNFileInfo.WONos = LoadWOfrRFID.JobNos
        lbl_currentref.Text = LoadWOfrRFID.JobModelName
        PSNFileInfo.ModelName = LoadWOfrRFID.JobModelName
        lbl_wocounter.Text = LoadWOfrRFID.JobQTy
        lbl_currcounter.Text = LoadWOfrRFID.JobUnitaryCount
        lbl_tagnos.Text = LoadWOfrRFID.JobRFIDTag
        lbl_articlenos.Text = LoadWOfrRFID.JobArticle
        LoadWOfrRFID.JobModelFW = "001"
        lbl_fw.Text = LoadWOfrRFID.JobModelFW
        UnitaryDateCode = GetDateCode()
        lbl_datecode.Text = UnitaryDateCode
        lbl_lastcounter.Text = Check_Serialnos(LoadWOfrRFID.JobArticle & LoadWOfrRFID.JobModelFW & UnitaryDateCode)
        LoadWOfrRFID.JobItemCount = CheckTotalItem(LoadWOfrRFID.JobModelName)
        BoardCount = LoadWOfrRFID.JobItemCount
        Label11.Text = BoardCount
        'Send parameter to PLC
        If Not LoadParameter2PLC() Then
            MsgBox("Unable to communicate with PLC")
            End
        End If
        'Load Rack Material List
        If Not LoadRackMaterial() Then
            MsgBox("Unable to load Rack Materials")
            End
        End If
        'Load Model Material
        If Not LoadModelMaterial(LoadWOfrRFID.JobModelName) Then
            MsgBox("Unable to load Model Material")
            End
        End If
        frmMsg.Label1.Text = "Refreshing indicators..."
        'Update Rack indicator
        If Not ActivateRackLED() Then
            MsgBox("Unable to communicate with PLC")
            End
        End If

        RFID_Comm.Open()
        Barcode_Comm.Open()

        frmMsg.Hide()
        Timer1.Enabled = True
    End Sub
    Public Sub Reset_PLC()
        Call frmModbus.tulisModbus(40500, 1)
    End Sub
    Private Function LoadParameter(csmodel As String) As Boolean
        Dim query = "Select * FROM Parameter WHERE ModelName = '" & csmodel & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)
        On Error Resume Next

        LoadWOfrRFID.JobArticle = "" & dt.Rows(0).Item("ArticleNos")
        LoadWOfrRFID.JobModelFW = "" & dt.Rows(0).Item("ProductVer")
        LoadWOfrRFID.JobProductThread = "" & dt.Rows(0).Item("BodyType")
        LoadWOfrRFID.JobButtonType = "" & dt.Rows(0).Item("ButtonOpt")
        LoadWOfrRFID.JobProductMaterial = "" & dt.Rows(0).Item("MaterialType")
        LoadWOfrRFID.JobElectroMagnet = "" & dt.Rows(0).Item("ElectroMagnetType")
        LoadWOfrRFID.JobPrimaryPCBA = "" & dt.Rows(0).Item("PrimaryPCBAType")
        Return True
    End Function
    Private Function LoadLabelParameter(csmodel As String) As Boolean
        Dim query = "Select * FROM Label WHERE ModelName = '" & csmodel & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)
        On Error Resume Next

        UnitLabel.UnitS4_1 = "" & dt.Rows(0).Item("Schematic_S4_1")
        UnitLabel.UnitS4_2 = "" & dt.Rows(0).Item("Schematic_S4_2")
        UnitLabel.UnitS5_1 = "" & dt.Rows(0).Item("Schematic_S5_1")
        UnitLabel.UnitS5_2 = "" & dt.Rows(0).Item("Schematic_S5_2")
        UnitLabel.UnitS6_1 = "" & dt.Rows(0).Item("Schematic_S6_1")
        UnitLabel.UnitS6_2 = "" & dt.Rows(0).Item("Schematic_S6_2")
        UnitLabel.UnitE2 = "" & dt.Rows(0).Item("Schematic_E2")
        UnitLabel.UnitE1 = "" & dt.Rows(0).Item("Schematic_E1")
        Return True
    End Function
    Private Function LoadParameter2PLC() As Boolean
        On Error GoTo ErrorHandler
        If LoadWOfrRFID.JobProductMaterial = "Zamak" Then
            If Not frmModbus.tulisModbus(40100, 1) Then Exit Function
        Else
            If Not frmModbus.tulisModbus(40100, 0) Then Exit Function
        End If
        If LoadWOfrRFID.JobProductThread = "1/2 NPT" Then
            If LoadWOfrRFID.JobProductMaterial = "Zamak" Then
                If Not frmModbus.tulisModbus(40107, 2) Then Exit Function
            Else
                If Not frmModbus.tulisModbus(40107, 1) Then Exit Function
            End If
        Else
            If Not frmModbus.tulisModbus(40107, 0) Then Exit Function
        End If
        If LoadWOfrRFID.JobButtonType = "Yes" Then
            If Not frmModbus.tulisModbus(40108, 0) Then Exit Function
        Else
            If Not frmModbus.tulisModbus(40108, 1) Then Exit Function
        End If
        If Not frmModbus.tulisModbus(40600, 1) Then Exit Function 'reset screw counter
        Return True
        Exit Function
ErrorHandler:
        Return False
    End Function
    Dim Part As Rackconfig
    Dim Job As JobOrder
    Private Function LoadRackMaterial() As Boolean
        Dim FNum As Integer
        Dim LineStr As String
        Dim i As Integer
        ReDim Part.PartPLCWord(45)
        ReDim Part.PartNos(45)

        On Error GoTo ErrorHandler

        FNum = FreeFile()

        FileOpen(FNum, INIMATERIALPATH & "Rack\" & "Station3", OpenMode.Input)
        Do While Not EOF(FNum)
            LineStr = LineInput(FNum)
            Part.PartNos(i) = LineStr
            Part.PartPLCWord(i) = 40200 + i
            i = i + 1
        Loop
        FileClose(FNum)
        Return True
ErrorHandler:
        Return False
    End Function
    Private Function LoadModelMaterial(Unitname As String) As Boolean
        Dim FNum As Integer
        Dim LineStr As String
        Dim i As Integer
        ReDim Job.JobModelMaterial(30)

        On Error GoTo ErrorHandler

        FNum = FreeFile()

        FileOpen(FNum, INIMATERIALPATH & "Station3\" & Unitname & ".Txt", OpenMode.Input)
        Do While Not EOF(FNum)
            LineStr = LineInput(FNum)
            Job.JobModelMaterial(i) = LineStr
            i = i + 1
        Loop
        FileClose(Fnum)
        Return True
ErrorHandler:
        Return False
    End Function
    Private Function ActivateRackLED() As Boolean
        Dim i, N As Integer
        ReDim Job.JobModelMaterial(30)
        On Error GoTo ErrorHandler
        For i = 0 To 29
            If Job.JobModelMaterial(i) <> "" Then
                For N = 0 To 29
                    If Job.JobModelMaterial(i) = Part.PartNos(N) Then
                        If Not frmModbus.tulisModbus(Part.PartPLCWord(N), 1) Then
                            GoTo ErrorHandler
                        End If
                    End If
                Next
            End If
        Next
        Return True

ErrorHandler:
        Return False
    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Tagref As String
        Dim Tagnos As String
        Dim TagQty As String
        Dim Tagid As String

        Ethernet.BackColor = Color.Black
        Tagnos = RD_MULTI_RFID("0000", 10)
        Tagid = RD_MULTI_RFID("0040", 3) 'Read Tag ID
        If Tagnos = "NOK" Then GoTo NoChange
        If Tagnos = "MASTER" Then
            If Tagid = lbl_tagnos.Text Then GoTo NoChange
            If lbl_WOnos.Text <> "MASTER" Then
                'update the Current WO into the database before changing
                If CheckWOExist(lbl_WOnos.Text) Then
                    Call UpdateWO(lbl_WOnos.Text, lbl_currcounter.Text)
                Else
                    Call AddWO(lbl_WOnos.Text)
                    Call UpdateWO(lbl_WOnos.Text, lbl_currcounter.Text)
                End If
                GoTo WOChange
            ElseIf lbl_WOnos.Text = "MASTER" Then
                GoTo WOChange
            End If
        ElseIf Tagnos <> LoadWOfrRFID.JobNos Then
Master:
            Txt_Msg.BackColor = Color.LightGray
            If lbl_WOnos.Text <> "MASTER" Then
                'Checking Current WO first b4 Change Series is allowed. If WO status is open, check Quantity
                Dim CheckWO As String
                CheckWO = ValidiateWONos(lbl_WOnos.Text)
                If CheckWO = "NOK" Then
                    Txt_Msg.Text = "Invalid WO - WO is not registered in Server"
                    GoTo NoChange
                ElseIf CheckWO = "OPEN" Then

                ElseIf CheckWO = "CLOSED" Then

                ElseIf CheckWO = "FORCED" Then

                ElseIf CheckWO = "DISTRUP" Then

                End If
                'update the Current WO into the database before changing
                If CheckWOExist(lbl_WOnos.Text) Then
                    Call UpdateWO(lbl_WOnos.Text, lbl_currcounter.Text)
                Else
                    Call AddWO(lbl_WOnos.Text)
                    Call UpdateWO(lbl_WOnos.Text, lbl_currcounter.Text)
                End If
            End If
WOChange:
            Txt_Msg.Text = "Changing Series..." & vbCrLf
            Txt_Msg.Text = Txt_Msg.Text & "Reading info from RFID Tag..." & vbCrLf

            Tagref = RD_MULTI_RFID("0014", 10) 'Read WO Reference from Tag
            If Tagref = "NOK" Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to read from RFID Tag" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                Exit Sub
            End If
            TagQty = RD_MULTI_RFID("0028", 10) 'Read WO Qty from Tag
            If TagQty = "NOK" Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to read from RFID Tag" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                Exit Sub
            End If
            Tagid = RD_MULTI_RFID("0040", 3) 'Read Tag ID
            If Tagid = "NOK" Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to read from RFID Tag" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                Exit Sub
            End If
            'Check if reference is valid from the database
            If Not RefCheck(Tagref) Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Invalid Reference" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                Exit Sub
            End If
            Txt_Msg.Text = Txt_Msg.Text & "loading parameters of new reference..." & vbCrLf
            If Not LoadModelMaterial(Tagref) Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to load Model parameter" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                Exit Sub
            End If

            'Load parameters
            Txt_Msg.Text = Txt_Msg.Text & "loading parameters to PLC..." & vbCrLf
            If Not LoadParameter(Tagref) Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to load parameters..." & vbCrLf
                Exit Sub
            End If
            If Not LoadLabelParameter(Tagref) Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to load parameters..." & vbCrLf
                Exit Sub
            End If
            Reset_PLC()

            If Not ActivateRackLED() Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to communicate with PLC" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                Exit Sub
            End If
            'Send parameter to PLC
            If Not LoadParameter2PLC() Then
                MsgBox("Unable to communicate with PLC")
                End
            End If

            'LoadWOfrRFID.JobNos = Tagnos
            lbl_WOnos.Text = Tagnos
            LoadWOfrRFID.JobNos = Tagnos
            lbl_currentref.Text = Tagref
            LoadWOfrRFID.JobModelName = Tagref
            lbl_wocounter.Text = TagQty
            LoadWOfrRFID.JobQTy = TagQty
            lbl_tagnos.Text = Tagid
            LoadWOfrRFID.JobRFIDTag = Tagid

            lbl_articlenos.Text = LoadWOfrRFID.JobArticle
            UnitaryDateCode = GetDateCode()
            lbl_lastcounter.Text = Check_Serialnos(LoadWOfrRFID.JobArticle & "001" & UnitaryDateCode)
            If Tagnos <> "MASTER" Then
                If CheckWOExist(Tagnos) Then
                    LoadWOfrRFID.JobUnitaryCount = Val(RetrieveWOQty(Tagnos))
                    lbl_currcounter.Text = LoadWOfrRFID.JobUnitaryCount
                Else
                    Call AddWO(Tagnos)
                    LoadWOfrRFID.JobUnitaryCount = 0 'Reset output counter
                    lbl_currcounter.Text = "0"
                End If
            Else
                lbl_currcounter.Text = "0"
                LoadWOfrRFID.JobUnitaryCount = 0
            End If

            UpdateStnStatus()
            Txt_Msg.Text = Txt_Msg.Text & "Change Series completed" & vbCrLf
            ErasePSNFileInfo() 'clearing all variable
            PSNFileInfo.ModelName = LoadWOfrRFID.JobModelName
            PSNFileInfo.WONos = LoadWOfrRFID.JobNos

        End If
        
NoChange:
        Dim Station_status As Long
        Station_status = frmModbus.bacaModbus(40101)
        Ethernet.BackColor = Color.Lime
        TextBox4.Text = Station_status

        Select Case Station_status
            Case 0

            Case 1

            Case 2 'Checking of body and dispensing
                lbl_msg.Text = ""
                Txt_Msg.Text = "Checking in progress..."
                PictureBox2.Image = Nothing
                Txt_Msg.BackColor = Color.LightGray
            Case 3 'Inform user to start screwing process
            Case 4
                lbl_msg.Text = ""
                Txt_Msg.Text = ""
                If frmModbus.bacaModbus(40102) = 1 Then 'Pass
                    If Not frmModbus.tulisModbus(40101, 10) Then
                        Txt_Msg.Text = "--> Unable to communicate with PLC - %MW101"
                        Exit Sub
                    End If
                    PSNFileInfo.BodyAssyCheckOut = currentDate.Date & "," & Now.ToLongTimeString
                    PSNFileInfo.BodyAssyStatus = "PASS"
                    BodyTest = True
                    PictureBox2.Image = My.Resources.ResourceManager.GetObject("Pass")
                    PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
                    Action = 1
                Else 'Fail
                    PictureBox2.Image = My.Resources.ResourceManager.GetObject("FAIL")
                    PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
                    lbl_msg.Text = ""
                    Dim Failcode As Integer

                    Failcode = frmModbus.bacaModbus(40110)
                    If Failcode = 5 Then
                        Txt_Msg.Text = "--> Wrong body material"
                    ElseIf Failcode = 6 Then
                        Txt_Msg.Text = "--> Wrong body Thread"
                    ElseIf Failcode = 7 Then
                        Txt_Msg.Text = "--> Wrong body housing - Button option"
                    ElseIf Failcode = 8 Then
                        Txt_Msg.Text = "--> No Insulation base"
                    End If
                    Txt_Msg.BackColor = Color.Red
                    If Not frmModbus.tulisModbus(40101, 10) Then
                        Txt_Msg.Text = "--> Unable to communicate with PLC - %MW101"
                        Exit Sub
                    End If
                    PCBAFLAG(1) = False
                    PCBAFLAG(2) = False
                    BoardCount = LoadWOfrRFID.JobItemCount
                    Label11.Text = BoardCount
                End If
        End Select

        Select Case Action
            Case 0
            Case 1
                If BodyTest = True And ItemsScanCompleteFlag = True Then
                    'Generate PSN
                    UnitaryDateCode = GetDateCode()
                    lbl_datecode.Text = UnitaryDateCode
                    lbl_lastcounter.Text = Check_Serialnos(LoadWOfrRFID.JobArticle & "001" & UnitaryDateCode)
                    PSNFileInfo.PSN = LoadWOfrRFID.JobArticle & "001" & UnitaryDateCode & NextCounter(lbl_lastcounter.Text)
                    lbl_psn.Text = PSNFileInfo.PSN
                    PSNFileInfo.DateCreated = currentDate.Date & "," & Now.ToLongTimeString

                    'Print label
                    Txt_Msg.Text = "Printing PSN label..." & vbCrLf
                    Call ZbrPrinter1()
                    ScanMode = 1
                    frmFeedback.Label1.Text = lbl_psn.Text
                    frmFeedback.Show()
                    frmFeedback.TextBox1.Text = ""
                    Action = 2
                End If
            Case 2
                If frmFeedback.TextBox1.Text = frmFeedback.Label1.Text Then
                    frmFeedback.TextBox1.Text = ""
                    frmFeedback.Hide()
                    ScanMode = 2 'Use to disable scanning
                    If Button6.Text = "Eye Open" Then
                        Call Save_LastSerialnos(PSNFileInfo.PSN)
                        Txt_Msg.Text = Txt_Msg.Text & "Creating " & PSNFileInfo.PSN & ".Txt..." & vbCrLf
                        If Not WRITEPSNFILE(PSNFileInfo.PSN) Then
                            Txt_Msg.BackColor = Color.Red
                            Txt_Msg.Text = Txt_Msg.Text & "--> Unable to Create " & PSNFileInfo.PSN & ".Txt"
                            ScanMode = 0 'Waiting for the next product
                            Action = 0
                            ItemsScanCompleteFlag = False
                            BodyTest = False
                            Exit Sub
                        End If
                    End If
                    Txt_Msg.Text = Txt_Msg.Text & "Created " & PSNFileInfo.PSN & ".Txt" & vbCrLf
                    ScanMode = 0 'Waiting for the next product
                    Action = 0
                    ItemsScanCompleteFlag = False
                    BodyTest = False
                    'Increment Counter
                    lbl_currcounter.Text = Val(lbl_currcounter.Text) + 1
                    LoadWOfrRFID.JobUnitaryCount = lbl_currcounter.Text
                    UpdateStnStatus() 'update Status.Txt file
                    PCBAFLAG(1) = False
                    PCBAFLAG(2) = False
                    BoardCount = LoadWOfrRFID.JobItemCount
                    Label11.Text = BoardCount
                End If
        End Select
    End Sub
    Private Function ValidiateWONos(strName As String) As String
        On Error GoTo ErrorHandler
        Dim query = "Select * From CSUNIT Where WONOS = '" & strName & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)
        Dim temp As String

        temp = dt.Rows(0).Item("STATUS")

        Return temp
ErrorHandler:
        Return "NOK"
    End Function
    Private Function RefCheck(strName As String) As Boolean
        Dim temp As String
        On Error GoTo ErrorHandler
        Dim query = "Select * From Parameter Where ModelName = '" & strName & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)
        temp = dt.Rows(0).Item("ModelName")

        Return True
ErrorHandler:
        Return False
    End Function
    Private Sub ErasePSNFileInfo()
        PSNFileInfo.DateCompleted = ""
        PSNFileInfo.DateCreated = ""
        PSNFileInfo.DebugComment = ""
        PSNFileInfo.DebugStatus = ""
        PSNFileInfo.DebugTechnican = ""
        PSNFileInfo.ElectroMagnet = ""
        PSNFileInfo.FTCheckIn = ""
        PSNFileInfo.FTCheckOut = ""
        PSNFileInfo.FTStatus = ""
        PSNFileInfo.MainPCBA = ""
        PSNFileInfo.ModelName = ""
        PSNFileInfo.OperatorID = ""
        PSNFileInfo.PackagingCheckIn = ""
        PSNFileInfo.PackagingCheckOut = ""
        PSNFileInfo.PackagingStatus = ""
        PSNFileInfo.PSN = ""
        PSNFileInfo.RepairDate = ""
        PSNFileInfo.ScrewStnCheckIn = ""
        PSNFileInfo.ScrewStnCheckOut = ""
        PSNFileInfo.ScrewStnStatus = ""
        PSNFileInfo.SecondaryPCBA = ""
        PSNFileInfo.Stn5CheckIn = ""
        PSNFileInfo.Stn5CheckOut = ""
        PSNFileInfo.Stn5Status = ""
        PSNFileInfo.WONos = ""
    End Sub
    Public Function NextCounter(ByVal LastCounter As String) As String
        Dim temp As String

        temp = CLng(LastCounter) + 1

        If CLng(temp) >= 99999 Then
            MsgBox("Maximum counter 99999!", vbCritical)
            Exit Function
        End If

        If Len(temp) = 1 Then
            temp = "0000" & temp
        ElseIf Len(temp) = 2 Then
            temp = "000" & temp
        ElseIf Len(temp) = 3 Then
            temp = "00" & temp
        ElseIf Len(temp) = 4 Then
            temp = "0" & temp
        End If
        Return temp
    End Function
    Private Function ZbrPrinter(SerialNos As String) As Boolean
        Dim FILENO As Integer
        Dim strCustFileName As String
        FILENO = FreeFile()
        Dim Article As String
        On Error Resume Next

        '========= Zebra USB PORT ==========
        Dim lhPrinter As Long
        Dim lReturn As Long
        Dim lpcWritten As Long
        Dim lDoc As Long
        Dim MyDocInfo As DOCINFO
        Dim sPrinterName As String

        Article = Mid(SerialNos, 1, 6)
        sPrinterName = "Zebra TLP2844-Z"
        'lReturn = OpenPrinter(Printer.DeviceName, lhPrinter, 0)
        lReturn = OpenPrinter(sPrinterName, lhPrinter, 0)
        If lReturn = 0 Then
            MsgBox("The Printer Name you typed wasn't recognised.")
            Exit Function
        End If
        MyDocInfo.pDocName = "Servo 3"
        MyDocInfo.pOutputFile = vbNullString
        MyDocInfo.pDatatype = vbNullString
        lDoc = StartDocPrinter(lhPrinter, 1, MyDocInfo)
        Call StartPagePrinter(lhPrinter)
        'sWrittendata = "^XA^FO370,60^A0,10,15^FD" & "1234567890" & "^FS^FO310,40^BXN,5,400^FD" & "12345" & "^FS^XZ"
        sWrittendata = "^XA^FO390,105^A0,25,10^FD" & SerialNos & "^FS^FO265,85^BXN,3,200^FD" & SerialNos & "^FS^XZ"
        'sWrittendata = "^XA^FS^FO490,32^BXN,3,200^FD" & SerialNos & "^FS^XZ"
        'Call PrintPSN(sWrittendata)
        lReturn = WritePrinter(lhPrinter, sWrittendata, Len(sWrittendata), lpcWritten)

        ' read data
        Dim sReadData As String
        Dim lpcRead As Long

        lReturn = ReadPrinter(lhPrinter, sReadData, Len(sReadData), lpcRead)

        lReturn = EndPagePrinter(lhPrinter)
        lReturn = EndDocPrinter(lhPrinter)
        lReturn = ClosePrinter(lhPrinter)
        '=======================================
    End Function
    Private Function ZbrPrinter1() As Boolean
        Dim FILENO As Integer
        Dim strCustFileName As String
        FILENO = FreeFile()
        Dim Article As String
        On Error GoTo ErrorHandler

        '========= Zebra USB PORT ==========
        Dim lhPrinter As Long
        Dim lReturn As Long
        Dim lpcWritten As Long
        Dim lDoc As Long
        Dim MyDocInfo As DOCINFO
        Dim sPrinterName As String

        'Article = Mid(SerialNos, 1, 6)
        sPrinterName = "Zebra TLP2844-Z"
        'lReturn = OpenPrinter(Printer.DeviceName, lhPrinter, 0)
        lReturn = OpenPrinter(sPrinterName, lhPrinter, 0)
        If lReturn = 0 Then
            MsgBox("The Printer Name you typed wasn't recognised.")
            Exit Function
        End If
        MyDocInfo.pDocName = "Servo 3"
        MyDocInfo.pOutputFile = vbNullString
        MyDocInfo.pDatatype = vbNullString
        lDoc = StartDocPrinter(lhPrinter, 1, MyDocInfo)
        Call StartPagePrinter(lhPrinter)


        sWrittendata = "^XA^FO260,157^AQB,25,17^FD" & UnitLabel.UnitS4_1 & "^FS" & "^FO300,157^AQB,25,17^FD" & UnitLabel.UnitS4_2 & "^FS" _
                    & "^FO340,157^AQB,25,17^FD" & UnitLabel.UnitS5_1 & "^FS" & "^FO380,157^AQB,25,17^FD" & UnitLabel.UnitS5_2 & "^FS" _
                    & "^FO420,157^AQB,25,17^FD" & UnitLabel.UnitS6_1 & "^FS" & "^FO460,157^AQB,25,17^FD" & UnitLabel.UnitS6_2 & "^FS" _
                    & "^FO500,157^AQB,25,18^FD" & UnitLabel.UnitE2 & "^FS" & "^FO540,157^AQB,25,18^FD" & UnitLabel.UnitE1 & "^FS" _
                    & "^FO333,148^GB0,220,2^FS" _
                    & "^FO413,148^GB0,220,2^FS" _
                    & "^FO493,148^GB0,220,2^FS" _
                    & "^FO370,90^AQ,48,30^FD" & PSNFileInfo.ModelName & "^FS" _
                    & "^FO265,85^BXN,3,200^FD" & PSNFileInfo.PSN & "^FS^XZ"


        lReturn = WritePrinter(lhPrinter, sWrittendata, Len(sWrittendata), lpcWritten)

        ' read data
        Dim sReadData As String
        Dim lpcRead As Long

        lReturn = ReadPrinter(lhPrinter, sReadData, Len(sReadData), lpcRead)

        lReturn = EndPagePrinter(lhPrinter)
        lReturn = EndDocPrinter(lhPrinter)
        lReturn = ClosePrinter(lhPrinter)
        '=======================================
        ZbrPrinter1 = True
        Exit Function

ErrorHandler:
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RFID_Comm.Close()
        Barcode_Comm.Close()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmMaterial.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmDatabase.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button5.Enabled = False
        Timer1.Enabled = False
        GetLastConfig()

        If Not LoadParameter(LoadWOfrRFID.JobModelName) Then
            MsgBox("Unable to load parameters...")
            End
        End If

        If Not LoadLabelParameter(LoadWOfrRFID.JobModelName) Then
            MsgBox("Unable to load Label parameters...")
            End
        End If

        Reset_PLC()
        'Send parameter to PLC
        If Not LoadParameter2PLC() Then
            MsgBox("Unable to communicate with PLC")
            Timer1.Enabled = True
            Button5.Enabled = True
            Exit Sub
        End If

        'Load Rack Material List
        If Not LoadRackMaterial() Then
            MsgBox("Unable to load Rack Materials")
            Timer1.Enabled = True
            Button5.Enabled = True
            Exit Sub
        End If
        'Load Model Material
        If Not LoadModelMaterial(LoadWOfrRFID.JobModelName) Then
            MsgBox("Unable to load Model Material")
            Timer1.Enabled = True
            Button5.Enabled = True
            Exit Sub
        End If
        frmMsg.Label1.Text = "Refreshing indicators..."
        'Update Rack indicator
        If Not ActivateRackLED() Then
            MsgBox("Unable to communicate with PLC")
            Timer1.Enabled = True
            Button5.Enabled = True
            Exit Sub
        End If

        lbl_WOnos.Text = LoadWOfrRFID.JobNos
        PSNFileInfo.WONos = LoadWOfrRFID.JobNos
        lbl_currentref.Text = LoadWOfrRFID.JobModelName
        PSNFileInfo.ModelName = LoadWOfrRFID.JobModelName
        lbl_wocounter.Text = LoadWOfrRFID.JobQTy
        lbl_currcounter.Text = LoadWOfrRFID.JobUnitaryCount
        lbl_tagnos.Text = LoadWOfrRFID.JobRFIDTag
        lbl_articlenos.Text = LoadWOfrRFID.JobArticle
        LoadWOfrRFID.JobModelFW = "001"
        lbl_fw.Text = LoadWOfrRFID.JobModelFW
        UnitaryDateCode = GetDateCode()
        lbl_datecode.Text = UnitaryDateCode
        lbl_lastcounter.Text = Check_Serialnos(LoadWOfrRFID.JobArticle & LoadWOfrRFID.JobModelFW & UnitaryDateCode)
        LoadWOfrRFID.JobItemCount = CheckTotalItem(LoadWOfrRFID.JobModelName)
        BoardCount = LoadWOfrRFID.JobItemCount
        Label11.Text = BoardCount

        Timer1.Enabled = True
        Button5.Enabled = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Call frmModbus.tulisModbus(40001, 1)
        ScanMode = 0
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Call frmModbus.tulisModbus(40600, 1)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Call frmModbus.tulisModbus(40101, 10)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Button6.Text = "Eye Open" Then
            If Not frmModbus.tulisModbus(40109, 1) Then
                Txt_Msg.Text = "--> Unable to communicate with PLC - %MW109"
                Exit Sub
            End If
            Button6.Text = "Eye Close"

        ElseIf Button6.Text = "Eye Close" Then
            If Not frmModbus.tulisModbus(40109, 0) Then
                Txt_Msg.Text = "--> Unable to communicate with PLC - %MW109"
                Exit Sub
            End If
            Button6.Text = "Eye Open"
        End If
    End Sub

    Private Sub Barcode_Comm_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles Barcode_Comm.DataReceived
        If ScanMode = 0 Then 'scanning of PCBA, Electromagnet
            AssyBuf = Barcode_Comm.ReadExisting()
            If InStr(1, AssyBuf, vbCrLf) <> 0 Then
                Me.Invoke(Sub()
                              Txt_Msg.BackColor = Color.LightGray
                              Txt_Msg.Text = ""
                              AssyBuf = Mid(AssyBuf, 1, InStr(1, AssyBuf, vbCr) - 1)
                              PictureBox2.Image = Nothing

                              If lbl_WOnos.Text <> "MASTER" Then
                                  'Disable Test if WO is distrupted
                                  Dim CheckWO As String
                                  CheckWO = ValidiateWONos(lbl_WOnos.Text)
                                  If CheckWO <> "OPEN" Then
                                      Txt_Msg.BackColor = Color.Red
                                      Txt_Msg.Text = "--> Current WO is " & CheckWO
                                      AssyBuf = ""
                                  End If
                              End If

                              If PCBAFLAG(1) = False Then
                                  If VerifyPCBA1(LoadWOfrRFID.JobModelName, Mid(AssyBuf, 1, 8)) = True Then
                                      PCBAFLAG(1) = True
                                      PSNFileInfo.MainPCBA = AssyBuf
                                      If PSNFileInfo.BodyAssyCheckIn = "" Then
                                          PSNFileInfo.BodyAssyCheckIn = currentDate.Date & "," & Now.ToLongTimeString
                                      End If
                                      TextBox3.Text = AssyBuf
                                      TextBox3.BackColor = Color.Green
                                      BoardCount = BoardCount - 1
                                      Label11.Text = BoardCount
                                      If BoardCount = 0 Then GoTo SKIPVERIFY
                                      AssyBuf = ""
                                      Exit Sub
                                  End If
                              End If

                              If PCBAFLAG(2) = False Then
                                  If VerifyPCBA2(LoadWOfrRFID.JobModelName, Mid(AssyBuf, 1, 8)) = True Then
                                      PCBAFLAG(2) = True
                                      PSNFileInfo.ElectroMagnet = AssyBuf
                                      If PSNFileInfo.BodyAssyCheckIn = "" Then
                                          PSNFileInfo.BodyAssyCheckIn = currentDate.Date & "," & Now.ToLongTimeString
                                      End If
                                      TextBox2.Text = AssyBuf
                                      TextBox2.BackColor = Color.Green
                                      BoardCount = BoardCount - 1
                                      Label11.Text = BoardCount
                                      If BoardCount = 0 Then GoTo SKIPVERIFY
                                      AssyBuf = ""
                                      Exit Sub
                                  End If
                              End If
                              Txt_Msg.Text = Txt_Msg.Text & "--> Incorrect item for selected reference"
                              Txt_Msg.BackColor = Color.Red
                              PictureBox2.Image = My.Resources.ResourceManager.GetObject("Fail")
                              PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
                              AssyBuf = ""
                              Exit Sub

SKIPVERIFY:
                              ItemsScanCompleteFlag = True
                              AssyBuf = ""
                              ScanMode = 1
                          End Sub)
            End If
        ElseIf ScanMode = 1 Then 'Used after the PSN is printed and to scan by operator
            AssyBuf = Barcode_Comm.ReadExisting()
            If InStr(1, AssyBuf, vbCrLf) <> 0 Then
                Me.Invoke(Sub()
                              AssyBuf = Mid(AssyBuf, 1, InStr(1, AssyBuf, vbCr) - 1)
                              frmFeedback.TextBox1.Text = AssyBuf
                              AssyBuf = ""
                              TextBox2.BackColor = Color.White
                              TextBox3.BackColor = Color.White
                          End Sub)
            End If
        ElseIf ScanMode = 2 Then 'when process is in progress, all scanning barocodes are ignored
            AssyBuf = Barcode_Comm.ReadExisting()
            AssyBuf = ""
        End If
    End Sub
    Public Function VerifyPCBA1(csmodel As String, scannos As String) As Boolean
        Dim pcbanos As String
        On Error GoTo ErrorHandler
        Dim query = "Select * FROM Parameter WHERE ModelName = '" & csmodel & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)
        pcbanos = dt.Rows(0).Item("PrimaryPCBAType")
        If pcbanos = scannos Then
            Return True
        End If
ErrorHandler:
        Return False
    End Function
    Public Function VerifyPCBA2(csmodel As String, scannos As String) As Boolean
        Dim pcbanos As String
        On Error GoTo ErrorHandler
        Dim query = "Select * FROM Parameter WHERE ModelName = '" & csmodel & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)
        pcbanos = dt.Rows(0).Item("ElectroMagnetType")
        If Mid(pcbanos, 1, 8) = scannos Then
            Return True
        End If
ErrorHandler:
        Return False
    End Function
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim imageFileName = INISLIDEPATH & "Slide" & SlideCount & ".JPG"
        PictureBox3.Image = Image.FromFile(imageFileName)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        SlideCount = SlideCount + 1
        If SlideCount = 27 Then SlideCount = 22
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Call ZbrPrinter("024V")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call frmModbus.tulisModbus(40111, 1)
    End Sub
End Class
