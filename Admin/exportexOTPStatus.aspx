<%@ Page Language="C#" AutoEventWireup="true" CodeFile="exportexOTPStatus.aspx.cs" Inherits="Admin_exportexOTPStatus" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <title></title>
</head>
<body bgcolor="Silver">
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="DataGridview" runat="server" AutoGenerateColumns="False"
                OnRowCommand="DataGridview_RowCommand"
                CssClass="table table-striped table-hover table-bordered" AllowPaging="False"
                OnPageIndexChanging="DataGridview_PageIndexChanging">
                <Columns>


                    <asp:TemplateField HeaderText="Source User">
                        <ItemTemplate>
                            <%#Eval("user_name")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Mechanic Mobile Number">
                        <ItemTemplate>
                            <%#Eval("MobileNumber")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="OTP">
                        <ItemTemplate>
                            <%#Eval("otp")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Gateway Message">
                        <ItemTemplate>
                            <%#Eval("Message")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="OTP Date & Time">
                        <ItemTemplate>
                            <%#Eval("CreatedOn")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        </div>

    </form>
</body>
</html>
