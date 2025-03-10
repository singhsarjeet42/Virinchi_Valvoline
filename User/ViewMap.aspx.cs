using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

public partial class ViewMap : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            var Role = Convert.ToString(Request["Role"]);
            if (Role == "DG")
            {
                RoleText.Text = Role;
                string userId = Convert.ToString(Session["UserId"]);
                UserIdText.Text = userId;
                string state = Convert.ToString(Session["SearchState"]);
                stateText.Text = state;
                string Segment = Convert.ToString(Session["SearchSegment"]);
                SegmentText.Text = Segment;
                string startDate = Convert.ToString(Session["SearchStartDate"]);
                startDateText.Text = startDate;
                string endDate = Convert.ToString(Session["SearchEndDate"]);
                endDateText.Text = endDate;
                string district = Convert.ToString(Session["SearchDistrict"]);
                District.Text = district;

            }
            else if (Role == "SaleHead")
            {
                RoleText.Text = Role;
                string state = Convert.ToString(Session["SearchState"]);
                stateText.Text = state;
                string Segment = Convert.ToString(Session["SearchSegment"]);
                SegmentText.Text = Segment;
                string startDate = Convert.ToString(Session["SearchStartDate"]);
                startDateText.Text = startDate;
                string endDate = Convert.ToString(Session["SearchEndDate"]);
                endDateText.Text = endDate;
                string district = Convert.ToString(Session["SearchDistrict"]);
                District.Text = district;
            }
            else if (Role == "StateHead")
            {
                RoleText.Text = Role;
                string userId = Convert.ToString(Session["UserId"]);
                UserIdText.Text = userId;
                string state = Convert.ToString(Session["SearchState"]);
                stateText.Text = state;
                string Segment = Convert.ToString(Session["SearchSegment"]);
                SegmentText.Text = Segment;
                string startDate = Convert.ToString(Session["SearchStartDate"]);
                startDateText.Text = startDate;
                string endDate = Convert.ToString(Session["SearchEndDate"]);
                endDateText.Text = endDate;
                string district = Convert.ToString(Session["SearchDistrict"]);
                District.Text = district;
            }
            else if (Role == "SegmentHead")
            {
                RoleText.Text = Role;
                string userId = Convert.ToString(Session["UserId"]);
                UserIdText.Text = userId;
                string state = Convert.ToString(Session["SearchState"]);
                stateText.Text = state;
                string Segment = Convert.ToString(Session["SearchSegment"]);
                SegmentText.Text = Segment;
                string startDate = Convert.ToString(Session["SearchStartDate"]);
                startDateText.Text = startDate;
                string endDate = Convert.ToString(Session["SearchEndDate"]);
                endDateText.Text = endDate;
                string district = Convert.ToString(Session["SearchDistrict"]);
                District.Text = district;
            }

        }
    }
    #endregion

    #region Get Lat Log
    [WebMethod]
    public static List<tblvalvoline_detail> GetLatLog()
    {
        var UsersDetail = new List<tblvalvoline_detail>();
        ValvolineDBDataContext db = new ValvolineDBDataContext();
        var Detail = (from p in db.tblvalvoline_details where p.deleted_on == false && p.lat != null && p.log != null && p.lat != "" && p.log != "" select new { p.lat, p.log }).ToList();
        if (Detail != null && Detail.Count > 0)
        {
            foreach (var item in Detail)
            {
                tblvalvoline_detail obj = new tblvalvoline_detail();
                obj.lat = item.lat;
                obj.log = item.log;
                UsersDetail.Add(obj);
            }
        }
        return UsersDetail;
    }
    #endregion

    #region Get Lat Log Sale head
    [WebMethod]
    public static List<tblvalvoline_detail> GetLatLogForSaleHead(string State, string Segment, string StartDate, string EndDate, string District)
    {
        DateTime startDate;
        DateTime endDate;
        if (StartDate == "")
        {
            startDate = Convert.ToDateTime("01/01/1754");
        }
        else
        {
            startDate = Convert.ToDateTime(StartDate);
        }

        if (EndDate == "")
        {
            endDate = Convert.ToDateTime("01/01/9999");
        }
        else
        {
            endDate = Convert.ToDateTime(EndDate);
        }
        var UsersDetail = new List<tblvalvoline_detail>();
        ValvolineDBDataContext db = new ValvolineDBDataContext();
        var Detail = (from p in db.tblvalvoline_details where p.lat != null && p.log != null && p.lat != "" && p.log != "" && p.deleted_on == false && (p.segment == Segment || Segment == "") && (p.state == State || State == "") && Convert.ToDateTime(p.createdOn).Date >= startDate.Date && Convert.ToDateTime(p.createdOn).Date <= endDate.Date && (p.district == District || District == "") select new { p.lat, p.log }).ToList();
        if (Detail != null && Detail.Count > 0)
        {
            foreach (var item in Detail)
            {
                tblvalvoline_detail obj = new tblvalvoline_detail();
                obj.lat = item.lat;
                obj.log = item.log;
                UsersDetail.Add(obj);
            }
        }
        return UsersDetail;
    }
    #endregion

    #region Get Lat Log For DG
    [WebMethod]
    public static List<tblvalvoline_detail> GetLatLogForDG(string UserId, string State, string Segment, string StartDate, string EndDate, string District)
    {
        DateTime startDate;
        DateTime endDate;
        if (StartDate == "")
        {
            startDate = Convert.ToDateTime("01/01/1754");
        }
        else
        {
            startDate = Convert.ToDateTime(StartDate);
        }

        if (EndDate == "")
        {
            endDate = Convert.ToDateTime("01/01/9999");
        }
        else
        {
            endDate = Convert.ToDateTime(EndDate);
        }
        var UsersDetail = new List<tblvalvoline_detail>();
        ValvolineDBDataContext db = new ValvolineDBDataContext();
        var Detail = (from p in db.tblvalvoline_details
                      join u in db.tblusers on Convert.ToInt16(p.UserId) equals Convert.ToInt16(u.user_id)
                      where p.lat != null && p.log != null && p.lat != "" && p.log != "" && p.UserId == UserId && p.deleted_on == false && (p.segment == Segment || Segment == "") && (p.state == State || State == "") && Convert.ToDateTime(p.createdOn).Date >= startDate.Date && Convert.ToDateTime(p.createdOn).Date <= endDate.Date && (p.district == District || District == "")
                      select new { p.lat, p.log }).ToList();
        if (Detail != null && Detail.Count > 0)
        {
            foreach (var item in Detail)
            {
                tblvalvoline_detail obj = new tblvalvoline_detail();
                obj.lat = item.lat;
                obj.log = item.log;
                UsersDetail.Add(obj);
            }
        }
        return UsersDetail;
    }
    #endregion

    #region Get Lat Log For State Head
    [WebMethod]
    public static List<tblvalvoline_detail> GetLatLogForStateHead(string UserId, string State, string Segment, string StartDate, string EndDate, string District)
    {
        DateTime startDate;
        DateTime endDate;
        if (StartDate == "")
        {
            startDate = Convert.ToDateTime("01/01/1754");
        }
        else
        {
            startDate = Convert.ToDateTime(StartDate);
        }

        if (EndDate == "")
        {
            endDate = Convert.ToDateTime("01/01/9999");
        }
        else
        {
            endDate = Convert.ToDateTime(EndDate);
        }
        var UsersDetail = new List<tblvalvoline_detail>();
        ValvolineDBDataContext db = new ValvolineDBDataContext();

        var IsStateAll = (from p in db.tblUserStates where p.UserId == Convert.ToInt32(UserId) && p.IsDeleted == false && p.State == "All" select p).SingleOrDefault();
        if (IsStateAll != null)
        {
            #region Get all mechanic list if use have all state access
            var MechanicList = (from p in db.tblvalvoline_details
                                where p.lat != null && p.log != null && p.lat != "" && p.log != "" && p.state != null && p.state != "" && (p.segment == Segment || Segment == "") && (p.state == State || State == "") && Convert.ToDateTime(p.createdOn).Date >= startDate.Date && Convert.ToDateTime(p.createdOn).Date <= endDate.Date && (p.district == District || District == "")
                                select new { p.lat, p.log }).ToList();
            if (MechanicList != null && MechanicList.Count > 0)
            {
                foreach (var item in MechanicList)
                {
                    tblvalvoline_detail obj = new tblvalvoline_detail();
                    obj.lat = item.lat;
                    obj.log = item.log;
                    UsersDetail.Add(obj);
                }
            }
            #endregion
        }
        else
        {
            #region Get mechanic list base on state
            List<string> StateName = new List<string>();
            var StateList = (from p in db.tblUserStates where p.UserId == Convert.ToInt32(UserId) && p.IsDeleted == false select p).ToList();
            if (StateList != null && StateList.Count > 0)
            {
                foreach (var item in StateList)
                {
                    StateName.Add(item.State);
                }
            }
            var MechanicList = (from p in db.tblvalvoline_details
                                where p.lat != null && p.log != null && p.lat != "" && p.log != "" && StateName.Contains(p.state) && p.state != null && p.state != "" && (p.segment == Segment || Segment == "") && (p.state == State || State == "") && Convert.ToDateTime(p.createdOn).Date >= startDate.Date && Convert.ToDateTime(p.createdOn).Date <= endDate.Date && (p.district == District || District == "")
                                select new { p.lat, p.log }).ToList();
            if (MechanicList != null && MechanicList.Count > 0)
            {
                foreach (var item in MechanicList)
                {
                    tblvalvoline_detail obj = new tblvalvoline_detail();
                    obj.lat = item.lat;
                    obj.log = item.log;
                    UsersDetail.Add(obj);
                }
            }
            #endregion
        }
        return UsersDetail;
    }
    #endregion

    #region Get Lat Log For Segment Head
    [WebMethod]
    public static List<tblvalvoline_detail> GetLatLogForSegmentHead(string UserId, string State, string Segment, string StartDate, string EndDate, string District)
    {
        DateTime startDate;
        DateTime endDate;
        if (StartDate == "")
        {
            startDate = Convert.ToDateTime("01/01/1754");
        }
        else
        {
            startDate = Convert.ToDateTime(StartDate);
        }

        if (EndDate == "")
        {
            endDate = Convert.ToDateTime("01/01/9999");
        }
        else
        {
            endDate = Convert.ToDateTime(EndDate);
        }
        var UsersDetail = new List<tblvalvoline_detail>();
        ValvolineDBDataContext db = new ValvolineDBDataContext();

        bool IsSegmentAll = false;
        bool IsStateAll = false;
        List<string> StateName = new List<string>();
        List<string> SegmentName = new List<string>();
        var SegmentAll = (from p in db.tblUserSegments where p.UserId == Convert.ToInt32(UserId) && p.IsDeleted == false && p.Segment == "All" select p).SingleOrDefault();
        if (SegmentAll != null)
        {
            IsSegmentAll = true;
        }
        var StateAll = (from p in db.tblUserStates where p.UserId == Convert.ToInt32(UserId) && p.IsDeleted == false && p.State == "All" select p).SingleOrDefault();
        if (StateAll != null)
        {
            IsStateAll = true;
        }

        if (IsSegmentAll)
        {
            if (IsStateAll)
            {
                #region Mechanic list for segment head if segment is 'All' and state is also 'All'
                var MechanicList = (from p in db.tblvalvoline_details
                                    where p.lat != null && p.log != null && p.lat != "" && p.log != "" && p.state != null && p.state != "" && (p.segment == Segment || Segment == "") && (p.state == State || State == "") && Convert.ToDateTime(p.createdOn).Date >= startDate.Date && Convert.ToDateTime(p.createdOn).Date <= endDate.Date && (p.district == District || District == "")
                                    select new { p.lat, p.log }).ToList();
                if (MechanicList != null && MechanicList.Count > 0)
                {
                    foreach (var item in MechanicList)
                    {
                        tblvalvoline_detail obj = new tblvalvoline_detail();
                        obj.lat = item.lat;
                        obj.log = item.log;
                        UsersDetail.Add(obj);
                    }
                }
                #endregion
            }
            else
            {
                #region Mechanic list for segment head if segment is 'All' and state selected
                var StateList = (from p in db.tblUserStates where p.UserId == Convert.ToInt32(UserId) && p.IsDeleted == false select p).ToList();
                if (StateList != null && StateList.Count > 0)
                {
                    foreach (var item in StateList)
                    {
                        StateName.Add(item.State);
                    }
                }
                var MechanicList = (from p in db.tblvalvoline_details
                                    where p.lat != null && p.log != null && p.lat != "" && p.log != "" && StateName.Contains(p.state) && p.state != null && p.state != "" && (p.segment == Segment || Segment == "") && (p.state == State || State == "") && Convert.ToDateTime(p.createdOn).Date >= startDate.Date && Convert.ToDateTime(p.createdOn).Date <= endDate.Date && (p.district == District || District == "")
                                    select new { p.lat, p.log }).ToList();
                if (MechanicList != null && MechanicList.Count > 0)
                {
                    foreach (var item in MechanicList)
                    {
                        tblvalvoline_detail obj = new tblvalvoline_detail();
                        obj.lat = item.lat;
                        obj.log = item.log;
                        UsersDetail.Add(obj);
                    }
                }
                #endregion
            }
        }
        else
        {
            if (IsStateAll)
            {
                #region Mechanic list for segment head if segment is selected and state is 'All'
                var SegmentList = (from p in db.tblUserSegments where p.UserId == Convert.ToInt32(UserId) && p.IsDeleted == false select p).ToList();
                if (SegmentList != null && SegmentList.Count > 0)
                {
                    foreach (var item in SegmentList)
                    {
                        SegmentName.Add(item.Segment);
                    }
                }
                var MechanicList = (from p in db.tblvalvoline_details
                                    where p.lat != null && p.log != null && p.lat != "" && p.log != "" && SegmentName.Contains(p.segment) && p.state != null && p.state != "" && (p.segment == Segment || Segment == "") && (p.state == State || State == "") && Convert.ToDateTime(p.createdOn).Date >= startDate.Date && Convert.ToDateTime(p.createdOn).Date <= endDate.Date && (p.district == District || District == "")
                                    select new { p.lat, p.log }).ToList();
                if (MechanicList != null && MechanicList.Count > 0)
                {
                    foreach (var item in MechanicList)
                    {
                        tblvalvoline_detail obj = new tblvalvoline_detail();
                        obj.lat = item.lat;
                        obj.log = item.log;
                        UsersDetail.Add(obj);
                    }
                }
                #endregion
            }
            else
            {
                #region Mechanic list for segment head if segment is selected and state also selected
                var StateList = (from p in db.tblUserStates where p.UserId == Convert.ToInt32(UserId) && p.IsDeleted == false select p).ToList();
                if (StateList != null && StateList.Count > 0)
                {
                    foreach (var item in StateList)
                    {
                        StateName.Add(item.State);
                    }
                }
                var SegmentList = (from p in db.tblUserSegments where p.UserId == Convert.ToInt32(UserId) && p.IsDeleted == false select p).ToList();
                if (SegmentList != null && SegmentList.Count > 0)
                {
                    foreach (var item in SegmentList)
                    {
                        SegmentName.Add(item.Segment);
                    }
                }
                var MechanicList = (from p in db.tblvalvoline_details
                                    where p.lat != null && p.log != null && p.lat != "" && p.log != "" && SegmentName.Contains(p.segment) && StateName.Contains(p.state) && p.state != null && p.state != "" && (p.segment == Segment || Segment == "") && (p.state == State || State == "") && Convert.ToDateTime(p.createdOn).Date >= startDate.Date && Convert.ToDateTime(p.createdOn).Date <= endDate.Date && (p.district == District || District == "")
                                    select new { p.lat, p.log }).ToList();
                if (MechanicList != null && MechanicList.Count > 0)
                {
                    foreach (var item in MechanicList)
                    {
                        tblvalvoline_detail obj = new tblvalvoline_detail();
                        obj.lat = item.lat;
                        obj.log = item.log;
                        UsersDetail.Add(obj);
                    }
                }
                #endregion
            }
        }
        return UsersDetail;
    }
    #endregion

}