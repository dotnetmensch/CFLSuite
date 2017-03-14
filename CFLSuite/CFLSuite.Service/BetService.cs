using CFLSuite.Data;
using CFLSuite.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CFLSuite.DataContracts;
using CFLSuite.DataContracts.Entities;
using CFLSuite.Engines;

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

        public List<RedeemedThrowModel> GetRedeemedThrowModels(int betID)
        {
            return new ThrowAccessor().GetRedeemedThrowModels(betID);
        }

        public BetGridModel SaveBetGridModel(BetGridModel model)
        {
            return new BetAccessor().SaveBetGridModel(model);
        }

        public List<RedemptionModel> GetRedemptionsByParentBet(int betID)
        {
            return new BetAccessor().GetRedemptionsByParentBet(betID);
        }

        public List<ThrowModel> GetThrowModels(int participantID)
        {
            return new ThrowAccessor().GetThrowModels(participantID);
        }

        public RedemptionModel SaveRedemptionModel(RedemptionModel model)
        {
            return new BetAccessor().SaveRedemptionModel(model);
        }

        public ThrowModel SaveThrowModel(ThrowModel model)
        {
            var result = model;
            model.ValidateModel();
            var throwEngine = new ThrowEngine();
            var throwAccessor = new ThrowAccessor();
            var betEngine = new BetEngine();
            var betAccessor = new BetAccessor();
            var parentBet = betAccessor.GetBetByParticipant(model.ParticipantID);

            using (var scope = new TransactionScope())
            {
                var savedThrow = throwAccessor.SaveThrow(throwEngine.BuildThrow(model));
                var betsToAdd = betEngine.BuildBets(savedThrow, model.RedemptionBets, parentBet.BetID);
               
                foreach (var bet in betsToAdd)
                {
                    betAccessor.AddNewBetWithNewParticipants(bet);
                }

                result = throwAccessor.GetThrowModel(savedThrow.ThrowID);
                scope.Complete();
            }

            return result;
        }

        public ParticipantModel GetParticipantModel(int partcipantID)
        {
            return new BetAccessor().GetParticipantModel(partcipantID);
        }

        public ThrowModel DeleteThrowModel(ThrowModel model)
        {
            return new ThrowAccessor().DeleteThrowModel(model);
        }

        public ParticipantModel SaveParticipantModel(ParticipantModel model)
        {
            return new BetAccessor().SaveParticipantModel(model);
        }

        public List<ParticipantModel> GetBetParticipantModels(int betID)
        {
            return new BetAccessor().GetBetParticipantModels(betID);
        }

        public ParticipantModel DeleteParticipantModel(ParticipantModel model)
        {
            return new BetAccessor().DeleteParticipantModel(model);
        }

        public List<Player> GetAllPlayersForBet(int betID)
        {
            return new BetAccessor().GetAllPlayersForRedemption(betID);
        }

        public List<PlayerPrizeModel> GetPlayerPrizeModels(int betID, int playerID)
        {
            return new BetAccessor().GetPlayerPrizeModels(betID, playerID);
        }
    }
}
