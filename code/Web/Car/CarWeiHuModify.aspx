<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarWeiHuModify.aspx.cs" Inherits="Car_CarWeiHuModify" %>

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
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;车辆管理&nbsp;>>&nbsp;修改车辆维护信息
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
                    车辆名称：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCarName" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCarInfo&LieName=CarName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtCarName').value=wName;}"
                        src="../images/Button/search.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCarName"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    维护日期：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <input class="Wdate" type="text" autocomplete="off" id="txtWeiHuRiQi" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    维护类型：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtWeiHuLeiXing" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCarWeiHu&LieName=WeiHuLeiXing&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtWeiHuLeiXing').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    维护原因：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtWeiHuYuanYin" runat="server" Width="350px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    经办人：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtJingBanUser" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=ERPUser&LieName=UserName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtJingBanUser').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    维护费用：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtWeiHuFeiYong" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    录入人：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtUserName" runat="server" Width="350px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    录入时间：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtTimeStr" runat="server" Width="350px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    备注信息：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtBackInfo" runat="server" Width="350px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
