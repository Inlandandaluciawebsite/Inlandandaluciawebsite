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

public partial class Admin_ManageCompanies : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            bindCompany();
        }
    }
    private void bindCompany()
    {
        DataTable dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_Companies_Select_All").Tables[0];
        if (dt.Rows.Count > 0)
        {
            grdCompany.DataSource = dt;
            grdCompany.DataBind();

        }
        else
        {
            grdCompany.DataSource = dt;
            grdCompany.DataBind();
        }
    }
    protected void grdCompany_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "changestatus")
        {
            GridViewRow grow = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
            ImageButton img = e.CommandSource as ImageButton;
            GridViewRow gvRow = img.Parent.Parent as GridViewRow;
            int id = int.Parse(e.CommandArgument.ToString());
            ImageButton imgStatus = (ImageButton)grdCompany.Rows[gvRow.RowIndex].FindControl("imgBtnStatus");
            SqlParameter[] sql = new SqlParameter[2];
            if (imgStatus.ImageUrl.Contains("crosss.png"))
            {
                sql[0] = new SqlParameter("@id", id);
                sql[1] = new SqlParameter("@IsPunchCard", true);
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_Companies_Update_Status", sql);
                bindCompany();
            }
            else
            {
                sql[0] = new SqlParameter("@id", id);
                sql[1] = new SqlParameter("IsPunchCard", false);
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_Companies_Update_Status", sql);
                bindCompany();
            }
        }
    }
    protected void grdCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdCompany.PageIndex = e.NewPageIndex;
        bindCompany();
    }
}