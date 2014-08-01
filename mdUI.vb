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
        If getStr = "" Then getStr = "无"
        getEnable = funcGetRegeditValue("ProxyEnable")
        With frmMain
            Select Case getEnable
                Case 0
                    getEnable = "[未启用]"
                    .btnProxyDisable.Enabled = False
                    .notifyIcon.Icon = My.Resources.red
                Case 1
                    getEnable = "[已启用]"
                    .btnProxyDisable.Enabled = True
                    .notifyIcon.Icon = My.Resources.green
            End Select
            .lbInfo.Text = shortString("当前设置为：" & getEnable & " - " & getStr)
            .Text = Application.ProductName & " - " & Application.ProductVersion
            .notifyIcon.Text = .Text & vbCrLf & .lbInfo.Text
        End With
    End Sub
End Module
