<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateAcc.aspx.cs" Inherits="CreateAcc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
    
   

     <ul>
  <li><a href="default.aspx">Home</a></li>
  <li><a href="Patientlogin.aspx">Patient login</a></li>
  <li style ="float:right"> <a class="active" href="ContactUs.aspx">Contact</a></li>
  <li style="float:right"><a class="active" href="AboutUs.aspx">About</a></li>
</ul>
    
           <form id="form1" runat="server">
    <table width="1000px">
           <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>       
        
        <tr>
            <td style="width: 20%; height: 96px;" class="frontsize">
                <br />
                <br />
                Are you a primary account holder?
            </td>
            <td style="width: 50%; height: 150px;">
                

               <asp:RadiobuttonList ID="bi" runat="server"  CssClass="control-group form" AutoPostBack="true" Height="38px" Width="50%" 
                    >
                                  
             <asp:ListItem  Value="S" >Yes</asp:ListItem>
                   
             <asp:ListItem  Value="N" >No</asp:ListItem>
                    </asp:RadiobuttonList>
</td>

<td style="height: 96px">                   
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="bi" 
                    ErrorMessage="Please select yes or no"></asp:RequiredFieldValidator>

                <script type="text/jscript"></script>


                           
            </td>
        </tr>
        <tr>
            <td class="frontsize" style="width: 20%; font-size: medium; height: 56px";>
                Enter First name: 
                <br />
                
            </td>
            <td style="width: 50%; height: 56px;">
                
                <asp:TextBox ID="fname" runat="server" CssClass="forms" ></asp:TextBox>
                
                <asp:RequiredFieldValidator ID="fnrfv" runat="server" ControlToValidate="fname" 
                    ErrorMessage="first name is required"></asp:RequiredFieldValidator>
                    </td>             
           
        </tr>
        <tr>
            <td class="frontsize" style="width: 20%">
                Enter Last name:<br />
               
                </td>
            <td style="width: 50%">
                <asp:TextBox ID="lname" runat="server" CssClass="forms" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="lnrfv" runat="server" ControlToValidate="lname" 
                    ErrorMessage="last name is required"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
        <tr>
            <td class="frontsize" style="width: 20%">
            Enter email id:
                
                </td>
            <td style="width: 50%">
                <asp:TextBox ID="email" runat="server" CssClass="forms" ValidationGroup="email" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="em" runat="server" ErrorMessage="enter valid email address"
                    ControlToValidate="email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                  
            </td>
        </tr>
        <tr>
            <td class="frontsize" style="width: 20%">
                Enter password:
                
            </td>
            <td style="width: 50%">
                <asp:TextBox ID="pswd" runat="server" CssClass="forms" TextMode="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="frvp" runat="server" ControlToValidate="pswd" 
                    ErrorMessage="password is required"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
        <tr>
            <td class="frontsize" style="width: 20%">
                Answer security question
            </td>
            <td class="frontsize">
                What is the name of your first school?
                <br />
                <br />
                <asp:TextBox ID="ques" runat="server" CssClass="forms" ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RFV" runat="server" ErrorMessage="please enter answer"
                    ControlToValidate="ques" >
                                        </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="frontsize" style="width: 20%">
                Enter telephone:
               
            </td>
            <td style="width: 50%">
                <asp:TextBox ID="tphone" runat="server" CssClass="forms" ></asp:TextBox>
                 <asp:RegularExpressionValidator ID="phn" runat="server" ErrorMessage="enter valid phone"
                    ControlToValidate="tphone" ValidationExpression="[0-9]{10}">
                                        </asp:RegularExpressionValidator>

                
               
            </td>
          
        </tr>
        <tr>
            <td class="frontsize" style="width: 20%">
                Enter address
            </td>
            <td>
                <asp:TextBox ID="add" runat="server" CssClass="forms"></asp:TextBox>
                 <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="enter address"
                    ControlToValidate="add" ></asp:RegularExpressionValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="frontsize" style="width: 20%">
                Enter date of birth:<br />
&nbsp;</td>
            <td style="width: 50%">
                <asp:TextBox ID="dob" runat="server" CssClass="forms" Onblur="dobValidate(event)"
                     >

                </asp:TextBox>
                 <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"
                    TargetControlID="dob"
                    PopupButtonID="Image1" />
              <%--  <asp:Label ID="dobvalidation" runat="server"></asp:Label> --%>
                <span></span>
                <asp:RequiredFieldValidator ID="rfvdob" runat="server" ControlToValidate="dob" 
                    ErrorMessage="Date of birth is required">
                   

                </asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="bderr" runat="server"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td style="width: 20%"></td>
            <td style="width: 50%">
                
            </td>
        </tr>
        <tr>
            <td style="width: 20%">
                <input type="reset" value="Cancel" class="cancelbtn frontsize" style="color: #FFFFFF" /></td>
           

            <td style="width: 50%">
                <asp:Button ID="Button1" CssClass="submit frontsize"  runat ="server" Text=" Create Account" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 20%"></td>
            <td style="width: 50%">
                <asp:Label ID="insertResult" runat="server"></asp:Label> &nbsp
                <asp:Label ID="errormsg" runat="server" ></asp:Label>            &nbsp;
                <asp:Label ID="inserterrormsg" runat="server"></asp:Label>
            &nbsp;
            <br />
                <asp:Label ID="updateerror" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
       </form>
    
    </asp:Content>