using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_ChangePassword : System.Web.UI.Page
{
    ValvolineDBDataContext db = new ValvolineDBDataContext();

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var userId = Session["UserId"];
            var UserDetail = (from p in db.tblusers where p.user_id == Convert.ToInt32(userId) select p).SingleOrDefault();
            if (UserDetail != null)
            {
                UserName.Text = UserDetail.user_name;
                EmailId.Text = UserDetail.EmailId;
            }
        }
    }
    #endregion

    #region Change password
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        var userId = Session["UserId"];
        var UserDetail = (from p in db.tblusers where p.user_id == Convert.ToInt32(userId) select p).SingleOrDefault();
        if (UserDetail != null)
        {
            UserDetail.Password = Password.Text;
            db.SubmitChanges();
            Message.Text = "Password changed successfully";
        }
    }
    #endregion
}