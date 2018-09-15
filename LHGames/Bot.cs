using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarterProject.Web.Api;

namespace LHGames
{

    public class Bot
    {
        public PrivatePlayerInfo PlayerInfo { get; set; }

        public Bot(PrivatePlayerInfo info = null)
        {
            PlayerInfo = info;
        }

        public string ExecuteTurn(Tile[,] map, List<KeyValuePair<string, PublicPlayerInfo>> otherPlayers)
        {
            // TODO: Implement your AI here.
            return AIHelper.CreateMoveAction(new Point(1, 0));
            throw new NotImplementedException();
        }
    }
}
