using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZWL.DBUtility;
namespace ZWL.BLL
{
	/// <summary>
	/// 类ERPClassType。
	/// </summary>
	[Serializable]
	public partial class ERPClassType
	{
		public ERPClassType()
		{}
		#region Model
		private int _id;
		private string _name;
        private string _Type;

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
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
		public ERPClassType(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Name,Type ");
			strSql.Append(" FROM [ERPClassType] ");
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
                if (ds.Tables[0].Rows[0]["Type"] != null)
                {
                    this.Type = ds.Tables[0].Rows[0]["Type"].ToString();
                }
			}
		}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{

		return DbHelperSQL.GetMaxID("ID", "ERPClassType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ERPClassType]");
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
			strSql.Append("insert into [ERPClassType] (");
            strSql.Append("Name,Type)");
			strSql.Append(" values (");
            strSql.Append("@Name,@Type)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,200),
                    new SqlParameter("@Type", SqlDbType.NVarChar,200)
                                        };
			parameters[0].Value = Name;
            parameters[1].Value = Type;

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
			strSql.Append("update [ERPClassType] set ");
            strSql.Append("Name=@Name,Type=@Type");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,200),
                    new SqlParameter("@Type", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = Name;
            parameters[1].Value = Type;
            parameters[2].Value = ID;

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
			strSql.Append("delete from [ERPClassType] ");
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
            strSql.Append("select ID,Name,Type ");
			strSql.Append(" FROM [ERPClassType] ");
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
                if (ds.Tables[0].Rows[0]["Type"] != null)
                {
                    this.Type = ds.Tables[0].Rows[0]["Type"].ToString();
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
			strSql.Append(" FROM [ERPClassType] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where 1=1 "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ERPClassType> GetLists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [ERPClassType] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<ERPClassType> list = new List<ERPClassType>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new ERPClassType()
                    {
                        ID = int.Parse(dr["ID"].ToString()),
                        Name = dr["Name"].ToString(),
                        Type = dr["Type"].ToString()

                    });

                }

            }
            return list;
        }
        /// <summary>
        /// 获得Type
        /// </summary>
        public DataSet GetTypeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct Type ");
            strSql.Append(" FROM [ERPClassType] where Type is not null ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  Method
	}
}

