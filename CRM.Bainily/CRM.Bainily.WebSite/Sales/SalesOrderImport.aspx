<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesOrderImport.aspx.cs" Inherits="Sales_SalesOrderImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        *{
            background-color:  darkgray;
        }
        table {
            width: 70%;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="header">
                <tr>
                    <td>
                        <asp:Literal ID="title" Text="开票申请及明细导入" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <input id="hidMsg" type="hidden" runat="server" />
                    </td>
                </tr>
            </table>
            <table class="query">
                <tr>
                    <td style="height: 14px"></td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;
                    <asp:Label ID="lblImpContect" runat="server" CssClass="Text" Text="选择导入的文件：" Font-Size="9pt"></asp:Label>
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="378px" />
                    </td>
                    <td style="height: 26px; text-align: right; margin-right: 10px">
                        <asp:Button ID="btnImport" runat="server" Text="导入" CssClass="button" OnClick="btnImport_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 200px; text-align: center" colspan="2">
                        <asp:TextBox ID="txtLog" runat="server" Height="300px" ReadOnly="true" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
