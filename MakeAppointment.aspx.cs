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

public partial class MakeAppointment : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["MyOracle"].ConnectionString;
    string pfname= null;
    string servId = null;
    string householdid = null;
    String pid = null;
    string slot1room= null;
    string slot2room =null;
    string slot3room =null;
    string slot4room =null;
    string slot5room =null;
    string slot6room =null;
    string slot7room =null;
    string slot8room =null;

    string s1doct= null;
    string s2doct= null;
    string s3doct= null;
    string s4doct= null;
    string s5doct= null;
    string s6doct= null;
    string s7doct= null;
    string s8doct= null;


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
        OracleConnection con = new OracleConnection(connectionString);// create new connection
        OracleCommand selcmd = new OracleCommand(SelectSQL, con); // open command with sql sttme aganist above connection
        OracleDataReader reader4 = null; // reader for result
        try
        {
            con.Open(); // open connection
            reader4 = selcmd.ExecuteReader(); // execute connmand
            reader4.Read();// reads result

            HtmlGenericControl li = new System.Web.UI.HtmlControls.HtmlGenericControl("li"); //create html li tag
            HtmlGenericControl a = new System.Web.UI.HtmlControls.HtmlGenericControl("a"); // create html a tag
            a.InnerText = "Welcome " + reader4["pf_name"]; //text 
            householdid = reader4["household_id"].ToString();
           pid = reader4["patient_id"].ToString();
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
            this.populateservices();
            
        }

        if (!IsPostBack)
        {
            this.populatedependends();
        }
    }
    protected void radID_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        if (checkbox.Checked)
        {
            ViewState[checkbox.UniqueID] = true;
        }
        else
        {
            ViewState.Remove(checkbox.UniqueID);
        }
    }
    protected void radID_DataBinding(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        checkbox.Checked = ViewState[checkbox.UniqueID] != null;
    }
    private void populatedependends()
    
