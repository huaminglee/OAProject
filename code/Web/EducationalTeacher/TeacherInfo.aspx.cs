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

public partial class EducationalTeacher_TeacherInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            ZWL.Common.PublicMethod.CheckSession();

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
            ConditionStr = ConditionStr + " and AddTime>='" + this.TextBox2.Value.Trim() + " 00:00:00' ";
        }
        if (DateTime.TryParse(this.TextBox3.Value.Trim(), out MyDateSec) == true)
        {
            ConditionStr = ConditionStr + " and AddTime<='" + this.TextBox3.Value.Trim() + " 23:59:59' ";
        }
        return ConditionStr;
    }
    public void DataBindToGridview()
    {
        ZWL.BLL.ERPPaiKe MyModel = new ZWL.BLL.ERPPaiKe();

        GVData.DataSource = MyModel.GetList(" " + this.DropDownList1.SelectedItem.Value.ToString() + " Like '%" + this.TextBox1.Text + "%' " + GetTimeCondition() + " and ','+ TeacherName +',' like '%," + ZWL.Common.PublicMethod.GetSessionValue("UserName") + ",%'  " + " order by ID desc");

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
}