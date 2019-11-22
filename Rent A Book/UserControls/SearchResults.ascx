<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SearchResults.ascx.vb" Inherits="Rent_A_Book.WebUserControl3" %>
<%@ Register src="BooksList.ascx" tagname="BooksList" tagprefix="uc1" %>

<asp:Label ID="titleLabel" runat="server" CssClass="FirstPageText"></asp:Label>
<br />
<br />
<asp:Label ID="pageNumberLabel" runat="server" CssClass="SearchResult"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:HyperLink ID="PreviousPage" runat="server" CssClass="SearchResult">Previous</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
<asp:HyperLink ID="NextPage" runat="server" CssClass="SearchResult">Next</asp:HyperLink>
<br />
<uc1:BooksList ID="BooksList1" runat="server" />

