Public Class WebUserControl2
    Inherits System.Web.UI.UserControl

    Private Sub searchTextBox_TextChanged(ByVal sender As System.Object, ByVal ex As System.EventArgs) Handles searchTextBox.TextChanged
        ExecuteSearch()
    End Sub

    Private Sub ExecuteSearch()
        If Trim(searchTextBox.Text) <> "" Then
            Response.Redirect(Request.Url.AbsolutePath + "?Search=" + searchTextBox.Text + "&PageNumber=1&BooksOnPage=4")
        End If
    End Sub

End Class