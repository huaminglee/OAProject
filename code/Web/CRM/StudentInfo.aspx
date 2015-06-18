<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentInfo.aspx.cs" Inherits="CRM_StudentInfo" %>

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

    function CheckFenPei() {
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
            alert("请选择需要分配的项！");
            return false;
        }
        return true;
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
        <asp:HiddenField ID="hfIsVip" runat="server" Value="0" />
        <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img src="../images/BanKuaiJianTou.gif" />
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;学生管理&nbsp;>>&nbsp;学生信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/Button/BtnAdd.jpg"
                        ImageAlign="AbsMiddle" OnClick="ImageButton1_Click" />&nbsp;
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/Button/BtnModify.jpg"
                        OnClick="ImageButton5_Click" OnClientClick="javascript:return CheckModify();" />&nbsp;
                    <asp:ImageButton ID="ImageButton3" runat="server" OnClientClick="javascript:return CheckDel();"
                        ImageUrl="../images/Button/BtnDel.jpg" ImageAlign="AbsMiddle" OnClick="ImageButton3_Click" />
                    &nbsp;<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="../images/Button/BtnReport.jpg"
                        ImageAlign="AbsMiddle" OnClick="ImageButton2_Click" />&nbsp;<asp:ImageButton ID="ImageButton6"
                            runat="server" ImageUrl="../images/Button/BtnExit.jpg" ImageAlign="AbsMiddle"
                            OnClick="ImageButton6_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border-bottom: #006633 1px dashed; height: 30px" valign="middle">
                    &nbsp; &nbsp;&nbsp; 选择过滤条件：<asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="TrueName">客户名称</asp:ListItem>
                        <%--<asp:ListItem Value="Grade">年级</asp:ListItem>--%>
                        <asp:ListItem Value="ParentTel">父母电话</asp:ListItem>
                        <asp:ListItem Value="TestTime">添加日期</asp:ListItem>
                    </asp:DropDownList>
                    过滤内容：<asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="85px"></asp:TextBox>
                    &nbsp; 添加时间：<input class="Wdate" type="text" autocomplete="off" id="TextBox2" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                    至
                    <input class="Wdate" type="text" autocomplete="off" id="TextBox3" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                    <asp:ImageButton ID="ImageButton5" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/Button/BtnSerch.jpg"
                        OnClick="ImageButton4_Click" />
                    &nbsp;<asp:ImageButton ID="ImageButton7" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/Button/UpLoad.jpg"
                        OnClick="ImageButton7_Click" />
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <table style="width: 100%">
        <tr>
            <td>
                <asp:GridView ID="GVData" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    BorderStyle="Groove" BorderWidth="1px" OnRowDataBound="GVData_RowDataBound" PageSize="15"
                    Width="100%" OnRowCommand="GVData_RowCommand" OnSelectedIndexChanged="GVData_SelectedIndexChanged">
                    <PagerSettings Mode="NumericFirstLast" Visible="False" />
                    <PagerStyle BackColor="LightSteelBlue" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#DEDEDE" Font-Size="12px" ForeColor="Black" Height="20px" />
                    <AlternatingRowStyle BackColor="WhiteSmoke" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="LabVisible" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID")%>'
                                    Visible="False"></asp:Label><asp:CheckBox ID="CheckSelect" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle Width="20px" />
                            <HeaderTemplate>
                                <input id="CheckBoxAll" onclick="CheckAll()" type="checkbox" />
                            </HeaderTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="客户姓名">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" NavigateUrl='<%# "CustomView.aspx?ID="+ DataBinder.Eval(Container.DataItem, "ID")%>'><%# DataBinder.Eval(Container.DataItem, "TrueName")%></asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="TrueName" HeaderText="客户姓名"></asp:BoundField>
                        <asp:BoundField DataField="ParentTel" HeaderText="父母电话"></asp:BoundField>
                        <asp:BoundField DataField="Tel" HeaderText="学生电话"></asp:BoundField>
                        <asp:BoundField DataField="StuEmail" HeaderText="学生邮箱"></asp:BoundField>
                        <asp:BoundField DataField="ParentEmail" HeaderText="父母邮箱"></asp:BoundField>
                        <asp:BoundField DataField="PaymentAmount" HeaderText="缴费数额"></asp:BoundField>
                        <asp:BoundField DataField="DestinateCountry" HeaderText="目标国家"></asp:BoundField>
                        <asp:BoundField DataField="Remark" HeaderText="备注"></asp:BoundField>
                        <asp:BoundField DataField="AddPerson" HeaderText="创建人"></asp:BoundField>
                        <asp:BoundField DataField="statusStr" HeaderText="状态"></asp:BoundField>
                        <asp:BoundField DataField="bname" HeaderText="所属顾问"></asp:BoundField>
                        <asp:BoundField DataField="TestTime" HeaderText="考试时间"></asp:BoundField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton Text="分配" runat="server" ID="fenpei" CommandName="fenpei" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' />
                                <asp:LinkButton Text="编辑状态" runat="server" CommandName="editstatus" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle HorizontalAlign="Center" Height="25px" />
                    <EmptyDataTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" style="border-right: black 1px; border-top: black 1px; border-left: black 1px;
                                    border-bottom: black 1px; background-color: whitesmoke;">
                                    该列表中暂时无数据！
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="border-top: #000000 1px solid; border-bottom: #000000 1px solid">
                <asp:ImageButton ID="BtnFirst" runat="server" CommandName="First" ImageUrl="../images/Button/First.jpg"
                    OnClick="PagerButtonClick" />
                <asp:ImageButton ID="BtnPre" runat="server" CommandName="Pre" ImageUrl="../images/Button/Pre.jpg"
                    OnClick="PagerButtonClick" />
                <asp:ImageButton ID="BtnNext" runat="server" CommandName="Next" ImageUrl="../images/Button/Next.jpg"
                    OnClick="PagerButtonClick" />
                <asp:ImageButton ID="BtnLast" runat="server" CommandName="Last" ImageUrl="../images/Button/Last.jpg"
                    OnClick="PagerButtonClick" />
                &nbsp;第<asp:Label ID="LabCurrentPage" runat="server" Text="Label"></asp:Label>页&nbsp;
                共<asp:Label ID="LabPageSum" runat="server" Text="Label"></asp:Label>页&nbsp;
                <asp:TextBox ID="TxtPageSize" runat="server" CssClass="TextBoxCssUnder2" Height="20px"
                    Width="35px">15</asp:TextBox>
                行每页 &nbsp; 转到第<asp:TextBox ID="GoPage" runat="server" CssClass="TextBoxCssUnder2"
                    Height="20px" Width="33px"></asp:TextBox>
                页&nbsp;
                <asp:ImageButton ID="ButtonGo" runat="server" OnClientClick="javascript:return CheckValuePiece();"
                    ImageUrl="../images/Button/Jump.jpg" OnClick="ButtonGo_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
