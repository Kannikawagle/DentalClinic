<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PopulateDate.aspx.cs" Inherits="PopulateDate" %>

<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server" >

     <asp:GridView ID="DctGRIDVIEW" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="SqlDataSource1" HorizontalAlign="Center" BackColor="White" BorderColor="#336666"
          BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Height="377px" OnSelectedIndexChanged="DctGRIDVIEW_SelectedIndexChanged"  >
                    <Columns>
                        <asp:CommandField ShowSelectButton="TRUE" />
                        <asp:CommandField ShowEditButton="FALSE" />
                        
                        <asp:BoundField DataField="Room_num" HeaderText="Room number" ReadOnly="True" />
                            
                         
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
                    SelectCommand="SELECT Room_num FROM room 
                     "
                      ProviderName="<%$ ConnectionStrings:MyOracle.ProviderName %>">  
 
   </asp:SqlDataSource>
    <asp:Label ID="dberror" runat="server">

    </asp:Label>
                        <asp:Label ID="result" runat="server"></asp:Label>
    </asp:Content>