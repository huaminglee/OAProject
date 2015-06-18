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
using ZWL.DBUtility;
using System.Data.SqlClient;

public partial class OnlineCount : System.Web.UI.Page
{
    public string TiXingJianGe = "30";
    public string TanChuStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //统一模块发送提醒
            SendTXMail("ERPCustomInfo", "YuJiTiXing", "CustomName", "否", "您设定的客户信息提醒时间已到！");
            SendTXMail("ERPLinkMan", "BirthDay", "NameStr", "是", "您的客户联系人生日日期已到！");
            SendTXMail("ERPHuiYuan", "ChuShengDate", "NameStr", "是", "您的会员生日日期已到！");
            SendTXMail("ERPLinkLog", "CusBakE", "LinkTitle", "否", "您设定的客户联系记录提醒时间已到！");
            SendTXMail("ERPSongYang", "CusBakE", "SongYangLiaoHao", "否", "您设定的客户送样记录提醒时间已到！");
            SendTXMail("ERPContract", "TiXingDate", "HeTongName", "否", "您设定的销售合同提醒时间已到！");
            SendTXMail("ERPBuyOrder", "TiXingDate", "OrderName", "否", "您设定的采购订单提醒时间已到！");
            SendTXMail("ERPSupplyLink", "ShengRi", "LinkManName", "是", "您的供应商联系人生日日期已到！");
            SendTXMail("ERPProject", "TiXingDate", "ProjectName", "否", "您设定的项目信息提醒时间已到！");

            //检测产品库存情况报警
            CheckKuCun();



            //检测需要发送信息提醒的项---日程安排
            CheckRiCheng();
            //检测需要发送信息提醒的项---仪器设备
            CheckYiQi();
            //检测需要发送信息提醒的项---保险费用
            CheckBX();

            //检测需要发送信息提醒的项---超时发送催办提醒
            CheckChaoShi();

            //检测需要发送信息提醒的助教
            CheckNoticeBeforeOneDay();

            //提示助教:上课结束后，提示助教将反馈学生教学信息和教师评分表反馈给教学总监。
            CheckNoticeAfterFinished();

            //提示助教:最后一次课程陪需结束，提前三天提示助教进行，拍照，写心得和教师评分表。
            CheckNoticeBeforeThreeDays();

            //提醒教师当日上课内容。
            CheckNoticeTakeClass();

            //超过7天的待定客户 恢复为待分配状态
            CheckNoticeStudent();

            ZWL.Common.PublicMethod.CheckSession();
            //刷新当前用户的激活时间
            DbHelperSQL.ExecuteSQL("update ERPUser set ActiveTime=getdate() where UserName='" + ZWL.Common.PublicMethod.GetSessionValue("UserName") + "'");
            this.HyperLink1.Text = DbHelperSQL.GetSHSL("select count(*) from ERPUser where datediff(minute,ActiveTime,getdate())<20");

            //获得提醒的间隔时间，是否提醒
            ZWL.BLL.ERPTiXing MyModel = new ZWL.BLL.ERPTiXing();
            MyModel.GetModel(int.Parse(ZWL.Common.PublicMethod.GetSessionValue("UserID")));
            TiXingJianGe = MyModel.TiXingTime;

            //是否需要提醒
            string IFTanChu = MyModel.IfTiXing;
            //获取新邮件个数
            int NewMailCount = int.Parse(ZWL.DBUtility.DbHelperSQL.GetSHSLInt("select count(*) from ERPLanEmail where ToUser='" + ZWL.Common.PublicMethod.GetSessionValue("UserName") + "' and EmailState='未读'"));
            this.HyperLink2.Text = NewMailCount.ToString();

