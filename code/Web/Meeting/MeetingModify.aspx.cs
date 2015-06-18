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

public partial class Meeting_MeetingModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ZWL.Common.PublicMethod.CheckSession();
            //绑定页面数据
            ZWL.BLL.ERPMeeting Model = new ZWL.BLL.ERPMeeting();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.TextBox1.Text = Model.MeetingTitle;
            this.TxtContent.Text = Model.HuiYiJiYao;
            this.TextBox2.Text = Model.MeetingZhuTi;
            this.TextBox3.Text = Model.MiaoShu;
            this.TextBox4.Text = Model.ChuXiRen;
            this.TextBox5.Text = Model.WangLuoHuiYiShiIP;
            this.TextBox6.Text = Model.HuiYiZhuChi;

            this.TextBox7.Value = Model.KaiShiTime.ToString().Split(' ')[0];
            //this.DropDownList1.SelectedValue = DateTime.Parse(Model.KaiShiTime.ToString()).Hour.ToString("D2");
            //this.DropDownList2.SelectedValue = DateTime.Parse(Model.KaiShiTime.ToString()).Minute.ToString("D2");

            this.TextBox8.Value = Model.JieShuTime.ToString().Split(' ')[0];
            //this.DropDownList3.SelectedValue = DateTime.Parse(Model.JieShuTime.ToString()).Hour.ToString("D2");
            //this.DropDownList4.SelectedValue = DateTime.Parse(Model.JieShuTime.ToString()).Minute.ToString("D2");            
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ZWL.BLL.ERPMeeting Model = new ZWL.BLL.ERPMeeting();
        Model.ID = int.Parse(Request.QueryString["ID"].ToString());
        Model.ChuXiRen = this.TextBox4.Text;
        Model.HuiYiJiYao = this.TxtContent.Text;
        Model.HuiYiZhuChi = this.TextBox6.Text;
        Model.JieShuTime = DateTime.Parse(this.TextBox8.Value.Trim());
        Model.KaiShiTime = DateTime.Parse(this.TextBox7.Value.Trim());
        Model.MeetingTitle = this.TextBox1.Text;
        Model.MeetingZhuTi = this.TextBox2.Text;
        Model.MiaoShu = this.TextBox3.Text;
        Model.WangLuoHuiYiShiIP = this.TextBox5.Text;
        Model.Update();

        //写系统日志
        ZWL.BLL.ERPRiZhi MyRiZhi = new ZWL.BLL.ERPRiZhi();
        MyRiZhi.UserName = ZWL.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改会议信息(" + this.TextBox1.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        ZWL.Common.MessageBox.ShowAndRedirect(this, "会议修改成功！", "MeetingDengJi.aspx");
    }
}