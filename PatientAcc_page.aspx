<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PatientAcc_page.aspx.cs" Inherits="PatientAcc_page" %>



<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">

     <ul id="menuid" runat="server">
        
         <li style="float:right"><a class="active" onserverclick="logout" runat="server">Logout</a></li>
          
</ul>
     <form id="form1" runat="server">
    <table style="width: 1000px; height: 612px">
        <tr>
           
            <td style="width: 456px; height: 233px;">
                <br />
                   
                            <a id="a" class="button buttonactive"
                    href="Checkupcomingapp.aspx" runat="server" > 
                               Check upcoming Appointment 
                               
                            </a>
                               
                            <br />
                               
            </td>
            <td style="width: 425px">
            <br />
                 <a id="A1" class="button buttonactive"  href="MakeAppointment.aspx" runat="server" >                 
                        
                         Make Appointment<br />
                     
                         </a>
            </td>
        </tr>
        <tr>
         
            <td style="width: 425px">
                <br />
                 <a class="button buttonactive"  href="AddInsurance.aspx" runat="server">
                         Add insurance
                         </a>
            </td>
            <td style="width: 425px">
                    <br />
                 <a id="A2" class="button buttonactive"  href="AddHousehold.aspx" runat="server" >                 
                        
                         Add Dependents<br />
                     
                         </a>
            </td>
        </tr>
        <tr>
            
                 <td style="width: 425px">
            <br />
                 <a id="A3" class="button buttonactive"  href="CheckInvoice.aspx" runat="server" >                 
                        
                         Check Invoice<br />
                     
                         </a>
            </td>
            
        </tr>
       
    </table>
         </form>
    <h4>
         
                <asp:Label ID="dberr" runat="server"></asp:Label>
           
    </h4>
    </asp:Content>