<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OTPStatusList.aspx.cs" Inherits="Admin_OTPStatusList" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/SideBar.ascx" TagPrefix="uc1" TagName="Footer" %>
<!DOCTYPE html>
<!--[if !IE]><!--> <html lang="en" class="no-js"> <!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
	<meta charset="utf-8" />
	<title>Valvoline | OTP </title>
	<meta content="width=device-width, initial-scale=1.0" name="viewport" />
	<meta content="" name="description" />
	<meta content="" name="author" />
	<!-- BEGIN GLOBAL MANDATORY STYLES -->        
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
	<link href="../plugins/fullcalendar/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css"/>
	<link href="../plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css" media="screen"/>
	<link href="../plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.css" rel="stylesheet" type="text/css" media="screen"/>
	<!-- END PAGE LEVEL PLUGIN STYLES -->
	<!-- BEGIN PAGE LEVEL STYLES --> 
	<link href="../css/pages/tasks.css" rel="stylesheet" type="text/css" media="screen"/>
	<!-- END PAGE LEVEL STYLES -->
    
	<link rel="shortcut icon" href="favicon.ico" />
</head>
   <!--Begin Page Google Map -->
 

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
						<h3 class="page-title">
							OTP<small></small>
						</h3>
						<ul class="breadcrumb">
							<li>
								<i class="icon-home"></i>
								<a href="../User/Default.aspx">Home</a> 
								<i class="icon-angle-right"></i>
							</li>
							<li><a href="../Admin/MechanicSearch.aspx">Mechanical Search</a></li>
							<li class="pull-right no-text-shadow">
								
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
               <!-- BEGIN CONTENT -->
                         <!-- BEGIN FORM-->
						<form id="Form1" runat="server" class="form-horizontal">
                                
                                  <asp:ScriptManager ID="ScriptManager2" runat="server" />
                            <asp:Panel ID="Panel1" runat="server" DefaultButton="BtnAddNew">
                                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                   <ContentTemplate>
                                  <div class="portlet box blue">
                                       <div class="portlet-title">
								                <div class="caption"><i class="icon-edit"></i>OTP Status List</div>
								                      <div class="tools">
									                      <a href="javascript:;" class="collapse"></a>
									                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
									                       <a href="javascript:;" class="reload"></a>
									                   <a href="javascript:;" class="remove"></a>
								                         </div>
							                    </div>

                                       <div class="portlet-body">
                                             <div align="right">
                                     
                                  </div>
                                  <br/>
												
												<div class="row-fluid">
													<div class="span6 ">
														<div class="control-group">      
															<label class="control-label">From Date</label>
														 <div class="controls">
															<%--<div class="input-append date date-picker" data-date="mm-dd-yyyy" data-date-format="mm-dd-yyyy" data-date-viewmode="years">
															<asp:TextBox ID="txtDate" runat="server" class="m-wrap m-ctrl-medium date-picker" size="47" type="text" value="mm-dd-yyyy"></asp:TextBox>
                                                              <span class="add-on"><i class="icon-calendar"></i></span>
                                                              </div>--%>

                                                               <asp:TextBox ID="txtDate" runat="server"  class="m-wrap span12" type="text"> </asp:TextBox>
                                                              <%-- <asp:Image ID="Image1" runat="server" ImageUrl="Calendar-schedulehs.png"/>--%>
                                                             <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"  Format="dd-MM-yyyy"
                                                               TargetControlID="txtDate" PopupButtonID="txtDate">
                                                            </ajaxToolkit:CalendarExtender>

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

                                                          <asp:TextBox ID="TxtFDate" runat="server"  class="m-wrap span12" type="text"> </asp:TextBox>
                                                               <%--<asp:Image ID="Image2" runat="server" ImageUrl="Calendar-schedulehs.png" Height="20"/>--%>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy"
                                                               TargetControlID="TxtFDate" PopupButtonID="TxtFDate">
                                                            </ajaxToolkit:CalendarExtender>

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
															<asp:Button ID="BtnAddNew" runat="server" Text=" Search "  class="btn green" 
                                                        onclick="BtnAddNew_Click" />
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
                                                <!--/row-->  
                                                <div class="row-fluid">

                                                <!--/span-->
                                                <div class="span6 ">
														<%--<div class="control-group">
															<label class="control-label">City</label>
															<div class="controls">                                                
															<asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" class="m-wrap span12"
                                                            onselectedindexchanged="ddlCity_SelectedIndexChanged">
                                                        </asp:DropDownList> 
															</div>
														</div>--%>
													</div>
                                                    <!--/span-->
													
													<!--/span-->
													<div class="span6 ">
														<div class="control-group">
															<div class="controls" align="right">
														<asp:Button ID="Button3" runat="server" Text="Download Searched Data"  class="btn green" 
                                                                    onclick="Button3_Click"  />
                                                             
															</div>
														</div>
													</div>
													<!--/span-->
												</div>                 
												
												<!--/row-->
												
                                                   
                                    <table class="center" id="sample_editable_1">
                                   
                                    <asp:GridView ID="DataGridview" runat="server" AutoGenerateColumns="False" 
                                            onrowcommand="DataGridview_RowCommand"   
                                            CssClass="table table-striped table-hover table-bordered" AllowPaging="True" 
                                            onpageindexchanging="DataGridview_PageIndexChanging" >
                                    <Columns >
                                    

                                   <asp:TemplateField headerText="Source Mobile App User">
                                  <ItemTemplate>
                                       <%#Eval("SourceOfUser")%>
                                   </ItemTemplate>
                                    </asp:TemplateField>

                                   <asp:TemplateField headerText="Mechanic Mobile Number">
                                  <ItemTemplate>
                                       <%#Eval("MobileNumber")%>
                                   </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField headerText="Date & Time of OTP">
                                   <ItemTemplate>
                                       <%#Eval("DateTimes")%>
                                   </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField headerText="OTP">
                                  <ItemTemplate>
                                       <%#Eval("OTP")%>
                                   </ItemTemplate>
                                    </asp:TemplateField>

                                  <asp:TemplateField headerText="Gateway Submit Status">
                                  <ItemTemplate>
                                       <%#Eval("Message")%>
                                   </ItemTemplate>
                                    </asp:TemplateField>

                                

