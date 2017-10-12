<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MakeAppointment.aspx.cs" Inherits="MakeAppointment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
     

    <ul id="menuid" runat="server">
        
         <li style="float:right"><a id="A1" class="active" onserverclick="logout" runat="server" CausesValidation="False">Logout</a></li>
          <li style="float:right"><a class="active" href="PatientAcc_page.aspx" id="backtoacc" runat="server">Back to account page</a></li>
          </ul>
        <asp:Label ID ="Label1" runat="server"></asp:Label>
    <br />
    <br />
     <form id="form1" runat="server">
         <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <table>
        <tr>
            <td>
                
                </td>
            <td class ="frontsize" >
                Choose person 
            </td>
            <td class ="frontsize">Choose Services</td>
        </tr>
        <tr>
            <td>
                             
            </td>
            <td>
               
                <asp:RadiobuttonList ID="householdbox" runat="server"  CssClass="control-group form" AutoPostBack="true"></asp:RadiobuttonList>
            </td>
            <%--<td class ="frontsize" style="width: 184px">
                choose services
            </td>--%>
            <td>
               
                <asp:CheckBoxList ID="servicesbox" type="Checkbox" runat="server">
</asp:CheckBoxList>
                    
            </td>
           
        </tr>
        <tr>
            <td class ="frontsize">
                Enter Prefered date
            </td>
         <td>   
                           <asp:TextBox ID="appdte" runat="server" CssClass="forms"></asp:TextBox>
                <asp:Label ID="dobvalidation" runat="server"></asp:Label> 
                <asp:RequiredFieldValidator ID="rfvd" runat="server" ControlToValidate="appdte" 
                    ErrorMessage="Prefered date is required">
                    </asp:RequiredFieldValidator>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="appdte" />
           </td> 
            <td></td>
        </tr>
        <tr>
            <td class ="frontsize">
                 <input type="reset" value="Cancel" class="cancelbtn" style="color: #FFFFFF" /></td>
            
            <td>
                <asp:Button ID="submit" CssClass="submit"  runat="server" Text="Check " OnClick="submit_Click"/>
                <asp:Label ID="dberr" runat="server"></asp:Label>
                <asp:Label ID="result" runat="server"></asp:Label>
            </td>
            <td></td>
        </tr>
        </table>
         <table>
        <tr>
            <td style="width: auto;">&nbsp;</td>
            <td >
            <table  id="apptable" >
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
                </td>
        </tr>
        <tr>
            <td style="width: 30%"></td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="next" CssClass="button4" Text="Next day" runat="server" OnClick="next_Click" />
                <asp:Label ID="insertResult" runat="server"></asp:Label>
                <asp:Label ID="dberror" runat="server"></asp:Label>
                        </td>
        </tr>
    </table>
    <br />
    <br />
         </form>
       </asp:Content>
