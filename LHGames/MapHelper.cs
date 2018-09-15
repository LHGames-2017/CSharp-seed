using StarterProject.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LHGames.DataStructures;

namespace LHGames
{
    public static class MapHelper
    {
        public static Tile[,] DeserializeMap(string customSerializedMap, int xMin, int yMin)
        {
            customSerializedMap = customSerializedMap.Substring(1, customSerializedMap.Length - 2);
            var rows = customSerializedMap.Split('[');
            var column = rows[1].Split('{');
            var map = new Tile[rows.Length - 1, column.Length - 1];
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
                    map[i, j] = new Tile(tileType, i + xMin, j + yMin);
                }
            }
            return map;
        }
    }
}
