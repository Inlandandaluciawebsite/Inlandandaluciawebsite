using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HashSoftwares;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
public partial class GenerateLeads_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            binddate();
            if (drpdate.SelectedValue != "")
            {
                bindadmin();
            }
        }
    }

    private void binddate()
    {
        List<ListItem> items = new List<ListItem>();
        for (int i = -1; i > -6; i--)
        {
            items.Add(new ListItem(DateTime.Now.AddDays(i).ToShortDateString(), DateTime.Now.AddDays(i).ToShortDateString()));
        }
        drpdate.DataSource = items;
        drpdate.DataBind();

        ListItem licategory = new ListItem("Select Date", "");

        drpdate.Items.Insert(0, licategory);
        //drpdate.Items[2].Selected = true;
    }
    private void bindadmin()
    {
         SqlParameter[] sql = new SqlParameter[2];

         sql[0] = new SqlParameter("@Date", Convert.ToDateTime(drpdate.SelectedValue));
         sql[1] = new SqlParameter("@EmailProvider", drpemail.SelectedValue);

         DataTable dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["con"].ConnectionString, CommandType.StoredProcedure, "USP_tblFiveDayData_Select_By_Search_Different_Param", sql).Tables[0];
        if (dt.Rows.Count > 0)
        {
            grdAdmin.DataSource = dt;
            grdAdmin.DataBind();
            lblmessage.Visible = false;

        }
        else
        {
            grdAdmin.DataSource = dt;
            grdAdmin.DataBind();
            lblmessage.Visible = true;
           
        }
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        bindadmin();
    }
    protected void grdAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAdmin.PageIndex = e.NewPageIndex;
        bindadmin();
    }
    protected void grdAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "genlead")
        {
            

            SqlParameter[] sql = new SqlParameter[1];

            sql[0] = new SqlParameter("@DateId", id);

            DataTable dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["con"].ConnectionString, CommandType.StoredProcedure, "Usp_tblFiveDayData_selectById", sql).Tables[0];
            {

                ltconteactemail.Text = dt.Rows[0]["Email"].ToString();
                ltcosname.Text = dt.Rows[0]["CustomerName"].ToString();
                ltcity.Text = dt.Rows[0]["city"].ToString();
                ltstate.Text = dt.Rows[0]["state"].ToString();
                lttele.Text = dt.Rows[0]["MobileNumber"].ToString();
                hdndataid.Value = dt.Rows[0]["DateId"].ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            }
        }

        if (e.CommandName == "leadgen")
        {
            Response.Redirect("leadDetail.aspx?Id=" + id);
        
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {


        SqlParameter[] sql = new SqlParameter[7];

        sql[0] = new SqlParameter("@Date_Id", hdndataid.Value);
        sql[1] = new SqlParameter("@Email", ltconteactemail.Text);
        sql[2] = new SqlParameter("@CustomerName" ,ltcosname.Text);
        sql[3] = new SqlParameter("@city",ltcity.Text);
        sql[4] = new SqlParameter("@state", ltstate.Text);
        sql[5] = new SqlParameter("@MobileNumber",lttele.Text);
        sql[6] = new SqlParameter("@Message", txtmessage.Text);
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["con"].ConnectionString, CommandType.StoredProcedure, "usp_tblLeads_insert", sql);
        bindadmin();
        txtmessage.Text = "";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", " $('.modal-backdrop').css('display', 'none');", true);
         
    }
}