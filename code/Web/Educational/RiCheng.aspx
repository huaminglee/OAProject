<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RiCheng.aspx.cs" Inherits="Work_RiCheng" %>

<html>
<head>
    <title>
        <%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
    <link href="../Style/Style.css" type="text/css" rel="STYLESHEET">
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


    function CheckModify1() {
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
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;日程安排
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    查询：<asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="100px"></asp:TextBox><asp:ImageButton
                        ID="ImageButton4" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/Button/BtnSerch.jpg"
                        OnClick="ImageButton4_Click" />&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server"
                            OnClick="LinkButton1_Click">列表显示模式</asp:LinkButton>&nbsp;&nbsp;
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/Button/BtnAdd.jpg"
                        ImageAlign="AbsMiddle" OnClick="ImageButton1_Click" />&nbsp;
                    <asp:ImageButton ID="ImageButton5" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/Button/BtnModify.jpg"
                        OnClick="ImageButton5_Click" OnClientClick="javascript:return CheckModify();" />&nbsp;
                    <asp:ImageButton ID="ImageButton3" runat="server" OnClientClick="javascript:return CheckDel();"
                        ImageUrl="../images/Button/BtnDel.jpg" ImageAlign="AbsMiddle" OnClick="ImageButton3_Click" /><img
                            src="../images/Button/JianGe.jpg" /><img class="HerCss" onclick="javascript:window.history.go(-1)"
                                src="../images/Button/BtnExit.jpg" />&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="False">
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:GridView ID="GVData" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        BorderStyle="Groove" BorderWidth="1px" OnRowDataBound="GVData_RowDataBound" PageSize="15"
                        Width="100%">
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
                            <asp:TemplateField HeaderText="主题">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" NavigateUrl=''><%# DataBinder.Eval(Container.DataItem, "CustomerName")%></asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ClassRoom" HeaderText="教室"></asp:BoundField>
                            <asp:BoundField DataField="ClassStyle" HeaderText="上课方式"></asp:BoundField>
                            <asp:BoundField DataField="ClassType" HeaderText="上课类型"></asp:BoundField>
                            <asp:BoundField DataField="TeacherName" HeaderText="老师"></asp:BoundField>
                            <asp:BoundField DataField="Assistant" HeaderText="助教"></asp:BoundField>
                            <asp:BoundField DataField="StartTime" HeaderText="开始时间"></asp:BoundField>
                            <asp:BoundField DataField="EndTime" HeaderText="结束时间"></asp:BoundField>
                            <asp:BoundField DataField="Remark" HeaderText="备注"></asp:BoundField>
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
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Width="100%">
        <br />
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black"
            CellPadding="4" FirstDayOfWeek="Monday" ForeColor="Black" Height="320px" NextPrevFormat="ShortMonth"
            OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"
            ShowGridLines="True" Width="100%">
            <DayStyle BorderWidth="1px" />
            <DayHeaderStyle BackColor="Gainsboro" BorderWidth="1px" Font-Size="12px" />
            <TitleStyle BorderWidth="1px" />
        </asp:Calendar>
    </asp:Panel>
    </form>
</body>
</html>
