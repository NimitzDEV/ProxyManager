Imports System.Text.RegularExpressions.Regex
Module mdUI
    Dim getStr As String
    Dim getEnable As String
    Public Function showEditDialog(ByRef IPAddress As String, ByRef Port As String, ByRef name As String, Optional defaultAddress As String = "", Optional defaultPort As String = "", Optional defaultName As String = "") As Boolean
        With frmAddProxy
            .Show()
            .Visible = False
            .txtIPAddress.Text = defaultAddress
            .txtPort.Text = defaultPort
            .txtName.Text = defaultName
            .ShowDialog()
            IPAddress = .txtIPAddress.Text.Trim
            Port = .txtPort.Text.Trim
            name = .txtName.Text.Trim
            .Dispose()
            If IPAddress = "" And Port = "" And name = "" Then Return False
            Return True
        End With
    End Function

    Public Sub appMsg(ByVal msgString As String)
        If frmAppMsg.Handle <> Nothing Then frmAppMsg.Close()
        frmAppMsg.Show()
        frmAppMsg.Label1.Text = msgString
    End Sub

    Public Function shortString(ByRef originString As String) As String
        If Len(originString) > 40 Then shortString = originString.Substring(0, 40) & "..."
        Return originString
    End Function

    Public Sub updateStatus()
        updateTrayList()
        getStr = funcGetRegeditValue("ProxyServer")
        If getStr = "" Then getStr = IIf(IsEnglish, My.Resources.mdUI_none, "无")
        getEnable = funcGetRegeditValue("ProxyEnable")
        With frmMain
            Select Case getEnable
                Case 0
                    getEnable = IIf(IsEnglish, My.Resources.mdUI_disable, "[未启用]")
                    .btnProxyDisable.Enabled = False
                    .notifyIcon.Icon = My.Resources.red
                Case 1
                    getEnable = IIf(IsEnglish, My.Resources.mdUI_enable, "[已启用]")
                    .btnProxyDisable.Enabled = True
                    .notifyIcon.Icon = My.Resources.green
            End Select
            .lbInfo.Text = shortString(IIf(IsEnglish, My.Resources.mdUI_current, "当前设置为：") & getEnable & " - " & getStr)
            .Text = Application.ProductName & " - " & Application.ProductVersion
            .notifyIcon.Text = .Text & vbCrLf & .lbInfo.Text
        End With
    End Sub

    Public Function checkAddress(ByVal inputAddress As String, ByVal inputPort As String) As Boolean
        If inputAddress = "" Or inputPort = "" Then Return False
        Dim address As Boolean = False
        Dim port As Boolean = False
        If IsMatch(inputAddress, "^http(s)?:\/\/([a-zA-Z0-9]([a-zA-Z0-9\-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,6}$") _
            Or IsMatch(inputAddress, _
            "^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$") Then address = True
        If Int(inputPort) > -1 And Int(inputPort) < 65536 Then port = True
        Return address And port
    End Function

End Module
