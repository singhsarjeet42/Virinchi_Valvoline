using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddState : System.Web.UI.Page
{
    SqlConnection con= new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!IsPostBack))
        {
            if (Request.QueryString["cid"] != null && Request.QueryString["cid"].ToString() != "")
            {
                set_value();
            }
        }
    }

    public void set_value()
    {

        Llocation.Text = "Edit Location";
        BtnSubmit.Text = "Update";
        SqlCommand cmd = new SqlCommand("adminEditLocation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", Convert.ToString(Request.QueryString["cid"]));
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adap.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txtstate.Text = dt.Rows[0]["state"].ToString();
            txtCity.Text = dt.Rows[0]["city"].ToString();
            txtDistrict.Text = dt.Rows[0]["district"].ToString();
            txtPincide.Text = dt.Rows[0]["pincode"].ToString();
        }
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (BtnSubmit.Text == "Update")
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("adminUpdateLocation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Convert.ToString(Request.QueryString["cid"]));
            cmd.Parameters.AddWithValue("@state", txtstate.Text);
            cmd.Parameters.AddWithValue("@city", txtCity.Text);
            cmd.Parameters.AddWithValue("@district", txtDistrict.Text);
            cmd.Parameters.AddWithValue("@pincode", txtPincide.Text);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Response.Redirect("ViewLocation.aspx");
                con.Close();

            }
        }
        else
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("adminAddLocation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@state", txtstate.Text);
            cmd.Parameters.AddWithValue("@city", txtCity.Text);
            cmd.Parameters.AddWithValue("@district", txtDistrict.Text);
            cmd.Parameters.AddWithValue("@pincode", txtPincide.Text);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Response.Write("<script>alert('Record Saved Successfully')</script>");
                con.Close();

            }
        
        }

    }
}