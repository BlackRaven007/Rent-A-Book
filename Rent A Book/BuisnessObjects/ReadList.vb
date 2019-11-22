Imports System.Data.SqlClient

Public Class ReadList
    Private Shared ReadOnly Property rentlistId()
        Get
            Dim context As HttpContext = HttpContext.Current
            'This will check if the user has cookies
            If context.Request.Cookies("RentABook_RentListID") Is Nothing Then
                'If they do not it will create one
                Dim listID As Guid = Guid.NewGuid()
                Dim cookie As New HttpCookie("RentABook_RentListID", listID.ToString)
                context.Response.Cookies.Add(cookie)
                Return listID.ToString
            Else
                Return context.Request.Cookies("RentABook_RentListID").Value
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
        'This will call the SQL stored procedure AddToReadList
        Dim command As New SqlCommand("AddToReadList", connection)
        command.CommandType = CommandType.StoredProcedure
        'These are the parameters being passed into the procedure
        command.Parameters.Add("@listID", SqlDbType.Char, 36)
        command.Parameters("@listID").Value = rentlistId
        command.Parameters.Add("@BookID", SqlDbType.Int)
        command.Parameters("@BookID").Value = bookId
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
        Return 0
    End Function

    Public Shared Function RemoveFromReadList(ByVal bookId As String)
        Dim connection As New SqlConnection(connectionString)
        'This will call the SQL stored procedure RemoveFromReadList
        Dim command As New SqlCommand("RemoveFromReadList", connection)
        command.CommandType = CommandType.StoredProcedure
        'These are the parameters being passed into the procedure
        command.Parameters.Add("@listID", SqlDbType.Char, 36)
        command.Parameters("@listID").Value = rentlistId
        command.Parameters.Add("@BookID", SqlDbType.Int)
        command.Parameters("@BookID").Value = bookId
        Try
            connection.Open()
            command.ExecuteNonQuery()
        Finally
            connection.Close()
        End Try
        Return 0
    End Function

    Public Shared Function GetBooksFromReadList() As SqlDataReader
        Dim connection As New SqlConnection(connectionString)
        'This will call the SQL stored procedure GetBooksForReadList
        Dim command As New SqlCommand("GetBooksForReadList", connection)
        command.CommandType = CommandType.StoredProcedure
        'This is the only parameter being passed into the procedure
        command.Parameters.Add("@listID", SqlDbType.Char, 36)
        command.Parameters("@listID").Value = rentlistId
        Try
            connection.Open()
            Return command.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            connection.Close()
            Throw ex
        End Try
    End Function

    Public Shared Function RemoveBookFromReadList() As String
        'This function will remve a book book from the reading list
        Dim newQueryString As String = String.Empty
        Try
            Dim query As System.Collections.Specialized.NameValueCollection
            query = HttpContext.Current.Request.QueryString
            Dim paramname As String
            Dim paramvalue As String
            Dim i As Integer
            For i = 0 To query.Count - 1
                If Not query.AllKeys(i) Is Nothing Then
                    paramname = query.AllKeys(i).ToString()
                    If paramname.ToUpper <> "VIEWREADLIST" Then
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
