using CFLSuite.DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Models
{
    public class PlayerPrizeModel
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string Prize { get; set; }
    }
}
