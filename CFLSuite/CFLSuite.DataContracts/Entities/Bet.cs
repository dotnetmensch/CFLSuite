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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BetID { get; set; }
        public int ThrowTypeID { get; set; }
        public DateTime BetDateTimeStarted { get; set; }

        public virtual ThrowType ThrowType { get; set; }

        public virtual ICollection<BetParticipant> BetParticipants { get; set; }
    }
}
