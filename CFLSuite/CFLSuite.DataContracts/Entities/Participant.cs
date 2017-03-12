using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Entities
{
    public class Participant
    {
        public Participant()
        {
            Throws = new List<Throw>();
        }
        public int ParticipantID { get; set; }
        public int PlayerID { get; set; }
        public int BetID { get; set; }
        public bool Winner { get; set; }


        public virtual Player Player { get; set; }
        public virtual Bet Bet { get; set; }
        public virtual ICollection<Throw> Throws { get; set; }
        public virtual ICollection<Prize> PrizesWon { get; set; }
        public virtual ICollection<Prize> PrizesLost { get; set; }
    }
}
