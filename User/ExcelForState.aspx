<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExcelForState.aspx.cs" Inherits="User_ExcelForState" EnableEventValidation="false" %>

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
                OnRowCommand="DataGridview_RowCommand"
                CssClass="table table-striped table-hover table-bordered" AllowPaging="False"
                OnPageIndexChanging="DataGridview_PageIndexChanging">
                <Columns>
                    <%--<asp:ImageField DataImageUrlField="image_url" ControlStyle-Width="100"
                           ControlStyle-Height = "100" HeaderText = "Preview Image"/>--%>

                    <%-- <asp:TemplateField headerText="Image">
                                    <ItemTemplate>
                                       <%#Eval("image")%>
                                     </ItemTemplate>
                                    </asp:TemplateField>--%>

                    <%--  <asp:TemplateField headerText="id">
                                  <ItemTemplate>
                                       <%#Eval("id")%>
                                   </ItemTemplate>
                                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Mechanic Name">
                        <ItemTemplate>
                            <%#Eval("Mechanic Name")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name Of Outlet">
                        <ItemTemplate>
                            <%#Eval("Name Of Outlet")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Contact Number">
                        <ItemTemplate>
                            <%#Eval("Contact Number")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Pincode">
                        <ItemTemplate>
                            <%#Eval("Pincode")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Adhar Number">
                        <ItemTemplate>
                            <%#Eval("Adhar Number")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Workshop">
                        <ItemTemplate>
                            <%#Eval("Workshop")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Segment">
                        <ItemTemplate>
                            <%#Eval("Segment")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Counter Potential">
                        <ItemTemplate>
                            <%#Eval("Counter Potential")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="No Of Services">
                        <ItemTemplate>
                            <%#Eval("No Of Services")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valvoline Usage">
                        <ItemTemplate>
                            <%#Eval("Valvoline Usage")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Preferred Retailer">
                        <ItemTemplate>
                            <%#Eval("Preferred Retailer")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <%#Eval("Remarks")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Street Location">
                        <ItemTemplate>
                            <%#Eval("Street Location")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="State">
                        <ItemTemplate>
                            <%#Eval("State")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="City">
                        <ItemTemplate>
                            <%#Eval("City")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="District">
                        <ItemTemplate>
                            <%#Eval("District")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%-- <asp:TemplateField headerText="Campaign_id">
                                  <ItemTemplate>
                                       <%#Eval("campaign_id")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Team Name">
                        <ItemTemplate>
                            <%#Eval("Team Name")%>
                        </ItemTemplate>
                    </asp:TemplateField>



                    <%--<asp:TemplateField headerText="OTP Password">
                                  <ItemTemplate>
                                       <%#Eval("otp_password")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>--%>

                    <%-- <asp:TemplateField headerText="OTP Verification">
                                  <ItemTemplate>
                                       <%#Eval("otp_verification")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>--%>

                    <%-- <asp:TemplateField headerText="Mobile Verify Status">
                                  <ItemTemplate>
                                       <%#Eval("mob_verify_status")%>
                                   </ItemTemplate>                                          
                                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Organization Source">
                        <ItemTemplate>
                            <%#Eval("Organization Source")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Authenticated By">
                        <ItemTemplate>
                            <%#Eval("Authenticated By")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Authenticated Contact">
                        <ItemTemplate>
                            <%#Eval("Authenticated Contact")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date Of Birth">
                        <ItemTemplate>
                            <%#Eval("Date Of Birth")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Source Of Contact">
                        <ItemTemplate>
                            <%#Eval("user_name")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email Id">
                        <ItemTemplate>
                            <%#Eval("EmailId")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Campaign Name">
                        <ItemTemplate>
                            <%#Eval("campaign_name")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Lat">
                        <ItemTemplate>
                            <%#Eval("Lat")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Log">
                        <ItemTemplate>
                            <%#Eval("Log")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Record Input Form">
                        <ItemTemplate>
                            <%#Eval("Record Input Form")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Near Location">
                        <ItemTemplate>
                            <%#Eval("Near Location")%>
                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="Created On">
                        <ItemTemplate>
                            <%#Eval("Created On")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Created Year">
                        <ItemTemplate>
                            <%#Eval("Years")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Created Month">
                        <ItemTemplate>
                            <%#Eval("VMonth")%>
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
