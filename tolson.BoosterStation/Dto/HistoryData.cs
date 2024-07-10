using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using xbd.s7netplus;

namespace tolson.BoosterStation.Dto
{
    public class HistoryData
    {
        public int Id { get; set; }
        public float PressureIn { get; set; }
        public float PressureOut { get; set; }
        public float TempIn1 { get; set; }
        public float TempIn2 { get; set; }
        public float TempOut { get; set; }
        public float PressureTank1 { get; set; }
        public float PressureTank2 { get; set; }
        public float LevelTank1 { get; set; }
        public float LevelTank2 { get; set; }
        public float PressureTankOut { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }
    }
}
