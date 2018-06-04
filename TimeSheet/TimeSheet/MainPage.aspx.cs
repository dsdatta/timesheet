using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using DevExpress.Web;

namespace TimeSheet
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["name"] == null) Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {

                Label1.Visible = false;
                var grid = BLL.Login.Employeeid(Session["name"].ToString());
                timeSheetGrid.DataSource = BLL.Login.DatePick(grid.ToString(), DateTime.Now.Date.ToShortDateString());
                timeSheetGrid.DataBind();
                dtpTimeSheet.Date = DateTime.Now.Date;
                dtpTimeSheet.MaxDate = DateTime.Now.Date;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void timeSheetGrid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
            ASPxGridView grid = (ASPxGridView)sender;
            string id = e.Keys["TaskId"].ToString();


        
            BLL.Login.DeleteTask(id);
       

            var gridv = BLL.Login.Employeeid(Session["name"].ToString());
            timeSheetGrid.DataSource = BLL.Login.Gridsheet(gridv.ToString(), dtpTimeSheet.Date.ToShortDateString());
            timeSheetGrid.DataBind();

        }

        protected void timeSheetGrid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string date = e.NewValues[0].ToString();
            var datevalue = DateTime.ParseExact(date, "dd/MM/yyyy", null).ToString("yyy-MM-dd");

        
            string id = e.NewValues[3].ToString();
            string ftime = e.NewValues[1].ToString();
            DateTime fromt = DateTime.Parse(ftime);
            string fromtime = fromt.ToShortTimeString();

            string ttime = e.NewValues[2].ToString();
            DateTime tot = DateTime.Parse(ttime);
            string toTime = tot.ToShortTimeString();



            string description = e.NewValues[4].ToString();
    
            BLL.Login.UpdateTask(id, fromtime, toTime, description);
          
            var gridv = BLL.Login.Employeeid(Session["name"].ToString());
            timeSheetGrid.DataSource = BLL.Login.Gridsheet(gridv.ToString(), datevalue.ToString());
            timeSheetGrid.DataBind();

            timeSheetGrid.CancelEdit();
            e.Cancel = true;

        }

        protected void dtpTimeSheet_DateChanged(object sender, EventArgs e)
        {
            
            var empId = BLL.Login.Employeeid(Session["name"].ToString());
            timeSheetGrid.DataSource = BLL.Login.DatePick(empId.ToString(), dtpTimeSheet.Date.ToShortDateString());
            timeSheetGrid.DataBind();
        }

        protected void addTask_Click(object sender, EventArgs e)
        {
            if (ASPxTextBox5.Text != null && ASPxTimeEdit1.Text != "" && ASPxTimeEdit2.Text != "" && ASPxTextBox5.Text != "")
            {
                var emplyeeid = BLL.Login.Employeeid(Session["name"].ToString());
                if (ASPxTimeEdit2.DateTime < ASPxTimeEdit1.DateTime)
                {
                    Label1.Visible = true;
                    Label1.Text = "Enter  correct time";
                    Label1.ForeColor = System.Drawing.Color.Red;
                   
                }
                else
                {
                    Label1.Visible = false;
                   
                    var user = BLL.Login.AddTask(ASPxTimeEdit1.Text, ASPxTimeEdit2.Text, ASPxTextBox5.Text, emplyeeid.ToString(),dtpTimeSheet.Date.ToShortDateString());                  
                    timeSheetGrid.DataSource = BLL.Login.Gridsheet(emplyeeid.ToString(),dtpTimeSheet.Date.ToShortDateString());
                    timeSheetGrid.DataBind();                 
                    ASPxTextBox5.Text = "";
                    ASPxTimeEdit1.Text = "";
                    ASPxTimeEdit2.Text = "";

                   
                  
                }

            }
            
        }

        protected void logOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void timeSheetGrid_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            if (e.NewValues[1] != null && e.NewValues[2] != null && e.NewValues[4] != null)
            {
                string toTime = e.NewValues[2].ToString();
                DateTime tot = DateTime.Parse(toTime);
                var totimeonly = tot - tot.Date;

                string ftime = e.NewValues[1].ToString();
                DateTime fromt = DateTime.Parse(ftime);
                var fromtimeonly = fromt - fromt.Date;
                if (totimeonly < fromtimeonly)
                {
                    AddError(e.Errors, timeSheetGrid.Columns["ToTime"], "Enter correct time");
                }
            }
            else
            {
                AddError(e.Errors, timeSheetGrid.Columns["Description"], "Fields cannot be blank ");
            }

            

       
    }

        private void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn gridViewColumn, string v)
        {
            if (errors.ContainsKey(gridViewColumn)) return;
            errors[gridViewColumn] = v;
        }
    }
}