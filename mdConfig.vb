Imports System.IO
Imports Microsoft.VisualBasic.FileIO.FileSystem
Module mdConfig
    Public binPath As String
    Public IsEnglish As Boolean
    Public Sub checkCulture()
        If System.Threading.Thread.CurrentThread.CurrentUICulture.LCID <> 2052 Then
            IsEnglish = True
        End If
    End Sub
    Public Sub writeBINConfig()
        Dim writeString As String = ""
        Try
            With frmMain
                If .ListView1.Items.Count = 0 Then
                    If FileExists(binPath) = True Then DeleteFile(binPath)
                    Exit Sub
                End If
                Dim FS As New System.IO.FileStream(binPath, FileMode.Create)
                Dim Bw As New System.IO.BinaryWriter(FS, System.Text.Encoding.Unicode)
                For i = 0 To .ListView1.Items.Count - 1
                    Bw.Write(.ListView1.Items(i).Tag)
                Next
                Bw.Close()
                FS.Close()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub readBINConfig()
        Try
            If FileExists(binPath) = False Then Exit Sub
            Dim FS As New System.IO.FileStream(binPath, FileMode.Open)
            Dim Br As New System.IO.BinaryReader(FS, System.Text.Encoding.Unicode)
            Do While Not (FS.Position = FS.Length)
                addListItem(Br.ReadString)
            Loop
            Br.Close()
            FS.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub addListItem(ByVal stringAdd As String)
        With frmMain
            Dim addItem As New ListViewItem
            addItem.SubItems(0).Text = Split(stringAdd, ":")(0)
            addItem.SubItems.Add(Split(stringAdd, ":")(1))
            addItem.SubItems.Add(Split(stringAdd, ":")(2))
            addItem.Tag = stringAdd.Replace(vbCrLf, "")
            .ListView1.Items.Add(addItem)
        End With
    End Sub
End Module
