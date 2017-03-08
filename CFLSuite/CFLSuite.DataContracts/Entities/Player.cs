﻿using System;
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
            Throws = new List<Throw>();
            PayoutToPlayers = new List<Throw>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Throw> Throws { get; set; }
        public virtual ICollection<Throw> PayoutToPlayers { get; set; }
    }
}
