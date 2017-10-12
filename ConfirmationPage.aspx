<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConfirmationPage.aspx.cs" Inherits="ConfiramtionPage" %>

<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
        <ul id="menuid" runat="server">
 <%-- <li><a href="default.aspx">Home</a></li>--%>
             <li style="float:right"><a id="A1" class="active" onserverclick="logout" runat="server">Logout</a></li>
  <li><a href="PatientAcc_page.aspx">Back to Account page</a></li>
 
        
           
</ul>

    <table>
        <tr>
            <td>
                
            </td>
            <td CssClass="forms">
                Your Appointment is created sucessfully
            </td>
        </tr>
    </table>
    </asp:Content>