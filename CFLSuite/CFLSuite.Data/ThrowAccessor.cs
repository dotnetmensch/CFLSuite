using System;
using System.Collections.Generic;
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
        public List<ThrowModel> GetThrowModels(int betID)
        {
            var result = new List<ThrowModel>();
            using (var db = new CFLSuiteDB())
            {
                result = db.Throws.Where(x => x.BetID == betID)
                    .ToThrowModels().ToList();
            }

            return result;
        }

        public ThrowModel SaveThrowModel(ThrowModel model)
        {
            model.ValidateModel();
            ThrowModel result = null;
            using (var db = new CFLSuiteDB())
            {
                Throw dataModel = null; 
                if(model.ThrowID > 0)
                {
                    dataModel = db.Throws.First(x => x.ThrowID == model.ThrowID);
                    dataModel.BetID = model.BetID;
                    dataModel.Notes = model.Notes;
                    dataModel.ReceivingPlayerID = model.ReceivingPlayerID;
                    dataModel.Points = model.Points;
                    dataModel.RedemptionForThrowID = model.RedemptionForThrowID;
                    dataModel.ThrowingPlayerID = model.ThrowingPlayerID;
                    dataModel.ThrowTypeID = model.ThrowTypeID;
                }
                else
                {
                    dataModel = new Throw
                    {
                        BetID = model.BetID,
                        Notes = model.Notes,
                        ReceivingPlayerID = model.ReceivingPlayerID,
                        Points = model.Points,
                        RedemptionForThrowID = model.RedemptionForThrowID,
                        ThrowingPlayerID = model.ThrowingPlayerID,
                        ThrowTypeID = model.ThrowTypeID
                    };
                    db.Throws.Add(dataModel);
                }
                db.SaveChanges();

                result = db.Throws.Where(x => x.ThrowID == dataModel.ThrowID).ToThrowModels().First();
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
    }
}
