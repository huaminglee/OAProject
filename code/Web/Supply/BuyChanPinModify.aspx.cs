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

public partial class Supply_BuyChanPinModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			ZWL.Common.PublicMethod.CheckSession();
			ZWL.BLL.ERPBuyChanPin Model = new ZWL.BLL.ERPBuyChanPin();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtOrderName.Text=Model.OrderName.ToString();
			this.txtProductName.Text=Model.ProductName.ToString();
			this.txtProductSerils.Text=Model.ProductSerils.ToString();
			this.txtGongYingShang.Text=Model.GongYingShang.ToString();
			this.txtProductType.Text=Model.ProductType.ToString();
			this.txtXingHao.Text=Model.XingHao.ToString();
			this.txtDanWei.Text=Model.DanWei.ToString();
			this.txtDanJia.Text=Model.DanJia.ToString();
			this.txtShuLiang.Text=Model.ShuLiang.ToString();
			this.txtZongJia.Text=Model.ZongJia.ToString();
			this.txtYiFuKuan.Text=Model.YiFuKuan.ToString();
			this.txtQianKuanShu.Text=Model.QianKuanShu.ToString();
            this.RadioButtonList1.SelectedValue = Model.IFJiaoFu.ToString();
			this.txtChanPinMiaoShu.Text=Model.ChanPinMiaoShu.ToString();
			this.txtUserName.Text=Model.UserName.ToString();
			this.txtTimeStr.Text=Model.TimeStr.ToString();
			this.txtBackInfo.Text=Model.BackInfo.ToString();
            this.Label1.Text = Model.ShuLiang.ToString();
            this.Label4.Text = Model.IFJiaoFu.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		ZWL.BLL.ERPBuyChanPin Model = new ZWL.BLL.ERPBuyChanPin();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.OrderName=this.txtOrderName.Text.ToString();
		Model.ProductName=this.txtProductName.Text.ToString();
		Model.ProductSerils=this.txtProductSerils.Text.ToString();
		Model.GongYingShang=this.txtGongYingShang.Text.ToString();
		Model.ProductType=this.txtProductType.Text.ToString();
		Model.XingHao=this.txtXingHao.Text.ToString();
		Model.DanWei=this.txtDanWei.Text.ToString();
		Model.DanJia=decimal.Parse(this.txtDanJia.Text);
		Model.ShuLiang=decimal.Parse(this.txtShuLiang.Text);
		Model.ZongJia=decimal.Parse(this.txtZongJia.Text);
		Model.YiFuKuan=decimal.Parse(this.txtYiFuKuan.Text);
		Model.QianKuanShu=decimal.Parse(this.txtQianKuanShu.Text);
        Model.IFJiaoFu = this.RadioButtonList1.SelectedItem.Text;
		Model.ChanPinMiaoShu=this.txtChanPinMiaoShu.Text.ToString();
		Model.UserName=this.txtUserName.Text.ToString();
		Model.TimeStr=DateTime.Parse(this.txtTimeStr.Text);
		Model.BackInfo=this.txtBackInfo.Text.ToString();


        if (this.RadioButtonList1.SelectedItem.Text == this.Label4.Text)
        {
            if (this.Label4.Text == "已交付")
            {
                //从产品库存中减去
                string TempSqlStr = "update ERPProduct set RuKuSum=RuKuSum-" + this.Label1.Text + "+" + this.txtShuLiang.Text + ",NowKuCun=NowKuCun-" + this.Label1.Text + "+" + this.txtShuLiang.Text + " where ProductName='" + this.txtProductName.Text.ToString() + "'";
                ZWL.DBUtility.DbHelperSQL.ExecuteSQL(TempSqlStr);
            }
        }
        else
        {
            if (this.Label4.Text == "已交付")
            {
                //从产品库存中退回原始状态
                string TempSqlStr = "update ERPProduct set RuKuSum=RuKuSum-" + this.Label1.Text + ",NowKuCun=NowKuCun-" + this.Label1.Text + " where ProductName='" + this.txtProductName.Text.ToString() + "'";
                ZWL.DBUtility.DbHelperSQL.ExecuteSQL(TempSqlStr);
            }
            else
            {
                //从产品库存中减去
                string TempSqlStr = "update ERPProduct set RuKuSum=RuKuSum+" + this.txtShuLiang.Text + ",NowKuCun=NowKuCun+" + this.txtShuLiang.Text + " where ProductName='" + this.txtProductName.Text.ToString() + "'";
                ZWL.DBUtility.DbHelperSQL.ExecuteSQL(TempSqlStr);
            }
        }

		Model.Update();
		
		//写系统日志
		ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
		MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改采购订单产品信息(" + this.txtOrderName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        ZWL.Common.MessageBox.ShowAndRedirect(this, "采购订单产品信息修改成功！", "BuyLog.aspx?OrderName=" + Request.QueryString["OrderName"].ToString());
	}
}
