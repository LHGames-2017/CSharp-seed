using StarterProject.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LHGames
{
    public static class MapHelper
    {
        public static Tile[,] DeserializeMap(string customSerializedMap)
        {
            customSerializedMap = customSerializedMap.Substring(1, customSerializedMap.Length - 1);
            var rows = customSerializedMap.Split('[');
            var column = rows[1].Split('{');
            var map = new Tile[rows.Length - 1, column.Length - 1];
            for (int i = 0; i < rows.Length - 1; i++)
            {
                column = rows[i + 1].Split('{');
                for (int j = 0; j < column.Length - 1; j++)
                {
                    var infos = column[j + 1].Split(',');
                    map[i, j] = new Tile(byte.Parse(infos[0]), int.Parse(infos[1]), int.Parse(infos[2].Substring(0, infos[2].IndexOf('}'))));
                }
            }
            return map;
        }
    }
}
