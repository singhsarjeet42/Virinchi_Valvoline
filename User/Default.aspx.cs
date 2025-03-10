using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["SearchStartDate"] = Convert.ToDateTime("01/01/1754");
        Session["SearchEndDate"] = Convert.ToDateTime("01/01/9999");
        if (HttpContext.Current.User.IsInRole("Admin"))
        {
            Role.Text = "Admin";
        }
        else
            if (HttpContext.Current.User.IsInRole("DemandGenerator"))
            {
                Role.Text = "DemandGenerator";
            }
            else
                if (HttpContext.Current.User.IsInRole("SegmentHead"))
                {
                    Role.Text = "SegmentHead";
                }
                else
                    if (HttpContext.Current.User.IsInRole("SaleHead"))
                    {
                        Role.Text = "SaleHead";
                    }
                    else
                        if (HttpContext.Current.User.IsInRole("StateHead"))
                        {
                            Role.Text = "StateHead";
                        }
       // MapUser();
    }
    #endregion

    #region map User
    public void MapUser()
    {
        var MechanicListNotTag = (from p in db.tblvalvoline_details
                                  join u in db.tblusers on p.imei_no equals u.imei_first
                                  where   p.deleted_on == false
                                  select new { p.id, u.user_id, p.createdOn }).ToList();
        if (MechanicListNotTag != null && MechanicListNotTag.Count > 0)
        {
            foreach (var item in MechanicListNotTag)
            {
                var Single = (from p in db.tblvalvoline_details where p.id == item.id select p).SingleOrDefault();
                if (Single != null)
                {
                    Single.UserId = Convert.ToString(item.user_id);
                    //if (Convert.ToString(Single.UpdateOn) == null || Convert.ToString(Single.UpdateOn) == "")
                    //    Single.UpdateOn = item.createdOn;
                    db.SubmitChanges();
                }
            }
        }
    }
    #endregion


}