using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class ValvolineData : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Grid_Fill();
        }
    }
    #endregion

    #region Get mechanic list
    public void Grid_Fill()
    {

        var MechanicDetail = (from m in db.tblvalvoline_details join u in db.tblusers on Convert.ToString(m.UserId) equals Convert.ToString(u.user_id) where m.deleted_on==false select new { m, u }).OrderByDescending(m => m.m.id).Take(1000).ToList();
        if (MechanicDetail != null && MechanicDetail.Count > 0)
        {
            int count = 0;
            MechanicList.Controls.Add(new LiteralControl("<table id='MechanicListDetail'><thead class='static'><tr><th class='tableTR'>S No.</th><th class='tableTR'>Image</th><th class='tableTR'>Mechanic Name</th><th class='tableTR'>Mobile Number</th><th class='tableTR'>City</th> <th class='tableTR'>District</th><th class='tableTR'>State</th><th class='tableTR'>Segment</th><th class='tableTR'>Preferred Retailer</th><th class='tableTR'>Tag User</th><th class='tableTR'>Delete</th></tr></thead>"));
            MechanicList.Controls.Add(new LiteralControl("<tfoot><tr><th class='tableTR'>S No.</th><th class='tableTR'>Image</th><th class='tableTR'>Mechanic Name</th><th class='tableTR'>Mobile Number</th><th class='tableTR'>City</th> <th class='tableTR'>District</th><th class='tableTR'>State</th><th class='tableTR'>Segment</th><th class='tableTR'>Preferred Retailer</th><th class='tableTR'>Tag User</th><th class='tableTR'>Delete</th></tr></tfoot><tbody>"));
            foreach (var item in MechanicDetail)
            {
                count++;
                MechanicList.Controls.Add(new LiteralControl("<tr><td>" + count + "</td><td><img style='width:75px;height: 75px;' id='deleteimage' src='" + item.m.image_url + "' /></td><td>" + item.m.name_of_person + "</td><td>" + item.m.contact_number + "</td><td>" + item.m.city + " </td><td>" + item.m.district + "</td><td>" + item.m.state + "</td><td>" + item.m.segment + "</td><td>" + item.m.preferred_retailer + "</td><td>" + item.u.user_name + "</td><td><img style='width:25px;' id='deleteimage' onclick='Delete(" + item.m.id + ")' src='../img/delete.png' /></td></tr>"));
            }
            MechanicList.Controls.Add(new LiteralControl("</tbody></table>"));
        }
    }
    #endregion

    #region Link to Mechanic search
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("MechanicSearch.aspx");
        //ExportGridToExcel();
    }
    #endregion

    #region Link to Export excel sheet
    protected void btnDownloadAllData_Click(object sender, EventArgs e)
    {
        Response.Redirect("exportexl.aspx");
    }
    #endregion

    #region Helper function
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the runtime error "
        //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."
    }
    #endregion

    #region Delete a mechanic
    [System.Web.Services.WebMethod]
    public static string Delete(string Id)
    {
        ValvolineDBDataContext db = new ValvolineDBDataContext();
        if (Id != null && Id != "")
        {
            var obj = (from p in db.tblvalvoline_details where p.id == Convert.ToInt32(Id) select p).Single();
            if (obj != null)
            {
                db.tblvalvoline_details.DeleteOnSubmit(obj);
                db.SubmitChanges();
            }
        }

        return "true";
    }
    #endregion
}

