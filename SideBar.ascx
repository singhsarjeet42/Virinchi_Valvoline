<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideBar.ascx.cs" Inherits="SideBar" %>



<div class="page-sidebar nav-collapse collapse">
    <!-- BEGIN SIDEBAR MENU -->
    <ul class="page-sidebar-menu">
        <li>
            <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
            <%--	<div class="sidebar-toggler hidden-phone"></div>--%>
            <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
        </li>   


        <li>
            <!-- BEGIN RESPONSIVE QUICK SEARCH FORM -->

            <!-- END RESPONSIVE QUICK SEARCH FORM -->
        </li>
        <li class="start active">
            <a href="../User/Default.aspx">
                <i class="icon-home"></i>
                <span class="title">Dashboard</span>
                <span class="selected"></span>
            </a>

        </li>
        <%--<li >
					<a href="javascript:;">
					<i class="icon-cogs"></i> 
					<span class="title">Layouts</span>
					<span class="arrow "></span>
					</a>
					
				</li>--%>
        <!-- BEGIN FRONT DEMO -->

        <!-- END FRONT DEMO -->

        <li>
            <a href="javascript:;">
                <i class="icon-bookmark-empty"></i>
                <span class="title">Mechanic</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li id="liMechanicList" runat="server" visible="false">
                    <a href="../Admin/ValvolineData.aspx">Mechanic List</a>
                </li>
                <li id="liMechanicListNotTag" runat="server" visible="false">
                    <a href="../user/MechanicListNotTag.aspx">Mechanic List (Not tag)</a>
                </li>
                <li id="liMechanicListTranfer" runat="server" visible="false">
                    <a href="../Admin/TransferMechanic.aspx">Mechanic Transfer</a>
                </li>
                 <li id="liViewMapAdmin" runat="server" visible="false">
                    <a href="../User/ViewMap.aspx">View Map</a>
                </li>
                <li id="liMechanicListDG" runat="server" visible="false">
                    <a href="../user/MechanicListForDG.aspx">Mechanic List (DG)</a>
                </li>
                 <li id="liViewMapDG" runat="server" visible="false">
                    <a href="../User/ViewMap.aspx?Role=DG">View Map</a>
                </li>
                <li id="liMechanicListSegment" runat="server" visible="false">
                    <a href="../user/MechanicListForSegment.aspx">Mechanic List (Segment)</a>
                </li>
                 <li id="liViewMapSegment" runat="server" visible="false">
                    <a href="../User/ViewMap.aspx?Role=SegmentHead">View Map</a>
                </li>

                <li id="liMechanicListSale" runat="server" visible="false">
                    <a href="../user/MechanicListForSale.aspx">Mechanic List (Sale)</a>
                </li>
                 <li id="liViewMapSale" runat="server" visible="false">
                    <a href="../User/ViewMap.aspx?Role=SaleHead">View Map</a>
                </li>
                <li id="liMechanicListState" runat="server" visible="false">
                    <a href="../user/MechanicListForState.aspx">Mechanic List (State)</a>
                </li>
                 <li id="liViewMapState" runat="server" visible="false">
                    <a href="../User/ViewMap.aspx?Role=StateHead">View Map</a>
                </li>
            </ul>

        </li>
        <li id="liChangePassword" runat="server" visible="false">
            <a href="javascript:;">
                <i class="icon-bookmark-empty"></i>
                <span class="title">Change Password</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a href="../User/ChangePassword.aspx">Change Password</a>
                </li>
            </ul>
        </li>

        <li id="liTeam" runat="server" visible="false">
            <a href="javascript:;">
                <i class="icon-bookmark-empty"></i>
                <span class="title">Team Management</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a href="../User/AddTeam.aspx">Add Team</a>
                </li>
                <li>
                    <a href="../User/ViewTeam.aspx">View Team</a>
                </li>
            </ul>
        </li>

        <li id="liCampaign" runat="server" visible="false">
            <a href="javascript:;">
                <i class="icon-bookmark-empty"></i>
                <span class="title">Campaign Management</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a href="../User/AddCampaign.aspx">Add Campaign</a>
                </li>
                <li>
                    <a href="../User/ViewCampaign.aspx">View Campaign</a>
                </li>
            </ul>
        </li>

        <li id="liUser" runat="server" visible="false">
            <a href="javascript:;">
                <i class="icon-bookmark-empty"></i>
                <span class="title">User Management</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a href="../User/AddUser.aspx">Add User</a>
                </li>
                <li>
                    <a href="../User/ViewUser.aspx">View User</a>
                </li>
            </ul>
        </li>


        <li id="liLocation" runat="server" visible="false">
            <a href="javascript:;">
                <i class="icon-bookmark-empty"></i>
                <span class="title">Location Management</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a href="../User/AddLocation.aspx">Add Location</a>
                </li>
                <li>
                    <a href="../User/ViewLocation.aspx">View Location</a>
                </li>
            </ul>
        </li>
        <li id="liUpdExcelSheet" runat="server" visible="false">
            <a href="javascript:;">
                <i class="icon-bookmark-empty"></i>
                <span class="title">Upload ExcelSheet</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a href="../Admin/UploadExelSheet.aspx">Upload ExcelSheet</a>
                </li>
            </ul>
        </li>
        <li id="liDataClean" runat="server" visible="false">
            <a href="javascript:;">
                <i class="icon-bookmark-empty"></i>
                <span class="title">Data Clean</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a href="../Admin/DataCleanByMobileNo.aspx">Delete By Mobile Number</a>
                </li>
            </ul>
        </li>

          <li id="liOTPPerformance" runat="server" visible="false">
            <a href="javascript:;">
                <i class="icon-bookmark-empty"></i>
                <span class="title">OTP Performance</span>
                <span class="arrow "></span>
            </a>
            <ul class="sub-menu">
                <li>
                    <a href="../user/OTPStatus.aspx">List of OTP Status</a>
                </li>
            </ul>
        </li>


    </ul>
    <!-- END SIDEBAR MENU -->
</div>


