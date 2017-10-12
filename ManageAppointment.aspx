﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageAppointment.aspx.cs" Inherits="ManageAppointment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
  
    <ul id="menuid" runat="server">
 
  <li><a href="default.aspx">Home</a></li>
  
          <li style="float:right"><a class="active" href="ReceptionistAcc.aspx" id="backtoacc" runat="server">Back to account page</a></li>
             <li style="float:right"><a id="A1" class="active" onserverclick="logout" runat="server">Logout</a></li>
  
</ul>
    <br />
    <br />
     <form id="form1" runat="server">

           <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>

           <asp:Label ID="Label1" runat="server" Text="Appointment Date"></asp:Label>

           <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

           <ajaxToolkit:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" TargetControlID="TextBox1" />
         <asp:Button ID="Button1" runat="server" Text="Get Appointments" OnClick="Button1_Click" />
  <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="TextBox1" 
                    ErrorMessage="Appointment date is required"></asp:RequiredFieldValidator>

    <table>
        <tr>
            <td></td>
            <td><asp:GridView ID="display" runat="server" AllowPaging="True" 
            AllowSorting="True" CellPadding="3" Width="394px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" AutoGenerateDeleteButton="True" OnRowEditing="display_RowEditing" OnRowUpdating="display_RowUpdating" OnSelectedIndexChanged="display_SelectedIndexChanged" OnRowDeleting="display_RowDeleting">
                 <%--<Columns>
                        
                        <asp:BoundField DataField="Patient_id" HeaderText="Patient Id" ReadOnly="True" />
                        <asp:BoundField DataField="Pf_name" HeaderText="Patient first name" ReadOnly="True" />
                      <asp:BoundField DataField="Pn_name" HeaderText="Patient last name" ReadOnly="True" />
                     <asp:BoundField DataField="status" HeaderText="Appointment status" ReadOnly="false" />
                     <asp:BoundField DataField="Start_time" HeaderText="Appointment start time" ReadOnly="True" />
                     <asp:BoundField DataField="appointment_num" HeaderText="Appointment number" ReadOnly="True" />
                     <asp:BoundField DataField="room" HeaderText="Room number" ReadOnly="True" />
                             </Columns> --%>           
                
                 <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
                    <EmptyDataTemplate>No Appointments for selected day</EmptyDataTemplate>
        </asp:GridView>
                <asp:Label ID="dberror" runat="server"></asp:Label>
                <asp:Label ID ="sucess" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
         </form>
 
</asp:Content>