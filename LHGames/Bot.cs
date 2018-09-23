using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LHGames.DataStructures;

namespace LHGames
{
    internal class Bot
    {
        internal IPlayer PlayerInfo { get; set; }
        private int currentDirection = 1;

        internal Bot() { }

        /// <summary>
        /// Gets called before ExecuteTurn. This is where you get your bot's state.
        /// </summary>
        /// <param name="playerInfo">Your bot's current state.</param>
        internal void BeforeTurn(IPlayer playerInfo)
        {
            PlayerInfo = playerInfo;
        }

        /// <summary>
        /// Implement your bot here.
        /// </summary>
        /// <param name="map">The gamemap.</param>
        /// <param name="visiblePlayers">Players that are visible to your bot.</param>
        /// <returns>The action you wish to execute.</returns>
        internal string ExecuteTurn(Map map, List<KeyValuePair<string, PublicPlayerInfo>> visiblePlayers)
        {
            // TODO: Implement your AI here.
            if (map.GetTileAt(PlayerInfo.Position.X + currentDirection, PlayerInfo.Position.Y) == TileContent.Wall)
            {
                currentDirection *= -1;
            }

            return AIHelper.CreateMoveAction(new Point(currentDirection, 0));
        }

        /// <summary>
        /// Gets called after ExecuteTurn.
        /// </summary>
        internal void AfterTurn()
        {
        }
    }
}
