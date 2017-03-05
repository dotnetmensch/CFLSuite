using CFLSuite.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.Data
{
    public class BetAccessor
    {
        public List<BetGridModel> GetBetGridModels()
        {
            var result = new List<BetGridModel>();
            using (var db = new CFLSuiteDB())
            {
                result = db.Bets.Select(x => new BetGridModel
                {
                    BetID = x.BetID,
                    Started = x.BetDateTimeStarted,
                    ThrowDescription = x.ThrowDescription,
                    WinnerPlayerID = x.BetParticipants.FirstOrDefault(y => y.Winner).Player.PlayerID,
                    WinnerName = x.BetParticipants.FirstOrDefault(y => y.Winner).Player.Name,
                    WinCount = x.BetParticipants.Count(y => !y.Winner)
                }).ToList();
            }
            return result;
        }
    }
}
