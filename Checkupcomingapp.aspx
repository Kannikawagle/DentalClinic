<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Checkupcomingapp.aspx.cs" Inherits="Checkupcomingapp" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="maincontent" Runat="Server">
        <ul id="menuid" runat="server">
           
     
         <li style="float:right"><a class="active" runat="server" onserverclick="logout" CausesValidation="False" >Logout</a></li>
            <li style="float:right"><a class="active" href="PatientAcc_page.aspx" id="backtoacc" runat="server">Back to account page</a></li>
          </ul>
    <br />
    <br />
    <br />
    <form id="form1" runat="server">
    <table>
        <tr>
            <td CssClass="forms">
                Select form options
                </td>
            <td style="width: 412px">
               
                
 <asp:RadioButtonList ID="householdbox" CssClass="control-group form" AutoPostBack="true" runat="server" ></asp:RadioButtonList>
                </td>
            
            </tr>
        <tr>
            <td></td>
            <td>
                 <asp:Button ID="submit" CssClass="submit"  runat="server" Text="Check " OnClick="submit_Click"/>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
    <br />
        <td>
        <asp:GridView ID="selectdisplay" runat="server" AllowPaging="True" 
            AllowSorting="True" CellPadding="3" Width="394px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" >
           
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
               <EmptyDataTemplate>No appointments found</EmptyDataTemplate>
        </asp:GridView>
    
               
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="width: 412px">
                 
                <asp:Label ID="dberr"  runat="server"></asp:Label>
            </td>
        </tr>
    <tr>
        <td>
            </td>
  </tr>
  
   </table>
        </form>
    </asp:Content>