using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LHGames.DataStructures;

namespace LHGames
{
    public class Bot
    {
        public PrivatePlayerInfo PlayerInfo { get; set; }
        public Bot() { }

        public string ExecuteTurn(Tile[,] map, List<KeyValuePair<string, PublicPlayerInfo>> otherPlayers)
        {
            // TODO: Implement your AI here.
            return AIHelper.CreateMoveAction(new Point(1, 0));
            throw new NotImplementedException();
        }
    }
}
