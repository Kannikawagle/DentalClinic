<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmpLogin.aspx.cs" Inherits="EmpLogin" %>

<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">

    <ul>
  <li><a href="default.aspx">Home</a></li>
   <li style ="float:right"> <a class="active" href="#ContactUs.aspx">Contact</a></li>
  <li style="float:right"><a class="active" href="AboutUs.aspx">About us</a></li>
</ul>
     <form id="form1" runat="server">
    <table style="width: 1000px">
        <tr>
            <td class ="frontsize" style="width: 20%">
                Enter your id:<br />
                <br />
                &nbsp;<br />
            </td>
            <td style="width: 47%">
                <%--<a class="forms" form ="email" runat="server" id="id"></a>--%>
                <asp:TextBox ID="id" CssClass="passwordtext" runat="server"></asp:TextBox>
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class ="frontsize" style="width: 20% ">
                Enter password:<br />
                <br />
                <br />
&nbsp;</td>
            <td style="width: 47%">
                <asp:TextBox ID="pswrd" CssClass="passwordtext" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 20%">
                 <input type="reset" value="Cancel" class="cancelbtn" />
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
            <td style="width: 47%">
                <asp:Button ID="lgin" runat="server" CssClass="loginbutton forms" Text="Login" OnClick="lgin_Click" />
                <asp:Label ID="dberrlg" runat="server"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 20%"></td>
            <td style="width: 50%">
                <asp:Label ID="errormsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
     </form>     
    </asp:Content>
