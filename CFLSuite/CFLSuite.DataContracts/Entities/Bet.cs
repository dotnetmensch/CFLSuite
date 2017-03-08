using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Entities
{
    public class Bet
    {
        public Bet()
        {
            Throws = new List<Throw>();
        }
        public int BetID { get; set; }
        public string Description { get; set; }
        public DateTime BetStarted { get; set; }

        public virtual ICollection<Throw> Throws { get; set; }
    }
}
