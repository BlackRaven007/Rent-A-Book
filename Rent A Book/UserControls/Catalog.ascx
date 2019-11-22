<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Catalog.ascx.vb" Inherits="Rent_A_Book.Catalog1"%>
<%@ Register src="BooksList.ascx" tagname="BooksList" tagprefix="uc1" %>
<P align="right">
    <asp:label ID="sectionTitleLabel" CssClass="SectionTitle" runat="server">
    </asp:label>
</P>
<asp:label ID="descriptionLabel" CssClass="ListDescription" runat="server">
</asp:label>
<br><br>
<uc1:BooksList ID="BooksList1" runat="server" />
