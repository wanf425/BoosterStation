using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tolson.BoosterStation.Dto
{
    public class LSData
    {
        public ushort CardNo { get; set; }
        public string Version { get; set; }
        public ushort[] Axies { get; set; }
        public uint TotalAxis { get; set; }

    }
}
