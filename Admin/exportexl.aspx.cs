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

public partial class page1 : System.Web.UI.Page
{
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
                startDate = Convert.ToDateTime("01/01/1754");
                endDate = Convert.ToDateTime("01/01/9999");
            }
            else
            {
                startDate = Convert.ToDateTime(starttime).AddDays(-1);
                endDate = Convert.ToDateTime(endtime).AddDays(1);
            }

            if (campaign_id == "0")
                campaign_id = "";
            if (state == "Select")
                state = "";
            if (team_name == "Select")
                team_name = "";
            SqlCommand cmd = new SqlCommand("adminSearchValvoline", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@campaign_id", campaign_id);
            //cmd.Parameters.AddWithValue("@client_name", ddlClient.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@team_name", team_name);
            cmd.Parameters.AddWithValue("@contact_number", contact_number);
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
                Response.Redirect("MechanicSearch.aspx?");
            }

        }
        else
        {
            SqlCommand cmd = new SqlCommand("adminExportExcel", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            DataGridview.DataSource = dt;
            string str = dt.Rows.Count.ToString();
            DataGridview.DataBind();
            ExportGridToExcel();
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