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
            bind();

            ZWL.Common.PublicMethod.CheckSession();
            ZWL.BLL.ERPClassType model = new ZWL.BLL.ERPClassType();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

            ddlType.SelectedValue = model.Type;
            txtName.Value = model.Name;

            
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
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (ZWL.Common.PublicMethod.IFExists("Name", "ERPClassType", int.Parse(Request.QueryString["ID"].ToString()), this.txtName.Value) == true)
        {
            string name = txtName.Value;

            ZWL.BLL.ERPClassType model = new ZWL.BLL.ERPClassType();
            model.ID = Convert.ToInt32(Request.QueryString["ID"]);
            model.Name = name;
            model.Type = ddlType.SelectedValue;

            model.Update();

            //写系统日志
            ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
            MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "字典信息(" + this.txtName.Value + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            ZWL.Common.MessageBox.ShowAndRedirect(this, "字典信息修改成功！", "ClassType.aspx");
        }
        else
        {
            ZWL.Common.MessageBox.Show(this, "该字典信息已经存在，请查证后再输入！");
        }
    }
}