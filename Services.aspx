<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="Services" %>

<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
     <ul>
         <li>p</li>
  <li><a href="default.aspx">Home</a></li>
  <li><a href="Patientlogin.aspx">Patientlogin</a></li>
   <li style ="float:right"> <a class="active" href="ContactUs.aspx">Contact us</a></li>
  <li style="float:right"><a class="active" href="AboutUs.aspx">About us</a></li>

</ul>
       <br />
    <br />
    <br />
    <table style=" width: 100%; background-color: #00FFFF;" class="table" frame="border">
        <tr>
            <th style="font-size: large; font-style: italic; background-color: white;">
                Services
            </th>
            <th style="font-size: large; font-style: italic; background-color: white; width: 60%;">
                Description about services
            </th>
            <th style="width: 20%; font-size: large; font-style: italic;background-color: white;">
                Cost
            </th>
        </tr>
        <tr >
            <td class="th" style="width: 20%; text-align: center;">
                Filling:
            </td>
            <td  class="th" style  ="width: 60%; text-align: center;"  >
                <br />
                <br />
                To fill the decayed teeth doctors will remove decayed portion of the tooth and 
                then fill the area on the tooth where the decayed material once lived.  
                <br />
                <br />
            </td>
            <td class="th" style="width: 20%; font-size: large; text-align: center;">
                200 $
            </td>
        </tr>
        <tr>
            <td style="width: 20%; background-color: white; text-align: center;" >
                Root Canal:
                <br />
            </td>
            <th style="width: 60%;  background-color: white;">
                <br />
                <br />
                Endodontic treatment is necessary when the pulp, the soft tissue inside the root canal, becomes inflamed or infected. The inflammation or infection can have a variety of causes: deep decay, 
                repeated dental procedures on the tooth, or a crack or chip in the tooth.
                <br />
                <br />
            </th>
            <th style="width: 20%; font-size: large; background-color:white;">
                500$
            </th>
        </tr>
        <tr>
            <th class="th" >
                Cleaning
            </th>
            <th class= " th" style=" width: 60%">
                <br />
                <br />
                Teeth cleaning is part of oral hygiene and involves the removal of dental plaque from teeth with the intention of preventing cavities (dental caries), gingivitis, and periodontal disease.
                 People routinely clean their own teeth by brushing and interdental cleaning, and dental hygienists can remove hardened deposits (tartar) not removed by routine cleaning.
                 Those with dentures and natural teeth may supplement their cleaning with a denture cleaner
                <br />
                <br />
            </th>
            <th class="th" style="width: 20%; font-size: large"; >
                100$
            </th>
        </tr>
        <tr>
            <td style="width: 20%; background-color: white; text-align: center;">
                Crown:
            </td>
            <th style="width: 60%; background-color: white;">
                <br />
                <br />
                The crowning process usually takes two visits. It typically takes two separate appointments for a dentist to place a dental crown. 
                The first appointment involves: 1) Preparing (shaping) the tooth, 2) Taking its impression and 3) Placing a temporary crown.
                <br />
                <br />
            </th>
            <th style="width: 20%; font-size: large;  background-color: white;">
                300$
            </th>
        </tr>
    </table>
    <br />
    <br />
    <br />
    </asp:Content>