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
using ZWL.Common;
using ZWL.DBUtility;

public partial class Main : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PublicMethod.CheckSession();            
            //Response.Write(ZWL.Common.PublicMethod.GetSessionValue("QuanXian"));

            //显示自定义导航快捷菜单
            this.Label3.Text = ZWL.DBUtility.DbHelperSQL.GetSHSL("select top 1 DaoHangList from ERPUser where UserName='" + ZWL.Common.PublicMethod.GetSessionValue("UserName") + "'");

            //绑定所有s的菜单项目
            BindTree(ListTreeView.Nodes, 0);
            //设置有权限的项才显示
            SetQuanXian();

            //显示授权信息文字
            //this.Label1.Text = ZWL.Common.DEncrypt.DESEncrypt.Decrypt(ZWL.DBUtility.DbHelperSQL.GetSHSL("select top 1 DanWeiStr from ERPSerils"), "www.baidu.com");

            //try
            //{
            //    this.ListTreeView.Nodes[0].Expanded = true;
            //}
            //catch
            //{ }
        }
    }
    private void BindTree(TreeNodeCollection Nds, int IDStr)
    {
        DataSet MYDT = ZWL.DBUtility.DbHelperSQL.GetDataSet("select * from ERPTreeList where ParentID=" + IDStr.ToString() +" and isdelete =0 order by PaiXuStr asc,ID asc");
        for (int i = 0; i < MYDT.Tables[0].Rows.Count; i++)
        {
            //if (MYDT.Tables[0].Rows[i]["NavigateUrlStr"].ToString().Trim().Length<=0||ZWL.Common.PublicMethod.StrIFIn("|" + MYDT.Tables[0].Rows[i]["ValueStr"].ToString() + "|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian")) == true)
            //{
            TreeNode MenuNode = new TreeNode();
            MenuNode.Text = MYDT.Tables[0].Rows[i]["TextStr"].ToString();
            MenuNode.Value = MYDT.Tables[0].Rows[i]["ValueStr"].ToString();
            int strId = int.Parse(MYDT.Tables[0].Rows[i]["ID"].ToString());
            MenuNode.ImageUrl = MYDT.Tables[0].Rows[i]["ImageUrlStr"].ToString();

            if (MYDT.Tables[0].Rows[i]["NavigateUrlStr"].ToString().Trim().Length <= 0)
            {
                MenuNode.SelectAction = TreeNodeSelectAction.Expand;
            }
            else
            {
                MenuNode.NavigateUrl = MYDT.Tables[0].Rows[i]["NavigateUrlStr"].ToString();
                MenuNode.Target = MYDT.Tables[0].Rows[i]["Target"].ToString();
            }
            Nds.Add(MenuNode);
            BindTree(Nds[Nds.Count - 1].ChildNodes, strId);
            //}            
        }
    }
    public void SetQuanXian()
    {
        //判断权限分配
        for (int i = 0; i < this.ListTreeView.Nodes.Count; i++)
        {
            for (int j = 0; j < this.ListTreeView.Nodes[i].ChildNodes.Count; j++)
            {
                //删除子菜单中的不在权限中的项
                for (int k = 0; k < this.ListTreeView.Nodes[i].ChildNodes[j].ChildNodes.Count; k++)
                {
                    if (PublicMethod.StrIFIn("|" + this.ListTreeView.Nodes[i].ChildNodes[j].ChildNodes[k].Value + "|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian")) == false)
                    {
                        this.ListTreeView.Nodes[i].ChildNodes[j].ChildNodes.Remove(this.ListTreeView.Nodes[i].ChildNodes[j].ChildNodes[k]);
                        k = -1;
                    }                    
                }
                //判断是父节点还是子节点
                if (this.ListTreeView.Nodes[i].ChildNodes[j].SelectAction == TreeNodeSelectAction.Expand)
                {
                    if (this.ListTreeView.Nodes[i].ChildNodes[j].ChildNodes.Count <= 0)
                    {
                        this.ListTreeView.Nodes[i].ChildNodes.Remove(this.ListTreeView.Nodes[i].ChildNodes[j]);
                        j = -1;
                    }
                }
                else
                {
                    if (PublicMethod.StrIFIn("|" + this.ListTreeView.Nodes[i].ChildNodes[j].Value + "|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian")) == false)
                    {
                        this.ListTreeView.Nodes[i].ChildNodes.Remove(this.ListTreeView.Nodes[i].ChildNodes[j]);
                        j = -1;
                    }
                }
            }
            //判断是父节点还是子节点
            if (this.ListTreeView.Nodes[i].SelectAction == TreeNodeSelectAction.Expand)
            {
                if (this.ListTreeView.Nodes[i].ChildNodes.Count <= 0)
                {
                    this.ListTreeView.Nodes.Remove(this.ListTreeView.Nodes[i]);
                    i = -1;
                }
            }
            else
            {
                if (PublicMethod.StrIFIn("|" + this.ListTreeView.Nodes[i].Value + "|", ZWL.Common.PublicMethod.GetSessionValue("QuanXian")) == false)
                {
                    this.ListTreeView.Nodes.Remove(this.ListTreeView.Nodes[i]);
                    i = -1;
                }
            }
        }
    }
}
