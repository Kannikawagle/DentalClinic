using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using Oracle.DataAccess.Client;
using System.Web.UI.HtmlControls;


public partial class Forgotpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string connectionString = "Data Source=Oracle8i;Integrated Security=yes";
        string connectionString = WebConfigurationManager.ConnectionStrings["MyOracle"].ConnectionString;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String selectpassword;
        selectpassword = " select SECURITY_ANS from Patient_info ";
        selectpassword= " where EMAI_ID = '" + security.Text + "'";

        OracleConnection con = new OracleConnection(connectionString);
        OracleCommand selcmd = new OracleCommand(selectpassword, con);
        OracleDataReader reader;
        try
        {
            con.Open();
            reader = selcmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                message.Text= ("password is sent to your email id");
            }
            else if (!reader.HasRows)
            {
                errmsg.Text = ("username or password is incorrect, please try again later");
            }

        }
        catch (Exception err)
        {
            dberror.Text = "Error getting info. ";
            dberror.Text += err.Message;
        }
        finally
        {
            con.Close();
        }

    }

    public string connectionString { get; set; }
}