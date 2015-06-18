using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Linq;

public partial class CRM_CustomAdd : System.Web.UI.Page
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
            ZWL.Common.PublicMethod.CheckSession();

            binddroplist();
        }
    }

    private void binddroplist()
    {
        ZWL.BLL.ERPClassType bll = new ZWL.BLL.ERPClassType();
        List<ZWL.BLL.ERPClassType> list = bll.GetLists("");

        ddlKemu.DataSource = list.Where(x=>x.Type=="科目信息").ToList();
        ddlKemu.DataTextField = "Name";
        ddlKemu.DataValueField = "ID";
        ddlKemu.DataBind();

        ddlClass.DataSource = list.Where(x => x.Type == "班级信息").ToList();
        ddlClass.DataTextField = "Name";
        ddlClass.DataValueField = "ID";
        ddlClass.DataBind();

        ddlDestinateCountry.DataSource = list.Where(x => x.Type == "目标国家").ToList();
        ddlDestinateCountry.DataTextField = "Name";
        ddlDestinateCountry.DataValueField = "ID";
        ddlDestinateCountry.DataBind();

        ddlqd.DataSource = list.Where(x => x.Type == "渠道信息").ToList();
        ddlqd.DataTextField = "Name";
        ddlqd.DataValueField = "ID";
        ddlqd.DataBind();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (ZWL.Common.PublicMethod.IFExists("TrueName", "ERPStudent", 0, this.txtTrueName.Text) == true)
        {
            string TrueName = this.txtTrueName.Text;
            //int Grade = Convert.ToInt32(this.txtGrade.Text);
            string ParentTel = this.txtParentTel.Text;
            string AddPerson = ZWL.Common.PublicMethod.GetSessionValue("TrueName");
            string StuEmail = this.txtStuEmail.Text;
            string ParentEmail = this.txtParentEmail.Text;

            int IsGuoNei = Convert.ToInt32(RadioButtonList2.SelectedValue);

            string Kemu = this.ddlKemu.SelectedItem.Text;
            string BackGround = this.txtBackGround.Text;
            string TestTime = this.txtTestTime.Value;
            string QuDao = this.ddlqd.SelectedItem.Text;
            string DestinateCountry = ddlDestinateCountry.SelectedItem.Text;
            DateTime ChuGuoTime = Convert.ToDateTime(this.txtChuGuoTime.Value);
            DateTime PetitionTime = Convert.ToDateTime(this.txtPetitionTime.Value);
            DateTime SigningTime = Convert.ToDateTime(this.txtSigningTime.Value);
            int Class = Convert.ToInt32(ddlClass.SelectedValue);
            decimal PaymentAmount = Convert.ToDecimal(this.txtPaymentAmount.Text);
            string Remark = this.txtRemark.Text;
            int Intention = Convert.ToInt32(this.RadioButtonList1.SelectedValue);

            ZWL.BLL.ERPStudentInfo model = new ZWL.BLL.ERPStudentInfo();
            model.TrueName = TrueName;
            //model.Grade = Grade;
            model.ParentTel = ParentTel;
            model.AddPerson = AddPerson;
            model.StuEmail = StuEmail;
            model.ParentEmail = ParentEmail;
            model.IsGuoNei = IsGuoNei;
            model.Kemu = Kemu;
            model.BackGround = BackGround;
            model.TestTime = TestTime;
            model.QuDao = QuDao;
            model.DestinateCountry = DestinateCountry;
            model.ChuGuoTime = ChuGuoTime;
            model.PetitionTime = PetitionTime;
            model.SigningTime = SigningTime;
            model.Class = Class;
            model.PaymentAmount = PaymentAmount;
            model.Remark = Remark;
            model.Intention = Intention;

            if (model.Add() > 0)
            {
                ZWL.BLL.ERPUser muser = new ZWL.BLL.ERPUser();
                muser.UserName = ZWL.Common.ChineseToSpell.ConvertToAllSpell(TrueName);
                muser.TrueName = TrueName;
                muser.Tel = ParentTel;
                muser.JiaoSe = "VIP客户";
                muser.Department = "VIP客户 ";
                muser.UserPwd = ZWL.Common.DEncrypt.DESEncrypt.Encrypt(muser.UserName);
                muser.Serils = DateTime.Now.ToString("yyyyMMddhms");
                muser.ZaiGang = "在岗";
                muser.IfLogin = "是";
                muser.Cardno = "";

                muser.Add();
            }



            //写系统日志
            ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
            MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户添加客户信息(" + this.txtTrueName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            ZWL.Common.MessageBox.ShowAndRedirect(this, "客户信息添加成功！", "StudentInfo.aspx");
        }
        else
        {
            ZWL.Common.MessageBox.Show(this, "该客户名称已经存在，请查证后再输入！");
        }
    }
}