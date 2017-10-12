<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReceptionistAcc.aspx.cs" Inherits="ReceptionistAcc" %>

<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">

  <ul id="menuid" runat="server">
  <%--<li><a href="default.aspx">eHome</a></li>
  <li><a href="#news">Welcome Employee</a></li>--%>
       <li style="float:right"><a id="A1" class="active" onserverclick="logout" runat="server">Logout</a></li>
  <%--<li style ="float:right"> <a class="active" href="ContactUs.aspx">Contact us</a></li>
  <li style="float:right"><a class="active" href="AboutUs.aspx">About us</a></li>--%>
</ul>

    <table style="width: 836px; height: 310px">
        <tr>
            <td>
                <asp:Label ID="dberror" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 456px">
                            <a class="button buttonactive"  href="ManageAppointment.aspx">
                               Manage Appointment 
                               
                            </a>
                               
            </td>
            <td style="width: 425px" >
                 <a class="button buttonactive" href="ReceptionistmakeAppointment.aspx">
                     Make appointment
                     
                     </a>
            </td>
        </tr>
        <tr>
                        <td style="width: 425px">
                 <a class="button buttonactive" href="CheckinPatient.aspx">
                         check-in<br />
                         </a>
            </td>
       
        
         <td style="width: 425px" >
                 <a class="button buttonactive" href="ReceptionistAddInsurance.aspx">
                     Add Insurance
                     
                     </a>
            </td>
             </tr>
    </table>

    </asp:Content>