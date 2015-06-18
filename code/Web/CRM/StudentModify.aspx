<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentModify.aspx.cs" Inherits="CRM_CustomModify" %>

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
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;学生管理&nbsp;>>&nbsp;修改学生信息
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
                    学生姓名：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtTrueName" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTrueName"
                        ErrorMessage="*该项不可以为空！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    父母联系方式：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtParentTel" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    学生邮箱：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtStuEmail" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    父母邮箱：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtParentEmail" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    国内还是国外：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1" Text="国内" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="2" Text="国外"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    科目：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:DropDownList ID="ddlKemu" runat="server" Width="200px" AppendDataBoundItems="true">
                        <asp:ListItem Value="">请选择</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlKemu"
                        ErrorMessage="*该项不可以为空！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    渠道：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:DropDownList ID="ddlqd" runat="server" Width="200px" AppendDataBoundItems="true">
                        <asp:ListItem Value="">请选择</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlqd"
                        ErrorMessage="*该项不可以为空！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    目标国家：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:DropDownList ID="ddlDestinateCountry" runat="server" Width="200px" AppendDataBoundItems="true">
                        <asp:ListItem Value="">请选择</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlDestinateCountry"
                        ErrorMessage="*该项不可以为空！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    考试时间：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <input type="text" autocomplete="off" id="txtTestTime" runat="server" style="width: 200px" /><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTestTime" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    出国时间：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <input class="Wdate" type="text" autocomplete="off" id="txtChuGuoTime" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" style="width: 200px" /><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtChuGuoTime"
                            ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    上访时间：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <input class="Wdate" type="text" autocomplete="off" id="txtPetitionTime" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" style="width: 200px" /><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPetitionTime"
                            ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #cccccc">
                    签单时间：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <input class="Wdate" type="text" autocomplete="off" id="txtSigningTime" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" style="width: 200px" /><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSigningTime"
                            ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    班级：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:DropDownList ID="ddlClass" runat="server" Width="200px" AppendDataBoundItems="true">
                        <asp:ListItem Value="">请选择</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlClass"
                        ErrorMessage="*该项不可以为空！"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    缴费数额：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtPaymentAmount" runat="server" Width="200px"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPaymentAmount"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    意向：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                        <asp:ListItem Value="2" Text="2" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                    </asp:RadioButtonList>
                    <%--<asp:TextBox ID="txtIntention" runat="server" Width="200px"></asp:TextBox>1～3等级<asp:RequiredFieldValidator
                        ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtIntention"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    入学背景：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtBackGround" runat="server" Width="350px" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                    备注说明：&nbsp;
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtRemark" runat="server" Width="350px" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
