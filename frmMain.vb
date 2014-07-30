Imports Microsoft.VisualBasic.FileIO.FileSystem
Public Class frmMain
    Dim getStr As String
    Dim binFolder As String
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        writeBINConfig()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        binFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Proxy Manager\"
        If DirectoryExists(binFolder) = False Then MkDir(binFolder)
        binPath = binFolder & "proxylist.bin"
        getStr = funcGetRegeditValue("ProxyServer")
        txtIPAddress.Text = Split(getStr, ":")(0)
        txtPort.Text = Split(getStr, ":")(1)
        Me.Text = Application.ProductName & " - " & Application.ProductVersion
        readBINConfig()
    End Sub

    Private Sub btnProxyEnable_Click(sender As Object, e As EventArgs) Handles btnProxyEnable.Click
        If checkIPAddress(txtIPAddress.Text, txtPort.Text) = False Then
            MsgBox("IP地址错误或端口错误")
            Exit Sub
        End If
        setProxy(txtIPAddress.Text, txtPort.Text)
        MsgBox("代理已启用")
    End Sub

    Private Sub btnProxyDisable_Click(sender As Object, e As EventArgs) Handles btnProxyDisable.Click
        cancelProxy()
        MsgBox("代理已关闭")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nameStr, ipAddr, ipPort As String
        nameStr = ""
        ipAddr = ""
        ipPort = ""
        If showEditDialog(ipAddr, ipPort, nameStr) = False Then Exit Sub
        Dim listContext As New ListViewItem
        listContext.SubItems(0).Text = nameStr
        listContext.SubItems.Add(ipAddr)
        listContext.SubItems.Add(ipPort)
        listContext.EnsureVisible()
        listContext.Tag = nameStr & ":" & ipAddr & ":" & ipPort
        ListView1.Items.Add(listContext)
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        For Each itm As ListViewItem In ListView1.SelectedItems
            txtIPAddress.Text = itm.SubItems(1).Text
            txtPort.Text = itm.SubItems(2).Text
        Next
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
