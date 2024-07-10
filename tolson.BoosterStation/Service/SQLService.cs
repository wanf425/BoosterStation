using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tolson.BoosterStation.Adadpter;

namespace tolson.BoosterStation.Service
{
    public class SQLService
    {
        public SQLService(string connString) {
            MySqlHelper.ConnString = connString;
        }
    }
}
