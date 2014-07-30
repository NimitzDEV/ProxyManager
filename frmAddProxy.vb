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
        Me.Close()
    End Sub
End Class