Module mdTrayProxyListMgr
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
        MsgBox(sender.tag)
    End Sub
End Module
