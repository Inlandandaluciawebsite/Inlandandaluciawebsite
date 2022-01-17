using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class excelfiles_Genratedlead : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ContactID"] == null)
        {
            Response.Redirect("/Agentlogin.aspx");
        }
    }

    protected void ImageButtonSignOut_Click(object sender, EventArgs e)
    {
         Session.Clear();

        //' Return to Hoempage
        Response.Redirect("/");
    }
}
