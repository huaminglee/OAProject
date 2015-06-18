<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NeedAdd.aspx.cs" Inherits="CRM_NeedAdd" %>

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
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;客户管理&nbsp;>>&nbsp;添加需求信息
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
                    客户单位名称：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCustomName" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetType=My&TableName=ERPCustomInfo&LieName=CustomName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtCustomName').value=wName;}"
                        src="../images/Button/search.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomName"
                        ErrorMessage="*该项不可以为空！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    需求内容：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtNeedContent" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomNeed&LieName=NeedContent&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtNeedContent').value=wName;}"
                        src="../images/Button/search.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNeedContent"
                        ErrorMessage="*该项不可以为空！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    需求现状：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtNeedNow" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomNeed&LieName=NeedNow&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtNeedNow').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    需要产品：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtNeedProduct" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomNeed&LieName=NeedProduct&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtNeedProduct').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    需求时间：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <input class="Wdate" type="text" autocomplete="off" id="txtNeedTime" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    需求偏好：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtNeedLike" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomNeed&LieName=NeedLike&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtNeedLike').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    竞争对手：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtJingZhengDuiShou" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomNeed&LieName=JingZhengDuiShou&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtJingZhengDuiShou').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    合作意愿：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtHeZuoYiYuan" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomNeed&LieName=HeZuoYiYuan&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtHeZuoYiYuan').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    合作几率：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtHeZuoJiLv" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomNeed&LieName=HeZuoJiLv&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtHeZuoJiLv').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    需求障碍：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtNeedZhangAi" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomNeed&LieName=NeedZhangAi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtNeedZhangAi').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    共享人员：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtIFShare" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=ERPUser&LieName=UserName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtIFShare').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    客户自定义A：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCusBakA" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomNeed&LieName=CusBakA&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtCusBakA').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    客户自定义B：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCusBakB" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomNeed&LieName=CusBakB&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtCusBakB').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    客户自定义C：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCusBakC" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomNeed&LieName=CusBakC&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtCusBakC').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    客户自定义D：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCusBakD" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomNeed&LieName=CusBakD&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtCusBakD').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    客户自定义E：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCusBakE" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomNeed&LieName=CusBakE&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtCusBakE').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    备注信息：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtBackInfo" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomNeed&LieName=BackInfo&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtBackInfo').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
