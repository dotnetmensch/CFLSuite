using CFLSuite.DataContracts.Entities;
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
                //BetID = x.BetID,
                //Notes = x.Notes,
                //ReceivingPlayerID = x.ReceivingPlayerID,
                //Points = x.Success,
                //RedemptionForThrowID = x.RedemptionForThrowID,
                //ThrowID = x.ThrowID,
                //ThrowingPlayerID = x.ParticipantID,
                //ThrowingPlayerName = x.Participant.Name,
                //ThrowTypeDescription = x.ThrowType.Description,
                //ThrowTypeID = x.ThrowTypeID,
                //ReceivingPlayerName = x.ReceivingPlayer != null ? x.ReceivingPlayer.Name : string.Empty
            });
        }

        public static IQueryable<BetGridModel> ToBetGridModel(this IQueryable<Bet> bets)
        {
            return bets.Select(x => new BetGridModel
            {
                BetID = x.BetID,
                BetStarted = x.BetStarted,
                Description = x.Description,
            });
        }
    }
}
