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

public partial class PopulateDate : System.Web.UI.Page
{
    string connectionString = WebConfigurationManager.ConnectionStrings["MyOracle"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
    }
   protected void DctGRIDVIEW_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        DateTime currentTime = DateTime.Now;
        DateTime endDate = DateTime.Today.AddDays(90);
        foreach (DateTime day in EachDay(currentTime, endDate))
        {
            if (IsWeekend(day))
            {
                String updateSQLweekend;

                updateSQLweekend = "INSERT INTO temp_room (";
                updateSQLweekend += "slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8, room_num, app_date ) ";
                updateSQLweekend += "VALUES (";
                updateSQLweekend += " :slot1,:slot2, :slot3, :slot4, :slot5, :slot6, :slot7, :slot8, :room_num, :app_date)";
                OracleConnection incon = new OracleConnection(connectionString);
                OracleCommand cmd2 = new OracleCommand(updateSQLweekend, incon);
                cmd2.Parameters.Add(":slot1", "w");
                cmd2.Parameters.Add(":slot2", "w");
                cmd2.Parameters.Add(":slot3", "w");
                cmd2.Parameters.Add(":slot4", "w");
                cmd2.Parameters.Add(":slot5", "w");
                cmd2.Parameters.Add(":slot6", "w");
                cmd2.Parameters.Add(":slot7", "w");
                cmd2.Parameters.Add(":slot8", "w");
                cmd2.Parameters.Add(":room_num", DctGRIDVIEW.SelectedRow.Cells[2].Text);
                cmd2.Parameters.Add(":app_date", Convert.ToDateTime(day.ToString()));
                

                cmd2.BindByName = true;

                int added1 = 0;
                try
                {
                    incon.Open();
                    added1 = cmd2.ExecuteNonQuery();
                    result.Text = "Inserted";
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
            else if (!IsWeekend(day))
            {
                String insertweekend;
                insertweekend = "INSERT INTO temp_room (";
                insertweekend += "slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8, room_num, app_date ) ";
                insertweekend += "VALUES (";
                insertweekend += " :slot1,:slot2, :slot3, :slot4, :slot5, :slot6, :slot7, :slot8, :room_num, :app_date)";
                 OracleConnection incon = new OracleConnection(connectionString);
                OracleCommand cmd2 = new OracleCommand(insertweekend, incon);

                cmd2.Parameters.Add(":slot1", "");
                cmd2.Parameters.Add(":slot2", "");
                cmd2.Parameters.Add(":slot3", "");
                cmd2.Parameters.Add(":slot4", "");
                cmd2.Parameters.Add(":slot5", "");
                cmd2.Parameters.Add(":slot6", "");
                cmd2.Parameters.Add(":slot7", "");
                cmd2.Parameters.Add(":slot8", "");
                cmd2.Parameters.Add(":room_num", (DctGRIDVIEW.SelectedRow.Cells[2].Text));
                cmd2.Parameters.Add(":app_date", Convert.ToDateTime(day.ToString()));
                
                cmd2.BindByName = true;

                cmd2.BindByName = true;

                int added1 = 0;
                try
                {
                    incon.Open();
                    added1 = cmd2.ExecuteNonQuery();
                    result.Text = "inserted";
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
}



