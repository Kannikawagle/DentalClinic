using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using Oracle.DataAccess.Client;
using System.Web.UI.HtmlControls;

public partial class CreateInvoice : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["MyOracle"].ConnectionString;

   
   // string insuranceid= null;
    string patientid = null;
    int invoiceId;
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
        //finally
        //{
        //    con.Close();

        //}

       
       

        string selectinfo;

  selectinfo="select patient_info.Pf_name,  appointment.patient_id ";
 selectinfo += " from appointment ,   patient_info  where ";
 selectinfo += "appointment.PATIENT_ID=patient_info.PATIENT_ID ";
selectinfo += " and APPOINTMENT_NUM= :appointment_num ";

        string selectSQL;
     //   OracleConnection inconpat = new OracleConnection(connectionString); // create new connection
        OracleCommand selcmd1 = new OracleCommand(selectinfo, con); // open command with sql sttme aganist above connection
        OracleDataReader reader1 = null; // reader for result

       // con.Open();

       
        selectSQL = "SELECT invoice_seq.NEXTVAL invoice_number FROM DUAL";
        OracleCommand selcmdorder_id = new OracleCommand(selectSQL, con);
             
        
        invoiceId = Int16.Parse(selcmdorder_id.ExecuteScalar().ToString());
        selcmd1.Parameters.Add(":appointment_num", Request.QueryString["appnum"].ToString());


        try
        {
         //   con.Open(); // open connection
            reader1 = selcmd1.ExecuteReader(); // execute connmand
            reader1.Read();// reads result
            pn.Text = reader1["pf_name"].ToString();
            pid.Text = reader1["patient_id"].ToString();
           appnum.Text=Request.QueryString["appnum"].ToString();
           inonum.Text = invoiceId.ToString();
            todate.Text = DateTime.Now.ToString("MM/dd/yyyy h:mmtt");
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
        if (!this.IsPostBack)
        {
            FillInvoice();
        }
    }
    private void FillInvoice()
    {
        invoice1.DataSource = GetDataSet().Tables["appointment_services"];
        invoice1.DataBind();
        Session["DataTable"] = invoice1.DataSource;
    }
    private DataSet GetDataSet()
    {
        String selectinvoice;
               
        selectinvoice = "select services.service_name,  services.service_cost, services.SERVICE_COST*.75 as Insucover, services.SERVICE_COST*.25 as youowe "; 
        selectinvoice+= "from appointment , appointment_services,  services  where appointment_services.APPOINTMENT_NUM=appointment.APPOINTMENT_NUM ";
        selectinvoice += "and appointment_services.service_id=services.service_id and appointment.APPOINTMENT_NUM=" + Request.QueryString["appnum"].ToString();



        OracleConnection con = new OracleConnection(connectionString);
        OracleDataAdapter adapter = new OracleDataAdapter(selectinvoice, con);
        OracleCommand selchkcmd = new OracleCommand(selectinvoice, con);
       // selchkcmd.Parameters.Add(":appointment_num", Request.QueryString["appnum"].ToString());
        selchkcmd.BindByName = true;

        DataSet app = new DataSet();
        try
        {
            //int sum = 0;
            adapter.Fill(app, "appointment_services");
            return app;
        }
        catch (Exception err)
        {
            dberror.Text = "Error reading list of orders. ";
            dberror.Text += err.Message;
            return null;
        }
        finally
        {
            con.Close();
        }
    }

    protected void crtinvoice_Click(object sender, EventArgs e)
     {
        String insertinvoice;

        insertinvoice = " insert into invoice ";
        insertinvoice += "(Invoice_number, appointment_num,patient_id, patient_name, price_paid, invoice_date) ";
        insertinvoice += "values (:Invoice_number, :appointment_num, :patient_id, :patient_name, :price_paid, :invoice_date) ";

        OracleConnection incon = new OracleConnection(connectionString);
        OracleCommand cmdinsert = new OracleCommand(insertinvoice, incon);
        incon.Open();

        cmdinsert.Parameters.Add(":Invoice_number", invoiceId);
        cmdinsert.Parameters.Add(":appointment_num", Request.QueryString["appnum"].ToString());
        cmdinsert.Parameters.Add(":patient_id", pid.Text);
        cmdinsert.Parameters.Add(":patient_name", pn.Text);
        cmdinsert.Parameters.Add(":price_paid", "100");
        cmdinsert.Parameters.Add(":invoice_date", Convert.ToDateTime(todate.Text));
        int added1 = 0;

        try
        {
            added1 = cmdinsert.ExecuteNonQuery();
           insertResult.Text = ("created sucessfully");

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





    protected void logout(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("EmpLogin.aspx", true);
    }


}

