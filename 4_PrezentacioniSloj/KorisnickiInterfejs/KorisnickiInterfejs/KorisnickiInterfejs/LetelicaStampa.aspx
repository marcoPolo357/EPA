<%@ Page Title="" Language="C#" MasterPageFile="~/StampaZaglavlje.Master" AutoEventWireup="true" CodeBehind="LetelicaStampa.aspx.cs" Inherits="KorisnickiInterfejs.LetelicaStampa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style6
        {
            width: 160px;
        }
        .style7
        {
            color: #0066FF;
        }
        .style8
        {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style6">
                <span class="style8">
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                <strong>
                <asp:Label ID="lblNaslov" runat="server" Text="SPISAK LETELICA"></asp:Label>
                </strong>
            </td>
            <td>
                </span>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                <asp:GridView ID="gvSpisakLetelica" runat="server" Height="286px" Width="433px">
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
