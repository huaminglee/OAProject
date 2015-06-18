using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ZWL.DBUtility;

namespace ZWL.BLL
{
    /// <summary>
    /// 类ERPFangKe。
    /// </summary>
    [Serializable]
    public partial class ERPFangKe
    {
        public ERPFangKe()
        { }
        #region Model
        private int _id;
        private string _customername;
        private string _telephone;
        private string _receiver;
        private string _description;
        private string _sourcefrom;
        private DateTime? _addtime;
        private DateTime? _PetitionTime;

        public DateTime? PetitionTime
        {
            get { return _PetitionTime; }
            set { _PetitionTime = value; }
        }
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
        public string CustomerName
        {
            set { _customername = value; }
            get { return _customername; }
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
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SourceFrom
        {
            set { _sourcefrom = value; }
            get { return _sourcefrom; }
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
        public ERPFangKe(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CustomerName,Telephone,Receiver,Description,SourceFrom,AddTime,PetitionTime ");
            strSql.Append(" FROM [ERPFangKe] ");
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
                if (ds.Tables[0].Rows[0]["CustomerName"] != null)
                {
                    this.CustomerName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Telephone"] != null)
                {
                    this.Telephone = ds.Tables[0].Rows[0]["Telephone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Receiver"] != null)
                {
                    this.Receiver = ds.Tables[0].Rows[0]["Receiver"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null)
                {
                    this.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SourceFrom"] != null)
                {
                    this.SourceFrom = ds.Tables[0].Rows[0]["SourceFrom"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    this.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PetitionTime"] != null && ds.Tables[0].Rows[0]["PetitionTime"].ToString() != "")
                {
                    this.PetitionTime = DateTime.Parse(ds.Tables[0].Rows[0]["PetitionTime"].ToString());
                }                
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ERPFangKe]");
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
            strSql.Append("insert into [ERPFangKe] (");
            strSql.Append("CustomerName,Telephone,Receiver,Description,SourceFrom,AddTime,PetitionTime)");
            strSql.Append(" values (");
            strSql.Append("@CustomerName,@Telephone,@Receiver,@Description,@SourceFrom,@AddTime,@PetitionTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerName", SqlDbType.NVarChar,20),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,11),
					new SqlParameter("@Receiver", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@SourceFrom", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@PetitionTime", SqlDbType.DateTime),};
            parameters[0].Value = CustomerName;
            parameters[1].Value = Telephone;
            parameters[2].Value = Receiver;
            parameters[3].Value = Description;
            parameters[4].Value = SourceFrom;
            parameters[5].Value = AddTime;
            parameters[6].Value = PetitionTime;

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
            strSql.Append("update [ERPFangKe] set ");
            strSql.Append("CustomerName=@CustomerName,");
            strSql.Append("Telephone=@Telephone,");
            strSql.Append("Receiver=@Receiver,");
            strSql.Append("Description=@Description,");
            strSql.Append("SourceFrom=@SourceFrom,");
            //strSql.Append("AddTime=@AddTime");
            strSql.Append("PetitionTime=@PetitionTime");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerName", SqlDbType.NVarChar,20),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,11),
					new SqlParameter("@Receiver", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@SourceFrom", SqlDbType.NVarChar,50),
					//new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@PetitionTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = CustomerName;
            parameters[1].Value = Telephone;
            parameters[2].Value = Receiver;
            parameters[3].Value = Description;
            parameters[4].Value = SourceFrom;
            //parameters[5].Value = AddTime;
            parameters[5].Value = PetitionTime;
            parameters[6].Value = ID;

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
            strSql.Append("delete from [ERPFangKe] ");
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
            strSql.Append("select ID,CustomerName,Telephone,Receiver,Description,SourceFrom,AddTime,PetitionTime ");
            strSql.Append(" FROM [ERPFangKe] ");
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
                if (ds.Tables[0].Rows[0]["CustomerName"] != null)
                {
                    this.CustomerName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Telephone"] != null)
                {
                    this.Telephone = ds.Tables[0].Rows[0]["Telephone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Receiver"] != null)
                {
                    this.Receiver = ds.Tables[0].Rows[0]["Receiver"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null)
                {
                    this.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SourceFrom"] != null)
                {
                    this.SourceFrom = ds.Tables[0].Rows[0]["SourceFrom"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    this.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PetitionTime"] != null && ds.Tables[0].Rows[0]["PetitionTime"].ToString() != "")
                {
                    this.PetitionTime = DateTime.Parse(ds.Tables[0].Rows[0]["PetitionTime"].ToString());
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
            strSql.Append(" FROM [ERPFangKe] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
