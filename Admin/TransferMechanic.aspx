<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransferMechanic.aspx.cs" Inherits="Admin_TransferMechnic" %>

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
    <link href="../plugins/gritter/css/jquery.gritter.css" rel="stylesheet" type="text/css" />
    <link href="../plugins/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet" type="text/css" />
    <link href="../plugins/fullcalendar/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css" />
    <link href="../plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.css" rel="stylesheet" type="text/css" media="screen" />
    <!-- END PAGE LEVEL PLUGIN STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <!-- END PAGE LEVEL STYLES -->
    <link rel="shortcut icon" href="../favicon.ico" />
    <style type="text/css">
        #MechanicListNotMappedDetail {
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
<!--End Page Google Map -->


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
                        <h3 class="page-title">Transfer Mechanic<small>&nbsp;&nbsp;&nbsp;   For DG</small>
                        </h3>
                        <ul class="breadcrumb">
                            <li>
                                <i class="icon-home"></i>
                                <a href="Default.aspx">Home</a>
                                <i class="icon-angle-right"></i>
                            </li>
                            <li><a href="../User/TrasferMechanic.aspx">Transfer Mechanic</a></li>
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
                        <div class="clearfix">
                        </div>

                    </div>

                    <form id="Form1" runat="server">
                        <div class="row-fluid">
                            <div class="span12">
                                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                <div class="portlet box blue">
                                    <div class="portlet-title">
                                        <div class="caption"><i class="icon-edit"></i>View Map</div>
                                        <div class="tools">
                                            <a href="javascript:;" class="collapse"></a>
                                            <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                            <a href="javascript:;" class="reload"></a>
                                            <a href="javascript:;" class="remove"></a>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <br />
                                        <asp:Label ID="Message" runat="server" Text="" Style="width: 40px;"></asp:Label>
                                        <table style="width: 1150px;">
                                            <tr>
                                                <td>User list from
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="FromUser" runat="server" AutoPostBack="True" OnSelectedIndexChanged="FromUser_SelectedIndexChanged"></asp:DropDownList>
                                                </td>
                                                <td>User list to
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ToUser" runat="server"></asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />

                                        <input type="button" id="Transfer" style="margin-left: 353px; float: left;" value="Transfer Selected" />
                                        <input type="button" id="TransferAll" style="margin-left: 41px;" value="Transfer All" />
                                        <asp:Button ID="GetAll" runat="server" Text="Get All" OnClick="GetAll_Click" />
                                        <br />
                                        <br />
                                        <img style="margin-left: 470px;" src="../img/load.gif" width="40" id="Loader"  />
                                        <br />
                                        <div runat="server" id="MechanicListNotMapped">
                                        </div>
                                    </div>
                                </div>
                                <!-- END EXAMPLE TABLE PORTLET-->
                            </div>
                        </div>
                    </form>
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
            $("#Loader").hide();
            App.init();
            $("#MechanicListNotMappedDetail").DataTable({
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/English.json"
                }
            });
            $("#GetAll").click(function () {
                $("#Loader").show();
            });
            $("#Transfer").click(function () {
                var CheckBox = {};
                CheckBox.Checked = [];

                $("input:checkbox").each(function () {
                    var $this = $(this);

                    if ($this.is(":checked")) {
                        if ($this.attr("id") != "CheckAll")
                            CheckBox.Checked.push($this.attr("id"));
                    }
                });
                var ToUser = $("#ToUser").val();
                var FromUser = $("#FromUser").val();
                if (ToUser != null && ToUser != "" && ToUser != "NA") {
                    if (CheckBox.Checked.length > 0) {
                        if (ToUser != FromUser) {
                            $("#Loader").show();
                            $.ajax({
                                type: "POST",
                                url: "TransferMechanic.aspx/TransferMechanicForSelected",
                                data: JSON.stringify({ SelecteId: CheckBox.Checked, ToUser: ToUser }),
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (result) {
                                    alert("Success")
                                    window.location.reload(true);
                                },
                                error: function (result) {
                                    alert("Error")
                                }
                            });
                        }
                        else {
                            alert("'From' and 'To' user must not be same")
                        }
                    }
                    else {
                        alert("At least select one mechanic list")
                    }
                }
                else {
                    alert("please select user to whome transfer")
                }
            });
            $("#CheckAll").click(function () {
                var CheckBox = {};
                CheckBox.Checked = [];

                $("input:checkbox").each(function () {
                    var $this = $(this);
                    $("#uniform-" + $this.attr("id")).removeClass();
                });
                if ($('#CheckAll').is(':checked')) {
                    var checkboxes = new Array();
                    checkboxes = document.getElementsByTagName('input');
                    for (var i = 0; i < checkboxes.length; i++) {
                        if (checkboxes[i].type == 'checkbox') {
                            //checkboxes[i].checked = checktoggle;
                            checkboxes[i].checked = true;
                        }
                    }

                }
                else {
                    $(".rowchk").removeAttr('checked');
                }
            });
            $("#TransferAll").click(function () {
                var ToUser = $("#ToUser").val();
                var FromUser = $("#FromUser").val();
                if (ToUser != null && ToUser != "" && ToUser != "NA") {
                    if (ToUser != FromUser) {
                        $("#Loader").show();
                        $.ajax({
                            type: "POST",
                            url: "TransferMechanic.aspx/TransferMechanicForAll",
                            data: JSON.stringify({ FromUser: FromUser, ToUser: ToUser }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (result) {
                                alert("Success")
                                window.location.reload(true);
                            },
                            error: function (result) {
                                alert("Error")
                            }
                        });
                    }
                    else {
                        alert("'From' and 'To' user must not be same")
                    }
                }
                else {
                    alert("please select user to whome transfer")
                }
            });
        });
    </script>
</body>
<!-- END BODY -->
</html>
