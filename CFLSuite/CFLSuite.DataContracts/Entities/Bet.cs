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
            Participants = new List<Participant>();
            Prizes = new List<Prize>();
        }
        public int BetID { get; set; }
        public string Description { get; set; }
        public DateTime BetStarted { get; set; }
        public int? ThrowID { get; set; }

        public virtual Throw Throw { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<Prize> Prizes { get; set; }
    }
}
