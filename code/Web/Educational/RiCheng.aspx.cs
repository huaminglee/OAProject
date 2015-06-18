using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using ZWL.Common;

public partial class Work_RiCheng : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ZWL.Common.PublicMethod.CheckSession();
            DataBindToGridview();
            this.Calendar1.SelectedDate = DateTime.Now.Date;

            //设定按钮权限            
            ImageButton1.Visible = ZWL.Common.PublicMethod.StrIFIn("|xs012A|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton5.Visible = ZWL.Common.PublicMethod.StrIFIn("|xs012M|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = ZWL.Common.PublicMethod.StrIFIn("|xs012D|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));
            this.ImageButton5.Visible = false;
            this.ImageButton3.Visible = false;
        }
    }
    public void DataBindToGridview()
    {
        //身份类型：0，教务部，1 vip客户，2 助教，3 教师 
        //int identity = Convert.ToInt32(Request.QueryString["identity"]);

        string juese = PublicMethod.GetSessionValue("JiaoSe");

        string field = string.Empty;
        switch (juese.Trim())
        {
            case "VIP客户": field = "CustomerName"; break;
            case "助教部门": field = "Assistant"; break;
            case "教师部门": field = "TeacherName"; break;
            default:
                break;
        }

        ZWL.BLL.ERPPaiKe MyModel = new ZWL.BLL.ERPPaiKe();
        GVData.DataSource = MyModel.GetList("Remark Like '%" + this.TextBox1.Text + (!string.IsNullOrEmpty(field) ? ("%' and " + field + "='" + ZWL.Common.PublicMethod.GetSessionValue("TrueName")) : "") + "' order by ID desc");
        GVData.DataBind();
        LabPageSum.Text = Convert.ToString(GVData.PageCount);
        LabCurrentPage.Text = Convert.ToString(((int)GVData.PageIndex + 1));
        this.GoPage.Text = LabCurrentPage.Text.ToString();
    }

    #region  分页方法
    protected void ButtonGo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (GoPage.Text.Trim().ToString() == "")
            {
                Response.Write("<script language='javascript'>alert('页码不可以为空!');</script>");
            }
            else if (GoPage.Text.Trim().ToString() == "0" || Convert.ToInt32(GoPage.Text.Trim().ToString()) > GVData.PageCount)
            {
                Response.Write("<script language='javascript'>alert('页码不是一个有效值!');</script>");
            }
            else if (GoPage.Text.Trim() != "")
            {
                int PageI = Int32.Parse(GoPage.Text.Trim()) - 1;
                if (PageI >= 0 && PageI < (GVData.PageCount))
                {
                    GVData.PageIndex = PageI;
                }
            }

            if (TxtPageSize.Text.Trim().ToString() == "")
            {
                Response.Write("<script language='javascript'>alert('每页显示行数不可以为空!');</script>");
            }
            else if (TxtPageSize.Text.Trim().ToString() == "0")
            {
                Response.Write("<script language='javascript'>alert('每页显示行数不是一个有效值!');</script>");
            }
            else if (TxtPageSize.Text.Trim() != "")
            {
                try
                {
                    int MyPageSize = int.Parse(TxtPageSize.Text.ToString().Trim());
                    this.GVData.PageSize = MyPageSize;
                }
                catch
                {
                    Response.Write("<script language='javascript'>alert('每页显示行数不是一个有效值!');</script>");
                }
            }

            DataBindToGridview();
        }
        catch
        {
            DataBindToGridview();
            Response.Write("<script language='javascript'>alert('请输入有效数字！');</script>");
        }
    }
    protected void PagerButtonClick(object sender, ImageClickEventArgs e)
    {
        //获得Button的参数值
        string arg = ((ImageButton)sender).CommandName.ToString();
        switch (arg)
        {
            case ("Next"):
                if (this.GVData.PageIndex < (GVData.PageCount - 1))
                    GVData.PageIndex++;
                break;
            case ("Pre"):
                if (GVData.PageIndex > 0)
                    GVData.PageIndex--;
                break;
            case ("Last"):
                try
                {
                    GVData.PageIndex = (GVData.PageCount - 1);
                }
                catch
                {
                    GVData.PageIndex = 0;
                }

                break;
            default:
                //本页值
                GVData.PageIndex = 0;
                break;
        }
        DataBindToGridview();
    }
    #endregion

    protected void GVData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ZWL.Common.PublicMethod.GridViewRowDataBound(e);
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        DataBindToGridview();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("RiChengAdd.aspx");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string IDlist = ZWL.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        if (ZWL.DBUtility.DbHelperSQL.ExecuteSQL("delete from ERPPaiKe where ID in (" + IDlist + ")") == -1)
        {
            Response.Write("<script>alert('删除选中记录时发生错误！请重新登陆后重试！');</script>");
        }
        else
        {
            DataBindToGridview();
            //写系统日志
            ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
            MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户删除日程安排信息";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }

    //修改
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        string CheckStr = ZWL.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        string[] CheckStrArray = CheckStr.Split(',');
        Response.Redirect("RiChengModify.aspx?ID=" + CheckStrArray[0].ToString());
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (this.LinkButton1.Text == "列表显示模式")
        {
            this.Panel1.Visible = true;
            this.Panel2.Visible = false;
            ImageButton5.Visible = ZWL.Common.PublicMethod.StrIFIn("|xs012M|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = ZWL.Common.PublicMethod.StrIFIn("|xs012D|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));
            this.LinkButton1.Text = "日历显示模式";
        }
        else
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;
            this.ImageButton5.Visible = false;
            this.ImageButton3.Visible = false;

            this.LinkButton1.Text = "列表显示模式";
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        //身份类型：0，教务部，1 vip客户，2 助教，3 教师 
        //int identity = Convert.ToInt32(Request.QueryString["identity"]);
        string juese = PublicMethod.GetSessionValue("JiaoSe");

        string field = string.Empty;
        string content = string.Empty;

        switch (juese.Trim())
        {
            case "VIP客户": field = "CustomerName"; break;
            case "助教部门": field = "Assistant"; break;
            case "教师部门": field = "TeacherName"; break;
            default:
                break;
        }

        DataSet MYDT = ZWL.DBUtility.DbHelperSQL.GetDataSet("select *,convert(varchar(10),starttime,24)+'-'+convert(varchar(10),endtime,24) time from ERPPaiKe where datediff(day,StartTime,'" + e.Day.Date.ToString() + "')=0 " + (!string.IsNullOrEmpty(field) ? (" and " + field + " like '%" + ZWL.Common.PublicMethod.GetSessionValue("TrueName")) + "%'" : ""));
        for (int i = 0; i < MYDT.Tables[0].Rows.Count; i++)
        {
            e.Cell.BackColor = System.Drawing.Color.AntiqueWhite;
            Label MyContent = new Label();
            MyContent.ForeColor = System.Drawing.Color.White;
            switch (juese)
            {
                //case "VIP客户": content = "老师：{0}，助教：{1}，教室：{2}，上课方式：{3}，上课类型：{4}<br/>时间：{5}";
                //    MyContent.Text = "<BR><a title=" + MYDT.Tables[0].Rows[i]["time"].ToString() + " href=\"RiChengView.aspx?ID=" + MYDT.Tables[0].Rows[i]["ID"].ToString() + " \">" + string.Format(content, MYDT.Tables[0].Rows[i]["TeacherName"].ToString(), MYDT.Tables[0].Rows[i]["Assistant"].ToString(), MYDT.Tables[0].Rows[i]["ClassRoom"].ToString(), MYDT.Tables[0].Rows[i]["ClassStyle"].ToString(), MYDT.Tables[0].Rows[i]["ClassType"].ToString(), MYDT.Tables[0].Rows[i]["time"].ToString()) + "</a>";
                //    break;
                //case "助教部门":
                //    content = "老师：{1}，教室：{2}，上课方式：{3}，上课类型：{4}<br/>时间：{0}";
                //    MyContent.Text = "<BR><a title=" + MYDT.Tables[0].Rows[i]["time"].ToString() + " href=\"RiChengView.aspx?ID=" + MYDT.Tables[0].Rows[i]["ID"].ToString() + " \">" + string.Format(content, MYDT.Tables[0].Rows[i]["time"].ToString(), MYDT.Tables[0].Rows[i]["TeacherName"].ToString(), MYDT.Tables[0].Rows[i]["ClassRoom"].ToString(), MYDT.Tables[0].Rows[i]["ClassStyle"].ToString(), MYDT.Tables[0].Rows[i]["ClassType"].ToString()) + "</a>";
                //    break;
                //case "教师部门":
                //    content = "助教：{1}，教室：{2}，上课方式：{3}，上课类型：{4}<br/>时间：{0}";
                //    MyContent.Text = "<BR><a title=" + MYDT.Tables[0].Rows[i]["time"].ToString() + " href=\"RiChengView.aspx?ID=" + MYDT.Tables[0].Rows[i]["ID"].ToString() + " \">" + string.Format(content, MYDT.Tables[0].Rows[i]["time"].ToString(), MYDT.Tables[0].Rows[i]["Assistant"].ToString(), MYDT.Tables[0].Rows[i]["ClassRoom"].ToString(), MYDT.Tables[0].Rows[i]["ClassStyle"].ToString(), MYDT.Tables[0].Rows[i]["ClassType"].ToString()) + "</a>";
                //    break;
                //default:
                //    content = "老师：{1}，助教：{2}，教室：{3}，上课方式：{4}，上课类型：{5}<br/>时间：{0}";
                //    MyContent.Text = "<BR><a title=" + MYDT.Tables[0].Rows[i]["time"].ToString() + " href=\"RiChengView.aspx?ID=" + MYDT.Tables[0].Rows[i]["ID"].ToString() + " \">" + string.Format(content, MYDT.Tables[0].Rows[i]["time"].ToString(), MYDT.Tables[0].Rows[i]["TeacherName"].ToString(), MYDT.Tables[0].Rows[i]["Assistant"].ToString(), MYDT.Tables[0].Rows[i]["ClassRoom"].ToString(), MYDT.Tables[0].Rows[i]["ClassStyle"].ToString(), MYDT.Tables[0].Rows[i]["ClassType"].ToString()) + "</a>";
                //    break;
                case "VIP客户": content = "学生：{0}";
                    MyContent.Text = "<BR><a href=\"RiChengView.aspx?ID=" + MYDT.Tables[0].Rows[i]["ID"].ToString() + " \">" + string.Format(content, ZWL.Common.PublicMethod.GetSessionValue("TrueName")) + "</a>";
                    break;
                case "助教部门":
                    content = "助教：{0}";
                    MyContent.Text = "<BR><a href=\"RiChengView.aspx?ID=" + MYDT.Tables[0].Rows[i]["ID"].ToString() + " \">" + string.Format(content, MYDT.Tables[0].Rows[i]["Assistant"].ToString()) + "</a>";
                    break;
                case "教师部门":
                    content = "老师：{0}";
                    MyContent.Text = "<BR><a href=\"RiChengView.aspx?ID=" + MYDT.Tables[0].Rows[i]["ID"].ToString() + " \">" + string.Format(content, MYDT.Tables[0].Rows[i]["TeacherName"].ToString()) + "</a>";
                    
                    break;
                default:
                    content = "老师：{0}，助教：{1}";
                    MyContent.Text = "<BR><a href=\"RiChengView.aspx?ID=" + MYDT.Tables[0].Rows[i]["ID"].ToString() + " \">" + string.Format(content, MYDT.Tables[0].Rows[i]["TeacherName"].ToString(), MYDT.Tables[0].Rows[i]["Assistant"].ToString()) + "</a>";
                    break;
            }
            //e.Cell.ToolTip = MYDT.Tables[0].Rows[i]["time"].ToString();

            MyContent.ForeColor = System.Drawing.Color.White;
            e.Cell.Controls.Add(MyContent);
        }
    }
}