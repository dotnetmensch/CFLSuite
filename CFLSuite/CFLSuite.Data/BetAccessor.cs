using CFLSuite.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFLSuite.DataContracts.Entities;
using CFLSuite.DataContracts;

namespace CFLSuite.Data
{
    public class BetAccessor
    {
        public List<BetGridModel> GetBetGridModels()
        {
            var result = new List<BetGridModel>();
            using (var db = new CFLSuiteDB())
            {
                result = db.Bets.ToBetGridModel().ToList();
            }
            return result;
        }

        public BetGridModel SaveBetGridModel(BetGridModel model)
        {
            model.ValidateModel();
            BetGridModel result = null;
            using (var db = new CFLSuiteDB())
            {
                Bet dataModel = null;
                if(model.BetID > 0)
                {
                    dataModel = db.Bets.First(x => x.BetID == model.BetID);
                    dataModel.BetStarted = model.BetStarted;
                    dataModel.Description = model.Description;
                }
                else
                {
                    dataModel = new Bet
                    {
                        BetStarted = model.BetStarted,
                        Description = model.Description
                    };
                    db.Bets.Add(dataModel);
                }
                db.SaveChanges();
                result = db.Bets.Where(x => x.BetID == dataModel.BetID).ToBetGridModel().First();
            }

            return result;
        }

        public Bet GetBet(int betID)
        {
            Bet result = null;
            using (var db = new CFLSuiteDB())
            {
                result = db.Bets.First(x => x.BetID == betID);
            }

            return result;
        }
    }
}
