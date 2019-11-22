Public Class DepartmentsList
    Inherits System.Web.UI.UserControl

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'The departmentIndex parameter is added to the query string when a department link is clicked.
        'This is because that when the page is reloaded, the DataList forgets which link was clicked.
        Dim listIndex As String = Request.QueryString("departmentIndex")
        'If listIndex has a value, the user has clicked on a type of book
        If Not listIndex Is Nothing Then
            List.SelectedIndex = CInt(listIndex)
        End If
        'Get departments returns a SqlDataReader object that has two fields: TypeOfBookID and Name.
        'These fields are read in the SelectedItemTemplate and ItemTemplate of the DataList
        List.DataSource = Catalog.GetBookTypes()
        List.DataBind()
    End Sub

End Class