
Imports BillApp.DBHelper
Imports BillApp.Presenter
Imports BillApp.ViewHelper

Public Class LoginForm
    Implements ILoginView
    Dim presenter As ILoginPresenter
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        presenter = New LoginPresenter(Me, New LoginDBHelper)
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If RadioUser.Checked Then
            presenter.LoginAsUser(txtUsername.Text, txtPassword.Text)
        Else
            presenter.LoginAsAdmin(txtUsername.Text, txtPassword.Text)
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        presenter.CancelLogin()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        RadioUser.Checked = True
    End Sub

    Private Sub txtUsername_GotFocus(sender As Object, e As EventArgs) Handles txtUsername.GotFocus
        ClearError()
    End Sub
    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        ClearError()
    End Sub

    Public Sub SetError(msg As String) Implements ILoginView.SetError
        lblerror.Text = msg
    End Sub

    Public Sub ClearFields() Implements ILoginView.ClearFields
        txtPassword.Text = ""
        txtUsername.Text = ""
    End Sub

    Public Sub ShowMainForm() Implements ILoginView.ShowMainForm
        MainForm.Show()
    End Sub

    Public Sub CloseView() Implements ILoginView.CloseView
        Close()
    End Sub

    Public Sub ClearError() Implements ILoginView.ClearError
        lblerror.Text = ""
    End Sub
End Class