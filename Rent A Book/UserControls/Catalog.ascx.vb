Public Class Catalog1
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim TypeOfBooksID As String = Request.QueryString("TypeOfBooksID")
        Dim GenreOfBookID As String = Request.QueryString("GenreOfBookID")
        'This will check if one of the genres have been clicked on
        If Not GenreOfBookID Is Nothing Then
            Dim GenreOfBooksDetails As New GenreOfBooksDetails()
            'If it has then this will set the title of the page too its name and a description of it is shown too
            'The line below calls a function from the catalog class to get this information from the table
            GenreOfBooksDetails = Catalog.GetGenreOfBookDetails(GenreOfBookID)
            sectionTitleLabel.Text = GenreOfBooksDetails.Name
            descriptionLabel.Text = GenreOfBooksDetails.Description
            'If a genre hasent been selected it will then check to see if a type of book has been selected
        ElseIf Not TypeOfBooksID Is Nothing Then
            'If it has then this will set the title of the page too its name and a description of it is shown too
            'The line below calls a function from the catalog class to get this information from the table
            Dim TypeOfBookDetails As New TypeOfBookDetails()
            TypeOfBookDetails = Catalog.GetTypeOfBookDetails(TypeOfBooksID)
            sectionTitleLabel.Text = TypeOfBookDetails.Name
            descriptionLabel.Text = TypeOfBookDetails.Description
        End If
    End Sub

End Class