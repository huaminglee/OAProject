<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomModify.aspx.cs" Inherits="CRM_CustomModify" %>

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
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;客户管理&nbsp;>>&nbsp;修改客户信息
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
                    客户名称：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCustomName" runat="server" Width="350px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomName"
                        ErrorMessage="*该项不可以为空！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    客户编号：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCustomSerils" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    负责人：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtChargeMan" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    客户地址：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtAddress" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    客户单位网站：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtUrlLink" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    邮编：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtYouBian" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    联系电话：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtTelStr" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    客户性质：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtXingZhi" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomInfo&LieName=XingZhi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtXingZhi').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    客户来源：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtLaiYuan" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomInfo&LieName=LaiYuan&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtLaiYuan').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    所在区域：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtQuYu" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomInfo&LieName=QuYu&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtQuYu').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    客户状态：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtZhuangTai" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomInfo&LieName=ZhuangTai&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtZhuangTai').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    人数：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtRenShu" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    办公面积：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtBanGongMianJi" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    客户类别：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtLeiBie" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomInfo&LieName=LeiBie&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtLeiBie').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    客户级别：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtJiBie" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomInfo&LieName=JiBie&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtJiBie').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    业务范围：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtYeWuFanWei" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomInfo&LieName=YeWuFanWei&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtYeWuFanWei').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    所属行业：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtHangYe" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomInfo&LieName=HangYe&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtHangYe').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    目前主要问题：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtMuQianWenTi" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    预计下达订单时间：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                     <input class="Wdate" type="text" autocomplete="off" id="txtYuJiDingDanDate" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    提醒时间：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtYuJiTiXing" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var dataString = showModalDialog('../JS/calendar.htm', 'yyyy-mm-dd' ,'dialogWidth:286px;dialogHeight:221px;status:no;help:no;');if(dataString==null){}else{document.getElementById('txtYuJiTiXing').value=dataString;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    订单及利润情况：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtDingDanCount" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomInfo&LieName=DingDanCount&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtDingDanCount').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    共享人员：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtIFShare" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=ERPUser&LieName=UserName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtIFShare').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    收款情况：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCusBakD" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomInfo&LieName=CusBakD&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtCusBakD').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    综合评分：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCusBakE" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomInfo&LieName=CusBakE&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtCusBakE').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    客户自定义A：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCusBakA" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomInfo&LieName=CusBakA&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtCusBakA').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    客户自定义B：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCusBakB" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomInfo&LieName=CusBakB&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtCusBakB').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    客户自定义C：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCusBakC" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomInfo&LieName=CusBakC&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtCusBakC').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    信息化管理：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtBackInfoA" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?GetTable=ERPCrmSetting&TableName=ERPCustomInfo&LieName=BackInfoA&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtBackInfoA').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    设备情况：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtBackInfoB" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    原有供应商：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtBackInfoC" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    公司名称英文：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtNameEng" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=NameEng&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtNameEng').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    法人代码：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtFaRenDaiMa" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=FaRenDaiMa&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtFaRenDaiMa').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    营业执照：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtYingYeZhiZhao" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=YingYeZhiZhao&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtYingYeZhiZhao').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    资本额：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtZiBenE" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=ZiBenE&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtZiBenE').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    组织性质：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtZuZhiXingZhi" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=ZuZhiXingZhi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtZuZhiXingZhi').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    营业场所：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtYingYeChangSuo" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=YingYeChangSuo&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtYingYeChangSuo').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    经济状况：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtJingJi" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=JingJi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtJingJi').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    社会关系：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtSheHuiGuanXi" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=SheHuiGuanXi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtSheHuiGuanXi').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    与本公司关系：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtBenGongSiGuanXi" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=BenGongSiGuanXi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtBenGongSiGuanXi').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    介绍人：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtJieShaoRen" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=JieShaoRen&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtJieShaoRen').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    保证人：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtBaoZhengRen" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=BaoZhengRen&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtBaoZhengRen').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    税票名称：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtShuiPiaoName" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=ShuiPiaoName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtShuiPiaoName').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    地址电话：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtDiZhiDianHua" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=DiZhiDianHua&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtDiZhiDianHua').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    纳税登记号：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtNaShuiDengJiHao" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=NaShuiDengJiHao&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtNaShuiDengJiHao').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    开户行账号：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtKaiHuHangZhangHao" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=KaiHuHangZhangHao&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtKaiHuHangZhangHao').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    交易方式：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtJiaoYiFangShi" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=JiaoYiFangShi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtJiaoYiFangShi').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    帐期：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtZhangQi" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=ZhangQi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtZhangQi').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    付款方式：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtFuKuanFangShi" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=FuKuanFangShi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtFuKuanFangShi').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    运费承担方：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtYunFeiChengDan" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=YunFeiChengDan&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtYunFeiChengDan').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    促销费用：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCuXiaoFei" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=CuXiaoFei&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtCuXiaoFei').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    广告费用：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtGuangGaoFei" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=GuangGaoFei&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtGuangGaoFei').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    优待折扣：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtYouDaiZheKou" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=YouDaiZheKou&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtYouDaiZheKou').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    付款态度：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtFuKuanTaiDu" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=FuKuanTaiDu&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtFuKuanTaiDu').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    要否对账：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtShiFouDuiZhang" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=ShiFouDuiZhang&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtShiFouDuiZhang').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    对账时间：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtDuiZhangShiJian" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=DuiZhangShiJian&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtDuiZhangShiJian').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    最佳拜访时间：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtZuiJiaPaiFangShiJian" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=ZuiJiaPaiFangShiJian&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtZuiJiaPaiFangShiJian').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    最佳收款时间：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtZuiJiaShouKuanShiJian" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=ZuiJiaShouKuanShiJian&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtZuiJiaShouKuanShiJian').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    同类产品其他供应客户：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtQiTaGongYing" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=QiTaGongYing&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtQiTaGongYing').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    常用哪家产品及原因：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtChangYongNaJia" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=ChangYongNaJia&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtChangYongNaJia').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    对本公司意见：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtGongSiYiJian" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=GongSiYiJian&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtGongSiYiJian').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    资信：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtZiXin" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=ZiXin&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtZiXin').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    总结论：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtZongJieLun" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPCustomInfo&LieName=ZongJieLun&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtZongJieLun').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    备注说明：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtBackInfoD" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    所属业务员：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    创建时间：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
