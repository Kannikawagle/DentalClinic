<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Encryptwebconfig.aspx.cs" Inherits="Encryptwebconfig" %>

<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
    CodeFile="EncryptWebConfig.aspx.cs" Inherits="EncryptWebConfig" Title="Encrypt Web Config" 


    <h3>Encrypt/Decrypt Configurations</h3>
    <table style="width: 562px">
        <tr>
            <td align="right" style="width: 113px">
                <asp:Label ID="Label1" runat="server" Text="Section Name: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSectionName" CssClass="forms" runat="server" Width="263px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="cmdEncrypt" runat="server" Text="Encrypt" OnClick="cmdEncrypt_Click" />
                <asp:Button ID="cmdDecrypt" runat="server" Text="Decrypt" OnClick="cmdDecrypt_Click" />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <asp:Label ID="lblMessage" runat="server" Width="541px" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
