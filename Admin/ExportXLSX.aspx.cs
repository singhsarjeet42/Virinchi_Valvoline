using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ExportXLSX : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlCommand cmd = new SqlCommand("adminExportXLSX", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            ExportExcel(dt);
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the runtime error "
        //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."
    }
    private void ExportExcel(DataTable dt)
    {
        String timestamp_without_commas = DateTime.Now.ToString("R").Replace(",", "");

        try
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("SearchReport");

                //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                ws.Cells["A1"].LoadFromDataTable(dt, true);
                //prepare the range for the column headers
                string cellRange = "A1:" + Convert.ToChar('A' + dt.Columns.Count - 1) + 1;
                //Format the header for columns
                using (ExcelRange rng = ws.Cells[cellRange])
                {
                    rng.Style.WrapText = false;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid; //Set Pattern for the background to Solid
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    rng.Style.Font.Color.SetColor(Color.White);
                }
                //prepare the range for the rows
                string rowsCellRange = "A2:" + Convert.ToChar('A' + dt.Columns.Count - 1) + dt.Rows.Count * dt.Columns.Count;
                //Format the rows
                using (ExcelRange rng = ws.Cells[rowsCellRange])
                {
                    rng.Style.WrapText = false;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                }
                //Read the Excel file in a byte array
                Byte[] fileBytes = pck.GetAsByteArray();

                //Clear the response
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Cookies.Clear();
                //MemoryStream ms = new MemoryStream(fileBytes);
                //Add the header & other information 
                Response.Cache.SetCacheability(HttpCacheability.Private);
                Response.CacheControl = "private";
                Response.Charset = System.Text.UTF8Encoding.UTF8.WebName;
                Response.ContentEncoding = System.Text.UTF8Encoding.UTF8;
                Response.AppendHeader("Content-Length", fileBytes.Length.ToString());
                Response.AppendHeader("Pragma", "cache");
                Response.AppendHeader("Expires", "60");
                Response.AppendHeader("Content-Disposition",
                "attachment; " +
                "filename=\"ExcelReport.xlsx\"; " +
                "size=" + fileBytes.Length.ToString() + "; " +
                "creation-date=" + timestamp_without_commas + "; " +
                "modification-date=" + timestamp_without_commas + "; " +
                "read-date=" + timestamp_without_commas);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Response.Buffer = true;
                //ms.WriteTo(Response.OutputStream);
                //Write it back to the client
                Response.BinaryWrite(fileBytes);
                //Response.TransmitFile("ExcelReport.xlsx");
                Response.End();
            }
        }
        catch(Exception ex)
        {
            if (!(ex is System.Threading.ThreadAbortException))
            {
                //Log other errors here
            }
        }
    }
    //"creation-date=" + DateTime.Now.ToString("R") + "; " +
    //"modification-date=" + DateTime.Now.ToString("R") + "; " +
    //"read-date=" + DateTime.Now.ToString("R"));
}