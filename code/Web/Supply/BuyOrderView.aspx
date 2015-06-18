<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuyOrderView.aspx.cs" Inherits="Supply_BuyOrderView" %>
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
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;采购订单&nbsp;>>&nbsp;查看采购订单信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <img class="HerCss" onclick="PrintTable()" src="../images/Button/BtnPrint.jpg" />
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
		订单名称：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblOrderName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		供应商名称：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblGongYingShangName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		订单编号：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblSerils" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		订单类型：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblDingDanLeiXing" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		订单描述：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblDingDanMiaoShu" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		创建日期：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblCreateDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		来货日期：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblLaiHuoDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		提醒日期：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblTiXingDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		创建人：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblChuangJianRen" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		负责人：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblFuZeRen" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		附件文件：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblFuJianList" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		当前状态：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblNowState" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		审核人：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblShenPiTongGuoRen" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		备注说明：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblBackInfo" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		录入人：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblUserName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
		录入时间：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblTimeStr" runat="server"></asp:Label>
	</td></tr>
</table>


<hr style="height:1px; color: #003333;">
    &nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="BuyLog.aspx?OrderName=<%=OrderName %>">订单产品记录</a>&nbsp;&nbsp;
     
    <hr style="height:1px; color: #003333;">
    <IFRAME name="RMid" frameBorder="0" marginHeight="0" marginWidth="0" width="100%" height="500"
													BORDERCOLOR="#ffffFF"  src="BuyLog.aspx?OrderName=<%=OrderName %>" border="0"></IFRAME>
    
    
    
		</div>
	</form>
</body>
</html>
