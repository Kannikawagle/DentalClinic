using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using Oracle.DataAccess.Client;
using System.Web.UI.HtmlControls;

public partial class ManageAppointment : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["MyOracle"].ConnectionString;
    string PatientId = null;
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
    private void Fillappointmnt()
    {
        display.DataSource = GetDataSet().Tables["Patient_info"];
        display.DataBind();
        Session["DataTable"] = display.DataSource;
    }
    private DataSet GetDataSet()
    {
        string selectSQL;
        selectSQL = "SELECT patient_info.patient_id, patient_info.pf_name, patient_info.pn_name, appointment.status, appointment.start_time,appointment.appointment_num, appointment.room,appointment_services.dentist_id FROM patient_info, appointment,appointment_services ";
        selectSQL += "where patient_info.patient_id = appointment.patient_id and appointment.appointment_num=appointment_services.appointment_num and start_time>=:appointbegin and start_time<=:appointend ";
        OracleConnection con = new OracleConnection(connectionString);
        OracleDataAdapter adapter = new OracleDataAdapter(selectSQL, con);
        adapter.SelectCommand.Parameters.Add(":appointbegin", Convert.ToDateTime(TextBox1.Text));
        adapter.SelectCommand.Parameters.Add(":appointend", Convert.ToDateTime(TextBox1.Text).AddDays(1));
        DataSet app = new DataSet();
        try
        {
            con.Open();
            adapter.Fill(app, "Patient_info");
            return app;
        }
        catch (Exception err)
        {
            dberror.Text = "Error reading list of orders. ";
            dberror.Text += err.Message;
            return null;
        }
    }
    protected void display_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string updateSQL;
        updateSQL = "UPDATE appointment set ";
        updateSQL += "status=:status ";
        updateSQL += " telephone= :status ";
        updateSQL += "WHERE start_time=:start_time  and patient_id =:patient_id ";

        OracleConnection con = new OracleConnection(connectionString);
        OracleCommand cmd = new OracleCommand(updateSQL, con);

        cmd.Parameters.Add(":status", e.NewValues[6].ToString());
        cmd.Parameters.Add(":start_time", Convert.ToDateTime(display.Rows[e.RowIndex].Cells[7].Text));
         cmd.Parameters.Add(":patient_id", display.Rows[e.RowIndex].Cells[2].Text);
        // Try to open database and execute the update.
        int updated = 0;
        try
        {
            con.Open();
            updated = cmd.ExecuteNonQuery();
          //  editresult.Text = updated.ToString() + " record updated.";
        }
        catch (Exception err)
        {
            dberror.Text = "Error updating author. ";
            dberror.Text += err.Message;
        }

        string updatetemproom;
     
        updatetemproom = "UPDATE temp_room set ";
        updatetemproom += "status=:status ";
        updatetemproom += " telephone= :status ";
        updatetemproom += "WHERE start_time=:start_time  and patient_id =:patient_id and room=:room";

     //   OracleConnection con = new OracleConnection(connectionString);
        OracleCommand cmdup = new OracleCommand(updatetemproom, con);

        cmdup.Parameters.Add(":status", e.NewValues[6].ToString());
        cmdup.Parameters.Add(":start_time", Convert.ToDateTime(display.Rows[e.RowIndex].Cells[7].Text));
         cmdup.Parameters.Add(":patient_id", display.Rows[e.RowIndex].Cells[2].Text);
        cmdup.Parameters.Add(":room", display.Rows[e.RowIndex].Cells[8].Text);
        // Try to open database and execute the update.
        int updated1 = 0;
        try
        {
            con.Open();
            updated1 = cmd.ExecuteNonQuery();
            //  editresult.Text = updated.ToString() + " record updated.";
        }
        catch (Exception err)
        {
            dberror.Text = "Error updating author. ";
            dberror.Text += err.Message;
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
        Fillappointmnt();
    }

    protected void display_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void display_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void display_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        String deleteSql = "delete from appointment where appointment_num='" + display.Rows[e.RowIndex].Cells[6].Text + "'";
        OracleConnection con = new OracleConnection(connectionString);
        OracleCommand cmd = new OracleCommand(deleteSql, con);
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            //  editresult.Text = updated.ToString() + " record updated.";
             DateTime appointmentDate = Convert.ToDateTime(display.Rows[e.RowIndex].Cells[5].Text);
        int apphour = appointmentDate.Hour;
        String slot=null;
        if (apphour == 8)
            slot = "slot1";
        if (apphour == 9)
            slot = "slot2";
        if (apphour == 10)
            slot = "slot3";
        if (apphour == 11)
            slot = "slot4";
        if (apphour == 12)
            slot = "slot5";
        if (apphour == 13)
            slot = "slot6";
        if (apphour == 14)
            slot = "slot7";
        if (apphour == 15)
            slot = "slot8";
        
        String updateDentistAppoint = "update TEMPDENTISTSLOT set " + slot + "=null ";
        updateDentistAppoint+="where dentist_id='"+display.Rows[e.RowIndex].Cells[8].Text+"'";
        updateDentistAppoint += "and appdate=:appdate";
        OracleCommand ucmd = new OracleCommand(updateDentistAppoint, con);
        ucmd.Parameters.Add(":appdate", appointmentDate.Date);
        ucmd.ExecuteNonQuery();
        String roomUpdate = "update TEMP_ROOM set " + slot + "=null ";
        roomUpdate += "where room_num=" + display.Rows[e.RowIndex].Cells[7].Text;
        roomUpdate += "and app_date=:appdate";
        OracleCommand roomcmd = new OracleCommand(roomUpdate, con);
        roomcmd.Parameters.Add(":appdate", appointmentDate.Date);
        roomcmd.ExecuteNonQuery();
        }
        catch (Exception err)
        {
            dberror.Text = "Error cancelling appointment ";
            dberror.Text += err.Message;
        }
        finally
        {
            con.Close();
        }

        Fillappointmnt();
        sucess.Text = ("Cancel appointment sucess");

    }
}