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

public partial class User_ExcelForDG : System.Web.UI.Page
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
        Response.AddHeader("content-disposition", "attachment;filename=MechanicList.xlsx");
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
        string state = Convert.ToString(Session["SearchState"]);
        string Segment = Convert.ToString(Session["SearchSegment"]);
        string StartDate = Convert.ToString(Session["SearchStartDate"]);
        string EndDate = Convert.ToString(Session["SearchEndDate"]);
        string District = Convert.ToString(Session["SearchDistrict"]);  
        DateTime startDate;
        DateTime endDate;
        if (StartDate == "")
        {
            startDate = Convert.ToDateTime("01/01/1754");
        }
        else
        {
            startDate = Convert.ToDateTime(StartDate).AddDays(-1);
        }

        if (EndDate == "")
        {
            endDate = Convert.ToDateTime("01/01/9999");
        }
        else
        {
            endDate = Convert.ToDateTime(EndDate).AddDays(1);
        }
        var userId = Session["UserId"];
        SqlCommand cmd = new SqlCommand("ExportExcelDG", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@userId", userId);
        cmd.Parameters.AddWithValue("@state", state);
        cmd.Parameters.AddWithValue("@Segment", Segment);
        cmd.Parameters.AddWithValue("@startDate", startDate);
        cmd.Parameters.AddWithValue("@endDate", endDate);
        cmd.Parameters.AddWithValue("@District", District);
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