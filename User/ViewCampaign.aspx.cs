using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ViewCampaign : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

    #region Page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.IsInRole("User"))
        {
            btnDownloadCampaign.Visible = false;
        }
        if ((!IsPostBack))
        {
            Grid_Fill();
        }
    }
    #endregion

    #region Get list of Compaign
    public void Grid_Fill()
    {
        var CampaignDetail = (from c in db.tblcampaigns
                              join t in db.tblteams on Convert.ToInt32(c.TeamId) equals t.team_id
                              select new { c.campaign_id, c.campaign_name, c.start_date, c.end_date, c.StateName, c.District, t.team_name }).OrderByDescending(m => m.campaign_id).ToList();
        if (CampaignDetail != null && CampaignDetail.Count > 0)
        {
            int count = 0;
            CampaignList.Controls.Add(new LiteralControl("<table id='CampaignListDetail'><thead class='static'><tr><th class='tableTR'>S No.</th><th class='tableTR'>Campaign Name</th><th class='tableTR'>Team Name</th><th class='tableTR'>Start Date</th> <th class='tableTR'>End Date</th><th class='tableTR'>State</th><th class='tableTR'>District</th><th class='tableTR'>Edit</th><th class='tableTR'>Delete</th></tr></thead>"));
            CampaignList.Controls.Add(new LiteralControl("<tfoot><tr><th class='tableTR'>S No.</th><th class='tableTR'>Campaign Name</th><th class='tableTR'>Team Name</th><th class='tableTR'>Start Date</th> <th class='tableTR'>End Date</th><th class='tableTR'>State</th><th class='tableTR'>District</th><th class='tableTR'>Edit</th><th class='tableTR'>Delete</th></tr></tfoot><tbody>"));
            foreach (var item in CampaignDetail)
            {
                count++;
                CampaignList.Controls.Add(new LiteralControl("<tr><td>" + count + "</td><td>" + item.campaign_name + "</td><td>" + item.team_name + "</td><td>" + String.Format("{0:ddd, MMM d, yyyy}", item.start_date) + " </td><td>" + String.Format("{0:ddd, MMM d, yyyy}", item.end_date) + "</td><td>" + item.StateName + "</td><td>" + item.District + "</td><td><a href='AddCampaign.aspx?cid=" + item.campaign_id + "'><img style='width:25px;' id='editimage' src='../img/edit.png' /></a></td><td><img style='width:25px;' id='deleteimage' onclick='Delete(" + item.campaign_id + ")' src='../img/delete.png' /></td></tr>"));
            }
            CampaignList.Controls.Add(new LiteralControl("</tbody></table>"));
        }
    }
    #endregion

    #region Link for add compaign
    protected void BtnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCampaign.aspx");
    }
    #endregion

    #region Link to down excel file
    protected void btnDownloadCampaign_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Admin/ExlCampaign.aspx");
    }
    #endregion

    #region Delete a Campaign
    [System.Web.Services.WebMethod]
    public static string Delete(string Id)
    {
        ValvolineDBDataContext db = new ValvolineDBDataContext();
        if (Id != null && Id != "")
        {
            var obj = (from p in db.tblcampaigns where p.campaign_id == Convert.ToInt32(Id) select p).Single();
            if (obj != null)
            {
                var HaveUser = (from p in db.tblusers where Convert.ToInt32(p.campaign_id) == obj.campaign_id select p).Take(1).SingleOrDefault();
                if (HaveUser != null)
                {
                    return "HaveUser";
                }
                else
                {
                    db.tblcampaigns.DeleteOnSubmit(obj);
                    db.SubmitChanges();
                }
            }
        }

        return "true";
    }
    #endregion
}