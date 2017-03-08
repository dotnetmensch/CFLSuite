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
        public int ThrowID { get; set; }
        public int? BetID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Throw Type is required"), DisplayName("Throw Type")]
        public int ThrowTypeID { get; set; }
        public string ThrowTypeDescription { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Thrower is required"), DisplayName("Thrower")]
        public int ThrowingPlayerID { get; set; }
        public string ThrowingPlayerName { get; set; }

        public int Points { get; set; }
        [DisplayName("Receiving Player")]
        public int? ReceivingPlayerID { get; set; }
        public string ReceivingPlayerName { get; set; }
        public int? RedemptionForThrowID { get; set; }
        public string Notes { get; set; }
    }
}
