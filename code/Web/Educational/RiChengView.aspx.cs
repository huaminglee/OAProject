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

public partial class Work_RiChengView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ZWL.Common.PublicMethod.CheckSession();
            //绑定页面数据
            ZWL.BLL.ERPPaiKe Model = new ZWL.BLL.ERPPaiKe();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lcustomer.Text = Model.CustomerName;
            this.lteacher.Text = Model.TeacherName;
            this.lassistant.Text = Model.Assistant;
            this.lstarttime.Text = Model.StartTime.ToString();
            this.lendtime.Text = Model.EndTime.ToString();
            this.lclassroom.Text = Model.ClassRoom.ToString();
            lblClassStyle.Text = Model.ClassStyle;
            lblClassType.Text = Model.ClassType;
            lblKemu.Text = Model.Kemu;
            lblRemark.Text = Model.Remark;
            Label1.Text = Model.IsFinish == 0 ? "否" : "是";

        }
    }
}
