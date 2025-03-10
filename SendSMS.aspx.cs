using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SendSMS : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();

    #region Page load
    protected void Page_Load(object sender, EventArgs e)
    {
        var UserList = (from p in db.tblusers where p.Roles == "DemandGenerator" && p.MobileNo != null && p.MobileNo != "" select p).ToList();
        if (UserList != null && UserList.Count > 0)
        {
            foreach (var item in UserList)
            {
                var LunchStart_time = DateTime.Parse("15:55");
                var LunchEnd_time = DateTime.Parse("16:05");
                var NightStart_time = DateTime.Parse("21:55");
                var NightEnd_time = DateTime.Parse("22:05");
                var time_now = DateTime.Now;
                DateTime startDateTime = DateTime.Today;
                DateTime endDateTime = DateTime.Now;
                int DailyCount = 0;
                int DailyCountNotVerified = 0;
                int DailyCountVerified = 0;
                int DailyCountUpdated = 0;
                string DailyMessage = "";

                #region Daily SMS to user
                if ((time_now >= LunchStart_time && time_now <= LunchEnd_time) || (time_now >= NightStart_time && time_now <= NightEnd_time))
                {
                    DailyMessage += "Dear " + item.user_name + ", ";

                    #region Total count daily
                    var TotalContactAdded = (from p in db.tblvalvoline_details where p.UserId == Convert.ToString(item.user_id) && p.deleted_on == false select p).ToList();
                    if (TotalContactAdded != null && TotalContactAdded.Count > 0)
                    {
                        foreach (var items in TotalContactAdded)
                        {
                            if (items.createdOn >= startDateTime && items.createdOn <= endDateTime)
                            {
                                DailyCount++;
                            }
                        }
                    }
                    if (DailyCount > 1)
                    {
                        DailyMessage += DailyCount + " contacts";
                    }
                    else
                    {
                        DailyMessage += DailyCount + " contact";
                    }
                    DailyMessage += " have been added by you on " + String.Format(CultureInfo.InvariantCulture, "{0:dd/MM/yyyy}", DateTime.Now) + ",";
                    #endregion

                    #region OTP verified count for daily
                    var TotalContactAddedverified = (from p in db.tblvalvoline_details where p.UserId == Convert.ToString(item.user_id) && p.deleted_on == false && p.otp_verification == true select p).ToList();
                    if (TotalContactAddedverified != null && TotalContactAddedverified.Count > 0)
                    {
                        foreach (var items in TotalContactAddedverified)
                        {
                            if (items.createdOn >= startDateTime && items.createdOn <= endDateTime)
                            {
                                DailyCountVerified++;
                            }
                        }
                    }
                    DailyMessage += " " + DailyCountVerified + " were OTP Verified,";
                    #endregion

                    #region Non OTP verified count for daily
                    var TotalContactAddedNotverified = (from p in db.tblvalvoline_details where p.UserId == Convert.ToString(item.user_id) && p.deleted_on == false && p.otp_verification == false select p).ToList();
                    if (TotalContactAddedNotverified != null && TotalContactAddedNotverified.Count > 0)
                    {
                        foreach (var items in TotalContactAddedNotverified)
                        {
                            if (items.createdOn >= startDateTime && items.createdOn <= endDateTime)
                            {
                                DailyCountNotVerified++;
                            }
                        }
                    }
                    DailyMessage += " " + DailyCountNotVerified + " were Non-Verified,";
                    #endregion

                    #region Updated Count for daily
                    var TotalContactUpdated = (from p in db.tblvalvoline_details where p.UserId == Convert.ToString(item.user_id) && p.deleted_on == false && p.UpdateOn != null select p).ToList();
                    if (TotalContactUpdated != null && TotalContactUpdated.Count > 0)
                    {
                        foreach (var items in TotalContactUpdated)
                        {
                            if (Convert.ToDateTime(items.UpdateOn).Date == DateTime.Now.Date && Convert.ToDateTime(items.UpdateOn).Date > Convert.ToDateTime(items.createdOn).Date)
                            {
                                DailyCountUpdated++;
                            }
                        }
                    }
                    DailyMessage += " " + DailyCountUpdated + " old were updated.";
                    #endregion

                    if (DailyCount > 0 || DailyCountNotVerified > 0 || DailyCountVerified > 0 || DailyCountUpdated > 0)
                        Common.SendSMS(item.MobileNo, DailyMessage);
                }
                #endregion

                string DayOfWeek = (DateTime.Now.DayOfWeek).ToString();
                startDateTime = DateTime.Today.AddDays(-7);
                endDateTime = DateTime.Today.AddDays(-1);
                DailyCount = 0;
                DailyCountNotVerified = 0;
                DailyCountVerified = 0;
                DailyCountUpdated = 0;
                DailyMessage = "";

                #region Weekly SMS to user
                if ((time_now >= LunchStart_time && time_now <= LunchEnd_time))
                {
                    if (DayOfWeek == "Monday")
                    {
                        DailyMessage += "Dear " + item.user_name + ", ";

                        #region Total count Weekly
                        var TotalContactAdded = (from p in db.tblvalvoline_details where p.UserId == Convert.ToString(item.user_id) && p.deleted_on == false select p).ToList();
                        if (TotalContactAdded != null && TotalContactAdded.Count > 0)
                        {
                            foreach (var items in TotalContactAdded)
                            {
                                if (items.createdOn >= startDateTime && items.createdOn <= endDateTime)
                                {
                                    DailyCount++;
                                }
                            }
                        }
                        if (DailyCount > 1)
                        {
                            DailyMessage += DailyCount + " contacts";
                        }
                        else
                        {
                            DailyMessage += DailyCount + " contact";
                        }
                        DailyMessage += " have been added by you last week,";
                        #endregion

                        #region OTP verified count for Weekly
                        var TotalContactAddedverified = (from p in db.tblvalvoline_details where p.UserId == Convert.ToString(item.user_id) && p.deleted_on == false && p.otp_verification == true select p).ToList();
                        if (TotalContactAddedverified != null && TotalContactAddedverified.Count > 0)
                        {
                            foreach (var items in TotalContactAddedverified)
                            {
                                if (items.createdOn >= startDateTime && items.createdOn <= endDateTime)
                                {
                                    DailyCountVerified++;
                                }
                            }
                        }
                        DailyMessage += " " + DailyCountVerified + " were OTP Verified,";
                        #endregion

                        #region Non OTP verified count for Weekly
                        var TotalContactAddedNotverified = (from p in db.tblvalvoline_details where p.UserId == Convert.ToString(item.user_id) && p.deleted_on == false && p.otp_verification == false select p).ToList();
                        if (TotalContactAddedNotverified != null && TotalContactAddedNotverified.Count > 0)
                        {
                            foreach (var items in TotalContactAddedNotverified)
                            {
                                if (items.createdOn >= startDateTime && items.createdOn <= endDateTime)
                                {
                                    DailyCountNotVerified++;
                                }
                            }
                        }
                        DailyMessage += " " + DailyCountNotVerified + " were Non-Verified,";
                        #endregion

                        #region Updated Count for Weekly
                        var TotalContactUpdated = (from p in db.tblvalvoline_details where p.UserId == Convert.ToString(item.user_id) && p.deleted_on == false && p.UpdateOn != null select p).ToList();
                        if (TotalContactUpdated != null && TotalContactUpdated.Count > 0)
                        {
                            foreach (var items in TotalContactUpdated)
                            {
                                if (Convert.ToDateTime(items.UpdateOn).Date > startDateTime && Convert.ToDateTime(items.UpdateOn).Date > Convert.ToDateTime(items.createdOn).Date)
                                {
                                    DailyCountUpdated++;
                                }
                            }
                        }
                        DailyMessage += " " + DailyCountUpdated + " old were updated.";
                        #endregion

                        if (DailyCount > 0 || DailyCountNotVerified > 0 || DailyCountVerified > 0 || DailyCountUpdated > 0)
                            Common.SendSMS(item.MobileNo, DailyMessage);
                    }
                }
                #endregion

                string DateOfTheMonth = (DateTime.Now.Day).ToString();
                int Month = DateTime.Now.Month - 1;
                if (Month == 0)
                    Month = DateTime.Now.Month;
                int DaysInLastMonth = DateTime.DaysInMonth(DateTime.Now.Year, Month);
                startDateTime = DateTime.Today.AddDays(-DaysInLastMonth);
                endDateTime = DateTime.Today.AddDays(-1);
                DailyCount = 0;
                DailyCountNotVerified = 0;
                DailyCountVerified = 0;
                DailyCountUpdated = 0;
                DailyMessage = "";

                #region Monthly SMS to user
                if ((time_now >= LunchStart_time && time_now <= LunchEnd_time))
                {
                    if (DateOfTheMonth == "1")
                    {
                        DailyMessage += "Dear " + item.user_name + ", ";

                        #region Total count Monthly
                        var TotalContactAdded = (from p in db.tblvalvoline_details where p.UserId == Convert.ToString(item.user_id) && p.deleted_on == false select p).ToList();
                        if (TotalContactAdded != null && TotalContactAdded.Count > 0)
                        {
                            foreach (var items in TotalContactAdded)
                            {
                                if (items.createdOn >= startDateTime && items.createdOn <= endDateTime)
                                {
                                    DailyCount++;
                                }
                            }
                        }
                        if (DailyCount > 1)
                        {
                            DailyMessage += DailyCount + " contacts";
                        }
                        else
                        {
                            DailyMessage += DailyCount + " contact";
                        }
                        string CurrentYear = Convert.ToString(DateTime.Now.Year);
                        if (DateTime.Now.Month.ToString() == "1")
                            CurrentYear = Convert.ToString(DateTime.Now.Year - 1);
                        DailyMessage += " have been added by you in " + Convert.ToString(DateTime.Now.AddMonths(-1).ToString("MMMM")) + " " + CurrentYear + " ,";
                        #endregion

                        #region OTP verified count for Monthly
                        var TotalContactAddedverified = (from p in db.tblvalvoline_details where p.UserId == Convert.ToString(item.user_id) && p.deleted_on == false && p.otp_verification == true select p).ToList();
                        if (TotalContactAddedverified != null && TotalContactAddedverified.Count > 0)
                        {
                            foreach (var items in TotalContactAddedverified)
                            {
                                if (items.createdOn >= startDateTime && items.createdOn <= endDateTime)
                                {
                                    DailyCountVerified++;
                                }
                            }
                        }
                        DailyMessage += " " + DailyCountVerified + " were OTP Verified,";
                        #endregion

                        #region Non OTP verified count for Monthly
                        var TotalContactAddedNotverified = (from p in db.tblvalvoline_details where p.UserId == Convert.ToString(item.user_id) && p.deleted_on == false && p.otp_verification == false select p).ToList();
                        if (TotalContactAddedNotverified != null && TotalContactAddedNotverified.Count > 0)
                        {
                            foreach (var items in TotalContactAddedNotverified)
                            {
                                if (items.createdOn >= startDateTime && items.createdOn <= endDateTime)
                                {
                                    DailyCountNotVerified++;
                                }
                            }
                        }
                        DailyMessage += " " + DailyCountNotVerified + " were Non-Verified,";
                        #endregion

                        #region Updated Count for Monthly
                        var TotalContactUpdated = (from p in db.tblvalvoline_details where p.UserId == Convert.ToString(item.user_id) && p.deleted_on == false && p.UpdateOn != null select p).ToList();
                        if (TotalContactUpdated != null && TotalContactUpdated.Count > 0)
                        {
                            foreach (var items in TotalContactUpdated)
                            {
                                if (Convert.ToDateTime(items.UpdateOn).Date > startDateTime && Convert.ToDateTime(items.UpdateOn).Date > Convert.ToDateTime(items.createdOn).Date)
                                {
                                    DailyCountUpdated++;
                                }
                            }
                        }
                        DailyMessage += " " + DailyCountUpdated + " old were updated.";
                        #endregion

                        if (DailyCount > 0 || DailyCountNotVerified > 0 || DailyCountVerified > 0 || DailyCountUpdated > 0)
                            Common.SendSMS(item.MobileNo, DailyMessage);
                    }
                }
                #endregion

            }

        }
    }
    #endregion
}