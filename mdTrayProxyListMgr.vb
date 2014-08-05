Module mdTrayProxyListMgr
    Dim ipAddress As String
    Dim ipPort As String
    Public Sub updateTrayList()
        Dim tagStr As String
        With frmMain
            .cmsList.Items.Clear()
            .cmsList.Items.Add(IIf(IsEnglish, My.Resources.mdTPLM_disableproxy, "关闭代理"), _
                               Nothing, AddressOf listEvenHandler).Tag = "proxyenable"
            .cmsList.Items.Add("-")
            For i = 0 To .ListView1.Items.Count - 1
                tagStr = .ListView1.Items(i).Tag
                .cmsList.Items.Add(tagStr.Replace(":", " - "), Nothing, AddressOf listEvenHandler).Tag = tagStr
            Next
        End With
    End Sub

    Public Sub listEvenHandler(sender As Object, e As EventArgs)
        If sender.tag = "proxyenable" Then
            cancelProxy()
            updateStatus()
            appMsg(IIf(IsEnglish, My.Resources.mdTPLM_disabled, "代理已关闭"))
            Exit Sub
        End If
        ipAddress = Split(sender.tag, ":")(1)
        ipPort = Split(sender.tag, ":")(2)
        setProxy(ipAddress, ipPort)
        appMsg(IIf(IsEnglish, My.Resources.mdTPLM_head_proxy, "代理: ") & sender.tag & IIf(IsEnglish, My.Resources.mdTPLM_last_enable, " 已启用"))
        updateStatus()
    End Sub
End Module
