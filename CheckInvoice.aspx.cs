using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using Oracle.DataAccess.Client;
using System.Web.UI.HtmlControls;

public partial class CheckInvoice : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["MyOracle"].ConnectionString;

    string householdid = null;
    string patientId = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["emai_id"] == null)
        {
            Response.Redirect("Patientlogin.aspx");
        }

        string SelectSQL;
        //string INSERTSQLACC = "";
        SelectSQL = "select pf_name, household_id, patient_id FROM patient_info ";
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
            patientId = reader["patient_id"].ToString();

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
        if (!IsPostBack)
        {
            this.populatedependends();
        }
        
    }
    private void populatedependends() // populates dependents in gridview
    {
        string selecthousehold;
        selecthousehold = "select pf_name,  patient_id FROM patient_info ";
        selecthousehold += "WHERE household_id = '" + householdid + "'";
        OracleConnection conhouse = new OracleConnection(connectionString);
        OracleCommand cmd = new OracleCommand(selecthousehold, conhouse);
        OracleDataReader reader;
        try
        {
            conhouse.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListItem item = new ListItem();
                item.Text = reader["Pf_name"].ToString();
                item.Value = reader["patient_id"].ToString();

                patientId = reader["patient_id"].ToString();

                householdbox.Items.Add(item);
            }

        }
        catch (Exception err)
        {
        }
        finally
        {
            conhouse.Close();
        }
    }

    protected void logout(object sender, EventArgs e)//logout session
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Patientlogin.aspx", true);
    }



    protected void submit_Click(object sender, EventArgs e) // fills invoice
    {
        fillcheckinvoice();
    }

    private void fillcheckinvoice()
    {
        display.DataSource = GetDataSet2().Tables["Invoice"];
        display.DataBind();
        Session["DataTable2"] = display.DataSource;
    }

    private DataSet GetDataSet2() // fills gridview2 for selected id
    {
        // string value = selectdisplay.SelectedRow.Cells[1].Text;
        string selectSQL1;
        selectSQL1 = "SELECT invoice_number, appointment_num, patient_id, patient_name, ";
        selectSQL1 += " price_paid, invoice_date FROM invoice where patient_id = '" + householdbox.SelectedValue.ToString() + "'";
        OracleConnection con = new OracleConnection(connectionString);
        OracleDataAdapter adapter = new OracleDataAdapter(selectSQL1, con);
        

        DataSet display = new DataSet();
        try
        {

            adapter.Fill(display, "invoice");
            return display;

            
        }
        catch (Exception err)
        {
            dberr.Text = "Error reading list  ";
            dberr.Text += err.Message;
            return null;
        }
    }
}