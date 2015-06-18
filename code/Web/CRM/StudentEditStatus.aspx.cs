using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Linq;
using ZWL.BLL;

public partial class CRM_CustomAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ZWL.Common.PublicMethod.CheckSession();
        }
    }

    //提交
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string id = Request.QueryString["id"];

        if (string.IsNullOrEmpty(id))
        {
            ZWL.Common.MessageBox.ShowAndRedirect(this, "参数为空！", "studentinfo.aspx");
        }
        string status = ddlStatus.SelectedValue;
        ERPStudentInfo info = new ERPStudentInfo();
        info.GetModel(Convert.ToInt32(id));

        info.status = Convert.ToInt32(status);
        info.SigningTime = DateTime.Now;
        switch (info.status)
        {
            case 0: info.Belongs = ""; break;
            default:
                break;
        }

        if (info.Update())//更新状态
        {
            //ZWL.Common.MessageBox.ShowAndRedirect(this, "提交成功", "studentinfo.aspx");
            Response.Redirect("studentinfo.aspx");
        }

        //写系统日志
        ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
        MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加客户信息(" + this.ddlStatus.SelectedItem.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
    }
}