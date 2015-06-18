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

public partial class Sell_ContractChanPinModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			ZWL.Common.PublicMethod.CheckSession();
			ZWL.BLL.ERPContractChanPin Model = new ZWL.BLL.ERPContractChanPin();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtHeTongName.Text=Model.HeTongName.ToString();
			this.txtChanPinName.Text=Model.ChanPinName.ToString();
			this.txtDanJia.Text=Model.DanJia.ToString();
			this.txtShuLiang.Text=Model.ShuLiang.ToString();
            this.Label1.Text = Model.ShuLiang.ToString();
			this.txtZongJia.Text=Model.ZongJia.ToString();
			this.txtYiFuKuan.Text=Model.YiFuKuan.ToString();
			this.txtQianKuanShu.Text=Model.QianKuanShu.ToString();
			this.RadioButtonList1.SelectedValue=Model.IFJiaoFu.ToString();
			this.Label2.Text=Model.UserName.ToString();
			this.Label3.Text=Model.TimeStr.ToString();
			this.txtBackInfo.Text=Model.BackInfo.ToString();
            this.Label4.Text = Model.IFJiaoFu.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		ZWL.BLL.ERPContractChanPin Model = new ZWL.BLL.ERPContractChanPin();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.HeTongName=this.txtHeTongName.Text.ToString();
		Model.ChanPinName=this.txtChanPinName.Text.ToString();
		Model.DanJia=decimal.Parse(this.txtDanJia.Text);
		Model.ShuLiang=decimal.Parse(this.txtShuLiang.Text);
		Model.ZongJia=decimal.Parse(this.txtZongJia.Text);
		Model.YiFuKuan=decimal.Parse(this.txtYiFuKuan.Text);
		Model.QianKuanShu=decimal.Parse(this.txtQianKuanShu.Text);
        Model.IFJiaoFu = this.RadioButtonList1.SelectedItem.Text;
        Model.UserName = this.Label2.Text.ToString();
        Model.TimeStr = DateTime.Parse(this.Label3.Text);
		Model.BackInfo=this.txtBackInfo.Text.ToString();

        if (this.RadioButtonList1.SelectedItem.Text == this.Label4.Text)
        {
            if (this.Label4.Text == "已交付")
            {
                //从产品库存中减去
                string TempSqlStr = "update ERPProduct set ChuKuSum=ChuKuSum-" + this.Label1.Text + "+" + this.txtShuLiang.Text + ",NowKuCun=NowKuCun+" + this.Label1.Text + "-" + this.txtShuLiang.Text + " where ProductName='" + this.txtChanPinName.Text.ToString() + "'";
                ZWL.DBUtility.DbHelperSQL.ExecuteSQL(TempSqlStr);
            }
        }
        else
        {
            if (this.Label4.Text == "已交付")
            {
                //从产品库存中退回原始状态
                string TempSqlStr = "update ERPProduct set ChuKuSum=ChuKuSum-" + this.Label1.Text + ",NowKuCun=NowKuCun+" + this.Label1.Text + " where ProductName='" + this.txtChanPinName.Text.ToString() + "'";
                ZWL.DBUtility.DbHelperSQL.ExecuteSQL(TempSqlStr);
            }
            else
            {
                //从产品库存中减去
                string TempSqlStr = "update ERPProduct set ChuKuSum=ChuKuSum+" + this.txtShuLiang.Text + ",NowKuCun=NowKuCun-" + this.txtShuLiang.Text + " where ProductName='" + this.txtChanPinName.Text.ToString() + "'";
                ZWL.DBUtility.DbHelperSQL.ExecuteSQL(TempSqlStr);
            }
        }
		
		Model.Update();
		
		//写系统日志
		ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
		MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "用户修改订单产品信息(" + this.txtHeTongName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        ZWL.Common.MessageBox.ShowAndRedirect(this, "订单产品信息修改成功！", "SellLog.aspx?HeTongName=" + Request.QueryString["HeTongName"].ToString());
	}
}
