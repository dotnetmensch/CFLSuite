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
                result = db.Bets.Where(x => x.ParentBetID == null)
                    .OrderByDescending(x => x.BetStarted)
                    .ToBetGridModel().ToList();
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
                if (model.BetID > 0)
                {
                    dataModel = db.Bets.First(x => x.BetID == model.BetID);
                    dataModel.BetStarted = model.BetStarted;
                    dataModel.Description = model.Description;
                }
                else
                {
                    dataModel = new Bet
                    {
                        BetStarted = model.BetStarted.ToUniversalTime(),
                        Description = model.Description
                    };
                    db.Bets.Add(dataModel);
                }
                db.SaveChanges();
                result = db.Bets.Where(x => x.BetID == dataModel.BetID).ToBetGridModel().First();
            }

            return result;
        }

        public RedemptionModel SaveRedemptionModel(RedemptionModel model)
        {
            model.ValidateModel();
            RedemptionModel result = null;
            Bet dataModel = null;
            using (var db = new CFLSuiteDB())
            {
                if (model.BetID > 0)
                {
                    dataModel = db.Bets.First(x => x.BetID == model.BetID);
                    dataModel.BetStarted = model.BetStarted;
                    dataModel.Description = model.Description;
                    dataModel.ThrowID = model.ThrowID;
                    dataModel.ParentBetID = model.ParentBetID;
                    var participant = db.Participants.FirstOrDefault(x => x.BetID == model.BetID && x.PlayerID == model.PlayerID);
                    if(participant == null)
                    {
                        participant = new Participant
                        {
                            PlayerID = model.PlayerID,
                            Winner = false,
                        };

                        dataModel.Participants.Add(participant);
                    }
                }
                else
                {
                    dataModel = new Bet
                    {
                        BetStarted = model.BetStarted,
                        Description = model.Description,
                        ThrowID = model.ThrowID,
                        ParentBetID = model.ParentBetID,
                        Participants = new List<Participant>()
                        {
                            new Participant
                            {
                                PlayerID = model.PlayerID,
                                Winner = false
                            }
                        }
                    };

                    db.Bets.Add(dataModel);
                }
                db.SaveChanges();
                result = db.Bets.Where(x => x.BetID == dataModel.BetID).ToRedemptionModel().First();
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

        public RedemptionModel DeleteRedemptionModel(RedemptionModel  model)
        {
            var result = model;
            using (var db = new CFLSuiteDB())
            {
                var existing = db.Bets.First(x => x.BetID == model.BetID);
                db.Bets.Remove(existing);
            }

            return result;
        }

        public List<Player> GetAllPlayersForRedemption(int betID)
        {
            var result = new List<Player>();
            using (var db = new CFLSuiteDB())
            {
                var betIDs = GetAllAssociatedBets(db, betID).Select(x => x.BetID);

                result = db.Players.Where(x => x.Participants.Any(y => betIDs.Contains(y.BetID))).ToList();
            }

            return result;
        }

        public List<PlayerPrizeModel> GetPlayerPrizeModels(int betID, int playerID)
        {
            var result = new List<PlayerPrizeModel>();
            using (var db = new CFLSuiteDB())
            {
                var betIDs = GetAllAssociatedBets(db, betID).Select(x => x.BetID);

                result = db.Prizes.Where(x => x.LosingParticipant.PlayerID == playerID && betIDs.Contains(x.LosingParticipant.BetID)).ToPlayerPrizeModel().ToList();
            }

            return result;
        }

        public List<Bet> GetAllAssociatedBets(CFLSuiteDB db, int betID)
        {
            var parentBet = db.Bets.GetTopParentBet(betID);
            var result = GetAllChildBets(db, parentBet.BetID).ToList();
            result.Add(parentBet);
            result.AddRange(GetAllChildBets(db, parentBet.BetID));
            return result;
        }

        public List<Bet> GetAllChildBets(CFLSuiteDB db, int betID)
        {
            var result = new List<Bet>();
            var bets = db.Bets.Where(x => x.ParentBetID == betID).ToList();
            result.AddRange(bets);
            foreach (var bet in bets)
            {
                result.AddRange(GetAllChildBets(db, bet.BetID));
            }
            return result;   
        }

        public List<RedemptionModel> GetBetsByParentBet(int betID)
        {
            var result = new List<RedemptionModel>();
            using (var db = new CFLSuiteDB())
            {
                var topParentBet = db.Bets.GetTopParentBet(betID);
                var betIDs = GetAllChildBets(db, topParentBet.BetID).Select(x => x.BetID);
                result = db.Bets.Where(x => betIDs.Contains(x.BetID))
                    .OrderByDescending(x => x.BetStarted)
                    .ToRedemptionModel().ToList();
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
                var dup = db.Participants.FirstOrDefault(x => x.PlayerID == model.PlayerID &&
                    x.BetID == model.BetID &&
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

        public List<Player> GetBetParticipantPlayers(int betID)
        {
            var result = new List<Player>();
            using (var db = new CFLSuiteDB())
            {
                result = db.Players.Where(x => x.Participants.Any(y => y.BetID == betID)).ToList();
            }
            return result;
        }

        public ParticipantModel DeleteParticipantModel(ParticipantModel model)
        {
            var result = model;
            using (var db = new CFLSuiteDB())
            {
                var existing = db.Participants.First(x => x.ParticipantID == model.ParticipantID);
                var throws = db.Throws.Any(x => x.ParticipantID == existing.ParticipantID);
                var prizes = db.Prizes.Any(x => x.LosingParticipantID == existing.ParticipantID || x.WinningParticipantID == existing.ParticipantID);

                if (throws || prizes)
                {
                    throw new Exception("Cannot delete this participant because they either have throws or payouts associated with them.");
                }

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

        public Bet GetBetByParticipant(int participantID)
        {
            Bet result = null;
            using (var db = new CFLSuiteDB())
            {
                result = db.Bets.First(x => x.Participants.Any(y => y.ParticipantID == participantID));
            }

            return result;
        }
    }
}
