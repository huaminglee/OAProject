using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Educational_PaikeAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    //添加
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (ZWL.Common.PublicMethod.IFExists("Name", "ERPTeacher", 0, this.txtName.Value) == true)
        {
            string Name = txtName.Value;
            int Age = Convert.ToInt32(txtAge.Text);
            DateTime Birth = Convert.ToDateTime(txtBirth.Value);
            string Mobile = txtMobile.Text;
            int? Sex = Convert.ToInt32(txtSex.Text);
            string Address = txtAddress.Text;
            DateTime AddTime = Convert.ToDateTime(txtAddTime.Value);

            ZWL.BLL.ERPTeacher model = new ZWL.BLL.ERPTeacher();
            model.Name = Name;
            model.Age = Age;
            model.Birth = Birth;
            model.Mobile = Mobile;
            model.Sex = Sex;
            model.Address = Address;
            model.AddTime = AddTime;

            model.Add();

            //写系统日志
            ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
            MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户添加排课信息(" + this.txtName.Value + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            ZWL.Common.MessageBox.ShowAndRedirect(this, "排课信息添加成功！", "Teachers.aspx");
        }
        else
        {
            ZWL.Common.MessageBox.Show(this, "该客户名称已经存在，请查证后再输入！");
        }
    }
}