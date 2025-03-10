using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using Outlook = Microsoft.Office.Interop.Outlook;
/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
    public Common()
    {

    }

    #region Send User Mail From Valvoline
    public static Boolean SendUserMailFromValvoline(string To, string Body, string Subject)
    {
        try
        {
            Body += "</b>'</p><p >Thank You</p><p>Support Team";
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("atoot.admin@valvolinecummins.com");
            msg.To.Add(To);
            msg.Body = Body;
            msg.Subject = Subject;
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "192.168.12.12";

           // smtp.Host = "VCL-SRV-EXCHCAS.corporatevcl.com"; 
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            //NetworkCred.UserName = "atoot.admin";
            //NetworkCred.Password = "mail@123";
            //smtp.UseDefaultCredentials = true;
            //smtp.Credentials = NetworkCred;
            //smtp.Port = 465;
            //smtp.EnableSsl = true;
            smtp.Send(msg);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }


    }
    #endregion

    #region Send SMS
    public static string SendSMS(string MobileNo, string msg)
    {
        //msg = HttpUtility.UrlEncode(msg);
        WebClient client = new WebClient();
        string baseurl = "http://ems2.icsmsg.com/?username=valvoline&password=valvo123&source=BX-INVCPL&destination=" + MobileNo + "&message=" + msg;
       // string baseurl = "http://smsgateway.virinchisoftware.com/api/sendhttp.php?authkey=129619A7ORV1PKYN7J58120003&mobiles=91" + MobileNo + "&message=" + msg + "&sender=VALVLN&route=4&country=91";
        Stream data = client.OpenRead(baseurl);
        StreamReader reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        data.Close();
        reader.Close();
        return s;
    }
    #endregion

    #region send EMail Through OUTLOOK
    public static string sendEMailThroughOUTLOOK(string EmailId, string Body)
    {
        try
        {
            MailMessage mail = new MailMessage("tabtest@valvolinecummins.com", "rameshpatelcse@gmail.com");
            mail.IsBodyHtml = true;
            mail.Subject = "An email from Office365";
            mail.Body = "<html><body><h1>Hello world</h1></body></html>";
            SmtpClient client = new SmtpClient("smtp.office365.com");
            client.Port = 25;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false; // Important: This line of code must be executed before setting the NetworkCredentials object, otherwise the setting will be reset (a bug in .NET)
            NetworkCredential cred = new System.Net.NetworkCredential("tabtest@valvolinecummins.com", "abc@1234");
            client.Credentials = cred;
            client.Send(mail);
        }
        catch (Exception ex)
        {
        }
        return "";
    }
    #endregion


}