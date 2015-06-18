<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HuiYuanAdd.aspx.cs" Inherits="HY_HuiYuanAdd" %>
<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
  <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
    <script src="../JS/My97DatePickerBeta/WdatePicker.js" type="text/javascript"></script>
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
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;会员管理&nbsp;>>&nbsp;添加信息
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
		姓名：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtNameStr" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=NameStr&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtNameStr').value=wName;}"  src="../images/Button/search.gif" />
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNameStr" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		入会时间：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<input class="Wdate" type="text" autocomplete="off" id="txtRuHuiDate" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		介绍人
：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtJieShaoRen" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=JieShaoRen&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtJieShaoRen').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		性别
：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtSexStr" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=SexStr&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtSexStr').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		籍贯
：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtJiGuan" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=JiGuan&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtJiGuan').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		经济状况
：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtJingJi" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=JingJi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtJingJi').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		出生日期
：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<input class="Wdate" type="text" autocomplete="off" id="txtChuShengDate" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		学历
：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtXueLi" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=XueLi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtXueLi').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		资历
：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtZiLi" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=ZiLi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtZiLi').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		个性
：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtGeXing" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=GeXing&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtGeXing').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		爱好
：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtAiHao" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=AiHao&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtAiHao').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		家庭住址
：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtAddress" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=Address&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtAddress').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		电话：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtTel" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=Tel&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtTel').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		手机：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtMobTel" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=MobTel&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtMobTel').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		最佳拜访时间
：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtZuiJiaTime" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=ZuiJiaTime&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtZuiJiaTime').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		常用品牌：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtChangYong" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=ChangYong&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtChangYong').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		资信
：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtZiXin" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=ZiXin&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtZiXin').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		总结论
：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtJieLun" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ERPHuiYuan&LieName=JieLun&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtJieLun').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		备注说明：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtBackInfo" Style="display: none" runat="server" Width="350px"></asp:TextBox>
		<iframe frameborder="0" height="350" scrolling="no" src="../eWebEditor/ewebeditor.htm?id=txtBackInfo&style=mini" width="99%"></iframe>
	</td></tr>
</table>
		</div>
	</form>
</body>
</html>
