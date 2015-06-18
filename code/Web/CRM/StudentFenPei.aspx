<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentFenPei.aspx.cs" Inherits="CRM_CustomAdd" %>

<html>
<head>
    <title>
        <%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
    <link href="../Style/Style.css" type="text/css" rel="STYLESHEET">
    <script src="../JS/My97DatePickerBeta/WdatePicker.js" type="text/javascript"></script>
    <script language="javascript">
        function PrintTable() {
            document.getElementById("PrintHide").style.visibility = "hidden"
            print();
            document.getElementById("PrintHide").style.visibility = "visible"
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img src="../images/BanKuaiJianTou.gif" />
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;学生管理&nbsp;>>&nbsp;分配学生
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Button/Submit.jpg"
                        OnClick="ImageButton1_Click" />
                    <img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;
                </td>
            </tr>
            <tr>
                <td height="3px" colspan="2" style="background-color: #ffffff">
                </td>
            </tr>
        </table>
        <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    顾问人员：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:DropDownList ID="ddlGuwenlist" runat="server" Width="200px" AppendDataBoundItems="true">
                        <asp:ListItem Value="">请选择</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlGuwenlist"
                        ErrorMessage="*该项不可以为空！"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
