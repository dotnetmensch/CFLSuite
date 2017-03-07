using CFLSuite.DataContracts;
using CFLSuite.DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.Data
{
    public class PlayerAccessor
    {
        public List<Player> GetPlayers()
        {
            var result = new List<Player>();
            using (var db = new CFLSuiteDB())
            {
                result = db.Players.ToList();
            }

            return result;
        }

        public Player SavePlayer(Player model)
        {
            model.ValidateModel();
            Player result = null;
            using (var db = new CFLSuiteDB())
            {
                var dup = db.Players.FirstOrDefault(x => x.Name == model.Name && x.PlayerID != model.PlayerID);
                if(dup == null)
                {
                    if (model.PlayerID < 0)
                    {
                        db.Players.Attach(model);
                        db.Entry(model).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Players.Add(model);
                    }
                }
                else
                {
                    throw new Exception("That player already exists.");
                }
                db.SaveChanges();
                result = model;
            }
            return result;
        }
    }
}
