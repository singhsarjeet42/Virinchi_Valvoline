using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class ViewTeam : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.IsInRole("User"))
        {
            btnExlViewTeam.Visible = false;
        }
        if (!(IsPostBack))
        {
            Grid_Fill();
        }
    }
    #endregion

    #region Get Team List
    public void Grid_Fill()
    {
        var TeamLists = (from p in db.tblteams select p).OrderByDescending(m => m.team_id).ToList();
        if (TeamLists != null && TeamLists.Count > 0)
        {
            int count = 0;
            TeamList.Controls.Add(new LiteralControl("<table id='TeamListDetail'><thead class='static'><tr><th class='tableTR'>S No.</th><th class='tableTR'>Organization Name</th><th class='tableTR'>Team Name</th><th class='tableTR'>User Type</th><th class='tableTR'>State</th><th class='tableTR'>District</th><th class='tableTR'>Edit</th><th class='tableTR'>Delete</th></tr></thead>"));
            TeamList.Controls.Add(new LiteralControl("<tfoot><tr><th class='tableTR'>S No.</th><th class='tableTR'>Organization Name</th><th class='tableTR'>Team Name</th> <th class='tableTR'>User Type</th><th class='tableTR'>State</th><th class='tableTR'>District</th><th class='tableTR'>Edit</th><th class='tableTR'>Delete</th></tr></tfoot><tbody>"));
            foreach (var item in TeamLists)
            {
                count++;
                TeamList.Controls.Add(new LiteralControl("<tr><td>" + count + "</td><td>" + item.name + "</td><td>" + item.team_name + "</td><td>" + item.user_type + "</td><td>" + item.state + "</td><td>" + item.District + "</td><td><a href='AddTeam.aspx?cid=" + item.team_id + "'><img style='width:25px;' id='editimage' src='../img/edit.png' /></a></td><td><img style='width:25px;' id='deleteimage' onclick='Delete(" + item.team_id + ")' src='../img/delete.png' /></td></tr>"));
            }
            TeamList.Controls.Add(new LiteralControl("</tbody></table>"));
        }
    }
    #endregion

    #region Link code for add team
    protected void AddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddTeam.aspx");
    }
    #endregion

    #region Helper Method
    protected void CampaignGridview_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    #endregion

    #region Button Excel sheet download
    protected void btnExlViewTeam_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Admin/ExlViewTeam.aspx");
    }
    #endregion

    #region Delete a team
    [System.Web.Services.WebMethod]
    public static string Delete(string Id)
    {
        ValvolineDBDataContext db = new ValvolineDBDataContext();
        if (Id != null && Id != "")
        {
            var obj = (from p in db.tblteams where p.team_id == Convert.ToInt32(Id) select p).Single();
            if (obj != null)
            {
                var HaveCampaign = (from p in db.tblcampaigns where Convert.ToInt32(p.TeamId) == obj.team_id select p).Take(1).SingleOrDefault();
                if (HaveCampaign != null)
                {
                    return "HaveCampaign";
                }
                else
                {
                    db.tblteams.DeleteOnSubmit(obj);
                    db.SubmitChanges();
                }
            }
        }

        return "true";
    }
    #endregion
}