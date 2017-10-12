using System;
using System.Collections.Generic;
using System.Linq;
 using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using Oracle.DataAccess.Client;

public partial class EmpLogin : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["MyOracle"].ConnectionString;

    string role = null;
  
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    protected void lgin_Click(object sender, EventArgs e)
    {
        //Session["emp_id"] = id.Text;
        //Session["password"] = pswrd.Text;

        {
            string select;

            select = " Select emp_id , Emp_password, emp_role from clinic_employee ";
            select += "WHERE emp_id = '" + id.Text + "' and emp_password='" + pswrd.Text + "'";

            OracleConnection conn = new OracleConnection(connectionString);
            OracleCommand selctcmd = new OracleCommand(select, conn);
            OracleDataReader reader;
            
            try
            {
                conn.Open();
                reader = selctcmd.ExecuteReader();
                reader.Read();
                

                if (reader.HasRows)
                {
                    Session["emp_id"] = id.Text;
                    role = reader["emp_role"].ToString();
                   
  //                  
                    if (role == "Amdmin")
                    {
                    Response.Redirect("SystemAdminAcc.aspx");
                    }
                    else if (role == "Recep")
                    {
                       
                        Response.Redirect("ReceptionistAcc.aspx");
                    }
                }
                else if (!reader.HasRows)
                {
                    errormsg.Text = ("username or password is incorrect, please try again");
                }
            }

            catch (Exception err)
            {
                dberrlg.Text = "Error getting info. ";
                dberrlg.Text += err.Message;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}