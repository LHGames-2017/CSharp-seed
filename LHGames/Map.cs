using LHGames.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LHGames
{
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
                    Tiles[i, j] = new Tile(tileType, i + xMin, j + yMin);
                }
            }
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

        private void InitMapSize()
        {
            if (Tiles == null)
            {
                XMin = XMax = YMin = YMax = 0;
                VisibleDistance = 0;
            }
            else
            {
                XMin = Tiles[0, 0].X;
                YMin = Tiles[0, 0].Y;
                XMax = XMin + Tiles.GetLength(0);
                YMax = YMin + Tiles.GetLength(1);
                VisibleDistance = (XMax - XMin - 1) / 2;
            }
        }
    }
}
