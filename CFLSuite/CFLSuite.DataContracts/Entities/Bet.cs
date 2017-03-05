using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Entities
{
    public class Bet
    {
        public int BetID { get; set; }
        public string ThrowDescription { get; set; }
        public DateTime BetDateTimeStarted { get; set; }

        public virtual ICollection<BetParticipant> BetParticipants { get; set; }
    }
}
