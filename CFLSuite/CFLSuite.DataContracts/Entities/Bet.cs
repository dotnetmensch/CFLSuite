using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            ChildBets = new List<Bet>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BetID { get; set; }
        public string Description { get; set; }
        public DateTime BetStarted { get; set; }
        public int? ThrowID { get; set; }
        public int? ParentBetID { get; set; }

        public virtual Throw Throw { get; set; }
        public virtual Bet ParentBet { get; set; }
        public virtual ICollection<Bet> ChildBets { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
