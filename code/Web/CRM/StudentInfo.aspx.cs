using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using ZWL.Common;
using System.Configuration;
using System.Data;
using System.IO;
using ZWL.BLL.Data;
using System.Text;

public partial class CRM_StudentInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //string isvip = Request["isvip"];
            //if (!string.IsNullOrEmpty(isvip))
            //{
            //    hfIsVip.Value = isvip;
            //}

            ZWL.Common.PublicMethod.CheckSession();
            //设定按钮权限            
            ImageButton1.Visible = ZWL.Common.PublicMethod.StrIFIn("|xs001A|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = ZWL.Common.PublicMethod.StrIFIn("|xs001D|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = ZWL.Common.PublicMethod.StrIFIn("|xs001M|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));

            try
            {
                this.DropDownList1.SelectedValue = Request.QueryString["DropStr"].ToString();
                this.TextBox1.Text = Request.QueryString["TextStr"].ToString();
            }
            catch
            { }


            DataBindToGridview();
        }
    }
    public string GetTimeCondition()
    {
        string ConditionStr = "";
        DateTime MyDate, MyDateSec;
        if (DateTime.TryParse(this.TextBox2.Value.Trim(), out MyDate) == true)
        {
            ConditionStr = ConditionStr + " and TestTime>='" + this.TextBox2.Value.Trim() + " 00:00:00' ";
        }
        if (DateTime.TryParse(this.TextBox3.Value.Trim(), out MyDateSec) == true)
        {
            ConditionStr = ConditionStr + " and TestTime<='" + this.TextBox3.Value.Trim() + " 23:59:59' ";
        }
        return ConditionStr;
    }

    public string GetTypeCondition()
    {
        int type = 0;
        int.TryParse(Request["type"], out type);

        string condition = " and status in ({0})";
        switch (type)
        {
            case 1: condition = string.Format(condition, "0,1"); break;//导入分配表
            case 2: condition = string.Format(condition, "2,3"); break;//意向登记表
            case 3: condition = string.Format(condition, "4"); break;//上访登记表
            case 4: condition = string.Format(condition, "5"); break;//成交登记表
            default: condition = string.Format(condition, "0,1");
                break;
        }

        return condition;
    }

    public string GetAccessCondition()
    {
        string condition = string.Empty;
        string access = ZWL.Common.PublicMethod.GetSessionValue("JiaoSe");
        if (access.Equals("顾问部"))
        {
            condition = string.Format(" and b.TrueName='{0}'", ZWL.Common.PublicMethod.GetSessionValue("TrueName"));
        }

        return condition;
    }

    public void DataBindToGridview()
    {
        ZWL.BLL.ERPStudentInfo MyModel = new ZWL.BLL.ERPStudentInfo();

        DataSet ds = MyModel.GetList(" a." + this.DropDownList1.SelectedItem.Value.ToString() + " Like '%" + this.TextBox1.Text + "%' " + GetTimeCondition() + GetTypeCondition() + GetAccessCondition() + " and (a.isdelete is null or a.isdelete !=1) order by a.status desc,a.ID desc");

        string strStatus = string.Empty;
        ds.Tables[0].Columns.Add(new DataColumn("statusStr", typeof(string)));
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            switch (dr["status"].ToString())
            {
                case "0": strStatus = "待分配"; break;
                case "1": strStatus = "已分配"; break;
                case "2": strStatus = "待定"; break;
                case "3": strStatus = "意向"; break;
                case "4": strStatus = "上访"; break;
                case "5": strStatus = "成交"; break;
                default:
                    break;
            }
            dr["statusStr"] = strStatus;
        }
        GVData.DataSource = ds;
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string access = ZWL.Common.PublicMethod.GetSessionValue("JiaoSe");
            if (access.Equals("顾问部"))
            {
                LinkButton lkfenpei = e.Row.FindControl("fenpei") as LinkButton;
                lkfenpei.Visible = false;
            }
        }
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        DataBindToGridview();
    }

    // 删除
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string IDlist = ZWL.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        if (ZWL.DBUtility.DbHelperSQL.ExecuteSQL("update dbo.ERPStudent set isdelete=1 where ID in (" + IDlist + ")") == -1)
        {
            Response.Write("<script>alert('删除选中记录时发生错误！请重新登陆后重试！');</script>");
        }
        else
        {
            DataBindToGridview();
            //写系统日志
            ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
            MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户删除客户信息";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        //string IDList = "0";
        //for (int i = 0; i < GVData.Rows.Count; i++)
        //{
        //    Label LabVis = (Label)GVData.Rows[i].FindControl("LabVisible");
        //    IDList = IDList + "," + LabVis.Text.ToString();
        //}
        Hashtable MyTable = new Hashtable();
        MyTable.Add("ID", "编号");
        MyTable.Add("TrueName", "客户姓名");
        MyTable.Add("ParentTel", "父母电话");
        MyTable.Add("StuEmail", "学生邮箱");
        MyTable.Add("ParentEmail", "父母邮箱");
        MyTable.Add("PaymentAmount", "缴费数额");
        MyTable.Add("DestinateCountry", "目标国家");
        MyTable.Add("Remark", "备注");
        MyTable.Add("AddPerson", "创建人");
        MyTable.Add("TestTime", "考试时间");

        ZWL.BLL.ERPStudentInfo MyModel = new ZWL.BLL.ERPStudentInfo();
        DataSet ds = MyModel.GetList(" " + this.DropDownList1.SelectedItem.Value.ToString() + " Like '%" + this.TextBox1.Text + "%' " + GetTimeCondition() + " and (isdelete is null or isdelete !=1) order by ID desc");

        //ZWL.Common.DataToExcel.GridViewToExcel(ds, MyTable, "Excel报表");

        StringBuilder sb = new StringBuilder();

        sb.Append("<table borderColor='black' border='1' >");
        sb.Append("<thead>");
        sb.Append("<tr><th>编号</th><th>客户姓名</th><th>父母电话</th><th>学生邮箱</th><th>父母邮箱</th><th>缴费数额</th><th>目标国家</th><th>备注</th><th>创建人</th><th>考试时间</th></tr>");
        sb.Append("</thead>");
        sb.Append("<tbody>");
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            sb.Append("<tr>");
            sb.Append("<td>" + dr["ID"].ToString() + "</td>");
            sb.Append("<td>" + dr["TrueName"].ToString() + "</td>");
            sb.Append("<td>" + dr["ParentTel"].ToString() + "</td>");
            sb.Append("<td>" + dr["StuEmail"].ToString() + "</td>");
            sb.Append("<td>" + dr["ParentEmail"].ToString() + "</td>");
            sb.Append("<td>" + dr["PaymentAmount"].ToString() + "</td>");
            sb.Append("<td>" + dr["DestinateCountry"].ToString() + "</td>");
            sb.Append("<td>" + dr["Remark"].ToString() + "</td>");
            sb.Append("<td>" + dr["AddPerson"].ToString() + "</td>");
            sb.Append("<td>" + dr["TestTime"].ToString() + "</td>");
            sb.Append("</tr>");
        }
        sb.Append("</tbody></table>");
        ZWL.Common.DataToExcel.ExportToExcel("客户信息.xls", sb.ToString());
    }



    //添加
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("StudentAdd.aspx");
    }

    //修改
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        string CheckStr = ZWL.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        string[] CheckStrArray = CheckStr.Split(',');
        if (CheckStrArray[0].ToString().Trim().Length > 0)
        {
            Response.Redirect("StudentModify.aspx?id=" + CheckStrArray[0].ToString());
        }
        else
        {
            ZWL.Common.MessageBox.Show(this, "当前未选择任何待修改项，不可以进行修改！");
        }
    }

    //选择excel文档 导入
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        //string path = fileupload.PostedFile.FileName;

        //string fullPath = Path.GetFullPath(fileupload.PostedFile.FileName); //获取文件的绝对路径

        //string path1 = HttpContext.Current.Server.MapPath(path);

        //if (!path.EndsWith("xls") && !path.EndsWith("xlsx"))
        //{
        //    ZWL.Common.MessageBox.Show(this, "您选择的文件不是excel文档，请重新选择！");
        //}

        Response.Redirect("StudentInfoImport.aspx");

        //string excelpath = ConfigurationManager.AppSettings["excelpath"];
        //DataSet ds = ExcelToDB.ImportFromExcel(excelpath);
        //ExcelToDB.BulkToDB(ds.Tables[0]);

        //ZWL.Common.MessageBox.Show(this, "导入成功！");

        //DataBindToGridview();
    }
    //审核
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void GVData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName.Equals("editstatus"))
        {
            Response.Redirect("StudentEditStatus.aspx?id=" + id);
        }

        if (e.CommandName.Equals("fenpei"))
        {
            Response.Redirect("StudentFenPei.aspx?id=" + id);
        }
    }

    protected void GVData_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}