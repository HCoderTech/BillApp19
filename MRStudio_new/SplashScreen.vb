Imports BillApp.Presenter
Imports BillApp.ViewHelper

Public Class SplashScreen
    Implements ISplashScreenView
    Dim presenter As ISplashScreenPresenter
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        presenter = New SplashScreenPresenter(Me)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        presenter.IncrementLoadProgress()
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

    Public Sub IncrementProgressBar(value As Integer) Implements ISplashScreenView.IncrementProgressBar
        ProgressBar1.Increment(value)
    End Sub

    Public Sub CloseView() Implements ISplashScreenView.CloseView
        Me.Close()
    End Sub

    Public Sub ShowLoginForm() Implements ISplashScreenView.ShowLoginForm
        Form2.Show()
    End Sub
End Class
