<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CheckinPatient.aspx.cs" Inherits="CheckinPatient" %>

<%-- Add content controls here --%>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">

    <ul id="menuid" runat="server">
 
  
          <li style="float:right"><a id="A1" class="active" onserverclick="logout" runat="server" CausesValidation="False">Logout</a></li>
 
</ul>
    <br />
    <br />
    <form id="form1" runat="server">
    <asp:GridView ID="GRIDVIEW" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="SqlDataSource1" HorizontalAlign="Center" BackColor="#CCFFFF" BorderColor="#66FFFF"
        OnRowUpdating="dctGRIDVIEW2_RowUpdating"  AutoGenerateEditButton="True"   BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AutoGenerateSelectButton="True" >
                   
                                         <Columns> 

                         <asp:BoundField DataField="Appointment_num" HeaderText=" Appointment number"  />
                         <asp:BoundField DataField="patient_id" HeaderText="patient Id" ReadOnly="True" />                      
                        <asp:BoundField DataField="pf_name" HeaderText="First Name" ReadOnly="True" />
                        <asp:BoundField DataField="pn_name" HeaderText="last name" ReadOnly="True" />
                        <asp:BoundField DataField="Start_time" HeaderText="Start time" ReadOnly="True" />
                        <asp:BoundField DataField="end_time" HeaderText="end time" ReadOnly="True"/>
                              <asp:BoundField DataField="room" HeaderText="Room" ReadOnly="True" />
                              <asp:BoundField DataField="status" HeaderText=" Status" />
                         <asp:BoundField DataField="Insurance_id" HeaderText=" Insurance" />
                 
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
SELECT appointment.appointment_num,appointment.patient_id, patient_info.pf_name, patient_info.pn_name, appointment.start_time,
                    appointment.end_time, appointment.room, appointment.status, house_hold.insurance_id from patient_info join appointment on patient_info.patient_id=
                    appointment.patient_id join house_hold on patient_info.household_id = house_hold.household_id "

                    updatecommand = "update appointment set 
           status = :status  WHERE patient_id=:patient_id "
      
                    ProviderName="<%$ ConnectionStrings:MyOracle.ProviderName %>">  

                    <UpdateParameters>
        <asp:Parameter Name="status" Type="string" />
        <asp:Parameter Name="patient_id" Type="Int64" />
           </UpdateParameters>
     </asp:SqlDataSource>
    <table>
        <tr>
            <td style="width: 254px">
                <input type="reset" value="Cancel"  class="cancelbtn frontsize"  />&nbsp;</td>
            <td style="width: 432px">
                <asp:Button ID="crtinvoice" cssclass="submit frontsize"  text="Create Invoice" runat ="server" OnClick="crtinvoice_Click" />
            </td>
            <td style="width: 368px">
                <asp:Button ID="discount" cssclass="submit frontsize"  text="Create Discounted Invoice" runat ="server" OnClick="discount_Click" />
        </tr>
        <tr>
            <td style="width: 254px"></td>
            <td style="width: 432px">
                <asp:Label ID="dberror" runat="server">

                </asp:Label>
                <asp:Label ID="updateresult" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
        </form>
    </asp:Content>