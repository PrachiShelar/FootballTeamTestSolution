using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeam.models
{
    public class DataHub
    {
        IData _obj;
        public DataHub(IData obj)
        {
            _obj = obj;
        }
        public List<FTeam> GetData()
        {
            return _obj.GetData();
        }

    }
}