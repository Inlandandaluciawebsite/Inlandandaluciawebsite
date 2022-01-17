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

public partial class GenerateLeads_leadDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            bindtext();
        }
    }

    private void bindtext()
    {
        SqlParameter[] sql = new SqlParameter[1];
        int id = Convert.ToInt32( Request.QueryString["id"]);
        sql[0] = new SqlParameter("@DateId", id);


        DataSet dt = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["con"].ConnectionString, CommandType.StoredProcedure, "Usp_tblLeads_selectById",sql);
        if (dt.Tables[0].Rows.Count > 0)
        {
           ltconteactemail.Text = dt.Tables[0].Rows[0]["Email"].ToString();
           ltcosname.Text = dt.Tables[0].Rows[0]["CustomerName"].ToString();
           ltcity.Text = dt.Tables[0].Rows[0]["city"].ToString();
           ltstate.Text = dt.Tables[0].Rows[0]["state"].ToString();
           lttele.Text = dt.Tables[0].Rows[0]["MobileNumber"].ToString();
           hdndataid.Value = dt.Tables[0].Rows[0]["LeadId"].ToString();
        }
        if (dt.Tables[1].Rows.Count > 0)
        {
            rpmessge.DataSource = dt.Tables[1];

            rpmessge.DataBind();
          
        }
      
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sql = new SqlParameter[2];
        int id = Convert.ToInt32(hdndataid.Value);
        sql[0] = new SqlParameter("@Lead_Id", id);
        sql[1] = new SqlParameter("@Message", txtmessage.Text);
     SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["con"].ConnectionString, CommandType.StoredProcedure, "Usp_tblleadmessage_Insert", sql);
     txtmessage.Text = string.Empty;
        bindtext();
    }
}