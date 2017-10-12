<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SysAdminEditDoctor.aspx.cs" Inherits="SysAdminEditDoctor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server" >
    
      <ul id="menuid" runat="server">
  
       
   <li style ="float:right"><a href="EmpLogin.aspx" onserverclick="logout" runat="server" CausesValidation="False">Logout</a></li>
   <li style="float:right"><a class="active" href="SystemAdminAcc.aspx" id="backtoacc" runat="server">Back to account page</a></li>
</ul>
     <form id="form1" runat="server">
         <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <table >
        <tr>
            <td>
                <asp:Label ID="dberror" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            Edit Doctor
                </td>
        </tr>
        <tr>
            <td>
    <asp:GridView ID="DctGRIDVIEW" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="SqlDataSource1" HorizontalAlign="Center" BackColor="White" BorderColor="#336666"
          BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Height="405px" OnRowUpdating="dctGRIDVIEW_RowUpdating">
                    <Columns>
                        <asp:CommandField ShowSelectButton="false" />
                        <asp:CommandField ShowEditButton="true" />
                        
                        <asp:BoundField DataField="dentist_id" HeaderText="Dentist id" ReadOnly="True" />
                            <asp:BoundField DataField="dentist_name" HeaderText="dentist name" />
                         <asp:BoundField DataField="designation" HeaderText="Designation" />
                         <asp:BoundField DataField="Address" HeaderText="Address" />
                         <asp:BoundField DataField="Telephone" HeaderText="Telephone" />
                         <asp:BoundField DataField="doct_Startdate" HeaderText="Start date" />
                         <asp:BoundField DataField="doct_enddate" HeaderText="End date" />
                         
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

   
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ConnectionStrings:MyOracle%>"
                    SelectCommand="SELECT * FROM Clinic_dentist "
                     
                     Updatecommand ="update  clinic_dentist set
                dentist_name=:dentist_name, designation=:designation, address= :address,
                telephone= :telephone, doct_startdate= :doct_startdate, doct_enddate= :doct_enddate 
               WHERE dentist_id=:dentist_id "
                   
                    ProviderName="<%$ ConnectionStrings:MyOracle.ProviderName %>">  
 
                    
                 <UpdateParameters>
        <asp:Parameter Name="dentist_name" Type="string" />
        <asp:Parameter Name="designation" Type="String" />
          <asp:Parameter Name="address" Type="String" />
        <asp:Parameter Name="telephone" Type="Int64" />
          <asp:Parameter Name="doct_startdate" Type="DateTime" />
          <asp:Parameter Name="doct_enddate" Type="DateTime" />
    </UpdateParameters>
 
                     </asp:SqlDataSource>
                        
                   </td>
            </tr>
              <tr>
                  <td>
                     Add doctor vacation 
                 </td>
              </tr>
             <tr>
                 
                 <td>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="SqlDataSource1" HorizontalAlign="Center" BackColor="White" BorderColor="#336666"
          BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Height="535px" OnRowUpdating="dctGRIDVIEW2_RowUpdating" Width="909px" AutoGenerateEditButton="True"  >
                    <Columns>
                        
                        <asp:BoundField DataField="dentist_name" HeaderText="Dentist name" ReadOnly="True" />
                        <asp:BoundField DataField="dentist_id" HeaderText="Dentist id" ReadOnly="True" />
                         <asp:TemplateField HeaderText="Start date">
                    <ItemTemplate>
                        <asp:TextBox ID="strtdte" runat="server"></asp:TextBox>
                         <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="strtdte" runat="server" />
                    </ItemTemplate>
                      <FooterTemplate>
                               <asp:Button ID="Button1" runat="server" Text="Button Submit Footer" />
                      </FooterTemplate>    
                </asp:TemplateField> 
                        <asp:TemplateField HeaderText="End date">
                    <ItemTemplate>
                        <asp:TextBox ID="enddte" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="enddte" runat="server" />
                    </ItemTemplate>
                      <FooterTemplate>
                               <asp:Button ID="Button2" runat="server" Text="Button Submit Footer" />
                      </FooterTemplate>    
                </asp:TemplateField>   
                         
                        
                                          <asp:BoundField />
                                          <asp:TemplateField></asp:TemplateField>
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

   
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ConnectionStrings:MyOracle%>"
                    SelectCommand="SELECT doctor_name, dentist_id FROM Clinic_dentist">

                                                              </asp:SqlDataSource>
    </td>
        </tr>
       
        <tr>
            <td>
            <asp:Label ID="bdreeor" runat="server"></asp:Label>
            <asp:Label ID="adderror" runat="server"></asp:Label>
                </td>
        </tr>
                <tr>
                    <td>
            <asp:Label id="editresult" runat="server"></asp:Label>
            <asp:Label ID="errresult" runat="server"></asp:Label>
                        </td>
        </tr>
        
        

        
    </table>
          </form>
    </asp:Content>
