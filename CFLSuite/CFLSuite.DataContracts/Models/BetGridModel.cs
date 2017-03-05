using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Models
{
    public class BetGridModel
    {
        public int BetID { get; set; }
        public string ThrowDescription { get; set; }
        public DateTime Started { get; set; }
        public int WinnerPlayerID { get; set; }
        public string WinnerName { get; set; }
        public int WinCount { get; set; }

    }
}
