<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataCleanByMobileNo.aspx.cs" Inherits="Admin_DataCleanByMobileNo" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/SideBar.ascx" TagPrefix="uc1" TagName="Footer" %>

<!DOCTYPE html>



<!--[if !IE]><!--> <html lang="en" class="no-js"> <!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
	<meta charset="utf-8" />
	<title>Valvoline | Admin  </title>
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
	<link href="../aplugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
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
	<link rel="shortcut icon" href="../favicon.ico" />
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
						<h3 class="page-title">
							Data Cleaning <small>By Mobile Number</small>
						</h3>
						<ul class="breadcrumb">
							<li>
								<i class="icon-home"></i>
								<a href="../User/Default.aspx">Home</a> 
								<i class="icon-angle-right"></i>
							</li>
							<li><a href="DataCleanByMobileNo.aspx">DataCleaning</a></li>
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
                    <form runat="server" method="post" enctype="multipart/form-data">
                        <asp:FileUpload  ID="FileUpload1" runat="server" class="btn bg-yellow fileupload" /> <br />
                        
                        <br />
                        <asp:Button ID="btnUpload" runat="server" Text="Upload MobileNumber" class="btn green fileupload" OnClick="btnUpload_Click"  />
                        <br />
                        <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="lblError" runat="server" visible="false"></asp:Label>
                        <br />
                         <asp:Button ID="BtbDownload" runat="server" Text="Download MobileNumber Sample Sheet" class="btn green fileupload" 
                             OnClick="BtbDownload_Click"  />
                        <br /><br />
                        
                        <asp:GridView ID="GridViewByMobile" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                            CssClass="table table-striped table-hover table-bordered" PageSize="50" DataKeyNames="contact_number"
                            OnPageIndexChanging="GridViewByMobile_PageIndexChanging" OnRowCommand="GridViewByMobile_RowCommand">
                            
                            <Columns>
                            <asp:TemplateField headerText="Mechanic Name">
                                  <ItemTemplate>
                                       <%#Eval("name_of_person")%>
                                   </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField headerText="Name Of Outlet">
                                  <ItemTemplate>
                                       <%#Eval("name_of_outlet")%>
                                   </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField headerText="Contact Number">
                                  <ItemTemplate>
                                       <%#Eval("contact_number")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>

                                     
                                    <asp:TemplateField headerText="Team Name">
                                  <ItemTemplate>
                                       <%#Eval("team_name")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>

                                      <asp:TemplateField headerText="Organization Source">
                                  <ItemTemplate>
                                       <%#Eval("organization_source")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>

                                    <asp:TemplateField headerText="Authenticated By">
                                  <ItemTemplate>
                                       <%#Eval("authenticated_by")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>

                                      <asp:TemplateField headerText="Authenticated Contact">
                                  <ItemTemplate>
                                       <%#Eval("authenticated_contact")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                             

                                      <asp:TemplateField headerText="Record Input Form">
                                  <ItemTemplate>
                                       <%#Eval("record_input_form")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>

                                   <asp:TemplateField headerText="Created On">
                                  <ItemTemplate>
                                       <%#Eval("createdOn")%>
                                   </ItemTemplate>
                                    </asp:TemplateField> 

                                <asp:templatefield HeaderText="Select">
                                      <HeaderTemplate>
                                         <asp:CheckBox ID="chkboxSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkboxSelectAll_CheckedChanged" />
                                    </HeaderTemplate>
                                    <itemtemplate>
                                      <asp:CheckBox ID="chkDel" runat="server" />
                                   </itemtemplate>
                                 </asp:templatefield>
                                  </Columns>

                        </asp:GridView>
                         <div align="Center">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn red fileupload" visible ="false"
                    OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete selected items?');"/>
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
</body>
<!-- END BODY -->
</html>