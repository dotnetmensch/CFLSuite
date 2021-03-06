﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CFLSuite.DataContracts.Entities
{
    public class Prize
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrizeID { get; set; }
        public int WinningParticipantID { get; set; }
        public int LosingParticipantID { get; set; }
        public string PrizeDescription { get; set; }

        public virtual Participant WinningParticipant { get; set; }
        public virtual Participant LosingParticipant { get; set; }
    }
}