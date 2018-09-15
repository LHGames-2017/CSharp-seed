using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LHGames;
using LHGames.DataStructures;

namespace StarterProject.Web.Api.Controllers
{
    [Route("/")]
    public class GameController : Controller
    {
        Bot playerBot = new Bot();

        [HttpPost]
        public string Index([FromForm]string data)
        {
            if (data == null)
            {
                return "";
            }

            GameInfo gameInfo = JsonConvert.DeserializeObject<GameInfo>(data);
            playerBot.PlayerInfo = gameInfo.Player;

            var map = MapHelper.DeserializeMap(gameInfo.CustomSerializedMap, gameInfo.xMin, gameInfo.yMin);
            return playerBot.ExecuteTurn(map, gameInfo.OtherPlayers);
        }
    }
}
