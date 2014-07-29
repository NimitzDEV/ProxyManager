Imports System.IO

Module mdConfig
    Public Sub writeBINConfig()
        Dim writeString As String
        With Form1
            If .ListView1.Items.Count = 0 Then Exit Sub
            writeString = .ListView1.Items(0).Tag
            If .ListView1.Items.Count > 1 Then
                For i = 1 To .ListView1.Items.Count - 1
                    writeString &= "§" & .ListView1.Items(i).Tag
                Next
            End If
        End With
        Dim FS As New System.IO.FileStream(Application.StartupPath & "\Test.dat", FileMode.Create)
        Dim Bw As New System.IO.BinaryWriter(FS, System.Text.Encoding.Unicode)
        Bw.Write(writeString)
        Bw.Close()
        FS.Close()
    End Sub

    Public Sub readBINConfig()
        If Dir(Application.StartupPath & "\test.dat") = "" Then Exit Sub

        Dim FS As New System.IO.FileStream(Application.StartupPath & "\test.dat", FileMode.Open)
        Dim Br As New System.IO.BinaryReader(FS, System.Text.Encoding.Unicode)
        Dim getStr() As String
        Dim subStr As String
        getStr = Br.ReadString.Split("§")
        If getStr.Count = 1 Then
            addListItem(getStr(0))
        Else
            For i = 0 To getStr.Count - 1
                subStr = getStr(i)
                addListItem(subStr)
            Next
        End If
        Br.Close()
        FS.Close()
    End Sub

    Private Sub addListItem(ByVal stringAdd As String)
        With Form1
            Dim addItem As New ListViewItem
            addItem.SubItems(0).Text = Split(stringAdd, ":")(0)
            addItem.SubItems.Add(Split(stringAdd, ":")(1))
            addItem.SubItems.Add(Split(stringAdd, ":")(2))
            addItem.Tag = stringAdd
            .ListView1.Items.Add(addItem)
        End With
    End Sub
End Module
