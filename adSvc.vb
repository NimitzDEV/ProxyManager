Module adSvc
    Dim wbStart As WebBrowser
    Dim wbInfo As WebBrowser
    Public docString As String
    Dim spliter() As String = {"≡"}
    Dim spliter2() As String = {"≠"}
    Public adList() As String
    Public Sub getAd()
        If System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable = False Then Exit Sub
        wbStart = New WebBrowser
        wbInfo = New WebBrowser
        wbStart.ScriptErrorsSuppressed = True
        wbInfo.ScriptErrorsSuppressed = True
        AddHandler wbStart.DocumentCompleted, AddressOf wbStart_OK
        AddHandler wbInfo.DocumentCompleted, AddressOf wbInfo_OK
        wbStart.Navigate("http://nimitzdev.free3v.net/adsvc/adsvclist.txt")
        Debug.Print("√")
    End Sub
    Private Sub wbStart_OK()
        Dim gs() As String = (From mt As HtmlElement In wbStart.Document.Links Select System.Text.RegularExpressions.Regex.Match(mt.OuterHtml, "http://[^\x22 >]+").Value).ToArray
        If gs.Count = 0 Then
            getAd()
            Exit Sub
        End If
        Debug.Print(gs(0))
        wbInfo.Navigate(gs(0))
    End Sub
    Private Sub wbInfo_OK()
        docString = wbInfo.DocumentText.Split(spliter, StringSplitOptions.RemoveEmptyEntries)(1).Trim
        If docString = "" Then Exit Sub
        loadAd()
    End Sub
    Private Sub loadAd()
        adList = docString.Split(spliter2, StringSplitOptions.RemoveEmptyEntries)
    End Sub
End Module
