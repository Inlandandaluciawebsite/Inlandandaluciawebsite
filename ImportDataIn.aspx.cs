using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace ImportDataInland
{
    public partial class ImportDataIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Coneection String by default empty  
            string ConStr = "";
            //Extantion of the file upload control saving into ext because   
            //there are two types of extation .xls and .xlsx of Excel   
            string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
            //getting the path of the file   
            string path = Server.MapPath("~/Files/" + FileUpload1.FileName);
            //saving the file inside the MyFolder of the server  
            FileUpload1.SaveAs(path);
            Label1.Text = FileUpload1.FileName + "\'s Data showing into the GridView";
            //checking that extantion is .xls or .xlsx  
            if (ext.Trim() == ".xls")
            {
                //connection string for that file which extantion is .xls  
                ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (ext.Trim() == ".xlsx")
            {
                //connection string for that file which extantion is .xlsx  
                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            //making query  
            string query = "SELECT * FROM [Sheet1$]";
            //Providing connection  
            OleDbConnection conn = new OleDbConnection(ConStr);
            //checking that connection state is closed or not if closed the   
            //open the connection  
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //create command object  
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // create a data adapter and get the data into dataadapter  
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            //fill the Excel data to data set  
            da.Fill(ds);
            //set data source of the grid view  
            gvExcelFile.DataSource = ds.Tables[0];
            DataTable dt = new DataTable();
            dt= ds.Tables[0];
            string InsertQuery = "";
            int postCode = Convert.ToUInt16(txtPostCode.Text);
            for (int i=0;i<=dt.Rows.Count-1;i++)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["IA"].ConnectionString;
                //InsertQuery = "insert into PC_SubArea (SubArea_ID,SubArea_Name) values (" + dt.Rows[i][3] + ",'" + dt.Rows[i][0].ToString() + "'); insert into postcode (Postcode_ID,Postcode,Country_ID,Region_ID,Area_ID,SubArea_ID,Default_Partner_ID) values(" + postCode + "," + dt.Rows[i][1] + ",2,"+txtregion.Text+"," + dt.Rows[i][2] + ","+ dt.Rows[i][3] + ",3873)";
                  InsertQuery = "insert into PC_Area (Area_ID,Area_Name) values (" + dt.Rows[i][2] + ",'" + dt.Rows[i][0].ToString() + "'); insert into postcode (Postcode_ID,Postcode,Country_ID,Region_ID,Area_ID,SubArea_ID,Default_Partner_ID) values(" + postCode + "," + dt.Rows[i][1] + ",2,"+txtregion.Text+"," + dt.Rows[i][2] + ",0,3873)";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand commandASD = new SqlCommand(InsertQuery, con);
                SqlDataAdapter sda = new SqlDataAdapter(commandASD);
                DataTable dtn = new DataTable();
                sda.Fill(dtn);
                postCode++;
            }
                        //binding the gridview  
            gvExcelFile.DataBind();
            //close the connection  
            conn.Close();
        }
    }
}