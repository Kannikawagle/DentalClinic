<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginSucessful.aspx.cs" Inherits="LoginSucessful" %>

<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
     <ul id="menuid" runat="server">
 <li><a href="default.aspx">Home</a></li>
  
         
 
</ul>

    <table>
        <tr>
            <td></td>
            <td>
                Your account is sucessfully created
            </td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Patientlogin.aspx" >Click here to login</asp:HyperLink>
            </td>
        </tr>
    </table>
    </asp:Content>