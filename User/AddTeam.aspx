<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddTeam.aspx.cs" Inherits="AddTeam" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/SideBar.ascx" TagPrefix="uc1" TagName="Footer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--[if !IE]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>Valvoline | Admin Dashboard Template</title>
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
            <div id="portlet-config" class="modal hide">
                <div class="modal-header">
                    <button data-dismiss="modal" class="close" type="button"></button>
                    <h3>Widget Settings</h3>
                </div>
                <div class="modal-body">
                    Widget settings form goes here
                </div>
            </div>
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
                            <asp:Label ID="LTeam2" runat="server" Text="Add Team "></asp:Label><small></small>
                        </h3>
                        <ul class="breadcrumb">
                            <li>
                                <i class="icon-home"></i>
                                <a href="Default.aspx">Home</a>
                                <i class="icon-angle-right"></i>
                            </li>
                            <li><a href="AddTeam.aspx">
                                <asp:Label ID="Lteam" runat="server" Text="Add Team"></asp:Label></a></li>
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
                <form runat="server" class="form-horizontal">
                    <asp:ScriptManager ID="ScriptManager2" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="portlet box blue">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-edit"></i>
                                        <asp:Label ID="Lteam1" runat="server" Text="Create Team"></asp:Label>
                                    </div>
                                    <div class="tools">
                                        <a href="javascript:;" class="collapse"></a>
                                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                        <a href="javascript:;" class="reload"></a>
                                        <a href="javascript:;" class="remove"></a>
                                    </div>
                                </div>

                                <div class="portlet-body">
                                    <h3 class="form-section">Team Info</h3>
                                    <div>
                                        <h3>
                                            <asp:Label ID="Label1" runat="server" ForeColor="#0066FF"></asp:Label><h3>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span6 ">
                                            <div class="control-group">
                                                <label class="control-label">Organization Name</label>
                                                <div class="controls">
                                                    <%--input type="text" class="m-wrap span12" placeholder="Chee Kin">
																<span class="help-block">This is inline help</span>--%>
                                                    <asp:TextBox ID="txtName" runat="server" class="m-wrap span12"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                        ControlToValidate="txtName" ErrorMessage="Provide your name"
                                                        ForeColor="Red" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <!--/span-->
                                        <div class="span6 ">
                                            <div class="control-group">
                                                <label class="control-label">Team Name</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtUName" runat="server" class="m-wrap span12"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                        ControlToValidate="txtUName" ErrorMessage="Provide your username"
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
                                                    <asp:TextBox ID="txtPassword" runat="server" class="m-wrap span12"
                                                        ToolTip="Text"></asp:TextBox>
                                                    <%--<span class="help-inline">Provide your password</span>--%>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
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
                                                    <asp:TextBox ID="txtCPassword" runat="server" class="m-wrap span12"></asp:TextBox>
                                                    <asp:CompareValidator runat="server" ID="Comp1" ControlToValidate="txtPassword"
                                                        ControlToCompare="txtCPassword" ForeColor="Red" Text="Password mismatch" />

                                                </div>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <!--/row-->

                                    <div class="row-fluid">

                                        <!--/span-->
                                        <div class="span6 ">
                                            <div class="control-group">
                                                <label class="control-label">State</label>
                                                <div class="controls">
                                                    <asp:ListBox ID="ListState" runat="server" class="m-wrap span12"
                                                        SelectionMode="Multiple" OnSelectedIndexChanged="ListStatet_SelectedIndexChanged"
                                                        AutoPostBack="True"></asp:ListBox>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                              ControlToValidate="ddlCity" ErrorMessage="Provide your city" InitialValue="NA"
                                                                ForeColor="Red" Display="Dynamic">
                                                              </asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                        </div>
                                        <!--/span-->

                                        <!--/span-->
                                        <div class="span6 ">
                                            <div class="control-group">
                                                <label class="control-label">District</label>
                                                <div class="controls">
                                                    <asp:ListBox ID="ListBoxDistrict" runat="server" class="m-wrap span12"
                                                        SelectionMode="Multiple"
                                                        OnSelectedIndexChanged="ListBoxDistrict_SelectedIndexChanged"></asp:ListBox>
                                                </div>
                                            </div>
                                        </div>
                                        <!--/span-->
                                    </div>
                                    <!--/row-->

                                    <!--/row-->
                                    <div class="form-actions">
                                        <%--<button type="submit" class="btn blue"><i class="icon-ok"></i> Save</button>--%>
                                        <asp:Button ID="BtnSubmit" runat="server" class="btn blue"
                                            Text="Submit" OnClick="BtnSubmit_Click" />


                                    </div>
                                    <asp:HiddenField ID="HField" runat="server" />
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
        });
    </script>
    <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>
