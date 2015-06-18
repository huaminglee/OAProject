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

public partial class CRM_CustomModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ZWL.Common.PublicMethod.CheckSession();
            ZWL.BLL.ERPDengJi model = new ZWL.BLL.ERPDengJi();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));


            this.txtUserName.Text = model.UName;
            this.txtTelephone.Text = model.Telephone;
            this.txtDescription.Text = model.Description;
            this.txtRecordTime.Text = model.RecordTime.ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ZWL.BLL.ERPDengJi model = new ZWL.BLL.ERPDengJi();

        model.ID = int.Parse(Request.QueryString["ID"].ToString());
        model.UName = txtUserName.Text.Trim();
        model.Telephone = txtTelephone.Text.Trim();
        model.Description = txtDescription.Text.Trim();
        model.RecordTime = Convert.ToDateTime(txtRecordTime.Text);

        model.Update();

        //写系统日志
        ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
        MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改客户信息(" + this.txtUserName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        ZWL.Common.MessageBox.ShowAndRedirect(this, "客户信息修改成功！", "CallRecordsInfo.aspx");
    }
}