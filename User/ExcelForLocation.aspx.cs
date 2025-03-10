using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ExcelForLocation : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
    ExcelPackage pck = new ExcelPackage();
    DateTime startDate;
    DateTime endDate;
    DataTable dt = new DataTable();

    #region Page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SearchData();
        }
    }
    #endregion

    #region Helper Function
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the runtime error "
        //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."
    }
    protected void DataGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void DataGridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    #endregion

    #region Export grid to excel
    private void ExportGridToExcel()
    {
        Response.Clear();
        Response.Charset = "";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=LocationList.xlsx");
        ExcelWorksheet wsDt;
        DataTable dtt = DataGridview.DataSource as DataTable;
        //using(ExcelPackage pck As New ExcelPackage())
        {
            wsDt = pck.Workbook.Worksheets.Add("Sheet1");
            wsDt.Cells["A1"].LoadFromDataTable(dtt, true, TableStyles.None);
            wsDt.Cells[wsDt.Dimension.Address].AutoFitColumns();

            Response.BinaryWrite(pck.GetAsByteArray());
        }
        Response.Flush();
        Response.End();
    }
    #endregion

    #region Get Mechanic list for DG
    public void SearchData()
    {
        string Location = Convert.ToString(Session["SearchLocation"]);

        SqlCommand cmd = new SqlCommand("ExportExcelLocation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Location", Location);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            DataGridview.DataSource = dt;
            DataGridview.DataBind();
            ExportGridToExcel();
        }

    }
    #endregion
}