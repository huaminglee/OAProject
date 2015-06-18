<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherAdd.aspx.cs" Inherits="Educational_PaikeAdd" %>

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
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;教师管理&nbsp;>>&nbsp;添加教师信息
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
                    姓名：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <input type="text" id="txtName" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                        ErrorMessage="*该项不可以为空！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    年龄：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtAge" runat="server" Width="350px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAge"
                        ErrorMessage="*该项不可以为空！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    生日：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <input class="Wdate" type="text" autocomplete="off" id="txtBirth" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" /><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                            runat="server" ControlToValidate="txtBirth" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    联系方式：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtMobile" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    性别：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtSex" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    地址：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtAddress" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    添加时间：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <input class="Wdate" type="text" autocomplete="off" id="txtAddTime" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" /><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server" ControlToValidate="txtAddTime" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
