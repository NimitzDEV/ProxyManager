Public Class frmUpdate
    Dim docString As String
    Dim versionString As String
    Dim linkString As String
    Dim updateString As String
    Dim spliter() As String = {"≠"}
    Public timeout As Integer = 20

    Private Sub frmUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = 128
        Me.Top = frmMain.Top
        wbStart.Navigate("http://nimitzdev.free3v.net/update/update_dlljgl.html")
        PictureBox1.Image = My.Resources.wait64px
    End Sub

    Private Sub wbStart_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wbStart.DocumentCompleted
        'Dim gs() As String = (From mt As HtmlElement In wbStart.Document.Links Select System.Text.RegularExpressions.Regex.Match(mt.OuterHtml, "http://[^\x22 >]+").Value).ToArray
        'If gs.Count = 0 Then
        '    MsgBox("噢~真不好意思~服务器打了一下小瞌睡，重新试一次叫醒她")
        '    Me.Close()
        '    Exit Sub
        'End If
        'wbInfo.Navigate(gs(0))
        wbInfo.Navigate("http://nimitzdev.free3v.net/update/update_dlljgl.html")
    End Sub

    Private Sub wbInfo_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wbInfo.DocumentCompleted
        docString = New System.IO.StreamReader(wbInfo.DocumentStream, System.Text.Encoding.Default).ReadToEnd
        versionString = Split(docString, "≡")(1).Trim
        updateString = Split(docString, "≡")(2).Trim
        linkString = Split(docString, "≡")(3).Trim
        detectUpdate()
    End Sub

    Private Sub detectUpdate()
        If isNew() = False Then
            ProgressBar1.Visible = False
            lbStatus.Text = "当前已经是最新版本 （" & Application.ProductVersion & "）"
            lbStatus.ForeColor = Color.DodgerBlue
            btnClose.Top = 51
            PictureBox1.Image = My.Resources.uptodate64px
        Else
            If listLoaded() = True Then btnDownload.Enabled = True
            Me.Height = 260
            txtDetails.Visible = True
            txtDetails.Text = updateString
            PictureBox1.Image = My.Resources.new64px
            lbStatus.Text = "检测到新的版本可以下载！" & vbCrLf & "- 新的版本：" & versionString & vbCrLf & "- 当前版本：" & Application.ProductVersion
            lbStatus.ForeColor = Color.Green
        End If
        btnClose.Text = "关闭"
        tmrTimeOut.Enabled = False
    End Sub

    Private Function isNew() As Boolean
        For i = 0 To 3
            If Int(Split(versionString, ".")(i)) > Int(Split(Application.ProductVersion, ".")(i)) Then
                Return True
            ElseIf Int(Split(versionString, ".")(i)) < Int(Split(Application.ProductVersion, ".")(i)) Then
                Return False
            End If
        Next
        Return False
    End Function

    Private Function listLoaded() As Boolean
        Dim downloadList() As String
        If linkString = "" Then Return False
        Try
            downloadList = linkString.Split(spliter, StringSplitOptions.RemoveEmptyEntries)
            For i = 0 To downloadList.Count - 1
                cmsDownloadList.Items.Add(Split(downloadList(i), "∫")(0), _
                               Nothing, AddressOf downloadClickHandler).Tag = Split(downloadList(i), "∫")(1)
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub downloadClickHandler(sender As Object, e As EventArgs)
        Process.Start(sender.tag)
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tmrTimeOut_Tick(sender As Object, e As EventArgs) Handles tmrTimeOut.Tick
        timeout -= 1
        If timeout < 0 Then
            wbStart.Stop()
            wbInfo.Stop()
            tmrTimeOut.Enabled = False
            MsgBox("与服务器的连接超时" & vbCrLf & "建议您重试即可")
            Me.Close()
        End If
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        cmsDownloadList.Show(btnDownload, 0, btnDownload.Height)
    End Sub
End Class