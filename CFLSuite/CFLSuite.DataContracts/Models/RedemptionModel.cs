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
        public string Description { get; set; }
        public int ThrowID { get; set; }
        public string ThrowDescription { get; set; }
        [DisplayName("Redeeming On")]
        public int ParticipantID { get; set; }
        public string ParticipantName { get; set; }
    }
}
