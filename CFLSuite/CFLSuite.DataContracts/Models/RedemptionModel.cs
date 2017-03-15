using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Models
{
    public class RedemptionModel
    {
        public int BetID { get; set; }
        [DisplayFormat(DataFormatString = "{0:g}"), DisplayName("Date Time Started")]
        public DateTime BetStarted { get; set; }

        [Required]
        public string Description { get; set; }

        [DisplayName("Throw"), Required, Range(1, int.MaxValue, ErrorMessage = "Throw is required")]
        public int ThrowID { get; set; }
        public string ThrowDescription { get; set; }
        [DisplayName("Redeeming On"), Required, Range(1, int.MaxValue, ErrorMessage = "Redeeming on player is required")]
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Parent Bet is required")]
        public int ParentBetID { get; set; }

    }
}
