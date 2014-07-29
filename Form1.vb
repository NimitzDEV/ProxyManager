Public Class Form1
    Dim getStr As String

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        writeBINConfig()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getStr = funcGetRegeditValue("ProxyServer")
        txtIPAddress.Text = Split(getStr, ":")(0)
        txtPort.Text = Split(getStr, ":")(1)
        Me.Text = Application.ProductName & " - " & Application.ProductVersion
        If My.Settings.listPath = "NONE" Then xmlPathSet()
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

    Private Sub xmlPathSet()
        MsgBox("需要设置代理列表保存路径，请选择一个吧")
        fbd.ShowNewFolderButton = True
        fbd.Description = "请选择一个存放列表保存的地方"
        fbd.ShowDialog()
        If fbd.SelectedPath = "" Then
            MsgBox("没有进行选择")
            Exit Sub
        End If
        My.Settings.listPath = fbd.SelectedPath
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtIPAddress.Text = "" And txtPort.Text = "" Then
            MsgBox("信息不完整，请填写")
            Exit Sub
        End If
        Dim nameStr As String = InputBox("请输入一个代理名称", "添加列表")
        If nameStr = "" Then
            MsgBox("名称为空，取消添加")
            Exit Sub
        End If
        Dim listContext As New ListViewItem
        listContext.SubItems(0).Text = nameStr
        listContext.SubItems.Add(txtIPAddress.Text)
        listContext.SubItems.Add(txtPort.Text)
        listContext.EnsureVisible()
        listContext.Tag = nameStr & ":" & txtIPAddress.Text & ":" & txtPort.Text
        ListView1.Items.Add(listContext)
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        For Each itm As ListViewItem In ListView1.SelectedItems
            txtIPAddress.Text = itm.SubItems(1).Text
            txtPort.Text = itm.SubItems(2).Text
        Next
    End Sub
End Class
