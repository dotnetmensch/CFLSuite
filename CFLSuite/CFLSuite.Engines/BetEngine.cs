using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFLSuite.Data;
using CFLSuite.DataContracts.Entities;
using CFLSuite.DataContracts.Models;

namespace CFLSuite.Engines
{
    public class BetEngine
    {
        public List<Bet> BuildBets(Throw model, int redemptionBetCount)
        {
            var result = new List<Bet>();
            if (redemptionBetCount > model.Bets.Count)
            {
                for (int i = 0; i < redemptionBetCount - model.Bets.Count; i++)
                {
                    var bet = new Bet()
                    {
                        BetStarted = DateTime.Now,
                        Description = $"Redemption for {model.Participant.Player.Name}'s {model.ThrowType.Description}. Notes: {model.Notes}.",
                        ThrowID = model.ThrowID,
                        Participants = new List<Participant>
                        {
                            new Participant
                            {
                                PlayerID = model.Participant.PlayerID,
                            }
                        }
                    };
                }
            }

            return result;
        }
    }
}
