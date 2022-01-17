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
            If Session("ContactID") Is Nothing Then

            '  Redirect to Login
            Response.Redirect("~/AgentLogin.aspx")

        End If
        if (!IsPostBack)
        {
            if (Request.QueryString.HasKeys())
            {
                id = Convert.ToInt32(Request.QueryString[0]);
                SqlParameter[] sql = new SqlParameter[1];
                sql[0] = new SqlParameter("@AdminID", id);
                DataTable dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_tblAdmin_Select_By_Id", sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    btnUpdate.Style.Add(HtmlTextWriterStyle.Display, "block");
                    btnSubmit.Style.Add(HtmlTextWriterStyle.Display, "none");
                    btnCancel.Style.Add(HtmlTextWriterStyle.Display, "none");
                    txtName.Text = Convert.ToString(dt.Rows[0]["Name"]);
                    txtAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                    txtZipCode.Text = Convert.ToString(dt.Rows[0]["AreaZipCode"]);
                    txtCity.Text = Convert.ToString(dt.Rows[0]["City"]);
                    txtEmail.Text = Convert.ToString(dt.Rows[0]["Email"]);
                    txtPhone.Text = Convert.ToString(dt.Rows[0]["Phone"]);
                    txtUserName.Text = Convert.ToString(dt.Rows[0]["UserName"]);
                    txtState.Text = Convert.ToString(dt.Rows[0]["State"]);
                    txtPassword.Text = Convert.ToString(dt.Rows[0]["Password"]);
                    hdnPassword.Value = dt.Rows[0]["Password"].ToString();
                }
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lblEmailMessage.ForeColor != System.Drawing.Color.Red && lblUsernameMessage.ForeColor != System.Drawing.Color.Red)
        {
            SqlParameter[] sql = new SqlParameter[10];
            sql[0] = new SqlParameter("@Name", txtName.Text);
            sql[1] = new SqlParameter("@Address", txtAddress.Text);
            sql[2] = new SqlParameter("@City", txtCity.Text);
            sql[3] = new SqlParameter("@State", txtState.Text);
            sql[4] = new SqlParameter("@AreaZipCode", txtZipCode.Text);
            sql[5] = new SqlParameter("@Phone", txtPhone.Text);
            sql[6] = new SqlParameter("@Email", txtEmail.Text);
            sql[7] = new SqlParameter("@UserName", txtUserName.Text);
            sql[8] = new SqlParameter("@Password", txtPassword.Text);
            sql[9] = new SqlParameter("@IsActive", true);
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_tblAdmin_Insert", sql).ToString();
            Response.Redirect("ManageAdmins.aspx");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (lblEmailMessage.ForeColor != System.Drawing.Color.Red && lblUsernameMessage.ForeColor != System.Drawing.Color.Red)
        {
            SqlParameter[] sql = new SqlParameter[10];
            sql[0] = new SqlParameter("@Name", txtName.Text);
            sql[1] = new SqlParameter("@Address", txtAddress.Text);
            sql[2] = new SqlParameter("@City", txtCity.Text);
            sql[3] = new SqlParameter("@State", txtState.Text);
            sql[4] = new SqlParameter("@AreaZipCode", txtZipCode.Text);
            sql[5] = new SqlParameter("@Phone", txtPhone.Text);
            sql[6] = new SqlParameter("@Email", txtEmail.Text);
            sql[7] = new SqlParameter("@UserName", txtUserName.Text);
            sql[8] = new SqlParameter("@Password", txtPassword.Text);
            sql[9] = new SqlParameter("@AdminID", id);
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_tblAdmin_Update", sql).ToString();
            Response.Redirect("ManageAdmins.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddAdmin.aspx");
    }
    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        if (txtEmail.Text == "")
        {
            lblEmailMessage.Text = "";
        }
        if (txtEmail.Text.Contains("@"))
        {
            SqlParameter[] sql = new SqlParameter[1];
            sql[0] = new SqlParameter("@Email", txtEmail.Text);
            DataTable dtClientCheck = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_Check_AdminEmail_Exists", sql).Tables[0];
            if (dtClientCheck.Rows.Count > 0)
            {
                lblEmailMessage.Text = "<img src='images/notavailable.png'/> &nbsp; Email address has already been used, sorry.";
                lblEmailMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblEmailMessage.Text = "<img src='images/available.png'/> &nbsp; Email Available !";
                lblEmailMessage.ForeColor = System.Drawing.Color.Green;
                txtEmail.Focus();
            }
        }
        if (txtEmail.Text != "" && !txtEmail.Text.Contains("@"))
        {
            lblEmailMessage.Text = "Email format is not correct, Please enter valid email !";
            lblEmailMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
        if (txtUserName.Text == "")
        {
            lblUsernameMessage.Text = "";
        }
        else
        {
            SqlParameter[] sql = new SqlParameter[1];
            sql[0] = new SqlParameter("@UserName", txtUserName.Text);
            DataTable dtClientCheck = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, CommandType.StoredProcedure, "USP_Check_AdminUsername_Exists", sql).Tables[0];
            if (dtClientCheck.Rows.Count > 0)
            {
                lblUsernameMessage.Text = "<img src='images/notavailable.png'/> &nbsp; Username not available, sorry.";
                lblUsernameMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblUsernameMessage.Text = "<img src='images/available.png'/> &nbsp; Username Available !";
                lblUsernameMessage.ForeColor = System.Drawing.Color.Green;
                txtUserName.Focus();
            }
        }
    }
    protected void txtPassword_PreRender(object sender, EventArgs e)
    {
        txtPassword.Attributes.Add("Value", hdnPassword.Value);
    }
}