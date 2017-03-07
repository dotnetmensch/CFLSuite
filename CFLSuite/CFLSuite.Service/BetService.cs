using CFLSuite.Data;
using CFLSuite.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFLSuite.DataContracts.Entities;

namespace CFLSuite.Service
{
    public class BetService
    {
        public List<BetGridModel> GetBetGridModels()
        {
            return new BetAccessor().GetBetGridModels();
        }

        public Bet GetBet(int id)
        {
            return new BetAccessor().GetBet(id);
        }

        public BetGridModel SaveBetGridModel(BetGridModel model)
        {
            return new BetAccessor().SaveBetGridModel(model);
        }

        public List<ThrowModel> GetThrowModels(int betID)
        {
            return new ThrowAccessor().GetThrowModels(betID);
        }

        public ThrowModel SaveThrowModel(ThrowModel model)
        {
            return new ThrowAccessor().SaveThrowModel(model);
        }

        public ThrowModel DeleteThrowModel(ThrowModel model)
        {
            return new ThrowAccessor().DeleteThrowModel(model);
        }
    }
}
