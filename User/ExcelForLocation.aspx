<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExcelForLocation.aspx.cs" Inherits="User_ExcelForLocation" %>

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


                    <asp:TemplateField HeaderText="State Name">
                        <ItemTemplate>
                            <%#Eval("state")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="City Name">
                        <ItemTemplate>
                            <%#Eval("city")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="District">
                        <ItemTemplate>
                            <%#Eval("district")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Pin code">
                        <ItemTemplate>
                            <%#Eval("pincode")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>

    </form>
</body>
</html>
