using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using tolson.BoosterStation.Adadpter;

namespace tolson.BoosterStation.UnitTest.Adapter
{
    [TestClass]
    public class SQLiteHelperTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            SQLiteHelper.ConnString = "Data Source=F:\\Code\\BoosterStation\\tolson.BoosterStation\\bin\\Debug\\data;Pooling=true;";
            using(var conn = new SQLiteConnection(SQLiteHelper.ConnString))
            {
                conn.Open();
                // 判断TestTable表是否存在，如果存在则删除
                using(var cmd = new SQLiteCommand("DROP TABLE IF EXISTS TestTable", conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // 创建TestTable表
                using(var cmd = new SQLiteCommand("CREATE TABLE TestTable (Id INTEGER PRIMARY KEY, Name TEXT)", conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        [TestMethod]
        public void TestExecuteNonQuery()
        {
            string sql = "INSERT INTO TestTable (Name) VALUES (@Name)";
            var parameters = new SQLiteParameter[] { new SQLiteParameter("@Name", "TestName") };

            int result = SQLiteHelper.ExecuteNonQuery(sql, parameters);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestExecuteScalar()
        {
            string sql = "INSERT INTO TestTable (Name) VALUES (@Name)";
            var parameters = new SQLiteParameter[] { new SQLiteParameter("@Name", "TestName") };
            SQLiteHelper.ExecuteNonQuery(sql, parameters);

            sql = "SELECT COUNT(*) FROM TestTable";
            object result = SQLiteHelper.ExecuteScalar(sql);

            Assert.AreEqual(1L, result);
        }

        [TestMethod]
        public void TestExecuteReader()
        {
            string sql = "INSERT INTO TestTable (Name) VALUES (@Name)";
            var parameters = new SQLiteParameter[] { new SQLiteParameter("@Name", "TestName") };
            SQLiteHelper.ExecuteNonQuery(sql, parameters);

            sql = "SELECT * FROM TestTable";
            using (var reader = SQLiteHelper.ExecuteReader(sql))
            {
                Assert.IsTrue(reader.HasRows);
                while (reader.Read())
                {
                    Assert.AreEqual("TestName", reader["Name"]);
                }
            }
        }

        [TestMethod]
        public void TestGetDataSet()
        {
            string sql = "INSERT INTO TestTable (Name) VALUES (@Name)";
            var parameters = new SQLiteParameter[] { new SQLiteParameter("@Name", "TestName") };
            SQLiteHelper.ExecuteNonQuery(sql, parameters);

            sql = "SELECT * FROM TestTable";
            DataSet ds = SQLiteHelper.GetDataSet(sql);

            Assert.AreEqual(1, ds.Tables[0].Rows.Count);
            Assert.AreEqual("TestName", ds.Tables[0].Rows[0]["Name"]);
        }

        [TestMethod]
        public void TestGetDataSetWithDictionary()
        {
            string sql = "INSERT INTO TestTable (Name) VALUES (@Name)";
            var parameters = new SQLiteParameter[] { new SQLiteParameter("@Name", "TestName") };
            SQLiteHelper.ExecuteNonQuery(sql, parameters);

            var dicTableAndSql = new Dictionary<string, string>
            {
                { "TestTable", "SELECT * FROM TestTable" }
            };
            DataSet ds = SQLiteHelper.GetDataSet(dicTableAndSql);

            Assert.AreEqual(1, ds.Tables["TestTable"].Rows.Count);
            Assert.AreEqual("TestName", ds.Tables["TestTable"].Rows[0]["Name"]);
        }
    }
}


