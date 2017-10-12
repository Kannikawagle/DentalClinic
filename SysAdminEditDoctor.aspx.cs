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

public partial class SysAdminEditDoctor : System.Web.UI.Page
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
    
    
    private void BindData()
    {
        DctGRIDVIEW.DataSource = Session["clinic_dentist"];
        DctGRIDVIEW.DataBind();
    }
    protected void dctGRIDVIEW_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string updateSQL;
        updateSQL = "UPDATE clinic_dentist set ";
        updateSQL += "dentist_name=:dentist_name, designation=:designation, address= :address, ";
        updateSQL += " telephone= :telephone, doct_startdate= :doct_startdate, doct_enddate= :doct_enddate ";
        updateSQL += "WHERE dentist_id=:dentist_id ";

        OracleConnection con = new OracleConnection(connectionString);
        OracleCommand cmd = new OracleCommand(updateSQL, con);

        cmd.Parameters.Add(":dentist_name", e.NewValues[0].ToString());
        cmd.Parameters.Add(":designation", e.NewValues[1].ToString());
        cmd.Parameters.Add(":address", e.NewValues[2].ToString());
        cmd.Parameters.Add(":telephone", Int64.Parse(e.NewValues[3].ToString()));
        cmd.Parameters.Add(":doct_startdate", Convert.ToDateTime(e.NewValues[4].ToString()));
        cmd.Parameters.Add(":doct_enddate", Convert.ToDateTime(e.NewValues[5].ToString()));
        cmd.Parameters.Add(":dentist_id", Int64.Parse(DctGRIDVIEW.Rows[e.RowIndex].Cells[3].Text));
        // Try to open database and execute the update.
        int updated = 0;
        try
        {
            con.Open();
            updated = cmd.ExecuteNonQuery();
            editresult.Text = updated.ToString() + " record updated.";
        }
        catch (Exception err)
        {
            errresult.Text = "Error updating author. ";
            errresult.Text += err.Message;
        }
        finally
        {
            con.Close();
        }
        DctGRIDVIEW.EditIndex = -1;
        DctGRIDVIEW.DataBind();

    }

    protected void dctGRIDVIEW2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DateTime currentTime = DateTime.Now;
        DateTime endDate = DateTime.Today.AddDays(90);
        foreach (DateTime day in EachDay(currentTime, endDate))
        {
            if (IsWeekend(day))
            {
                string insertweekend;
                String selectsql;
                selectsql = " select slot1 ";
                selectsql += " from tempdentistslot ";
                selectsql += "WHERE appdate = :day and dentist_id=:dentistid";// +Convert.ToDateTime(day) + "'";
                OracleConnection incon = new OracleConnection(connectionString);
                OracleCommand cmd1 = new OracleCommand(selectsql, incon);
                cmd1.Parameters.Add(":day", day);
                cmd1.Parameters.Add(":dentistid", Int64.Parse(GridView2.Rows[e.RowIndex].Cells[2].Text));
                incon.Open();
                OracleDataReader readerchk;
                try
                {
                    readerchk = cmd1.ExecuteReader();
                    readerchk.Read();
                    if (!readerchk.HasRows)
                    {
                        insertweekend = "INSERT INTO tempDentistSlot (";
                        insertweekend += "dentist_id, appdate, slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8, vaction ) ";
                        insertweekend += "VALUES (";
                        insertweekend += ":dentist_id, :appdate, :slot1,:slot2, :slot3, :slot4, :slot5, :slot6, :slot7, :slot8, :vaction)";
                        // OracleConnection incon = new OracleConnection(connectionString);
                        OracleCommand cmd2 = new OracleCommand(insertweekend, incon);
                        cmd2.Parameters.Add(":dentist_id", Int64.Parse(GridView2.Rows[e.RowIndex].Cells[2].Text));
                        cmd2.Parameters.Add(":APPDATE", Convert.ToDateTime(day.ToString()));
                        cmd2.Parameters.Add(":slot1", "w");
                        cmd2.Parameters.Add(":slot2", "w");
                        cmd2.Parameters.Add(":slot3", "w");
                        cmd2.Parameters.Add(":slot4", "w");
                        cmd2.Parameters.Add(":slot5", "w");
                        cmd2.Parameters.Add(":slot6", "w");
                        cmd2.Parameters.Add(":slot7", "w");
                        cmd2.Parameters.Add(":slot8", "w");
                       cmd2.Parameters.Add(":vaction", "");
                        cmd2.BindByName = true;
                        int added1 = 0;

                       // incon.Open();
                        added1 = cmd2.ExecuteNonQuery();
                        adderror.Text = "Update doctor vacation";
                    }
                }
                catch (Exception err)
                {
                    bdreeor.Text = "Error inserting record. ";
                    bdreeor.Text += err.Message;
                }
                finally
                {
                    incon.Close();
                }
            }
            TextBox t = (TextBox)GridView2.Rows[e.RowIndex].Cells[2].FindControl("strtdte");
            string strdte = t.Text;
         //   string strdte = (GridView2.FooterRow.FindControl("startdate") as TextBox).Text;
           // string enddte = (GridView2.FooterRow.FindControl("enddate") as TextBox).Text;
            TextBox t1 = (TextBox)GridView2.Rows[e.RowIndex].Cells[2].FindControl("enddte");
            string enddte = t1.Text;

  if (day >= Convert.ToDateTime(strdte) && day <= Convert.ToDateTime(enddte))
            {
                string INSERTSQL;
                INSERTSQL = "INSERT INTO tempDentistSlot (";
                INSERTSQL += "dentist_id, appdate, slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8, vaction) ";
                INSERTSQL += "VALUES (";
                INSERTSQL += ":dentist_id, :appdate, :slot1, :slot2, :slot3, :slot4, :slot5, :slot6, :slot7, :slot8, :vaction )";



                OracleConnection incon = new OracleConnection(connectionString);
                OracleCommand cmd = new OracleCommand(INSERTSQL, incon);

                //   incon2.Open();


                cmd.Parameters.Add(":dentist_id", Int64.Parse(GridView2.Rows[e.RowIndex].Cells[2].Text));
                cmd.Parameters.Add(":APPDATE", Convert.ToDateTime(day.ToString()));
                cmd.Parameters.Add(":slot1", "v");
                cmd.Parameters.Add(":slot2", "v");
                cmd.Parameters.Add(":slot3", "v");
                cmd.Parameters.Add(":slot4", "v");
                cmd.Parameters.Add(":slot5", "v");
                cmd.Parameters.Add(":slot6", "v");
                cmd.Parameters.Add(":slot7", "v");
                cmd.Parameters.Add(":slot8", "v");
                cmd.Parameters.Add(":vaction", "v");
                cmd.BindByName = true;

                int added2 = 0;
                try
                {
                    incon.Open();
                    added2 = cmd.ExecuteNonQuery();
                    adderror.Text = "New services added";
                }
                catch (Exception err)
                {
                    bdreeor.Text = "Error inserting record. ";
                    bdreeor.Text += err.Message;
                }
                finally
                {
                    incon.Close();
                }
            }

            else if (!IsWeekend(day))
            {
                string INSERTSQL;
                INSERTSQL = "INSERT INTO tempDentistSlot (";
                INSERTSQL += "dentist_id, appdate, slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8, vaction) ";
                INSERTSQL += "VALUES (";
                INSERTSQL += ":dentist_id, :appdate, :slot1, :slot2, :slot3, :slot4, :slot5, :slot6, :slot7, :slot8, :vaction )";


               OracleConnection incon2 = new OracleConnection(connectionString);
                OracleCommand cmd3 = new OracleCommand(INSERTSQL, incon2);

                //incon2.Open();


                cmd3.Parameters.Add(":dentist_id", Int64.Parse(GridView2.Rows[e.RowIndex].Cells[2].Text));
                cmd3.Parameters.Add(":APPDATE", Convert.ToDateTime(day.ToString()));
                cmd3.Parameters.Add(":slot1", "");
                cmd3.Parameters.Add(":slot2", "");
                cmd3.Parameters.Add(":slot3", "");
                cmd3.Parameters.Add(":slot4", "");
                cmd3.Parameters.Add(":slot5", "");
                cmd3.Parameters.Add(":slot6", "");
                cmd3.Parameters.Add(":slot7", "");
                cmd3.Parameters.Add(":slot8", "");
                cmd3.Parameters.Add(":vaction", "");
                cmd3.BindByName = true;

                int added1 = 0;
                try
                {
                    incon2.Open();
                    added1 = cmd3.ExecuteNonQuery();
                    adderror.Text = "New services added";
                }
                catch (Exception err)
                {
                    bdreeor.Text = "Error inserting record. ";
                    bdreeor.Text += err.Message;
                }
                finally
                {
                    incon2.Close();
                }
            }
        }

    }


private string TO_DATE(System.DateTime day,char p)
{
 	throw new System.NotImplementedException();
}




    public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
    {
        for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
            yield return day;
    }
    private bool IsWeekend(DateTime date)
    {
        return (date.DayOfWeek == DayOfWeek.Saturday) ||
           (date.DayOfWeek == DayOfWeek.Sunday);
    }

    protected void logout(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("EmpLogin.aspx", true);
    }

}





