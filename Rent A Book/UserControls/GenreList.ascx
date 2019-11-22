<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="GenreList.ascx.vb" Inherits="Rent_A_Book.WebUserControl1" %>
<asp:DataList ID="list" runat="server" CellPadding="0">
    <HeaderStyle BackColor="PaleGoldenrod" />
    <HeaderTemplate>
        Select genre
    </HeaderTemplate>
    <ItemStyle BackColor="PaleGoldenrod" />
    <ItemTemplate>
        &nbsp;&raquo
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "../default.aspx?TypeOfBooksID=" & Request.QueryString("TypeOfBooksID") & "&amp;TypeOfBookIndex=" & Request.QueryString("DepartmentIndex") & "&amp;GenreOfBookID=" & DataBinder.Eval(Container.DataItem, "GenreOfBookID") & "&amp;GenreOfBookIndex=" & Container.ItemIndex %>'
            Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'
            CssClass="GenreUnselected">HyperLink</asp:HyperLink>
    </ItemTemplate>
    <SelectedItemTemplate>
        &nbsp;&raquo;
        <asp:Label ID="Label1" runat="server"
            Text='%# DataBinder.Eval(Container.DataItem, "Name") %>'
            CssClass="GenreSelected">Lable 
            </asp:Label>
    </SelectedItemTemplate>
</asp:DataList>

