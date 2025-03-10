using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TransferMechnic : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            #region User list in drop down from whome mechanic list to be transfer
            FromUser.Items.Insert(0, new ListItem("Select", "NA"));
            var UserList = (from p in db.tblusers
                            join v in db.tblvalvoline_details on p.user_id equals Convert.ToInt32(v.UserId)
                            where p.Roles == "DemandGenerator" && v.UserId != "null"
                            select p).OrderBy(m => m.user_name).Distinct().ToList();
            var count = 0;
            if (UserList != null && UserList.Count > 0)
            {
                foreach (var item in UserList)
                {
                    count++;
                    FromUser.Items.Insert(count, new ListItem(Convert.ToString(item.user_name), Convert.ToString(item.user_id)));
                }
            }
            #endregion

            #region User list in drop down from whome mechanic list to be transfer
            ToUser.Items.Insert(0, new ListItem("Select", "NA"));
            var UserListTo = (from p in db.tblusers
                              where p.Roles == "DemandGenerator"
                              select p).OrderBy(m => m.user_name).ToList();
            var count1 = 0;
            if (UserListTo != null && UserListTo.Count > 0)
            {
                foreach (var item in UserListTo)
                {
                    count1++;
                    ToUser.Items.Insert(count1, new ListItem(Convert.ToString(item.user_name), Convert.ToString(item.user_id)));
                }
            }
            #endregion
        }
    }
    #endregion

    #region Get mechanic list base on user
    protected void FromUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        string UserId = Convert.ToString(FromUser.SelectedValue);
        var MechanicList = (from p in db.tblvalvoline_details where p.UserId == UserId select p).Take(100).ToList();
        if (MechanicList != null && MechanicList.Count > 0)
        {
            int count = 0;
            MechanicListNotMapped.Controls.Add(new LiteralControl("<table id='MechanicListNotMappedDetail'><thead class='static'><tr><th style='width: 20px;' class='tableTR'><input style='width: 20px;height: 20px;' type='checkbox' id='CheckAll' /></th><th class='tableTR'>S No.</th><th class='tableTR'>Mechanic Name</th><th class='tableTR'>Mobile Number</th><th class='tableTR'>City</th><th class='tableTR'>District</th> <th class='tableTR'>State</th><th class='tableTR'>Segment</th></tr></thead>"));
            MechanicListNotMapped.Controls.Add(new LiteralControl("<tfoot><tr><th class='tableTR'></th><th class='tableTR'>S No.</th><th class='tableTR'>Mechanic Name</th><th class='tableTR'>Mobile Number</th><th class='tableTR'>City</th><th class='tableTR'>District</th> <th class='tableTR'>State</th><th class='tableTR'>Segment</th></tr></tfoot><tbody>"));
            foreach (var item in MechanicList)
            {
                count++;
                MechanicListNotMapped.Controls.Add(new LiteralControl("<tr><td><input class=rowchk style='width: 20px;height: 20px;' type='checkbox' id='" + item.id + "' /></td><td>" + count + "</td><td>" + item.name_of_person + "</td><td>" + item.contact_number + "</td><td>" + item.city + " </td><td>" + item.district + " </td><td>" + item.state + "</td><td>" + item.segment + "</td></tr>"));
            }
            MechanicListNotMapped.Controls.Add(new LiteralControl("</tbody></table>"));
        }
       // Loader.Visible = false;
    }
    #endregion

    #region Transfer Mechanic For Selected
    [System.Web.Services.WebMethod]
    public static string TransferMechanicForSelected(string[] SelecteId, string ToUser)
    {
        ValvolineDBDataContext db = new ValvolineDBDataContext();
        for (int i = 0; i < SelecteId.Length; i++)
        {
            var MechanicDetail = (from p in db.tblvalvoline_details where p.id == Convert.ToInt32(SelecteId[i]) select p).SingleOrDefault();
            if (MechanicDetail != null)
            {
                MechanicDetail.UserId = ToUser;
                db.SubmitChanges();
            }
        }

        return "true";
    }
    #endregion

    #region Transer Mechanic List for all
    [System.Web.Services.WebMethod]
    public static string TransferMechanicForAll(string FromUser, string ToUser)
    {
        ValvolineDBDataContext db = new ValvolineDBDataContext();
        string FromUserId = FromUser;
        string ToUserId = ToUser;
        if (ToUserId != null && ToUserId != "" && ToUserId != "NA" && FromUserId != null && FromUserId != "" && FromUserId != "NA")
        {
            if (ToUserId != FromUserId)
            {
                var MechanicList = (from p in db.tblvalvoline_details where p.UserId == FromUserId select p).ToList();
                if (MechanicList != null && MechanicList.Count > 0)
                {
                    foreach (var item in MechanicList)
                    {
                        var SelectSingleRecord = (from p in db.tblvalvoline_details where p.id == item.id select p).SingleOrDefault();
                        if (SelectSingleRecord != null)
                        {
                            SelectSingleRecord.UserId = ToUserId;
                            db.SubmitChanges();
                        }
                    }
                }

            }
        }
        return "true";
    }
    #endregion

    #region get All mechanic added by a user
    protected void GetAll_Click(object sender, EventArgs e)
    {
       // Loader.Visible = true;
        string UserId = Convert.ToString(FromUser.SelectedValue);
        var MechanicList = (from p in db.tblvalvoline_details where p.UserId == UserId select p).ToList();
        if (MechanicList != null && MechanicList.Count > 0)
        {
            int count = 0;
            MechanicListNotMapped.Controls.Add(new LiteralControl("<table id='MechanicListNotMappedDetail'><thead class='static'><tr><th style='width: 20px;' class='tableTR'><input style='width: 20px;height: 20px;' type='checkbox' id='CheckAll' /></th><th class='tableTR'>S No.</th><th class='tableTR'>Mechanic Name</th><th class='tableTR'>Mobile Number</th><th class='tableTR'>City</th><th class='tableTR'>District</th> <th class='tableTR'>State</th><th class='tableTR'>Segment</th></tr></thead>"));
            MechanicListNotMapped.Controls.Add(new LiteralControl("<tfoot><tr><th class='tableTR'></th><th class='tableTR'>S No.</th><th class='tableTR'>Mechanic Name</th><th class='tableTR'>Mobile Number</th><th class='tableTR'>City</th><th class='tableTR'>District</th> <th class='tableTR'>State</th><th class='tableTR'>Segment</th></tr></tfoot><tbody>"));
            foreach (var item in MechanicList)
            {
                count++;
                MechanicListNotMapped.Controls.Add(new LiteralControl("<tr><td><input class=rowchk style='width: 20px;height: 20px;' type='checkbox' id='" + item.id + "' /></td><td>" + count + "</td><td>" + item.name_of_person + "</td><td>" + item.contact_number + "</td><td>" + item.city + " </td><td>" + item.district + " </td><td>" + item.state + "</td><td>" + item.segment + "</td></tr>"));
            }
            MechanicListNotMapped.Controls.Add(new LiteralControl("</tbody></table>"));
        }
        //Loader.Visible = false;
    }
    #endregion
}