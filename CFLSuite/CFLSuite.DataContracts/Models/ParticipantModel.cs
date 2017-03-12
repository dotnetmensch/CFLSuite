using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Models
{
    public class ParticipantModel
    {
        public int ParticipantID { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Player is required"), DisplayName("Player")]
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }

        [Required, Range(0,int.MaxValue, ErrorMessage = "Bet is required")]
        public int BetID { get; set; }
        public bool Winner { get; set; }
    }
}
