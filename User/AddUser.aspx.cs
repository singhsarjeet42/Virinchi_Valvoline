using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddUser : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

    #region Page load
    protected void Page_Load(object sender, EventArgs e)
    {

        if ((!IsPostBack))
        {
            if (Request.QueryString["cid"] != null && Request.QueryString["cid"].ToString() != "")
            {
                set_value();
            }
            if (BtnSubmit.Text == "Update")
            {
                // txtImei.Enabled = false;
            }
            else
            {
                SetClient();
                SetCampaign();
                SelectState();
                SelectSegment();
            }

        }
    }
    #endregion

    #region set value function
    public void set_value()
    {
        LUser.Text = "Edit User";
        LUser1.Text = "Edit User";
        LUser2.Text = "Edit User";
        BtnSubmit.Text = "Update";
        int UserId = Convert.ToInt32(Request.QueryString["cid"]);
        var UserDetail = (from p in db.tblusers where p.user_id == UserId select p).SingleOrDefault();
        if (UserDetail != null)
        {
            txtETeamMemb.Text = UserDetail.user_name;
            EmailId.Text = UserDetail.EmailId;
            MobileNumber.Text = UserDetail.MobileNo;
            txtPassword.Attributes["value"] = UserDetail.Password;
            txtCPassword.Attributes["value"] = UserDetail.Password;

        }
        SetClientForUpdate(UserId);
        SetCampaignforUpdate(UserId);
        SelectStateForUpdate(UserId);
        SetRoleForUpdate(UserId);
        SetSegmentForUpdate(UserId);
    }
    #endregion

    #region Get Team List On Page Load in dropdown
    public void SetClient()
    {
        ddlClientName.Items.Insert(0, new ListItem("Select", "NA"));
        var TeamList = (from p in db.tblteams where p.user_type != "Admin" select p).OrderBy(m => m.team_name).ToList();
        var count = 0;
        if (TeamList != null && TeamList.Count > 0)
        {
            foreach (var item in TeamList)
            {
                count++;
                ddlClientName.Items.Insert(count, new ListItem(Convert.ToString(item.team_name), Convert.ToString(item.team_id)));
            }
        }
    }
    #endregion

    #region Set Role For Update
    public void SetRoleForUpdate(int UserId)
    {

        var UserDetail = (from u in db.tblusers where u.user_id == UserId select u).SingleOrDefault();
        if (UserDetail != null)
        {
            if (UserDetail.Roles != null && UserDetail.Roles != "")
            {
                UserRole.Items.Clear();
                if (UserDetail.Roles == "SaleHead")
                {
                    UserRole.Items.Insert(0, new ListItem("Sale Head", Convert.ToString(UserDetail.Roles)));
                    UserRole.Items.Insert(1, new ListItem("State Head", "StateHead"));
                    UserRole.Items.Insert(2, new ListItem("Segment Head", "SegmentHead"));
                    UserRole.Items.Insert(3, new ListItem("Demand Generator", "DemandGenerator"));
                }
                if (UserDetail.Roles == "StateHead")
                {
                    UserRole.Items.Insert(0, new ListItem("State Head", Convert.ToString(UserDetail.Roles)));
                    UserRole.Items.Insert(1, new ListItem("Sale Head", "SaleHead"));
                    UserRole.Items.Insert(2, new ListItem("Segment Head", "SegmentHead"));
                    UserRole.Items.Insert(3, new ListItem("Demand Generator", "DemandGenerator"));
                }
                if (UserDetail.Roles == "SegmentHead")
                {
                    UserRole.Items.Insert(0, new ListItem("Segment Head", Convert.ToString(UserDetail.Roles)));
                    UserRole.Items.Insert(1, new ListItem("State Head", "StateHead"));
                    UserRole.Items.Insert(2, new ListItem("Sale Head", "SaleHead"));
                    UserRole.Items.Insert(3, new ListItem("Demand Generator", "DemandGenerator"));
                }
                if (UserDetail.Roles == "DemandGenerator")
                {
                    UserRole.Items.Insert(0, new ListItem("Demand Generator", Convert.ToString(UserDetail.Roles)));
                    UserRole.Items.Insert(1, new ListItem("State Head", "StateHead"));
                    UserRole.Items.Insert(2, new ListItem("Segment Head", "SegmentHead"));
                    UserRole.Items.Insert(3, new ListItem("Sale Head", "SaleHead"));
                }
            }
        }


    }
    #endregion

    #region Get Team List in dropdown For Update
    public void SetClientForUpdate(int UserId)
    {
        string TeamId = "";
        var TeamDetail = (from t in db.tblteams join u in db.tblusers on t.team_id equals u.team_id where u.user_id == UserId select new { t.team_name, t.team_id }).SingleOrDefault();
        if (TeamDetail != null)
        {
            TeamId = Convert.ToString(TeamDetail.team_id);
            ddlClientName.Items.Insert(0, new ListItem(TeamDetail.team_name, Convert.ToString(TeamDetail.team_id)));
        }
        var TeamList = (from p in db.tblteams where p.user_type != "Admin" select p).OrderBy(m => m.team_name).ToList();
        var count = 0;
        if (TeamList != null && TeamList.Count > 0)
        {
            foreach (var item in TeamList)
            {
                if (TeamId != Convert.ToString(item.team_id))
                {
                    count++;
                    ddlClientName.Items.Insert(count, new ListItem(Convert.ToString(item.team_name), Convert.ToString(item.team_id)));
                }
            }
        }
    }
    #endregion

    #region Get Campaign list on page load in dropdown
    public void SetCampaign()
    {
        ddlCamName.Items.Insert(0, new ListItem("Select", "NA"));
        var CampaignList = (from p in db.tblcampaigns select p).OrderBy(m => m.campaign_name).ToList();
        var count = 0;
        if (CampaignList != null && CampaignList.Count > 0)
        {
            foreach (var item in CampaignList)
            {
                count++;
                ddlCamName.Items.Insert(count, new ListItem(Convert.ToString(item.campaign_name), Convert.ToString(item.campaign_id)));
            }
        }
    }
    #endregion

    #region Get Campaign list for update
    public void SetCampaignforUpdate(int UserId)
    {
        string CampaignId = "";
        var CampaignDetail = (from c in db.tblcampaigns join u in db.tblusers on c.campaign_id equals u.campaign_id where u.user_id == UserId select new { c.campaign_id, c.campaign_name }).SingleOrDefault();
        if (CampaignDetail != null)
        {
            CampaignId = Convert.ToString(CampaignDetail.campaign_id);
            ddlCamName.Items.Insert(0, new ListItem(CampaignDetail.campaign_name, Convert.ToString(CampaignDetail.campaign_id)));
        };
        var CampaignList = (from p in db.tblcampaigns select p).OrderBy(m => m.campaign_name).ToList();
        var count = 0;
        if (CampaignList != null && CampaignList.Count > 0)
        {
            foreach (var item in CampaignList)
            {
                if (CampaignId != Convert.ToString(item.campaign_id))
                {
                    count++;
                    ddlCamName.Items.Insert(count, new ListItem(Convert.ToString(item.campaign_name), Convert.ToString(item.campaign_id)));
                }
            }
        }
    }
    #endregion

    #region Save and Update
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        Loader.Visible = true;
        if (BtnSubmit.Text == "Update")
        {
            string OldPassword = "";
            #region Update User
            int UserId = Convert.ToInt32(Request.QueryString["cid"]);
            var MobileNo = MobileNumber.Text.Trim();
            var UserDetails = (from p in db.tblusers where p.user_id == UserId select p).SingleOrDefault();
            if (UserDetails != null)
            {
                OldPassword = UserDetails.Password;
                var UserDetail = (from p in db.tblusers where p.MobileNo == MobileNo && p.user_id != UserId select p).SingleOrDefault();
                if (UserDetail != null)
                {
                    Label1.Text = "This mobile number already registered, please enter different mobile number";
                    MobileNumber.Text = "";
                    set_value();
                }
                else
                {
                    UserDetail = (from p in db.tblusers where p.EmailId == EmailId.Text.Trim() && p.user_id != UserId select p).SingleOrDefault();
                    if (UserDetail != null)
                    {
                        Label1.Text = "This email id already registered, please enter different email id";
                        set_value();
                    }
                    else
                    {
                        bool IsSave = true;
                        if (IsSave)
                        {
                            Label1.Text = "Record updated successfully";
                            // System.Threading.Thread.Sleep(10000);
                            UserDetails.campaign_id = Convert.ToInt32(ddlCamName.SelectedValue);
                            UserDetails.MobileNo = MobileNo;
                            UserDetails.Password = txtPassword.Text.Trim();
                            UserDetails.EmailId = EmailId.Text.Trim();
                            UserDetails.Roles = UserRole.SelectedValue;
                            UserDetails.team_id = Convert.ToInt32(ddlClientName.SelectedValue);
                            UserDetails.user_name = txtETeamMemb.Text.Trim();
                            db.SubmitChanges();

                            #region Update State for a user
                            List<int> SelectedState = ListState.GetSelectedIndices().ToList();
                            for (int i = 0; i < SelectedState.Count; i++)
                            {
                                bool IsToBeDelete = true;
                                ListItem StateName = ListState.Items[SelectedState[i]];
                                var StateAdded = (from p in db.tblUserStates where p.UserId == UserId && p.State == StateName.Text && p.IsDeleted == false select p).SingleOrDefault();
                                if (StateAdded != null)
                                {
                                }
                                else
                                {
                                    #region delete all state for a user if 'All' selected or delete 'All' if other state is select
                                    if (StateName.Text == "All")
                                    {
                                        var StateToBeDelete = (from p in db.tblUserStates where p.UserId == UserId && p.IsDeleted == false select p).ToList();
                                        if (StateToBeDelete != null && StateToBeDelete.Count > 0)
                                        {
                                            foreach (var item in StateToBeDelete)
                                            {
                                                var getSinglerecord = (from p in db.tblUserStates where p.Id == item.Id select p).SingleOrDefault();
                                                if (getSinglerecord != null)
                                                {
                                                    getSinglerecord.IsDeleted = true;
                                                    db.SubmitChanges();
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (IsToBeDelete)
                                        {
                                            var getSinglerecord = (from p in db.tblUserStates where p.UserId == UserId && p.State == "All" && p.IsDeleted == false select p).SingleOrDefault();
                                            if (getSinglerecord != null)
                                            {
                                                getSinglerecord.IsDeleted = true;
                                                db.SubmitChanges();
                                            }
                                        }
                                    }
                                    #endregion

                                    tblUserState obj1 = new tblUserState();
                                    obj1.CreatedOn = DateTime.Now;
                                    obj1.IsDeleted = false;
                                    obj1.State = StateName.Text;
                                    obj1.UserId = UserDetails.user_id;
                                    db.tblUserStates.InsertOnSubmit(obj1);
                                    db.SubmitChanges();
                                    if (StateName.Text == "All")
                                    {
                                        break;
                                    }
                                }

                            }
                            #endregion

                            #region Update Segment for a user
                            List<int> SelectedSegment = Segment.GetSelectedIndices().ToList();

                            for (int i = 0; i < SelectedSegment.Count; i++)
                            {
                                bool IsToBeDelete = true;
                                ListItem SegmentName = Segment.Items[SelectedSegment[i]];
                                var SegmentAdded = (from p in db.tblUserSegments where p.UserId == UserId && p.Segment == SegmentName.Text && p.IsDeleted == false select p).SingleOrDefault();
                                if (SegmentAdded != null)
                                {
                                }
                                else
                                {

                                    #region delete all segment for a user if 'All' selected or delete 'All' if other segment is select
                                    if (SegmentName.Text == "All")
                                    {
                                        var SegmentToBeDelete = (from p in db.tblUserSegments where p.UserId == UserId && p.IsDeleted == false select p).ToList();
                                        if (SegmentToBeDelete != null && SegmentToBeDelete.Count > 0)
                                        {
                                            foreach (var item in SegmentToBeDelete)
                                            {
                                                var getSinglerecord = (from p in db.tblUserSegments where p.Id == item.Id select p).SingleOrDefault();
                                                if (getSinglerecord != null)
                                                {
                                                    getSinglerecord.IsDeleted = true;
                                                    db.SubmitChanges();
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (IsToBeDelete)
                                        {
                                            var getSinglerecord = (from p in db.tblUserSegments where p.UserId == UserId && p.Segment == "All" && p.IsDeleted == false select p).SingleOrDefault();
                                            if (getSinglerecord != null)
                                            {
                                                getSinglerecord.IsDeleted = true;
                                                db.SubmitChanges();
                                            }
                                        }
                                    }
                                    #endregion

                                    tblUserSegment obj2 = new tblUserSegment();
                                    IsToBeDelete = false;
                                    obj2.CreatedOn = DateTime.Now;
                                    obj2.IsDeleted = false;
                                    obj2.Segment = SegmentName.Text;
                                    obj2.UserId = UserDetails.user_id;
                                    db.tblUserSegments.InsertOnSubmit(obj2);
                                    db.SubmitChanges();
                                    if (SegmentName.Text == "All")
                                    {
                                        break;
                                    }
                                }
                            }
                            #endregion

                            #region Send Password to email id and mobile
                            if (OldPassword != txtPassword.Text.Trim())
                            {
                                string Body = "";
                                Body += "<p>Welcome " + txtETeamMemb.Text.Trim() + "</p>";
                                Body += "<p style='padding-left: 40px;'></p></br>";
                                Body += "<p>Your Username : " + UserDetails.EmailId + "</p>";
                                Body += "<p>Your Password : " + txtPassword.Text.Trim() + "</p></br>";
                                Body += "<p>Please feel free to contact us in case you have any difficulty in Logging in with these credentials.</P></br>";
                                Common.SendUserMailFromValvoline(UserDetails.EmailId, Body, "Login Credentials for Atoot Bandhan");
                                string Message = "";
                                Message += "Welcome " + txtETeamMemb.Text.Trim() + "\nYour Atoot Bandhan User Name:" + UserDetails.EmailId + "\nYour Password:" + txtPassword.Text.Trim();
                                Common.SendSMS(Convert.ToString(MobileNo), Message);
                            }
                            #endregion

                            //Response.Redirect("ViewUser.aspx");
                        }
                    }
                }
            }

            #endregion
        }
        else
        {
            #region Add User
            var MobileNo = MobileNumber.Text.Trim();
            var UserDetail = (from p in db.tblusers where p.MobileNo == MobileNo select p).SingleOrDefault();
            if (UserDetail != null)
            {
                Label1.Text = "This mobile number already registered, please enter different mobile number";
                MobileNumber.Text = "";
            }
            else
            {
                UserDetail = (from p in db.tblusers where p.EmailId == EmailId.Text.Trim() select p).SingleOrDefault();
                if (UserDetail != null)
                {
                    Label1.Text = "This email id already registered, please enter different email id";
                    EmailId.Text = "";
                }
                else
                {
                    bool IsSave = true;
                    List<int> SelectedState = ListState.GetSelectedIndices().ToList();
                    if (SelectedState.Count == 0)
                    {
                        IsSave = false;
                        Label1.Text = "Please select state";
                    }
                    if (IsSave)
                    {
                        tbluser obj = new tbluser();
                        obj.campaign_id = Convert.ToInt32(ddlCamName.SelectedValue);
                        obj.createdOn = DateTime.Now;
                        obj.MobileNo = MobileNo;
                        obj.Password = txtPassword.Text.Trim();
                        obj.Roles = UserRole.SelectedValue;
                        obj.status = false;
                        obj.EmailId = EmailId.Text.Trim();
                        obj.team_id = Convert.ToInt32(ddlClientName.SelectedValue);
                        obj.user_name = txtETeamMemb.Text.Trim();
                        obj.imei_first = MobileNo + obj.campaign_id;
                        db.tblusers.InsertOnSubmit(obj);
                        db.SubmitChanges();
                        UserDetail = (from p in db.tblusers where p.MobileNo == MobileNo select p).SingleOrDefault();
                        if (UserDetail != null)
                        {
                            for (int i = 0; i < SelectedState.Count; i++)
                            {
                                ListItem StateName = ListState.Items[SelectedState[i]];
                                tblUserState obj1 = new tblUserState();
                                obj1.CreatedOn = DateTime.Now;
                                obj1.IsDeleted = false;
                                obj1.State = StateName.Text;
                                obj1.UserId = UserDetail.user_id;
                                db.tblUserStates.InsertOnSubmit(obj1);
                                db.SubmitChanges();
                                if (StateName.Text == "All")
                                    break;

                            }
                            List<int> SelectedSegment = Segment.GetSelectedIndices().ToList();

                            for (int i = 0; i < SelectedSegment.Count; i++)
                            {
                                ListItem SegmentName = Segment.Items[SelectedSegment[i]];
                                tblUserSegment obj2 = new tblUserSegment();
                                obj2.CreatedOn = DateTime.Now;
                                obj2.IsDeleted = false;
                                obj2.Segment = SegmentName.Text;
                                obj2.UserId = UserDetail.user_id;
                                db.tblUserSegments.InsertOnSubmit(obj2);
                                db.SubmitChanges();
                                if (SegmentName.Text == "All")
                                    break;
                            }
                        }


                        #region Send Password to email id and mobile
                        string Body = "";
                        Body += "<p>Welcome " + txtETeamMemb.Text.Trim() + "</p>";
                        Body += "<p style='padding-left: 40px;'></p></br>";
                        Body += "<p>Your Username : " + EmailId.Text.Trim() + "</p>";
                        Body += "<p>Your Password : " + txtPassword.Text.Trim() + "</p></br>";
                        Body += "<p>Please feel free to contact us in case you have any difficulty in Logging in with these credentials.</P></br>";
                        Common.SendUserMailFromValvoline(EmailId.Text, Body, "Login Credentials for Atoot Bandhan");
                        string Message = "";
                        Message += "Welcome " + txtETeamMemb.Text.Trim() + "\nYour Atoot Bandhan User Name:" + EmailId.Text.Trim() + "\nYour Password:" + txtPassword.Text.Trim();
                        Common.SendSMS(Convert.ToString(MobileNo), Message);
                        #endregion

                        Label1.Text = "Record  save successfully";
                        txtETeamMemb.Text = "";
                        txtPassword.Text = "";
                        txtCPassword.Text = "";
                        MobileNumber.Text = "";
                        EmailId.Text = "";
                        SelectState();
                    }
                }
            }
            #endregion
        }
        //System.Threading.Thread.Sleep(10000);
        //Label1.Text = "";
        Loader.Visible = false;
    }
    #endregion

    #region Helper Function
    protected void ddlCityName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlPincode_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void ListBoxDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region State list on page load in dropdown
    public void SelectState()
    {
        ListState.Items.Clear();
        ListItem item = new ListItem();
        item.Text = "All";
        item.Value = "0";
        ListState.Items.Add(item);
        int id = 1;

        var StateDetail = (from p in db.tblpincodes select new { p.state }).Distinct().OrderBy(m => m.state).ToList();
        if (StateDetail != null && StateDetail.Count > 0)
        {
            foreach (var items in StateDetail)
            {
                id++;
                item = new ListItem();
                item.Text = items.state;
                item.Value = Convert.ToString(id);
                ListState.Items.Add(item);
            }
        }
    }
    #endregion

    #region Segment list on page load in dropdown
    public void SelectSegment()
    {
        int id = 0;
        Segment.Items.Clear();
        var SegmentDetail = (from p in db.tblsegments select new { p.segment }).Distinct().OrderBy(m => m.segment).ToList();
        if (SegmentDetail != null && SegmentDetail.Count > 0)
        {
            foreach (var items in SegmentDetail)
            {
                if (items.segment == "All")
                {
                    id++;
                    ListItem item = new ListItem();
                    item.Text = items.segment;
                    item.Value = Convert.ToString(id);
                    item.Selected = true;
                    Segment.Items.Add(item);
                }
                else
                {
                    id++;
                    ListItem item = new ListItem();
                    item.Text = items.segment;
                    item.Value = Convert.ToString(id);
                    Segment.Items.Add(item);
                }
            }
        }
    }
    #endregion

    #region Segment list in dropdown for update
    public void SetSegmentForUpdate(int UserId)
    {
        int id = 0;
        Segment.Items.Clear();
        var SegmengDetail = (from u in db.tblusers
                             join s in db.tblUserSegments on u.user_id equals s.UserId
                             where u.user_id == UserId && s.Segment != null && s.Segment != "" && s.IsDeleted == false
                             select new { s.Segment }).ToList();
        if (SegmengDetail != null && SegmengDetail.Count > 0)
        {
            foreach (var items in SegmengDetail)
            {
                id++;
                ListItem item = new ListItem();
                item.Text = items.Segment;
                item.Value = Convert.ToString(id);
                item.Selected = true;
                Segment.Items.Add(item);
            }
        };

        var SegmentDetail = (from p in db.tblsegments select new { p.segment }).Distinct().OrderBy(m => m.segment).ToList();
        if (SegmentDetail != null && SegmentDetail.Count > 0)
        {
            foreach (var items in SegmentDetail)
            {
                var SegmengDetailForUser = (from u in db.tblusers
                                            join s in db.tblUserSegments on u.user_id equals s.UserId
                                            where u.user_id == UserId && s.Segment != null && s.Segment != "" && s.Segment == items.segment && s.IsDeleted == false
                                            select new { s.Segment }).SingleOrDefault();
                if (SegmengDetailForUser != null)
                {

                }
                else
                {
                    id++;
                    ListItem item = new ListItem();
                    item.Text = items.segment;
                    item.Value = Convert.ToString(id);
                    Segment.Items.Add(item);
                }
            }
        }
    }
    #endregion

    #region State list in dropdown for Update
    public void SelectStateForUpdate(int UserId)
    {
        #region Map User mapped state
        int id = 0; ;
        ListState.Items.Clear();
        var StateDetails = (from u in db.tblusers
                            join s in db.tblUserStates on u.user_id equals s.UserId
                            where u.user_id == UserId && s.State != null && s.State != "" && s.IsDeleted == false
                            select new { s.State }).ToList();
        if (StateDetails != null)
        {
            foreach (var items in StateDetails)
            {
                id++;
                ListItem item = new ListItem();
                item.Text = items.State;
                item.Value = Convert.ToString(id);
                item.Selected = true;
                ListState.Items.Add(item);
            }
        };
        #endregion

        #region Map 'All' As State
        var IsAllStateMapped = (from p in db.tblUserStates where p.UserId == UserId && p.State == "All" && p.IsDeleted == false select p).SingleOrDefault();
        if (IsAllStateMapped != null)
        {
        }
        else
        {
            id++;
            ListItem itemall = new ListItem();
            itemall.Text = "All";
            itemall.Value = Convert.ToString(id);
            ListState.Items.Add(itemall);
        }
        #endregion

        #region Map Rest of the state
        var StateDetail = (from p in db.tblpincodes select new { p.state }).Distinct().OrderBy(m => m.state).ToList();
        if (StateDetail != null && StateDetail.Count > 0)
        {

            foreach (var items in StateDetail)
            {
                var StateDetailForUser = (from u in db.tblusers
                                          join s in db.tblUserStates on u.user_id equals s.UserId
                                          where u.user_id == UserId && s.State != null && s.State != "" && s.State == items.state
                                          select new { s.State }).SingleOrDefault();
                if (StateDetailForUser != null)
                { }
                else
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
    }
    #endregion

    #region District List base on state name
    public void SelectDistrict(string stateName)
    {
        int did = 0;
        if (count == 1)
        {
            //ListBoxDistrict.Items.Clear();
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
                //ListBoxDistrict.Items.Add(item);
            }
        }
    }
    #endregion

    #region District List state name for Update
    public void SelectDistrictForUpdate(string stateName, int UserId)
    {
        string DistrictName = "";
        var DistrictDetails = (from u in db.tblusers where u.user_id == UserId select new { u.District }).SingleOrDefault();
        if (DistrictDetails != null)
        {
            DistrictName = Convert.ToString(DistrictDetails.District);
            ListItem item = new ListItem();
            item.Text = DistrictDetails.District;
            item.Value = "1";
            item.Selected = true;
            // ListBoxDistrict.Items.Add(item);
        };
        int did = 0;
        if (count == 1)
        {
            //ListBoxDistrict.Items.Clear();
        }
        var DistrictList = (from p in db.tblpincodes where p.state.Trim() == stateName.Trim() select new { p.district }).Distinct().OrderBy(m => m.district).ToList();
        if (DistrictList != null && DistrictList.Count > 0)
        {
            foreach (var items in DistrictList)
            {
                if (DistrictName != items.district)
                {
                    did++;
                    ListItem item = new ListItem();
                    item.Text = items.district;
                    item.Value = Convert.ToString(did);
                    //ListBoxDistrict.Items.Add(item);
                }
            }
        }
    }
    #endregion

    int count = 0;

    #region Action for changing state
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
