using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DataCleanByMobileNo : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
    static int eMobCount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        eMobCount = 0;
    }
    
    protected void GridViewByMobile_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridViewByMobile_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewByMobile.PageIndex = e.NewPageIndex;
        //Grid_Fill();
    }

    string eMsg, totalMsg;
    int totalCount = 0;
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string fName = FileUpload1.FileName.ToString();
            string path = string.Empty;
            string fileType = string.Empty;
            string excelConnectionString = string.Empty;

            if (!Directory.Exists(Server.MapPath("~/ExcelSheet")))
            {
                Directory.CreateDirectory(Server.MapPath("~/ExcelSheet"));
            }

            fileType = Path.GetExtension(FileUpload1.FileName).ToLower();
            path = Server.MapPath("~/ExcelSheet/" + fName);

            if (fileType.Trim() == ".xls")
            {
                FileUpload1.SaveAs(path);
              
                lblMessage.Text = "Invalid File Format.";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
            }
            else if (fileType.Trim() == ".xlsx")
            {
                FileUpload1.SaveAs(path);
                ReadMobileNumber(path);
                File.Delete(path);

                lblError.Text = "No. Of Invalid Mobile Number : " + eMobCount;
                lblError.ForeColor = Color.Red;
            }
            else
            {
                lblMessage.Text = "Invalid File";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Visible = true;
            }
        }
        else
        {
            lblMessage.Text = "Please select excel sheet";
            lblMessage.ForeColor = Color.Red;
            lblMessage.Visible = true;
        }
    }
    protected void BtbDownload_Click(object sender, EventArgs e)
    {
        string filepath = Server.MapPath("../SampleSheet/Sample Mobile Number.xlsx");
        FileInfo file = new FileInfo(filepath);
        if (file.Exists)
        {
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=" + file.Name);
            Response.AddHeader("Content-Type", "application/Excel");
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.WriteFile(file.FullName);
            Response.End();
        }
        else
        {
            lblMessage.Text = "File Does Not Exists.";
            lblMessage.ForeColor = Color.Red;
            lblMessage.Visible = true;
        }
    }
    protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)GridViewByMobile.HeaderRow.FindControl("chkboxSelectAll");
        foreach (GridViewRow row in GridViewByMobile.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkDel");
            if (ChkBoxHeader.Checked == true)
            {
                ChkBoxRows.Checked = true;
            }
            else
            {
                ChkBoxRows.Checked = false;
            }
        }
    }

    protected void ReadMobileNumber(string path)
    {
        DataTable dtNew = new DataTable();
        dtNew = ReadMobileNumberFromDataTable(path);

        if (dtNew.Rows.Count > 0)
        {
            SelectDataFromMobNo(dtNew);
        }
    }

    DataTable dtExcel = new DataTable();
    protected DataTable ReadMobileNumberFromDataTable(string path)
    {
        ExcelPackage xlPackage = new ExcelPackage();
        var stream = File.OpenRead(path);
        xlPackage.Load(stream);
        ExcelWorksheet ws = xlPackage.Workbook.Worksheets.First();
        //dtExcel = new DataTable(ws.Name);
        dtExcel.TableName = ws.Name;
        stream.Close();

        int totalCols = ws.Dimension.End.Column;
        int totalRows = ws.Dimension.End.Row;
        int startRow = 2;
        ExcelRange wsRows;
        DataRow dr;
        bool b1 = true;

        if (totalCols == 1)
        {
            dtExcel.Columns.Add("contact_number", typeof(string));

            for (int rownum = startRow; rownum <= totalRows; rownum++)
            {
                wsRows = ws.Cells[rownum, 1, rownum, totalCols];
                dr = dtExcel.NewRow();
                foreach (var cell in wsRows)
                {
                    b1 = ValidMobNo(cell.Text);
                    if (b1 == false)
                    {
                        continue;
                    }
                    dr[cell.Start.Column - 1] = cell.Text;
                }
                dtExcel.Rows.Add(dr);
            }
        }
        else
        {
            lblMessage.Text = "Invalid No. Of Columns, There must be 1 Columns.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Visible = true;
        }
        return dtExcel;
    }

    protected void SelectDataFromMobNo(DataTable dtNew)
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Connection = con;

        cmd.Parameters.Add("@contact_number", SqlDbType.Structured).Value = dtNew;

        cmd.CommandText = "adminSelectDataForDelete";
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        //int i = cmd.ExecuteNonQuery();
        da.Fill(dt);
        GridViewByMobile.DataSource = dt;
        GridViewByMobile.DataBind();
        con.Close();
        btnDelete.Visible = true;
        
        lblMessage.Text = "Uploading Done.";
        lblMessage.ForeColor = System.Drawing.Color.Green;
        lblMessage.Visible = true;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int count = 0;
        foreach (GridViewRow gvrow in GridViewByMobile.Rows)
        {
            //Finiding checkbox control in gridview for particular row
            CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkDel");
            //Condition to check checkbox selected or not
            if (chkdelete.Checked)
            {
                count++;
                //Getting UserId of particular row using datakey value
                string mob = Convert.ToString(GridViewByMobile.DataKeys[gvrow.RowIndex].Value);
                DeleteRecord(mob);
            }
        }
        lblMessage.Text = count + " Rows Deleted Successfully";
        GridViewByMobile.DataSource = null;
        GridViewByMobile.DataBind();
    }

    protected void DeleteRecord(string mob)
    {
        con.Open();
        SqlCommand com = new SqlCommand("update tblvalvoline_detail set deleted_on = 1 where contact_number = @contact_number", con);
        com.Parameters.AddWithValue("@contact_number", mob);
        com.ExecuteNonQuery();
        con.Close();
    }

    protected bool ValidMobNo(string MobNo)
    {
        bool b1 = true;
        if (MobNo.Length != 10)
        {
            eMobCount++;
            b1 = false;
            lblError.Visible = true;
        }
        else
        {
            b1 = MobNo.All(char.IsNumber);
            if (b1 == false)
            {
                eMobCount++;
                lblError.Visible = true;
            }
        }
        return b1;
    }

    //public void Grid_Fill()
    //{
    //    if (dtExcel.Rows.Count > 0)
    //    {
    //        SqlCommand cmd = new SqlCommand("adminSelectDataForDelete", con);
    //        SqlDataAdapter ad = new SqlDataAdapter(cmd);
    //        DataTable dt = new DataTable();
    //        cmd.Parameters.AddWithValue("@contact_number", dtExcel);

    //        ad.Fill(dt);
    //        GridViewByMobile.DataSource = dt;
    //        GridViewByMobile.DataBind();
    //    }
    //    else
    //    {
    //        lblMessage.Text = "No Rows Found";
    //    }
    //}
}