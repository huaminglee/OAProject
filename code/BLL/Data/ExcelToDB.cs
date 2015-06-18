using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using ZWL.DBUtility;

namespace ZWL.BLL.Data
{
    public class ExcelToDB
    {
        /// <summary>
        /// 获取Excel数据表列表
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetExcelTables(string FilePath)
        {
            //将Excel架构存入数据里
            System.Data.DataTable dt = new System.Data.DataTable();
            ArrayList TablesList = new ArrayList();

            if (File.Exists(FilePath))
            {
                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet." +
                     "OLEDB.4.0;Extended Properties=\"Excel 8.0\";Data Source=" + FilePath))
                {
                    try
                    {
                        conn.Open();
                        dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    }
                    catch (Exception exp)
                    {

                    }

                    //获取数据表个数
                    int tablecount = dt.Rows.Count;
                    for (int i = 0; i < tablecount; i = i + 2)
                    {
                        string tablename = dt.Rows[i][2].ToString().Trim().TrimEnd('$');
                        if (TablesList.IndexOf(tablename) < 0)
                        {
                            TablesList.Add(tablename);
                        }

                    }
                }
            }
            return TablesList;
        }

        /// <summary>
        /// 导入Excel数据表至DataTable（第一行作为表头）
        /// </summary>
        /// <returns></returns>
        public static System.Data.DataSet FillDataSet(string FilePath)
        {
            if (!File.Exists(FilePath))
            {
                throw new Exception("Excel文件不存在！");
            }

            ArrayList TableList = new ArrayList();
            TableList = GetExcelTables(FilePath);
            if (TableList.Count <= 0)
            {
                return null;
            }

            System.Data.DataTable table;
            System.Data.DataSet ds = new DataSet();
            OleDbConnection dbcon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties=Excel 8.0");
            try
            {
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }
                for (int i = 0; i < TableList.Count; i++)
                {
                    string dtname = TableList[i].ToString();
                    try
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [" + dtname + "$]", dbcon);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        table = new DataTable(dtname);
                        adapter.Fill(table);
                        ds.Tables.Add(table);
                    }
                    catch (Exception exp)
                    {

                    }
                }
            }
            finally
            {
                if (dbcon.State == ConnectionState.Open)
                {
                    dbcon.Close();
                }
            }
            return ds;
        }

        /// <summary>
        /// Excel导入数据库
        /// </summary>
        /// <returns></returns>
        public static DataSet ImportFromExcel(string FilePath)
        {
            return FillDataSet(FilePath);
        }

        public static void BulkToDB(DataTable dt)
        {
            //SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
            SqlConnection sqlConn = new SqlConnection(DbHelperSQL.ConnectionString);
            SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConn);
            bulkCopy.DestinationTableName = "ERPStudent";
            bulkCopy.BatchSize = dt.Rows.Count;

            try
            {
                sqlConn.Open();
                if (dt != null && dt.Rows.Count != 0)
                {
                    var column = new DataColumn("ID", System.Type.GetType("System.Int32"));

                    dt.Columns.Add(column);

                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName.ToLower().Equals("id"))
                        {
                            col.SetOrdinal(0);
                            break;
                        }
                    }
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i - 1]["ID"] = ERPStudentInfo.MaxID + i;
                    }

                    bulkCopy.WriteToServer(dt);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
                if (bulkCopy != null)
                    bulkCopy.Close();
            }
        }
    }
}
