using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Bindgrid();
            Grid_Fill();
            ExportGridToExcel();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the runtime error "
        //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."
    }
    private void ExportGridToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "MechanicList" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel"; //For Excel 2003
        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        DataGridview.GridLines = GridLines.Both;
        DataGridview.HeaderStyle.Font.Bold = true;
        DataGridview.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
    }

    string value;
    public void Grid_Fill()
    {
        value = Request.QueryString["id"];
        SqlCommand cmd = new SqlCommand("adminExportDupExcel", con);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        //SqlParameter param = new SqlParameter();
        cmd.Parameters.AddWithValue("@id", value);
        cmd.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        ad.Fill(dt);
        DataGridview.DataSource = dt;
        DataGridview.DataBind();
    }
    protected void DataGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void DataGridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}