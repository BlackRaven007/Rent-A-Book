<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Basket.ascx.vb" Inherits="Rent_A_Book.Basket1" %>
<asp:Label ID="IntroductionLabel" runat="server" CssClass="ListDescription" Text="Books currently in your basket:"></asp:Label>
<br />
<asp:GridView ID="Grid" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="BookID">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="Name" HeaderText="Book Name" ReadOnly="True" />
        <asp:BoundField DataField="PricePerDay" DataFormatString="{0:c}" HeaderText="Price Per Day" ReadOnly="True" />
        <asp:TemplateField HeaderText="Number of Days">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NumberOfDays") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Days") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Cost" DataFormatString="{0:c}" HeaderText="Cost" ReadOnly="True" />
        <asp:CommandField ButtonType="Button" EditText="Edit Number of Days" ShowEditButton="True" />
        <asp:CommandField ButtonType="Button" EditText="Remove" ShowDeleteButton="True" />
    </Columns>
    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    <SortedAscendingCellStyle BackColor="#FDF5AC" />
    <SortedAscendingHeaderStyle BackColor="#4D0000" />
    <SortedDescendingCellStyle BackColor="#FCF6C0" />
    <SortedDescendingHeaderStyle BackColor="#820000" />
</asp:GridView>
<p>
    <asp:Label ID="TotalCostLabel" runat="server" CssClass="BookDescription" Text="Total Cost:"></asp:Label>
    <asp:Label ID="TotalCost" runat="server" CssClass="BookPrice"></asp:Label>
</p>
<p>
    <asp:Button ID="ContinueLookingButton" runat="server" Text="Continue Looking" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Checkout" runat="server" Text="Check out" />
</p>

