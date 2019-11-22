Public Class _default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim TypeOfBooksID As String = Request.QueryString("TypeOfBooksID")
        Dim searchString As String = Request.QueryString("Search")
        Dim ViewBasket As String = Request.QueryString("ViewBasket")
        Dim ReadList As String = Request.QueryString("ReadList")
        Dim SignUp As String = Request.QueryString("SignUp")
        Dim AddBooksPage As String = Request.QueryString("AddBooksPage")
        'This if statement checks to see if the user has clicked the Add book button
        If Not AddBooksPage Is Nothing Then
            Dim control As Control
            'If it has it will load the Add books page from the UserControls folder
            control = Page.LoadControl("UserControls/AddBooksPage.ascx")
            pageContentsCell.Controls.Add(control)
            'This elseif statement checks to see if the user has clicked the Signup button
        ElseIf Not SignUp Is Nothing Then
            Dim control As Control
            'If it has it will load the signup page from the UserControls folder
            control = Page.LoadControl("UserControls/SignUpPage.ascx")
            pageContentsCell.Controls.Add(control)
            'This elseif statement checks to see if the user has clicked the Read list button
        ElseIf Not ReadList Is Nothing Then
            Dim control As Control
            'If it has it will load the ReadList page from the UserControls folder
            control = Page.LoadControl("UserControls/ReadList.ascx")
            pageContentsCell.Controls.Add(control)
            'This elseif statement checks to see if the user has clicked of the View Basket button
        ElseIf Not ViewBasket Is Nothing Then
            Dim control As Control
            'If it has it will load the Basket page from the UserControls folder
            control = Page.LoadControl("UserControls/Basket.ascx")
            pageContentsCell.Controls.Add(control)
            'This elseif statement checks to see if the user has typed in anything in the search box
        ElseIf Not searchString Is Nothing Then
            Dim control As Control
            'If it has it will load the SearchResults page from the UserControls folder
            control = Page.LoadControl("UserControls/SearchResults.ascx")
            pageContentsCell.Controls.Add(control)
            'This elseif statement checks to see if the user has clicked one of the type of books, fiction or non-fiction
        ElseIf Not TypeOfBooksID Is Nothing Then
            Dim control As Control
            'If it has it will load the Catalog page from the UserControls folder
            control = Page.LoadControl("UserControls/Catalog.ascx")
            pageContentsCell.Controls.Add(control)
            'Otherwise it will just load first page from the UserControls folder
        Else
            Dim control As Control
            control = Page.LoadControl("UserControls/FirstPage.ascx")
            pageContentsCell.Controls.Add(control)
        End If
    End Sub

    Protected Sub ViewBasketButton_Click(sender As Object, e As EventArgs) Handles ViewBasketButton.Click
        If Request.QueryString("ViewBasket") Is Nothing Then
            Response.Redirect("default.aspx?ViewBasket=1&" & Request.QueryString.ToString())
        End If
    End Sub

    Protected Sub SignUpButton_Click(sender As Object, e As EventArgs) Handles SignUpButton.Click
        If Request.QueryString("SignUp") Is Nothing Then
            Response.Redirect("default.aspx?SignUp=1&" & Request.QueryString.ToString())
        End If
    End Sub

    Protected Sub AddBookButton_Click(sender As Object, e As EventArgs) Handles AddBookButton.Click
        If Request.QueryString("AddBooksPage") Is Nothing Then
            Response.Redirect("default.aspx?AddBooksPage=1&" & Request.QueryString.ToString())
        End If
    End Sub

    Protected Sub ReadList_Click(sender As Object, e As EventArgs) Handles ReadList.Click
        If Request.QueryString("ReadList") Is Nothing Then
            Response.Redirect("default.aspx?ReadList=1&" & Request.QueryString.ToString())
        End If
    End Sub
End Class