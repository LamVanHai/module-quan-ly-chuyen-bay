using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLCSharp
{
    class Change
    {
        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
        public int flightNumber { get; set; }
        public String from { get; set; }
        public String to { get; set; }
        public int airCode { get; set; }
        public decimal economyPrice { get; set; }
        public int confirmed { get; set; }
        public int id { get; set; }


        public Change()
        {

        }
    }
}
