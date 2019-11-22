Public Class AddBooksPage
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        Dim Email As String = EmailTextBox.Text
        Dim Password As String = PasswordTextBox.Text
        Dim BookName As String = NameOfBookTextBox.Text
        Dim Description As String = DescriptionOfTheBookTextBox.Text
        Dim PricePerDay As String = PriceTextBox.Text
        'This will get the list of selected genres
        Dim SelectedGenres As ListItem = GenreCheckBoxList.SelectedItem
        'This will call the function Checkuser to see if the user entered valid credentials
        Dim authentic As Integer = Account.CheckUser(Email, Password)
        'This will check if the variable authentic equals 1
        If authentic <> 1 Then
            'If it does it means that the user has entered invalid login credentials
            AddBookLabel.Text = "Your Email or Password is incorrect!"
        Else
            'Otherwise it will call the following two functions from the Account class to save the book to the books table and link the owner of the book to the book
            Dim BookId As Integer = Account.AddBooktoTheBooksTable(BookName, Description, PricePerDay)
            Account.LinkUserAndBook(BookId, Email)
        End If


    End Sub
End Class