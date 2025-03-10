using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
//using System.Globalization.CultureInfo.InvariantCulture;

public partial class AddCampaign : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
    ValvolineDBDataContext db = new ValvolineDBDataContext();

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!IsPostBack))
        {
            if (Request.QueryString["cid"] != null && Request.QueryString["cid"].ToString() != "")
            {
                set_value();
                FillTeamOnUpdate(Request.QueryString["cid"]);
                SelectStateForUpdate(Request.QueryString["cid"]);
            }
            if (BtnSubmit.Text == "Update")
            { }
            else
            {
                FillTeam();
                SelectState();
            }
        }
    }
    #endregion

    #region Fill Team On Update Function
    public void FillTeamOnUpdate(string CompaignId)
    {
        string OldTeam = "";
        var CompaignDetail = (from p in db.tblcampaigns where p.campaign_id == Convert.ToInt32(CompaignId) select p).SingleOrDefault();
        if (CompaignDetail != null)
        {
            var TeamDetail = (from p in db.tblteams where p.team_id == Convert.ToInt32(CompaignDetail.TeamId) select p).SingleOrDefault();
            if (TeamDetail != null)
            {
                OldTeam = TeamDetail.team_name;
                ddlName.Items.Insert(0, new ListItem(TeamDetail.team_name, Convert.ToString(TeamDetail.team_id)));
            }
            else
            {
                ddlName.Items.Insert(0, new ListItem("Select", "NA"));
            }
        }
        else
        {
            ddlName.Items.Insert(0, new ListItem("Select", "NA"));
        }
        var TeamList = (from p in db.tblteams where p.user_type != "Admin" select p).OrderBy(m => m.team_name).ToList();
        var count = 0;
        if (TeamList != null && TeamList.Count > 0)
        {
            foreach (var item in TeamList)
            {
                if (OldTeam.Trim() != item.team_name.Trim())
                {
                    count++;
                    ddlName.Items.Insert(count, new ListItem(Convert.ToString(item.team_name), Convert.ToString(item.team_id)));
                }
            }
        }
    }
    #endregion

    #region Fill Team Function
    public void FillTeam()
    {
        ddlName.Items.Insert(0, new ListItem("Select", "NA"));
        var TeamList = (from p in db.tblteams where p.user_type != "Admin" select p).OrderBy(m => m.team_name).ToList();
        var count = 0;
        if (TeamList != null && TeamList.Count > 0)
        {
            foreach (var item in TeamList)
            {
                count++;
                ddlName.Items.Insert(count, new ListItem(Convert.ToString(item.team_name), Convert.ToString(item.team_id)));
            }
        }
    }
    #endregion

    #region set value function
    public void set_value()
    {
        LCamp.Text = "Edit Campaign";
        LCamp1.Text = "Edit Campaign";
        LCamp2.Text = "Edit Campaign";
        BtnSubmit.Text = "Update";
        var CompaignDetail = (from p in db.tblcampaigns where p.campaign_id == Convert.ToInt32(Request.QueryString["cid"]) select p).SingleOrDefault();
        if (CompaignDetail != null)
        {
            txtCName.Text = CompaignDetail.campaign_name;
            txtSTime.Text = Convert.ToString(CompaignDetail.start_date).Substring(0, 10);
            txtETime.Text = Convert.ToString(CompaignDetail.end_date).Substring(0, 10);
        }
    }
    #endregion

    #region Save Campaign
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (BtnSubmit.Text == "Update")
        {
            var CampaignDetail = (from p in db.tblcampaigns where p.campaign_id != Convert.ToInt32(Request.QueryString["cid"]) && p.TeamId == ddlName.SelectedValue && p.campaign_name == txtCName.Text.Trim() select p).SingleOrDefault();
            if (CampaignDetail != null)
            {
                Label1.Text = "'" + txtCName.Text + "' is already added in '" + Convert.ToString(ddlName.SelectedItem) + "' team";
            }
            else
            {

                var CompaignDetail = (from p in db.tblcampaigns where p.campaign_id == Convert.ToInt32(Request.QueryString["cid"]) select p).SingleOrDefault();
                if (CompaignDetail != null)
                {
                    bool IsSaveCampaign = true;
                    if (txtSTime.Text != null && txtSTime.Text != "")
                    {
                        if (Convert.ToDateTime(txtETime.Text) < Convert.ToDateTime(txtSTime.Text))
                        {
                            IsSaveCampaign = false;
                            Label1.Text = "End date must be greater than start date";
                        }

                    }
                    if (Convert.ToString(ListState.SelectedItem) != null && Convert.ToString(ListState.SelectedItem) != "")
                        CompaignDetail.StateName = Convert.ToString(ListState.SelectedItem);
                    if (Convert.ToString(ListBoxDistrict.SelectedItem) != null && Convert.ToString(ListBoxDistrict.SelectedItem) != "")
                        CompaignDetail.District = Convert.ToString(ListBoxDistrict.SelectedItem);
                    CompaignDetail.campaign_name = txtCName.Text.Trim();
                    CompaignDetail.start_date = Convert.ToDateTime(txtSTime.Text);
                    CompaignDetail.end_date = Convert.ToDateTime(txtETime.Text);
                    CompaignDetail.TeamId = ddlName.SelectedValue;
                    if (IsSaveCampaign)
                    {
                        db.SubmitChanges();
                        Response.Redirect("ViewCampaign.aspx");
                    }
                }
            }
        }
        else
        {
            var CampaignDetail = (from p in db.tblcampaigns where p.TeamId == ddlName.SelectedValue && p.campaign_name == txtCName.Text.Trim() select p).SingleOrDefault();
            if (CampaignDetail != null)
            {
                Label1.Text = "'" + txtCName.Text + "' is already added in '" + Convert.ToString(ddlName.SelectedItem) + "' team";
            }
            else
            {
                bool IsSaveCampaign = true;
                if (txtSTime.Text != null && txtSTime.Text != "")
                {
                    if (Convert.ToDateTime(txtETime.Text) < Convert.ToDateTime(txtSTime.Text))
                    {
                        IsSaveCampaign = false;
                        Label1.Text = "End date must be greater than start date";
                    }

                }
                DateTime startDate = DateTime.ParseExact(txtSTime.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DateTime endDate = DateTime.ParseExact(txtETime.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                tblcampaign obj = new tblcampaign();
                obj.campaign_name = txtCName.Text.Trim();
                obj.client_name = Convert.ToString(ddlName.SelectedItem);
                if (Convert.ToString(ListBoxDistrict.SelectedItem).Trim() != null && Convert.ToString(ListBoxDistrict.SelectedItem).Trim() != "")
                    obj.District = Convert.ToString(ListBoxDistrict.SelectedItem).Trim();
                if (Convert.ToString(startDate) != null && Convert.ToString(startDate) != "")
                    obj.end_date = Convert.ToDateTime(endDate);
                if (Convert.ToString(endDate) != null && Convert.ToString(endDate) != "")
                    obj.start_date = Convert.ToDateTime(endDate);
                if (Convert.ToString(ListState.SelectedItem).Trim() != null && Convert.ToString(ListState.SelectedItem).Trim() != "")
                    obj.StateName = Convert.ToString(ListState.SelectedItem).Trim();
                obj.status = false;
                obj.TeamId = ddlName.SelectedValue;
                if (IsSaveCampaign)
                {
                    db.tblcampaigns.InsertOnSubmit(obj);
                    db.SubmitChanges();
                    txtCName.Text = ""; 
                    txtSTime.Text = "";
                    txtETime.Text = "";
                    Label1.Text = "Record Saved Successfully";
                }
            }

        }
    }
    #endregion

    #region Helper Fuction
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ListBoxDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlPincode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlCityName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region Select State Function
    public void SelectState()
    {
        int id = 0;
        ListState.Items.Clear();
        var StateDetail = (from p in db.tblpincodes select new { p.state }).Distinct().OrderBy(m => m.state).ToList();
        if (StateDetail != null && StateDetail.Count > 0)
        {
            foreach (var items in StateDetail)
            {
                id++;
                ListItem item = new ListItem();
                item.Text = items.state;
                item.Value = Convert.ToString(id);
                ListState.Items.Add(item);
            }
        }
    }
    #endregion

    #region Select State For Update Function
    public void SelectStateForUpdate(string CampaignId)
    {
        ListState.Items.Clear();
        var CompaignDetail = (from p in db.tblcampaigns where p.StateName != null && p.StateName != "" && p.campaign_id == Convert.ToInt32(CampaignId) select p).SingleOrDefault();
        if (CompaignDetail != null)
        {
            if (CompaignDetail.StateName != null && CompaignDetail.StateName != "")
            {
                Session["StateName"] = CompaignDetail.StateName;
                ListItem item = new ListItem();
                item.Text = CompaignDetail.StateName;
                item.Value = "1";
                item.Selected = true;
                ListState.Items.Add(item);
                SelectDistrictForUpdate(CompaignDetail.StateName, CampaignId);
            }
        }

        int id = 1;
        var StateDetail = (from p in db.tblpincodes select new { p.state }).Distinct().OrderBy(m => m.state).ToList();
        if (StateDetail != null && StateDetail.Count > 0)
        {
            foreach (var items in StateDetail)
            {
                id++;
                string StateName = items.state;
                string StateName1 = Convert.ToString(Session["StateName"]);
                ListItem item = new ListItem();
                if (StateName != StateName1)
                {
                    item.Text = items.state;
                    item.Value = Convert.ToString(id);
                    ListState.Items.Add(item);
                }
            }
        }
        Session["StateName"] = "";
    }
    #endregion

    #region Select District base on state name
    public void SelectDistrict(string stateName)
    {
        int did = 0;
        if (count == 1)
        {
            ListBoxDistrict.Items.Clear();
        }
        var DistrictList = (from p in db.tblpincodes where p.state.Trim() == stateName.Trim() select new { p.district }).Distinct().OrderBy(m => m.district).ToList();
        if (DistrictList != null && DistrictList.Count > 0)
        {
            foreach (var items in DistrictList)
            {
                did++;
                ListItem item = new ListItem();
                item.Text = items.district;
                item.Value = Convert.ToString(did);
                ListBoxDistrict.Items.Add(item);
            }
        }
    }
    #endregion

    #region Select District base on state name For Update
    public void SelectDistrictForUpdate(string stateName, string CampaignId)
    {
        int did = 1;
        var CompaignDetail = (from p in db.tblcampaigns where p.campaign_id == Convert.ToInt32(CampaignId) select p).SingleOrDefault();
        if (CompaignDetail != null)
        {
            if (CompaignDetail.District != null && CompaignDetail.District != "")
            {
                Session["DistrictName"] = CompaignDetail.District;
                ListItem item = new ListItem();
                item.Text = CompaignDetail.District;
                item.Value = "1";
                item.Selected = true;
                ListBoxDistrict.Items.Add(item);
            }
        }
        if (count == 1)
        {
            ListBoxDistrict.Items.Clear();
        }
        var DistrictList = (from p in db.tblpincodes where p.state.Trim() == stateName.Trim() select new { p.district }).Distinct().OrderBy(m => m.district).ToList();
        if (DistrictList != null && DistrictList.Count > 0)
        {
            foreach (var items in DistrictList)
            {
                string DistrictName = items.district;
                string DistrictName1 = Convert.ToString(Session["DistrictName"]);
                did++;
                if (DistrictName != DistrictName1)
                {
                    ListItem item = new ListItem();
                    item.Text = items.district;
                    item.Value = Convert.ToString(did);
                    ListBoxDistrict.Items.Add(item);
                }
            }
        }

        Session["DistrictName"] = "";
    }
    #endregion


    int count = 0;

    #region Action Change on select state
    protected void ListState_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in ListState.Items)
        {
            if (item.Selected)
            {
                count++;
                string statename = item.Text;
                SelectDistrict(statename);
            }
        }
    }
    #endregion
}