<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="LetelicaDetaljiEdit.aspx.cs" Inherits="KorisnickiInterfejs.LetelicaDetaljiEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 275px;
        text-align: right;
    }
    .style2
    {
        width: 400px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            LETELICA - DETALJNI PRIKAZ ZA EDITOVANJE</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            Registarski broj</td>
        <td class="style2">
            <asp:TextBox ID="txbRegBrLetelice" runat="server" Enabled="False"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            Naziv</td>
        <td class="style2">
            <asp:TextBox ID="txbNaziv" runat="server" Enabled="False"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            <asp:Label ID="lblStatus" runat="server" Text="STATUS"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            <asp:Button ID="btnObrisi" runat="server" Text="Obrisi" 
                onclick="btnObrisi_Click" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            <asp:Button ID="btnIzmeni" runat="server" Text="Omoguci izmenu" 
                onclick="btnIzmeni_Click" Width="110px" />
            <asp:Button ID="btnSnimiIzmenu" runat="server" onclick="btnSnimiIzmenu_Click" 
                Text="SNIMI IZMENU" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
