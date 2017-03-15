using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts.Entities
{
    public class ThrowType
    {
        public ThrowType()
        {
            Throws = new List<Throw>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ThrowTypeID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Throw> Throws { get; set; }
    }
}
