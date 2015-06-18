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
        if (ZWL.Common.PublicMethod.IFExists("CustomerName", "ERPFangKe", 0, this.txtCustomerName.Text) == true)
        {
            string CustomerName = this.txtCustomerName.Text;
            string Telephone = this.txtTelephone.Text;
            string Receiver = this.txtReceiver.Text;
            string Description = this.txtDescription.Text;
            string SourceFrom = ddlSourceFrom.SelectedValue;
            DateTime AddTime = Convert.ToDateTime(this.txtPetitionTime.Value);

            ZWL.BLL.ERPFangKe model = new ZWL.BLL.ERPFangKe();
            model.CustomerName = CustomerName;
            model.Telephone = Telephone;
            model.Receiver = Receiver;
            model.Description = Description;
            model.SourceFrom = SourceFrom;
            model.AddTime = System.DateTime.Now;
            model.PetitionTime = AddTime;

            model.Add();

            //写系统日志
            ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
            MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户添加客户信息(" + this.txtCustomerName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            ZWL.Common.MessageBox.ShowAndRedirect(this, "访客信息添加成功！", "fangkeinfo.aspx");
        }
        else
        {
            ZWL.Common.MessageBox.Show(this, "该访客名称已经存在，请查证后再输入！");
        }
    }
}