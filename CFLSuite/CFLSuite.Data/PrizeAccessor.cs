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
    public class PrizeAccessor
    {
        public List<PrizeModel> GetPrizeModelsByLosingParticipant(int losingParticipantID)
        {
            var result = new List<PrizeModel>();
            using (var db = new CFLSuiteDB())
            {
                result = db.Prizes.Where(x => x.LosingParticipantID == losingParticipantID).ToPrizeModel().ToList();
            }

            return result;
        }

        public PrizeModel DeletePrizeModel(PrizeModel model)
        {
            var result = model;
            using (var db = new CFLSuiteDB())
            {
                var existing = db.Prizes.First(x => x.PrizeID == model.PrizeID);
                db.Prizes.Remove(existing);
                db.SaveChanges();
            }

            return result;
        }

        public PrizeModel SavePrizeModel(PrizeModel model)
        {
            model.ValidateModel();
            PrizeModel result = null;
            Prize dataModel = null;
            using (var db = new CFLSuiteDB())
            {
                if(model.PrizeID > 0)
                {
                    dataModel = db.Prizes.First(x => x.PrizeID == model.PrizeID);
                    dataModel.LosingParticipantID = model.LosingParticipantID;
                    dataModel.WinningParticipantID = model.WinningParticipantID;
                    dataModel.PrizeDescription = model.PrizeDescription;
                }
                else
                {
                    dataModel = new Prize
                    {
                        LosingParticipantID = model.LosingParticipantID,
                        WinningParticipantID = model.WinningParticipantID,
                        PrizeDescription = model.PrizeDescription
                    };
                    db.Prizes.Add(dataModel);
                }
                db.SaveChanges();
                result = db.Prizes.Where(x => x.PrizeID == dataModel.PrizeID).ToPrizeModel().First();
            }

            return result;
        }
    }
}
