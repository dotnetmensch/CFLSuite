using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Entities
{
    public class Throw
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ThrowID { get; set; }
        public int? BetID { get; set; }
        public int ThrowTypeID { get; set; }
        public int ThrowingPlayerID { get; set; }
        public int Points { get; set; }
        public int? OwedPlayerID { get; set; }
        public int? RedemptionForThrowID { get; set; }
        public string Notes { get; set; }

        public virtual Player ThrowingPlayer { get; set; }
        public virtual ThrowType ThrowType { get; set; }
        public virtual Player OwedPlayer { get; set; }
        public virtual Throw RedemptionForThrow { get; set; }
        public virtual Bet Bets { get; set; }
        public virtual ICollection<Throw> RedemptionThrows { get; set; }
    }
}
