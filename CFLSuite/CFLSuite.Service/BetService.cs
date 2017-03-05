using CFLSuite.Data;
using CFLSuite.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.Service
{
    public class BetService
    {
        public List<BetGridModel> GetBetGridModels()
        {
            return new BetAccessor().GetBetGridModels();
        }
    }
}
