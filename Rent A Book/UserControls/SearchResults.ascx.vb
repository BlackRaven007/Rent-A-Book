Public Class WebUserControl3
    Inherits System.Web.UI.UserControl

    Private Sub page_load(ByVal sender As System.Object, ByVal ex As System.EventArgs) Handles MyBase.Load
        'This will only load if the user has tried searching for something
        Dim searchString As String = Request.QueryString("Search")
        Dim PageNumber As String = Request.QueryString("PageNumber")
        Dim BooksOnPage As String = Request.QueryString("BooksOnPage")

        Dim HowManyResults As Integer
        'This will get the number of books found relating to what the user has searched for
        HowManyResults = Catalog.SearchCatalog(searchString, PageNumber, BooksOnPage)
        'If there are no results the website will display a message saying that no books were found
        If HowManyResults = 0 Then
            titleLabel.Text = "Your search for <font-style = italic>" + searchString + " had no results"
            pageNumberLabel.Visible = False
            PreviousPage.Visible = False
            NextPage.Visible = False
        Else
            'Otherwise it will display to the user how many results were found
            titleLabel.Text = "Your search for <font-style = italic>" + searchString + " gave back " + HowManyResults.ToString + " results"
            Dim HowManyPages As Integer
            'This will contain how many pages of results are needed
            HowManyPages = Math.Ceiling(HowManyResults / (CType(BooksOnPage, Integer)))

            pageNumberLabel.Text = "Page" + PageNumber.ToString + " of " + HowManyPages.ToString
            'If the user is on page one, 'previous page' option will be hidden and next page will be shown
            If PageNumber = 1 Then
                PreviousPage.Visible = False
                NextPage.Visible = True
            Else
                PreviousPage.NavigateUrl = "?search=" + searchString + "&PageNumber" + (CType(PageNumber, Integer) - 1).ToString + "BooksOnPage=" + BooksOnPage.ToString
            End If
            'If the user is on the last page, the next page option will be hidden instead
            If PageNumber = HowManyPages Then
                NextPage.Visible = False
            Else
                NextPage.NavigateUrl = "?search=" + searchString + "&PageNumber" + (CType(PageNumber, Integer) + 1).ToString + "&BooksOnPage=" + BooksOnPage.ToString
            End If
        End If
    End Sub

End Class