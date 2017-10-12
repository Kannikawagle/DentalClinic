using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using Oracle.DataAccess.Client;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Security;
using System.Text;

public partial class CheckinPatient : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["MyOracle"].ConnectionString;
    string patient_id = null;

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
    protected void logout(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("EmpLogin.aspx", true);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
    }
    protected void dctGRIDVIEW2_RowUpdating(object sender, GridViewUpdateEventArgs e)// update status fro appointment table on update row click
    {
       
        string updateappoint;

        updateappoint = "update appointment set ";
        updateappoint += "  status = :status ";
        updateappoint += "WHERE patient_id=:patient_id ";

        OracleConnection con = new OracleConnection(connectionString);
        OracleCommand cmd = new OracleCommand(updateappoint, con);

      
        cmd.Parameters.Add(":status", (e.NewValues[0].ToString()));
        cmd.Parameters.Add(":patient_id", Int64.Parse(GRIDVIEW.Rows[e.RowIndex].Cells[1].Text)); 

        

        // Try to open database and execute the update.
        int updated = 0;
        try
        {
            con.Open();
            updated = cmd.ExecuteNonQuery();
            updateresult.Text = updated.ToString() + " record updated.";
        }
        catch (Exception err)
        {
            dberror.Text = "Error updating author. ";
            dberror.Text += err.Message;
        }
        finally
        {
            con.Close();
        }
    }

    protected void crtinvoice_Click(object sender, EventArgs e)// creates invoice
    {
          
                string url = "CreateInvoice.aspx?";
                url += "appnum=" + GRIDVIEW.SelectedRow.Cells[1].Text;

                Response.Redirect(url);
            }


    //protected void Button2_Click1(object sender, EventArgs e)
    //{
    //    string url = "CreateInvoice.aspx?";
    //    url += "appnum=" + GRIDVIEW.SelectedRow.Cells[3].Text;
    //}


    protected void discount_Click(object sender, EventArgs e)
    {
        string url = "CreateInvoice.aspx?";
        url += "appnum=" + GRIDVIEW.SelectedRow.Cells[1].Text;

        Response.Redirect(url);
    }
}





