<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCampaign.aspx.cs" Inherits="AddCampaign" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/SideBar.ascx" TagPrefix="uc1" TagName="Footer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--[if !IE]><!--> <html lang="en" class="no-js"> <!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
	<meta charset="utf-8" />
	<title>Valvolone | Admin </title>
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
	<link href="../plugins/fullcalendar/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css"/>
	<link href="../plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css" media="screen"/>
	<link href="../plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.css" rel="stylesheet" type="text/css" media="screen"/>
	<!-- END PAGE LEVEL PLUGIN STYLES -->
	<!-- BEGIN PAGE LEVEL STYLES --> 
	<link href="../css/pages/tasks.css" rel="stylesheet" type="text/css" media="screen"/>
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
					<%--<button data-dismiss="modal" class="close" type="button"></button>--%>
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
                            <asp:Label ID="LCamp" runat="server" Text="Add Campaign"></asp:Label> <small></small>
						</h3>
						<ul class="breadcrumb">
							<li>
								<i class="icon-home"></i>
								<a href="Default.aspx">Home</a> 
								<i class="icon-angle-right"></i>
							</li>
							<li><a href="AddCampaign.aspx">
                                <asp:Label ID="LCamp1" runat="server" Text="Add Campaign"></asp:Label></a></li>
							<li class="pull-right no-text-shadow">
								<div id="dashboard-report-range" class="dashboard-date-range tooltips no-tooltip-on-touch-device responsive" data-tablet="" data-desktop="tooltips" data-placement="top" data-original-title="Change dashboard date range">
									<i class="icon-calendar"></i>
									<span></span>
									<i class="icon-angle-down"></i>
								</div>
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
								                <div class="caption"><i class="icon-edit"></i>
                                                    <asp:Label ID="LCamp2" runat="server" Text="Create Campaign"></asp:Label></div>
								                      <div class="tools">
									                      <a href="javascript:;" class="collapse"></a>
									                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
									                       <a href="javascript:;" class="reload"></a>
									                   <a href="javascript:;" class="remove"></a>
								                         </div>
							                     </div>

                                              <div class="portlet-body">
												<h3 class="form-section">Campaign Info</h3>
                                                  <div>
                                                     <h3> <asp:Label ID="Label1" runat="server" ForeColor="#0066FF" ></asp:Label><h3>
                                                    </div>
												<div class="row-fluid">
													<div class="span6 ">
                                                         
														<div class="control-group">
															<label class="control-label">Team Name</label>
															<div class="controls">
																<%--input type="text" class="m-wrap span12" placeholder="Chee Kin">
																<span class="help-block">This is inline help</span>--%>
                                                         <%-- <asp:TextBox ID="txtName" runat="server"   class="m-wrap span12"></asp:TextBox>--%>
                                                          <asp:DropDownList ID="ddlName" runat="server" class="m-wrap span12"></asp:DropDownList>
                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                          ControlToValidate="ddlName" ErrorMessage="Provide client name" 
                                                          ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        
															</div>
														</div>
													</div>
													<!--/span-->
													<div class="span6 ">
														<div class="control-group">
															<label class="control-label">Campaign Name</label>
															<div class="controls">
														 <asp:TextBox ID="txtCName" runat="server"  class="m-wrap span12"></asp:TextBox>
                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                          ControlToValidate="txtCName" ErrorMessage="Provide  campaign name" 
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
															<label class="control-label">Start Time</label>
															<div class="controls">
														      <%--<div class="input-append date date-picker" data-date="<%#DateTime.Now %>" data-date-format="dd/mm/yyyy" data-date-viewmode="years">
												                <asp:TextBox ID="txtSTime" runat="server" class="m-wrap m-ctrl-medium date-picker" size="47" type="text" value="dd/mm/yyyy"></asp:TextBox>
                                                                <span class="add-on"><i class="icon-calendar"></i></span>     01/12/2015
                                                            </div>--%>
                                                        <asp:TextBox ID="txtSTime" runat="server"  class="m-wrap span12" type="text"> </asp:TextBox>
                                                              <%-- <asp:Image ID="Image1" runat="server" ImageUrl="Calendar-schedulehs.png"/>--%>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                                                               TargetControlID="txtSTime" Format="dd-MM-yyyy" PopupButtonID="txtSTime">
                                                            </ajaxToolkit:CalendarExtender>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                          ControlToValidate="txtSTime" ErrorMessage="Provide  start time" 
                                                          ForeColor="Red" Display="Dynamic">
                                                         </asp:RequiredFieldValidator>
												      </div>
														</div>
													</div>
													<!--/span-->
													<div class="span6 ">
														<div class="control-group">
															<label class="control-label" >End Time</label>
															<div class="controls">
															<%--<div class="input-append date date-picker" data-date="<%#DateTime.Now %>" data-date-format="dd/mm/yyyy" data-date-viewmode="years">
														    <asp:TextBox ID="txtETime" runat="server" class="m-wrap m-ctrl-medium date-picker" size="47" type="text" Text='dd/mm/yyyy'></asp:TextBox>
                                                            <span class="add-on"><i class="icon-calendar"></i></span>

                                                            
														</div>--%>

                                                        <asp:TextBox ID="txtETime" runat="server"  class="m-wrap span12" type="text"> </asp:TextBox>
                                                              <%-- <asp:Image ID="Image1" runat="server" ImageUrl="Calendar-schedulehs.png"/>--%>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                                                               TargetControlID="txtETime" Format="dd-MM-yyyy" PopupButtonID="txtETime">
                                                            </ajaxToolkit:CalendarExtender>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                            ControlToValidate="txtETime" ErrorMessage="Provide end time" 
                                                            ForeColor="Red" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>

															</div>
														</div>
													</div>
													<!--/span-->
												</div>
												<!--/row-->        
												<%--<div class="row-fluid">
													<div class="span6 ">
														<div class="control-group">
															<label class="control-label">PinCode</label>
															<div class="controls">
															<asp:DropDownList ID="ddlPincode" runat="server" AutoPostBack="True"  class="m-wrap span12"
                                                            onselectedindexchanged="ddlPincode_SelectedIndexChanged">
                                                          </asp:DropDownList>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="NA"
                                                          ControlToValidate="ddlPincode" ErrorMessage="Provide pincode" 
                                                          ForeColor="Red" Display="Dynamic">
                                                         </asp:RequiredFieldValidator>
															</div>
														</div>
													</div>
													<!--/span-->
													     <div class="span6 ">
                                                         <div class="control-group">
                                                         <label class="control-label">State</label>
                                                         <div class="controls">
                                                        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" class="m-wrap span12" 
                                                            onselectedindexchanged="ddlState_SelectedIndexChanged">
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="NA"
                                                          ControlToValidate="ddlState" ErrorMessage="Provide state name" 
                                                          ForeColor="Red" Display="Dynamic">
                                                         </asp:RequiredFieldValidator>
                                                        </div>
                                                       </div>
                                                     </div>
													<!--/span-->
												</div>--%>

                                                <div class="row-fluid">

                                                <!--/span-->
                                                <div class="span6 ">
														<div class="control-group">
															<label class="control-label">State</label>
															<div class="controls">                                                
															<asp:ListBox ID="ListState" runat="server" class="m-wrap span12"   
                                                            SelectionMode="Multiple" onselectedindexchanged="ListState_SelectedIndexChanged" 
                                                            AutoPostBack="True"></asp:ListBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" InitialValue="NA"
                                                          ControlToValidate="ddlCityName" ErrorMessage="Provide city name" 
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
                                                        SelectionMode="Multiple" onselectedindexchanged="ListBoxDistrict_SelectedIndexChanged"></asp:ListBox>
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
                                                     Text="Submit" onclick="BtnSubmit_Click" />
                                                    
                                                   
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
	<script src="../plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js" type="text/javascript" ></script>
	<!--[if lt IE 9]>
	<script src="plugins/excanvas.min.js"></script>
	<script src="plugins/respond.min.js"></script>  
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

     <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
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
	        $("#<%=txtSTime.ClientID%>,#<%=txtETime.ClientID %>").datepicker({
	            changeMonth: true, //this option for allowing user to select month
	            changeYear: true, //this option for allowing user to select from year range
	            dateFormat: 'mm-dd-yy'
	        });
//	        App.init();
	        Search.init();
	    });
	</script>
	<!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>