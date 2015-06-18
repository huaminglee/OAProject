﻿using System;
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
            ZWL.BLL.ERPMubiaoGuojia model = new ZWL.BLL.ERPMubiaoGuojia();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

            txtName.Value = model.Name;

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (ZWL.Common.PublicMethod.IFExists("Name", "ERPClassType", int.Parse(Request.QueryString["ID"].ToString()), this.txtName.Value) == true)
        {
            string name = txtName.Value;

            ZWL.BLL.ERPMubiaoGuojia model = new ZWL.BLL.ERPMubiaoGuojia();
            model.ID = Convert.ToInt32(Request.QueryString["ID"]);
            model.Name = name;

            model.Update();

            //写系统日志
            ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
            MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户修改客户信息(" + this.txtName.Value + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            ZWL.Common.MessageBox.ShowAndRedirect(this, "客户信息修改成功！", "MubiaoGuojia.aspx");
        }
        else
        {
            ZWL.Common.MessageBox.Show(this, "该客户名称已经存在，请查证后再输入！");
        }
    }
}