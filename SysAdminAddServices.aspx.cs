using System;
using System.Collections.Generic;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using Oracle.DataAccess.Client;
using System.Web.UI.HtmlControls;

public partial class SysAdminAddServices : System.Web.UI.Page
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
    protected void logout(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("EmpLogin.aspx", true);
    }

    
    protected void addser_Click(object sender, EventArgs e)
    {
        string INSERTSQL;
        INSERTSQL = "INSERT INTO services (";
        INSERTSQL += "service_name, service_id, service_cost, dutation, low_cost ) ";
        INSERTSQL += "VALUES (";
        INSERTSQL += ":service_name, :service_id, :service_cost, :dutation, :low_cost )";

        string selectSQL;
        OracleConnection conn = new OracleConnection(connectionString);
        conn.Open();

        OracleCommand cmd = new OracleCommand();
        cmd.Connection = conn;

        selectSQL = "SELECT services_seq.NEXTVAL ORDER_ID FROM DUAL";
        OracleCommand selcmdorder_id = new OracleCommand(selectSQL, conn);
        cmd.CommandType = CommandType.Text;
        int service_id;
        service_id = Int16.Parse(selcmdorder_id.ExecuteScalar().ToString());

        OracleConnection incon = new OracleConnection(connectionString);
        OracleCommand cmd1 = new OracleCommand(INSERTSQL, incon);
        cmd1.Parameters.Add(":service_name", sername.Text);
        cmd1.Parameters.Add(":service_id", service_id);
        cmd1.Parameters.Add(":service_cost", sercst.Text);
        cmd1.Parameters.Add(":dutation", serduration.Text);
        cmd1.Parameters.Add(":low_cost", lwcst.Text);

        int added1 = 0;
        try
        {
            incon.Open();
            added1 = cmd1.ExecuteNonQuery();
            addservice.Text = "New services added";
        }
        catch (Exception err)
        {
            dberror.Text = "Error inserting record. ";
            dberror.Text += err.Message;
        }
        finally
        {
            incon.Close();
        }

    }
    
}
    
