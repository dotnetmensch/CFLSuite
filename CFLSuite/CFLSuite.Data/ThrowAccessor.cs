using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFLSuite.DataContracts.Models;
using CFLSuite.DataContracts;
using CFLSuite.DataContracts.Entities;

namespace CFLSuite.Data
{
    public class ThrowAccessor
    {
        public List<ThrowModel> GetThrowModels(int participantID)
        {
            var result = new List<ThrowModel>();
            using (var db = new CFLSuiteDB())
            {
                result = db.Throws.Where(x => x.ParticipantID == participantID)
                    .ToThrowModels().ToList();
            }

            return result;
        }

        public ThrowModel GetThrowModel(int throwID)
        {
            ThrowModel result = null;
            using (var db = new CFLSuiteDB())
            {
                result = db.Throws.Where(x => x.ThrowID == throwID).ToThrowModels().First();
            }

            return result;
        }

        public List<RedeemedThrowModel> GetRedeemedThrowModels(int playerID, int betID)
        {
            var result = new List<RedeemedThrowModel>();
            using (var db = new CFLSuiteDB())
            {
                result = db.Throws.Where(x => x.Participant.BetID == betID && x.Participant.PlayerID == playerID)
                    .ToRedeemedThrowModels().ToList();
            }

            return result;
        }

        public ThrowModel DeleteThrowModel(ThrowModel model)
        {
            var result = model;
            using (var db = new CFLSuiteDB())
            {
                var existing = db.Throws.First(x => x.ThrowID == model.ThrowID);
                db.Throws.Remove(existing);
                db.SaveChanges();
            }
            return result;
        }

        public Throw SaveThrow(Throw model)
        {
            model.ValidateModel();
            Throw result = null;
            using (var db = new CFLSuiteDB())
            {
                if (model.ThrowID > 0)
                {
                    db.Throws.Attach(model);
                    db.Entry(model).State = EntityState.Modified;
                }
                else
                {
                    db.Throws.Add(model);
                }
                db.SaveChanges();
                result = db.Throws
                    .Include(x => x.ThrowType)
                    .Include(x => x.Bets)
                    .Include(x => x.Participant.Player)
                    .First(x => x.ThrowID == model.ThrowID);
            }

            return result;
        }

        public List<ThrowType> GetThrowTypes()
        {
            var result = new List<ThrowType>();
            using (var db = new CFLSuiteDB())
            {
                result = db.ThrowTypes.ToList();
            }

            return result;
        }

        public ThrowType SaveThrowType(ThrowType model)
        {
            model.ValidateModel();
            ThrowType result = null;
            using (var db = new CFLSuiteDB())
            {
                var dup = db.ThrowTypes.FirstOrDefault(x => x.Description == model.Description && x.ThrowTypeID != model.ThrowTypeID);
                if (dup == null)
                {
                    if (model.ThrowTypeID > 0)
                    {
                        db.ThrowTypes.Attach(model);
                        db.Entry(model).State = EntityState.Modified;
                    }
                    else
                    {
                        db.ThrowTypes.Add(model);
                    }
                }
                else
                {
                    throw new Exception("This throw already exists");
                }

                db.SaveChanges();
                result = model;
            }

            return result;
        }
    }
}
