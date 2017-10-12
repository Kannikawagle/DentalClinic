<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SysAdminAddDoctors.aspx.cs" Inherits="SysAdminEditDoctors" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%-- Add content controls here --%>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
        <ul id="menuid" runat="server">

  <li><a href="SystemAdminAcc.aspx">Account page</a></li>
 
         <li style ="float:right"><a href="EmpLogin.aspx"  onserverclick="logout" runat="server" CausesValidation="False">Logout</a></li>
          <li style="float:right"><a class="active" href="SysAdminAcc_page.aspx" id="backtoacc" runat="server" >Back to account page</a></li>
       
</ul>
     <form id="form1" runat="server">
     <asp:GridView ID="GRIDVIEW" runat="server" AutoGenerateColumns="False" DataKeyNames="Service_id"
                    DataSourceID="SqlDataSource1" HorizontalAlign="Center" BackColor="White" BorderColor="#336666"
         OnSelectedIndexChanged="GRIDVIEW_SelectedIndexChanged" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                   
                         <Columns>
                             <asp:templatefield HeaderText="Select">
                    <itemtemplate>
                        <asp:checkbox ID="cbSelect" CssClass="gridCB" runat="server"></asp:checkbox>
                    </itemtemplate>
                </asp:templatefield>
                      <%--  <asp:CommandField ShowCheckBox="true" /> --%>                       
                        <asp:BoundField DataField="Service_Name" HeaderText="service Name" ReadOnly="True" />
                        <asp:BoundField DataField="Service_id" HeaderText="Service_id" />
                        
                    </Columns>
        
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
         </asp:GridView>
    <asp:HiddenField runat="server" ID="usname" />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ConnectionStrings:MyOracle%>"
                    SelectCommand="SELECT Service_name, Service_id FROM Services"
                    ProviderName="<%$ ConnectionStrings:MyOracle.ProviderName %>">  
     </asp:SqlDataSource>
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
        <table style="width: 946px; margin-right: 50px">
        <tr>
            <td style="width: 296px">
               
            </td>
            <td style="width: 50%">
                <asp:Label ID="dberror1" runat="server"></asp:Label>
                <asp:Label ID="dberror2" runat="server"></asp:Label>
                <br />
            </td>
            </tr>
        <tr>
            <td class ="frontsize" style="width: 36%">style="width: 20%">
                Enter Doctor name:
                <br />
                <br />
            </td>
            
            <td style="width: 50%">
                <asp:TextBox ID="dctname" CssClass="forms" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="frvp" runat="server" ControlToValidate="dctname" 
                    ErrorMessage="Enter name"></asp:RequiredFieldValidator>
                
                <br />
                <br />
            </td>
            
        </tr>
        <tr>
            <td class ="frontsize" style="width: 20%">
                Enter doctor designation:<br />
&nbsp;</td>
            <td style="width: 50%">
                <asp:TextBox ID="dctdesi" CssClass="forms" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvdesi" runat="server" ControlToValidate="dctdesi" 
                    ErrorMessage="Enter designation"></asp:RequiredFieldValidator>
                <br />
                <br />
                </td>
                <td>
                
            </td>
                    </tr>
        <tr>
            <td class ="frontsize" style="width: 20%">
                Enter telephone:
                <br />
                <br />
            </td>
            <td class ="frontsize" style="width: 50%">
                 <asp:TextBox ID="dctrtele" CssClass="forms" runat="server"> </asp:TextBox>
                <asp:Label ID="already" runat="server"></asp:Label>
                              <asp:RequiredFieldValidator ID="rfvtele" runat="server" ControlToValidate="dctrtele" 
                    ErrorMessage="Enter telephone"></asp:RequiredFieldValidator>
             <br />
                 <br />    
            </td>
            <td>
                      
                
            </td>
        </tr>
        <tr>
            <td class ="frontsize" style="height: 33px; width: 20%;">
                Enter doctor address:<br />
                <br />
                </td>
            <td style="width: 50%; height: 50%">
                <asp:TextBox ID="dctadd" CssClass="forms" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvadd" runat="server" ControlToValidate="dctadd" 
                    ErrorMessage="Enter telephone"></asp:RequiredFieldValidator>
                <br />

            </td>
            <td>
                
                
            </td>

        </tr>
        <tr>
            <td class ="frontsize" style="width: 20%">
                Enter appointment start date:
                <br />
                <br />
            </td>
            <td style="width: 50%">
                <asp:TextBox ID="strtdte" CssClass="forms" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvsdte" runat="server" ControlToValidate="strtdte" 
                    ErrorMessage="Start date is required"></asp:RequiredFieldValidator>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" 
                        TargetControlID="strtdte" runat="server" />
                </td>
            <td>
               
                <br />
                <br />
            </td>
            </tr>
        <tr>
            <td style="width: 20%"> 
                 <input type="reset" value="Cancel" class="cancelbtn" /></td>
            <td style="width: 50%">
                <asp:Button ID="Adddct" runat="server" CssClass="submit" Text ="Add Doctor" OnClick="Adddct_Click" />
                <asp:Label ID="dberror" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 20%"></td>
            <td style="width: 50%">
                <asp:Label ID="addresult" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
        </form>
</asp:Content>