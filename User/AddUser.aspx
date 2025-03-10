<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/SideBar.ascx" TagPrefix="uc1" TagName="Footer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--[if !IE]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>Valvoline | Admin </title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="../plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../plugins/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/style-metro.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/style-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/themes/default.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="../plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
    <%--<link href="plugins/gritter/css/jquery.gritter.css" rel="stylesheet" type="text/css"/>--%>
    <link href="../plugins/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet" type="text/css" />
    <link href="../plugins/fullcalendar/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css" />
    <link href="../plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.css" rel="stylesheet" type="text/css" media="screen" />
    <!-- END PAGE LEVEL PLUGIN STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="../css/pages/tasks.css" rel="stylesheet" type="text/css" media="screen" />
    <!-- END PAGE LEVEL STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="page-header-fixed">
    <!-- BEGIN HEADER -->
    <div class="header navbar navbar-inverse navbar-fixed-top">
        <!-- BEGIN TOP NAVIGATION BAR -->
        <div class="navbar-inner">
        </div>
        <!-- END TOP NAVIGATION BAR -->
    </div>
    <!-- END HEADER -->
    <!-- BEGIN CONTAINER -->
    <div class="page-container">
        <!-- BEGIN SIDEBAR -->
        <uc1:Header runat="server" ID="Header" />
        <uc1:Footer runat="server" ID="Footer" />
        <!-- END SIDEBAR -->
        <!-- BEGIN PAGE -->
        <div class="page-content">
            <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
            <%--<div id="portlet-config" class="modal hide">
				<div class="modal-header">
					<button data-dismiss="modal" class="close" type="button"></button>
					<h3>Widget Settings</h3>
				</div>
				<div class="modal-body">
					Widget settings form goes here
				</div>
			</div>--%>
            <!-- END SAMPLE PORTLET CONFIGURATION MODAL FORM-->
            <!-- BEGIN PAGE CONTAINER-->
            <div class="container-fluid">
                <!-- BEGIN PAGE HEADER-->
                <div class="row-fluid">
                    <div class="span12">
                        <!-- BEGIN STYLE CUSTOMIZER -->

                        <!-- END BEGIN STYLE CUSTOMIZER -->
                        <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                        <h3 class="page-title">
                            <asp:Label ID="LUser" runat="server" Text="Add User"></asp:Label>
                            <small></small>
                        </h3>
                        <ul class="breadcrumb">
                            <li>
                                <i class="icon-home"></i>
                                <a href="Default.aspx">Home</a>
                                <i class="icon-angle-right"></i>
                            </li>
                            <li><a href="AddUser.aspx">
                                <asp:Label ID="LUser2" runat="server" Text="Add User"></asp:Label></a></li>
                            <li class="pull-right no-text-shadow">
                                <%--<div id="dashboard-report-range" class="dashboard-date-range tooltips no-tooltip-on-touch-device responsive" data-tablet="" data-desktop="tooltips" data-placement="top" data-original-title="Change dashboard date range">
									<i class="icon-calendar"></i>
									<span></span>
									<i class="icon-angle-down"></i>
								</div>--%>
                            </li>
                        </ul>
                        <!-- END PAGE TITLE & BREADCRUMB-->
                    </div>
                </div>
                <!-- END PAGE HEADER-->
                <div id="dashboard">
                    <!-- BEGIN DASHBOARD STATS -->
                    <div class="row-fluid">

                        <!-- END DASHBOARD STATS -->
                        <div class="clearfix"></div>
                    </div>

                </div>
                <!-- BEGIN CONTENT -->
                <!-- BEGIN FORM-->
                <form id="Form1" runat="server" class="form-horizontal">

                    <asp:ScriptManager ID="ScriptManager2" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="portlet box blue">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-edit"></i>
                                        <asp:Label ID="LUser1" runat="server" Text="Create User"></asp:Label>
                                    </div>

                                    <div class="tools">
                                        <a href="javascript:;" class="collapse"></a>
                                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                        <a href="javascript:;" class="reload"></a>
                                        <a href="javascript:;" class="remove"></a>
                                    </div>
                                </div>

                                <div class="portlet-body">
                                    <h3 class="form-section">User Info</h3>
                                    <br />
                                    <img style="margin-left: 470px;" runat="server" src="../img/load.gif" width="40" id="Loader" />
                                    <br />
                                    <h3>
                                        <asp:Label ID="Label1" runat="server" ForeColor="#3399FF"></asp:Label><h3>
                                            <div class="row-fluid">
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <label class="control-label">Team Name</label>
                                                        <div class="controls">
                                                            <%--input type="text" class="m-wrap span12" placeholder="Chee Kin">
																<span class="help-block">This is inline help</span>--%>
                                                            <asp:DropDownList ID="ddlClientName" runat="server" class="m-wrap span12">
                                                            </asp:DropDownList>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                                ControlToValidate="ddlClientName" ErrorMessage="Provide  client name" InitialValue="NA"
                                                                ForeColor="Red" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <label class="control-label">Campaign Name</label>
                                                        <div class="controls">
                                                            <asp:DropDownList ID="ddlCamName" runat="server" class="m-wrap span12">
                                                            </asp:DropDownList>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                ControlToValidate="ddlCamName" ErrorMessage="Provide campaign name" InitialValue="NA"
                                                                ForeColor="Red" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>


                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->
                                            </div>
                                            <div class="row-fluid">

                                                <!--/span-->
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <label class="control-label">User Name</label>
                                                        <div class="controls">
                                                            <asp:TextBox ID="txtETeamMemb" runat="server" class="m-wrap span12"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                                ControlToValidate="txtETeamMemb" ErrorMessage="Provide user name"
                                                                ForeColor="Red" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->

                                                <!--/span-->
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <label class="control-label">Email Id</label>
                                                        <div class="controls">
                                                            <asp:TextBox ID="EmailId" runat="server" class="m-wrap span12"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                                ControlToValidate="EmailId" ErrorMessage="Provide email id"
                                                                ForeColor="Red" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server"
                                                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ControlToValidate="EmailId" ErrorMessage="Invalid Email Id" ForeColor="Red">
                                                            </asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->
                                            </div>
                                            <!--/row-->

                                            <div class="row-fluid">
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <label class="control-label">Mobile Number</label>
                                                        <div class="controls">
                                                            <asp:TextBox ID="MobileNumber" runat="server" class="m-wrap span12"></asp:TextBox>

                                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="MobileNumber"
                                                                ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{10,10}$" runat="server" ErrorMessage="Enter valid mobile number." ForeColor="Red">
                                                            </asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                                ControlToValidate="MobileNumber" ErrorMessage="Provide mobile number"
                                                                ForeColor="Red" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <label class="control-label">User Role</label>
                                                        <div class="controls">
                                                            <asp:DropDownList ID="UserRole" runat="server" class="m-wrap span12">
                                                                <asp:ListItem Text="Select" Value="NA"></asp:ListItem>
                                                                <asp:ListItem Text="Sale Head" Value="SaleHead"></asp:ListItem>
                                                                <asp:ListItem Text="State Head" Value="StateHead"></asp:ListItem>
                                                                <asp:ListItem Text="Segment Head" Value="SegmentHead"></asp:ListItem>
                                                                <asp:ListItem Text="Demand Generator" Value="DemandGenerator"></asp:ListItem>
                                                            </asp:DropDownList>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                ControlToValidate="UserRole" ErrorMessage="Provide user role" InitialValue="NA"
                                                                ForeColor="Red" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>


                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->
                                            </div>

                                            <!--/row-->
                                            <div class="row-fluid">
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <label class="control-label">Password</label>
                                                        <div class="controls">
                                                            <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" class="m-wrap span12"
                                                                ToolTip="Text"></asp:TextBox>
                                                            <%--<span class="help-inline">Provide your password</span>--%>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"
                                                                ControlToValidate="txtPassword" ErrorMessage="Provide your password"
                                                                ForeColor="Red" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtPassword"
                                                                ID="RegularExpressionValidator21" ValidationExpression="^[\s\S]{6,14}$" runat="server" ErrorMessage="Password length must be in between 6-14." ForeColor="Red">
                                                            </asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <label class="control-label">Confirm Password</label>
                                                        <div class="controls">
                                                            <asp:TextBox TextMode="Password" ID="txtCPassword" runat="server" class="m-wrap span12"></asp:TextBox>
                                                            <asp:CompareValidator runat="server" ID="Comp1" ControlToValidate="txtPassword"
                                                                ControlToCompare="txtCPassword" Text="Password mismatch" ForeColor="Red" />

                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->
                                            </div>
                                            <!--/row-->
                                            <div class="row-fluid">
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <label class="control-label">State</label>
                                                        <div class="controls">
                                                            <asp:ListBox ID="ListState" runat="server" class="m-wrap span12"
                                                                SelectionMode="Multiple"
                                                                OnSelectedIndexChanged="ListState_SelectedIndexChanged"></asp:ListBox>

                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                          ControlToValidate="ddlCityName" ErrorMessage="Provide city name" InitialValue="NA"
                                                          ForeColor="Red" Display="Dynamic">
                                                         </asp:RequiredFieldValidator>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <label class="control-label">Segment</label>
                                                        <div class="controls">
                                                            <asp:ListBox ID="Segment" runat="server" class="m-wrap span12"
                                                                SelectionMode="Multiple" OnSelectedIndexChanged="ListBoxDistrict_SelectedIndexChanged"></asp:ListBox>
                                                        </div>

                                                    </div>
                                                </div>
                                                <!--/span-->
                                            </div>






                                            <!--/row-->
                                            <div class="form-actions">
                                                <%--<button type="submit" class="btn blue"><i class="icon-ok"></i> Save</button>--%>
                                                <asp:Button ID="BtnSubmit" runat="server" class="btn blue"
                                                    Text="Submit" OnClick="BtnSubmit_Click" Style="margin-left: 300px;" />



                                            </div>
                                            <%-- <h3> <asp:Label ID="Label1" runat="server" ForeColor="#0066FF" ></asp:Label><h3>--%>
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </form>
                <!-- END FORM-->

                <!-- END CONTENT -->
            </div>
            <!-- END PAGE CONTAINER-->
        </div>
        <!-- END PAGE -->
    </div>
    <!-- END CONTAINER -->

    <!-- BEGIN FOOTER -->
    <div class="footer">
        <div class="footer-inner">
            2015 &copy; Valvoline by Virinchi Software.
        </div>
        <div class="footer-tools">
            <span class="go-top">
                <i class="icon-angle-up"></i>
            </span>
        </div>
    </div>
    <!-- END FOOTER -->

    <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
    <!-- BEGIN CORE PLUGINS -->
    <script src="../plugins/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="../plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <!-- IMPORTANT! Load jquery-ui-1.10.1.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
    <script src="../plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>
    <script src="../plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
    <!--[if lt IE 9]>
	<script src="plugins/excanvas.min.js"></script>
	<script src="plugins/respond.min.js"></script>  
	<![endif]-->
    <script src="../plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="../plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="../plugins/jquery.cookie.min.js" type="text/javascript"></script>
    <script src="../plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script src="../plugins/jqvmap/jqvmap/jquery.vmap.js" type="text/javascript"></script>
    <script src="../plugins/jqvmap/jqvmap/maps/jquery.vmap.russia.js" type="text/javascript"></script>
    <script src="../plugins/jqvmap/jqvmap/maps/jquery.vmap.world.js" type="text/javascript"></script>
    <script src="../plugins/jqvmap/jqvmap/maps/jquery.vmap.europe.js" type="text/javascript"></script>
    <script src="../plugins/jqvmap/jqvmap/maps/jquery.vmap.germany.js" type="text/javascript"></script>
    <script src="../plugins/jqvmap/jqvmap/maps/jquery.vmap.usa.js" type="text/javascript"></script>
    <script src="../plugins/jqvmap/jqvmap/data/jquery.vmap.sampledata.js" type="text/javascript"></script>
    <script src="../plugins/flot/jquery.flot.js" type="text/javascript"></script>
    <script src="../plugins/flot/jquery.flot.resize.js" type="text/javascript"></script>
    <script src="../plugins/jquery.pulsate.min.js" type="text/javascript"></script>
    <script src="../plugins/bootstrap-daterangepicker/date.js" type="text/javascript"></script>
    <script src="../plugins/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript"></script>
    <script src="../plugins/gritter/js/jquery.gritter.js" type="text/javascript"></script>
    <script src="../plugins/fullcalendar/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
    <script src="../plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.js" type="text/javascript"></script>
    <script src="../plugins/jquery.sparkline.min.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="../scripts/app.js" type="text/javascript"></script>
    <script src="../scripts/index.js" type="text/javascript"></script>
    <script src="../scripts/tasks.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL SCRIPTS -->
    <script>
        jQuery(document).ready(function () {
            $("#Loader").hide();
            App.init(); // initlayout and core plugins
            Index.init();
            Index.initJQVMAP(); // init index page's custom scripts
            Index.initCalendar(); // init index page's custom scripts
            Index.initCharts(); // init index page's custom scripts
            Index.initChat();
            Index.initMiniCharts();
            Index.initDashboardDaterange();
            Index.initIntro();
            Tasks.initDashboardWidget();
            $("#MobileNumber").keydown(function (e) {
                // Allow: backspace, delete, tab, escape and enter
                if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110]) !== -1 ||
                    // Allow: Ctrl+A
                    (e.keyCode == 65 && e.ctrlKey === true) ||
                    // Allow: home, end, left, right
                    (e.keyCode >= 35 && e.keyCode <= 39)) {
                    // let it happen, don't do anything
                    return;
                }
                // Ensure that it is a number and stop the keypress
                if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                    e.preventDefault();
                }
            });
            $("#BtnSubmit").click(function () {
                var IsShow = true;
                var ddlClientName = $("#ddlClientName").val();
                var ddlCamName = $("#ddlCamName").val();
                var txtETeamMemb = $("#txtETeamMemb").val();
                var EmailId = $("#EmailId").val();
                var MobileNumber = $("#MobileNumber").val();
                var UserRole = $("#UserRole").val();
                var password = $("#password").val();
                var txtCPassword = $("#txtCPassword").val();
                if (txtETeamMemb == null || txtETeamMemb == "")
                    IsShow = false;
                if (EmailId == null || EmailId == "")
                    IsShow = false;
                if (MobileNumber == null || MobileNumber == "")
                    IsShow = false;
                if (txtPassword == null || txtPassword == "")
                    IsShow = false;
                if (password == null || password == "")
                    IsShow = false;
                if (ddlClientName == 'NA')
                    IsShow = false;
                if (ddlCamName == 'NA')
                    IsShow = false;
                if (UserRole == 'NA')
                    IsShow = false;
                if (IsShow) {
                    $("#Loader").show();
                }
                else {
                    $("#Loader").hide();
                }

            });
        });
    </script>
    <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>
