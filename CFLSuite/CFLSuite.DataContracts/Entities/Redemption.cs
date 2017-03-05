using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Entities
{
    public class Redemption
    {
        public int RedemptionID { get; set; }
        public int? BetID { get; set; }
        public string Description { get; set; }
        public int PlayerID { get; set; }

        public virtual Bet Bet { get; set; }
        public virtual Player Player { get; set; }

        public virtual ICollection<RedemptionParticipant> RedemptionParticipants { get; set; }

    }
}
