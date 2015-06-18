<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaskFPModify.aspx.cs" Inherits="Subaltern_TaskFPModify" %>
<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
  <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
  <script language="javascript">
  function PrintTable()
    {
        document.getElementById("PrintHide") .style.visibility="hidden"    
        print();
        document.getElementById("PrintHide") .style.visibility="visible"    
    }
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;任务分配&nbsp;>>&nbsp;修改信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Button/Submit.jpg"
                        OnClick="ImageButton1_Click" />
                    <img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;</td>
            </tr>
            <tr>
            <td height="3px" colspan="2" style="background-color: #ffffff"></td>
        </tr>
        </table>
<table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		任务标题：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtTaskTitle" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPTaskFP&LieName=TaskTitle&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtTaskTitle').value=wName;}"  src="../images/Button/search.gif" />
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTaskTitle" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
	</td></tr>
    <tr>
        <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
		执行人：</td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
		<asp:TextBox id="txtToUserList" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=ERPUser&LieName=UserName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtToUserList').value=wName;}" src="../images/Button/search.gif" /><asp:CheckBox
            ID="CHKSMS" runat="server" Checked="True" /><img src="../images/TreeImages/@sms.gif" />短消息<asp:CheckBox
                ID="CHKMOB" runat="server" /><img src="../images/TreeImages/mobile_sms.gif" />短信</td>
    </tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		任务内容：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtTaskContent" Style="display: none" runat="server" Width="350px"></asp:TextBox>
		<iframe frameborder="0" height="280" scrolling="no" src="../eWebEditor/ewebeditor.htm?id=txtTaskContent&style=mini" width="99%"></iframe>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
        任务进度(%)：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtJinDu" runat="server" Width="350px"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="*必须为有效数字" ControlToValidate="txtJinDu" Display="Dynamic" MaximumValue="100" MinimumValue="0" Type="Double"></asp:RangeValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*该项必须输入" Display="Dynamic" ControlToValidate="txtJinDu"></asp:RequiredFieldValidator>
        <asp:TextBox id="txtFromUser" runat="server" Width="0px" Enabled="False" Height="0px"></asp:TextBox>
		<asp:TextBox id="txtXinXiGouTong" Style="display: none" runat="server" Width="0px" Enabled="False" Height="0px"></asp:TextBox></td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		完成情况：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtWanCheng" runat="server" Width="350px" Height="60px" TextMode="MultiLine"></asp:TextBox></td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		当前状态：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
        <asp:DropDownList ID="DropDownList1" runat="server" Width="350px">
            <asp:ListItem>任务添加</asp:ListItem>
            <asp:ListItem>等待执行</asp:ListItem>
            <asp:ListItem>正在执行</asp:ListItem>
            <asp:ListItem>任务完成</asp:ListItem>
            <asp:ListItem>任务暂停</asp:ListItem>
            <asp:ListItem>任务取消</asp:ListItem>
            <asp:ListItem>其他情况</asp:ListItem>
        </asp:DropDownList></td></tr>
</table>
		</div>
	</form>
</body>
</html>
