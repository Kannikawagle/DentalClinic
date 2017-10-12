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

public partial class SystemAdminAcc : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["MyOracle"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        //    string emp_id = Session["Emp_id"].ToString();
        {

            if (Session["emp_id"] == null)
            {
                Response.Redirect("EmpLogin.aspx");
            }

            string SelectSQL;
            //string INSERTSQLACC = "";
            SelectSQL = "select Emp_name FROM Clinic_employee ";
            SelectSQL += "WHERE Emp_id = '" + Session["emp_id"].ToString() +"'";

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
    }
    protected void logout(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("EmpLogin.aspx", true);
    }
    
    protected void adddct_Click(object sender, EventArgs e)
    {
        Response.Redirect("SysAdminAddDoctors.aspx");
    }
    protected void addser_Click(object sender, EventArgs e)
    {
        Response.Redirect("SysAdminAddServices.aspx");
    }
    
}