using System;
using System.Collections.Generic;
using System.Text;
using ZWL.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace ZWL.BLL
{
    /// <summary>
    /// 类ERPAssistant。
    /// </summary>
    [Serializable]
    public partial class ERPAssistant
    {
        public ERPAssistant()
        { }
        #region Model
        private int _id;
        private string _name;
        private int? _age;
        private DateTime? _birth;
        private string _mobile;
        private int? _sex;
        private string _address;
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Age
        {
            set { _age = value; }
            get { return _age; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Birth
        {
            set { _birth = value; }
            get { return _birth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ERPAssistant(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Name,Age,Birth,Mobile,Sex,Address ");
            strSql.Append(" FROM [ERPAssistant] ");
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
                if (ds.Tables[0].Rows[0]["Name"] != null)
                {
                    this.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Age"] != null && ds.Tables[0].Rows[0]["Age"].ToString() != "")
                {
                    this.Age = int.Parse(ds.Tables[0].Rows[0]["Age"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Birth"] != null && ds.Tables[0].Rows[0]["Birth"].ToString() != "")
                {
                    this.Birth = DateTime.Parse(ds.Tables[0].Rows[0]["Birth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Mobile"] != null)
                {
                    this.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    this.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Address"] != null)
                {
                    this.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ERPAssistant]");
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
            strSql.Append("insert into [ERPAssistant] (");
            strSql.Append("Name,Age,Birth,Mobile,Sex,Address)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Age,@Birth,@Mobile,@Sex,@Address)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@Birth", SqlDbType.DateTime),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,50)};
            parameters[0].Value = Name;
            parameters[1].Value = Age;
            parameters[2].Value = Birth;
            parameters[3].Value = Mobile;
            parameters[4].Value = Sex;
            parameters[5].Value = Address;

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
            strSql.Append("update [ERPAssistant] set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Age=@Age,");
            strSql.Append("Birth=@Birth,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Address=@Address");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@Birth", SqlDbType.DateTime),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = Name;
            parameters[1].Value = Age;
            parameters[2].Value = Birth;
            parameters[3].Value = Mobile;
            parameters[4].Value = Sex;
            parameters[5].Value = Address;
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
            strSql.Append("delete from [ERPAssistant] ");
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
            strSql.Append("select ID,Name,Age,Birth,Mobile,Sex,Address ");
            strSql.Append(" FROM [ERPAssistant] ");
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
                if (ds.Tables[0].Rows[0]["Name"] != null)
                {
                    this.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Age"] != null && ds.Tables[0].Rows[0]["Age"].ToString() != "")
                {
                    this.Age = int.Parse(ds.Tables[0].Rows[0]["Age"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Birth"] != null && ds.Tables[0].Rows[0]["Birth"].ToString() != "")
                {
                    this.Birth = DateTime.Parse(ds.Tables[0].Rows[0]["Birth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Mobile"] != null)
                {
                    this.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    this.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Address"] != null)
                {
                    this.Address = ds.Tables[0].Rows[0]["Address"].ToString();
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
            strSql.Append(" FROM [ERPAssistant] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
