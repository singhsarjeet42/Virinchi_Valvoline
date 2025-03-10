<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExlViewTeam.aspx.cs" Inherits="Admin_ExlViewTeam" EnableEventValidation="false" %>

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

                    <asp:TemplateField HeaderText="Organization Name">
                        <ItemTemplate>
                            <%#Eval("name")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Team Name">
                        <ItemTemplate>
                            <%#Eval("team_name")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Password">
                        <ItemTemplate>
                            <%#Eval("password")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="User Type">
                        <ItemTemplate>
                            <%#Eval("user_type")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="State">
                        <ItemTemplate>
                            <%#Eval("state")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="District">
                        <ItemTemplate>
                            <%#Eval("District")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                   

                </Columns>

            </asp:GridView>
        </div>

    </form>
</body>

</html>
