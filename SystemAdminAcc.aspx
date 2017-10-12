<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SystemAdminAcc.aspx.cs" Inherits="SystemAdminAcc" %>

<%-- Add content controls here --%>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">

    <ul id="menuid" runat="server">
  
        
    <li style ="float:right"><a id="A1" href="EmpLogin.aspx" onserverclick="logout" runat="server" CausesValidation="False">Logout</a></li>
   
 
        </ul>


 <form id="form1" runat="server">
    <table style="width: 836px; height: 310px">
        <tr>
            <td>
                <asp:Label ID="dberror" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            
            <td style="width: 456px">
                
                   
                            <a class="button "  href="SysAdminAddDoctors.aspx">
                               Add Doctor 
                               
                            </a>
                               
            </td>
            <td style="width: 456px">
                 <a class="button" href="SysAdminAddServices.aspx">
                         Add new services 
                         </a>
            </td>
        </tr>
        <tr>
            
            <td style="width: 425px">
                 <a class="button" href="SysAdminEditDoctor.aspx">
                         Edit Doctors<br />
                         </a>
            </td>
        </tr>
    </table>
     </form>
    </asp:Content>