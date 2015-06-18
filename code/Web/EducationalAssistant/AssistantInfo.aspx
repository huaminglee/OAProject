<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssistantInfo.aspx.cs" Inherits="EducationalAssistant_AssistantInfo" %>

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
</script>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img src="../images/BanKuaiJianTou.gif" />
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;课程&nbsp;>>&nbsp;您协助的课程
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border-bottom: #006633 1px dashed; height: 30px" valign="middle">
                    &nbsp; &nbsp;&nbsp; 选择过滤条件：<asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="ClassRoom">教室</asp:ListItem>
                    </asp:DropDownList>
                    过滤内容：<asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="85px"></asp:TextBox>
                    &nbsp; 添加时间：
                    <input class="Wdate" type="text" autocomplete="off" id="TextBox2" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />至
                    <input class="Wdate" type="text" autocomplete="off" id="TextBox3" runat="server"
                        onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                    <asp:ImageButton ID="ImageButton5" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/Button/BtnSerch.jpg"
                        OnClick="ImageButton4_Click" />
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
                    Width="100%">
                    <PagerSettings Mode="NumericFirstLast" Visible="False" />
                    <PagerStyle BackColor="LightSteelBlue" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#DEDEDE" Font-Size="12px" ForeColor="Black" Height="20px" />
                    <AlternatingRowStyle BackColor="WhiteSmoke" />
                    <Columns>
                        <asp:BoundField DataField="CustomerName" HeaderText="客户姓名"></asp:BoundField>
                        <asp:BoundField DataField="ClassRoom" HeaderText="教室"></asp:BoundField>
                        <asp:BoundField DataField="ClassStyle" HeaderText="上课方式"></asp:BoundField>
                        <asp:BoundField DataField="ClassType" HeaderText="上课类型"></asp:BoundField>
                        <asp:BoundField DataField="TeacherName" HeaderText="老师"></asp:BoundField>
                        <asp:BoundField DataField="Assistant" HeaderText="助教    "></asp:BoundField>
                        <asp:BoundField DataField="Remark" HeaderText="备注"></asp:BoundField>
                        <asp:BoundField DataField="IsFinish" HeaderText="是否完成"></asp:BoundField>
                        <asp:BoundField DataField="AddTime" HeaderText="添加时间"></asp:BoundField>
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
