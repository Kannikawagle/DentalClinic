using System.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using Oracle.DataAccess.Client;
using System.Web.UI.HtmlControls;


public partial class PatientAcc_page : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["MyOracle"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["emai_id"] == null)
        {
            Response.Redirect("Patientlogin.aspx");
        }

        string SelectSQL;
        //string INSERTSQLACC = "";
        SelectSQL = "select pf_name FROM patient_info ";
        SelectSQL += "WHERE emai_id = '" + Session["emai_id"].ToString() + "'";

        OracleConnection con = new OracleConnection(connectionString);// create new connection
        OracleCommand selcmd = new OracleCommand(SelectSQL, con); // open command with sql sttme aganist above connection
        OracleDataReader reader = null; // reader for result
        try
        {
            con.Open(); // open connection
            reader = selcmd.ExecuteReader(); // execute connmand
            reader.Read();// reads result

            HtmlGenericControl li = new System.Web.UI.HtmlControls.HtmlGenericControl("li"); //create html li tag
            HtmlGenericControl a = new System.Web.UI.HtmlControls.HtmlGenericControl("a"); // create html a tag
            a.InnerText = "Welcome " + reader["pf_name"]; //text 
            li.Controls.Add(a);//add a inside li tag
            menuid.Controls.Add(li); // add li to ul tag

        }

        catch (Exception err)
        {
            dberr.Text = "Error selecting record. ";
            dberr.Text += err.Message;
        }
        finally
        {
            con.Close();

        }
    }
    protected void button_click(object sender, EventArgs e)
    {
        string url = "AddHousehold.aspx?";
       
    }
     protected void button_clickmakeapp(object sender, EventArgs e)

    {
        string url = "MakeAppointment.aspx?";
       
    }
     //protected void button_clickchkinvoice(object sender, EventArgs e)
     //{
     //    string url = "CheckInvoice.aspx?";

     //}

    protected void button_clickinsu(object sender, EventArgs e)
    {
        string url = "AddInsurance.aspx?";
    }

    protected void button_clickapp(object sender, EventArgs e)
    {
        string url = "Checkupcomingapp.aspx?";
        
    }

    protected void button_clickinvoice(object sender, EventArgs e)
    {
        string url = "CheckInvoice.aspx?";
        
    }
    protected void button_checkTreatment(object sender, EventArgs e)
    {
        string url = "CheckTreatmenthitory.aspx?";
    }
    protected void logout(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Patientlogin.aspx", true);
    }
}