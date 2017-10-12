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

public partial class ReceptionistAddInsurance : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["MyOracle"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
         if (Session["emp_id"] == null)
        {
            Response.Redirect("EmpLogin.aspx");
        }

        string SelectSQL;
        //string INSERTSQLACC = "";
        SelectSQL = "select Emp_name FROM Clinic_employee ";
        SelectSQL += "WHERE Emp_id = '" + Session["emp_id"].ToString() + "'";

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
            a.InnerText = "Welcome " + reader["emp_name"]; //text 
            li.Controls.Add(a);//add a inside li tag
            menuid.Controls.Add(li); // add li to ul tag

        }

        catch (Exception err)
        {
            dberror.Text = "Error selecting record. ";
            dberror.Text += err.Message;
        }
        finally
        {
            con.Close();

        }
    }

   protected void Button1_Click(object sender, EventArgs e)
        
    {
        string insertinsurance;

        insertinsurance = "INSERT INTO insurance (";
        insertinsurance += "company_name, address, telephone, insurance_id ) ";
        insertinsurance += "VALUES (";
        insertinsurance += ":company_name, :address, :telephone, :insurance_id )";

        OracleConnection inconins = new OracleConnection(connectionString);
        OracleCommand cmd = new OracleCommand(insertinsurance, inconins);
        inconins.Open();

        cmd.Parameters.Add(":company_name", insuname.Text);
        cmd.Parameters.Add(":address", add.Text);
        cmd.Parameters.Add(":telephone", tphone.Text);
        cmd.Parameters.Add(":insurance_id", insunum.Text);
        int added1 = 0;

        try
        {
            added1 = cmd.ExecuteNonQuery();
            addinsurance.Text = ("Insurance added sucessfully");

       }

        catch (Exception err)
        {
            bderror.Text = "Error inserting record. ";
            bderror.Text += err.Message;
        }

        finally
        {
            inconins.Close();
        }

        string updatepat;
        updatepat = "update house_hold set ";
        updatepat += "  insurance_id = :insurance_id ";
        updatepat += "WHERE household_id=:household_id";

        //  OracleConnection inconins = new OracleConnection(connectionString);
        OracleCommand cmdin = new OracleCommand(updatepat, inconins);


        cmdin.Parameters.Add(":insurance_id", Int32.Parse(insunum.Text));
        cmdin.Parameters.Add(":household_id",Int32.Parse( GRIDVIEW.SelectedRow.Cells[5].Text));



        // Try to open database and execute the update.
        int updated = 0;
        try
        {
            inconins.Open();
            updated = cmdin.ExecuteNonQuery();
          //  updtinsu.Text = updated.ToString() + " record updated.";
            GRIDVIEW.DataBind();
            insuname.Text = null;
            add.Text = null;
            tphone.Text = null;
            insunum.Text = null;
            GRIDVIEW.SelectedIndex = -1;
            
        }
        catch (Exception err)
        {
            bderror.Text = "Error inserting. ";
            bderror.Text += err.Message;
        }
        finally
        {
            inconins.Close();
        }

    }
   protected void logout(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("EmpLogin.aspx", true);
    }

    
}

   