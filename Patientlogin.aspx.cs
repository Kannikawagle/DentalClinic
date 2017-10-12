using System;
using System.Collections.Generic;
using System.Linq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using Oracle.DataAccess.Client;

//using System.Web.UI.Html.Controls.HtmlAnchor;


public partial class Patientlogin : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["MyOracle"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lgin_Click(object sender, EventArgs e)
    {
        {
            {
                string SelectSQL;
                SelectSQL = "select emai_id, patient_password FROM Patient_info ";
                SelectSQL += "WHERE emai_id = '" + email.Text + "' and patient_password='" + pswrd.Text + "'";


                OracleConnection con = new OracleConnection(connectionString);
                OracleCommand selcmd = new OracleCommand(SelectSQL, con);
                OracleDataReader reader;
                try
                {
                    con.Open();
                    reader = selcmd.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        Session["emai_id"] = email.Text;
                        Response.Redirect("PatientAcc_page.aspx");
                       // string url = "patientAcc_page.aspx?";
                        //url += "Item=" + email.Text;
                       // url += "Mode=" + fname.Text;
                       // Response.Redirect(url);
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
                    con.Close();
                }

            }
        }
    }
}
    
 
