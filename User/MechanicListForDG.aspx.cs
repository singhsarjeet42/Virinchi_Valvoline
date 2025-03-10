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

public partial class MechanicListForDG : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        BtViewMap.Visible = false;
        if (!IsPostBack)
        {
            DistrictDropDown.Items.Insert(0, new ListItem("Select", "0"));
            Session["SearchState"] = "";
            Session["SearchSegment"] = "";
            Session["SearchDistrict"] = "";
            Session["SearchStartDate"] = Convert.ToDateTime("01/01/1754");
            Session["SearchEndDate"] = Convert.ToDateTime("01/01/9999");
            Grid_Fill();
            GetCity();
            GetSegment();
        }
    }
    #endregion

    #region List Of mechanic for a DG
    public void Grid_Fill()
    {
        var userId = Session["UserId"];
        var MechanicList = (from p in db.tblvalvoline_details
                            join u in db.tblusers on Convert.ToInt16(p.UserId) equals Convert.ToInt16(u.user_id)
                            where p.UserId == userId
                            select new { p.image_url, p.name_of_person, p.district, p.name_of_outlet, p.contact_number, p.city, p.state, p.workshop, p.segment, p.createdOn, p.street_location, p.otp_verification, p.record_input_form, p.id, u.user_name }).OrderBy(m => m.id).ToList();
        if (MechanicList != null && MechanicList.Count > 0)
        {
            if (MechanicList.Count == 1)
                Count.Text = Convert.ToString(MechanicList.Count) + " Mechanic found";
            else
                Count.Text = Convert.ToString(MechanicList.Count) + " Mechanics found";
            DataGridview.DataSource = MechanicList;
            DataGridview.DataBind();
        }
    }
    #endregion

    #region Page Index
    protected void DataGridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataGridview.PageIndex = e.NewPageIndex;
        SearchList();
    }
    #endregion

    #region Link to Excel Sheet
    protected void btnDownloadAllData_Click(object sender, EventArgs e)
    {
        Response.Redirect("ExcelForDG.aspx");
    }
    #endregion

    #region Link for view map
    protected void BtViewMap_Click(object sender, EventArgs e)
    {
        Response.Redirect("../User/ViewMap.aspx?Role=DG");
    }
    #endregion

    #region Get State in dropdown
    public void GetCity()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select distinct state from tblpincode order by state", con);
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        con.Close();
        ddlCity.DataSource = dt;
        ddlCity.DataTextField = "state";
        //ddlCity.DataValueField = "pincode";
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("Select", "0"));
    }
    #endregion

    #region Get segment in dropdown
    public void GetSegment()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select distinct segment from tblsegment where segment !='All' order by segment", con);
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        con.Close();
        ddlSegment.DataSource = dt;
        ddlSegment.DataTextField = "segment";
        //ddlCity.DataValueField = "pincode";
        ddlSegment.DataBind();
        ddlSegment.Items.Insert(0, new ListItem("Select", "0"));
    }
    #endregion

    #region Search Mechanic Button
    protected void BtnAddNew_Click(object sender, EventArgs e)
    {
        SearchList();
    }
    #endregion

    #region List of mechanic for a DG base on search
    public void SearchList()
    {
        Count.Text = "";
        DateTime startDate;
        DateTime endDate;
        string state = ddlCity.SelectedItem.Text;
        string Segment = ddlSegment.SelectedItem.Text;
        string District = "";
        if (DistrictDropDown.SelectedItem.Text != null)
            District = DistrictDropDown.SelectedItem.Text;
        string starttime = txtDate.Text;
        string endtime = TxtFDate.Text;
        if (state == "Select")
            state = "";
        if (Segment == "Select")
            Segment = "";
        if (District == "Select")
            District = "";
        if (txtDate.Text == "")
        {
            startDate = Convert.ToDateTime("01/01/1754");
        }
        else
        {
            string Month = starttime.ToString().Substring(0, 2);
            string Day = starttime.ToString().Substring(3, 2);
            string Year = starttime.ToString().Substring(6, 4);
            starttime = Day + "/" + Month + "/" + Year;
            startDate = Convert.ToDateTime(starttime);
        }

        if (TxtFDate.Text == "")
        {
            endDate = Convert.ToDateTime("01/01/9999");
        }
        else
        {
            string Month = endtime.ToString().Substring(0, 2);
            string Day = endtime.ToString().Substring(3, 2);
            string Year = endtime.ToString().Substring(6, 4);
            endtime = Day + "/" + Month + "/" + Year;
            endDate = Convert.ToDateTime(endtime);
        }
        if (startDate > endDate)
        {
            btnDownloadAllData.Visible = false;
            BtViewMap.Visible = false;
            lblMsg.Visible = true;
            lblMsg.Text = "End date must be greater than start date";
            DataGridview.DataBind();
        }
        else
        {
            Session["SearchDistrict"] = District;
            Session["SearchState"] = state;
            Session["SearchSegment"] = Segment;
            Session["SearchStartDate"] = startDate;
            Session["SearchEndDate"] = endDate;
            var userId = Session["UserId"];
            var MechanicList = (from p in db.tblvalvoline_details
                                join u in db.tblusers on Convert.ToInt16(p.UserId) equals Convert.ToInt16(u.user_id)
                                where p.UserId == userId && (p.segment == Segment || Segment == "") && (p.state == state || state == "") && Convert.ToDateTime(p.createdOn).Date >= startDate.Date && Convert.ToDateTime(p.createdOn).Date <= endDate.Date && (p.district == District || District == "")
                                select new { p.image_url, p.name_of_person, p.district, p.name_of_outlet, p.contact_number, p.city, p.state, p.workshop, p.segment, p.createdOn, p.street_location, p.otp_verification, p.record_input_form, p.id, u.user_name }).OrderBy(m => m.id).ToList();
            if (MechanicList != null && MechanicList.Count > 0)
            {
                if (MechanicList.Count == 1)
                    Count.Text = Convert.ToString(MechanicList.Count) + " Mechanic found";
                else
                    Count.Text = Convert.ToString(MechanicList.Count) + " Mechanics found";

                DataGridview.DataSource = MechanicList;
                lblMsg.Visible = false;
                //BtViewMap.Visible = true;
                btnDownloadAllData.Visible = true;
                btnDownloadAllData.Visible = false;
            }
            else
            {
                BtViewMap.Visible = false;
                lblMsg.Visible = true;
                btnDownloadAllData.Visible = false;
                lblMsg.Text = "No Record Found";
            }
            DataGridview.DataBind();
        }
    }
    #endregion

    #region Get District base on state
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        DistrictDropDown.Items.Clear();
        DistrictDropDown.Items.Insert(0, new ListItem("Select", "0"));
        int did = 1;
        var DistrictList = (from p in db.tblpincodes where p.state.Trim() == Convert.ToString(ddlCity.SelectedItem) select new { p.district }).Distinct().OrderBy(m => m.district).ToList();
        if (DistrictList != null && DistrictList.Count > 0)
        {
            foreach (var items in DistrictList)
            {
                DistrictDropDown.Items.Insert(did, new ListItem(Convert.ToString(items.district), Convert.ToString(did)));
                did++;
            }
        }

    }
    #endregion
}