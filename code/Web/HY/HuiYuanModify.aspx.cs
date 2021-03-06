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

public partial class HY_HuiYuanModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			ZWL.Common.PublicMethod.CheckSession();
			ZWL.BLL.ERPHuiYuan Model = new ZWL.BLL.ERPHuiYuan();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtNameStr.Text=Model.NameStr.ToString();
            this.txtRuHuiDate.Value = Model.RuHuiDate.ToString();
			this.txtJieShaoRen.Text=Model.JieShaoRen.ToString();
			this.txtSexStr.Text=Model.SexStr.ToString();
			this.txtJiGuan.Text=Model.JiGuan.ToString();
			this.txtJingJi.Text=Model.JingJi.ToString();
            this.txtChuShengDate.Value = Model.ChuShengDate.ToString();
			this.txtXueLi.Text=Model.XueLi.ToString();
			this.txtZiLi.Text=Model.ZiLi.ToString();
			this.txtGeXing.Text=Model.GeXing.ToString();
			this.txtAiHao.Text=Model.AiHao.ToString();
			this.txtAddress.Text=Model.Address.ToString();
			this.txtTel.Text=Model.Tel.ToString();
			this.txtMobTel.Text=Model.MobTel.ToString();
			this.txtZuiJiaTime.Text=Model.ZuiJiaTime.ToString();
			this.txtChangYong.Text=Model.ChangYong.ToString();
			this.txtZiXin.Text=Model.ZiXin.ToString();
			this.txtJieLun.Text=Model.JieLun.ToString();
			this.txtBackInfo.Text=Model.BackInfo.ToString();
			this.txtUserName.Text=Model.UserName.ToString();
			this.txtTimeStr.Text=Model.TimeStr.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		ZWL.BLL.ERPHuiYuan Model = new ZWL.BLL.ERPHuiYuan();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.NameStr=this.txtNameStr.Text.ToString();
        Model.RuHuiDate = this.txtRuHuiDate.Value.ToString();
		Model.JieShaoRen=this.txtJieShaoRen.Text.ToString();
		Model.SexStr=this.txtSexStr.Text.ToString();
		Model.JiGuan=this.txtJiGuan.Text.ToString();
		Model.JingJi=this.txtJingJi.Text.ToString();
        Model.ChuShengDate = this.txtChuShengDate.Value.ToString();
		Model.XueLi=this.txtXueLi.Text.ToString();
		Model.ZiLi=this.txtZiLi.Text.ToString();
		Model.GeXing=this.txtGeXing.Text.ToString();
		Model.AiHao=this.txtAiHao.Text.ToString();
		Model.Address=this.txtAddress.Text.ToString();
		Model.Tel=this.txtTel.Text.ToString();
		Model.MobTel=this.txtMobTel.Text.ToString();
		Model.ZuiJiaTime=this.txtZuiJiaTime.Text.ToString();
		Model.ChangYong=this.txtChangYong.Text.ToString();
		Model.ZiXin=this.txtZiXin.Text.ToString();
		Model.JieLun=this.txtJieLun.Text.ToString();
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		Model.UserName=this.txtUserName.Text.ToString();
		Model.TimeStr=DateTime.Parse(this.txtTimeStr.Text);
		
		Model.Update();
		
		//写系统日志
		ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
		MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "用户修改会员信息(" + this.txtNameStr.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		ZWL.Common.MessageBox.ShowAndRedirect(this, "会员信息修改成功！", "HuiYuan.aspx");
	}
}
