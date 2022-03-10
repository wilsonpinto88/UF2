using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parquímetro
{
    public class Area
    {
        public int id;

        public double hourPrice;

        // max time represented in minutes
        public int? maxTime;

        public Area(int id, double hourPrice, int? maxTime)
        {
            this.id = id;
            this.hourPrice = hourPrice;
            this.maxTime = maxTime;
        }
    }
}
