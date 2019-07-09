using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace WebDrive.App_Start
{
    public static class DatabaseConfig
    {
        #region 数据库连接配置
        /*****************数据库配置************************/
        struct DBConfig
        {
            public static string server = "localhost";         // 服务器
            public static string port = "3306";                    // 端口号
            public static string database = "webapi_db";   // 数据库
            public static string username = "root";            //用户名
            public static string password = "";                    //密码
        }

        public static string conn_string
        {
            get
            {
                string param = "";
                param += "server=" + DBConfig.server;
                param += ";port=" + DBConfig.port;
                param += ";database=" + DBConfig.database;
                param += ";username=" + DBConfig.username;
                param += ";password=" + DBConfig.password;
                param += ";";
                return param;
            }
        }

        public static string conn_string2 = "server=localhost;user=root;password=;database=webapi_db;";
        #endregion

        // 连接数据库
        public static MySqlConnection Connect()
        {
            MySqlConnection connect = new MySqlConnection(conn_string);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                connect.Open();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
            }
            connect.Close();
            return connect;
        }

    }
}
