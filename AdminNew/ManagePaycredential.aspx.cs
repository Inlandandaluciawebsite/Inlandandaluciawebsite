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

public partial class Admin_ManagePaycredential : System.Web.UI.Page
{
    public static Int32 Paymentid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            bindpaymentcred();
        }
    }
    public void bindpaymentcred()
    {
        DataTable dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "Usp_get_paymentcredentail").Tables[0];
        if (dt.Rows.Count > 0)
        {
            btnUpdate.Style.Add(HtmlTextWriterStyle.Display, "block");
            txtusername.Text = Convert.ToString(dt.Rows[0]["UserName"]);
            txtPassword.Text = Convert.ToString(dt.Rows[0]["Password"]);
            txtconfirmpassword.Text = Convert.ToString(dt.Rows[0]["Password"]);
            Paymentid = Convert.ToInt32(dt.Rows[0]["PCID"]);
            hdnPassword.Value = dt.Rows[0]["Password"].ToString();
        }
    }

    protected void txtconfirmpassword_PreRender(object sender, EventArgs e)
    {
        txtconfirmpassword.Attributes.Add("Value", hdnPassword.Value);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlParameter[] sql = new SqlParameter[10];
        sql[0] = new SqlParameter("@username", txtusername.Text);
        sql[1] = new SqlParameter("@password", txtPassword.Text);
        sql[2] = new SqlParameter("@pcid", Paymentid);


        SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "Usp_update_paymentcredentail", sql).ToString();
        bindpaymentcred();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Payment Credentials updated successfully!');", true);
       
    }
    protected void txtPassword_PreRender(object sender, EventArgs e)
    {
        txtPassword.Attributes.Add("Value", hdnPassword.Value);
    }
}