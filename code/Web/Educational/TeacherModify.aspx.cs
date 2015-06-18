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
            ZWL.BLL.ERPPaiKe model = new ZWL.BLL.ERPPaiKe();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

            txtName.Value = model.CustomerName;
            txtClassRoom.Text = model.ClassRoom;
            txtClassStyle.Text = model.ClassStyle;
            txtClassType.Text = model.ClassType;
            txtTeacherName.Text = model.TeacherName;
            txtAssistant.Text = model.Assistant;
            txtRemark.Text = model.Remark;
            txtIsFinish.Text = model.IsFinish.ToString();
            txtAddTime.Value = model.AddTime.ToString();

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (ZWL.Common.PublicMethod.IFExists("Name", "ERPPaike", int.Parse(Request.QueryString["ID"].ToString()), this.txtName.Value) == true)
        {
            string CustomerName = txtName.Value;
            string ClassRoom = txtClassRoom.Text;
            string ClassStyle = txtClassStyle.Text;
            string ClassType = txtClassType.Text;
            string TeacherName = txtTeacherName.Text;
            string Assistant = txtAssistant.Text;
            string Remark = txtRemark.Text;
            int IsFinish = Convert.ToInt32(txtIsFinish.Text);
            DateTime AddTime = Convert.ToDateTime(txtAddTime.Value);

            ZWL.BLL.ERPPaiKe model = new ZWL.BLL.ERPPaiKe();
            model.ID = Convert.ToInt32(Request.QueryString["ID"]);
            model.CustomerName = CustomerName;
            model.ClassRoom = ClassRoom;
            model.ClassStyle = ClassStyle;
            model.ClassType = ClassType;
            model.TeacherName = TeacherName;
            model.Assistant = Assistant;
            model.Remark = Remark;
            model.IsFinish = IsFinish;
            model.AddTime = AddTime;

            model.Update();

            //写系统日志
            ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
            MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户修改客户信息(" + this.txtName.Value + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            ZWL.Common.MessageBox.ShowAndRedirect(this, "客户信息修改成功！", "Teacher.aspx");
        }
        else
        {
            ZWL.Common.MessageBox.Show(this, "该客户名称已经存在，请查证后再输入！");
        }
    }
}