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

public partial class Educational_Course : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            ZWL.Common.PublicMethod.CheckSession();
            //设定按钮权限            
            ImageButton1.Visible = ZWL.Common.PublicMethod.StrIFIn("|xs004A|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = ZWL.Common.PublicMethod.StrIFIn("|xs004D|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = ZWL.Common.PublicMethod.StrIFIn("|xs004E|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));

            DataBindToGridview();
        }
    }
    public void DataBindToGridview()
    {
        ZWL.BLL.ERPMubiaoGuojia MyModel = new ZWL.BLL.ERPMubiaoGuojia();

        GVData.DataSource = MyModel.GetList("");

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

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string IDlist = ZWL.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        if (ZWL.DBUtility.DbHelperSQL.ExecuteSQL("delete from dbo.ERPMubiaoGuojia where ID in (" + IDlist + ")") == -1)
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

    //添加
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("MubiaoGuojiaAdd.aspx");
    }

    //修改
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        string CheckStr = ZWL.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        string[] CheckStrArray = CheckStr.Split(',');
        if (CheckStrArray[0].ToString().Trim().Length > 0)
        {
            Response.Redirect("MubiaoGuojiaModify.aspx?id=" + CheckStrArray[0].ToString());
        }
        else
        {
            ZWL.Common.MessageBox.Show(this, "当前未选择任何待修改项，不可以进行修改！");
        }
    }
}