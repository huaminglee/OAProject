<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<html>
<head>
    <title>
        <%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
    <link href="../Style/Style.css" type="text/css" rel="STYLESHEET">
    <script language="javascript">
        function visible_click() {
            if (td1.className == "") {
                td1.className = "tddisp";
                main.middle_picture.src = "../images/Jt_right.gif";
            }
            else if (td1.className == "tddisp") {
                td1.className = "";
                main.middle_picture.src = "../images/Jt_left.gif";
            }
        }

        function OnUpOrDown() {
            if (UPOrDown.className == "") {
                UPOrDown.className = "tddisp";
                main.UpDownImg.src = "../images/Down.gif";
            }
            else if (UPOrDown.className == "tddisp") {
                UPOrDown.className = "";
                main.UpDownImg.src = "../images/UP.gif";
            }
        }
                    
         
    </script>
</head>
<body scroll="no" onload="setInterval(nowtime,1000)">
    <form id="main" method="post" runat="server">
    <table width="100%" height="100%" cellspacing="0" cellpadding="0" border="0">
        <tr id="UPOrDown">
            <td height="50" background="../images/TitleBg.gif" style="width: 410">
                <img src="../images/Logo2.jpg" />
            </td>
            <td height="50" background="../images/TitleBg.gif" align="right">
                <iframe align="absMiddle" src="http://m.weather.com.cn/m/pn4/weather.htm " width="160"
                    height="20" marginwidth="0" marginheight="0" hspace="0" vspace="10" frameborder="0"
                    allowtransparency="true" scrolling="no"></iframe>
                <script language="JavaScript">
                    today = new Date();
                    function initArray() {
                        this.length = initArray.arguments.length
                        for (var i = 0; i < this.length; i++)
                            this[i + 1] = initArray.arguments[i]
                    }
                    var d = new initArray(
     "星期日",
     "星期一",
     "星期二",
     "星期三",
     "星期四",
     "星期五",
     "星期六");
                    document.write(
     "",
     today.getYear(), "年",
     today.getMonth() + 1, "月",
     today.getDate(), "日   ",
     d[today.getDay() + 1],
     ""); 
                </script>
                &nbsp;&nbsp;<img align="absMiddle" src="../images/time.gif" />
                <span id="t1">
                    <script language="javascript">                        todaytime1 = new Date(); t1.innerText = todaytime1.toLocaleTimeString();</script>
                </span>&nbsp;&nbsp;
                <script language="javascript">
                    function nowtime() {
                        todaytime = new Date();
                        //t1.innerText=todaytime.getHours()+'：'+todaytime.getMinutes()+'：'+todaytime.getSeconds();
                        t1.innerText = todaytime.toLocaleTimeString();
                    }
                </script>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="185" height="100%" valign="top" class="" id="td1">
                            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr bgcolor="#EBE9ED">
                                    <td width="185" background="../images/BackWhite.gif" style="height: 27px">
                                        &nbsp;&nbsp;<img align="absMiddle" height="18" src="../images/node_user.gif" width="18" />&nbsp;<strong><span
                                            style="color: #ffffff">欢迎您：<%= ZWL.Common.PublicMethod.GetSessionValue("UserName")%></span></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="185" bgcolor="#FFFFFF" height="100%" style="padding-bottom: 5px; padding-left: 2px;">
                                        <table width="185" height="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td height="28">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td colspan="5" height="2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="22" height="28" background="../images/Tree_01_01.jpg">
                                                                &nbsp;
                                                            </td>
                                                            <td height="28" background="../images/Tree_01_02.jpg" colspan="3" style="text-align: center;
                                                                vertical-align: middle;">
                                                                <img align="absMiddle" height="18" src="../images/TreeImages/@bbs.gif" width="18" /><a
                                                                    target="rform" class="hei" href="../Main/OnlineUser.aspx">组织</a>
                                                                <img align="absMiddle" height="18" src="../images/TreeImages/webmail.gif" width="18" /><a
                                                                    target="rform" class="hei" href="../LanEmail/LanEmailShou.aspx">邮件</a>
                                                                <img align="absMiddle" height="18" src="../images/TreeImages/winexe.gif" width="18" /><a
                                                                    target="rform" class="hei" href="../Main/About.aspx">关于</a>
                                                            </td>
                                                            <td width="21" height="28" background="../images/Tree_01_05.jpg">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table bgcolor="#FFFFFF" width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="9" background="../images/Tree_03_01.jpg">
                                                                &nbsp;
                                                            </td>
                                                            <td background="../images/Tree_03_02.jpg">
                                                                <div style="overflow-y: auto; overflow-x: hidden; height: 100%;">
                                                                    <asp:TreeView ID="ListTreeView" runat="server" ExpandDepth="0" ForeColor="Black"
                                                                        Width="100%" ShowLines="True">
                                                                        <ParentNodeStyle HorizontalPadding="2px" />
                                                                        <RootNodeStyle HorizontalPadding="2px" Height="20px" Width="100%" />
                                                                        <LeafNodeStyle HorizontalPadding="2px" />
                                                                    </asp:TreeView>
                                                                </div>
                                                            </td>
                                                            <td width="12" background="../images/Tree_03_03.jpg">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="20" height="5">
                                                                <img width="20" height="5" src="../images/Tree_04_01.jpg" />
                                                            </td>
                                                            <td height="5" background="../images/Tree_04_02.jpg" colspan="3">
                                                            </td>
                                                            <td width="25" height="5">
                                                                <img width="25" height="5" src="../images/Tree_04_05.jpg" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="0%">
                            <table width="0%" border="0" cellpadding="0" cellspacing="0" height="100%">
                                <tr>
                                    <td background="../images/BackWhite.gif" height="27px">
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#FFFFFF">
                                        <img onclick="visible_click()" style="cursor: hand;" src="../images/Jt_left.gif"
                                            id="middle_picture">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="100%" height="100%">
                            <table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
                                            <tr>
                                                <td height="27" background="../images/BackWhite.gif">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="right">
                                                                <a class="bai" href="DingYi.aspx" target="rform">
                                                                    <img align="absMiddle" alt="定义导航菜单" border="0" height="16" src="../images/TreeImages/diary.gif"
                                                                        width="16" />
                                                                    定义导航</a>&nbsp; <a class="bai" href="MyDesk.aspx" target="rform">
                                                                        <img align="absMiddle" alt="我的办公桌" border="0" height="16" src="../images/TreeImages/mytable.gif"
                                                                            width="16" />&nbsp;桌面</a>&nbsp; <a class="bai" href="../Personal/SystemTiXing.aspx"
                                                                                target="rform">
                                                                                <img align="absMiddle" alt="提醒设置" border="0" height="16" src="../images/TreeImages/theme.gif"
                                                                                    width="16" />&nbsp;提醒</a>&nbsp; <a class="bai" href="../Default.aspx">
                                                                                        <img align="absMiddle" alt="注销用户" border="0" src="../images/login.gif" />&nbsp;注销</a>
                                                                &nbsp;<img id="UpDownImg" align="absMiddle" alt="折叠" onclick="OnUpOrDown();" class="HerCss"
                                                                    border="0" src="../images/UP.gif" />&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" width="100%" height="100%" style="padding-bottom: 5px; padding-top: 5px;
                                                    padding-left: 5px;">
                                                    <iframe name="rform" frameborder="0" marginheight="0" marginwidth="0" width="100%"
                                                        height="100%" bordercolor="#ffffFF" src="MyDesk.aspx" border="0"></iframe>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="20" colspan="2" background="../images/BottomBg.gif" valign="middle">
                <table border="0" cellpadding="0" cellspacing="0" class="small" width="100%">
                    <tr>
                        <td valign="middle">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td valign="middle" height="25px" style="padding-left: 10px;">
                                        <iframe name="bform" frameborder="0" marginheight="0" marginwidth="0" width="150px"
                                            height="25px" src="Blank.aspx" border="0" allowtransparency="true" scrolling="no">
                                        </iframe>
                                    </td>
                                    <td>
                                    </td>
                                    <td valign="middle" align="right" style="padding-right: 10px;">
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
