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
            ZWL.BLL.ERPFangKe model = new ZWL.BLL.ERPFangKe();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

            this.txtCustomerName.Text = model.CustomerName;
            this.txtTelephone.Text = model.CustomerName;
            this.txtReceiver.Text = model.Receiver;
            this.txtDescription.Text = model.Description;
            this.ddlSourceFrom.SelectedValue = model.SourceFrom;
            this.txtPetitionTime.Value = model.PetitionTime.ToString();

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (ZWL.Common.PublicMethod.IFExists("CustomName", "ERPFangKe", int.Parse(Request.QueryString["ID"].ToString()), this.txtCustomerName.Text) == true)
        {
            ZWL.BLL.ERPFangKe model = new ZWL.BLL.ERPFangKe();

            model.ID = int.Parse(Request.QueryString["ID"].ToString());
            model.CustomerName = txtCustomerName.Text;
            model.Telephone = txtTelephone.Text;
            model.Receiver = txtReceiver.Text;
            model.Description = txtDescription.Text;
            model.SourceFrom = ddlSourceFrom.SelectedValue;
            model.PetitionTime = Convert.ToDateTime(txtPetitionTime.Value);


            model.Update();

            //写系统日志
            ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
            MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户修改访客信息(" + this.txtCustomerName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            ZWL.Common.MessageBox.ShowAndRedirect(this, "访客信息修改成功！", "fangkeinfo.aspx");
        }
        else
        {
            ZWL.Common.MessageBox.Show(this, "该访客名称已经存在，请查证后再输入！");
        }
    }
}