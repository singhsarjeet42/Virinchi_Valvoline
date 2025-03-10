<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewMap.aspx.cs" Inherits="ViewMap" %>

<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/SideBar.ascx" TagPrefix="uc1" TagName="Footer" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>MarkerClusterer v3 Simple Example</title>
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
    <link rel="shortcut icon" href="../favicon.ico" />
    <style>
        body {
            margin: 0;
            padding: 10px 20px 20px;
            font-family: Arial;
            font-size: 16px;
        }

        #map-container {
            padding: 6px;
            border-width: 1px;
            border-style: solid;
            border-color: #ccc #ccc #999 #ccc;
            -webkit-box-shadow: rgba(64, 64, 64, 0.5) 0 2px 5px;
            -moz-box-shadow: rgba(64, 64, 64, 0.5) 0 2px 5px;
            box-shadow: rgba(64, 64, 64, 0.1) 0 2px 5px;
            width: 600px;
        }

        #map {
            width: 600px;
            height: 400px;
        }
    </style>


</head>
<body class="page-header-fixed" onload="initialize()">
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
                        <img style="margin-top: 15px; margin-right: 560px; float: right;" src="../img/load.gif" width="40" id="Loader" runat="server" />
                        <h3 class="page-title">Mechanic Location Map <small>google map</small>
                        </h3>
                        <ul class="breadcrumb">
                            <li>
                                <i class="icon-home"></i>
                                <a href="Default.aspx">Home</a>
                                <i class="icon-angle-right"></i>
                            </li>
                            <li><a href="../User/ViewMap.aspx">Location Map</a></li>
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
                        <asp:TextBox ID="RoleText" runat="server"></asp:TextBox>
                        <asp:TextBox ID="UserIdText" runat="server"></asp:TextBox>


                        <asp:TextBox ID="stateText" runat="server"></asp:TextBox>
                        <asp:TextBox ID="SegmentText" runat="server"></asp:TextBox>
                        <asp:TextBox ID="startDateText" runat="server"></asp:TextBox>
                        <asp:TextBox ID="endDateText" runat="server"></asp:TextBox>
                        <asp:TextBox ID="District" runat="server"></asp:TextBox>
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
                                        <%--<div class="table-toolbar">

                                   </div>--%>

                                        <table class="center" id="sample_editable_1">

                                            <%-- <div id="mapArea" style="width: 1060px; height: 700px;">
                                            </div>--%>
                                            <div id="map-container" style="width: 1060px; height: 700px;">
                                                <div id="map" style="width: 1060px; height: 700px;"></div>
                                            </div>
                                        </table>
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

    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="../scripts/app.js" type="text/javascript"></script>
    <script src="../scripts/index.js" type="text/javascript"></script>
    <script src="../scripts/tasks.js" type="text/javascript"></script>

    <script src="https://maps.googleapis.com/maps/api/js"></script>
    <script src="../js/AdminLTE/data.json"></script>
    <script type="text/javascript" src="../js/AdminLTE/markerclusterer.js"></script>

    <script>
        function initialize() {
            $("#stateText").hide();
            $("#SegmentText").hide();
            $("#startDateText").hide();
            $("#endDateText").hide();
            $("#RoleText").hide();
            $("#UserIdText").hide();
            $("#District").hide();
            var District = $("#District").val();
            var State = $("#stateText").val();
            var Segment = $("#SegmentText").val();
            var StartDate = $("#startDateText").val();
            var EndDate = $("#endDateText").val();
            var Role = $("#RoleText").val();
            var UserId = $("#UserIdText").val();
            var center = new google.maps.LatLng(23.195307, 77.370873);

            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 5,
                center: center,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });
            if (Role == "SaleHead") {
                $.ajax({
                    type: 'POST',
                    url: 'ViewMap.aspx/GetLatLogForSaleHead',
                    data: JSON.stringify({ State: State, Segment: Segment, StartDate: StartDate, EndDate: EndDate, District: District }),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        var item = data.d;
                        var markers = [];
                        $.each(item, function (index, obj) {
                            var latLng = new google.maps.LatLng(obj.lat, obj.log);
                            var marker = new google.maps.Marker({ 'position': latLng });
                            markers.push(marker);
                        });
                        var markerCluster = new MarkerClusterer(map, markers, { imagePath: '../images/m' });
                        $("#Loader").hide();
                    }
                });
            }
            else
                if (Role == "SegmentHead") {
                    $.ajax({
                        type: 'POST',
                        url: 'ViewMap.aspx/GetLatLogForSegmentHead',
                        data: JSON.stringify({ UserId: UserId, State: State, Segment: Segment, StartDate: StartDate, EndDate: EndDate, District: District }),
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (data) {
                            var item = data.d;
                            var markers = [];
                            $.each(item, function (index, obj) {
                                var latLng = new google.maps.LatLng(obj.lat, obj.log);
                                var marker = new google.maps.Marker({ 'position': latLng });
                                markers.push(marker);
                            });
                            var markerCluster = new MarkerClusterer(map, markers, { imagePath: '../images/m' });
                            $("#Loader").hide();
                        }
                    });
                }
                else
                    if (Role == "StateHead") {
                        $.ajax({
                            type: 'POST',
                            url: 'ViewMap.aspx/GetLatLogForStateHead',
                            data: JSON.stringify({ UserId: UserId, State: State, Segment: Segment, StartDate: StartDate, EndDate: EndDate, District: District }),
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            success: function (data) {
                                var item = data.d;
                                var markers = [];
                                $.each(item, function (index, obj) {
                                    var latLng = new google.maps.LatLng(obj.lat, obj.log);
                                    var marker = new google.maps.Marker({ 'position': latLng });
                                    markers.push(marker);
                                });
                                var markerCluster = new MarkerClusterer(map, markers, { imagePath: '../images/m' });
                                $("#Loader").hide();
                            }
                        });
                    }
                    else
                        if (Role == "DG") {
                            $.ajax({
                                type: 'POST',
                                url: 'ViewMap.aspx/GetLatLogForDG',
                                data: JSON.stringify({ UserId: UserId, State: State, Segment: Segment, StartDate: StartDate, EndDate: EndDate, District: District }),
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'json',
                                success: function (data) {
                                    var item = data.d;
                                    var markers = [];
                                    $.each(item, function (index, obj) {
                                        var latLng = new google.maps.LatLng(obj.lat, obj.log);
                                        var marker = new google.maps.Marker({ 'position': latLng });
                                        markers.push(marker);
                                    });
                                    var markerCluster = new MarkerClusterer(map, markers, { imagePath: '../images/m' });
                                    $("#Loader").hide();
                                }
                            });
                        }
                        else {
                            $.ajax({
                                type: 'POST',
                                url: 'ViewMap.aspx/GetLatLog',
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'json',
                                success: function (data) {
                                    var item = data.d;
                                    var markers = [];
                                    $.each(item, function (index, obj) {
                                        var latLng = new google.maps.LatLng(obj.lat, obj.log);
                                        var marker = new google.maps.Marker({ 'position': latLng });
                                        markers.push(marker);
                                    });
                                    var markerCluster = new MarkerClusterer(map, markers, { imagePath: '../images/m' });
                                    $("#Loader").hide();
                                }
                            });
                        }
            App.init();
        }
    </script>
    <script>
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-12846745-20']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' === document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>
</body>
</html>
