using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ViewState : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

    #region Page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!IsPostBack))
        {
            Session["SearchLocation"] = "";
            Grid_Fill();

        }
    }
    #endregion

    #region Get list of location
    public void Grid_Fill()
    {

        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT id ,state,city,district,pincode FROM tblpincode", con);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        con.Close();

    }
    #endregion

    #region Link to add and edit location
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "ECOMMAND")
        {
            Response.Redirect("AddLocation.aspx?cid=" + e.CommandArgument);
            Grid_Fill();
        }

        if (e.CommandName == "deletecity")
        {
            string id = e.CommandArgument.ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE tblpincode WHERE id='" + id + "'", con);
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {

                Response.Write("<script>alert('Record is deleted')</script>");


            }
            con.Close();
            Grid_Fill();
        }

    }
    #endregion

    #region Link to add location
    protected void AddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddLocation.aspx");
    }
    #endregion

    #region Helper function
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion

    #region Get search location list base on city
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        //SqlCommand cmd = new SqlCommand("SEARCHCITY", con);
        SqlCommand cmd = new SqlCommand("SEARCHCITY", con);
        cmd.CommandType = CommandType.StoredProcedure;
        Session["SearchLocation"] = Convert.ToString(TextBox1.Text);
        cmd.Parameters.AddWithValue("@state", Convert.ToString(TextBox1.Text));
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adap.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    #endregion

    #region Page index
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Grid_Fill();
    }
    #endregion

    #region Link to download excel
    protected void btnDownloadAllData_Click(object sender, EventArgs e)
    {
        Response.Redirect("ExcelForLocation.aspx");
    }
    #endregion
}