Public Class UserForm
    Dim st As Integer = 0
    Dim cnn As New OleDb.OleDbConnection
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.UsersTableAdapter.Fill(Me.MRStudioDataSet2.Users)
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\MRStudio.accdb;"
    End Sub
    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        UsersBindingSource.MovePrevious()
    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        UsersBindingSource.AddNew()
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        UsersBindingSource.MoveNext()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        UsersBindingSource.EndEdit()
        UsersTableAdapter.Adapter.Update(MRStudioDataSet2.Users)
        st = 1
        MessageBox.Show("Changes Saved")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        UsersBindingSource.RemoveCurrent()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        If st = 1 Then
            MessageBox.Show("Application will restart", "Restart Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Application.Restart()
        End If
    End Sub
    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Dim cmd As New OleDb.OleDbCommand
        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()
        End If
        cmd.Connection = cnn
        cmd.CommandText = "UPDATE [Admin] SET [Password] = '" & txtPassword.Text & "' WHERE [ID] =1"
        cmd.ExecuteNonQuery()
        cnn.Close()
        MessageBox.Show("Password Changed", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class