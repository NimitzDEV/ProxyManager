Imports Microsoft.VisualBasic.FileIO.FileSystem
Public Class frmMain
    Dim binFolder As String
    Dim adCounter As Integer
    Dim sixCounter As Integer
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
        notifyIcon.BalloonTipTitle = Me.Text
        notifyIcon.BalloonTipText = "界面已经隐藏，点击图标显示" & vbCrLf & "右键显示快速菜单"
        notifyIcon.ShowBalloonTip(3000)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        checkCulture()
        binFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Proxy Manager\"
        If DirectoryExists(binFolder) = False Then MkDir(binFolder)
        binPath = binFolder & "proxylist.bin"
        readBINConfig()
        updateStatus()
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
            MsgBox(IIf(IsEnglish, My.Resources.frmMain_uncomplete, "数据不完整"))
            Exit Sub
        End If
        Dim listContext As New ListViewItem
        listContext.SubItems(0).Text = nameStr
        listContext.SubItems.Add(ipAddr)
        listContext.SubItems.Add(ipPort)
        listContext.EnsureVisible()
        listContext.Tag = nameStr & ":" & ipAddr & ":" & ipPort
        ListView1.Items.Add(listContext)
        updateTrayList()
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

    Private Sub notifyIcon_MouseClick(sender As Object, e As MouseEventArgs) Handles notifyIcon.MouseClick
        If e.Button <> Windows.Forms.MouseButtons.Left Then Exit Sub
        Me.Visible = Not Me.Visible
        If Me.Visible = False Then
            notifyIcon.BalloonTipTitle = Me.Text
            notifyIcon.BalloonTipText = "界面已经隐藏，点击图标显示" & vbCrLf & "右键显示快速菜单"
            notifyIcon.ShowBalloonTip(3000)
        End If
    End Sub


    Private Sub tsmiExit_Click(sender As Object, e As EventArgs) Handles tsmiExit.Click
        If appExit() = True Then
            writeBINConfig()
            Me.Dispose()
        End If

    End Sub


    Private Function appExit() As Boolean
        updateStatus()
        If MsgBox(IIf(IsEnglish, My.Resources.frmMain_exitcomfirm, "确认退出？"), _
                  MsgBoxStyle.OkCancel, IIf(IsEnglish, My.Resources.frmMain_exit, "退出")) = MsgBoxResult.Cancel Then Return False
        If btnProxyDisable.Enabled = True Then
            If MsgBox(IIf(IsEnglish, My.Resources.frmMain_closeproxy, "是否关闭代理？"), MsgBoxStyle.YesNo, _
                      IIf(IsEnglish, My.Resources.frmMain_proxyisusing, "当前正在使用代理")) = MsgBoxResult.Yes Then
                cancelProxy()
            End If
        End If
        Return True
    End Function

    Private Sub tsmiProxyList_Click(sender As Object, e As EventArgs) Handles tsmiProxyList.Click
        cmsList.Show(MousePosition.X, MousePosition.Y)
    End Sub

    Private Sub tsmiAbout_Click(sender As Object, e As EventArgs) Handles tsmiAbout.Click
        frmAbout.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmAbout.Show()
    End Sub


    Private Sub menuEdit_Click(sender As Object, e As EventArgs) Handles menuEdit.Click
        Dim editAddress As String
        Dim editPort As String
        Dim editName As String
        editName = ListView1.SelectedItems.Item(0).SubItems(0).Text
        editAddress = ListView1.SelectedItems.Item(0).SubItems(1).Text
        editPort = ListView1.SelectedItems.Item(0).SubItems(2).Text
        If showEditDialog(editAddress, editPort, editName, editAddress, editPort, editName) = False Then
            MsgBox(IIf(IsEnglish, My.Resources.frmMain_canceloruncomp, "取消或者数据不完整"))
            Exit Sub
        End If
        ListView1.SelectedItems.Item(0).SubItems(0).Text = editName
        ListView1.SelectedItems.Item(0).SubItems(1).Text = editAddress
        ListView1.SelectedItems.Item(0).SubItems(2).Text = editPort
        ListView1.SelectedItems.Item(0).Tag = editName & ":" & editAddress & ":" & editPort
        updateTrayList()
    End Sub


    Private Sub llbUpdate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbUpdate.LinkClicked
        frmUpdate.ShowDialog()
        frmUpdate.Dispose()
    End Sub


End Class
