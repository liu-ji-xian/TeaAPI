using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace TeaAPI
{
    public class DBHelper
    {
        //连接
        public static SqlConnection GetConn()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=Tea;User ID=sa;pwd=1234");
        }
        //执行添加删除修改
        public static int ExecuteNonQuery(string sql, CommandType type = CommandType.Text, SqlParameter[] parm = null)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = type;
            if (parm != null)
            {
                cmd.Parameters.AddRange(parm);
            }
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        //查询首行首列
        public static object ExecuteScalar(string sql, CommandType type = CommandType.Text, SqlParameter[] parm = null)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = type;
            if (parm != null)
            {
                cmd.Parameters.AddRange(parm);
            }
            object i = cmd.ExecuteScalar();
            conn.Close();
            return i;
        }
        //查询多行多列
        public static SqlDataReader ExecuteReader(string sql, CommandType type = CommandType.Text, SqlParameter[] parm = null)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = type;
            if (parm != null)
            {
                cmd.Parameters.AddRange(parm);
            }
            SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return sdr;
        }


        //查询多行多列
        public static DataTable GetDataTable(string sql, CommandType type = CommandType.Text, SqlParameter[] parm = null)
        {
            SqlConnection conn = GetConn();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = type;
            if (parm != null)
            {
                cmd.Parameters.AddRange(parm);
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }


        //引用 newtownsoft 后 去掉注释
        public static List<T> GetList<T>(string sql, CommandType type = CommandType.Text, SqlParameter[] parm = null)
        {


            DataTable dt = GetDataTable(sql, type, parm);
            string json = JsonConvert.SerializeObject(dt);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json);
            return list;
        }


    }
}
