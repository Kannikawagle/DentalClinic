<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Forgotpassword.aspx.cs" Inherits="Forgotpassword" %>

<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server" >

    <table width="100%">
        <tr>
            <td width=" 30%">
                Please enter your email
            </td>
            <td width ="70%">
                <asp:TextBox ID="email" runat="server" CssClass="forms" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="30%">
                 What is the name of your first school?
            </td>
            <td width ="70%">
                 <asp:TextBox ID="security" runat="server" CssClass="forms" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 14%">
                <input type="reset" value="Cancel" class="cancelbtn" style="color: #FFFFFF" /></td>
           

            <td style="width: 50%">
                <asp:Button ID="Button1" CssClass="submit" runat ="server" Text=" Submit " OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td>
                <asp:Label ID="message" runat="server"></asp:Label>
                <asp:Label ID="errmsg" runat="server"></asp:Label>
                <asp:Label ID="dberror" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>