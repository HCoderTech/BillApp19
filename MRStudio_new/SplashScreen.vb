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
        presenter.InitializeEnvironment()
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
