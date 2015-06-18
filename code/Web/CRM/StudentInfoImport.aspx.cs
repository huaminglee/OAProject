using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

public partial class CRM_StudentInfoImport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 上传用户
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        string ErrorMsg = string.Empty;
        #region 上传文件包含验证
        /*验证是否选择了文件*/
        if (string.IsNullOrEmpty(FileUpload1.PostedFile.FileName))
        {
            lblMsg.Text = "请选择需要导入的Excel文件";
            return;
        }

        /*验证文件类型*/
        string FileExtension = FileUpload1.PostedFile.FileName.Split('.')[1].ToUpper();
        if (FileExtension != "XLS" && FileExtension != "XLSX")
        {
            lblMsg.Text = "文件类型错误，请上传正确的Excel文件";
            return;
        }

        /*上传文件*/
        //string FileName = Guid.NewGuid().ToString() + "." + FileExtension.ToLower();
        string ImgNameStr = "";
        string FileNewUrl = "";
        try
        {
            ImgNameStr = ZWL.Common.PublicMethod.UploadFileIntoDir(this.FileUpload1, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName));
            FileNewUrl = System.Web.HttpContext.Current.Request.MapPath("../UploadFile/" + ImgNameStr);
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
            return;
        }

        #endregion

        #region 将Excel转换为DataTable
        /*将Excel转换成DataTable*/
        System.Data.DataTable dt = ExcelToDataTable(FileNewUrl);

        /*验证Excel是否为空*/
        if (dt == null || dt.Rows.Count <= 0)
        {
            lblMsg.Text = "Excel文件为空，请重新上传Excel文件";
            try
            {
                //删除上传的Excel文件
                DelExcel(FileNewUrl);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.ToString();
                return;
            }
            return;
        }

        //转换成功，删除上传的Excel文件、
        try
        {
            DelExcel(FileNewUrl);
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
        }


        #endregion

        #region 重新设置列名
        int m = 0;
        dt.Columns[m++].ColumnName = "TrueName";
        dt.Columns[m++].ColumnName = "ParentTel";
        dt.Columns[m++].ColumnName = "Tel";
        dt.Columns[m++].ColumnName = "StuEmail";//
        dt.Columns[m++].ColumnName = "ParentEmail";
        dt.Columns[m++].ColumnName = "PaymentAmount";
        dt.Columns[m++].ColumnName = "DestinateCountry";
        dt.Columns[m++].ColumnName = "TestTime";
        dt.Columns[m++].ColumnName = "Remark";
        //dt.Columns[m++].ColumnName = "StaffCount";
        //dt.Columns[m++].ColumnName = "UsedStatus";        
        #endregion

        #region 数据验证,并重新构造实体列表
        int index = 2;

        //记录导入excel错误提示
        DataRow row;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            row = dt.Rows[i];
            #region 分管业务员
            //string custNo = string.Empty;
            //if (string.IsNullOrEmpty(row["Manager"].ToString()))
            //    ErrorMsg += "分管业务员不能为空。<br />";
            //else
            //{
            //    //row["Manager"] = XBase.Business.Common.EmployeeBus.GetEmployeeNameByName(row["Manager"].ToString(), CompanyCD);
            //}
            #endregion

            #region 若无错误信息，则将该行数据添加至新的数据源,反之则保存错误信息
            if (string.IsNullOrEmpty(ErrorMsg))
            {
                #region 添加数据
                if (string.IsNullOrEmpty(ErrorMsg))
                {
                    try
                    {
                        ZWL.BLL.ERPStudentInfo model = new ZWL.BLL.ERPStudentInfo();
                        model.TrueName = row["TrueName"].ToString();
                        //model.Grade = Grade;
                        model.ParentTel = row["ParentTel"].ToString();
                        model.Tel = row["Tel"].ToString();
                        model.AddPerson = ZWL.Common.PublicMethod.GetSessionValue("UserName");
                        model.StuEmail = row["StuEmail"].ToString();
                        model.ParentEmail = row["ParentEmail"].ToString();
                        model.IsGuoNei = 1;
                        model.Kemu = "";
                        model.BackGround = "";
                        model.TestTime = row["TestTime"].ToString();
                        model.QuDao = "朋友介绍";
                        model.DestinateCountry = row["DestinateCountry"].ToString();
                        model.ChuGuoTime = System.DateTime.Now;
                        model.PetitionTime = System.DateTime.Now;
                        model.SigningTime = System.DateTime.Now;
                        model.Class = 18;
                        model.PaymentAmount = decimal.Parse(row["PaymentAmount"].ToString());
                        model.Remark = row["Remark"].ToString();
                        model.Intention = 3;

                        if (string.IsNullOrEmpty(model.TrueName))
                        {
                            lblMsg.Text += string.Format("第{0}行记录，用户姓名不能为空！<br/>", i + 2);
                        }
                        else if (string.IsNullOrEmpty(model.Tel) && string.IsNullOrEmpty(model.ParentTel))
                        {
                            lblMsg.Text += string.Format("第{0}行记录，父母电话和学生电话不能同时为空！<br/>", i + 2);
                        }
                        else if (model.Exists(model.TrueName, model.ParentTel, model.Tel))
                        {
                            lblMsg.Text += string.Format("第{0}行记录在数据库中已存在！<br/>", i + 2);
                        }
                        else
                        {
                            if (model.Add() > 0)
                            {
                                ZWL.BLL.ERPUser muser = new ZWL.BLL.ERPUser();
                                muser.UserName = ZWL.Common.ChineseToSpell.ConvertToAllSpell(row["TrueName"].ToString());
                                muser.TrueName = row["TrueName"].ToString();
                                muser.Tel = row["ParentTel"].ToString(); ;
                                muser.JiaoSe = "VIP客户";
                                muser.Department = "VIP客户 ";
                                muser.UserPwd = ZWL.Common.DEncrypt.DESEncrypt.Encrypt(muser.UserName);
                                muser.Serils = DateTime.Now.ToString("yyyyMMddhms");
                                muser.ZaiGang = "在岗";
                                muser.IfLogin = "是";
                                muser.Cardno = "";

                                muser.Add();
                            }
                        }
                        //LinkManModel LinkManM = new LinkManModel();
                        //Hashtable ht = new System.Collections.Hashtable();
                        //bool res = CustInfoBus.CustInfoAdd(CustInfoM, LinkManM, ht);
                        //if (res)
                        //    lblMsg.Text = "数据导入成功！";
                        //else
                        //    lblMsg.Text = "数据导入失败！";
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = ex.ToString();
                    }

                }
                else
                {
                    lblMsg.Text = "数据导入失败，原因如下：<br />" + ErrorMsg;
                }

                #endregion

            }
            else
            {
                ErrorMsg = "第 " + index.ToString() + " 行中存在的错误：<br />" + ErrorMsg;
            }
            #endregion

            index++;
        }
        lblMsg.Text += "数据导入完成！";

        #endregion
    }

    /*将Excel转换成datatable */
    protected System.Data.DataTable ExcelToDataTable(string FileUrl)
    {
        /*转换成DataTable*/
        string SheetName = "Sheet1";//默认为sheet1
        string strConn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + FileUrl + ";Extended Properties='Excel 8.0;IMEX=1'";
        string strExcel = string.Format("select * from [{0}$]", SheetName);
        DataSet ds = new DataSet();
        try
        {
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
                adapter.Fill(ds, SheetName);
                conn.Close();
            }
        }
        catch
        {
        }
        System.Data.DataTable dt = ds.Tables[SheetName];
        return dt;
    }


    /*删除上传的Excel*/
    protected void DelExcel(string FileUrl)
    {
        FileInfo fileinfo = new FileInfo(FileUrl);
        if (fileinfo.Exists)
        {
            fileinfo.Delete();
        }
    }


    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("StudentInfo.aspx");
    }
}