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

public partial class Work_RiChengAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ZWL.Common.PublicMethod.CheckSession();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ZWL.BLL.ERPAnPai Model = new ZWL.BLL.ERPAnPai();
        Model.TitleStr = this.TextBox1.Text;
        Model.ContentStr = this.TxtContent.Text;
        Model.TimeEnd = DateTime.Parse(this.TextBox3.Value.Trim());
        Model.TimeStart = DateTime.Parse(this.TextBox2.Value.Trim());
        Model.TimeStr = DateTime.Now;
        Model.TimeTiXing = DateTime.Parse(this.TextBox4.Value.Trim());
        Model.TypeStr = this.TextBox5.Text.Trim();
        Model.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        Model.GongXiangWho = "待处理";
        Model.Add();

        //写系统日志
        ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
        MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加日程安排信息(" + this.TextBox1.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        ZWL.Common.MessageBox.ShowAndRedirect(this, "日程安排信息添加成功！", "RiCheng.aspx");        
    }
}