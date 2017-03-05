using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Entities
{
    public class BetParticipant
    {
        public int BetParticipantID { get; set; }
        public int PlayerID { get; set; }
        public int BetID { get; set; }
        public bool Winner { get; set; }
        public string Payout { get; set; }

        //Nav Props
        public virtual Player Player { get; set; }
        public virtual Bet Bet { get; set; }
    }
}
