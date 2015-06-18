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
        if (ZWL.Common.PublicMethod.IFExists("CName", "ERPClassRoom", 0, this.txtName.Value) == true)
        {
            string name = txtName.Value;

            ZWL.BLL.ERPClassRoom model = new ZWL.BLL.ERPClassRoom();
            model.CName = name;

            model.Add();

            //写系统日志
            ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
            MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户添加排课信息(" + this.txtName.Value + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            ZWL.Common.MessageBox.ShowAndRedirect(this, "排课信息添加成功！", "Course.aspx");
        }
        else
        {
            ZWL.Common.MessageBox.Show(this, "该客户名称已经存在，请查证后再输入！");
        }
    }
}