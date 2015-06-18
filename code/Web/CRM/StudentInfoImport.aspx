<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentInfoImport.aspx.cs" Inherits="CRM_StudentInfoImport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
    <title>
        <%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
    <link href="../Style/Style.css" type="text/css" rel="STYLESHEET">
    <script src="../JS/My97DatePickerBeta/WdatePicker.js" type="text/javascript"></script>
</head>
<script language="JavaScript">
    var a;
    function CheckValuePiece() {
        if (window.document.form1.GoPage.value == "") {
            alert("请输入跳转的页码！");
            window.document.form1.GoPage.focus();
            return false;
        }
        return true;
    }
    function CheckAll() {
        var inputs = document.getElementsByTagName("input");
        if (a == 1) {
            for (var i = 0; i < inputs.length; i++) {
                var e = inputs[i];
                if (e.type == "checkbox")
                    e.checked = false;
            }
            a = 0;
        }
        else {
            for (var i = 0; i < inputs.length; i++) {
                var e = inputs[i];
                if (e.type == "checkbox")
                    e.checked = true;
            }
            a = 1;
        }
    }
    function CheckDel() {
        var number = 0;
        for (var i = 0; i < window.document.form1.elements.length; i++) {
            var e = form1.elements[i];
            if (e.Name != "CheckBoxAll") {
                if (e.checked == true) {
                    number = number + 1;
                }
            }
        }
        if (number == 0) {
            alert("请选择需要删除的项！");
            return false;
        }
        if (window.confirm("你确认删除吗？")) {
            return true;
        }
        else {
            return false;
        }
    }

    function CheckDel1() {
        var number = 0;
        for (var i = 0; i < window.document.form1.elements.length; i++) {
            var e = form1.elements[i];
            if (e.Name != "CheckBoxAll") {
                if (e.checked == true) {
                    number = number + 1;
                }
            }
        }
        if (number == 0) {
            alert("请选择需要转移的客户数据！");
            return false;
        }
        if (window.confirm("你确认将选中客户转移给选定的业务员吗？")) {
            return true;
        }
        else {
            return false;
        }
    }

    function CheckModify() {
        var Modifynumber = 0;
        for (var i = 0; i < window.document.form1.elements.length; i++) {
            var e = form1.elements[i];
            if (e.Name != "CheckBoxAll") {
                if (e.checked == true) {
                    Modifynumber = Modifynumber + 1;
                }
            }
        }
        if (Modifynumber == 0) {
            alert("请至少选择一项！");
            return false;
        }
        if (Modifynumber > 1) {
            alert("只允许选择一项！");
            return false;
        }

        return true;
    }
             
             
             
</script>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img src="../images/BanKuaiJianTou.gif" />
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;学生管理&nbsp;>>&nbsp;学生信息导入
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;
                    &nbsp;
                    &nbsp;&nbsp;<asp:ImageButton ID="ImageButton6"
                            runat="server" ImageUrl="../images/Button/BtnExit.jpg" ImageAlign="AbsMiddle"
                            OnClick="ImageButton6_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border-bottom: #006633 1px dashed; height: 30px" valign="middle">
                </td>
            </tr>
        </table>
    </div>
    <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
        <tr>
            <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                <a href="客户信息导入模板.xls">模板下载</a>：&nbsp;
            </td>
            <td style="padding-left: 5px; height: 25px;width:400px;background-color: #ffffff">
                <%--<input id="fileExportExcel" style="width:400px" type="file" runat="server" />--%>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="400px" />
            </td>
            <td style="height: 25px; background-color: #ffffff">
                <asp:ImageButton ID="ImageButton7" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/Button/UpLoad.jpg"
                    OnClick="ImageButton7_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 170px; height: 25px; background-color: #cccccc" align="right">
                导入结果：&nbsp;
            </td>
            <td colspan="2" style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
