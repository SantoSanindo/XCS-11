Imports System.Data.SqlClient
Module modGeneral
    Public Sub GetLastConfig()
        Dim Filenum As Integer
        Filenum = FreeFile()
        Dim tempcode As String
        Dim pos1, pos2, pos3, pos4, pos5 As Integer

        FileOpen(Filenum, INISTATUSPATH, OpenMode.Input)

        tempcode = LineInput(Filenum)
        FileClose(Filenum)

        pos1 = InStr(1, tempcode, ",")
        pos2 = InStr(pos1 + 1, tempcode, ",")
        pos3 = InStr(pos2 + 1, tempcode, ",")
        pos4 = InStr(pos3 + 1, tempcode, ",")

        LoadWOfrRFID.JobNos = Mid(tempcode, 1, pos1 - 1)
        LoadWOfrRFID.JobModelName = Mid(tempcode, pos1 + 1, (pos2 - pos1) - 1)
        LoadWOfrRFID.JobQTy = Mid(tempcode, pos2 + 1, (pos3 - pos2) - 1)
        LoadWOfrRFID.JobRFIDTag = Mid(tempcode, pos3 + 1, (pos4 - pos3) - 1)
        LoadWOfrRFID.JobUnitaryCount = Mid(tempcode, pos4 + 1)

    End Sub
    Public Function GetDateCode() As String
        Dim YY, WW As String
        YY = Right(Now.Year.ToString(), 2)
        WW = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.FirstFullWeek).ToString("00")

        If Len(WW) = 1 Then
            WW = "0" & WW
        End If
        Return YY & WW
    End Function
    Public Function Check_Serialnos(AAAAAARRRYYWW As String) As String
        Dim query = "Select * FROM SERIAL WHERE RVYYWW = '" & AAAAAARRRYYWW & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)
        Dim tempor As String
        On Error GoTo ErrorHandler

        tempor = dt.Rows(0).Item("LASTNOS")
        Return tempor

ErrorHandler:
        Return "00000"
    End Function
    Public Function CheckTotalItem(csmodel As String) As Integer
        Dim query = "Select * FROM Parameter WHERE ModelName = '" & csmodel & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)
        Dim ItemCount As Integer

        On Error Resume Next

        If dt.Rows(0).Item("PrimaryPCBAType") <> "" Then ItemCount = ItemCount + 1
        If dt.Rows(0).Item("SecondaryPCBAType") <> "" Then ItemCount = ItemCount + 1
        If dt.Rows(0).Item("ElectroMagnetType") <> "" Then ItemCount = ItemCount + 1

        Return ItemCount
    End Function
    Public Function CheckWOExist(WO As String) As Boolean
        On Error GoTo ErrorHandler
        Dim temp As String
        Dim query = "Select * From STN3 Where WONOS = '" & WO & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        temp = dt.Rows(0).Item("WONOS")
        Return True
ErrorHandler:
        Return False
    End Function
    Public Function UpdateWO(WO As String, updateqty As String) As Boolean
        On Error GoTo ErrorHandler
        Dim konek As New SqlConnection(Database)
        Dim sql As String = "Update STN3 Set OUTPUT = '" & updateqty & "' Where WONOS = '" & WO & "'"
        konek.Open()
        Dim sc As New SqlCommand(sql, konek)
        Dim adapter As New SqlDataAdapter(sc)
        If adapter.SelectCommand.ExecuteNonQuery().ToString() = 1 Then
            'MsgBox("Saving succeed!")
            konek.Close()
        Else
            MsgBox("Saving Failed!")
        End If
        Return True
ErrorHandler:
        MsgBox("Error Update WO!")
        Return False
    End Function
    Public Function AddWO(WO As String) As Boolean
        On Error GoTo ErrorHandler
        Dim konek As New SqlConnection(Database)
        Dim sql As String = "INSERT INTO STN3 (WONOS,OUTPUT) VALUES ('" & WO & "', 0)"
        konek.Open()
        Dim sc As New SqlCommand(sql, konek)
        Dim adapter As New SqlDataAdapter(sc)
        If adapter.SelectCommand.ExecuteNonQuery().ToString() = 1 Then
            MsgBox("Saving succeed!")
            konek.Close()
        Else
            MsgBox("Saving Failed!")
        End If
        Return True
ErrorHandler:
        MsgBox("Error AddWO!")
        Return False
    End Function
    Public Function RetrieveWOQty(WO As String) As String
        Dim readqty As String
        Dim query = "Select * FROM STN3 WHERE WONOS = '" & WO & "'"
        Dim dt = KoneksiDB.bacaData(query).Tables(0)

        readqty = dt.Rows(0).Item("OUTPUT")
        Return readqty
    End Function
    Public Function UpdateStnStatus() As Boolean
        Dim Filenum1 As Integer
        Filenum1 = FreeFile()
        FileOpen(Filenum1, INISTATUSPATH, OpenMode.Output)
        PrintLine(Filenum1, LoadWOfrRFID.JobNos & "," & LoadWOfrRFID.JobModelName & "," & LoadWOfrRFID.JobQTy & "," & LoadWOfrRFID.JobRFIDTag & "," & LoadWOfrRFID.JobUnitaryCount)
        FileClose(Filenum1)
        Return True
    End Function
    Public Function Save_LastSerialnos(Lastpsn As String) As Boolean
        Dim Lastcount As String
        Dim anrvdc As String

        On Error GoTo ErrorHandler

        Lastcount = Right(Lastpsn, 5)
        anrvdc = Left(Lastpsn, 13)
        Console.WriteLine("LastCount : " & Lastcount)
        Console.WriteLine("anrvdc : " & anrvdc)
        Dim konek As New SqlConnection(Database)
        Dim sql As String = "Update SERIAL Set LASTNOS = '" & Lastcount & "' Where RVYYWW = '" & anrvdc & "'"
        konek.Open()
        Dim sc As New SqlCommand(sql, konek)
        Dim adapter As New SqlDataAdapter(sc)
        If adapter.SelectCommand.ExecuteNonQuery().ToString() = 1 Then
            'MsgBox("Saving succeed!1")
            konek.Close()
            Return True
        Else
            'MsgBox("Saving Failed!1")
            Return False
        End If

ErrorHandler:
        Dim nkonek As New SqlConnection(Database)
        Dim nsql As String = "INSERT INTO SERIAL (RVYYWW,LASTNOS) VALUES ('" & anrvdc & "', '" & Lastcount & "')"
        nkonek.Open()
        Dim nsc As New SqlCommand(nsql, nkonek)
        Dim nadapter As New SqlDataAdapter(nsc)
        If nadapter.SelectCommand.ExecuteNonQuery().ToString() = 1 Then
            'MsgBox("Saving succeed!2")
            nkonek.Close()
            Return True
        Else
            'MsgBox("Saving Failed!2")
            Return False
        End If
    End Function
End Module
