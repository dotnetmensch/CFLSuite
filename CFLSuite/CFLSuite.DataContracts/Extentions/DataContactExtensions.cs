using CFLSuite.DataContracts.Entities;
using CFLSuite.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                BetID = x.BetID,
                Notes = x.Notes,
                OwedPlayerID = x.OwedPlayerID,
                Points = x.Points,
                RedemptionForThrowID = x.RedemptionForThrowID,
                ThrowID = x.ThrowID,
                ThrowingPlayerID = x.ThrowingPlayerID,
                ThrowingPlayerName = x.ThrowingPlayer.Name,
                ThrowTypeDescription = x.ThrowType.Description,
                ThrowTypeID = x.ThrowTypeID
            });
        }

        public static IQueryable<BetGridModel> ToBetGridModel(this IQueryable<Bet> bets)
        {
            return bets.Select(x => new BetGridModel
            {
                BetID = x.BetID,
                BetStarted = x.BetStarted,
                Description = x.Description,
                WinnerPlayerID = x.Throws.FirstOrDefault(t => t.Points == x.Throws.Max(y => y.Points)).ThrowingPlayerID,
                WinnerName = x.Throws.FirstOrDefault(t => t.Points == x.Throws.Max(y => y.Points)).ThrowingPlayer.Name,
                WinCount = x.Throws.Select(y => y.ThrowingPlayerID).Distinct().Count() - 1
            });
        }
    }
}
