using LHGames.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LHGames
{
    /// <summary>
    /// This class represents the GameMap.
    /// DO NOT MODIFY FUNCTIONS FROM THIS CLASS.
    /// </summary>
    internal class Map
    {
        private Tile[,] Tiles { get; set; }
        private int XMin { get; set; }
        private int YMin { get; set; }
        private int XMax { get; set; }
        private int YMax { get; set; }

        /// <summary>
        /// How far your Bot can see.
        /// </summary>
        public int VisibleDistance { get; set; }

        internal Map(string customSerializedMap, int xMin, int yMin)
        {
            XMin = xMin;
            YMin = yMin;
            DeserializeMap(customSerializedMap);
            InitMapSize();
        }

        /// <summary>
        /// Returns the TileType at this location. If you try to look outside 
        /// of your visible region, it will always return TileType.Tile. (Empty tile)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        internal TileType GetTileAt(int x, int y)
        {
            if (x < XMin || x > XMax || y < YMin || y > YMax)
            {
                return TileType.Tile;
            }
            return Tiles[x - XMin, y - YMin].TileType;
        }

        /// <summary>
        /// Deserialize the map received from the game server. 
        /// DO NOT MODIFY THIS.
        /// </summary>
        /// <param name="customSerializedMap">The received map.</param>
        private void DeserializeMap(string customSerializedMap)
        {
            customSerializedMap = customSerializedMap.Substring(1, customSerializedMap.Length - 2);
            var rows = customSerializedMap.Split('[');
            var column = rows[1].Split('{');
            Tiles = new Tile[rows.Length - 1, column.Length - 1];
            for (int i = 0; i < rows.Length - 1; i++)
            {
                column = rows[i + 1].Split('{');
                for (int j = 0; j < column.Length - 1; j++)
                {
                    var tileType = (byte)TileType.Tile;
                    if (column[j + 1][0] != '}')
                    {
                        var infos = column[j + 1].Split('}');
                        tileType = byte.Parse(infos[0]);
                    }
                    Tiles[i, j] = new Tile(tileType, i + XMin, j + YMin);
                }
            }
        }

        /// <summary>
        /// Initializes the XMax, YMax and VisibleDistance.
        /// </summary>
        private void InitMapSize()
        {
            if (Tiles == null)
            {
                throw new InvalidOperationException("Tiles cannot be null.");
            }

            XMax = XMin + Tiles.GetLength(0);
            YMax = YMin + Tiles.GetLength(1);
            VisibleDistance = (XMax - XMin - 1) / 2;
        }
    }
}
