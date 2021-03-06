using HashSoftwares;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Default3 : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        ImporttoDatatable();
        // CheckData();

        //BindGrid();

    }
    private void ImporttoDatatable()
    {
        try
        {
            if (FlUploadcsv.HasFile)
            {

                //  lblmsg.Visible = false;
                //string FileName = FlUploadcsv.FileName;
                //string path = string.Concat(Server.MapPath("Product_Images/" + FlUploadcsv.FileName));
                //FlUploadcsv.PostedFile.SaveAs(path);
                //OleDbConnection OleDbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;");                              
                //OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", OleDbcon);
                //OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(cmd);
                //ds = new DataSet();
                //objAdapter1.Fill(ds);
                //Dt = ds.Tables[0];


                OleDbConnection conn = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter da = new OleDbDataAdapter();
                //DataSet ds = new DataSet();
                string query = null;
                string connString = "";
                string strFileName = DateTime.Now.ToString("ddMMyyyy_HHmmss");
                string strFileType = System.IO.Path.GetExtension(FlUploadcsv.FileName).ToString().ToLower();

                if (strFileType == ".xls" || strFileType == ".xlsx")
                {
                    FlUploadcsv.SaveAs(Server.MapPath("excelfiles/" + strFileName + strFileType));
                }

                string strNewPath = Server.MapPath("excelfiles/" + strFileName + strFileType);
                if (strFileType.Trim() == ".xls")
                {
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strNewPath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (strFileType.Trim() == ".xlsx")
                {
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strNewPath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }

                conn = new OleDbConnection(connString);
                if (conn.State == ConnectionState.Closed) conn.Open();
                string SpreadSheetName = "";
                DataTable ExcelSheets = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                SpreadSheetName = ExcelSheets.Rows[0]["TABLE_NAME"].ToString();
                query = "SELECT * FROM [" + SpreadSheetName + "]";
                cmd = new OleDbCommand(query, conn);
                da = new OleDbDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "tab1");
                Dt = ds.Tables[0];
                conn.Close();
                if (File.Exists(Server.MapPath("excelfiles/" + strFileName + strFileType)))
                {
                    File.Delete(Server.MapPath("excelfiles/" + strFileName + strFileType));
                }
                InsertData();
            }
            //else
            //{
            //    lblmsg.Visible = true;
            //    lblmsg.Text = "Please browse to select a file to upload!";
            //    return;
            //}


        }
        catch (Exception ex)
        {

        }
    }




    private void CheckData()
    {
        try
        {
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if (Dt.Rows[i][0].ToString() == "")
                {
                    int RowNo = i + 2;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "InvalidArgs", "alert('Please enter Employee ID in row " + RowNo + "');", true);
                    return;
                }
            }

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if (Dt.Rows[i][1].ToString() == "")
                {
                    int RowNo = i + 2;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "InvalidArgs", "alert('Please enter Name in row " + RowNo + "');", true);
                    return;
                }
            }

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if (Dt.Rows[i][2].ToString() == "")
                {
                    int RowNo = i + 2;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "InvalidArgs", "alert('Please enter Designation in row " + RowNo + "');", true);
                    return;
                }
            }

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                string date = DateTime.Parse(Dt.Rows[i][3].ToString()).ToString("dd/MM/yyyy");
                if (!ValidateDate(date))
                {
                    int RowNo = i + 2;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "InvalidArgs", "alert('Wrong Date format in row " + RowNo + "');", true);

                    return;
                }
            }

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if (Dt.Rows[i][4].ToString() == "")
                {
                    int RowNo = i + 2;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "InvalidArgs", "alert('Please Enter City in Row " + RowNo + "');", true);
                    return;
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    private bool ValidateDate(string date)
    {
        try
        {
            string[] dateParts = date.Split('/');
            DateTime testDate = new DateTime(Convert.ToInt32(dateParts[2]), Convert.ToInt32(dateParts[1]), Convert.ToInt32(dateParts[0]));
            return true;
        }
        catch
        {
            return false;
        }
    }

    private void InsertData()
    {

        try
        {

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                DataRow row = Dt.Rows[i];
                int columnCount = Dt.Columns.Count;
                string[] columns = new string[columnCount];
                for (int j = 0; j < columnCount; j++)
                {


                    columns[j] = row[j].ToString();
                }

                SqlParameter[] sql = new SqlParameter[5];
                //    sql[0] = new SqlParameter("@LOANID", columns[0]);
                // string tst = columns[1].Substring(1, columns[1].Length - 1);

                sql[0] = new SqlParameter("@Email", columns[0]);
                sql[1] = new SqlParameter("@CustomerName", columns[1]);
                sql[2] = new SqlParameter("@city", columns[2]);
                sql[3] = new SqlParameter("@state", columns[3]);
                sql[4] = new SqlParameter("@MobileNumber", columns[4]);

                //  SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["con"].ConnectionString, CommandType.StoredProcedure, "usp_tblFiveDayData_insert", sql).ToString();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", "alert('Record has added sucessfully  !');", true);


            }
        }
        catch
        {

        }
    }
}