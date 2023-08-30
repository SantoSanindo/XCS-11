Module modZebraUSB
    Public sWrittendata As String
    Public Structure DOCINFO
        Dim pDocName As String
        Dim pOutputFile As String
        Dim pDatatype As String
    End Structure
    Public Declare Function ClosePrinter Lib "winspool.drv" (ByVal _
       hPrinter As IntPtr) As Long
    Public Declare Function EndDocPrinter Lib "winspool.drv" (ByVal _
       hPrinter As IntPtr) As Long
    Public Declare Function EndPagePrinter Lib "winspool.drv" (ByVal _
       hPrinter As IntPtr) As Long
    Public Declare Function OpenPrinter Lib "winspool.drv" Alias _
       "OpenPrinterA" (ByVal pPrinterName As String, ByVal phPrinter As IntPtr, ByVal pDefault As IntPtr) As Long
    Public Declare Function StartDocPrinter Lib "winspool.drv" Alias _
       "StartDocPrinterA" (hPrinter As IntPtr, Level As Integer,
       ByRef pDocInfo As DOCINFO) As Long
    Public Declare Function StartPagePrinter Lib "winspool.drv" (ByVal _
       hPrinter As IntPtr) As Long
    Public Declare Function WritePrinter Lib "winspool.drv" (ByVal _
       hPrinter As IntPtr, pBuf As String, cdBuf As Integer,
       ByRef pcWritten As Integer) As Long
    Public Declare Function ReadPrinter Lib "winspool.drv" (ByVal _
        hPrinter As IntPtr, pBuf As String, cdBuf As Integer,
        pcRead As Integer) As Long
End Module
