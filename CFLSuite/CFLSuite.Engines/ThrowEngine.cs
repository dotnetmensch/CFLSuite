using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFLSuite.DataContracts.Entities;
using CFLSuite.DataContracts.Models;

namespace CFLSuite.Engines
{
    public class ThrowEngine
    {
        public Throw BuildThrow(ThrowModel model)
        {
            return new Throw()
            {
                ThrowID = model.ThrowID,
                ThrowTypeID = model.ThrowTypeID,
                ParticipantID = model.ParticipantID,
                Notes = model.Notes,
                Success = model.Success
            };
        }
    }
}
