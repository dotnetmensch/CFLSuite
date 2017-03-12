using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Models
{
    public class BetGridModel
    {
        public int BetID { get; set; }
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}"), DisplayName("Date Time Started")]
        public DateTime BetStarted { get; set; }

        [DisplayName("Winner")]
        public string WinnerName { get; set; }

    }
}
