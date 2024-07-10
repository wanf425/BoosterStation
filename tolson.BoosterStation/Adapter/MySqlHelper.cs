using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;


namespace tolson.BoosterStation.Adadpter
{
    public class MySqlHelper
    {
        //数据库连接字符串
        public static string ConnString { get; set; } = string.Empty;

        /// <summary> 
        /// 执行insert、update、delete SQL语句
        /// </summary> 
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param> 
        /// <param name="cmdText">存储过程名称或者sql命令语句</param> 
        /// <param name="commandParameters">执行命令所用参数的集合</param> 
        /// <returns>执行命令所影响的行数</returns> 
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            using(MySqlConnection conn = new MySqlConnection(ConnString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 执行insert、update、delete 并得到受影响行的ID
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns>受影响行的ID</returns>
        public static object ExecuteNonExist(CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();

            using(MySqlConnection connection = new MySqlConnection(ConnString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteNonQuery();

                return cmd.LastInsertedId;
            }
        }

        /// <summary> 
        /// 执行insert、update、delete SQL语句（带事务）
        /// </summary> 
        /// <remarks> 
        ///举例: 
        /// int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24)); 
        /// </remarks> 
        /// <param name="trans">一个现有的事务</param> 
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param> 
        /// <param name="cmdText">存储过程名称或者sql命令语句</param> 
        /// <param name="commandParameters">执行命令所用参数的集合</param> 
        /// <returns>执行命令所影响的行数</returns> 
        public static int ExecuteNonQuery(MySqlTransaction trans, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
            catch
            {
                throw;
            }
        }

        /// <summary> 
        /// 返回单一结果的查询
        /// </summary> 
        /// <remarks> 
        ///例如: 
        /// Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24)); 
        /// </remarks> 
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param> 
        /// <param name="cmdText">存储过程名称或者sql命令语句</param> 
        /// <param name="commandParameters">执行命令所用参数的集合</param> 
        /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns> 
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            using(MySqlConnection connection = new MySqlConnection(ConnString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary> 
        /// 执行返回一个只读结果集的查询 
        /// </summary> 
        /// <remarks> 
        /// 举例: 
        /// MySqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24)); 
        /// </remarks> 
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param> 
        /// <param name="cmdText">存储过程名称或者sql命令语句</param> 
        /// <param name="commandParameters">执行命令所用参数的集合</param> 
        /// <returns>包含结果的读取器</returns> 
        public static MySqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(ConnString);
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return reader;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary> 
        /// 返回包含一张数据表的数据集的查询
        /// </summary> 
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param> 
        /// <param name="cmdText">存储过程名称或者sql命令语句</param> 
        /// <param name="commandParameters">执行命令所用参数的集合</param> 
        /// <returns></returns> 
        public static DataSet GetDataSet(CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(ConnString);
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();

                adapter.Fill(ds);
                cmd.Parameters.Clear();
                conn.Close();
                return ds;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 用指定的数据库连接字符串执行一个命令并返回一个数据表 
        /// </summary>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param> 
        /// <param name="cmdText">存储过程名称或者sql命令语句</param> 
        /// <param name="commandParameters">执行命令所用参数的集合</param> 
        public static DataTable GetDataTable(CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(ConnString);
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable ds = new DataTable();

                adapter.Fill(ds);
                cmd.Parameters.Clear();
                conn.Close();
                return ds;
            }
            catch
            {
                throw;
            }
        }

        /// <summary> 
        /// 准备执行一个命令 
        /// </summary> 
        /// <param name="cmd">sql命令</param> 
        /// <param name="conn">数据库连接</param> 
        /// <param name="trans">数据库事务</param> 
        /// <param name="cmdType">命令类型例如 存储过程或者文本</param> 
        /// <param name="cmdText">命令文本,例如:Select * from Products</param> 
        /// <param name="cmdParms">执行命令的参数</param> 
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
        {
            try
            {
                if(conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                if(trans != null)
                    cmd.Transaction = trans;
                cmd.CommandType = cmdType;

                if(cmdParms != null)
                {
                    foreach(MySqlParameter parm in cmdParms)
                        cmd.Parameters.Add(parm);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}



