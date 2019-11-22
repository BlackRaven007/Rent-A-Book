<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReadList.ascx.vb" Inherits="Rent_A_Book.ReadList" %>
<asp:Label ID="IntroductionLabel" runat="server" CssClass="ListDescription" Text="Books currently in your basket:"></asp:Label>
<br />
<asp:GridView ID="Grid" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="BookID">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="Name" HeaderText="Book Name" ReadOnly="True" />
        <asp:BoundField DataField="PricePerDay" DataFormatString="{0:c}" HeaderText="Price Per Day" ReadOnly="True" />
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
    &nbsp;</p>
<p>
    <asp:Button ID="ContinueLookingButton" runat="server" Text="Continue Looking" />
</p>

