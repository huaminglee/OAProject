using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZWL.DBUtility;
namespace ZWL.BLL
{
    /// <summary>
    /// 类ERPPaiKe。
    /// </summary>
    [Serializable]
    public partial class ERPPaiKe
    {
        public ERPPaiKe()
        { }
        #region Model
        private int _id;
        private string _customername;
        private string _classroom;
        private string _classstyle;
        private string _classtype;
        private string _teachername;
        private string _assistant;
        private string _remark;
        private int? _isfinish;
        private DateTime? _starttime;
        private DateTime? _endtime;
        private DateTime? _addtime;
        private string _Kemu;

        public string Kemu
        {
            get { return _Kemu; }
            set { _Kemu = value; }
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
        public string ClassRoom
        {
            set { _classroom = value; }
            get { return _classroom; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassStyle
        {
            set { _classstyle = value; }
            get { return _classstyle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassType
        {
            set { _classtype = value; }
            get { return _classtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TeacherName
        {
            set { _teachername = value; }
            get { return _teachername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Assistant
        {
            set { _assistant = value; }
            get { return _assistant; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsFinish
        {
            set { _isfinish = value; }
            get { return _isfinish; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
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
        public ERPPaiKe(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CustomerName,ClassRoom,ClassStyle,ClassType,TeacherName,Assistant,Remark,IsFinish,StartTime,EndTime,AddTime,Kemu ");
            strSql.Append(" FROM [ERPPaiKe] ");
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
                if (ds.Tables[0].Rows[0]["ClassRoom"] != null)
                {
                    this.ClassRoom = ds.Tables[0].Rows[0]["ClassRoom"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ClassStyle"] != null)
                {
                    this.ClassStyle = ds.Tables[0].Rows[0]["ClassStyle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ClassType"] != null)
                {
                    this.ClassType = ds.Tables[0].Rows[0]["ClassType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TeacherName"] != null)
                {
                    this.TeacherName = ds.Tables[0].Rows[0]["TeacherName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Assistant"] != null)
                {
                    this.Assistant = ds.Tables[0].Rows[0]["Assistant"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null)
                {
                    this.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsFinish"] != null && ds.Tables[0].Rows[0]["IsFinish"].ToString() != "")
                {
                    this.IsFinish = int.Parse(ds.Tables[0].Rows[0]["IsFinish"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StartTime"] != null && ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    this.StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"] != null && ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    this.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    this.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Kemu"] != null)
                {
                    this.Kemu = ds.Tables[0].Rows[0]["Kemu"].ToString();
                }
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ERPPaiKe]");
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
            strSql.Append("insert into [ERPPaiKe] (");
            strSql.Append("CustomerName,ClassRoom,ClassStyle,ClassType,TeacherName,Assistant,Remark,IsFinish,StartTime,EndTime,AddTime,Kemu)");
            strSql.Append(" values (");
            strSql.Append("@CustomerName,@ClassRoom,@ClassStyle,@ClassType,@TeacherName,@Assistant,@Remark,@IsFinish,@StartTime,@EndTime,@AddTime,@Kemu)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerName", SqlDbType.NVarChar,20),
					new SqlParameter("@ClassRoom", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassStyle", SqlDbType.NVarChar,20),
					new SqlParameter("@ClassType", SqlDbType.NVarChar,20),
					new SqlParameter("@TeacherName", SqlDbType.NVarChar,20),
					new SqlParameter("@Assistant", SqlDbType.NVarChar,20),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@IsFinish", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@Kemu", SqlDbType.VarChar,200),};
            parameters[0].Value = CustomerName;
            parameters[1].Value = ClassRoom;
            parameters[2].Value = ClassStyle;
            parameters[3].Value = ClassType;
            parameters[4].Value = TeacherName;
            parameters[5].Value = Assistant;
            parameters[6].Value = Remark;
            parameters[7].Value = IsFinish;
            parameters[8].Value = StartTime;
            parameters[9].Value = EndTime;
            parameters[10].Value = AddTime;
            parameters[11].Value = Kemu;

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
            strSql.Append("update [ERPPaiKe] set ");
            strSql.Append("CustomerName=@CustomerName,");
            strSql.Append("ClassRoom=@ClassRoom,");
            strSql.Append("ClassStyle=@ClassStyle,");
            strSql.Append("ClassType=@ClassType,");
            strSql.Append("TeacherName=@TeacherName,");
            strSql.Append("Assistant=@Assistant,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("IsFinish=@IsFinish,");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Kemu=@Kemu");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerName", SqlDbType.NVarChar,20),
					new SqlParameter("@ClassRoom", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassStyle", SqlDbType.NVarChar,20),
					new SqlParameter("@ClassType", SqlDbType.NVarChar,20),
					new SqlParameter("@TeacherName", SqlDbType.NVarChar,20),
					new SqlParameter("@Assistant", SqlDbType.NVarChar,20),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@IsFinish", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4),
                                        new SqlParameter("@Kemu", SqlDbType.VarChar,200),};
            parameters[0].Value = CustomerName;
            parameters[1].Value = ClassRoom;
            parameters[2].Value = ClassStyle;
            parameters[3].Value = ClassType;
            parameters[4].Value = TeacherName;
            parameters[5].Value = Assistant;
            parameters[6].Value = Remark;
            parameters[7].Value = IsFinish;
            parameters[8].Value = StartTime;
            parameters[9].Value = EndTime;
            parameters[10].Value = AddTime;
            parameters[11].Value = ID;
            parameters[12].Value = Kemu;

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
            strSql.Append("delete from [ERPPaiKe] ");
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
            strSql.Append("select ID,CustomerName,ClassRoom,ClassStyle,ClassType,TeacherName,Assistant,Remark,IsFinish,StartTime,EndTime,AddTime,Kemu ");
            strSql.Append(" FROM [ERPPaiKe] ");
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
                if (ds.Tables[0].Rows[0]["ClassRoom"] != null)
                {
                    this.ClassRoom = ds.Tables[0].Rows[0]["ClassRoom"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ClassStyle"] != null)
                {
                    this.ClassStyle = ds.Tables[0].Rows[0]["ClassStyle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ClassType"] != null)
                {
                    this.ClassType = ds.Tables[0].Rows[0]["ClassType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TeacherName"] != null)
                {
                    this.TeacherName = ds.Tables[0].Rows[0]["TeacherName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Assistant"] != null)
                {
                    this.Assistant = ds.Tables[0].Rows[0]["Assistant"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null)
                {
                    this.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsFinish"] != null && ds.Tables[0].Rows[0]["IsFinish"].ToString() != "")
                {
                    this.IsFinish = int.Parse(ds.Tables[0].Rows[0]["IsFinish"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StartTime"] != null && ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    this.StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"] != null && ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    this.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    this.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Kemu"] != null)
                {
                    this.Kemu = ds.Tables[0].Rows[0]["Kemu"].ToString();
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
            strSql.Append(" FROM [ERPPaiKe] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}

