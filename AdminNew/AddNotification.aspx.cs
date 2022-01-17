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

public partial class Admin_AddAdmin : System.Web.UI.Page
{
    static Int32 id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindPartner();
            bindCompany();
            bindNotiFicationType();
            if (Request.QueryString.HasKeys())
            {
                id = Convert.ToInt32(Request.QueryString[0]);
                SqlParameter[] sql = new SqlParameter[1];
                sql[0] = new SqlParameter("@NotificationID", id);
                DataTable dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_Notification_Seelct_By_ID", sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    btnUpdate.Style.Add(HtmlTextWriterStyle.Display, "block");
                    btnSubmit.Style.Add(HtmlTextWriterStyle.Display, "none");
                    btnCancel.Style.Add(HtmlTextWriterStyle.Display, "none");
                    drpCompany.Items[drpCompany.Items.IndexOf(drpCompany.Items.FindByValue(dt.Rows[0]["fkCompanyID"].ToString()))].Selected = true;
                    if (drpCompany.SelectedValue != "0")
                        divCompany.Visible = true;

                    else
                        divCompany.Visible = false;
                    drpPartner.Items[drpPartner.Items.IndexOf(drpPartner.Items.FindByValue(dt.Rows[0]["fkPartnerID"].ToString()))].Selected = true;
                    if (drpPartner.SelectedValue != "0")
                        divPartner.Visible = true;
                    else
                        divPartner.Visible = false;
                    drpNotification.Items[drpNotification.Items.IndexOf(drpNotification.Items.FindByValue(dt.Rows[0]["fkNotificationType"].ToString()))].Selected = true;
                    txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                }
            }
        }
    }
    private void bindCompany()
    {
        DataTable dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_Companies_Select_All").Tables[0];
        if (dt.Rows.Count > 0)
        {
            drpCompany.DataSource = dt;
            drpCompany.DataTextField = "CompanyName";
            drpCompany.DataValueField = "id";
            drpCompany.DataBind();
            ListItem licategory1 = new ListItem("Select Company", "0");
            drpCompany.Items.Insert(0, licategory1);

        }
    }
    private void bindPartner()
    {
        DataTable dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_Partner_Select").Tables[0];
        if (dt.Rows.Count > 0)
        {


            drpPartner.DataSource = dt;
            drpPartner.DataTextField = "FirstName";
            drpPartner.DataValueField = "PartnerId";
            drpPartner.DataBind();
            ListItem licategory = new ListItem("Select Partner", "0");
            drpPartner.Items.Insert(0, licategory);

        }
    }
    private void bindNotiFicationType()
    {
        DataTable dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_NotificationTypes_Select").Tables[0];
        if (dt.Rows.Count > 0)
        {


            drpNotification.DataSource = dt;
            drpNotification.DataTextField = "Description";
            drpNotification.DataValueField = "NotificationTypeID";
            drpNotification.DataBind();
            ListItem licategory2 = new ListItem("Select Notification Type", "0");
            drpNotification.Items.Insert(0, licategory2);

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        SqlParameter[] sql = new SqlParameter[4];
        sql[0] = new SqlParameter("@Description", txtDescription.Text);
        sql[1] = new SqlParameter("@fkCompanyID", drpCompany.SelectedValue);
        sql[2] = new SqlParameter("@fkPartnerID", drpPartner.SelectedValue);
        sql[3] = new SqlParameter("@fkNotificationType", drpNotification.SelectedValue);
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_Notification_Insert", sql).ToString();
        Response.Redirect("ManageNotifications.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlParameter[] sql = new SqlParameter[5];
        sql[0] = new SqlParameter("@Description", txtDescription.Text);
        sql[1] = new SqlParameter("@fkCompanyID", drpCompany.SelectedValue);
        sql[2] = new SqlParameter("@fkPartnerID", drpPartner.SelectedValue);
        sql[3] = new SqlParameter("@fkNotificationType", drpNotification.SelectedValue);
        sql[4] = new SqlParameter("@NotificationID", id);
        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_Notification_Update", sql).ToString();
        Response.Redirect("ManageNotifications.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddNotification.aspx");
    }
    protected void drpNotification_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpNotification.SelectedValue == "1")
        {
            divCompany.Visible = false;
            divPartner.Visible = false;
        }
        else if (drpNotification.SelectedValue == "2")
        {
            divCompany.Visible = true;
            divPartner.Visible = false;
        }
        else if (drpNotification.SelectedValue == "3")
        {
            divCompany.Visible = false;
            divPartner.Visible = false;
        }
        else if (drpNotification.SelectedValue == "4")
        {
            divCompany.Visible = false;
            divPartner.Visible = true;
        }
        else
        {
            divCompany.Visible = false;
            divPartner.Visible = false;
        }
    }
}