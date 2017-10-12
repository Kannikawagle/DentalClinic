<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReceptionistmakeAppointment.aspx.cs" Inherits="ReceptionistmakeAppointment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">


     

     <ul id="menuid" runat="server">
  <li><a href="default.aspx">Home</a></li>
   <li style="float:right"><a id="A1" class="active" onserverclick="logout" runat="server" CausesValidation="False">Logout</a></li>
          <li style="float:right"><a class="active" href="ReceptionistAcc.aspx" id="backtoacc" runat="server">Back to account page</a></li>
</ul>
     <form id="form1" runat="server">
         <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <table  >
        <tr>
            <td class ="frontsize" >
                Enter patient's first name:
            </td>
            <td >
                <asp:TextBox ID="fname" runat="server" CssClass="forms"></asp:TextBox>
            </td>
        </tr>
        <tr>
         <td class ="frontsize" >
                Enter patient's last name:
            </td>
            <td >
                <asp:TextBox ID="lstname" runat="server" CssClass="forms"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td class ="frontsize" >
                Enter Date of birth:
            </td>
            <td>
                 <asp:TextBox ID="dob" runat="server" CssClass="forms"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" TargetControlID="dob" />
           <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="dob" 
                    ErrorMessage="Appointment date is required"></asp:RequiredFieldValidator>

            </td>
            
        </tr>
                <tr>
            <td >
                <input type="reset" value="Cancel" class="cancelbtn" style="color: #FFFFFF" /></td>
            <td >
                &nbsp;<asp:Button ID="Button1" CssClass="submit" runat ="server" Text=" Search Patient" OnClick="Button1_Click" />
            &nbsp;
                <asp:Label ID="dberror" runat="server"></asp:Label>
                </td>
                       <td >
            &nbsp;</td>
              </tr >
        <tr>
        <td class ="frontsize" style="width: 36%">
            first name
        </td>
            <td width="80%">
                <asp:Label ID="fn" runat="server"></asp:Label>
            </td>
            </tr>
        <tr>
            <td class ="frontsize" style="width: 36%">
            last name
        </td>
            <td width="80%">
                <asp:Label ID="ln" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class ="frontsize" style="width: 36%">
            Date of Birth
                        </td>
            <td width="80%">>
                <asp:Label ID="dobp" runat="server"></asp:Label>

            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="errorresult" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class ="frontsize"  style="width: 36%">Select services:</td>
       
        <td>
            <asp:CheckBoxList ID="servicesbox" type="Checkbox" runat="server" BorderStyle="Solid">
</asp:CheckBoxList>
             
        </td>
            </tr>
        <tr>
            <td class ="frontsize"  style="width: 36%">
            Choose prefered date:
     </td>
         <td>                 <asp:TextBox ID="appdte" runat="server" CssClass="forms" Width=30%   ></asp:TextBox>
                <asp:Label ID="dobvalidation" runat="server"></asp:Label> 
                <%--<asp:RequiredFieldValidator ID="rfvd" runat="server" ControlToValidate="appdte" 
                    ErrorMessage="Prefered date is required">
                    </asp:RequiredFieldValidator>--%>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="appdte" />
             
           </td> 
        </tr>
         <tr>
            <td style="width: 36%">
                 <input type="reset" value="Cancel" class="cancelbtn" style="color: #FFFFFF" /></td>
            
            <td>
                <asp:Button ID="submit" CssClass="submit"  runat="server" Text="Check " OnClick="submit_Click" />
                <asp:Label ID="dberr" runat="server"></asp:Label>
                <asp:Label ID="result" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
         <table>
        <tr>
            <td style="height: 224px; width: 36%;">&nbsp;</td>
            <td style="height: 224px">
            <table border="Solid" style="border-style: solid; border-width: medium" id="apptable" >
                <tr>
                    <td style="border-style: solid; border-width: medium; width: 110px; text-align:center">
                        9.00-10.00
                    </td>
                    <td style="border-style: solid; border-width: medium; width: 110px; text-align:center">
                        10.00-11.00
                    </td>
                    <td style="width: 110px; border-style: solid; border-width: medium; width: 110px; text-align:center; ">
                        11.00-12.00
                    </td>
                    <td style="border-style: solid; border-width: medium; width: 110px; text-align:center">
                        12.00-1.00
                    </td>
                    <td style="border-style: solid; border-width: medium; width: 110px; text-align:center">
                        1.00-2.00
                    </td >
                    <td style="border-style: solid; border-width: medium; width: 110px; text-align:center">
                        2.00-3.00
                    </td>
                    <td style="border-style: solid; border-width: medium; width: 110px; text-align:center">
                        3.00-4.00
                    </td>
                    <td style="border-style: solid; border-width: medium; width: 110px; text-align:center">
                        4.00-5.00
                    </td>
                    </tr>
             <tr>
                <td style="border-style: solid; border-width: medium; width: 110px; text-align: center;" >
                    <a class="tablebutton" id="s1" runat="server" onserverclick="click_s1"></a>
                                                          
                                                                     
                            
                </td>
                <td style="border-style: solid; border-width: medium; height: 144px; width: 110px;" >
                      <a class="tablebutton" id="s2" runat="server" onserverclick="click_s2" >
                          </a>
                                                    </td>
                       
                <td style="border-style: solid; border-width: medium; width: 110px; text-align: center;" >   
                    <a class="tablebutton" id="s3" runat="server" onserverclick="click_s3">
                          </a></td>

                <td style="border-style: solid; border-width: medium; width: 110px; text-align: center;" >   
                    <a class="tablebutton" id="s4" runat="server" onserverclick="click_s4">
                          </a></td>
                <td style="border-style: solid; border-width: medium; width: 110px; text-align: center;" >  
                     <a class="tablebutton" id="s5" runat="server" onserverclick="click_s5">
                          </a></td>
                <td style="border-style: solid; border-width: medium; width: 110px; text-align: center;" >  
                     <a class="tablebutton" id="s6" runat="server" onserverclick="click_s6" >
                          </a></td>
                <td style="border-style: solid; border-width: medium; width: 110px; text-align: center;"> 
                      <a class="tablebutton" id="s7" runat="server" onserverclick="click_s7">
                          </a></td>
                <td style="border-style: solid; border-width: medium; width: 110px; text-align: center;">  
                     <a class="tablebutton" id="s8" runat="server" onserverclick="click_s8">
                          </a></td>
                 </tr>
            </table>
        </tr>
        <tr>
            <td style="width: 36%"></td>
            <td>
                <asp:Button ID="next" CssClass="button4" Text="Next day" runat="server" OnClick="next_Click" />
                <asp:Label ID="insertResult" runat="server"></asp:Label>
                <asp:Label ID="Label1" runat="server"></asp:Label>
                        </td>
        </tr>
    </table>
    <br />
    <br />

           
         </form>
    </asp:Content>