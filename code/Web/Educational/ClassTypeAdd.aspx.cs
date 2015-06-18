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
            bind();
        }
    }

    private void bind()
    {
        ZWL.BLL.ERPClassType model = new ZWL.BLL.ERPClassType();
        ddlType.DataSource = model.GetTypeList("");
        ddlType.DataTextField = "Type";
        ddlType.DataValueField = "Type";
        ddlType.DataBind();
    }

    //添加
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (ZWL.Common.PublicMethod.IFExists("CustomerName", "ERPClassType", 0, this.txtName.Value) == true)
        {
            string name = txtName.Value;

            ZWL.BLL.ERPClassType model = new ZWL.BLL.ERPClassType();
            model.Name = name;
            model.Type = ddlType.SelectedValue;

            model.Add();

            //写系统日志
            ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
            MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "字典信息(" + this.txtName.Value + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            ZWL.Common.MessageBox.ShowAndRedirect(this, "字典信息添加成功！", "ClassType.aspx");
        }
        else
        {
            ZWL.Common.MessageBox.Show(this, "该字典信息已经存在，请查证后再输入！");
        }
    }
}