Public Class frmAddProxy

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtIPAddress.Text = ""
        txtName.Text = ""
        txtPort.Text = ""
        Me.Close()
    End Sub

    Private Sub frmAddProxy_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If checkAddress(txtIPAddress.Text, txtPort.Text) = False Then
            MsgBox("地址或端口数值有误")
            Exit Sub
        End If
        Me.Close()
    End Sub
End Class