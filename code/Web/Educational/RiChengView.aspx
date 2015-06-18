<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RiChengView.aspx.cs" Inherits="Work_RiChengView" %>

<html>
<head>
    <title>
        <%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
    <link href="../Style/Style.css" type="text/css" rel="STYLESHEET">
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
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;排课日程&nbsp;>>&nbsp;查看排课
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <img class="HerCss" onclick="PrintTable()" src="../images/Button/BtnPrint.jpg" />&nbsp;
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
                <td align="right" style="width: 170px; background-color: #cccccc; height: 25px;">
                    学生姓名：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                    <asp:Label ID="lcustomer" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    教室：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lclassroom" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    上课方式：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblClassStyle" runat="server"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    上课类型：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblClassType" runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    科目：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblKemu" runat="server" Width="350px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; background-color: #cccccc; height: 25px;">
                    教师：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                    <asp:Label ID="lteacher" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; background-color: #cccccc; height: 25px;">
                    助教：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                    <asp:Label ID="lassistant" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    是否完成课程：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                     <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    开始时间：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lstarttime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    结束时间：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lendtime" runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    备注：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblRemark" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
