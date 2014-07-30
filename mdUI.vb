﻿Module mdUI
    Public Function showEditDialog(ByRef IPAddress As String, ByRef Port As String, ByRef name As String, Optional defaultAddress As String = "", Optional defaultPort As String = "", Optional defaultName As String = "") As Boolean
        With frmAddProxy
            .Show()
            .Visible = False
            .txtIPAddress.Text = defaultAddress
            .txtPort.Text = defaultPort
            .txtName.Text = defaultName
            .ShowDialog()
            IPAddress = .txtIPAddress.Text.Trim
            Port = .txtPort.Text.Trim
            name = .txtName.Text.Trim
            .Dispose()
            If IPAddress = "" Or Port = "" Or name = "" Then
                MsgBox("数据不完整")
                Return False
            End If
            Return True
        End With
    End Function
End Module