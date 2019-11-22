Public Class ReadList
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ContinueLookingButton_Click(sender As Object, e As EventArgs) Handles ContinueLookingButton.Click
        'This will run only if the user has clicked the continue looking button
        Dim redirectPage As String
        redirectPage = Request.Url.AbsolutePath + "?" + Basket.RemoveBookFromBasket()
        Response.Redirect(redirectPage)
    End Sub

    Protected Sub Grid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Grid.SelectedIndexChanged

    End Sub


    Private Sub BindBasket()
        'This will get the books for the read list grid 
        Grid.DataSource = ReadList.GetBooksFromReadList
        Grid.DataBind()
    End Sub

    Private Sub Grid_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles Grid.RowDeleting
        'This will run if the user wants to delete a book from their read list
        Dim row As GridViewRow = Grid.Rows(e.RowIndex)
        Dim bookId As String = Grid.DataKeys(e.RowIndex).Value
        Basket.RemoveFromBasket(bookId)
        BindBasket()
    End Sub
End Class