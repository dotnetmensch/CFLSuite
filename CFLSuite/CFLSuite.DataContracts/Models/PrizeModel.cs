using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Models
{
    public class PrizeModel
    {
        public int PrizeID { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "Losing Player is required")]
        public int LosingParticipantID { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Winning Recipient is required."), DisplayName("Winning Recipient")]
        public int WinningParticipantID { get; set; }
        public string WinningPlayerName { get; set; }

        [Required, DisplayName("Prize Description")]
        public string PrizeDescription { get; set; }
    }
}
