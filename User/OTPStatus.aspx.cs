using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_OTPStatus : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Grid_Fill();
        }
    }
    #endregion

    #region OTP Status List
    public void Grid_Fill()
    {
        var OTPSTATUSLIST = (from s in db.tblOTPStatus
                             join t in db.tblusers on s.TagId equals Convert.ToString(t.user_id)
                             where Convert.ToDateTime(s.CreatedOn).Date == DateTime.Now.Date
                             select new { s, t.user_name }).OrderByDescending(m => m.s.Id).ToList();
        if (OTPSTATUSLIST != null && OTPSTATUSLIST.Count > 0)
        {
            int count = 0;
            OTPStatusList.Controls.Add(new LiteralControl("<table id='OTPDetail'><thead class='static'><tr><th class='tableTR'>S No.</th><th class='tableTR'>Source User</th><th class='tableTR'>Mobile Number</th><th class='tableTR'>OTP</th> <th class='tableTR'>Gateway Message</th><th class='tableTR'>Created Date</th><th class='tableTR'>Created Time</th></tr></thead>"));
            OTPStatusList.Controls.Add(new LiteralControl("<tfoot><tr><th class='tableTR'>S No.</th><th class='tableTR'>Source User</th><th class='tableTR'>Mobile Number</th><th class='tableTR'>OTP</th> <th class='tableTR'>Gateway Message</th><th class='tableTR'>Created Date</th><th class='tableTR'>Created Time</th></tr></tfoot><tbody>"));
            foreach (var item in OTPSTATUSLIST)
            {
                var MechanicDetail = (from p in db.tblvalvoline_details where Convert.ToString(p.contact_number) == item.s.MobileNumber select new { p.otp_password }).Take(1).SingleOrDefault();

                string OTP = "";
                if (MechanicDetail != null)
                {
                    OTP = MechanicDetail.otp_password;
                }
                count++;
                OTPStatusList.Controls.Add(new LiteralControl("<tr><td>" + count + "</td><td>" + item.user_name + "</td><td>" + item.s.MobileNumber + "</td><td>" + OTP + " </td><td>" + item.s.Message + "</td><td>" + String.Format("{0:ddd, MMM d, yyyy}", item.s.CreatedOn) + "</td><td>" + String.Format("{0:t}", item.s.CreatedOn) + "</td></tr>"));
            }
            OTPStatusList.Controls.Add(new LiteralControl("</tbody></table>"));
            Button3.Visible = true;
        }
        else
        {
            Button3.Visible = false;
        }
    }
    #endregion

    #region Get data by date
    protected void BtnAddNew_Click(object sender, EventArgs e)
    {
        string StartDate = txtDate.Text;
        if (StartDate == null || StartDate == "")
            StartDate = "01/01/1754";
        string EndDate = TxtFDate.Text;
        if (EndDate == null || EndDate == "")
            EndDate = "01/01/9999";

        var OTPSTATUSLIST = (from s in db.tblOTPStatus
                             join t in db.tblusers on s.TagId equals Convert.ToString(t.user_id)
                             where Convert.ToDateTime(s.CreatedOn).Date >= Convert.ToDateTime(StartDate).Date && Convert.ToDateTime(s.CreatedOn).Date <= Convert.ToDateTime(EndDate).Date
                             select new { s, t.user_name }).OrderByDescending(m => m.s.Id).ToList();
        if (OTPSTATUSLIST != null && OTPSTATUSLIST.Count > 0)
        {
            int count = 0;
            OTPStatusList.Controls.Add(new LiteralControl("<table id='OTPDetail' style='width:1060px;'><thead class='static'><tr><th class='tableTR'>S No.</th><th class='tableTR'>Source User</th><th class='tableTR'>Mobile Number</th><th class='tableTR'>OTP</th> <th class='tableTR'>Gateway Message</th><th class='tableTR'>Created Date</th><th class='tableTR'>Created Time</th></tr></thead>"));
            OTPStatusList.Controls.Add(new LiteralControl("<tfoot><tr><th class='tableTR'>S No.</th><th class='tableTR'>Source User</th><th class='tableTR'>Mobile Number</th><th class='tableTR'>OTP</th> <th class='tableTR'>Gateway Message</th><th class='tableTR'>Created Date</th><th class='tableTR'>Created Time</th></tr></tfoot><tbody>"));
            foreach (var item in OTPSTATUSLIST)
            {
                var MechanicDetail = (from p in db.tblvalvoline_details where Convert.ToString(p.contact_number) == item.s.MobileNumber select p).SingleOrDefault();

                string OTP = "";
                if (MechanicDetail != null)
                {
                    OTP = MechanicDetail.otp_password;
                }
                count++;
                OTPStatusList.Controls.Add(new LiteralControl("<tr><td>" + count + "</td><td>" + item.user_name + "</td><td>" + item.s.MobileNumber + "</td><td>" + OTP + " </td><td>" + item.s.Message + "</td><td>" + String.Format("{0:ddd, MMM d, yyyy}", item.s.CreatedOn) + "</td><td>" + String.Format("{0:t}", item.s.CreatedOn) + "</td></tr>"));
            }
            OTPStatusList.Controls.Add(new LiteralControl("</tbody></table>"));
            Button3.Visible = true;
        }
        else
        {
            Button3.Visible = false;
        }
    }
    #endregion

    #region Link to download
    protected void Button3_Click(object sender, EventArgs e)
    {
        string StartDate = txtDate.Text;
        if (StartDate == null || StartDate == "")
            StartDate = "01/01/1754";
        string EndDate = TxtFDate.Text;
        if (EndDate == null || EndDate == "")
            EndDate = "01/01/9999";
        Response.Redirect("../admin/exportexOTPStatus.aspx?starttime=" + Convert.ToDateTime(StartDate) + "&endtime=" + Convert.ToDateTime(EndDate) + "");

    }
    #endregion
}