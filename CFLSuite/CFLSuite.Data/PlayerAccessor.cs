using CFLSuite.DataContracts.Entities;
using System;
using System.Collections.Generic;
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
            Player result = null;
            using (var db = new CFLSuiteDB())
            {
                if(model.PlayerID < 0)
                {
                    var existing = db.Players.First(x => x.PlayerID == model.PlayerID);
                    existing.Name = model.Name;
                }
                else
                {
                    db.Players.Add(model);
                }
                db.SaveChanges();
                result = db.Players.First(x => x.PlayerID == model.PlayerID);
            }
            return result;
        }

        public Player DeletePlayer(Player model)
        {
            var result = model;
            using (var db = new CFLSuiteDB())
            {
                var existing = db.Players.First(x => x.PlayerID == model.PlayerID);
                db.Players.Remove(existing);
            }

            return result;
        }
    }
}
