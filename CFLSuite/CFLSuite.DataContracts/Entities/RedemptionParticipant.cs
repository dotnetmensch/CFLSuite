using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Entities
{
    public class RedemptionParticipant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RedemptionParticipantID { get; set; }
        public int PlayerID { get; set; }
        public int RedemptionID { get; set; }
        public bool Success { get; set; }
        public string Prize { get; set; }

        public virtual Player Player { get; set; }
        public virtual Redemption Redemption { get; set; }
    }
}
