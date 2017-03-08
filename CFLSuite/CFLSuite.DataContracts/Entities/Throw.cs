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
        public Throw()
        {
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ThrowID { get; set; }
        public int ThrowTypeID { get; set; }
        public int ParticipantID { get; set; }
        public bool Success { get; set; }
        public string Notes { get; set; }

        public virtual Participant Participant { get; set; }
        public virtual ThrowType ThrowType { get; set; }
        public virtual ICollection<Bet> Bets { get; set; }
    }
}
