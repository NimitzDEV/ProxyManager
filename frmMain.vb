Imports Microsoft.VisualBasic.FileIO.FileSystem
Public Class frmMain
    Dim getStr As String
    Dim getEnable As String
    Dim binFolder As String
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        writeBINConfig()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        binFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Proxy Manager\"
        If DirectoryExists(binFolder) = False Then MkDir(binFolder)
        binPath = binFolder & "proxylist.bin"
        updateStatus()
        Me.Text = Application.ProductName & " - " & Application.ProductVersion
        readBINConfig()
    End Sub

    Private Sub updateStatus()
        getStr = funcGetRegeditValue("ProxyServer")
        If getStr = "" Then getStr = "无"
        getEnable = funcGetRegeditValue("ProxyEnable")
        Select Case getEnable
            Case 0
                getEnable = "[未启用]"
                btnProxyDisable.Enabled = False
            Case 1
                getEnable = "[已启用]"
                btnProxyDisable.Enabled = True
        End Select
        lbInfo.Text = shortString("当前设置为：" & getEnable & " - " & getStr)
    End Sub

    Private Sub btnProxyDisable_Click(sender As Object, e As EventArgs) Handles btnProxyDisable.Click
        cancelProxy()
        updateStatus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nameStr, ipAddr, ipPort As String
        nameStr = ""
        ipAddr = ""
        ipPort = ""
        If showEditDialog(ipAddr, ipPort, nameStr) = False Then Exit Sub
        If nameStr = "" Or ipAddr = "" Or ipPort = "" Then
            MsgBox("数据不完整")
            Exit Sub
        End If
        Dim listContext As New ListViewItem
        listContext.SubItems(0).Text = nameStr
        listContext.SubItems.Add(ipAddr)
        listContext.SubItems.Add(ipPort)
        listContext.EnsureVisible()
        listContext.Tag = nameStr & ":" & ipAddr & ":" & ipPort
        ListView1.Items.Add(listContext)
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Try
            setProxy(ListView1.SelectedItems.Item(0).SubItems(1).Text, ListView1.SelectedItems.Item(0).SubItems(2).Text)
            updateStatus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseClick
        If e.Button <> Windows.Forms.MouseButtons.Right Then Exit Sub
        cmsRightClick.Show(ListView1, e.Location)
    End Sub

    Private Sub menuDelete_Click(sender As Object, e As EventArgs) Handles menuDelete.Click
        For Each itm As ListViewItem In ListView1.SelectedItems
            ListView1.Items.Remove(itm)
        Next
    End Sub

End Class
