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

public partial class CRM_CustomAdd : System.Web.UI.Page
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
        string UserName = this.txtUserName.Text;
        string Telephone = this.txtTelephone.Text;
        string Receiver = this.txtReceiver.Text;
        DateTime AddTime = Convert.ToDateTime(this.txtAddTime.Text);

        ZWL.BLL.ERPCallRecords model = new ZWL.BLL.ERPCallRecords();
        model.UName = UserName;
        model.Telephone = Telephone;
        model.Receiver = Receiver;
        model.AddTime = AddTime;

        model.Add();

        //写系统日志
        ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
        MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加客户信息(" + this.txtUserName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        ZWL.Common.MessageBox.ShowAndRedirect(this, "信息添加成功！", "CallRecordsInfo.aspx");

    }
}