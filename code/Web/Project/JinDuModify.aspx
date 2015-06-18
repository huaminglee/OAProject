<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JinDuModify.aspx.cs" Inherits="Project_JinDuModify" %>

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
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;项目管理&nbsp;>>&nbsp;修改项目进度信息
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
        <!--******************************增加页面代码********************************-->
        <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    项目名称：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtProjectName" runat="server" Width="350px"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProjectName"
                        Display="Dynamic" ErrorMessage="*该项不可为空！"></asp:RequiredFieldValidator>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPProject&LieName=ProjectName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtProjectName').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    项目编号：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtProjectSerils" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPProject&LieName=ProjectSerils&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtProjectSerils').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    阶段名称：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtJieDuanName" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPJinDu&LieName=JieDuanName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtJieDuanName').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    开始时间：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <input class="Wdate" type="text" autocomplete="off" id="txtStartTime" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" /><asp:RangeValidator ID="RangeValidator1"
                            runat="server" ControlToValidate="txtStartTime" Display="Dynamic" ErrorMessage="*日期格式不正确"
                            MaximumValue="2099-01-01" MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStartTime"
                                Display="Dynamic" ErrorMessage="*该项不可为空！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    结束时间：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <input class="Wdate" type="text" autocomplete="off" id="txtEndTime" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" /><asp:RangeValidator ID="RangeValidator2"
                            runat="server" ControlToValidate="txtEndTime" Display="Dynamic" ErrorMessage="*日期格式不正确"
                            MaximumValue="2099-01-01" MinimumValue="1900-01-01" Type="Date"></asp:RangeValidator><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEndTime" Display="Dynamic"
                                ErrorMessage="*该项不可为空！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    完成度：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtWanChengDu" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPJinDu&LieName=WanChengDu&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtWanChengDu').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    负责人：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtFuZeRen" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPJinDu&LieName=FuZeRen&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtFuZeRen').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    附件文件：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                    &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False"
                        ImageAlign="AbsMiddle" ImageUrl="../images/Button/DelFile.jpg" OnClick="ImageButton3_Click" />
                    &nbsp; &nbsp;
                    <asp:ImageButton ID="ImageButton4" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
                        ImageUrl="~/images/Button/ReadFile.gif" OnClick="ImageButton4_Click" />
                    &nbsp; &nbsp;&nbsp;
                    <asp:ImageButton ID="ImageButton5" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
                        ImageUrl="~/images/Button/EditFile.gif" OnClick="ImageButton5_Click" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    上传附件：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="350px" />
                    <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
                        ImageUrl="../images/Button/UpLoad.jpg" OnClick="ImageButton2_Click" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    详细内容：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtContentStr" runat="server" Width="350px" Height="101px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
