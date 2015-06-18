using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZWL.DBUtility;//Please add references
namespace ZWL.BLL
{
    /// <summary>
    /// 类ERPStudent。
    /// </summary>
    [Serializable]
    public partial class ERPStudentInfo
    {
        public ERPStudentInfo()
        { }
        #region Model
        private int _id;
        private string _truename;
        private int? _grade;
        private string _parenttel;
        private string _addperson;
        private string _stuemail;
        private string _parentemail;
        private int? _isguonei;
        private string _kemu;
        private string _background;
        private string _testtime;
        private string _qudao;
        private string _destinatecountry;
        private DateTime? _chuguotime;
        private DateTime? _petitiontime;
        private DateTime? _signingtime;
        private int? _class;
        private decimal? _paymentamount;
        private string _remark;
        private int? _intention;
        private int? _isdelete;
        private string _tel;
        private int? _status = 0;
        private string _belongs;
        private int? _fenpertims;
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
        public string TrueName
        {
            set { _truename = value; }
            get { return _truename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Grade
        {
            set { _grade = value; }
            get { return _grade; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParentTel
        {
            set { _parenttel = value; }
            get { return _parenttel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AddPerson
        {
            set { _addperson = value; }
            get { return _addperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StuEmail
        {
            set { _stuemail = value; }
            get { return _stuemail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParentEmail
        {
            set { _parentemail = value; }
            get { return _parentemail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsGuoNei
        {
            set { _isguonei = value; }
            get { return _isguonei; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Kemu
        {
            set { _kemu = value; }
            get { return _kemu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BackGround
        {
            set { _background = value; }
            get { return _background; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TestTime
        {
            set { _testtime = value; }
            get { return _testtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuDao
        {
            set { _qudao = value; }
            get { return _qudao; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DestinateCountry
        {
            set { _destinatecountry = value; }
            get { return _destinatecountry; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ChuGuoTime
        {
            set { _chuguotime = value; }
            get { return _chuguotime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PetitionTime
        {
            set { _petitiontime = value; }
            get { return _petitiontime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SigningTime
        {
            set { _signingtime = value; }
            get { return _signingtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Class
        {
            set { _class = value; }
            get { return _class; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PaymentAmount
        {
            set { _paymentamount = value; }
            get { return _paymentamount; }
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
        public int? Intention
        {
            set { _intention = value; }
            get { return _intention; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        ///状态（0,待分配 1,已分配 2,意向 3,上访 4,成交）
        /// </summary>
        public int? status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Belongs
        {
            set { _belongs = value; }
            get { return _belongs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FenperTims
        {
            set { _fenpertims = value; }
            get { return _fenpertims; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ERPStudentInfo(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,TrueName,Grade,ParentTel,AddPerson,StuEmail,ParentEmail,IsGuoNei,Kemu,BackGround,TestTime,QuDao,DestinateCountry,ChuGuoTime,PetitionTime,SigningTime,Class,PaymentAmount,Remark,Intention,IsDelete,tel,status,Belongs,FenperTims ");
            strSql.Append(" FROM [ERPStudent] ");
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
                if (ds.Tables[0].Rows[0]["TrueName"] != null)
                {
                    this.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Grade"] != null && ds.Tables[0].Rows[0]["Grade"].ToString() != "")
                {
                    this.Grade = int.Parse(ds.Tables[0].Rows[0]["Grade"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentTel"] != null)
                {
                    this.ParentTel = ds.Tables[0].Rows[0]["ParentTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddPerson"] != null)
                {
                    this.AddPerson = ds.Tables[0].Rows[0]["AddPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StuEmail"] != null)
                {
                    this.StuEmail = ds.Tables[0].Rows[0]["StuEmail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParentEmail"] != null)
                {
                    this.ParentEmail = ds.Tables[0].Rows[0]["ParentEmail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsGuoNei"] != null && ds.Tables[0].Rows[0]["IsGuoNei"].ToString() != "")
                {
                    this.IsGuoNei = int.Parse(ds.Tables[0].Rows[0]["IsGuoNei"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Kemu"] != null)
                {
                    this.Kemu = ds.Tables[0].Rows[0]["Kemu"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BackGround"] != null)
                {
                    this.BackGround = ds.Tables[0].Rows[0]["BackGround"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TestTime"] != null)
                {
                    this.TestTime = ds.Tables[0].Rows[0]["TestTime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["QuDao"] != null)
                {
                    this.QuDao = ds.Tables[0].Rows[0]["QuDao"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DestinateCountry"] != null)
                {
                    this.DestinateCountry = ds.Tables[0].Rows[0]["DestinateCountry"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ChuGuoTime"] != null && ds.Tables[0].Rows[0]["ChuGuoTime"].ToString() != "")
                {
                    this.ChuGuoTime = DateTime.Parse(ds.Tables[0].Rows[0]["ChuGuoTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PetitionTime"] != null && ds.Tables[0].Rows[0]["PetitionTime"].ToString() != "")
                {
                    this.PetitionTime = DateTime.Parse(ds.Tables[0].Rows[0]["PetitionTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SigningTime"] != null && ds.Tables[0].Rows[0]["SigningTime"].ToString() != "")
                {
                    this.SigningTime = DateTime.Parse(ds.Tables[0].Rows[0]["SigningTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Class"] != null && ds.Tables[0].Rows[0]["Class"].ToString() != "")
                {
                    this.Class = int.Parse(ds.Tables[0].Rows[0]["Class"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PaymentAmount"] != null && ds.Tables[0].Rows[0]["PaymentAmount"].ToString() != "")
                {
                    this.PaymentAmount = decimal.Parse(ds.Tables[0].Rows[0]["PaymentAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null)
                {
                    this.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Intention"] != null && ds.Tables[0].Rows[0]["Intention"].ToString() != "")
                {
                    this.Intention = int.Parse(ds.Tables[0].Rows[0]["Intention"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsDelete"] != null && ds.Tables[0].Rows[0]["IsDelete"].ToString() != "")
                {
                    this.IsDelete = int.Parse(ds.Tables[0].Rows[0]["IsDelete"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tel"] != null)
                {
                    this.Tel = ds.Tables[0].Rows[0]["tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    this.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Belongs"] != null)
                {
                    this.Belongs = ds.Tables[0].Rows[0]["Belongs"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FenperTims"] != null && ds.Tables[0].Rows[0]["FenperTims"].ToString() != "")
                {
                    this.FenperTims = int.Parse(ds.Tables[0].Rows[0]["FenperTims"].ToString());
                }
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ERPStudent]");
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
            strSql.Append("insert into [ERPStudent] (");
            strSql.Append("TrueName,Grade,ParentTel,AddPerson,StuEmail,ParentEmail,IsGuoNei,Kemu,BackGround,TestTime,QuDao,DestinateCountry,ChuGuoTime,PetitionTime,SigningTime,Class,PaymentAmount,Remark,Intention,IsDelete,tel,status,Belongs,FenperTims)");
            strSql.Append(" values (");
            strSql.Append("@TrueName,@Grade,@ParentTel,@AddPerson,@StuEmail,@ParentEmail,@IsGuoNei,@Kemu,@BackGround,@TestTime,@QuDao,@DestinateCountry,@ChuGuoTime,@PetitionTime,@SigningTime,@Class,@PaymentAmount,@Remark,@Intention,@IsDelete,@tel,@status,@Belongs,@FenperTims)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TrueName", SqlDbType.NVarChar,50),
					new SqlParameter("@Grade", SqlDbType.Int,4),
					new SqlParameter("@ParentTel", SqlDbType.NVarChar,20),
					new SqlParameter("@AddPerson", SqlDbType.NVarChar,10),
					new SqlParameter("@StuEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@IsGuoNei", SqlDbType.Int,4),
					new SqlParameter("@Kemu", SqlDbType.NVarChar,10),
					new SqlParameter("@BackGround", SqlDbType.NVarChar,1000),
					new SqlParameter("@TestTime", SqlDbType.NVarChar,100),
					new SqlParameter("@QuDao", SqlDbType.NVarChar,500),
					new SqlParameter("@DestinateCountry", SqlDbType.NVarChar,50),
					new SqlParameter("@ChuGuoTime", SqlDbType.DateTime),
					new SqlParameter("@PetitionTime", SqlDbType.DateTime),
					new SqlParameter("@SigningTime", SqlDbType.DateTime),
					new SqlParameter("@Class", SqlDbType.Int,4),
					new SqlParameter("@PaymentAmount", SqlDbType.Decimal,9),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@Intention", SqlDbType.Int,4),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@tel", SqlDbType.NVarChar,11),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@Belongs", SqlDbType.NVarChar,10),
					new SqlParameter("@FenperTims", SqlDbType.Int,4)};
            parameters[0].Value = TrueName;
            parameters[1].Value = Grade;
            parameters[2].Value = ParentTel;
            parameters[3].Value = AddPerson;
            parameters[4].Value = StuEmail;
            parameters[5].Value = ParentEmail;
            parameters[6].Value = IsGuoNei;
            parameters[7].Value = Kemu;
            parameters[8].Value = BackGround;
            parameters[9].Value = TestTime;
            parameters[10].Value = QuDao;
            parameters[11].Value = DestinateCountry;
            parameters[12].Value = ChuGuoTime;
            parameters[13].Value = PetitionTime;
            parameters[14].Value = SigningTime;
            parameters[15].Value = Class;
            parameters[16].Value = PaymentAmount;
            parameters[17].Value = Remark;
            parameters[18].Value = Intention;
            parameters[19].Value = IsDelete;
            parameters[20].Value = Tel;
            parameters[21].Value = status;
            parameters[22].Value = Belongs;
            parameters[23].Value = FenperTims;

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
            strSql.Append("update [ERPStudent] set ");
            strSql.Append("TrueName=@TrueName,");
            strSql.Append("Grade=@Grade,");
            strSql.Append("ParentTel=@ParentTel,");
            strSql.Append("AddPerson=@AddPerson,");
            strSql.Append("StuEmail=@StuEmail,");
            strSql.Append("ParentEmail=@ParentEmail,");
            strSql.Append("IsGuoNei=@IsGuoNei,");
            strSql.Append("Kemu=@Kemu,");
            strSql.Append("BackGround=@BackGround,");
            strSql.Append("TestTime=@TestTime,");
            strSql.Append("QuDao=@QuDao,");
            strSql.Append("DestinateCountry=@DestinateCountry,");
            strSql.Append("ChuGuoTime=@ChuGuoTime,");
            strSql.Append("PetitionTime=@PetitionTime,");
            strSql.Append("SigningTime=@SigningTime,");
            strSql.Append("Class=@Class,");
            strSql.Append("PaymentAmount=@PaymentAmount,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Intention=@Intention,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("tel=@tel,");
            strSql.Append("status=@status,");
            strSql.Append("Belongs=@Belongs,");
            strSql.Append("FenperTims=@FenperTims");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TrueName", SqlDbType.NVarChar,50),
					new SqlParameter("@Grade", SqlDbType.Int,4),
					new SqlParameter("@ParentTel", SqlDbType.NVarChar,20),
					new SqlParameter("@AddPerson", SqlDbType.NVarChar,10),
					new SqlParameter("@StuEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@IsGuoNei", SqlDbType.Int,4),
					new SqlParameter("@Kemu", SqlDbType.NVarChar,10),
					new SqlParameter("@BackGround", SqlDbType.NVarChar,1000),
					new SqlParameter("@TestTime", SqlDbType.NVarChar,100),
					new SqlParameter("@QuDao", SqlDbType.NVarChar,500),
					new SqlParameter("@DestinateCountry", SqlDbType.NVarChar,50),
					new SqlParameter("@ChuGuoTime", SqlDbType.DateTime),
					new SqlParameter("@PetitionTime", SqlDbType.DateTime),
					new SqlParameter("@SigningTime", SqlDbType.DateTime),
					new SqlParameter("@Class", SqlDbType.Int,4),
					new SqlParameter("@PaymentAmount", SqlDbType.Decimal,9),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@Intention", SqlDbType.Int,4),
					new SqlParameter("@IsDelete", SqlDbType.Int,4),
					new SqlParameter("@tel", SqlDbType.NVarChar,11),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@Belongs", SqlDbType.NVarChar,10),
					new SqlParameter("@FenperTims", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = TrueName;
            parameters[1].Value = Grade;
            parameters[2].Value = ParentTel;
            parameters[3].Value = AddPerson;
            parameters[4].Value = StuEmail;
            parameters[5].Value = ParentEmail;
            parameters[6].Value = IsGuoNei;
            parameters[7].Value = Kemu;
            parameters[8].Value = BackGround;
            parameters[9].Value = TestTime;
            parameters[10].Value = QuDao;
            parameters[11].Value = DestinateCountry;
            parameters[12].Value = ChuGuoTime;
            parameters[13].Value = PetitionTime;
            parameters[14].Value = SigningTime;
            parameters[15].Value = Class;
            parameters[16].Value = PaymentAmount;
            parameters[17].Value = Remark;
            parameters[18].Value = Intention;
            parameters[19].Value = IsDelete;
            parameters[20].Value = Tel;
            parameters[21].Value = status;
            parameters[22].Value = Belongs;
            parameters[23].Value = FenperTims;
            parameters[24].Value = ID;

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
            strSql.Append("delete from [ERPStudent] ");
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
            strSql.Append("select ID,TrueName,Grade,ParentTel,AddPerson,StuEmail,ParentEmail,IsGuoNei,Kemu,BackGround,TestTime,QuDao,DestinateCountry,ChuGuoTime,PetitionTime,SigningTime,Class,PaymentAmount,Remark,Intention,IsDelete,tel,status,Belongs,FenperTims ");
            strSql.Append(" FROM [ERPStudent] ");
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
                if (ds.Tables[0].Rows[0]["TrueName"] != null)
                {
                    this.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Grade"] != null && ds.Tables[0].Rows[0]["Grade"].ToString() != "")
                {
                    this.Grade = int.Parse(ds.Tables[0].Rows[0]["Grade"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentTel"] != null)
                {
                    this.ParentTel = ds.Tables[0].Rows[0]["ParentTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddPerson"] != null)
                {
                    this.AddPerson = ds.Tables[0].Rows[0]["AddPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StuEmail"] != null)
                {
                    this.StuEmail = ds.Tables[0].Rows[0]["StuEmail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParentEmail"] != null)
                {
                    this.ParentEmail = ds.Tables[0].Rows[0]["ParentEmail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsGuoNei"] != null && ds.Tables[0].Rows[0]["IsGuoNei"].ToString() != "")
                {
                    this.IsGuoNei = int.Parse(ds.Tables[0].Rows[0]["IsGuoNei"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Kemu"] != null)
                {
                    this.Kemu = ds.Tables[0].Rows[0]["Kemu"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BackGround"] != null)
                {
                    this.BackGround = ds.Tables[0].Rows[0]["BackGround"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TestTime"] != null)
                {
                    this.TestTime = ds.Tables[0].Rows[0]["TestTime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["QuDao"] != null)
                {
                    this.QuDao = ds.Tables[0].Rows[0]["QuDao"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DestinateCountry"] != null)
                {
                    this.DestinateCountry = ds.Tables[0].Rows[0]["DestinateCountry"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ChuGuoTime"] != null && ds.Tables[0].Rows[0]["ChuGuoTime"].ToString() != "")
                {
                    this.ChuGuoTime = DateTime.Parse(ds.Tables[0].Rows[0]["ChuGuoTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PetitionTime"] != null && ds.Tables[0].Rows[0]["PetitionTime"].ToString() != "")
                {
                    this.PetitionTime = DateTime.Parse(ds.Tables[0].Rows[0]["PetitionTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SigningTime"] != null && ds.Tables[0].Rows[0]["SigningTime"].ToString() != "")
                {
                    this.SigningTime = DateTime.Parse(ds.Tables[0].Rows[0]["SigningTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Class"] != null && ds.Tables[0].Rows[0]["Class"].ToString() != "")
                {
                    this.Class = int.Parse(ds.Tables[0].Rows[0]["Class"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PaymentAmount"] != null && ds.Tables[0].Rows[0]["PaymentAmount"].ToString() != "")
                {
                    this.PaymentAmount = decimal.Parse(ds.Tables[0].Rows[0]["PaymentAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null)
                {
                    this.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Intention"] != null && ds.Tables[0].Rows[0]["Intention"].ToString() != "")
                {
                    this.Intention = int.Parse(ds.Tables[0].Rows[0]["Intention"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsDelete"] != null && ds.Tables[0].Rows[0]["IsDelete"].ToString() != "")
                {
                    this.IsDelete = int.Parse(ds.Tables[0].Rows[0]["IsDelete"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tel"] != null)
                {
                    this.Tel = ds.Tables[0].Rows[0]["tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    this.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Belongs"] != null)
                {
                    this.Belongs = ds.Tables[0].Rows[0]["Belongs"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FenperTims"] != null && ds.Tables[0].Rows[0]["FenperTims"].ToString() != "")
                {
                    this.FenperTims = int.Parse(ds.Tables[0].Rows[0]["FenperTims"].ToString());
                }
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,b.TrueName bname ");
            strSql.Append(" FROM [ERPStudent] a left join [ERPUser] b on a.belongs=b.id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string trueName, string parentTel, string tel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ERPStudent]");
            strSql.Append(" where TrueName=@TrueName and (ParentTel=@ParentTel or Tel=@Tel) ");

            SqlParameter[] parameters = {
					new SqlParameter("@TrueName", SqlDbType.NVarChar,50),
                    new SqlParameter("@ParentTel", SqlDbType.NVarChar,11),
                    new SqlParameter("@Tel", SqlDbType.NVarChar,11)};
            parameters[0].Value = trueName;
            parameters[1].Value = parentTel;
            parameters[2].Value = tel;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public int FenPei(string cid, string gwid)
        {
            string sql = "update erpstudent set status=1,Belongs='{0}',signingtime=getdate() where ID ={1}";
            sql = string.Format(sql, gwid, cid);

            return DbHelperSQL.ExecuteSQL(sql);
        }

        private static int _maxid = 0;
        private static string TableName = "ERPStudent";
        public static int MaxID
        {
            get
            {
                if (_maxid == 0)
                {
                    int res = DbHelperSQL.GetMaxID("ID", TableName);

                    _maxid = Convert.ToInt32(res);
                    return _maxid;
                }
                return _maxid;
            }
        }
    }
}

