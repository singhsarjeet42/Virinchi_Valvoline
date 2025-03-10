<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/SideBar.ascx" TagPrefix="uc1" TagName="Footer" %>

<!DOCTYPE html>

<!--[if !IE]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>valvoline | Admin  </title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />    
    <!-- BEGIN GLOBAL MANDATORY STYLES -->   
     <script src="../Modernizr-master/modernizr.js"></script>
	<link href="../plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
	<link href="../plugins/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css"/>
	<link href="../plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
	<link href="../css/style-metro.css" rel="stylesheet" type="text/css"/>
	<link href="../css/style.css" rel="stylesheet" type="text/css"/>
	<link href="../css/style-responsive.css" rel="stylesheet" type="text/css"/>
	<link href="../css/themes/default.css" rel="stylesheet" type="text/css" id="style_color"/>
	<link href="../plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>  
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
    <style>
        .span6 {
    max-width: 290px !important;
    float:left !important;
    margin-right:10px !important;
}
    </style>
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
    
<body class="page-header-fixed">
   
    <%--<uc1:Header runat="server" ID="Header" />--%>
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
        <uc1:Header runat="server" ID="Header1" />
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
                        <h3 class="page-title">Dashboard <small></small>
                        </h3>
                        <ul class="breadcrumb">
                            <li>
                                <i class="icon-home"></i>
                                <a href="Default.aspx">Home</a>
                                <i class="icon-angle-right"></i>
                            </li>
                            <li><a href="#">Dashboard</a></li>
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
                <form runat="server">
                    <asp:TextBox ID="Role" runat="server"></asp:TextBox>
                </form>
                <!-- END PAGE HEADER-->
                <div id="DashBoardAdmin">
                    <!-- BEGIN DASHBOARD STATS -->
                    <div class="row-fluid">
                        <div class="span3 responsive" data-tablet="span6" data-desktop="span3">
                            <div class="dashboard-stat blue">
                                <div class="visual">
                                    <%--<i class="icon-comments"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                    </div>
                                    <div class="desc">
                                        Location
                                    </div>
                                    <div class="desc">
                                        Management
                                    </div>
                                </div>
                                <a class="more" href="../User/ViewLocation.aspx">View data <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        <div class="span3 responsive" data-tablet="span6" data-desktop="span3">
                            <div class="dashboard-stat green">
                                <div class="visual">
                                    <%--<i class="icon-shopping-cart"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number"></div>
                                    <div class="desc">User </div>
                                    <div class="desc">Management</div>
                                </div>
                                <a class="more" href="ViewUser.aspx">View User <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        <div class="span3 responsive" data-tablet="span6  fix-offset" data-desktop="span3">
                            <div class="dashboard-stat purple">
                                <div class="visual">

                                    <%--<i class="icon-globe"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number"></div>
                                    <div class="desc">Campaign</div>
                                    <div class="desc">Management</div>
                                </div>
                                <a class="more" href="ViewCampaign.aspx">View Campaign <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        <div class="span3 responsive" data-tablet="span6" data-desktop="span3">
                            <div class="dashboard-stat yellow">
                                <div class="visual">
                                    <%--<i class="icon-bar-chart"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number"></div>
                                    <div class="desc">Team </div>
                                    <div class="desc">Management</div>
                                </div>
                                <a class="more" href="ViewTeam.aspx">View Team <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>


                    </div>



                    <!-- END DASHBOARD STATS -->
                    <div class="clearfix"></div>

                </div>


                <div id="DashBoardDG">
                    <!-- BEGIN DASHBOARD STATS -->
                    <div class="row-fluid">
                        <div class="span3 responsive" data-tablet="span6" data-desktop="span3">
                            <div class="dashboard-stat blue">
                                <div class="visual">
                                    <%--<i class="icon-comments"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                    </div>
                                    <div class="desc">
                                        Mechanic
                                    </div>
                                    <div class="desc">
                                        Management
                                    </div>
                                </div>
                                <a class="more" href="../user/MechanicListForDG.aspx">View data <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        
                    </div>
                </div>

                <div id="DashBoardSegment">
                    <!-- BEGIN DASHBOARD STATS -->
                    <div class="row-fluid">
                        <div class="span3 responsive" data-tablet="span6" data-desktop="span3">
                            <div class="dashboard-stat blue">
                                <div class="visual">
                                    <%--<i class="icon-comments"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                    </div>
                                    <div class="desc">
                                        Mechanic
                                    </div>
                                    <div class="desc">
                                        Management
                                    </div>
                                </div>
                                <a class="more" href="../user/MechanicListForSegment.aspx">View data <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        
                    </div>
                </div>

                <div id="DashBoardSale">
                    <!-- BEGIN DASHBOARD STATS -->
                    <div class="row-fluid">
                        <div class="span3 responsive" data-tablet="span6" data-desktop="span3">
                            <div class="dashboard-stat blue">
                                <div class="visual">
                                    <%--<i class="icon-comments"></i>--%>
                                </div>
                                <div class="details">
                                    <div class="number">
                                    </div>
                                    <div class="desc">
                                        Mechanic
                                    </div>
                                    <div class="desc">
                                        Management
                                    </div>
                                </div>
                                <a class="more" href="../user/MechanicListForSale.aspx">View data <i class="m-icon-swapright m-icon-white"></i>
                                </a>
                            </div>
                        </div>
                        
                    </div>
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
   
	<script src="../plugins/excanvas.min.js"></script>
	<script src="../plugins/respond.min.js"></script>  
	<![endif]
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
            $("#Role").hide();
            $("#DashBoardDG").hide();
            $("#DashBoardAdmin").hide();
            $("#DashBoardSegment").hide();
            $("#DashBoardSale").hide();
            $("#DashBoardState").hide();
            var Role = $("#Role").val();
            if (Role == "Admin") {
                $("#DashBoardAdmin").show();
            }
            else
                if (Role == "DemandGenerator") {
                    $("#DashBoardDG").show();
                }
                else
                    if (Role == "SegmentHead") {
                        $("#DashBoardSegment").show();
                    }
                    else
                        if (Role == "SaleHead") {
                            $("#DashBoardSale").show();
                        }
                        else
                            if (Role == "StateHead") {
                                $("#DashBoardState").show();
                            }

            App.init(); // initlayout and core plugins
            //Index.init();
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
