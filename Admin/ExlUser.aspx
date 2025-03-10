<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExlUser.aspx.cs" Inherits="Admin_ExlUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                  CssClass="table table-striped table-hover table-bordered" AllowPaging="False">
                  <Columns>
                        
                        <asp:TemplateField headerText="User Name">
                        <ItemTemplate>
                              <%#Eval("user_name")%>
                        </ItemTemplate>
                        </asp:TemplateField>

                      <asp:TemplateField headerText="Campaign Name">
                      <ItemTemplate>
                            <%#Eval("campaign_name")%>
                      </ItemTemplate>
                      </asp:TemplateField>

                      <asp:TemplateField headerText="Team Name">
                        <ItemTemplate>
                              <%#Eval("team_name")%>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                      <asp:TemplateField headerText="Mobile Number">
                                  <ItemTemplate>
                                       <%#Eval("MobileNo") %>
                                   </ItemTemplate>
                                    </asp:TemplateField>

                                         <asp:TemplateField headerText="Email Id">
                                  <ItemTemplate>
                                       <%#Eval("EmailId") %>
                                   </ItemTemplate>
                                    </asp:TemplateField>

                                        <asp:TemplateField headerText="Role">
                                  <ItemTemplate>
                                       <%#Eval("Roles") %>
                                   </ItemTemplate>
                                    </asp:TemplateField>

                                        <asp:TemplateField headerText="Password">
                                  <ItemTemplate>
                                       <%#Eval("Password") %>
                                   </ItemTemplate>
                                    </asp:TemplateField>
                 </Columns>
                                  
   </asp:GridView>            
    </div>
   
    </form>
</body>

</html>
