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

public partial class Admin_ExlViewTeam : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
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


    private void BindGrid()
    {
        //DataTable dt = new DataTable();
        //SqlCommand cmd = new SqlCommand("adminTeamListNew", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //SqlDataAdapter ad = new SqlDataAdapter(cmd);

        //ad.Fill(dt);
        //if (dt.Rows.Count > 0)
        //{
        //    DataGridview.DataSource = dt;
        //    DataGridview.DataBind();
        //}
        var TeamDetail = (from p in db.tblteams select p).OrderByDescending(m => m.team_id).ToList();
        if (TeamDetail != null && TeamDetail.Count > 0)
        {
            DataGridview.DataSource = TeamDetail;
            DataGridview.DataBind();
        }
    }

    private void ExportGridToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "TeamList" + DateTime.Now + ".xls";
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