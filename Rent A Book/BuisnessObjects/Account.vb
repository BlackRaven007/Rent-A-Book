Imports System.Data.SqlClient

Public Class Account

    Private Shared ReadOnly Property connectionString() As String
        Get
            ' Return ConfigurationSettings.AppSettings("ConnectionString")
            Return System.Configuration.ConfigurationManager.AppSettings("ConnectionString")

        End Get
    End Property

    Public Shared Function AddUser(ByVal Name As String, ByVal Email As String, ByVal Password As String)
        Dim connection As New SqlConnection(connectionString)
        'This will load the sql procedure AddtoUserTable
        Dim command As New SqlCommand("AddToUserTable", connection)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add("@name", SqlDbType.Char, 36)
        command.Parameters("@name").Value = Name
        command.Parameters.Add("@email", SqlDbType.Char, 36)
        command.Parameters("@email").Value = Email
        command.Parameters.Add("@password", SqlDbType.Char, 36)
        command.Parameters("@password").Value = Password
        Try
            'This will open the connecetion to the database which holds the procedures
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
        Return 0
    End Function

    Public Shared Function CheckUser(ByVal Email As String, ByVal Password As String)
        Dim connection As New SqlConnection(connectionString)
        'This will load the sql procedure CheckUser
        Dim command As New SqlCommand("CheckUser", connection)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add("@email", SqlDbType.Char, 36)
        command.Parameters("@email").Value = Email
        command.Parameters.Add("@password", SqlDbType.Char, 36)
        command.Parameters("@password").Value = Password
        command.Parameters.Add("@Emailwordcount", SqlDbType.Int)
        command.Parameters("@Emailwordcount").Direction = ParameterDirection.Output

        Dim authentic As Integer = 0
        Try
            'This will open the connecetion to the database which holds the procedures
            connection.Open()
            command.ExecuteNonQuery()
            'This will save the results to the variable called authentic
            authentic = command.Parameters("@Emailwordcount").Value
        Finally
            connection.Close()
        End Try
        'This passes out the variable to the calling function
        Return authentic
    End Function

    Public Shared Function AddBooktoTheBooksTable(ByVal Name As String, ByVal Description As String, ByVal PricePerDay As String)
        Dim connection As New SqlConnection(connectionString)
        'This will load the sql procedure AddtoThe BooksTable
        Dim command As New SqlCommand("AddToTheBooksTable", connection)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add("@bookName", SqlDbType.Char, 36)
        command.Parameters("@bookName").Value = Name
        command.Parameters.Add("@description", SqlDbType.Char, 36)
        command.Parameters("@description").Value = Description
        command.Parameters.Add("@pricePerDay", SqlDbType.Char, 36)
        command.Parameters("@pricePerDay").Value = Convert.ToDouble(PricePerDay)
        command.Parameters.Add("@bookId", SqlDbType.Int, 36)
        command.Parameters("@bookId").Direction = ParameterDirection.Output
        Dim bookId As Integer = 0
        Try
            'This will open the connecetion to the database which holds the procedures
            connection.Open()
            command.ExecuteNonQuery()
            bookId = command.Parameters("@bookId").Value
        Finally
            connection.Close()
        End Try
        Return bookId
    End Function

    Public Shared Function LinkUserAndBook(ByVal BookId As Integer, ByVal Email As String)
        Dim userID As Integer = getUserId(Email)
        Dim connection As New SqlConnection(connectionString)

        'This will load the sql procedure AddtoUserJunction
        Dim command As New SqlCommand("AddToUserJunction", connection)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add("@bookId", SqlDbType.Int, 36)
        command.Parameters("@bookId").Value = BookId
        command.Parameters.Add("@userId", SqlDbType.Char, 36)
        command.Parameters("@UserId").Value = userID
        Try
            'This will open the connecetion to the database which holds the procedures
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
        Return 0
    End Function

    Private Shared Function getUserId(ByVal Email As String)
        Dim connection As New SqlConnection(connectionString)
        'This will load the sql procedure GetUserId
        Dim command As New SqlCommand("GetUserId", connection)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Add("@email", SqlDbType.Char, 36)
        command.Parameters("@email").Value = Email
        command.Parameters.Add("@userId", SqlDbType.Int, 36)
        command.Parameters("@userId").Direction = ParameterDirection.Output
        Dim userId As Integer = 0
        Try
            'This will open the connecetion to the database which holds the procedures
            connection.Open()
            command.ExecuteNonQuery()
            userId = command.Parameters("@userId").Value
        Finally
            connection.Close()
        End Try
        Return userId

    End Function
End Class
