Imports Microsoft.Win32
Module mdProxy
    'IE设置函数
    Private Declare Function internetsetoption Lib "wininet.dll" Alias "InternetSetOptionA" _
    (ByVal hinternet As Long, ByVal dwoption As Long, ByRef lpBuffer As Integer, ByVal dwbufferlength As Long) As Long
    '注册表相关
    Public regKeyPath As String = "Software\Microsoft\Windows\CurrentVersion\Internet Settings\"
    Public Function funcGetRegeditValue(ByVal regName As String) As String
        Dim reg As RegistryKey
        Dim strReturn As String = String.Empty
        reg = Registry.CurrentUser
        reg = reg.OpenSubKey(regKeyPath, True)
        strReturn = reg.GetValue(regName)
        Return strReturn
    End Function
    Public Sub funcSetRegeditValue(ByVal regName As String, ByVal regValue As String, ByVal rvKind As RegistryValueKind)
        Dim reg As RegistryKey
        reg = Registry.CurrentUser
        reg = reg.OpenSubKey(regKeyPath, True)
        reg.SetValue(regName, regValue, rvKind)
    End Sub
    Public Sub setProxy(ByVal ProxyIPAddress As String, ByVal ProxyIPPort As Integer)
        funcSetRegeditValue("ProxyServer", ProxyIPAddress & ":" & ProxyIPPort, RegistryValueKind.String)
        funcSetRegeditValue("ProxyEnable", "1", RegistryValueKind.DWord)
        Call internetsetoption(0, 39, 0, 0)
    End Sub
    Public Sub cancelProxy()
        funcSetRegeditValue("ProxyEnable", "0", RegistryValueKind.DWord)
        Call internetsetoption(0, 39, 0, 0)
    End Sub
    Public Function checkIPAddress(ByVal IPAddress As String, ByVal Port As String) As Boolean
        Dim checkIncrease As Integer = 0
        Try
            For i = 0 To 3
                If Split(IPAddress, ".")(i) > -1 And Split(IPAddress, ".")(i) < 255 Then checkIncrease += 1
            Next
            If InStr(IPAddress, ".") < 4 Then Return False
            If checkIncrease < 4 Then Return False
            If Int(Port) < 0 Or Int(Port) > 65535 Then Return False
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
