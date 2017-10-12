<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddInsurance.aspx.cs" Inherits="AddInsurance" %>

<%-- Add content controls here --%>

    <asp:Content ID="Content1" ContentPlaceHolderID="maincontent" Runat="Server">
        <ul id="menuid" runat="server">
        
         <li style="float:right"><a id="A1" class="active" onserverclick="logout" runat="server" CausesValidation="False" >Logout</a></li>
            <li style="float:right"><a class="active" href="PatientAcc_page.aspx" id="backtoacc" runat="server">Back to account page</a></li>
          </ul>
        <asp:Label ID ="dberr" runat="server"></asp:Label>
        <br />
        <br />
        <form id="form1" runat="server">
        <table style="width: 100%">
            <tr>
                <td class="frontsize"
                    width="20%">
               
                    Enter your insurance details:
                </td>
            </tr>
            <tr>
                <td class="frontsize" width="20%">
                    Enter insurance name:
                </td>
                <td width="50%" >
                     <asp:TextBox ID="insuname" runat="server" CssClass="forms"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rev" runat="server" ErrorMessage="enter insurance name"
                    ControlToValidate="insuname" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="frontsize" width ="20%">
                    Enter address:
                </td>
                <td width ="50%">
                     <asp:TextBox ID="add" runat="server" CssClass="forms"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="enter address"
                    ControlToValidate="add" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr >
                <td class="frontsize" width ="20%">
                    Enter Telephone:
                </td>
                <td width ="50%">
                     <asp:TextBox ID="tphone" runat="server" CssClass="forms" ></asp:TextBox>
                 <asp:RegularExpressionValidator ID="phn" runat="server" ErrorMessage="enter valid phone"
                    ControlToValidate="tphone" ValidationExpression="[0-9]{10}">
                                        </asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="frontsize" width ="20%">
                    Enter insurance number
                </td>
                <td width ="50%">
                    <asp:TextBox ID="insunum" runat="server" CssClass="forms"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter insurance number"
                    ControlToValidate="insunum" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td width ="20%">
                    <input type="reset" value="Cancel" class="frontsize cancelbtn" style="color: #FFFFFF" />
                </td>
                <td width ="50%">
                    <asp:Button ID="Button1" CssClass="submit" class="frontsize" runat ="server" Text=" Add Inurance" OnClick="Button1_Click"  />
                </td>
            </tr>
            <tr>
                
                <td width ="20%">
                    <asp:Label ID="bderror" runat="server"></asp:Label>
                </td>
                <td width ="50%">
                    <asp:Label ID="addinsurance" runat="server"></asp:Label>
                    <asp:Label ID="updtinsu" runat="server"></asp:Label>
                </td>
            </tr>
        </table></form>
    </asp:Content>