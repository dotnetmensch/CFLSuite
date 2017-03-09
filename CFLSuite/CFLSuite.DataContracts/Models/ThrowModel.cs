using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Models
{
    public class ThrowModel
    {
        public ThrowModel()
        {
            BetIDs = new List<int>();
        }
        public int ThrowID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Throw Type is required"), DisplayName("Throw Type")]
        public int ThrowTypeID { get; set; }
        public string ThrowTypeDescription { get; set; }
        public int ParticipantID { get; set; }
        public bool Success { get; set; }

        [DisplayName("Redemption Bets")]
        public int? RedemptionBets { get; set; }

        public List<int> BetIDs { get; set; }
        public string Notes { get; set; }
    }
}
