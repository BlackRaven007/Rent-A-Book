<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SignUpPage.ascx.vb" Inherits="Rent_A_Book.SignUpPage" %>
<p>
    <asp:Label ID="SignUpLabel" runat="server" Text="To sign up fill out the details below:"></asp:Label>
</p>
<asp:Label ID="NameLabel" runat="server" Text="Name:"></asp:Label>
<br />
<asp:TextBox ID="NameTextBox" runat="server" Width="304px"></asp:TextBox>
<p>
    <asp:Label ID="EmailLabel" runat="server" Text="Email:"></asp:Label>
<br />
    <asp:TextBox ID="EmailTextBox" runat="server" Width="304px"></asp:TextBox>
</p>
<p>
    <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>
<br />
    <asp:TextBox ID="PasswordTextBox" runat="server" Width="304px" TextMode="Password"></asp:TextBox>
</p>
<p>
    <asp:Label ID="ReEnterPasswordLabel" runat="server" Text="ReEnter Password:"></asp:Label>
<br />
    <asp:TextBox ID="ReEnterPasswordTextBox" runat="server" Width="304px" TextMode="Password"></asp:TextBox>
</p>



<asp:Button ID="SignUpButton" runat="server" Text="Sign Up" />




