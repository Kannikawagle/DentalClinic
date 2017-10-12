
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using Oracle.DataAccess.Client;


public partial class CreateAcc : System.Web.UI.Page
{

    string connectionString = WebConfigurationManager.ConnectionStrings["MyOracle"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        //fname.Enabled = false;
        //lname.Enabled = false;
        //email.Enabled = false;
        //pswd.Enabled = false;
        //tphone.Enabled = false;
        //dob.Enabled = false;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (bi.SelectedItem.Text == "Yes")
        {
            string inserthousehold;

            inserthousehold = "INSERT INTO house_hold (";
            inserthousehold += "household_id, house_h_name, lname, address) ";
            inserthousehold += "VALUES (";
            inserthousehold += ":household_id, :house_h_name, :lname, :address )";


            string selectSQLhouse;
            OracleConnection incon = new OracleConnection(connectionString);
            OracleCommand cmdhouse = new OracleCommand(inserthousehold, incon);
            incon.Open();


            selectSQLhouse = "SELECT household_seq.NEXTVAL household_id FROM DUAL";
            OracleCommand selcmdorder_hid = new OracleCommand(selectSQLhouse, incon);
            cmdhouse.CommandType = CommandType.Text;
            int house_hold_id;
            house_hold_id = Int16.Parse(selcmdorder_hid.ExecuteScalar().ToString());


          //  OracleCommand cmdhouse = new OracleCommand(inserthousehold, incon);

            cmdhouse.Parameters.Add(":household_id", house_hold_id);
            cmdhouse.Parameters.Add(":house_h_name", fname.Text);
            cmdhouse.Parameters.Add(":lname", lname.Text);
            cmdhouse.Parameters.Add(":address", add.Text);

            int added2 = 0;

            try
            {
                added2 = cmdhouse.ExecuteNonQuery();
                // insertResult.Text = ("Account created sucessfully");

            }

            catch (Exception err)
            {
                bderr.Text = "Error inserting record. ";
                bderr.Text += err.Message;
            }

            finally
            {
                incon.Close();
            }
            
            string INSERTSQLACC;
                INSERTSQLACC = "INSERT INTO patient_info (";
                INSERTSQLACC += "pf_name, pn_name, patient_id, emai_id, patient_password, telephone, DOB, household_id, address, security_ans ) ";
                INSERTSQLACC += "VALUES (";
                INSERTSQLACC += ":pf_name, :pn_name, :patient_id, :emai_id, :patient_password,  :telephone, :DOB, :household_id, :address, :security_ans)";

            

            string selectSQL;
            OracleConnection inconpat = new OracleConnection(connectionString);
            OracleCommand cmd = new OracleCommand(INSERTSQLACC, inconpat);
            inconpat.Open();
            //cmd.Connection = con;

            selectSQL = "SELECT Patient_seq.NEXTVAL ORDER_ID FROM DUAL";
            OracleCommand selcmdorder_id = new OracleCommand(selectSQL, inconpat);
            int patients_id;
            patients_id = Int16.Parse(selcmdorder_id.ExecuteScalar().ToString());


            cmd.Parameters.Add(":pf_name", fname.Text);
            cmd.Parameters.Add(":pn_name", lname.Text);
            cmd.Parameters.Add(":patient_id", patients_id);
            cmd.Parameters.Add(":emai_id", email.Text);
            cmd.Parameters.Add(":patient_password", pswd.Text);
            cmd.Parameters.Add(":telephone", tphone.Text);
            cmd.Parameters.Add(":DOB", Convert.ToDateTime(dob.Text));
            cmd.Parameters.Add(":household_id", house_hold_id);
            cmd.Parameters.Add(":address", add.Text);
          cmd.Parameters.Add(":security_ans", ques.Text);
                  
                        int added1 = 0;

            try
            {
                added1 = cmd.ExecuteNonQuery();
                insertResult.Text = ("Account created sucessfully");
                //fname.Text = string.Empty;
                //lname.Text = string.Empty;
                //email.Text = string.Empty; 
                //pswd.Text = string.Empty;
                //tphone.Text = string.Empty;
                //add.Text = string.Empty;
                //ques.Text = string.Empty;

            }

            catch (Exception err)
            {
                bderr.Text = "Error inserting record. ";
                bderr.Text += err.Message;
            }

            finally
            {
                inconpat.Close();
            }
            
        }
        if (bi.SelectedItem.Text == "No")
        {
            DateTime birth = Convert.ToDateTime(dob.Text);

            string selectcheck;
            selectcheck = " select pf_name, pn_name, dob ";
            selectcheck += " from patient_info ";
            selectcheck += "WHERE dob = :birth";

            

            OracleConnection concheck = new OracleConnection(connectionString);
            OracleCommand selchkcmd = new OracleCommand(selectcheck, concheck);
            selchkcmd.Parameters.Add(":birth", birth);
            concheck.Open();
            OracleDataReader readerchk;
            try
            {
                readerchk = selchkcmd.ExecuteReader();
                readerchk.Read();
                if (readerchk.HasRows)
                {
                    string updatepat;


                    updatepat = "update patient_info set ";
                    updatepat += "  emai_id = :emai_id, patient_password =:patient_password ";
                    updatepat += "WHERE pf_name=:pf_name and pn_name=:pn_name and dob=:dob";

                    OracleConnection con = new OracleConnection(connectionString);
                    OracleCommand cmd = new OracleCommand(updatepat, con);

                    // Add the parameters.        
                    //cmd.Parameters.Add(":patient_id", patients_id);
                    cmd.Parameters.Add(":emai_id", email.Text);
                    cmd.Parameters.Add(":patient_password", pswd.Text);
                    cmd.Parameters.Add(":pf_name", fname.Text);
                    cmd.Parameters.Add(":pn_name", lname.Text);
                    cmd.Parameters.Add(":dob", Convert.ToDateTime(dob.Text));


                    // Try to open database and execute the update.
                    int updated = 0;
                    try
                    {
                        con.Open();
                        updated = cmd.ExecuteNonQuery();
                        updateerror.Text = updated.ToString() + " record updated.";
                    }
                    catch (Exception err)
                    {
                        errormsg.Text = "Error updating author. ";
                        errormsg.Text += err.Message;
                    }
                    finally
                    {
                        con.Close();
                    }


                    if (!readerchk.HasRows)
                    {
                        inserterrormsg.Text = ("Account already exist");
                    }

                }
            }


            catch (Exception err)
            {
                errormsg.Text = "Error getting info. ";
                errormsg.Text += err.Message;
            }
            finally
            {
                concheck.Close();
            }
       
    }
    
        {
        
         Response.Redirect("LoginSucessful.aspx"); 
        }
    }
   
private string TO_DATE(char p1,char p2)
{
 	throw new NotImplementedException();
}

    
    


  
    }



    

    
    


        
        
    

 


    


        
    


        
    

