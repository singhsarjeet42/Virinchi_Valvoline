using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_MechanicListNotTag : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetUserList();
            Grid_Fill();
        }
    }
    #endregion

    #region List Of mechanic for a DG
    public void Grid_Fill()
    {
        //Loader.Visible = true;
        var MechanicList = (from p in db.tblvalvoline_details
                            where (p.UserId == null || p.UserId == "null")
                            select new { p.name_of_person, p.district, p.name_of_outlet, p.contact_number, p.city, p.state, p.workshop, p.segment, p.preferred_retailer, p.organization_source, p.otp_verification, p.record_input_form, p.id }).OrderBy(m => m.id).Take(100).ToList();
        if (MechanicList != null && MechanicList.Count > 0)
        {
            int count = 0;
            MechanicListNotMapped.Controls.Add(new LiteralControl("<table id='MechanicListNotMappedDetail'><thead class='static'><tr><th style='width: 20px;' class='tableTR'><input style='width: 20px;height: 20px;' type='checkbox' id='CheckAll' /></th><th class='tableTR'>S No.</th><th class='tableTR'>Mechanic Name</th><th class='tableTR'>Mobile Number</th><th class='tableTR'>City</th> <th class='tableTR'>State</th><th class='tableTR'>Segment</th></tr></thead>"));
            MechanicListNotMapped.Controls.Add(new LiteralControl("<tfoot><tr><th class='tableTR'></th><th class='tableTR'>S No.</th><th class='tableTR'>Mechanic Name</th><th class='tableTR'>Mobile Number</th><th class='tableTR'>City</th> <th class='tableTR'>State</th><th class='tableTR'>Segment</th></tr></tfoot><tbody>"));
            foreach (var item in MechanicList)
            {

                count++;
                MechanicListNotMapped.Controls.Add(new LiteralControl("<tr><td><input class=rowchk style='width: 20px;height: 20px;' type='checkbox' id='" + item.id + "' /></td><td>" + count + "</td><td>" + item.name_of_person + "</td><td>" + item.contact_number + "</td><td>" + item.city + " </td><td>" + item.state + "</td><td>" + item.segment + "</td></tr>"));
            }
            MechanicListNotMapped.Controls.Add(new LiteralControl("</tbody></table>"));
        }
        //Loader.Visible = false;
    }
    #endregion

    #region Get User List (DG)
    protected void GetUserList()
    {
        UserList.Items.Clear();
        UserList.Items.Insert(0, new ListItem("Select", "0"));
        int did = 1;
        var UserListDetail = (from p in db.tblusers where p.Roles == "DemandGenerator" select new { p.user_name, p.user_id }).Distinct().OrderBy(m => m.user_name).ToList();
        if (UserListDetail != null && UserListDetail.Count > 0)
        {
            foreach (var items in UserListDetail)
            {
                UserList.Items.Insert(did, new ListItem(Convert.ToString(items.user_name), Convert.ToString(items.user_id)));
                did++;
            }
        }

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

    #region Get all Transfer
    protected void GetAll_Click(object sender, EventArgs e)
    {
        // Loader.Visible = true;
        var MechanicList = (from p in db.tblvalvoline_details
                            where (p.UserId == null || p.UserId == "null")
                            select new { p.name_of_person, p.district, p.name_of_outlet, p.contact_number, p.city, p.state, p.workshop, p.segment, p.preferred_retailer, p.organization_source, p.otp_verification, p.record_input_form, p.id }).OrderBy(m => m.id).ToList();
        if (MechanicList != null && MechanicList.Count > 0)
        {
            int count = 0;
            MechanicListNotMapped.Controls.Add(new LiteralControl("<table id='MechanicListNotMappedDetail' style='width: 1000px;'><thead class='static'><tr><th style='width: 20px;' class='tableTR'><input style='width: 20px;height: 20px;' type='checkbox' id='CheckAll' /></th><th class='tableTR'>S No.</th><th class='tableTR'>Mechanic Name</th><th class='tableTR'>Mobile Number</th><th class='tableTR'>City</th> <th class='tableTR'>State</th><th class='tableTR'>Segment</th></tr></thead>"));
            MechanicListNotMapped.Controls.Add(new LiteralControl("<tfoot><tr><th class='tableTR'></th><th class='tableTR'>S No.</th><th class='tableTR'>Mechanic Name</th><th class='tableTR'>Mobile Number</th><th class='tableTR'>City</th> <th class='tableTR'>State</th><th class='tableTR'>Segment</th></tr></tfoot><tbody>"));
            foreach (var item in MechanicList)
            {

                count++;
                MechanicListNotMapped.Controls.Add(new LiteralControl("<tr><td><input class=rowchk style='width: 20px;height: 20px;' type='checkbox' id='" + item.id + "' /></td><td>" + count + "</td><td>" + item.name_of_person + "</td><td>" + item.contact_number + "</td><td>" + item.city + " </td><td>" + item.state + "</td><td>" + item.segment + "</td></tr>"));
            }
            MechanicListNotMapped.Controls.Add(new LiteralControl("</tbody></table>"));
        }
        Loader.Visible = false;
    }
    #endregion
}