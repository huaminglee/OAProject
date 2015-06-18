<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TreeListAdd.aspx.cs" Inherits="SystemManage_TreeListAdd" %>
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
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;菜单管理&nbsp;>>&nbsp;添加信息
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
		显示文字：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtTextStr" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPTreeList&LieName=TextStr&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtTextStr').value=wName;}"  src="../images/Button/search.gif" />
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTextStr" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		所用图片：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtImageUrlStr" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPTreeList&LieName=ImageUrlStr&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtImageUrlStr').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		后台数值：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtValueStr" runat="server" Width="350px"></asp:TextBox>
        当前最后一项为：<asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>&nbsp;
        子节点为数值，父节点可设置为和显示文字相同。</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		链接地址：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtNavigateUrlStr" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPTreeList&LieName=NavigateUrlStr&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtNavigateUrlStr').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		目标框架：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtTarget" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPTreeList&LieName=Target&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtTarget').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		父节点：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtParentID" runat="server" Width="350px"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtParentID"
            Display="Dynamic" ErrorMessage="*该项必须输入数字" MaximumValue="10000" MinimumValue="0"
            Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                runat="server" ControlToValidate="txtParentID" ErrorMessage="*该项不可为空"></asp:RequiredFieldValidator></td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		权限：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtQuanXianList" runat="server" Width="350px">A_添加|M_修改|D_删除|E_导出</asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPTreeList&LieName=QuanXianList&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtQuanXianList').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		排序：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtPaiXuStr" runat="server" Width="350px"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtPaiXuStr"
            Display="Dynamic" ErrorMessage="*该项必须输入数字" MaximumValue="10000" MinimumValue="0"
            Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                runat="server" ControlToValidate="txtPaiXuStr" ErrorMessage="*该项不可为空"></asp:RequiredFieldValidator></td></tr>
</table>
		</div>
	</form>
</body>
</html>
