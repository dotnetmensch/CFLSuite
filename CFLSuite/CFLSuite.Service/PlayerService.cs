using CFLSuite.Data;
using CFLSuite.DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFLSuite.Service
{
    public class PlayerService
    {
        public List<Player> GetPlayers()
        {
            return new PlayerAccessor().GetPlayers();
        }

        public Player SavePlayer(Player model)
        {
            return new PlayerAccessor().SavePlayer(model);
        }

        public Player DeletePlayer(Player model)
        {
            return new PlayerAccessor().DeletePlayer(model);
        }
    }
}
