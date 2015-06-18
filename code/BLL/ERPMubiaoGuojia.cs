using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZWL.DBUtility;
namespace ZWL.BLL
{
	/// <summary>
	/// 类ERPMubiaoGuojia。
	/// </summary>
	[Serializable]
	public partial class ERPMubiaoGuojia
	{
		public ERPMubiaoGuojia()
		{}
		#region Model
		private int _id;
		private string _name;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model


		#region  Method

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERPMubiaoGuojia(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Name ");
			strSql.Append(" FROM [ERPMubiaoGuojia] ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					this.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null)
				{
					this.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
			}
		}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{

		return DbHelperSQL.GetMaxID("ID", "ERPMubiaoGuojia"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ERPMubiaoGuojia]");
			strSql.Append(" where ID=@ID ");

			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [ERPMubiaoGuojia] (");
			strSql.Append("Name)");
			strSql.Append(" values (");
			strSql.Append("@Name)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,20)};
			parameters[0].Value = Name;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [ERPMubiaoGuojia] set ");
			strSql.Append("Name=@Name");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,20),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = Name;
			parameters[1].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [ERPMubiaoGuojia] ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public void GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Name ");
			strSql.Append(" FROM [ERPMubiaoGuojia] ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					this.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null )
				{
					this.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [ERPMubiaoGuojia] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  Method
	}
}