{
    string selecthousehold;
     selecthousehold = "select pf_name,  patient_id FROM patient_info ";
    selecthousehold +="WHERE household_id = '" + householdid+ "'"; 
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

                        pid = reader["patient_id"].ToString();
                       
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



    private void populateservices()
    {
        using (OracleConnection conn = new OracleConnection())
        {
           

            {
                string selectsql;

                selectsql = "select service_name, service_id from services ";
                OracleConnection con = new OracleConnection(connectionString);
                OracleCommand cmd = new OracleCommand(selectsql, con);
                OracleDataReader reader;
                try
                {
                    con.Open();
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = reader["Service_name"].ToString();
                      item.Value = reader["Service_id"].ToString();

                        servId = reader["Service_id"].ToString();
                        servicesbox.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception err)
                {
                }
                finally
                {
                    con.Close();
                }
            }

        }
       
    }
     
    protected void submit_Click(object sender, EventArgs e)
    {
        string plsql = "GETAPPOINTMENTS";

        try
        {

            using (OracleConnection con = new OracleConnection(connectionString))
            {
                con.Open();

                OracleCommand cmd = new OracleCommand(plsql, con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
               // OracleParameter returnParameter = cmd.Parameters.Add("RetVal", OracleDbType.Varchar2);
              //   returnParameter.Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.Add("apdateselected_in", OracleDbType.Date).Value = Convert.ToDateTime(appdte.Text);
                cmd.Parameters.Add("s1", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s2", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s3", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s4", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s5", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s6", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s7", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s8", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("s1doc", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s2doc", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s3doc", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s4doc", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s5doc", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s6doc", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s7doc", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s8doc", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s1room", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;             
                cmd.Parameters.Add("s2room", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s3room", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s4room", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s5room", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;               
                cmd.Parameters.Add("s6room", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s7room", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("s8room", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                slot1room= Convert.ToString(cmd.Parameters["s1room"].Value);
                Session["slot1room"] = slot1room;
                slot2room= Convert.ToString(cmd.Parameters["s2room"].Value);
                Session["slot2room"] = slot2room;
                slot3room= Convert.ToString(cmd.Parameters["s3room"].Value);
                Session["slot3room"] = slot3room;
                slot4room= Convert.ToString(cmd.Parameters["s4room"].Value);
                Session["slot4room"] = slot4room;
                slot5room= Convert.ToString(cmd.Parameters["s5room"].Value);
                Session["slot5room"] = slot5room;
                slot6room= Convert.ToString(cmd.Parameters["s6room"].Value);
                Session["slot6room"] = slot6room;
                slot7room= Convert.ToString(cmd.Parameters["s7room"].Value);
                Session["slot7room"] = slot7room;
                slot8room= Convert.ToString(cmd.Parameters["s8room"].Value);
                Session["slot8room"] = slot8room;


                s1doct = Convert.ToString(cmd.Parameters["s1doc"].Value);
                Session["s1doct"] = s1doct;
                s2doct = Convert.ToString(cmd.Parameters["s2doc"].Value);
                Session["s2doct"] = s2doct;
                s3doct = Convert.ToString(cmd.Parameters["s3doc"].Value);
                Session["s3doct"] = s3doct;
                s4doct = Convert.ToString(cmd.Parameters["s4doc"].Value);
                Session["s4doct"] = s4doct;
                s5doct = Convert.ToString(cmd.Parameters["s5doc"].Value);
                Session["s5doct"] = s5doct;
                s6doct = Convert.ToString(cmd.Parameters["s6doc"].Value);
                Session["s6doct"] = s6doct;
                s7doct = Convert.ToString(cmd.Parameters["s7doc"].Value);
                Session["s7doct"] = s7doct;
                s8doct = Convert.ToString(cmd.Parameters["s8doc"].Value);
                Session["s8doct"] = s8doct;
               

                s1.InnerText=   Convert.ToString(cmd.Parameters["s1"].Value);
                if (s1.InnerText == null || Convert.ToString(cmd.Parameters["s1"].Value).Equals("Not Available"))
                {
                    s1.Attributes.Add("onclick", "javascript:return false;");
                    s1.Style.Add("background", "#b3b3b3");
                }
                else
                {
                    s1.Attributes.Add("onclick", "javascript:return true;");
                    s1.Style.Add("background", "#00e600");
                }
                s2.InnerText = Convert.ToString(cmd.Parameters["s2"].Value);
                if (s2.InnerText == null || Convert.ToString(cmd.Parameters["s2"].Value).Equals("Not Available"))
                {
                    s2.Attributes.Add("onclick", "javascript:return false;");
                    s2.Style.Add("background", "#b3b3b3");
                }
                else
                {
                    s2.Attributes.Add("onclick", "javascript:return true;");
                    s2.Style.Add("background", "#00e600");
                }
                s3.InnerText = Convert.ToString(cmd.Parameters["s3"].Value);
                if (s3.InnerText == null || Convert.ToString(cmd.Parameters["s3"].Value).Equals("Not Available"))
                {
                    s3.Attributes.Add("onclick", "javascript:return false;");
                    s3.Style.Add("background", "#b3b3b3");
                }
                else
                {
                    s3.Attributes.Add("onclick", "javascript:return true;");
                    s3.Style.Add("background", "#00e600");
                }
                s4.InnerText = Convert.ToString(cmd.Parameters["s4"].Value);
                if (s4.InnerText == null || Convert.ToString(cmd.Parameters["s4"].Value).Equals("Not Available"))
                {
                    s4.Attributes.Add("onclick", "javascript:return false;");
                    s4.Style.Add("background", "#b3b3b3");
                }
                else
                {
                    s4.Attributes.Add("onclick", "javascript:return true;");
                    s4.Style.Add("background", "#00e600");
                }
                s5.InnerText = Convert.ToString(cmd.Parameters["s5"].Value);
                if (s5.InnerText == null || Convert.ToString(cmd.Parameters["s5"].Value).Equals("Not Available"))
                {
                    s5.Attributes.Add("onclick", "javascript:return false;");
                    s5.Style.Add("background", "#b3b3b3");
                }
                else
                {
                    s5.Attributes.Add("onclick", "javascript:return true;");
                    s5.Style.Add("background", "#00e600");
                }
                s6.InnerText = Convert.ToString(cmd.Parameters["s6"].Value);
                if (s6.InnerText == null || Convert.ToString(cmd.Parameters["s6"].Value).Equals("Not Available"))
                {
                    s6.Attributes.Add("onclick", "javascript:return false;");
                    s6.Style.Add("background", "#b3b3b3");
                }
                else
                {
                    s6.Attributes.Add("onclick", "javascript:return true;");
                    s6.Style.Add("background", "#00e600");
                }
                s7.InnerText = Convert.ToString(cmd.Parameters["s7"].Value);
                if (s7.InnerText == null || Convert.ToString(cmd.Parameters["s7"].Value).Equals("Not Available"))
                {
                    s7.Attributes.Add("onclick", "javascript:return false;");
                    s7.Style.Add("background", "#b3b3b3");
                }
                else
                {
                    s7.Attributes.Add("onclick", "javascript:return true;");
                    s7.Style.Add("background", "#00e600");
                }
                s8.InnerText = Convert.ToString(cmd.Parameters["s8"].Value);
                if (s8.InnerText == null || Convert.ToString(cmd.Parameters["s8"].Value).Equals("Not Available"))
                {
                    s8.Attributes.Add("onclick", "javascript:return false;");
                    s8.Style.Add("background", "#b3b3b3");
                }
                else
                {
                    s8.Attributes.Add("onclick", "javascript:return true;");
                    s8.Style.Add("background", "#00e600");
                }
               

            }
        }


        catch (Exception se)
        {

            dberr.Text = ("error reading records");
            s1.InnerText = "Not Available";
               
            s1.Attributes.Add("onclick", "javascript:return false;");
            s2.Attributes.Add("onclick", "javascript:return false;");
            s3.Attributes.Add("onclick", "javascript:return false;");
            s4.Attributes.Add("onclick", "javascript:return false;");
            s5.Attributes.Add("onclick", "javascript:return false;");
            s6.Attributes.Add("onclick", "javascript:return false;");
            s7.Attributes.Add("onclick", "javascript:return false;");
            s8.Attributes.Add("onclick", "javascript:return false;");

        }
    }


    protected void ReserveAppointment(string selectedSlot, string Selecteddoct, string selectedroom, DateTime startdate, DateTime enddate)
    {
        string insertapp;
        insertapp = " insert into appointment ";
        insertapp += "(patient_id, appointment_num, status, room, start_time, end_time ) ";
        insertapp += "VALUES (";
        insertapp += ":patient_id, :appointment_num, :status, :room, :start_time, :end_time )";

        string selectSQL;
        OracleConnection incon = new OracleConnection(connectionString);
        OracleCommand cmd = new OracleCommand(insertapp, incon);
        incon.Open();
        //cmd.Connection = con;

        selectSQL = "SELECT appointment_seq.NEXTVAL appointment FROM DUAL";
        OracleCommand selcmdorder_id = new OracleCommand(selectSQL, incon);
        int appointmentNum;
        appointmentNum = Int16.Parse(selcmdorder_id.ExecuteScalar().ToString());

        cmd.Parameters.Add(":patient_id", householdbox.SelectedItem.Value);
        cmd.Parameters.Add(":appointment_num", appointmentNum);
        cmd.Parameters.Add(":status", "Yes");
        cmd.Parameters.Add(":room", selectedroom);
        cmd.Parameters.Add(":start_time", startdate);
        cmd.Parameters.Add(":end_time", enddate);
        int added1 = 0;

        try
        {
            added1 = cmd.ExecuteNonQuery();
            insertResult.Text = ("Account created sucessfully");

        }

        catch (Exception err)
        {
            dberror.Text = "Error inserting record. ";
            dberror.Text += err.Message;
        }

        string insertappser;

        foreach (ListItem item in servicesbox.Items)
        {
            if (item.Selected)
            {
                insertappser = " insert into appointment_services ";
                insertappser += "(appointment_num, service_id, dentist_id, service_start_time, service_end_time ) ";
                insertappser += "VALUES (";
                insertappser += ":appointment_num, :service_id, :dentist_id, :service_start_time, :service_end_time) ";

                OracleCommand cmd1 = new OracleCommand(insertappser, incon);
                //   incon.Open();

                cmd1.Parameters.Add(":appointment_num", appointmentNum);
                cmd1.Parameters.Add(":service_id", item.Value);
                cmd1.Parameters.Add(":dentist_id", Selecteddoct);
                cmd1.Parameters.Add(":service_start_time", startdate);
                cmd1.Parameters.Add(":service_end_time", enddate);

                int added2 = 0;

                try
                {
                    added2 = cmd1.ExecuteNonQuery();
               //     insertResult.Text = ("Account created sucessfully");

                }

                catch (Exception err)
                {
                    dberror.Text = "Error inserting record. ";
                    dberror.Text += err.Message;
                }
            }
        }

                string updatetemdentist;
                updatetemdentist = "UPDATE tempdentistslot set ";
                updatetemdentist += selectedSlot;
                updatetemdentist += "= 'Not Available' ";
                updatetemdentist += "WHERE appdate= :appdate and dentist_id=:dentist_id ";

                OracleCommand cmd2 = new OracleCommand(updatetemdentist, incon);
                cmd2.Parameters.Add(":appdate", Convert.ToDateTime(appdte.Text));
                cmd2.Parameters.Add(":dentist_id", Selecteddoct);

                //    incon.Open();

                int added3 = 0;

                try
                {
                    added3 = cmd2.ExecuteNonQuery();
                //    insertResult.Text = ("Account created sucessfully");

                }

                catch (Exception err)
                {
                    dberror.Text = "Error inserting record. ";
                    dberror.Text += err.Message;
                }

                string updatetemp;
                updatetemp = "UPDATE temp_room set ";
                updatetemp += selectedSlot;
                updatetemp += "= 'Not Available' ";
                updatetemp += "WHERE app_date= :app_date and room_num=:room_num ";

                OracleCommand cmd3 = new OracleCommand(updatetemp, incon);
                //   incon.Open();

                cmd3.Parameters.Add(":app_date", Convert.ToDateTime(appdte.Text));
                cmd3.Parameters.Add(":room_num", selectedroom);

                int added4 = 0;

                try
                {
                    added4 = cmd3.ExecuteNonQuery();
                   // insertResult.Text = ("Account created sucessfully");

                }

                catch (Exception err)
                {
                    dberror.Text = "Error inserting record. ";
                    dberror.Text += err.Message;
                }
                Response.Redirect("ConfirmationPage.aspx");
            }
        


    protected void click_s1(object sender, EventArgs e)
    {
        
        DateTime sdate = Convert.ToDateTime(appdte.Text).AddHours(+8);
       DateTime Eddate = sdate.AddHours(+1);
       slot1room = (String) Session["slot1room"];
       s1doct = (String)Session["s1doct"];
        ReserveAppointment("slot1", s1doct, slot1room, sdate, Eddate);
    }

   

    

    protected void click_s2(object sender, EventArgs e)
    {
        DateTime sdate = Convert.ToDateTime(appdte.Text).AddHours(+9);
        DateTime Eddate = sdate.AddHours(+1);
        slot2room = (String)Session["slot2room"];
        s2doct = (String)Session["s2doct"];
             ReserveAppointment("slot2", s2doct, slot2room, sdate, Eddate);
    }
    protected void click_s3(object sender, EventArgs e)
    {
        DateTime sdate = Convert.ToDateTime(appdte.Text).AddHours(+10);
        DateTime Eddate = sdate.AddHours(+1);
        slot3room = (String)Session["slot3room"];
        s3doct = (String)Session["s3doct"];
        ReserveAppointment("slot3", s3doct, slot3room, sdate, Eddate);
    }
    protected void click_s4(object sender, EventArgs e)
    {
        DateTime sdate = Convert.ToDateTime(appdte.Text).AddHours(+11);
        DateTime Eddate = sdate.AddHours(+1);
        slot4room = (String)Session["slot4room"];
        s4doct = (String)Session["s4doct"];
        ReserveAppointment("slot4", s4doct, slot4room, sdate, Eddate);
    }
    protected void click_s5(object sender, EventArgs e)
    {
        DateTime sdate = Convert.ToDateTime(appdte.Text).AddHours(+12);
        DateTime Eddate = sdate.AddHours(+1);
        slot5room = (String)Session["slot5room"];
        s5doct = (String)Session["s5doct"];
        ReserveAppointment("slot5", s5doct, slot5room, sdate, Eddate);
    }
    protected void click_s6(object sender, EventArgs e)
    {
        DateTime sdate = Convert.ToDateTime(appdte.Text).AddHours(+13);
        DateTime Eddate = sdate.AddHours(+1);
        slot6room = (String)Session["slot6room"];
        s6doct = (String)Session["s6doct"];
        ReserveAppointment("slot6", s6doct, slot6room, sdate, Eddate);
    }
    protected void click_s7(object sender, EventArgs e)
    {
        DateTime sdate = Convert.ToDateTime(appdte.Text).AddHours(+14);
        DateTime Eddate = sdate.AddHours(-1);
        slot7room = (String)Session["slot7room"];
        s7doct = (String)Session["s7doct"];
        ReserveAppointment("slot7", s7doct, slot7room, sdate, Eddate);
    }
    protected void click_s8(object sender, EventArgs e)
    {
        DateTime sdate = Convert.ToDateTime(appdte.Text).AddHours(+15);
        DateTime Eddate = sdate.AddHours(-1);
        slot8room = (String)Session["slot8room"];
        s8doct = (String)Session["s8doct"];
        ReserveAppointment("slot88", s8doct, slot8room, sdate, Eddate);
    }
    protected void logout(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Patientlogin.aspx", true);
    }

    protected void next_Click(object sender, EventArgs e)
    {
        appdte.Text = Convert.ToDateTime(appdte.Text).AddDays(1).ToString();
        submit_Click(sender, e);
    }
    protected void Previous_Click(object sender, EventArgs e)
    {
        appdte.Text = Convert.ToDateTime(appdte.Text).AddDays(-1).ToString();
        submit_Click(sender, e);
    }
}

    
    

