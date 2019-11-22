Public Class BooksList
    Inherits System.Web.UI.UserControl

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim TypeOfBooksID As String = Request.QueryString("TypeOfBooksID")
        Dim GenreOfBookID As String = Request.QueryString("GenreOfBookID")
        Dim searchString As String = Request.QueryString("Search")
        'This will check to see if the user has searched for anything
        If Not searchString Is Nothing Then
            List.DataSource = Session("searchTable")
            List.DataBind()
            Session.Remove("searchTable")
            'This will see if a genre has been selected
        ElseIf Not GenreOfBookID Is Nothing Then
            'If so it will call the function GetBooksInGenre from the catalog class
            List.DataSource = Catalog.GetBooksInGenre(GenreOfBookID)
            List.DataBind()
            'This will see if a type of book has been selected
        ElseIf Not TypeOfBooksID Is Nothing Then
            'If so it will call the function GetBooksOnTypeOfBookPromotion from the catalog class
            List.DataSource = Catalog.GetBooksOnTypeOfBookPromotion(TypeOfBooksID)
            List.DataBind()
        Else
            List.DataSource = Catalog.GetBooksOnGenreOfBookPromotion()
            List.DataBind()
        End If
    End Sub

    Private Sub list_ItemCommand(ByVal source As Object, ByVal ex As System.Web.UI.WebControls.DataListCommandEventArgs) Handles List.ItemCommand
        Dim bookId As String = ex.CommandArgument
        Basket.AddBooks(bookId)
    End Sub



End Class