<%--                                  <asp:TemplateField HeaderText="Delete">
                                 <ItemTemplate>
                                  <asp:LinkButton ID="LINK1" runat="server" Text="Delete" CommandName="Dcammand" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
                                 </ItemTemplate>
                                 </asp:TemplateField>--%>
                                  </Columns>
                                  
                                  </asp:GridView>
                                        
                                  <asp:Label ID="lblMsg" runat="server" Text="Label" Visible="false"></asp:Label>
								    
                                    </table>
                                  </ContentTemplate>
                                </asp:UpdatePanel>
                                </asp:Panel>
                                </div>
                               </div>
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
	<script src="../plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
	<!-- IMPORTANT! Load jquery-ui-1.10.1.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
	<script src="../plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>      
	<script src="../plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
	<script src="../plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js" type="text/javascript" ></script>
	<!--[if lt IE 9]>
	<script src="assets/plugins/excanvas.min.js"></script>
	<script src="assets/plugins/respond.min.js"></script>  
	<![endif]-->   
	<script src="../plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
	<script src="../plugins/jquery.blockui.min.js" type="text/javascript"></script>  
	<script src="../plugins/jquery.cookie.min.js" type="text/javascript"></script>
	<script src="../plugins/uniform/jquery.uniform.min.js" type="text/javascript" ></script>
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


    <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
	<!-- BEGIN CORE PLUGINS -->   <script src="assets/plugins/jquery-1.10.1.min.js" type="text/javascript"></script>
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
	<!-- BEGIN PAGE LEVEL PLUGINS -->
	<sript type="text/javascript" src="../assets/plugins/select2/select2.min.js"></script>
	<script type="text/javascript" src="../assets/plugins/data-tables/jquery.dataTables.js"></script>
	<script type="text/javascript" src="../assets/plugins/data-tables/DT_bootstrap.js"></script>
	<!-- END PAGE LEVEL PLUGINS -->
	<!-- BEGIN PAGE LEVEL SCRIPTS -->
	<%--<script src="assets/scripts/app.js"></script>
	<script src="assets/scripts/table-editable.js"></script> --%>   
    
	<script>
	    jQuery(document).ready(function () {
	        //App.init();
	        TableEditable.init();
	    });
	</script>

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
	<script type="text/javascript" src="../assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
	<script src="../assets/plugins/fancybox/source/jquery.fancybox.pack.js"></script>
	<script src="../assets/scripts/app.js"></script>
	<script src="../assets/scripts/search.js"></script>   
	<script>
	    jQuery(document).ready(function () {
	        //App.init();
	        Search.init();
	    });
	</script>
	<!-- END JAVASCRIPTS -->


</body>
<!-- END BODY -->
</html>



   <%-- <link type="text/css" href="http://ajax.microsoft.com/ajax/jquery.ui/1.8.2/themes/blitzer/jquery-ui.css" rel="Stylesheet" />
    <script src="../assets/plugins/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="../assets/plugins/jquery-ui.js" type="text/javascript"></script>
    <script>
        $(function () {
            $("#txtDate").datepicker({ minDate: '0', dateFormat: 'yy-dd-mm' });
            $("#TxtFDate").datepicker({ minDate: '0', dateFormat: 'yy-dd-mm' });
        });
    </script>--%>