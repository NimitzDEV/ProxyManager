<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lbInfo = New System.Windows.Forms.Label()
        Me.btnProxyDisable = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmsRightClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.notifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmsTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiProxyList = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.llbUpdate = New System.Windows.Forms.LinkLabel()
        Me.cmsRightClick.SuspendLayout()
        Me.cmsTray.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbInfo
        '
        resources.ApplyResources(Me.lbInfo, "lbInfo")
        Me.lbInfo.Name = "lbInfo"
        '
        'btnProxyDisable
        '
        resources.ApplyResources(Me.btnProxyDisable, "btnProxyDisable")
        Me.btnProxyDisable.Name = "btnProxyDisable"
        Me.btnProxyDisable.UseVisualStyleBackColor = True
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        resources.ApplyResources(Me.ColumnHeader1, "ColumnHeader1")
        '
        'ColumnHeader2
        '
        resources.ApplyResources(Me.ColumnHeader2, "ColumnHeader2")
        '
        'ColumnHeader3
        '
        resources.ApplyResources(Me.ColumnHeader3, "ColumnHeader3")
        '
        'cmsRightClick
        '
        Me.cmsRightClick.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuEdit, Me.menuDelete})
        Me.cmsRightClick.Name = "cmsRightClick"
        resources.ApplyResources(Me.cmsRightClick, "cmsRightClick")
        '
        'menuEdit
        '
        Me.menuEdit.Name = "menuEdit"
        resources.ApplyResources(Me.menuEdit, "menuEdit")
        '
        'menuDelete
        '
        Me.menuDelete.Name = "menuDelete"
        resources.ApplyResources(Me.menuDelete, "menuDelete")
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'notifyIcon
        '
        Me.notifyIcon.ContextMenuStrip = Me.cmsTray
        resources.ApplyResources(Me.notifyIcon, "notifyIcon")
        '
        'cmsTray
        '
        Me.cmsTray.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiProxyList, Me.ToolStripMenuItem1, Me.tsmiExit, Me.tsmiAbout})
        Me.cmsTray.Name = "cmsTray"
        resources.ApplyResources(Me.cmsTray, "cmsTray")
        '
        'tsmiProxyList
        '
        Me.tsmiProxyList.Name = "tsmiProxyList"
        resources.ApplyResources(Me.tsmiProxyList, "tsmiProxyList")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'tsmiExit
        '
        Me.tsmiExit.Name = "tsmiExit"
        resources.ApplyResources(Me.tsmiExit, "tsmiExit")
        '
        'tsmiAbout
        '
        resources.ApplyResources(Me.tsmiAbout, "tsmiAbout")
        Me.tsmiAbout.Name = "tsmiAbout"
        '
        'cmsList
        '
        Me.cmsList.Name = "cmsList"
        resources.ApplyResources(Me.cmsList, "cmsList")
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'LinkLabel1
        '
        resources.ApplyResources(Me.LinkLabel1, "LinkLabel1")
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.TabStop = True
        '
        'llbUpdate
        '
        resources.ApplyResources(Me.llbUpdate, "llbUpdate")
        Me.llbUpdate.Name = "llbUpdate"
        Me.llbUpdate.TabStop = True
        '
        'frmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.llbUpdate)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnProxyDisable)
        Me.Controls.Add(Me.lbInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.TopMost = True
        Me.cmsRightClick.ResumeLayout(False)
        Me.cmsTray.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbInfo As System.Windows.Forms.Label
    Friend WithEvents btnProxyDisable As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmsRightClick As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents notifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents cmsTray As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiProxyList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents llbUpdate As System.Windows.Forms.LinkLabel

End Class
