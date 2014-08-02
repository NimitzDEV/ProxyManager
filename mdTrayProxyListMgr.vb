Module mdTrayProxyListMgr
    Dim ipAddress As String
    Dim ipPort As String
    Public Sub updateTrayList()
        Dim tagStr As String
        With frmMain
            .cmsList.Items.Clear()
            .cmsList.Items.Add("关闭代理", Nothing, AddressOf listEvenHandler).Tag = "proxyenable"
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
            appMsg("代理已关闭")
            Exit Sub
        End If
        ipAddress = Split(sender.tag, ":")(1)
        ipPort = Split(sender.tag, ":")(2)
        setProxy(ipAddress, ipPort)
        appMsg("代理: " & sender.tag & " 已启用")
        updateStatus()
    End Sub
End Module