            //需要提醒，弹出提醒窗口
            if (IFTanChu.Trim() == "是")
            {
                if (NewMailCount > 0)
                {
                    TanChuStr = "<script language=\"javascript\">var num=Math.random();var abc=screen.height-250;focusid=setTimeout(\"focus();window.showModelessDialog('SmsShow.aspx?rad=\" + num + \"','','scroll:1;status:0;help:0;resizable:0;dialogLeft:3px;dialogTop:\"+abc+\"px;dialogWidth:350px;dialogHeight:200px')\",0000)</script>";
                }
            }
        }
        catch
        { }
    }

    //发送统一性的提醒邮件
    protected void SendTXMail(string TableName, string LieName, string TitleLieName, string IFOnlyDate, string MailContent)
    {
        string ToDayStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();

        DataSet MyDataSet = ZWL.DBUtility.DbHelperSQL.GetDataSet("select * from " + TableName);
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            if (IFOnlyDate == "是")
            {
                ToDayStr = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                if (ZWL.Common.PublicMethod.LongToShortStr(MyDataSet.Tables[0].Rows[j][LieName].ToString(), 5) == ToDayStr)
                {
                    ZWL.BLL.ERPLanEmail MyModel = new ZWL.BLL.ERPLanEmail();
                    MyModel.EmailContent = MailContent + "(" + MyDataSet.Tables[0].Rows[j][TitleLieName].ToString() + ")";
                    MyModel.EmailState = "未读";
                    MyModel.EmailTitle = MailContent + "(" + MyDataSet.Tables[0].Rows[j][TitleLieName].ToString() + ")";
                    MyModel.FromUser = "系统消息";
                    MyModel.FuJian = "";
                    MyModel.TimeStr = DateTime.Now;
                    MyModel.ToUser = ZWL.Common.PublicMethod.GetSessionValue("UserName");
                    if (ZWL.Common.PublicMethod.IFExists("EmailTitle", "ERPLanEmail", 0, MyModel.EmailTitle) == true)
                    {
                        MyModel.Add();
                    }
                }
            }
            else
            {
                if (MyDataSet.Tables[0].Rows[j][LieName].ToString() == ToDayStr)
                {
                    ZWL.BLL.ERPLanEmail MyModel = new ZWL.BLL.ERPLanEmail();
                    MyModel.EmailContent = MailContent + "(" + MyDataSet.Tables[0].Rows[j][TitleLieName].ToString() + ")";
                    MyModel.EmailState = "未读";
                    MyModel.EmailTitle = MailContent + "(" + MyDataSet.Tables[0].Rows[j][TitleLieName].ToString() + ")";
                    MyModel.FromUser = "系统消息";
                    MyModel.FuJian = "";
                    MyModel.TimeStr = DateTime.Now;
                    MyModel.ToUser = ZWL.Common.PublicMethod.GetSessionValue("UserName");
                    if (ZWL.Common.PublicMethod.IFExists("EmailTitle", "ERPLanEmail", 0, MyModel.EmailTitle) == true)
                    {
                        MyModel.Add();
                    }
                }
            }
        }
    }

    protected void CheckChaoShi()
    {
        DataSet MyDataSet = ZWL.DBUtility.DbHelperSQL.GetDataSet("select * from ERPNWorkToDo where getdate()>LateTime and StateNow='正在办理' and  ','+ShenPiUserList+',' like '%," + ZWL.Common.PublicMethod.GetSessionValue("UserName") + ",%' and ','+OKUserList+',' not like '%," + ZWL.Common.PublicMethod.GetSessionValue("UserName") + ",%' order by ID asc");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            ZWL.BLL.ERPLanEmail MyModel = new ZWL.BLL.ERPLanEmail();
            MyModel.EmailContent = "您有待办工作未办理，时间已超时！。(" + MyDataSet.Tables[0].Rows[j]["WorkName"].ToString() + "-工作流水号：" + MyDataSet.Tables[0].Rows[j]["ID"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您有待办工作未办理，时间已超时！(" + MyDataSet.Tables[0].Rows[j]["WorkName"].ToString() + "-工作流水号：" + MyDataSet.Tables[0].Rows[j]["ID"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            if (ZWL.Common.PublicMethod.IFExists("EmailTitle", "ERPLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }

    //检测产品库存
    protected void CheckKuCun()
    {
        DataSet MyDataSet = ZWL.DBUtility.DbHelperSQL.GetDataSet("select * from ERPProduct  where NowKuCun<=KuCunBaoJing  order by ID asc");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            ZWL.BLL.ERPLanEmail MyModel = new ZWL.BLL.ERPLanEmail();
            MyModel.EmailContent = "您的产品库存不足，请及时处理！(" + MyDataSet.Tables[0].Rows[j]["ProductName"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您的产品库存不足，请及时处理！(" + MyDataSet.Tables[0].Rows[j]["ProductName"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            if (ZWL.Common.PublicMethod.IFExists("EmailTitle", "ERPLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }

    protected void CheckBX()
    {
        string ToDayStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
        DataSet MyDataSet = ZWL.DBUtility.DbHelperSQL.GetDataSet("select * from ERPCarBaoXian where UserName='" + ZWL.Common.PublicMethod.GetSessionValue("UserName") + "'  and TiXingDate='" + ToDayStr + "'");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            ZWL.BLL.ERPLanEmail MyModel = new ZWL.BLL.ERPLanEmail();
            MyModel.EmailContent = "您所制定的车辆保险费用提醒时间到。(" + MyDataSet.Tables[0].Rows[j]["CarName"].ToString() + "--" + MyDataSet.Tables[0].Rows[j]["FeiYongName"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您所制定的车辆保险费用提醒时间到。(" + MyDataSet.Tables[0].Rows[j]["CarName"].ToString() + "--" + MyDataSet.Tables[0].Rows[j]["FeiYongName"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            if (ZWL.Common.PublicMethod.IFExists("EmailTitle", "ERPLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }

    protected void CheckYiQi()
    {
        string ToDayStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
        DataSet MyDataSet = ZWL.DBUtility.DbHelperSQL.GetDataSet("select * from ERPSheBei where ','+TiXingUser+',' like '%," + ZWL.Common.PublicMethod.GetSessionValue("UserName") + ",%'  and TiXingDate='" + ToDayStr + "'");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            ZWL.BLL.ERPLanEmail MyModel = new ZWL.BLL.ERPLanEmail();
            MyModel.EmailContent = "您所制定的仪器设备溯源提醒时间到。(" + MyDataSet.Tables[0].Rows[j]["SheBeiName"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您所制定的仪器设备溯源提醒时间到。(" + MyDataSet.Tables[0].Rows[j]["SheBeiName"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            if (ZWL.Common.PublicMethod.IFExists("EmailTitle", "ERPLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }

    protected void CheckRiCheng()
    {
        string ToDayStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
        DataSet MyDataSet = ZWL.DBUtility.DbHelperSQL.GetDataSet("select * from ERPAnPai where UserName= '" + ZWL.Common.PublicMethod.GetSessionValue("UserName") + "'  and TimeTiXing='" + ToDayStr + "'");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            ZWL.BLL.ERPLanEmail MyModel = new ZWL.BLL.ERPLanEmail();
            MyModel.EmailContent = "您所制定的日程安排提醒时间到。(" + MyDataSet.Tables[0].Rows[j]["TitleStr"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您所制定的日程安排提醒时间到。(" + MyDataSet.Tables[0].Rows[j]["TitleStr"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            if (ZWL.Common.PublicMethod.IFExists("EmailTitle", "ERPLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }

    /// <summary>
    /// 提示助教:最后一次课程陪需结束，提前三天提示助教进行，拍照，写心得和教师评分表。
    /// </summary>
    protected void CheckNoticeBeforeThreeDays()
    {
        //string ToDayStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
        string ToDayStr = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd");
        DataSet MyDataSet = ZWL.DBUtility.DbHelperSQL.GetDataSet("select * from ERPPaike where ','+ Assistant +',' like '%," + ZWL.Common.PublicMethod.GetSessionValue("UserName") + ",%'  and TimeStr='" + ToDayStr + "'");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            ZWL.BLL.ERPLanEmail MyModel = new ZWL.BLL.ERPLanEmail();
            MyModel.EmailContent = "您参与协助的课程快结束了，请及时进行，拍照，写心得和教师评分表。(" + MyDataSet.Tables[0].Rows[j]["ClassRoom"].ToString() + MyDataSet.Tables[0].Rows[j]["ClassStyle"].ToString() + "客户：" + MyDataSet.Tables[0].Rows[j]["CustomerName"].ToString() + "，授课老师：" + MyDataSet.Tables[0].Rows[j]["TeacherName"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您参与协助的课程快结束了，请及时进行，拍照，写心得和教师评分表。(" + MyDataSet.Tables[0].Rows[j]["ClassRoom"].ToString() + MyDataSet.Tables[0].Rows[j]["ClassStyle"].ToString() + "客户：" + MyDataSet.Tables[0].Rows[j]["CustomerName"].ToString() + "，授课老师：" + MyDataSet.Tables[0].Rows[j]["TeacherName"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            if (ZWL.Common.PublicMethod.IFExists("EmailTitle", "ERPLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }
    /// <summary>
    /// 提示助教:提前一天，通知第二天要上课的家长和上课内容
    /// </summary>
    protected void CheckNoticeBeforeOneDay()
    {
        //string ToDayStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
        string ToDayStr = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        DataSet MyDataSet = ZWL.DBUtility.DbHelperSQL.GetDataSet("select * from ERPPaike where ','+ Assistant +',' like '%," + ZWL.Common.PublicMethod.GetSessionValue("UserName") + ",%'  and TimeStr='" + ToDayStr + "'");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            ZWL.BLL.ERPLanEmail MyModel = new ZWL.BLL.ERPLanEmail();
            MyModel.EmailContent = "您好，这是明天要参加的课程，请及时通知家长和老师。(" + MyDataSet.Tables[0].Rows[j]["ClassRoom"].ToString() + MyDataSet.Tables[0].Rows[j]["ClassStyle"].ToString() + "客户：" + MyDataSet.Tables[0].Rows[j]["CustomerName"].ToString() + "，授课老师：" + MyDataSet.Tables[0].Rows[j]["TeacherName"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您好，这是明天要参加的课程，请及时通知家长和老师。(" + MyDataSet.Tables[0].Rows[j]["ClassRoom"].ToString() + MyDataSet.Tables[0].Rows[j]["ClassStyle"].ToString() + "客户：" + MyDataSet.Tables[0].Rows[j]["CustomerName"].ToString() + "，授课老师：" + MyDataSet.Tables[0].Rows[j]["TeacherName"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            if (ZWL.Common.PublicMethod.IFExists("EmailTitle", "ERPLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }
    /// <summary>
    /// 提示助教:上课结束后，提示助教将反馈学生教学信息和教师评分表反馈给教学总监。
    /// </summary>
    protected void CheckNoticeAfterFinished()
    {
        //string ToDayStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
        string ToDayStr = DateTime.Now.ToString("yyyy-MM-dd");
        DataSet MyDataSet = ZWL.DBUtility.DbHelperSQL.GetDataSet("select * from ERPPaike where ','+ Assistant +',' like '%," + ZWL.Common.PublicMethod.GetSessionValue("UserName") + ",%'  and TimeStr='" + ToDayStr + "'" + " and IsFinish=1");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            ZWL.BLL.ERPLanEmail MyModel = new ZWL.BLL.ERPLanEmail();
            MyModel.EmailContent = "您所参与的课程已结束，请及时将反馈学生教学信息和教师评分表反馈给教学总监。(" + MyDataSet.Tables[0].Rows[j]["ClassRoom"].ToString() + MyDataSet.Tables[0].Rows[j]["ClassStyle"].ToString() + "客户：" + MyDataSet.Tables[0].Rows[j]["CustomerName"].ToString() + "，授课老师：" + MyDataSet.Tables[0].Rows[j]["TeacherName"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您所参与的课程已结束，请及时将反馈学生教学信息和教师评分表反馈给教学总监。(" + MyDataSet.Tables[0].Rows[j]["ClassRoom"].ToString() + MyDataSet.Tables[0].Rows[j]["ClassStyle"].ToString() + "客户：" + MyDataSet.Tables[0].Rows[j]["CustomerName"].ToString() + "，授课老师：" + MyDataSet.Tables[0].Rows[j]["TeacherName"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            if (ZWL.Common.PublicMethod.IFExists("EmailTitle", "ERPLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }
    /// <summary>
    /// 提示老师:提醒教师当日上课内容。
    /// </summary>
    protected void CheckNoticeTakeClass()
    {
        //string ToDayStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
        string ToDayStr = DateTime.Now.ToString("yyyy-MM-dd");
        DataSet MyDataSet = ZWL.DBUtility.DbHelperSQL.GetDataSet("select * from ERPPaike where ','+ TeacherName +',' like '%," + ZWL.Common.PublicMethod.GetSessionValue("UserName") + ",%'  and TimeStr='" + ToDayStr + "'" + " and IsFinish=0");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            ZWL.BLL.ERPLanEmail MyModel = new ZWL.BLL.ERPLanEmail();
            MyModel.EmailContent = "您预定的授课时间定于今天，请准时出席。(" + MyDataSet.Tables[0].Rows[j]["ClassRoom"].ToString() + MyDataSet.Tables[0].Rows[j]["ClassStyle"].ToString() + "客户：" + MyDataSet.Tables[0].Rows[j]["CustomerName"].ToString() + "，授课老师：" + MyDataSet.Tables[0].Rows[j]["TeacherName"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您预定的授课时间定于今天，请准时出席(" + MyDataSet.Tables[0].Rows[j]["ClassRoom"].ToString() + MyDataSet.Tables[0].Rows[j]["ClassStyle"].ToString() + "客户：" + MyDataSet.Tables[0].Rows[j]["CustomerName"].ToString() + "，授课老师：" + MyDataSet.Tables[0].Rows[j]["TeacherName"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = ZWL.Common.PublicMethod.GetSessionValue("UserName");
            if (ZWL.Common.PublicMethod.IFExists("EmailTitle", "ERPLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }

    protected void CheckNoticeStudent()
    {
        string sql = "update erpstudent set belongs='', status=0 where status=2 and datediff(day,signingtime,getdate())>7";
        DbHelperSQL.ExecuteSQL(sql);
    }
}
