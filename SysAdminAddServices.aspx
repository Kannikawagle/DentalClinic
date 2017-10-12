<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SysAdminAddServices.aspx.cs" Inherits="SysAdminAddServices" %>

<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
     <ul id="menuid" runat="server">
   
       
          <li style ="float:right"><a href="EmpLogin.aspx" onserverclick="logout" runat="server" CausesValidation="False">Logout</a></li>
   <li style="float:right"><a class="active" href="SystemAdminAcc.aspx" id="backtoacc" runat="server">Back to account page</a></li>

</ul>
     <form id="form1" runat="server">
    <table width="946px">
        <tr>
            <td class ="frontsize" style="width: 20%">
                Enter Service name:
                <br />
                <br />
            </td>
            <td style="width: 50%">
                <asp:TextBox ID="sername" cssclass="forms" runat="server"></asp:TextBox>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class ="frontsize" style="width: 20%">
                Enter cost for services:
                <br />
                <br />
            </td>
            <td style="width: 50%">
                 <asp:TextBox ID="sercst" cssclass="forms" runat="server"></asp:TextBox>
                 <br />
                 <br />
            </td>
        </tr>
        <tr>
            <td class ="frontsize" style="width: 20%">
                Enter duration for services:<br />
                <br />
            </td>
            <td class ="frontsize" style="width: 50%">
                 <asp:TextBox ID="serduration" cssclass="forms" runat="server"></asp:TextBox>
                 <br />
                 <br />
            </td>
        </tr>
        <tr>
            <td class ="frontsize" style="width: 20%">
            Enter low cost after discount:
                <br />
                <br />
                </td>
            <td style="width: 50%">
                <asp:TextBox ID="lwcst" cssclass="forms" runat="server"></asp:TextBox>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 20%">
                
                <input type="reset" value="Cancel" class="cancelbtn" />
            </td>
            <td style="width: 50%">
                <asp:Button ID="addser" CssClass="submit" runat="server" Text="Add new Service" OnClick="addser_Click" />
                <br />
                <asp:Label id="dberror" runat="server"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 20%"></td>
            <td style="width: 50%">
                <asp:Label ID="addservice" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
         </form>
</asp:Content>
