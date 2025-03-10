<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DownloadDupData.aspx.cs" Inherits="Admin_Default" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <title></title>
</head>
<body bgcolor="Silver">
    <form id="form1" runat="server">
    <%-- <br />
    <h2 style="color: #808000; font-size: x-large; font-weight: bolder;">
        Article by Vithal Wadje</h2>
    <br />
   --%>
    <div>
   <asp:GridView ID="DataGridview" runat="server" AutoGenerateColumns="False" 
                  onrowcommand="DataGridview_RowCommand"   
                  CssClass="table table-striped table-hover table-bordered" AllowPaging="False" 
                  onpageindexchanging="DataGridview_PageIndexChanging" >
                  <Columns>
                   <%--<asp:ImageField DataImageUrlField="image_url" ControlStyle-Width="100"
                           ControlStyle-Height = "100" HeaderText = "Preview Image"/>--%>
                                    
                                   <%-- <asp:TemplateField headerText="Image">
                                    <ItemTemplate>
                                       <%#Eval("image")%>
                                     </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField headerText="id">
                                  <ItemTemplate>
                                       <%#Eval("id")%>
                                   </ItemTemplate>
                                    </asp:TemplateField>
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

                                     <asp:TemplateField headerText="Cantact Number">
                                  <ItemTemplate>
                                       <%#Eval("contact_number")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>

                                      <asp:TemplateField headerText="Pincode">
                                  <ItemTemplate>
                                       <%#Eval("pincode")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>

                                    <asp:TemplateField headerText="Date Of Birth">
                                  <ItemTemplate>
                                       <%#Eval("date_of_birth")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>

                                     <asp:TemplateField headerText="Adhar Number">
                                  <ItemTemplate>
                                       <%#Eval("adhar_number")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                      <asp:TemplateField headerText="Workshop">
                                  <ItemTemplate>
                                       <%#Eval("workshop")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                       <asp:TemplateField headerText="Segment">
                                  <ItemTemplate>
                                       <%#Eval("segment")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>

                                     <asp:TemplateField headerText="Counter Potential">
                                  <ItemTemplate>
                                       <%#Eval("counter_potential")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                     <asp:TemplateField headerText="No Of Services">
                                  <ItemTemplate>
                                       <%#Eval("no_of_services")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                      <asp:TemplateField headerText="Valvoline_usage">
                                  <ItemTemplate>
                                       <%#Eval("valvoline_usage")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                      <asp:TemplateField headerText="Preferred_retailer">
                                  <ItemTemplate>
                                       <%#Eval("preferred_retailer")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                     <asp:TemplateField headerText="Remarks">
                                  <ItemTemplate>
                                       <%#Eval("remarks")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                      <asp:TemplateField headerText="Street_location">
                                  <ItemTemplate>
                                       <%#Eval("street_location")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                      <asp:TemplateField headerText="State">
                                  <ItemTemplate>
                                       <%#Eval("state")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                    <asp:TemplateField headerText="City">
                                  <ItemTemplate>
                                       <%#Eval("city")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>

                                    <asp:TemplateField headerText="District">
                                  <ItemTemplate>
                                       <%#Eval("district")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField headerText="Campaign_id">
                                  <ItemTemplate>
                                       <%#Eval("campaign_id")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                    <asp:TemplateField headerText="Team_name">
                                  <ItemTemplate>
                                       <%#Eval("team_name")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                     <asp:TemplateField headerText="Lat">
                                  <ItemTemplate>
                                       <%#Eval("lat")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                    <asp:TemplateField headerText="Log">
                                  <ItemTemplate>
                                       <%#Eval("log")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                     <asp:TemplateField headerText="OTP Password">
                                  <ItemTemplate>
                                       <%#Eval("otp_password")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>

                                      <asp:TemplateField headerText="OTP Verification">
                                  <ItemTemplate>
                                       <%#Eval("otp_verification")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                    
                                     <%-- <asp:TemplateField headerText="Mobile Verify Status">
                                  <ItemTemplate>
                                       <%#Eval("mob_verify_status")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>--%>

                                      <asp:TemplateField headerText="Organization Source">
                                  <ItemTemplate>
                                       <%#Eval("organization_source")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                      <asp:TemplateField headerText="Authenticated Contact">
                                  <ItemTemplate>
                                       <%#Eval("authenticated_contact")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>
                                     <asp:TemplateField headerText="Authenticated By">
                                  <ItemTemplate>
                                       <%#Eval("authenticated_by")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>

                                      <asp:TemplateField headerText="Record Input Form">
                                  <ItemTemplate>
                                       <%#Eval("record_input_form")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>


                                   <asp:TemplateField headerText="IMEI Number">
                                  <ItemTemplate>
                                       <%#Eval("imei_no")%>
                                   </ItemTemplate>
                                    </asp:TemplateField>

                                 <asp:TemplateField headerText="Source Of Contact">
                                  <ItemTemplate>
                                       <%#Eval("source_of_contact")%>
                                   </ItemTemplate>
                                    </asp:TemplateField>

                                   <asp:TemplateField headerText="Created On">
                                  <ItemTemplate>
                                       <%#Eval("createdOn")%>
                                   </ItemTemplate>
                                    </asp:TemplateField>   
                                   

                                      <asp:TemplateField headerText="Near Location">
                                  <ItemTemplate>
                                       <%#Eval("near_by_location")%>
                                   </ItemTemplate>
                                    </asp:TemplateField>

                                  <%--<asp:TemplateField HeaderText="Delete">
                                 <ItemTemplate>
                                  <asp:LinkButton ID="LINK1" runat="server" Text="Delete" CommandName="Dcammand" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
                                 </ItemTemplate>
                                 </asp:TemplateField>--%>
                                  </Columns>
                                  
                                  </asp:GridView>
<%--&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp  &nbsp&nbsp&nbsp<asp:Button ID="Button1" runat="server" Text="Export To Excel" onclick="Button1_Click" />--%>
            
    </div>
   
    </form>
</body>
</html>

