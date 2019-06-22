Public Class SplashScreen
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ProgressBar1.Increment(1)
        If ProgressBar1.Value = 100 Then
            Form2.Show()
            Me.Close()
        End If
    End Sub

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim path1 As String
        Dim path2 As String
        path1 = "MRStudio\"
        If (Not System.IO.Directory.Exists(path1)) Then
            System.IO.Directory.CreateDirectory(path1)
        End If
        path2 = "MRStudio\count.txt"
        If Not System.IO.File.Exists(path2) Then
            Using sw As System.IO.StreamWriter = System.IO.File.CreateText(path2)
                sw.Write("50000")
            End Using
        End If
    End Sub
End Class
