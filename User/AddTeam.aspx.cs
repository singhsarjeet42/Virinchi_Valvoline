using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddTeam : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    //static CheckBox ck = null;
    //static List<CheckBox> listCk = new List<CheckBox>();

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!IsPostBack))
        {
            if (Request.QueryString["cid"] != null && Request.QueryString["cid"].ToString() != "")
            {
                set_value();
            }
            if (BtnSubmit.Text == "Update")
            { }
            else
            {
                SelectState();
            }
        }
    }
    #endregion

    #region set value function
    public void set_value()
    {
        Lteam.Text = "Edit Team";
        LTeam2.Text = "Edit Team";
        Lteam1.Text = "Edit Team";
        BtnSubmit.Text = "Update";
        SqlCommand cmd = new SqlCommand("adminEditTeam", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@team_id", Convert.ToString(Request.QueryString["cid"]));
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adap.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txtName.Text = dt.Rows[0]["name"].ToString();
            txtUName.Text = dt.Rows[0]["team_name"].ToString();
            txtPassword.Text = dt.Rows[0]["password"].ToString();
            txtCPassword.Text = dt.Rows[0]["password"].ToString();
            string stName = dt.Rows[0]["state"].ToString();
            ListState.Items.Insert(0, new ListItem(stName));
        }
        else
        {
            string TeamId = Convert.ToString(Request.QueryString["cid"]);
            if (TeamId != null && TeamId != "")
            {
                var TeamDetail = (from p in db.tblteams where p.team_id == Convert.ToInt32(TeamId) select p).SingleOrDefault();
                if (TeamDetail != null)
                {
                    txtName.Text = TeamDetail.name;
                    txtUName.Text = TeamDetail.team_name;
                    txtPassword.Text = TeamDetail.password;
                    txtCPassword.Text = TeamDetail.password;
                }

            }
            SelectStateForUpdate(TeamId);
        }
    }
    #endregion

    #region Select State For update
    public void SelectStateForUpdate(string TeamId)
    {
        int id = 1;
        ListState.Items.Clear();
        string OldState = "";
        var TeamDetail = (from p in db.tblteams where p.state != null && p.state != "" && p.team_id == Convert.ToInt32(TeamId) select p).SingleOrDefault();
        if (TeamDetail != null)
        {
            if (TeamDetail.state != null && TeamDetail.state != "")
            {
                ListItem item = new ListItem();
                item.Text = TeamDetail.state;
                OldState = TeamDetail.state;
                item.Selected = true;
                item.Value = "1";
                ListState.Items.Add(item);
            }
        }
        var StateDetail = (from p in db.tblpincodes select new { p.state }).Distinct().OrderBy(m => m.state).ToList();
        if (StateDetail != null && StateDetail.Count > 0)
        {
            foreach (var items in StateDetail)
            {
                if (items.state.Trim() != OldState.Trim())
                {
                    id++;
                    ListItem item = new ListItem();
                    item.Text = items.state;
                    item.Value = Convert.ToString(id);
                    ListState.Items.Add(item);
                }
            }
        }
        SelectDistrictForUpdate(OldState, TeamId);
    }
    #endregion

    #region Select State
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

    #region Select District
    public void SelectDistrict(string stateName)
    {
        int did = 0;
        var StateDetail = (from p in db.tblpincodes where p.state == stateName.Trim() select new { p.district }).Distinct().OrderBy(m => m.district).ToList();
        if (count == 1)
        {
            ListBoxDistrict.Items.Clear();
        }
        if (StateDetail != null && StateDetail.Count > 0)
        {
            foreach (var items in StateDetail)
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

    #region Select District for Update
    public void SelectDistrictForUpdate(string stateName, string TeamId)
    {
        int did = 1;
        string OldDistict = "";
        var TeamDetail = (from p in db.tblteams where p.team_id == Convert.ToInt32(TeamId) select p).SingleOrDefault();
        if (TeamDetail != null)
        {
            if (TeamDetail.District != null && TeamDetail.District != "")
            {
                ListItem item = new ListItem();
                item.Text = TeamDetail.District;
                OldDistict = TeamDetail.District;
                item.Selected = true;
                item.Value = "1";
                ListBoxDistrict.Items.Add(item);
            }
        }
        var StateDetail = (from p in db.tblpincodes where p.state == stateName.Trim() select new { p.district }).Distinct().OrderBy(m => m.district).ToList();
        if (count == 1)
        {
            ListBoxDistrict.Items.Clear();
        }
        if (StateDetail != null && StateDetail.Count > 0)
        {
            foreach (var items in StateDetail)
            {
                if (OldDistict != items.district)
                {
                    did++;
                    ListItem item = new ListItem();
                    item.Text = items.district;
                    item.Value = Convert.ToString(did);
                    ListBoxDistrict.Items.Add(item);
                }
            }
        }
    }
    #endregion

    #region Add/Update Team
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (BtnSubmit.Text == "Update")
        {
            int TeamId = Convert.ToInt32(Request.QueryString["cid"]);
            var TeamDeatil = (from p in db.tblteams where p.team_id != TeamId && (p.team_name).ToLower().Trim() == Convert.ToString(txtUName.Text).ToLower().Trim() select p).SingleOrDefault();
            if (TeamDeatil != null)
            {
                Label1.Text = "'" + Convert.ToString(txtUName.Text) + "' as team name already added";
            }
            else
            {
                var TeamDeatilForUpdate = (from p in db.tblteams where p.team_id == TeamId select p).SingleOrDefault();
                if (TeamDeatilForUpdate != null)
                {
                    if (Convert.ToString(ListBoxDistrict.SelectedItem) != null && Convert.ToString(ListBoxDistrict.SelectedItem) != "")
                        TeamDeatilForUpdate.District = Convert.ToString(ListBoxDistrict.SelectedItem);
                    if (Convert.ToString(ListState.SelectedItem) != null && Convert.ToString(ListState.SelectedItem) != "")
                        TeamDeatilForUpdate.state = Convert.ToString(ListState.SelectedItem);
                    TeamDeatilForUpdate.password = Convert.ToString(txtPassword.Text);
                    TeamDeatilForUpdate.name = Convert.ToString(txtName.Text);
                    TeamDeatilForUpdate.status = 0;
                    TeamDeatilForUpdate.user_type = "user";
                    TeamDeatilForUpdate.team_name = Convert.ToString(txtUName.Text);
                    db.SubmitChanges();
                    Label1.Text = "Record Updated Successfully";
                    txtPassword.Text = "";
                    txtName.Text = "";
                    txtUName.Text = "";
                    txtCPassword.Text = "";
                }
            }
           
                Response.Redirect("viewTeam.aspx");
            

        }
        else
        {
            if (Convert.ToString(txtUName.Text) != null && Convert.ToString(txtUName.Text) != "" && Convert.ToString(txtName.Text) != null && Convert.ToString(txtName.Text) != "")
            {
                var TeamDeatil = (from p in db.tblteams where (p.team_name).ToLower().Trim() == Convert.ToString(txtUName.Text).ToLower().Trim() select p).SingleOrDefault();
                if (TeamDeatil != null)
                {
                    Label1.Text = "'" + Convert.ToString(txtUName.Text) + "' as team name already added";
                }
                else
                {

                    tblteam obj = new tblteam();
                    if (Convert.ToString(ListBoxDistrict.SelectedItem) != null && Convert.ToString(ListBoxDistrict.SelectedItem) != "")
                        obj.District = Convert.ToString(ListBoxDistrict.SelectedItem);
                    if (Convert.ToString(ListState.SelectedItem) != null && Convert.ToString(ListState.SelectedItem) != "")
                        obj.state = Convert.ToString(ListState.SelectedItem);
                    obj.password = Convert.ToString(txtPassword.Text);
                    obj.name = Convert.ToString(txtName.Text);
                    obj.status = 0;
                    obj.user_type = "user";
                    obj.team_name = Convert.ToString(txtUName.Text);
                    db.tblteams.InsertOnSubmit(obj);
                    db.SubmitChanges();
                    Label1.Text = "Record Save Successfully";
                    txtPassword.Text = "";
                    txtName.Text = "";
                    txtUName.Text = "";
                    txtCPassword.Text = "";
                }
            }
            else
            {
                Label1.Text = "User name and Team name is required field";
            }
            //con.Open();
            //SqlCommand cmd = new SqlCommand("adminSetTeam", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@name", Convert.ToString(txtName.Text));
            //cmd.Parameters.AddWithValue("@team_name", Convert.ToString(txtUName.Text));
            //cmd.Parameters.AddWithValue("@password", Convert.ToString(txtPassword.Text));
            //cmd.Parameters.AddWithValue("@user_type", "user");
            //cmd.Parameters.AddWithValue("@status", 0);
            //SqlDataAdapter adap = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adap.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    HField.Value = dt.Rows[0]["tmid"].ToString();
            //}
            //con.Close();

            //if (ListBoxDistrict.GetSelectedIndices().Count() == 0)
            //{

            //    con.Open();
            //    string teamid = HField.Value;
            //    foreach (ListItem item in ListState.Items)
            //    {
            //        if (item.Selected)
            //        {
            //            string statename = item.Text;

            //            SqlCommand cmditem = new SqlCommand("adminAddStateTeam", con);
            //            cmditem.CommandType = CommandType.StoredProcedure;
            //            cmditem.Parameters.AddWithValue("@team_id", Convert.ToInt32(teamid));
            //            cmditem.Parameters.AddWithValue("@state", Convert.ToString(statename));
            //            int result = cmditem.ExecuteNonQuery();
            //            if (result > 0)
            //            { }
            //        }
            //    }
            //    con.Close();
            //}
            //else
            //{
            //    foreach (ListItem item in ListState.Items)
            //    {
            //        string teamid = HField.Value;
            //        if (item.Selected)
            //        {
            //            string statename = item.Text;
            //            addLocation(statename, teamid);
            //        }
            //    }
            //}

        }
    }
    #endregion

    #region Helper function
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlPincode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (BtnSubmit.Text == "Submit")
        {

        }
    }
    protected void ListBoxDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    int count = 0;

    #region Action on changing state
    protected void ListStatet_SelectedIndexChanged(object sender, EventArgs e)
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