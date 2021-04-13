using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project
{
    public class Database
    {
        public static SqlConnection GetConnection()
        {
            string strCon = ConfigurationManager.ConnectionStrings["connString"].ToString();
            return new SqlConnection(strCon);
        }
        /// <summary>
        /// Phuong thu lay du lieu theo truy van sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataBySQL(string sql)
        {
            // Tao doi tuong SqlCommand de thuc hien truy van
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            // Tao doi tuong DataSet de chua du lieu duoc tra ve
            DataSet ds = new DataSet(); // Data cache
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static int ExecuteSQL(string sql, params SqlParameter[] para)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, GetConnection());
                cmd.Parameters.AddRange(para);
                cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                return 0;
            }
            return result;
        }

    }
}