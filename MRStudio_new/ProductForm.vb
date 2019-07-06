Public Class ProductForm

    Dim st As Integer = 0
    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        ProductDetailBindingSource1.MovePrevious()
    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ProductDetailBindingSource1.AddNew()
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ProductDetailBindingSource1.MoveNext()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ProductDetailBindingSource1.EndEdit()
        ProductDetailTableAdapter1.Adapter.Update(MRStudioDataSet1.ProductDetail)
        st = 1
        MessageBox.Show("Changes Saved")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ProductDetailBindingSource1.RemoveCurrent()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        If st = 1 Then
            MessageBox.Show("Application will restart", "Restart Required", MessageBoxButtons.OK)
            Application.Restart()
        End If
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MRStudioDataSet1.ProductDetail' table. You can move, or remove it, as needed.
        Me.ProductDetailTableAdapter1.Fill(Me.MRStudioDataSet1.ProductDetail)

    End Sub
End Class