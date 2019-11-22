<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Rent_A_Book._default" %>

<%@ Register src="UserControls/Header.ascx" tagname="Header" tagprefix="uc1" %>

<%@ Register src="UserControls/DepartmentsList.ascx" tagname="DepartmentsList" tagprefix="uc2" %>

<%@ Register src="UserControls/GenreList.ascx" tagname="GenreList" tagprefix="uc3" %>

<%@ Register src="UserControls/SearchBox.ascx" tagname="SearchBox" tagprefix="uc4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rent A Book</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema"

content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="RentABook.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table style="height:100px; border-spacing:0; Padding:0; width:770px; border:0">
            <tr>
                <td style="width:190px; height:100px">
                    <table style="height:100px; width:190px; border-spacing:0; Padding:0px">
                        <tr>
                            <td style="vertical-align:top; height:100px">&nbsp;<uc2:DepartmentsList ID="DepartmentsList1" runat="server" />
                                <br />
                                <uc3:GenreList ID="GenreList1" runat="server" />
                                <br />
                                <uc4:SearchBox ID="SearchBox1" runat="server" />
                                <br />
                                <asp:Button ID="ViewBasketButton" runat="server" Text="View Basket" />
                                <br />
                                <asp:Button ID="ReadList" runat="server" Text="Reading List" />
                                <br />
                                <br />
                                <asp:Button ID="SignUpButton" runat="server" Text="Sign Up" />
                                <br />
                                <asp:Button ID="AddBookButton" runat="server" Text="Add Book" />
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="vertical-align:top; width:550px;"><br/>
                    <table>
                        <tr>
                            <td>
                                <uc1:Header ID="Header1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td id="pageContentsCell" runat="server">
                                Welcome to Rent A Book, this is the world famous website allowing you to rent out or lend out books for your own gain!!!!</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
