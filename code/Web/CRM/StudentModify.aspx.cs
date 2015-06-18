using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Linq;

public partial class CRM_CustomModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //string kemu = ConfigurationManager.AppSettings["kemu"];
            //string qudao = ConfigurationManager.AppSettings["qudao"];
            //if (!string.IsNullOrEmpty(kemu))
            //{
            //    string[] arr_kemu = kemu.Split(',');
            //    foreach (string item in arr_kemu)
            //    {
            //        ListItem li = new ListItem(item, item);
            //        ddlKemu.Items.Add(li);
            //    }
            //}
            //if (!string.IsNullOrEmpty(qudao))
            //{
            //    string[] arr_qudao = qudao.Split(',');
            //    foreach (string item in arr_qudao)
            //    {
            //        ListItem li = new ListItem(item, item);
            //        ddlqd.Items.Add(li);
            //    }
            //}
            binddroplist();

            ZWL.Common.PublicMethod.CheckSession();
            ZWL.BLL.ERPStudentInfo model = new ZWL.BLL.ERPStudentInfo();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

            this.txtTrueName.Text = model.TrueName;
            //this.txtGrade.Text = model.Grade.ToString();
            this.txtParentTel.Text = model.ParentTel;
            //this.txtAddPerson.Text = model.AddPerson;
            this.txtStuEmail.Text = model.StuEmail;
            this.txtParentEmail.Text = model.ParentEmail;
            RadioButtonList2.SelectedValue = model.IsGuoNei.ToString();
            //this.txtKemu.Text = model.Kemu;

            this.ddlKemu.SelectedValue = model.Kemu;
            this.txtBackGround.Text = model.BackGround;
            this.txtTestTime.Value = model.TestTime.ToString();
            this.ddlqd.SelectedValue = model.QuDao;

            ddlDestinateCountry.SelectedValue = model.DestinateCountry;
            this.txtChuGuoTime.Value = model.ChuGuoTime.ToString();
            this.txtPetitionTime.Value = model.PetitionTime.ToString();
            this.txtSigningTime.Value = model.SigningTime.ToString();
            this.ddlClass.SelectedValue = model.Class.ToString();
            this.txtPaymentAmount.Text = model.PaymentAmount.ToString();
            this.txtRemark.Text = model.Remark;
            this.RadioButtonList1.SelectedValue = model.Intention.ToString();

        }
    }
    private void binddroplist()
    {
        ZWL.BLL.ERPClassType bll = new ZWL.BLL.ERPClassType();
        List<ZWL.BLL.ERPClassType> list = bll.GetLists("");

        ddlKemu.DataSource = list.Where(x => x.Type == "科目信息").ToList();
        ddlKemu.DataTextField = "Name";
        ddlKemu.DataValueField = "Name";
        ddlKemu.DataBind();

        ddlClass.DataSource = list.Where(x => x.Type == "班级信息").ToList();
        ddlClass.DataTextField = "Name";
        ddlClass.DataValueField = "ID";
        ddlClass.DataBind();

        ddlDestinateCountry.DataSource = list.Where(x => x.Type == "目标国家").ToList();
        ddlDestinateCountry.DataTextField = "Name";
        ddlDestinateCountry.DataValueField = "Name";
        ddlDestinateCountry.DataBind();

        ddlqd.DataSource = list.Where(x => x.Type == "渠道信息").ToList();
        ddlqd.DataTextField = "Name";
        ddlqd.DataValueField = "Name";
        ddlqd.DataBind();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (ZWL.Common.PublicMethod.IFExists("CustomName", "ERPCustomInfo", int.Parse(Request.QueryString["ID"].ToString()), this.txtTrueName.Text) == true)
        {
            ZWL.BLL.ERPStudentInfo model = new ZWL.BLL.ERPStudentInfo();

            model.ID = int.Parse(Request.QueryString["ID"].ToString());
            model.TrueName = this.txtTrueName.Text;
            //model.Grade = Convert.ToInt32(this.txtGrade.Text);
            model.ParentTel = this.txtParentTel.Text;
            model.StuEmail = this.txtStuEmail.Text;
            model.ParentEmail = this.txtParentEmail.Text;

            int IsGuoNei = Convert.ToInt32(RadioButtonList2.SelectedValue);
            model.Kemu = this.ddlKemu.SelectedValue;
            model.BackGround = this.txtBackGround.Text;
            model.TestTime = this.txtTestTime.Value;
            model.QuDao = this.ddlqd.SelectedValue;
            model.DestinateCountry = ddlDestinateCountry.SelectedItem.Text;
            model.ChuGuoTime = Convert.ToDateTime(this.txtChuGuoTime.Value);
            model.PetitionTime = Convert.ToDateTime(this.txtPetitionTime.Value);
            model.SigningTime = Convert.ToDateTime(this.txtSigningTime.Value);
            model.Class = Convert.ToInt32(ddlClass.SelectedValue);
            model.PaymentAmount = Convert.ToDecimal(this.txtPaymentAmount.Text);
            model.Remark = this.txtRemark.Text;
            model.Intention = Convert.ToInt32(this.RadioButtonList1.SelectedValue);

            model.Update();

            //写系统日志
            ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
            MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户修改客户信息(" + this.txtTrueName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            ZWL.Common.MessageBox.ShowAndRedirect(this, "客户信息修改成功！", "StudentInfo.aspx");
        }
        else
        {
            ZWL.Common.MessageBox.Show(this, "该客户名称已经存在，请查证后再输入！");
        }
    }
}