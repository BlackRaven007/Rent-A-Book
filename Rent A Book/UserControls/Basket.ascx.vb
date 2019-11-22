Imports System.Net.Mail

Public Class Basket1
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            BindBasket()
        End If
    End Sub

    Private Sub BindBasket()
        'This will first check to see the total amount the users basket comes to
        Dim cost As Decimal = Basket.GetTotalCost()
        TotalCostLabel.Text = String.Format("{0:c}", cost)
        'If it comes to 0 then the basket must be empty, this means a message is displayed telling the user
        If cost = 0 Then
            IntroductionLabel.Text = "Your basket is empty!!!!"
            'This will hide the basket
            Grid.Visible = False
        Else
            'Otherwise it will get the books stored in the basket and display them
            Grid.DataSource = Basket.GetBooksFromBasket
            Grid.DataBind()
        End If
    End Sub

    Private Sub ContinueLookingButton_Click(sender As Object, e As EventArgs) Handles ContinueLookingButton.Click
        Dim redirectPage As String
        'This will only run if the user has clicked on the continue looking button
        redirectPage = Request.Url.AbsolutePath + "?" + Basket.RemoveBookFromBasket()
        Response.Redirect(redirectPage)
    End Sub

    Private Sub Grid_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles Grid.RowCancelingEdit
        'If the user is on edit mode in the basket and they click cancel this is called to take them out of edit mode
        Grid.EditIndex = -1
        BindBasket()
    End Sub

    Private Sub Grid_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles Grid.RowDeleting
        Dim row As GridViewRow = Grid.Rows(e.RowIndex)
        Dim bookId As String = Grid.DataKeys(e.RowIndex).Value
        'This is run when the user wants to delete a book from their basket
        Basket.RemoveFromBasket(bookId)
        BindBasket()
    End Sub

    Private Sub Grid_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles Grid.RowEditing
        'This will open the basket in edit mode
        Grid.EditIndex = e.NewEditIndex
    End Sub

    Private Sub Grid_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles Grid.RowUpdating
        Dim row As GridViewRow = Grid.Rows(e.RowIndex)
        Dim bookId As String = Grid.DataKeys(e.RowIndex).Value
        Dim days As String = TryCast(row.FindControl("TextBox1"), TextBox).Text
        'When the user wants to change the number of days they want to rent a book out, this is called
        Try
            'This will call a function from the basket class to save the new number of days
            Basket.UpdateBasket(bookId, days)
            'However if an exception is thrown, this will catch it and inform the user they can only enter in a valid number of days
        Catch ex As Exception
            IntroductionLabel.Text = "You can only enter valid number of days"
        Finally
            Grid.EditIndex = -1
            BindBasket()
        End Try
    End Sub

    Protected Sub Checkout_Click(sender As Object, e As EventArgs) Handles Checkout.Click
        'If the user wants to checkout and they clicked the checkout button, this is called
        Try
            Dim SmtpServer As New SmtpClient
            Dim mail As New MailMessage
            SmtpServer.UseDefaultCredentials = False
            'This will enter in the credentials of the website email account
            SmtpServer.Credentials = New Net.NetworkCredential("rentabookreply@gmail.com", "Password")
            SmtpServer.Port = 587
            SmtpServer.EnableSsl = True
            SmtpServer.Host = "smtp.gmail.com"
            'These next few lines composes the email
            mail = New MailMessage()
            mail.From = New MailAddress("rentabookreply@gmail.com")
            mail.To.Add("UserEmail")
            mail.Subject = "Rent A Book MATCH"
            mail.IsBodyHtml = False
            'This is the message sent to the owner of the book
            mail.Body = "Congratulations....we have a match for a book you have on our system.\nPlease log in to RentABook for details!"
            SmtpServer.Send(mail)
            'This create a popup box telling the user that the message has been sent
            MsgBox("Confirmation mail sent")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class