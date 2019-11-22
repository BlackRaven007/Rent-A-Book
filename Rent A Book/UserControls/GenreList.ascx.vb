Public Class WebUserControl1
    Inherits System.Web.UI.UserControl

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim TypeOfBooksID As String = Request.QueryString("TypeOfBooksID")
        'This will check if a type of book has been clicked
        If Not TypeOfBooksID Is Nothing Then
            Dim listIndex As String = Request.QueryString("GenreIndex")
            If Not listIndex Is Nothing Then
                list.SelectedIndex = CInt(listIndex)
            End If
            'If one of them have been clicked, it will display the list of genres belonging to that type of book
            list.DataSource = Catalog.GetGenresInTypeOfBook(TypeOfBooksID)
            list.DataBind()
        End If
    End Sub

End Class