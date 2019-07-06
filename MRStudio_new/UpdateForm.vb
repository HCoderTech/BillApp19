Public Class UpdateForm
    Public Sub CheckForUpdates()
        If ProgressBar1.Value = 100 Then
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://sowiee.com/mrstudio/update/version.txt")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()

            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())

            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion As String = Application.ProductVersion
            If newestversion.Contains(currentversion) Then
                btnUpdate.Text = ("You are up-to-date!")
                lblUpdate.Text = ("You may now close this dialog")
            Else
                btnUpdate.Text = ("Downloading update!")
                WebBrowser1.Navigate("https://dl.dropboxusercontent.com/s/r78k537lpg89ins/MRStudio_Setup.exe")
                lblUpdate.Text = ("You may now close this dialog")
            End If
        End If
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        btnUpdate.Enabled = False
        Timer1.Enabled = True
        btnUpdate.Text = "Checking for updates..."
        Timer1.Start()
        CheckForUpdates()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(5)
        lblcount.Text = ProgressBar1.Value
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
            If ProgressBar1.Value = 100 Then
                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://sowiee.com/mrstudio/update/version.txt")
                Dim response As System.Net.HttpWebResponse = request.GetResponse()

                Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())

                Dim newestversion As String = sr.ReadToEnd()
                Dim currentversion As String = Application.ProductVersion
                If newestversion.Contains(currentversion) Then
                    btnUpdate.Text = ("You are up-to-date!")
                    lblUpdate.Text = ("You may now close this dialog")
                Else
                    btnUpdate.Text = ("Downloading update!")
                    WebBrowser1.Navigate("https://dl.dropboxusercontent.com/s/r78k537lpg89ins/MRStudio_Setup.exe")
                    lblUpdate.Text = ("You may now close this dialog")
                End If
            End If
        End If

    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer1.Enabled = False
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim url As String = "http://sowiee.com/mrstudio/update/update.txt"
        Process.Start(url)
    End Sub
End Class