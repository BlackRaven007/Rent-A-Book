<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DepartmentsList.ascx.vb" Inherits="Rent_A_Book.DepartmentsList" %>
<asp:DataList ID="List" runat="server" CellPadding="0">
    <HeaderStyle BackColor="Yellow" />
    <HeaderTemplate>
        Select type
    </HeaderTemplate>
    <ItemStyle BackColor="Yellow" />
    <ItemTemplate>
        &nbsp;&raquo;
        <asp:HyperLink id=HyperLink1 runat="server"
            NavigateUrl='<%# "../default.aspx?TypeOfBooksID=" & DataBinder.Eval(Container.DataItem, "TypeOfBooksID") & "&amp;TypeOfBookIndex=" & Container.ItemIndex %>'
            Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'
            CssClass="BookTypeUnselected">[HyperLink1]</asp:HyperLink>

    </ItemTemplate>
    <SelectedItemTemplate>
        &nbsp;&raquo;
        <asp:HyperLink id=HyperLink2 runat="server"
            NavigateUrl='<%# "../default.aspx?TypeOfBooksID=" & DataBinder.Eval(Container.DataItem, "TypeOfBooksID") & "&amp;TypeOfBookIndex=" & Container.ItemIndex %>'
            Text ='<%# DataBinder.Eval(Container.DataItem, "Name") %>'
            CssClass="BookTypeSelected">[HyperLink2]</asp:HyperLink>
    </SelectedItemTemplate>
</asp:DataList>

