<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BooksList.ascx.vb" Inherits="Rent_A_Book.BooksList" %>
<style type="text/css">
    .auto-style1 {
        height: 200px;
    }
</style>
<asp:DataList ID="List" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
    <ItemTemplate>
        <cellPadding:0>
<table style="text-align:left;">
    <tr>
        <td style="vertical-align:central; width:110px" class="auto-style1">
            <img src='BookImages/<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>' border="0"; style="margin: 10px 0px" /></a>
                </td>
        <td style="vertical-align:top; width:200px" class="auto-style1"><font class="BookName">
                        <%# DataBinder.Eval(Container.DataItem, "Name") %>
                    </font>
            <br />
            <br /><font class="BookDescription">
                        <%# DataBinder.Eval(Container.DataItem, "Description") %>
                        <br />
            <br />Price per day:</font><%# DataBinder.Eval(Container.DataItem, "PricePerDay", "{0:c}") %><br />
            <asp:Button ID="Button1" runat="server" Text="Add to Basket" 
                        commandArgument='<%# DataBinder.Eval(Container.DataItem, "BookID") %>' />
            <br />
            <asp:Button ID="Button2" runat="server" commandArgument='<%# DataBinder.Eval(Container.DataItem, "BookID") %>' Text="Add to reading list" />
        </td>
    </tr>
</table>
    </ItemTemplate>
</asp:DataList>
