Imports System.Data.SqlClient

Public Class TypeOfBookDetails
    Public Name As String
    Public Description As String
End Class

Public Class GenreOfBooksDetails
    Public Name As String
    Public Description As String
End Class

Public Class Catalog
    Public Shared Function GetBookTypes() As SqlDataReader
        'This will open a connection object
        Dim connection As New SqlConnection(connectionString)
        'The line beneath will call the SQL stored procedure GetTypeOfBooks
        Dim command As New SqlCommand("GetTypeOfBooks", connection)
        command.CommandType = CommandType.StoredProcedure
        connection.Open()
        'This will return an SqlDataReader
        Return command.ExecuteReader(CommandBehavior.CloseConnection)
    End Function

    Private Shared ReadOnly Property connectionString() As String
        Get
            ' Return ConfigurationSettings.AppSettings("ConnectionString")
            Return System.Configuration.ConfigurationManager.AppSettings("ConnectionString")

        End Get
    End Property

    Public Shared Function GetTypeOfBookDetails(ByVal TypeOfBooksId As String) As TypeOfBookDetails
        Dim connection As New SqlConnection(connectionString)
        'The line beneath will call the SQL stored procedure GetTypeOfBooksDetails
        Dim command As New SqlCommand("GetTypeOfBooksDetails", connection)
        command.CommandType = CommandType.StoredProcedure
        'These are the parameters being passed in
        command.Parameters.Add("@TypeOfBooksID", SqlDbType.Int, 4)
        command.Parameters("@TypeOfBooksID").Value = TypeOfBooksId
        command.Parameters.Add("@Name", SqlDbType.VarChar, 50)
        command.Parameters("@Name").Direction = ParameterDirection.Output
        command.Parameters.Add("@Description", SqlDbType.VarChar, 200)
        command.Parameters("@Description").Direction = ParameterDirection.Output
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
        Dim details As New TypeOfBookDetails()
        details.Name = command.Parameters("@Name").Value.ToString()
        details.Description = command.Parameters("@Description").Value.ToString()
        Return details
    End Function

    Public Shared Function GetGenresInTypeOfBook(ByVal TypeOfBooksId As String) As SqlDataReader
        Dim connection As New SqlConnection(connectionString)
        'The line beneath will call the SQL stored procedure GetGenreFromTypeOfBooks
        Dim command As New SqlCommand("GetGenreFromTypeOfBooks", connection)
        command.CommandType = CommandType.StoredProcedure
        'This is the the parameter being passed in
        command.Parameters.Add("@TypeOfBooksID", SqlDbType.Int, 4)
        command.Parameters("@TypeOfBooksID").Value = TypeOfBooksId
        Try
            connection.Open()
            Return command.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            connection.Close()
            Throw ex
        End Try
    End Function

    Public Shared Function GetGenreOfBookDetails(ByVal GenreOfBooksId As String) As GenreOfBooksDetails
        Dim connection As New SqlConnection(connectionString)
        'The line beneath will call the SQL stored procedure GetgenreOfBookDetails
        Dim command As New SqlCommand("GetGenreOfBookDetails", connection)
        command.CommandType = CommandType.StoredProcedure
        'These are the parameters being passed through
        command.Parameters.Add("@GenreOfBookID", SqlDbType.Int, 4)
        command.Parameters("@GenreOfBookID").Value = GenreOfBooksId
        command.Parameters.Add("@Name", SqlDbType.VarChar, 50)
        command.Parameters("@Name").Direction = ParameterDirection.Output
        command.Parameters.Add("@Description", SqlDbType.VarChar, 200)
        command.Parameters("@Description").Direction = ParameterDirection.Output
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
        Dim details As New GenreOfBooksDetails()
        details.Name = command.Parameters("@Name").Value.ToString()
        details.Description = command.Parameters("@Description").Value.ToString()
        Return details
    End Function

    Public Shared Function GetBooksInGenre(ByVal GenreOfBooksId As String) As SqlDataReader
        Dim connection As New SqlConnection(connectionString)
        'The line beneath will call the SQL stored procedure GetbooksInGenre
        Dim command As New SqlCommand("GetBooksInGenre", connection)
        command.CommandType = CommandType.StoredProcedure
        'This is the parameter being passed in
        command.Parameters.Add("@GenreOfBookID", SqlDbType.Int, 4)
        command.Parameters("@GenreOfBookID").Value = GenreOfBooksId
        Try
            connection.Open()
            Return command.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            connection.Close()
            Throw ex
        End Try
    End Function

    Public Shared Function GetBooksOnTypeOfBookPromotion(ByVal TypeOfBooksID As String) As SqlDataReader
        Dim connection As New SqlConnection(connectionString)
        Dim command As New SqlCommand("GetBooksOnTypeOfBookPromotion", connection)
        command.CommandType = CommandType.StoredProcedure
        'This will pass through a parameter called TypeOfBooksID
        command.Parameters.Add("@TypeOfBooksID", SqlDbType.Int, 4)
        command.Parameters("@TypeOfBooksID").Value = TypeOfBooksID
        Try
            connection.Open()
            Return command.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            connection.Close()
            Throw ex
        End Try
    End Function

    Public Shared Function GetBooksOnGenreOfBookPromotion() As SqlDataReader
        Dim connection As New SqlConnection(connectionString)
        Dim command As New SqlCommand("GetBooksOnGenrePromotion", connection)
        command.CommandType = CommandType.StoredProcedure
        Try
            connection.Open()
            Return command.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            connection.Close()
            Throw ex
        End Try
    End Function

    Public Shared Function SearchCatalog(ByVal searchString As String, ByVal pageNumber As String, ByVal booksOnPage As String) As Integer
        Dim connection As New SqlConnection(connectionString)
        Dim command As New SqlCommand("SearchCatalog", connection)
        command.CommandType = CommandType.StoredProcedure
        'This will pass through the parameters @pageNumber, @BooksOnPage and @HowManyResults into the SQL stored procedure
        command.Parameters.Add("@PageNumber", SqlDbType.Int)
        command.Parameters("@PageNumber").Value = pageNumber
        command.Parameters.Add("@BooksOnPage", SqlDbType.Int)
        command.Parameters("@BooksOnPage").Value = booksOnPage
        command.Parameters.Add("@HowManyResults", SqlDbType.Int)
        command.Parameters("@HowManyResults").Direction = ParameterDirection.Output

        Dim words() As String = Split(searchString, " ")
        Dim wordCount As Integer = words.Length
        Dim index As Integer = 0
        Dim addedwords As Integer = 0
        'This will keep looping around until eiter addedwords equal 5 or less, or index is smaller than wordCount
        While addedwords < 5 And index < wordCount
            'This checks if the length of the word is bigger than two
            If Len(words(index)) > 2 Then
                'This is so that the resuls will not come up with every book with a single letter that matches it
                addedwords += 1
                command.Parameters.AddWithValue("@word" + addedwords.ToString, words(index))
            End If
            index += 1
        End While

        Try
            connection.Open()
            Dim reader As SqlDataReader
            reader = command.ExecuteReader(CommandBehavior.CloseConnection)
            Dim table As New DataTable()
            Dim fieldCount As Integer = reader.FieldCount
            Dim fieldindex As Integer
            For fieldindex = 0 To fieldCount - 1
                table.Columns.Add(reader.GetName(fieldindex), reader.GetFieldType(fieldindex))
            Next
            Dim row As DataRow
            While reader.Read()
                row = table.NewRow()
                For fieldindex = 0 To fieldCount - 1
                    row(fieldindex) = reader(fieldindex)
                Next
                table.Rows.Add(row)
            End While
            reader.Close()
            HttpContext.Current.Session("searchTable") = table
            Return command.Parameters("@HowManyResults").Value
        Catch ex As Exception
            connection.Close()
            Throw ex
        End Try
    End Function
End Class
