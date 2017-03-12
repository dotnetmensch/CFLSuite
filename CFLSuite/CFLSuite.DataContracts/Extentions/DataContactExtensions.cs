﻿using CFLSuite.DataContracts.Entities;
using CFLSuite.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.DataContracts
{
    public static class DataContactExtensions
    {
        public static void ValidateModel(this object model)
        {
            var vc = new ValidationContext(model);

            List<ValidationResult> validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(model, vc, validationResults, true))
            {
                if (validationResults.Count > 0)
                {
                    throw new Exception(validationResults[0].ErrorMessage);
                }
            }
        }

        public static IQueryable<ThrowModel> ToThrowModels(this IQueryable<Throw> throws)
        {
            return throws.Select(x => new ThrowModel
            {
                ThrowID = x.ThrowID,
                ThrowTypeDescription = x.ThrowType.Description,
                ThrowTypeID = x.ThrowTypeID,
                Notes = x.Notes,
                Success = x.Success,
                ParticipantID = x.ParticipantID,
                RedemptionBets = x.Bets.Count,
                BetIDs = x.Bets.Select(y => y.BetID).ToList()
            });
        }

        public static IQueryable<BetGridModel> ToBetGridModel(this IQueryable<Bet> bets)
        {
            return bets.Select(x => new BetGridModel
            {
                BetID = x.BetID,
                BetStarted = x.BetStarted,
                Description = x.Description,
                WinnerName = x.Participants.Any(y => y.Winner) ? 
                    x.Participants.FirstOrDefault(y => y.Winner).Player.Name : 
                    string.Empty
            });
        }

        public static IQueryable<ParticipantModel> ToParticipantModels(this IQueryable<Participant> participants)
        {
            return participants.Select(x => new ParticipantModel()
            {
                ParticipantID = x.ParticipantID,
                BetID = x.BetID,
                Winner = x.Winner,
                PlayerID = x.PlayerID,
                PlayerName = x.Player.Name
            });
        }

        public static IQueryable<PrizeModel> ToPrizeModel(this IQueryable<Prize> prizes)
        {
            return prizes.Select(x => new PrizeModel
            {
                PrizeID = x.PrizeID,
                PrizeDescription = x.PrizeDescription,
                LosingParticipantID = x.LosingParticipantID,
                WinningParticipantID = x.WinningParticipantID,
                WinningPlayerName = x.WinningParticipant.Player.Name
            });
        }
    }
}
