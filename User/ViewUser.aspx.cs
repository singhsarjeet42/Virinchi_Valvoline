using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Outlook = Microsoft.Office.Interop.Outlook;
public partial class ViewUser : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

    #region Page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.IsInRole("User"))
        {
            btnDownloadUsers.Visible = false;
        }
        if (!(IsPostBack))
        {
            Grid_Fill();
        }
    }
    #endregion

    #region List of User for campaign
    public void Grid_Fill()
    {
        var UserDetail = (from u in db.tblusers
                          join c in db.tblcampaigns on u.campaign_id equals c.campaign_id
                          join t in db.tblteams on u.team_id equals t.team_id
                          select new { u.EmailId, u.Roles, u.Password, u.user_name, u.user_id, u.imei_second, u.imei_first, u.District, u.createdOn, u.state, c.campaign_name, t.team_name }).OrderByDescending(m => m.user_id).ToList();

        if (UserDetail != null && UserDetail.Count > 0)
        {
            int count = 0;
            UserList.Controls.Add(new LiteralControl("<table id='UserListDetail'><thead class='static'><tr><th class='tableTR'>S No.</th><th class='tableTR'>User Name</th><th class='tableTR'>Campaign Name</th><th class='tableTR'>Team Name</th><th class='tableTR'>Email Id</th><th class='tableTR'>Role</th><th class='tableTR'>View More</th><th class='tableTR'>Edit</th><th class='tableTR'>Delete</th></tr></thead>"));
            UserList.Controls.Add(new LiteralControl("<tfoot><tr><th class='tableTR'>S No.</th><th class='tableTR'>User Name</th><th class='tableTR'>Campaign Name</th><th class='tableTR'>Team Name</th><th class='tableTR'>Email Id</th><th class='tableTR'>Role</th><th class='tableTR'>View More</th><th class='tableTR'>Edit</th><th class='tableTR'>Delete</th></tr></tfoot><tbody>"));
            foreach (var item in UserDetail)
            {
                count++;
                UserList.Controls.Add(new LiteralControl("<tr><td>" + count + "</td><td>" + item.user_name + "</td><td>" + item.campaign_name + "</td><td>" + item.team_name + " </td><td>" + item.EmailId + "</td><td>" + item.Roles + "</td><td><a href='UserInfo.aspx?cid=" + item.user_id + "'><img style='width:25px;' id='editimage' src='../img/detail.png' /></a></td>      <td><a href='AddUser.aspx?cid=" + item.user_id + "'><img style='width:25px;' id='editimage' src='../img/edit.png' /></a></td><td><img style='width:25px;' id='deleteimage' onclick='Delete(" + item.user_id + ")' src='../img/delete.png' /></td></tr>"));
            }
            UserList.Controls.Add(new LiteralControl("</tbody></table>"));
        }
    }
    #endregion

    #region helper function
    protected void GridViewClient_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridViewClient_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion

    #region Link to add user
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddUser.aspx");
    }
    #endregion

    #region Edit/Delete link for user
    protected void GridViewClient_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("AddUser.aspx?cid=" + e.CommandArgument);
            Grid_Fill();
        }
        if (e.CommandName == "View")
        {
            Response.Redirect("UserInfo.aspx?cid=" + e.CommandArgument);
            Grid_Fill();
        }
        if (e.CommandName == "SendCredential")
        {
            string UserId = Convert.ToString(e.CommandArgument);
            var UserDetail = (from p in db.tblusers where p.user_id == Convert.ToInt32(UserId) select p).SingleOrDefault();
            if (UserDetail != null)
            {
                #region Send Password to email id and mobile
                string Body = "";
                Body += "<p>Welcome " + UserDetail.user_name + "</p>";
                Body += "<p style='padding-left: 40px;'></p></br>";
                Body += "<p>Your Username : " + UserDetail.EmailId + "</p>";
                Body += "<p>Your Password : " + UserDetail.Password + "</p></br>";
                Body += "<p>Please feel free to contact us in case you have any difficulty in Logging in with these credentials.</P></br>";
                Common.SendUserMailFromValvoline(UserDetail.EmailId, Body, "Login Credentials for Atoot Bandhan");
                string Message = "";
                Message += "Welcome " + UserDetail.user_name + "\nYour Atoot Bandhan User Name:" + UserDetail.EmailId + "\nYour Password:" + UserDetail.Password;
                Common.SendSMS(Convert.ToString(UserDetail.MobileNo), Message);
                #endregion
                Response.Write("<script>alert('Credential have been sent to user')</script>");
            }
            else
            {
                Response.Write("<script>alert('User not exist')</script>");
            }
        }
        if (e.CommandName == "deleteclient")
        {
            string UserId = Convert.ToString(e.CommandArgument);
            var UserHaveMechanic = (from p in db.tblvalvoline_details where p.UserId == UserId && p.deleted_on == false select p).ToList();
            if (UserHaveMechanic != null && UserHaveMechanic.Count > 0)
            {
                Response.Write("<script>alert('Shift the mechanic list before delete')</script>");
            }
            else
            {
                con.Open();
                SqlCommand Cmd = new SqlCommand("adminDelUser", con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@user_id", e.CommandArgument);
                int t = Cmd.ExecuteNonQuery();
                if (t > 0)
                {
                    Response.Write("<script>alert('Record is deleted')</script>");
                }
                con.Close();
                Grid_Fill();
            }
        }
    }
    #endregion

    #region Link for Excel Sheet download
    protected void btnDownloadUsers_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Admin/ExlUser.aspx");
    }
    #endregion

    #region Delete a User
    [System.Web.Services.WebMethod]
    public static string Delete(string Id)
    {
        ValvolineDBDataContext db = new ValvolineDBDataContext();
        if (Id != null && Id != "")
        {
            var obj = (from p in db.tblusers where p.user_id == Convert.ToInt32(Id) select p).Single();
            if (obj != null)
            {
                var UserHaveMechanic = (from p in db.tblvalvoline_details where p.UserId == Convert.ToString(obj.user_id) && p.deleted_on == false select p).ToList();
                if (UserHaveMechanic != null && UserHaveMechanic.Count > 0)
                {
                    return "HaveMechanic";
                }
                else
                {
                    db.tblusers.DeleteOnSubmit(obj);
                    db.SubmitChanges();
                }
            }
        }

        return "true";
    }
    #endregion

    #region Send Credential
    [System.Web.Services.WebMethod]
    public static string SendCredential(string Id)
    {
        ValvolineDBDataContext db = new ValvolineDBDataContext();
        if (Id != null && Id != "")
        {
            var obj = (from p in db.tblusers where p.user_id == Convert.ToInt32(Id) select p).Single();
            if (obj != null)
            {
                #region Send Password to email id and mobile
                string Body = "";
                string EmailId = Convert.ToString(obj.EmailId);
                Body += "<p>Welcome " + obj.user_name + "</p>";
                Body += "<p style='padding-left: 40px;'></p></br>";
                Body += "<p>Your Username : " + obj.EmailId + "</p>";
                Body += "<p>Your Password : " + obj.Password + "</p></br>";
                Body += "<p>Please feel free to contact us in case you have any difficulty in Logging in with these credentials.</P></br>";
                Common.SendUserMailFromValvoline(obj.EmailId, Body, "Login Credentials for Atoot Bandhan");
                string Message = "";
                Message += "Welcome " + obj.user_name + "\nYour Atoot Bandhan User Name:" + obj.EmailId + "\nYour Password:" + obj.Password;
                Common.SendSMS(Convert.ToString(obj.MobileNo), Message);
                //Common.sendEMailThroughOUTLOOK(EmailId, Body);
                #endregion
            }
        }

        return "true";
    }
    #endregion
}