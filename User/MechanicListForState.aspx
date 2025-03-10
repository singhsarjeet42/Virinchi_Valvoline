<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MechanicListForState.aspx.cs" Inherits="MechanicListForState" EnableEventValidation="false" %>

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
    <link href="../css/bootstrap-datepicker.css" type="text/css" rel="stylesheet" />   
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
    <link rel="stylesheet" href="../css/jquery-ui.css" />
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
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="Button2">
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
                                            <div align="right">
                                                <asp:Button ID="BtViewMap" runat="server" Text=" View Map " class="btn green"
                                                    OnClick="BtViewMap_Click" />
                                            </div>
                                            <br />
                                            <div class="row-fluid">
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <label class="control-label">Segment</label>
                                                        <div class="controls">
                                                            <asp:DropDownList ID="ddlSegment" runat="server" class="m-wrap span12">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <label class="control-label">State</label>
                                                        <div class="controls">
                                                            <asp:DropDownList OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" ID="ddlCity" runat="server" class="m-wrap span12" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->
                                            </div>
                                            <!--/row-->
                                            <div class="row-fluid">
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <label class="control-label">From Date</label>
                                                        <div class="controls">
                                                            <%--<div class="input-append date date-picker" data-date="mm-dd-yyyy" data-date-format="mm-dd-yyyy" data-date-viewmode="years">
															<asp:TextBox ID="txtDate" runat="server" class="m-wrap m-ctrl-medium date-picker" size="47" type="text" value="mm-dd-yyyy"></asp:TextBox>
                                                              <span class="add-on"><i class="icon-calendar"></i></span>
                                                              </div>--%>

                                                            <asp:TextBox ID="txtDate" runat="server" class="m-wrap span12" type="text"> </asp:TextBox>
                                                            <%-- <asp:Image ID="Image1" runat="server" ImageUrl="Calendar-schedulehs.png"/>--%>
                                                           <%-- <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="MM-dd-yyyy"
                                                                TargetControlID="txtDate" PopupButtonID="txtDate">
                                                            </ajaxToolkit:CalendarExtender>--%>

                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <label class="control-label">To Date</label>
                                                        <div class="controls">
                                                            <%--<div class="input-append date date-picker" data-date="mm-dd-yyyy" data-date-format="mm-dd-yyyy" data-date-viewmode="years">
													       <asp:TextBox ID="TxtFDate" runat="server" class="m-wrap m-ctrl-medium date-picker" size="47" type="text" value="mm-dd-yyyy"></asp:TextBox>
                                                          <span class="add-on"><i class="icon-calendar"></i></span>
                                                          </div>--%>

                                                            <asp:TextBox ID="TxtFDate" runat="server" class="m-wrap span12" type="text"> </asp:TextBox>
                                                            <%--<asp:Image ID="Image2" runat="server" ImageUrl="Calendar-schedulehs.png" Height="20"/>--%>
                                                           <%-- <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Format="MM-dd-yyyy"
                                                                TargetControlID="TxtFDate" PopupButtonID="TxtFDate">
                                                            </ajaxToolkit:CalendarExtender>--%>

                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->
                                            </div>
                                            <div class="row-fluid">
                                                <!--/span-->
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <label class="control-label">District</label>
                                                        <div class="controls">
                                                            <asp:DropDownList ID="DistrictDropDown" runat="server" class="m-wrap span12">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->
                                            </div>
                                            <div class="row-fluid">
                                                <!--/span-->
                                                <div class="span7">
                                                    <div class="control-group">
                                                        <%--<label class="control-label">City</label>--%>
                                                        <div class="controls" align="right">
                                                            <asp:Button ID="Button2" runat="server" Text=" Search " class="btn green"
                                                                OnClick="BtnAddNew_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->

                                                <!--/span-->
                                                <div class="span6 ">
                                                    <div class="control-group">
                                                        <%--<label class="control-label">District</label>--%>
                                                        <div class="controls" align="center">
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--/span-->
                                            </div>
                                            <div class="table-toolbar">
                                                <div class="btn-group">

                                                    <i class="icon-plus"></i>
                                                </div>
                                                <div class="btn-group pull-right">
                                                    <asp:Button ID="btnDownloadAllData" class="btn green" runat="server" Text="Download All Data" OnClick="btnDownloadAllData_Click" />
                                                </div>

                                            </div>

                                            <table class="center" id="sample_editable_1">
                                                <asp:GridView ID="DataGridview" runat="server" AutoGenerateColumns="False"
                                                    PageSize="100"
                                                    CssClass="table table-striped table-hover table-bordered" AllowPaging="True"
                                                    OnPageIndexChanging="DataGridview_PageIndexChanging">
                                                    <Columns>
                                                        <%--<asp:ImageField DataImageUrlField="image_url" ControlStyle-Width="100"

                                       ControlStyle-Height = "100" HeaderText = "Preview Image"/>--%>


                                                        <asp:TemplateField HeaderText="Mechanic Name">
                                                            <ItemTemplate>
                                                                <%#Eval("name_of_person")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Mobile Number">
                                                            <ItemTemplate>
                                                                <%#Eval("contact_number")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="City">
                                                            <ItemTemplate>
                                                                <%#Eval("city")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="State">
                                                            <ItemTemplate>
                                                                <%#Eval("state")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="WorkShop">
                                                            <ItemTemplate>
                                                                <%#Eval("workshop")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Segment">
                                                            <ItemTemplate>
                                                                <%#Eval("segment")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Preferred Retailer">
                                                            <ItemTemplate>
                                                                <%#Eval("preferred_retailer")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Organization Source">
                                                            <ItemTemplate>
                                                                <%#Eval("organization_source")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="OTP Verified">
                                                            <ItemTemplate>
                                                                <%#Eval("otp_verification")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="District">
                                                            <ItemTemplate>
                                                                <%#Eval("district")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Source Of Contact">
                                                            <ItemTemplate>
                                                                <%#Eval("source_of_contact")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>



                                                    </Columns>

                                                </asp:GridView>
                                                <asp:Label ID="lblMsg" runat="server" Text="Label" Visible="false"></asp:Label>
                                            </table>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
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
    <!-- END FOOTER -->
    <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
    <!-- BEGIN CORE PLUGINS -->
    <script src="../plugins/jquery-1.10.1.min.js" type="text/javascript"></script>
     <script src="../js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script src="../plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
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
    <!-- END PAGE LEVEL SCRIPTS -->
    <script>
        function pageLoad() {
            $('#txtDate').datepicker({
                format: 'dd/mm/yyyy',
                startDate: '-3d'
            });
            $('#TxtFDate').datepicker({
                format: 'dd/mm/yyyy',
                startDate: '-3d'
            });

        }
        jQuery(document).ready(function () {
            $("#BtViewMap").hide();
            $('#txtDate').datepicker({
                format: 'dd/mm/yyyy',
                startDate: '-3d'
            });
            $('#TxtFDate').datepicker({
                format: 'dd/mm/yyyy',
                startDate: '-3d'
            });
            App.init(); // initlayout and core plugins
            //Index.init();
            //Index.initJQVMAP(); // init index page's custom scripts
            //Index.initCalendar(); // init index page's custom scripts
            //Index.initCharts(); // init index page's custom scripts
            //Index.initChat();
            //Index.initMiniCharts();
            //Index.initDashboardDaterange();
            //Index.initIntro();
            //Tasks.initDashboardWidget();
        });
    </script>
     <script type="text/javascript">
         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (sender, args) {
             if (args.get_error() && args.get_error().name === 'Sys.WebForms.PageRequestManagerTimeoutException') {
                 args.set_errorHandled(true);
             }
         });
    </script> 
    <!-- END JAVASCRIPTS -->


    <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
    <!-- BEGIN CORE PLUGINS -->
    <script src="../assets/plugins/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="../assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <!-- IMPORTANT! Load jquery-ui-1.10.1.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
    <script src="../assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>
    <script src="../assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../assets/plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
    <!--[if lt IE 9]>
	<script src="assets/plugins/excanvas.min.js"></script>
	<script src="assets/plugins/respond.min.js"></script>  
	<![endif]-->
    <script src="../assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="../assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="../assets/plugins/jquery.cookie.min.js" type="text/javascript"></script>
    <script src="../assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <sript type="../text/javascript" src="../assets/plugins/select2/select2.min.js"></script>
	<script type="../text/javascript" src="../assets/plugins/data-tables/jquery.dataTables.js"></script>
	<script type="../text/javascript" src="../assets/plugins/data-tables/DT_bootstrap.js"></script>
	<!-- END PAGE LEVEL PLUGINS -->
	<!-- BEGIN PAGE LEVEL SCRIPTS -->
	<%--<script src="assets/scripts/app.js"></script>
	<script src="assets/scripts/table-editable.js"></script> --%>   
    
	

    <!-- BEGIN CORE PLUGINS -->   <script src="../assets/plugins/jquery-1.10.1.min.js" type="text/javascript"></script>
	<script src="../assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
	<!-- IMPORTANT! Load jquery-ui-1.10.1.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
	<script src="../assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>      
	<script src="../assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
	<script src="../assets/plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js" type="text/javascript" ></script>
	<!--[if lt IE 9]>
	<script src="assets/plugins/excanvas.min.js"></script>
	<script src="assets/plugins/respond.min.js"></script>  
	<![endif]-->   
	<script src="../assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
	<script src="../assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>  
	<script src="../assets/plugins/jquery.cookie.min.js" type="text/javascript"></script>
	<script src="../assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript" ></script>
	<!-- END CORE PLUGINS -->
	<script type="../text/javascript" src="../assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
	<script src="../assets/plugins/fancybox/source/jquery.fancybox.pack.js"></script>
	<script src="../assets/scripts/app.js"></script>
	<script src="../assets/scripts/search.js"></script>   
	
	<!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>

