using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;

public partial class SideBar : System.Web.UI.UserControl
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (HttpContext.Current.User.IsInRole("Admin"))
        {
            liUpdExcelSheet.Visible = true;
            liMechanicList.Visible = true;
            liDataClean.Visible = true;
            liTeam.Visible = true;
            liCampaign.Visible = true;
            liUser.Visible = true;
            liLocation.Visible = true;
            liLocation.Visible = true;
            liMechanicListNotTag.Visible = true;
            liMechanicListTranfer.Visible = true;
            //liViewMapAdmin.Visible = true;
            liOTPPerformance.Visible = true;
        }
        if (HttpContext.Current.User.IsInRole("DemandGenerator"))
        {
            liMechanicListDG.Visible = true;
            liChangePassword.Visible = true;
           // liViewMapDG.Visible = true;
        }
        if (HttpContext.Current.User.IsInRole("SegmentHead"))
        {
            liMechanicListSegment.Visible = true;
            liChangePassword.Visible = true;
            //liViewMapSegment.Visible = true;
        }
        if (HttpContext.Current.User.IsInRole("SaleHead"))
        {
            liMechanicListSale.Visible = true;
            liChangePassword.Visible = true;
           // liViewMapSale.Visible = true;
        }
        if (HttpContext.Current.User.IsInRole("StateHead"))
        {
            liMechanicListState.Visible = true;
            liChangePassword.Visible = true;
            //liViewMapState.Visible = true;
        }
    }
    #endregion
}