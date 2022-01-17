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

public partial class Admin_ManageAdmins : System.Web.UI.Page
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
        DataTable dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_tblAdmin_Select_All").Tables[0];
        if (dt.Rows.Count > 0)
        {
            grdAdmin.DataSource = dt;
            grdAdmin.DataBind();
            BtnDelete.Visible = true;
            lblmessage.Visible = false;

        }
        else
        {
            grdAdmin.DataSource = dt;
            grdAdmin.DataBind();
            BtnDelete.Visible = false;
            lblmessage.Visible = true;
        }
    }
    protected void grdAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "editadmin")
        {
            Response.Redirect("AddAdmin.aspx?AdminID=" + e.CommandArgument.ToString());
        }
        if (e.CommandName.ToString() == "changestatus")
        {
            GridViewRow grow = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
            ImageButton img = e.CommandSource as ImageButton;
            GridViewRow gvRow = img.Parent.Parent as GridViewRow;
            int id = int.Parse(e.CommandArgument.ToString());
            ImageButton imgStatus = (ImageButton)grdAdmin.Rows[gvRow.RowIndex].FindControl("imgBtnStatus");
            SqlParameter[] sql = new SqlParameter[2];
            if (imgStatus.ImageUrl.Contains("crosss.png"))
            {
                sql[0] = new SqlParameter("@AdminID", id);
                sql[1] = new SqlParameter("@IsActive", true);
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_tblAdmin_Update_Status", sql);
                bindadmin();
            }
            else
            {
                sql[0] = new SqlParameter("@AdminID", id);
                sql[1] = new SqlParameter("IsActive", false);
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_tblAdmin_Update_Status", sql);
                bindadmin();
            }
        }
    }
    protected void grdAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAdmin.PageIndex = e.NewPageIndex;
        bindadmin();
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        Int32 ID;
        for (Int32 i = 0; i < grdAdmin.Rows.Count; i++)
        {
            CheckBox chkClient = (CheckBox)grdAdmin.Rows[i].FindControl("chkSelect");
            if (chkClient.Checked != true)
            {
            }
            else
            {
                if (Convert.ToInt32(Session["AdminID"]) != Convert.ToInt32(grdAdmin.DataKeys[i][0]))
                {
                    ID = Convert.ToInt32(grdAdmin.DataKeys[i][0]);
                    SqlParameter[] sql = new SqlParameter[1];
                    sql[0] = new SqlParameter("@AdminID", ID);
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_tblAdmin_Delete_By_Id", sql);                
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", "alert('Record has been removed sucessfully  !');", true);
                }
            }
        }
        bindadmin();
    }
}