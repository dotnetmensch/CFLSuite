using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFLSuite.DataContracts.Models;
using CFLSuite.Data;

namespace CFLSuite.Service
{
    public class PrizeService
    {
        public List<PrizeModel> GetPrizeModelsByLosingParticipant(int losingParticipantID)
        {
            return new PrizeAccessor().GetPrizeModelsByLosingParticipant(losingParticipantID);
        }

        public PrizeModel DeletePrizeModel(PrizeModel model)
        {
            return new PrizeAccessor().DeletePrizeModel(model);
        }

        public PrizeModel SavePrizeModel(PrizeModel model)
        {
            return new PrizeAccessor().SavePrizeModel(model);
        }
    }
}
