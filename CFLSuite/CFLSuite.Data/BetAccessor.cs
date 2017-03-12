using CFLSuite.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                result = db.Bets.Where(x => x.ThrowID == null).ToBetGridModel().ToList();
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

        public ParticipantModel GetParticipantModel(int partcipantID)
        {
            ParticipantModel result = null;
            using (var db = new CFLSuiteDB())
            {
                result = db.Participants.Where(x => x.ParticipantID == partcipantID).ToParticipantModels().First();
            }
            return result;
        }

        public ParticipantModel SaveParticipantModel(ParticipantModel model)
        {
            model.ValidateModel();
            ParticipantModel result = null;
            using (var db = new CFLSuiteDB())
            {
                Participant dataModel = null;
                var dup = db.Participants.FirstOrDefault(
                           x => x.PlayerID == model.PlayerID && x.BetID == model.BetID &&
                             x.ParticipantID != model.ParticipantID);
                if (dup == null)
                {
                    if (model.ParticipantID > 0)
                    {
                        dataModel = db.Participants.First(x => x.ParticipantID == model.ParticipantID);
                        dataModel.Winner = model.Winner;
                        dataModel.PlayerID = model.PlayerID;
                    }
                    else
                    {
                        dataModel = new Participant()
                        {
                            BetID = model.BetID,
                            PlayerID = model.PlayerID,
                            Winner = model.Winner
                        };
                        db.Participants.Add(dataModel);
                    }
                    db.SaveChanges();
                    result =
                        db.Participants.Where(x => x.ParticipantID == dataModel.ParticipantID)
                            .ToParticipantModels().First();
                }
                else
                {
                    throw new Exception("That participant already exists for this bet.");
                }
            }
            return result;
        }

        public List<ParticipantModel> GetBetParticipantModels(int betID)
        {
            var result = new List<ParticipantModel>();
            using (var db = new CFLSuiteDB())
            {
                result = db.Participants.Where(x => x.BetID == betID).ToParticipantModels().ToList();
            }
            return result;
        }

        public ParticipantModel DeleteParticipantModel(ParticipantModel model)
        {
            var result = model;
            using (var db = new CFLSuiteDB())
            {
                var existing = db.Participants.First(x => x.ParticipantID == model.ParticipantID);
                db.Participants.Remove(existing);
                db.SaveChanges();
            }
            return result;
        }

        public Bet AddNewBetWithNewParticipants(Bet bet)
        {
            Bet result = null;
            using (var db = new CFLSuiteDB())
            {
                db.Bets.Add(bet);
                db.SaveChanges();
                result = bet;
            }
            return result;
        }

        public Participant GetParticipant(int participantID)
        {
            Participant result = null;
            using (var db = new CFLSuiteDB())
            {
                result = db.Participants.Include(x => x.Player).First(x => x.ParticipantID == participantID);
            }

            return result;
        }
    }
}
