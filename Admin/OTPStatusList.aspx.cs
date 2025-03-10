using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OTPStatusList : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
    DateTime startDate;
    DateTime endDate;

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!IsPostBack))
        {
            Grid_Fill();
        }
    }
    #endregion

    #region List of OTP Status
    public void Grid_Fill()
    {
        List<OTPStatus> list = new List<OTPStatus>();
        var OTPSTATUSLIST = (from s in db.tblOTPStatus
                             join t in db.tblusers on s.TagId equals Convert.ToString(t.user_id)
                             where Convert.ToDateTime(s.CreatedOn).Date == DateTime.Now.Date
                             select new { s, t.user_name }).OrderByDescending(m => m.s.Id).ToList();
        if (OTPSTATUSLIST != null && OTPSTATUSLIST.Count > 0)
        {
            foreach (var item in OTPSTATUSLIST)
            {
                OTPStatus obj = new OTPStatus();
                obj.DateTimes = Convert.ToString(item.s.CreatedOn);
                obj.Message = item.s.Message;
                obj.MobileNumber = item.s.MobileNumber;
                var OTPdetail = (from p in db.tblvalvoline_details where Convert.ToString(p.contact_number) == item.s.MobileNumber select p).SingleOrDefault();
                if (OTPdetail != null)
                    obj.OTP = OTPdetail.otp_password;
                obj.SourceOfUser = item.user_name;
                list.Add(obj);
            }
        }
        DataGridview.DataSource = list;
        DataGridview.DataBind();
    }
    #endregion

    #region Get OTP base on search
    protected void BtnAddNew_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        string starttime = txtDate.Text;
        string endtime = TxtFDate.Text;
        if (txtDate.Text == "")
        {
            startDate = Convert.ToDateTime("01/01/1754");
        }
        else
        {
            startDate = Convert.ToDateTime(starttime);
        }

        if (TxtFDate.Text == "")
        {
            endDate = Convert.ToDateTime("01/01/9999");
        }
        else
        {
            endDate = Convert.ToDateTime(endtime);
        }
        lblMsg.Text = "";

        try
        {
            lblMsg.Text = "No Record Found";
            txtDate.Text = "";
            TxtFDate.Text = "";
        }
        catch (Exception ex)
        {
            Grid_Fill();
        }
    }
    #endregion

    protected void DataGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Dcammand")
        {
            con.Open();
            SqlCommand Cmd = new SqlCommand("adminDelValData", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@id", e.CommandArgument);
            int t = Cmd.ExecuteNonQuery();
            if (t > 0)
            {
                //Response.Write("<script>alert('Record is deleted')</script>");
            }
            con.Close();
            Grid_Fill();
        }
    }

    #region Helping function
    protected void DataGridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataGridview.PageIndex = e.NewPageIndex;
        Grid_Fill();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlCampaign_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlTeam_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region Link to download
    protected void Button3_Click(object sender, EventArgs e)
    {
        string StartDate = TxtFDate.Text;
        if (StartDate == null || StartDate == "")
            StartDate = "01/01/1754";
        string EndDate = TxtFDate.Text;
        if (EndDate == null || EndDate == "")
            EndDate = "01/01/9999";
        //Response.Redirect("exportexl.aspx?campaign_id=" + ddlCampaign.SelectedValue + "&state=" + ddlCity.SelectedItem.Text +
        //"&team_name=" + ddlTeam.SelectedItem.Text + "&contact_number=" + txtMobileNumber.Text + "&starttime=" + Convert.ToDateTime(StartDate) +
        //"&endtime=" + Convert.ToDateTime(EndDate) + "");

    }
    #endregion

}