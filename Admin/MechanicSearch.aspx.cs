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
using System.Globalization;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Drawing;
using System.Drawing;

public partial class ReserchData : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
    DateTime startDate;
    DateTime endDate;

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        BtViewMap.Visible = false;
        if ((!IsPostBack))
        {
            Grid_Fill();
            //GetClient();
            GetCity();
            GetCampaign();
            GetTeam();
        }
    }
    #endregion

    #region Get mechanic list on page load
    public void Grid_Fill()
    {
        SqlCommand cmd = new SqlCommand("adminViewValvoline", con);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        DataGridview.DataSource = dt;
        DataGridview.DataBind();
    }
    #endregion

    #region Search Mechanic List
    protected void BtnAddNew_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        string campaign_id = ddlCampaign.SelectedValue;
        string state = ddlCity.SelectedItem.Text;
        string team_name = ddlTeam.SelectedItem.Text;
        string contact_number = txtMobileNumber.Text;
        string starttime = txtDate.Text;
        string endtime = TxtFDate.Text;
        if (campaign_id == "0")
            campaign_id = "";
        if (state == "Select")
            state = "";
        if (team_name == "Select")
            team_name = "";
        if (txtDate.Text == "")
        {
            startDate = Convert.ToDateTime("01/01/1754");
        }
        else
        {
            string Month = starttime.ToString().Substring(0, 2);
            string Day = starttime.ToString().Substring(3, 2);
            string Year = starttime.ToString().Substring(6, 4);
            starttime = Day + "/" + Month + "/" + Year;
            startDate = Convert.ToDateTime(starttime).AddDays(-1);
        }

        if (TxtFDate.Text == "")
        {
            endDate = Convert.ToDateTime("01/01/9999");
        }
        else
        {
            string Month = endtime.ToString().Substring(0, 2);
            string Day = endtime.ToString().Substring(3, 2);
            string Year = endtime.ToString().Substring(6, 4);
            endtime = Day + "/" + Month + "/" + Year;
            endDate = Convert.ToDateTime(endtime).AddDays(1);
        }
        lblMsg.Text = "";

        try
        {

            SqlCommand cmd = new SqlCommand("adminSearchValvoline1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@campaign_id", campaign_id);
            //cmd.Parameters.AddWithValue("@client_name", ddlClient.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@team_name", team_name);
            cmd.Parameters.AddWithValue("@contact_number", txtMobileNumber.Text);
            cmd.Parameters.AddWithValue("@starttime ", startDate);
            cmd.Parameters.AddWithValue("@endtime ", endDate);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            ad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataGridview.DataSource = dt;
                // BtViewMap.Visible = true;
                Button3.Visible = true;
                lblMsg.Visible = false;
            }
            else
            {
                BtViewMap.Visible = false;
                Button3.Visible = false;
                lblMsg.Visible = true;
                lblMsg.Text = "No Record Found";
            }

            DataGridview.DataBind();
            //if (dt.Rows != null && dt.Rows.Count > 0)
            //{
            //    int count = 0;
            //    MechanicSearchData.Controls.Add(new LiteralControl("<table id='ReviewListDetail'><thead><tr><th class='tableTR'>Preview Image</th><th class='tableTR'>Mechanic Name</th> <th class='tableTR'>Mobile Number</th><th class='tableTR'>City</th> <th class='tableTR'>State</th><th class='tableTR'>Preferred Retailer</th><th class='tableTR'>Source Of Contact</th><th class='tableTR'>Uploaded From</th><th class='tableTR'>Online Save</th><th class='tableTR'>Delete</th></tr></thead>"));
            //    MechanicSearchData.Controls.Add(new LiteralControl("<tfoot><tr><th class='tableTR'>Preview Image</th><th class='tableTR'>Mechanic Name</th> <th class='tableTR'>Mobile Number</th><th class='tableTR'>City</th> <th class='tableTR'>State</th><th class='tableTR'>Preferred Retailer</th><th class='tableTR'>Source Of Contact</th><th class='tableTR'>Uploaded From</th><th class='tableTR'>Online Save</th><th class='tableTR'>Delete</th></tr></tfoot><tbody>"));
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        MechanicSearchData.Controls.Add(new LiteralControl("<tr><td><img style='width:20px;height:20px;' src='" + Convert.ToString(dr["image_url"]) + "' /></td><td>" + Convert.ToString(dr["name_of_person"]) + "</td><td>" + Convert.ToString(dr["contact_number"]) + "</td><td>" + Convert.ToString(dr["city"]) + "</td><td>" + Convert.ToString(dr["state"]) + "</td><td>" + Convert.ToString(dr["preferred_retailer"]) + "</td><td>" + Convert.ToString(dr["source_of_contact"]) + "</td><td>" + Convert.ToString(dr["record_input_form"]) + "</td><td>" + Convert.ToString(dr["authenticated_contact"]) + "</td><td onclick='Delete()'>Delete</td></tr>"));
            //    }
            //    MechanicSearchData.Controls.Add(new LiteralControl("</tbody></table>"));
            //}
            //GetCity();
            //GetCampaign();
            //GetTeam();

        }
        catch (Exception ex)
        {
            Grid_Fill();
        }
    }
    #endregion

    #region Helping Function
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

    #region Get city on page load
    public void GetCity()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select distinct state from tblpincode", con);
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        con.Close();
        ddlCity.DataSource = dt;
        ddlCity.DataTextField = "state";
        //ddlCity.DataValueField = "pincode";
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("Select", "0"));
    }
    #endregion

    #region Get Campaign on page load
    public void GetCampaign()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select campaign_id,campaign_name from tblcampaign", con);
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        con.Close();
        ddlCampaign.DataSource = dt;
        ddlCampaign.DataTextField = "campaign_name";
        ddlCampaign.DataValueField = "campaign_id";
        ddlCampaign.DataBind();
        ddlCampaign.Items.Insert(0, new ListItem("Select", "0"));
    }
    #endregion

    #region Get team on page load
    public void GetTeam()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select team_id,team_name from tblteam where user_type != 'Admin' ", con);
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        con.Close();
        ddlTeam.DataSource = dt;
        ddlTeam.DataTextField = "team_name";
        ddlTeam.DataValueField = "team_id";
        ddlTeam.DataBind();
        ddlTeam.Items.Insert(0, new ListItem("Select", "NA"));
    }
    #endregion

    #region Delete a mechanic 
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
    #endregion

    #region Link for View Map
    protected void BtViewMap_Click(object sender, EventArgs e)
    {
        Response.Redirect("../User/ViewMap.aspx");
    }
    #endregion

    #region Page Index 
    protected void DataGridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataGridview.PageIndex = e.NewPageIndex;
        Grid_Fill();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the runtime error "
        //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."
    }
    #endregion

    #region Action link for download mechanic 
    protected void Button3_Click(object sender, EventArgs e)
    {
        string StartDate = txtDate.Text;
        if (StartDate == null || StartDate == "")
            StartDate = "01/01/1754";
        else
        {
            string Month = StartDate.ToString().Substring(0, 2);
            string Day = StartDate.ToString().Substring(3, 2);
            string Year = StartDate.ToString().Substring(6, 4);
            StartDate = Day + "/" + Month + "/" + Year;
        }
        string EndDate = TxtFDate.Text;
        if (EndDate == null || EndDate == "")
            EndDate = "01/01/9999";
        else
        {
            string Month = EndDate.ToString().Substring(0, 2);
            string Day = EndDate.ToString().Substring(3, 2);
            string Year = EndDate.ToString().Substring(6, 4);
            EndDate = Day + "/" + Month + "/" + Year;
        }
        Response.Redirect("exportexl.aspx?campaign_id=" + ddlCampaign.SelectedValue + "&state=" + ddlCity.SelectedItem.Text +
        "&team_name=" + ddlTeam.SelectedItem.Text + "&contact_number=" + txtMobileNumber.Text + "&starttime=" + Convert.ToDateTime(StartDate) +
        "&endtime=" + Convert.ToDateTime(EndDate) + "");

    }
    #endregion
}