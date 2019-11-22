Public Class SignUpPage
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub SignUpButton_Click(sender As Object, e As EventArgs) Handles SignUpButton.Click
        'This function will only load if the user has clicked on the signup button at the bottom of the signup page
        Dim name As String = NameTextBox.Text
        Dim email As String = EmailTextBox.Text
        Dim password As String = PasswordTextBox.Text
        Dim rePassword As String = ReEnterPasswordTextBox.Text
        'This will compare the string in password to the string in rePassword
        If password <> rePassword Then
            'If they do not match the program will display the message below on the website
            SignUpLabel.Text = "Passwords do not match, please re-enter"
        Else
            'If the passwords to match it will attempt to add the details to the table
            Try
                Account.AddUser(name, email, password)
                SignUpLabel.Text = "You have signed up!"
                hide()
                'If there is an error returned from trying to add the account, it would be because the email address is already in use
            Catch ex As Exception
                'The website will then tell the user about the email already in use
                SignUpLabel.Text = "This email address is already in use!"
            End Try
        End If
    End Sub

    Private Sub hide()
        'This function will hide everything on the page
        NameLabel.Visible = False
        NameTextBox.Visible = False
        EmailLabel.Visible = False
        EmailTextBox.Visible = False
        PasswordLabel.Visible = False
        PasswordTextBox.Visible = False
        ReEnterPasswordLabel.Visible = False
        ReEnterPasswordTextBox.Visible = False
        SignUpButton.Visible = False
    End Sub
End Class