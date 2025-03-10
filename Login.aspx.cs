using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Login : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session.Abandon();
        FormsAuthentication.SignOut();
    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        FormsAuthentication.Initialize();

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "SELECT user_type, team_id FROM tblteam WHERE name=@username " +
        "AND password=@password";

        cmd.Parameters.Add("@username", SqlDbType.NVarChar, 64).Value = txtUName.Text;
        cmd.Parameters.Add("@password", SqlDbType.NVarChar, 128).Value = txtPassword.Text;
        //FormsAuthentication.HashPasswordForStoringInConfigFile(
        //   Txtpassword.Text, "md5"); // Or "sha1"

        // Execute the command
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            Session["UserName"] = txtUName.Text;
            Session["TeamId"] = Convert.ToString(reader.GetInt32(1));
            Session["Role"] = "Admin";
            // Create a new ticket used for authentication
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
            1, // Ticket version
            txtUName.Text, // Username associated with ticket
            DateTime.Now, // Date/time issued
            DateTime.Now.AddMinutes(30), // Date/time to expire
            true, // "true" for a persistent user cookie
            reader.GetString(0), // User-data, in this case the roles
            FormsAuthentication.FormsCookiePath); // Path cookie valid for

            // Encrypt the cookie using the machine key for secure transport
            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(
               FormsAuthentication.FormsCookieName, // Name of auth cookie
               hash); // Hashed ticket
                        // Set the cookie's expiration time to the tickets expiration time
            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

            // Add the cookie to the list for outgoing response
            Response.Cookies.Add(cookie);

            // Redirect to requested URL, or homepage if no previous page
            // requested
            string returnUrl = "User/Default.aspx"; //Request.QueryString["ReturnUrl"];
            if (returnUrl == null) returnUrl = "/";

            // Don't call FormsAuthentication.RedirectFromLoginPage since it
            // could
            // replace the authentication ticket (cookie) we just added
            Response.Redirect(returnUrl);
        }
        else
        {
            var UserDetail = (from p in db.tblusers where p.EmailId == txtUName.Text.Trim() && p.Password == txtPassword.Text.Trim() select p).SingleOrDefault();
            if (UserDetail != null)
            {
                Session["UserName"] = txtUName.Text;
                Session["Role"] = UserDetail.Roles;
                Session["UserId"] = UserDetail.user_id;
                // Create a new ticket used for authentication
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1, // Ticket version
                txtUName.Text, // Username associated with ticket
                DateTime.Now, // Date/time issued
                DateTime.Now.AddMinutes(30), // Date/time to expire
                true, // "true" for a persistent user cookie
                UserDetail.Roles, // User-data, in this case the roles
                FormsAuthentication.FormsCookiePath); // Path cookie valid for

                // Encrypt the cookie using the machine key for secure transport
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(
                   FormsAuthentication.FormsCookieName, // Name of auth cookie
                   hash); // Hashed ticket

                // Set the cookie's expiration time to the tickets expiration time
                if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

                // Add the cookie to the list for outgoing response
                Response.Cookies.Add(cookie);

                // Redirect to requested URL, or homepage if no previous page
                // requested
                string returnUrl = "User/Default.aspx"; //Request.QueryString["ReturnUrl"];
                if (returnUrl == null) returnUrl = "/";

                // Don't call FormsAuthentication.RedirectFromLoginPage since it
                // could
                // replace the authentication ticket (cookie) we just added
                Response.Redirect(returnUrl);
            }
            else
            {
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
                ErrorLabel.Text = "Username / password incorrect. Please try again.";
                ErrorLabel.Visible = true;
            }
        }

        reader.Close();
        con.Close();

        //con.Open();
        //SqlCommand cmd = new SqlCommand("uspAdminLogin", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@user_name", txtUName.Text);
        //cmd.Parameters.AddWithValue("@password", txtPassword.Text);
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //da.Fill(dt);
        //if (dt.Rows.Count > 0)
        //{
        //    string UserName = dt.Rows[0]["name"].ToString();
        //    Session["TeamId"] = dt.Rows[0]["team_id"].ToString();
        //    Session["UserName"] = UserName;
        //    Session["Password"] = dt.Rows[0]["password"].ToString();
        //    Session["LoginType"] = dt.Rows[0]["user_type"].ToString();
        //    FormsAuthentication.RedirectFromLoginPage(UserName, false);
        //     //Session["user"]="user";
        //}
        //else
        //{
        //    ErrorLabel.Text = "Wrong UserName OR Password";
        //    ErrorLabel.ForeColor = Color.Red;
        //    ErrorLabel.Font.Size = 12;
        //    ErrorLabel.Visible = true;
        //    //Response.Write("<script>alert('Wrong UserName or Password')</script>");
        //}
        //con.Close();
    }
}