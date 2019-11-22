<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AddBooksPage.ascx.vb" Inherits="Rent_A_Book.AddBooksPage" %>
<br />
<asp:Label ID="AddBookLabel" runat="server" Text="Fill out the details below to add book!"></asp:Label>
<br />
<br />
<asp:Label ID="EmailLabel" runat="server" Text="Enter Email address:"></asp:Label>
<br />
<br />
<asp:TextBox ID="EmailTextBox" runat="server" Width="304px"></asp:TextBox>
<br />
<br />
<asp:Label ID="PasswordLabel" runat="server" Text="Enter Password:"></asp:Label>
<br />
<br />
<asp:TextBox ID="PasswordTextBox" runat="server" Width="304px" TextMode="Password"></asp:TextBox>
<br />
<br />
<asp:Label ID="NameOfBookLabel" runat="server" Text="Name of Book:"></asp:Label>
<p>
    <asp:TextBox ID="NameOfBookTextBox" runat="server" Width="304px"></asp:TextBox>
</p>
<p>
    <asp:Label ID="DescriptionLabel" runat="server" Text="Description of the Book:"></asp:Label>
</p>
<p>
    <asp:TextBox ID="DescriptionOfTheBookTextBox" runat="server" Height="152px" Width="304px" TextMode="MultiLine"></asp:TextBox>
</p>
<p>
    <asp:Label ID="PriceLabel" runat="server" Text="Price Per Day:"></asp:Label>
</p>
<asp:TextBox ID="PriceTextBox" runat="server"></asp:TextBox>
<p>
    <asp:Label ID="GenreLabel" runat="server" Text="Select the Genre(s) the book belongs to:"></asp:Label>
</p>
<asp:CheckBoxList ID="GenreCheckBoxList" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name">
</asp:CheckBoxList>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RentABookTestConnectionString %>" SelectCommand="SELECT [Name] FROM [GenreOfBook]"></asp:SqlDataSource>
<p>
    <asp:Label ID="ImageLabel" runat="server" Text="Insert the image of the book below:"></asp:Label>
</p>
<p>
    <asp:FileUpload ID="ImageUpload" runat="server" />
</p>
<asp:Button ID="AddButton" runat="server" Text="Add" />

