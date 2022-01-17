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
            bindNotification();
        }
    }
    private void bindNotification()
    {
        DataTable dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_Notifications_Select_All").Tables[0];
        if (dt.Rows.Count > 0)
        {
            grdNotification.DataSource = dt;
            grdNotification.DataBind();
            BtnDelete.Visible = true;
            lblmessage.Visible = false;

        }
        else
        {
            grdNotification.DataSource = dt;
            grdNotification.DataBind();
            BtnDelete.Visible = false;
            lblmessage.Visible = true;
        }
    }
    protected void grdNotification_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "editadmin")
        {
            Response.Redirect("AddNotification.aspx?NID=" + e.CommandArgument.ToString());
        }
        if (e.CommandName.ToString() == "changestatus")
        {
            GridViewRow grow = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
            ImageButton img = e.CommandSource as ImageButton;
            GridViewRow gvRow = img.Parent.Parent as GridViewRow;
            int id = int.Parse(e.CommandArgument.ToString());
            ImageButton imgStatus = (ImageButton)grdNotification.Rows[gvRow.RowIndex].FindControl("imgBtnStatus");
            SqlParameter[] sql = new SqlParameter[2];
            if (imgStatus.ImageUrl.Contains("crosss.png"))
            {
                sql[0] = new SqlParameter("@IsDismissed", "0");
                sql[1] = new SqlParameter("@NotificationID", id);
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_Notifications_Dismiss_Status", sql);
                bindNotification();
            }
            else
            {
                sql[0] = new SqlParameter("@IsDismissed", "1");
                sql[1] = new SqlParameter("@NotificationID", id);
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_Notifications_Dismiss_Status", sql);
                bindNotification();
            }
        }
    }
    protected void grdNotification_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdNotification.PageIndex = e.NewPageIndex;
        bindNotification();
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        Int32 ID;
        for (Int32 i = 0; i < grdNotification.Rows.Count; i++)
        {
            CheckBox chkClient = (CheckBox)grdNotification.Rows[i].FindControl("chkSelect");
            if (chkClient.Checked != true)
            {
            }
            else
            {

                    ID = Convert.ToInt32(grdNotification.DataKeys[i][0]);
                    SqlParameter[] sql = new SqlParameter[1];
                    sql[0] = new SqlParameter("@NotificationID", ID);
                    SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_Notifications_Delete_By_Id", sql);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", "alert('Record has been removed sucessfully  !');", true);
            }
        }
        bindNotification();
    }
}