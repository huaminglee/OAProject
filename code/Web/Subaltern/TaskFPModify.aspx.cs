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

public partial class Subaltern_TaskFPModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			ZWL.Common.PublicMethod.CheckSession();
			ZWL.BLL.ERPTaskFP Model = new ZWL.BLL.ERPTaskFP();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtTaskTitle.Text=Model.TaskTitle.ToString();
			this.txtTaskContent.Text=Model.TaskContent.ToString();
			this.txtFromUser.Text=Model.FromUser.ToString();
			this.txtToUserList.Text=Model.ToUserList.ToString();
			this.txtXinXiGouTong.Text=Model.XinXiGouTong.ToString();
			this.txtJinDu.Text=Model.JinDu.ToString();
			this.txtWanCheng.Text=Model.WanCheng.ToString();
			this.DropDownList1.SelectedValue=Model.NowState.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		ZWL.BLL.ERPTaskFP Model = new ZWL.BLL.ERPTaskFP();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.TaskTitle=this.txtTaskTitle.Text.ToString();
		Model.TaskContent=this.txtTaskContent.Text.ToString();
		Model.FromUser=this.txtFromUser.Text.ToString();
		Model.ToUserList=this.txtToUserList.Text.ToString();
		Model.XinXiGouTong=this.txtXinXiGouTong.Text.ToString();
		Model.JinDu=decimal.Parse(this.txtJinDu.Text);
		Model.WanCheng=this.txtWanCheng.Text.ToString();
        Model.NowState = this.DropDownList1.SelectedValue.ToString();
		
		Model.Update();

        //发送短信
        SendMainAndSms.SendMessage(CHKSMS, CHKMOB, "您有新的任务需要执行！(" + this.txtTaskTitle.Text + ")", this.txtToUserList.Text.Trim());

		//写系统日志
		ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
		MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "用户修改任务分配信息(" + this.txtTaskTitle.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		ZWL.Common.MessageBox.ShowAndRedirect(this, "任务分配信息修改成功！", "TaskFP.aspx");
	}
}
