using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Entities
{
    public class Player
    {
        public Player()
        {
            Participants = new List<Participant>();
            PrizesLost = new List<Prize>();
            PrizesWon = new List<Prize>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<Prize> PrizesWon { get; set; }
        public virtual ICollection<Prize> PrizesLost { get; set; }

    }
}
