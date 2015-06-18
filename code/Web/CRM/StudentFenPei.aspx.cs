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
using ZWL.BLL;

public partial class CRM_CustomAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ZWL.Common.PublicMethod.CheckSession();

            binddroplist();
        }
    }

    private void binddroplist()
    {
        ZWL.BLL.ERPUser bll = new ZWL.BLL.ERPUser();
        List<ZWL.BLL.ERPUser> list = bll.GetListByJueSe("顾问部,顾问主管");

        ddlGuwenlist.DataSource = list;
        ddlGuwenlist.DataTextField = "UserName";
        ddlGuwenlist.DataValueField = "ID";
        ddlGuwenlist.DataBind();
    }

    //分配
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string id = Request.QueryString["id"];

        if (string.IsNullOrEmpty(id))
        {
            ZWL.Common.MessageBox.ShowAndRedirect(this, "参数为空！", "studentinfo.aspx");
        }

        string gwid = ddlGuwenlist.SelectedValue;
        ERPStudentInfo info = new ERPStudentInfo();
        int result = info.FenPei(id, gwid);

        if (result > 0)
        {
            //ZWL.Common.MessageBox.ShowAndRedirect(this, "提交成功", "studentinfo.aspx");
            Response.Redirect("studentinfo.aspx");
        }
    }
}