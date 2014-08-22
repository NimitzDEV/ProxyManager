<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdate
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdate))
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.wbStart = New System.Windows.Forms.WebBrowser()
        Me.txtDetails = New System.Windows.Forms.TextBox()
        Me.wbInfo = New System.Windows.Forms.WebBrowser()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tmrTimeOut = New System.Windows.Forms.Timer(Me.components)
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.cmsDownloadList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbStatus
        '
        Me.lbStatus.AutoSize = True
        Me.lbStatus.Location = New System.Drawing.Point(95, 12)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(107, 12)
        Me.lbStatus.TabIndex = 1
        Me.lbStatus.Text = "正在查找更新....."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(97, 53)
        Me.ProgressBar1.MarqueeAnimationSpeed = 10
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(348, 23)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 2
        '
        'wbStart
        '
        Me.wbStart.Location = New System.Drawing.Point(1, 106)
        Me.wbStart.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbStart.Name = "wbStart"
        Me.wbStart.ScriptErrorsSuppressed = True
        Me.wbStart.Size = New System.Drawing.Size(160, 94)
        Me.wbStart.TabIndex = 3
        Me.wbStart.Visible = False
        '
        'txtDetails
        '
        Me.txtDetails.Location = New System.Drawing.Point(97, 53)
        Me.txtDetails.Multiline = True
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.ReadOnly = True
        Me.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDetails.Size = New System.Drawing.Size(348, 130)
        Me.txtDetails.TabIndex = 4
        Me.txtDetails.Visible = False
        '
        'wbInfo
        '
        Me.wbInfo.Location = New System.Drawing.Point(176, 106)
        Me.wbInfo.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbInfo.Name = "wbInfo"
        Me.wbInfo.ScriptErrorsSuppressed = True
        Me.wbInfo.Size = New System.Drawing.Size(160, 94)
        Me.wbInfo.TabIndex = 5
        Me.wbInfo.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(17, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(370, 24)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "取消"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tmrTimeOut
        '
        Me.tmrTimeOut.Enabled = True
        Me.tmrTimeOut.Interval = 1000
        '
        'btnDownload
        '
        Me.btnDownload.Enabled = False
        Me.btnDownload.Location = New System.Drawing.Point(370, 189)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(75, 23)
        Me.btnDownload.TabIndex = 7
        Me.btnDownload.Text = "立即下载"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'cmsDownloadList
        '
        Me.cmsDownloadList.Name = "cmsDownloadList"
        Me.cmsDownloadList.Size = New System.Drawing.Size(61, 4)
        '
        'frmUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 218)
        Me.Controls.Add(Me.btnDownload)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtDetails)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lbStatus)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.wbStart)
        Me.Controls.Add(Me.wbInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "检查更新"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents wbStart As System.Windows.Forms.WebBrowser
    Friend WithEvents txtDetails As System.Windows.Forms.TextBox
    Friend WithEvents wbInfo As System.Windows.Forms.WebBrowser
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents tmrTimeOut As System.Windows.Forms.Timer
    Friend WithEvents btnDownload As System.Windows.Forms.Button
    Friend WithEvents cmsDownloadList As System.Windows.Forms.ContextMenuStrip
End Class
