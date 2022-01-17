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

public partial class GenerateLeads_Lead : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindadmin();
        }
    }


    private void bindadmin()
    {
        DataTable dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["con"].ConnectionString, CommandType.StoredProcedure, "usp_tblLeads_showAll").Tables[0];
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
   
    protected void grdAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAdmin.PageIndex = e.NewPageIndex;
        bindadmin();
    }
    protected void grdAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "remove")
        {


            SqlParameter[] sql = new SqlParameter[1];

            sql[0] = new SqlParameter("@leadId", id);

            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["con"].ConnectionString, CommandType.StoredProcedure, "usp_tblLeads_deleteById", sql);
            bindadmin();
        }

        if (e.CommandName == "leadgen")
        {
            Response.Redirect("leadDetail.aspx?Id=" + id);

        }
    }
   
}