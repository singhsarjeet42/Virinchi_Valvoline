using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ExlCampaign : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        GridFill();
        ExportGridToExcel();
    }
    #endregion

    #region Helper Function
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the runtime error "
        //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."
    }
    #endregion

    #region Get list of campaign
    protected void GridFill()
    {
        ////DataTable dt = new DataTable();
        ////SqlCommand cmd = new SqlCommand("adminCampaignListNew", con);
        ////cmd.CommandType = CommandType.StoredProcedure;
        ////SqlDataAdapter ad = new SqlDataAdapter(cmd);

        ////ad.Fill(dt);
        ////if (dt.Rows.Count > 0)
        ////{
        ////    DataGridview.DataSource = dt;
        ////    DataGridview.DataBind();
        ////}

        var CampaignDetail = (from c in db.tblcampaigns
                              join t in db.tblteams on Convert.ToInt32(c.TeamId) equals t.team_id
                              select new { c.campaign_id, c.campaign_name, c.start_date, c.end_date, c.StateName, c.District, t.team_name }).OrderByDescending(m => m.campaign_id).ToList();
        if (CampaignDetail != null && CampaignDetail.Count > 0)
        {
            DataGridview.DataSource = CampaignDetail;
            DataGridview.DataBind();
        }
    }
    #endregion

    private void ExportGridToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "CampaignList" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel"; //For Excel 2003
        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        DataGridview.GridLines = GridLines.Both;
        DataGridview.HeaderStyle.Font.Bold = true;
        DataGridview.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
    }
}