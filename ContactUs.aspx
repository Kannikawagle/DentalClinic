<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<%-- Add content controls here --%>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
    <ul>
  <li><a href="default.aspx">Home</a></li>
  <li><a href="Patientlogin.aspx">Patient login</a></li>
  <li style ="float:right"> <a class="active" href="ContactUs.aspx">Contact us</a></li>
  <li style="float:right"><a class="active" href="AboutUs.aspx">About us</a></li>
   
</ul>
    <table>
        <tr>
            <td style="width: 489px; font-size: large; font-weight: bold; font-variant: normal; font-family: 'Nirmala UI';">
                Email:
            </td>
            <td style="width: 489px; font-size: large; font-weight: bold; font-variant: normal; font-family: 'Nirmala UI';">
                Telephone:
            </td>
        </tr>
        <tr>
            <td style="width: 489px; height: 70px; font-family: Century; font-size: large; font-style: italic;">
                HelloPearlDental@email.com
            </td>
            <td style="width: 489px; height: 70px; font-family: Century; font-size: large; font-style: italic;">
                3145559999
            </td>
            </tr>
        <tr>
            <td style="width: 489px; font-size: large; font-weight: bold; font-variant: normal; font-family: 'Nirmala UI';">
                Address:
            </td>
            <td style="width: 489px; font-size: large; font-weight: bold; font-variant: normal; font-family: 'Nirmala UI';">
                Questions??
            </td>
        </tr>
        <tr>
            <td style="width: 489px; height: 70px; font-family: Century; font-size: large; font-style: italic;">
                20989 Pearl Avenue,
                <br />
                Pearl City -76554
            </td>
            <td style="width: 380px; height: 213px">
                
            </td>
        </tr>
    </table>

    </asp:Content>