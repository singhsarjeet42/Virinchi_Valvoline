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

public partial class Admin_ExlUser : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

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

    #region Get user list
    private void BindGrid()
    {
        var UserDetail = (from u in db.tblusers
                          join c in db.tblcampaigns on u.campaign_id equals c.campaign_id
                          join t in db.tblteams on u.team_id equals t.team_id
                          select new { u.EmailId, u.MobileNo, u.Roles, u.Password, u.user_name, u.user_id, u.imei_second, u.imei_first, u.District, u.createdOn, u.state, c.campaign_name, t.team_name }).OrderByDescending(m => m.user_id).ToList();

        if (UserDetail != null && UserDetail.Count > 0)
        {
            DataGridview.DataSource = UserDetail;
            DataGridview.DataBind();
        }
    }
    #endregion

    #region Export to excel function
    private void ExportGridToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "UserList" + DateTime.Now + ".xls";
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
    #endregion
}