<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SearchBox.ascx.vb" Inherits="Rent_A_Book.WebUserControl2" %>

<table border="0" style="width:168px;background-color:LightBlue;text-align:center;padding:5px;border-collapse:collapse;border-spacing:10px;">
    <tr>
        <td>
            <asp:TextBox ID="searchTextBox" runat="server" Width="90%" CssClass="SearchBox" BorderStyle="Dotted" MaxLength="100">Search for books here</asp:TextBox>
        </td>
    </tr>
</table>