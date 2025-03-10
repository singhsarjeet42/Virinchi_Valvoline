using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using System.IO;

public partial class Admin_DownloadSearchData : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Bindgrid();
            SearchData();
            //ExportGridToExcel();
        }
    }

    ExcelPackage pck = new ExcelPackage();
    private void ExportGridToExcel()
    {
        //Response.Clear();
        //Response.Buffer = true;
        //Response.ClearContent();
        //Response.ClearHeaders();
        //Response.Charset = "";
        //string FileName = "Vithal" + DateTime.Now + ".xls";
        //StringWriter strwritter = new StringWriter();
        //HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Response.ContentType = "application/vnd.ms-excel";
        //Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        //DataGridview.GridLines = GridLines.Both;
        //DataGridview.HeaderStyle.Font.Bold = true;
        //DataGridview.RenderControl(htmltextwrtter);
        //Response.Write(strwritter.ToString());
        //Response.End();






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

    string startDate = "";
    string endDate = "";
    DataTable dt = new DataTable();

    public void SearchData()
    {
        string campaign_id = Request.QueryString["campaign_id"];
        string state = Request.QueryString["state"];
        string team_name = Request.QueryString["team_name"];
        string contact_number = Request.QueryString["contact_number"];
        string starttime = Request.QueryString["starttime"];
        string endtime = Request.QueryString["endtime"];

        if ((campaign_id != "0" || state != "Select" || team_name != "Select" || contact_number != "" || starttime != "1/1/0001 12:00:00 AM" || endtime != "1/1/0001 12:00:00 AM") && (campaign_id != null))
        {

            if (starttime == "01-01-0001 00:00:00" || starttime == "01-01-0001 12:00:00" || starttime == "1/1/0001 12:00:00 AM" || endtime == "01-01-0001 00:00:00" || endtime == "01-01-0001 12:00:00" || endtime == "1/1/0001 12:00:00 AM")
            {
                startDate = "01/01/1754";
                endDate = "01/01/9999";
            }
            if (campaign_id == "0")
                campaign_id = null;
            if (team_name == "Select")
                team_name = null;
            if (state == "Select")
                state = null;
            var MechanicData = (from p in db.tblvalvoline_details
                                where p.deleted_on == false && (p.state == state || state == "" || state == null)
                                    && (p.campaign_id == Convert.ToInt32(campaign_id) || Convert.ToString(campaign_id) == "" || Convert.ToString(campaign_id) == null)
                                    && (Convert.ToString(p.contact_number) == contact_number || Convert.ToString(contact_number) == "" || Convert.ToString(contact_number) == null)
                                    && (p.team_name == team_name || team_name == "" || team_name == null)
                                     && (p.createdOn > Convert.ToDateTime(startDate) && p.createdOn < Convert.ToDateTime(endDate))
                                select p).ToList();
            if (MechanicData != null && MechanicData.Count > 0)
            {
                DataGridview.DataSource = MechanicData;
                DataGridview.DataBind();
            }
            ExportGridToExcel();
        }
        //else
        //{
        //    SqlCommand cmd = new SqlCommand("adminExportExcel", con);
        //    SqlDataAdapter ad = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    ad.Fill(dt);
        //    DataGridview.DataSource = dt;
        //    string str = dt.Rows.Count.ToString();
        //    DataGridview.DataBind();
        //    ExportGridToExcel();
        //}
    }
}