using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tolson.BoosterStation.Dto;
using tolson.BoosterStation.Util;

namespace tolson.BoosterStation.Service
{
    public class HistoryDataService : Singleton<HistoryDataService>
    {
        private DateTime lastUpdateTime = DateTime.Now;
        private HistoryDataService(){}
        public void UpdateByPLCData(object obj)
        {
            PlcData plcData = obj as PlcData;
            if(plcData == null)
            {
                Console.WriteLine("UpdateByPLCData, obj is null");
                return;
            }

            // 更新间隔小于10秒，不保存
            if(DateTime.Now.Subtract(lastUpdateTime).TotalSeconds < 10)
            {
                return;
            }

            HistoryData data = new HistoryData
            {
                PressureIn = plcData.PressureIn,
                PressureOut = plcData.PressureOut,
                TempIn1 = plcData.TempIn1,
                TempIn2 = plcData.TempIn2,
                TempOut = plcData.TempOut,
                PressureTank1 = plcData.PressureTank1,
                PressureTank2 = plcData.PressureTank2,
                LevelTank1 = plcData.LevelTank1,
                LevelTank2 = plcData.LevelTank2,
                PressureTankOut = plcData.PressureTankOut,
                CreateUser = "system",
                UpdateUser = "system"
            };

            bool isSuccess = Save(data);
            if(isSuccess)
            {
                lastUpdateTime = DateTime.Now;
            }
        }

        public bool Save(HistoryData data)
        {
            try
            {
                string sql = "insert into plchistorydata(TempIn1,TempIn2,TempOut,PressureTank1,PressureTank2,LevelTank1,LevelTank2,PressureTankOut,CreateUser,UpdateUser) " +
    "values(@TempIn1,@TempIn2,@TempOut,@PressureTank1,@PressureTank2,@LevelTank1,@LevelTank2,@PressureTankOut,@CreateUser,@UpdateUser)";

                MySqlParameter[] mySqlParameter = new MySqlParameter[]
                {
                    new MySqlParameter("@TempIn1",data.TempIn1),
                    new MySqlParameter("@TempIn2",data.TempIn2),
                    new MySqlParameter("@TempOut",data.TempOut),
                    new MySqlParameter("@PressureTank1",data.PressureTank1),
                    new MySqlParameter("@PressureTank2",data.PressureTank2),
                    new MySqlParameter("@LevelTank1",data.LevelTank1),
                    new MySqlParameter("@LevelTank2",data.LevelTank2),
                    new MySqlParameter("@PressureTankOut",data.PressureTankOut),
                    new MySqlParameter("@CreateUser",data.CreateUser),
                    new MySqlParameter("@UpdateUser",data.UpdateUser)
                };

                int result = Adadpter.MySqlHelper.ExecuteNonQuery(CommandType.Text, sql, mySqlParameter);

                return result > 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine("保存历史数据失败" + ex.Message);
                return false;
            }
        }

        public List<HistoryData> Query(DateTime start,DateTime end)
        {
            List<HistoryData> list = new List<HistoryData>();
            try
            {
                string sql = "select * from plchistorydata where createTime >= @start and createTime <= @end ";

                MySqlParameter[] mySqlParameter = new MySqlParameter[]
                {
                new MySqlParameter("@start",start),
                new MySqlParameter("@end",end)
                };

                DataTable dt = Adadpter.MySqlHelper.GetDataTable(CommandType.Text, sql, mySqlParameter);
               
                foreach(DataRow dr in dt.Rows)
                {
                    HistoryData data = new HistoryData();
                    data.TempIn1 = (float)Math.Round(float.Parse(dr["TempIn1"].ToString()), 2);
                    data.TempIn2 = (float)Math.Round(float.Parse(dr["TempIn2"].ToString()), 2);
                    data.TempOut = (float)Math.Round(float.Parse(dr["TempOut"].ToString()), 2);
                    data.PressureTank1 = (float)Math.Round(float.Parse(dr["PressureTank1"].ToString()), 2);
                    data.PressureTank2 = (float)Math.Round(float.Parse(dr["PressureTank2"].ToString()), 2);
                    data.LevelTank1 = (float)Math.Round(float.Parse(dr["LevelTank1"].ToString()), 2);
                    data.LevelTank2 = (float)Math.Round(float.Parse(dr["LevelTank2"].ToString()), 2);
                    data.PressureTankOut = (float)Math.Round(float.Parse(dr["PressureTankOut"].ToString()), 2);
                    data.CreateTime = Convert.ToDateTime(dr["CreateTime"]);

                    list.Add(data);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("查询历史数据失败,{0}",ex.StackTrace);
            }

            return list;
        }
    }
}
