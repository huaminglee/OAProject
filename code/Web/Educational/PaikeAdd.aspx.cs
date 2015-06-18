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
        if (ZWL.Common.PublicMethod.IFExists("CustomerName", "ERPPaike", 0, this.txtCustomerName.Value) == true)
        {
            string CustomerName = txtCustomerName.Value;
            string ClassRoom = txtClassRoom.Text;
            string ClassStyle = txtClassStyle.Text;
            string ClassType = txtClassType.Text;
            string TeacherName = txtTeacherName.Text;
            string Assistant = txtAssistant.Text;
            string Remark = txtRemark.Text;
            int IsFinish = Convert.ToInt32(txtIsFinish.Text);
            DateTime TimeStr = Convert.ToDateTime(txtAddTime.Value);

            ZWL.BLL.ERPPaiKe model = new ZWL.BLL.ERPPaiKe();
            model.CustomerName = CustomerName;
            model.ClassRoom = ClassRoom;
            model.ClassStyle = ClassStyle;
            model.ClassType = ClassType;
            model.TeacherName = TeacherName;
            model.Assistant = Assistant;
            model.Remark = Remark;
            model.IsFinish = IsFinish;
            //model.TimeStr = TimeStr;
            model.AddTime = DateTime.Now;

            model.Add();

            //写系统日志
            ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
            MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户添加排课信息(" + this.txtCustomerName.Value + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            ZWL.Common.MessageBox.ShowAndRedirect(this, "排课信息添加成功！", "paike.aspx");
        }
        else
        {
            ZWL.Common.MessageBox.Show(this, "该客户名称已经存在，请查证后再输入！");
        }
    }
}