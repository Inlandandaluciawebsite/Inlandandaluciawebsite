using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            lblUserName.Text = Session["UserName"].ToString();
        }
        else
        {
            Response.Redirect("/AgentLogin.aspx");
        }
        if (!IsPostBack)
        {
            if (Page.Request.Url.AbsoluteUri.Contains("Index.aspx"))
            {
                liDashboard.Attributes.Add("class", "active open ");
            }
            if (Page.Request.Url.AbsoluteUri.Contains("AddAdmin.aspx"))
            {
                sArrow.Attributes.Add("class", "arrow open");
                liAdmins.Attributes.Add("class", "active open");
                liAddAdmin.Attributes.Add("style", "color: #fff;background-color: #080808;");
            }
            if (Page.Request.Url.AbsoluteUri.Contains("ManageAdmins.aspx"))
            {
                sArrow.Attributes.Add("class", "arrow open");
                liAdmins.Attributes.Add("class", "active open");
                liManageAdmins.Attributes.Add("style", "color: #fff;background-color: #080808;");
            }
            if (Page.Request.Url.AbsoluteUri.Contains("AddNotification.aspx"))
            {
                spnNotification.Attributes.Add("class", "arrow open");
                liNotification.Attributes.Add("class", "active open");
                liAddNotification.Attributes.Add("style", "color: #fff;background-color: #080808;");
            }
            if (Page.Request.Url.AbsoluteUri.Contains("ManageNotifications.aspx"))
            {
                spnNotification.Attributes.Add("class", "arrow open");
                liNotification.Attributes.Add("class", "active open");
                liManageNotification.Attributes.Add("style", "color: #fff;background-color: #080808;");
            }
            if (Page.Request.Url.AbsoluteUri.Contains("ManageCompanies.aspx"))
            {
                SpanCompany.Attributes.Add("class", "arrow open");
                liCompanies.Attributes.Add("class", "active open");
                liManageCompany.Attributes.Add("style", "color: #fff;background-color: #080808;");
            }
            if (Page.Request.Url.AbsoluteUri.Contains("ManagePaycredential.aspx"))
            {
                sArrow.Attributes.Add("class", "arrow open");
                liAdmins.Attributes.Add("class", "active open");
                liManagePayment.Attributes.Add("style", "color: #fff;background-color: #080808;");
            }
        }
    }
}
