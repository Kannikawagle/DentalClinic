<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateInvoice.aspx.cs" Inherits="CreateInvoice" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>

     <ul id="menuid" runat="server">
 
        <li><a href="ReceptionistAcc.aspx">Back to account page</a></li>
     <li style="float:right"><a id="A1" class="active" onserverclick="logout" runat="server">Logout</a></li>
 
</ul>
    <br />
    <br />
    <br />
     <form id="form1" runat="server">
    <table>
       
        <tr>
            <td class ="frontsize">
                Patient name:
            </td>
            <td style="width: 411px">
                <asp:label id="pn" runat="server"></asp:label>
            </td>
            <td class ="frontsize">
                Today's date:
            </td>
            <td>
                <asp:Label ID="todate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class ="frontsize">
                Patient Id:
            </td>
            <td style="width: 411px">
                <asp:Label ID="pid" runat="server"></asp:Label>
            </td>
            <td class ="frontsize">
                Invoice Number:
            </td>
            <td>
                <asp:Label ID="inonum" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class ="frontsize">
               insurance Id
            </td>
            <td>
                <asp:Label ID="insuid" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class ="frontsize">
                Appointment number
            </td>
            <td style="width: 411px">
                <asp:Label ID="appnum" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                 <asp:Label ID="dberror" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td style="width: 411px">
                 <asp:GridView ID="invoice1" runat="server" AutoGenerateColumns="False" 
                     HorizontalAlign="Center" BackColor="#CCFFFF" BorderColor="Aqua"
         AutoGenerateEditButton="True"   BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" >
                   
                                         <Columns> 
                         
                         <asp:BoundField DataField="Service_name" HeaderText="Service " ReadOnly="True" />
                         <asp:BoundField DataField="service_Cost" HeaderText="Cost" ReadOnly="True" />
                       <asp:BoundField DataField="Insucover" HeaderText="Insurance covered" ReadOnly="True" />
                     <asp:BoundField DataField="youowe" HeaderText="You Owe" ReadOnly="True" />
                               
                       </Columns>
        
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="blue" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
         </asp:GridView>
            </td>

        </tr>
        <tr>
            <td>
<%--<asp:Label ID="ErrorResult" runat="server"></asp:Label>--%>
            </td>
            
            <td>
              <asp:Button ID="crtinvoice" cssclass="submit"  text="Save" runat ="server" OnClick="crtinvoice_Click" />
            <asp:Label ID="insertResult" runat="server">

            </asp:Label></td>
        </tr>
    </table>
    </form>
    </asp:Content>