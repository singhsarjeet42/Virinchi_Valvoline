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

public partial class User_ExcelForSegment : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
    ExcelPackage pck = new ExcelPackage();
    DateTime startDate;
    DateTime endDate;
    DataTable dt = new DataTable();

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Bindgrid();
            SearchData();
            //ExportGridToExcel();
        }
    }
    #endregion

    #region Export Grid To Excel
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

    #region Get Mechanic List
    public void SearchData()
    {
        bool IsSegmentAll = false;
        bool IsStateAll = false;
        var userId = Session["UserId"];
        string state = Convert.ToString(Session["SearchState"]);
        string Segment = Convert.ToString(Session["SearchSegment"]);
        string StartDate = Convert.ToString(Session["SearchStartDate"]);
        string EndDate = Convert.ToString(Session["SearchEndDate"]);
        string District = Convert.ToString(Session["SearchDistrict"]);  
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
        var SegmentAll = (from p in db.tblUserSegments where p.UserId == Convert.ToInt32(userId) && p.IsDeleted == false && p.Segment == "All" select p).SingleOrDefault();
        if (SegmentAll != null)
        {
            IsSegmentAll = true;
        }
        var StateAll = (from p in db.tblUserStates where p.UserId == Convert.ToInt32(userId) && p.IsDeleted == false && p.State == "All" select p).SingleOrDefault();
        if (StateAll != null)
        {
            IsStateAll = true;
        }
        string SegmentName = "";
        string StateName = "";
        if (IsSegmentAll)
        {
            if (IsStateAll)
            {
                #region Mechanic list for segment head if segment is 'All' and state is also 'All'
                SqlCommand cmd = new SqlCommand("ExportExcelSegmentForAllSegmentAndAllState", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@Segment", Segment);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Parameters.AddWithValue("@District", District);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                DataGridview.DataSource = dt;
                string str = dt.Rows.Count.ToString();
                DataGridview.DataBind();
                ExportGridToExcel();
                #endregion
            }
            else
            {
                #region Mechanic list for segment head if segment is 'All' and state selected
                var StateList = (from p in db.tblUserStates where p.UserId == Convert.ToInt32(userId) && p.IsDeleted == false select p).ToList();
                if (StateList != null && StateList.Count > 0)
                {
                    foreach (var item in StateList)
                    {
                        StateName = StateName + "," + item.State;
                    }
                }
                SqlCommand cmd = new SqlCommand("ExportExcelSegmentForAllSegmentAndSelectedState", con);//This procedure for segment head when segment is 'All'
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateName", StateName);
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
                #endregion
            }
        }
        else
        {
            if (IsStateAll)
            {
                #region Mechanic list for segment head if segment is selected and state is 'All'
                var SegmentList = (from p in db.tblUserSegments where p.UserId == Convert.ToInt32(userId) && p.IsDeleted == false select p).ToList();
                if (SegmentList != null && SegmentList.Count > 0)
                {
                    foreach (var item in SegmentList)
                    {
                        SegmentName = SegmentName + "," + item.Segment;
                    }
                }
                SqlCommand cmd = new SqlCommand("ExportExcelSegmentWithAllState", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SegmentName", SegmentName);
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
                #endregion
            }
            else
            {
                #region Mechanic list for segment head if segment is selected and state also selected
                var StateList = (from p in db.tblUserStates where p.UserId == Convert.ToInt32(userId) && p.IsDeleted == false select p).ToList();
                if (StateList != null && StateList.Count > 0)
                {
                    foreach (var item in StateList)
                    {
                        StateName = StateName + "," + item.State;
                    }
                }
                var SegmentList = (from p in db.tblUserSegments where p.UserId == Convert.ToInt32(userId) && p.IsDeleted == false select p).ToList();
                if (SegmentList != null && SegmentList.Count > 0)
                {
                    foreach (var item in SegmentList)
                    {
                        SegmentName = SegmentName + "," + item.Segment;
                    }
                }
                SqlCommand cmd = new SqlCommand("ExportExcelSegment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateName", StateName);
                cmd.Parameters.AddWithValue("@SegmentName", SegmentName);
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
                #endregion
            }
        }

    }
    #endregion

    #region Helper Method
    protected void DataGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void DataGridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the runtime error "
        //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."
    }
    #endregion
}