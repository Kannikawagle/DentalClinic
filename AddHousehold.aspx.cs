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

public partial class AddHousehold : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["MyOracle"].ConnectionString;

    string householdid = null;
    protected void Page_Load(object sender, EventArgs e)// page load login secession begins
    {
        if (Session["emai_id"] == null)
        {
            Response.Redirect("Patientlogin.aspx");
        }
        string SelectSQL;
        //string INSERTSQLACC = "";
        SelectSQL = "select pf_name, household_id FROM patient_info ";
        SelectSQL += "WHERE emai_id = '" + Session["emai_id"].ToString() + "'";
        backtoacc.HRef = "PatientAcc_page.aspx?Item=" + Session["emai_id"].ToString() + "'";
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
            householdid = reader["household_id"].ToString();

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

    protected void adding_Click(object sender, EventArgs e)// adding dependents
    {
        string SelectSQL; // selects household id ti insert into house hold table 
        SelectSQL = "select household_id FROM patient_info ";
        SelectSQL += "WHERE emai_id = '" + Session["emai_id"].ToString() + "'";

        OracleConnection con = new OracleConnection(connectionString);// create new connection
        OracleCommand selcmd = new OracleCommand(SelectSQL, con); // open command with sql sttme aganist above connection
        OracleDataReader reader = null; // reader for result
        String houseHoldId = null;
        try
        {
            con.Open(); // open connection
            reader = selcmd.ExecuteReader(); // execute connmand
            reader.Read();// reads result
            houseHoldId = reader["household_id"].ToString();

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

        string inserthousehold; // insert into household table

        inserthousehold = "INSERT INTO patient_info (";
        inserthousehold += "pf_name, pn_name, patient_id, address, telephone, DOB, relation_ship,  household_id) ";
        inserthousehold += "VALUES (";
        inserthousehold += ":pf_name, :pn_name, :patient_id, :address,  :telephone, :DOB, :relation_ship, :household_id )";


        string selectSQL;

        OracleCommand cmd = new OracleCommand(inserthousehold, con);
        con.Open();

        selectSQL = "SELECT Patient_seq.NEXTVAL ORDER_ID FROM DUAL";// generating next patinet id
        OracleCommand selcmdorder_id = new OracleCommand(selectSQL, con);
        //   cmd.CommandType = CommandType.Text;
        int patients_id;
        patients_id = Int16.Parse(selcmdorder_id.ExecuteScalar().ToString());


        cmd.Parameters.Add(":pf_name", fname.Text);
        cmd.Parameters.Add(":pn_name", lname.Text);
        cmd.Parameters.Add(":patient_id", patients_id);
        cmd.Parameters.Add(":address", add.Text);
        cmd.Parameters.Add(":telephone", tele.Text);
        cmd.Parameters.Add(":DOB", Convert.ToDateTime(dob.Text));
        cmd.Parameters.Add(":relation_ship", dd.SelectedItem.Value);
        cmd.Parameters.Add(":household_id", (houseHoldId));

        int added1 = 0;

        try
        {
            added1 = cmd.ExecuteNonQuery();
            addresult.Text = ("Added sucessfully");

        }

        catch (Exception err)
        {
            dberr.Text = "Error inserting record. ";
            dberr.Text += err.Message;
        }

        finally
        {
            con.Close();
        }

    }

    public string household_id { get; set; }


    protected void logout(object sender, EventArgs e)//Clear session
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Patientlogin.aspx", true);
    }
}
        