<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="FirstPage.ascx.vb" Inherits="Rent_A_Book.FirstPage"%>
<%@ Register src="BooksList.ascx" tagname="BooksList" tagprefix="uc1" %>
<br><br />
<asp:Label ID="IntroLabel" runat="server" Text="Here are a few books that are currently for rent:" CssClass="ListDescription"></asp:Label>
<br><br />
<uc1:BooksList ID="BooksList1" runat="server" />
