Public Class Form2
    Dim cnn As New OleDb.OleDbConnection
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If
        Dim dt As New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        If RadioUser.Checked = True Then
            da = New OleDb.OleDbDataAdapter("SELECT COUNT(Username) as cnt FROM Users " & _
                                                  " WHERE Username='" & txtUsername.Text & "' and Password='" & txtPassword.Text & "'", cnn)
        Else
            da = New OleDb.OleDbDataAdapter("SELECT COUNT(Username) as cnt FROM Admin " & _
                                                  " WHERE Username='" & txtUsername.Text & "' and Password='" & txtPassword.Text & "'", cnn)
        End If
        da.Fill(dt)
        cnn.Close()
        If dt.Rows(0).Item("cnt") = 1 Then
            Form3.Show()
            Me.Close()
        Else
            lblerror.Text = "Username/Password does not match"
            txtPassword.Text = ""
            txtUsername.Text = ""
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtPassword.Text = ""
        txtUsername.Text = ""
        Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\MRStudio.accdb;"
        RadioUser.Checked = True
    End Sub

    Private Sub txtUsername_GotFocus(sender As Object, e As EventArgs) Handles txtUsername.GotFocus
        lblerror.Text = ""
    End Sub
    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        lblerror.Text = ""
    End Sub
End Class