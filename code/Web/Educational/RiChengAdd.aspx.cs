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

public partial class Work_RiChengAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ZWL.Common.PublicMethod.CheckSession();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string CustomerName = txtCustomerName.Value;
        string ClassRoom = txtClassRoom.Text;
        string ClassStyle = txtClassStyle.Text;
        string ClassType = txtClassType.Text;
        string TeacherName = txtTeacherName.Text;
        string Assistant = txtAssistant.Text;
        string Remark = txtRemark.Text;
        int IsFinish = Convert.ToInt32(RadioButtonList1.SelectedValue);
        DateTime StartTime = Convert.ToDateTime(txtStartTime.Value);
        DateTime EndTime = Convert.ToDateTime(txtEndTime.Value);

        ZWL.BLL.ERPPaiKe model = new ZWL.BLL.ERPPaiKe();
        model.CustomerName = CustomerName;
        model.ClassRoom = ClassRoom;
        model.ClassStyle = ClassStyle;
        model.ClassType = ClassType;
        model.TeacherName = TeacherName;
        model.Assistant = Assistant;
        model.Remark = Remark;
        model.IsFinish = IsFinish;
        model.StartTime = StartTime;
        model.EndTime = EndTime;
        model.AddTime = DateTime.Now;
        model.Kemu = txtKemu.Text;

        model.Add();

        //写系统日志
        ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
        MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加排课信息(" + this.txtCustomerName.Value + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        ZWL.Common.MessageBox.ShowAndRedirect(this, "排课信息添加成功！", "RiCheng.aspx");
    }
}