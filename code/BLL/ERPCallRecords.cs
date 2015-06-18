using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZWL.DBUtility;
using System.Data.SqlClient;

namespace ZWL.BLL
{
    /// <summary>
    /// 类ERPCallRecords。
    /// </summary>
    [Serializable]
    public partial class ERPCallRecords
    {
        public ERPCallRecords()
        { }
        #region Model
        private int _id;
        private string _uname;
        private string _telephone;
        private string _receiver;
        private DateTime? _addtime;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UName
        {
            set { _uname = value; }
            get { return _uname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Telephone
        {
            set { _telephone = value; }
            get { return _telephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Receiver
        {
            set { _receiver = value; }
            get { return _receiver; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ERPCallRecords(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UName,Telephone,Receiver,AddTime ");
            strSql.Append(" FROM [ERPCallRecords] ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    this.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UName"] != null)
                {
                    this.UName = ds.Tables[0].Rows[0]["UName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Telephone"] != null)
                {
                    this.Telephone = ds.Tables[0].Rows[0]["Telephone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Receiver"] != null)
                {
                    this.Receiver = ds.Tables[0].Rows[0]["Receiver"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    this.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ERPCallRecords]");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [ERPCallRecords] (");
            strSql.Append("UName,Telephone,Receiver,AddTime)");
            strSql.Append(" values (");
            strSql.Append("@UName,@Telephone,@Receiver,@AddTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UName", SqlDbType.NVarChar,10),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,11),
					new SqlParameter("@Receiver", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
            parameters[0].Value = UName;
            parameters[1].Value = Telephone;
            parameters[2].Value = Receiver;
            parameters[3].Value = AddTime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ERPCallRecords] set ");
            strSql.Append("UName=@UName,");
            strSql.Append("Telephone=@Telephone,");
            strSql.Append("Receiver=@Receiver,");
            strSql.Append("AddTime=@AddTime");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UName", SqlDbType.NVarChar,10),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,11),
					new SqlParameter("@Receiver", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = UName;
            parameters[1].Value = Telephone;
            parameters[2].Value = Receiver;
            parameters[3].Value = AddTime;
            parameters[4].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [ERPCallRecords] ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UName,Telephone,Receiver,AddTime ");
            strSql.Append(" FROM [ERPCallRecords] ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    this.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UName"] != null)
                {
                    this.UName = ds.Tables[0].Rows[0]["UName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Telephone"] != null)
                {
                    this.Telephone = ds.Tables[0].Rows[0]["Telephone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Receiver"] != null)
                {
                    this.Receiver = ds.Tables[0].Rows[0]["Receiver"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    this.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [ERPCallRecords] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
