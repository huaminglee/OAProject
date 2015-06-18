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

public partial class Supply_BuyChanPinView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			ZWL.Common.PublicMethod.CheckSession();
			ZWL.BLL.ERPBuyChanPin Model = new ZWL.BLL.ERPBuyChanPin();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblOrderName.Text=Model.OrderName.ToString();
			this.lblProductName.Text=Model.ProductName.ToString();
			this.lblProductSerils.Text=Model.ProductSerils.ToString();
			this.lblGongYingShang.Text=Model.GongYingShang.ToString();
			this.lblProductType.Text=Model.ProductType.ToString();
			this.lblXingHao.Text=Model.XingHao.ToString();
			this.lblDanWei.Text=Model.DanWei.ToString();
			this.lblDanJia.Text=Model.DanJia.ToString();
			this.lblShuLiang.Text=Model.ShuLiang.ToString();
			this.lblZongJia.Text=Model.ZongJia.ToString();
			this.lblYiFuKuan.Text=Model.YiFuKuan.ToString();
			this.lblQianKuanShu.Text=Model.QianKuanShu.ToString();
			this.lblIFJiaoFu.Text=Model.IFJiaoFu.ToString();
			this.lblChanPinMiaoShu.Text=Model.ChanPinMiaoShu.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			this.lblBackInfo.Text=Model.BackInfo.ToString();
			
			//写系统日志
			ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
			MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "用户查看采购订单产品信息(" + this.lblOrderName.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
