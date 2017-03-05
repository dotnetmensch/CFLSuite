using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Entities
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BetParticipant> BetParticipants { get; set; }
        public virtual ICollection<RedemptionParticipant> RedemptionParticipants { get; set; }
        public virtual ICollection<Redemption> Redemptions { get; set; }
    }
}
