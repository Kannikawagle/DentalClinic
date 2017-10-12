using System;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using Oracle.DataAccess.Client;
using System.Web.UI.HtmlControls;

public partial class SysAdminEditDoctors : System.Web.UI.Page
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
    protected void logout(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("EmpLogin.aspx", true);
    }

    protected void GRIDVIEW_SelectedIndexChanged(object sender, EventArgs e)
    {
        //add to table service_dentist_info
    }


    protected void Adddct_Click(object sender, EventArgs e)
    {
            string INSERTSQL;
            INSERTSQL = "INSERT INTO Clinic_Dentist (";
            INSERTSQL += "Dentist_name, designation, address, telephone, dentist_id, Doct_startDate ) ";
            INSERTSQL += "VALUES (";
            INSERTSQL += ":Dentist_name, :deisgnation, :address, :telephone, :dentist_id, :Doct_startDate )";

            string selectSQL;

            OracleConnection con = new OracleConnection(connectionString);
            OracleCommand cmd1 = new OracleCommand(INSERTSQL, con);
            con.Open();

            // OracleConnection conn = new OracleConnection(connectionString);
            //  conn.Open();



            selectSQL = "SELECT Dentist_seq.NEXTVAL ORDER_ID FROM DUAL";
            OracleCommand selcmdorder_id = new OracleCommand(selectSQL, con);
            int Dentist_id;
            Dentist_id = Int16.Parse(selcmdorder_id.ExecuteScalar().ToString());


            cmd1.Parameters.Add(":Dentist_name", dctname.Text);
            cmd1.Parameters.Add(":Designation", dctdesi.Text);
            cmd1.Parameters.Add(":address", dctadd.Text);
            cmd1.Parameters.Add(":telephone", dctrtele.Text);
            cmd1.Parameters.Add(":dentist_id", Dentist_id);
            cmd1.Parameters.Add(":doct_startdate", Convert.ToDateTime(strtdte.Text));
            //cmd1.Parameters.Add(":doct_enddate", Convert.ToDateTime(enddte.Text));

            int added1 = 0;
            try
            {
              //  con.Open();
                added1 = cmd1.ExecuteNonQuery();
                addresult.Text = "doctor added";
            }
            catch (Exception err)
            {
                dberror.Text = "Error inserting record. ";
                dberror.Text += err.Message;
            }
            finally
            {
                con.Close();
            }


            foreach (GridViewRow row in GRIDVIEW.Rows)
            {
                CheckBox cbSelect = row.FindControl("cbSelect") as CheckBox;
                String insertservice;
                if (cbSelect.Checked)
                {
                    insertservice = "Insert into dentist_service_info(";
                    insertservice += "Dentist_id, service_id )";
                    insertservice += "values(";
                    insertservice += ":Dentist_id, :Service_id )";

                    //  string selectSQL;
                    OracleConnection inservicecon = new OracleConnection(connectionString);


                    OracleCommand cmd2 = new OracleCommand(insertservice, inservicecon);
                    cmd2.Connection = inservicecon;
                    string service = row.Cells[2].Text;
                    //   OracleConnection inservicecon = new OracleConnection(connectionString);
                    //inservicecon.Open();
                    // OracleCommand cmd2 = new OracleCommand(insertservice, inservicecon);
                    cmd2.Parameters.Add(":Dentist_id", Dentist_id);
                    cmd2.Parameters.Add(":Service_id", service);
                    int added = 0;
                    try
                    {
                        inservicecon.Open();
                        added = cmd2.ExecuteNonQuery();
                        addresult.Text = "doctor added";
                    }
                    catch (Exception err)
                    {
                        dberror.Text = "Error inserting record. ";
                        dberror.Text += err.Message;
                    }
                    finally
                    {
                        inservicecon.Close();
                    }
                }
            }
        }
    }

        
        
    

