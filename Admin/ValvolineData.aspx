<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValvolineData.aspx.cs" Inherits="ValvolineData" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/SideBar.ascx" TagPrefix="uc1" TagName="Footer" %>
<!DOCTYPE html>
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
    <style type="text/css">
        #MechanicListDetail {
            border: solid;
            text-align: center;
        }

        .tableTR {
            text-align: center;
        }

        #deleteimage {
            cursor: pointer;
        }

        table.dataTable {
            border-collapse: collapse !important;
        }

            table.dataTable tbody tr {
                border-bottom: 1px solid #000;
            }

        .fixd {
            position: fixed;
            top: 0px;
            border-top: 2px solid #000;
            background: #fff;
            margin-right: 18px;
        }
    </style>
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
                        <h3 class="page-title">Mechnic List <small></small>
                        </h3>
                        <ul class="breadcrumb">
                            <li>
                                <i class="icon-home"></i>
                                <a href="../User/Default.aspx">Home</a>
                                <i class="icon-angle-right"></i>
                            </li>
                            <li><a href="ValvolineData.aspx">Mechnic List</a></li>
                            <li class="pull-right no-text-shadow"></li>
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
                    <!-- BEGIN CONTENT -->
                    <!-- BEGIN FORM-->
                    <form id="Form1" runat="server" class="form-horizontal">
                        <asp:ScriptManager ID="ScriptManager2" runat="server" />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="portlet box blue">
                                    <div class="portlet-title">
                                        <div class="caption"><i class="icon-edit"></i>Mechnic List</div>
                                        <div class="tools">
                                            <a href="javascript:;" class="collapse"></a>
                                            <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                            <a href="javascript:;" class="reload"></a>
                                            <a href="javascript:;" class="remove"></a>
                                        </div>
                                    </div>

                                    <div class="portlet-body">
                                        <div class="table-toolbar">
                                            <div class="btn-group">
                                                <asp:Button ID="btnAddNew" runat="server" Text="Search" class="btn green"
                                                    OnClick="btnAddNew_Click" />
                                                <i class="icon-plus"></i>
                                            </div>
                                            <div class="btn-group pull-right">
                                                <asp:Button ID="btnDownloadAllData" class="btn green" runat="server" Text="Download All Data" OnClick="btnDownloadAllData_Click" />
                                            </div>

                                        </div>
                                        <div runat="server" id="MechanicList">
                                        </div>
                                        <br />

                                    </div>
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
    </div>
    <script src="../plugins/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="../plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>

    <!-- IMPORTANT! Load jquery-ui-1.10.1.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
    <script src="../plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>
    <script src="../plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
    <!--[if lt IE 9]>
	<script src="assets/plugins/excanvas.min.js"></script>
	<script src="assets/plugins/respond.min.js"></script>  
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

    <!-- jQuery 2.0.2 -->

    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />

    <script src="../js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/bootbox.min.js"></script>

    <link href="../js/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="../js/jquery.dataTables.min.js"></script>

    <script>
        $(window).scroll(function () {
            if ($(window).scrollTop() > 270 /*or $(window).height()*/) {
                $(".static").addClass('fixd');
            }
            else {
                $(".static").removeClass('fixd');
            }
        });
    </script>

    <script>
        $(function () {
            App.init();
            $("#MechanicListDetail").DataTable({
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/English.json"
                }
            });
        });
        function Delete(id) {
            bootbox.confirm("Are you sure you want to delete this record?", function (result) {
                if (result) {
                    $.ajax({
                        type: "POST",
                        url: "ValvolineData.aspx/Delete",
                        data: JSON.stringify({ Id: id }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (result) {
                            bootbox.alert("Mechanic deleted successfully", function () {
                            });
                            window.location.reload(true);
                        },
                        error: function (result) {
                            bootbox.alert("error " + result, function () {
                            });
                        }
                    });
                }
            });
        }
    </script>
</body>
<!-- END BODY -->
</html>
