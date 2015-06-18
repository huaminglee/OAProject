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

public partial class Work_RiChengModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ZWL.Common.PublicMethod.CheckSession();
            //绑定页面数据
            ZWL.BLL.ERPPaiKe model = new ZWL.BLL.ERPPaiKe();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

            txtCustomerName.Value = model.CustomerName;
            txtClassRoom.Text = model.ClassRoom;
            txtClassStyle.Text = model.ClassStyle;
            txtClassType.Text = model.ClassType;
            txtTeacherName.Text = model.TeacherName;
            txtAssistant.Text = model.Assistant;
            txtRemark.Text = model.Remark;
            RadioButtonList1.SelectedValue = model.IsFinish.ToString();
            txtStartTime.Value = model.StartTime.ToString();
            txtEndTime.Value = model.EndTime.ToString();
            txtKemu.Text = model.Kemu;
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

        model.ID = Convert.ToInt32(Request.QueryString["ID"]);
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
        model.Kemu=txtKemu.Text;

        model.Update();

        //写系统日志
        ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
        MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "修改日程安排信息(" + this.txtCustomerName.Value + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        ZWL.Common.MessageBox.ShowAndRedirect(this, "日程安排信息修改成功！", "RiCheng.aspx");
    }
}