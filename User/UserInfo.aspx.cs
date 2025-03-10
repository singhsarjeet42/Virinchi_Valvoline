using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserInfo : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        int UserId = Convert.ToInt32(Request["cid"]);
        var UserDetail = (from p in db.tblusers where p.user_id == UserId select p).SingleOrDefault();
        if (UserDetail != null)
        {
            UserName.Text = UserDetail.user_name;
            MobileNumber.Text = UserDetail.MobileNo;
            var SegmentDetail = (from p in db.tblUserSegments where p.UserId == UserId && p.IsDeleted == false select p).ToList();
            if (SegmentDetail != null && SegmentDetail.Count > 0)
            {
                ListOfSegment.Controls.Add(new LiteralControl("<ul>"));
                foreach (var item in SegmentDetail)
                {
                    ListOfSegment.Controls.Add(new LiteralControl("<li>" + item.Segment + "</li>"));
                }
                ListOfSegment.Controls.Add(new LiteralControl("</ul>"));
            }
            var StateDetail = (from p in db.tblUserStates where p.UserId == UserId && p.IsDeleted == false select p).ToList();
            if (StateDetail != null && StateDetail.Count > 0)
            {
                ListOfState.Controls.Add(new LiteralControl("<ul>"));
                foreach (var item in StateDetail)
                {
                    ListOfState.Controls.Add(new LiteralControl("<li>" + item.State + "</li>"));
                }
                ListOfState.Controls.Add(new LiteralControl("</ul>"));
            }
        }
    }
}