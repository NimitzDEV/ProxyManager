Public Class frmAppMsg

    Private Sub Label1_SizeChanged(sender As Object, e As EventArgs) Handles Label1.SizeChanged
        Me.Width = Label1.Width + 40
        Label1.Left = 20
        Me.Left = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - Me.Width
    End Sub

    Private Sub Label1_TextChanged(sender As Object, e As EventArgs) Handles Label1.TextChanged

    End Sub

    Private Sub frmAppMsg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height * 0.2
        Me.Height = Label1.Height + 20
        Label1.Top = 10
        Me.Left = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - Me.Width
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub
End Class