<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PeiXunAdd.aspx.cs" Inherits="DocFile_PeiXunAdd" %>

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
                    <a class="hei" href="../Main/MyDesk.aspx">����</a>&nbsp;>>&nbsp;��ѵ����&nbsp;>>&nbsp;�����ѵ��Ϣ
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
                    ��ѵ���ƣ�
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtPeiXunName" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPPeiXun&LieName=PeiXunName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtPeiXunName').value=wName;}"
                        src="../images/Button/search.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPeiXunName"
                        ErrorMessage="*�������Ϊ��"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    ��ѵ�ˣ�
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtPeiXunUser" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=ERPUser&LieName=UserName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtPeiXunUser').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    �����ˣ�
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtCanYuUser" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=ERPUser&LieName=UserName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtCanYuUser').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    ��ʼʱ�䣺
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <input class="Wdate" type="text" autocomplete="off" id="txtStartDate" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    ����ʱ�䣺
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <input class="Wdate" type="text" autocomplete="off" id="txtEndDate" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    ��ѵĿ�ģ�
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtPeiXunMuDi" runat="server" Width="350px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    ��ѵ���ݣ�
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtPeiXunNeiRong" runat="server" Width="350px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    ��ѵЧ����
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtXiaoGuo" runat="server" Width="350px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    ��ע˵����
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtBackInfo" runat="server" Width="350px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    �����ļ���
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                    &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False"
                        ImageAlign="AbsMiddle" ImageUrl="../images/Button/DelFile.jpg" OnClick="ImageButton3_Click" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    �ϴ�������
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="350px" />
                    <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
                        ImageUrl="../images/Button/UpLoad.jpg" OnClick="ImageButton2_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
