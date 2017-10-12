<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReceptionistAddInsurance.aspx.cs" Inherits="ReceptionistAddInsurance" %>

<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">

  <ul id="menuid" runat="server">
 

             <li style="float:right"><a id="A1" class="active" onserverclick="logout" runat="server" CausesValidation="False">Logout</a></li>
 
</ul>
     <form id="form1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="dberror" runat="server"></asp:Label>
            </td>

        </tr>
        <tr>
            <td>
                <asp:GridView ID="GRIDVIEW" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="SqlDataSource1" HorizontalAlign="Center" BackColor="#CCFFFF" BorderColor="#66FFFF"
        AutoGenerateEditButton="True"   BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AutoGenerateSelectButton="True" >
                   
                                         <Columns> 

                         <asp:BoundField DataField="Patient_id" HeaderText="  Patient number"  />
                        <asp:BoundField DataField="pf_name" HeaderText="First Name" ReadOnly="True" />
                        <asp:BoundField DataField="pn_name" HeaderText="last name" ReadOnly="True" />
                        <asp:BoundField DataField="dob" HeaderText="Date of Birth" ReadOnly="True" />
                        <asp:BoundField DataField="Household_id" HeaderText="House hold id" ReadOnly="True"/>
                              <asp:BoundField DataField="Insurance_id" HeaderText="Insurance Id" ReadOnly="True" />
                              <asp:BoundField DataField="house_h_name" HeaderText=" Name of Household" />
                        
                 
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
                    SelectCommand="
select patient_info.patient_id, patient_info.pf_name, patient_info.pn_name, patient_info.Dob, house_hold.household_id,house_hold.house_h_name,
house_hold.insurance_id from  PATIENT_INFO join  house_hold on patient_info.household_id= house_hold.household_id 
where house_hold.insurance_id is null" 
                     ProviderName="<%$ ConnectionStrings:MyOracle.ProviderName %>">
                </asp:SqlDataSource>  

            </td>
        </tr>
        </table>
    <table>
                 <tr>
                <td class ="frontsize" width="20%">
                    Enter insurance name:
                </td>
                <td width="50%" >
                     &nbsp;<asp:TextBox ID="insuname" runat="server" CssClass="forms"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rev" runat="server" ErrorMessage="enter insurance name"
                    ControlToValidate="insuname" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class ="frontsize" width ="20%">
                    Enter address:
                </td>
                <td width ="50%">
                     <asp:TextBox ID="add" runat="server" CssClass="forms"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="enter address"
                    ControlToValidate="add" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr >
                <td  class ="frontsize" width ="20%">
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
                <td class ="frontsize" width ="20%">
                    Enter insurance number
                </td>
                <td width ="50%">
                    <asp:TextBox ID="insunum" runat="server" CssClass="forms"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter insurance number"
                    ControlToValidate="insunum" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class ="frontsize" width ="20%">
                    <input type="reset" value="Cancel" class="cancelbtn" style="color: #FFFFFF" />
                </td>
                <td width ="50%">
                    <asp:Button ID="Button1" CssClass="submit" runat ="server" Text=" Add Inurance" OnClick="Button1_Click"  />
                </td>
            </tr>
            <tr>
                
                <td class ="frontsize" width ="20%">
                    <asp:Label ID="bderror" runat="server"></asp:Label>
                </td>
                <td width ="50%">
                    <asp:Label ID="addinsurance" runat="server"></asp:Label>
                    <asp:Label ID="updtinsu" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
   </form>
    </asp:Content>
