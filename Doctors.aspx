<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Doctors.aspx.cs" Inherits="Doctors" %>

<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
     <ul>
  <li><a href="default.aspx">Home</a></li>
  <li><a href="Patientlogin.aspx">Patientlogin</a></li>
  <li style ="float:right"> <a class="active" href="ContactUs.aspx">Contact</a></li>
  <li style="float:right"><a class="active" href="AboutUs.aspx">About Us</a></li>
   
</ul>
    <br />
    <br />
    <br />
   <table style=" width: 80%" class="table" frame="border">
        <tr>
            <th style="font-size: large; font-style: italic; background-color: white;">
                
            </th>
            <th  style="font-size: large; font-style: italic; background-color: white; width: 55%;">
                Our Doctors
            </th>
            
        </tr>
        <tr >
            <td class="th" style="width: 20%; text-align: center;">
              Dr.Julie
            </td>
            <td  class="th" style  ="width: 60%; text-align: center;"  >
                <br />
                <br />
                Dr. Julie is a menmber of American Dental Association. She is committed to continuing
                her education in order to best serve her patients and strives to provide the highest standard of dental care. 
       </td>

</tr>  
          <tr >
            <td class="th" style="width: 20%; background-color:white; color: #000000; text-align: center;">
              Dr.Sonia
            </td>
            <td  class="th" style  ="width: 60%; background-color:white; color: #000000; text-align: center;">
                <br />
                <br />
                Dr. Sonia is a menmber of American Dental Association. She loves getting to know each and every patient, 
                and helping them feel comfortable and appreciated here.
       </td>

</tr>
        
       <tr>
        <td class="th" style="width: 20%; text-align: center;";>
             Dr.Edward
            </td>
            <td  class="th" style  ="width: 60%; text-align: center;";  >
  
            Dr. Edward is a menmber of American Dental Association He enjoy all the smiles he meet everyday and the variety of tasks. 
            His favorite moments are when we encounter a patient who is very fearful of seeing a dentist and by the time they leave our office 
           their fear has subsided and they have a great big smile on their face.

       </td>
            </tr>

         <tr>
            <th style="font-size: large; font-style: italic; background-color: white; height: 33px;">
                
            </th>
            <th style="font-size: large; font-style: italic; background-color: white; width: 55%; height: 33px;">
                Our Nurse
            </th>
            
        </tr>
        <tr>
        <td class="th" style="width: 20%; text-align: center;";>
             George
            </td>
            <td  class="th" style  ="width: 60%; text-align: center;";  >
  
              He really enjoy working with all the staff and patients at this office.
                He looks forward to meeting new people and learning new things everyday. 

       </td>
            </tr>
      
    </table>
    </asp:Content>