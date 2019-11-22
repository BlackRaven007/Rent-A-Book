Imports System.Data.SqlClient

Public Class Basket
    Friend Shared EditItemIndex As Integer

    Private Shared ReadOnly Property basketId()
        Get
            Dim context As HttpContext = HttpContext.Current
            'This will check if the user has cookies
            If context.Request.Cookies("RentABook_BasketID") Is Nothing Then
                'If they do not it will create one
                Dim cartID As Guid = Guid.NewGuid()
                Dim cookie As New HttpCookie("RentABook_BasketID", cartID.ToString)
                Dim currentDate As DateTime = DateTime.Now()
                Dim expiry As DateTime = currentDate.Add(New TimeSpan(10, 0, 0, 0))
                cookie.Expires = expiry
                context.Response.Cookies.Add(cookie)
                Return cartID.ToString
            Else
                Return context.Request.Cookies("RentABook_BasketID").Value
            End If
        End Get
    End Property

    Private Shared ReadOnly Property connectionString() As String
        Get
            Return ConfigurationManager.AppSettings("connectionString")
        End Get
    End Property

    Public Shared Function AddBooks(ByVal bookId As String)
        Dim connection As New SqlConnection(connectionString)
        'This will load the sql procedure AddtoBasket
        Dim command As New SqlCommand("AddToBasket", connection)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add("@basketID", SqlDbType.Char, 36)
        command.Parameters("@basketID").Value = basketId
        command.Parameters.Add("@BookID", SqlDbType.Int)
        command.Parameters("@BookID").Value = bookId
        Try
            'This will open the connecetion to the database which holds the procedures
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
        Return 0
    End Function

    Public Shared Function UpdateBasket(ByVal bookId As String, ByVal days As Integer)
        Dim connection As New SqlConnection(connectionString)
        'This will load the sql procedure UpdateBasket
        Dim command As New SqlCommand("UpdateBasket", connection)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add("@basketID", SqlDbType.Char, 36)
        command.Parameters("@basketID").Value = basketId
        command.Parameters.Add("@BookID", SqlDbType.Int)
        command.Parameters("@BookID").Value = bookId
        command.Parameters.Add("@Days", SqlDbType.Int)
        command.Parameters("@Days").Value = days
        Try
            'This will open the connecetion to the database which holds the procedures
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
        Return 0
    End Function

    Public Shared Function RemoveFromBasket(ByVal bookId As String)
        Dim connection As New SqlConnection(connectionString)
        'This will load the sql procedure RemoveFromBasket
        Dim command As New SqlCommand("RemoveFromBasket", connection)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add("@basketID", SqlDbType.Char, 36)
        command.Parameters("@basketID").Value = basketId
        command.Parameters.Add("@BookID", SqlDbType.Int)
        command.Parameters("@BookID").Value = bookId
        Try
            'This will open the connecetion to the database which holds the procedures
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
        Return 0
    End Function

    Public Shared Function GetBooksFromBasket() As SqlDataReader
        Dim connection As New SqlConnection(connectionString)
        'This will load the sql procedure GetBooksForBasket
        Dim command As New SqlCommand("GetBooksForBasket", connection)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add("@basketID", SqlDbType.Char, 36)
        command.Parameters("@basketID").Value = basketId
        Try
            'This will open the connecetion to the database which holds the procedures
            connection.Open()
            Return command.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            connection.Close()
            Throw ex
        End Try
    End Function

    Public Shared Function GetTotalCost() As Decimal
        Dim connection As New SqlConnection(connectionString)
        'This will load the sql procedure TotalCost
        Dim command As SqlCommand = New SqlCommand("TotalCost", connection)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add("@basketID", SqlDbType.Char, 36)
        command.Parameters("@basketID").Value = basketId
        Dim total As Decimal = 0
        Try
            'This will open the connecetion to the database which holds the procedures
            connection.Open()
            total = command.ExecuteScalar()
        Finally
            connection.Close()
        End Try
        Return total
    End Function

    Public Shared Function RemoveBookFromBasket() As String
        Dim newQueryString As String = String.Empty
        Try
            'This will run in order to remove the book the user has selected from their basket
            Dim query As System.Collections.Specialized.NameValueCollection
            query = HttpContext.Current.Request.QueryString
            Dim paramname As String
            Dim paramvalue As String
            Dim i As Integer
            For i = 0 To query.Count - 1
                If Not query.AllKeys(i) Is Nothing Then
                    paramname = query.AllKeys(i).ToString()
                    If paramname.ToUpper <> "VIEWBASKET" Then
                        paramvalue = query.Item(i)
                        newQueryString = newQueryString + paramname + "=" + paramvalue + "&"
                    End If
                End If
            Next
        Catch ex As Exception
            Return String.Empty
        End Try
        Return newQueryString
    End Function

End Class
