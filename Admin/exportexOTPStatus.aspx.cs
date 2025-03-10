using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;

public partial class Admin_exportexOTPStatus : System.Web.UI.Page
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
            SearchData();
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
        Response.AddHeader("content-disposition", "attachment;filename=OTPStatus.xlsx");
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

    #region Get OTP Status List
    public void SearchData()
    {
        //List<OTPStatus> list = new List<OTPStatus>();
        //var OTPSTATUSLIST = (from s in db.tblOTPStatus
        //                     join t in db.tblusers on s.TagId equals Convert.ToString(t.user_id)
        //                     where Convert.ToDateTime(s.CreatedOn).Date == DateTime.Now.Date
        //                     select new { s, t.user_name }).OrderByDescending(m => m.s.Id).ToList();
        //if (OTPSTATUSLIST != null && OTPSTATUSLIST.Count > 0)
        //{
        //    foreach (var item in OTPSTATUSLIST)
        //    {
        //        OTPStatus obj = new OTPStatus();
        //        obj.DateTimes = Convert.ToString(item.s.CreatedOn);
        //        obj.Message = item.s.Message;
        //        obj.MobileNumber = item.s.MobileNumber;
        //        var OTPdetail = (from p in db.tblvalvoline_details where Convert.ToString(p.contact_number) == item.s.MobileNumber select p).SingleOrDefault();
        //        if (OTPdetail != null)
        //            obj.OTP = OTPdetail.otp_password;
        //        obj.SourceOfUser = item.user_name;
        //        list.Add(obj);
        //    }
        //}
        //DataGridview.DataSource = list;
        //DataGridview.DataBind();
        //ExportGridToExcel();
        string starttime = Request.QueryString["starttime"];
        string endtime = Request.QueryString["endtime"];
        if (starttime == "01-01-0001 00:00:00" || starttime == "01-01-0001 12:00:00" || starttime == "1/1/0001 12:00:00 AM" || endtime == "01-01-0001 00:00:00" || endtime == "01-01-0001 12:00:00" || endtime == "1/1/0001 12:00:00 AM")
        {
            startDate = Convert.ToDateTime("01/01/1754");
            endDate = Convert.ToDateTime("01/01/9999");
        }
        else
        {
            startDate = Convert.ToDateTime(starttime).AddDays(-1);
            endDate = Convert.ToDateTime(endtime).AddDays(1);
        }
        SqlCommand cmd = new SqlCommand("GetOTPStatus", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@starttime ", Convert.ToDateTime(startDate));
        cmd.Parameters.AddWithValue("@endtime ", Convert.ToDateTime(endDate));
        SqlDataAdapter ad = new SqlDataAdapter(cmd);

        ad.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            DataGridview.DataSource = dt;
            DataGridview.DataBind();
            ExportGridToExcel();
        }
        else
        {
            Response.Redirect("../admin/OTPStatus.aspx?");
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