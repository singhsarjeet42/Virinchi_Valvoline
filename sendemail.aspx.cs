using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sendemail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Send_Click(object sender, EventArgs e)
    {
        try
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(From.Text);
            msg.To.Add(To.Text);
            msg.Body = Body.Text;
            msg.Subject = Subject.Text;
            MailAddress copy = new MailAddress("ramesh.kumar@virinchisoftware.com");
            msg.Bcc.Add(copy);
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = HostName.Text;
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = From.Text;
            NetworkCred.Password = Password.Text;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = Convert.ToInt32(PortNumber.Text);
            smtp.EnableSsl = true;
            smtp.Send(msg);
            Label1.Text = "Email sent successfully";
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}