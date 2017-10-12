<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="defaultpage" %>


<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
       
    <%-- <h1 class="w3-xxlarge"
        
         <span class="w3-border w3-border-black w3-padding" class="w3-xxlarge">Pearl Dental Clinic</span> 

        <span class="w3-hide-small" style="font-size: medium; font-style: italic;">Smile with shining teeth</span>
   </h1>
     --%><ul>
  <li><a href="defaultPage.aspx">Home</a></li>
  <li><a href="Patientlogin.aspx">Patient login</a></li>
  <li style ="float:right"> <a class="active" href="ContactUs.aspx">Contact us</a></li>
  <li style="float:right"><a class="active" href="AboutUs.aspx">About us</a></li>
   
</ul>
       
        
   <table>
        <tr>
            <td style="height: 238px; width: 66px"></td>
            <td style="width: 300px; height: 238px;">
                <a class="button procimagebutton"
                    href="Services.aspx" style="font-size: large; color: #333300; font-weight: bold">
                    
                    Procudeurs
                </a>
            </td>
            <td style="width: 12px; height: 238px;">&nbsp&nbsp</td>
            <td style="height: 238px">
                <a class="button doctimagebutton" href="Doctors.aspx" style="font-size: large; color: #333300; font-weight: bold">
                     Doctors</a>
            </td>
        </tr>
        <tr>
            <%--<td style="height: 293px; width: 66px"></td>
            <td style="width: 300px; height: 293px;">
               <a class="button"> Cost</a>
            </td>--%>
            <td style="width: 12px; height: 293px;">&nbsp&nbsp</td>
            <td style="height: 293px">
                 <a class="button patimagebutton" href="CreateAcc.aspx" style="font-size: large; color: #333300; font-weight: bold">
                      Create Account
                     
                 </a>
            </td>
        </tr>
    </table>
    <ul>
    <li style="float:right"><a class="active" href="EmpLogin.aspx">Employee Login</a></li>
        </ul>
</asp:Content>

