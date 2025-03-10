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
using System.Security.Principal;
using System.Globalization;

public partial class ReserchData : System.Web.UI.Page
{
   SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
   string teamId = string.Empty;
   protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.IsInRole("Admin"))
        {
            Response.Redirect("../Admin/MechanicSearch.aspx");
        }
        else if (Session["TeamId"] != null)
        {
            teamId = Session["TeamId"].ToString();
        }
        
        if ((!IsPostBack))
        {
            //Grid_Fill();
            //GetClient();
            GetState();
            GetCampaign();
            GetTeam();
        }
    }

   public void Grid_Fill()
   {
        SqlCommand cmd = new SqlCommand("adminViewValvoline", con);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        DataGridview.DataSource = dt;
        DataGridview.DataBind();
    }

    DateTime startDate;
    DateTime endDate;
    protected void BtnAddNew_Click(object sender, EventArgs e)
    {
        if (txtDate.Text != "" && txtDate.Text != null)
            startDate = DateTime.ParseExact(txtDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        if (TxtFDate.Text != "" && txtDate.Text != null)
            endDate = DateTime.ParseExact(TxtFDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        try
        {
            if (txtDate.Text == "" || TxtFDate.Text == "")
            {
                startDate = Convert.ToDateTime("01/01/1754");
                endDate = Convert.ToDateTime("01/01/9999");
            }
            SqlCommand cmd = new SqlCommand("adminSearchValvoline", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@campaign_id", ddlCampaign.SelectedValue);
            //cmd.Parameters.AddWithValue("@client_name", ddlClient.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@state", ddlCity.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@team_name", ddlTeam.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@contact_number", txtMobileNumber.Text);
            cmd.Parameters.AddWithValue("@starttime ", Convert.ToDateTime(startDate));
            cmd.Parameters.AddWithValue("@endtime ", Convert.ToDateTime(endDate));
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataGridview.DataSource = dt;
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "No Record Found";
            }
            txtDate.Text="";
            TxtFDate.Text="";
            DataGridview.DataBind();
        }
        catch (Exception ex) 
        {
            Grid_Fill();
        }

        if (ddlCity.SelectedItem.Text == "Select" && ddlTeam.SelectedItem.Text == "Select" && 
            ddlCampaign.SelectedItem.Text == "Select" && txtMobileNumber.Text == "")
        {
            Grid_Fill();
            lblMsg.Text = "";
        }
    }
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
    //public void GetClient()
    //{
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("select team_id,name from tblteam", con);
    //    DataTable dt = new DataTable();
    //    dt.Load(cmd.ExecuteReader());
    //    con.Close();
    //    ddlClient.DataSource = dt;
    //    ddlClient.DataTextField = "name";
    //    ddlClient.DataValueField = "team_id";
    //    ddlClient.DataBind();
    //    ddlClient.Items.Insert(0, new ListItem("Select","0"));
    //}
    public void GetState()
    {   
        con.Open();
        SqlCommand cmd = new SqlCommand("select distinct state from tbllocations where team_id = '"+teamId+"'", con);
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        con.Close();
        ddlCity.DataSource = dt;
        ddlCity.DataTextField = "state";
        //ddlCity.DataValueField = "pincode";
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("Select", "0"));
    }

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

    protected void BtViewMap_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewMap.aspx");
    }
    protected void DataGridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataGridview.PageIndex = e.NewPageIndex;
        Grid_Fill();
    }
}