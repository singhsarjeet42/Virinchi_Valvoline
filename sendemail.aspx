<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sendemail.aspx.cs" Inherits="sendemail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <div>
            <table style="width: 1000px; font-size: large; margin-left: 33px;">
                <tr>
                    <td>From
                    </td>
                    <td>
                        <asp:TextBox ID="From" runat="server"></asp:TextBox>
                    </td>
                    <td>To
                    </td>
                    <td>
                        <asp:TextBox ID="To" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 20px;"></td>
                </tr>
                <tr>

                    <td>Body
                    </td>
                    <td>
                        <asp:TextBox ID="Body" runat="server"></asp:TextBox>
                    </td>
                    <td>Subject
                    </td>
                    <td>
                        <asp:TextBox ID="Subject" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="4" style="height: 20px;"></td>
                </tr>

                <tr>
                    <td>Host Name
                    </td>
                    <td>
                        <asp:TextBox ID="HostName" runat="server"></asp:TextBox>
                    </td>
                    <td>Port Number
                    </td>
                    <td>
                        <asp:TextBox ID="PortNumber" runat="server"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td colspan="4" style="height: 20px;"></td>
                </tr>
                <tr>
                    <td style='vertical-align: top;'>Password
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <asp:Button ID="Send" runat="server" Text="Button" OnClick="Send_Click" />
        </div>
    </form>
</body>
</html>
