<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddHousehold.aspx.cs" Inherits="AddHousehold" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
    <form action="Patientlogin.aspx">
     <ul id="menuid" runat="server">
       <%--  <li><a href="default.aspx">Home</a></li>--%>
  <%--<li> <span id="span1" runat="server"></li>--%>
 <%-- <li style="float:right"><a class="active" href="CountUS.aspx">Contact</a></li>
  <li style="float:right"><a class="active" href="AboutUs.aspx">About</a></li>--%>
         
        <li style="float:right"><a id="A1" class="active" onserverclick="logout" runat="server" CausesValidation="False">Logout</a></li>
         <li style="float:right"><a class="active" href="PatientAcc_page.aspx" id="backtoacc" runat="server">Back to account page</a></li>
          
</ul>
        </form>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>

    <table style="width: 1000px">
        <tr>
            <td class="frontsize" style="width: 20%">
                Please fill below form to enter house hold
            </td>
        </tr>
        <tr>
            <td class="frontsize" style="width: 50%; height: 100px;">
                Choose relation 
            </td>
            <td style="height: 100px">
                
               
<asp:DropDownList ID="dd" runat="server" cssclass="dropbtn" Width="146px">
    <asp:ListItem>Daughter</asp:ListItem>
    <asp:ListItem>Son</asp:ListItem>
    <asp:ListItem>Spouse</asp:ListItem>

</asp:DropDownList>
    </td>
        </tr>
        <tr>
            <td class="frontsize" style="width: 20%">
                Enter first name:
            </td>
            <td>
                <asp:TextBox ID="fname" CssClass="forms" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="frontsize" style="width: 50%">
                Enter last name:
            </td>
            <td>
                <asp:TextBox ID="lname" CssClass="forms" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            
            <td class="frontsize" style="width: 20%">
            Enter telephone:
                </td>
<td style="width: 50%">
    <asp:TextBox ID="tele" CssClass="forms" runat="server"></asp:TextBox>
</td>
        </tr>
        <tr>
            <td class="frontsize" style="width: 20%">
                Enter date of birth:
            </td>
            <td style="width: 50%">
                <asp:TextBox ID="dob" CssClass="forms" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvd" runat="server" ControlToValidate="dob" 
                    ErrorMessage="date of birth is required"></asp:RequiredFieldValidator>
                    <ajaxToolkit:CalendarExtender runat="server"
                    TargetControlID="dob"
                    PopupButtonID="Image1" ></ajaxToolkit:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="frontsize" style="width: 20%">
            Enter address:
                </td>
            <td style="width: 50%">
                 <asp:TextBox ID="add" CssClass="forms" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
                <asp:Button ID="adding" runat="server" CssClass="submit" class="frontsize" Text ="Add" OnClick="adding_Click" />
                <asp:Label ID="addresult" CssClass="frontsize" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
        </form>
    <h4>
         
                <asp:Label ID="dberr" runat="server"></asp:Label>
           
    </h4>
    </asp:Content>