using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ViewUnAuthDetail : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Grid_Fill();
            // btnDeleteRecord.Attributes.Add("onclick", "javascript:return DeleteConfirm()"); 
        }
    }

    public void Grid_Fill()
    {
        SqlCommand cmd = new SqlCommand("adminViewUnAuthData", con);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        DataGridview.DataSource = dt;
        DataGridview.DataBind();
    }
    
    protected void DataGridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataGridview.PageIndex = e.NewPageIndex;
        Grid_Fill();
    }
    protected void DataGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         
    }

    //Method for Deleting Record  
    protected void DeleteRecord(int id)
    {
        con.Open();
        SqlCommand com = new SqlCommand("delete from tblduplicate_valvoline_data where id=@ID", con);
        com.Parameters.AddWithValue("@ID", id);
        com.ExecuteNonQuery();
        con.Close();
    }

    protected void btnDeleteRecord_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvrow in DataGridview.Rows)
        {
               //Finiding checkbox control in gridview for particular row
              CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkDel");
                //Condition to check checkbox selected or not
                if (chkdelete.Checked)
                {
                    //Getting UserId of particular row using datakey value
                    int usrid = Convert.ToInt32(DataGridview.DataKeys[gvrow.RowIndex].Value);
                    DeleteRecord(usrid);
                }
        }
        Grid_Fill();
    }

    protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)DataGridview.HeaderRow.FindControl("chkboxSelectAll");
        foreach (GridViewRow row in DataGridview.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkDel");
            if (ChkBoxHeader.Checked == true)
            {
                ChkBoxRows.Checked = true;
            }
            else
            {
                ChkBoxRows.Checked = false;
            }
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string str = string.Empty;

        foreach (GridViewRow gvrow in DataGridview.Rows)
        {
               //Finiding checkbox control in gridview for particular row
               CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkDel");
                //Condition to check checkbox selected or not
                if (chkdelete.Checked)
                {
                    //Getting UserId of particular row using datakey value
                    int usrid = Convert.ToInt32(DataGridview.DataKeys[gvrow.RowIndex].Value);
                    str += usrid + "_";
                }
        }
        str = str.TrimEnd('_');
        Response.Redirect("DownloadDupData.aspx?id=" + str + "");
    }
} 